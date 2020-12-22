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

namespace OMW15.Services.ServiceView
{
	public partial class JobSPItemInfo : Form
	{
		#region class field member
		private ORDERSPAREPART _sp = new ORDERSPAREPART();
		private ActionMode _mode = ActionMode.None;
		private int _spLineId = 0;
		private int _orderId = 0;
		private string _orderCode = string.Empty;
		private string _orderNumber = string.Empty;

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			this.txtIssueNo.ReadOnly = (_mode == ActionMode.Edit);
			this.txtDateNeed.ReadOnly = this.txtIssueNo.ReadOnly;
			this.txtItemNo.ReadOnly = this.txtIssueNo.ReadOnly;
			this.txtItemName.ReadOnly = this.txtIssueNo.ReadOnly;
			this.txtUOM.ReadOnly = this.txtIssueNo.ReadOnly;
			
			this.btnSave.Enabled = !string.IsNullOrEmpty(this.txtIssueNo.Text)
									&& !string.IsNullOrEmpty(this.txtDateNeed.Text)
									&& !string.IsNullOrEmpty(this.txtUOM.Text)
									&& (Convert.ToDecimal(this.ntxtQtyNeed.Text) > 0.00m);

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
					_sp = new Warehouse.WarehouseContoller.IssueController().GetIssueItemInfo(Id);
					break;
			}

			this.txtIssueNo.Text = _sp.issueno;
			this.txtOrderNumber.Text = string.Format("{0}-{1}", _sp.ordercode, _sp.s_order);
			this.txtDateNeed.Text = _sp.dateneed.ToShortDateString();
			this.txtItemNo.Text = _sp.itemno;
			this.txtItemName.Text = _sp.itemname;
			this.txtUOM.Text = _sp.uom;
			this.ntxtQtyNeed.Text = string.Format("{0:N2}", _sp.qtyneed);
			this.ntxtUnitCost.Text = string.Format("{0:N2}", _sp.ucost);
			this.ntxtTotalCost.Text = string.Format("{0:N2}", ( _sp.ucost*_sp.qtyneed));
			this.ntxtUnitPrice.Text = string.Format("{0:N2}", _sp.uprice);
			this.ntxtDiscount.Text = string.Format("{0:N2}", _sp.discount);
			this.ntxtNetPrice.Text = string.Format("{0:N2}", _sp.netuprice);
			this.ntxtTotalPrice.Text = string.Format("{0:N2}", _sp.totalprice);
			this.txtRemark.Text = _sp.itemremark;

			this.UpdateUI();

		} // end GetSPItemInfo

		private void CalPrice()
		{
			decimal _qty = Convert.ToDecimal(this.ntxtQtyNeed.Text);
			decimal _unitCost = Convert.ToDecimal(this.ntxtUnitCost.Text);
			decimal _unitPrice = Convert.ToDecimal(this.ntxtUnitPrice.Text);
			decimal _discount = Convert.ToDecimal(this.ntxtDiscount.Text);
			decimal _netPrice = (_unitPrice - _discount);
			decimal _totalPrice = (_netPrice * _qty);
			decimal _totalCost = (_unitCost * _qty);

			this.ntxtNetPrice.Text = string.Format("{0:N2}", _netPrice);
			this.ntxtTotalPrice.Text = string.Format("{0:N2}", _totalPrice);
			this.ntxtTotalCost.Text = string.Format("{0:N2}", _totalCost);

			this.UpdateUI();

		} // end CalPrice

		private void UpdateIssueItem(int LineId)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_sp.issueno = this.txtIssueNo.Text;
					_sp.dateneed = Convert.ToDateTime(this.txtDateNeed.Text);
					_sp.itemno = this.txtItemNo.Text;
					_sp.itemname = this.txtItemName.Text;
					_sp.uom = this.txtUOM.Text;
					_sp.qtyneed = Convert.ToDecimal(this.ntxtQtyNeed.Text);
					_sp.uprice = Convert.ToDecimal(this.ntxtUnitPrice.Text);
					_sp.discount = Convert.ToDecimal(this.ntxtDiscount.Text);
					_sp.netuprice = Convert.ToDecimal(this.ntxtNetPrice.Text);
					_sp.totalprice = Convert.ToDecimal(this.ntxtTotalPrice.Text);
					_sp.itemremark = this.txtRemark.Text;
					_sp.audituser = omglobal.UserName;
					_sp.auditdt = DateTime.Now;
					_sp.modiuser = omglobal.UserName;
					_sp.modidt = DateTime.Now;

					if (new Warehouse.WarehouseContoller.IssueController().UpdateIssueItemInfo(LineId, _sp) > 0)
					{
						MessageBox.Show("Add Item successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					break;

				case ActionMode.Edit:
					_sp.qtyneed = Convert.ToDecimal(this.ntxtQtyNeed.Text);
					_sp.uprice = Convert.ToDecimal(this.ntxtUnitPrice.Text);
					_sp.discount = Convert.ToDecimal(this.ntxtDiscount.Text);
					_sp.netuprice = Convert.ToDecimal(this.ntxtNetPrice.Text);
					_sp.totalprice = Convert.ToDecimal(this.ntxtTotalPrice.Text);
					_sp.itemremark = this.txtRemark.Text;
					_sp.modiuser = omglobal.UserName;
					_sp.modidt = DateTime.Now;

					if (new Warehouse.WarehouseContoller.IssueController().UpdateIssueItemInfo(LineId, _sp) > 0)
					{
						MessageBox.Show("Update Item successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					break;
			}

		} // end UpdateIssueItem


		#endregion


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
			// update Mode
			this.grp.Text = string.Format("รายการเบิก [{0}]", _mode.ToString());

			this.GetSPItemInfo(_spLineId);
		}

		private void ntxt_TextChanged(object sender, EventArgs e)
		{
			this.CalPrice();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.UpdateIssueItem(_spLineId);
		}

		private void btnIssueDate_DateSelected(object sender, EventArgs e)
		{
			this.txtDateNeed.Text = this.btnIssueDate.SelectedDate.ToShortDateString();
		}

		private void btnIssueDate_ButtonClick(object sender, EventArgs e)
		{
			if (OMControls.OMUtils.IsDate(this.txtDateNeed.Text))
			{
				this.btnIssueDate.SelectedDate = Convert.ToDateTime(this.txtDateNeed.Text);
			}
			else
			{
				this.btnIssueDate.SelectedDate = DateTime.Today;
			}
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}
	}
}
