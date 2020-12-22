using OMControls;
using OMW15.Models.ProductionModel;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class WorkerStat : Form
	{
		#region class field

		private static WorkerStat instance;
		private int _selectWorkYear = DateTime.Today.Year;

		#endregion

		#region class properties

		public static WorkerStat GetInstance
		{
			get
			{
				if (instance == null || instance.IsDisposed)
				{
					instance = new WorkerStat();
				}
				return instance;
			}
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			cbxWorker.Enabled = (_selectWorkYear > 0);
		}

		private void GetWorkYear()
		{
			cbxYearStat.DataSource = new ProductionStatDAL().GetWorkYear();
			cbxYearStat.DisplayMember = "WORKYEAR";
			cbxYearStat.ValueMember = "WORKYEAR";
		}

		private void GetWorkerByYear(int workYear)
		{
			cbxWorker.DataSource = new ProductionStatDAL().GetWorkerList(workYear);
			cbxWorker.DisplayMember = "Workername";
			cbxWorker.ValueMember = "workerId";
		}

		private void GetWorkerStatResult(int workYear)
		{
			//GetWorkCost();
			dgv.SuspendLayout();
			//dgv.DataSource = new ProductionStatDAL().GetWorkerStatictic(workYear);

			//foreach(DataGridViewColumn dgc in dgv.Columns)
			//{
			//    if(dgc.Name != "Worker")
			//    {
			//        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//        dgc.DefaultCellStyle.Format = "P1";
			//    }
			//}
			//dgv.Columns["Worker"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

			dgv.ResumeLayout();
		}

		private async void GetWorkCost(int year)
		{
			dgv.SuspendLayout();
			dgv.DataSource = await new ProductionDAL().GetWorkCostAsync(year);

			//foreach(DataGridViewColumn dgc in dgv.Columns)
			//{
			//    if(dgc.Name != "Worker")
			//    {
			//        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//        dgc.DefaultCellStyle.Format = "P1";
			//    }
			//}
			dgv.Columns["NormalTimeCost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["NormalTimeCost"].DefaultCellStyle.Format = "N2";

			dgv.Columns["OvertimeCost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["OvertimeCost"].DefaultCellStyle.Format = "N2";

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgv.ResumeLayout();
		}


		#endregion


		public WorkerStat()
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgv);

			GetWorkYear();
		}

		private void WorkerStat_Load(object sender, EventArgs e)
		{

		}

		private void cbxYearStat_SelectedValueChanged(object sender, EventArgs e)
		{

		}

		private void cbxWorker_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{

			}
			catch
			{

			}
		}

		private void cbxYearStat_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_selectWorkYear = Convert.ToInt32(cbxYearStat.SelectedValue.ToString());
			}
			catch
			{
				_selectWorkYear = DateTime.Today.Year;
			}

			//GetWorkerByYear(_selectWorkYear);
			//GetWorkerStatResult(_selectWorkYear);

			GetWorkCost(_selectWorkYear);

			UpdateUI();
		}
	}
}
