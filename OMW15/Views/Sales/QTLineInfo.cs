using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using OMControls;
using OMW15.Controllers.SaleController;
using OMW15.Controllers.WarehouseContoller;
using OMW15.Models.SaleModel;
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class QTLineInfo : Form
	{
		#region CONSTRUCTOR

		public QTLineInfo(int QTLineId, int RefHIndex,string currency)
		{
			InitializeComponent();
			this.Currency = currency;
			_qtHeaderIndex = RefHIndex;
			_qtLineId = QTLineId;
			_mode = _qtLineId == 0 ? ActionMode.Add : ActionMode.Edit;
			gb.Text = $"Item Information [{_mode}]";
			lbLineIndex.Text = _qtLineId.ToString();
			lbHIndex.Text = _qtHeaderIndex.ToString();
			lbCurrency.Text = currency;
		}

		#endregion

		private void QTLineInfo_Load(object sender, EventArgs e)
		{
			CenterToParent();

			// hide item info
			UpdateWindowSize(_openItemInfo = false);

			// load data
			GetQTLineItemInfo(_qtLineId);
		}

		private void btnItemNo_Click(object sender, EventArgs e)
		{
			var sto = new StockMasterController(ActionMode.Selection);
			if (sto.IsEmptyResult == false)
			{
				txtItemNo.Text = sto.ItemNo;
				txtItemName.Text = sto.ItemNameTH;
				txtUnit.Text = sto.ItemUnit;
				txtUnitPrice.Text = $"{(this.Currency == omglobal.SOURCE_CURRENCY ? sto.USDUnitPrice : sto.THBUnitPrice):N2}";
			}
		}


		private void txtPrice_TextChanged(object sender, EventArgs e)
		{
			CalLineTotal();
		}

		private void btnItemInfo_Click(object sender, EventArgs e)
		{
			UpdateWindowSize(_openItemInfo = !_openItemInfo);
			var _btn = sender as OMFlatButton;
			_btn.Tag = _openItemInfo ? "ON" : "OFF";

			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			AddUpdateQTLine(_qtLineId);
		}


		private void lnklbFindInQTMasterItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var _getMaster = new MasterQTController(OMShareSaleEnum.MasterQuotationListStyle.QuotationItem, Currency);

			if (_getMaster.IsEmptyResult == false)
			{
				txtItemNo.Text = _getMaster.ItemNo;
				txtItemName.Text = _getMaster.ItemName;
				txtItemInfo.Text = _getMaster.ItemInfo;
				lbCurrency.Text = _getMaster.Currency;
				txtQty.Text = string.Format("{0:N2}", _getMaster.Qty);
				txtUnit.Text = _getMaster.Unit;
				txtUnitPrice.Text = string.Format("{0:N2}", _getMaster.UnitPrice);
				txtLineTotal.Text = string.Format("{0:N2}", _getMaster.LineTotalValue);
			}
		}

		#region class field member

		private const int _FIX_DEFAULT_HEIGHT = 550;
		private const int _FIX_ITEM_INFO_HEIGHT = 200;
		private QUOTATIONLL _ql;
		private readonly ActionMode _mode = ActionMode.None;
		private bool _openItemInfo;
		private decimal _qty;
		private decimal _unitPrice;
		private readonly int _qtLineId;
		private readonly int _qtHeaderIndex;
		//private int _selectedMasterQTItemId = 0;

		#endregion

		#region class property

		public ActionMode HeaderMode { get; set; }

		public string Currency { get; set; }

		#endregion

		#region class

		private void UpdateUI()
		{
			btnSave.Enabled = _qty > 0.00m;
			pnlItemInfo.Visible = _openItemInfo;

		} // end UpdateUI

		private void GetQTLineItemInfo(int QTLineId)
		{
			if (QTLineId == 0)
			{
				_ql = new QUOTATIONLL();
				lbCurrency.Text = Currency;
			}
			else
			{
				_ql = new SaleQTDAL().GetQuotationItem(QTLineId);
				lbCurrency.Text = _ql.QL_CURRENCY;
			}

			txtItemNo.Text = _ql.QL_ITEMNO;
			txtItemName.Text = _ql.QL_ITEMNAME;
			txtItemInfo.Text = _ql.QL_ITEMINFO;
			txtLineTotal.Text = string.Format("{0:N2}", _ql.QL_TOTAL);
			txtQty.Text = string.Format("{0:N2}", _ql.QL_QTY);
			txtUnit.Text = _ql.QL_UNIT;
			txtUnitPrice.Text = string.Format("{0:N2}", _ql.QL_UNITPRICE);

			UpdateUI();
		} // end GetQTLineItemInfo


		private void CalLineTotal()
		{
			_unitPrice = Information.IsNumeric(txtUnitPrice.Text) ? Convert.ToDecimal(txtUnitPrice.Text) : 0.00m;

			_qty = Information.IsNumeric(txtQty.Text) ? Convert.ToDecimal(txtQty.Text) : 0.00m;

			txtLineTotal.Text = string.Format("{0:N2}", _unitPrice * _qty);

			UpdateUI();
		} // end CalLineTotal


		private void AddUpdateQTLine(int QTLineId)
		{
			_ql = new QUOTATIONLL();

			switch (_mode)
			{
				case ActionMode.Add:
					_ql.QL_ID = 0;
					_ql.QL_QT = _qtHeaderIndex;
					_ql.AUDITUSER = omglobal.UserName;
					break;

				case ActionMode.Edit:
					_ql = new SaleQTDAL().GetQuotationItem(QTLineId);
					break;
			}

			_ql.QL_REFID = _qtHeaderIndex;
			_ql.MODIDATE = DateTime.Now;
			_ql.MODIUSER = omglobal.UserName;
			_ql.QL_CURRENCY = lbCurrency.Text;
			_ql.QL_ITEMINFO = txtItemInfo.Text;
			_ql.QL_ITEMNAME = txtItemName.Text;
			_ql.QL_ITEMNO = txtItemNo.Text;
			_ql.QL_QTY = Convert.ToDecimal(txtQty.Text);
			_ql.QL_TOTAL = Convert.ToDecimal(txtLineTotal.Text);
			_ql.QL_UNIT = txtUnit.Text;
			_ql.QL_UNITPRICE = Convert.ToDecimal(txtUnitPrice.Text);

			if (new SaleQTDAL().UpdateQTLine(_ql) > 0)
				MessageBox.Show(string.Format("{0} record complete..", _mode == ActionMode.Add ? "Insert" : "Update"), "Message",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
		} // end AddUpdateQTLine

		private void UpdateWindowSize(bool OpenItemInfoBlock)
		{
			SuspendLayout();

			Height = OpenItemInfoBlock == false ? _FIX_DEFAULT_HEIGHT - _FIX_ITEM_INFO_HEIGHT : _FIX_DEFAULT_HEIGHT;

			ResumeLayout();
		}

		#endregion
	}
}