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
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class STDPriceList : Form
	{
		#region class field
		private ActionMode mode = ActionMode.None;
		private string codeFilter = "";
		private string nameFilter = "";
		private int selectedSearchCat = 0;

		#endregion

		#region class property
		public string PartNo
		{
			get; set;
		}

		public string PartName
		{
			get; set;
		}

		public string Unit
		{
			get; set;
		}

		public decimal ThUnitCost
		{
			get; set;
		}
		public decimal ThUnitPrice
		{
			get; set;
		}

		public Image ItemImage
		{
			get; set;
		}

		#endregion

		#region class helper

		private void updateUI()
		{
			pnlCommand.Visible = (mode == ActionMode.Selection);
			tsbtnClose.Visible = !pnlCommand.Visible;
			tsSepClose.Visible = tsbtnClose.Visible;

			if(selectedSearchCat == (int)Shared.OMShareSaleEnum.PriceListItemFilterCategory.AllCategory)
			{
				txtFilter.Enabled = false;
				btnSearch.Enabled = true;
			}
			else
			{
				txtFilter.Enabled = true;
				btnSearch.Enabled = !string.IsNullOrEmpty(txtFilter.Text);
			}

		} // end UpdateUI

		private void createFilterList()
		{
			cbxSearchCat.DataSource = EnumWithName<Shared.OMShareSaleEnum.PriceListItemFilterCategory>.ParseEnum().ToDataTable();
			cbxSearchCat.DisplayMember = "Name";
			cbxSearchCat.ValueMember = "Value";
			cbxSearchCat.SelectedIndex = 0;
		}


		private void loadErpPriceList(string codeFilter, string nameFilter)
		{
			dgv.SuspendLayout();

			dgv.DataSource = new Models.SaleModel.ERPPriceDAL().getErpPriceList(codeFilter, nameFilter);

			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if(dgc.ValueType == typeof(System.Decimal))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.NumericCellStyle();
				}
			}

			dgv.Columns["StockKey"].Visible = false;
			dgv.Columns["GoodsKey"].Visible = false;
			dgv.Columns["StockUnit"].Visible = false;
			dgv.Columns["MasterUnit"].Visible = false;
			dgv.Columns["UnitFactor"].Visible = false;

			dgv.ResumeLayout();

			lbCount.Text = $"found : {dgv.Rows.Count}";
		}

		#endregion


		public STDPriceList(ActionMode Mode = ActionMode.View,
			OMShareWarehouseEnums.StockAppCall App = OMShareWarehouseEnums.StockAppCall.StockMaster)
		{
			InitializeComponent();
			mode = Mode;
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void STDPriceList_Load(object sender, EventArgs e)
		{
			CenterToParent();
			// setting
			OMControls.OMUtils.SettingDataGridView(ref dgv);

			// create filter list
			createFilterList();

			updateUI();

		}

		private void tsbtnLoad_Click(object sender, EventArgs e)
		{
			//loadErpPriceList();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			switch(selectedSearchCat)
			{
				case (int)Shared.OMShareSaleEnum.PriceListItemFilterCategory.AllCategory:
					codeFilter = "";
					nameFilter = "";
					break;
				case (int)Shared.OMShareSaleEnum.PriceListItemFilterCategory.ByItemName:
					codeFilter = "";
					nameFilter = txtFilter.Text;
					break;
				case (int)Shared.OMShareSaleEnum.PriceListItemFilterCategory.ByItemNo:
					codeFilter = txtFilter.Text;
					nameFilter = "";
					break;
			}

			loadErpPriceList(codeFilter, nameFilter);
		}

		private void txtFilter_TextChanged(object sender, EventArgs e)
		{
			updateUI();
		}

		private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
			{
				btnSearch.PerformClick();
			}
		}

		private void cbxSearchCat_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				selectedSearchCat = Convert.ToInt32(cbxSearchCat.SelectedValue);
			}
			catch
			{
				selectedSearchCat = 0;
			}

			lbSearchTitle.Text = $"ค้นหา:({selectedSearchCat})";

			updateUI();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			this.PartNo = dgv["PartNo", e.RowIndex].Value.ToString();
			this.PartName = dgv["PartName", e.RowIndex].Value.ToString();
			this.Unit = dgv["Unit", e.RowIndex].Value.ToString();
			this.ThUnitCost = Convert.ToDecimal(dgv["UnitCostTH", e.RowIndex].Value);
			this.ThUnitPrice = Convert.ToDecimal(dgv["UnitPriceTH", e.RowIndex].Value);
			this.ItemImage = pic.Image = new Models.WarehouseModel.WHDDAL().getItemMasterImage(this.PartNo);


		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}
	}
}
