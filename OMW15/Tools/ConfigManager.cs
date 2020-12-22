using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;

namespace OMW15.Tools
{
	public partial class ConfigManager : Form
	{
		#region class field
		private const string _title = "System Configuration Manager";
		private ActionMode _mode = ActionMode.None;
		private AppConfigure _appConfig;
		private string _workGroup = OMShareSysConfigEnums.WorkGroups.None.ToString();
		private string _registrySubKey = string.Empty;

		#endregion

		#region class properties

		public ActionMode Mode
		{
			set
			{
				_mode = value;
			}
		}

		public string RegistrySubKey
		{
			set
			{
				_registrySubKey = value;
			}
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.btnUpdateConfig.Enabled = !string.IsNullOrEmpty(this.txtCompanyId.Text)
											&& !string.IsNullOrEmpty(this.txtERPServer.Text)
											&& !string.IsNullOrEmpty(this.txtERPDatabase.Text)
											&& !string.IsNullOrEmpty(this.txtERPUser.Text)
											&& !string.IsNullOrEmpty(this.txtSysServer.Text)
											&& !string.IsNullOrEmpty(this.txtSysDatabase.Text)
											&& !string.IsNullOrEmpty(this.txtSystemAdmin.Text)
											&& !string.IsNullOrEmpty(this.txtImgLocationPath.Text);

		} // end UpdateUI

		private void ReadAppRegistryConfig()
		{
			if (_appConfig.IsFoundRegistryKey)
			{
				omglobal.COMPANY_ID = _appConfig.CompanyId;
				omglobal.USER_WORKGROUP = _appConfig.UserWorkGroup;
				omglobal.SysServer = _appConfig.ServerName;
				omglobal.SysDatabase = _appConfig.DatabaseName;
				omglobal.SysAdmin = _appConfig.DbAdminUser;
				omglobal.SysPassword = _appConfig.DbAdminPassword;
				omglobal.ERPServer = _appConfig.ERP_ServerName;
				omglobal.ERPDatabase = _appConfig.ERP_DatabaseName;
				omglobal.ERPAdmin = _appConfig.ERP_DbAdminUser;
				omglobal.ERPPassword = _appConfig.ERP_DbAdminPassword;
				omglobal.IMAGE_LOCATION_PATH = _appConfig.ImageLocationPath;

				this.ReadAppConfig();
			}
			else
			{
			}

		} // end ReadAppRegistryConfig

		private void ReadAppConfig()
		{
			//omglobal.GetCurrentAppSetting();
			//omglobal.GetCurrentERPConnectionString();
			//omglobal.GetCurrentSysConnectionString();

			OMControls.OMAppConfig _config = new OMControls.OMAppConfig();
			_config.GetCurrentConnectionString(omglobal.OM_CONNECT_NAME, ref omglobal.SysConnectionString);
			_config.GetCurrentConnectionString(omglobal.ERP_CONNECT_NAME, ref omglobal.ERPConnectionString);

		} // end ReadConfig

		private void UpdateAppSetting()
		{
			Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			_config.AppSettings.Settings["CompanyId"].Value = this.txtCompanyId.Text;

			// save and refresh
			_config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("configuration");

			// Update global value
			omglobal.COMPANY_ID = this.txtCompanyId.Text;
			this.UpdateCompanyProfile(omglobal.COMPANY_ID);

		} // end UpdateAppSetting

		private void UpdateCompanyProfile(string CompanyId)
		{
			using(var _scope = new System.Transactions.TransactionScope())
			{
				OLDMOONEF _oldmoon = new OLDMOONEF();
				var _cprofile = (from c in _oldmoon.COMPANY_PROFILES
								 where c.COMPANYID == CompanyId
								 select c).FirstOrDefault();
				try
				{
					_cprofile.IMAGE_LOCATION = this.txtImgLocationPath.Text;
					_oldmoon.SaveChanges();
					_scope.Complete();
				}
				catch(OptimisticConcurrencyException ex)
				{
					//_scope.Dispose();
					throw new Exception("Update Company-profile fail....", ex);
				}
			}

		} // end UpdateCurrentCompanyProfile


		#region UNUSED
		//private void UpdateSysConfigValues()
		//{
		//	// Get Current System ConnectionString from App.Config
		//	string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OLDMOONEF"].ConnectionString;

		//	Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

		//	// Get Entities ConnectionString
		//	EntityConnectionStringBuilder _efb = new EntityConnectionStringBuilder(_connectionString);

		//	// Get classic SQL Connection String
		//	SqlConnectionStringBuilder _sqb = new SqlConnectionStringBuilder(_efb.ProviderConnectionString);

		//	// set new value to App.Config
		//	_sqb.DataSource = this.txtSysServer.Text;
		//	_sqb.InitialCatalog = this.txtSysDatabase.Text;
		//	_sqb.UserID = this.txtSystemAdmin.Text;
		//	_sqb.Password = this.txtSysPassword.Text;

		//	// pop back to EntitiesConnectionString
		//	_efb.ProviderConnectionString = _sqb.ConnectionString;

		//	// update EntitiesConnectionString (OLDMOONEF) in App.Config
		//	_config.ConnectionStrings.ConnectionStrings["OLDMOONEF"].ConnectionString = _efb.ConnectionString;

		//	// save and refresh
		//	_config.Save(ConfigurationSaveMode.Modified);
		//	ConfigurationManager.RefreshSection("connectionStrings");

		//	// update global parameter
		//	omglobal.SysServer = this.txtSysServer.Text;
		//	omglobal.SysDatabase = this.txtSysDatabase.Text;
		//	omglobal.SysAdmin = this.txtSystemAdmin.Text;
		//	omglobal.SysPassword = this.txtSysPassword.Text;

		//} // end UpdateSysConfigValues


		//private void UpdateERPConfigValues()
		//{
		//	// Get Current System ConnectionString from App.Config
		//	string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ERPEF"].ConnectionString;

		//	Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

		//	// Get Entities ConnectionString
		//	EntityConnectionStringBuilder _efb = new EntityConnectionStringBuilder(_connectionString);

		//	// Get SQL Connection String
		//	SqlConnectionStringBuilder _sqb = new SqlConnectionStringBuilder(_efb.ProviderConnectionString);

		//	// set new value to App.Config
		//	_sqb.DataSource = this.txtERPServer.Text;
		//	_sqb.InitialCatalog = this.txtERPDatabase.Text;
		//	_sqb.UserID = this.txtERPUser.Text;
		//	_sqb.Password = this.txtERPPassword.Text;

		//	// pop back to EntitiesConnectionString
		//	_efb.ProviderConnectionString = _sqb.ConnectionString;

		//	// update EntitiesConnectionString (OLDMOONEF) in App.Config
		//	_config.ConnectionStrings.ConnectionStrings["ERPEF"].ConnectionString = _efb.ConnectionString;

		//	// save and refresh
		//	_config.Save(ConfigurationSaveMode.Modified);
		//	ConfigurationManager.RefreshSection("connectionStrings");

		//	// update global parameter
		//	omglobal.ERPServer = this.txtERPServer.Text;
		//	omglobal.ERPDatabase = this.txtERPDatabase.Text;
		//	omglobal.ERPAdmin = this.txtERPUser.Text;
		//	omglobal.ERPPassword = this.txtERPPassword.Text;

		//} // end UpdateERPConfigValues

		#endregion

		private void GetCurrentConfig(string Key)
		{
			if (_mode == ActionMode.Edit)
			{
				// Read Configuration from App.Config
				this.ReadAppRegistryConfig();

				// System Configuration
				this.txtSysServer.Text = omglobal.SysServer;
				this.txtSysDatabase.Text = omglobal.SysDatabase;
				this.txtSystemAdmin.Text = omglobal.SysAdmin;
				this.txtSysPassword.Text = omglobal.SysPassword;

				// ERP Configuration
				this.txtERPServer.Text = omglobal.ERPServer;
				this.txtERPDatabase.Text = omglobal.ERPDatabase;
				this.txtERPUser.Text = omglobal.ERPAdmin;
				this.txtERPPassword.Text = omglobal.ERPPassword;

				// General System Configuration
				this.txtCompanyId.Text = omglobal.COMPANY_ID;
				this.txtImgLocationPath.Text = omglobal.IMAGE_LOCATION_PATH;
				this.cbxWorkGroup.Text = omglobal.USER_WORKGROUP;
			}
			else
			{
				// System Configuration
				this.txtSysServer.Text = string.Empty;
				this.txtSysDatabase.Text = string.Empty;
				this.txtSystemAdmin.Text = string.Empty;
				this.txtSysPassword.Text = string.Empty;

				// ERP Configuration
				this.txtERPServer.Text = string.Empty;
				this.txtERPDatabase.Text = string.Empty;
				this.txtERPUser.Text = string.Empty;
				this.txtERPPassword.Text = string.Empty;

				// General System Configuration
				this.txtCompanyId.Text = string.Empty;
				this.txtImgLocationPath.Text = string.Empty;
				this.cbxWorkGroup.Text = OMShareSysConfigEnums.WorkGroups.None.ToString();
			}

		} // end GetCurrentConfig

		private string GetDatabaseServerName()
		{
			string _selectedServerName = string.Empty;
			using (ServerList _serverList = new ServerList())
			{
				_serverList.StartPosition = FormStartPosition.CenterScreen;
				if (_serverList.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					_selectedServerName = _serverList.ServerName;
				}
			}

			return _selectedServerName;
		
		} // end GetDatabaseServerName

		private void GetWorkGroupList()
		{
			this.cbxWorkGroup.DataSource = OMControls.EnumWithName<OMShareSysConfigEnums.WorkGroups>.ParseEnum();
			this.cbxWorkGroup.DisplayMember = "Name";
			this.cbxWorkGroup.ValueMember = "Value";

		} // end GetWorkGroupList

		#endregion


		public ConfigManager(string RegistrySubKey)
		{
			InitializeComponent();
			_registrySubKey = RegistrySubKey;
		}

		private void ConfigManage_Load(object sender, EventArgs e)
		{
			// UPDATE TITLE 
			this.lbTitle.Text = string.Format("{0} ({1})", _title, _mode.ToString());

			// initial class AppConfigure
			_appConfig = new AppConfigure(_registrySubKey);

			// read configuration
			this.GetWorkGroupList();
			this.GetCurrentConfig(_registrySubKey);

			// update UI
			this.UpdateUI();
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void btnUpdateConfig_Click(object sender, EventArgs e)
		{
			// update registry configuration
			_appConfig.CreateRegistry(_registrySubKey, 
										this.txtCompanyId.Text, 
										_workGroup,
										this.txtSysServer.Text, 
										this.txtSysDatabase.Text, 
										this.txtSystemAdmin.Text, 
										this.txtSysPassword.Text, 
										this.txtERPServer.Text, 
										this.txtERPDatabase.Text, 
										this.txtERPUser.Text, 
										this.txtERPPassword.Text,
										this.txtImgLocationPath.Text);

			// read configuration
			omglobal.ReadAppConfig(_registrySubKey);

			// update registry values
			OMControls.OMAppConfig _config = new OMControls.OMAppConfig();
			_config.UpdateConnectionString(omglobal.OM_CONNECT_NAME, omglobal.SysServer, omglobal.SysDatabase, omglobal.SysAdmin, omglobal.SysPassword);
			_config.UpdateConnectionString(omglobal.SERVICE_CONNECT_NAME, omglobal.SysServer, omglobal.SysDatabase, omglobal.SysAdmin, omglobal.SysPassword);
			_config.UpdateConnectionString(omglobal.ERP_CONNECT_NAME, omglobal.ERPServer, omglobal.ERPDatabase, omglobal.ERPAdmin, omglobal.ERPPassword);
			
			// Update App.Config file
			this.UpdateAppSetting();


			// force user to re-start application
			if (omglobal.UserLogId > 0)
			{
				MessageBox.Show("Application must be close for updating configuration", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				Application.Exit();
			}
		}

		private void btnSysServer_Click(object sender, EventArgs e)
		{
			this.txtSysServer.Text = this.GetDatabaseServerName();
		}

		private void btnERPServer_Click(object sender, EventArgs e)
		{
			this.txtERPServer.Text = this.GetDatabaseServerName();
		}

		private void btnImgLocationPath_Click(object sender, EventArgs e)
		{
			this.txtImgLocationPath.Text = OMControls.OMUtils.GetFolderPath();
		}

		private void txtImgLocationPath_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void cbxWorkGroup_SelectedValueChanged(object sender, EventArgs e)
		{
			//try
			//{
			//	_workGroup = this.cbxWorkGroup.Text;
			//}
			//catch
			//{
			//	_workGroup = WorkGroups.None.ToString();
			//}
		}

		private void cbxWorkGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			_workGroup = this.cbxWorkGroup.Text;
		}

	}
}
