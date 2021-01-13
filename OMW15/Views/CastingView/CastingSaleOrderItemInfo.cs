using Microsoft.VisualBasic;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingSaleOrderItemInfo : Form
	{
		#region class field member

		private SOLINE _sl;
		private readonly ActionMode _headerMode = ActionMode.None;
		private readonly ActionMode _itemMode = ActionMode.None;
		private decimal _vatFactor;
		private int _selectedMatId;
		private int _itemId;
		private int _soId;
		private int _refId;

		// variable for Item-Code
		private string _value = string.Empty;
		private string _code = string.Empty;
		private int _id;

		private bool _notFoundCastingPriceItem = false;
		private int _selectPriceTableRowId = 0;
	

		#endregion

		#region class property

		public int SOLineId { get; set; }

		public int CustomerId { get; set; }

		public string CustomerCode { get; set; }

		public int SaleOrderId { get; set; }

		public string SaleOrderNumber { get; set; }

		public DateTime OrderDate { get; set; }

		public OMShareCastingEnums.SaleTypeEnum SaleType { get; set; }

		public int MaterialId { get; set; }

		public string MaterialName { get; set; }

		public string MaterialCategory { get; set; }

		public string VATRate { get; set; }

		public decimal VATFactor { get; set; }

		public decimal TotalWeight { get; set; }

		public int  PriceListItemId { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnItemNo.Visible = SaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ;
			cbxMaterial.Enabled = btnItemNo.Enabled;
			//btnUnitPrice.Visible = (SaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ	 && !string.IsNullOrEmpty(lbItemNo.Text));
			pic.Visible = !btnUnitPrice.Visible;
			lbPrefix.Visible = pic.Visible;
			pnlMaterial.Visible = pic.Visible;
			lbFGOnHand.Visible = pic.Visible;
			lbFGStockQvailableQty.Visible = pic.Visible;
		} // end UpdateUI

		private void GetMaterial(string CustomerCode)
		{
			if (SaleType != OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
			{
				cbxMaterial.DataSource = new CastingSaleOrderDAL().GetAvailableMaterialForCastingOrderByCustomer(CustomerCode);
				cbxMaterial.DisplayMember = "MATNAME";
				cbxMaterial.ValueMember = "MATID";
				cbxMaterial.SelectedIndex = 0;
			}
		} // end GetMaterial


		private void GetSOLineItemDetail(int Id)
		{
			_sl = new SOLINE();
			if (Id == 0)
			{
				_sl.SALETYPE = (int)SaleType;
				_sl.ITEMID = MaterialId;
				_sl.PREFIX = "";
				_sl.DELIVEREDQTY = (SaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ ? TotalWeight : 0.00m);
				_sl.TOTALWEIGHT = _sl.DELIVEREDQTY;
				_sl.VATFACTOR = 0.00m;
				_sl.ISMATINCLUDE = false;
			}
			else
			{
				_sl = new CastingSaleOrderDAL().GetSOLineItemInfo(Id);
				if (_sl.FGLINESEQ > 0)
				{
					lbFGStockQvailableQty.Text = $"{(_sl.DELIVEREDQTY + new CastingSaleOrderDAL().GetAvailableQtyFGStock(_sl.FGLINESEQ)):N2}";
				}

				if (string.IsNullOrEmpty(MaterialCategory))
				{
					MaterialCategory = new MaterialDAL().GetMaterialCategoryForSell(MaterialId);
				}

				_selectPriceTableRowId = _sl.SL_CPT;
				_itemId = _sl.ITEMID;
				lbItemId.Text = $"{_itemId}";
			}

			GetMaterial(_sl != null ? _sl.CUSTCODE : CustomerCode);

			_vatFactor = _sl.VATFACTOR;
			_selectedMatId = _sl.MATTYPE;
			_soId = _sl.SOSEQ;
			_refId = _sl.REFSOKEY;
			lbSaleType.Text = _sl != null ? _sl.SALETYPE.ToString() : ((int)SaleType).ToString();
			lbJobNo.Text = _sl.JOBNO.ToString();
			lbPrefix.Text = _sl.PREFIX;
			lbItemNo.Text = _sl.ITEMNO;
			lbMaterialId.Text = _sl.MATTYPE.ToString();

			lbCPTID.Text = $"{_sl.SL_CPT}";

			txtItemName.Text = _sl.ITEMNAME;
			txtUnit.Text = _sl.UNIT;
			txtDeliveryQty.Text = $"{_sl.DELIVEREDQTY:N2}";
			chkIsMatInclude.Checked = _sl.ISMATINCLUDE;
			txtUnitPrice.Text = $"{_sl.UNITPRICE:N2}";
			txtTotalValue.Text = $"{_sl.TOTALVALUE:N2}";
			txtTotalAmount.Text = $"{_sl.LINEAMOUNT:N2}";

			cbxMaterial.SelectedValue = _sl.MATTYPE;
			txtTotalWeight.Text = $"{_sl.TOTALWEIGHT:N2}";
			txtAVGUnitWT.Text = $"{_sl.AVGUNITWEIGHT:N2}";
			txtAVGPriceWT.Text = $"{_sl.AVGPRICEUNITWEIGHT:N2}";
			txtRemark.Text = _sl.SOLINEREMARK;

			pic.Image = _sl.SALETYPE == (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ ? null : GetPictureForItemSelected(_itemId);
			UpdateUI();
		} // end GetSOLineItemDetail

		private Image GetPictureForItemSelected(int ItemId)
		{
			// get more property info for PriceListItem
			var cp = new PriceListDAL().GetCustomerPriceListItemInfo(ItemId);
			return PriceListDAL.GetPriceListItemPicture(cp.IMAGE_LOCATION);
		} // end GetPictureForItemSelected

		private void GetFieldOption(SelectTypeOption Option)
		{
			//
			// this method will loading select-box depend on the option giving
			//
			ToolGetData.GetData(Option, ref _value, ref _code, ref _id);
		} // end GetFieldOption


		private void CalWeightAvg()
		{
			var _qty = Information.IsNumeric(txtDeliveryQty.Text) ? Convert.ToDecimal(txtDeliveryQty.Text) : 0.00m;
			var _unitPrice = Information.IsNumeric(txtUnitPrice.Text) ? Convert.ToDecimal(txtUnitPrice.Text) : 0.00m;
			var _totalValue = (_unitPrice * _qty);
			var _totalAmount = _totalValue;
			var _totalWT = SaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
				? _qty
				: Information.IsNumeric(txtTotalWeight.Text) ? Convert.ToDecimal(txtTotalWeight.Text) : 0.00m;
			var _unitWeight = (_totalWT / (_qty == 0.00m ? 1 : _qty));
			var _avgPriceWeight = (_unitPrice / (_unitWeight == 0.00m ? 1.00m : _unitWeight));

			txtTotalValue.Text = $"{_totalValue:N2}";
			txtTotalAmount.Text = $"{_totalAmount:N2}";
			txtAVGUnitWT.Text = $"{_unitWeight:N2}";
			txtAVGPriceWT.Text = $"{_avgPriceWeight:N2}";
			txtTotalWeight.Text = (SaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ ? $"{_totalWT:N2}" : txtTotalWeight.Text);
		} // end CalWeightAvg

		private void UpdateSOLineItem(int SOLineId)
		{
			var _sl = new SOLINE();
			if (_itemMode == ActionMode.Add)
			{
				_sl.AUDITDATE = DateTime.Now;
				_sl.AUDITUSER = omglobal.UserInfo;
				_sl.CUSTCODE = CustomerCode;
				_sl.CUSTID = CustomerId;
				_sl.SALETYPE = (int)SaleType;
				_sl.REFSOKEY = SaleOrderId;
				_sl.SOSEQ = SaleOrderId;
				_sl.SONO = SaleOrderNumber;
				_sl.DELIVERDATE = OrderDate.Date2Num();
				_sl.JOBNO = Convert.ToInt32(lbJobNo.Text);
				_sl.PO = "";
				_sl.MATTYPE = MaterialId;
			}
			else if (_itemMode == ActionMode.Edit)
			{
				_sl = new CastingSaleOrderDAL().GetSOLineItemInfo(SOLineId);
				_sl.MATTYPE = MaterialId;
			}

			_sl.MODIDATE = DateTime.Now;
			_sl.MODIUSER = omglobal.UserInfo;
			_sl.ITEMID = SaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ ? MaterialId : _itemId;
			_sl.PREFIX = lbPrefix.Text;
			_sl.ITEMNO = lbItemNo.Text;
			_sl.ITEMNAME = txtItemName.Text;
			_sl.UNIT = txtUnit.Text;
			_sl.DELIVEREDQTY = Convert.ToDecimal(txtDeliveryQty.Text);
			_sl.ISMATINCLUDE = chkIsMatInclude.Checked;
			_sl.UNITPRICE = Convert.ToDecimal(txtUnitPrice.Text);
			_sl.UNITDISCOUNT = 0.00m;
			_sl.NETTUNITVALUE = _sl.UNITPRICE;
			_sl.TOTALVALUE = Convert.ToDecimal(txtTotalValue.Text);
			_sl.VATVALUE = 0.00m;
			_sl.LINEAMOUNT = Convert.ToDecimal(txtTotalAmount.Text);
			_sl.TOTALWEIGHT = Convert.ToDecimal(txtTotalWeight.Text);
			_sl.AVGUNITWEIGHT = Convert.ToDecimal(txtAVGUnitWT.Text);
			_sl.AVGPRICEUNITWEIGHT = Convert.ToDecimal(txtAVGPriceWT.Text);
			_sl.SOLINEREMARK = txtRemark.Text;
			_sl.SL_CPT = _selectPriceTableRowId;

			if (new CastingSaleOrderDAL().UpdateSOLineItem(_sl, _itemMode) > 0)
			{
			}
		} // end UpdateSOLineItem

		private void GetMaterialPriceList(string ItemNo)
		{
			using (var _ml = new MaterialPriceList(ItemNo, OrderDate))
			{
				_ml.StartPosition = FormStartPosition.CenterScreen;
				if (_ml.ShowDialog(this) == DialogResult.OK)
				{
					txtUnitPrice.Text = $"{_ml.MaterialPrice:N2}";
				}
			}
		} // end GetMaterialPriceList

		#endregion


		// CONSTRUCTOR
		public CastingSaleOrderItemInfo(int SOLineItemId, ActionMode SOHeaderMode)
		{
			InitializeComponent();
			SOLineId = SOLineItemId;
			_headerMode = SOHeaderMode;
			_itemMode = SOLineId == 0 ? ActionMode.Add : ActionMode.Edit;
			lbItemMode.Text = _itemMode.ToString().Substring(0, 1);
			lbHeaderMode.Text = _headerMode.ToString();
		}

		private void CastingSaleOrderItemInfo_Load(object sender, EventArgs e)
		{
			CenterToParent();

			lbSaleOrderNumber.Text = SaleOrderNumber;
			lbRefSEQ.Text = SaleOrderId.ToString();
			lbSOLineSEQ.Text = SOLineId.ToString();
			lbPriceItemId.Text = $"{this.PriceListItemId }";
			lbMatInfo.Text = $"{this.MaterialId} {this.MaterialName}";

			GetSOLineItemDetail(SOLineId);
		}

		private void btnUnit_Click(object sender, EventArgs e)
		{
			GetFieldOption(SelectTypeOption.UnitCount);
			txtUnit.Text = _value;
			UpdateUI();
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			CalWeightAvg();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			UpdateSOLineItem(SOLineId);

			#region Update PriceList Table
			CUSTPRICETAB _cpt = new CUSTPRICETAB();
			_cpt.ID = _selectPriceTableRowId;
			_cpt.CPT_CP = _itemId;
			_cpt.PRICE_YEAR = this.OrderDate.Year;
			_cpt.MATERIAL = this.MaterialId;
			_cpt.PRICEUNITNAME = this.txtUnit.Text;
			_cpt.ISMATINCLUDE = chkIsMatInclude.Checked;

			if (chkIsMatInclude.Checked == true)
			{
				_cpt.UNITPRICE = _castingPrice;
				_cpt.UNITPRICE_WITHMAT = Convert.ToDecimal(txtUnitPrice.Text);
			}
			else
			{
				_cpt.UNITPRICE = Convert.ToDecimal(txtUnitPrice.Text);
				_cpt.UNITPRICE_WITHMAT = _castingPriceWithMat;
			}

			int result = new PriceListDAL().UpdateCustPriceTable(_cpt);

			//if (_notFoundCastingPriceItem)
			//{
			//	if (MessageBox.Show("ต้องการปรับปรุงข้อมูลราคาลงฐานข้อมูลหรือไม่?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			//	{
			//		_cpt.ID = 0;
			//	}
			//}
			#endregion

		}

		private void btnItemNo_Click(object sender, EventArgs e)
		{
			using (var _ml = new MaterialList(CustomerCode, MaterialCategory))
			{
				_ml.StartPosition = FormStartPosition.CenterScreen;
				if (_ml.ShowDialog(this) == DialogResult.OK)
				{
					MaterialId = _ml.MaterialId;
					lbMaterialId.Text = MaterialId.ToString();
					MaterialName = _ml.MaterialName;
					lbItemNo.Text = MaterialName;
					txtItemName.Text = _ml.MaterialName;
				}
			} // end 

			UpdateUI();
		}


		private decimal _castingPrice = 0m;
		private decimal _castingPriceWithMat = 0m;

		private void btnUnitPrice_Click(object sender, EventArgs e)
		{
			if (SaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
					&& !string.IsNullOrEmpty(lbItemNo.Text))
			{
				GetMaterialPriceList(lbItemNo.Text);
			}
			else
			{
	//			using (var cpt = new CastingPriceItemList(_itemId, this.MaterialId, this.OrderDate.Year, txtUnit.Text, this.MaterialName))
				using (var cpt = new CastingPriceItemList(_itemId, this.MaterialId,this.MaterialName,this.txtUnit.Text))
				{
					if (cpt.ShowDialog(this) == DialogResult.OK)
					{
						_selectPriceTableRowId = cpt.ItemPriceRowId;
						lbCPTID.Text = $"{_selectPriceTableRowId}";

						_castingPrice = cpt.ItemPrice;
						_castingPriceWithMat = cpt.ItemPriceWithMat;


						txtUnitPrice.Text = $"{(chkIsMatInclude.Checked ? _castingPriceWithMat : _castingPrice):N2}";
						_notFoundCastingPriceItem = false;
					}
					else
					{
						_selectPriceTableRowId = 0;
						_notFoundCastingPriceItem = true;
					}
				}
			}
		}
	}
}