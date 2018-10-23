namespace StorageView {
	partial class NameWithMetadataForm {
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
			this.m_txtName = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtKey1 = new System.Windows.Forms.TextBox();
			this.m_txtValue1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtKey2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtValue2 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name: ";
			// 
			// m_txtName
			// 
			this.m_txtName.Location = new System.Drawing.Point(56, 9);
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.Size = new System.Drawing.Size(189, 20);
			this.m_txtName.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_txtValue2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.m_txtKey2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.m_txtValue1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.m_txtKey1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(11, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(239, 140);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Metadata";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Key: ";
			// 
			// m_txtKey1
			// 
			this.m_txtKey1.Location = new System.Drawing.Point(45, 16);
			this.m_txtKey1.Name = "m_txtKey1";
			this.m_txtKey1.Size = new System.Drawing.Size(188, 20);
			this.m_txtKey1.TabIndex = 1;
			// 
			// m_txtValue1
			// 
			this.m_txtValue1.Location = new System.Drawing.Point(45, 44);
			this.m_txtValue1.Name = "m_txtValue1";
			this.m_txtValue1.Size = new System.Drawing.Size(188, 20);
			this.m_txtValue1.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Value: ";
			// 
			// m_txtKey2
			// 
			this.m_txtKey2.Location = new System.Drawing.Point(45, 73);
			this.m_txtKey2.Name = "m_txtKey2";
			this.m_txtKey2.Size = new System.Drawing.Size(188, 20);
			this.m_txtKey2.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Key: ";
			// 
			// m_txtValue2
			// 
			this.m_txtValue2.Location = new System.Drawing.Point(45, 102);
			this.m_txtValue2.Name = "m_txtValue2";
			this.m_txtValue2.Size = new System.Drawing.Size(188, 20);
			this.m_txtValue2.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 105);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Value: ";
			// 
			// m_btnOK
			// 
			this.m_btnOK.Location = new System.Drawing.Point(120, 204);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(63, 23);
			this.m_btnOK.TabIndex = 3;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.Location = new System.Drawing.Point(187, 204);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(63, 23);
			this.m_btnCancel.TabIndex = 4;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// NameWithMetadataForm
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(263, 240);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_txtName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NameWithMetadataForm";
			this.Text = "NameWithMetadataForm";
			this.Load += new System.EventHandler(this.NameWithMetadataForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txtName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox m_txtValue2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox m_txtKey2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox m_txtValue1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_txtKey1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button m_btnCancel;
	}
}