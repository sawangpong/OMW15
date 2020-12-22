using System;
using System.Data;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CastingModel;
using OMW15.Views.CastingView.CastingUserControls;

namespace OMW15.Views.CastingView
{
	public partial class CastingPerformanceCharts : Form
	{
		public CastingPerformanceCharts()
		{
			InitializeComponent();
		}

		private void CastingPerformanceCharts_Load(object sender, EventArgs e)
		{
			CenterToParent();
			CreateYearList();
			CreatePeriodList();
			tscbxPeriod.ComboBox.SelectedValue = WorkPeriod;
			tscbxYear.ComboBox.SelectedValue = WorkYear;
			CreateStatisticCategoryTable();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tscbxYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tscbxYear.ComboBox.SelectedValue.GetType() == typeof(int))
			{
				WorkYear = Convert.ToInt32(tscbxYear.ComboBox.SelectedValue);
				switch (selectedStatCategoryCode)
				{
					case "WORK_PERFORMANCE":
						if (pnlChart.HasChildren)
							if (pnlChart.Controls[0].Name == "WORKER") wp.SelectedYear = WorkYear;
							else CreateWorkerPerformanceChart();
						break;
					case "CASTING_STAT":
						if (pnlChart.HasChildren)
							if (pnlChart.Controls[0].Name == "CASTING_STAT") cper.SelectedWorkYear = WorkYear;
							else CreateCastingStatChart();
						break;
					default:
						pnlChart.Controls.Clear();
						break;
				}
			}
		}

		private void tscbxPeriod_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tscbxPeriod.ComboBox.SelectedValue.GetType() == typeof(int))
			{
				WorkPeriod = Convert.ToInt32(tscbxPeriod.ComboBox.SelectedValue);
				switch (selectedStatCategoryCode)
				{
					case "WORK_PERFORMANCE":
						if (pnlChart.HasChildren)
							if (pnlChart.Controls[0].Name == "WORKER") wp.SelectedMonth = WorkPeriod;
							else CreateWorkerPerformanceChart();
						break;
					default:
						pnlChart.Controls.Clear();
						break;
				}
			}
		}

		private void lstStatisticCategory_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				selectedStatCategoryCode = lstStatisticCategory.SelectedValue.ToString();
				chartTitle = lstStatisticCategory.Text;

				switch (selectedStatCategoryCode)
				{
					case "WORK_PERFORMANCE":

						if (pnlChart.HasChildren)
							if (pnlChart.Controls[0].Name == "WORKER")
							{
								// setting new value
							}
							else
							{
								CreateWorkerPerformanceChart();
							}
						else CreateWorkerPerformanceChart();
						break;

					case "CASTING":
						if (pnlChart.HasChildren)
							if (pnlChart.Controls[0].Name == "CASTING")
							{
								// setting new value
							}
							else
							{
								CreateCastingChart();
							}
						else CreateCastingChart();
						break;

					case "CASTING_STAT":
						if (pnlChart.HasChildren)
							if (pnlChart.Controls[0].Name == "CASTING_STAT")
							{
								// setting new value
							}
							else
							{
								CreateCastingStatChart();
							}
						else CreateCastingStatChart();
						break;

					default:
						pnlChart.Controls.Clear();
						break;
				}
			}
			catch
			{
				selectedStatCategoryCode = "";
				pnlChart.Controls.Clear();
			}
		}

		#region class field member

		private WorkerPerformance wp;
		private CastingStat ct;
		private Views.CastingView.CastingUserControls.CastingPerformance cper;
		private string selectedStatCategoryCode = "";
		private string chartTitle = "Title";

		#endregion

		#region class properties

		public int WorkYear { get; set; }

		public int WorkPeriod { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end UpdateUI

		private void CreateYearList()
		{
			tscbxYear.ComboBox.DataSource = new JobDAL().CreateJobYearList();
			tscbxYear.ComboBox.DisplayMember = "JOBYEAR";
			tscbxYear.ComboBox.ValueMember = "JOBYEAR";
		} // end CreateYearList

		private void CreatePeriodList()
		{
			tscbxPeriod.ComboBox.DataSource = OMUtils.GetMonthTable();
			tscbxPeriod.ComboBox.DisplayMember = "MONTHNAME";
			tscbxPeriod.ComboBox.ValueMember = "MONTHID";
		} // end CratePeriodList


		private void CreateStatisticCategoryTable()
		{
			var dt = new DataTable();

			dt.Columns.Add(new DataColumn("CategoryCode", typeof(string)));
			dt.Columns.Add(new DataColumn("CategoryName", typeof(string)));

			var dr = dt.NewRow();
			dr["CategoryCode"] = "WORK_PERFORMANCE";
			dr["CategoryName"] = "ประสิทธิ์ภาพพนักงาน";
			dt.Rows.Add(dr);

			dr = dt.NewRow();
			dr["CategoryCode"] = "CASTING";
			dr["CategoryName"] = "ยอดการหล่อชิ้นงาน";
			dt.Rows.Add(dr);

			dr = dt.NewRow();
			dr["CategoryCode"] = "CASTING_STAT";
			dr["CategoryName"] = "สถิติการหล่อชิ้นงานเสีย";
			dt.Rows.Add(dr);

			// binding to listbox
			lstStatisticCategory.DataSource = dt;
			lstStatisticCategory.DisplayMember = "CategoryName";
			lstStatisticCategory.ValueMember = "CategoryCode";
		} // end CreateStatisticCategoryTable


		private void CreateWorkerPerformanceChart()
		{
			pnlChart.Controls.Clear();
			wp = new WorkerPerformance();
			wp.Name = "WORKER";
			wp.SelectedMonth = WorkPeriod;
			wp.SelectedYear = WorkYear;
			wp.Title = lstStatisticCategory.Text;
			wp.Dock = DockStyle.Fill;

			pnlChart.SuspendLayout();
			pnlChart.Controls.Add(wp);
			pnlChart.ResumeLayout();
		} // end CreateWorkerPerformanceChart

		private void CreateCastingChart()
		{
			pnlChart.Controls.Clear();
			ct = new CastingStat();
			ct.Name = "CASTING";
			ct.Title = lstStatisticCategory.Text;
			ct.Dock = DockStyle.Fill;
			pnlChart.SuspendLayout();
			pnlChart.Controls.Add(ct);
			pnlChart.ResumeLayout();
		} // end CreateCastingChart


		private void CreateCastingStatChart()
		{
			pnlChart.Controls.Clear();
			cper = new CastingView.CastingUserControls.CastingPerformance();
			cper.Name = "CASTING_STAT";
			cper.SelectedWorkYear = WorkYear;
			cper.Title = lstStatisticCategory.Text;
			cper.Dock = DockStyle.Fill;
			pnlChart.SuspendLayout();
			pnlChart.Controls.Add(cper);
			pnlChart.ResumeLayout();
		} // end CreateCastingStatChart

		#endregion
	}
}