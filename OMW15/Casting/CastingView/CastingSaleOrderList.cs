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
using OMW15.Controllers;
using OMW15.Models;
using OMW15.Shared;
using OMW15.Views;

namespace OMW15.Casting.CastingView
{
	public partial class CastingSaleOrderList : Form
	{
		#region class field member

		private enum CastingSaleOrderStatus
		{
			None = 0,
			Active = 1,
			Complete = 2
		}

		private CastingSaleOrderStatus _castingSaleOrderStatus = CastingSaleOrderStatus.None;
		private int _selectedSOId = 0;
		private int _selectedSaleType = (int)OMShareCastingEnums.SaleTypeEnum.ไม่ระบุ;
		private string _selectedStatusTextMenu = string.Empty;
		private string _selectedSONumber = string.Empty;
		private string _customerCode = string.Empty;
		private string _customerName = string.Empty;
		private int _customerId = 0;
		
		#endregion

		#region class property
		
		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.pnlTop.Enabled = (_castingSaleOrderStatus != CastingSaleOrderStatus.None);
			this.btnAddOrder.Enabled = (!string.IsNullOrEmpty(_customerCode));
			this.btnEditOrder.Enabled = ((this.dgv.Rows.Count > 0) && (_selectedSOId > 0));
			

		} // end UpdateUI

		private void UpdateToolStrip(string SelectedMenuText)
		{
			this.tsmnuSOStatus.Text = string.Format("สถานะ : {0}", SelectedMenuText);
		
		} // end UpdateToolStrip

		private void GetCastingOrderListByStatus(CastingSaleOrderStatus Status,string CustomerCode)
		{
			OLDMOONEF _oldmoon = new OLDMOONEF();
			switch(Status)
			{
				case CastingSaleOrderStatus.Active:
					// loading active casting sale orders
					var _sos = from so in _oldmoon.SALEORDERS
							   where so.BILLSEQ == 0
								   && so.ISCOMPLETE == false
								   && so.ISDELETE == false
								   && so.ISCANCEL == false
							   select new
							   {
								   TYPE = so.SALETYPE == (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ ? "M" : "S",
								   so.CUSTCODE,
								   so.CUSTID,
								   so.SOSEQ,
								   so.SONO,
								   so.SODATE,
								   so.DUEDATE,
								   so.TOTALVALUE,
								   so.DISCOUNT,
								   so.NETVALUE,
								   so.VATVALUE,
								   so.TOTALAMOUNT,
								   so.SALEMATID,
								   so.DELIVERMAT,
								   so.DELIVERWEIGHT,
								   so.OUTSTANDWEIGHT
							   };
					this.dgv.SuspendLayout();
					this.dgv.DataSource = _sos.ToList();
					this.dgv.ResumeLayout();

					break;

				case CastingSaleOrderStatus.Complete:
					// loading completed casting sale orders
					var _soc = from so in _oldmoon.SALEORDERS
							   where so.BILLSEQ != 0
								   && so.ISCOMPLETE == false
								   && so.ISDELETE == false
								   && so.ISCANCEL == false
							   select so;

					this.dgv.DataSource = _soc.ToList();

					break;
			}

			if (!string.IsNullOrEmpty(CustomerCode))
			{
				if (this.dgv.Rows.Count > 0)
				{
					(this.dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(
					"[{0}] LIKE '%{1}%'", "CUSTCODE", CustomerCode);
				}
			}

			// update count records
			this.lbSOCount.Text = string.Format("found : {0}",this.dgv.Rows.Count);

			this.UpdateUI();

		} // end GetCastingOrderListByStatus


		private void GetCustomer()
		{
			Views.CustomerView.MasterCustomers _customer = new Views.CustomerView.MasterCustomers();
			_customer.Action = OMShareCustomerEnums.MasterCustomerAction.SearchOnly;
			_customer.StartPosition = FormStartPosition.CenterScreen;
			if (_customer.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				_customerCode = _customer.SelectedCustomerCode;
				_customerName = _customer.SelectedCustomerName;
				_customerId = _customer.SelectedCustomerId;
				
				// display selected Customer
				this.txtCustomerName.Text = string.Format("({0}){1}", _customerCode, _customerName);
			}

		} // end GetCustomer

		private void GetCastingSaleOrderInfo(int CastingSaleOrderId,string CustomerCode)
		{
			OMW15.Casting.CastingView.CastingSaleOrderInfo _cinfo = new CastingSaleOrderInfo();
			_cinfo.CastingSaleOrderId = CastingSaleOrderId;
			_cinfo.CustomerCode = CustomerCode;
			_cinfo.StartPosition = FormStartPosition.CenterScreen;
			_cinfo.ShowDialog(this);

			// refresh Casting Sale Order list
			this.btnRefresh.PerformClick();

		} // end GetCastingSaleOrderInfo


		#endregion

		public CastingSaleOrderList()
		{
			InitializeComponent();
		}

		private void tsmnu_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem _mnu = sender as ToolStripMenuItem;
			_selectedStatusTextMenu = _mnu.Text;
			this.lbStatus.Text = _mnu.Tag.ToString().ToUpper();

			// update tool strip menu
			this.UpdateToolStrip(_selectedStatusTextMenu);

			switch (_mnu.Tag.ToString())
			{
				case "Active":
					_castingSaleOrderStatus = CastingSaleOrderStatus.Active;
					break;
				case "Complete":
					_castingSaleOrderStatus = CastingSaleOrderStatus.Complete;
					break;
			}

			this.GetCastingOrderListByStatus(_castingSaleOrderStatus,_customerCode);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CastingSaleOrderList_Load(object sender, EventArgs e)
		{
			// setting DataGridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			// initial variable value
			_castingSaleOrderStatus = CastingSaleOrderStatus.None;
			_customerCode = string.Empty;
			_customerId = 0;
			_customerName = string.Empty;

			// Updating UI
			this.UpdateUI();
		}

		private void btnSearchSObyCustomer_Click(object sender, EventArgs e)
		{
			// search customer
			this.GetCustomer();

			// refresh Casting Sale Order as selected Customer Code
			this.GetCastingOrderListByStatus(_castingSaleOrderStatus, _customerCode);
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			// clear all customer existing values
			_customerCode = string.Empty;
			_customerId = 0;
			_customerName = string.Empty;
			this.txtCustomerName.Text = string.Empty;

			// refresh Casting Sale Order as selected Customer Code
			this.GetCastingOrderListByStatus(_castingSaleOrderStatus, _customerCode);

		}

		private void btnAddOrder_Click(object sender, EventArgs e)
		{
			_selectedSOId = 0;
			this.GetCastingSaleOrderInfo(_selectedSOId,_customerCode);
		}

		private void btnEditOrder_Click(object sender, EventArgs e)
		{
			this.GetCastingSaleOrderInfo(_selectedSOId,_customerCode);

		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedSOId = Convert.ToInt32(this.dgv["SOSEQ", e.RowIndex].Value);
		}
	}
}
