using OMW15.Views.EmployeeView;
using OMW15.Views.Productions.ProductionReports;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public enum ReportDisplayType
	{
		AllRecords,
		SingleRecord
	}

	public partial class Production : Form
	{
		public Production()
		{
			InitializeComponent();

			mnuIssueMap.Visible = (omglobal.PermisionId >= (int)Shared.OMShareSysConfigEnums.UserPermission.Manager);
		}

		#region class field member
		private static Production instance;

		#endregion

		#region class properties
		public static Production GetInstance
		{
			get
			{
				if (instance == null || instance.IsDisposed)
				{
					instance = new Production();
				}

				return instance;
			}
		}

		#endregion

		#region class helper method

		private void GetProductionTaskList()
		{
			ProductionJobList _task = ProductionJobList.GetInstance;
			_task.WindowState = FormWindowState.Maximized;
			_task.MdiParent = this;
			_task.Show();

		} // end GetProductionTaskList

		#endregion

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Production_Load(object sender, EventArgs e)
		{
			//this.CreateProductionTransformList();
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void mnuProductionTasks_Click(object sender, EventArgs e)
		{
			GetProductionTaskList();
		}

		private void mnuStandardItems_Click(object sender, EventArgs e)
		{
			STDParts _stdItems = new STDParts();
			_stdItems.StartPosition = FormStartPosition.CenterParent;
			_stdItems.MdiParent = this;
			_stdItems.Show();
		}

		private void mnuProductionMembers_Click(object sender, EventArgs e)
		{
			var _emp = new MasterEmployee();
			_emp.StartPosition = FormStartPosition.CenterScreen;
			_emp.MdiParent = this;
			_emp.Show();
		}

		private void mnuProductionProcess_Click(object sender, EventArgs e)
		{
			var _pc = new Prdprocess();
			_pc.StartPosition = FormStartPosition.CenterScreen;

			_pc.Show(this);
		}

		private void mnuClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnSTDTime_Click(object sender, EventArgs e)
		{
			mnuStandardItems.PerformClick();
		}

		private void tsbtnProductionTask_Click(object sender, EventArgs e)
		{
			mnuProductionTasks.PerformClick();
		}

		private void mnuCascadeWindows_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void mnuVerticalWindowList_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void mnuHorizontalWindowList_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}


		private void tsbtnBOM_Click(object sender, EventArgs e)
		{
			this.mnuBOM.PerformClick();
		}

		private void mnuBOM_Click(object sender, EventArgs e)
		{
			BOM bom = new BOM();
			bom.StartPosition = FormStartPosition.CenterScreen;
			bom.Show();
		}

		private void mnuWorkStat_Click(object sender, EventArgs e)
		{
			//var _workerStat = WorkerStat.GetInstance;
			//_workerStat.StartPosition = FormStartPosition.CenterScreen;
			//_workerStat.BringToFront();
			//_workerStat.MdiParent = this;
			//_workerStat.Show();
		}

		private void tsbtnStat_Click(object sender, EventArgs e)
		{
			mnuWorkStat.PerformClick();
		}

		private void mnuIssueMap_Click(object sender, EventArgs e)
		{
			REQISU rq = new REQISU();
			rq.MdiParent = this;
			rq.Show();
		}

		private void mnuTimeRecord_Click(object sender, EventArgs e)
		{
			PDTimeRecord pdTimeRecord = PDTimeRecord.GetInstance;
			pdTimeRecord.BringToFront();
			pdTimeRecord.MdiParent = this;
			pdTimeRecord.Show();

		}

		private void tsbtnTimeRecord_Click(object sender, EventArgs e)
		{
			this.mnuTimeRecord.PerformClick();
		}

		private void mnuWorkHistory_Click(object sender, EventArgs e)
		{
			var _stat = ItemStat.GetInstance;
			_stat.StartPosition = FormStartPosition.CenterScreen;
			_stat.MdiParent = this;
			_stat.Show();

		}

		private void tsbtnWorkHistory_Click(object sender, EventArgs e)
		{
			mnuWorkHistory.PerformClick();
		}

		private void mnuReports_Click(object sender, EventArgs e)
		{
			var _reports = ProductionReport.GetInstance;
			_reports.StartPosition = FormStartPosition.CenterScreen;
			_reports.ShowDialog(this);
		}

		private void tsbtnReport_Click(object sender, EventArgs e)
		{
			mnuReports.PerformClick();
		}

		private void mnuCheckWorkTime_Click(object sender, EventArgs e)
		{
			var _checkWorkTime = WorktimeManager.GetInstance;
			_checkWorkTime.StartPosition = FormStartPosition.CenterScreen;
			_checkWorkTime.Show(this);
		}
	}
}