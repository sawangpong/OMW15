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
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using OMW15.Shared;
using OMControls;

namespace OMW15.Casting.CastingView
{
	public partial class CastingReportView : Form
	{

		#region class property

		public int JobNumber
		{
			get;
			set;
		}

		public PrintDocumentType PrintWhat
		{
			get;
			set;
		}

		#endregion

		#region class helper method

		private void PrintJobOrder(int JobNumber)
		{
			DataTable dt = new Casting.CastingController.CastingOrderReportDS().GetJobPrintingRecord(this.JobNumber);

			ReportDocument rpt = new Casting.CastingReports.JobOrderForm();
			rpt.SetDataSource(dt);
			rpt.SetParameterValue(1, string.Format("Printed by {0}\\{1}", omglobal.WorkStation, omglobal.UserName));
			this.crv.ReportSource = rpt;

		} // end 

		private void PrintJobQC()
		{
			int _status = (int)OMShareJobEnums.JobStatusEnum.Active;
			DataTable dt = new Casting.CastingController.CastingOrderReportDS().GetActiveQCJob(_status);
			ReportDocument rpt = new Casting.CastingReports.JobQCReport();
			rpt.SetDataSource(dt);
			rpt.SetParameterValue(0, string.Format("Printed by {0}\\{1}", omglobal.WorkStation, omglobal.UserName));
			this.crv.ReportSource = rpt;

		} // end PrintJobQC

		#endregion

		public CastingReportView()
		{
			InitializeComponent();
		}

		private void CastingReportView_Load(object sender, EventArgs e)
		{
			switch (this.PrintWhat)
			{
				case PrintDocumentType.JobOrder:
					this.PrintJobOrder(this.JobNumber);
					break;

				case PrintDocumentType.JobProgress:
					break;
				case PrintDocumentType.JobQC:
					this.PrintJobQC();

					break;
				case PrintDocumentType.JobSummary:
					break;
			}
		}
	}
}
