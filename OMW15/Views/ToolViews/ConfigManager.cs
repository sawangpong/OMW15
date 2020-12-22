using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Shared;
using System.Data.Entity.Core;

namespace OMW15.Views.ToolViews
{
	public partial class ConfigManager : Form
	{
		public ConfigManager(string RegistrySubKey)
		{
			InitializeComponent();
			_registrySubKey = RegistrySubKey;
		}

		private void ConfigManage_Load(object sender, EventArgs e)
		{
			CenterToParent();
			// log
			omglobal._log.AppendFormat("{0,-10} ----------------------------------------", ++omglobal.logLine);
			omglobal._log.AppendLine();
			omglobal._log.AppendFormat("{0,-10} Start Config Manager", ++omglobal.logLine);
			omglobal._log.AppendLine();
			omglobal._log.AppendFormat("{0,-10} -----------------------------------------", ++omglobal.logLine);
			omglobal._log.AppendLine();

			// UPDATE TITLE 
			lbTitle.Text = string.Format("{0} ({1})", _title, _mode);


			// log
			omglobal._log.AppendFormat("{0,-10} Get App Config", ++omglobal.logLine);
			omglobal._log.AppendLine();

			// initial class AppConfigure
			_appConfig = new AppConfigure(_registrySubKey);


			// log
			omglobal._log.AppendFormat("{0,-10} Get Flag Found Registry = {1}", ++omglobal.logLine, _appConfig.IsFoundRegistryKey);
			omglobal._log.AppendLine();

			// read configuration
			omglobal._log.AppendFormat("{0,-10} Get Workgroup List Registry ", ++omglobal.logLine);
			omglobal._log.AppendLine();
			//GetWorkGroupList();

			omglobal._log.AppendFormat("{0,-10} Read Current Configuration from Registry ", ++omglobal.logLine);
			omglobal._log.AppendLine();

			GetCurrentConfig(_registrySubKey);

			// update UI
			UpdateUI();
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnUpdateConfig_Click(object sender, EventArgs e)
		{
			// log
			//omglobal._log.AppendFormat("{0,-10} Start Update Configuration ", ++omglobal.logLine);
			//omglobal._log.AppendLine();

			// update registry configuration
			_appConfig.CreateRegistry(_registrySubKey,
				txtCompanyId.Text,
				/*_workGroup, */
				txtSysServer.Text,
				txtSysDatabase.Text,
				txtSystemAdmin.Text,
				txtSysPassword.Text,
				txtERPServer.Text,
				txtERPDatabase.Text,
				txtERPUser.Text,
				txtERPPassword.Text,
				""
				/*this.txtImgLocationPath.Text*/);

			// log
			//omglobal._log.AppendFormat("{0,-10} Read new Configuration from registry", ++omglobal.logLine);
			//omglobal._log.AppendLine();

			// read configuration
			var _appConfigure = new AppConfigure(omglobal.APP_REGISTRY_SUBKEY);

			// log
			//omglobal._log.AppendFormat("{0,-10} Update String Connection", ++omglobal.logLine);
			//omglobal._log.AppendLine();

			// update String Connection

			// Main
			var _config = new OMAppConfig();
			_config.UpdateConnectionString(omglobal.OM_CONNECT_NAME, omglobal.SysServer, omglobal.SysDatabase, omglobal.SysAdmin,
				omglobal.SysPassword);

			// Service
			//_config.UpdateConnectionString(omglobal.SERVICE_CONNECT_NAME, omglobal.SysServer, omglobal.SysDatabase,
			//	omglobal.SysAdmin, omglobal.SysPassword);

			// login
			//_config.UpdateConnectionString(omglobal.LOGIN_CONNECT_NAME, omglobal.SysServer, omglobal.SysDatabase,
			//	omglobal.SysAdmin, omglobal.SysPassword);

			// production
			//_config.UpdateConnectionString(omglobal.PRODUCTION_CONNECT_NAME, omglobal.SysServer, omglobal.SysDatabase,
			//	omglobal.SysAdmin, omglobal.SysPassword);

			// ERP
			_config.UpdateConnectionString(omglobal.ERP_CONNECT_NAME, omglobal.ERPServer, omglobal.ERPDatabase, omglobal.ERPAdmin,
				omglobal.ERPPassword);

			// log
			omglobal._log.AppendFormat("{0,-10} Get Current Connection String After re-config by Config Manager",
				++omglobal.logLine);
			omglobal._log.AppendLine();

			// get Current connection string
			_config.GetCurrentConnectionString(omglobal.OM_CONNECT_NAME, ref omglobal.SysConnectionString);
			_config.GetCurrentConnectionString(omglobal.ERP_CONNECT_NAME, ref omglobal.ERPConnectionString);


			// log
			omglobal._log.AppendFormat("{0,-10} Main ConnectionString : {1} ", ++omglobal.logLine, omglobal.SysConnectionString);
			omglobal._log.AppendLine();

			omglobal._log.AppendFormat("{0,-10} ERP ConnectionString : {1} ", ++omglobal.logLine, omglobal.ERPConnectionString);
			omglobal._log.AppendLine();

			// log
			omglobal._log.AppendFormat("{0,-10} Update App Configuration", ++omglobal.logLine);
			omglobal._log.AppendLine();

			// Update App.Config file
			UpdateAppSetting();

			// log
			omglobal._log.AppendFormat("{0,-10} -------- END CONFIGURATION MANAGER ---------------", ++omglobal.logLine);
			omglobal._log.AppendLine();

			// restart application with any case
			MessageBox.Show("Application will automatic restart after updated configuration....", "Message", MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);
			Application.Restart();
		}

		private void btnSysServer_Click(object sender, EventArgs e)
		{
			txtSysServer.Text = GetDatabaseServerName();
		}

		private void btnERPServer_Click(object sender, EventArgs e)
		{
			txtERPServer.Text = GetDatabaseServerName();
		}

		private void btnImgLocationPath_Click(object sender, EventArgs e)
		{
			txtImgLocationPath.Text = OMUtils.GetFolderPath();
		}

		private void txtImgLocationPath_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		//private void cbxWorkGroup_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//	_workGroup = cbxWorkGroup.Text;
		//}

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
			set { _mode = value; }
		}

		public string RegistrySubKey
		{
			set { _registrySubKey = value; }
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnUpdateConfig.Enabled = !string.IsNullOrEmpty(txtCompanyId.Text)
			                          && !string.IsNullOrEmpty(txtERPServer.Text)
			                          && !string.IsNullOrEmpty(txtERPDatabase.Text)
			                          && !string.IsNullOrEmpty(txtERPUser.Text)
			                          && !string.IsNullOrEmpty(txtSysServer.Text)
			                          && !string.IsNullOrEmpty(txtSysDatabase.Text)
			                          && !string.IsNullOrEmpty(txtSystemAdmin.Text);
		} // end UpdateUI

		private void ReadAppRegistryConfig()
		{
			if (_appConfig.IsFoundRegistryKey) ReadAppConfig();
		} // end ReadAppRegistryConfig

		private void ReadAppConfig()
		{
			var _config = new OMAppConfig();
			_config.GetCurrentConnectionString(omglobal.OM_CONNECT_NAME, ref omglobal.SysConnectionString);
			_config.GetCurrentConnectionString(omglobal.ERP_CONNECT_NAME, ref omglobal.ERPConnectionString);

		} // end ReadConfig

		private void UpdateAppSetting()
		{
			// log
			omglobal._log.AppendFormat("{0,-10} Update Company ID in AppConfig", ++omglobal.logLine);
			omglobal._log.AppendLine();

			var _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			_config.AppSettings.Settings["CompanyId"].Value = txtCompanyId.Text;

			// save and refresh
			_config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("configuration");

			// log
			omglobal._log.AppendFormat("{0,-10} Update Global Variable (Company ID) in omglobal Module", ++omglobal.logLine);
			omglobal._log.AppendLine();

			// Update global value
			omglobal.COMPANY_ID = txtCompanyId.Text;

			// log
			omglobal._log.AppendFormat("{0,-10} Update Company Profile", ++omglobal.logLine);
			omglobal._log.AppendLine();
		} // end UpdateAppSetting

		private void UpdateCompanyProfile(string CompanyId)
		{
			using (var _scope = new TransactionScope())
			{
				var _log = new OLDMOONEF1();
				var _cprofile = (from c in _log.COMPANY_PROFILES
					where c.COMPANYID == CompanyId
					select c).Single();
				try
				{
					_cprofile.IMAGE_LOCATION = txtImgLocationPath.Text;
					_log.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					//_scope.Dispose();
					throw new Exception("Update Company-profile fail....", ex);
				}
			}
		} // end UpdateCurrentCompanyProfile

		private void GetCurrentConfig(string Key)
		{
			if (_mode == ActionMode.Edit)
			{
				// Read Configuration from App.Config
				ReadAppRegistryConfig();

				// System Configuration
				txtSysServer.Text = omglobal.SysServer;
				txtSysDatabase.Text = omglobal.SysDatabase;
				txtSystemAdmin.Text = omglobal.SysAdmin;
				txtSysPassword.Text = omglobal.SysPassword;

				// ERP Configuration
				txtERPServer.Text = omglobal.ERPServer;
				txtERPDatabase.Text = omglobal.ERPDatabase;
				txtERPUser.Text = omglobal.ERPAdmin;
				txtERPPassword.Text = omglobal.ERPPassword;

				// General System Configuration
				txtCompanyId.Text = omglobal.COMPANY_ID;
				//cbxWorkGroup.Text = omglobal.USER_WORKGROUP;
			}
			else
			{
				// System Configuration
				txtSysServer.Text = string.Empty;
				txtSysDatabase.Text = string.Empty;
				txtSystemAdmin.Text = string.Empty;
				txtSysPassword.Text = string.Empty;

				// ERP Configuration
				txtERPServer.Text = string.Empty;
				txtERPDatabase.Text = string.Empty;
				txtERPUser.Text = string.Empty;
				txtERPPassword.Text = string.Empty;

				// General System Configuration
				txtCompanyId.Text = string.Empty;
				//cbxWorkGroup.Text = OMShareSysConfigEnums.WorkGroups.None.ToString();
			}
		} // end GetCurrentConfig

		private string GetDatabaseServerName()
		{
			var _selectedServerName = string.Empty;
			using (var _serverList = new ServerList())
			{
				_serverList.StartPosition = FormStartPosition.CenterScreen;
				if (_serverList.ShowDialog() == DialogResult.OK) _selectedServerName = _serverList.ServerName;
			}

			return _selectedServerName;

		} // end GetDatabaseServerName

		#endregion
	}
}