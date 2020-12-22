using OMControls;
using OMW15.Models.ProductionModel;
using OMW15.Shared;
using System;
using System.Windows.Forms;
using static OMW15.Shared.OMShareProduction;

namespace OMW15.Views.Productions.ProductionReports
{
	public partial class ProductionReport : Form
	{
		#region class field

		private static ProductionReport instance;
		private int _mnuIndex = 0;
		private int _reportYear = DateTime.Today.Year;
		private int _reportMonth = DateTime.Today.Month;
		private ReportDisplayType _displayFlag = ReportDisplayType.AllRecords;
		private int _selectedJobStatus = 0;

		#endregion

		#region class properties

		public static ProductionReport GetInstance
		{
			get
			{
				if (instance == null || instance.IsDisposed)
				{
					instance = new ProductionReport();
				}

				return instance;
			}
		}

		#endregion

		#region Class helper

		private void UpdateUI()
		{
			if (_displayFlag == ReportDisplayType.SingleRecord)
			{
				btnShowReport.Enabled = (!String.IsNullOrEmpty(txtProductionJob.Text));
			}
			else if(_mnuIndex == 2 && !String.IsNullOrEmpty(cbxMonth.Text))
			{
				btnShowReport.Enabled = true;
			}
			else
			{
				btnShowReport.Enabled = (_mnuIndex > 0);
			}
		}

		private void GetProductionStatus()
		{
			// job status
			// 0 = none
			// 1 = active
			// 2 = closed
			//
			cbxStatus.DataSource = EnumWithName<OMShareProduction.ProductionJobStatus>.ParseEnum();
			cbxStatus.DisplayMember = "Name";
			cbxStatus.ValueMember = "Value";
		} // end GetProductionStatus


		private void GetWorkYear()
		{
			cbxYearReport.DataSource = new ProductionStatDAL().GetWorkYear();
			cbxYearReport.DisplayMember = "WorkYear";
			cbxYearReport.ValueMember = "WorkYear";

			cbxYearReport.SelectedValue = _reportYear;
		}

		private void GetWorkMonth(int workYear)
		{
			cbxMonth.DataSource = new ProductionStatDAL().GetWorkMonth(workYear);
			cbxMonth.DisplayMember = "Name";
			cbxMonth.ValueMember = "WorkPeriod";
			_reportMonth = DateTime.Today.Month;
			cbxMonth.SelectedValue = _reportMonth;
		}


		private void ShowProductionReport(int reportIndex, int yearReport, int monthReport = 0, int jobStatus = 0, string jobNo = "", ReportDisplayType _reportFlag = ReportDisplayType.AllRecords)
		{
			ProductionReportViewer _report = new ProductionReportViewer(reportIndex, yearReport, monthReport, jobStatus, _reportFlag, jobNo);
			_report.WindowState = FormWindowState.Normal;
			_report.StartPosition = FormStartPosition.CenterScreen;
			_report.Show();

		}

		#endregion

		public ProductionReport()
		{
			InitializeComponent();

			GetProductionStatus();

		}

		private void ProductionReport_Load(object sender, EventArgs e)
		{
			GetWorkYear();

			UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void mnu_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem _mnu = sender as ToolStripMenuItem;
			_mnuIndex = Int32.Parse(_mnu.Tag.ToString());
			lbReportName.Text = $"{_mnu.Text}[{_mnuIndex}]";
			txtProductionJob.Text = "";

			pnlCondition.Visible = (_mnuIndex > 0);
			pnlMonthWork.Visible = (_mnuIndex == 2);
			pnlJobStatus.Visible = (_mnuIndex == 3);
			pnlJobSearch.Visible = pnlJobStatus.Visible;

			switch (_mnuIndex)
			{
				case 1:
					cbxYearReport.SelectedValue = _reportYear;
					break;

				case 2:
					cbxYearReport.SelectedValue = _reportYear;
					break;

				case 3:
					cbxYearReport.SelectedValue = _reportYear;
					rdoAllJob.Checked = true;
					break;

			}

			UpdateUI();
		}

		private void btnShowReport_Click(object sender, EventArgs e)
		{
			ShowProductionReport(_mnuIndex, _reportYear, _reportMonth, _selectedJobStatus, txtProductionJob.Text,_displayFlag);
		}

		private void btnSearchJob_Click(object sender, EventArgs e)
		{
			using (ActiveProductionJobs jobs = new ActiveProductionJobs(_selectedJobStatus, _reportYear, txtProductionJob.Text))
			{
				jobs.StartPosition = FormStartPosition.CenterScreen;
				if (jobs.ShowDialog(this) == DialogResult.OK)
				{
					txtProductionJob.Text = jobs.ProductionJob;
				}
			}
		}

		private void rdoJob_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton _rdo = sender as RadioButton;
			string _tag = _rdo.Tag.ToString();

			_displayFlag = _tag == "A" ? ReportDisplayType.AllRecords : ReportDisplayType.SingleRecord;

			txtProductionJob.Visible = (_displayFlag ==  ReportDisplayType.SingleRecord);
			btnSearchJob.Visible = txtProductionJob.Visible;

			switch (_tag)
			{
				case "A":
					txtProductionJob.Text = "";
					txtProductionJob.Focus();
					break;

				case "S":
					btnShowReport.Enabled = (!String.IsNullOrEmpty(txtProductionJob.Text));
					break;
			}
		}

		private void txtProductionJob_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnSearchJob.PerformClick();
			}
		}

		private void cbxStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedJobStatus = Convert.ToInt32(cbxStatus.SelectedValue.ToString());
			}
			catch
			{
				_selectedJobStatus = (int)ProductionJobStatus.None;
			}

			pnlCondition2.Visible = (_selectedJobStatus != (int)ProductionJobStatus.None);
			pnlJobSearch.Visible = (pnlCondition2.Visible && _mnuIndex == 3);
			txtProductionJob.Text = "";
		}

		private void cbxMonth_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_reportMonth = int.Parse(cbxMonth.SelectedValue.ToString());
			UpdateUI();
		}

		private void cbxYearReport_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_reportYear = int.Parse(cbxYearReport.SelectedValue.ToString());
				if (_mnuIndex == 2)
				{
					cbxMonth.SelectedValue = _reportMonth;
					pnlMonthWork.Visible = (_mnuIndex == 2);
					GetWorkMonth(_reportYear);
				}
			}
			catch
			{
				//_reportYear = DateTime.Today.Year;
			}

			UpdateUI();
		}

		private void txtProductionJob_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void panel3_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
