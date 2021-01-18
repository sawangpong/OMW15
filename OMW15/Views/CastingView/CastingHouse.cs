using OMW15.Controllers.CastingController;
using OMW15.Shared;
using OMW15.Views.CustomerView;
using OMW15.Views.EmployeeView;
using OMW15.Views.ToolViews;
using System;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingHouse : Form
	{
		#region Singleton
		public static CastingHouse _instance;
		public static CastingHouse GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed) _instance = new CastingHouse();
				return _instance;
			}
		}
		#endregion

		public CastingHouse()
		{
			InitializeComponent();
		}

		#region class helper methods

		private void SetMenuItemPermission()
		{
			mnuSCSummary.Enabled = omglobal.PermisionId >= (int)OMShareSysConfigEnums.UserPermission.Accounting;
			mnuItemImageResize.Visible = mnuSCSummary.Enabled;
			mnuReports.Visible = mnuSCSummary.Enabled;
		} // end SetMenuItemPermission

		#endregion

		private void mnuCastingPriceList_Click(object sender, EventArgs e)
		{
			var _castingPrice = new CastingPriceList();
			_castingPrice.MdiParent = this;
			_castingPrice.WindowState = FormWindowState.Maximized;
			_castingPrice.Show();
		}

		//private void mnuItemImageResize_Click(object sender, EventArgs e)
		//{
		//	var _imgResize = new ItemImageResize();
		//	_imgResize.StartPosition = FormStartPosition.CenterParent;
		//	_imgResize.Show(this);
		//}

		private void mnuRubberBase_Click(object sender, EventArgs e)
		{
			var _rb = new RBList(ActionMode.Recording);
			_rb.MdiParent = this;
			_rb.StartPosition = FormStartPosition.CenterParent;
			_rb.Show();
		}

		private void mnuCastingMaterials_Click(object sender, EventArgs e)
		{
			var _cml = new CastingMatList(ActionMode.Recording);
			_cml.StartPosition = FormStartPosition.CenterParent;
			_cml.MdiParent = this;
			_cml.Show();
		}

		private void mnuMaterialSaleCost_Click(object sender, EventArgs e)
		{
			var _matSales = new MaterialCost();
			_matSales.StartPosition = FormStartPosition.CenterParent;
			_matSales.MdiParent = this;
			_matSales.Show();
		}

		private void mnuCastingJobs_Click(object sender, EventArgs e)
		{
			//var _cj = new CTJobs();
			var _cj = CastingHub.GetInstance;
			_cj.WindowState = FormWindowState.Maximized;
			_cj.MdiParent = this;
			_cj.Show();
		}

		private void mnuCastingDaily_Click(object sender, EventArgs e)
		{
			var _ct = new CastingTree();
			_ct.WindowState = FormWindowState.Maximized;
			_ct.MdiParent = this;
			_ct.Show();
		}

		private void mnuCastingSaleOrder_Click(object sender, EventArgs e)
		{
			var _cso = new CastingSaleOrderList();
			_cso.MdiParent = this;
			_cso.StartPosition = FormStartPosition.CenterParent;
			_cso.Show();
		}

		private void mnuJobsProgress_Click(object sender, EventArgs e)
		{
			var _jp = new JobOrderProgressStatus();
			_jp.MdiParent = ParentForm;
			_jp.StartPosition = FormStartPosition.CenterParent;
			_jp.Show();
		}

		private void mnuWorkPerformance_Click(object sender, EventArgs e)
		{
			//var jp = new CastingProgress();
			//jp.MdiParent = this;
			//jp.WindowState = FormWindowState.Maximized;
			//jp.Show();

			Views.CastingView.CastingWorkPerformance cp = new CastingWorkPerformance();
			cp.StartPosition = FormStartPosition.CenterParent;
			cp.Show();
		}

		private void mnuWorkerPerformanceByChart_Click(object sender, EventArgs e)
		{
			var _chart = new CastingPerformanceCharts();
			_chart.WorkYear = DateTime.Today.Year;
			_chart.WorkPeriod = DateTime.Today.Month;
			_chart.MdiParent = this;
			_chart.StartPosition = FormStartPosition.CenterParent;
			_chart.Show();
		}

		private void mnuCloseCastingWindow_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnCastingPriceList_Click(object sender, EventArgs e)
		{
			mnuCastingPriceList.PerformClick();
		}

		private void mnuExchangeRate_Click(object sender, EventArgs e)
		{
			var _exchange = new ExchangeRateList();
			_exchange.StartPosition = FormStartPosition.CenterParent;
			_exchange.MdiParent = this;
			_exchange.Show();
		}

		private void mnuEmployee_Click(object sender, EventArgs e)
		{
			var memp = new MasterEmployee();
			memp.MdiParent = this;
			memp.StartPosition = FormStartPosition.CenterParent;
			memp.Show();
		}

		private void tsbtnEmployee_Click(object sender, EventArgs e)
		{
			mnuEmployee.PerformClick();
		}

		private void tsbtnCastingJobs_Click(object sender, EventArgs e)
		{
			mnuCastingJobs.PerformClick();
		}

		private void tsbtnCastingSO_Click(object sender, EventArgs e)
		{
			mnuCastingSaleOrder.PerformClick();
		}

		private void tsbtnMatSum_Click(object sender, EventArgs e)
		{
			mnuMaterialSum.PerformClick();
		}

		private void mnuMaterialSum_Click(object sender, EventArgs e)
		{
			var _matSum = CastingMaterialSummary.GetInstance;
			_matSum.WindowState = FormWindowState.Maximized;
			_matSum.MdiParent = this;
			_matSum.Show();
		}

		private void mnuCascadeWindows_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void mnuHorizontalWindowList_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void mnuVerticalWindowList_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void tsbtnBilling_Click(object sender, EventArgs e)
		{
			var _bl = new SCBilling();
			_bl.StartPosition = FormStartPosition.CenterParent;
			_bl.MdiParent = this;
			_bl.Show();
		}

		private void Casting_Load(object sender, EventArgs e)
		{
			SetMenuItemPermission();
		}


		private void mnuSCSummary_Click(object sender, EventArgs e)
		{
			var _scSum = SCOrderSummary.GetInstance;
			_scSum.StartPosition = FormStartPosition.CenterParent;
			_scSum.MdiParent = this;
			_scSum.Show();
		}

		private void tsbtnSearchJobOrder_Click(object sender, EventArgs e)
		{
			var _js = new CastingJobOrderSearch();
			_js.FormBorderStyle = FormBorderStyle.Sizable;
			_js.StartPosition = FormStartPosition.CenterScreen;
			_js.MdiParent = this;
			_js.Show();
		}

		private void mnuMatReceive_Click(object sender, EventArgs e)
		{
			var _mclear = new MaterialClearing();
			_mclear.StartPosition = FormStartPosition.CenterScreen;
			_mclear.MdiParent = this;
			_mclear.Show();
		}

		private void tsbtnCustomer_Click(object sender, EventArgs e)
		{
		}

		private void tsbtnPrintDOC_Click(object sender, EventArgs e)
		{
			var _qcOption = new PrintJobOption();
			_qcOption.StartPosition = FormStartPosition.CenterScreen;
			_qcOption.ShowDialog(this);
		}

		private void mnuCastingMonthReport_Click(object sender, EventArgs e)
		{
			var reportType = PrintDocumentType.None;
			var mnu = sender as ToolStripMenuItem;
			switch (mnu.Tag.ToString())
			{
				case "BY_CUST_MAT":
					reportType = PrintDocumentType.CastingMonthlyReportByCustomerAndMaterial;
					break;

				case "BY_CUST_GROUP":
					reportType = PrintDocumentType.CastingMonthlyReportByCustomerGroup;
					break;

				case "BY_DOCUMENT":
					reportType = PrintDocumentType.CastingMonthlyReportByDocNo;
					break;

				case "SALE_MATERIAL":
					reportType = PrintDocumentType.CastingMonthlySaleMaterialReport;
					break;
				case "BY_MAT":
					reportType = PrintDocumentType.CastingMonthlyReportByMaterial;
					break;
				case "WORK_SCORE":
					reportType = PrintDocumentType.WorkSummary;
					break;

			}

			var _castingReport = new CastingReportControllers();
			_castingReport.CastingMonthlyReport(reportType);
		}

		private void mnuCustomerList_Click(object sender, EventArgs e)
		{
			var _masterCustomers = new MasterCustomers();
			_masterCustomers.StartPosition = FormStartPosition.CenterScreen;
			_masterCustomers.Action = OMShareCustomerEnums.MasterCustomerAction.None;
			_masterCustomers.MdiParent = this;
			_masterCustomers.Show();
		}

		private void mnuCustomerGroups_Click(object sender, EventArgs e)
		{
			var _customerGroupList = new CustomerGroupList();
			_customerGroupList.MdiParent = this;
			_customerGroupList.StartPosition = FormStartPosition.CenterScreen;
			_customerGroupList.Show();
		}

		private void mnuMaterialCard_Click(object sender, EventArgs e)
		{
			var _matCard = new MaterialDeliveryController();
			_matCard.ViewMaterialDeliveryCard();
		}

		private void mnuMatBalance_Click(object sender, EventArgs e)
		{
			var mb = new MaterialCutBalance("", "", "");
			mb.StartPosition = FormStartPosition.CenterScreen;
			mb.Show();
		}

		private void tsbtnJobQC_Click(object sender, EventArgs e)
		{
			var _qc = new CastingJobFG();
			_qc.StartPosition = FormStartPosition.CenterScreen;
			_qc.MdiParent = this;
			_qc.Show();
		}

		private void tsbtnDailyCasting_Click(object sender, EventArgs e)
		{
			mnuCastingDaily.PerformClick();
		}
	}
}