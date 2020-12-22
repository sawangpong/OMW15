using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace OMW15.Services.ServiceReports
{
	public partial class ServicePrintHost : Form
	{

		#region class property

		public int OrderId
		{
			get;
			set;
		}

		public MachineHistoryDisplayStyle ReportType
		{
			get;
			set;
		}

		#endregion

		#region class helper method

		private void ShowOrderReport(int OrderId)
		{
			ReportDocument _rpt = new Services.ServiceReports.ServiceOrderForm();
			_rpt.SetDataSource(new Services.ServiceController.ServiceReportDataSource(OrderId));
			_rpt.SetParameterValue(0, string.Format("{0}\\{1}", omglobal.WorkStation, omglobal.UserName));
			this.rptView.ReportSource = _rpt;

		} // end ShowOrderReport

		#endregion

		public ServicePrintHost()
		{
			InitializeComponent();
		}

		private void ServicePrintHost_Load(object sender, EventArgs e)
		{
			switch (this.ReportType)
			{
				case MachineHistoryDisplayStyle.DisplayOrderForm:
					this.ShowOrderReport(this.OrderId);
					break;
			}

		}
	}
}
