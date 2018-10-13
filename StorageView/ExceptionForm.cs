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
	public partial class ExceptionForm : Form
	{
		public ExceptionForm() {
			InitializeComponent();
		}

		public Exception Exception {
			get;set;
		}

		private void m_btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}

		private void ExceptionForm_Load(object sender, EventArgs e) {
			if (Exception != null) {
				Text = Exception.GetType().Name;
				m_txtInfo.Text = string.Format("Exception: {0}\r\n\r\nMessage: {1}\r\n\r\nStack trace: {2}",
					Exception.GetType().Name, Exception.Message, Exception.StackTrace);
			}
			else {
				Text = "";
			}			
		}

		private void m_txtInfo_TextChanged(object sender, EventArgs e) {
			m_txtInfo.SelectionLength = 0;
		}
	}
}
