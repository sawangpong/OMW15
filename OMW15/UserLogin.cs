using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;

namespace OMW15
{
	public partial class UserLogin : Form
	{
		#region class field

		private OLDMOONEF _om;
		private string _machineName = System.Environment.MachineName;

		#endregion

		#region class property

		public int UserId
		{
			get;
			set;
		}

		public int PermissionId
		{
			get;
			set;
		}

		public string PermissionClass
		{
			get;
			set;
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.btnLogin.Enabled = !string.IsNullOrEmpty(this.txtUserName.Text);

		} // end UpdateUI

		private int GetUserPermission(string UserName, string Password)
		{
			int _permissionId = 0;

			LOGIN ul = _om.LOGINs.FirstOrDefault(x => x.uname == UserName && x.password == Password);
			if (ul != null)
			{
				_permissionId = ul.permissionid;
				this.PermissionClass = ul.auditclass;
			}
			else
			{
				_permissionId = 0;
				this.PermissionClass = string.Empty;
			}

			return _permissionId;

		} // end GetUserPermission

		private int GetNewUserId()
		{
			int _newId = 0;
			using (var _scope = new System.Transactions.TransactionScope())
			{
				try
				{
					USERLOG _log = new USERLOG();
					_log.APPNAME = omglobal.APP_NAME;
					_log.APPVERSION = Application.ProductVersion;
					_log.AUDITCLASS = this.PermissionClass;
					_log.DATABASENAME = omglobal.SysDatabase;
					_log.LOGINDT = DateTime.Now;
					_log.SERVERNAME = omglobal.SysServer;
					_log.USERNAME = this.txtUserName.Text;
					_log.WORKSTATION = _machineName;

					_om.USERLOGs.Add(_log);
					_om.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					_newId = 0;
					throw new Exception("ไม่สามารถลงชื่อเข้าใช้งานระบบได้....", ex);
				}
			} // end scope

			_newId = (int)(from u in _om.USERLOGs
						   select u).Max(id => id.USERID);

			return _newId;

		} // end GetNewUserId

		private void GetCurrentConfig()
		{
			this.txtMainServer.Text = omglobal.SysServer;
			this.txtSysDatabase.Text = omglobal.SysDatabase;
			this.txtERPServer.Text = omglobal.ERPServer;
			this.txtERPDatabase.Text = omglobal.ERPDatabase;

		} // end GetCurrentConfig

		#endregion


		public UserLogin()
		{
			InitializeComponent();
		}

		private void UserLogin_Load(object sender, EventArgs e)
		{
			// create object
			_om = new OLDMOONEF();

			// display current Configuration from registry
			this.GetCurrentConfig();

			// get user name from default environment
			this.txtUserName.Text = System.Environment.UserName;
			this.txtPassword.Text = string.Empty;
		}

		private void txtUserName_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			if ((this.PermissionId = this.GetUserPermission(this.txtUserName.Text, this.txtPassword.Text)) > 0)
			{
				omglobal.UserName = this.txtUserName.Text;
				omglobal.PassWord = this.txtPassword.Text;
				omglobal.WorkStation = _machineName;
				omglobal.PermisionId = this.PermissionId;
				omglobal.PermissionClass = this.PermissionClass;
				this.UserId = this.GetNewUserId();
			}
			else
			{
				this.UserId = 0;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.UserId = 0;
		}

		private void txt_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				this.btnLogin.PerformClick();
			}
		}

		private void lklbChangeAppConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			using (Tools.ConfigManager _configMgr = new Tools.ConfigManager(omglobal.APP_REGISTRY_SUBKEY))
			{
				_configMgr.Mode = ActionMode.Edit;
				_configMgr.StartPosition = FormStartPosition.CenterScreen;
				_configMgr.ShowDialog(this);

				// re-load Current Configuration
				this.GetCurrentConfig();
			}
		}

		private void UserLogin_FormClosing(object sender, FormClosingEventArgs e)
		{
			//_om.Dispose();
		}
	}
}
