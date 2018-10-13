namespace StorageView
{
	partial class LeaseForm
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
			this.m_groupBox = new System.Windows.Forms.GroupBox();
			this.m_numLeaseSec = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.m_leaseTypeFixed = new System.Windows.Forms.RadioButton();
			this.m_leaseTypeInfinite = new System.Windows.Forms.RadioButton();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_numLeaseSec)).BeginInit();
			this.SuspendLayout();
			// 
			// m_btnOK
			// 
			this.m_btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnOK.Location = new System.Drawing.Point(152, 158);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(62, 27);
			this.m_btnOK.TabIndex = 4;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// m_groupBox
			// 
			this.m_groupBox.Controls.Add(this.m_numLeaseSec);
			this.m_groupBox.Controls.Add(this.label1);
			this.m_groupBox.Controls.Add(this.m_leaseTypeFixed);
			this.m_groupBox.Controls.Add(this.m_leaseTypeInfinite);
			this.m_groupBox.Location = new System.Drawing.Point(4, 0);
			this.m_groupBox.Name = "m_groupBox";
			this.m_groupBox.Size = new System.Drawing.Size(279, 133);
			this.m_groupBox.TabIndex = 5;
			this.m_groupBox.TabStop = false;
			this.m_groupBox.Text = "Lease Properties";
			// 
			// m_numLeaseSec
			// 
			this.m_numLeaseSec.Location = new System.Drawing.Point(116, 71);
			this.m_numLeaseSec.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.m_numLeaseSec.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.m_numLeaseSec.Name = "m_numLeaseSec";
			this.m_numLeaseSec.Size = new System.Drawing.Size(45, 20);
			this.m_numLeaseSec.TabIndex = 7;
			this.m_numLeaseSec.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 71);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "Period (sec):";
			// 
			// m_leaseTypeFixed
			// 
			this.m_leaseTypeFixed.AutoSize = true;
			this.m_leaseTypeFixed.Checked = true;
			this.m_leaseTypeFixed.Location = new System.Drawing.Point(11, 48);
			this.m_leaseTypeFixed.Name = "m_leaseTypeFixed";
			this.m_leaseTypeFixed.Size = new System.Drawing.Size(55, 19);
			this.m_leaseTypeFixed.TabIndex = 5;
			this.m_leaseTypeFixed.TabStop = true;
			this.m_leaseTypeFixed.Text = "Fixed";
			this.m_leaseTypeFixed.UseVisualStyleBackColor = true;
			// 
			// m_leaseTypeInfinite
			// 
			this.m_leaseTypeInfinite.AutoSize = true;
			this.m_leaseTypeInfinite.Location = new System.Drawing.Point(11, 23);
			this.m_leaseTypeInfinite.Name = "m_leaseTypeInfinite";
			this.m_leaseTypeInfinite.Size = new System.Drawing.Size(61, 19);
			this.m_leaseTypeInfinite.TabIndex = 4;
			this.m_leaseTypeInfinite.Text = "Infinite";
			this.m_leaseTypeInfinite.UseVisualStyleBackColor = true;
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnCancel.Location = new System.Drawing.Point(218, 158);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(62, 27);
			this.m_btnCancel.TabIndex = 6;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// LeaseForm
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(287, 192);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_groupBox);
			this.Controls.Add(this.m_btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LeaseForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Lease";
			this.m_groupBox.ResumeLayout(false);
			this.m_groupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_numLeaseSec)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.GroupBox m_groupBox;
		private System.Windows.Forms.NumericUpDown m_numLeaseSec;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton m_leaseTypeFixed;
		private System.Windows.Forms.RadioButton m_leaseTypeInfinite;
		private System.Windows.Forms.Button m_btnCancel;
	}
}