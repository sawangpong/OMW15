using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using OMControls;
using OMW15.Controllers.SaleController;
using OMW15.Models.SaleModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class PIInfo : Form
	{
		public PIInfo(int PIInfoId)
		{
			InitializeComponent();
			PIHeaderId = PIInfoId;

			lbMode.Text = (_mode = PIHeaderId == 0 ? ActionMode.Add : ActionMode.Edit).ToString();
			_isPosted = _mode == ActionMode.Add ? false : true;
			lbPosted.Text = _isPosted ? "<POSTED>" : "";
		}

		#region class properties

		public int PIHeaderId { get; set; }

		#endregion

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (_isPosted == false)
				if (new PIController().ClearUnPostedPIRecords(_refPIHeaderId) > 0)
					MessageBox.Show("Cancel PI completed..", "CANCEL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			Close();
		}

		private void PIInfo_Load(object sender, EventArgs e)
		{
			chkAutoCreatePINumber.Enabled = _mode == ActionMode.Add;

			OMUtils.SettingDataGridView(ref dgv);
			GetCurrencyList();

			// load PI record info
			GetPI(PIHeaderId);
		}

		private void btnCustomerSearch_Click(object sender, EventArgs e)
		{
			GetCustomer();
		}

		private void btn_Click(object sender, EventArgs e)
		{
			var _btn = sender as OMFlatButton;
			switch (_btn.Tag.ToString().ToUpper())
			{
				case "COUNTRY":
					_contentType = OMShareSaleEnum.SaleContentInfo.Country;
					break;
				case "DEL_TERM":
					_contentType = OMShareSaleEnum.SaleContentInfo.DeliveryTerm;
					break;
				case "DEL_TIME":
					_contentType = OMShareSaleEnum.SaleContentInfo.DeliveryTime;
					break;
				case "PAY_TERM":
					_contentType = OMShareSaleEnum.SaleContentInfo.PaymentTerm;
					break;
			}


			var _delTerm = new DelTerm(_contentType);
			_delTerm.StartPosition = FormStartPosition.CenterScreen;
			if (_delTerm.ShowDialog(this) == DialogResult.OK)
				switch (_contentType)
				{
					case OMShareSaleEnum.SaleContentInfo.Country:
						txtCountry.Text = _delTerm.Result;
						break;
					case OMShareSaleEnum.SaleContentInfo.DeliveryTerm:
						txtDeliveryTerm.Text = _delTerm.Result;
						break;
					case OMShareSaleEnum.SaleContentInfo.DeliveryTime:
						txtDeliveryTime.Text = _delTerm.Result;
						break;
					case OMShareSaleEnum.SaleContentInfo.PaymentTerm:
						txtPaymentTerm.Text = _delTerm.Result;
						break;
				}
		}

		private void btnBank_Click(object sender, EventArgs e)
		{
			//Views.BankView.Banks _b = new BankView.Banks();
			//_b.StartPosition = FormStartPosition.CenterScreen;

			//if (_b.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			//{
			//	this.txtBankInfo.Text = _b.BankCompleteInfo;
			//}

			var _b = new BankController(ActionMode.Selection);
			if (_b.IsEmptyResult == false)
				txtBankInfo.Text = _b.BankInfo;
		}

		private void chkAutoCreatePINumber_CheckedChanged(object sender, EventArgs e)
		{
			if (_mode == ActionMode.Add)
			{
				txtPINumber.Text = chkAutoCreatePINumber.Checked ? "***AUTO***" : string.Empty;
				txtPINumber.Enabled = !chkAutoCreatePINumber.Checked;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			UpdatePI(PIHeaderId);
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void txtPINumber_Validating(object sender, CancelEventArgs e)
		{
			if (chkAutoCreatePINumber.Checked == false)
				if (Information.IsNumeric(txtPINumber.Text.Substring(3)))
				{
					_piCountNumber = Convert.ToInt32(txtPINumber.Text.Substring(3));
					e.Cancel = false;
				}
				else
				{
					MessageBox.Show("PI Number not correct format, please use the format YY-nnnn", "", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					e.Cancel = true;
				}
		}

		private void tsbtnPIAddLine_Click(object sender, EventArgs e)
		{
			AddEditPILine(_selectedPILineId = 0);
		}

		private void tsbtnPIEditLine_Click(object sender, EventArgs e)
		{
			AddEditPILine(_selectedPILineId);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedPILineId = Convert.ToInt32(dgv["PI_ITEM", e.RowIndex].Value);
			tslbLineIndex.Text = string.Format("idx:{0}", _selectedPILineId);
			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetPILineList(_mode == ActionMode.Add ? _refPIHeaderId : PIHeaderId);
		}

		private void tsbtnPIDeleteLine_Click(object sender, EventArgs e)
		{
			if (
				MessageBox.Show("Do you rely want to delete that selected record?", "Delete", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (new SaleDAL().DeletePILine(_selectedPILineId) > 0)
					MessageBox.Show("Selected record had deleted from the database....", "Message", MessageBoxButtons.OK,
						MessageBoxIcon.Information);

				// re-set selected pi row
				_selectedPILineId = 0;

				// re-load PI-Line Data
				tsbtnRefresh.PerformClick();
			}
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnPIEditLine.PerformClick();
		}

		private void txtCalCost_TextChanged(object sender, EventArgs e)
		{
			UpdateTotalPIAmount();
		}

		#region class field members

		private readonly bool _isPosted = true;
		private int _refPIHeaderId;
		private int _custId;
		private int _piCountNumber;
		private int _selectedPILineId;
		private string _custAddress = string.Empty;
		private string _custCountry = string.Empty;
		private readonly ActionMode _mode = ActionMode.None;
		private OMShareSaleEnum.SaleContentInfo _contentType = OMShareSaleEnum.SaleContentInfo.None;

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			txtPINumber.Enabled = _mode == ActionMode.Add;
			tsbtnPIEditLine.Enabled = _selectedPILineId > 0;
			tsbtnPIDeleteLine.Enabled = tsbtnPIEditLine.Enabled;


			btnSave.Enabled = !string.IsNullOrEmpty(txtCustomer.Text)
			                  && !string.IsNullOrEmpty(txtAddress.Text)
			                  && !string.IsNullOrEmpty(txtBankInfo.Text)
			                  && !string.IsNullOrEmpty(txtDeliveryTerm.Text)
			                  && !string.IsNullOrEmpty(txtDeliveryTime.Text)
			                  && !string.IsNullOrEmpty(txtPaymentTerm.Text)
			                  && dgv.Rows.Count > 0;
		} // end UpdateUI

		private void GetCustomer()
		{
			//using (Views.CustomerView.CustomerSearch _cust = new Views.CustomerView.CustomerSearch())
			//{
			//	_cust.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			//	if (_cust.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			//	{
			//		this.txtCustomer.Text = _cust.CustomerName;
			//		_custId = _cust.CustomerId;
			//		this.txtCustomer.Tag = _cust.CustomerCode;
			//		this.txtAddress.Text = _cust.CustomerAddress;
			//	}
			//}

			//using (Views.Sales.SaleContact _sc = new SaleContact(ActionMode.Selection))
			//{
			//	_sc.StartPosition = FormStartPosition.CenterScreen;
			//	if (_sc.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			//	{
			//		this.txtCustomer.Text = _sc.CompanyName;
			//		this.txtCustomer.Tag = _sc.CustomerCode;
			//		_custId = _sc.CustomerId;
			//		this.txtAddress.Text = _sc.Address;
			//		this.txtCountry.Text = _sc.Country;
			//	}
			//}

			var _contact = new SaleContactController(ActionMode.Selection);
			if (_contact.IsEmptyResult == false)
			{
				txtCustomer.Text = _contact.CustomerName;
				txtCustomer.Tag = _contact.CustomerCode;
				_custId = _contact.CustomerId;
				txtAddress.Text = _contact.CustomerAddress;
				txtCountry.Text = _contact.Country;
			}
		} // end GetCustomer

		private void GetCurrencyList()
		{
			cbxCurrency.DataSource = new ExchangeCurrencyDAL().GetCurrencyUnitList();
			cbxCurrency.DisplayMember = "CURCODE";
			cbxCurrency.ValueMember = "CURCODE";
			cbxCurrency.SelectedValue = "USD";
		} // end GetCurrencyList

		private void GetPI(int PIId)
		{
			var _pi = new PI_INVOICE();

			switch (_mode)
			{
				case ActionMode.Add:
					dtpPIDate.Value = DateTime.Today;
					chkAutoCreatePINumber.Checked = true;
					txtAddress.Text = _pi.PI_ADDRESS;
					txtBankInfo.Text = _pi.PI_BANKINFO;
					txtCountry.Text = _pi.PI_COUNTRY;
					txtCustomer.Text = _pi.PI_CUSTNAME;
					txtDeliveryTerm.Text = _pi.PI_DELIVERY_TERM;
					txtDeliveryTime.Text = _pi.PI_DELIVERY_TIME;
					txtPaymentTerm.Text = _pi.PI_PAYMENT_TERM;
					txtPILineTotal.Text = string.Format("{0:N2}", 0);
					txtPackingCost.Text = string.Format("{0:N2}", 0);
					txtDeliveryCost.Text = string.Format("{0:N2}", 0);
					txtPITotalAmount.Text = string.Format("{0:N2}", 0);

					_refPIHeaderId = OMUtils.CreateRandomNumber(omglobal.UserLogId);
					lbRandomId.Text = _refPIHeaderId.ToString();
					break;

				case ActionMode.Edit:
					_pi = new SaleDAL().GetPIHeaderInfo(PIId);
					dtpPIDate.Value = _pi.PI_DATE;
					txtPINumber.Text = _pi.PINO;
					txtAddress.Text = _pi.PI_ADDRESS;
					txtBankInfo.Text = _pi.PI_BANKINFO;
					txtCountry.Text = _pi.PI_COUNTRY;
					txtCustomer.Text = _pi.PI_CUSTNAME;
					txtDeliveryTerm.Text = _pi.PI_DELIVERY_TERM;
					txtDeliveryTime.Text = _pi.PI_DELIVERY_TIME;
					txtPaymentTerm.Text = _pi.PI_PAYMENT_TERM;
					txtPILineTotal.Text = string.Format("{0:N2}", _pi.PI_LINE_TOTAL);
					txtPackingCost.Text = string.Format("{0:N2}", _pi.PI_PACKING);
					txtDeliveryCost.Text = string.Format("{0:N2}", _pi.PI_DELIVERY);
					txtPITotalAmount.Text = string.Format("{0:N2}", _pi.PI_TOTAL_VALUES);
					cbxCurrency.SelectedValue = _pi.PI_CURRENCY;
					_refPIHeaderId = 0;
					lbRandomId.Text = "";
					break;
			}

			// loading PI-Line record
			tsbtnRefresh.PerformClick();

			// map data to control

			UpdateUI();
		} // end PIId

		private void UpdatePI(int PIHeaderId)
		{
			var _pi = new PI_INVOICE();

			if (PIHeaderId > 0) // edit
			{
				_pi = new SaleDAL().GetPIHeaderInfo(PIHeaderId);
			}
			else // new PI
			{
				if (chkAutoCreatePINumber.Checked)
				{
					_piCountNumber = new PIController().GetMaxPINumber() + 1;
					var _newPI = OMShareMethods.GetOMNumberThaiFormat(_piCountNumber);
					_pi.PI_COUNT = _piCountNumber;
					_pi.PINO = _newPI;
				}
				else
				{
					_pi.PINO = txtPINumber.Text;
				}
			}

			// debug PI-Number and Counter
			//	MessageBox.Show(string.Format(" PI-Counter : {0} \n\n PI-Number : {1}", _piCountNumber, _pi.PINO));
			// end debug

			_pi.CREATEUSER = string.IsNullOrEmpty(_pi.CREATEUSER) ? omglobal.UserName : _pi.CREATEUSER;
			_pi.LASTUPDATE = DateTime.Now;
			_pi.MODIUSER = omglobal.UserName;
			_pi.PI_ADDRESS = txtAddress.Text;
			_pi.PI_BANKINFO = txtBankInfo.Text;
			_pi.PI_COUNTRY = txtCountry.Text;
			_pi.PI_CURRENCY = cbxCurrency.Text;
			_pi.PI_CUSTCODE = txtCustomer.Tag == null ? string.Empty : txtCustomer.Tag.ToString();
			_pi.PI_CUSTID = _custId;
			_pi.PI_CUSTNAME = txtCustomer.Text;
			_pi.PI_DATE = dtpPIDate.Value;
			_pi.PI_DELIVERY_TERM = txtDeliveryTerm.Text;
			_pi.PI_DELIVERY_TIME = txtDeliveryTime.Text;
			_pi.PI_PAYMENT_TERM = txtPaymentTerm.Text;
			_pi.PI_LINE_TOTAL = Convert.ToDecimal(txtPILineTotal.Text);
			_pi.PI_PACKING = Convert.ToDecimal(txtPackingCost.Text);
			_pi.PI_DELIVERY = Convert.ToDecimal(txtDeliveryCost.Text);
			_pi.PI_TOTAL_VALUES = Convert.ToDecimal(txtPITotalAmount.Text);
			_pi.PI_YEAR = dtpPIDate.Value.Year;


			if (new SaleDAL().UpdatePIHeader(_pi) > 0)
				if (_mode == ActionMode.Add)
				{
					// find new ID for PL-Header after insert the record completed
					//
					var _latestPIId = new SaleDAL().GetLatestPIHeaderId();
					if (dgv.Rows.Count > 0)
						if (new SaleDAL().UpdateRefPIHeaderIdInPILine(_latestPIId, _refPIHeaderId) > 0)
							MessageBox.Show("Update reference index completed....", "Message", MessageBoxButtons.OK,
								MessageBoxIcon.Information);
				}

			MessageBox.Show("Update Completed...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
		} // end Update PI

		private void GetPILineList(int Id)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new SaleDAL().GetPIItemList(Id);

			// format datagridview columns
			dgv.Columns["PI_ID"].Visible = false;
			dgv.Columns["PI_ITEM"].Visible = false;

			dgv.Columns["QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["QTY"].DefaultCellStyle.Format = "N2";

			dgv.Columns["UNITPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["UNITPRICE"].DefaultCellStyle.Format = "N2";

			dgv.Columns["AMOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["AMOUNT"].DefaultCellStyle.Format = "N2";

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();

			// update UI
			UpdateUI();

			// update TotalPILineAmount
			UpdateTotalPIAmount();
		} // end GetPILineList


		private void AddEditPILine(int PILineId)
		{
			using (var _pil = new PILines(PILineId, _mode == ActionMode.Add ? _refPIHeaderId : PIHeaderId, txtPINumber.Text))
			{
				_pil.StartPosition = FormStartPosition.CenterScreen;
				_pil.PIHeaderMode = _mode;
				_pil.Currency = cbxCurrency.Text;
				_pil.ShowDialog(this);
			}
			// re-load PI-Lines
			tsbtnRefresh.PerformClick();
		} // end AddEditPILine

		private void UpdateTotalPIAmount()
		{
			//if(this.dgv.Rows.Count > 0 )
			//{
			//	lineTotal = ((DataTable)this.dgv.DataSource).AsEnumerable().Sum(x => x.Field<decimal>("AMOUNT"));
			//}

			var lineTotal = dgv.Rows.Count > 0
				? ((DataTable) dgv.DataSource).AsEnumerable().Sum(x => x.Field<decimal>("AMOUNT"))
				: 0.00m;

			var packing = string.IsNullOrEmpty(txtPackingCost.Text) ? 0.00m : Convert.ToDecimal(txtPackingCost.Text);
			var delivery = string.IsNullOrEmpty(txtDeliveryCost.Text) ? 0.00m : Convert.ToDecimal(txtDeliveryCost.Text);

			txtPILineTotal.Text = string.Format("{0:N2}", lineTotal);
			txtPITotalAmount.Text = string.Format("{0:N2}", lineTotal + packing + delivery);
		} // UpdateTotalPILineAmount

		#endregion
	}
}