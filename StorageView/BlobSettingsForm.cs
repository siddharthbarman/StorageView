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
	public partial class BlobSettingsForm : Form
	{
		public BlobSettingsForm() {
			InitializeComponent();
			
		}

		public object PropertyObject { get; set; }

		private void BlobSettingsForm_Load(object sender, EventArgs e) {
			m_properties.SelectedObject = PropertyObject;
		}

		private void m_btnOK_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}
	}
}
