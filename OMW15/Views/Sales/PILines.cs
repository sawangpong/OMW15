using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using OMW15.Controllers.WarehouseContoller;
using OMW15.Models.SaleModel;
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class PILines : Form
	{
		#region class field member

		private ActionMode _mode = ActionMode.None;

		#endregion

		public PILines(int LineId, int PIRecordId, string PINo)
		{
			InitializeComponent();
			PILineId = LineId;
			PIId = PIRecordId;
			PINumber = PINo;
		}

		private void PILines_Load(object sender, EventArgs e)
		{
			lbMode.Text = (_mode = PILineId == 0 ? ActionMode.Add : ActionMode.Edit).ToString();

			lbId.Text = string.Format("PI:{0}", PINumber);
			lbHeaderIndex.Text = string.Format("idx:{0}", PIId);

			GetPILineInfo(PILineId);
		}

		private void btnItemNo_Click(object sender, EventArgs e)
		{
			//Views.WarehouseView.StockMaster _sto = new WarehouseView.StockMaster(Shared.ActionMode.Selection);
			//_sto.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			//_sto.StartPosition = FormStartPosition.CenterScreen;

			var _sto = new StockMasterController(ActionMode.Selection);
			if (_sto.IsEmptyResult == false)
			{
				txtItemNo.Text = _sto.ItemNo;
				txtItemName.Text = _sto.ItemNameTH;
				txtUnit.Text = _sto.ItemUnit;
				txtUnitPrice.Text = string.Format("{0:N2}",
					Currency == omglobal.SOURCE_CURRENCY ? _sto.USDUnitPrice : _sto.THBUnitCost);
			}
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			CalPILineTotal();
		}

		private void txtItemName_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			UpdatePILine(PILineId);
		}

		#region class property

		public ActionMode PIHeaderMode { get; set; }

		public int PIId { get; set; }

		public string PINumber { get; set; }

		public int PILineId { get; set; }

		public string Currency { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnSave.Enabled = !string.IsNullOrEmpty(txtItemName.Text);
		} // end UpdateUI

		private void CalPILineTotal()
		{
			if (Information.IsNumeric(txtQty.Text)
			    && Information.IsNumeric(txtUnitPrice.Text))
				txtLineTotal.Text = string.Format("{0:N2}", Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtUnitPrice.Text));
			else
				txtLineTotal.Text = string.Format("{0:N2}", "0");
		} // end CalPILineTotal


		private void GetPILineInfo(int Id)
		{
			var _pil = new PI_ITEMS();

			if (Id > 0)
				_pil = new SaleDAL().GetPIItemInfo(Id);
			txtCurrency.Text = Currency;
			txtItemName.Text = _pil.PI_ITEMNAME;
			txtItemNo.Text = _pil.PI_ITEMNO;
			txtQty.Text = string.Format("{0:N2}", _pil.PI_ITEM_QTY);
			txtUnit.Text = _pil.PI_ITEM_UNIT;
			txtRemark.Text = _pil.PI_ITEM_REMARK;
			txtUnitPrice.Text = string.Format("{0:N2}", _pil.PI_ITEM_PRICE);

			UpdateUI();
		} // end GetPILineInfo


		private void UpdatePILine(int PILineId)
		{
			var _pl = new PI_ITEMS();

			switch (PIHeaderMode)
			{
				case ActionMode.Add:
					switch (_mode)
					{
						case ActionMode.Add:
							_pl.PI_ITEM = 0;
							_pl.PI_ID = PIId;
							_pl.REF_INDEX = PIId;
							break;
						case ActionMode.Edit:
							_pl = new SaleDAL().GetPIItemInfo(PILineId);
							break;
					}
					break;
				case ActionMode.Edit:
					switch (_mode)
					{
						case ActionMode.Add:
							_pl.PI_ITEM = 0;
							_pl.PI_ID = PIId;
							_pl.REF_INDEX = PIId;
							break;
						case ActionMode.Edit:
							_pl = new SaleDAL().GetPIItemInfo(PILineId);
							break;
					}
					break;
			}

			_pl.PI_ITEMNO = txtItemNo.Text;
			_pl.PI_ITEMNAME = txtItemName.Text;
			_pl.PI_ITEM_UNIT = txtUnit.Text;
			_pl.PI_ITEM_QTY = Convert.ToDecimal(txtQty.Text);
			_pl.PI_ITEM_PRICE = Convert.ToDecimal(txtUnitPrice.Text);
			_pl.PI_ITEM_AMOUNT = Convert.ToDecimal(txtLineTotal.Text);
			_pl.PI_ITEM_REMARK = txtRemark.Text;
			_pl.LASTUPDATE = DateTime.Now;
			_pl.MODIUSER = omglobal.UserName;

			if (new SaleDAL().InsertOrUpdatePILine(_pl) > 0)
			{
				// ShowMessage...
			}
		} // end UpdatePILine

		#endregion
	}
}