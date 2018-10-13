namespace StorageView
{
	partial class ExceptionForm
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.m_txtInfo = new System.Windows.Forms.TextBox();
			this.m_btnOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::StorageView.Properties.Resources.error;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(37, 36);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// m_txtInfo
			// 
			this.m_txtInfo.BackColor = System.Drawing.Color.White;
			this.m_txtInfo.Location = new System.Drawing.Point(61, 12);
			this.m_txtInfo.Multiline = true;
			this.m_txtInfo.Name = "m_txtInfo";
			this.m_txtInfo.ReadOnly = true;
			this.m_txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.m_txtInfo.Size = new System.Drawing.Size(368, 170);
			this.m_txtInfo.TabIndex = 1;
			this.m_txtInfo.TextChanged += new System.EventHandler(this.m_txtInfo_TextChanged);
			// 
			// m_btnOK
			// 
			this.m_btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnOK.Location = new System.Drawing.Point(356, 191);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(73, 27);
			this.m_btnOK.TabIndex = 2;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// ExceptionForm
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(435, 226);
			this.Controls.Add(this.m_btnOK);
			this.Controls.Add(this.m_txtInfo);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExceptionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ExceptionForm";
			this.Load += new System.EventHandler(this.ExceptionForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox m_txtInfo;
		private System.Windows.Forms.Button m_btnOK;
	}
}