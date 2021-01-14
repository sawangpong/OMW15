using OMW15.Models.CastingModel;
using System;
using System.Data;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingPriceItemList : Form
	{
		#region class field

		private int _itemId = 0;
		private int _matId = 0;
		private int _yearSale = DateTime.Today.Year;
		private string _unitName = string.Empty;
		private string _matName = string.Empty;
		private int _selectdPriceListItem = 0;
		#endregion

		#region class property

		public decimal ItemPrice { get; set; }
		public decimal ItemPriceWithMat { get; set; }
		public int ItemPriceRowId { get; set; }

		//public bool IsMatInclude { get; set; }

		#endregion


		#region class helper

		private void UpdateUI()
		{
			btnSelect.Enabled = (_selectdPriceListItem > 0);
		}


		private void GetPriceTable(int itemId, int matId, int yearSale, string unitName)
		{
			//DataTable _dtPrice = new PriceListDAL().GetPriceTableById(itemId, matId, yearSale, unitName);
			DataTable _dtPrice = new PriceListDAL().GetPriceTableById(itemId, matId, unitName, yearSale);

			dgv.SuspendLayout();
			dgv.DataSource = _dtPrice;
			dgv.Columns["ID"].Visible = false;
			dgv.Columns["CPT_CP"].Visible = false;
			dgv.Columns["MATERIAL"].Visible = false;
			dgv.Columns["ISMATINCLUDE"].Visible = false;

			dgv.Columns["PRICE_YEAR"].HeaderText = "ปี";
			dgv.Columns["MATERIAL_NAME"].HeaderText = "วัสดุ";
			dgv.Columns["PRICEUNITNAME"].HeaderText = "หน่วยนับ";
			dgv.Columns["UNITPRICE"].HeaderText = "ราคาหล่อ/หน่วย";
			dgv.Columns["UNITPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["UNITPRICE_WITHMAT"].HeaderText = "ราคารวมวัสดุ/หน่วย";
			dgv.Columns["UNITPRICE_WITHMAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			//dgv.Columns["ISMATINCLUDE"].HeaderText = "ราคารวมวัสดุ";

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			dgv.ResumeLayout();

			UpdateUI();
		}
		#endregion

		//public CastingPriceItemList(int itemId,int matId,int yearSale, string unitName,string matName = "")
		public CastingPriceItemList(int itemId, int matId, string matName, string unitName)
		{
			InitializeComponent();
			_itemId = itemId;
			_matId = matId;
			//_yearSale = yearSale;
			_unitName = unitName;
			_matName = matName;

			lbMaterial.Text = $"{_matId} {_matName}";
			lbItemId.Text = $"{_itemId}";
			this.CenterToScreen();
			OMControls.OMUtils.SettingDataGridView(ref dgv);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectdPriceListItem = Convert.ToInt32(dgv["ID", e.RowIndex].Value.ToString());



			this.ItemPriceRowId = _selectdPriceListItem;
			this.ItemPrice = Convert.ToDecimal(dgv["UNITPRICE", e.RowIndex].Value.ToString());
			this.ItemPriceWithMat = Convert.ToDecimal(dgv["UNITPRICE_WITHMAT", e.RowIndex].Value.ToString());
			//this.IsMatInclude = Convert.ToBoolean(dgv["ISMATINCLUDE", e.RowIndex].Value);

			UpdateUI();
		}

		private void CastingPriceItemList_Load(object sender, EventArgs e)
		{
			_selectdPriceListItem = 0;
			GetPriceTable(_itemId, _matId, _yearSale, _unitName);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.ItemPriceRowId = 0;

		}
	}
}
