using OMControls;
using OMW15.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.EmployeeView
{
	public partial class Hourcost : Form
	{
		#region class helper
		private void UpdateUI()
		{

		}

		private async void GetProductionHourCostAsync()
		{
			dgv.SuspendLayout();

			dgv.DataSource = await new EmployeeDAL().GetProductionAvgCostHourAsync();

			dgv.Columns["DayAvgHourCost"].HeaderText = "Avg Cost - daily base";
			dgv.Columns["DayAvgHourCost"].DefaultCellStyle.Format = "N2";
			dgv.Columns["DayAvgHourCost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dgv.Columns["MonthAvgHourCost"].HeaderText = "Avg Cost - monthly base";
			dgv.Columns["MonthAvgHourCost"].DefaultCellStyle.Format = "N2";
			dgv.Columns["MonthAvgHourCost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dgv.Columns["MonthActualAvgHourCost"].HeaderText = "Actual Avg Cost - monthly base";
			dgv.Columns["MonthActualAvgHourCost"].DefaultCellStyle.Format = "N2";
			dgv.Columns["MonthActualAvgHourCost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


			dgv.ResumeLayout();

			tssCount.Text = $"found: {dgv.Rows.Count}";
		}

		#endregion


		public Hourcost()
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgv);
		}

		private void Hourcost_Load(object sender, EventArgs e)
		{
			CenterToParent();

			GetProductionHourCostAsync();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
