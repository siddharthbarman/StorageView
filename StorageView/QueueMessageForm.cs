using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageView
{
	public partial class QueueMessageForm : Form
	{
		public QueueMessageForm() {
			InitializeComponent();
			MessageType = MessageSendTypes.Text;
		}

		public MessageSendTypes MessageType {
			get;
			set;
		}

		public string MessageText {
			get;
			set;
		}

		public string FilePath {
			get;
			set;
		}

		public TimeSpan TTL {
			get;
			set;
		}

		public TimeSpan Delay {
			get;
			set;
		}

		void EnableDisableUI() {
			if (m_radioText.Checked) {
				m_groupMessage.Enabled = true;
				m_groupBinary.Enabled = false;
			}
			else {
				m_groupMessage.Enabled = false;
				m_groupBinary.Enabled = true;
			}
		}

		void InitializeUI() {
			if (MessageType == MessageSendTypes.Text) {				
				m_radioText.Checked = true;
			}
			else {
				m_radioBinary.Checked = true;
			}

			m_txtMessageText.Text = MessageText;
			m_txtFile.Text = FilePath;
		}

		void BrowseForFile() {
			OpenFileDialog dlg = new OpenFileDialog {
				CheckFileExists = true,
				CheckPathExists = true,
				Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*",
				FilterIndex = 0,
				Multiselect = false,
				Title = "Select a file to send"
			};
			if (dlg.ShowDialog() == DialogResult.OK) {
				m_txtFile.Text = dlg.FileName;
			}
		}
		
		bool OnOK() {
			MessageType = m_radioText.Checked ? MessageSendTypes.Text : MessageSendTypes.Binary;
			if (MessageType == MessageSendTypes.Text) {
				if (string.IsNullOrEmpty(m_txtMessageText.Text)) {
					MessageBox.Show("Please enter the message you wish to send", "Error", 
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					m_txtMessageText.Focus();
					return false;
				}
			}
			else if (MessageType == MessageSendTypes.Binary) {
				if (string.IsNullOrEmpty(m_txtFile.Text)) {
					MessageBox.Show("Please enter the file you wish to send", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					m_txtFile.Focus();
					return false;
				}

				if (!File.Exists(m_txtFile.Text)) {
					MessageBox.Show("The specified file does not exist!", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					m_txtFile.Focus();
					return false;
				}
			}

			FilePath = m_txtFile.Text;
			MessageText = m_txtMessageText.Text;
			TTL = new TimeSpan((int)m_numTTL.Value, 0, 0);
			Delay = new TimeSpan(0, 0, (int)m_numDelay.Value);
			return true;
		}

		private void m_radioText_CheckedChanged(object sender, EventArgs e) {
			EnableDisableUI();
		}

		private void m_radioBinary_CheckedChanged(object sender, EventArgs e) {
			EnableDisableUI();
		}

		private void QueueMessageForm_Load(object sender, EventArgs e) {
			InitializeUI();
		}

		private void m_btnBrowse_Click(object sender, EventArgs e) {
			BrowseForFile();
		}

		private void m_btnOK_Click(object sender, EventArgs e) {
			if (OnOK())
				DialogResult = DialogResult.OK;
		}
	}

	
}
