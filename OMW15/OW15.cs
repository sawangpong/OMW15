using OMW15.Controllers.ToolController;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using OMW15.Views.BankView;
using OMW15.Views.CastingView;
using OMW15.Views.CustomerView;
using OMW15.Views.EmployeeView;
using OMW15.Views.Productions;
using OMW15.Views.Sales;
using OMW15.Views.ServiceView;
using OMW15.Views.ToolViews;
using OMW15.Views.WarehouseView;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OMW15
{
	public partial class OW15 : Form
	{
		// CONSTRUCTOR
		public OW15()
		{
			// system-initialize components
			InitializeComponent();

			// setting style
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);


			Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(57, 86, 151);

			// setting from Title
			this.Text = $"{omglobal.AssemblyInformation}";

			//this.GetCurrentConfig();
			omglobal.log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
			//omglobal.log.Info("Start program");

			UpdateUI();
		}

		private void OW15_Load(object sender, EventArgs e)
		{
			if (omglobal.UserLogId > 0)
			{
				//omglobal.log.Info($"Create user id [{omglobal.UserLogId}] [{omglobal.UserName}] success");

				// update userInfo
				UpdateUserInfoUI();
				//UpdateMenus();

				UpdateUI();
			}
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void mnuConfig_Click(object sender, EventArgs e)
		{
			using (var _configMgr = new ConfigManager(omglobal.APP_REGISTRY_SUBKEY))
			{
				_configMgr.Mode = ActionMode.Edit;
				_configMgr.StartPosition = FormStartPosition.CenterScreen;
				_configMgr.ShowDialog(this);
			}
		}

		private void mnuShowToolBar_Click(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void OW15_FormClosing(object sender, FormClosingEventArgs e)
		{
			// update user-log record for logout time in case of user_id > 0
			if (omglobal.UserLogId > 0)
			{
				if (!new Logout().UpdateUserLogoutTime(omglobal.UserLogId, DateTime.Now))
				{
					MessageBox.Show("Update user record error during logout ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void mnuChangeUserPassword_Click(object sender, EventArgs e)
		{
			using (var _changePassword = new UserChangePassword())
			{
				_changePassword.StartPosition = FormStartPosition.CenterScreen;
				_changePassword.UserName = omglobal.UserName;
				_changePassword.OldPassword = omglobal.PassWord;
				_changePassword.ShowDialog(this);
			}
		}

		private void mnuMembers_Click(object sender, EventArgs e)
		{
			using (var _uMgr = new UserPermissionManager())
			{
				_uMgr.StartPosition = FormStartPosition.CenterScreen;
				_uMgr.ShowDialog(this);
			}
		}

		private void mnuWindowCascade_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void mnuWindowVertical_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void mnuWindowHorizontal_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void mnuMasterCustomers_Click(object sender, EventArgs e)
		{
			var _masterCustomers = MasterCustomers.GetInstance;
			_masterCustomers.StartPosition = FormStartPosition.CenterScreen;
			_masterCustomers.Action = OMShareCustomerEnums.MasterCustomerAction.None;
			_masterCustomers.MdiParent = this;
			_masterCustomers.Show();
		}

		private void tsbtnMasterCustomers_Click(object sender, EventArgs e)
		{
			mnuMasterCustomers.PerformClick();
		}

		private void testInputToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var t = new TestInput();
			t.ShowDialog();
		}

		private void mnuCompanyProfile_Click(object sender, EventArgs e)
		{
			var _cprofile = new CompanyProfile();
			_cprofile.CompanyId = omglobal.COMPANY_ID;
			_cprofile.Mode = ActionMode.Edit;
			_cprofile.StartPosition = FormStartPosition.CenterScreen;
			_cprofile.ShowDialog(this);

			var _profile = new CompanyProfileModel();
			_profile.ReadCurrentCompanyProfile(omglobal.COMPANY_ID);

			// updating UI - display parameters
			UpdateUserInfoUI();
		}

		private void mnuAbout_Click(object sender, EventArgs e)
		{
			var _about = new About();
			_about.StartPosition = FormStartPosition.CenterScreen;
			_about.ShowDialog(this);
		}

		private void mnuExchangeRate_Click(object sender, EventArgs e)
		{
			var _exchange = ExchangeRateList.GetInstance;
			_exchange.StartPosition = FormStartPosition.CenterScreen;
			_exchange.MdiParent = this;
			_exchange.Show();
		}

		private void mnuEmployee_Click(object sender, EventArgs e)
		{
			var memp = MasterEmployee.GetInstance;
			memp.MdiParent = this;
			memp.StartPosition = FormStartPosition.CenterScreen;
			memp.Show();
		}

		private void tsbtnEmployee_Click(object sender, EventArgs e)
		{
			mnuEmployee.PerformClick();
		}

		private void tsbtnServices_Click(object sender, EventArgs e)
		{
			mnuServices.PerformClick();
		}

		private void mnuBankList_Click(object sender, EventArgs e)
		{
			var _bl = BankList.GetInstance;
			_bl.MdiParent = this;
			_bl.StartPosition = FormStartPosition.CenterScreen;
			_bl.Show();
		}

		private void mnuCasting_Click(object sender, EventArgs e)
		{
			//omglobal.log.Info($"loading Casting Section.");

			var _casting = CastingHouse.GetInstance;
			_casting.WindowState = FormWindowState.Maximized;
			_casting.Show();
		}

		private void tsbtnCasting_Click(object sender, EventArgs e)
		{
			mnuCasting.PerformClick();
		}

		private void mnuProduction_Click(object sender, EventArgs e)
		{
			var _prd = Production.GetInstance;
			_prd.WindowState = FormWindowState.Maximized;
			_prd.Show(this);
		}

		private void tsbtnProductionWorks_Click(object sender, EventArgs e)
		{
			mnuProduction.PerformClick();
		}

		private void mnuServices_Click(object sender, EventArgs e)
		{
			var _serviceWorks = ServiceWorks.GetInstance;
			_serviceWorks.WindowState = FormWindowState.Maximized;
			_serviceWorks.Show(this);
		}

		private void mnuSM_Click(object sender, EventArgs e)
		{
			var _saleWorks = SaleWorks.GetInstance;
			_saleWorks.WindowState = FormWindowState.Maximized;
			_saleWorks.Show(this);
		}

		private void mnuShowLog_Click(object sender, EventArgs e)
		{
			Alert.DisplayAlert("Display Log", omglobal._log.ToString());
		}

		private void mnuWH_Click(object sender, EventArgs e)
		{
			var _wh = Warehouse.GetInstance;
			_wh.WindowState = FormWindowState.Maximized;
			_wh.Show();
		}

		private void tsbtnSales_Click(object sender, EventArgs e)
		{
			mnuSM.PerformClick();
		}

		private void tsbtnWarehouse_Click(object sender, EventArgs e)
		{
			mnuWH.PerformClick();
		}

		#region class helper





		private void UpdateUI()
		{
			mnuShowToolBar.Checked = !mnuShowToolBar.Checked;
			ts.Visible = mnuShowToolBar.Checked;

			//UpdateMenus();

		} // end UpdateUI

		private void UpdateMenus()
		{
			// menu tools
			mnuConfig.Enabled = omglobal.PermisionId >= (int)OMShareSysConfigEnums.UserPermission.Admin;
			mnuCompanyProfile.Enabled = mnuConfig.Enabled;
			mnuMembers.Enabled = mnuConfig.Enabled;
			mnuBankList.Enabled = mnuConfig.Enabled;
			mnuMasterCompany.Enabled = mnuConfig.Enabled;
			tsbtnEmployee.Visible = mnuConfig.Enabled;
			tsSepEmployee.Visible = mnuConfig.Enabled;
			mnuEmpData.Visible = omglobal.PermisionId >= (int)OMShareSysConfigEnums.UserPermission.AccountManager;

		} // end UpdateMenu


		private void UpdateUserInfoUI()
		{
			// update the menus

			mnuWH.Visible = (omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.Warehouse
							|| omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.SystemAdmin
							|| omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.Management);

			mnuCasting.Visible = (omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.Casting
								 || omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.SystemAdmin
								 || omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.Management);

			mnuProduction.Visible = (omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.Production
									|| omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.SystemAdmin
									|| omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.Management);

			mnuServices.Visible = (omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.Services
								  || omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.SystemAdmin
								  || omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.Management);

			mnuSM.Visible = (omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.Sales
							|| omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.SystemAdmin
							|| omglobal.WorkGroupId == (int)OMShareSysConfigEnums.WorkGroups.Management);


			// setting Tool buttons
			ts.SuspendLayout();
			// tool bar
			tslbAuditClass.Text = omglobal.PermissionClass;

			omglobal.USER_WORKGROUP = Enum.GetName(typeof(Shared.OMShareSysConfigEnums.WorkGroups), omglobal.WorkGroupId);
			tslbUserGroup.Text = omglobal.USER_WORKGROUP;
			tsbtnCasting.Visible = mnuCasting.Visible;
			tsSepCasting.Visible = mnuCasting.Visible;

			tsbtnProductionWorks.Visible = mnuProduction.Visible;
			tsSepProduction.Visible = mnuProduction.Visible;

			tsbtnSales.Visible = mnuSM.Visible;
			tsSepSales.Visible = mnuSM.Visible;

			tsbtnWarehouse.Visible = mnuWH.Visible;
			tsSepWH.Visible = mnuWH.Visible;

			tsbtnServices.Visible = mnuServices.Visible;
			tsSepServiceJob.Visible = mnuServices.Visible;

			ts.ResumeLayout();

			ts.Refresh();

			// status bar
			tsslbCompanyName.Text = omglobal.COMPANY_NAME;
			tsslbUserId.Text = $"User Id : {omglobal.UserLogId}";
			tsslbUserName.Text = omglobal.UserName;
			tsslbSysServer.Text = $"{ omglobal.SysServer}...[{omglobal.SysDatabase}]";
			tsslbERPServer.Text = $"{omglobal.ERPServer}...[{omglobal.ERPDatabase}]";
			tsslbMachineName.Text = $"Workstation [{omglobal.WorkStation}]";
			tsslbNONVAT.Text = $"non-VAT {omglobal.DEFAULT_SYSTEM_NON_VAT}% ({omglobal.DEFAULT_SYSTEM_NON_VAT_FACTOR:N2})";
			tsslbVAT.Text = $"VAT {omglobal.DEFAULT_SYSTEM_VAT}% ({omglobal.DEFAULT_SYSTEM_VAT_FACTOR:N2})";

		} // end UpdateUserInfoUI

		//private void getForms()
		//{
		//	Assembly p = Assembly.GetExecutingAssembly();
		//	System.Text.StringBuilder s = new System.Text.StringBuilder();
		//	int row = 0;
		//	foreach (Type t in p.GetTypes())
		//	{
		//		if (t.BaseType == typeof(Form))
		//		{
		//			s.AppendFormat("{0,-10} {1,-80}", ++row, t.Name);
		//			s.AppendLine();
		//		}
		//	}

		//	Controllers.ToolController.Alert.DisplayAlert("Get All form", s.ToString());
		//}


		#endregion

		private void mnuLoadExcel_Click(object sender, EventArgs e)
		{
			//Views.ToolViews.TestLoadExcel excl = new TestLoadExcel();
			//excl.StartPosition = FormStartPosition.CenterParent;
			//excl.MdiParent = this;
			//excl.Show();
		}

		private void mnuEmpData_Click(object sender, EventArgs e)
		{
			using (var empSal = new EmpSala())
			{
				empSal.StartPosition = FormStartPosition.CenterScreen;
				empSal.ShowDialog(this);
			}
		}

		private void mnuCheckWorkTime_Click(object sender, EventArgs e)
		{
			var _worktime = WorktimeManager.GetInstance;
			_worktime.WindowState = FormWindowState.Normal;
			_worktime.MdiParent = this;
			_worktime.Show();

		}

		private void mnuLogin_Click(object sender, EventArgs e)
		{

		}

		private void mnuDataDic_Click(object sender, EventArgs e)
		{
			var datadic = Datadic.GetInstance;
			datadic.StartPosition = FormStartPosition.CenterParent;
			datadic.Show();
		}
	}
}