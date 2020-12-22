using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView
{
	public partial class MaterialPriceList : Form
	{
		// CONSTRUCTOR
		public MaterialPriceList(string Material, DateTime PriceDate)
		{
			InitializeComponent();
			_selectedMaterial = Material;
			_yearSale = PriceDate.Year;
			_monthSale = PriceDate.Month;
			dtpDuration.Value = DateTime.Today;
		}

		#region class property

		public decimal MaterialPrice { get; set; }

		#endregion

		private void MaterialPriceList_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);
			GetMaterialForSale();
		}

		private void cbxMat_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_selectedMaterialId = Convert.ToInt32(cbxMat.SelectedValue);
			}
			catch
			{
				_selectedMaterialId = 2; // SILVER 100%
			}

			GetMaterialPrice(_yearSale, _monthSale, _selectedMaterialId);
		}

		private void dtpDuration_ValueChanged(object sender, EventArgs e)
		{
			_yearSale = dtpDuration.Value.Year;
			_monthSale = dtpDuration.Value.Month;

			// update material price list
			GetMaterialPrice(_yearSale, _monthSale, _selectedMaterialId);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			MaterialPrice = Convert.ToDecimal(dgv["PRICETHGRAM", e.RowIndex].Value);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			MaterialPrice = 0.00m;
		}

		private void cbxMat_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedMaterialId = Convert.ToInt32(cbxMat.SelectedValue);
			}
			catch
			{
				_selectedMaterialId = 2;
			}
			GetMaterialPrice(_yearSale, _monthSale, _selectedMaterialId);
		}

		private void cbxMat_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		#region class field members

		private string _selectedMaterial = string.Empty;
		private int _selectedMaterialId = 2; // SILVER 100%
		private int _yearSale = DateTime.Today.Year;
		private int _monthSale = DateTime.Today.Month;

		#endregion

		#region class helper method

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetMaterialForSale()
		{
			cbxMat.DataSource = new MaterialDAL().GetMaterialForSaleList();
			cbxMat.DisplayMember = "MATNAME";
			cbxMat.ValueMember = "MATID";
		} // end GetMaterialForSale

		private void GetMaterialPrice(int YearSale, int MonthSale, int MaterialId)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new MaterialDAL().GetMaterialPriceRecords(YearSale, MonthSale, MaterialId);
			dgv.Columns["PRICETHGRAM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["PRICETHGRAM"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.Columns["PRICETHGRAM"].HeaderText = "Unit Price (THB/g)";
			dgv.Columns["PRICEDATE"].HeaderText = "DATE";
			dgv.ResumeLayout();
		} // end GetMaterialPrice

		#endregion
	}
}