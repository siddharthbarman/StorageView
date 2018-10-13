namespace StorageView
{
	partial class BlockBlobUploadForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_numBlockSizeKB = new System.Windows.Forms.NumericUpDown();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnSelectFile = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.m_numBlockSizeKB)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "File to upload: ";
			// 
			// m_txtFile
			// 
			this.m_txtFile.Location = new System.Drawing.Point(100, 7);
			this.m_txtFile.Name = "m_txtFile";
			this.m_txtFile.Size = new System.Drawing.Size(180, 20);
			this.m_txtFile.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Block size (KB): ";
			// 
			// m_numBlockSizeKB
			// 
			this.m_numBlockSizeKB.Location = new System.Drawing.Point(100, 35);
			this.m_numBlockSizeKB.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.m_numBlockSizeKB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.m_numBlockSizeKB.Name = "m_numBlockSizeKB";
			this.m_numBlockSizeKB.Size = new System.Drawing.Size(76, 20);
			this.m_numBlockSizeKB.TabIndex = 4;
			this.m_numBlockSizeKB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_numBlockSizeKB.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// m_btnOK
			// 
			this.m_btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnOK.Location = new System.Drawing.Point(160, 103);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(69, 24);
			this.m_btnOK.TabIndex = 5;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnCancel.Location = new System.Drawing.Point(233, 103);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(69, 24);
			this.m_btnCancel.TabIndex = 6;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// m_btnSelectFile
			// 
			this.m_btnSelectFile.FlatAppearance.BorderSize = 0;
			this.m_btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnSelectFile.Image = global::StorageView.Properties.Resources.Folder_Open_16x16;
			this.m_btnSelectFile.Location = new System.Drawing.Point(286, 7);
			this.m_btnSelectFile.Name = "m_btnSelectFile";
			this.m_btnSelectFile.Size = new System.Drawing.Size(18, 18);
			this.m_btnSelectFile.TabIndex = 2;
			this.m_btnSelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.m_btnSelectFile.UseVisualStyleBackColor = true;
			this.m_btnSelectFile.Click += new System.EventHandler(this.m_btnSelectFile_Click);
			// 
			// BlockBlobUploadForm
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(315, 139);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnOK);
			this.Controls.Add(this.m_numBlockSizeKB);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_btnSelectFile);
			this.Controls.Add(this.m_txtFile);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BlockBlobUploadForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Block Blob Upload Properties";
			this.Load += new System.EventHandler(this.BlockBlobUploadForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.m_numBlockSizeKB)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txtFile;
		private System.Windows.Forms.Button m_btnSelectFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown m_numBlockSizeKB;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button m_btnCancel;
	}
}