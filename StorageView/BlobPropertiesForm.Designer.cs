namespace StorageView
{
	partial class BlobPropertiesForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlobPropertiesForm));
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_blobPropertiesTabs = new System.Windows.Forms.TabControl();
			this.m_metadataTab = new System.Windows.Forms.TabPage();
			this.lblInfo = new System.Windows.Forms.Label();
			this.m_dataGrid = new System.Windows.Forms.DataGridView();
			this.m_blocksTab = new System.Windows.Forms.TabPage();
			this.m_blockList = new System.Windows.Forms.ListView();
			this.m_colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.m_colLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.m_colCommitted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.m_leaseTab = new System.Windows.Forms.TabPage();
			this.m_txtLeaseID = new System.Windows.Forms.TextBox();
			this.m_txtLeaseState = new System.Windows.Forms.TextBox();
			this.m_txtLeaseStatus = new System.Windows.Forms.TextBox();
			this.m_lblLeaseID = new System.Windows.Forms.Label();
			this.m_lblLeasesState = new System.Windows.Forms.Label();
			this.m_lblLeaseStatus = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.m_blobPropertiesTabs.SuspendLayout();
			this.m_metadataTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).BeginInit();
			this.m_blocksTab.SuspendLayout();
			this.m_leaseTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnCancel.Location = new System.Drawing.Point(256, 349);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 26);
			this.m_btnCancel.TabIndex = 8;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// m_btnOK
			// 
			this.m_btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnOK.Location = new System.Drawing.Point(178, 349);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 26);
			this.m_btnOK.TabIndex = 7;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// m_blobPropertiesTabs
			// 
			this.m_blobPropertiesTabs.Controls.Add(this.m_metadataTab);
			this.m_blobPropertiesTabs.Controls.Add(this.m_blocksTab);
			this.m_blobPropertiesTabs.Controls.Add(this.m_leaseTab);
			this.m_blobPropertiesTabs.Location = new System.Drawing.Point(6, 12);
			this.m_blobPropertiesTabs.Name = "m_blobPropertiesTabs";
			this.m_blobPropertiesTabs.SelectedIndex = 0;
			this.m_blobPropertiesTabs.Size = new System.Drawing.Size(331, 330);
			this.m_blobPropertiesTabs.TabIndex = 9;
			// 
			// m_metadataTab
			// 
			this.m_metadataTab.Controls.Add(this.lblInfo);
			this.m_metadataTab.Controls.Add(this.m_dataGrid);
			this.m_metadataTab.Location = new System.Drawing.Point(4, 22);
			this.m_metadataTab.Name = "m_metadataTab";
			this.m_metadataTab.Padding = new System.Windows.Forms.Padding(3);
			this.m_metadataTab.Size = new System.Drawing.Size(323, 304);
			this.m_metadataTab.TabIndex = 0;
			this.m_metadataTab.Text = "Metadata";
			this.m_metadataTab.UseVisualStyleBackColor = true;
			// 
			// lblInfo
			// 
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(8, 8);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(238, 15);
			this.lblInfo.TabIndex = 3;
			this.lblInfo.Text = "Enter the metadata name and value pairs: ";
			// 
			// m_dataGrid
			// 
			this.m_dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_dataGrid.Location = new System.Drawing.Point(11, 30);
			this.m_dataGrid.Name = "m_dataGrid";
			this.m_dataGrid.Size = new System.Drawing.Size(306, 275);
			this.m_dataGrid.TabIndex = 2;
			// 
			// m_blocksTab
			// 
			this.m_blocksTab.Controls.Add(this.m_blockList);
			this.m_blocksTab.Location = new System.Drawing.Point(4, 22);
			this.m_blocksTab.Name = "m_blocksTab";
			this.m_blocksTab.Padding = new System.Windows.Forms.Padding(3);
			this.m_blocksTab.Size = new System.Drawing.Size(323, 304);
			this.m_blocksTab.TabIndex = 1;
			this.m_blocksTab.Text = "Blocks";
			this.m_blocksTab.UseVisualStyleBackColor = true;
			// 
			// m_blockList
			// 
			this.m_blockList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colName,
            this.m_colLength,
            this.m_colCommitted});
			this.m_blockList.Location = new System.Drawing.Point(6, 6);
			this.m_blockList.Name = "m_blockList";
			this.m_blockList.Size = new System.Drawing.Size(311, 299);
			this.m_blockList.TabIndex = 0;
			this.m_blockList.UseCompatibleStateImageBehavior = false;
			this.m_blockList.View = System.Windows.Forms.View.Details;
			// 
			// m_colName
			// 
			this.m_colName.Text = "Name";
			this.m_colName.Width = 120;
			// 
			// m_colLength
			// 
			this.m_colLength.Text = "Length";
			this.m_colLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_colLength.Width = 80;
			// 
			// m_colCommitted
			// 
			this.m_colCommitted.Text = "Committed";
			this.m_colCommitted.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_colCommitted.Width = 80;
			// 
			// m_leaseTab
			// 
			this.m_leaseTab.Controls.Add(this.m_txtLeaseID);
			this.m_leaseTab.Controls.Add(this.m_txtLeaseState);
			this.m_leaseTab.Controls.Add(this.m_txtLeaseStatus);
			this.m_leaseTab.Controls.Add(this.m_lblLeaseID);
			this.m_leaseTab.Controls.Add(this.m_lblLeasesState);
			this.m_leaseTab.Controls.Add(this.m_lblLeaseStatus);
			this.m_leaseTab.Location = new System.Drawing.Point(4, 22);
			this.m_leaseTab.Name = "m_leaseTab";
			this.m_leaseTab.Padding = new System.Windows.Forms.Padding(3);
			this.m_leaseTab.Size = new System.Drawing.Size(323, 304);
			this.m_leaseTab.TabIndex = 2;
			this.m_leaseTab.Text = "Lease";
			this.m_leaseTab.UseVisualStyleBackColor = true;
			// 
			// m_txtLeaseID
			// 
			this.m_txtLeaseID.BackColor = System.Drawing.Color.White;
			this.m_txtLeaseID.Location = new System.Drawing.Point(90, 64);
			this.m_txtLeaseID.Name = "m_txtLeaseID";
			this.m_txtLeaseID.ReadOnly = true;
			this.m_txtLeaseID.Size = new System.Drawing.Size(204, 20);
			this.m_txtLeaseID.TabIndex = 5;
			// 
			// m_txtLeaseState
			// 
			this.m_txtLeaseState.BackColor = System.Drawing.Color.White;
			this.m_txtLeaseState.Location = new System.Drawing.Point(90, 38);
			this.m_txtLeaseState.Name = "m_txtLeaseState";
			this.m_txtLeaseState.ReadOnly = true;
			this.m_txtLeaseState.Size = new System.Drawing.Size(204, 20);
			this.m_txtLeaseState.TabIndex = 4;
			// 
			// m_txtLeaseStatus
			// 
			this.m_txtLeaseStatus.BackColor = System.Drawing.Color.White;
			this.m_txtLeaseStatus.Location = new System.Drawing.Point(90, 12);
			this.m_txtLeaseStatus.Name = "m_txtLeaseStatus";
			this.m_txtLeaseStatus.ReadOnly = true;
			this.m_txtLeaseStatus.Size = new System.Drawing.Size(204, 20);
			this.m_txtLeaseStatus.TabIndex = 3;
			// 
			// m_lblLeaseID
			// 
			this.m_lblLeaseID.AutoSize = true;
			this.m_lblLeaseID.Location = new System.Drawing.Point(11, 63);
			this.m_lblLeaseID.Name = "m_lblLeaseID";
			this.m_lblLeaseID.Size = new System.Drawing.Size(62, 15);
			this.m_lblLeaseID.TabIndex = 2;
			this.m_lblLeaseID.Text = "Lease ID: ";
			// 
			// m_lblLeasesState
			// 
			this.m_lblLeasesState.AutoSize = true;
			this.m_lblLeasesState.Location = new System.Drawing.Point(11, 37);
			this.m_lblLeasesState.Name = "m_lblLeasesState";
			this.m_lblLeasesState.Size = new System.Drawing.Size(76, 15);
			this.m_lblLeasesState.TabIndex = 1;
			this.m_lblLeasesState.Text = "Lease state: ";
			// 
			// m_lblLeaseStatus
			// 
			this.m_lblLeaseStatus.AutoSize = true;
			this.m_lblLeaseStatus.Location = new System.Drawing.Point(11, 13);
			this.m_lblLeaseStatus.Name = "m_lblLeaseStatus";
			this.m_lblLeaseStatus.Size = new System.Drawing.Size(82, 15);
			this.m_lblLeaseStatus.TabIndex = 0;
			this.m_lblLeaseStatus.Text = "Lease status: ";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(9, 344);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(33, 31);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// BlobPropertiesForm
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(340, 383);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.m_blobPropertiesTabs);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BlobPropertiesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Blob Properties";
			this.Load += new System.EventHandler(this.NameVauleForm_Load);
			this.m_blobPropertiesTabs.ResumeLayout(false);
			this.m_metadataTab.ResumeLayout(false);
			this.m_metadataTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).EndInit();
			this.m_blocksTab.ResumeLayout(false);
			this.m_leaseTab.ResumeLayout(false);
			this.m_leaseTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.TabControl m_blobPropertiesTabs;
		private System.Windows.Forms.TabPage m_metadataTab;
		private System.Windows.Forms.TabPage m_blocksTab;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.DataGridView m_dataGrid;
		private System.Windows.Forms.ListView m_blockList;
		private System.Windows.Forms.ColumnHeader m_colName;
		private System.Windows.Forms.ColumnHeader m_colLength;
		private System.Windows.Forms.ColumnHeader m_colCommitted;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TabPage m_leaseTab;
		private System.Windows.Forms.Label m_lblLeaseStatus;
		private System.Windows.Forms.Label m_lblLeaseID;
		private System.Windows.Forms.Label m_lblLeasesState;
		private System.Windows.Forms.TextBox m_txtLeaseID;
		private System.Windows.Forms.TextBox m_txtLeaseState;
		private System.Windows.Forms.TextBox m_txtLeaseStatus;
	}
}