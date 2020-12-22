using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMW15.Shared;
using OMControls;

namespace OMW15.Tools
{
	public partial class InputBox : Form
	{
		// Class field member 
		private string _value = string.Empty;
		private InputBoxTypeValue _typeNeed = InputBoxTypeValue.Text;

		#region class property

		public string Title
		{
			set
			{
				this.lbTitle.Text = value;
			}
		}

		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		#endregion

		#region helper

		private Boolean CurrencyOnly(string Target, KeyPressEventArgs e)
		{
			char CurrentChar = e.KeyChar;
			if (_typeNeed == InputBoxTypeValue.Number)
			{
				if ((((int)CurrentChar >= 48 && (int)CurrentChar <= 57)) ||
					((CurrentChar.ToString() == ".") && (Target.IndexOf(".") == -1)) ||
					(CurrentChar == (char)Keys.Back))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return false;
			}
		} // end CurrencyOnly

		#endregion

		#region constructor
		public InputBox(string Title, InputBoxTypeValue TypeNeed)
		{
			InitializeComponent();
			this.lbTitle.Text = Title;
			_typeNeed = TypeNeed;
		}

		public InputBox(string Title, InputBoxTypeValue TypeNeed,string DefaultValue)
		{
			InitializeComponent();
			this.lbTitle.Text = Title;
			_value = DefaultValue;
			_typeNeed = TypeNeed;
		}

		#endregion

		private void InputBox_Load(object sender, EventArgs e)
		{
			if (_typeNeed == InputBoxTypeValue.Number)
			{
				this.txtMessage.MaxLength = 10;
			}
			else
			{
				this.txtMessage.MaxLength = 50;
			}
			this.txtMessage.Text = _value.ToString();
			this.txtMessage.Focus();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			_value = this.txtMessage.Text;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			_value = string.Empty;
		}

		private void txtMassgae_KeyPress(object sender, KeyPressEventArgs e)
		{
			switch (_typeNeed)
			{
				case InputBoxTypeValue.Text:
					if (e.KeyChar == (char)Keys.Enter)
					{
						this.btnOK.PerformClick();
					}
					break;
				case InputBoxTypeValue.Number:

					if (e.KeyChar < '0' || e.KeyChar > '9')
					{
						e.Handled = true;
					}

					if (e.KeyChar == (char)Keys.Back)
					{
						e.Handled = false;
					}
					e.Handled = this.CurrencyOnly(this.txtMessage.Text, e);


					if (e.KeyChar == (char)Keys.Enter)
					{
						e.Handled = true;
						this.btnOK.PerformClick();
					}
					break;
			}
		}
	}
}
