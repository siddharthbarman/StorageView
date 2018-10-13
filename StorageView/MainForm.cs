using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace StorageView
{
	public partial class MainForm : Form
    {
        public MainForm() {
            InitializeComponent();			
        }

		private bool m_useETagCheck;
		private CloudBlobClient m_blobClient;
		private BlobRequestOptions m_blobRequestOptions = new BlobRequestOptions();
		private int m_blockSizeKB = 4;
		private const int IDX_STATUS = 8;
		private Dictionary<ListViewItem, string> m_leaseIds = new Dictionary<ListViewItem, string>();

		void Connect() {
			m_blobClient = null;
			ConnectForm form = new ConnectForm();

			if (ConfigurationManager.AppSettings["AccessKey"] != null)
				form.AccessKey = ConfigurationManager.AppSettings["AccessKey"];

			if (ConfigurationManager.AppSettings["StorageAccount"] != null)
				form.StorageAccount = ConfigurationManager.AppSettings["StorageAccount"];

			if (form.ShowDialog() == DialogResult.OK) {
				var creds = new StorageCredentials(form.StorageAccount, form.AccessKey);
				var acc = new CloudStorageAccount(creds, form.UseHttps);
				m_blobClient = acc.CreateCloudBlobClient();				
			}
		}

		void UploadFilesToBlob(IDictionary<string, string> metadata) {
			CloudBlobContainer container = (m_objectTree.SelectedNode.Tag as NodeWrapper)
				.Context as CloudBlobContainer;

			if (container == null) return;

			OpenFileDialog dlg = new OpenFileDialog {
				CheckFileExists = true,
				Multiselect = true,
				Title = "Select files to upload",
				ValidateNames = true
			};

			if (dlg.ShowDialog() == DialogResult.OK) {
				foreach(string file in dlg.FileNames) {
					UploadFileToBlob(file, container, metadata);
				}
			}
		}

		async void UploadFileToBlob(string file, CloudBlobContainer container, 
			IDictionary<string, string> metadata) {
			string name = Path.GetFileName(file);
			
			CloudBlockBlob blob = container.GetBlockBlobReference(name);
			
			if (blob.Exists()) {
				if (MessageBox.Show(string.Format("{0} blob exists in {1} container. Do you want to overwrite this blob with the new file?",
					name, container.Name), "Confirm", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.No) {
					return;
				}
				else {					
					await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.None, GetCommonAccessCondition(blob), 
						null, null);
				}
			}

			if (metadata != null && metadata.Count > 0) {
				CopyDictionary<string, string>(metadata, blob.Metadata);
			}

			Stopwatch sw = new Stopwatch();
			sw.Start();
			await blob.UploadFromFileAsync(file, new AccessCondition { IfNoneMatchETag = "*" }, 
				m_blobRequestOptions, CreateOperationContext(file));
			sw.Stop();			

			string status = string.Format("Uploaded in {0} ms", sw.ElapsedMilliseconds);
			WriteInfo("{0} uploaded in {1} ms", name, sw.ElapsedMilliseconds);
			ShowBlobInList(container, blob, "Uploaded", status);
		}

		async void UploadFileAsBlocks(CloudBlobContainer container, string file, int blockSizeKB) {
			if (!File.Exists(file)) {
				MessageBox.Show(string.Format("{0} file was not found!", file), "Error", MessageBoxButtons.OK, 
					MessageBoxIcon.Asterisk);
				return;
			}

			string blobName = Path.GetFileName(file);
			var blob = container.GetBlockBlobReference(blobName);
			if (blob.Exists()) {
				if (MessageBox.Show(string.Format("{0} blob exists in {1} container. Do you want to overwrite this blob with the new file?",
					blobName, container.Name), "Confirm", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.No) {
					return;
				}
				else {
					await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.None, GetCommonAccessCondition(blob),
						null, null);
				}
			}

			var blockIds = new List<string>();
			long bytesRead = 0;
			Stopwatch sw = new Stopwatch();
			
			using (FileStream fs = File.OpenRead(file)) {
				bool finished = false;
				int blockId = 0;
				int bufferSize = blockSizeKB * 1024;
				byte[] bytes = new byte[bufferSize];
				sw.Start();

				while (!finished) {
					int actualRead = fs.Read(bytes, (int)bytesRead, bufferSize);  //((fs.Length - bytesRead) < ((long)blockSizeKB * 1024)) ? (int)fs.Length - (int)bytesRead : blockSizeKB * 1024;
					finished =  actualRead < (blockSizeKB * 1024);					
					string blockIdStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(blockId.ToString().PadLeft(10, '0')));
					await blob.PutBlockAsync(blockIdStr, new MemoryStream(bytes, 0, actualRead), null);
					blockIds.Add(blockIdStr);
					blockId++;
				}
				
				// finalize the write
				await blob.PutBlockListAsync(blockIds);
				sw.Stop();

				string status = string.Format("Uploaded {0} blocks in {1} ms", blockIds.Count, 
					sw.ElapsedMilliseconds);
				WriteInfo("{0} uploaded in {1} ms", blobName, sw.ElapsedMilliseconds);
				ShowBlobInList(container, blob, "Uploaded", status);
			}
		}

		void UploadFileInMultipleBlocks() {
			CloudBlobContainer container = (m_objectTree.SelectedNode.Tag as NodeWrapper)
				.Context as CloudBlobContainer;

			if (container == null) return;

			BlockBlobUploadForm form = new BlockBlobUploadForm {
				BlockSizeKB = m_blockSizeKB
			};

			if (form.ShowDialog() == DialogResult.OK) {
				m_blockSizeKB = form.BlockSizeKB;
				UploadFileAsBlocks(container, form.SelectedFile, form.BlockSizeKB);
			}
		}

		void CopyDictionary<KeyT, ValueT>(IDictionary<KeyT, ValueT> from, IDictionary<KeyT, ValueT> to) {
			foreach(KeyT key in from.Keys) {
				to.Add(key, from[key]);
			}
		}

		void UploadFilesToBlobWithMetadata() {
			BlobPropertiesForm form = new BlobPropertiesForm();
			if (form.ShowDialog() == DialogResult.OK) {				
				UploadFilesToBlob(form.Pairs);
			}
		}

		OperationContext CreateOperationContext(string file) {
			OperationContext ctx = new OperationContext();
			ctx.CustomUserAgent = "Storage View";
			ctx.LogLevel = LogLevel.Verbose;
			ctx.RequestCompleted += (sender,  e) => {
				WriteInfoSafe("Req complete. Http status: {0}, bytes out: {1}, bytes in: {2}",
					e.RequestInformation.HttpStatusCode, e.RequestInformation.EgressBytes, e.RequestInformation.IngressBytes);
			};
			ctx.ResponseReceived += (sender, e) => {
				WriteInfoSafe("Resp recvd. Http status: {0}, bytes out: {1}, bytes in: {2}",
					e.RequestInformation.HttpStatusCode, e.RequestInformation.EgressBytes, e.RequestInformation.IngressBytes);
			};
			ctx.Retrying += (sender, e) => {
				WriteInfoSafe("Retrying. Http status: {0}, bytes out: {1}, bytes in: {2}",
					e.RequestInformation.HttpStatusCode, e.RequestInformation.EgressBytes, e.RequestInformation.IngressBytes);
			};
			ctx.SendingRequest += (sender, e) => {
				WriteInfoSafe("Sending req. Http status: {0}, bytes out: {1}, bytes in: {2}",
					e.RequestInformation.HttpStatusCode, e.RequestInformation.EgressBytes, e.RequestInformation.IngressBytes);
			};
			return ctx;
		}

		void WriteInfoSafe(string format, params object[] args) {
			this.Invoke((MethodInvoker) delegate {
				WriteInfo(format, args);
			});
		}

		void WriteInfo(string format, params object[] args) {
			string line = string.Format("{0} {1}", DateTime.Now.ToShortTimeString(),
				string.Format(format, args));
			m_txtInfo.Text = m_txtInfo.Text +  line + "\r\n";
		}

		void SetTreeNode(TreeNode node, int imageIndex, bool isLoaded = true, object context = null) {
			node.ImageIndex = imageIndex;
			node.SelectedImageIndex = imageIndex;
			node.Tag = new NodeWrapper(isLoaded, context);
		}

		void LoadContainers() {
			var containers = m_blobClient.ListContainers();
			m_objectTree.Nodes.Clear();

			TreeNode blobNode = m_objectTree.Nodes.Add("Blobs");
			SetTreeNode(blobNode, 0);
			
			TreeNode containersNode = blobNode.Nodes.Add("Containers");
			SetTreeNode(containersNode, 0);
			
			foreach (var container in containers) {
				TreeNode containerNode = containersNode.Nodes.Add(container.Name);
				SetTreeNode(containerNode, 1, false, container);				
			}
		}

		void CreateBlobColumns() {
			m_objectList.Clear();
			m_objectList.Columns.Add("Name", 300);
			m_objectList.Columns.Add("Type", 100);
			m_objectList.Columns.Add("Created", 100, HorizontalAlignment.Right);
			m_objectList.Columns.Add("ETag", 100);
			m_objectList.Columns.Add("Server Encrypted", 50, HorizontalAlignment.Right);
			m_objectList.Columns.Add("Modified", 100, HorizontalAlignment.Right);
			m_objectList.Columns.Add("Size", 100, HorizontalAlignment.Right);
			m_objectList.Columns.Add("Lease State", 70);
			m_objectList.Columns.Add("Lease Status", 70);
			m_objectList.Columns.Add("App Status", 100);
			m_objectList.Columns.Add("Message", 200);
		}

		string GetBlobNameOnly(CloudBlobContainer container, IListBlobItem item) {
			return item.Uri.LocalPath.Substring(container.Name.Length + 2);
		}
		
		void ShowBlobInList(CloudBlobContainer container, IListBlobItem blob, string status, string message = "") {			
			var item = m_objectList.Items.Add(GetBlobNameOnly(container, blob), 2);		
			item.SubItems.Add("Blob Item");
			item.SubItems.Add("");
			item.SubItems.Add("");
			item.SubItems.Add("");
			item.SubItems.Add("");
			item.SubItems.Add("");
			item.SubItems.Add("");
			item.SubItems.Add("");
			item.SubItems.Add("");
			item.SubItems.Add(status);
			item.SubItems.Add(message);			
			item.Tag = blob;
		}

		private void ShowBlobInList(CloudBlobContainer container, CloudBlob blob, string status, string message = "") {
			ListViewItem item = m_objectList.Items.Add(blob.Name, 2);
			item.Tag = blob;
			for (int n=1; n < m_objectList.Columns.Count; n++) {
				item.SubItems.Add("");
			}
			UpdateBlobInList(item, status, message);

			/*
			item.SubItems.Add(blob.BlobType.ToString());

			if (blob.Properties.Created.HasValue) 
				item.SubItems.Add(blob.Properties.Created.Value.ToLocalTime().ToString());
			else
				item.SubItems.Add("");
			
			item.SubItems.Add(blob.Properties.ETag);
			item.SubItems.Add(blob.Properties.IsServerEncrypted ? "Yes" : "No");
			
			if (blob.Properties.LastModified.HasValue)
				item.SubItems.Add(blob.Properties.LastModified.Value.ToLocalTime().ToString());
			else
				item.SubItems.Add("");

			item.SubItems.Add(blob.Properties.Length.ToString());
			item.SubItems.Add(blob.Properties.LeaseState.ToString());
			item.SubItems.Add(blob.Properties.LeaseStatus.ToString());
			item.SubItems.Add(status);
			item.SubItems.Add(message);
			*/
		}

		void UpdateBlobInList(ListViewItem listItem, string status = null, string message = null) {
			CloudBlob blob = listItem.Tag as CloudBlob;
			if (blob != null) {
				listItem.Text = blob.Name;
				listItem.SubItems[1].Text = blob.BlobType.ToString();

				if (blob.Properties.Created.HasValue)
					listItem.SubItems[2].Text = blob.Properties.Created.Value.ToLocalTime().ToString();
				else
					listItem.SubItems[2].Text = string.Empty;

				listItem.SubItems[3].Text = blob.Properties.ETag;
				listItem.SubItems[4].Text = blob.Properties.IsServerEncrypted ? "Yes" : "No";

				if (blob.Properties.LastModified.HasValue)
					listItem.SubItems[5].Text = blob.Properties.LastModified.Value.ToLocalTime().ToString();
				else
					listItem.SubItems[5].Text = "";

				listItem.SubItems[6].Text = blob.Properties.Length.ToString();
				listItem.SubItems[7].Text = blob.Properties.LeaseState.ToString();
				listItem.SubItems[8].Text = blob.Properties.LeaseStatus.ToString();
				listItem.SubItems[9].Text = status == null ? listItem.SubItems[9].Text : status;
				listItem.SubItems[10].Text = message == null ? listItem.SubItems[10].Text : message;				
			}
		}

		private void LoadContainerItems(CloudBlobContainer container) {			
			CreateBlobColumns();
			
			foreach (var blob in container.ListBlobs(null, true, BlobListingDetails.All, null)) {
				if (blob is CloudBlob) {
					ShowBlobInList(container, (CloudBlob)blob, "Available");
				}
				else {
					ShowBlobInList(container, blob, "Available");
				}
			}
		}

		private void ShowBlobSettings() {
			BlobSettingsForm form = new BlobSettingsForm();
			form.PropertyObject = m_blobRequestOptions;
			form.ShowDialog();
		}

		private void ViewBlobProperties() {
			if (m_objectList.SelectedItems.Count == 0)
				return;

			ListViewItem listItem = m_objectList.SelectedItems[0];
			CloudBlob blob = listItem.Tag as CloudBlob;
			if (blob != null && blob.Metadata != null) {
				BlobPropertiesForm form = new BlobPropertiesForm();
				CopyDictionary<string, string>(blob.Metadata, form.Pairs);

				CloudBlockBlob blockBlob = blob as CloudBlockBlob;
				if (blockBlob != null) {					
					form.Blocks = blockBlob.DownloadBlockList();
				}

				if (m_leaseIds.ContainsKey(listItem))
					form.LeaseID = m_leaseIds[listItem];

				form.LeaseState = blob.Properties.LeaseState;
				form.LeaseStatus = blob.Properties.LeaseStatus;

				if (form.ShowDialog() == DialogResult.OK) {
					bool changed = form.HasChanges;
				}
			}
		}

		private async void DeleteBlobs() {
			if (m_objectList.SelectedItems.Count == 0) return;
			foreach(ListViewItem item in m_objectList.SelectedItems) {
				CloudBlockBlob blob = item.Tag as CloudBlockBlob;
				if (blob != null) {
					await blob.DeleteAsync(DeleteSnapshotsOption.None, GetCommonAccessCondition(blob), null, null);
					item.SubItems[IDX_STATUS].Text = "Deleted";
				}
			}
		}

		AccessCondition GetCommonAccessCondition(CloudBlob blob) {
			if (m_useETagCheck) {
				return new AccessCondition {
					IfMatchETag = blob.Properties.ETag
				};
			}
			else {
				return null;
			}
		}

		private void DownloadBlobs() {
			if (m_objectList.SelectedItems.Count == 0) {
				MessageBox.Show("No blobs selected for download!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			FolderBrowserDialog dlg = new FolderBrowserDialog {
				Description = "Select the download location",
				ShowNewFolderButton = true				
			};

			if (dlg.ShowDialog() == DialogResult.OK) {
				// first make a copy of selected blobs so they don't change
				List<CloudBlob> blobs = new List<CloudBlob>();
				foreach(ListViewItem item in m_objectList.SelectedItems) {
					blobs.Add(item.Tag as CloudBlob);
				}
				
				foreach(var blob in blobs) {
					string downloadFile = Path.Combine(dlg.SelectedPath, blob.Name);
					if (File.Exists(downloadFile)) {
						WriteInfo("Skipping download of {0} as it exists", downloadFile);
						continue;
					}
					WriteInfo("Starting download of {0}", blob.Name);
					Stopwatch sw = new Stopwatch();
					sw.Start();
					blob.DownloadToFileAsync(downloadFile, FileMode.CreateNew, 
						GetCommonAccessCondition(blob), m_blobRequestOptions, CreateOperationContext(downloadFile));
					sw.Stop();
					WriteInfoSafe("{0} finished downloading. Time taken: {1} ms", blob.Name, sw.ElapsedMilliseconds);
				}
			}
		}

		private void RefreshView() {
			if (m_objectTree.SelectedNode == null)
				return;

			if (m_objectTree.SelectedNode.Tag != null) {
				NodeWrapper nw = m_objectTree.SelectedNode.Tag as NodeWrapper;
				if (nw.Context == null)
					return;
				if (nw.Context is CloudBlobContainer) {
					LoadContainerItems(nw.Context as CloudBlobContainer);
					nw.IsLoaded = true;
				}
			}
		}

		async void TakeLease() {
			if (m_objectList.SelectedItems.Count == 0) {
				MessageBox.Show("No items have been selected for leasing", "Error", MessageBoxButtons.OK, 
					MessageBoxIcon.Warning);
				return;
			}

			LeaseForm form = new LeaseForm();
			if (form.ShowDialog() != DialogResult.OK)
				return;

			foreach(ListViewItem item in m_objectList.SelectedItems) {
				CloudBlob blob = item.Tag as CloudBlob;
				if (blob != null) {
					string proposedLeaseId = Guid.NewGuid().ToString();
					string leaseId = await blob.AcquireLeaseAsync(form.LeasePeriod, proposedLeaseId, null, null, null);
					m_leaseIds.Add(item, leaseId);
					string msg = string.Format("Lease (id={0}) has been obtained on {1}", leaseId, blob.Name);
					WriteInfo(msg);
					await blob.FetchAttributesAsync();
					UpdateBlobInList(item, "Leased", msg);
				}
			}
		}

		async void ReleaseLease() {
			if (m_objectList.SelectedItems.Count == 0) {
				MessageBox.Show("No items have been selected for releasing", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			List<ListViewItem> releasedItems = new List<ListViewItem>();

			foreach(ListViewItem item in m_leaseIds.Keys) {
				string leaseId = m_leaseIds[item];
				CloudBlob blob = item.Tag as CloudBlob;
				if (blob != null) {
					await blob.ReleaseLeaseAsync(new AccessCondition { LeaseId = leaseId });
					string msg = string.Format("Lease has been released from {0}", blob.Name);
					WriteInfo(msg);
					await blob.FetchAttributesAsync();
					UpdateBlobInList(item, "Released lease", msg);
					releasedItems.Add(item);
				}
			}

			foreach(ListViewItem item in releasedItems) {
				m_leaseIds.Remove(item);
			}
		}

		void ShowAbout() {
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}

		void CreateAppendBlob() {
			CloudBlobContainer container = (m_objectTree.SelectedNode.Tag as NodeWrapper)
				.Context as CloudBlobContainer;

			if (container == null)
				return;

			InputForm form = new InputForm("Enter a name for the append blob",
				"Info needed");

			if (form.ShowDialog() == DialogResult.OK) {
				if (string.IsNullOrEmpty(form.InputText)) {
					MessageBox.Show("Invalid blob name specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				CloudAppendBlob blob = container.GetAppendBlobReference(form.InputText);
				if (blob.Exists()) {
					MessageBox.Show("Specified blob already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				blob.CreateOrReplaceAsync();
				ShowBlobInList(container, blob, "Created");
			}
		}

		void AppendTextToBlob(string text, CloudAppendBlob blob, string leaseId) {
			Stopwatch sw = new Stopwatch();
			sw.Start();
			if (!string.IsNullOrEmpty(leaseId)) {
				blob.AppendText(text, null, new AccessCondition { LeaseId = leaseId });
			}
			else {
				blob.AppendText(text);
			}
			sw.Stop();
			WriteInfo("Append text length {0} in {1} ms", text.Length, sw.ElapsedMilliseconds);
		}

		void AppendTextDataToAppendBlob() {
			if (m_objectList.SelectedItems.Count == 0)
				return;

			ListViewItem listItem = m_objectList.SelectedItems[0];
			CloudAppendBlob blob = listItem.Tag as CloudAppendBlob;
			if (blob == null) {
				string msg = string.Format("The selected blob {0} is not an append blob!", listItem.Text);
				MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			InputForm form = new InputForm("Enter data to append to blob", "Input data", "Enter something");
			if (form.ShowDialog() == DialogResult.OK) {
				if (string.IsNullOrEmpty(form.InputText)) {
					MessageBox.Show("No data entered to append!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				string leaseId = m_mnuUseLease.Checked && m_leaseIds.ContainsKey(listItem) ? m_leaseIds[listItem] : null;
				AppendTextToBlob(form.InputText, blob, leaseId);
				blob.FetchAttributes();
				UpdateBlobInList(listItem, null, "Appended text");
			}
		}
				
		void AppendFileDataToAppendBlob() {
			if (m_objectList.SelectedItems.Count == 0)
				return;

			ListViewItem listItem = m_objectList.SelectedItems[0];
			CloudAppendBlob blob = listItem.Tag as CloudAppendBlob;
			if (blob == null) {
				string msg = string.Format("The selected blob {0} is not an append blob!", listItem.Text);
				MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			OpenFileDialog dlg = new OpenFileDialog {
				AddExtension = false,
				CheckFileExists = true,
				CheckPathExists = true,
				DefaultExt = "txt",
				Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
				FilterIndex = 0,
				Multiselect = false,
				ShowReadOnly = true,
				Title = "Select text file to append"
			};
			if (dlg.ShowDialog() == DialogResult.OK) {
				using (TextReader tr = File.OpenText(dlg.FileName)) {
					string text = tr.ReadToEnd();
					string leaseId = m_mnuUseLease.Checked && m_leaseIds.ContainsKey(listItem) ? m_leaseIds[listItem] : null;
					AppendTextToBlob(text, blob, leaseId);
					blob.FetchAttributes();
					UpdateBlobInList(listItem, null, "Appended text");
				}
			}
		}

		async void RenameBlob() {
			CloudBlobContainer container = (m_objectTree.SelectedNode.Tag as NodeWrapper)
				.Context as CloudBlobContainer;

			if (container == null) {
				MessageBox.Show("The selected container is not a blob container", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			if (m_objectList.SelectedItems.Count == 0)
				return;

			ListViewItem listItem = m_objectList.SelectedItems[0];
			CloudBlob blob = listItem.Tag as CloudAppendBlob;
			if (blob == null) {
				MessageBox.Show("Selected item is not a blob!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			InputForm inputForm = new InputForm("Enter the new name", "Rename", "", false);
			if (inputForm.ShowDialog() == DialogResult.OK) {
				string newName = inputForm.InputText;
				CloudBlob newBlob = container.GetBlobReference(newName);
				if (newBlob.Exists()) {
					MessageBox.Show("A blob by the specified name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);					
				}
				else {
					Stopwatch sw = new Stopwatch();
					sw.Start();
					await newBlob.StartCopyAsync(blob.Uri);
					sw.Stop();
					string msg = string.Format("Renamed blob {0} to {1} in {2} ms", blob.Name, newBlob.Name, sw.ElapsedMilliseconds);
					WriteInfo(msg);
					await newBlob.FetchAttributesAsync();
					listItem.Tag = newBlob;
					UpdateBlobInList(listItem, "Renamed", msg);
				}
			}
		}

		private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
			Connect();
			if (m_blobClient != null) LoadContainers();
		}

		private void m_toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

		}

		private void m_objectTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
			if (e.Node.Tag != null) {
				NodeWrapper nw = e.Node.Tag as NodeWrapper;
				if (nw.Context == null)
					return;
				if (nw.Context is CloudBlobContainer && nw.IsLoaded == false) {
					LoadContainerItems(nw.Context as CloudBlobContainer);
					nw.IsLoaded = true;
				}
			}
		}

		private void MainForm_Load(object sender, EventArgs e) {
			m_useETagCheck = m_mnuBlobCheckETags.Checked;
		}

		private void m_mnuFileExit_Click(object sender, EventArgs e) {
			Close();
		}

		private void mnuBlobUploadFiles_Click(object sender, EventArgs e) {
			UploadFilesToBlob(null);
		}

		private void m_mnuBlobSettings_Click(object sender, EventArgs e) {
			ShowBlobSettings();
		}

		private void m_mnuBlobViewProperties_Click(object sender, EventArgs e) {
			ViewBlobProperties();
		}

		private void m_mnuBlobsDelete_Click(object sender, EventArgs e) {
			DeleteBlobs();
		}

		private void mnuViewRefresh_Click(object sender, EventArgs e) {
			RefreshView();
		}

		private void m_mnuUploadWithMetadata_Click(object sender, EventArgs e) {
			UploadFilesToBlobWithMetadata();
		}

		private void m_mnuBlobCheckETags_CheckedChanged(object sender, EventArgs e) {
			m_useETagCheck = m_mnuBlobCheckETags.Checked;			
		}

		private void m_mnuDownloadBlobs_Click(object sender, EventArgs e) {
			DownloadBlobs();
		}

		private void mnuUploadFileInBlocks_Click(object sender, EventArgs e) {
			UploadFileInMultipleBlocks();
		}

		private void mnuBlobTakeLease_Click(object sender, EventArgs e) {
			TakeLease();
		}

		private void mnuBlobReleaseLease_Click(object sender, EventArgs e) {
			ReleaseLease();
		}

		private void m_mnuHelpAbout_Click(object sender, EventArgs e) {
			ShowAbout();
		}

		private void m_mnuBlobsCreateAppendBlob_Click(object sender, EventArgs e) {
			CreateAppendBlob();
		}

		private void m_mnuBlobsAppendTextData_Click(object sender, EventArgs e) {
			AppendTextDataToAppendBlob();
		}

		private void m_mnuAppendTextFromFile_Click(object sender, EventArgs e) {
			AppendFileDataToAppendBlob();
		}

		private void m_blobRename_Click(object sender, EventArgs e) {
			RenameBlob();
		}
	}
}
