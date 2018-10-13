using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageView
{
	public partial class BlockBlobUploadForm : Form
	{
		public BlockBlobUploadForm() {
			InitializeComponent();
		}

		public string SelectedFile { get; set; }

		public int BlockSizeKB { get; set; }

		private void m_btnOK_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(m_txtFile.Text)) {
				MessageBox.Show("No file has been selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			SelectedFile = m_txtFile.Text;
			BlockSizeKB = (int)m_numBlockSizeKB.Value;
			DialogResult = DialogResult.OK;
		}

		private void BlockBlobUploadForm_Load(object sender, EventArgs e) {
			m_txtFile.Text = SelectedFile;
			m_numBlockSizeKB.Value = BlockSizeKB;
		}

		private void m_btnSelectFile_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog {
				Title = "Select a file",
				Multiselect = false,
				CheckFileExists = true				
			};

			if (dlg.ShowDialog() == DialogResult.OK) {
				m_txtFile.Text = dlg.FileName;
			}
		}
	}
}
