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
	public partial class AboutForm : Form
	{
		public AboutForm() {
			InitializeComponent();
		}

		private void AboutForm_Load(object sender, EventArgs e) {
			m_txtInfo.Text = "Storage View 1.0\r\n" +
				"(c) Siddharth Barman, 2018 - 2019.\r\n\r\n" +
				"Storage View is free to use. It has been built for educational purpose, specifically to learn about Azure Storage facilities.\r\n\r\n" +
				"If you have any suggestions, comments or questions, you can send them to sbytestream.outlook.com.\r\n\r\n" +
				"Homepage: https://www.sbytestream.pythonanywhere.com";
		}

		private void m_btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
	}
}
