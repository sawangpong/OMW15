using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ProductionModel;

namespace OMW15.Views.Productions
{
	public partial class UpdateJobHrs : Form
	{
		#region Singleton
		private static UpdateJobHrs _instance;
		public static UpdateJobHrs GetInstance
		{
			get
			{
				if(_instance == null || _instance.IsDisposed)
				{
					_instance = new UpdateJobHrs();
				}
				return _instance;
			}
		}

		#endregion

		#region class field
		private int _selectedWorkYear = DateTime.Today.Year;
		private string _selectedWorkerId = string.Empty;
		#endregion


		#region class helper
		private void UpdateUI()
		{

		}

		private void GetWorkYear()
		{
			cbxYear.DataSource = new ProductionDAL().GetProductionWorkYear();
			cbxYear.DisplayMember = "WORKYEAR";
			cbxYear.ValueMember = "WORKYEAR";

			cbxYear.SelectedIndex = 0;
			_selectedWorkYear = Convert.ToInt32(cbxYear.SelectedValue);
			GetWorkerByYear(_selectedWorkYear);
		}

		private void GetWorkerByYear(int workYear)
		{
			dgvWorker.SuspendLayout();
			dgvWorker.DataSource = new ProductionDAL().GetWokerByYear(workYear);
			dgvWorker.ColumnHeadersVisible = false;
			dgvWorker.Columns["WORKERID"].Visible = false;
			dgvWorker.Columns["WORKERNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvWorker.ResumeLayout();
		}

		private void GetWorkInfo(int workYear, string workerId)
		{
			dgvWorkInfo.SuspendLayout();
			dgvWorkInfo.DataSource = new ProductionDAL().GetWorkInfo(workYear, workerId);

			dgvWorkInfo.ResumeLayout();
		}


		#endregion


		public UpdateJobHrs()
		{
			InitializeComponent();

			OMUtils.SettingDataGridView(ref dgvWorker);
			OMUtils.SettingDataGridView(ref dgvWorkInfo);


			GetWorkYear();
		}

		private void cbxYear_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_selectedWorkYear = Convert.ToInt32(cbxYear.SelectedValue);

			GetWorkerByYear(_selectedWorkYear);
		}

		private void dgvWorker_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedWorkerId = dgvWorker["WORKERID", e.RowIndex].Value.ToString();

			GetWorkInfo(_selectedWorkYear, _selectedWorkerId);
		}
	}
}
