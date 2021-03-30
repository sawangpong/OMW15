using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMW15.Models.ProductionModel;

namespace OMW15.Views.Productions.ProductionUserControl
{
	public partial class MissReportControl : UserControl
	{
		#region class helper

		private void GetMissReportList()
		{
			dgv.SuspendLayout();
			dgv.DataSource = new ProductionDAL().GetProductionMissReport();
			dgv.Columns["EMPCODE"].Visible = false;
			dgv.Columns["fname"].HeaderText = "ชื่อพนักงาน";
			dgv.Columns["fname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["nday"].HeaderText = "จำนวนวัน";
			dgv.Columns["nday"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.ResumeLayout();

		}

		#endregion

		public MissReportControl()
		{
			InitializeComponent();

			GetMissReportList();
		}
	}
}
