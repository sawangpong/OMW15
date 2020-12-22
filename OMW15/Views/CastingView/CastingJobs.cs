using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers;
using OMW15.Models;
using OMW15.Shared;
using OMW15.Views;

namespace OMW15.Views.CastingView
{
	public partial class CastingJobs : Form
	{
		#region class field member

		private enum FindList
		{
			หมายเลขใบงาน,
			ชื่อลูกค้า
		}

		private FindList _findOption = FindList.ชื่อลูกค้า;
		private string _selectedCustomerName = string.Empty;
		private string _selectedCustomerCode = string.Empty;
		private string _selectedJobCategory = string.Empty;
		private string _selectedItemPrefix = string.Empty;
		private int _selectedCustomerId = 0;
		private int _selectedJobStatus = -1;
		private int _selectedJobId = 0;
		private int _selectedItemId = 0;
		private int _priceItemId = 0;
		private int _selectedPrintForm = 0;

		private int _maxRows = 0;

		#endregion

		#region class properties

		public string SelectedCustomerCode
		{
			get
			{
				return _selectedCustomerCode;
			}
			set
			{
				_selectedCustomerCode = value;
			}
		}

		public int PriceItemId
		{
			set
			{
				_priceItemId = value;
			}
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.btnLoadJobs.Enabled = (!string.IsNullOrEmpty(_selectedJobCategory));
			this.tscbxFind.Enabled = (this.dgv.Rows.Count > 0);
			this.tsbtnEditJob.Enabled = (_selectedJobId > 0);
			this.tscbxPrintCastingForm.Enabled = this.tsbtnEditJob.Enabled;
			this.btnJobInfo.Enabled = this.tsbtnEditJob.Enabled;

		} // end UpdateUI

		private void UpdateListStatus()
		{
			this.tslbRecordFound.Text = string.Format("Found :: {0} record{1}", this.dgv.Rows.Count, this.dgv.Rows.Count > 1 ? "s" : "");

			this.tslbJobId.Text = string.Format("Job Id :: {0}", _selectedJobId);

			this.tslbCustSelected.Text = string.Format("({0})::{1}", _selectedCustomerId, _selectedCustomerCode);

		} // end UpdateListStatus

		private void GetActiveSummaryJob()
		{
			this.dgvActiveQty.SuspendLayout();
			DataTable _dt = new Models.CastingModel.JobDAL().GetSummaryJobActive();
			_dt.DefaultView.Sort = "Q";
			this.dgvActiveQty.DataSource = _dt;
			this.dgvActiveQty.Columns["Q"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.dgvActiveQty.Columns["BQ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dgvActiveQty.Columns["BQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
			this.dgvActiveQty.ColumnHeadersVisible = false;
			this.dgvActiveQty.ResumeLayout();

		} // end GetActiveSummaryJob

		private void GetJobOrderList(string JobCategory, int JobStatus)
		{
			this.dgv.SuspendLayout();

			// binding data
			if (!string.IsNullOrEmpty(JobCategory) && (JobStatus >= 0))
			{
				//DataTable _dt = new OMW15.Models.CastingModel.JobDAL().GetJobOrderList(JobCategory, JobStatus);

				//_maxRows = _dt.Rows.Count;

				//_dt.DefaultView.Sort = "JOBNO";
				//this.dgv.DataSource = _dt;

				// formatting DataGridView
				// -- hide column
				this.dgv.Columns["STATUS"].Visible = false;
				this.dgv.Columns["ITEMID"].Visible = false;
				this.dgv.Columns["CUSTOMERCODE"].Visible = false;
				this.dgv.Columns["CUSTOMERID"].Visible = false;
				this.dgv.Columns["STYLE"].Visible = false;

				// -- formating style
				this.dgv.Columns["ORDERDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

				this.dgv.Columns["START"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

				this.dgv.Columns["DUE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

				this.dgv.Columns["QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

				this.dgv.Columns["REMAIN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

				this.dgv.Columns["CAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

				this.dgv.Columns["UNIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

				this.dgv.Columns["RD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}

			// set columns width
			foreach (DataGridViewColumn dgc in this.dgv.Columns)
			{
				if (dgc.Index <= (this.dgv.Columns.Count - 2))
				{
					dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				}
				else
				{
					dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}

				if (dgc.Name == "RD" 
					|| dgc.Name == "REMAIN" 
					|| dgc.Name == "QTY")
				{
					dgc.DefaultCellStyle.Format = "N2";
				}
			}

			this.dgv.ResumeLayout();

			// update - Active Order
			this.GetActiveSummaryJob();

			// update - status
			this.UpdateListStatus();

			// update UI
			this.UpdateUI();

		} // end GetJobOrderList

		private void CreatePrintCastingJobs()
		{
			this.tscbxPrintCastingForm.ComboBox.DataSource = new Models.CastingModel.JobDAL().GetJobReportForm();
			this.tscbxPrintCastingForm.ComboBox.DisplayMember = "NAME";
			this.tscbxPrintCastingForm.ComboBox.ValueMember = "KEY";

		} // end CreatePrintCastingJobs

		private void CreateJobCategoryMenus()
		{
			DataTable _dt = new Models.ToolModel.SelectOptions().GetItemCodeData();
			this.dgvJobCat.SuspendLayout();
			this.dgvJobCat.DataSource = _dt;
			this.dgvJobCat.ColumnHeadersVisible = false;
			this.dgvJobCat.Columns["KEY"].Visible = false;
			this.dgvJobCat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvJobCat.AlternatingRowsDefaultCellStyle.BackColor = this.dgvJobCat.BackgroundColor;
			this.dgvJobCat.ResumeLayout();

		} // end CreateJobCategoryMenus

		private void AddEditJobOrder(int JobId)
		{
			using (Views.CastingView.CastingJobInfo _jobInfo = new Views.CastingView.CastingJobInfo())
			{
				_jobInfo.CreateMode = OMShareJobEnums.JobOrderCreatedMode.CreateFromJobOrderList;
				_jobInfo.ItemId = 0;
				_jobInfo.ItemCode = string.Empty;
				_jobInfo.ItemName = string.Empty;
				_jobInfo.ItemNo = string.Empty;
				_jobInfo.StyleId = 0;
				_jobInfo.StyleName = string.Empty;
				_jobInfo.Material = string.Empty;
				_jobInfo.MaterialId = 0;
				_jobInfo.ItemImage = this.pic.Image;
				_jobInfo.JobId = JobId;
				_jobInfo.StartPosition = FormStartPosition.CenterScreen;
				_jobInfo.ShowDialog(this);
			}

			// re-load job after Add/Edit
			this.tsbtnRefresh.PerformClick();


		} // end AddEditJobOrder

		private void PrintJobOrder(int SelectPrintForm, int JobNo, int JobStatus, string CustomerCode, string JobCode)
		{
			//PrintDocumentType _printForm = (PrintDocumentType)Enum.ToObject(typeof(PrintDocumentType), SelectPrintForm);

			//Casting.CastingView.JobPrintViewer _jpv = new JobPrintViewer();
			//_jpv.MdiParent = this.ParentForm;
			//_jpv.WindowState = FormWindowState.Maximized;
			//_jpv.JobNumber = JobNo;
			//_jpv.JobStatus = _selectedJobStatus;
			//_jpv.CustomerCode = _selectedCustomerCode;
			//_jpv.JobCategory = _selectedJobCategory;
			//_jpv.PrintingTitle = this.tscbxPrintCastingForm.Text;
			//_jpv.PrintWhat = _printForm;
			//_jpv.Show();

			PrintDocumentType _reportType = PrintDocumentType.None;

			switch (SelectPrintForm)
			{
				case 1:
					_reportType = PrintDocumentType.JobOrder;
					break;
				case 2:
					_reportType = PrintDocumentType.JobQC;
					break;
				case 3:
					_reportType = PrintDocumentType.JobSummary;
					break;
			}

			Views.CastingView.CastingReportView _crv = new CastingReportView();
			_crv.JobNumber = JobNo;
			_crv.PrintWhat = _reportType;
			_crv.WindowState = FormWindowState.Maximized;
			_crv.MdiParent = this.ParentForm;
			_crv.Show();

			// end Test

		} // end PrintJobOrder

		private void PrintOrders()
		{
			this.PrintJobOrder(_selectedPrintForm, _selectedJobId, _selectedJobStatus, _selectedCustomerCode, _selectedJobCategory);

		} // end PrinitOrder

		private void UpdateJobOrderInfos()
		{
			int _resultUpdate = 0;

			// update jobinfos for FISCYEAR and FISCPERIOD
			_resultUpdate = new Models.CastingModel.JobDAL().UpdateYearPeriodForJobInfos();

			// update status
			this.tslbUpdateJobInfos.Text = string.Format("JobInfos({0})", _resultUpdate);

			// update JobOrders for status of finishQty
			_resultUpdate = new  Models.CastingModel.JobDAL().UpdateJobOrdersStatusByFinishQty();

			this.tslbUpdateJobOrders.Text = string.Format("JobOrders({0})", _resultUpdate);

		} // end UpdateYPJobInfos

		private void CreateFindList()
		{
			this.tscbxFind.ComboBox.DataSource = OMControls.OMDataUtils.GetValueList<FindList>();
			this.tscbxFind.ComboBox.DisplayMember = "Value";
			this.tscbxFind.ComboBox.ValueMember = "Key";

		} // end 


		#endregion


		public CastingJobs()
		{
			InitializeComponent();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CastingJobs_Load(object sender, EventArgs e)
		{
			// formatting DataGridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			OMControls.OMUtils.SettingDataGridView(ref this.dgvActiveQty);
			OMControls.OMUtils.SettingDataGridView(ref this.dgvJobCat);

			// set initial variable value
			_selectedItemId = 0;
			_selectedJobCategory = string.Empty;
			_selectedJobId = 0;
			_selectedJobStatus = 1;


			// display active summary for all job-category
			this.GetActiveSummaryJob();

			// Create menu-items
			this.CreateFindList();
			this.CreateJobCategoryMenus();
			this.CreatePrintCastingJobs();

			// initial status value
			this.rdoActive.Checked = true;

			this.UpdateListStatus();
			this.UpdateUI();
		}

		private void rdo_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton _rdo = sender as RadioButton;
			if (_rdo.Checked == true)
			{
				// get the status flag
				_selectedJobStatus = Convert.ToInt32(_rdo.Tag.ToString());

				// display selected value on group-box
				this.gbStatus.Text = string.Format("Status : [{0}]", _selectedJobStatus);

				//// loading job-orders as selected job category and status
				//this.GetJobOrderList(_selectedJobCategory, _selectedJobStatus);
			}
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_maxRows == this.dgv.Rows.Count)
			{
				_selectedJobId = Convert.ToInt32(this.dgv["JOBNO", e.RowIndex].Value);
				_selectedItemPrefix = this.dgv["CAT", e.RowIndex].Value.ToString();
				_selectedItemId = Convert.ToInt32(this.dgv["ITEMID", e.RowIndex].Value);
				_selectedCustomerId = Convert.ToInt32(this.dgv["CUSTOMERID", e.RowIndex].Value);
				_selectedCustomerCode = this.dgv["CUSTOMERCODE", e.RowIndex].Value.ToString();
				_selectedCustomerName = this.dgv["CUSTOMERNAME", e.RowIndex].Value.ToString();

				string _itemNo = this.dgv["ITEMNO", e.RowIndex].Value.ToString();

				//tslbFile.Text = 

				// display picture
				this.pic.Image = Models.CastingModel.PriceListDAL.GetPriceListItemPictureByItemNo(_itemNo);

				// update selected-status
				this.UpdateListStatus();

				// update-UI
				this.UpdateUI();
			}

		}

		private void tsbtnFindCustomer_Click(object sender, EventArgs e)
		{
			// search by string input for customer name
			(this.dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(
				"[{0}] LIKE '%{1}%'", "CUSTOMERNAME", OMControls.OMDataUtils.GetFilter<string>("กำหนดชื่อลูกค้าที่ต้องการค้นหา"));

			this.UpdateListStatus();
		}

		private void tsbtnNewJob_Click(object sender, EventArgs e)
		{
			_selectedJobId = 0;
			this.AddEditJobOrder(0);
		}

		private void tsbtnEditJob_Click(object sender, EventArgs e)
		{
			this.AddEditJobOrder(_selectedJobId);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.GetJobOrderList(_selectedJobCategory, _selectedJobStatus);
		}

		private void btnJobInfo_Click(object sender, EventArgs e)
		{
			using (Views.CastingView.CastingJobFG _fg = new CastingJobFG())
			{
				_fg.JobId = _selectedJobId;
				_fg.ItemId = _selectedItemId;;
				_fg.ItemPrefix = _selectedItemPrefix;
				_fg.CustomerId = _selectedCustomerId;
				_fg.CustomerCode = _selectedCustomerCode;
				_fg.CustomerName = _selectedCustomerName;
				_fg.ItemImage = this.pic.Image;

				if (_fg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					// update -- joblist
				}
			}
		}

		private void btnJobProgress_Click(object sender, EventArgs e)
		{
			using (Views.CastingView.JobOrderProgressStatus _jud = new JobOrderProgressStatus())
			{
				_jud.StartPosition = FormStartPosition.CenterScreen;
				_jud.ShowDialog(this);
			}
		}

		private void tscbxPrintCastingForm_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tscbxPrintCastingForm.ComboBox.SelectedValue.GetType() == typeof(System.Int32))
			{
				_selectedPrintForm = Convert.ToInt32(this.tscbxPrintCastingForm.ComboBox.SelectedValue);
			}
			if (_selectedPrintForm > 0)
			{
				this.PrintJobOrder(_selectedPrintForm, _selectedJobId, _selectedJobStatus, _selectedCustomerCode, _selectedJobCategory);
			}
		}

		private void tscbxFind_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tscbxFind.ComboBox.SelectedValue.GetType() == typeof(System.Int32))
			{
				_findOption = (FindList)Enum.ToObject(typeof(FindList), Convert.ToInt32(this.tscbxFind.ComboBox.SelectedValue));

				(this.dgv.DataSource as DataTable).DefaultView.RowFilter = string.Empty;

				switch (_findOption)
				{
					case FindList.ชื่อลูกค้า:
						// search by string input for customer name
						(this.dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(
							"[{0}] LIKE '%{1}%'", "CUSTOMERNAME", OMControls.OMDataUtils.GetFilter<string>("กำหนดชื่อลูกค้าที่ต้องการค้นหา"));

						break;
					case FindList.หมายเลขใบงาน:
						// search by string input for customer name
						(this.dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(
							"[{0}] LIKE '%{1}%'", "JOBNO", OMControls.OMDataUtils.GetFilter<string>("กำหนดหมายเลขใบงานที่ต้องการค้นหา"));

						break;
				}
				this.UpdateListStatus();
			}
		}

		private void dgvJobCat_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedJobCategory = this.dgvJobCat["KEY", e.RowIndex].Value.ToString();

			// update menu
			this.lbJobCat.Text = string.Format("ประเภทงานหล่อ ({0})", _selectedJobCategory);

			// update-UI
			this.UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.tsbtnEditJob.PerformClick();
		}

		private void btnLoadJobs_Click(object sender, EventArgs e)
		{
			// loading data
			this.GetJobOrderList(_selectedJobCategory, _selectedJobStatus);
		}

		private void dgvJobCat_DoubleClick(object sender, EventArgs e)
		{
			this.btnLoadJobs.PerformClick();
		}

		private void tscbxPrintCastingForm_Click(object sender, EventArgs e)
		{

		}

		private void tslbPrintJobOrder_Click(object sender, EventArgs e)
		{

		}
	}
}
