using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ProductionModel;

namespace OMW15.Views.Productions
{
	public partial class Prdprocess : Form
	{
		#region class field member

		private int _rowCount;
		private int _selectedProductionProcessId;

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			tsbtnEdit.Enabled = (_selectedProductionProcessId > 0);
			tsbtnDelete.Enabled = tsbtnEdit.Enabled;

			lbCount.Text = $"found : {_rowCount}";
		} // end UpdateUI


		private void GetProcessList()
		{
			var dt = new ProductionDAL().GetProductionProcessList();

			_rowCount = dt.Rows.Count;

			dgv.SuspendLayout();
			dgv.DataSource = dt;
			dgv.Columns["PRDPROCESSID"].Visible = false;
			dgv.Columns["PROCESSNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["PROCESSNAME"].HeaderText = "ขั้นตอนการผลิต";
			dgv.Columns["MACHINE"].HeaderText = "เครื่องจักร";
			dgv.Columns["SCORE"].HeaderText = "คะแนน";
			dgv.Columns["SCORE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dgv.ResumeLayout();


			UpdateUI();
		} // end GetProcessList


		private void DeleteProcess(int ProductionProcessId)
		{
			if (
				MessageBox.Show("Do you want to delete the selected record?", "Delete", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
				if (new ProductionDAL().DeleteProductionProcess(ProductionProcessId) > 0)
					MessageBox.Show("Delete the selected record complete....", "Message", MessageBoxButtons.OK,
						MessageBoxIcon.Information);
		} // end DeleteProcess

		private void GetProductionProcessInfo(int ProductionProcessId)
		{
			using (var pinfo = new ProductionProcessInfo(ProductionProcessId))
			{
				pinfo.StartPosition = FormStartPosition.CenterScreen;
				pinfo.ShowDialog();
			}


			tsbtnRefresh.PerformClick();
		} // end GetProductionProcessInfo

		#endregion

		public Prdprocess()
		{
			InitializeComponent();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Prdprocess_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);

			GetProcessList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_rowCount == dgv.Rows.Count)
			{
				_selectedProductionProcessId = Convert.ToInt32(dgv["PRDPROCESSID", e.RowIndex].Value);
			}
			else
			{
				_selectedProductionProcessId = 0;
			}

			// display index
			lbIndex.Text = string.Format("Idx : {0}", _selectedProductionProcessId);

			UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			DeleteProcess(_selectedProductionProcessId);

			tsbtnRefresh.PerformClick();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetProcessList();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			GetProductionProcessInfo(_selectedProductionProcessId = 0);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			GetProductionProcessInfo(_selectedProductionProcessId);
		}

	


	}
}