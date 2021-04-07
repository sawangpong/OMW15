using Microsoft.VisualBasic;
using OMControls;
using OMW15.Controllers.SaleController;
using OMW15.Controllers.ToolController;
using OMW15.Models.SaleModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.Sales
{
	public partial class QTInfo : Form
	{
		#region class field members

		private QUOTATIONHH _qtHeader;
		private ActionMode _headerMode = ActionMode.None;
		private readonly bool _isPosted; // this flag using for control posting data
		private string _qtPrefix = string.Empty;
		private string _QTNO = string.Empty;
		private string _curr = "USD";
		private int _qtMaxNumber;
		private int _refHIndex;
		private int _selectedQTLineId;
		private int _customerId;
		private decimal _qtLineTotal;
		private decimal _discount;
		private decimal _extraDiscount;
		private decimal _netQTValues;
		private decimal _vatValues;
		private decimal _totalGoodsValues;
		private decimal _packingCost;
		private decimal _shippingCost;
		private decimal _totalAmount;
		private decimal _VATFactor = omglobal.DEFAULT_SYSTEM_VAT_FACTOR;
		#endregion

		#region class property

		public int QuotationId { get; set; }

		public bool MasterQuotation { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			lbMode.Text = _headerMode.ToString();

			switch (_headerMode)
			{
				case ActionMode.Add:
					rdoLocal.Enabled = true;
					rdoInter.Enabled = rdoLocal.Enabled;
					rdoMaster.Enabled = rdoLocal.Enabled;
					break;
				case ActionMode.Edit:
					rdoLocal.Enabled = false;
					rdoInter.Enabled = rdoLocal.Enabled;
					rdoMaster.Enabled = rdoLocal.Enabled;
					txtQTRev.Enabled = true;
					cbxQTStatus.Enabled = rdoMaster.Checked ? false : true;
					break;
			}
			chkAutoNumber.Enabled = _headerMode == ActionMode.Add;
			txtQTNO.Enabled = _headerMode == ActionMode.Add
									&& chkAutoNumber.Checked == false;
			lnkCopyFromMaster.Visible = rdoMaster.Checked == false
												 && _headerMode == ActionMode.Add;


			lb.Text = string.Format("[id : {0}] [Status : {1}] [Master : {2}]", QuotationId, cbxQTStatus.Text,
				rdoMaster.Checked ? "Y" : "N");

			btnSave.Enabled = string.IsNullOrEmpty(txtCustomerName.Text) == false;
		} // end UpdateUI


		private void GetQTStatusList()
		{
			cbxQTStatus.DataSource = EnumWithName<OMShareSaleEnum.QoutationStatus>.ParseEnum();
			cbxQTStatus.DisplayMember = "Name";
			cbxQTStatus.ValueMember = "Value";
		} // end GetQTStatusList

		private void GetVATList()
		{
			var dt = new SelectOptions().GetVatRateData();
			cbxVAT.DataSource = dt;
			cbxVAT.DisplayMember = "VALUE";
			cbxVAT.ValueMember = "KEY";
		}

		private void GetQuotationInfo(int QuotationId)
		{
			// create Quotation object
			// load Quotation info
			switch (_headerMode)
			{
				case ActionMode.Add:
					// generate the reference id
					_refHIndex = OMUtils.CreateRandomNumber(45000);
					this.QuotationId = _refHIndex;

					// create QUOTATION HEADER OBJECT
					_qtHeader = new QUOTATIONHH();

					cbxQTStatus.SelectedValue = (int)OMShareSaleEnum.QoutationStatus.Active;
					chkAutoNumber.Checked = true;
					rdoInter.Checked = true;
					txtQTNO.Text = "***NEW***";
					txtQTRev.Text = "0";
					dtpQTDate.Value = DateTime.Today;
					dtpValidate.Value = DateTime.Today.AddMonths(6);
					cbxVAT.SelectedValue = omglobal.DEFAULT_SYSTEM_VAT;
					break;

				case ActionMode.Edit:

					// LOAD QUOTATION VALUE
					_qtHeader = new SaleQTDAL().GetQuotationHeader(QuotationId);

					_refHIndex = _qtHeader.QT_ID;
					chkAutoNumber.Checked = false;
					txtQTNO.Text = _qtHeader.QT_NUMBER;
					rdoMaster.Checked = _qtHeader.QT_PREFIX == "QM";
					rdoInter.Checked = _qtHeader.QT_PREFIX == "QI";
					rdoLocal.Checked = _qtHeader.QT_PREFIX == "QL";

					txtQTRev.Text = _qtHeader.QT_REVISION.ToString();
					dtpQTDate.Value = _qtHeader.QT_DATE;
					dtpValidate.Value = _qtHeader.QT_VALIDATIONDATE;
					cbxQTStatus.SelectedValue = _qtHeader.QT_STATUS;
					break;
			}

			// binding value
			lbRefIdx.Text = _refHIndex.ToString();

			txtQTLineTotal.Text = string.Format("{0:N2}", _qtHeader.QT_TOTALVALUEITEMS);
			txtDiscount.Text = string.Format("{0:N2}", _qtHeader.QT_TOTALDISCOUNT);
			txtExtraDiscount.Text = string.Format("{0:N2}", _qtHeader.QT_EXTRADISCOUNT);
			txtNetQTLineTotal.Text = string.Format("{0:N2}", _qtHeader.QT_TOTALNETTVALUES);
			cbxVAT.SelectedValue = (_qtHeader.QT_VATRATE * 100.0m);
			ntxtVatValue.Text = $"{_qtHeader.QT_VATVALUES:N2}";
			ntxtTotalGoodAmount.Text = $"{_qtHeader.QT_TOTALGOODSAMT:N2}";
			txtPackingCost.Text = string.Format("{0:N2}", _qtHeader.QT_PACKINGVALUE);
			txtShippingCost.Text = string.Format("{0:N2}", _qtHeader.QT_SHIPPINGVALUE);
			txtQTTotalAmont.Text = string.Format("{0:N2}", _qtHeader.QT_TOTALAMOUNT);

			txtAddress.Text = _qtHeader.QT_ADDRESS;
			txtContactPerson.Text = _qtHeader.QT_CONTACT_PERSON;
			txtCountry.Text = _qtHeader.QT_COUNTRY;
			txtCustomerName.Text = _qtHeader.QT_CUSTOMER;
			txtCustomerName.Tag = _qtHeader.QT_CUSTCODE;
			_customerId = _qtHeader.QT_CUSTID;
			txtDeliverySchedule.Text = _qtHeader.QT_DELIVERY_TIME;
			txtDeliveryTerm.Text = _qtHeader.QT_DELIVERY_TERM;
			txtEmail.Text = _qtHeader.QT_CUST_EMAIL;
			txtPaymentTerm.Text = _qtHeader.QT_PAYMENT_TERM;
			txtBankInfo.Text = _qtHeader.QT_BANKINFO;
			txtSaleContactNumber.Text = _qtHeader.QT_SALE_CONTACTNO;
			txtSaleEmail.Text = _qtHeader.QT_SALE_EMAIL;
			txtSalePerson.Text = _qtHeader.QT_SALE_PERSON;
			txtTelMobile.Text = _qtHeader.QT_CONTACTNO;
			txtTraining.Text = _qtHeader.QT_TRAINING;
			txtWarranty.Text = _qtHeader.QT_WARRANTY;
			txtRemark.Text = _qtHeader.QT_REMARK;

			// load QUOTATION LINE
			GetQuotationLines(this.QuotationId);

			UpdateUI();
		} // end GetQuotationInfo


		private void UpdateQTLineUI()
		{
			tsbtnEdit.Enabled = _selectedQTLineId > 0;
			tsbtnDelete.Enabled = tsbtnEdit.Enabled;
		} // end UpdateQTLineUI

		private void CalQuotationLineValues()
		{
			_qtLineTotal = dgv.Rows.Count > 0
				? ((DataTable)dgv.DataSource).AsEnumerable().Sum(x => x.Field<decimal>("TOTAL"))
				: 0.00m;

			txtQTLineTotal.Text = string.Format("{0:N2}", _qtLineTotal);
		} // end CalQuotationLineValues

		private void CalQuotationValues(decimal QTLineTotalValues)
		{
			_discount = Information.IsNumeric(txtDiscount.Text) ? Convert.ToDecimal(txtDiscount.Text) : 0.00m;
			_extraDiscount = Information.IsNumeric(txtExtraDiscount.Text) ? Convert.ToDecimal(txtExtraDiscount.Text) : 0.00m;

			_netQTValues = (QTLineTotalValues - _discount - _extraDiscount);

			_vatValues = Convert.ToDecimal(ntxtVatValue.Text);
			_totalGoodsValues = Convert.ToDecimal(ntxtTotalGoodAmount.Text);

			_packingCost = Information.IsNumeric(txtPackingCost.Text) ? Convert.ToDecimal(txtPackingCost.Text) : 0.00m;

			_shippingCost = Information.IsNumeric(txtShippingCost.Text) ? Convert.ToDecimal(txtShippingCost.Text) : 0.00m;

			_totalAmount = (_totalGoodsValues + _packingCost + _shippingCost);

			// display cal values
			txtDiscount.Text = string.Format("{0:N2}", _discount);
			txtExtraDiscount.Text = string.Format("{0:N2}", _extraDiscount);
			txtNetQTLineTotal.Text = string.Format("{0:N2}", _netQTValues);
			txtPackingCost.Text = string.Format("{0:N2}", _packingCost);
			txtShippingCost.Text = string.Format("{0:N2}", _shippingCost);
			txtQTTotalAmont.Text = string.Format("{0:N2}", _totalAmount);

		} // end CalQuotationValues

		private void GetQuotationLines(int QuotationId)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new SaleQTDAL().GetQuotationItems(QuotationId);

			// formatting datagridview
			dgv.Columns["ID"].Visible = false;
			dgv.Columns["REFID"].Visible = false;
			dgv.Columns["ITEMINFO"].Visible = false;
			dgv.Columns["AUDITUSER"].Visible = false;
			dgv.Columns["MODIUSER"].Visible = false;
			dgv.Columns["MODIDATE"].Visible = false;

			// format columns
			dgv.Columns["ITEMNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["CURR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns["QTY"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgv.Columns["UNITPRICE"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgv.Columns["TOTAL"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgv.ResumeLayout();
			_selectedQTLineId = 0;

			// update QT line UI
			UpdateQTLineUI();

			CalQuotationLineValues();
			CalQuotationValues(Convert.ToDecimal(txtQTLineTotal.Text));

		} // end GetQuotationLines


		private void GetQTLineInfo(int QTLineId, string currency)
		{
			// call QTLine Item info
			using (var _qlinfo = new QTLineInfo(QTLineId, _refHIndex, currency))
			{
				_qlinfo.Currency = currency;
				_qlinfo.StartPosition = FormStartPosition.CenterScreen;

				if (_qlinfo.ShowDialog(this) == DialogResult.OK)
				{
				}
			}

			dgv.Refresh();
			tsbtnRefresh.PerformClick();
		} // end GetQTLineInfo

		private void UpdateQuotation(int QTHeaderId)
		{
			var _qt = new QUOTATIONHH();

			if (QTHeaderId > 0) // edit + update
			{
				_qt = new SaleQTDAL().GetQuotationHeader(QTHeaderId);
			}
			else // insert new QUOTATION
			{
				_qt.QT_PREFIX = _qtPrefix;
				_qt.AUDITUSER = omglobal.UserName;
				_qt.QT_REF_KEY = _refHIndex;
				_qtMaxNumber = new SaleQuotationController().GetMaxQuotationNumber(_qtPrefix) + 1;

				if (rdoMaster.Checked)
				{
					_qt.QT_COUNT = _qtMaxNumber;
					_qt.QT_NUMBER = OMShareMethods.GetOMNumberThaiFormat(_qtMaxNumber);
				}
				else
				{
					if (chkAutoNumber.Checked)
					{
						_qt.QT_COUNT = _qtMaxNumber;
						_qt.QT_NUMBER = OMShareMethods.GetOMNumberThaiFormat(_qtMaxNumber);
					}
					else
					{
						_qt.QT_NUMBER = txtQTNO.Text;
						_qt.QT_COUNT = Convert.ToInt32(txtQTNO.Text.Substring(txtQTNO.Text.LastIndexOf("-")));
					}
				}
			}

			_qt.QT_INBOUND = rdoLocal.Checked ? true : false;
			_qt.QT_MASTER = rdoMaster.Checked ? true : false;
			_qt.QT_REVISION = Convert.ToInt32(txtQTRev.Text);
			_qt.QT_STATUS = Convert.ToInt32(cbxQTStatus.SelectedValue);
			_qt.QT_CURRENCY = _curr;
			_qt.QT_CUSTID = _customerId;
			_qt.QT_CUSTCODE = string.IsNullOrEmpty(txtCustomerName.Tag.ToString()) ? "" : txtCustomerName.Tag.ToString();
			_qt.QT_CUSTOMER = txtCustomerName.Text;
			_qt.QT_ADDRESS = txtAddress.Text;
			_qt.QT_COUNTRY = txtCountry.Text;
			_qt.QT_CONTACTNO = txtTelMobile.Text;
			_qt.QT_CONTACT_PERSON = txtContactPerson.Text;
			_qt.QT_CUST_EMAIL = txtEmail.Text;
			_qt.QT_SALE_CONTACTNO = txtSaleContactNumber.Text;
			_qt.QT_SALE_EMAIL = txtSaleEmail.Text;
			_qt.QT_SALE_PERSON = txtSalePerson.Text;
			_qt.QT_BANKINFO = txtBankInfo.Text;
			_qt.QT_YEAR = dtpQTDate.Value.Year;
			_qt.QT_DATE = dtpQTDate.Value;
			_qt.QT_VALIDATIONDATE = dtpValidate.Value;
			_qt.QT_DELIVERY_TERM = txtDeliveryTerm.Text;
			_qt.QT_DELIVERY_TIME = txtDeliverySchedule.Text;
			_qt.QT_PAYMENT_TERM = txtPaymentTerm.Text;
			_qt.QT_TRAINING = txtTraining.Text;
			_qt.QT_WARRANTY = txtWarranty.Text;
			_qt.QT_TOTALVALUEITEMS = _netQTValues;
			_qt.QT_TOTALDISCOUNT = Convert.ToDecimal(txtDiscount.Text);
			_qt.QT_EXTRADISCOUNT = Convert.ToDecimal(txtExtraDiscount.Text);
			_qt.QT_TOTALNETTVALUES = Convert.ToDecimal(txtNetQTLineTotal.Text);
			_qt.QT_VATRATE = _VATFactor;
			_qt.QT_VATVALUES = Convert.ToDecimal(ntxtVatValue.Text);
			_qt.QT_TOTALGOODSAMT = Convert.ToDecimal(ntxtTotalGoodAmount.Text);
			_qt.QT_PACKINGVALUE = Convert.ToDecimal(txtPackingCost.Text);
			_qt.QT_SHIPPINGVALUE = Convert.ToDecimal(txtShippingCost.Text);
			_qt.QT_TOTALAMOUNT = Convert.ToDecimal(txtQTTotalAmont.Text);
			_qt.QT_REMARK = txtRemark.Text;
			_qt.MODIDATE = DateTime.Now;
			_qt.MODIUSER = omglobal.UserName;


			// updating Quotation Header and Lines
			if (new SaleQTDAL().InsertUpdateQuotationHeader(_qt) > 0)
			{
				if (_headerMode == ActionMode.Add)
				{
					// updating Quotation Line by changing the refIndex in QUOTATIONLL to 
					// current QUOTATIONHH ID
					var _latestQuotationHeaderIndex = new SaleQTDAL().GetLatestQuotationHeaderId();
					if (dgv.Rows.Count > 0)
						if (new SaleQTDAL().UpdateRefQTHeaderIdInQTLine(_latestQuotationHeaderIndex, _refHIndex) > 0)
							MessageBox.Show("Update Quotation line completed...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				MessageBox.Show(string.Format("Complete {0} Quotation!.", _headerMode == ActionMode.Add ? "insert" : "update"),
					"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		} // end UpdateQuotation


		private void ClearUnpostedQuotation(int QuotationId)
		{
			if (new SaleQuotationController().ClearUnpostedQuotationData(QuotationId) > 0)
				MessageBox.Show("Un-posting record(s) was cleared....", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		} // end ClearUnpostedQuotation


		private void CalQTVAT(decimal VATFactor)
		{
			ntxtVatValue.Text = $"{(VATFactor * Convert.ToDecimal(txtNetQTLineTotal.Text)):N2}";
			ntxtTotalGoodAmount.Text = $"{(Convert.ToDecimal(ntxtVatValue.Text) + Convert.ToDecimal(txtNetQTLineTotal.Text)):N2}";

			CalQuotationValues(Convert.ToDecimal(txtQTLineTotal.Text));

		}




		#endregion


		// Constructor
		public QTInfo(int QTId)
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgv);

			pnlHeader.BackColor = omglobal.OM_GREEN_COLOR;

			rdoInter.Checked = false;
			QuotationId = QTId;

			_headerMode = QuotationId == 0 ? ActionMode.Add : ActionMode.Edit;
			_isPosted = _headerMode == ActionMode.Add ? false : true;
			tpHeader.Text = string.Format("Quotation Header {0}", _isPosted ? "<< POSTED >>" : "");
		}

		private void QTInfo_Load(object sender, EventArgs e)
		{
			GetQTStatusList();
			GetVATList();

			GetQuotationInfo(QuotationId);
		}

		private void rdo_CheckedChanged(object sender, EventArgs e)
		{
			var _rdo = sender as RadioButton;
			_qtPrefix = _rdo.Tag.ToString().ToUpper();

			if (_rdo.Checked)
			{
				switch (_qtPrefix)
				{
					case "QL":
						_curr = "THB";
						break;

					case "QI":
					case "QM":
						_curr = "USD";
						break;
				}

				switch (_qtPrefix)
				{
					case "QI":
					case "QL":
						if (rdoMaster.Checked == false
							 && _headerMode == ActionMode.Add)
						{
							cbxQTStatus.SelectedValue = (int)OMShareSaleEnum.QoutationStatus.Active;
							cbxQTStatus.Enabled = true;
							chkAutoNumber.Checked = true;
							chkAutoNumber.Enabled = true;
							txtQTNO.Text = "***NEW***";
							txtQTRev.Text = "0";
							txtQTNO.Enabled = false;
							txtQTRev.Enabled = txtQTNO.Enabled;
						}

						break;
					case "QM":
						if (rdoMaster.Checked
							 && _headerMode == ActionMode.Add)
						{
							cbxQTStatus.SelectedValue = (int)OMShareSaleEnum.QoutationStatus.None;
							cbxQTStatus.Enabled = false;
							chkAutoNumber.Checked = true;
							chkAutoNumber.Enabled = false;
							txtQTNO.Text = "**MASTER**";
							txtQTNO.Enabled = false;
							txtQTRev.Text = "0";
							txtQTRev.Enabled = txtQTNO.Enabled;
						}
						else
						{
							cbxQTStatus.Enabled = _headerMode == ActionMode.Edit && rdoMaster.Checked ? false : true;
						}
						break;
				}

				lbCurrency.Text = _curr;
				lbLinetotal.Text = $"Total ({_curr})";
				lbDiscount.Text = $"Discount ({_curr})";
				lbExtra.Text = $"Extra discount ({_curr})";
				lbNett.Text = $"Nett Total ({_curr})";
				lbPacking.Text = $"Packing Cost ({_curr})";
				lbShipping.Text = $"Shipping Cost ({_curr})";
				lbAmount.Text = $"Total Amount ({_curr})";
			}
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedQTLineId = Convert.ToInt32(dgv["ID", e.RowIndex].Value);
			txtItemInfo.Text = dgv["ITEMINFO", e.RowIndex].Value.ToString();

			tslbSelectedQTLineIndex.Text = string.Format("idx:{0}", _selectedQTLineId);
			UpdateQTLineUI();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			GetQTLineInfo(_selectedQTLineId = 0, _curr);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			GetQTLineInfo(_selectedQTLineId, _curr);
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			if (
				MessageBox.Show("Do you want to delele the selected record?", "DELETE", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
				if (new SaleQTDAL().DeleteQuotationLine(_selectedQTLineId) > 0)
					MessageBox.Show("Delete record completed..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			tsbtnRefresh.PerformClick();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetQuotationLines(QuotationId);
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			CalQTVAT(_VATFactor);
			CalQuotationValues(Convert.ToDecimal(txtQTLineTotal.Text));
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			UpdateQuotation(_headerMode == ActionMode.Add ? 0 : QuotationId);
		}

		private void chkAutoNumber_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoMaster.Checked == false)
			{
				txtQTNO.Enabled = chkAutoNumber.Checked == false;
				txtQTNO.Text = chkAutoNumber.Checked ? "***NEW***" : "";
				txtQTRev.Enabled = txtQTNO.Enabled;
			}
		}

		private void dtpQTDate_ValueChanged(object sender, EventArgs e)
		{
			if (Information.IsDate(dtpQTDate.Value))
				dtpValidate.Value = dtpQTDate.Value.AddMonths(6);
		}

		private void btnCustomerFromContact_Click(object sender, EventArgs e)
		{
			var _contact = new SaleContactController(ActionMode.Selection);
			if (_contact.IsEmptyResult == false)
			{
				txtContactPerson.Text = _contact.ContactPerson;
				txtCountry.Text = _contact.Country;
				txtCustomerName.Text = _contact.CustomerName;
				txtCustomerName.Tag = _contact.CustomerCode;
				_customerId = _contact.CustomerId;
				txtAddress.Text = _contact.CustomerAddress;
				txtEmail.Text = _contact.CustomerEmail;
				txtTelMobile.Text = _contact.ContactNumber;
			}
			else
			{
				txtCustomerName.Tag = "";
				_customerId = 0;
			}
		}

		private void btnBankInfo_Click(object sender, EventArgs e)
		{
			var _bank = new BankController(ActionMode.Selection);
			if (_bank.IsEmptyResult == false)
				txtBankInfo.Text = _bank.BankInfo;
		}

		private void cbxQTStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btn_Click(object sender, EventArgs e)
		{
			var _btn = sender as OMFlatButton;
			var _tag = _btn.Tag.ToString().ToUpper();
			var _option = OMShareSaleEnum.SaleQuotationOptions.None;

			switch (_tag)
			{
				case "COUNTRY":
					_option = OMShareSaleEnum.SaleQuotationOptions.Country;
					break;

				case "SALEMAN":
					_option = OMShareSaleEnum.SaleQuotationOptions.SalePerson;
					break;

				case "DEL_TERM":
					_option = OMShareSaleEnum.SaleQuotationOptions.DeliveryTerm;
					break;

				case "DEL_TIME":
					_option = OMShareSaleEnum.SaleQuotationOptions.DeliveryTime;
					break;

				case "PAY_TERM":
					_option = OMShareSaleEnum.SaleQuotationOptions.PaymentTerm;
					break;

				case "TRAINING":
					_option = OMShareSaleEnum.SaleQuotationOptions.Training;
					break;

				case "WARRANTY":
					_option = OMShareSaleEnum.SaleQuotationOptions.Warranty;
					break;
			}

			var _opt = new SaleOptionController(_option);

			// debug
			// MessageBox.Show(_opt.Value, "DEBUG");
			// end debug


			if (_opt.IsEmptyResult == false)
				switch (_tag)
				{
					case "COUNTRY":
						txtCountry.Text = _opt.Value;
						break;

					case "SALEMAN":
						txtSalePerson.Text = _opt.Value;
						break;

					case "DEL_TERM":
						txtDeliveryTerm.Text = _opt.Value;
						break;

					case "DEL_TIME":
						txtDeliverySchedule.Text = _opt.Value;
						break;

					case "PAY_TERM":
						txtPaymentTerm.Text = _opt.Value;
						break;

					case "TRAINING":
						txtTraining.Text = _opt.Value;
						break;

					case "WARRANTY":
						txtWarranty.Text = _opt.Value;
						break;
				}
		}

		private void txtCustomerName_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtCustomerName.Text))
			{
				txtCustomerName.Tag = string.Empty;
				_customerId = 0;
			}

			UpdateUI();
		}

		private void btnSalePerson_Click(object sender, EventArgs e)
		{
			var _sm = new SalePersonController(ActionMode.Selection);
			if (_sm.IsEmptyResult == false)
			{
				txtSaleContactNumber.Text = _sm.SaleContractNo;
				txtSaleEmail.Text = _sm.SaleEmail;
				txtSalePerson.Text = _sm.SalePersonName;
			}
		}

		private void txtSalePerson_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtSalePerson.Text))
			{
				txtSaleEmail.Text = "";
				txtSaleContactNumber.Text = "";
			}
		}

		private void lnkCopyFromMaster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var _selectedMasterQuotationId = 0;

			var _getMaster = new MasterQTController(OMShareSaleEnum.MasterQuotationListStyle.QuotationHeader, _curr);

			if (_getMaster.IsEmptyResult == false)
			{
				_selectedMasterQuotationId = _getMaster.MasterQuotationId;

				var _copyQT = new SaleQuotationController();

				if ((QuotationId = _copyQT.CopyMasterQuotation(_selectedMasterQuotationId, _curr, _qtPrefix)) > 0)
				{
					MessageBox.Show("Copy Quotation completed.", "COPY QUOTATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

					_headerMode = QuotationId == 0 ? ActionMode.Add : ActionMode.Edit;
					GetQuotationInfo(QuotationId);
				}
			}
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void txt_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
			{
				CalQTVAT(_VATFactor);
				CalQuotationValues(Convert.ToDecimal(txtQTLineTotal.Text));
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (_isPosted == false)
				if (
					MessageBox.Show("Do you want to cancel this quotation without save?", "CANCEL QUOTATION", MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)
					ClearUnpostedQuotation(QuotationId);
		} // end 

		private void cbxVAT_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_VATFactor = Convert.ToDecimal(cbxVAT.SelectedValue) / 100.00m;
				lbVATFactor.Text = $"{_VATFactor}";
			}
			catch
			{
				_VATFactor = 0.00m;
			}

			CalQTVAT(_VATFactor);
		}


	} // end class
} // end namespace