using System;
using System.Windows.Forms;
using OMW15.Shared;

namespace OMW15.Views.ToolViews
{
	public partial class InputBox : Form
	{
		// Class field member 
		//private string _value = string.Empty;
		private readonly InputBoxTypeValue _typeNeed = InputBoxTypeValue.Text;

		#region helper

		private bool CurrencyOnly(string Target, KeyPressEventArgs e)
		{
			var CurrentChar = e.KeyChar;
			if (_typeNeed == InputBoxTypeValue.Number)
				if (CurrentChar >= 48 && CurrentChar <= 57 ||
				    CurrentChar.ToString() == "." && Target.IndexOf(".") == -1 ||
				    CurrentChar == (char) Keys.Back) return false;
				else return true;
			return false;
		} // end CurrencyOnly

		#endregion

		private void InputBox_Load(object sender, EventArgs e)
		{
			if (_typeNeed == InputBoxTypeValue.Number) txtMessage.MaxLength = 10;
			else txtMessage.MaxLength = 50;
			txtMessage.Text = Value;
			txtMessage.Focus();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Value = txtMessage.Text;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Value = string.Empty;
		}

		private void txtMassgae_KeyPress(object sender, KeyPressEventArgs e)
		{
			switch (_typeNeed)
			{
				case InputBoxTypeValue.Text:
					if (e.KeyChar == (char) Keys.Enter) btnOK.PerformClick();
					break;
				case InputBoxTypeValue.Number:

					if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;

					if (e.KeyChar == (char) Keys.Back) e.Handled = false;
					e.Handled = CurrencyOnly(txtMessage.Text, e);


					if (e.KeyChar == (char) Keys.Enter)
					{
						e.Handled = true;
						btnOK.PerformClick();
					}
					break;
			}
		}

		#region class property

		public string Title
		{
			set { lbTitle.Text = value; }
		}

		public string Value { get; set; }

		#endregion

		#region constructor

		public InputBox(string Title, InputBoxTypeValue TypeNeed)
		{
			InitializeComponent();
			lbTitle.Text = Title;
			_typeNeed = TypeNeed;
		}

		public InputBox(string Title, InputBoxTypeValue TypeNeed, string DefaultValue)
		{
			InitializeComponent();
			lbTitle.Text = Title;
			Value = DefaultValue;
			_typeNeed = TypeNeed;
		}

		#endregion
	}
}