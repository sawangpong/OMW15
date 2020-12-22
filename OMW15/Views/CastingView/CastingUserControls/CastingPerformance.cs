using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OMW15.Views.CastingView.CastingUserControls
{
	public enum workCatenum
	{
		All,
		NonCasting,
		OnlyCasting
	}

	public partial class CastingPerformance : UserControl, INotifyPropertyChanged
	{
		public CastingPerformance()
		{
			InitializeComponent();
			chkShowData.Checked = false;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void CastingPerformance_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			CreateChartData(_selectedWorkYear, _selectedCat);

			AddWorkCats();
		}

		private void chkShowData_CheckedChanged(object sender, EventArgs e)
		{
			pnlData.Visible = chkShowData.Checked;
			splitter1.Enabled = pnlData.Visible;
		}

		private void cbxWorkCAT_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateChartSetting();
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		private void cbxWorkCat_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			_selectedCat = (workCatenum)Enum.Parse(typeof(workCatenum), cbxWorkCat.Text, true);
			lbWorkCat.Text = _selectedCat.ToString();
			CreateChartData(SelectedWorkYear, _selectedCat);
		}

		#region class field member

		private DataTable chartDataSource;
		private int _selectedWorkYear = DateTime.Today.Year;
		private workCatenum _selectedCat = workCatenum.All;

		#endregion

		#region class property

		public int SelectedWorkYear
		{
			get { return _selectedWorkYear; }
			set
			{
				if (value != _selectedWorkYear)
				{
					_selectedWorkYear = value;
					//MessageBox.Show("Property was changed : " + _selectedWorkYear.ToString());

					//OnPropertyChanged("SelectedWorkYear");
					// update chart data
					grp.Controls.Clear();
					CreateChartData(_selectedWorkYear, _selectedCat);
				}
			}
		}

		public string Title { get; set; }

		#endregion

		#region class helper

		private void UpdateChartSetting()
		{
			chart1.Titles[0].Text = string.Format("{0} / {1}", Title, SelectedWorkYear);
		} // end UpdateChartSetting

		private void UpdateDataTableStyle()
		{
			foreach (DataGridViewRow dgr in dgv.Rows)
			{
				dgr.DefaultCellStyle.BackColor = Color.WhiteSmoke;
				dgr.DefaultCellStyle.ForeColor = Color.Black;
			}

			// highlight the data in datagridView
			foreach (Control c in grp.Controls)
				if (c.GetType() == typeof(CheckBox))
				{
					var chk = c as CheckBox;
					if (chk.Checked)
						foreach (DataGridViewRow dgr in dgv.Rows)
							if (dgr.Cells["Style"].Value.ToString() == chk.Text)
							{
								dgr.DefaultCellStyle.BackColor = Color.Orange;
								dgr.DefaultCellStyle.ForeColor = Color.DarkBlue;
							}
				}
		} // end UpdateDataTableStyle

		private async void CreateChartData(int WorkYear, workCatenum selectCat)
		{
			var _dal = new JobDAL();
			chartDataSource = await _dal.GetSummaryBadCastingByStyleAsync(WorkYear, selectCat);

			dgv.SuspendLayout();
			dgv.DataSource = chartDataSource;

			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if (dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
			}
			dgv.ResumeLayout();


			// add check Style
			if (grp.Controls.Count == 0)
			{
				AddCheckStyle(chartDataSource);
			}

			// create Chart
			UpdateChartDisplay(chartDataSource);
		} // end CreateChartData

		private void UpdateChartDisplay(DataTable source)
		{
			Series series = null;
			var seriesName = "";
			chart1.Series.Clear();
			chart1.ChartAreas.SuspendUpdates();

			// debug
			//StringBuilder s = new StringBuilder();
			//foreach(DataRow dr in source.Rows)
			//{
			//	foreach(DataColumn dc in source.Columns)
			//	{
			//		s.Append($"{dr[dc.ColumnName].ToString()}\t");
			//	}
			//	s.AppendLine();
			//}
			//MessageBox.Show(s.ToString());
			// end



			foreach (Control c in grp.Controls)
			{
				if (c.GetType() == typeof(CheckBox))
				{
					var chk = c as CheckBox;
					if (chk.Checked)
					{
						foreach (DataRow dr in source.Rows)
						{
							if (dr["Style"].ToString() == chk.Text)
							{
								series = new Series();
								// set chart Style
								series.ChartType = SeriesChartType.Spline;
								series.BorderWidth = 2;
								seriesName = chk.Name;
								series.Name = seriesName;
								chart1.Series.Add(series);
								chart1.Series[seriesName].IsValueShownAsLabel = false;
								chart1.ChartAreas["Default"].AxisX.Title = "Month";
								chart1.ChartAreas["Default"].AxisX.IsMarginVisible = false;

								// binding data to series data
								foreach (DataColumn dc in source.Columns)
								{
									if (dc.ColumnName != "Style")
									{
										chart1.Series[seriesName].Points.AddXY(dc.ColumnName, Convert.ToDouble(dr[dc.ColumnName].ToString()));
									}
								}
							}
						}
					}
				}
			}
			chart1.ChartAreas.ResumeUpdates();
			chart1.Update();

			UpdateChartSetting();
			UpdateDataTableStyle();
		} // end UpdateChartDisplay

		private void AddCheckStyle(DataTable styles)
		{
			//this.grp.Controls.Clear();
			CheckBox chk;

			foreach (DataRow style in styles.Rows)
			{
				chk = new CheckBox();
				chk.Name = style["Style"].ToString();
				chk.Text = chk.Name;
				chk.CheckedChanged += CheckStyle_CheckedChanged;
				chk.Dock = DockStyle.Top;

				grp.Controls.Add(chk);
			}
		} // end AddCheckStyle

		private void CheckStyle_CheckedChanged(object sender, EventArgs e)
		{
			UpdateChartDisplay(chartDataSource);
		}


		private void AddWorkCats()
		{
			cbxWorkCat.Items.Clear();
			cbxWorkCat.Items.AddRange(Enum.GetNames(typeof(workCatenum)));
			cbxWorkCat.SelectedIndex = 0;
		}

		#endregion
	}
}