using System;
using System.Data;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.SaleModel;
using OMW15.Shared;
using OMW15.Views.Reports;

namespace OMW15.Views.Sales
{
	public partial class SaleProformaList : Form
	{
		public SaleProformaList()
		{
			InitializeComponent();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			ProformaInfo(_selectedPIId = 0);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetProformaList(_selectedYearSale);
		}

		private void SaleProformaList_Load(object sender, EventArgs e)
		{
			// setting data grid view
			OMUtils.SettingDataGridView(ref dgv);

			// create year sale list
			CreateYearSaleList();
		}

		private void tscbxYearSale_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				GetProformaList((int) tscbxYearSale.ComboBox.SelectedValue);
			}
			catch
			{
				GetProformaList(DateTime.Today.Year);
			}
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			ProformaInfo(_selectedPIId);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedPIId = Convert.ToInt32(dgv["PIID", e.RowIndex].Value);
			lbPIIndex.Text = string.Format("idx:{0}", _selectedPIId);
			UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void tsbtnPrintPI_Click(object sender, EventArgs e)
		{
			var _rptv = new ReportView(PrintDocumentType.SalePI);
			_rptv.DocumentId = _selectedPIId;
			_rptv.MdiParent = ParentForm;
			_rptv.WindowState = FormWindowState.Maximized;
			_rptv.Show();
		}

		#region class field members

		private int _selectedPIId;
		private readonly int _selectedYearSale = DateTime.Today.Year;

		#endregion

		#region class properties

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			tsbtnEdit.Enabled = _selectedPIId > 0;
			tsbtnPrintPI.Enabled = tsbtnEdit.Enabled;
		} // end UpdateUI

		private void CreateYearSaleList()
		{
			tscbxYearSale.ComboBox.DataSource = new SaleDAL().GetPIYear();
			tscbxYearSale.ComboBox.DisplayMember = "PI_YEAR";
			tscbxYearSale.ComboBox.ValueMember = "PI_YEAR";

			if (((DataTable) tscbxYearSale.ComboBox.DataSource).Rows.Count > 0)
				tscbxYearSale.ComboBox.SelectedIndex = 0;
		} // end CreateYearSaleList

		private void GetProformaList(int YearSale)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new SaleDAL().GetPIList(YearSale);

			// format datagidview column
			dgv.Columns["PIID"].Visible = false;

			dgv.Columns["TOTAL_VALUES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["TOTAL_VALUES"].DefaultCellStyle.Format = "N2";

			dgv.Columns["PACKING"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["PACKING"].DefaultCellStyle.Format = "N2";

			dgv.Columns["DELIVERY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["DELIVERY"].DefaultCellStyle.Format = "N2";

			dgv.Columns["TOTAL_AMOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["TOTAL_AMOUNT"].DefaultCellStyle.Format = "N2";

			dgv.ResumeLayout();
			UpdateUI();
		} // end GetProformaList

		private void ProformaInfo(int PIId)
		{
			var _piInfo = new PIInfo(PIId);
			_piInfo.StartPosition = FormStartPosition.CenterScreen;
			if (_piInfo.ShowDialog() == DialogResult.OK)
			{
			}

			tsbtnRefresh.PerformClick();
		} // end ProformaInfo

		#endregion
	}
}