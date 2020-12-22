using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using OMW15.Controllers.ServiceController;
using OMW15.Models.ServiceModel;
using OMW15.Shared;

namespace OMW15.Views.ServiceReports
{
	public partial class ServicePrintHost : Form
	{
		public ServicePrintHost()
		{
			InitializeComponent();
		}

		private void ServicePrintHost_Load(object sender, EventArgs e)
		{
			switch (ReportType)
			{
				case MachineHistoryDisplayStyle.DisplayOrderForm:
					ShowOrderReport(OrderId);
					break;

				case MachineHistoryDisplayStyle.DisplayHistory:
					ShowOrderHistoryReport(OrderId);
					break;

				case MachineHistoryDisplayStyle.DisplayHistories:
					ShowOrderHistoriesReport(OrderIds);
					break;
			}
		}

		#region class property

		public int OrderId { get; set; }

		public MachineHistoryDisplayStyle ReportType { get; set; }

		public int[] OrderIds { get; set; }

		#endregion

		#region class helper method

		private void ShowOrderReport(int OrderId)
		{
			ReportDocument _rpt = new ServiceOrderForm();
			_rpt.SetDataSource(new ServiceReportDataSource(OrderId));

			// data for subreport
			_rpt.Subreports[0].SetDataSource(new ServiceReportDAL().GetServiceOrderSpareParts(OrderId));

			_rpt.SetParameterValue(0, string.Format("{0}\\{1}", omglobal.WorkStation, omglobal.UserName));

			rptView.ReportSource = _rpt;

		} // end ShowOrderReport

		private void ShowOrderHistoryReport(int OrderId)
		{
			ReportDocument _rpt = new JobHistory();
			_rpt.SetDataSource(new ServiceReportDAL().GetServiceJobHistory(OrderId));

			// data for subreport
			_rpt.Subreports[0].SetDataSource(new ServiceReportDAL().GetServiceOrderSpareParts(OrderId));

			_rpt.SetParameterValue(0, string.Format("{0}", omglobal.UserInfo));

			rptView.ReportSource = _rpt;
		} // end ShowOrderHistoryReport


		private void ShowOrderHistoriesReport(int[] OrderIds)
		{
			ReportDocument _rpt = new JobHistory();
			_rpt.SetDataSource(new ServiceReportDAL().GetServiceJobHistories(OrderIds));

			// data for subreport
			_rpt.Subreports[0].SetDataSource(new ServiceReportDAL().GetServiceOrderSpareParts(OrderIds));

			_rpt.SetParameterValue(0, string.Format("{0}", omglobal.UserInfo));

			rptView.ReportSource = _rpt;
		} // end ShowOrderHistoryReport

		#endregion
	}
}