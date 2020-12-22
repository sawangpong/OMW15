using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Shared;
using OMW15.Views.ToolViews;
using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace OMW15
{
	public static class omglobal
	{
		#region Configure Parameter

		public static string COMPANY_ID = "OLDMOON";
		public static string COMPANY_NAME = string.Empty;
		public static string COMPANY_NAME_TH = "บริษัทโอลด์มูน จำกัด";
		public static string IMAGE_LOCATION_PATH = string.Empty;
		public static string IMAGE_EXTENSION = ".jpg";
		public static int DEFAULT_IMAGE_WIDTH = 150;
		public static int DEFAULT_IMAGE_HEIGHT = 180;
		public static int DEFAULT_IMAGE_QUALITY = 80; // setting @80%

		public static decimal WEIGHT_FACTOR = DEFAULT_MATERIAL_CONVERT_FACTOR;
		public static decimal SILVER_MARKUP_FACTOR = DEFAULT_SILVER_MARKUP_FACTOR;
		public static decimal GOLD_MARKUP_FACTOR = DEFAULT_GOLD_MARKUP_FACTOR;

		public static string DEFAULT_SYSTEM_NON_VAT = "0%";
		public static string DEFAULT_SYSTEM_VAT = "7%";
		public static string HOME_CURRENCY = "THB";
		public static string SOURCE_CURRENCY = "";
		public static decimal DEFAULT_SYSTEM_NON_VAT_FACTOR = 0.00m; // update by company profile when application loading
		public static decimal DEFAULT_SYSTEM_VAT_FACTOR = 0.07m; // update by company profile when application loading
		public static decimal HOME_CURRENCY_FACTOR = 1.00m;
		public static decimal SOURCE_CURRENCY_VALUE = 0.00m;

		public static string APP_NAME = Application.ProductName;
		public static string APP_VERSION = Application.ProductVersion;

		public static string SysServer = string.Empty;
		public static string SysDatabase = string.Empty;
		public static string SysAdmin = string.Empty;
		public static string SysPassword = string.Empty;
		public static string SysConnectionString = string.Empty;

		public static string ERPServer = string.Empty;
		public static string ERPDatabase = string.Empty;
		public static string ERPAdmin = string.Empty;
		public static string ERPPassword = string.Empty;
		public static string ERPConnectionString = string.Empty;

		public static string USER_WORKGROUP = OMShareSysConfigEnums.WorkGroups.None.ToString();

		public const string ERP_CONNECT_NAME = "ERP";
		public const string OM_CONNECT_NAME = "OLDMOONEF1";
		//public const string SERVICE_CONNECT_NAME = "SERVICEEF";
		//public const string PRODUCTION_CONNECT_NAME = "PDEF";
		//public const string LOGIN_CONNECT_NAME = "LOGINEF";

		public const string AUTO_SI_NUMBER = "***AUTO***";

		public const string APP_REGISTRY_SUBKEY = "OW15";
		public const string DEFAULT_NEW_ORDER = "**NEW**";
		public const string SELECT_SIGN_LEFT = "»»";
		public const string SELECT_SIGN_RIGHT = "««";
		public const decimal DEFAULT_SILVER_MARKUP_FACTOR = 1.10m; //1.045m;
		public const decimal DEFAULT_GOLD_MARKUP_FACTOR = 1.045m;
		public const decimal DEFAULT_MATERIAL_CONVERT_FACTOR = 31.104m;
		public const decimal DEFAULT_AVG_MAT_LOSS = 0.005m; // 0.5%

		// CASTING JOB DURATION
		public const int CASTING_DURATION_DAYS = 3;

		// SYSTEM COLOR
		public static Color FB_BLUE = Color.FromArgb(59, 89, 152);
		public static Color OM_GREEN_COLOR = Color.FromArgb(4, 116, 76);
		public static Color OM_BLUE_COLOR = Color.FromArgb(3, 4, 97);
		public static Color OM_RED_COLOR = Color.FromArgb(204, 24, 30);
		public static Color OM_ORANGE_COLOR = Color.FromArgb(240, 56, 10);
		public static Color OM_LIGHT_BLUE_COLOR = Color.FromArgb(64, 128, 255);
		public static Color OM_LIGHT_GREEN_COLOR = Color.FromArgb(1, 144, 138);
		public static Color OM_LOGIN_PAGE_COLOR = Color.FromArgb(220, 10, 10);

		// PRODUCTION HOUR RATE
		public static decimal PRODUCTION_HOUR_RATE = 0.00m;
		public static decimal NORMAL_OT_FACTOR = 1.50m;
		public static decimal HOLIDAY_OT_FACTOR = 2.00m;
		public static decimal HOLIDAY_WORK_FACTOR = 2.00m;
		public static decimal WORK_HOUR_DAY = 8.0m;
		public static decimal TOTAL_MONTH_HOURS = 240.0m;			// 30d * 8h/d = 240 h/m
		public static decimal TOTAL_ACTUAL_MONTH_HOURS = 208.0m; // 26d * 8h/d = 208 h/m

		public static string[] WH_SUB_ITEM = { "RU", "RM", "DT", "DR" };
		public static string[] SeriveIssueCode = { "DRCT", "DRMK", "DRPI", "DRSV" };
		public static string[] FOCOrderCode = { "AS", "SF", "SW" };

		public static bool NONVAT_DISPLAY = false;

		public static log4net.ILog log; // = log4net.LogManager.GetLogger(typeof(Program));

		public const decimal _classA = 10000.00m;
		public const decimal _classB = 5000.00m;
		public const decimal _classC = 1000.00m;
		public const decimal _classD = 0.00m;

		public static int[] DepartmentList = { 104, 111, 112 };
		public static int[] EmployeeActiveStatus = { 1, 6, 7, 8 };
		public static int[] EmployeeDeactiveStatus = { 2, 3, 4 };


		#endregion

		#region Assembly Information
		public static string AssemblyInformation = $"{Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false).OfType<AssemblyDescriptionAttribute>().FirstOrDefault().Description} ({Application.ProductName})";
		#endregion

		#region User Login
		public static int UserLogId = 0;
		public static int WorkGroupId = 0;
		public static int PermisionId = (int)OMShareSysConfigEnums.UserPermission.None;
		public static string UserName = string.Empty;
		public static string PassWord = string.Empty;
		public static string PermissionClass = string.Empty;
		public static string WorkStation = Environment.MachineName;
		public static string UserInfo = WorkStation + "::" + UserName;

		// LOG INFO
		public static StringBuilder _log = new StringBuilder();
		public static int logLine = 0;

		#endregion

		#region class methods
		public static void GetCurrentConfig()
		{
			AppConfigure _appConfigure;
			_appConfigure = new AppConfigure(APP_REGISTRY_SUBKEY);
			if (_appConfigure.IsFoundRegistryKey == false)
				using (var _mgr = new ConfigManager(APP_REGISTRY_SUBKEY))
				{
					_mgr.Mode = ActionMode.Add;
					_mgr.StartPosition = FormStartPosition.CenterScreen;

					if (_mgr.ShowDialog() == DialogResult.Cancel)
						Application.Exit();
				}
			else // found RegistryKey the read data from Registry
			{
				AppConfigure.ReadAppRegistryConfiguration(APP_REGISTRY_SUBKEY);
			}

			// create object for updating connectionstring as giving connection name
			var _config = new OMAppConfig();

			// Update System ConnectionString for SysServer
			_config.UpdateConnectionString(OM_CONNECT_NAME, SysServer, SysDatabase, SysAdmin, SysPassword);

			// Update ERP ConnectionString for ERP
			_config.UpdateConnectionString(ERP_CONNECT_NAME, ERPServer, ERPDatabase, ERPAdmin, ERPPassword);

			// get Current connection string
			_config.GetCurrentConnectionString(OM_CONNECT_NAME, ref SysConnectionString);
			_config.GetCurrentConnectionString(ERP_CONNECT_NAME, ref ERPConnectionString);

		} // end GetCurrentConfig
		#endregion

	} // end class omglobal
} // end namespace OMWorks