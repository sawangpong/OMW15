using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingView
{
	public partial class CastingProgress : Form
	{
		#region class field member
		private decimal _selectedWorkDate = 0;
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
			//DataTable _dt = new DataTable();
			//using(OLDMOONEF om = new OLDMOONEF())
			//{
			//	var wy = (from y in om.JOBINFOS
			//			  select new
			//			  {
			//				  JOBYEAR= y.FISCYEAR.Value
			//			  }).Distinct().OrderByDescending(x => x.JOBYEAR).AsParallel();

			//	if(wy != null)
			//	{
			//		_dt = omdal.ToDataTable(wy.ToList());
			//	}
			//} // end

			//_dt.DefaultView.d.Sort = "FISCYEAR";

			this.tscbxWorkYear.ComboBox.DataSource = new Casting.CastingController.JobDAL().CreateJobYearList();
			this.tscbxWorkYear.ComboBox.DisplayMember = "JOBYEAR";
			this.tscbxWorkYear.ComboBox.ValueMember = "JOBYEAR";

		} // end GetWorkYear

		private void LoadJobProgress(int WorkYear, int WorkPeriod)
		{
			if (WorkYear > 0)
			{
				// load summary progress by year
				this.GetSummaryJobInfoByYear();

				DataTable dt = new Casting.CastingController.JobDAL().GetProgressJobInfos(WorkYear, WorkPeriod);

				// create summary row
				DataRow dr = dt.NewRow();
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

				this.dgv.SuspendLayout();

				// map data into datagridview
				this.dgv.DataSource = dt;

				// format column header
				foreach (DataGridViewColumn dgc in this.dgv.Columns)
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

					if ((dgc.ValueType.GetType() != typeof(System.String)) || (dgc.ValueType.GetType() != typeof(System.DateTime)) ||
						(dgc.ValueType.GetType() != typeof(System.Boolean)))
					{
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
						dgc.DefaultCellStyle.Format = "N0";
					}
				}
				this.dgv.Columns["DAY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				this.dgv.Columns["DAY"].DefaultCellStyle.Font = new Font(this.dgv.Font, FontStyle.Bold);

				this.dgv.Columns["WORKDATE"].Frozen = true;
				this.dgv.Columns["WORKDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

				this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

				this.dgv.ResumeLayout();

				// display status
				this.lbWorkDetailsByMonth.Text = string.Format("Year:{0} Month:{1} - {2} record(s)", WorkYear, OMControls.OMUtils.GetMonthName(WorkPeriod), this.dgv.Rows.Count);

				this.lbSummary.Text = string.Format("Summary by Worker (ทำก้อน / ฉีด / แต่ง) Month:{0} Year:{1} ", OMControls.OMUtils.GetMonthName(WorkPeriod), WorkYear);

				// loading relate display
				// load 
				this.GetAVGProgressByMonth(_selectedPeriod, _selectedWorkYear);

			}

		} // end LoadJobProgress

		private void GetWorkDetails(decimal WorkDate)
		{
			DataTable _dt = new Casting.CastingController.JobDAL().GetWorkDetailsByDay(WorkDate);
			this.dgv2.SuspendLayout();

			// summary row
			// create summary row
			DataRow dr = _dt.NewRow();
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
			this.dgv2.DataSource = _dt;
			this.dgv2.Columns["OPERATORNAME"].HeaderText = "ชื่อพนักงาน";

			foreach (DataGridViewColumn dgc in this.dgv2.Columns)
			{
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
			}
			this.dgv2.Columns["OPERATORNAME"].Frozen = true;
			this.dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgv2.ResumeLayout();


		} // end GetWorkDetails

		private void GetSummaryJobInfoByYear()
		{
			this.dgvYearSum.SuspendLayout();

			// map data to datagridview
			this.dgvYearSum.DataSource = new Casting.CastingController.JobDAL().GetSummaryJobInfoByYear();

			this.dgvYearSum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

			// format datagridview
			foreach (DataGridViewColumn dgc in this.dgvYearSum.Columns)
			{
				if ((dgc.ValueType.GetType() != typeof(System.String)) || (dgc.ValueType.GetType() != typeof(System.DateTime)) ||
					(dgc.ValueType.GetType() != typeof(System.Boolean)))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = "N0";
				}
			}
			this.dgvYearSum.Columns["YEAR"].Frozen = true;
			this.dgvYearSum.Columns["YEAR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


			this.dgvYearSum.ResumeLayout();

		} // end GetSummaryJobInfoByYear

		private void AddMonthButton()
		{
			this.ts.SuspendLayout();
			for (int i = 1; i <= 12; i++)
			{
				ToolStripButton _tsbtn = new ToolStripButton();
				_tsbtn.Text = OMControls.OMUtils.GetMonthName(i);
				_tsbtn.Tag = i.ToString();
				_tsbtn.Click += new EventHandler(this.tsbtn_Click);
				_tsbtn.MouseLeave += new System.EventHandler(this.tsbtn_MouseLeave);

				this.ts.Items.Add(_tsbtn);
				this.ts.Items.Add(new ToolStripSeparator());
			}
			this.ts.ResumeLayout();

		} // end AddMonthButton

		private void GetAVGProgressByMonth(int Period, int WorkYear)
		{
			DataTable _dt = new Casting.CastingController.JobDAL().GetAVGProgressByMonth(Period, WorkYear);

			this.dgvAVG.SuspendLayout();
			this.dgvAVG.DataSource = _dt;

			// formatting datagridview
			this.dgvAVG.Columns["WORKER"].HeaderText = "ชื่อพนักงาน";
			this.dgvAVG.Columns["N"].Visible = false;
			this.dgvAVG.Columns["WORKER"].Frozen = true;

			this.dgvAVG.Columns["TOTAL"].HeaderText = "ยอดรวม";
			this.dgvAVG.Columns["TOTAL"].DefaultCellStyle.Format = "N0";
			this.dgvAVG.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			this.dgvAVG.Columns["AVG"].HeaderText = "ยอดเฉลี่ยต่อเดือน";
			this.dgvAVG.Columns["AVG"].DefaultCellStyle.Format = "N2";
			this.dgvAVG.Columns["AVG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			this.dgvAVG.Columns["PERFORMANCE"].HeaderText = " ผลงาน%";
			this.dgvAVG.Columns["PERFORMANCE"].DefaultCellStyle.Format = "P2";
			this.dgvAVG.Columns["PERFORMANCE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgvAVG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

			this.dgvAVG.ResumeLayout();

		} // end GetAVGProgressByMonth

		private void GetSummaryByWorker(int WorkYear)
		{
			this.dgvWorkSum.SuspendLayout();

			DataTable dt = new Casting.CastingController.JobDAL().GetSummaryByWorker(WorkYear);
			//dt.DefaultView.Sort = "RATE";
			this.dgvWorkSum.DataSource = dt;

			this.dgvWorkSum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

			// format datagridview
			foreach (DataGridViewColumn dgc in this.dgvWorkSum.Columns)
			{
				if ((dgc.ValueType.GetType() != typeof(System.String)) || (dgc.ValueType.GetType() != typeof(System.DateTime)) ||
					(dgc.ValueType.GetType() != typeof(System.Boolean)))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = "N0";
				}
			}
			this.dgvWorkSum.Columns["KEY"].HeaderText = "ชื่อพนักงาน";
			this.dgvWorkSum.Columns["KEY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			this.dgvWorkSum.Columns["RATE"].DefaultCellStyle.Format = "P2";
			this.dgvWorkSum.Columns["RATE"].HeaderText = "ผลงาน";
			this.dgvWorkSum.Columns["RATE"].Frozen = true;

			this.dgvWorkSum.ResumeLayout();

		} // end GetSummaryByWorker

		#endregion

		public CastingProgress()
		{
			InitializeComponent();
		}

		private void CastingProgress_Load(object sender, EventArgs e)
		{
			// setting All DataGridView Control
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			OMControls.OMUtils.SettingDataGridView(ref this.dgv2);
			OMControls.OMUtils.SettingDataGridView(ref this.dgvAVG);
			OMControls.OMUtils.SettingDataGridView(ref this.dgvYearSum);
			OMControls.OMUtils.SettingDataGridView(ref this.dgvWorkSum);

			this.GetWorkYear();
			this.AddMonthButton();

			this.dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
		}

		private void tsbtn_Click(object sender, EventArgs e)
		{
			ToolStripButton _btn = sender as ToolStripButton;
			_btn.Font = new System.Drawing.Font(_btn.Font, FontStyle.Bold | FontStyle.Underline);
			_selectedPeriod = Convert.ToInt32(_btn.Tag.ToString());

			// call method
			this.LoadJobProgress(_selectedWorkYear, _selectedPeriod);

		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tsbtn_MouseLeave(object sender, EventArgs e)
		{
			ToolStripButton _btn = sender as ToolStripButton;
			_btn.Font = new System.Drawing.Font(_btn.Font, FontStyle.Regular);

		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedWorkDate = OMControls.OMUtils.Date2Num(this.dgv["WORKDATE", e.RowIndex].Value);

			this.GetWorkDetails(_selectedWorkDate);

			this.lbWorkDetailByDay.Text = string.Format("Details for date {0}", OMControls.OMUtils.Num2Date(_selectedWorkDate).ToShortDateString());
		}

		private void tscbxWorkYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tscbxWorkYear.ComboBox.SelectedValue.GetType() == typeof(System.Int32))
			{
				_selectedWorkYear = Convert.ToInt32(this.tscbxWorkYear.ComboBox.SelectedValue);

				// call method
				this.LoadJobProgress(_selectedWorkYear, _selectedPeriod);
			}
			else
			{
				//_selectedWorkYear = DateTime.Today.Year;
			}
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (this.dgv["WORKDATE", e.RowIndex].Value.ToString() == "TOTAL")
			{
				e.CellStyle.BackColor = Color.Red;
				e.CellStyle.ForeColor = Color.Yellow;
				e.CellStyle.Font = new Font(this.dgv.Font, FontStyle.Bold);
			}
		}

		private void dgvYearSum_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectSummaryWorkYear = Convert.ToInt32(this.dgvYearSum["YEAR", e.RowIndex].Value);

			this.lbWorkSummaryByYWorker.Text = string.Format("ยอดสะสม (ทำก้อน /ฉีด / แต่ง) in Year : [{0}]", _selectSummaryWorkYear);

			// loading
			this.GetSummaryByWorker(_selectSummaryWorkYear);
		}

		private void dgv_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (this.dgv["DAY", e.RowIndex].Value.ToString().ToUpper() == "SUN")
			{
				e.CellStyle.BackColor = Color.Red;
				e.CellStyle.ForeColor = Color.White;
			}
		}

		private void btnChart_Click(object sender, EventArgs e)
		{
			Casting.CastingView.CastingPerformanceCharts ps = new CastingPerformanceCharts();
			ps.WorkYear = _selectedWorkYear;
			ps.WorkPeriod = _selectedPeriod;

			ps.StartPosition = FormStartPosition.CenterScreen;
			ps.MdiParent = this.ParentForm;

			ps.Show();
		}

	}
}
