namespace StorageView
{
    partial class ConnectForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
			this.label1 = new System.Windows.Forms.Label();
			this.txtStorageAccount = new System.Windows.Forms.TextBox();
			this.txtAccessKey = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.m_chkUseSecure = new System.Windows.Forms.CheckBox();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Storage account: ";
			// 
			// txtStorageAccount
			// 
			this.txtStorageAccount.Location = new System.Drawing.Point(113, 10);
			this.txtStorageAccount.Name = "txtStorageAccount";
			this.txtStorageAccount.Size = new System.Drawing.Size(179, 20);
			this.txtStorageAccount.TabIndex = 1;
			// 
			// txtAccessKey
			// 
			this.txtAccessKey.Location = new System.Drawing.Point(113, 37);
			this.txtAccessKey.Name = "txtAccessKey";
			this.txtAccessKey.Size = new System.Drawing.Size(179, 20);
			this.txtAccessKey.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Access account: ";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOK.Location = new System.Drawing.Point(143, 163);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 26);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// m_chkUseSecure
			// 
			this.m_chkUseSecure.AutoSize = true;
			this.m_chkUseSecure.Location = new System.Drawing.Point(113, 62);
			this.m_chkUseSecure.Name = "m_chkUseSecure";
			this.m_chkUseSecure.Size = new System.Drawing.Size(90, 19);
			this.m_chkUseSecure.TabIndex = 5;
			this.m_chkUseSecure.Text = "Use HTTP&S";
			this.m_chkUseSecure.UseVisualStyleBackColor = true;
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnCancel.Location = new System.Drawing.Point(221, 163);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 26);
			this.m_btnCancel.TabIndex = 6;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(13, 121);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(60, 64);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// ConnectForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(304, 196);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_chkUseSecure);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtAccessKey);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtStorageAccount);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConnectForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Connect";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectForm_FormClosed);
			this.Load += new System.EventHandler(this.ConnectForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStorageAccount;
        private System.Windows.Forms.TextBox txtAccessKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.CheckBox m_chkUseSecure;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}