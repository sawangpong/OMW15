using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OMW15.Models.CastingModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class PrintJobOption : Form
	{
		// CONSTRUCTOR
		public PrintJobOption(int Status = (int) OMShareJobEnums.JobStatusEnumEN.Active)
		{
			InitializeComponent();
			_jobStatus = Status;
		}

		private void cbxJobCat_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_selectedJobCategory = cbxJobCat.SelectedValue.ToString();
			}
			catch
			{
				_selectedJobCategory = "R";
			}

			lbJobCat.Text = string.Format("เลือกประเภทงาน [{0}] :", _selectedJobCategory);
			lbCAT.Text = _selectedJobCategory;
			GetJobCount(_selectedJobCategory, _customerCode);

			UpdateUI();
		}

		private void PrintJobQCOption_Load(object sender, EventArgs e)
		{
			GetJobCat();
			GetJobs(_jobStatus);
			rdoPrintJob.Checked = true;
			chkPrintAllJobCat.Checked = true;
			chkPrintAllCustomers.Checked = true;
			rdoAllJobs.Checked = true;
		}

		private void chkPrintAllJobCat_CheckedChanged(object sender, EventArgs e)
		{
			if (chkPrintAllJobCat.Checked)
				_selectedJobCategory = "";
			lbJobCat.Visible = !chkPrintAllJobCat.Checked;
			cbxJobCat.Visible = lbJobCat.Visible;
			lbCAT.Text = _selectedJobCategory;
			GetJobCount(_selectedJobCategory, _customerCode);
		}

		private void btnCustomerSearch_Click(object sender, EventArgs e)
		{
			using (var customers = new CastingOrderCustomers(lbCustomer.Text))
			{
				customers.StartPosition = FormStartPosition.CenterScreen;
				if (customers.ShowDialog(this) == DialogResult.OK)
				{
					lbCustomerName.Text = customers.CustomerName;
					_customerCode = customers.CustomerCode;
				}
			}

			// display selected cust-code
			lbCustCode.Text = string.Format("{0}", _customerCode);

			GetJobCount(_selectedJobCategory, _customerCode);
			UpdateUI();
		}

		private void chkPrintAllCustomers_CheckedChanged(object sender, EventArgs e)
		{
			if (chkPrintAllCustomers.Checked)
				_customerCode = "";
			lbCustomer.Visible = !chkPrintAllCustomers.Checked;
			lbCustomerName.Visible = lbCustomer.Visible;
			btnCustomerSearch.Visible = lbCustomer.Visible;

			lbCustCode.Text = _customerCode;

			GetJobCount(_selectedJobCategory, _customerCode);
		}

		private void rdoCheckedChanged(object sender, EventArgs e)
		{
			// updating result datatable
			GetJobCount(_selectedJobCategory, _customerCode);

			var _rdo = sender as RadioButton;

			btnFindJobQC.Enabled = _rdo.Tag.ToString().ToUpper() == "SELECT";

			if (_rdo.Checked)
				switch (_rdo.Tag.ToString().ToUpper())
				{
					case "ALL":
						break;

					case "SELECT":
						btnFindJobQC.PerformClick();
						break;
				}

			UpdateUI();
		}

		private void bthFindJobQC_Click(object sender, EventArgs e)
		{
			lbSelectedJobs.Text = string.Format("จำนวนรายการที่ต้องพิมพ์ = {0} รายการ",
				GetJobList(_jobStatus, _selectedJobCategory, _customerCode));
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			var _crv = new CastingReportView();
			_crv.JobNumber = 0;
			_crv.JobNumbers = _jobList;
			_crv.PrintWhat = _printDocumentType;
			_crv.WindowState = FormWindowState.Maximized;
			_crv.ShowDialog(this);
		}

		private void rdoDocumentOption_CheckedChanged(object sender, EventArgs e)
		{
			var _rdo = sender as RadioButton;

			switch (_rdo.Tag.ToString().ToUpper())
			{
				case "JOB":
					_printDocumentType = PrintDocumentType.JobOrders;
					break;
				case "QC":
					_printDocumentType = PrintDocumentType.JobQC;
					break;
			}
		}

		#region class field member

		private DataTable _dtJobs = new DataTable();
		private string _customerCode = string.Empty;
		private string _selectedJobCategory = "R";
		private readonly int _jobStatus = (int) OMShareJobEnums.JobStatusEnumEN.Active;
		private int _printItems;
		private int[] _jobList;
		private PrintDocumentType _printDocumentType = PrintDocumentType.None;

		#endregion

		#region class helper method

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetJobCat()
		{
			cbxJobCat.DataSource = new SelectOptions().GetItemCodeData();
			cbxJobCat.DisplayMember = "VALUE";
			cbxJobCat.ValueMember = "KEY";
			cbxJobCat.SelectedValue = _selectedJobCategory;
			lbJobCat.Text = string.Format("เลือกประเภทงาน [{0}] :", _selectedJobCategory);
		} // end GetJobCat

		private void GetJobs(int Status)
		{
			var _dal = new CastingOrderReportDS();

			_dtJobs = _dal.GetJobQCList(Status);

			lbTotalRows.Text =$"Total rows = {_dtJobs.Rows.Count}";
		} // end GetJobs

		private void GetJobCount(string CAT, string Code)
		{
			var _jobnoList = new ArrayList();
			var _dt = new DataTable();

			if (_dtJobs.Rows.Count > 0)
			{
				_dt = _dtJobs.Copy();
				if (CAT == "" && Code == "")
				{
					foreach (DataRow dr in _dt.Rows)
						_jobnoList.Add(dr["JOBNO"]);
					_jobList = (int[]) _jobnoList.ToArray(typeof(int));
				}
				else if (CAT != "" && Code == "")
				{
					foreach (var item in _dt.AsEnumerable().Where(x => x.Field<string>("PREFIX") == CAT).ToList())
						_jobnoList.Add(item.Field<int>("JOBNO"));
					_jobList = (int[]) _jobnoList.ToArray(typeof(int));
				}
				else if (CAT == "" && Code != "")
				{
					foreach (var item in _dt.AsEnumerable().Where(x => x.Field<string>("CUSTCODE") == Code).ToList())
						_jobnoList.Add(item.Field<int>("JOBNO"));
					_jobList = (int[]) _jobnoList.ToArray(typeof(int));
				}
				else if (CAT != "" && Code != "")
				{
					foreach (
						var item in
						_dt.AsEnumerable()
							.Where(x => x.Field<string>("PREFIX") == CAT)
							.Where(x => x.Field<string>("CUSTCODE") == Code)
							.ToList())
						_jobnoList.Add(item.Field<int>("JOBNO"));
					_jobList = (int[]) _jobnoList.ToArray(typeof(int));
				}

				_printItems = _jobList.Count();
			}
			else
			{
				_printItems = 0;
			}

			// display the number of record selecting option
			lbSelectedJobs.Text = string.Format("จำนวนรายการที่ต้องพิมพ์ = {0} รายการ", _printItems);

		} // end GetJobCount

		private int GetJobList(int Status, string CAT, string Code)
		{
			var _jobSelectedCount = 0;
			using (var _jl = new JobListForPrint())
			{
				_jl.JobStatus = Status;
				_jl.Category = CAT;
				_jl.CustomerCode = Code;
				_jl.StartPosition = FormStartPosition.CenterScreen;
				if (_jl.ShowDialog(this) == DialogResult.OK)
				{
					_jobList = _jl.JobList;
					_jobSelectedCount = _jobList.Count();
				}
				else
				{
					_jobList = null;
				}
			}

			return _jobSelectedCount;
		} // end GetJobQCList

		#endregion
	}
}