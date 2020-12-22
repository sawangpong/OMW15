using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class JobOrderProgressStatus : Form
	{

		#region class field member

		private int _rowCount;
		private int _selectedJobStatus = (int)OMShareJobEnums.JobStatusEnumEN.Active;
		private int _selectedYearClose = DateTime.Today.Year;

		#endregion


		// CONSTRUCTOR
		public JobOrderProgressStatus()
		{
			InitializeComponent();
			pnlHeader.BackColor = omglobal.OM_BLUE_COLOR;
		}

		private void JobOrderUpdateStatus_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);

			dgv.BorderStyle = BorderStyle.FixedSingle;

			CreateJobStatusMenus();
			_selectedJobStatus = (int)OMShareJobEnums.JobStatusEnumEN.Active;

			UpdateUI();
		}

		private void tsbtnLoadData_Click(object sender, EventArgs e)
		{
			GetJobFG(_selectedJobStatus);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void JobOrderUpdateStatus_Resize(object sender, EventArgs e)
		{
			ReDrawGridView();
		}

		private void tscbxCloseYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedYearClose = Convert.ToInt32(tscbxCloseYear.ComboBox.SelectedValue);
			}
			catch
			{
				_selectedYearClose = DateTime.Today.Year;
			}

			GetJobFG(_selectedJobStatus, _selectedYearClose);
		}

		private void txtJobNo_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtJobNo.Text))
				tsbtnLoadData.PerformClick();

			UpdateUI();
		}

		private void txtJobNo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				btnSearchJob.PerformClick();
		}

		private void btnSearchJob_Click(object sender, EventArgs e)
		{
			((DataTable)dgv.DataSource).DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", "JOBORDER",Convert.ToInt32(txtJobNo.Text));

			// update rows found
			UpdateUI();
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			var _font = new Font(dgv.Font, FontStyle.Bold);
			if (
				Convert.ToDecimal(dgv["COMPLETE", e.RowIndex].Value.ToString()
					.Substring(0, dgv["COMPLETE", e.RowIndex].Value.ToString().IndexOf("%"))) >= 80.0m)
			{
				e.CellStyle.Font = _font;
				e.CellStyle.ForeColor = Color.Yellow;
				e.CellStyle.BackColor = Color.DarkBlue;
			}
			else if (
				Convert.ToDecimal(dgv["COMPLETE", e.RowIndex].Value.ToString()
					.Substring(0, dgv["COMPLETE", e.RowIndex].Value.ToString().IndexOf("%"))) <= 10.0m)
			{
				e.CellStyle.Font = _font;
				e.CellStyle.ForeColor = Color.Yellow;
				e.CellStyle.BackColor = Color.Red;
			}
		}

		#region class helper

		private void UpdateUI()
		{
			tsbtnLoadData.Enabled = _selectedJobStatus > 0;
			tslbCloseYear.Visible = _selectedJobStatus == (int)OMShareJobEnums.JobStatusEnumEN.Closed;
			tscbxCloseYear.Visible = tslbCloseYear.Visible;
			tsSepCloseYear.Visible = tslbCloseYear.Visible;

			txtJobNo.Enabled = dgv.Rows.Count > 0;
			btnSearchJob.Enabled = !string.IsNullOrEmpty(txtJobNo.Text);

			// display count record
			lbCount.Text = $"found : {dgv.Rows.Count} record{(dgv.Rows.Count > 1 ? "s" : "")}";
		} // end UpdateUI


		private async void GetJobFG(int JobStatus, int YearClose = 0)
		{
			var dt = new DataTable();

			// binding and update DataGridView
			dgv.SuspendLayout();
			dgv.DataSource = null;

			var _dal = new JobDAL();

			dt = await (YearClose == 0 ? _dal.GetJobFGAsync(JobStatus) : _dal.GetJobFGAsync(JobStatus, YearClose));

			_rowCount = dt.Rows.Count;
			dgv.DataSource = dt;

			// formatting data grid view
			dgv.Columns["STATUS"].Visible = false;
			dgv.Columns["COMPLETE"].HeaderText = "Complete (%)";
			dgv.Columns["ORDERQTY"].DefaultCellStyle.BackColor = Color.Green;
			dgv.Columns["ORDERQTY"].DefaultCellStyle.ForeColor = Color.Yellow;

			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.ValueType == typeof(decimal))
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			ReDrawGridView();
			dgv.ResumeLayout();
			UpdateUI();
		} // end GetJobFG

		private void ReDrawGridView()
		{
			dgv.SuspendLayout();
			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.Index <= dgv.Columns.Count - 2)
					dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				else
					dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dgv.ResumeLayout();
		} // end ReDrawGridView

		private void FormattingDataGridView()
		{
			// formatting datagridview
			dgv.SuspendLayout();
			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgv.Columns[dgc.Name].ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = "N2";
				}
			dgv.ResumeLayout();
		}

		private void CreateJobStatusMenus()
		{
			var _mnu = new ToolStripMenuItem("Active Job");
			_mnu.Tag = (int)OMShareJobEnums.JobStatusEnumEN.Active;
			_mnu.Click += MenuJobStatusSelecttion;
			tsmnuJobStatus.DropDownItems.Add(_mnu);
		} // end

		private void MenuJobStatusSelecttion(object sender, EventArgs e)
		{
			var _mnu = sender as ToolStripMenuItem;
			_selectedJobStatus = Convert.ToInt32(_mnu.Tag);
			tsmnuJobStatus.Text = $"Job Status :: [{_mnu.Text}]";

			switch (_selectedJobStatus)
			{
				case (int)OMShareJobEnums.JobStatusEnumEN.Active:
					tsbtnLoadData.PerformClick();
					break;

				case (int)OMShareJobEnums.JobStatusEnumEN.Closed:
					break;
			}

			UpdateUI();
		} // end MenuJobStatusSelecttion

		#endregion
	}
}