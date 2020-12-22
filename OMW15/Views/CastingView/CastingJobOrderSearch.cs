using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class CastingJobOrderSearch : Form
	{
		// CONSTRUCTOR
		public CastingJobOrderSearch()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void rdo_CheckedChanged(object sender, EventArgs e)
		{
			var _rdo = sender as RadioButton;
			_findOption = _rdo.Tag.ToString() == "JOBNO"
				? OMShareJobEnums.FindList.หมายเลขใบงาน
				: OMShareJobEnums.FindList.ชื่อลูกค้า;
		}


		private async void GetJobOrderList(string FindText, OMShareJobEnums.FindList FindOption)
		{
			var _dal = new JobDAL();

			var _dt = await _dal.GetJobOrderListAsync(FindText, _findOption);
			_maxRows = _dt.Count;

			dgv.SuspendLayout();
			dgv.DataSource = _dt;

			// formatting DataGridView
			// -- hide column
			dgv.Columns["STATUS"].Visible = false;
			dgv.Columns["ITEMID"].Visible = false;
			dgv.Columns["CUSTOMERCODE"].Visible = false;
			dgv.Columns["CUSTOMERID"].Visible = false;

			// -- formating style
			dgv.Columns["JOBSTATUSNAME"].HeaderText = "STATUS";
			dgv.Columns["ORDERDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["START"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["DUE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["CAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["UNIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["RD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["REMAIN"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.Columns["QTY"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgv.ResumeLayout();

			// display row count
			lbRowCount.Text = $"Row found : {_maxRows}";

			UpdateUI();
		} // end GetJobData

		private void CastingJobOrderSearch_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			rdoByJobNo.Checked = true;
			UpdateUI();
		}

		private void btnShowData_Click(object sender, EventArgs e)
		{
			dgv.DataSource = null;
			lbRowCount.Text = "Row found : 0";
			switch (_findOption)
			{
				case OMShareJobEnums.FindList.หมายเลขใบงาน:
					_filterText = OMDataUtils.GetFilter<string>("กำหนดหมายเลขใบงานที่ต้องการค้นหา");
					break;

				case OMShareJobEnums.FindList.ชื่อลูกค้า:
					_filterText = OMDataUtils.GetFilter<string>("กำหนดชื่อลูกค้าที่ต้องการค้นหา");
					break;
			}

			GetJobOrderList(_filterText, _findOption);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedJobId = Convert.ToInt32(dgv["JOBNO", e.RowIndex].Value);
			_selectedItemPrefix = dgv["CAT", e.RowIndex].Value.ToString();
			_selectedJobStatus = Convert.ToInt32(dgv["STATUS", e.RowIndex].Value);
			_selectedItemId = Convert.ToInt32(dgv["ITEMID", e.RowIndex].Value);
			_selectedCustomerId = Convert.ToInt32(dgv["CUSTOMERID", e.RowIndex].Value);
			_selectedCustomerCode = dgv["CUSTOMERCODE", e.RowIndex].Value.ToString();
			_selectedCustomerName = dgv["CUSTOMERNAME", e.RowIndex].Value.ToString();

			UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnEdit.PerformClick();
		}

		private void btnJobInfo_Click(object sender, EventArgs e)
		{
			using (var _fg = new CastingJobFG())
			{
				_fg.JobId = _selectedJobId;
				_fg.ItemId = _selectedItemId;
				_fg.ItemPrefix = _selectedItemPrefix;
				_fg.CustomerId = _selectedCustomerId;
				_fg.CustomerCode = _selectedCustomerCode;
				_fg.CustomerName = _selectedCustomerName;
				_fg.ItemImage = new PriceListDAL().GetItemImageFromItemId(_selectedItemId);

				_fg.StartPosition = FormStartPosition.CenterParent;

				if (_fg.ShowDialog(this) == DialogResult.OK)
				{
					// update -- joblist
				}
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (_selectedJobStatus == (int)OMShareCastingEnums.CastingOrderStatus.Active)
			{
				EditJobOrder(_selectedJobId);
			}
		}

		#region class field member

		private OMShareJobEnums.FindList _findOption = OMShareJobEnums.FindList.None;
		private string _filterText = string.Empty;
		private string _selectedCustomerName = string.Empty;
		private string _selectedCustomerCode = string.Empty;
		private string _selectedItemPrefix = string.Empty;
		private int _selectedCustomerId;
		private int _selectedJobStatus = (int)OMShareJobEnums.JobStatusEnumTH.เริ่มผลิต;
		private int _selectedJobId;
		private int _selectedItemId;
		private int _maxRows;
		private int _selectedYear = DateTime.Today.Year;

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnEdit.Enabled = _selectedJobId > 0;
			btnJobInfo.Enabled = _selectedJobId > 0;
		} // end UpdateUI

		private void EditJobOrder(int JobId)
		{
			using (var _jobInfo = new CastingJobInfo())
			{
				_jobInfo.CreateMode = OMShareJobEnums.JobOrderCreatedMode.CreateFromJobOrderList;
				_jobInfo.ItemId = _selectedItemId;
				_jobInfo.ItemCode = string.Empty;
				_jobInfo.ItemName = string.Empty;
				_jobInfo.ItemNo = string.Empty;
				_jobInfo.StyleId = 0;
				_jobInfo.StyleName = string.Empty;
				_jobInfo.Material = string.Empty;
				_jobInfo.MaterialId = 0;
				_jobInfo.ItemImage = null;
				_jobInfo.JobId = JobId;
				_jobInfo.ItemImage = new PriceListDAL().GetItemImageFromItemId(_selectedItemId);
				_jobInfo.StartPosition = FormStartPosition.CenterScreen;
				_jobInfo.ShowDialog(this);
			}
		} // end EditJobOrder

		#endregion
	}
}