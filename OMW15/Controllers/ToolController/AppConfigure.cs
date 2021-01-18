using System;
using Microsoft.Win32;
using OMW15.Shared;

namespace OMW15.Controllers.ToolController
{
	public class AppConfigure
	{
		#region class field member

		private string MasterRegistryKey = string.Empty;

		#endregion

		// class constructor
		public AppConfigure(string MasterRegistryKey)
		{
			IsFoundRegistryKey = CheckExistingRegistry(MasterRegistryKey);
		} // end AppConfigure -- constructor

		#region class properties

		public bool IsFoundRegistryKey{get; set;}

		#endregion

		#region class helper

		private bool CheckExistingRegistry(string Key)
		{
			var _result = false;

			foreach (var _key in Registry.CurrentUser.GetSubKeyNames())
				if (_key == Key)
				{
					MasterRegistryKey = string.Format("{0}\\{1}", Registry.CurrentUser, _key);
					_result = true;

					// get current registry values as supply key
					ReadAppRegistryConfiguration(Key);
					break;
				}
				else
				{
					_result = false;
				}
			return _result;
		} // end CheckExistingRegistry

		public static void ReadAppRegistryConfiguration(string Key)
		{
			try
			{
				using (var _rk = Registry.CurrentUser.OpenSubKey(Key))
				{
					omglobal.COMPANY_ID = _rk.GetValue("CompanyId").ToString();

					// -- read registry for default server
					omglobal.SysServer = _rk.GetValue("ServerName").ToString();
					omglobal.SysDatabase = _rk.GetValue("DatabaseName").ToString();
					omglobal.SysAdmin = _rk.GetValue("DbAdminUser").ToString();
					omglobal.SysPassword = _rk.GetValue("DbAdminPassword").ToString();

					// -- read registry for ERP server
					omglobal.ERPServer = _rk.GetValue("ERP_ServerName").ToString();
					omglobal.ERPDatabase = _rk.GetValue("ERP_DatabaseName").ToString();
					omglobal.ERPAdmin = _rk.GetValue("ERP_DbAdminUser").ToString();
					omglobal.ERPPassword = _rk.GetValue("ERP_DbAdminPassword").ToString();
				}
			}
			catch
			{
			}
		} // end ReadAppRegistryConfiguration

		public bool CreateRegistry(string Key,
			string CompanyId,
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
			var _result = false;
			try
			{
				using (var _rk = Registry.CurrentUser.CreateSubKey(Key))
				{
					// create values under sub-key -> Key (parameter)
					_rk.SetValue("CompanyId", CompanyId);
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
			catch (Exception ex)
			{
				throw new Exception("Error Create Configuration.....", ex);
			}

			return _result;
		} // end 

		#endregion
	}
}