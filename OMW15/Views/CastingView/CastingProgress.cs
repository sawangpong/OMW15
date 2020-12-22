using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView
{
	public partial class CastingProgress : Form
	{
		public CastingProgress()
		{
			InitializeComponent();
		}

		private void CastingProgress_Load(object sender, EventArgs e)
		{
			// setting All DataGridView Control
			OMUtils.SettingDataGridView(ref dgv);
			OMUtils.SettingDataGridView(ref dgv2);
			OMUtils.SettingDataGridView(ref dgvAVG);
			OMUtils.SettingDataGridView(ref dgvYearSum);
			OMUtils.SettingDataGridView(ref dgvWorkSum);

			GetWorkYear();
			AddMonthButton();

			dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
		}

		private void tsbtn_Click(object sender, EventArgs e)
		{
			var _btn = sender as ToolStripButton;
			_btn.Font = new Font(_btn.Font, FontStyle.Bold | FontStyle.Underline);
			_selectedPeriod = Convert.ToInt32(_btn.Tag.ToString());

			// call method
			LoadJobProgress(_selectedWorkYear, _selectedPeriod);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtn_MouseLeave(object sender, EventArgs e)
		{
			var _btn = sender as ToolStripButton;
			_btn.Font = new Font(_btn.Font, FontStyle.Regular);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedWorkDate = OMUtils.Date2Num(dgv["WORKDATE", e.RowIndex].Value);

			GetWorkDetails(_selectedWorkDate);

			lbWorkDetailByDay.Text = string.Format("Details for date {0}", _selectedWorkDate.Num2Date().ToShortDateString());
		}

		private void tscbxWorkYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tscbxWorkYear.ComboBox.SelectedValue.GetType() == typeof(int))
			{
				_selectedWorkYear = Convert.ToInt32(tscbxWorkYear.ComboBox.SelectedValue);

				// call method
				LoadJobProgress(_selectedWorkYear, _selectedPeriod);
			}
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgv["WORKDATE", e.RowIndex].Value.ToString() == "TOTAL")
			{
				e.CellStyle.BackColor = Color.Red;
				e.CellStyle.ForeColor = Color.Yellow;
				e.CellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
			}
		}

		private void dgvYearSum_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectSummaryWorkYear = Convert.ToInt32(dgvYearSum["YEAR", e.RowIndex].Value);

			lbWorkSummaryByYWorker.Text = string.Format("ยอดสะสม (ทำก้อน /ฉีด / แต่ง) in Year : [{0}]", _selectSummaryWorkYear);

			// loading
			GetSummaryByWorker(_selectSummaryWorkYear);
		}

		private void dgv_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgv["DAY", e.RowIndex].Value.ToString().ToUpper() == "SUN")
			{
				e.CellStyle.BackColor = Color.Red;
				e.CellStyle.ForeColor = Color.White;
			}
		}

		private void btnChart_Click(object sender, EventArgs e)
		{
			var ps = new CastingPerformanceCharts();
			ps.WorkYear = _selectedWorkYear;
			ps.WorkPeriod = _selectedPeriod;
			ps.StartPosition = FormStartPosition.CenterScreen;
			ps.MdiParent = ParentForm;
			ps.Show();
		}

		#region class field member

		private decimal _selectedWorkDate;
		private int _selectedWorkYear = DateTime.Today.Year;
		private int _selectedPeriod = DateTime.Now.Month;
		private int _selectSummaryWorkYear = DateTime.Today.Year;

		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetWorkYear()
		{
			tscbxWorkYear.ComboBox.DataSource = new JobDAL().CreateJobYearList();
			tscbxWorkYear.ComboBox.DisplayMember = "JOBYEAR";
			tscbxWorkYear.ComboBox.ValueMember = "JOBYEAR";
		} // end GetWorkYear

		private async void LoadJobProgress(int WorkYear, int WorkPeriod)
		{
			if (WorkYear > 0)
			{
				// load summary progress by year
				GetSummaryJobInfoByYear();
				var _dal = new JobDAL();
				var dt = await _dal.GetProgressJobInfoAsync(WorkYear, WorkPeriod);

				// create summary row
				var dr = dt.NewRow();
				dr["DAY"] = "";
				dr["WORKDATE"] = "TOTAL";
				dr["BLOCK"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("BLOCK"));
				dr["WAX"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("WAX"));
				dr["FINISHING"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("FINISHING"));
				dr["TREE"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("TREE"));
				dr["CAST_GOOD"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("CAST_GOOD"));
				dr["CAST_BAD"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("CAST_BAD"));
				dr["TOTAL_CAST"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTAL_CAST"));

				// add summary row into main datatable
				dt.Rows.Add(dr);

				dgv.SuspendLayout();

				// map data into datagridview
				dgv.DataSource = dt;

				// format column header
				foreach (DataGridViewColumn dgc in dgv.Columns)
				{
					switch (dgc.Name)
					{
						case "WORKDATE":
							dgc.HeaderText = "วันทำงาน";
							break;
						case "BLOCK":
							dgc.HeaderText = "ทำก้อนยาง";
							break;
						case "WAX":
							dgc.HeaderText = "ฉีดเทียน";
							break;
						case "FINISHING":
							dgc.HeaderText = "แต่งเทียน";
							break;
						case "TREE":
							dgc.HeaderText = "ติดต้น";
							break;
						case "CAST_GOOD":
							dgc.HeaderText = "งานหล่อ-ดี";
							break;
						case "CAST_BAD":
							dgc.HeaderText = "งานหล่อ-เสีย";
							break;
						case "TOTAL_CAST":
							dgc.HeaderText = "รวมงานหล่อ";
							break;
					}

					if (dgc.ValueType.GetType() != typeof(string) || dgc.ValueType.GetType() != typeof(DateTime) ||
					    dgc.ValueType.GetType() != typeof(bool))
					{
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
						dgc.DefaultCellStyle.Format = "N0";
					}
				}
				dgv.Columns["DAY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				dgv.Columns["DAY"].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);

				dgv.Columns["WORKDATE"].Frozen = true;
				dgv.Columns["WORKDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

				dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

				dgv.ResumeLayout();

				// display status
				lbWorkDetailsByMonth.Text = string.Format("Year:{0} Month:{1} - {2} record(s)", WorkYear,
					WorkPeriod.GetMonthName(), dgv.Rows.Count);

				lbSummary.Text = string.Format("Summary by Worker (ทำก้อน / ฉีด / แต่ง) Month:{0} Year:{1} ",
					WorkPeriod.GetMonthName(), WorkYear);

				// loading relate display
				GetAVGProgressByMonth(_selectedPeriod, _selectedWorkYear);
			}
		} // end LoadJobProgress

		private async void GetWorkDetails(decimal WorkDate)
		{
			var _dal = new JobDAL();
			var _dt = await _dal.GetWorkDetailsByDayAsync(WorkDate);
			dgv2.SuspendLayout();

			// summary row
			// create summary row
			var dr = _dt.NewRow();
			dr[0] = "";
			dr["BLOCK"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("BLOCK"));
			dr["WAX"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("WAX"));
			dr["FINISHING"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("FINISHING"));
			dr["TREE"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("TREE"));
			dr["CAST_GOOD"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("CAST_GOOD"));
			dr["CAST_BAD"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("CAST_BAD"));
			dr["WORK_TOTAL"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("WORK_TOTAL"));

			// add summary row into main datatable
			//dt.Rows.Add(dr);

			// map data
			dgv2.DataSource = _dt;
			dgv2.Columns["OPERATORNAME"].HeaderText = "ชื่อพนักงาน";

			foreach (DataGridViewColumn dgc in dgv2.Columns)
				if (dgc.Name == "OPERATORNAME")
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				}
				else
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = "N0";

					switch (dgc.Name)
					{
						case "BLOCK":
							dgc.HeaderText = string.Format("ทำก้อนยาง = {0:N0}", dr["BLOCK"]);
							break;
						case "WAX":
							dgc.HeaderText = string.Format("ฉีดเทียน = {0:N0}", dr["WAX"]);
							break;
						case "FINISHING":
							dgc.HeaderText = string.Format("แต่งเทียน = {0:N0}", dr["FINISHING"]);
							break;
						case "TREE":
							dgc.HeaderText = string.Format("ติดต้น = {0:N0}", dr["TREE"]);
							break;
						case "CAST_GOOD":
							dgc.HeaderText = string.Format("งานหล่อ-ดี = {0:N0}", dr["CAST_GOOD"]);
							break;
						case "CAST_BAD":
							dgc.HeaderText = string.Format("งานหล่อ-เสีย = {0:N0}", dr["CAST_BAD"]);
							break;
						case "WORK_TOTAL":
							dgc.HeaderText = string.Format("รวม = {0:N0}", dr["WORK_TOTAL"]);
							break;
					}
				}
			dgv2.Columns["OPERATORNAME"].Frozen = true;
			dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgv2.ResumeLayout();
		} // end GetWorkDetails

		private async void GetSummaryJobInfoByYear()
		{
			var _dal = new JobDAL();

			// map data to datagridview
			dgvYearSum.SuspendLayout();
			dgvYearSum.DataSource = await _dal.GetSummaryJobInfoByYearAsync();
			dgvYearSum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

			// format datagridview
			foreach (DataGridViewColumn dgc in dgvYearSum.Columns)
				if (dgc.ValueType.GetType() != typeof(string) || dgc.ValueType.GetType() != typeof(DateTime) ||
				    dgc.ValueType.GetType() != typeof(bool))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = "N0";
				}
			dgvYearSum.Columns["YEAR"].Frozen = true;
			dgvYearSum.Columns["YEAR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dgvYearSum.ResumeLayout();

		} // end GetSummaryJobInfoByYear

		private void AddMonthButton()
		{
			ts.SuspendLayout();
			for (var i = 1; i <= 12; i++)
			{
				var _tsbtn = new ToolStripButton();
				_tsbtn.Text = i.GetMonthName();
				_tsbtn.Tag = i.ToString();
				_tsbtn.Click += tsbtn_Click;
				_tsbtn.MouseLeave += tsbtn_MouseLeave;

				ts.Items.Add(_tsbtn);
				ts.Items.Add(new ToolStripSeparator());
			}
			ts.ResumeLayout();
		} // end AddMonthButton

		private async void GetAVGProgressByMonth(int Period, int WorkYear)
		{
			var _dal = new JobDAL();

			var _dt = await _dal.GetAVGProgressByMonthAsync(Period, WorkYear);

			dgvAVG.SuspendLayout();
			dgvAVG.DataSource = _dt;

			// formatting datagridview
			dgvAVG.Columns["WORKER"].HeaderText = "ชื่อพนักงาน";
			dgvAVG.Columns["N"].Visible = false;
			dgvAVG.Columns["WORKER"].Frozen = true;

			dgvAVG.Columns["TOTAL"].HeaderText = "ยอดรวม";
			dgvAVG.Columns["TOTAL"].DefaultCellStyle.Format = "N0";
			dgvAVG.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dgvAVG.Columns["AVG"].HeaderText = "ยอดเฉลี่ยต่อเดือน";
			dgvAVG.Columns["AVG"].DefaultCellStyle.Format = "N2";
			dgvAVG.Columns["AVG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dgvAVG.Columns["PERFORMANCE"].HeaderText = " ผลงาน%";
			dgvAVG.Columns["PERFORMANCE"].DefaultCellStyle.Format = "P2";
			dgvAVG.Columns["PERFORMANCE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvAVG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

			dgvAVG.ResumeLayout();
		} // end GetAVGProgressByMonth

		private async void GetSummaryByWorker(int WorkYear)
		{
			var _dal = new JobDAL();
			var dt = await _dal.GetSummaryByWorkerAsync(WorkYear);

			dgvWorkSum.SuspendLayout();
			dgvWorkSum.DataSource = dt;
			dgvWorkSum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

			// format datagridview
			foreach (DataGridViewColumn dgc in dgvWorkSum.Columns)
				if (dgc.ValueType.GetType() != typeof(string) || dgc.ValueType.GetType() != typeof(DateTime) ||
				    dgc.ValueType.GetType() != typeof(bool))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = "N0";
				}
			dgvWorkSum.Columns["KEY"].HeaderText = "ชื่อพนักงาน";
			dgvWorkSum.Columns["KEY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dgvWorkSum.Columns["RATE"].DefaultCellStyle.Format = "P2";
			dgvWorkSum.Columns["RATE"].HeaderText = "ผลงาน";
			dgvWorkSum.Columns["RATE"].Frozen = true;

			dgvWorkSum.ResumeLayout();
		} // end GetSummaryByWorker

		#endregion
	}
}