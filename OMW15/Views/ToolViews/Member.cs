using System;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;
using System.Data.Entity.Core;

namespace OMW15.Views.ToolViews
{
	public partial class Member : Form
	{
		public Member()
		{
			InitializeComponent();

			// create object
			_om = new OLDMOONEF1();

			// loading permission list
			GetPermissionList();
			GetWorkGroupList();


			CenterToParent();
		}

		#region class property

		public int UserId { get; set; }

		#endregion

		private void Member_Load(object sender, EventArgs e)
		{

			// setting mode and display
			_mode = UserId == 0 ? ActionMode.Add : ActionMode.Edit;
			lbMode.Text = _mode.ToString();


			// load data as mode
			switch(_mode)
			{
				case ActionMode.Add:
					SetNewMemberUI();
					break;
				case ActionMode.Edit:
					GetUserProperties(UserId);
					break;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			switch(_mode)
			{
				case ActionMode.Add:
					SaveNewMember();
					break;
				case ActionMode.Edit:
					UpdateMemberProperties(UserId);
					break;
			}
			Close();
		}

		private void cbxPermission_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				//_selectedPermissionId = Convert.ToInt32(cbxPermission.SelectedValue);
				_selectedPermissionId = (int)Enum.Parse(typeof(Shared.OMShareSysConfigEnums.UserPermission), cbxPermission.Text);
			}
			catch
			{
				_selectedPermissionId = 0;
			}

			lbPermission.Text = _selectedPermissionId.ToString();
		}

		private void Password_TextChanged(object sender, EventArgs e)
		{
			btnSave.Enabled = GetSamePassword(txtPassword.Text, txtConfirmPassword.Text);
		}

		private void txtUserName_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnShowPassword_Click(object sender, EventArgs e)
		{
			txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
			txtConfirmPassword.UseSystemPasswordChar = txtPassword.UseSystemPasswordChar;
		}

		private void Member_FormClosing(object sender, FormClosingEventArgs e)
		{
			//_om.Dispose();
		}

		#region class field member

		private OLDMOONEF1 _om;
		private ActionMode _mode = ActionMode.None;
		private int _selectedPermissionId;
		private int _selectedWorkGroup;

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnSave.Enabled = !string.IsNullOrEmpty(txtUserName.Text);
		} // end UpdateUI

		private void GetPermissionList()
		{
			//cbxPermission.DataSource = OMDataUtils.GetValueList<OMShareSysConfigEnums.UserPermission>();
			cbxPermission.DataSource = EnumWithName<Shared.OMShareSysConfigEnums.UserPermission>.ParseEnum();
			cbxPermission.DisplayMember = "Name";
			cbxPermission.ValueMember = "Value";

		} // end GetPermissionList

		private bool GetSamePassword(string Password, string ConfirmPassword)
		{
			return Password.Length == ConfirmPassword.Length ? (Password.Equals(ConfirmPassword) ? true : false) : false;
		} // end GetSamePassword


		private void GetWorkGroupList()
		{
			cbxWorkGroup.DataSource = EnumWithName<OMShareSysConfigEnums.WorkGroups>.ParseEnum();
			cbxWorkGroup.DisplayMember = "Name";
			cbxWorkGroup.ValueMember = "Value";

		} // end GetWorkGroupList

		private void GetUserProperties(int UserId)
		{
			var member = _om.LOGINs.FirstOrDefault(x => x.id == UserId);

			txtUserName.Text = member.uname;
			cbxPermission.SelectedValue = member.permissionid;
			txtPassword.Text = member.password;
			txtConfirmPassword.Text = txtPassword.Text;
			chkActiveUser.Checked = member.islock;
			cbxWorkGroup.SelectedValue = member.DepartmentID;

			UpdateUI();

		} // end GetUserProperties

		private void SetNewMemberUI()
		{
			txtUserName.Text = string.Empty;
			txtPassword.Text = string.Empty;
			cbxPermission.SelectedValue = (int)OMShareSysConfigEnums.UserPermission.User;
			chkActiveUser.Checked = false;
			txtConfirmPassword.Text = string.Empty;
			cbxWorkGroup.SelectedValue = (int)OMShareSysConfigEnums.WorkGroups.None;

			UpdateUI();
		} // end SetNewMemberUI

		private void SaveNewMember()
		{
			using(var _scope = new TransactionScope())
			{
				try
				{
					var _member = new LOGIN();
					_member.islock = chkActiveUser.Checked;
					_member.password = txtPassword.Text;
					_member.permissionid = _selectedPermissionId;
					_member.auditclass = cbxPermission.Text;
					_member.uname = txtUserName.Text;
					_member.DepartmentID = _selectedWorkGroup;
					_om.LOGINs.Add(_member);
					_om.SaveChanges();
					_scope.Complete();
				}
				catch(OptimisticConcurrencyException ex)
				{
					throw new Exception("Update Member properties error !!!!!", ex);
				}
			}
		} // end SaveNewMember

		private void UpdateMemberProperties(int UserId)
		{
			using(var _scope = new TransactionScope())
			{
				try
				{
					var _member = (from m in _om.LOGINs
								   where m.id == UserId
								   select m).Single();

					_member.password = txtPassword.Text;
					_member.permissionid = _selectedPermissionId;
					_member.DepartmentID = _selectedWorkGroup;
					_member.auditclass = cbxPermission.Text;
					_member.islock = chkActiveUser.Checked;

					_om.SaveChanges();
					_scope.Complete();
				}
				catch(OptimisticConcurrencyException ex)
				{
					throw new Exception("Update Member properties error !!!!!", ex);
				}
			} // end scope
		} // end UpdateMemberProperties

		#endregion

		private void cbxWorkGroup_SelectionChangeCommitted(object sender, EventArgs e)
		{

		}

		private void cbxWorkGroup_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedWorkGroup = (int)Enum.Parse(typeof(Shared.OMShareSysConfigEnums.WorkGroups), this.cbxWorkGroup.Text);
			}
			catch
			{
				_selectedWorkGroup = (int)Shared.OMShareSysConfigEnums.WorkGroups.None;
			}
			lbGroup.Text = _selectedWorkGroup.ToString();
		}
	}
}