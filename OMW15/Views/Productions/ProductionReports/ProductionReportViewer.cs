using CrystalDecisions.CrystalReports.Engine;
using OMW15.Models.ProductionModel;
using System;
using System.Data;
using System.Windows.Forms;
using static OMW15.Shared.OMShareProduction;

namespace OMW15.Views.Productions.ProductionReports
{
	public partial class ProductionReportViewer : Form
	{
		#region class field member

		private int _reportIndex = 0;
		private int _yearReport = DateTime.Today.Year;
		private int _monthReport = DateTime.Today.Month;
		private int _jobStatus = (int)ProductionJobStatus.None;
		private string _jobNo = "";
		private ReportDisplayType _reportFlag = ReportDisplayType.AllRecords;
		private ProductionReportType _reportType = ProductionReportType.None;

		#endregion


		#region class Helper

		private void WorkProcessReport(int yearReport)
		{
			ReportDocument _rpt = new ProductionProcessHours();
			DataTable _dt = new ProductionStatDAL().GetDataReportByProcess(yearReport);
			_rpt.SetDataSource(_dt);
			_rpt.SetParameterValue(0, $"ประจำปี {yearReport}");
			_rpt.SetParameterValue(1, $"รายงานโดย : {Environment.MachineName}\\{omglobal.UserName}");
			crv.ReportSource = _rpt;

		}

		private void ProductionJobReport(int yearReport, int jobStatus, string jobNo, ReportDisplayType flag)
		{
			ReportDocument _rpt = new ReportDocument();		// main report document
			
			DataTable _dt = new DataTable();                // datasource for report header
			DataTable _dtSubReport = new DataTable();       // datasource for sub-report-outsource
			DataTable _dtProcess = new DataTable();         // datasource for sub-report-process

			// retrieve data to main report
			_dt = new ProductionStatDAL().GetProductionJobHeader(yearReport, jobStatus, jobNo);

			switch (flag)
			{
				case ReportDisplayType.AllRecords:
					_rpt = new ProductionJob21();
					break;

				case ReportDisplayType.SingleRecord:
					// retrieve data for subreport
					_dtSubReport = new ProductionStatDAL().GetProductionOutSource(jobNo);

					// retrive data for production process
					_dtProcess = new ProductionStatDAL().GetProductionJobInfo(jobNo);
					_rpt = new ProductionJob3();

					// assign data to subreport
					_rpt.Subreports[1].SetDataSource(_dtSubReport);
					_rpt.Subreports[0].SetDataSource(_dtProcess);
					break;
			}

			// assign data to main report
			_rpt.SetDataSource(_dt);
			// assign data to report parameter
			_rpt.SetParameterValue(0, $"ประจำปี {yearReport}");
			_rpt.SetParameterValue(1, $"รายงานโดย : {Environment.MachineName}\\{omglobal.UserName}");
			// map report to reportviewer
			crv.ReportSource = _rpt;
			crv.Refresh();
		}

		private void ProductionWorkByMonth(int yearReport, int monthReport)
		{
			ReportDocument _rpt = new WorkByMonth();
			DataTable _dt = new ProductionStatDAL().GetWorkByMonthData(yearReport, monthReport);
			_rpt.SetDataSource(_dt);
			_rpt.SetParameterValue(0, $"ประจำงวด {yearReport}/{monthReport.GetThaiMonthName()}");
			crv.ReportSource = _rpt;
		}

		private void ProductionJobCost(int yearReport, int monthReport)
		{
			ReportDocument _rpt = new ProductionCost();     // main report document
			DataTable _dt = new DataTable();                // datasource for report header
			// retrieve data to main report
			_dt = new ProductionStatDAL().GetProductionJobCostDataSource(yearReport, monthReport);
			_rpt.SetDataSource(_dt);
			_rpt.SetParameterValue(0, $"ประจำงวด {yearReport}{(monthReport > 0 ? "/"+ monthReport.ToString() : "")}");
			crv.ReportSource = _rpt;
		}

		#endregion

		public ProductionReportViewer(ProductionReportType reportType, int yearReport, int monthReport = 0, int jobStatus = 0, ReportDisplayType reportFlag = ReportDisplayType.AllRecords, string jobNo = "")
		{
			InitializeComponent();
			_reportType = reportType;
			_reportIndex = (int)reportType;
			_yearReport = yearReport;
			_monthReport = monthReport;
			_jobStatus = jobStatus;
			_jobNo = jobNo;
			_reportFlag = reportFlag;
		}

		public ProductionReportViewer(int reportIndex, int yearReport, int monthReport = 0, int jobStatus = 0, ReportDisplayType reportFlag = ReportDisplayType.AllRecords , string jobNo = "")
		{
			InitializeComponent();
			_reportIndex = reportIndex;

			switch (_reportIndex)
			{
				case 0:
					_reportType = ProductionReportType.None;
					break;
				case 1:
					_reportType = ProductionReportType.ByProductionProcess;
					break;
				case 2:
					_reportType = ProductionReportType.ByWorker;
					break;
				case 3:
					_reportType = ProductionReportType.ByOrderType;
					break;
				case 4:
					_reportType = ProductionReportType.ProductionCostByYear;
					break;
				case 5:
					_reportType = ProductionReportType.ProductionCostByMonth;
					break;
			}


			_yearReport = yearReport;
			_monthReport = monthReport;
			_jobStatus = jobStatus;
			_jobNo = jobNo;
			_reportFlag = reportFlag;
		}

		private void ProductionReportViewer_Load(object sender, EventArgs e)
		{
			/*
			switch (_reportIndex)
			{
				case 1:
					WorkProcessReport(_yearReport);
					break;

				case 2:
					ProductionWorkByMonth(_yearReport, _monthReport);
					break;

				case 3:
					ProductionJobReport(_yearReport, _jobStatus, _jobNo, _reportFlag);
					break;
			}
			*/

			switch (_reportType)
			{
				case ProductionReportType.ByProductionProcess:
					WorkProcessReport(_yearReport);
					break;

				case ProductionReportType.ByWorker:
					ProductionWorkByMonth(_yearReport, _monthReport);
					break;

				case ProductionReportType.ByOrderType:
					ProductionJobReport(_yearReport, _jobStatus, _jobNo, _reportFlag);
					break;

				case ProductionReportType.ProductionCostByYear:
					ProductionJobCost(_yearReport, _monthReport = 0);
					break;

				case ProductionReportType.ProductionCostByMonth:
					ProductionJobCost(_yearReport, _monthReport);
					break;
					
			}
		}
	}
}
