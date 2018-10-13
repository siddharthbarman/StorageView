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
	public partial class InputForm : Form
	{
		public InputForm() {
			InitializeComponent();
		}

		public InputForm(string infoText, string title, string inputText = "", bool allowEmptyInput = true) 
			: this()  {
			InfoText = infoText;
			Title = title;
			InputText = inputText;
			AllowEmptyInput = allowEmptyInput;
		}

		public string Title {
			get;
			set;
		}

		public string InfoText {
			get;
			set;
		}

		public string InputText {
			get;
			set;
		}

		public bool AllowEmptyInput {
			get;
			set;
		}

		private void InputForm_Load(object sender, EventArgs e) {
			m_text.Text = InputText;
			m_lblInfo.Text = InfoText;
			Text = Title;
		}

		private void m_btnOK_Click(object sender, EventArgs e) {
			if (!AllowEmptyInput) {
				if (string.IsNullOrEmpty(m_text.Text)) {
					m_lblError.Text = "Input string cannot be empty!";
					m_text.Focus();
					return;
				}
			}

			InputText = m_text.Text;
			DialogResult = DialogResult.OK;
		}
	}
}
