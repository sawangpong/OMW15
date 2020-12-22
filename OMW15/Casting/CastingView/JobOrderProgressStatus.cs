using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingView
{
	public partial class JobOrderProgressStatus : Form
	{
		#region class field member

		int _selectedJobStatus = 0;

		#endregion


		#region class helper

		private void UpdateUI()
		{
			this.tsbtnLoadData.Enabled = (_selectedJobStatus > 0);

		} // end UpdateUI


		private void GetJobFG(int JobStatus)
		{
			// binding and update DataGridView
			this.dgv.SuspendLayout();

			this.dgv.DataSource = new OMW15.Casting.CastingController.JobDAL().GetJobFG(JobStatus);

			// formatting data grid view
			this.dgv.Columns["STATUS"].Visible = false;
			this.dgv.Columns["ORDERQTY"].Frozen = true;

			this.dgv.Columns["COMPLETE"].HeaderText = "Complete (%)";
			this.dgv.Columns["COMPLETE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dgv.Columns["COMPLETE"].DefaultCellStyle.Format = "P2";

			this.dgv.Columns["WAX"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["WAX"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["FINISHING"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["FINISHING"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["TREE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["TREE"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["CASTING"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["CASTING"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["ORDERQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["ORDERQTY"].DefaultCellStyle.Format = "N2";
			this.dgv.Columns["ORDERQTY"].DefaultCellStyle.BackColor = Color.Green;
			this.dgv.Columns["ORDERQTY"].DefaultCellStyle.ForeColor = Color.Yellow;

			this.dgv.Columns["REMAIN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["REMAIN"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["AVGWEIGHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["AVGWEIGHT"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["TOTALWEIGHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["TOTALWEIGHT"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["DELIVERYQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["DELIVERYQTY"].DefaultCellStyle.Format = "N2";

			//this.dgv.Columns["DELIVERYWEIGHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//this.dgv.Columns["DELIVERYWEIGHT"].DefaultCellStyle.Format = "N2";

			//this.FormattingDataGridView();
			this.ReDrawGridView();

			this.dgv.ResumeLayout();

			// display count record
			this.lbCount.Text = string.Format("found : {0} record{1}", this.dgv.Rows.Count, (this.dgv.Rows.Count > 1 ? "s" : ""));

		} // end GetJobFG

		private void ReDrawGridView()
		{
			this.dgv.SuspendLayout();
			foreach (DataGridViewColumn dgc in this.dgv.Columns)
			{
				if (dgc.Index <= this.dgv.Columns.Count - 2)
				{
					dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				}
				else
				{
					dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				}
			}
			this.dgv.ResumeLayout();

		} // end ReDrawGridView

		private void FormattingDataGridView()
		{
			// formatting datagridview
			this.dgv.SuspendLayout();
			foreach (DataGridViewColumn dgc in this.dgv.Columns)
			{
				if (this.dgv.Columns[dgc.Name].ValueType == typeof(System.Decimal))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = "N2";
				}
			}
			this.dgv.ResumeLayout();
		}

		private void CreateJobStatusMenus()
		{
			ToolStripMenuItem _mnu = new ToolStripMenuItem();
			_mnu.Text = "Active Job";
			_mnu.Tag = "1";
			_mnu.Click += new EventHandler(this.MenuJobStatusSelecttion);
			this.tsmnuJobStatus.DropDownItems.Add(_mnu);

			_mnu = new ToolStripMenuItem();
			_mnu.Text = "Completed Job";
			_mnu.Tag = "2";
			_mnu.Click += new EventHandler(this.MenuJobStatusSelecttion);
			this.tsmnuJobStatus.DropDownItems.Add(_mnu);

		} // end

		private void MenuJobStatusSelecttion(object sender, EventArgs e)
		{
			ToolStripMenuItem _mnu = sender as ToolStripMenuItem;
			this.tsmnuJobStatus.Text = string.Format("Job Status :: [{0}]", _mnu.Text);
			_selectedJobStatus = Convert.ToInt32(_mnu.Tag);
			this.UpdateUI();
			this.tsbtnLoadData.PerformClick();

		} // end MenuJobStatusSelecttion

		#endregion


		public JobOrderProgressStatus()
		{
			InitializeComponent();
		}

		private void JobOrderUpdateStatus_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.CreateJobStatusMenus();
			this.UpdateUI();
		}

		private void tsbtnLoadData_Click(object sender, EventArgs e)
		{
			this.GetJobFG(_selectedJobStatus);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void JobOrderUpdateStatus_Resize(object sender, EventArgs e)
		{
			this.ReDrawGridView();
		}
	}
}
