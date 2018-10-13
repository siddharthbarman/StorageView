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
	public enum LeaseType
	{
		Infinite,
		Fixed
	}

	public partial class LeaseForm : Form
	{
		public LeaseForm() {
			InitializeComponent();
		}

		public LeaseType LeaseType { get; set; }

		public TimeSpan? LeasePeriod { get; set; }

		void SetNumericAccess() {
			m_numLeaseSec.Enabled = !m_leaseTypeInfinite.Checked;
		}

		private void m_leaseTypeInfinite_CheckedChanged(object sender, EventArgs e) {
			SetNumericAccess();
		}

		private void m_btnOK_Click(object sender, EventArgs e) {
			if (m_leaseTypeFixed.Checked) {
				LeaseType = LeaseType.Fixed;
				LeasePeriod = new TimeSpan(0, 0, (int)m_numLeaseSec.Value);
			}
			else {
				LeaseType = LeaseType.Infinite;
			}
			DialogResult = DialogResult.OK;
		}
	}
}
