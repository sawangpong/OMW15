using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15
{
	public partial class About : Form
	{
		#region class helper

		private void DisplayUI()
		{
			this.lbAppName.Text = string.Format("{0}-{1}", Application.ProductName,Application.ProductVersion);
			this.lbDefaultDatabase.Text = omglobal.SysDatabase;
			this.lbDefaultServer.Text = omglobal.SysServer;
			this.lbERPDatabase.Text = omglobal.ERPDatabase;
			this.lbERPServer.Text = omglobal.ERPServer;
			this.lbUsername.Text = omglobal.UserName;
			this.lbWorkstation.Text = omglobal.WorkStation;

			this.Text = omglobal.IMAGE_LOCATION_PATH;

		} // end DisplayUI

		#endregion

		public About()
		{
			InitializeComponent();
		}

		private void About_Load(object sender, EventArgs e)
		{
			this.DisplayUI();
		}
	}
}
