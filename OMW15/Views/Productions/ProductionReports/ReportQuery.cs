using OMW15.Models.ProductionModel;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Productions.ProductionReports
{
	public partial class ReportQuery : Form
	{
		#region Singleton
		private static ReportQuery _instance;
		public static ReportQuery GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new ReportQuery();
				}
				return _instance;
			}
		}
		#endregion


		#region class field

		private const int ORDER_STATUS_COLSE = 2;

		private ProductionReportType _reportType = ProductionReportType.None;
		private int _reportYear = DateTime.Today.Year;
		private int _reportMonth = DateTime.Today.Month;

		#endregion


		#region class helper

		private void UpdateUI()
		{
			lbMonth.Text = $"{_reportMonth}";
			lbYear.Text = $"{_reportYear}";
		}

		private void GetWorkYear()
		{
			cbxYear.DataSource = new ProductionStatDAL().GetWorkYear(ORDER_STATUS_COLSE);
			cbxYear.DisplayMember = "y";
			cbxYear.ValueMember = "y";

			cbxYear.SelectedValue = _reportYear;
		}

		private void GetWorkMonth(int workYear)
		{
			cbxMonth.DataSource = new ProductionStatDAL().GetWorkMonth(ORDER_STATUS_COLSE, workYear);
			cbxMonth.DisplayMember = "Name";
			cbxMonth.ValueMember = "m";
			_reportMonth = DateTime.Today.Month;
			cbxMonth.SelectedValue = _reportMonth;

			UpdateUI();
		}


		private void ShowProductionReport(ProductionReportType reportType, int yearReport, int monthReport = 0, int jobStatus = 0, string jobNo = "", ReportDisplayType _reportFlag = ReportDisplayType.AllRecords)
		{
			ProductionReportViewer _report = new ProductionReportViewer(reportType, yearReport, monthReport, jobStatus, _reportFlag, jobNo);
			_report.WindowState = FormWindowState.Normal;
			_report.StartPosition = FormStartPosition.CenterScreen;
			_report.Show();

		}
		#endregion



		public ReportQuery()
		{
			InitializeComponent();

			GetWorkYear();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnReport_Click(object sender, EventArgs e)
		{
			if (_reportYear > 0 && _reportMonth > 0) _reportType = ProductionReportType.ProductionCostByMonth;
			if (_reportYear > 0 && _reportMonth == 0) _reportType = ProductionReportType.ProductionCostByYear;

			ShowProductionReport(_reportType, _reportYear, _reportMonth);
		}

		private void cbxYear_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_reportYear = Convert.ToInt32(cbxYear.SelectedValue);
			if (chkMonth.Checked)
			{
				GetWorkMonth(_reportYear);
			}

			UpdateUI();
		}

		private void chkMonth_CheckedChanged(object sender, EventArgs e)
		{
			pnlMonth.Visible = chkMonth.Checked;

			if (chkMonth.Checked)
			{
				GetWorkMonth(_reportYear);
			}
			else
			{
				_reportMonth = 0;
			}

			UpdateUI();
		}

		private void ReportQuery_Load(object sender, EventArgs e)
		{
			chkMonth.Checked = false;
		}

		private void cbxMonth_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_reportMonth = Convert.ToInt32(cbxMonth.SelectedValue);
			}
			catch
			{

			}

			UpdateUI();
		}
	}
}
