using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OMW15.Views.Productions.ProductionUserControl
{
	public partial class WorkerTimeRecord : UserControl
	{
		#region property
		public string WorkerCode { get; set; }
		public string WorkerName { get; set; }
		public int WorkYear { get; set; }
		public int WorkMonth { get; set; }


		#endregion

		#region Class helper

		public void GetTimeRecordData(string workerCode, int workYear, int workMonth)
		{
			OLDMOONEF1 _om = new OLDMOONEF1();

			var trList = (from t in _om.PRODUCTIONJOBINFOes.AsEnumerable()
						  where t.WORKERID == workerCode
								 && t.WORKYEAR == workYear
								 && t.WORKPERIOD == workMonth
						  group t by t.DATETIME_START.Value.Date into tr
						  select new
						  {
							  d = tr.Key.Day,
							  total_normal = tr.Sum(x => x.TOTAL_NORMAL_HR),
							  total_ot = tr.Sum(x => x.TOTAL_OT_HR),
							  total_hr = tr.Sum(x => x.TOTAL_HRS)
						  }).AsParallel().OrderBy(o => o.d).ToList();

			#region NOT TO BE USE


			//DataTable _pt = (from p in _om.PRODUCTIONJOBINFOes
			//		   orderby p.DATETIME_START
			//		   where p.WORKERID == workerCode
			//				&& p.DATETIME_START.Value.Year == workYear
			//				 && p.DATETIME_START.Value.Month == workMonth
			//				 && p.TOTAL_NORMAL_HR > 0.00m
			//		   group p by p.WORKERNAME into pp
			//		   select new
			//		   {
			//			   D1 = pp.Sum(x => x.DATETIME_START.Value.Day == 1 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D2 = pp.Sum(x => x.DATETIME_START.Value.Day == 2 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D3 = pp.Sum(x => x.DATETIME_START.Value.Day == 3 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D4 = pp.Sum(x => x.DATETIME_START.Value.Day == 4 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D5 = pp.Sum(x => x.DATETIME_START.Value.Day == 5 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D6 = pp.Sum(x => x.DATETIME_START.Value.Day == 6 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D7 = pp.Sum(x => x.DATETIME_START.Value.Day == 7 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D8 = pp.Sum(x => x.DATETIME_START.Value.Day == 8 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D9 = pp.Sum(x => x.DATETIME_START.Value.Day == 9 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D10 = pp.Sum(x => x.DATETIME_START.Value.Day == 10 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D11 = pp.Sum(x => x.DATETIME_START.Value.Day == 11 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D12 = pp.Sum(x => x.DATETIME_START.Value.Day == 12 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D13 = pp.Sum(x => x.DATETIME_START.Value.Day == 13 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D14 = pp.Sum(x => x.DATETIME_START.Value.Day == 14 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D15 = pp.Sum(x => x.DATETIME_START.Value.Day == 15 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D16 = pp.Sum(x => x.DATETIME_START.Value.Day == 16 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D17 = pp.Sum(x => x.DATETIME_START.Value.Day == 17 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D18 = pp.Sum(x => x.DATETIME_START.Value.Day == 18 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D19 = pp.Sum(x => x.DATETIME_START.Value.Day == 19 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D20 = pp.Sum(x => x.DATETIME_START.Value.Day == 20 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D21 = pp.Sum(x => x.DATETIME_START.Value.Day == 21 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D22 = pp.Sum(x => x.DATETIME_START.Value.Day == 22 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D23 = pp.Sum(x => x.DATETIME_START.Value.Day == 23 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D24 = pp.Sum(x => x.DATETIME_START.Value.Day == 24 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D25 = pp.Sum(x => x.DATETIME_START.Value.Day == 25 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D26 = pp.Sum(x => x.DATETIME_START.Value.Day == 26 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D27 = pp.Sum(x => x.DATETIME_START.Value.Day == 27 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D28 = pp.Sum(x => x.DATETIME_START.Value.Day == 28 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D29 = pp.Sum(x => x.DATETIME_START.Value.Day == 29 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D30 = pp.Sum(x => x.DATETIME_START.Value.Day == 30 ? x.TOTAL_NORMAL_HR : 0.00m),
			//			   D31 = pp.Sum(x => x.DATETIME_START.Value.Day == 31 ? x.TOTAL_NORMAL_HR : 0.00m)
			//		   }).AsParallel().ToDataTable();
			#endregion


			DataTable m = trList.ToDataTable();

			// Mapping Data to chart
			//string normalTimeSeries = "NormalTime";
			//string otSeries = "OT";

			string totalTimeSeries = "Total";

			chart1.Series.Clear();
			chart1.SuspendLayout();

			//chart1.ChartAreas.SuspendUpdates();
			chart1.Titles[0].Text = $"Time record in {workMonth}/{workYear}";
			chart1.BackColor = Color.WhiteSmoke;
			

			// Create and add Data Series to Chart
			// NormatTime Series and set chart Style
			Series series = new Series();

			/*
			series.ChartType = SeriesChartType.Spline;
			series.Palette = ChartColorPalette.Bright;
			series.BorderWidth = 1;
			series.Name = normalTimeSeries;
			series.BorderDashStyle = ChartDashStyle.Solid;
			series.CustomProperties = "DrawSideBySide=True, DrawingStyle=Cylinder";
			chart1.Series.Add(series);
			chart1.Series[normalTimeSeries].IsValueShownAsLabel = true;
			
			
			// OT Series and set chart Style
			series = new Series();
			series.ChartType = SeriesChartType.Column;
			series.BorderWidth = 1;
			series.Name = otSeries;
			series.BorderDashStyle = ChartDashStyle.Solid;
			series.CustomProperties = "DrawSideBySide=True, DrawingStyle=Cylinder";
			chart1.Series.Add(series);
			chart1.Series[otSeries].IsValueShownAsLabel = true;

			*/

			// Total Time Series and set chart Style
			series = new Series();
			series.Color = Color.LightGreen;
			series.Palette = ChartColorPalette.EarthTones;
			series.ChartType = SeriesChartType.Column;
			series.BorderWidth = 1;
			series.Name = totalTimeSeries;
			series.LabelForeColor = Color.DarkBlue;
			series.BorderDashStyle = ChartDashStyle.Solid;
			series.CustomProperties = "DrawSideBySide=True, DrawingStyle=Cylinder";
			chart1.Series.Add(series);
			chart1.Series[totalTimeSeries].IsValueShownAsLabel = true;

			// config chart area
			chart1.ChartAreas[0].AxisX.Title = "วันที่";
			chart1.ChartAreas[0].AxisY.Title = "ชั่วโมง";
			chart1.ChartAreas[0].AxisX.IsMarginVisible = true;
			chart1.ChartAreas[0].IsSameFontSizeForAllAxes = true;


			// add data to Normal Time serial
			foreach (DataRow dr in m.Rows)
			{
				// add data to normal time series
				//chart1.Series[normalTimeSeries].Points.AddXY(dr[0].ToString(), Convert.ToDouble(dr[1]));

				// add data to OT series
				//chart1.Series[otSeries].Points.AddXY(dr[0].ToString(), Convert.ToDouble(dr[2]));

				// add data to Total time series
				chart1.Series[totalTimeSeries].Points.AddXY(dr[0].ToString(), Convert.ToDouble(dr[3]));
			}

			chart1.ResumeLayout();
			chart1.Update();

		}

		#endregion

		public WorkerTimeRecord()
		{
			InitializeComponent();
		}

		private void WorkerTimeRecord_Load(object sender, EventArgs e)
		{
		}
	}
}
