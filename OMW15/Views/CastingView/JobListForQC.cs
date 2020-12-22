using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers;
using OMW15.Models;
using OMW15.Shared;
using OMW15.Views;


namespace OMW15.Views.CastingView
{
	public partial class JobListForQC : Form
	{
		#region class field member
		private int _status = (int)Shared.OMShareJobEnums.JobStatusEnumEN.Active;


		#endregion


		#region class property

		public int[] JobQCList
		{
			get;
			set;
		}

		public int SelectedRowCount
		{
			get;
			set;
		}

		public int JobStatus
		{
			get;
			set;
		}

		public string Category
		{
			get;
			set;
		}

		public string CustomerCode
		{
			get;
			set;
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{

		} // end updateUI

		private void GetJobAvailableForQC(int Status, string CAT, string Code)
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = new Models.CastingModel.CastingOrderReportDS().GetJobQCList(Status, CAT, Code);
			this.dgv.ResumeLayout();

		} // end GetJobAvailableForQC

		#endregion

		// CONSTRUCTOR
		public JobListForQC()
		{
			InitializeComponent();
		}

		private void JobListForQC_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.dgv.MultiSelect = true;

			// loading data
			this.GetJobAvailableForQC(this.JobStatus, this.Category, this.CustomerCode);
		}

		private void dgv_SelectionChanged(object sender, EventArgs e)
		{
			this.SelectedRowCount = this.dgv.SelectedRows.Count;

			this.lbCount.Text = string.Format("เลือก = {0} จาก {1} รายการ ", this.SelectedRowCount, this.dgv.Rows.Count);
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			ArrayList _jlist = new ArrayList();
			foreach (DataGridViewRow dgr in this.dgv.SelectedRows)
			{
				_jlist.Add(Convert.ToInt32(dgr.Cells["JOBNO"].Value));
			}

			this.JobQCList = (int[])_jlist.ToArray(typeof(System.Int32));

			// debug
			//StringBuilder _sb = new StringBuilder();
			//foreach (var item in this.JobQCList)
			//{
			//	_sb.AppendFormat("{0}",item);
			//	_sb.AppendLine();
			//}
			//Controllers.ToolController.Alert.DisplayAlert("Show the job-no for printing QC",_sb.ToString());
			// end debug
		}
	}
}
