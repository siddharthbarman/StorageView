namespace StorageView
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.m_menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.m_mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuBlobs = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuBlobUploadFiles = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuUploadWithMetadata = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuUploadFileInBlocks = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuUploadAppendBlob = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.m_mnuAppendBlobs = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuBlobsCreateAppendBlob = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuBlobsAppendTextData = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuAppendTextFromFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.m_mnuDownloadBlobs = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuBlobViewProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuBlobTakeLease = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuBlobReleaseLease = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuBlobsDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.m_mnuBlobSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.m_mnuBlobCheckETags = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.m_splitter = new System.Windows.Forms.SplitContainer();
			this.m_objectTree = new System.Windows.Forms.TreeView();
			this.m_imageList = new System.Windows.Forms.ImageList(this.components);
			this.m_objectList = new System.Windows.Forms.ListView();
			this.m_txtInfo = new System.Windows.Forms.TextBox();
			this.m_blobRename = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.m_mnuUseLease = new System.Windows.Forms.ToolStripMenuItem();
			this.m_menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_splitter)).BeginInit();
			this.m_splitter.Panel1.SuspendLayout();
			this.m_splitter.Panel2.SuspendLayout();
			this.m_splitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_menuStrip
			// 
			this.m_menuStrip.BackColor = System.Drawing.Color.White;
			this.m_menuStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.m_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.m_mnuBlobs,
            this.viewToolStripMenuItem,
            this.m_mnuHelp});
			this.m_menuStrip.Location = new System.Drawing.Point(0, 0);
			this.m_menuStrip.Name = "m_menuStrip";
			this.m_menuStrip.Size = new System.Drawing.Size(800, 27);
			this.m_menuStrip.TabIndex = 0;
			this.m_menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.toolStripMenuItem1,
            this.m_mnuFileExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// connectToolStripMenuItem
			// 
			this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
			this.connectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.connectToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
			this.connectToolStripMenuItem.Text = "&Connect...";
			this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
			// 
			// m_mnuFileExit
			// 
			this.m_mnuFileExit.Name = "m_mnuFileExit";
			this.m_mnuFileExit.Size = new System.Drawing.Size(194, 24);
			this.m_mnuFileExit.Text = "E&xit";
			this.m_mnuFileExit.Click += new System.EventHandler(this.m_mnuFileExit_Click);
			// 
			// m_mnuBlobs
			// 
			this.m_mnuBlobs.CheckOnClick = true;
			this.m_mnuBlobs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBlobUploadFiles,
            this.m_mnuUploadWithMetadata,
            this.mnuUploadFileInBlocks,
            this.mnuUploadAppendBlob,
            this.toolStripSeparator2,
            this.m_mnuAppendBlobs,
            this.toolStripSeparator4,
            this.m_mnuDownloadBlobs,
            this.m_mnuBlobViewProperties,
            this.toolStripSeparator3,
            this.m_blobRename,
            this.mnuBlobTakeLease,
            this.mnuBlobReleaseLease,
            this.m_mnuBlobsDelete,
            this.toolStripMenuItem2,
            this.m_mnuBlobSettings,
            this.toolStripSeparator1,
            this.m_mnuBlobCheckETags});
			this.m_mnuBlobs.Name = "m_mnuBlobs";
			this.m_mnuBlobs.Size = new System.Drawing.Size(54, 23);
			this.m_mnuBlobs.Text = "&Blobs";
			// 
			// mnuBlobUploadFiles
			// 
			this.mnuBlobUploadFiles.Name = "mnuBlobUploadFiles";
			this.mnuBlobUploadFiles.Size = new System.Drawing.Size(313, 24);
			this.mnuBlobUploadFiles.Text = "Upload &Files as Blobs...";
			this.mnuBlobUploadFiles.Click += new System.EventHandler(this.mnuBlobUploadFiles_Click);
			// 
			// m_mnuUploadWithMetadata
			// 
			this.m_mnuUploadWithMetadata.Name = "m_mnuUploadWithMetadata";
			this.m_mnuUploadWithMetadata.Size = new System.Drawing.Size(313, 24);
			this.m_mnuUploadWithMetadata.Text = "Upload Files as Blobs With &Metadata...";
			this.m_mnuUploadWithMetadata.Click += new System.EventHandler(this.m_mnuUploadWithMetadata_Click);
			// 
			// mnuUploadFileInBlocks
			// 
			this.mnuUploadFileInBlocks.Name = "mnuUploadFileInBlocks";
			this.mnuUploadFileInBlocks.Size = new System.Drawing.Size(313, 24);
			this.mnuUploadFileInBlocks.Text = "Upload File in &Multiple Blocks";
			this.mnuUploadFileInBlocks.Click += new System.EventHandler(this.mnuUploadFileInBlocks_Click);
			// 
			// mnuUploadAppendBlob
			// 
			this.mnuUploadAppendBlob.Name = "mnuUploadAppendBlob";
			this.mnuUploadAppendBlob.Size = new System.Drawing.Size(313, 24);
			this.mnuUploadAppendBlob.Text = "Upload File as &Append Blob";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(310, 6);
			// 
			// m_mnuAppendBlobs
			// 
			this.m_mnuAppendBlobs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuBlobsCreateAppendBlob,
            this.m_mnuBlobsAppendTextData,
            this.m_mnuAppendTextFromFile,
            this.toolStripMenuItem3,
            this.m_mnuUseLease});
			this.m_mnuAppendBlobs.Name = "m_mnuAppendBlobs";
			this.m_mnuAppendBlobs.Size = new System.Drawing.Size(313, 24);
			this.m_mnuAppendBlobs.Text = "Append Blobs";
			// 
			// m_mnuBlobsCreateAppendBlob
			// 
			this.m_mnuBlobsCreateAppendBlob.Name = "m_mnuBlobsCreateAppendBlob";
			this.m_mnuBlobsCreateAppendBlob.Size = new System.Drawing.Size(216, 24);
			this.m_mnuBlobsCreateAppendBlob.Text = "Create A&ppend Blob";
			this.m_mnuBlobsCreateAppendBlob.Click += new System.EventHandler(this.m_mnuBlobsCreateAppendBlob_Click);
			// 
			// m_mnuBlobsAppendTextData
			// 
			this.m_mnuBlobsAppendTextData.Name = "m_mnuBlobsAppendTextData";
			this.m_mnuBlobsAppendTextData.Size = new System.Drawing.Size(216, 24);
			this.m_mnuBlobsAppendTextData.Text = "Append &Text Data";
			this.m_mnuBlobsAppendTextData.Click += new System.EventHandler(this.m_mnuBlobsAppendTextData_Click);
			// 
			// m_mnuAppendTextFromFile
			// 
			this.m_mnuAppendTextFromFile.Name = "m_mnuAppendTextFromFile";
			this.m_mnuAppendTextFromFile.Size = new System.Drawing.Size(216, 24);
			this.m_mnuAppendTextFromFile.Text = "Append Text From &File";
			this.m_mnuAppendTextFromFile.Click += new System.EventHandler(this.m_mnuAppendTextFromFile_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(310, 6);
			// 
			// m_mnuDownloadBlobs
			// 
			this.m_mnuDownloadBlobs.Name = "m_mnuDownloadBlobs";
			this.m_mnuDownloadBlobs.Size = new System.Drawing.Size(313, 24);
			this.m_mnuDownloadBlobs.Text = "Download...";
			this.m_mnuDownloadBlobs.Click += new System.EventHandler(this.m_mnuDownloadBlobs_Click);
			// 
			// m_mnuBlobViewProperties
			// 
			this.m_mnuBlobViewProperties.Name = "m_mnuBlobViewProperties";
			this.m_mnuBlobViewProperties.Size = new System.Drawing.Size(313, 24);
			this.m_mnuBlobViewProperties.Text = "View &Properties...";
			this.m_mnuBlobViewProperties.Click += new System.EventHandler(this.m_mnuBlobViewProperties_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(310, 6);
			// 
			// mnuBlobTakeLease
			// 
			this.mnuBlobTakeLease.Name = "mnuBlobTakeLease";
			this.mnuBlobTakeLease.Size = new System.Drawing.Size(313, 24);
			this.mnuBlobTakeLease.Text = "Take &Lease";
			this.mnuBlobTakeLease.Click += new System.EventHandler(this.mnuBlobTakeLease_Click);
			// 
			// mnuBlobReleaseLease
			// 
			this.mnuBlobReleaseLease.Name = "mnuBlobReleaseLease";
			this.mnuBlobReleaseLease.Size = new System.Drawing.Size(313, 24);
			this.mnuBlobReleaseLease.Text = "&Release Lease";
			this.mnuBlobReleaseLease.Click += new System.EventHandler(this.mnuBlobReleaseLease_Click);
			// 
			// m_mnuBlobsDelete
			// 
			this.m_mnuBlobsDelete.Name = "m_mnuBlobsDelete";
			this.m_mnuBlobsDelete.Size = new System.Drawing.Size(313, 24);
			this.m_mnuBlobsDelete.Text = "&Delete";
			this.m_mnuBlobsDelete.Click += new System.EventHandler(this.m_mnuBlobsDelete_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(310, 6);
			// 
			// m_mnuBlobSettings
			// 
			this.m_mnuBlobSettings.Name = "m_mnuBlobSettings";
			this.m_mnuBlobSettings.Size = new System.Drawing.Size(313, 24);
			this.m_mnuBlobSettings.Text = "&Settings";
			this.m_mnuBlobSettings.Click += new System.EventHandler(this.m_mnuBlobSettings_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(310, 6);
			// 
			// m_mnuBlobCheckETags
			// 
			this.m_mnuBlobCheckETags.Checked = true;
			this.m_mnuBlobCheckETags.CheckOnClick = true;
			this.m_mnuBlobCheckETags.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_mnuBlobCheckETags.Name = "m_mnuBlobCheckETags";
			this.m_mnuBlobCheckETags.Size = new System.Drawing.Size(313, 24);
			this.m_mnuBlobCheckETags.Text = "Check ETags";
			this.m_mnuBlobCheckETags.CheckedChanged += new System.EventHandler(this.m_mnuBlobCheckETags_CheckedChanged);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewRefresh});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(50, 23);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// mnuViewRefresh
			// 
			this.mnuViewRefresh.Name = "mnuViewRefresh";
			this.mnuViewRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.mnuViewRefresh.Size = new System.Drawing.Size(194, 24);
			this.mnuViewRefresh.Text = "&Refresh";
			this.mnuViewRefresh.Click += new System.EventHandler(this.mnuViewRefresh_Click);
			// 
			// m_mnuHelp
			// 
			this.m_mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuHelpAbout});
			this.m_mnuHelp.Name = "m_mnuHelp";
			this.m_mnuHelp.Size = new System.Drawing.Size(49, 23);
			this.m_mnuHelp.Text = "&Help";
			// 
			// m_mnuHelpAbout
			// 
			this.m_mnuHelpAbout.Name = "m_mnuHelpAbout";
			this.m_mnuHelpAbout.Size = new System.Drawing.Size(127, 24);
			this.m_mnuHelpAbout.Text = "&About...";
			this.m_mnuHelpAbout.Click += new System.EventHandler(this.m_mnuHelpAbout_Click);
			// 
			// m_splitter
			// 
			this.m_splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_splitter.Location = new System.Drawing.Point(0, 27);
			this.m_splitter.Name = "m_splitter";
			// 
			// m_splitter.Panel1
			// 
			this.m_splitter.Panel1.Controls.Add(this.m_objectTree);
			// 
			// m_splitter.Panel2
			// 
			this.m_splitter.Panel2.Controls.Add(this.m_objectList);
			this.m_splitter.Size = new System.Drawing.Size(800, 412);
			this.m_splitter.SplitterDistance = 198;
			this.m_splitter.SplitterWidth = 3;
			this.m_splitter.TabIndex = 3;
			// 
			// m_objectTree
			// 
			this.m_objectTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_objectTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_objectTree.ImageIndex = 0;
			this.m_objectTree.ImageList = this.m_imageList;
			this.m_objectTree.Location = new System.Drawing.Point(3, 0);
			this.m_objectTree.Name = "m_objectTree";
			this.m_objectTree.SelectedImageIndex = 0;
			this.m_objectTree.Size = new System.Drawing.Size(193, 311);
			this.m_objectTree.TabIndex = 0;
			this.m_objectTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_objectTree_NodeMouseClick);
			// 
			// m_imageList
			// 
			this.m_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageList.ImageStream")));
			this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.m_imageList.Images.SetKeyName(0, "Storage.png");
			this.m_imageList.Images.SetKeyName(1, "Folder.png");
			this.m_imageList.Images.SetKeyName(2, "Azure Storage - Blob.png");
			this.m_imageList.Images.SetKeyName(3, "Azure Storage.png");
			// 
			// m_objectList
			// 
			this.m_objectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_objectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_objectList.FullRowSelect = true;
			this.m_objectList.Location = new System.Drawing.Point(0, 0);
			this.m_objectList.Name = "m_objectList";
			this.m_objectList.Size = new System.Drawing.Size(604, 311);
			this.m_objectList.SmallImageList = this.m_imageList;
			this.m_objectList.TabIndex = 0;
			this.m_objectList.UseCompatibleStateImageBehavior = false;
			this.m_objectList.View = System.Windows.Forms.View.Details;
			// 
			// m_txtInfo
			// 
			this.m_txtInfo.BackColor = System.Drawing.Color.White;
			this.m_txtInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_txtInfo.Font = new System.Drawing.Font("Consolas", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_txtInfo.Location = new System.Drawing.Point(0, 341);
			this.m_txtInfo.Multiline = true;
			this.m_txtInfo.Name = "m_txtInfo";
			this.m_txtInfo.ReadOnly = true;
			this.m_txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.m_txtInfo.Size = new System.Drawing.Size(800, 98);
			this.m_txtInfo.TabIndex = 4;
			this.m_txtInfo.WordWrap = false;
			// 
			// m_blobRename
			// 
			this.m_blobRename.Name = "m_blobRename";
			this.m_blobRename.Size = new System.Drawing.Size(313, 24);
			this.m_blobRename.Text = "&Rename";
			this.m_blobRename.Click += new System.EventHandler(this.m_blobRename_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(213, 6);
			// 
			// m_mnuUseLease
			// 
			this.m_mnuUseLease.CheckOnClick = true;
			this.m_mnuUseLease.Name = "m_mnuUseLease";
			this.m_mnuUseLease.Size = new System.Drawing.Size(216, 24);
			this.m_mnuUseLease.Text = "Use &Lease If Available";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(800, 439);
			this.Controls.Add(this.m_txtInfo);
			this.Controls.Add(this.m_splitter);
			this.Controls.Add(this.m_menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.m_menuStrip;
			this.Name = "MainForm";
			this.Text = "Storage View";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.m_menuStrip.ResumeLayout(false);
			this.m_menuStrip.PerformLayout();
			this.m_splitter.Panel1.ResumeLayout(false);
			this.m_splitter.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_splitter)).EndInit();
			this.m_splitter.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip m_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
		private System.Windows.Forms.SplitContainer m_splitter;
		private System.Windows.Forms.TreeView m_objectTree;
		private System.Windows.Forms.ListView m_objectList;
		private System.Windows.Forms.ImageList m_imageList;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem m_mnuFileExit;
		private System.Windows.Forms.ToolStripMenuItem m_mnuBlobs;
		private System.Windows.Forms.ToolStripMenuItem mnuBlobUploadFiles;
		private System.Windows.Forms.TextBox m_txtInfo;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem m_mnuBlobSettings;
		private System.Windows.Forms.ToolStripMenuItem m_mnuBlobViewProperties;
		private System.Windows.Forms.ToolStripMenuItem m_mnuBlobCheckETags;
		private System.Windows.Forms.ToolStripMenuItem m_mnuBlobsDelete;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuViewRefresh;
		private System.Windows.Forms.ToolStripMenuItem m_mnuUploadWithMetadata;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem m_mnuDownloadBlobs;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem mnuUploadFileInBlocks;
		private System.Windows.Forms.ToolStripMenuItem mnuUploadAppendBlob;
		private System.Windows.Forms.ToolStripMenuItem m_mnuHelp;
		private System.Windows.Forms.ToolStripMenuItem m_mnuHelpAbout;
		private System.Windows.Forms.ToolStripMenuItem mnuBlobTakeLease;
		private System.Windows.Forms.ToolStripMenuItem mnuBlobReleaseLease;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem m_mnuAppendBlobs;
		private System.Windows.Forms.ToolStripMenuItem m_mnuBlobsCreateAppendBlob;
		private System.Windows.Forms.ToolStripMenuItem m_mnuBlobsAppendTextData;
		private System.Windows.Forms.ToolStripMenuItem m_mnuAppendTextFromFile;
		private System.Windows.Forms.ToolStripMenuItem m_blobRename;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem m_mnuUseLease;
	}
}

