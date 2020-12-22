using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using OMW15.Shared;
using OMControls;

namespace OMW15.Tools
{
	public partial class Member : Form
	{
		#region class field member
		private OLDMOONEF _om;
		private ActionMode _mode = ActionMode.None;
		private int _userId = 0;
		private int _selectedPermissionId = 0;

		#endregion

		#region class property
		public int UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				_userId = value;
			}
		}
		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.btnSave.Enabled = !string.IsNullOrEmpty(this.txtUserName.Text);

		} // end UpdateUI

		private void GetPermissionList()
		{
			this.cbxPermission.DataSource = OMControls.OMDataUtils.GetValueList<OMShareSysConfigEnums.UserPermission>();
			this.cbxPermission.DisplayMember = "Value";
			this.cbxPermission.ValueMember = "Key";

		} // end GetPermissionList

		private bool GetSamePassword(string Password, string ConfirmPassword)
		{
			return ((Password.Length == ConfirmPassword.Length) ? ((Password.Equals(ConfirmPassword)) ? true : false) : false);

		} // end GetSamePassword


		private void GetUserProperties(int UserId)
		{
			LOGIN member = _om.LOGINs.FirstOrDefault(x => x.id == UserId);

			this.txtUserName.Text = member.uname;
			this.cbxPermission.SelectedValue = member.permissionid;
			this.txtPassword.Text = member.password;
			this.txtConfirmPassword.Text = this.txtPassword.Text;
			this.chkActiveUser.Checked = member.islock;

			this.UpdateUI();

		} // end GetUserProperties

		private void SetNewMemberUI()
		{
			this.txtUserName.Text = string.Empty;
			this.txtPassword.Text = string.Empty;
			this.cbxPermission.SelectedValue = (int)OMShareSysConfigEnums.UserPermission.User;
			this.chkActiveUser.Checked = false;
			this.txtConfirmPassword.Text = string.Empty;

			this.UpdateUI();

		} // end SetNewMemberUI

		private void SaveNewMember()
		{
			using (var _scope = new System.Transactions.TransactionScope())
			{
				try
				{
					LOGIN _member = new LOGIN();
					_member.islock = this.chkActiveUser.Checked;
					_member.password = this.txtPassword.Text;
					_member.permissionid = _selectedPermissionId;
					_member.auditclass = this.cbxPermission.Text;
					_member.uname = this.txtUserName.Text;
					_om.LOGINs.Add(_member);
					_om.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Update Member properties error !!!!!", ex);
				}
			}
		} // end SaveNewMember

		private void UpdateMemberProperties(int UserId)
		{
			using (var _scope = new System.Transactions.TransactionScope())
			{
				try
				{
					var _member = (from m in _om.LOGINs
								   where m.id == UserId
								   select m).FirstOrDefault();

					_member.password = this.txtPassword.Text;
					_member.permissionid = _selectedPermissionId;
					_member.auditclass = this.cbxPermission.Text;
					_member.islock = this.chkActiveUser.Checked;

					_om.SaveChanges();
					_scope.Complete();

				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Update Member properties error !!!!!", ex);
				}
			} // end scope

		} // end UpdateMemberProperties

		#endregion


		public Member()
		{
			InitializeComponent();
		}

		private void Member_Load(object sender, EventArgs e)
		{
			// loading permission list
			this.GetPermissionList();

			// create object
			_om = new OLDMOONEF();

			// setting mode and display
			_mode = (_userId == 0 ? ActionMode.Add : ActionMode.Edit);
			this.lbMode.Text = _mode.ToString();

			// load data as mode
			switch (_mode)
			{
				case ActionMode.Add:
					this.SetNewMemberUI();
					break;
				case ActionMode.Edit:
					this.GetUserProperties(_userId);
					break;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					this.SaveNewMember();
					break;
				case ActionMode.Edit:
					this.UpdateMemberProperties(_userId);
					break;
			}
			this.Close();
		}

		private void cbxPermission_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedPermissionId = Convert.ToInt32(this.cbxPermission.SelectedValue);
			}
			catch
			{
				_selectedPermissionId = 0;
			}
		}

		private void Password_TextChanged(object sender, EventArgs e)
		{
			this.btnSave.Enabled = this.GetSamePassword(this.txtPassword.Text, this.txtConfirmPassword.Text);
		}

		private void txtUserName_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void btnShowPassword_Click(object sender, EventArgs e)
		{
			this.txtPassword.UseSystemPasswordChar = !this.txtPassword.UseSystemPasswordChar;
			this.txtConfirmPassword.UseSystemPasswordChar = this.txtPassword.UseSystemPasswordChar;
		}

		private void Member_FormClosing(object sender, FormClosingEventArgs e)
		{
			//_om.Dispose();
		}
	}
}
