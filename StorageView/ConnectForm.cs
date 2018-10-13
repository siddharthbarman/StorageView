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
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
			UseHttps = true;
        }

        public string StorageAccount { get; set; }

        public string AccessKey { get; set; }
        
		public bool UseHttps { get; set; }

        private void btnOK_Click(object sender, EventArgs e) {
            StorageAccount = txtStorageAccount.Text;
            AccessKey = txtAccessKey.Text;
			UseHttps = m_chkUseSecure.Checked;
			DialogResult = DialogResult.OK;
		}

        private void ConnectForm_Load(object sender, EventArgs e) {
            txtStorageAccount.Text = StorageAccount;
            txtAccessKey.Text = AccessKey;
			m_chkUseSecure.Checked = UseHttps;			
        }

		private void ConnectForm_FormClosed(object sender, FormClosedEventArgs e) {

		}

		private void m_btnCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
