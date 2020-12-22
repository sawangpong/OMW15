using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Tools
{
	public partial class UserChangePassword : Form
	{
		#region class field member

		private OLDMOONEF _om;
		private string _userName = string.Empty;
		private string _oldPassword = string.Empty;

		#endregion

		#region class property

		public string UserName
		{
			set
			{
				_userName = value;
			}
		}

		public string OldPassword
		{
			set
			{
				_oldPassword = value;
			}
		}

		#endregion

		#region class helper

		private bool CheckNewPassword(string NewPassword, string ConfirmPassword)
		{
			bool _success = false;

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
			bool _retValue = false;

			using (System.Transactions.TransactionScope _scope = new System.Transactions.TransactionScope())
			{
				try
				{
					var _up = (from u in _om.LOGINs
							   where (u.uname == UserName) 
							   && (u.password == OldPassword)
							   select u).FirstOrDefault();
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

		public UserChangePassword()
		{
			InitializeComponent();
		}

		private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				this.btnAcceptChangePassword.PerformClick();
			}
		}

		private void UserChangePassword_Load(object sender, EventArgs e)
		{
			// create object
			_om = new OLDMOONEF();

			// loading data
			this.txtOldPassword.Text = _oldPassword;
		}

		private void btnAcceptChangePassword_Click(object sender, EventArgs e)
		{
			if (this.CheckNewPassword(this.txtNewPassword.Text, this.txtConfirmPassword.Text))
			{
				// Update Password
				if (this.UpdatePassword(_userName, this.txtOldPassword.Text, this.txtNewPassword.Text) == true)
				{
					MessageBox.Show("Password has been changed successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void Password_TextChanged(object sender, EventArgs e)
		{
			this.CheckNewPassword(this.txtNewPassword.Text, this.txtConfirmPassword.Text);
		}

		private void UserChangePassword_FormClosing(object sender, FormClosingEventArgs e)
		{
			//_om.Dispose();
		}
	}
}
