using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using OMControls;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView.CastingUserControls
{
	public partial class WorkerPerformance : UserControl
	{
		public WorkerPerformance()
		{
			InitializeComponent();
			chkExploded.Checked = false;
		}

		private void cbxWorker_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateChartSetting();
		}

		//public event PropertyChangedEventHandler PropertyChanged;
		//private void NotifyPropertyChanged(string propertyName)
		//{
		//	if (PropertyChanged != null)
		//	{
		//		PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		//	}
		//}

		private void WorkerPerformance_Load(object sender, EventArgs e)
		{
			chkExploded.Checked = false;
			CreateChartData(SelectedMonth, SelectedYear);
		}

		private void chkExploded_CheckedChanged(object sender, EventArgs e)
		{
			if (chkExploded.Checked)
			{
				lbWorker.Visible = !chkExploded.Checked;
				cbxWorker.Visible = lbWorker.Visible;
			}
			else
			{
				lbWorker.Visible = !chkExploded.Checked;
				cbxWorker.Visible = lbWorker.Visible;
			}

			UpdateChartSetting();
		}

		#region class field member

		private int _selectedMonth = DateTime.Today.Month;
		private int _selectedYear = DateTime.Today.Year;

		private string[] _workerName;
		private double[] _values;

		#endregion

		#region class property

		public int SelectedMonth
		{
			get { return _selectedMonth; }
			set
			{
				if (_selectedMonth != value)
				{
					_selectedMonth = value;
					CreateChartData(_selectedMonth, _selectedYear);
					//this.NotifyPropertyChanged("SelectdMonth");
				}
			}
		}

		public int SelectedYear
		{
			get { return _selectedYear; }
			set
			{
				if (_selectedYear != value)
				{
					_selectedYear = value;
					CreateChartData(_selectedMonth, _selectedYear);
					//this.NotifyPropertyChanged("SelectedYear");
				}
			}
		}

		public string Title { get; set; }

		#endregion

		#region class helper

		private void UpdateChartSetting()
		{
			var _title = string.Format("{0} for {1}/{2}", Title, SelectedMonth.GetMonthName(), SelectedYear);
			chart1.Titles[0].Text = _title;
			chart1.Series[0].ChartType = SeriesChartType.Pie;
			chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
			chart1.Series[0]["PieLableStyle"] = "Outside";
			chart1.Series[0]["PieDrawingStyle"] = "SoftEdge";
			chart1.Legends[0].Enabled = true;

			// for exploded
			if (chkExploded.Checked)
				foreach (var point in chart1.Series[0].Points)
					point["Exploded"] = "true";
			else
				foreach (var point in chart1.Series[0].Points)
				{
					point["Exploded"] = "false";
					if (point.AxisLabel == cbxWorker.Text)
						point["Exploded"] = "true";
				}
		} // end UpdateChartSetting

		private async void CreateChartData(int WorkPeriod, int WorkYear)
		{
			// setting data to chart
			var _dal = new JobDAL();
			var _dt = await _dal.GetAVGProgressByMonthAsync(WorkPeriod, WorkYear);
			_workerName = new string[_dt.Rows.Count];
			_values = new double[_dt.Rows.Count];

			// counter
			var i = 0;

			foreach (DataRow dr in _dt.Rows)
			{
				_values[i] = Convert.ToDouble(dr["PERFORMANCE"]);
				_workerName[i] = string.Format("{0} ({1:P2})", dr["WORKER"], dr["PERFORMANCE"]);
				i++;
			}

			// add worker
			cbxWorker.Items.Clear();
			cbxWorker.Items.AddRange(_workerName);

			UpdateWorkChartData();
		} // end CreateChartData


		private void UpdateWorkChartData()
		{
			chart1.Series.Clear();

			var _seriesName = "";
			chart1.Series.Add(_seriesName);

			// setting Chart Style
			UpdateChartSetting();

			// binding data to chart
			chart1.Series[0].Points.DataBindXY(_workerName, _values);
			chart1.Series[0].LabelFormat = "P2";
			chart1.Series[0].IsValueShownAsLabel = true;

			UpdateChartSetting();
		} // end GetWorkData

		#endregion
	}
}