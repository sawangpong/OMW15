using CrystalDecisions.CrystalReports.Engine;
using OMW15.Models.CastingModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using OMW15.Views.CastingReports;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingReportView : Form
	{
		private void CastingReportView_Load(object sender, EventArgs e)
		{
			switch (PrintWhat)
			{
				case PrintDocumentType.JobOrder:
				case PrintDocumentType.JobOrders:
					if (JobNumber > 0) PrintJobOrder(JobNumber);
					else PrintJobOrder(JobNumbers);

					break;

				case PrintDocumentType.JobProgress:
					break;

				case PrintDocumentType.JobQC:
					PrintJobQC();

					break;
				case PrintDocumentType.JobSummary:
					break;

				case PrintDocumentType.SaleMaterialNoVAT:
				case PrintDocumentType.SaleMaterialWithVAT:
				case PrintDocumentType.SaleOrderWithVAT:
				case PrintDocumentType.SaleOrderNoVAT:
					PrintCastingSaleOrder(SaleOrderId);
					break;

				case PrintDocumentType.BillingSaleMaterial:
					break;

				case PrintDocumentType.BillingSaleOrder:
					GetBillingForSaleOrder(BillId);
					break;

				case PrintDocumentType.WaxTreeWeight:
					WaxTreeReport(CurrentDate);
					break;

				case PrintDocumentType.WaxTrssWeightLoss:
					break;

				case PrintDocumentType.CastingMonthlyReportByCustomerAndMaterial:
				case PrintDocumentType.CastingMonthlyReportByCustomerGroup:
				case PrintDocumentType.CastingMonthlyReportByDocNo:
				case PrintDocumentType.CastingMonthlyReportByMaterial:
				case PrintDocumentType.WorkSummary:
					GetCastingMonthlyRecords(PrintWhat, _year, _month);
					break;

				case PrintDocumentType.CastingMonthlySaleMaterialReport:
					// code here
					GetCastingMonthlyRecords(PrintWhat, _year, _month);
					break;

				case PrintDocumentType.CastingDeliveryReport:
					break;
				case PrintDocumentType.CastingSaleMaterialReport:
					break;
				case PrintDocumentType.SIReport:
					break;

				case PrintDocumentType.MaterialCard:
					MaterialCardReport(_source, _customerName);
					break;
			}

			// find the print button
			// and bound the event for keep print log to database
			foreach (var ts in crv.Controls.OfType<ToolStrip>())
				foreach (var tsb in ts.Items.OfType<ToolStripButton>()) tsb.Click += PrintButton_Click;
		}

		private void PrintButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (PrintWhat)
				{
					case PrintDocumentType.BillingSaleMaterial:
						break;
					case PrintDocumentType.BillingSaleOrder:
						break;
					case PrintDocumentType.CastingDeliveryReport:
						break;
					case PrintDocumentType.CastingMonthlyReportByCustomerAndMaterial:
						break;
					case PrintDocumentType.CastingSaleMaterialReport:
						break;
					case PrintDocumentType.JobOrder:
						UpdatePrintingLog(JobNumber.ToString(),
							PrintWhat.ToString());
						UpdatePrintedFlagForJobOrder(JobNumber);
						break;
					case PrintDocumentType.JobOrders:
						UpdatePrintingLog(JobNumbers, PrintWhat.ToString());
						UpdatePrintedFlagForJobOrder(JobNumbers);
						break;
					case PrintDocumentType.JobProgress:
						break;
					case PrintDocumentType.JobQC:
						break;
					case PrintDocumentType.JobSummary:
						break;
					case PrintDocumentType.SaleInvoiceEN:
						break;
					case PrintDocumentType.SaleInvoiceTH:
						break;
					case PrintDocumentType.SaleOfferEN:
						break;
					case PrintDocumentType.SaleOfferTH:
						break;
					case PrintDocumentType.SaleOrderNoVAT:
					case PrintDocumentType.SaleOrderWithVAT:
					case PrintDocumentType.SaleMaterialWithVAT:
					case PrintDocumentType.SaleMaterialNoVAT:
						UpdatePrintingLog(SaleOrderId.ToString(), PrintWhat.ToString());
						UpdatePrintedFlagForCastingSaleOrder(SaleOrderId);
						break;

					case PrintDocumentType.SalePI:
						break;
					case PrintDocumentType.SIReport:
						break;
					case PrintDocumentType.WaxTreeWeight:
						break;
					case PrintDocumentType.WaxTrssWeightLoss:
						break;
				}
			}
			catch
			{
			}
		}

		#region class field member

		private readonly int _year = DateTime.Today.Year;
		private readonly int _month = DateTime.Today.Month;
		private readonly string _customerName = string.Empty;
		private readonly string _duration = string.Empty;
		private readonly decimal _openBalace;
		private readonly DataTable _source = new DataTable();

		#endregion

		#region class property

		[DefaultValue(0)]
		public int JobNumber { get; set; }

		[DefaultValue(null)]
		public int[] JobNumbers { get; set; }

		[DefaultValue(PrintDocumentType.None)]
		public PrintDocumentType PrintWhat { get; set; }

		[DefaultValue(0)]
		public int SaleOrderId { get; set; }

		[DefaultValue(0)]
		public int BillId { get; set; }

		public DateTime CurrentDate { get; set; }

		public decimal OpenBalance { get; set; }

		#endregion

		#region class helper method

		private void PrintJobOrder(int JobNumber)
		{
			var dt = new CastingOrderReportDS().GetJobPrintingRecord(JobNumber);

			ReportDocument rpt = new JobOrderForm();

			//FieldObject fo = rpt.ReportDefinition.ReportObjects["Barcode"] as FieldObject;
			//fo.ApplyFont(OMControls.Barcode.GetBarcodeFont());

			rpt.SetDataSource(dt);
			rpt.SetParameterValue(1, string.Format("Printed by {0}", omglobal.UserInfo));
			crv.ReportSource = rpt;
		} // end PrintJobOrder

		private async void PrintJobOrder(int[] JobNumbers)
		{
			var _dal = new CastingOrderReportDS();
			var dt = await _dal.GetJobPrintingRecords(JobNumbers);

			ReportDocument rpt = new JobOrderFormList();
			rpt.SetDataSource(dt);
			rpt.SetParameterValue(1, string.Format("Printed by {0}", omglobal.UserInfo));
			crv.ReportSource = rpt;
		} // end PrintJobOrder

		private void PrintJobQC()
		{
			var _status = (int)OMShareJobEnums.JobStatusEnumEN.Active;
			var dt = new CastingOrderReportDS().GetActiveQCJob(_status, JobNumbers);
			ReportDocument rpt = new JobQCReport();
			rpt.SetDataSource(dt);
			rpt.SetParameterValue(0, string.Format("Printed by {0}\\{1}", omglobal.WorkStation, omglobal.UserName));
			crv.ReportSource = rpt;

		} // end PrintJobQC


		private void PrintCastingSaleOrder(int SaleOrderId)
		{
			var dt = new CastingSaleOrderDataSource().CastingSaleOrderRowSource(SaleOrderId);
			var rpt = new ReportDocument();

			switch (PrintWhat)
			{
				case PrintDocumentType.SaleMaterialNoVAT:
					rpt = new CastingSaleMaterialNoVAT();
					break;
				case PrintDocumentType.SaleMaterialWithVAT:
					rpt = new CastingSaleMaterial();
					break;
				case PrintDocumentType.SaleOrderNoVAT:
					rpt = new CastingSaleOrderNoVAT();
					break;
				case PrintDocumentType.SaleOrderWithVAT:
					rpt = new CastingSaleOrder();
					break;
			}

			rpt.SetDataSource(dt);
			crv.ReportSource = rpt;
		} // end PrintCastingSaleOrder

		private void GetBillingForSaleOrder(int BillId)
		{
			var _dt = new BillingDAL().GetBillingRecords(BillId);
			ReportDocument rpt = new BillingSO();
			rpt.SetDataSource(_dt);
			crv.ReportSource = rpt;
		} // end GetBillingForSaleOrder

		private /*async*/ void WaxTreeReport(DateTime SelectedDate)
		{
			var _dal = new CastingTreeController();

			var dt = /*await*/ _dal.GetAsyncCastingTrees(SelectedDate);

			ReportDocument rpt = new WaxTreeReport();
			rpt.SetDataSource(dt);
			crv.ReportSource = rpt;
		} // end WaxTreeReport

		private async void GetCastingMonthlyRecords(PrintDocumentType ReportType, int Year, int Month)
		{
			var _dal = new CastingOrderReportDS();
			var _dt = new DataTable();

			switch (ReportType)
			{
				case PrintDocumentType.CastingMonthlyReportByDocNo:

					// get data
					_dt = await _dal.GetAsyncCastingSaleOrderReportDataSource(ReportType, Year, Month);

					var rptByDocument = new CastingMonthReportByDocument();
					rptByDocument.SetDataSource(_dt);
					rptByDocument.SetParameterValue(0, string.Format("Printed by {0}", omglobal.UserInfo));
					rptByDocument.SetParameterValue(1, string.Format("{0} \\ {1}", Year, Month));
					crv.ReportSource = rptByDocument;
					break;

				case PrintDocumentType.CastingMonthlyReportByCustomerGroup:
					// get data
					_dt = await _dal.GetAsyncCastingSaleOrderReportDataSource(ReportType, Year, Month);

					var rptByCustGroup = new CastingMonthReportByCustGroup();
					rptByCustGroup.SetDataSource(_dt);
					rptByCustGroup.SetParameterValue(0, string.Format("Printed by {0}", omglobal.UserInfo));
					rptByCustGroup.SetParameterValue(1, string.Format("{0} \\ {1}", Year, Month));
					crv.ReportSource = rptByCustGroup;
					break;

				case PrintDocumentType.CastingMonthlyReportByCustomerAndMaterial:
					// get data
					_dt = await _dal.GetAsyncCastingSaleOrderReportDataSource(ReportType, Year, Month);

					var rptByCustMat = new CastingMonthReportByCustomer();
					rptByCustMat.SetDataSource(_dt);
					rptByCustMat.SetParameterValue(0, string.Format("Printed by {0}", omglobal.UserInfo));
					rptByCustMat.SetParameterValue(1, string.Format("{0} \\ {1}", Year, Month));
					crv.ReportSource = rptByCustMat;
					break;

				case PrintDocumentType.CastingMonthlySaleMaterialReport:
					// get data
					_dt = await _dal.GetAsyncCastingSaleMaterialReportDataSource(ReportType, Year, Month);
					var rptSaleMaterialMonthReport = new SaleMaterialMonthReport();
					rptSaleMaterialMonthReport.SetDataSource(_dt);
					rptSaleMaterialMonthReport.SetParameterValue(0, string.Format("Printed by {0}", omglobal.UserInfo));
					rptSaleMaterialMonthReport.SetParameterValue(1, string.Format("{0} \\ {1}", Year, Month));
					crv.ReportSource = rptSaleMaterialMonthReport;
					break;


				case PrintDocumentType.CastingMonthlyReportByMaterial:
					// get data
					_dt = await _dal.GetAsyncCastingSaleOrderReportDataSource(ReportType, Year, Month);

					var rptByMat = new CastingMonthReportByMaterial();
					rptByMat.SetDataSource(_dt);
					rptByMat.SetParameterValue(0, string.Format("Printed by {0}", omglobal.UserInfo));
					rptByMat.SetParameterValue(1, string.Format("{0} \\ {1}", Year, Month));
					crv.ReportSource = rptByMat;
					break;

				case PrintDocumentType.WorkSummary:

					_dt = await _dal.GetCastingWorkSummaryAsync(Year);
					var rpt = new WorkSummary();
					rpt.SetDataSource(_dt);
					rpt.SetParameterValue(0, $"{Year}");
					crv.ReportSource = rpt;
					break;
			}
		} // end GetCastingMonthlyRecords


		private void UpdatePrintingLog(string DocNo, string LogName)
		{
			var _log = new PRINTLOG();
			_log.DOCID = DocNo;
			_log.DOCNAME = LogName;
			_log.PRINT_DT = DateTime.Now;
			_log.PRINT_BY = omglobal.UserInfo;

			var _result = new PrintLog().UpdatePrintLog(_log);
		} // end UpdatePrintingLog

		private void UpdatePrintingLog(int[] DocNo, string LogName)
		{
			foreach (var doc in DocNo)
			{
				var _log = new PRINTLOG();
				_log.DOCID = doc.ToString();
				_log.DOCNAME = LogName;
				_log.PRINT_DT = DateTime.Now;
				_log.PRINT_BY = omglobal.UserInfo;

				var _result = new PrintLog().UpdatePrintLog(_log);
			}
		} // end UpdatePrintingLog

		private void UpdatePrintedFlagForCastingSaleOrder(int CastingSaleOrderId)
		{
			new PrintLog().UpdatePrintLogForCastingSaleOrder(CastingSaleOrderId);
		} // end UpdatePrintedFlagForCastingSaleOrder

		private void UpdatePrintedFlagForJobOrder(int JobNo)
		{
			new PrintLog().UpdatePrintLogForJobOrder(JobNo);
		} // end UpdatePrintedFlagForJobOrder

		private void UpdatePrintedFlagForJobOrder(int[] JobNos)
		{
			foreach (var job in JobNos) new PrintLog().UpdatePrintLogForJobOrder(job);
		} // end UpdatePrintedFlagForJobOrder

		private void MaterialCardReport(DataTable Source, string Customer)
		{
			ReportDocument rpt = new CastingReports.MaterialCard();
			rpt.SetDataSource(Source);
			rpt.SetParameterValue(0, Customer);
			rpt.SetParameterValue(1, _openBalace);
			rpt.SetParameterValue(2, string.Format("Printed by {0}", omglobal.UserInfo));
			rpt.SetParameterValue(3, _duration);
			crv.ReportSource = rpt;
		} // end MaterialCardReport

		#endregion

		// Constructor

		#region Overload Constructor

		public CastingReportView()
		{
			InitializeComponent();
		}

		public CastingReportView(int ReportYear, int ReportMonth)
		{
			InitializeComponent();
			_year = ReportYear;
			_month = ReportMonth;
		}

		public CastingReportView(DataTable DataSource, string Duration, string CustomerName, decimal OpenBalance)
		{
			InitializeComponent();
			_source = DataSource;
			_duration = Duration;
			_customerName = CustomerName;
			_openBalace = OpenBalance;
		}

		#endregion CONSTRUCTOR

		private void crv_Load(object sender, EventArgs e)
		{

		}
	}
}