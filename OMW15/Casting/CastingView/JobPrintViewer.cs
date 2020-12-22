using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Casting.CastingView
{
	public partial class JobPrintViewer : Form
	{
		#region class property
		public PrintDocumentType PrintWhat
		{
			get;
			set;
		}

		public int JobNumber
		{
			get;
			set;
		}

		public int JobStatus
		{
			get;
			set;
		}
		public string JobCategory
		{
			get;
			set;
		}

		public string CustomerCode
		{
			get;
			set;
		}

		public string PrintingTitle
		{
			get;
			set;
		}

		#region class method

		private void GetCastingQCJobs(int Status, string CustomerCode, string JobCategory)
		{
			try
			{
				// create datatable
				DataTable dt = new Casting.CastingController.CastingJobDataSource().GetCastingQCJobs(Status, CustomerCode, JobCategory);

				//this.JobOrderDataItemBindingSource.DataSource = dt;
				this.reportViewer1.LocalReport.ReportEmbeddedResource = "OMW15.Casting.CastingReports.JobQC.rdlc";
				this.reportViewer1.LocalReport.DataSources[0].Value = dt;

				this.reportViewer1.RefreshReport();

			}
			catch(Exception ex)
			{
				omglobal.DisplayAlert("Generate report error", ex.ToString());
			}

		} // end GetCastingQCJobs

		private void GetCastingJobOrder(int JobId)
		{
			DataTable dt = new Casting.CastingController.CastingJobDataSource().GetCastingJobOrderRecords(JobId);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "OMW15.Casting.CastingReports.JobOrder.rdlc";

			this.reportViewer1.LocalReport.DataSources[0].Value = dt;
			this.reportViewer1.RefreshReport();

		} // end GetCastingJobOrder

		#endregion


		#endregion

		public JobPrintViewer()
		{
			InitializeComponent();
		}

		private void JobPrintViewer_Load(object sender, EventArgs e)
		{
			this.bgw.RunWorkerAsync();
			this.lbTitle.Text = this.PrintingTitle;

		}

		private void bgw_DoWork(object sender, DoWorkEventArgs e)
		{
			switch(this.PrintWhat)
			{
				case PrintDocumentType.JobOrder:
					this.GetCastingJobOrder(this.JobNumber);
					break;
				case PrintDocumentType.JobQC:
					this.GetCastingQCJobs(this.JobStatus, this.CustomerCode, this.JobCategory);
					break;
				case PrintDocumentType.JobSummary:
					break;
				case PrintDocumentType.JobProgress:
					break;
			}
		}
	}
}
