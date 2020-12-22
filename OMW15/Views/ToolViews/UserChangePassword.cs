using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace OMW15.Views.ToolViews
{
	public partial class UserChangePassword : Form
	{
		public UserChangePassword()
		{
			InitializeComponent();
		}

		private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char) Keys.Enter) btnAcceptChangePassword.PerformClick();
		}

		private void UserChangePassword_Load(object sender, EventArgs e)
		{
			// create object
			_om = new OLDMOONEF1();

			// loading data
			txtOldPassword.Text = _oldPassword;
		}

		private void btnAcceptChangePassword_Click(object sender, EventArgs e)
		{
			if (CheckNewPassword(txtNewPassword.Text, txtConfirmPassword.Text))
				if (UpdatePassword(_userName, txtOldPassword.Text, txtNewPassword.Text))
					MessageBox.Show("Password has been changed successfully", "Message", MessageBoxButtons.OK,
						MessageBoxIcon.Information);
		}

		private void Password_TextChanged(object sender, EventArgs e)
		{
			CheckNewPassword(txtNewPassword.Text, txtConfirmPassword.Text);
		}

		private void UserChangePassword_FormClosing(object sender, FormClosingEventArgs e)
		{
			//_om.Dispose();
		}

		#region class field member

		private OLDMOONEF1 _om;
		private string _userName = string.Empty;
		private string _oldPassword = string.Empty;

		#endregion

		#region class property

		public string UserName
		{
			set { _userName = value; }
		}

		public string OldPassword
		{
			set { _oldPassword = value; }
		}

		#endregion

		#region class helper

		private bool CheckNewPassword(string NewPassword, string ConfirmPassword)
		{
			var _success = false;

			if (NewPassword.Length == ConfirmPassword.Length)
			{
				if (NewPassword.Equals(ConfirmPassword))
				{
					_success = true;
				}
				else
				{
					_success = false;
					MessageBox.Show("Password is not same !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				_success = false;
				MessageBox.Show("Length of password is not equal !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			return _success;
		} // end CheckNewPassword

		private bool UpdatePassword(string UserName, string OldPassword, string NewPassword)
		{
			var _retValue = false;

			using (var _scope = new TransactionScope())
			{
				try
				{
					var _up = (from u in _om.LOGINs
						where u.uname == UserName
						      && u.password == OldPassword
						select u).Single();
					_up.password = NewPassword;

					_om.SaveChanges();
					_scope.Complete();
					_retValue = true;
				}
				catch (OptimisticConcurrencyException ex)
				{
					_retValue = false;
					throw new Exception(string.Format("{0}\n\n {1}", "Update user password", "Try again!!!"), ex);
				}
			}

			return _retValue;
		} // end UpdatePassword

		#endregion
	}
}