using OMControls;
using OMW15.Models.ProductionModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Text;
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
		private string _currentSelectedOrderNo = string.Empty;


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
			//DataTable _dtMC = new ProductionDAL().GetProcessMachineList();
			DataTable _dtMC = new ProductionDAL().GetActualMachine(itemno,status, jobYear);
			StringBuilder s = new StringBuilder();

			s.AppendLine($"SELECT ");
			s.AppendLine($"pi.ERP_ORDER AS [ORDER-NO]");
			s.AppendLine($",pi.ITEMNO ");
			s.AppendLine($",pc.PROCESSNAME ");

			foreach (DataRow dr in _dtMC.Rows)
			{
				s.AppendLine($", 'STEP='+CAST(pi.STEP AS NVARCHAR(5)) + '__[TOTAL HRS=' + ");
				s.AppendLine($" FORMAT(SUM(CASE WHEN pc.MACHINE = '{dr[0].ToString()}' THEN pi.TOTAL_HRS END),'#,##0.00') +']' AS [{dr[0].ToString()}]");
			}
			s.AppendLine($" FROM PRODUCTIONJOBINFO pi  ");
			s.AppendLine($" INNER JOIN PRODUCTIONJOBS p ON pi.ERP_ORDER = p.ERP_ORDER ");
			s.AppendLine($" INNER JOIN PRDPROCESS pc ON pi.PROCESSID = pc.PRDPROCESSID ");
			s.AppendLine($" WHERE pi.ITEMNO = '{itemno}'");
			//s.AppendLine($" AND p.STATUS = {status} "); //AND YEAR(p.COMPLETEDATE) = {jobYear} AND pi.ITEMNO = '{itemno}'
			if (status == (int)ProductionJobStatus.Active)
			{
				s.AppendLine($" AND p.STATUS = {status} "); //AND YEAR(p.COMPLETEDATE) = {jobYear} AND pi.ITEMNO = '{itemno}'
				s.AppendLine($" AND p.JOBYEAR = {jobYear}");
			}
			else if (status == (int)ProductionJobStatus.Closed)
			{
				s.AppendLine($" AND p.STATUS = {status} "); //AND YEAR(p.COMPLETEDATE) = {jobYear} AND pi.ITEMNO = '{itemno}'
				s.AppendLine($" AND YEAR(p.COMPLETEDATE) = {jobYear}");
			}
			s.AppendLine($" GROUP BY pi.ERP_ORDER,pi.ITEMNO,pc.PROCESSNAME,pi.STEP");
			s.AppendLine($" ORDER BY pi.ERP_ORDER, pi.STEP");

			btnClose.Tag = s.ToString();

			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;
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
			}

			dgvJobInfo.ResumeLayout();
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
			GetPlan(_status, _jobYear, cbxItemNo.SelectedValue.ToString());
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSQL_Click(object sender, EventArgs e)
		{
			MessageBox.Show(btnClose.Tag.ToString(), "SQL Command", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			tslbJobNo.Text = dgv["ORDER-NO", e.RowIndex].Value.ToString();

			GetWorkInfoByOrder(tslbJobNo.Text);
		}
	}
}
