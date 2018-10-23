using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageView {
	public partial class NameWithMetadataForm : Form {
		public NameWithMetadataForm() {
			InitializeComponent();
		}

		public string EntityName {
			get;
			set;
		}

		public Dictionary<string, string> Metadata {
			get {
				return m_dict;
			}
		}

		public string Title {
			get;
			set;
		}

		public bool DoNotAllowEmptyName {
			get;
			set;
		}

		private void InitializeUI() {
			this.Text = Title;
			m_txtName.Text = EntityName;

			int counter = 0;
			foreach(string key in Metadata.Keys) {
				if (counter > 1) break;
				if (counter == 0) {
					m_txtKey1.Text = key;
					m_txtValue1.Text = Metadata[key];
				}
				else {
					m_txtKey2.Text = key;
					m_txtValue2.Text = Metadata[key];
				}
			}
		}

		void PopulateProperties() {
			m_dict.Clear();
			if (m_txtKey1.Text.Trim().Length > 0)
				m_dict.Add(m_txtKey1.Text, m_txtValue1.Text);
			if (m_txtKey2.Text.Trim().Length > 0)
				m_dict.Add(m_txtKey2.Text, m_txtValue2.Text);
			EntityName = m_txtName.Text;
		}

		private Dictionary<string, string> m_dict = new Dictionary<string, string>();

		private void NameWithMetadataForm_Load(object sender, EventArgs e) {
			InitializeUI();
		}

		private void m_btnOK_Click(object sender, EventArgs e) {
			if (DoNotAllowEmptyName) {
				if (string.IsNullOrEmpty(m_txtName.Text)) {
					MessageBox.Show("Name cannot be empty!", "Error", MessageBoxButtons.OK, 
						MessageBoxIcon.Error);
					m_txtName.Focus();
					return;
				}
			}

			if (m_txtKey1.Text != "" || m_txtKey2.Text != "") {
				if (m_txtKey1.Text == m_txtKey2.Text) {
					MessageBox.Show("Metadata keys should be unique!", "Error", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}

			PopulateProperties();			
			DialogResult = DialogResult.OK;
		}
	}
}
