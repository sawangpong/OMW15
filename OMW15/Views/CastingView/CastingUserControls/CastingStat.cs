using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView.CastingUserControls
{
	public partial class CastingStat : UserControl
	{
		public CastingStat()
		{
			InitializeComponent();
		}

		#region class property

		public string Title { get; set; }

		#endregion

		private void CastingStat_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			CreateCastingStatData();
			chkShowData.Checked = false;
		}

		private void chkShowData_CheckedChanged(object sender, EventArgs e)
		{
			pnlData.Visible = chkShowData.Checked;
			splitter1.Visible = pnlData.Visible;
		}

		#region class field member

		#endregion

		#region class helper

		private void UpdateChartSetting()
		{
			var _title = string.Format("{0}", Title);
			chart1.Titles[0].Text = _title;
		} // end 

		private async void CreateCastingStatData()
		{
			var _dal = new JobDAL();

			var dt = await _dal.GetSummaryJobInfoByYearAsync();

			dgv.SuspendLayout();
			dgv.DataSource = dt;
			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.ValueType == typeof(decimal))
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.ResumeLayout();

			CreateChart(dt);
			UpdateChartSetting();
		} // end

		private void CreateChart(DataTable SourceData)
		{
			Series series = null;
			//int seriesIndex = 0;
			var seriesName = "";

			chart1.Series.Clear();


			foreach (DataGridViewRow dgr in dgv.Rows)
			{
				series = new Series();

				// set chartType
				if (Convert.ToInt32(dgr.Cells["Year"].Value) != DateTime.Today.Year)
				{
					series.ChartType = SeriesChartType.Spline;
					if (Convert.ToInt32(dgr.Cells["Year"].Value) == DateTime.Today.Year - 1)
					{
						series.ChartType = SeriesChartType.Spline;
						series.BorderWidth = 3;
						series.BorderDashStyle = ChartDashStyle.Dash;
					}
					else
					{
						series.ChartType = SeriesChartType.Column;
						series.BorderWidth = 2;
						series.BorderDashStyle = ChartDashStyle.Solid;
					}
				}
				else
				{
					series.ChartType = SeriesChartType.Spline;
					series.BorderWidth = 4;
					series.BorderDashStyle = ChartDashStyle.Dash;
					series.BorderColor = Color.DarkGreen;
				}

				seriesName = dgr.Cells["Year"].Value.ToString();
				series.Name = seriesName;

				// add data series to Chart
				chart1.Series.Add(series);
				chart1.Series[seriesName].IsValueShownAsLabel = false;

				// set Axis Title
				chart1.ChartAreas["Default"].AxisX.Title = "Period";
				chart1.ChartAreas["Default"].AxisX.IsMarginVisible = false;

				// binding data to chart
				foreach (DataGridViewColumn dgc in dgv.Columns)
					if (dgc.Name != "Year" && dgc.Name != "total")
						chart1.Series[seriesName].Points.AddXY(dgc.Name, Convert.ToDouble(dgr.Cells[dgc.Index].Value));
					else if (dgc.Name == "Year")
						chart1.Series[seriesName].Points.AddXY(dgc.Name, 0.00m);

				//seriesIndex++;
			}
		} // end CreateChart

		#endregion
	}
}