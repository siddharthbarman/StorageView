using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using Microsoft.WindowsAzure.Storage.Table;
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

		#region Fields
				
		private CloudBlobClient m_blobClient;
		private CloudTableClient m_storageTableClient;
		private CloudQueueClient m_queueClient;
        private CloudFileClient m_fileClient;
		private BlobRequestOptions m_blobRequestOptions = new BlobRequestOptions();
		private int m_blockSizeKB = 4;
		private int m_peekMessageCount = 32; // This is the max allowed!
		private Dictionary<ListViewItem, string> m_leaseIds = new Dictionary<ListViewItem, string>();

		private TreeNode m_blobNode;
		private TreeNode m_tableNode;
		private TreeNode m_queueNode;
		private TreeNode m_filesNode;
		private TreeNode m_blobContainersNode;

		private const int IDX_STATUS = 8;
		private const int IMG_STORAGE_STACK = 0;
		private const int IMG_FOLDER = 1;
		private const int IMG_BLOB_STORAGE = 2;
		private const int IMG_STORAGE = 3;
		private const int IMG_STORAGE_TABLE = 4;
		private const int IMG_STORAGE_QUEUE = 5;
		private const int IMG_FILES_SHARES = 6;
		private const int IMG_SHARE_FOLDER = 7;

		bool TrackOperationContext {
			get { return m_mnuTrackOperationContext.Checked; }
		}

		bool CheckETag {
			get { return m_mnuBlobCheckETags.Checked; }
		}

		#endregion

		#region General methods

		DialogResult ConfirmYesNo(string title, string text, params object[] args) {
			string str = string.Format(text, args);
			return MessageBox.Show(str, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		void ShowError(string title, string text, params object[] args) {
			string str = string.Format(text, args);
			MessageBox.Show(str, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		OperationContext CreateOperationContextIfNeeded() {
			if (TrackOperationContext) {
				OperationContext ctx = new OperationContext();
				ctx.CustomUserAgent = "Storage View";
				ctx.LogLevel = LogLevel.Verbose;
				ctx.RequestCompleted += (sender, e) => {
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
			else {
				return null;
			}
		}

		void WriteInfoSafe(string format, params object[] args) {
			this.Invoke((MethodInvoker)delegate {
				WriteInfo(format, args);
			});
		}

		void WriteInfo(string format, params object[] args) {
			string line = string.Format("{0} {1}", DateTime.Now.ToShortTimeString(),
				string.Format(format, args));
			m_txtInfo.Text = m_txtInfo.Text + line + "\r\n";
		}

		void SetTreeNode(TreeNode node, int imageIndex, bool isLoaded = true, object context = null) {
			node.ImageIndex = imageIndex;
			node.SelectedImageIndex = imageIndex;
			node.Tag = new NodeWrapper(isLoaded, context);
		}

		void Connect() {
			m_blobClient = null;
			m_storageTableClient = null;
			m_queueClient = null;
            m_fileClient = null;

			ConnectForm form = new ConnectForm();

			if (ConfigurationManager.AppSettings["AccessKey"] != null)
				form.AccessKey = ConfigurationManager.AppSettings["AccessKey"];

			if (ConfigurationManager.AppSettings["StorageAccount"] != null)
				form.StorageAccount = ConfigurationManager.AppSettings["StorageAccount"];

			if (form.ShowDialog() == DialogResult.OK) {
				var creds = new StorageCredentials(form.StorageAccount, form.AccessKey);
				var acc = new CloudStorageAccount(creds, form.UseHttps);

				m_blobClient = acc.CreateCloudBlobClient();
				m_storageTableClient = acc.CreateCloudTableClient();
				m_queueClient = acc.CreateCloudQueueClient();
                m_fileClient = acc.CreateCloudFileClient();
                
				CreateTopLevelNodes();
			}
		}

		void CreateTopLevelNodes() {
			m_objectTree.Nodes.Clear();

			m_blobNode = m_objectTree.Nodes.Add("Blobs");
			SetTreeNode(m_blobNode, IMG_BLOB_STORAGE);

			m_tableNode = m_objectTree.Nodes.Add("Tables");
			SetTreeNode(m_tableNode, IMG_STORAGE_TABLE);

			m_queueNode = m_objectTree.Nodes.Add("Queues");
			SetTreeNode(m_tableNode, IMG_STORAGE_QUEUE);

			m_filesNode = m_objectTree.Nodes.Add("Files");
			SetTreeNode(m_filesNode, IMG_FILES_SHARES);
		}

		void HandleTreeNodeSelection(NodeWrapper nw, TreeNode node) {
			if (nw.Context == null)
				return;
			if (nw.Context is CloudBlobContainer && nw.IsLoaded == false) {
				LoadContainerItems(nw.Context as CloudBlobContainer);
				nw.IsLoaded = true;
			}
			else if (nw.Context is CloudTable) {
				LoadTableItems(nw.Context as CloudTable);
			}
			else if (nw.Context is CloudQueue) {
				LoadQueueItems(nw.Context as CloudQueue);
			}
			else if (nw.Context is CloudFileShare) {
				LoadFileShareFiles(nw.Context as CloudFileShare, node);
				nw.IsLoaded = true;
			}
			else if (nw.Context is CloudFileDirectory) {
				LoadFileShareDirectoryFiles(node);

			}
		}

		void LoadContainers() {
			LoadBlobContainers();
			LoadTables();
			LoadQueues();
			LoadFileShares();
		}

		void RefreshView() {
			if (m_objectTree.SelectedNode == null)
				return;

			NodeWrapper nw = m_objectTree.SelectedNode.Tag as NodeWrapper;
			if (nw.Context == null) {
				return;
			}
			else if (nw.Context is CloudBlobContainer) {
				LoadContainerItems(nw.Context as CloudBlobContainer);
				nw.IsLoaded = true;
			}
			else if (nw.Context is CloudTable) {
				LoadTableItems(nw.Context as CloudTable);
			}
			else if (nw.Context is CloudFileShare || nw.Context is CloudFileDirectory) {
				LoadFileShareDirectoryFiles(m_objectTree.SelectedNode);
			}
		}

		void ShowAbout() {
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}

		#endregion

		#region Block Blob methods 

		void CreateBlobContainer() {
			NameWithMetadataForm form = new NameWithMetadataForm {
				Title = "New Blob Container",
				DoNotAllowEmptyName = false
			};

			if (form.ShowDialog() == DialogResult.OK) {
				string name = form.EntityName;
				CloudBlobContainer container = m_blobClient.GetContainerReference(name);
				if (container.Exists(null, CreateOperationContextIfNeeded())) {
					ShowError("The container {0} already exists!", name);
					return;
				}

				container.CreateIfNotExists();
				TreeNode containerNode = m_blobContainersNode.Nodes.Add(container.Name);
				SetTreeNode(containerNode, 1, false, container);
			}
		}

		void CreateBlobView() {
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

		void LoadBlobContainers() {
			var containers = m_blobClient.ListContainers();
			m_blobNode.Nodes.Clear();
			m_blobContainersNode = m_blobNode.Nodes.Add("Containers");
			SetTreeNode(m_blobContainersNode, IMG_BLOB_STORAGE);

			foreach (var container in containers) {
				TreeNode containerNode = m_blobContainersNode.Nodes.Add(container.Name);
				SetTreeNode(containerNode, 1, false, container);
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
				m_blobRequestOptions, CreateOperationContextIfNeeded());
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
			for (int n = 1; n < m_objectList.Columns.Count; n++) {
				item.SubItems.Add("");
			}
			UpdateBlobInList(item, status, message);
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
			CreateBlobView();

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
			foreach (ListViewItem item in m_objectList.SelectedItems) {
				CloudBlockBlob blob = item.Tag as CloudBlockBlob;
				if (blob != null) {
					await blob.DeleteAsync(DeleteSnapshotsOption.None, GetCommonAccessCondition(blob), null, null);
					item.SubItems[IDX_STATUS].Text = "Deleted";
				}
			}
		}

		AccessCondition GetCommonAccessCondition(CloudBlob blob) {
			if (CheckETag) {
				return new AccessCondition {
					IfMatchETag = blob.Properties.ETag
				};
			}
			else {
				return null;
			}
		}

		void DownloadBlobs() {
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
				foreach (ListViewItem item in m_objectList.SelectedItems) {
					blobs.Add(item.Tag as CloudBlob);
				}

				foreach (var blob in blobs) {
					string downloadFile = Path.Combine(dlg.SelectedPath, blob.Name);
					if (File.Exists(downloadFile)) {
						WriteInfo("Skipping download of {0} as it exists", downloadFile);
						continue;
					}
					WriteInfo("Starting download of {0}", blob.Name);
					Stopwatch sw = new Stopwatch();
					sw.Start();
					blob.DownloadToFileAsync(downloadFile, FileMode.CreateNew,
						GetCommonAccessCondition(blob), m_blobRequestOptions, CreateOperationContextIfNeeded());
					sw.Stop();
					WriteInfoSafe("{0} finished downloading. Time taken: {1} ms", blob.Name, sw.ElapsedMilliseconds);
				}
			}
		}

		#endregion

		#region Append blob methods

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

		async void TakeLease() {
			if (m_objectList.SelectedItems.Count == 0) {
				MessageBox.Show("No items have been selected for leasing", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			LeaseForm form = new LeaseForm();
			if (form.ShowDialog() != DialogResult.OK)
				return;

			foreach (ListViewItem item in m_objectList.SelectedItems) {
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

			foreach (ListViewItem item in m_leaseIds.Keys) {
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

			foreach (ListViewItem item in releasedItems) {
				m_leaseIds.Remove(item);
			}
		}

		#endregion

		#region Storage Table methods

		void CreateTableView() {
			m_objectList.Clear();
			m_objectList.Columns.Add("PartitionKey", 100);
			m_objectList.Columns.Add("RowKey", 100);
			m_objectList.Columns.Add("ETag", 100);
			m_objectList.Columns.Add("TimeStamp", 100);
		}

		void LoadTables() {
			OperationContext ctx = CreateOperationContextIfNeeded();
			IEnumerable<CloudTable> tables = m_storageTableClient.ListTables(null, null, ctx);
			m_tableNode.Nodes.Clear();
			foreach (CloudTable table in tables) {
				TreeNode node = m_tableNode.Nodes.Add(table.Name);
				node.Tag = new NodeWrapper(false, table);
			}
		}

		void CreateStorageTable() {
			if (m_storageTableClient == null) return;
			InputForm form = new InputForm("Enter a name for the storage table", "New Table", "", false);
			if (form.ShowDialog() == DialogResult.OK) {
				string table = form.InputText;
				m_storageTableClient.GetTableReference(table).CreateIfNotExists(null,
					CreateOperationContextIfNeeded());
				LoadTables();
			}
		}

		int TABLE_PARTITIONKEY_INDEX = 0;
		int TABLE_ROWKEY_INDEX = 1;
		int TABLE_ETAG_INDEX = 2;
		int TABLE_TIMESTAMP_INDEX = 3;

		void LoadTableItems(CloudTable table) {
			CreateTableView();
			Dictionary<string, int> properties = new Dictionary<string, int>();
			TableQuery q = new TableQuery();
			List<DynamicTableEntity> entities = new List<DynamicTableEntity>();
			TableRequestOptions options = null;
			var result = table.ExecuteQuery(q, options, CreateOperationContextIfNeeded());
			entities.AddRange(result);

			foreach (var entity in entities) {
				foreach (var prop in entity.Properties) {
					if (!properties.ContainsKey(prop.Key)) {
						ColumnHeader hdr = m_objectList.Columns.Add(prop.Key, 100);
						properties.Add(prop.Key, hdr.Index);
					}
				}
			}

			foreach (var entity in entities) {
				var listItem = m_objectList.Items.Add(entity.PartitionKey);
				listItem.SubItems.Add(entity.RowKey);
				listItem.SubItems.Add(entity.ETag);
				listItem.SubItems.Add(entity.Timestamp.ToString());
				listItem.Tag = entity;

				for (int n = 4; n < m_objectList.Columns.Count; n++) {
					listItem.SubItems.Add("");
				}

				foreach (var keyValues in entity.Properties) {
					listItem.SubItems[properties[keyValues.Key]].Text = GetPropertyValue(keyValues.Value);
				}
			}
		}

		public string GetPropertyValue(EntityProperty prop) {
			string result;
			switch (prop.PropertyType) {
				case EdmType.Binary:
					result = "<BINARY DATA>";
					break;

				case EdmType.Boolean:
					result = prop.BooleanValue.ToString();
					break;

				case EdmType.DateTime:
					result = prop.DateTime.ToString();
					break;

				case EdmType.Double:
					result = prop.DoubleValue.ToString();
					break;

				case EdmType.Guid:
					result = prop.GuidValue.ToString();
					break;

				case EdmType.Int32:
					result = prop.Int32Value.ToString();
					break;

				case EdmType.Int64:
					result = prop.Int64Value.ToString();
					break;

				case EdmType.String:
					result = prop.StringValue;
					break;

				default:
					result = "<UNKNOWN>";
					break;
			}
			return result;
		}

		void InsertSampleTableItems(CloudTable table) {
			TableBatchOperation batch = new TableBatchOperation();
			batch.InsertOrReplace(new Book("9781312871342", "Swami Yoganadna", "Autobiography of a Yogi", 1946, "English"));
			batch.InsertOrReplace(new Book("1462917925", "Bruce Lee", "Bruce Lee Striking Thoughts: Bruce Lee's Wisdom for Daily Living", 2002, "English"));
			batch.InsertOrReplace(new Book("0007480687", "Mark Twain", "The Adventures of Tom Sawyer", 1876, "English"));
			table.ExecuteBatch(batch, null, CreateOperationContextIfNeeded());

			batch = new TableBatchOperation();
			batch.InsertOrReplace(new Book("9788446033677", "Bonifacio del Carril", "El Principito", 1951, "Spanish"));
			table.ExecuteBatch(batch, null, CreateOperationContextIfNeeded());
		}

		void DeleteTableEntities() {
			if (m_storageTableClient == null || m_objectList.SelectedItems.Count == 0) return;
			NodeWrapper node = (NodeWrapper)m_objectTree.SelectedNode.Tag;
			CloudTable table = node.Context as CloudTable;
			if (table == null) return;

			TableBatchOperation batch = new TableBatchOperation();
			foreach (ListViewItem item in m_objectList.SelectedItems) {
				DynamicTableEntity entity = item.Tag as DynamicTableEntity;
				if (entity != null) {
					batch.Delete(entity);
				}
			}

			if (MessageBox.Show(string.Format("Are you sure you want to delete {0} items?",
				batch.Count), "Confirm Delete", MessageBoxButtons.YesNo, 
				MessageBoxIcon.Question) == DialogResult.Yes) {
				table.ExecuteBatch(batch, null, CreateOperationContextIfNeeded());	
			}

			LoadTableItems(table);
		}

		#endregion

		#region Storage queue methods

		void CreateQueueView() {
			m_objectList.Clear();
			m_objectList.Columns.Add("Id", 100);
			m_objectList.Columns.Add("Insertion Time", 100);
			m_objectList.Columns.Add("Expiration Time", 100);
			m_objectList.Columns.Add("Next Visible Time", 100);
			m_objectList.Columns.Add("Deque Count", 100);
			m_objectList.Columns.Add("String Value", 100);
			m_objectList.Columns.Add("Byte Size", 100);			
		}

		void CreateQueue() {
			if (m_queueClient == null) return;
			InputForm form = new InputForm("Enter the name of the queue", "Create Queue", "", false);
			if (form.ShowDialog() == DialogResult.OK) {
				string queueName = form.InputText;
				CloudQueue queue = m_queueClient.GetQueueReference(queueName);
				queue.Create(null, CreateOperationContextIfNeeded());
				m_queueNode.Nodes.Add(queueName).Tag = new NodeWrapper(false, queue);
			}
		}

		void LoadQueues() {
			if (m_queueClient == null) return;
			m_queueNode.Nodes.Clear();

			IEnumerable<CloudQueue> queues = m_queueClient.ListQueues(null, QueueListingDetails.All, null, CreateOperationContextIfNeeded());
			foreach(var queue in queues) {
				m_queueNode.Nodes.Add(queue.Name).Tag = new NodeWrapper(false, queue);
			}
		}

		void AddMessageToList(CloudQueueMessage message) {
			ListViewItem item = m_objectList.Items.Add(message.Id);
			item.SubItems.Add(message.InsertionTime.HasValue ? message.InsertionTime.ToString() : "Not Available");
			item.SubItems.Add(message.ExpirationTime.HasValue ? message.ExpirationTime.ToString() : "Not Available");
			item.SubItems.Add(message.NextVisibleTime.HasValue ? message.NextVisibleTime.ToString() : "Not Available");
			item.SubItems.Add(message.DequeueCount.ToString());
			item.SubItems.Add(message.AsString != null ? message.AsString : "Not Available");
			item.SubItems.Add(message.AsBytes != null ? message.AsBytes.Length.ToString() : "Not Available");
		}
			   
		void LoadQueueItems(CloudQueue queue) {
			CreateQueueView();
			var messages = queue.PeekMessages(m_peekMessageCount, null, CreateOperationContextIfNeeded());
			foreach(CloudQueueMessage message in messages) {
				AddMessageToList(message);				
			}
		}

		void AddQueueMessage() {
			if (m_queueClient == null) return;
			CloudQueue queue = ((NodeWrapper)m_objectTree.SelectedNode.Tag).Context as CloudQueue;
			if (queue == null) return;

			QueueMessageForm form = new QueueMessageForm();
			if (form.ShowDialog() == DialogResult.OK) {
				if (form.MessageType == MessageSendTypes.Text) {
					queue.AddMessage(new CloudQueueMessage(form.MessageText), form.TTL, form.Delay);
				}
				else {
					byte[] bytes = File.ReadAllBytes(form.FilePath);
					queue.AddMessage(new CloudQueueMessage(bytes), form.TTL, form.Delay);
				}
			}			
		}

		void DequeueMessages() {
			CloudQueue queue = ((NodeWrapper)m_objectTree.SelectedNode.Tag).Context as CloudQueue;
			if (queue != null) {
				InputForm form = new InputForm("Enter the number of messages to dequeue. Note: items will be removed from the queue.", 
					"Dequeue", "10", false);
				if (form.ShowDialog() == DialogResult.OK) {
					if (!int.TryParse(form.InputText, out int count)) {
						MessageBox.Show("Invalid count specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					IEnumerable<CloudQueueMessage> messages = queue.GetMessages(count, null, null, CreateOperationContextIfNeeded());
					m_objectList.Items.Clear();
					foreach (var message in messages) {
						AddMessageToList(message);
					}
				}
			}
		}

		void ClearQueue() {
			if (m_queueClient == null) return;
			CloudQueue queue = ((NodeWrapper)m_objectTree.SelectedNode.Tag).Context as CloudQueue;
			if (queue == null) return;
			if (ConfirmYesNo("Confirm", "Are you sure you want to clear the queue '{0}'?", 
				queue.Name) == DialogResult.Yes) {
				queue.Clear(null, CreateOperationContextIfNeeded());
				LoadQueueItems(queue);
			}
		}

        #endregion

        #region File methods

		void LoadFileShares() {
			m_filesNode.Nodes.Clear();
			foreach(var share in m_fileClient.ListShares(null, ShareListingDetails.All, null, CreateOperationContextIfNeeded())) {
				TreeNode node = m_filesNode.Nodes.Add(share.Name);
				SetTreeNode(node, IMG_SHARE_FOLDER, false, share);
			}
		}

        void CreateFileShare() {
            InputForm form = new InputForm("Enter the name of the new file share", "New Share", "newshare", false);
            if (form.ShowDialog() == DialogResult.OK) {
				string name = form.InputText;
				CloudFileShare share = m_fileClient.GetShareReference(name);
				if (share.Exists(null, CreateOperationContextIfNeeded())) {
					ShowError("File Share", "The file share {0} already exists!", name);					
				}
				else {
					if (share.CreateIfNotExists(null, CreateOperationContextIfNeeded())) {
						TreeNode node = m_filesNode.Nodes.Add(share.Name);
						SetTreeNode(node, IMG_SHARE_FOLDER, false, share);
					}
					else {
						ShowError("Error", "Failed to create share named {0}", name);
					}
				}
            }            
        }

		void CreateShareView() {
			m_objectList.Clear();
			m_objectList.Columns.Add("Name", 100);
			m_objectList.Columns.Add("Size (Bytes)", 100);
			m_objectList.Columns.Add("Uri", 100);			
		}

		void LoadFileShareFiles(CloudFileShare share, TreeNode node) {
			CloudFileDirectory root = share.GetRootDirectoryReference();			
			IEnumerable<IListFileItem> items = root.ListFilesAndDirectories(null, CreateOperationContextIfNeeded());
			CreateShareView();
			ListFilesAndDirectories(node, items);
		}

		void LoadFileShareDirectoryFiles(TreeNode node) {
			NodeWrapper nw = (NodeWrapper)node.Tag;
			CloudFileDirectory dir = null;
			if (nw.Context is CloudFileShare) {
				dir = (nw.Context as CloudFileShare).GetRootDirectoryReference();
			}
			else if (nw.Context is CloudFileDirectory) {
				dir = (CloudFileDirectory)nw.Context;
			}

			if (dir != null) { 
				CreateShareView();
				ListFilesAndDirectories(node, dir.ListFilesAndDirectories(null, CreateOperationContextIfNeeded()));				
			}
		}

		void ListCloudFile(CloudFile cloudFile) {
			ListViewItem item = m_objectList.Items.Add(cloudFile.Name);
			item.SubItems.Add(cloudFile.Properties.Length.ToString());
			item.SubItems.Add(cloudFile.Uri.AbsolutePath);
			item.Tag = cloudFile;
		}

		void ListFilesAndDirectories(TreeNode parentNode, IEnumerable<IListFileItem> items) {
			foreach (var cloudItem in items) {
				CloudFile cloudFile = cloudItem as CloudFile;
				if (cloudFile != null) {
					ListCloudFile(cloudFile);
				}
				else {
					CloudFileDirectory cloudDir = cloudItem as CloudFileDirectory;
					if (cloudDir != null && (parentNode.Tag as NodeWrapper).IsLoaded == false) {
						TreeNode dirNode = parentNode.Nodes.Add(cloudDir.Name);
						SetTreeNode(dirNode, IMG_FOLDER, false, cloudDir);
					}
				}
			}
		}

		void CreateShareDirectory() {
			CloudFileShare share = (m_objectTree.SelectedNode.Tag as NodeWrapper).Context as CloudFileShare;
			CloudFileDirectory dir = null;
			if (share != null) {				
				dir = share.GetRootDirectoryReference();				
			}			
			else {
				dir = (m_objectTree.SelectedNode.Tag as NodeWrapper).Context as CloudFileDirectory;
			}

			if (dir != null) {
				InputForm form = new InputForm("Enter the directory name", "New Directory", "folder", false);
				if (form.ShowDialog() == DialogResult.OK) {
					string directoryName = form.InputText;
					CloudFileDirectory newDir = dir.GetDirectoryReference(directoryName);
					if (newDir.Exists()) {
						ShowError("Exists", "The specified directory '{0}' already exists!", directoryName);
						return;
					}
					newDir.Create(null, CreateOperationContextIfNeeded());
					SetTreeNode(m_objectTree.SelectedNode.Nodes.Add(directoryName), IMG_FOLDER, false, newDir);
				}
			}
		}

		async void UploadShareFile() {
			NodeWrapper nw = m_objectTree.SelectedNode.Tag as NodeWrapper;
			CloudFileShare share = nw.Context as CloudFileShare;
			CloudFileDirectory dir = null;
			if (share != null) {
				dir = share.GetRootDirectoryReference();
			}
			else {
				dir = nw.Context as CloudFileDirectory;
				if (dir == null) {
					ShowError("Invalid Object", "Select a File-share or a directory under a file share first!");
					return;
				}
			}

			OpenFileDialog dlg = new OpenFileDialog {
				CheckFileExists = true,
				Multiselect = false,
				Title = "Select files to upload",
				ValidateNames = true
			};

			if (dlg.ShowDialog() == DialogResult.OK) {
				string filename = Path.GetFileName(dlg.FileName);
				string filepath = dlg.FileName;
				CloudFile file = dir.GetFileReference(filename);
				if (file.Exists()) {
					if (ConfirmYesNo("File exists", "The file {0} already exists, do you want to overwrite it?", 
						filename) == DialogResult.No) {
						return;
					}
					file.Delete(null, null, CreateOperationContextIfNeeded());
				}				

				using (FileStream localStream = File.OpenRead(filepath)) {					
					using (CloudFileStream cloudStream = file.OpenWrite(localStream.Length, null, null, CreateOperationContextIfNeeded())) {
						int bufferSize = m_blockSizeKB * 1024;
						byte[] bytes = new byte[bufferSize];						
						int bytesRead = localStream.Read(bytes, 0, bufferSize);
						while (bytesRead > 0) {
							await cloudStream.WriteAsync(bytes, 0, bytesRead);							
							bytesRead = localStream.Read(bytes, 0, bufferSize);
						}
						cloudStream.Close();
					}
				}

				ListCloudFile(file);
			}
		}

		async void DeleteShareFiles() {
			if (m_objectList.SelectedItems.Count == 0) return;
			List<KeyValuePair<ListViewItem, CloudFile>> files = new List<KeyValuePair<ListViewItem, CloudFile>>();
			foreach(ListViewItem item in m_objectList.SelectedItems) {
				if (item.Tag is CloudFile) files.Add(new KeyValuePair<ListViewItem, CloudFile>(item, (CloudFile)item.Tag));
			}

			if (files.Count > 0) {
				if (ConfirmYesNo("Confirm Delete", "Are you sure you want to delete these {0} files?", files.Count) 
					== DialogResult.No) {
					return;
				}
			}

			foreach(KeyValuePair<ListViewItem, CloudFile> deleteItem  in files) {
				await deleteItem.Value.DeleteAsync();
				m_objectList.Items.Remove(deleteItem.Key);
			}
		}

		void DeleteShareDirectory() {
			if (m_objectTree.SelectedNode == null) return;
			NodeWrapper nw = (NodeWrapper)(m_objectTree.SelectedNode.Tag);
			CloudFileDirectory dir = nw.Context as CloudFileDirectory;
			if (dir != null) {
				dir.DeleteIfExists();
				m_objectTree.Nodes.Remove(m_objectTree.SelectedNode);
			}
		}

		void DeleteShare() {
			if (m_objectTree.SelectedNode == null) return;
			NodeWrapper nw = (NodeWrapper)(m_objectTree.SelectedNode.Tag);
			CloudFileShare share = nw.Context as CloudFileShare;
			if (share != null) {
				if (ConfirmYesNo("Confirm Delete", "Are you sure you want to delete the fileshare '{0}'?", 
					share.Name) == DialogResult.Yes) {
					share.Delete(null, null, CreateOperationContextIfNeeded());
					m_objectTree.Nodes.Remove(m_objectTree.SelectedNode);
				}
			}
		}

		#endregion

		private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
			Connect();
			if (m_blobClient != null) LoadContainers();
		}

		private void m_toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

		}

		private void MainForm_Load(object sender, EventArgs e) {
			m_mnuBlobCheckETags.Checked = true;
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

		private void m_mnuInsertSampleEntities_Click(object sender, EventArgs e) {
			if (m_objectTree.SelectedNode == null) return;			
			CloudTable table = ((NodeWrapper)m_objectTree.SelectedNode.Tag).Context as CloudTable;
			if (table == null) return;			
			if (MessageBox.Show(string.Format("Clicking 'Yes' will insert sample 'Book' entities in your table '{0}'. Do you want to continue?",
				table.Name), "Confirm", MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.Yes) {
				InsertSampleTableItems(table);
			}			
		}

		private void m_createStorageTable_Click(object sender, EventArgs e) {
			CreateStorageTable();
		}

		private void m_mnuDeleteEntity_Click(object sender, EventArgs e) {
			DeleteTableEntities();
		}

		private void m_mnuCreateQueue_Click(object sender, EventArgs e) {
			CreateQueue();
		}

		private void m_mnuClearQueue_Click(object sender, EventArgs e) {
			ClearQueue();
		}

		private void m_addQueueMessage_Click(object sender, EventArgs e) {
			AddQueueMessage();
		}

		private void m_mnuDequeueMessage_Click(object sender, EventArgs e) {
			DequeueMessages();
		}

		private void m_objectTree_AfterSelect(object sender, TreeViewEventArgs e) {
			if (e.Node.Tag != null) {
				NodeWrapper nw = e.Node.Tag as NodeWrapper;
				HandleTreeNodeSelection(nw, e.Node);
			}
		}

		private void m_mnuCreateBlobContainer_Click(object sender, EventArgs e) {
			CreateBlobContainer();
		}

        private void mnuFileShareCreate_Click(object sender, EventArgs e)
        {
            CreateFileShare();
        }

		private void m_mnuCreateShareDirectory_Click(object sender, EventArgs e) {
			CreateShareDirectory();
		}

		private void m_mnuUploadShareFile_Click(object sender, EventArgs e) {
			UploadShareFile();
		}

		private void deleteFilesToolStripMenuItem_Click(object sender, EventArgs e) {
			DeleteShareFiles();
		}

		private void m_mnuShareDeleteDirectory_Click(object sender, EventArgs e) {
			DeleteShareDirectory();
		}

		private void m_mnuFileShareDeleteShare_Click(object sender, EventArgs e) {
			DeleteShare();
		}
	}
}
