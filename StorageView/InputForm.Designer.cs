namespace StorageView
{
	partial class InputForm
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
			this.m_lblInfo = new System.Windows.Forms.Label();
			this.m_text = new System.Windows.Forms.TextBox();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_lblError = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// m_lblInfo
			// 
			this.m_lblInfo.Location = new System.Drawing.Point(66, 11);
			this.m_lblInfo.Name = "m_lblInfo";
			this.m_lblInfo.Size = new System.Drawing.Size(258, 45);
			this.m_lblInfo.TabIndex = 0;
			this.m_lblInfo.Text = "m_lblInfo";
			// 
			// m_text
			// 
			this.m_text.Location = new System.Drawing.Point(43, 63);
			this.m_text.Name = "m_text";
			this.m_text.Size = new System.Drawing.Size(295, 20);
			this.m_text.TabIndex = 1;
			// 
			// m_btnOK
			// 
			this.m_btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnOK.Location = new System.Drawing.Point(200, 125);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(65, 27);
			this.m_btnOK.TabIndex = 2;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnCancel.Location = new System.Drawing.Point(271, 125);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(65, 27);
			this.m_btnCancel.TabIndex = 3;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// m_lblError
			// 
			this.m_lblError.AutoSize = true;
			this.m_lblError.ForeColor = System.Drawing.Color.Red;
			this.m_lblError.Location = new System.Drawing.Point(42, 91);
			this.m_lblError.Name = "m_lblError";
			this.m_lblError.Size = new System.Drawing.Size(0, 15);
			this.m_lblError.TabIndex = 5;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::StorageView.Properties.Resources.question;
			this.pictureBox1.Location = new System.Drawing.Point(10, 9);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(47, 46);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// InputForm
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(345, 160);
			this.Controls.Add(this.m_lblError);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnOK);
			this.Controls.Add(this.m_text);
			this.Controls.Add(this.m_lblInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputForm";
			this.Text = "InputForm";
			this.Load += new System.EventHandler(this.InputForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label m_lblInfo;
		private System.Windows.Forms.TextBox m_text;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label m_lblError;
	}
}