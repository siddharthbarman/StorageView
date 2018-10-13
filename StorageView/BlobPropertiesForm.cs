using Microsoft.WindowsAzure.Storage.Blob;
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
	public partial class BlobPropertiesForm : Form {
		public BlobPropertiesForm() {
			InitializeComponent();
		}

		public IDictionary<string, string> Pairs {
			get { return m_pairs; }
		}

		public IEnumerable<ListBlockItem> Blocks { get; set; }

		public bool HasChanges {
			get {
				return m_table.GetChanges() != null;
			}
		}

		public LeaseState LeaseState { get; set; }

		public LeaseStatus LeaseStatus { get; set; }

		public string LeaseID { get; set; }

		private void m_btnOK_Click(object sender, EventArgs e) {
			m_pairs.Clear();
			foreach (DataRow row in m_table.Rows) {
				m_pairs.Add((string)row[0], (string)row[1]);
			}
			DialogResult = DialogResult.OK;
		}

		private Dictionary<string, string> m_pairs = new Dictionary<string, string>();
		private DataTable m_table = new DataTable();

		private void NameVauleForm_Load(object sender, EventArgs e) {
			m_table.Columns.Add("Name", typeof(string));
			m_table.Columns.Add("Value", typeof(string));
			m_dataGrid.DataSource = m_table;
			foreach(string key in m_pairs.Keys) {
				m_table.Rows.Add(key, m_pairs[key]);
			}
			m_table.AcceptChanges();

			if (Blocks != null) {
				m_blockList.Items.Clear();
				foreach(var block in Blocks) {
					ListViewItem item = m_blockList.Items.Add(block.Name);
					item.SubItems.Add(block.Length.ToString());
					item.SubItems.Add(block.Committed.ToString());
				}
			}

			m_txtLeaseID.Text = LeaseID;
			m_txtLeaseState.Text = LeaseState.ToString();
			m_txtLeaseStatus.Text = LeaseStatus.ToString();
		}
	}
}
