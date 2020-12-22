using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Security.Permissions;

namespace OMW15.Views.ToolViews
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
			this.BackColor = omglobal.FB_BLUE;
		}

		#region class helper

		private void DisplayUI()
		{
			//Assembly asm = Assembly.GetExecutingAssembly();

			//var descriptionAttribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false).OfType<AssemblyDescriptionAttribute>().FirstOrDefault().Description;

			//var _asmVersion = (AssemblyVersionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyVersionAttribute), true).Single();

			//var _buildVersion = Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();

			lbAppName.Text = $"{omglobal.AssemblyInformation} {Assembly.GetExecutingAssembly().FullName}";
			lbVersion.Text = $"{Assembly.GetExecutingAssembly().GetName().Version}";
			lbDefaultDatabase.Text = omglobal.SysDatabase;
			lbDefaultServer.Text = omglobal.SysServer;
			lbERPDatabase.Text = omglobal.ERPDatabase;
			lbERPServer.Text = omglobal.ERPServer;
			lbUsername.Text = omglobal.UserName;
			lbWorkstation.Text = omglobal.WorkStation;
			Text = omglobal.IMAGE_LOCATION_PATH;
		} // end DisplayUI

		#endregion

		private void About_Load(object sender, EventArgs e)
		{
			DisplayUI();


	

		}
	}
}