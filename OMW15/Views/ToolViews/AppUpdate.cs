using System;
using System.ComponentModel;
using System.Deployment.Application;
using System.Windows.Forms;

namespace OMW15.Views.ToolViews
{
	public partial class AppUpdate : Form
	{
		private long sizeOfUpdate;


		public AppUpdate()
		{
			InitializeComponent();
		}

		private void UpdateApplication()
		{
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				var ad = ApplicationDeployment.CurrentDeployment;
				ad.CheckForUpdateCompleted += ad_CheckForUpdateCompleted;
				ad.CheckForUpdateProgressChanged += ad_UpdateProgressChanged;
				ad.CheckForUpdateAsync();
			}
		}

		private void ad_CheckForUpdateProgressChenaged(object sender, DeploymentProgressChangedEventArgs e)
		{
			lbDownloadStatus.Text = string.Format("Downloading: {0}. {1:D}K of {2:D}K downloaded.", GetProgressString(e.State),
				e.BytesCompleted / 1024, e.BytesTotal / 1024);

			// update progress
			downloadProgress.Value = Convert.ToInt32(e.BytesCompleted / 1024 / 100);
		}

		private string GetProgressString(DeploymentProgressState state)
		{
			if (state == DeploymentProgressState.DownloadingApplicationFiles) return "application manifest";
			return "deployment manifest";
		}

		private void ad_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show("ERROR: Could not retrieve new version of the application. Reason: \n" + e.Error.Message +
				                "\nPlease report this error to the system administrator.");
				return;
			}
			if (e.Cancelled) MessageBox.Show("The update was cancelled....");

			// ask the user if they would like to update the application now.
			if (e.UpdateAvailable)
			{
				sizeOfUpdate = e.UpdateSizeBytes;
				if (!e.IsUpdateRequired)
				{
					var dr =
						MessageBox.Show(
							"An update is available. Would you like to update the application now?\n\nEstimated Download Time: ",
							"Update Available", MessageBoxButtons.OKCancel);
					if (DialogResult.OK == dr) BeginUpdate();
				}
				else
				{
					MessageBox.Show(
						"A mandatory update is available for your application. We will install the update now, after which we will save all of your in-progress data and restart you application.");
					BeginUpdate();
				}
			}
		}

		private void BeginUpdate()
		{
			//throw new NotImplementedException();
			var ad = ApplicationDeployment.CurrentDeployment;
			ad.UpdateCompleted += ad_UpdateCompleted;

			// Indicate progress in the application's status bar.
			ad.UpdateProgressChanged += ad_UpdateProgressChanged;
			ad.UpdateAsync();
		}

		private void ad_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
		{
			var progressText = string.Format("{0:D}K out of {1:D}K downloaded - {2:D}% complete", e.BytesCompleted / 1024,
				e.BytesTotal / 1024, e.ProgressPercentage);
			lbDownloadStatus.Text = progressText;
		}

		private void ad_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				MessageBox.Show("The update of the application's latest version was cancelled..");
				return;
			}
			if (e.Error != null)
			{
				MessageBox.Show("ERRPR: Could not install the latest version of the application. Reason: \n" + e.Error.Message +
				                "\nPlease report this error to the system administrator");
				return;
			}

			if (
				MessageBox.Show(
					"The application has been updated. Restart? (If you do not restart now, the new version will not take effect until after your quit an launch the application again.",
					"Restart Application", MessageBoxButtons.OKCancel) == DialogResult.OK) Application.Restart();
		}

		private void AppUpdate_Load(object sender, EventArgs e)
		{
			lbAppName.Text = Application.ProductName + " version : " + Application.ProductVersion;
			UpdateApplication();
		}
	}
}