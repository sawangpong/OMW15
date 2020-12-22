using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15
{
	public partial class UpdateApp : Form
	{
		UpdateCheckInfo appInfo = null;
		Boolean doUpdate = false;
		// Constructor
		public UpdateApp(UpdateCheckInfo Info)
		{
			InitializeComponent();
			appInfo = Info;
		}

		private void UpdateApp_Load(object sender, EventArgs e)
		{
			this.startUpdateApp();
		}


		private void startUpdateApp()
		{
			doUpdate = true;
			string message = string.Empty;	

			ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
			if (!appInfo.IsUpdateRequired)
			{
				//DialogResult dr = MessageBox.Show("An update is available \n\n\n(Software new version!!! Test update  configuration). \n\n\nWould you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
				
				message = "An update is available \n\n\n(Software new version!!! Test update  configuration). \n\n\nWould you like to update the application now?";
				
				//if (!(DialogResult.OK == dr))
				//{
				//	doUpdate = false;
				//}
				txtMessage.Text = message;

			}
			else
			{
				// display the message that the application must be reboot. Display the minimum require version.
				//MessageBox.Show("This application has detected a mandatory update from your current " + "Version to version " + appInfo.MinimumRequiredVersion.ToString() + ". The application will now install the update and restart.", "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);

				message = "This application has detected a mandatory update from your current " + "Version to version " + appInfo.MinimumRequiredVersion.ToString() + ". The application will now install the update and restart.";
				txtMessage.Text = message;
			
			}

			if (doUpdate)
			{
				try
				{
					ad.Update();
					MessageBox.Show("The application has been upgraded, and will now restart.");

					message = "The application has been upgraded, and will now restart.";
					//this.GetCurrentConfig();
					txtMessage.Text = message;
					Application.Restart();
				}
				catch (DeploymentDownloadException dde)
				{
					MessageBox.Show("Cannot install the latest version of the application. \n\n\nPlease check your network connection, or try again later. Error:" + dde.Message);

					message = "Cannot install the latest version of the application. \n\n\nPlease check your network connection, or try again later. Error:" + dde.Message;
					txtMessage.Text = message;
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		} // end startUpdateApp
	}
}
