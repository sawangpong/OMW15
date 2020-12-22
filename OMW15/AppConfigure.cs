using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using OMControls;
using OMW15.Shared;

namespace OMW15
{
	public class AppConfigure
	{
		#region class field member

		#endregion

		#region class properties
		public string MasterRegistryKey
		{
			get;
			set;
		}

		public bool IsFoundRegistryKey
		{
			get;
			set;
		}

		public string CompanyId
		{
			get;
			set;
		}


		public string ServerName
		{
			get;
			set;
		}

		public string DatabaseName
		{
			get;
			set;
		}

		public string DbAdminUser
		{
			get;
			set;
		}

		public string DbAdminPassword
		{
			get;
			set;
		}

		public string ERP_ServerName
		{
			get;
			set;
		}

		public string ERP_DatabaseName
		{
			get;
			set;
		}

		public string ERP_DbAdminUser
		{
			get;
			set;
		}

		public string ERP_DbAdminPassword
		{
			get;
			set;
		}

		public string ImageLocationPath
		{
			get;
			set;
		}

		public string UserWorkGroup
		{
			get;
			set;
		}

		#endregion

		#region class helper

		private bool CheckExistingRegistry(string Key)
		{
			bool _result = false;

			foreach(string _key in Registry.CurrentUser.GetSubKeyNames())
			{
				if(_key == Key)
				{
					this.MasterRegistryKey = string.Format("{0}\\{1}", Registry.CurrentUser.ToString(), _key);
					_result = true;

					// get current registry values as supply key
					this.ReadAppRegistryConfiguration(Key);
					break;
				}
				else
				{
					_result = false;
				}
			}
			return _result;

		} // end CheckExistingRegistry

		private void ReadAppRegistryConfiguration(string Key)
		{
			//// debug
			//string[] _keyNames = new string[] { };
			//using (RegistryKey _rk = Registry.CurrentUser.OpenSubKey(Key))
			//{
			//	_keyNames = _rk.GetValueNames();
			//}

			//StringBuilder s = new StringBuilder();
			//foreach (string n in _keyNames)
			//{
			//	s.Append(n);
			//	s.AppendLine();
			//}
			//MessageBox.Show(s.ToString());
			//// end debug


			try
			{
				using(RegistryKey _rk = Registry.CurrentUser.OpenSubKey(Key))
				{
					this.CompanyId = _rk.GetValue("CompanyId").ToString();
					this.UserWorkGroup = (string)_rk.GetValue("UserWorkGroup", OMShareSysConfigEnums.WorkGroups.SystemAdim.ToString());

					// -- read registry for default server
					this.ServerName = _rk.GetValue("ServerName").ToString();
					this.DatabaseName = _rk.GetValue("DatabaseName").ToString();
					this.DbAdminUser = _rk.GetValue("DbAdminUser").ToString();
					this.DbAdminPassword = _rk.GetValue("DbAdminPassword").ToString();

					// -- read registry for ERP server
					this.ERP_ServerName = _rk.GetValue("ERP_ServerName").ToString();
					this.ERP_DatabaseName = _rk.GetValue("ERP_DatabaseName").ToString();
					this.ERP_DbAdminUser = _rk.GetValue("ERP_DbAdminUser").ToString();
					this.ERP_DbAdminPassword = _rk.GetValue("ERP_DbAdminPassword").ToString();
					this.ImageLocationPath = _rk.GetValue("ImageLocationPath").ToString();
				}
			}
			catch
			{
				//throw new Exception("Get Configuration from Registry error", ex);
				this.CompanyId = omglobal.COMPANY_ID;
				this.UserWorkGroup = omglobal.USER_WORKGROUP;

				// -- read registry for default server
				this.ServerName = omglobal.SysServer;
				this.DatabaseName = omglobal.SysDatabase;
				this.DbAdminUser = omglobal.SysAdmin;
				this.DbAdminPassword = omglobal.SysPassword;

				// -- read registry for ERP server
				this.ERP_ServerName = omglobal.ERPServer;
				this.ERP_DatabaseName = omglobal.ERPDatabase;
				this.ERP_DbAdminUser =omglobal.ERPAdmin;
				this.ERP_DbAdminPassword = omglobal.ERPPassword;
				this.ImageLocationPath = omglobal.IMAGE_LOCATION_PATH;
			}

		} // end ReadAppRegistryConfiguration

		public bool CreateRegistry(string Key,
									string CompanyId,
									string UserWorkGroup,
									string DefaultServerName,
									string DefaultDatabaseName,
									string DefaultDbAdminUser,
									string DefaultDbAdminPassword,
									string ERPServerName,
									string ERPDatabaseName,
									string ERPDbAdminUser,
									string ERPDbAdminPassword,
									string ImageLocationPath)
		{
			bool _result = false;
			try
			{
				using(RegistryKey _rk = Registry.CurrentUser.CreateSubKey(Key))
				{
					// create values under sub-key -> Key (parameter)
					_rk.SetValue("CompanyId", CompanyId);
					_rk.SetValue("UserWorkGroup", UserWorkGroup);
					_rk.SetValue("ServerName", DefaultServerName);
					_rk.SetValue("DatabaseName", DefaultDatabaseName);
					_rk.SetValue("DbAdminUser", DefaultDbAdminUser);
					_rk.SetValue("DbAdminPassword", DefaultDbAdminPassword);
					_rk.SetValue("ERP_ServerName", ERPServerName);
					_rk.SetValue("ERP_DatabaseName", ERPDatabaseName);
					_rk.SetValue("ERP_DbAdminUser", ERPDbAdminUser);
					_rk.SetValue("ERP_DbAdminPassword", ERPDbAdminPassword);
					_rk.SetValue("ImageLocationPath", ImageLocationPath);
				}
				_result = true;
			}
			catch(Exception ex)
			{
				throw new Exception("Error Create Configuration.....", ex);
			}

			return _result;
		} // end 

		#endregion

		// class constructor
		public AppConfigure(string MasterRegistryKey)
		{
			this.IsFoundRegistryKey = this.CheckExistingRegistry(MasterRegistryKey);

		} // end AppConfigure -- constructor
	}
}
