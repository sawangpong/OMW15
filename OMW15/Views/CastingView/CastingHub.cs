using OMControls;
using OMW15.Casting.CastingView;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingHub : Form
	{
		#region Singleton

		public static CastingHub _instance;
		public static CastingHub GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed) _instance = new CastingHub();
				return _instance;
			}
		}
		#endregion

		#region calss field member
		//private string _selectedCustomerCode = String.Empty;

		private OMShareJobEnums.FindList _findOption = OMShareJobEnums.FindList.None;
		private ActionMode jobInfoMode = ActionMode.None;
		private bool _isEditable = true;
		private string _filterText = string.Empty;
		private string _selectedCustomerName = string.Empty;
		private string _selectedJobCategory = "R";
		private string _selectedItemPrefix = string.Empty;
		private string _selectedGroupCode = string.Empty;
		private int _selectedCustomerId = 0;
		private int _selectedJobStatus = (int)OMShareJobEnums.JobStatusEnumTH.เริ่มผลิต;
		private int _selectedJobId = 0;
		private int _selectedJobInfoItemId = 0;
		private int _selectedItemId = 0;
		private int _priceItemId = 0;
		private int _maxRows = 0;
		private int _selectedYear = DateTime.Today.Year;
		private int _selectedMonth = DateTime.Today.Month;
		private int _selectedMaterialId = 0;
		private decimal _requiredQtyForDelete = 0.00m;
		#endregion

		#region class property
		public string SelectedCustomerCode { get; set; } = string.Empty;

		public int PriceItemId
		{
			set
			{
				_priceItemId = value;
			}
		}


		#endregion

		#region class helper

		private void updateUI()
		{
			// Main-UI
			this.pnlMonth.Visible = _selectedJobStatus == (int)OMShareJobEnums.JobStatusEnumTH.ผลิตเสร็จ;
			this.pnlYear.Visible = this.pnlMonth.Visible;
			this.btnShowJobs.Enabled = !string.IsNullOrEmpty(_selectedJobCategory);
			mnuSearch.Enabled = (dgv.Rows.Count > 0);
			mnuEditJob.Enabled = (_selectedJobId > 0);
			mnuPrintJob.Enabled = mnuEditJob.Enabled;
			mnuJobProgress.Enabled = mnuEditJob.Enabled;

			// JOB-INFO
			tsmnuAdd.Enabled = (_selectedJobId > 0);
			if (string.IsNullOrEmpty(_selectedGroupCode))
			{
				tsbtnEdit.Enabled = tsmnuAdd.Enabled;
				tsbtnDelete.Enabled = tsmnuAdd.Enabled;
				tsbtnRefresh.Enabled = tsmnuAdd.Enabled;
			}
			else
			{
				tsbtnEdit.Enabled = (_selectedJobInfoItemId > 0);
				tsbtnDelete.Enabled = tsbtnEdit.Enabled;
				tsbtnRefresh.Enabled = (dgv.Rows.Count > 0);
			}

		} // end UpdateUI

		private void getJobCat()
		{
			cbxJobCat.DataSource = new SelectOptions().GetItemCodeData();
			cbxJobCat.DisplayMember = "VALUE";
			cbxJobCat.ValueMember = "KEY";
			cbxJobCat.SelectedValue = _selectedJobCategory;
			lbJobCat.Text = $"ประเภทงานหล่อ:[{_selectedJobCategory}] :";
		}

		private void getJobStatus()
		{
			cbxJobStatus.DataSource = OMDataUtils.GetValueList<OMShareJobEnums.JobStatusEnumTH>();
			cbxJobStatus.DisplayMember = "Value";
			cbxJobStatus.ValueMember = "Key";

			_selectedJobStatus =
				(int)Enum.Parse(typeof(OMShareJobEnums.JobStatusEnumTH), OMShareJobEnums.JobStatusEnumTH.เริ่มผลิต.ToString());
		} // end GetJobStatus

		private void getYearList()
		{
			cbxYear.DataSource = DataTableTools.GetGeneralYearList();
			cbxYear.DisplayMember = "Y";
			cbxYear.ValueMember = "Y";
			cbxYear.SelectedValue = _selectedYear;
		} // end GetYearList

		private void getMonthList()
		{
			cbxMonth.DataSource = EnumWithName<MonthList>.ParseEnum();
			cbxMonth.DisplayMember = "Name";
			cbxMonth.ValueMember = "Value";
			cbxMonth.SelectedValue = _selectedMonth;
		}

		private void updateJobOrderInfos()
		{
			var _resultUpdate = 0;

			// update jobinfos for FISCYEAR and FISCPERIOD
			_resultUpdate = new JobDAL().UpdateYearPeriodForJobInfos();

			// update JobOrders for status of finishQty
			_resultUpdate = new JobDAL().UpdateJobOrdersStatusByFinishQty();

		} // end UpdateYPJobInfos

		private void mnuFindJob_Click(object sender, EventArgs e)
		{
			var mnu = sender as ToolStripMenuItem;
			_findOption = mnu.Tag.ToString() == "BY_JOB"
				? OMShareJobEnums.FindList.หมายเลขใบงาน
				: OMShareJobEnums.FindList.ชื่อลูกค้า;

			switch (_findOption)
			{
				case OMShareJobEnums.FindList.ชื่อลูกค้า:
					_filterText = OMDataUtils.GetFilter<string>("กำหนดชื่อลูกค้าที่ต้องการค้นหา");
					break;

				case OMShareJobEnums.FindList.หมายเลขใบงาน:
					_filterText = OMDataUtils.GetFilter<string>("กำหนดหมายเลขใบงานที่ต้องการค้นหา");
					break;
			}

			getJobOrderListAsync(_selectedJobCategory, _selectedJobStatus, _selectedYear, _selectedMonth, _filterText, _findOption);

		}


		private async void getJobOrderListAsync(string JobCategory, int JobStatus, int JobYear, int JobMonth, string FindText,
	 OMShareJobEnums.FindList FindOption)
		{
			var _dal = new JobDAL();
			var _dt = await _dal.GetJobOrderListAsync(FindOption, JobCategory, JobStatus, JobYear, JobMonth, FindText, omglobal.SysConnectionString);

			bool showColumnsForCloseStatus = (JobStatus == (int)OMShareJobEnums.JobStatusEnumEN.Closed ? true : false);

			dgv.SuspendLayout();

			if (!string.IsNullOrEmpty(JobCategory) && JobStatus > 0)
			{
				_maxRows = _dt.Rows.Count;
				dgv.DataSource = _dt;

				// formatting DataGridView
				// -- hide column
				dgv.Columns["STATUS"].Visible = false;
				dgv.Columns["PRIORITY"].Visible = false;
				dgv.Columns["ITEMID"].Visible = false;
				dgv.Columns["CUSTOMERCODE"].Visible = false;
				dgv.Columns["CUSTOMERID"].Visible = false;
				dgv.Columns["CUSTPO"].Visible = false;
				dgv.Columns["MATERIALTYPE"].Visible = false;
				dgv.Columns["RD"].Visible = !showColumnsForCloseStatus;
				dgv.Columns["FINISH"].Visible = showColumnsForCloseStatus;
				dgv.Columns["REMARK"].Visible = false;

				// formating style
				dgv.Columns["THKEYNAME"].HeaderText = "MATERIAL";
				dgv.Columns["PRIORITYCLASS"].HeaderText = "PRIORITY";
				dgv.Columns["JOBSTATUSNAME"].HeaderText = "STATUS";
				dgv.Columns["ORDERDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgv.Columns["START"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgv.Columns["DUE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgv.Columns["FINISH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgv.Columns["CAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgv.Columns["UNIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgv.Columns["RD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgv.Columns["RD"].HeaderText = "Late";
				dgv.Columns["FINISHQTY"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				dgv.Columns["REMAIN"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				dgv.Columns["QTY"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			}
			else
			{
				dgv.DataSource = null;
			}

			dgv.ResumeLayout();

			this.getJobs(_dt, JobStatus, JobCategory);
		}

		//private void getJobOrderList(string JobCategory, int JobStatus, int JobYear, int JobMonth, string FindText,
		//OMShareJobEnums.FindList FindOption)
		//{
		//	var _dal = new JobDAL();
		//	var _dt = _dal.GetJobOrderList(JobCategory, JobStatus, JobYear, JobMonth, FindText, FindOption);
		//	this.getJobs(_dt,JobStatus,JobCategory);
		//}

		private void getJobs(DataTable dt, int JobStatus, string JobCategory)
		{
			#region UN-USED-CODE
			//bool showColumnsForCloseStatus = (JobStatus == (int)OMShareJobEnums.JobStatusEnumEN.Closed ? true : false);
			//dgv.SuspendLayout();
			//if (!string.IsNullOrEmpty(JobCategory) && JobStatus > 0)
			//{
			//	_maxRows = dt.Rows.Count;
			//	dgv.DataSource = dt;
			//	// formatting DataGridView
			//	// -- hide column
			//	dgv.Columns["STATUS"].Visible = false;
			//	dgv.Columns["PRIORITY"].Visible = false;
			//	dgv.Columns["ITEMID"].Visible = false;
			//	dgv.Columns["CUSTOMERCODE"].Visible = false;
			//	dgv.Columns["CUSTOMERID"].Visible = false;
			//	dgv.Columns["MATERIALTYPE"].Visible = false;
			//	dgv.Columns["RD"].Visible = !showColumnsForCloseStatus;
			//	dgv.Columns["FINISH"].Visible = showColumnsForCloseStatus;
			//	dgv.Columns["REMARK"].Visible = false;
			//	// formating style
			//	dgv.Columns["THKEYNAME"].HeaderText = "MATERIAL";
			//	dgv.Columns["PRIORITYCLASS"].HeaderText = "PRIORITY";
			//	dgv.Columns["JOBSTATUSNAME"].HeaderText = "STATUS";
			//	dgv.Columns["ORDERDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//	dgv.Columns["START"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//	dgv.Columns["DUE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//	dgv.Columns["FINISH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//	dgv.Columns["CAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//	dgv.Columns["UNIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//	dgv.Columns["RD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//	dgv.Columns["RD"].HeaderText = "Late";
			//	dgv.Columns["FINISHQTY"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			//	dgv.Columns["REMAIN"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			//	dgv.Columns["QTY"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			//}
			//else
			//{
			//	dgv.DataSource = null;
			//}
			//dgv.ResumeLayout(); 
			#endregion

			// refrehing active qty
			getActiveSummaryJob();

			// update - Job Priority
			getJobPrioritySummary();

			// update UI
			updateUI();

			// update - Active Order
			this.stCount.Text = $"found : {this.dgv.Rows.Count}";

		} // end GetJobOrderList

		private void settingJobInfoMenuState(string prefix)
		{
			this.tsmnuAddBlock.Enabled = (prefix == "L" || prefix == "M");
			this.tsmnuAddPrintResin.Enabled = (prefix == "P");
			this.tsmnuAddInjection.Enabled = (prefix == "R");
			this.tsmnuAddFinishing.Enabled = !this.tsmnuAddBlock.Enabled;
			this.tsmnuAddTree.Enabled = this.tsmnuAddFinishing.Enabled;
			this.tsmnuAddFG.Enabled = this.tsmnuAddTree.Enabled;
		}

		private async void getJobPrioritySummary()
		{
			var _dal = new JobDAL();
			var _dt = await _dal.getJobPrioritySummaryAsync();
			_dt.DefaultView.Sort = "Q";

			this.dgvPriority.SuspendLayout();
			this.dgvPriority.DataSource = _dt;
			this.dgvPriority.Columns["Q"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.dgvPriority.Columns["BQ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dgvPriority.Columns["BQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
			this.dgvPriority.Columns["BQ"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			this.dgvPriority.Columns["R"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.dgvPriority.Columns["R"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
			this.dgvPriority.Columns["R"].DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.PercentCellStyle();
			this.dgvPriority.ColumnHeadersVisible = false;
			this.dgvPriority.ResumeLayout();
		}

		private async void getActiveSummaryJob()
		{
			var _dal = new JobDAL();
			var _dt = await _dal.GetSummaryJobActiveAsync();
			_dt.DefaultView.Sort = "Q";

			dgvActiveQty.SuspendLayout();

			dgvActiveQty.DataSource = _dt;
			dgvActiveQty.Columns["Q"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			dgvActiveQty.Columns["BQ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvActiveQty.Columns["BQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
			dgvActiveQty.Columns["BQ"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgvActiveQty.ColumnHeadersVisible = false;
			dgvActiveQty.ResumeLayout();

		} // end GetActiveSummaryJob


		private async void getJobInfo(int jobNo)
		{
			var _dal = new JobDAL();

			this.dgvJobDoing.SuspendLayout();
			this.dgvJobDoing.DataSource = await _dal.getJobDoingAsync(jobNo);
			this.dgvJobDoing.ResumeLayout();

		}

		private async void getFGbyJob(int jobNo)
		{
			var _dal = new JobDAL();
			this.dgvFG.SuspendLayout();
			this.dgvFG.DataSource = await _dal.getFGByJobNoAsync(jobNo);
			this.dgvFG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvFG.Columns["STATUS"].HeaderText = "สถานะ";
			this.dgvFG.Columns["STOCK"].HeaderText = "จำนวนนำส่งสต็อก";
			this.dgvFG.Columns["DELIVERY"].HeaderText = "จำนวนที่ส่ง";
			this.dgvFG.Columns["ONHAND"].HeaderText = "จำนวนคงค้าง";
			this.dgvFG.Columns["STOCK"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			this.dgvFG.Columns["DELIVERY"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			this.dgvFG.Columns["ONHAND"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			this.dgvFG.ResumeLayout();
		}

		private async void getSOItemByJob(int jobNo)
		{
			var _dal = new JobDAL();
			this.dgvSO.SuspendLayout();
			this.dgvSO.DataSource = await _dal.getJobItemDeliveryAsync(jobNo);
			this.dgvSO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			this.dgvSO.Columns["SONO"].HeaderText = "เลขที่ใบส่งของ";
			this.dgvSO.Columns["DELIVERYDATE"].HeaderText = "วันที่ส่ง";
			this.dgvSO.Columns["DELIVERYDATE"].DefaultCellStyle.Format = "####-##-##";
			this.dgvSO.Columns["ITEM"].HeaderText = "รหัสสินค้า";
			this.dgvSO.Columns["ITEMNAME"].HeaderText = "ชื่อสินค้า";
			this.dgvSO.Columns["UNIT"].HeaderText = "หน่วย";
			this.dgvSO.Columns["DELIVEREDQTY"].HeaderText = "จำนวนที่ส่ง";
			this.dgvSO.Columns["TOTALWEIGHT"].HeaderText = "น.น.ที่ส่ง";
			this.dgvSO.Columns["DELIVEREDQTY"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			this.dgvSO.Columns["TOTALWEIGHT"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			this.dgvSO.ResumeLayout();

			// update menu
			this.tsbtnEdit.Enabled = (this.dgvSO.Rows.Count == 0);
			this.tsbtnDelete.Enabled = (this.tsbtnEdit.Enabled);
			_isEditable = this.tsbtnEdit.Enabled;
		}

		private async void getJobInfoLine(int jobNo)
		{
			var _dal = new JobDAL();
			this.dgvJobInfo.SuspendLayout();
			this.dgvJobInfo.DataSource = await _dal.getJobInfoDetailByJobAsync(jobNo);

			this.dgvJobInfo.Columns["ID"].Visible = false;
			this.dgvJobInfo.Columns["GOODQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgvJobInfo.Columns["BADQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgvJobInfo.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			this.dgvJobInfo.Columns["WORKDATE"].HeaderText = "วันที่";
			this.dgvJobInfo.Columns["WORKDATE"].DefaultCellStyle.Format = "####-##-##";

			this.dgvJobInfo.Columns["WORKER"].HeaderText = "ผุ้ปฏิบัติงาน";

			this.dgvJobInfo.Columns["GOODQTY"].HeaderText = "งานดี";
			this.dgvJobInfo.Columns["BADQTY"].HeaderText = "งานเสีย";
			this.dgvJobInfo.Columns["TOTAL"].HeaderText = "รวม";

			this.dgvJobInfo.ResumeLayout();
		}

		private void addEditJobOrder(int jobId)
		{
			using (var _jobInfo = new CastingJobInfo())
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
				_jobInfo.ItemImage = this.itemPic.Image;
				_jobInfo.JobId = jobId;
				_jobInfo.StartPosition = FormStartPosition.CenterScreen;
				_jobInfo.ShowDialog(this);
			}

			// re-load job after Add/Edit
			this.mnuRefresh.PerformClick();

		} // end AddEditJobOrder


		private void AddEditJobInfoItem(int jobNo, int jobInfoItemId)
		{
			// in case of want to edit recode must be 
			// looking that record was issue to SaleOrder or not
			// if, the record was issued must be alert to user
			if (jobInfoMode == ActionMode.Add)
			{
				using (var _fgItem = new CastingFGItem())
				{
					_fgItem.JobId = jobNo;
					_fgItem.JobinfoId = 0;
					_fgItem.FGItemId = 0;
					_fgItem.GroupCode = _selectedGroupCode;
					_fgItem.CustomerId = _selectedCustomerId;
					_fgItem.CustomerCode = SelectedCustomerCode;
					_fgItem.ItemId = _selectedItemId;
					_fgItem.ItemPrefix = lbPrefix.Text;
					_fgItem.ItemName = lbItemName.Text;
					_fgItem.MaterialId = _selectedMaterialId;
					_fgItem.MaterialName = this.lbMaterial.Text;
					_fgItem.Unit = this.lbUnit.Text;

					_fgItem.StartPosition = FormStartPosition.CenterParent;
					_fgItem.ShowDialog(this);
				}
			}
			else if (jobInfoMode == ActionMode.Edit)
			{

				_isEditable = ((_selectedGroupCode == "BLOCK" || _selectedGroupCode == "FG" || _selectedGroupCode == "RESIN")
					? (this.dgvSO.Rows.Count == 0 ? true : false)
					: true);

				if (_isEditable)
				{
					using (var _fgItem = new CastingFGItem())
					{
						_fgItem.JobId = jobNo;
						_fgItem.JobinfoId = jobInfoItemId;
						_fgItem.FGItemId = 0;
						_fgItem.GroupCode = _selectedGroupCode;
						_fgItem.CustomerId = _selectedCustomerId;
						_fgItem.CustomerCode = SelectedCustomerCode;
						_fgItem.ItemId = _selectedItemId;
						_fgItem.ItemPrefix = lbPrefix.Text;
						_fgItem.ItemName = lbItemName.Text;
						_fgItem.MaterialId = _selectedMaterialId;
						_fgItem.MaterialName = this.lbMaterial.Text;
						_fgItem.Unit = this.lbUnit.Text;

						_fgItem.StartPosition = FormStartPosition.CenterParent;
						_fgItem.ShowDialog(this);
					}
				}
				else
				{
					MessageBox.Show("รายการที่เลือกไม่สามารถแก้ไขได้! \nเนื่องจากได้นำไปใช้ในรายการส่งสินค้าแล้ว", "Message",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

			}

			// update JobOrder only for group code -> "BLOCK" or "FG"
			//
			if (_selectedGroupCode == "BLOCK" || _selectedGroupCode == "FG" || _selectedGroupCode == "RESIN")
			{
				// update - all pending process for job orders
				if (new JobDAL().UpdateJobOrdersStatusByFinishQty(_selectedJobId, _selectedGroupCode) > 0)
				{
					//Alert.DisplayAlert(" ปรับปรุงข้อมูล",
					//	$" ปรับปรุงข้อมูล ของหมายเลขใบงาน ที่ : {_selectedJobId} เรียบร้อยแล้ว");
				}
			}

			// re-load job order and JobInfo Item List
			this.tsbtnRefresh.PerformClick();

		} // end AddEditJobInfoItem

		#endregion

		public CastingHub()
		{
			InitializeComponent();

			OMUtils.SettingDataGridView(ref this.dgv);
			OMUtils.SettingDataGridView(ref this.dgvPriority);
			OMUtils.SettingDataGridView(ref this.dgvActiveQty);
			OMUtils.SettingDataGridView(ref this.dgvJobDoing);
			OMUtils.SettingDataGridView(ref this.dgvJobInfo);
			OMUtils.SettingDataGridView(ref this.dgvFG);
			OMUtils.SettingDataGridView(ref this.dgvSO);
		}

		private void CastingHub_Load(object sender, EventArgs e)
		{
			CenterToParent();
			getJobCat();
			getJobStatus();
			getYearList();
			getMonthList();
			updateUI();

			// update all status 
			updateJobOrderInfos();

			// update - Active Order
			getActiveSummaryJob();

			// update - Job Priority
			getJobPrioritySummary();
		}

		private void cbxMonth_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_selectedMonth = Convert.ToInt32(cbxMonth.SelectedValue);
			}
			catch
			{
				_selectedMonth = DateTime.Today.Month;
			}
		}

		private void cbxYear_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_selectedYear = Convert.ToInt32(cbxYear.SelectedValue);
			}
			catch
			{
				_selectedYear = DateTime.Today.Year;
			}
		}

		private void cbxJobStatus_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_selectedJobStatus = Convert.ToInt32(cbxJobStatus.SelectedValue);

				if (_selectedJobStatus == (int)OMShareJobEnums.JobStatusEnumTH.ผลิตเสร็จ)
				{
					_selectedMonth = DateTime.Today.Month;
					_selectedYear = DateTime.Today.Year;
				}
			}
			catch
			{
				_selectedJobStatus = 0;
			}

			lbStatus.Text = $"Status [{_selectedJobStatus}] :";

			updateUI();
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

			lbJobCat.Text = $"ประเภทงาน:[{_selectedJobCategory}]";
			updateUI();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			int _rd = 0;

			if (_maxRows == dgv.Rows.Count)
			{
				_rd = Convert.ToInt32(dgv["RD", e.RowIndex].Value);
				_selectedJobId = Convert.ToInt32(dgv["JOBNO", e.RowIndex].Value);
				_selectedItemPrefix = dgv["CAT", e.RowIndex].Value.ToString();
				_selectedItemId = Convert.ToInt32(dgv["ITEMID", e.RowIndex].Value);
				_selectedCustomerId = Convert.ToInt32(dgv["CUSTOMERID", e.RowIndex].Value);
				SelectedCustomerCode = dgv["CUSTOMERCODE", e.RowIndex].Value.ToString();
				_selectedCustomerName = dgv["CUSTOMERNAME", e.RowIndex].Value.ToString();
				_selectedMaterialId = Convert.ToInt32(this.dgv["MATERIALTYPE", e.RowIndex].Value);

				// display picture
				itemPic.Image = new PriceListDAL().GetPriceListItemPictureByItemId(_selectedItemId);


				// display info.
				this.pnlJobStatus.BackColor = (_rd <= 0 ? Color.Red : Color.Green);

				this.lbJobNo.Text = $"Job-No.: {_selectedJobId}";
				this.lbCustomer.Text = $"ลูกค้า : {_selectedCustomerName}";
				this.lbCustOrder.Text = $"PO: {dgv["CUSTPO", e.RowIndex].Value.ToString() }";
				this.lbPrefix.Text = _selectedItemPrefix;
				this.lbItemNo.Text = dgv["ITEMNO", e.RowIndex].Value.ToString();
				this.lbItemName.Text = dgv["ITEMNAME", e.RowIndex].Value.ToString();
				this.lbMaterial.Text = dgv["THKEYNAME", e.RowIndex].Value.ToString();
				this.lbUnit.Text = dgv["UNIT", e.RowIndex].Value.ToString();
				this.lbItemNumber.Text = $"{_selectedItemPrefix}{this.lbItemNo.Text}";
				this.lbOrderQty.Text = $"{dgv["QTY", e.RowIndex].Value:N2}";
				this.lbFinishQty.Text = $"{dgv["FINISHQTY", e.RowIndex].Value:N2}";
				this.lbBackOrderQty.Text = $"{dgv["REMAIN", e.RowIndex].Value:N2}";
				this.lbRemark.Text = $"{dgv["REMARK", e.RowIndex].Value}";

				this.lbProgress.Text =
					$"{(decimal.Parse(dgv["FINISHQTY", e.RowIndex].Value.ToString()) / decimal.Parse(dgv["QTY", e.RowIndex].Value.ToString())):P2}";

				this.lbCastingTemp.Text = $"{dgv["CAST_TEMP", e.RowIndex].Value.ToString()}";
				this.lbFlaskTemp.Text = $"{dgv["FLASK_TEMP", e.RowIndex].Value.ToString()}";

				// update Job-info menu state
				this.settingJobInfoMenuState(_selectedItemPrefix);

				// update selected-status
				this.stJobId.Text = $"Job Id : {_selectedJobId}";

				//updateListStatus();

				// display jobInfo details
				getJobInfoLine(_selectedJobId);

				// display summary for JobInfo
				getJobInfo(_selectedJobId);

				// display stock - FG
				getFGbyJob(_selectedJobId);

				// display delivery item
				getSOItemByJob(_selectedJobId);

				// update-UI
				updateUI();
			}
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (int.Parse(this.dgv["PRIORITY", e.RowIndex].Value.ToString()) == 3)
			{
				e.CellStyle.BackColor = System.Drawing.Color.FromArgb(129, 20, 24);
				e.CellStyle.ForeColor = System.Drawing.Color.White;
			}
			else if (int.Parse(this.dgv["PRIORITY", e.RowIndex].Value.ToString()) == 2)
			{
				e.CellStyle.BackColor = System.Drawing.Color.FromArgb(160, 62, 62);
				e.CellStyle.ForeColor = System.Drawing.Color.White;
			}
			else if (int.Parse(this.dgv["PRIORITY", e.RowIndex].Value.ToString()) == 1)
			{
				e.CellStyle.BackColor = System.Drawing.Color.FromArgb(100, 62, 62);
				e.CellStyle.ForeColor = System.Drawing.Color.White;
			}
			else
			{
				e.CellStyle.BackColor = System.Drawing.Color.FromArgb(12, 133, 117);
				e.CellStyle.ForeColor = System.Drawing.Color.White;
			}
		}

		private void mnuPrint_Click(object sender, EventArgs e)
		{
			var _crv = new CastingReportView();
			_crv.JobNumber = _selectedJobId;
			_crv.PrintWhat = PrintDocumentType.JobOrder;
			_crv.WindowState = FormWindowState.Maximized;
			_crv.MdiParent = ParentForm;
			_crv.Show();
		}

		private void btnShowJobs_Click(object sender, EventArgs e)
		{
			// loading job list

			if (_selectedJobStatus == (int)OMShareJobEnums.JobStatusEnumTH.เริ่มผลิต)
			{
				_selectedMonth = 0;
			}

			// refreshing Order List
			getJobOrderListAsync(_selectedJobCategory, _selectedJobStatus, _selectedYear, _selectedMonth, _filterText = "",
				_findOption = OMShareJobEnums.FindList.None);

			// refreshing active qty order.
			getActiveSummaryJob();

			// refreshing - Job Priority
			getJobPrioritySummary();

		}

		private void mnuEditJob_Click(object sender, EventArgs e)
		{
			addEditJobOrder(_selectedJobId);

		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.mnuEditJob.PerformClick();
		}

		private void tsmnuAdd_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem _mnu = sender as ToolStripMenuItem;
			_selectedGroupCode = _mnu.Tag.ToString();
			_selectedJobInfoItemId = 0;
			jobInfoMode = ActionMode.Add;
			this.AddEditJobInfoItem(_selectedJobId, _selectedJobInfoItemId);

		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			jobInfoMode = ActionMode.Edit;
			this.AddEditJobInfoItem(_selectedJobId, _selectedJobInfoItemId);
		}

		private void dgvJobInfo_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedJobInfoItemId = Convert.ToInt32(this.dgvJobInfo["ID", e.RowIndex].Value);

			_selectedGroupCode = this.dgvJobInfo["CODE", e.RowIndex].Value.ToString();

			if (_selectedGroupCode == "BLOCK" || _selectedGroupCode == "FG" || _selectedGroupCode == "RESIN")
			{
				_requiredQtyForDelete = Convert.ToDecimal(this.dgvJobInfo["GOODQTY", e.RowIndex].Value);
			}
			else
			{
				_requiredQtyForDelete = 0.00m;
			}

			// show selected JobInfoId
			tslbJobInfoId.Text = $"id :: {_selectedJobInfoItemId}";

			this.updateUI();
		}

		private void tsmnuClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			// display jobInfo details
			getJobInfoLine(_selectedJobId);

			// display summary for JobInfo
			getJobInfo(_selectedJobId);

			// display stock - FG
			getFGbyJob(_selectedJobId);

			// display delivery item
			getSOItemByJob(_selectedJobId);

		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			// step through for deleting record from JobInfo and FG-stock
			// 1. Check the Infomation code (FG, WAX etc)
			// 2. if information is not from "FG", delete the record from JobInfos table
			// 3. if information is "FG" or "BLOCK", do the following
			// 4. check the information from FG-Stock is able to delete the record.
			//    by the delivery-qty from the FG-Stock is active (more than zero (0))
			// 5. if, FG-Stock had taken to delivered Alert "CANNOT DELETE RECODE"
			// 6. otherwise, update (-) qty from FG-STOCK
			// 7. delete record from JobInfos table
			//

			// Main delete process
			if (
				MessageBox.Show("ต้องการลบรายการที่เลือก ใช่หรือไม่?", "Delete Record", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				int _result = 0;

				if (_selectedGroupCode == "FG" || _selectedGroupCode == "BLOCK" || _selectedGroupCode == "RESIN")
				{
					// checking Group for delete
					string _fgGroupCode = "";

					switch (_selectedGroupCode)
					{
						case "FG":
							_fgGroupCode = "QC-FG";
							break;

						case "BLOCK":
							_fgGroupCode = "QC-BLOCK";
							break;

						case "RESIN":
							_fgGroupCode = "QC-RESIN";
							break;
					}


					//if (_selectedGroupCode == "FG")
					//{
					//	_fgGroupCode = "QC-FG";
					//}
					//else if (_selectedGroupCode == "BLOCK")
					//{
					//	_fgGroupCode = "QC-BLOCK";
					//}


					// check remaining qty in case of FG-STOCK 
					decimal _remainFGQty = new JobDAL().findRemainFGQty(int.Parse(lbJobNo.Text), _fgGroupCode);


					if (_remainFGQty < _requiredQtyForDelete)
					{
						MessageBox.Show("รายการที่เลือกไม่สามารถลบได้! \nเนื่องจากได้นำไปใช้ในรายการส่งสินค้าแล้ว", "Delete",
							MessageBoxButtons.OK, MessageBoxIcon.Warning);

						return;
					}

					_result = new JobDAL().updateFGStockForDeletionJobInfoRecord(_selectedJobId, _selectedGroupCode, _selectedJobInfoItemId);
				}
				else
				{
					_result = new JobDAL().removeRecordForJobInfo(_selectedJobInfoItemId);

				}

				// Show message after delete complete....
				if (_result > 0)
				{
					MessageBox.Show("ลบรายการที่เลือกเรียบร้อยแล้ว", "Message",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				// display jobInfo details
				getJobInfoLine(_selectedJobId);

				// display summary for JobInfo
				getJobInfo(_selectedJobId);
			}
		}

	}
}
