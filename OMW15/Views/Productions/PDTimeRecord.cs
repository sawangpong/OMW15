﻿using OMControls;
using OMW15.Models.ProductionModel;
using OMW15.Models.ToolModel;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class PDTimeRecord : Form
	{
		#region Singleton
		private static PDTimeRecord instance;
		public static PDTimeRecord GetInstance
		{
			get
			{
				if (instance == null || instance.IsDisposed)
				{
					instance = new PDTimeRecord();
				}

				return instance;
			}
		}
		#endregion

		#region class field

		private string selectedItemNo = "";
		private string selectedItemName = "";
		private string selectedWorkerCode = "";
		private string selectedWorkerName = "";
		private string selectedRequestNo = "";
		private int selectedWorkYear = DateTime.Today.Year;
		private int _previousSelectedWorkYear = 0;
		private int selectedWorkMonth = DateTime.Today.Month;
		private int selectedTimeRecordId = 0;

		private bool _loadingYearData = false;
		private bool _loadingMonthData = false;
		private bool _firstView = false;

		private DataTable _dtworkProperties;

		#endregion

		#region class property
		public string Empcode { get; set; }
		public DateTime MissingDate { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnFindData.Enabled = (!String.IsNullOrEmpty(selectedWorkerCode)
											&& (selectedWorkYear > 0)
											&& (selectedWorkMonth > 0));
			btnAdd.Enabled = !String.IsNullOrEmpty(lbCode.Text);
			btnEdit.Enabled = (selectedTimeRecordId > 0);
			btnDelete.Enabled = btnEdit.Enabled;
		}

		private void GetWorker()
		{
			DataTable dt = new SelectOptions().GetWorkerList(omglobal.DepartmentList, omglobal.EmployeeActiveStatus);
			cbxWorker.DataSource = dt;
			cbxWorker.DisplayMember = "VALUE";
			cbxWorker.ValueMember = "KEY";
		} // end GetWorker

		private void GetWorkYear(string workerCode)
		{
			if (_loadingYearData)
			{
				_dtworkProperties = new ProductionDAL().GetYearForTimeRecord(workerCode);

				var _dt = (from yr in _dtworkProperties.AsEnumerable()
							  select new
							  {
								  jobyear = yr.Field<int>("JOBYEAR")
							  }).Distinct().ToDataTable();

				cbxYear.DataSource = _dt;
				cbxYear.DisplayMember = "JOBYEAR";
				cbxYear.ValueMember = "JOBYEAR";

				_loadingYearData = false;
			}
		}

		private void YearValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (e == null)
					return;

				selectedWorkYear = Convert.ToInt32(cbxYear.SelectedValue);
				lbWorkYear.Text = $"{selectedWorkYear}";
				GetWorkMonth(selectedWorkerCode, selectedWorkYear);
			}
			catch
			{
			}

			UpdateUI();
		}

		private void GetWorkMonth(string workerCode, int jobYear)
		{
			if (_loadingMonthData)
			{
				var _dtm = (from mm in _dtworkProperties.AsEnumerable()
								where mm.Field<int>("JOBYEAR") == jobYear
								select new
								{
									jobmonth = mm.Field<int>("JOBMONTH"),
									jobmonthname = Convert.ToInt32(mm.Field<int>("JOBMONTH")).GetThaiMonthName()
								}).Distinct().OrderByDescending(o => o.jobmonth).ToDataTable();

				if (_dtm != null)
				{
					cbxMonth.DataSource = _dtm;
					cbxMonth.DisplayMember = "JOBMONTHNAME";
					cbxMonth.ValueMember = "JOBMONTH";
					cbxMonth.SelectedIndex = 0;
				}

				_loadingMonthData = false;
			}
		}

		private void GetTimeRecords(string workerCode, int workYear, int workMonth)
		{
			// re-set the selected row
			selectedTimeRecordId = 0;

			dgv.SuspendLayout();
			dgv.DataSource = new ProductionDAL().GetProductionTimeItemByWorker(workerCode, workYear, workMonth);

			if (_firstView)
			{
				FormattingDataGrid();
			}

			dgv.ResumeLayout();

			// display record found
			lbRecordCount.Text = $"found : {dgv.Rows.Count} row(s)";

			UpdateUI();
		}

		private void FormattingDataGrid()
		{
			// hide columns
			dgv.Columns["RECORDID"].Visible = false;
			dgv.Columns["PROCESSID"].Visible = false;
			dgv.Columns["WORKERID"].Visible = false;
			dgv.Columns["WORKERNAME"].Visible = false;

			// format columns
			//dgv.Columns["WORKDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";
			//dgv.Columns["FROMTIME"].DefaultCellStyle.Format = "HH:mm";
			//dgv.Columns["TOTIME"].DefaultCellStyle.Format = "HH:mm";
			//dgv.Columns["OTFROM"].DefaultCellStyle.Format = "HH:mm";
			//dgv.Columns["OTEND"].DefaultCellStyle.Format = "HH:mm";
			dgv.Columns["INWORKPROCESSQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["GOODQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["BADQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["TOTALQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["TOTALTIME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			// fotmat headerText
			dgv.Columns["WORKDATE"].HeaderText = "วันที";
			dgv.Columns["PRODUCTIONJOB"].HeaderText = "เลขที่ใบสั่งผลิต";
			dgv.Columns["PROCESSNAME"].HeaderText = "ขั้นตอนการผลิต";
			dgv.Columns["DRAWINGNO"].HeaderText = "เลขที่แบบ";
			dgv.Columns["ITEMNO"].HeaderText = "รหัสชิ้นงาน";
			dgv.Columns["ITEMNAME"].HeaderText = "ชื่อชิ้นงาน";
			dgv.Columns["FROMTIME"].HeaderText = "เวลาเริ่ม";
			dgv.Columns["TOTIME"].HeaderText = "เวลาเลิก";
			dgv.Columns["OTFROM"].HeaderText = "เริ่ม OT";
			dgv.Columns["OTEND"].HeaderText = "เลิก OT";
			dgv.Columns["TOTALQTY"].HeaderText = "ชิ้นงานรวม";
			dgv.Columns["TOTALTIME"].HeaderText = "เวลารวม ช.ม.";
			dgv.Columns["INWORKPROCESSQTY"].HeaderText = "ชิ้นงานระหว่างทำ";
			dgv.Columns["GOODQTY"].HeaderText = "ชิ้นงานดี";
			dgv.Columns["BADQTY"].HeaderText = "ชิ้นงานเสีย";

			_firstView = false;
		}

		private void TimeRecordInfo(int recordId, string requestNo, string workerCode, string workerName, string itemNo, string itemName)
		{
			using (PRDHOURSINFO timeRecord = new PRDHOURSINFO(recordId, requestNo, itemNo, itemName, workerCode, workerName))
			{
				timeRecord.ShowDialog();
			}

			//ReloadTimeRecord();
			btnFindData.PerformClick();

		}

		private int DeleteTimeRecordRow(int rowId)
		{
			int _result = 0;
			if (MessageBox.Show("ต้องการลบรายการที่เลือกใช่ไหม ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_result = new ProductionDAL().RemoveTimeRecord(rowId);
			}
			return _result;
		}

		#endregion

		public PDTimeRecord()
		{
			InitializeComponent();
			this.WindowState = FormWindowState.Maximized;

			OMUtils.SettingDataGridView(ref dgv);

			pnlChart.Width = pnlData.Width;

			selectedWorkerCode = "";
			selectedWorkerName = "";
			lbCode.Text = "";

			_firstView = true;
			chkShowTimeRecord.Checked = false;
		}

		private void PDTimeRecord_Load(object sender, EventArgs e)
		{
			UpdateUI();

			lbWorkYear.Text = $"{selectedWorkYear}";
			lbWorkMonth.Text = $"{selectedWorkMonth}";
			this.GetWorker();

			if (String.IsNullOrEmpty(this.Empcode))
			{
				cbxWorker.SelectedIndex = 0;
			}
			else
			{
				selectedWorkerCode = this.Empcode;
				selectedWorkYear = this.MissingDate.Year;
				selectedWorkMonth = this.MissingDate.Month;

				cbxWorker.SelectedValue = this.selectedWorkerCode;

				if(cbxYear.DataSource == null) GetWorkYear(selectedWorkerCode);
				cbxYear.SelectedValue = this.selectedWorkYear;

				if(cbxMonth.DataSource == null )	GetWorkMonth(selectedWorkerName, selectedWorkYear);
				cbxMonth.SelectedValue = this.selectedWorkMonth;

				GetTimeRecords(selectedWorkerCode, selectedWorkYear, selectedWorkMonth);
			}
		}

		private void cbxYear_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (e == null)
					return;

				selectedWorkYear = Convert.ToInt32(cbxYear.SelectedValue);
				lbWorkYear.Text = $"{selectedWorkYear}";

				if (selectedWorkYear != _previousSelectedWorkYear)
				{
					_loadingMonthData = true;
					GetWorkMonth(selectedWorkerCode, selectedWorkYear);
					_previousSelectedWorkYear = selectedWorkYear;
				}
			}
			catch
			{
			}

			UpdateUI();
		}

		private void cbxMonth_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (e == null)
					return;

				selectedWorkMonth = Convert.ToInt32(cbxMonth.SelectedValue);
				lbWorkMonth.Text = $"{selectedWorkMonth}";
			}
			catch
			{ }

			UpdateUI();
		}

		private void btnFindData_Click(object sender, EventArgs e)
		{
			// Get data for DataGridView
			GetTimeRecords(selectedWorkerCode, selectedWorkYear, selectedWorkMonth);

			// Data for Graph
			if (chkShowTimeRecord.Checked)
			{
				workerTimeRecord1.GetTimeRecordData(selectedWorkerCode, selectedWorkYear, selectedWorkMonth);
			}
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			selectedTimeRecordId = Convert.ToInt32(dgv["RECORDID", e.RowIndex].Value);
			selectedRequestNo = dgv["ProductionJob", e.RowIndex].Value.ToString();
			selectedItemNo = dgv["ItemNo", e.RowIndex].Value.ToString();
			selectedItemName = dgv["ItemName", e.RowIndex].Value.ToString();
			lbRecordSelected.Text = $"id : {selectedTimeRecordId}";
			UpdateUI();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			selectedTimeRecordId = 0;
			selectedRequestNo = "";
			selectedItemNo = "";
			selectedItemName = "";
			TimeRecordInfo(selectedTimeRecordId, selectedRequestNo, selectedWorkerCode, selectedWorkerName, selectedItemNo, selectedItemName);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			TimeRecordInfo(selectedTimeRecordId, selectedRequestNo, selectedWorkerCode, selectedWorkerName, selectedItemNo, selectedItemName);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnEdit.PerformClick();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void PDTimeRecord_Resize(object sender, EventArgs e)
		{
			pnlChart.Width = pnlData.Width;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			// delete selected record
			DeleteTimeRecordRow(selectedTimeRecordId);

			// re-load data
			btnFindData.PerformClick();
		}

		private void cbxWorker_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				selectedWorkerCode = cbxWorker.SelectedValue.ToString();
				selectedWorkerName = cbxWorker.Text;

				_previousSelectedWorkYear = 0;
				_loadingYearData = true;
				GetWorkYear(selectedWorkerCode);
			}
			catch
			{
				_loadingYearData = false;
				selectedWorkerCode = "";
				selectedWorkerName = "";
			}

			// display selected value
			lbCode.Text = $"{selectedWorkerCode}";

			UpdateUI();
		}

		private void chkShowTimeRecord_CheckedChanged(object sender, EventArgs e)
		{
			pnlList.Visible = chkShowTimeRecord.Checked;
			pnlDetail.Dock = pnlList.Visible == true ? DockStyle.Top : DockStyle.Fill;

			if (chkShowTimeRecord.Checked)
			{
				workerTimeRecord1.GetTimeRecordData(selectedWorkerCode, selectedWorkYear, selectedWorkMonth);
			}
		}
	}
}
