using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers;
using OMW15.Models;
using OMW15.Shared;
using OMW15.Views;


namespace OMW15.Views.CastingView
{
	public partial class PrintJobQCOption : Form
	{
		#region class field member
		private DataTable _dtQC = new DataTable();
		private string _customerCode = string.Empty;
		private string _selectedJobCategory = "R";
		private int _jobStatus = (int)Shared.OMShareJobEnums.JobStatusEnumEN.Active;
		private int _printItems = 0;
		private int[] _jobList;

		#endregion


		#region class helper method

		private void UpdateUI()
		{

		} // end UpdateUI

		private void GetJobCat()
		{
			this.cbxJobCat.DataSource = new Models.ToolModel.SelectOptions().GetItemCodeData();
			this.cbxJobCat.DisplayMember = "VALUE";
			this.cbxJobCat.ValueMember = "KEY";
			this.cbxJobCat.SelectedValue = _selectedJobCategory;
			this.lbJobCat.Text = string.Format("เลือกประเภทงาน [{0}] :", _selectedJobCategory);

		} // end GetJobCat

		private void GetQCJobs(int Status)
		{
			Models.CastingModel.CastingOrderReportDS _dal = new Models.CastingModel.CastingOrderReportDS();

			_dtQC = _dal.GetJobQCList(Status);

			this.lbTotalRows.Text = string.Format("Total rows = {0}", _dtQC.Rows.Count);

		} // end GetQCJobs

		private void GetJobQCCount(string CAT, string Code)
		{
			ArrayList _jobnoList = new ArrayList();
			DataTable _dt = new DataTable();

			if (_dtQC.Rows.Count > 0)
			{
				_dt = _dtQC.Copy();
				if ((CAT == "") && (Code == ""))
				{
					foreach (DataRow dr in _dt.Rows)
					{
						_jobnoList.Add(dr["JOBNO"]);
					}
					_jobList = (int[])_jobnoList.ToArray(typeof(System.Int32));
				}
				else if ((CAT != "") && (Code == ""))
				{
					foreach (var item in _dt.AsEnumerable().Where(x => x.Field<string>("PREFIX") == CAT).ToList())
					{
						_jobnoList.Add(item.Field<int>("JOBNO"));
					}
					_jobList = (int[])_jobnoList.ToArray(typeof(System.Int32));
				}
				else if ((CAT == "") && (Code != ""))
				{
					foreach (var item in _dt.AsEnumerable().Where(x => x.Field<string>("CUSTCODE") == Code).ToList())
					{
						_jobnoList.Add(item.Field<int>("JOBNO"));
					}
					_jobList = (int[])_jobnoList.ToArray(typeof(System.Int32));
				}
				else if ((CAT != "") && (Code != ""))
				{
					foreach (var item in _dt.AsEnumerable().Where(x => x.Field<string>("PREFIX") == CAT).Where(x => x.Field<string>("CUSTCODE") == Code).ToList())
					{
						_jobnoList.Add(item.Field<int>("JOBNO"));
					}
					_jobList = (int[])_jobnoList.ToArray(typeof(System.Int32));
				}

				_printItems = _jobList.Count();
			}
			else
			{
				_printItems = 0;
			}

			// display the number of record selecting option
			this.lbSelectedJobs.Text = string.Format("จำนวนรายการที่ต้องพิมพ์ = {0} รายการ", _printItems);


			// debug
			//if (_jobList != null)
			//{
			//	this.GetFinalResultList(_jobList);
			//}
			// end debug

		} // end GetJobQCCount

		private int GetJobQCList(int Status, string CAT, string Code)
		{
			int _jobSelectedCount = 0;
			using (Views.CastingView.JobListForQC _jl = new JobListForQC())
			{
				_jl.JobStatus = Status;
				_jl.Category = CAT;
				_jl.CustomerCode = Code;
				_jl.StartPosition = FormStartPosition.CenterScreen;
				if (_jl.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					_jobList = _jl.JobQCList;
					_jobSelectedCount = _jobList.Count();
				}
				else
				{
					_jobList = null;
				}
			}

			// debug
			//if (_jobList != null)
			//{
			//	this.GetFinalResultList(_jobList);
			//}
			// end debug

			return _jobSelectedCount;

		} // end GetJobQCList

		private void GetFinalResultList(int[] JobList)
		{
			var _finalResult = _dtQC.AsEnumerable().Where(x => JobList.Contains(x.Field<int>("JOBNO"))).AsParallel().ToList();

			// debug
			StringBuilder _sb = new StringBuilder();
			foreach (var x in _finalResult)
			{
				_sb.AppendFormat("{0}  {1}", x.Field<int>("JOBNO"), x.Field<string>("CUSTNAME"));
				_sb.AppendLine();
			}

			// show result
			Controllers.ToolController.Alert.DisplayAlert("Show Final Result for QC Record", _sb.ToString());

			// end debug

		} // end GetFinalResultList

		#endregion


		// CONSTRUCTOR
		public PrintJobQCOption(int Status = (int)Shared.OMShareJobEnums.JobStatusEnumEN.Active)
		{
			InitializeComponent();
			_jobStatus = Status;
		}

		private void cbxJobCat_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_selectedJobCategory = this.cbxJobCat.SelectedValue.ToString();
			}
			catch
			{
				_selectedJobCategory = "R";
			}

			this.lbJobCat.Text = string.Format("เลือกประเภทงาน [{0}] :", _selectedJobCategory);
			this.lbCAT.Text = _selectedJobCategory;
			this.GetJobQCCount(_selectedJobCategory, _customerCode);

			this.UpdateUI();
		}

		private void PrintJobQCOption_Load(object sender, EventArgs e)
		{
			this.GetJobCat();
			this.GetQCJobs(_jobStatus);

			this.chkPrintAllJobCat.Checked = true;
			this.chkPrintAllCustomers.Checked = true;
			this.rdoAllJobs.Checked = true;
		}

		private void chkPrintAllJobCat_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkPrintAllJobCat.Checked == true)
			{
				_selectedJobCategory = "";
			}
			this.lbJobCat.Visible = !this.chkPrintAllJobCat.Checked;
			this.cbxJobCat.Visible = this.lbJobCat.Visible;
			this.lbCAT.Text = _selectedJobCategory;
			this.GetJobQCCount(_selectedJobCategory, _customerCode);

		}

		private void btnCustomerSearch_Click(object sender, EventArgs e)
		{
			using (Views.CastingView.CastingOrderCustomers customers = new Views.CastingView.CastingOrderCustomers(this.lbCustomer.Text))
			{
				customers.StartPosition = FormStartPosition.CenterScreen;
				if (customers.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					this.lbCustomerName.Text = customers.CustomerName;
					_customerCode = customers.CustomerCode;
				}
			}

			// display selected cust-code
			this.lbCustCode.Text = string.Format("{0}", _customerCode);

			this.GetJobQCCount(_selectedJobCategory, _customerCode);
			this.UpdateUI();
		}

		private void chkPrintAllCustomers_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkPrintAllCustomers.Checked == true)
			{
				_customerCode = "";

			}
			this.lbCustomer.Visible = !this.chkPrintAllCustomers.Checked;
			this.lbCustomerName.Visible = this.lbCustomer.Visible;
			this.btnCustomerSearch.Visible = this.lbCustomer.Visible;

			this.lbCustCode.Text = _customerCode;

			this.GetJobQCCount(_selectedJobCategory, _customerCode);
		}

		private void rdoCheckedChanged(object sender, EventArgs e)
		{
			// updating result datatable
			this.GetJobQCCount(_selectedJobCategory, _customerCode);

			RadioButton _rdo = sender as RadioButton;

			this.btnFindJobQC.Enabled = (_rdo.Tag.ToString().ToUpper() == "SELECT");

			if (_rdo.Checked == true)
			{
				switch (_rdo.Tag.ToString().ToUpper())
				{
					case "ALL":
						break;

					case "SELECT":
						this.btnFindJobQC.PerformClick();
						break;
				}
			}

			this.UpdateUI();
		}

		private void bthFindJobQC_Click(object sender, EventArgs e)
		{
			this.lbSelectedJobs.Text = string.Format("จำนวนรายการที่ต้องพิมพ์ = {0} รายการ", this.GetJobQCList(_jobStatus, _selectedJobCategory, _customerCode));
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			Views.CastingView.CastingReportView _crv = new CastingReportView();
			_crv.JobNumberList = _jobList;
			_crv.PrintWhat = PrintDocumentType.JobQC;
			_crv.WindowState = FormWindowState.Maximized;
			_crv.ShowDialog(this);

		}
	}
}
