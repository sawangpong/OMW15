using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView
{
	public partial class MaterialCost : Form
	{
		public MaterialCost()
		{
			InitializeComponent();
		}

		private void MaterialCost_Load(object sender, EventArgs e)
		{
			CenterToParent();
			// formatting DataGridView
			OMUtils.SettingDataGridView(ref dgvMatPrice);
			OMUtils.SettingDataGridView(ref dgvAVGPrice);

			// loading data
			GetMaterialYearSale();
			GetMaterialList();

			UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tscbxMaterial_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tscbxMaterial.ComboBox.SelectedValue.GetType() == typeof(int))
				_selectedMaterialId = int.Parse(tscbxMaterial.ComboBox.SelectedValue.ToString());
			else _selectedMaterialId = 0;

			// display selected material
			lbTitle.Text = $"ราคาขาย {(_selectedMaterialId > 0 ? tscbxMaterial.ComboBox.Text.Trim() : string.Empty)} รายวัน";

			// call functions
			GetMaterialPriceDetails(_selectedYearSale, _selectedMaterialId);
			GetMaterialPriceAVGByYear(_selectedYearSale, _selectedMaterialId);
			GetMaterialPriceAVGByMonth(_selectedYearSale, _selectedMaterialId);
		}

		private void tscbxYearSale_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tscbxYearSale.ComboBox.SelectedValue.GetType() == typeof(int))
				_selectedYearSale = int.Parse(tscbxYearSale.ComboBox.SelectedValue.ToString());
			else _selectedYearSale = DateTime.Today.Year;

			// call functions
			GetMaterialPriceAVGByYear(_selectedYearSale, _selectedMaterialId);
			GetMaterialPriceAVGByMonth(_selectedYearSale, _selectedMaterialId);
		}

		private void dgvMatPrice_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedMatPriceId = Convert.ToInt32(dgvMatPrice["SEQ", e.RowIndex].Value);
			lbId.Text = $"Id:({_selectedMatPriceId})";
			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			// call functions
			GetMaterialPriceDetails(_selectedYearSale, _selectedMaterialId);
			GetMaterialPriceAVGByYear(_selectedYearSale, _selectedMaterialId);
			GetMaterialPriceAVGByMonth(_selectedYearSale, _selectedMaterialId);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedMatPriceId = 0;
			AddEditMaterialPriceInfo(_selectedMatPriceId);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			AddEditMaterialPriceInfo(_selectedMatPriceId);
		}

		#region class filed member

		private int _selectedMaterialId;
		private int _selectedYearSale = DateTime.Today.Year;
		private int _selectedMatPriceId = 0;

		#endregion

		#region class property

		#endregion

		#region class Helper

		private void UpdateUI()
		{
			tsbtnEdit.Enabled = _selectedMatPriceId > 0;
			tsbtnRefresh.Enabled = dgvMatPrice.Rows.Count > 0;
		} // end UpdateUI

		private void GetMaterialList()
		{
			tscbxMaterial.ComboBox.DataSource = new MaterialDAL().GetMaterialForSaleList();
			tscbxMaterial.ComboBox.DisplayMember = "MATNAME";
			tscbxMaterial.ComboBox.ValueMember = "MATID";
		} // end GetMaterialList

		private void GetMaterialYearSale()
		{
			tscbxYearSale.ComboBox.DataSource = new MaterialDAL().GetMaterialYearSale();
			tscbxYearSale.ComboBox.DisplayMember = "FISCYEAR";
			tscbxYearSale.ComboBox.ValueMember = "FISCYEAR";
		} // end GetMaterialYearSale

		private void GetMaterialPriceAVGByYear(int YearSale, int MaterialId)
		{
			lbYearAVGMatPrice.Text = $"{new MaterialDAL().GetMaterialPriceAvgByYear(YearSale, MaterialId):N2}";
		} // end GetMaterialPriceAVGByYear

		private void GetMaterialPriceAVGByMonth(int YearSale, int MaterialId)
		{
			// binding data
			dgvAVGPrice.DataSource = new MaterialDAL().GetMaterialPriceAVGByMonth(YearSale, MaterialId);

			// format dataGridView
			dgvAVGPrice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvAVGPrice.Columns["YAVG"].HeaderText = "Average Price";
			dgvAVGPrice.Columns["YAVG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
			dgvAVGPrice.Columns["YAVG"].DefaultCellStyle.Format = "N2";
		} // end GetMaterialPriceAVGByMonth

		private void GetMaterialPriceDetails(int YearSale, int MaterialId)
		{
			// binding Data
			dgvMatPrice.DataSource = new MaterialDAL().GetMaterialPriceRecords(YearSale, MaterialId);

			// setting format
			dgvMatPrice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvMatPrice.Columns["SEQ"].Visible = false;

			dgvMatPrice.Columns["PRICEDATE"].HeaderText = "Date Effective";
			dgvMatPrice.Columns["PRICEDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			dgvMatPrice.Columns["PRICETHGRAM"].HeaderText = "Unit Price (THB)/g";
			dgvMatPrice.Columns["PRICETHGRAM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvMatPrice.Columns["PRICETHGRAM"].DefaultCellStyle.Format = "N2";

			// display the records count
			lbRecordCount.Text = $"found : ({dgvMatPrice.Rows.Count})";
		} // end GetMaterialPriceDetails

		private void AddEditMaterialPriceInfo(int RecordId)
		{
			var _matPriceInfo = new MaterialPriceInfo();
			_matPriceInfo.MatPriceRecordId = RecordId;
			_matPriceInfo.StartPosition = FormStartPosition.CenterScreen;

			if (_matPriceInfo.ShowDialog(this) == DialogResult.OK) tsbtnRefresh.PerformClick();
		} // end AddEditMaterialPriceInfo

		#endregion
	}
}