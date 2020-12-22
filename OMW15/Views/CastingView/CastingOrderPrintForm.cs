using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace OMW15.Casting.CastingView
{
	public partial class CastingOrderPrintForm : Form
	{

		#region class Field Member

		#endregion

		#region class property

		public PrintDocumentType DocumentType
		{
			get;
			set;
		}

		public int CastingOrderNumber
		{
			get;
			set;
		}

		public int JobStatus
		{
			get;
			set;
		}

		public string CustomerCode
		{
			get;
			set;
		}

		public string JobCode
		{
			get;
			set;
		}
		#endregion

		#region class method

		private void GetCastingOrderData(int CastingOrderNumber)
		{
			//update Title
			this.Text = "INTERNAL ORDER FORM";
			#region
			////generate SQL script
			//StringBuilder s = new StringBuilder();
			//s.AppendLine();
			//s.Append(" SELECT ");
			//s.AppendLine();
			//s.Append(" JOBNO,");
			//s.AppendLine();
			//s.Append(" 'JOBDATE'=dbo.uf_NUMTODATE(jd.JOBDATE),");
			//s.AppendLine();
			//s.Append(" 'STATUS'= CASE WHEN ISREWORKS=1 THEN '§Ò¹«èÍÁ' ELSE (SELECT THKEYNAME FROM SYSDATA WHERE GROUPTITLE='ORDERSTATUS' AND KEYVALUE=jd.STATUS) END,");
			//s.AppendLine();
			//s.Append("'CUSTOMER'=(SELECT CUSTNAME FROM CUSTOMERS WHERE CUSTCODE=jd.CUSTCODE),");
			//s.AppendLine();
			//s.Append(" CUSTPO,");
			//s.AppendLine();
			//s.Append("'DUE-DATE'=dbo.uf_NUMTODATE(jd.DUEDATE),");
			//s.AppendLine();
			//s.Append(" cp.PICTURE,");
			//s.AppendLine();
			//s.Append(" jd.ITEMNO,");
			//s.AppendLine();
			//s.Append(" jd.ITEMNAME,");
			//s.AppendLine();
			//s.Append(" jd.ORDERQTY,");
			//s.AppendLine();
			//s.Append(" jd.ORDERUNIT,");
			//s.AppendLine();
			//s.Append(" 'WAX'=CASE WHEN jd.WAX=1 THEN 'X' ELSE ' ' END,");
			//s.AppendLine();
			//s.Append(" 'CASTING'=CASE WHEN jd.CASTING=1 THEN 'X' ELSE ' ' END,");
			//s.AppendLine();
			//s.Append(" 'MAKEBLOCK'=CASE WHEN jd.MAKEBLOCK=1 THEN 'X' ELSE ' ' END,");
			//s.AppendLine();
			//s.Append(" WAXWORKER,FINISHINGWORKER,");
			//s.AppendLine();
			//s.Append(" 'MATERIAL'= (SELECT THKEYNAME FROM SYSDATA WHERE GROUPTITLE='MATERIAL' AND KEYVALUE = jd.MATERIALTYPE),");
			//s.AppendLine();
			//s.Append(" 'WAXSOURCE'=CASE WHEN ISOWNERWAX=1 THEN 'ÅÙ¡¤éÒãËéà·ÕÂ¹' ELSE '' END,");
			//s.AppendLine();
			//s.Append(" REMARK ");
			//s.AppendLine();
			//s.Append(" FROM JOBORDERS jd");
			//s.AppendLine();
			//s.Append(" LEFT OUTER JOIN CUSTPRICELIST cp ON jd.CUSTCODE=cp.CUSTID ");
			//s.AppendLine();
			//s.Append(" AND jd.ITEMNO = cp.ITEMNO ");
			//s.AppendLine();
			//s.Append(" WHERE jd.STATUS IN (1,2) ");
			//s.AppendLine();
			//s.AppendFormat(" AND jd.JOBNO IN ({0})", CastingOrderNumber);
			//s.AppendLine();
			//s.Append(" ORDER BY jd.JOBNO ");
			//s.AppendLine();

			//debug
			//AppUtils.ShowErrorMessage(s.ToString(), "debug SQL");
			//end debug
			#endregion

			try
			{
				// create datatable
				DataTable dt = new Casting.CastingController.JobDataSource().GetCastingJobOrderRecords(CastingOrderNumber);

				// create reportdocument object
				CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new Casting.CastingReports.JobOrderForm();

				// set datatable to reportdocument
				rpt.SetDataSource(dt);

				// send parameters to reportdocument
				rpt.SetParameterValue(0, string.Format("{0}", omglobal.COMPANY_NAME));
				rpt.SetParameterValue(1, string.Format("Printed by {0}\\{1}", omglobal.WorkStation, omglobal.UserName));

				// map reportdocument to report viewer
				this.crv.ReportSource = rpt;
			}
			catch(Exception ex)
			{
				omglobal.DisplayAlert("Generate report error", ex.ToString());
			}

		} // end GetCastingOrderData

		private void GetCastingQCJobs(int Status, string CustomerCode, string JobCode)
		{
			try
			{
				// create datatable
				DataTable dt = new Casting.CastingController.JobDataSource().GetJobQCTable(Status, CustomerCode, JobCode);

				// map job orm
				CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new Casting.CastingReports.JobQCReport();

				// set datatable to reportdocument
				rpt.SetDataSource(dt);

				// send parameters to reportdocument
				rpt.SetParameterValue(0, string.Format("{0}", omglobal.COMPANY_NAME));
				rpt.SetParameterValue(1, string.Format("Printed by {0}\\{1}", omglobal.WorkStation, omglobal.UserName));

				// map reportdocument to report viewer
				this.crv.ReportSource = rpt;
			}
			catch(Exception ex)
			{
				omglobal.DisplayAlert("Generate report error", ex.ToString());
			}

		} // end GetCastingQCJobs

		private void PrintJobQC()
		{
			this.GetCastingQCJobs(this.JobStatus, this.CustomerCode, this.JobCode);
		}

		#endregion

		public CastingOrderPrintForm()
		{
			InitializeComponent();
		}

		private void CastingOrderPrintForm_Load(object sender, EventArgs e)
		{
			switch(this.DocumentType)
			{
				case PrintDocumentType.JobOrder:
					  this.GetCastingOrderData(this.CastingOrderNumber);
					break;
				case PrintDocumentType.JobSummary:
					break;
				case PrintDocumentType.JobQC:
					this.GetCastingQCJobs(this.JobStatus, this.CustomerCode, this.JobCode);

					 //Thread _printThread = new Thread(new ThreadStart(this.PrintJobQC));
					 // _printThread.Start();
					break;

			}
		}
	}
}
