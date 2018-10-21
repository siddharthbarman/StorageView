namespace StorageView
{
	partial class QueueMessageForm
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
			this.m_btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.m_radioText = new System.Windows.Forms.RadioButton();
			this.m_groupMessage = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtMessageText = new System.Windows.Forms.TextBox();
			this.m_radioBinary = new System.Windows.Forms.RadioButton();
			this.m_groupBinary = new System.Windows.Forms.GroupBox();
			this.m_btnBrowse = new System.Windows.Forms.Button();
			this.m_txtFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_numTTL = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.m_numDelay = new System.Windows.Forms.NumericUpDown();
			this.m_groupMessage.SuspendLayout();
			this.m_groupBinary.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_numTTL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_numDelay)).BeginInit();
			this.SuspendLayout();
			// 
			// m_btnOK
			// 
			this.m_btnOK.Location = new System.Drawing.Point(188, 330);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(63, 26);
			this.m_btnOK.TabIndex = 1;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(257, 330);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(63, 26);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// m_radioText
			// 
			this.m_radioText.AutoSize = true;
			this.m_radioText.Checked = true;
			this.m_radioText.Location = new System.Drawing.Point(11, 39);
			this.m_radioText.Name = "m_radioText";
			this.m_radioText.Size = new System.Drawing.Size(102, 19);
			this.m_radioText.TabIndex = 3;
			this.m_radioText.Text = "Text Message";
			this.m_radioText.UseVisualStyleBackColor = true;
			this.m_radioText.CheckedChanged += new System.EventHandler(this.m_radioText_CheckedChanged);
			// 
			// m_groupMessage
			// 
			this.m_groupMessage.Controls.Add(this.m_txtMessageText);
			this.m_groupMessage.Controls.Add(this.label1);
			this.m_groupMessage.Location = new System.Drawing.Point(8, 57);
			this.m_groupMessage.Name = "m_groupMessage";
			this.m_groupMessage.Size = new System.Drawing.Size(311, 107);
			this.m_groupMessage.TabIndex = 4;
			this.m_groupMessage.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(138, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Enter the message text: ";
			// 
			// m_txtMessageText
			// 
			this.m_txtMessageText.Location = new System.Drawing.Point(9, 29);
			this.m_txtMessageText.Multiline = true;
			this.m_txtMessageText.Name = "m_txtMessageText";
			this.m_txtMessageText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.m_txtMessageText.Size = new System.Drawing.Size(296, 69);
			this.m_txtMessageText.TabIndex = 2;
			// 
			// m_radioBinary
			// 
			this.m_radioBinary.AutoSize = true;
			this.m_radioBinary.Location = new System.Drawing.Point(11, 169);
			this.m_radioBinary.Name = "m_radioBinary";
			this.m_radioBinary.Size = new System.Drawing.Size(113, 19);
			this.m_radioBinary.TabIndex = 5;
			this.m_radioBinary.Text = "Binary Message";
			this.m_radioBinary.UseVisualStyleBackColor = true;
			this.m_radioBinary.CheckedChanged += new System.EventHandler(this.m_radioBinary_CheckedChanged);
			// 
			// m_groupBinary
			// 
			this.m_groupBinary.Controls.Add(this.m_btnBrowse);
			this.m_groupBinary.Controls.Add(this.m_txtFile);
			this.m_groupBinary.Controls.Add(this.label2);
			this.m_groupBinary.Location = new System.Drawing.Point(8, 187);
			this.m_groupBinary.Name = "m_groupBinary";
			this.m_groupBinary.Size = new System.Drawing.Size(312, 75);
			this.m_groupBinary.TabIndex = 6;
			this.m_groupBinary.TabStop = false;
			// 
			// m_btnBrowse
			// 
			this.m_btnBrowse.Location = new System.Drawing.Point(279, 34);
			this.m_btnBrowse.Name = "m_btnBrowse";
			this.m_btnBrowse.Size = new System.Drawing.Size(23, 22);
			this.m_btnBrowse.TabIndex = 5;
			this.m_btnBrowse.Text = "...";
			this.m_btnBrowse.UseVisualStyleBackColor = true;
			this.m_btnBrowse.Click += new System.EventHandler(this.m_btnBrowse_Click);
			// 
			// m_txtFile
			// 
			this.m_txtFile.Location = new System.Drawing.Point(11, 35);
			this.m_txtFile.Name = "m_txtFile";
			this.m_txtFile.Size = new System.Drawing.Size(262, 20);
			this.m_txtFile.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Select a file: ";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(5, -1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(314, 38);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(250, 15);
			this.label3.TabIndex = 0;
			this.label3.Text = "Select the type of message you want to send:";
			// 
			// m_numTTL
			// 
			this.m_numTTL.Location = new System.Drawing.Point(131, 272);
			this.m_numTTL.Maximum = new decimal(new int[] {
            168,
            0,
            0,
            0});
			this.m_numTTL.Name = "m_numTTL";
			this.m_numTTL.Size = new System.Drawing.Size(51, 20);
			this.m_numTTL.TabIndex = 8;
			this.m_numTTL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 272);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 15);
			this.label4.TabIndex = 9;
			this.label4.Text = "Time to Live (hours): ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 298);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 15);
			this.label5.TabIndex = 11;
			this.label5.Text = "Visibility Delay (sec); ";
			// 
			// m_numDelay
			// 
			this.m_numDelay.Location = new System.Drawing.Point(131, 298);
			this.m_numDelay.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
			this.m_numDelay.Name = "m_numDelay";
			this.m_numDelay.Size = new System.Drawing.Size(51, 20);
			this.m_numDelay.TabIndex = 10;
			this.m_numDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// QueueMessageForm
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(327, 364);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.m_numDelay);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_numTTL);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_groupBinary);
			this.Controls.Add(this.m_radioBinary);
			this.Controls.Add(this.m_groupMessage);
			this.Controls.Add(this.m_radioText);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.m_btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QueueMessageForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Queue Message";
			this.Load += new System.EventHandler(this.QueueMessageForm_Load);
			this.m_groupMessage.ResumeLayout(false);
			this.m_groupMessage.PerformLayout();
			this.m_groupBinary.ResumeLayout(false);
			this.m_groupBinary.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_numTTL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_numDelay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton m_radioText;
		private System.Windows.Forms.GroupBox m_groupMessage;
		private System.Windows.Forms.TextBox m_txtMessageText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton m_radioBinary;
		private System.Windows.Forms.GroupBox m_groupBinary;
		private System.Windows.Forms.Button m_btnBrowse;
		private System.Windows.Forms.TextBox m_txtFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown m_numTTL;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown m_numDelay;
	}
}