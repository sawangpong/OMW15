using OMW15.Shared;
using OMW15.Views.CustomerView;
using System;
using System.Windows.Forms;

namespace OMW15.Views.ServiceView
{
	public partial class ServiceWorks : Form
	{
		#region Singleton
		public static ServiceWorks _instance;
		public static ServiceWorks GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new ServiceWorks();
				}
				return _instance;
			}
		}

		#endregion

		public ServiceWorks()
		{
			InitializeComponent();
		}

		#region class helper methods

		private void UpdateUI()
		{
		} // end UpdateUI

		private void UpdateMenuPermission()
		{
			this.mnuServiceStat.Enabled = (omglobal.PermisionId >= (int)Shared.OMShareSysConfigEnums.UserPermission.Admin);
		}

		#endregion

		private void mnuClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void mnuCascadeWindows_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void virticalWindowsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void horizontalWindowsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void mnuServiceOrder_Click(object sender, EventArgs e)
		{
			var _svj = new ServiceJobs();
			_svj.WindowState = FormWindowState.Maximized;
			_svj.MdiParent = this;
			_svj.Show();
		}

		private void mnuCustomer_Click(object sender, EventArgs e)
		{
			var _masterCustomers = new MasterCustomers();
			_masterCustomers.StartPosition = FormStartPosition.CenterParent;
			_masterCustomers.Action = OMShareCustomerEnums.MasterCustomerAction.None;
			_masterCustomers.MdiParent = this;
			_masterCustomers.Show();
		}

		private void tsbtnCustomer_Click(object sender, EventArgs e)
		{
			mnuCustomer.PerformClick();
		}

		private void tsbtnServiceOrders_Click(object sender, EventArgs e)
		{
			mnuServiceOrder.PerformClick();
		}

		private void mnuServiceEngineers_Click(object sender, EventArgs e)
		{
			var _engs = new ServiceEngineers(OMShareServiceEnums.EngineerViewState.Normal);
			_engs.StartPosition = FormStartPosition.CenterScreen;
			_engs.MdiParent = this;
			_engs.Show();
		}

		private void tsServiceEngineer_Click(object sender, EventArgs e)
		{
			mnuServiceEngineers.PerformClick();
		}

		private void mnuMachineSearch_Click(object sender, EventArgs e)
		{
			var _mc = new MCInfo();
			_mc.WindowState = FormWindowState.Maximized;
			_mc.MdiParent = this;
			_mc.Show();
		}

		private void mnuErrorCategory_Click(object sender, EventArgs e)
		{
			var _errCat = new ErrList();
			_errCat.MdiParent = this;
			_errCat.StartPosition = FormStartPosition.CenterParent;
			_errCat.Show();
		}

		private void Sevices_Load(object sender, EventArgs e)
		{
			this.UpdateMenuPermission();
		}

		private void tsbtnMCRegister_Click(object sender, EventArgs e)
		{
			mnuMCRegister.PerformClick();
		}

		private void mnuMCRegister_Click(object sender, EventArgs e)
		{
			var _mcRegister = new MCRegister();
			_mcRegister.StartPosition = FormStartPosition.CenterParent;
			_mcRegister.MdiParent = this;
			_mcRegister.Show();
		}

		private void tsbtnMCSearch_Click(object sender, EventArgs e)
		{
			mnuMachineSearch.PerformClick();
		}

		private void mnuServiceStat_Click(object sender, EventArgs e)
		{
			Views.ServiceView.SrvStat stat = new SrvStat();
			stat.StartPosition = FormStartPosition.CenterParent;
			stat.MdiParent = this;
			stat.Show();
		}

		private void mnuProducts_Click(object sender, EventArgs e)
		{
			var _productList = new ProductView.MCModelList();
			_productList.StartPosition = FormStartPosition.CenterScreen;
			_productList.MdiParent = this;
			_productList.Show();
		}

		private void tsbtnPM_Click(object sender, EventArgs e)
		{
			mnuPM.PerformClick();
		}

		private void mnuPM_Click(object sender, EventArgs e)
		{
			var _pm = new Views.ServiceView.PM();
			_pm.MdiParent = this;
			_pm.StartPosition = FormStartPosition.CenterParent;
			_pm.Show();
		}
	}
}