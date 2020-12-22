using OMControls;
using OMW15.Models.ProductionModel;
using OMW15.Models.ToolModel;
using System;
using System.Data;
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
		private int selectedWorkMonth = DateTime.Today.Month;
		private int selectedTimeRecordId = 0;
	
		#endregion



		#region class helper

		private void UpdateUI()
		{
			btnFindData.Enabled = (!String.IsNullOrEmpty(selectedWorkerCode) && (selectedWorkYear > 0) && (selectedWorkMonth > 0));
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
			cbxYear.DataSource = new ProductionDAL().GetYearForTimeRecord(workerCode);
			cbxYear.DisplayMember = "JOBYEAR";
			cbxYear.ValueMember = "JOBYEAR";
		}

		private void GetWorkMonth(string workerCode, int jobYear)
		{
			cbxMonth.DataSource = new ProductionDAL().GetMonthForTimeRecord(workerCode, jobYear);
			cbxMonth.DisplayMember = "JOBMONTHNAME";
			cbxMonth.ValueMember = "JOBMONTH";
			cbxMonth.SelectedIndex = 0;
		}

		private void GetTimeRecords(string workerCode, int workYear, int workMonth)
		{
			// re-set the selected row
			selectedTimeRecordId = 0;

			dgv.SuspendLayout();
			dgv.DataSource = new ProductionDAL().GetProductionTimeItemByWorker(workerCode, workYear, workMonth);

			// hide columns
			dgv.Columns["RECORDID"].Visible = false;
			dgv.Columns["PROCESSID"].Visible = false;
			dgv.Columns["WORKERID"].Visible = false;
			dgv.Columns["WORKERNAME"].Visible = false;

			// format columns
			dgv.Columns["WORKDATE"].DefaultCellStyle.Format = "dd/MM/yyyy";
			dgv.Columns["FROMTIME"].DefaultCellStyle.Format = "HH:mm";
			dgv.Columns["TOTIME"].DefaultCellStyle.Format = "HH:mm";
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

			dgv.ResumeLayout();

			// display record found
			lbRecordCount.Text = $"found : {dgv.Rows.Count} row(s)";

			UpdateUI();
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

		//private void ReloadTimeRecord()
		//{
		//	GetWorkYear(selectedWorkerCode);
		//}

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

			this.GetWorker();
		}

		private void PDTimeRecord_Load(object sender, EventArgs e)
		{
			UpdateUI();

			lbWorkYear.Text = $"{selectedWorkYear}";
			lbWorkMonth.Text = $"{selectedWorkMonth}";
			cbxWorker.SelectedIndex = 0;
		}

		private void cbxYear_SelectedValueChanged(object sender, EventArgs e)
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
			{

			}

			UpdateUI();
		}

		private void btnFindData_Click(object sender, EventArgs e)
		{
			// Get data for DataGridView
			GetTimeRecords(selectedWorkerCode, selectedWorkYear, selectedWorkMonth);

			// Data for Graph
			workerTimeRecord1.GetTimeRecordData(selectedWorkerCode, selectedWorkYear, selectedWorkMonth);
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

				GetWorkYear(selectedWorkerCode);
			}
			catch
			{
				selectedWorkerCode = "";
				selectedWorkerName = "";
			}

			// display selected value
			lbCode.Text = $"{selectedWorkerCode}";

			UpdateUI();
		}

		private void cbxWorker_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
