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
			this.m_mnuCreateBlobContainer = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuBlobUploadFiles = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuUploadWithMetadata = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuUploadFileInBlocks = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuUploadAppendBlob = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.m_mnuAppendBlobs = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuBlobsCreateAppendBlob = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuBlobsAppendTextData = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuAppendTextFromFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.m_mnuUseLease = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.m_mnuDownloadBlobs = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuBlobViewProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.m_blobRename = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuBlobTakeLease = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuBlobReleaseLease = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuBlobsDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.m_mnuBlobSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.m_mnuBlobCheckETags = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuTables = new System.Windows.Forms.ToolStripMenuItem();
			this.m_createStorageTable = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuInsertSampleEntities = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuDeleteEntity = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuQueues = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuCreateQueue = new System.Windows.Forms.ToolStripMenuItem();
			this.m_addQueueMessage = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuDequeueMessages = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuClearQueue = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuFiles = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileShareCreate = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuCreateShareDirectory = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuUploadShareFile = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuTrackOperationContext = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.m_splitter = new System.Windows.Forms.SplitContainer();
			this.m_objectTree = new System.Windows.Forms.TreeView();
			this.m_imageList = new System.Windows.Forms.ImageList(this.components);
			this.m_objectList = new System.Windows.Forms.ListView();
			this.m_txtInfo = new System.Windows.Forms.TextBox();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuShareDeleteDirectory = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mnuFileShareDeleteShare = new System.Windows.Forms.ToolStripMenuItem();
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
            this.m_mnuTables,
            this.m_mnuQueues,
            this.m_mnuFiles,
            this.viewToolStripMenuItem,
            this.m_mnuHelp});
			this.m_menuStrip.Location = new System.Drawing.Point(0, 0);
			this.m_menuStrip.Name = "m_menuStrip";
			this.m_menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
			this.m_menuStrip.Size = new System.Drawing.Size(1067, 28);
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
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// connectToolStripMenuItem
			// 
			this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
			this.connectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.connectToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
			this.connectToolStripMenuItem.Text = "&Connect...";
			this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(197, 6);
			// 
			// m_mnuFileExit
			// 
			this.m_mnuFileExit.Name = "m_mnuFileExit";
			this.m_mnuFileExit.Size = new System.Drawing.Size(200, 26);
			this.m_mnuFileExit.Text = "E&xit";
			this.m_mnuFileExit.Click += new System.EventHandler(this.m_mnuFileExit_Click);
			// 
			// m_mnuBlobs
			// 
			this.m_mnuBlobs.CheckOnClick = true;
			this.m_mnuBlobs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuCreateBlobContainer,
            this.toolStripSeparator5,
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
			this.m_mnuBlobs.Size = new System.Drawing.Size(58, 24);
			this.m_mnuBlobs.Text = "&Blobs";
			// 
			// m_mnuCreateBlobContainer
			// 
			this.m_mnuCreateBlobContainer.Name = "m_mnuCreateBlobContainer";
			this.m_mnuCreateBlobContainer.Size = new System.Drawing.Size(337, 26);
			this.m_mnuCreateBlobContainer.Text = "Create Blob &Container...";
			this.m_mnuCreateBlobContainer.Click += new System.EventHandler(this.m_mnuCreateBlobContainer_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(334, 6);
			// 
			// mnuBlobUploadFiles
			// 
			this.mnuBlobUploadFiles.Name = "mnuBlobUploadFiles";
			this.mnuBlobUploadFiles.Size = new System.Drawing.Size(337, 26);
			this.mnuBlobUploadFiles.Text = "Upload &Files as Blobs...";
			this.mnuBlobUploadFiles.Click += new System.EventHandler(this.mnuBlobUploadFiles_Click);
			// 
			// m_mnuUploadWithMetadata
			// 
			this.m_mnuUploadWithMetadata.Name = "m_mnuUploadWithMetadata";
			this.m_mnuUploadWithMetadata.Size = new System.Drawing.Size(337, 26);
			this.m_mnuUploadWithMetadata.Text = "Upload Files as Blobs With &Metadata...";
			this.m_mnuUploadWithMetadata.Click += new System.EventHandler(this.m_mnuUploadWithMetadata_Click);
			// 
			// mnuUploadFileInBlocks
			// 
			this.mnuUploadFileInBlocks.Name = "mnuUploadFileInBlocks";
			this.mnuUploadFileInBlocks.Size = new System.Drawing.Size(337, 26);
			this.mnuUploadFileInBlocks.Text = "Upload File in M&ultiple Blocks";
			this.mnuUploadFileInBlocks.Click += new System.EventHandler(this.mnuUploadFileInBlocks_Click);
			// 
			// mnuUploadAppendBlob
			// 
			this.mnuUploadAppendBlob.Name = "mnuUploadAppendBlob";
			this.mnuUploadAppendBlob.Size = new System.Drawing.Size(337, 26);
			this.mnuUploadAppendBlob.Text = "Upload File as &Append Blob";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(334, 6);
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
			this.m_mnuAppendBlobs.Size = new System.Drawing.Size(337, 26);
			this.m_mnuAppendBlobs.Text = "Append Blobs";
			// 
			// m_mnuBlobsCreateAppendBlob
			// 
			this.m_mnuBlobsCreateAppendBlob.Name = "m_mnuBlobsCreateAppendBlob";
			this.m_mnuBlobsCreateAppendBlob.Size = new System.Drawing.Size(233, 26);
			this.m_mnuBlobsCreateAppendBlob.Text = "Create A&ppend Blob";
			this.m_mnuBlobsCreateAppendBlob.Click += new System.EventHandler(this.m_mnuBlobsCreateAppendBlob_Click);
			// 
			// m_mnuBlobsAppendTextData
			// 
			this.m_mnuBlobsAppendTextData.Name = "m_mnuBlobsAppendTextData";
			this.m_mnuBlobsAppendTextData.Size = new System.Drawing.Size(233, 26);
			this.m_mnuBlobsAppendTextData.Text = "Append &Text Data";
			this.m_mnuBlobsAppendTextData.Click += new System.EventHandler(this.m_mnuBlobsAppendTextData_Click);
			// 
			// m_mnuAppendTextFromFile
			// 
			this.m_mnuAppendTextFromFile.Name = "m_mnuAppendTextFromFile";
			this.m_mnuAppendTextFromFile.Size = new System.Drawing.Size(233, 26);
			this.m_mnuAppendTextFromFile.Text = "Append Text From &File";
			this.m_mnuAppendTextFromFile.Click += new System.EventHandler(this.m_mnuAppendTextFromFile_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(230, 6);
			// 
			// m_mnuUseLease
			// 
			this.m_mnuUseLease.CheckOnClick = true;
			this.m_mnuUseLease.Name = "m_mnuUseLease";
			this.m_mnuUseLease.Size = new System.Drawing.Size(233, 26);
			this.m_mnuUseLease.Text = "Use &Lease If Available";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(334, 6);
			// 
			// m_mnuDownloadBlobs
			// 
			this.m_mnuDownloadBlobs.Name = "m_mnuDownloadBlobs";
			this.m_mnuDownloadBlobs.Size = new System.Drawing.Size(337, 26);
			this.m_mnuDownloadBlobs.Text = "Download...";
			this.m_mnuDownloadBlobs.Click += new System.EventHandler(this.m_mnuDownloadBlobs_Click);
			// 
			// m_mnuBlobViewProperties
			// 
			this.m_mnuBlobViewProperties.Name = "m_mnuBlobViewProperties";
			this.m_mnuBlobViewProperties.Size = new System.Drawing.Size(337, 26);
			this.m_mnuBlobViewProperties.Text = "View &Properties...";
			this.m_mnuBlobViewProperties.Click += new System.EventHandler(this.m_mnuBlobViewProperties_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(334, 6);
			// 
			// m_blobRename
			// 
			this.m_blobRename.Name = "m_blobRename";
			this.m_blobRename.Size = new System.Drawing.Size(337, 26);
			this.m_blobRename.Text = "&Rename";
			this.m_blobRename.Click += new System.EventHandler(this.m_blobRename_Click);
			// 
			// mnuBlobTakeLease
			// 
			this.mnuBlobTakeLease.Name = "mnuBlobTakeLease";
			this.mnuBlobTakeLease.Size = new System.Drawing.Size(337, 26);
			this.mnuBlobTakeLease.Text = "Take &Lease";
			this.mnuBlobTakeLease.Click += new System.EventHandler(this.mnuBlobTakeLease_Click);
			// 
			// mnuBlobReleaseLease
			// 
			this.mnuBlobReleaseLease.Name = "mnuBlobReleaseLease";
			this.mnuBlobReleaseLease.Size = new System.Drawing.Size(337, 26);
			this.mnuBlobReleaseLease.Text = "&Release Lease";
			this.mnuBlobReleaseLease.Click += new System.EventHandler(this.mnuBlobReleaseLease_Click);
			// 
			// m_mnuBlobsDelete
			// 
			this.m_mnuBlobsDelete.Name = "m_mnuBlobsDelete";
			this.m_mnuBlobsDelete.Size = new System.Drawing.Size(337, 26);
			this.m_mnuBlobsDelete.Text = "&Delete";
			this.m_mnuBlobsDelete.Click += new System.EventHandler(this.m_mnuBlobsDelete_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(334, 6);
			// 
			// m_mnuBlobSettings
			// 
			this.m_mnuBlobSettings.Name = "m_mnuBlobSettings";
			this.m_mnuBlobSettings.Size = new System.Drawing.Size(337, 26);
			this.m_mnuBlobSettings.Text = "&Settings";
			this.m_mnuBlobSettings.Click += new System.EventHandler(this.m_mnuBlobSettings_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(334, 6);
			// 
			// m_mnuBlobCheckETags
			// 
			this.m_mnuBlobCheckETags.Checked = true;
			this.m_mnuBlobCheckETags.CheckOnClick = true;
			this.m_mnuBlobCheckETags.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_mnuBlobCheckETags.Name = "m_mnuBlobCheckETags";
			this.m_mnuBlobCheckETags.Size = new System.Drawing.Size(337, 26);
			this.m_mnuBlobCheckETags.Text = "Check ETags";
			// 
			// m_mnuTables
			// 
			this.m_mnuTables.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_createStorageTable,
            this.m_mnuInsertSampleEntities,
            this.m_mnuDeleteEntity});
			this.m_mnuTables.Name = "m_mnuTables";
			this.m_mnuTables.Size = new System.Drawing.Size(62, 24);
			this.m_mnuTables.Text = "Tables";
			// 
			// m_createStorageTable
			// 
			this.m_createStorageTable.Name = "m_createStorageTable";
			this.m_createStorageTable.Size = new System.Drawing.Size(218, 26);
			this.m_createStorageTable.Text = "&Create...";
			this.m_createStorageTable.Click += new System.EventHandler(this.m_createStorageTable_Click);
			// 
			// m_mnuInsertSampleEntities
			// 
			this.m_mnuInsertSampleEntities.Name = "m_mnuInsertSampleEntities";
			this.m_mnuInsertSampleEntities.Size = new System.Drawing.Size(218, 26);
			this.m_mnuInsertSampleEntities.Text = "&Insert Sample Books";
			this.m_mnuInsertSampleEntities.Click += new System.EventHandler(this.m_mnuInsertSampleEntities_Click);
			// 
			// m_mnuDeleteEntity
			// 
			this.m_mnuDeleteEntity.Name = "m_mnuDeleteEntity";
			this.m_mnuDeleteEntity.Size = new System.Drawing.Size(218, 26);
			this.m_mnuDeleteEntity.Text = "&Delete Entities";
			this.m_mnuDeleteEntity.Click += new System.EventHandler(this.m_mnuDeleteEntity_Click);
			// 
			// m_mnuQueues
			// 
			this.m_mnuQueues.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuCreateQueue,
            this.m_addQueueMessage,
            this.m_mnuDequeueMessages,
            this.m_mnuClearQueue});
			this.m_mnuQueues.Name = "m_mnuQueues";
			this.m_mnuQueues.Size = new System.Drawing.Size(70, 24);
			this.m_mnuQueues.Text = "Queues";
			// 
			// m_mnuCreateQueue
			// 
			this.m_mnuCreateQueue.Name = "m_mnuCreateQueue";
			this.m_mnuCreateQueue.Size = new System.Drawing.Size(212, 26);
			this.m_mnuCreateQueue.Text = "&Create Queue...";
			this.m_mnuCreateQueue.Click += new System.EventHandler(this.m_mnuCreateQueue_Click);
			// 
			// m_addQueueMessage
			// 
			this.m_addQueueMessage.Name = "m_addQueueMessage";
			this.m_addQueueMessage.Size = new System.Drawing.Size(212, 26);
			this.m_addQueueMessage.Text = "&Add Message";
			this.m_addQueueMessage.Click += new System.EventHandler(this.m_addQueueMessage_Click);
			// 
			// m_mnuDequeueMessages
			// 
			this.m_mnuDequeueMessages.Name = "m_mnuDequeueMessages";
			this.m_mnuDequeueMessages.Size = new System.Drawing.Size(212, 26);
			this.m_mnuDequeueMessages.Text = "&Dequeue Messages";
			this.m_mnuDequeueMessages.Click += new System.EventHandler(this.m_mnuDequeueMessage_Click);
			// 
			// m_mnuClearQueue
			// 
			this.m_mnuClearQueue.Name = "m_mnuClearQueue";
			this.m_mnuClearQueue.Size = new System.Drawing.Size(212, 26);
			this.m_mnuClearQueue.Text = "C&lear";
			this.m_mnuClearQueue.Click += new System.EventHandler(this.m_mnuClearQueue_Click);
			// 
			// m_mnuFiles
			// 
			this.m_mnuFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileShareCreate,
            this.m_mnuCreateShareDirectory,
            this.m_mnuUploadShareFile,
            this.toolStripMenuItem4,
            this.deleteFilesToolStripMenuItem,
            this.m_mnuShareDeleteDirectory,
            this.m_mnuFileShareDeleteShare});
			this.m_mnuFiles.Name = "m_mnuFiles";
			this.m_mnuFiles.Size = new System.Drawing.Size(50, 24);
			this.m_mnuFiles.Text = "&Files";
			// 
			// mnuFileShareCreate
			// 
			this.mnuFileShareCreate.Name = "mnuFileShareCreate";
			this.mnuFileShareCreate.Size = new System.Drawing.Size(216, 26);
			this.mnuFileShareCreate.Text = "C&reate Share...";
			this.mnuFileShareCreate.Click += new System.EventHandler(this.mnuFileShareCreate_Click);
			// 
			// m_mnuCreateShareDirectory
			// 
			this.m_mnuCreateShareDirectory.Name = "m_mnuCreateShareDirectory";
			this.m_mnuCreateShareDirectory.Size = new System.Drawing.Size(216, 26);
			this.m_mnuCreateShareDirectory.Text = "Create &Directory...";
			this.m_mnuCreateShareDirectory.Click += new System.EventHandler(this.m_mnuCreateShareDirectory_Click);
			// 
			// m_mnuUploadShareFile
			// 
			this.m_mnuUploadShareFile.Name = "m_mnuUploadShareFile";
			this.m_mnuUploadShareFile.Size = new System.Drawing.Size(216, 26);
			this.m_mnuUploadShareFile.Text = "Upload &File...";
			this.m_mnuUploadShareFile.Click += new System.EventHandler(this.m_mnuUploadShareFile_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewRefresh,
            this.m_mnuTrackOperationContext});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// mnuViewRefresh
			// 
			this.mnuViewRefresh.Name = "mnuViewRefresh";
			this.mnuViewRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.mnuViewRefresh.Size = new System.Drawing.Size(244, 26);
			this.mnuViewRefresh.Text = "&Refresh";
			this.mnuViewRefresh.Click += new System.EventHandler(this.mnuViewRefresh_Click);
			// 
			// m_mnuTrackOperationContext
			// 
			this.m_mnuTrackOperationContext.CheckOnClick = true;
			this.m_mnuTrackOperationContext.Name = "m_mnuTrackOperationContext";
			this.m_mnuTrackOperationContext.Size = new System.Drawing.Size(244, 26);
			this.m_mnuTrackOperationContext.Text = "Track &Operation Context";
			// 
			// m_mnuHelp
			// 
			this.m_mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuHelpAbout});
			this.m_mnuHelp.Name = "m_mnuHelp";
			this.m_mnuHelp.Size = new System.Drawing.Size(53, 24);
			this.m_mnuHelp.Text = "&Help";
			// 
			// m_mnuHelpAbout
			// 
			this.m_mnuHelpAbout.Name = "m_mnuHelpAbout";
			this.m_mnuHelpAbout.Size = new System.Drawing.Size(134, 26);
			this.m_mnuHelpAbout.Text = "&About...";
			this.m_mnuHelpAbout.Click += new System.EventHandler(this.m_mnuHelpAbout_Click);
			// 
			// m_splitter
			// 
			this.m_splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_splitter.Location = new System.Drawing.Point(0, 28);
			this.m_splitter.Margin = new System.Windows.Forms.Padding(4);
			this.m_splitter.Name = "m_splitter";
			// 
			// m_splitter.Panel1
			// 
			this.m_splitter.Panel1.Controls.Add(this.m_objectTree);
			// 
			// m_splitter.Panel2
			// 
			this.m_splitter.Panel2.Controls.Add(this.m_objectList);
			this.m_splitter.Size = new System.Drawing.Size(1067, 512);
			this.m_splitter.SplitterDistance = 264;
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
			this.m_objectTree.Location = new System.Drawing.Point(4, 0);
			this.m_objectTree.Margin = new System.Windows.Forms.Padding(4);
			this.m_objectTree.Name = "m_objectTree";
			this.m_objectTree.SelectedImageIndex = 0;
			this.m_objectTree.Size = new System.Drawing.Size(256, 387);
			this.m_objectTree.TabIndex = 0;
			this.m_objectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_objectTree_AfterSelect);
			// 
			// m_imageList
			// 
			this.m_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageList.ImageStream")));
			this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.m_imageList.Images.SetKeyName(0, "Storage.png");
			this.m_imageList.Images.SetKeyName(1, "Folder.png");
			this.m_imageList.Images.SetKeyName(2, "Azure Storage - Blob.png");
			this.m_imageList.Images.SetKeyName(3, "Azure Storage.png");
			this.m_imageList.Images.SetKeyName(4, "Azure Storage - Table.png");
			this.m_imageList.Images.SetKeyName(5, "Azure Storage - Queue.png");
			this.m_imageList.Images.SetKeyName(6, "Azure Storage - Files.png");
			this.m_imageList.Images.SetKeyName(7, "Shared folder.png");
			// 
			// m_objectList
			// 
			this.m_objectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_objectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_objectList.FullRowSelect = true;
			this.m_objectList.Location = new System.Drawing.Point(0, 0);
			this.m_objectList.Margin = new System.Windows.Forms.Padding(4);
			this.m_objectList.Name = "m_objectList";
			this.m_objectList.Size = new System.Drawing.Size(797, 387);
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
			this.m_txtInfo.Location = new System.Drawing.Point(0, 420);
			this.m_txtInfo.Margin = new System.Windows.Forms.Padding(4);
			this.m_txtInfo.Multiline = true;
			this.m_txtInfo.Name = "m_txtInfo";
			this.m_txtInfo.ReadOnly = true;
			this.m_txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.m_txtInfo.Size = new System.Drawing.Size(1067, 120);
			this.m_txtInfo.TabIndex = 4;
			this.m_txtInfo.WordWrap = false;
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(213, 6);
			// 
			// deleteFilesToolStripMenuItem
			// 
			this.deleteFilesToolStripMenuItem.Name = "deleteFilesToolStripMenuItem";
			this.deleteFilesToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
			this.deleteFilesToolStripMenuItem.Text = "D&elete Files";
			this.deleteFilesToolStripMenuItem.Click += new System.EventHandler(this.deleteFilesToolStripMenuItem_Click);
			// 
			// m_mnuShareDeleteDirectory
			// 
			this.m_mnuShareDeleteDirectory.Name = "m_mnuShareDeleteDirectory";
			this.m_mnuShareDeleteDirectory.Size = new System.Drawing.Size(216, 26);
			this.m_mnuShareDeleteDirectory.Text = "Delete Directory";
			this.m_mnuShareDeleteDirectory.Click += new System.EventHandler(this.m_mnuShareDeleteDirectory_Click);
			// 
			// m_mnuFileShareDeleteShare
			// 
			this.m_mnuFileShareDeleteShare.Name = "m_mnuFileShareDeleteShare";
			this.m_mnuFileShareDeleteShare.Size = new System.Drawing.Size(216, 26);
			this.m_mnuFileShareDeleteShare.Text = "Delete Share";
			this.m_mnuFileShareDeleteShare.Click += new System.EventHandler(this.m_mnuFileShareDeleteShare_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1067, 540);
			this.Controls.Add(this.m_txtInfo);
			this.Controls.Add(this.m_splitter);
			this.Controls.Add(this.m_menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.m_menuStrip;
			this.Margin = new System.Windows.Forms.Padding(4);
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
		private System.Windows.Forms.ToolStripMenuItem m_mnuTrackOperationContext;
		private System.Windows.Forms.ToolStripMenuItem m_mnuTables;
		private System.Windows.Forms.ToolStripMenuItem m_mnuInsertSampleEntities;
		private System.Windows.Forms.ToolStripMenuItem m_createStorageTable;
		private System.Windows.Forms.ToolStripMenuItem m_mnuDeleteEntity;
		private System.Windows.Forms.ToolStripMenuItem m_mnuQueues;
		private System.Windows.Forms.ToolStripMenuItem m_mnuCreateQueue;
		private System.Windows.Forms.ToolStripMenuItem m_mnuClearQueue;
		private System.Windows.Forms.ToolStripMenuItem m_addQueueMessage;
		private System.Windows.Forms.ToolStripMenuItem m_mnuDequeueMessages;
		private System.Windows.Forms.ToolStripMenuItem m_mnuCreateBlobContainer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem m_mnuFiles;
        private System.Windows.Forms.ToolStripMenuItem mnuFileShareCreate;
		private System.Windows.Forms.ToolStripMenuItem m_mnuCreateShareDirectory;
		private System.Windows.Forms.ToolStripMenuItem m_mnuUploadShareFile;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem deleteFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_mnuShareDeleteDirectory;
		private System.Windows.Forms.ToolStripMenuItem m_mnuFileShareDeleteShare;
	}
}

