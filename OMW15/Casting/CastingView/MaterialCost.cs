using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingView
{
	public partial class MaterialCost : Form
	{
		#region class filed member

		private int _selectedMaterialId = 0;
		private int _selectedYearSale = DateTime.Today.Year;
		private int _selectedMatPriceId = 0;


		#endregion

		#region class property

		#endregion

		#region class Helper

		private void UpdateUI()
		{
			this.tsbtnEdit.Enabled = (_selectedMatPriceId > 0);
			this.tsbtnRefresh.Enabled = (this.dgvMatPrice.Rows.Count > 0);

		} // end UpdateUI

		private void GetMaterialList()
		{
			this.tscbxMaterial.ComboBox.DataSource = new OMW15.Casting.CastingController.MaterialDAL().GetMaterialForSaleList();
			this.tscbxMaterial.ComboBox.DisplayMember = "MATNAME";
			this.tscbxMaterial.ComboBox.ValueMember = "MATID";

		} // end GetMaterialList

		private void GetMaterialYearSale()
		{
			this.tscbxYearSale.ComboBox.DataSource = new OMW15.Casting.CastingController.MaterialDAL().GetMaterialYearSale();
			this.tscbxYearSale.ComboBox.DisplayMember = "FISCYEAR";
			this.tscbxYearSale.ComboBox.ValueMember = "FISCYEAR";

		} // end GetMaterialYearSale

		private void GetMaterialPriceAVGByYear(int YearSale, int MaterialId)
		{
			this.lbYearAVGMatPrice.Text = string.Format("{0:N2}", new OMW15.Casting.CastingController.MaterialDAL().GetMaterialPriceAVGByYear(YearSale, MaterialId));

		} // end GetMaterialPriceAVGByYear

		private void GetMaterialPriceAVGByMonth(int YearSale, int MaterialId)
		{
			// binding data
			this.dgvAVGPrice.DataSource = new OMW15.Casting.CastingController.MaterialDAL().GetMaterialPriceAVGByMonth(YearSale, MaterialId);

			// format dataGridView
			this.dgvAVGPrice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvAVGPrice.Columns["YAVG"].HeaderText = "Average Price";
			this.dgvAVGPrice.Columns["YAVG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
			this.dgvAVGPrice.Columns["YAVG"].DefaultCellStyle.Format = "N2";

		} // end GetMaterialPriceAVGByMonth

		private void GetMaterialPriceDetails(int YearSale, int MaterialId)
		{
			// binding Data
			this.dgvMatPrice.DataSource = new OMW15.Casting.CastingController.MaterialDAL().GetMaterialPriceRecords(YearSale, MaterialId);

			// setting format
			this.dgvMatPrice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvMatPrice.Columns["SEQ"].Visible = false;

			this.dgvMatPrice.Columns["PRICEDATE"].HeaderText = "Date Effective";
			this.dgvMatPrice.Columns["PRICEDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//this.dgvMatPrice.Columns["PRICEDATE"].DefaultCellStyle.Format = "####-##-##";

			this.dgvMatPrice.Columns["PRICETHGRAM"].HeaderText = "Unit Price (THB)/g";
			this.dgvMatPrice.Columns["PRICETHGRAM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgvMatPrice.Columns["PRICETHGRAM"].DefaultCellStyle.Format = "N2";

			// display the records count
			this.lbRecordCount.Text = string.Format("found : ({0})", this.dgvMatPrice.Rows.Count);

		} // end GetMaterialPriceDetails

		private void AddEditMaterialPriceInfo(int RecordId)
		{
			OMW15.Casting.CastingView.MaterialPriceInfo _matPriceInfo = new MaterialPriceInfo();
			_matPriceInfo.MatPriceRecordId = RecordId;
			_matPriceInfo.StartPosition = FormStartPosition.CenterScreen;
			
			if(_matPriceInfo.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				this.tsbtnRefresh.PerformClick();
			}

		} // end AddEditMaterialPriceInfo

		#endregion


		public MaterialCost()
		{
			InitializeComponent();
		}

		private void MaterialCost_Load(object sender, EventArgs e)
		{
			// formatting DataGridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgvMatPrice);
			OMControls.OMUtils.SettingDataGridView(ref this.dgvAVGPrice);

			// loading data
			this.GetMaterialYearSale();
			this.GetMaterialList();

			this.UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tscbxMaterial_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tscbxMaterial.ComboBox.SelectedValue.GetType() == typeof(System.Int32))
			{
				_selectedMaterialId = Convert.ToInt32(this.tscbxMaterial.ComboBox.SelectedValue.ToString());
			}
			else
			{
				_selectedMaterialId = 0;
			}

			// display selected material
			this.lbTitle.Text = string.Format("ราคาขาย {0} รายวัน", _selectedMaterialId > 0 ? this.tscbxMaterial.ComboBox.Text.Trim() : string.Empty);

			// call functions
			this.GetMaterialPriceDetails(_selectedYearSale, _selectedMaterialId);
			this.GetMaterialPriceAVGByYear(_selectedYearSale, _selectedMaterialId);
			this.GetMaterialPriceAVGByMonth(_selectedYearSale, _selectedMaterialId);

		}

		private void tscbxYearSale_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tscbxYearSale.ComboBox.SelectedValue.GetType() == typeof(System.Int32))
			{
				_selectedYearSale = Convert.ToInt32(this.tscbxYearSale.ComboBox.SelectedValue.ToString());
			}
			else
			{
				_selectedYearSale = DateTime.Today.Year;
			}

			// call functions
			this.GetMaterialPriceAVGByYear(_selectedYearSale, _selectedMaterialId);
			this.GetMaterialPriceAVGByMonth(_selectedYearSale, _selectedMaterialId);
		}

		private void dgvMatPrice_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedMatPriceId = Convert.ToInt32(this.dgvMatPrice["SEQ", e.RowIndex].Value);
			this.lbId.Text = string.Format("Id:({0})", _selectedMatPriceId);

			this.UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			// call functions
			this.GetMaterialPriceDetails(_selectedYearSale, _selectedMaterialId);
			this.GetMaterialPriceAVGByYear(_selectedYearSale, _selectedMaterialId);
			this.GetMaterialPriceAVGByMonth(_selectedYearSale, _selectedMaterialId);

		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedMatPriceId = 0;
			this.AddEditMaterialPriceInfo(_selectedMatPriceId);

		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			this.AddEditMaterialPriceInfo(_selectedMatPriceId);
		}
	}
}
