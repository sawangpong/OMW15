using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OMW15.Tools.ToolControls
{
	public class NumbericTextBox : TextBox
	{
		const string MESSAGE_ERROR_INPUT = "ค่าต้องเป็นตัวเลขเท่านั้น";

		// constructor
		public NumbericTextBox()
		{
			this.MaxLength = 15;
			this.Text = string.Format("{0:N2}", 0.00m);
		}

		private bool CurrencyOnly(string Target)
		{
			try
			{
				decimal _n = Convert.ToDecimal(Target);
				return true;
			}
			catch
			{
				return false;
			}
		}

		private Boolean CurrencyOnly(string Target, KeyPressEventArgs e)
		{
			char CurrentChar = e.KeyChar;

			if ((((int)CurrentChar >= 48) && ((int)CurrentChar <= 57)) ||
				(CurrentChar.ToString() == ".") &&
				(Target.IndexOf(".") == -1) ||
				(CurrentChar == (char)Keys.Back))
			{
				return false;
			}
			else
			{
				return true;
			}

		} // end CurrencyOnly

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if (e.KeyChar < '0' || e.KeyChar > '9')
			{
				e.Handled = true;
			}

			if (e.KeyChar == (char)Keys.Back)
			{
				e.Handled = false;
			}

			if (e.KeyChar == '.')
			{
				e.Handled = false;
			}
			if (Convert.ToBoolean(e.KeyChar == '.' && Convert.ToBoolean(this.Text.IndexOf(","))))
			{
				e.Handled = true;
			}

			e.Handled = this.CurrencyOnly(this.Text, e);

			if (e.Handled && (e.KeyChar != (char)Keys.Enter))
			{
				MessageBox.Show(MESSAGE_ERROR_INPUT, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.SelectAll();
				this.Focus();
			}
			else if (e.KeyChar == (char)Keys.Enter)
			{
				e.Handled = true;
			}

			this.Invalidate();
		}

		protected override void OnValidating(CancelEventArgs e)
		{
			base.OnValidating(e);
			e.Cancel = !this.CurrencyOnly(this.Text);
			this.Invalidate();
		}
	}
}
