using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OMW15.Casting.CastingView
{
	public partial class CastingPerformanceCharts : Form
	{
		#region class properties

		public int WorkYear
		{
			get;
			set;
		}

		public int WorkPeriod
		{
			get;
			set;
		}



		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end UpdateUI

		private void CreateYearList()
		{
			this.tscbxYear.ComboBox.DataSource = new Casting.CastingController.JobDAL().CreateJobYearList();
			this.tscbxYear.ComboBox.DisplayMember = "JOBYEAR";
			this.tscbxYear.ComboBox.ValueMember = "JOBYEAR";

			//using (OLDMOONEF om = new OLDMOONEF())
			//{
			//	var y = (from j in om.JOBINFOS
			//			 where j.ISDELETE == false && j.FISCYEAR > 0
			//			 select new
			//			 {
			//				 j.FISCYEAR
			//			 }).Distinct().OrderByDescending(o => o.FISCYEAR).AsParallel();
			//}

		} // end CreateYearList

		private void CreatePeriodList()
		{
			this.tscbxPeriod.ComboBox.DataSource = OMControls.OMUtils.GetMonthTable();
			this.tscbxPeriod.ComboBox.DisplayMember = "MONTHNAME";
			this.tscbxPeriod.ComboBox.ValueMember = "MONTHID";
		} // end CratePeriodList

		private void UpdateWorkChartData(int WorkYear, int WorkPeriod)
		{
			DataTable _dt = new Casting.CastingController.JobDAL().GetAVGProgressByMonth(WorkPeriod, WorkYear);
			this.chart1.Series.Clear();

			string _seriesName = "";
			this.chart1.Series.Add(_seriesName);

			this.chart1.Legends[0].Enabled = true;
			this.chart1.Series[0]["PieLableStyle"] = "Outside";
			this.chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
			chart1.Series[0]["PieDrawingStyle"] = "SoftEdge";

			this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

			string[] _workerName = new string[_dt.Rows.Count];
			double[] _values = new double[_dt.Rows.Count];
			;

			int i = 0;

			foreach (DataRow dr in _dt.Rows)
			{
				_workerName[i] = string.Format("{0:P0}", dr["PERFORMANCE"]);
				_values[i] = Convert.ToDouble(dr["PERFORMANCE"]) * 100;
				i++;
			}

			this.chart1.Series[0].Points.DataBindXY(_workerName, _values);


		} // end GetWorkData


		#endregion



		public CastingPerformanceCharts()
		{
			InitializeComponent();
		}

		private void CastingPerformanceCharts_Load(object sender, EventArgs e)
		{
			this.CreateYearList();
			this.CreatePeriodList();
			this.tscbxPeriod.ComboBox.SelectedValue = this.WorkPeriod;
			this.tscbxYear.ComboBox.SelectedValue = this.WorkYear;

			this.UpdateWorkChartData(this.WorkYear, this.WorkPeriod);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tscbxYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tscbxYear.ComboBox.SelectedValue.GetType() == typeof(System.Int32))
			{
				this.WorkYear = Convert.ToInt32(this.tscbxYear.ComboBox.SelectedValue);
				this.UpdateWorkChartData(this.WorkYear, this.WorkPeriod);
			}
		}
	}
}
