using OMControls;
using OMW15.Models.ProductionModel;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class WorkProcess : Form
	{
		#region calss field
		private int _itemId = 0;
		private string _itemNo = "";
		private string _itemName = "";

		#endregion

		#region class property
		public int Step { get; set; }
		public int ProcessId { get; set; }
		public string ProcessName { get; set; }
		public decimal StdHr { get; set; }
		public int SelectedMachineGroupId { get; set; } = 0;
		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnSelect.Enabled = (this.ProcessId > 0);
		}

		private void GetProcessList(string itemNo)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new ProductionDAL().GetStdProcessList(itemNo);

			// hide columns
			dgv.Columns["ID"].Visible = false;
			dgv.Columns["REF_STDITEM"].Visible = false;
			dgv.Columns["REF_STDITEMNO"].Visible = false;
			dgv.Columns["REF_PROCESS"].Visible = false;
			dgv.Columns["STD_HR"].Visible = false;
			dgv.Columns["WORKMINT"].Visible = false;
			dgv.Columns["STEP_COST"].Visible = false;
			dgv.Columns["MACHINE_GROUP"].Visible = false;

			dgv.Columns["STEP"].HeaderText = "ลำดับที่";
			dgv.Columns["PROCESSNAME"].HeaderText = "ขั้นตอนการผลิต";
			dgv.Columns["PROCESSNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			//dgv.Columns["STD_HR"].HeaderText = "ชั่วโมงมาตรฐาน";
			//dgv.Columns["STD_HR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//dgv.Columns["STD_HR"].DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.NumericCellStyle();

			dgv.Columns["MACHINE"].HeaderText = "กลุ่มเครื่องจักร";
			dgv.Columns["MACHINE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

			//dgv.Columns["WORKMINT"].HeaderText = "เวลาme'koมาตรฐาน (นาที)";
			//dgv.Columns["WORKMINT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//dgv.Columns["WORKMINT"].DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.NumericCellStyle();

			//dgv.Columns["STEP_COST"].HeaderText = "ค่าแรง";
			//dgv.Columns["STEP_COST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//dgv.Columns["STEP_COST"].DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.NumericCellStyle();

			dgv.ResumeLayout();

			this.ProcessId = 0;
			this.UpdateUI();
		}

		#endregion

		public WorkProcess(int itemId, string itemNo)
		{
			InitializeComponent();

			_itemId = itemId;
			_itemNo = itemNo;
		}

		public WorkProcess(int itemId, string itemNo, string itemName)
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgv);

			_itemId = itemId;
			_itemNo = itemNo;
			_itemName = itemName;
			lbItemNo.Text = $"{_itemId} {_itemNo} {_itemName}";
		}

		private void WorkProcess_Load(object sender, EventArgs e)
		{
			GetProcessList(_itemNo);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			this.ProcessId = Convert.ToInt32(dgv["REF_PROCESS", e.RowIndex].Value);
			this.ProcessName = dgv["PROCESSNAME", e.RowIndex].Value.ToString();
			this.Step = Convert.ToInt32(dgv["STEP", e.RowIndex].Value);
			this.StdHr = Convert.ToDecimal(dgv["STD_HR", e.RowIndex].Value);
			this.SelectedMachineGroupId = Convert.ToInt32(dgv["MACHINE_GROUP", e.RowIndex].Value);
			this.UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void btnAddProcess_Click(object sender, EventArgs e)
		{
			int _step = 0;
			using (var std = new STDItemProcess(_step, _itemId, _itemNo, _itemName))
			{
				std.ShowDialog(this);
			}

			// re-load process list
			GetProcessList(_itemNo);
		}
	}
}
