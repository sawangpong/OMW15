using System;
using System.Collections;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView
{
	public partial class JobListForPrint : Form
	{
		// CONSTRUCTOR
		public JobListForPrint()
		{
			InitializeComponent();
		}

		private void JobListForQC_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			dgv.MultiSelect = true;

			// loading data
			GetJobAvailableForPrint(JobStatus, Category, CustomerCode);
		}

		private void dgv_SelectionChanged(object sender, EventArgs e)
		{
			SelectedRowCount = dgv.SelectedRows.Count;
			lbCount.Text = string.Format("เลือก = {0} จาก {1} รายการ ", SelectedRowCount, dgv.Rows.Count);
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			var _jlist = new ArrayList();
			foreach (DataGridViewRow dgr in dgv.SelectedRows) _jlist.Add(Convert.ToInt32(dgr.Cells["JOBNO"].Value));

			JobList = (int[]) _jlist.ToArray(typeof(int));
		}

		#region class field member

		#endregion

		#region class property

		public int[] JobList { get; set; }

		public int SelectedRowCount { get; set; }

		public int JobStatus { get; set; }

		public string Category { get; set; }

		public string CustomerCode { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end updateUI

		private async void GetJobAvailableForPrint(int Status, string CAT, string Code)
		{
			var _dal = new CastingOrderReportDS();
			var dt = await _dal.GetJobList(Status, CAT, Code);
			dgv.SuspendLayout();
			dgv.DataSource = dt;
			dgv.ResumeLayout();
		} // end GetJobAvailableForPrint

		#endregion
	}
}