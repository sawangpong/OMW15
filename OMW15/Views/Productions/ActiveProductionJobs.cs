using OMControls;
using OMW15.Models.ProductionModel;
using System;
using System.Data;
using System.Windows.Forms;
using static OMW15.Shared.OMShareProduction;

namespace OMW15.Views.Productions
{
	public partial class ActiveProductionJobs : Form
	{
		#region class field
		private int _status = (int)ProductionJobStatus.Active;

		#endregion

		#region class property
		public string ProductionJob { get; set; }
		public int ProductionJobId { get; set; }
		public string ItemNo { get; set; }
		public string ItemName { get; set; }
		public string DrawingNo { get; set; }
		public decimal JobQty { get; set; }
		public string UnitOrder { get; set; }
		public ProductionJobType JobType { get; set; }
		public int Year { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnSelect.Enabled = (this.ProductionJobId > 0);
		}

		private async void GetProductionJob(int status, int year = 0 ,string filter="")
		{
			// clear all contents
			dgv.DataSource = null;

			// start new contents
			dgv.SuspendLayout();

			var _myTask = new ProductionDAL();
			DataTable dt = await _myTask.GetProductionJobsAsync(status, year, filter);

			dgv.DataSource = dt;

			// hide columns
			dgv.Columns["STATUS"].Visible = false;
			dgv.Columns["STATUSNAME"].Visible = false;
			dgv.Columns["PDJOBID"].Visible = false;
			dgv.Columns["ERP_DI"].Visible = false;
			dgv.Columns["CLOSEDATE"].Visible = false;
			dgv.Columns["TOTAL_HOURS"].Visible = false;
			dgv.Columns["WORKHOURUNIT"].Visible = false;

			//switch(status)
			//{
			//	case (int)ProductionJobStatus.Active:
			//		dgv.Columns["ActiveYear"].Visible = false;
			//		break;
			//	case (int)ProductionJobStatus.Closed:
			//		dgv.Columns["ClosedYear"].Visible = false;
			//		break;
			//}

			// formatting Columns
			dgv.Columns["ERP_ORDER"].HeaderText = "เลขที่ใบขอแปร";
			dgv.Columns["ERP_ORDER"].Frozen = true;

			dgv.Columns["JOBTYPE"].HeaderText = "งาน";

			dgv.Columns["OPENDATE"].HeaderText = "วันที่ขอแปร";
			dgv.Columns["STARTDATE"].HeaderText = "วันที่เริ่ม";
			dgv.Columns["DUE"].HeaderText = "กำหนดเสร็จ";

			dgv.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			dgv.Columns["ITEMNAME"].HeaderText = "ชื่อชิ้นงาน";
			dgv.Columns["DRAWINGNO"].HeaderText = "เลขที่แแบบ";
			dgv.Columns["QORDER"].HeaderText = "จำนวนสั่งผลิต";
			dgv.Columns["QORDER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["UNITORDER"].HeaderText = "หน่วยนับ";

			dgv.ResumeLayout();

			lbRows.Text = $"found # {dgv.Rows.Count}";

			this.ProductionJobId = 0;
			UpdateUI();

		}

		#endregion

		// constructor
		public ActiveProductionJobs(int status, int year = 0, string filterText = "")
		{
			InitializeComponent();

			txtFilter.Text = filterText;
			_status = status;

			this.Year = year;

			OMUtils.SettingDataGridView(ref dgv);

			string _statusText = Enum.GetName(typeof(ProductionJobStatus), _status).ToString();

			lbTitle.Text = _status == (int)ProductionJobStatus.Active
									? $"รายจะแสดงเฉพาะงานที่ยังไม่เสร็จแล้วเท่านั้น ({_statusText} - {this.Year})"
									: $"รายจะแสดงเฉพาะงานที่เสร็จแล้วเท่านั้น ({_statusText} - {this.Year})";
		}

		private void ActiveProductionJobs_Load(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(txtFilter.Text))
			{
				GetProductionJob(_status, this.Year, txtFilter.Text);
			}
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			this.ItemName = dgv["ITEMNAME", e.RowIndex].Value.ToString();
			this.ItemNo = dgv["ITEMNO", e.RowIndex].Value.ToString();
			this.DrawingNo = dgv["DRAWINGNO", e.RowIndex].Value.ToString();
			this.ProductionJob = dgv["ERP_ORDER", e.RowIndex].Value.ToString();
			this.ProductionJobId = Convert.ToInt32(dgv["ERP_DI", e.RowIndex].Value.ToString());
			this.JobQty = Convert.ToDecimal(dgv["QORDER", e.RowIndex].Value.ToString());
			this.UnitOrder = dgv["UNITORDER", e.RowIndex].Value.ToString();

			this.JobType = (ProductionJobType)Enum.Parse(typeof(ProductionJobType), dgv["JOBTYPE", e.RowIndex].Value.ToString(), true);

			// display selected jobid
			lbSelectJobId.Text = $"id # {this.ProductionJobId}";

			UpdateUI();

		}

		private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				this.btnSearch.PerformClick();
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			GetProductionJob(_status, this.Year,txtFilter.Text);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{

		}
	}
}
