using OMControls;
using OMW15.Models.ProductionModel;
using OMW15.Shared;
using System;
using System.Windows.Forms;
using static OMW15.Shared.OMShareProduction;

namespace OMW15.Views.Productions
{
	public partial class Production2Plan : Form
	{
		#region Sigleton
		private static Production2Plan _instance;
		public static Production2Plan GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new Production2Plan();
				}
				return _instance;
			}
		}
		#endregion


		#region class field

		private int _status = 0;
		private int _jobYear = DateTime.Today.Year;
		private int _recordId = 0;
		private string _currentSelectedOrderNo = string.Empty;
		private string _selectedItemNo = string.Empty;
		private string _selectedItemName = string.Empty;
		private string _selectedWorkerId = string.Empty;
		private string _selectedWorker = string.Empty;

		#endregion

		#region class helper
		private void UpdateUI()
		{
			lbYear.Visible = (_status != (int)ProductionJobStatus.None);
			cbxJobYear.Visible = lbYear.Visible;
		}

		private void GetJobStatus()
		{
			cbxJobStatus.DataSource = EnumWithName<OMShareProduction.ProductionJobStatus>.ParseEnum();
			cbxJobStatus.DisplayMember = "Name";
			cbxJobStatus.ValueMember = "Value";
			cbxJobStatus.SelectedValue = _status;
		}

		private void GetProductionYear(int status)
		{
			this.cbxJobYear.DataSource = new ProductionDAL().GetProductionYearByStatus(status);
			this.cbxJobYear.DisplayMember = "JobYear";
			this.cbxJobYear.ValueMember = "JobYear";
		}

		private void GetProductionItems(int status, int workyear = 0)
		{
			cbxItemNo.DataSource = new ProductionDAL().GetWorkItem(status, workyear);
			cbxItemNo.DisplayMember = "ItemName";
			cbxItemNo.ValueMember = "ItemNo";
		}

		private void GetPlan(int status, int jobYear, string itemno)
		{
			#region SQL COMMAND CODE
			//DataTable _dtMC = new ProductionDAL().GetProcessMachineList();
			//DataTable _dtMC = new ProductionDAL().GetActualMachine(itemno,status, jobYear);
			//StringBuilder s = new StringBuilder();
			//s.AppendLine($"SELECT ");
			//s.AppendLine($"pi.ERP_ORDER AS [ORDER-NO]");
			//s.AppendLine($",pi.ITEMNO ");
			//s.AppendLine($",p.QORDER AS [QTY]");
			//foreach (DataRow dr in _dtMC.Rows)
			//{
			//	s.AppendLine($",SUM(CASE WHEN pc.MACHINE = '{dr[2]}' THEN pi.TOTAL_HRS END) AS [STEP={dr[0]}-{dr[1]}-{dr[2]}]");
			//}
			//s.AppendLine($",SUM(pi.TOTAL_HRS) AS [TOTAL-HRs]");
			//s.AppendLine($",CASE WHEN (SUM(pi.TOTAL_HRS)/(CASE WHEN p.QORDER = 0 THEN 1 ELSE p.QORDER END) >= 1) ");
			//s.AppendLine($" THEN FORMAT(CAST(SUM(pi.TOTAL_HRS)/(CASE WHEN p.QORDER = 0 THEN 1 ELSE p.QORDER END) AS INT),'00') + ");
			//s.AppendLine($" FORMAT((SUM(pi.TOTAL_HRS)/(CASE WHEN p.QORDER = 0 THEN 1 ELSE p.QORDER END) - ");
			//s.AppendLine($" CAST(SUM(pi.TOTAL_HRS)/(CASE WHEN p.QORDER = 0 THEN 1 ELSE p.QORDER END) AS INT))*60,':0#') ");
			//s.AppendLine($" ELSE '00'+ FORMAT(CAST((SUM(pi.TOTAL_HRS)/(CASE WHEN p.QORDER = 0 THEN 1 ELSE p.QORDER END) * 60) AS INT),':0#' ) END ");
			//s.AppendLine($" AS [AVG (HR/UNIT)]");
			//s.AppendLine($" FROM PRODUCTIONJOBINFO pi  ");
			//s.AppendLine($" INNER JOIN PRODUCTIONJOBS p ON pi.ERP_ORDER = p.ERP_ORDER ");
			//s.AppendLine($" INNER JOIN PRDPROCESS pc ON pi.PROCESSID = pc.PRDPROCESSID ");
			//s.AppendLine($" WHERE pi.ITEMNO = '{itemno}'");
			//if (status == (int)ProductionJobStatus.Active)
			//{
			//	s.AppendLine($" AND p.STATUS = {status} "); 
			//	s.AppendLine($" AND p.JOBYEAR = {jobYear}");
			//}
			//else if (status == (int)ProductionJobStatus.Closed)
			//{
			//	s.AppendLine($" AND p.STATUS = {status} "); 
			//	s.AppendLine($" AND YEAR(p.COMPLETEDATE) = {jobYear}");
			//}
			//s.AppendLine($" GROUP BY pi.ERP_ORDER,pi.ITEMNO,p.QORDER");
			#endregion

			// clear data in datagridview - jobinfo
			dgvJobInfo.DataSource = null;

			dgv.SuspendLayout();

			// clear data in main datagridview
			dgv.DataSource = null;

			// binding new data
			dgv.DataSource = new ProductionDAL().GetProductionPlan(status, jobYear, itemno);

			// formating columns in datagridview
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if (dgc.Index > 1) dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			}

			dgv.ResumeLayout();
		}

		private void GetWorkInfoByOrder(string order)
		{
			dgvJobInfo.SuspendLayout();

			if (_currentSelectedOrderNo != order) // re-load new order
			{
				dgvJobInfo.DataSource = new ProductionDAL().GetProductionTimeItemByOrder(order);
				_currentSelectedOrderNo = order;

				dgvJobInfo.Columns["RECORDID"].Visible = false;
				dgvJobInfo.Columns["PRODUCTIONJOB"].Visible = false;
				dgvJobInfo.Columns["WORKERID"].Visible = false;
				dgvJobInfo.Columns["ITEMNO"].Visible = false;
				dgvJobInfo.Columns["ITEMNAME"].Visible = false;
				dgvJobInfo.Columns["DRAWINGNO"].Visible = false;
				dgvJobInfo.Columns["PROCESSID"].Visible = false;

				dgvJobInfo.Columns["WORKERNAME"].HeaderText = "ผุ็ปฏิบัติงาน";
				dgvJobInfo.Columns["PROCESSNAME"].HeaderText = "ขั้นตอนการผลิต";
				dgvJobInfo.Columns["WORKDATE"].HeaderText = "วันที่ผลิต";

				foreach (DataGridViewColumn dgc in dgvJobInfo.Columns)
				{
					if (dgc.Name == "STEP")
					{
						dgc.HeaderText = "ลำดับขั้นตอน";
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					}
					if (dgc.Name == "FROMTIME")
					{
						dgc.HeaderText = "เวลาเริ่ม";
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					}
					if (dgc.Name == "TOTIME")
					{
						dgc.HeaderText = "เวลาเลิก";
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					}
					if (dgc.Name == "OTFROM")
					{
						dgc.HeaderText = "เริ่ม OT";
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					}
					if (dgc.Name == "OTEND")
					{
						dgc.HeaderText = "เลิก OT";
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					}
					if (dgc.Name == "TOTALTIME")
					{
						dgc.HeaderText = "เวลารวม ช.ม.";
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					}
					if (dgc.Name == "INWORKPROCESSQTY")
					{
						dgc.HeaderText = "ชิ้นงานระหว่างทำ";
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					}
					if (dgc.Name == "GOODQTY")
					{
						dgc.HeaderText = "ชิ้นงานดี";
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					}
					if (dgc.Name == "BADQTY")
					{
						dgc.HeaderText = "ชิ้นงานเสีย";
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					}
					if (dgc.Name == "TOTALQTY")
					{
						dgc.HeaderText = "ชิ้นงานรวม";
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					}


				}
			}

			dgvJobInfo.ResumeLayout();

			tslbRows.Text = $"found:{dgvJobInfo.Rows.Count}";
		}

		private void ProductionItemInfo()
		{
			using (PRDHOURSINFO _hourInfo = new PRDHOURSINFO(_recordId, _currentSelectedOrderNo, _selectedItemNo, _selectedItemName, _selectedWorkerId, _selectedWorker))
			{
				if (_hourInfo.ShowDialog(this) == DialogResult.OK)
				{
					GetPlan(_status, _jobYear, _selectedItemNo);
				}
			}
		}


		#endregion


		public Production2Plan()
		{
			InitializeComponent();

			OMControls.OMUtils.SettingDataGridView(ref dgv);
			OMControls.OMUtils.SettingDataGridView(ref dgvJobInfo);

			GetJobStatus();
		}

		private void Production2Plan_Load(object sender, EventArgs e)
		{

		}

		private void cbxJobStatus_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_status = Convert.ToInt32(cbxJobStatus.SelectedValue.ToString());

			if (_status != (int)ProductionJobStatus.None)
			{
				GetProductionYear(_status);
			}
			else
			{
				GetProductionItems(_status, (_jobYear = 0));
			}
			UpdateUI();
		}

		private void cbxJobYear_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_jobYear = Convert.ToInt32(cbxJobYear.SelectedValue.ToString());

			GetProductionItems(_status, _jobYear);
		}

		private void cbxItemNo_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_selectedItemNo = cbxItemNo.SelectedValue.ToString();
			GetPlan(_status, _jobYear, _selectedItemNo);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		//private void btnSQL_Click(object sender, EventArgs e)
		//{
		//	MessageBox.Show(btnClose.Tag.ToString(), "SQL Command", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			tslbJobNo.Text = dgv["ORDER-NO", e.RowIndex].Value.ToString();

			GetWorkInfoByOrder(tslbJobNo.Text);
		}

		private void dgvJobInfo_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_recordId = Convert.ToInt32(dgvJobInfo["RECORDID", e.RowIndex].Value.ToString());
			_selectedItemNo = dgvJobInfo["ITEMNO", e.RowIndex].Value.ToString();
			_selectedItemName = dgvJobInfo["ITEMNAME", e.RowIndex].Value.ToString();
			_selectedWorker = dgvJobInfo["WORKERNAME", e.RowIndex].Value.ToString();
			_selectedWorkerId = dgvJobInfo["WORKERID", e.RowIndex].Value.ToString();

		}

		private void dgvJobInfo_DoubleClick(object sender, EventArgs e)
		{
			ProductionItemInfo();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetPlan(_status, _jobYear, _selectedItemNo);
		}

		private void cbxJobStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
		}
	}
}
