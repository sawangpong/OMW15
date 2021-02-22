using OMW15.Models.ProductionModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class Receive2WH : Form
	{
		#region class field

		private PRODUCTION_WH_RECEIVE _receiveItem;// = new PRODUCTION_WH_RECEIVE();
		private string _receiveNo = string.Empty;
		private string _receiveUnit = string.Empty;
		private string _itemNo = string.Empty;
		private string _orderNo = string.Empty;
		private ActionMode _mode = ActionMode.None;

		#endregion


		#region class properties


		#endregion

		#region class helper
		private void UpdateUI()
		{
			btnSave.Enabled = (!String.IsNullOrEmpty(txtReceiveNo.Text))
								&& (!String.IsNullOrEmpty(txtReceivedBy.Text)
								&& dtpReceiveDate.Value != null
								&& Convert.ToDecimal(ntxtReceiveQty.Text) > 0)
								&& (!String.IsNullOrEmpty(txtReceiveUnit.Text));
		}

		private void GetStockReceiveItem(string receiveNo)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_receiveItem = new PRODUCTION_WH_RECEIVE();
					_receiveItem.RECEIVE_AVG_UCOST = 0m;
					_receiveItem.RECEIVE_BY = "";
					_receiveItem.RECEIVE_DATE = DateTime.Today;
					_receiveItem.RECEIVE_NO = "";
					_receiveItem.RECEIVE_QTY = 0m;
					_receiveItem.REF_ISSUE_ID = 0;
					_receiveItem.RECEIVE_UNIT = _receiveUnit;
					_receiveItem.REF_TRANSFER_DOC = _orderNo;
					break;

				case ActionMode.Edit:
					_receiveItem = new ProductionDAL().GetReceiveItem(receiveNo);
					break;
			}

			txtAvgUnitCost.Text = $"{_receiveItem.RECEIVE_AVG_UCOST:N2}";
			txtReceiveCost.Text = $"{_receiveItem.RECEIVE_COST:N2}";
			txtReceivedBy.Text = _receiveItem.RECEIVE_BY;
			ntxtReceiveQty.Text = $"{_receiveItem.RECEIVE_QTY:N2}";
			dtpReceiveDate.Value = _receiveItem.RECEIVE_DATE.Value;
			txtReceiveNo.Text = _receiveItem.RECEIVE_NO;
			txtReceiveUnit.Text = _receiveItem.RECEIVE_UNIT;
		}

		private void UpdateReceiveItem(PRODUCTION_WH_RECEIVE item)
		{
			int _result = new ProductionDAL().UpdateReceiveItem(item);
		}

		#endregion

		public Receive2WH(string orderNo, string itemNo, string receiveNo, string receiveUnit = "")
		{
			InitializeComponent();
			_orderNo = orderNo;
			_receiveNo = receiveNo;
			_receiveUnit = receiveUnit;
			_itemNo = itemNo;

			_mode = (String.IsNullOrEmpty(_receiveNo) ? ActionMode.Add : ActionMode.Edit);

			lbTitle.Text = $"รายการรับเข้าคลัง (#{_orderNo} >> {_itemNo})";

		}

		private void Receive2WH_Load(object sender, EventArgs e)
		{
			GetStockReceiveItem(_receiveNo);
		}

		private void txtReceivedBy_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void dtpReceiveDate_CloseUp(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void ntxtReceiveQty_TextChanged(object sender, EventArgs e)
		{
			if (ntxtReceiveQty.Text.IsNumeric())
			{
				_receiveItem.RECEIVE_QTY = Convert.ToDecimal(ntxtReceiveQty.Text);
				if (_receiveItem.RECEIVE_QTY > 0m)
				{
					_receiveItem.RECEIVE_AVG_UCOST = _receiveItem.RECEIVE_COST / _receiveItem.RECEIVE_QTY;
				}
				txtAvgUnitCost.Text = $"{_receiveItem.RECEIVE_AVG_UCOST:N2}";
			}

			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			_receiveItem.RECEIVE_AVG_UCOST = Convert.ToDecimal(txtAvgUnitCost.Text);
			_receiveItem.RECEIVE_BY = txtReceivedBy.Text;
			_receiveItem.RECEIVE_COST = Convert.ToDecimal(txtReceiveCost.Text);
			_receiveItem.RECEIVE_DATE = dtpReceiveDate.Value;
			_receiveItem.RECEIVE_NO = txtReceiveNo.Text;
			_receiveItem.RECEIVE_QTY = Convert.ToDecimal(ntxtReceiveQty.Text);
			_receiveItem.RECEIVE_UNIT = txtReceiveUnit.Text;
			_receiveItem.REF_TRANSFER_DOC = _orderNo;

			UpdateReceiveItem(_receiveItem);

		}

		private void btnReceiveNo_Click(object sender, EventArgs e)
		{
			DataTable _dt = new ProductionDAL().GetReceiveItemCost(_itemNo, txtReceiveNo.Text);

			_receiveItem.RECEIVE_COST = _dt.AsEnumerable().Sum(x => x.Field<decimal>("TRD_SH_GSELL"));
			_receiveItem.RECEIVE_DATE = _dt.Rows[0].Field<DateTime>("DI_DATE");
			_receiveItem.REF_ISSUE_ID = _dt.Rows[0].Field<Int32>("DI_KEY");

			txtReceiveCost.Text = $"{_receiveItem.RECEIVE_COST:N2}";
			dtpReceiveDate.Value = _receiveItem.RECEIVE_DATE.Value;

			UpdateUI();
		}

		private void txtReceiveNo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
			{
				btnReceiveNo.PerformClick();
			}
		}

		private void txtReceivedBy_TextChanged_1(object sender, EventArgs e)
		{
			UpdateUI();
		}
	}
}
