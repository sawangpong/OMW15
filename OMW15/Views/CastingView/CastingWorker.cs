using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class CastingWorker : Form
	{

		#region class field members

		private EmployeeStatus _status = EmployeeStatus.Active;


		#endregion

		#region class property

		public int id { get; set; }
		public string workerName { get; set; }


		#endregion

		#region class helper

		private void updateUI()
		{
			this.btnSelect.Enabled = (this.id > 0);
		}

		private void loadWorker()
		{
			this.Name = "";
			this.id = 0;
			dgv.SuspendLayout();

			dgv.DataSource = new Models.CastingModel.CastingWorkerDAL().getWorkerList(_status);
			dgv.Columns["Id"].Visible = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();

			updateUI();
		}


		#endregion

		public CastingWorker()
		{
			InitializeComponent();
			CenterToParent();
		}

		private void CastingWorker_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			chkShowAllWorker.Checked = false;
			loadWorker();
		}

		private void chkShowAllWorker_CheckedChanged(object sender, EventArgs e)
		{
			_status = chkShowAllWorker.Checked ? EmployeeStatus.All : EmployeeStatus.Active;

			loadWorker();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			this.Name = dgv["Name", e.RowIndex].Value.ToString();
			this.id = int.Parse(dgv["Id", e.RowIndex].Value.ToString());

			this.updateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.btnSelect.PerformClick();
		}
	}
}
