using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.WarehouseModel;
using OMW15.Shared;

namespace OMW15.Views.ServiceView
{
	public partial class JobSPItemInfo : Form
	{
		public JobSPItemInfo(int LineId, int OrderId, string OrderCode, string OrderNumber)
		{
			InitializeComponent();
			_spLineId = LineId;
			_orderId = OrderId;
			_orderCode = OrderCode;
			_orderNumber = OrderNumber;
			_mode = _spLineId == 0 ? ActionMode.Add : ActionMode.Edit;
		}

		private void JobSPItemInfo_Load(object sender, EventArgs e)
		{
			CenterToParent();
			// update Mode
			grp.Text = string.Format("รายการเบิก [{0}]", _mode);

			GetSPItemInfo(_spLineId);
		}

		private void ntxt_TextChanged(object sender, EventArgs e)
		{
			CalPrice();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			UpdateIssueItem(_spLineId);
		}

		private void btnIssueDate_DateSelected(object sender, EventArgs e)
		{
			txtDateNeed.Text = btnIssueDate.SelectedDate.ToShortDateString();
		}

		private void btnIssueDate_ButtonClick(object sender, EventArgs e)
		{
			if (OMUtils.IsDate(txtDateNeed.Text))
				btnIssueDate.SelectedDate = Convert.ToDateTime(txtDateNeed.Text);
			else
				btnIssueDate.SelectedDate = DateTime.Today;
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		#region class field member

		private ORDERSPAREPART _sp = new ORDERSPAREPART();
		private readonly ActionMode _mode = ActionMode.None;
		private readonly int _spLineId;
		private readonly int _orderId;
		private readonly string _orderCode = string.Empty;
		private readonly string _orderNumber = string.Empty;

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			txtIssueNo.ReadOnly = _mode == ActionMode.Edit;
			txtDateNeed.ReadOnly = txtIssueNo.ReadOnly;
			txtItemNo.ReadOnly = txtIssueNo.ReadOnly;
			txtItemName.ReadOnly = txtIssueNo.ReadOnly;
			txtUOM.ReadOnly = txtIssueNo.ReadOnly;

			btnSave.Enabled = !string.IsNullOrEmpty(txtIssueNo.Text)
							  && !string.IsNullOrEmpty(txtDateNeed.Text)
							  && !string.IsNullOrEmpty(txtUOM.Text)
							  && Convert.ToDecimal(ntxtQtyNeed.Text) > 0.00m;
		} // end UpdateUI

		private void GetSPItemInfo(int Id)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_sp = new ORDERSPAREPART();
					_sp.spLine = 0;
					_sp.orderid = _orderId;
					_sp.ordercode = _orderCode;
					_sp.s_order = _orderNumber;
					_sp.dateneed = DateTime.Today;
					_sp.qtyneed = 0.00m;
					_sp.uom = "PC";
					break;

				case ActionMode.Edit:
					_sp = new IssueDAL().GetIssueItemInfo(Id);
					break;
			}

			txtIssueNo.Text = _sp.issueno;
			txtOrderNumber.Text = $"{_sp.ordercode}-{_sp.s_order}";
			txtDateNeed.Text = _sp.dateneed.ToShortDateString();
			txtItemNo.Text = _sp.itemno;
			txtItemName.Text = _sp.itemname;
			txtUOM.Text = _sp.uom;
			ntxtQtyNeed.Text = string.Format("{0:N2}", _sp.qtyneed);
			ntxtUnitCost.Text = string.Format("{0:N2}", _sp.ucost);
			ntxtTotalCost.Text = string.Format("{0:N2}", _sp.ucost * _sp.qtyneed);
			ntxtUnitPrice.Text = string.Format("{0:N2}", _sp.uprice);
			ntxtDiscount.Text = string.Format("{0:N2}", _sp.discount);
			ntxtNetPrice.Text = string.Format("{0:N2}", _sp.netuprice);
			ntxtTotalPrice.Text = string.Format("{0:N2}", _sp.totalprice);
			txtRemark.Text = _sp.itemremark;

			UpdateUI();
		} // end GetSPItemInfo

		private void CalPrice()
		{
			var _qty = Convert.ToDecimal(ntxtQtyNeed.Text);
			var _unitCost = Convert.ToDecimal(ntxtUnitCost.Text);
			var _unitPrice = Convert.ToDecimal(ntxtUnitPrice.Text);
			var _discount = Convert.ToDecimal(ntxtDiscount.Text);
			var _netPrice = _unitPrice - _discount;
			var _totalPrice = _netPrice * _qty;
			var _totalCost = _unitCost * _qty;

			ntxtNetPrice.Text = string.Format("{0:N2}", _netPrice);
			ntxtTotalPrice.Text = string.Format("{0:N2}", _totalPrice);
			ntxtTotalCost.Text = string.Format("{0:N2}", _totalCost);

			UpdateUI();
		} // end CalPrice

		private void UpdateIssueItem(int LineId)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_sp.issueno = txtIssueNo.Text;
					_sp.dateneed = Convert.ToDateTime(txtDateNeed.Text);
					_sp.itemno = txtItemNo.Text;
					_sp.itemname = txtItemName.Text;
					_sp.uom = txtUOM.Text;
					_sp.qtyneed = Convert.ToDecimal(ntxtQtyNeed.Text);
					_sp.uprice = Convert.ToDecimal(ntxtUnitPrice.Text);
					_sp.discount = Convert.ToDecimal(ntxtDiscount.Text);
					_sp.netuprice = Convert.ToDecimal(ntxtNetPrice.Text);
					_sp.totalprice = Convert.ToDecimal(ntxtTotalPrice.Text);
					_sp.itemremark = txtRemark.Text;
					_sp.audituser = omglobal.UserName;
					_sp.auditdt = DateTime.Now;
					_sp.modiuser = omglobal.UserName;
					_sp.modidt = DateTime.Now;

					if (new IssueDAL().UpdateIssueItemInfo(LineId, _sp) > 0)
						MessageBox.Show("Add Item successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					break;

				case ActionMode.Edit:
					_sp.qtyneed = Convert.ToDecimal(ntxtQtyNeed.Text);
					_sp.uprice = Convert.ToDecimal(ntxtUnitPrice.Text);
					_sp.discount = Convert.ToDecimal(ntxtDiscount.Text);
					_sp.netuprice = Convert.ToDecimal(ntxtNetPrice.Text);
					_sp.totalprice = Convert.ToDecimal(ntxtTotalPrice.Text);
					_sp.itemremark = txtRemark.Text;
					_sp.modiuser = omglobal.UserName;
					_sp.modidt = DateTime.Now;

					if (new IssueDAL().UpdateIssueItemInfo(LineId, _sp) > 0)
						MessageBox.Show("Update Item successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					break;
			}
		} // end UpdateIssueItem

		#endregion

		private void btnSearchItem_Click(object sender, EventArgs e)
		{
			WarehouseView.StockMaster _stock = new WarehouseView.StockMaster(ActionMode.Selection);
			if (_stock.ShowDialog(this) == DialogResult.OK)
			{
				this.txtItemNo.Text = _stock.ItemMasterCode;
				this.txtItemName.Text = _stock.ItemMasterNameTH;
				this.txtUOM.Text = _stock.ItemUnit;
				this.ntxtUnitCost.Text = $"{ _stock.ItemUnitCostTHB:N2}";
			}
		}
	}
}