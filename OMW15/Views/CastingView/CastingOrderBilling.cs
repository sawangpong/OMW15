using GAF;
using Microsoft.VisualBasic;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingOrderBilling : Form
	{
		// CONSTRUCTOR
		public CastingOrderBilling(string CustomerCode = "", string CustomerName = "", int BillingNo = 0)
		{
			InitializeComponent();

			CenterToParent();
			OMUtils.SettingDataGridView(ref dgvSO);
			OMUtils.SettingDataGridView(ref dgvBL);

			dgvSO.MultiSelect = true;

			_customerCode = CustomerCode;
			_customerName = CustomerName;
			_billId = BillingNo;

			_isCallByCustomer = !string.IsNullOrEmpty(CustomerCode);

			lbMode.Text = (_mode = _billId == 0 ? ActionMode.Add : ActionMode.Edit).ToString();
			lbCustomerCode.Text = _customerCode;
			lbCustomerName.Text = _customerName;
		}


		private void CastingOrderBilling_Load(object sender, EventArgs e)
		{
			if (_customerCode != "") GetBillingHeaderInfo(_billId, _customerCode);
		}

		private void btnClose_Click(object sender, EventArgs e) => Close();

		private void dgvSO_SelectionChanged(object sender, EventArgs e) => UpdateUI();

		private void btnAddToBilling_Click(object sender, EventArgs e)
		{
			// add selected items into dgvBL
			foreach (DataGridViewRow dgr in dgvSO.SelectedRows)
			{
				var _dr = _dtBL.NewRow();
				_dr["BILLLINGSEQ"] = 0;
				_dr["SALETYPE"] = dgr.Cells["SALETYPE"].Value;
				_dr["BILLID"] = dgr.Cells["BILLSEQ"].Value;
				_dr["SOSEQ"] = dgr.Cells["SOSEQ"].Value;
				_dr["SONO"] = dgr.Cells["SONO"].Value;
				_dr["ORDERDATE"] = dgr.Cells["ORDERDATE"].Value;
				_dr["TOTALVALUE"] = dgr.Cells["TOTALVALUE"].Value;
				_dr["DISCOUNT"] = dgr.Cells["DISCOUNT"].Value;
				_dr["NETVALUE"] = dgr.Cells["NETVALUE"].Value;
				_dr["TOTALVAT"] = dgr.Cells["TOTALVAT"].Value;
				_dr["TOTALAMOUNT"] = dgr.Cells["TOTALAMOUNT"].Value;
				_dtBL.Rows.Add(_dr);
			}

			dgvBL.SuspendLayout();
			dgvBL.DataSource = _dtBL;

			// formatting DataGridView
			foreach (DataGridViewColumn dgc in dgvBL.Columns)
			{
				dgc.Visible = false;
				if (dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
			}
			dgvBL.ResumeLayout();

			// visible only need columns
			FormattingBLGrid();

			// remove selected items from dgvSO
			foreach (DataGridViewRow dgr in dgvSO.SelectedRows)
			{
				dgvSO.Rows.RemoveAt(dgr.Index);
			}

			// cal remain summary
			GetSOSummary();
			GetBLSummary();
		}

		private void btnCustomer_Click(object sender, EventArgs e)
		{
			using (var customers = new CastingOrderCustomers(""))
			{
				customers.StartPosition = FormStartPosition.CenterScreen;
				if (customers.ShowDialog(this) == DialogResult.OK)
				{
					_customerName = customers.CustomerName;
					_customerCode = customers.CustomerCode;
					lbCustomerName.Text = _customerName;
					lbCustomerCode.Text = _customerCode;
					GetCustomerInfo(_customerCode);
					btnLoadData.PerformClick();
				}
			}

			UpdateUI();
		}

		private void btnLoadData_Click(object sender, EventArgs e) => GetAvailableSOForBilling(lbCustomerCode.Text, _billId);

		private void dgvBL_SelectionChanged(object sender, EventArgs e) => UpdateUI();

		private void rdo_CheckedChanged(object sender, EventArgs e)
		{
			var _rdo = sender as RadioButton;
			if (_rdo.Checked)
				switch (_rdo.Tag.ToString())
				{
					case "LABOUR":
						_isLabourCharge = true;
						break;
					case "MAT":
						_isLabourCharge = false;
						break;
				}

			GetAvailableSOForBilling(_customerCode, _billId);
		}

		private void btnSave_Click(object sender, EventArgs e) => UpdateBillHeaderInfo(_billId);

		private void dtpDueDate_ValueChanged(object sender, EventArgs e)
		{
			// the rule is duedate must be grater than billing date

			if (DateAndTime.DateDiff(DateInterval.Day, dtpBillingDate.Value, dtpDueDate.Value) < 0)
			{
				MessageBox.Show("วันที่ครบกำหนดต้องมากกว่าวันที่เปิดใบวางบิล", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				// reset current date to duedate
				dtpDueDate.Value = DateTime.Today;
			}

			lbStatus.Text = DateAndTime.DateDiff(DateInterval.Day, dtpDueDate.Value, DateTime.Today) <= 0 ? "NORMAL" : "WARNING";
		}

		private void btnDeleteFromBilling_Click(object sender, EventArgs e)
		{
			// first add the selected item back to datatable of SO-List
			dgvBL.SuspendLayout();

			if (_selectedBLLineIdFromBLList > 0)
			{
				// update SO Header (SALEORDERS - TABLE)
				// and reload 

				var _om = new OLDMOONEF1();
				try
				{
					// update SaleOrders
					_om.SALEORDERS.Where(x => x.SOSEQ == _selectedSOIdFromBLList).ToList().ForEach(c =>
					{
						c.BILLNO = "";
						c.BILLDATE = 0;
						c.BILLDUEDATE = 0;
						c.BILLSEQ = 0;
						c.ISCOMPLETE = false;
					});
					_om.SaveChanges();

					// remove selected from BILLLINES
					_om.BILLLINES.Remove(_om.BILLLINES.Single(x => x.BILLLINGSEQ == _selectedBLLineIdFromBLList));
					_om.SaveChanges();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't remove record from the list", ex);
				}


				GetAvailableSOForBilling(_customerCode, _billId);
			}
			else
			{
				var _dt = (DataTable)dgvSO.DataSource;
				foreach (DataGridViewRow dgr in dgvBL.SelectedRows)
				{
					var _dr = _dt.NewRow();
					_dr["SOSEQ"] = dgr.Cells["SOSEQ"].Value;
					_dr["BILLSEQ"] = dgr.Cells["BILLID"].Value;
					_dr["SALETYPE"] = dgr.Cells["SALETYPE"].Value;
					_dr["SONO"] = dgr.Cells["SONO"].Value;
					_dr["ORDERDATE"] = dgr.Cells["ORDERDATE"].Value;
					_dr["TOTALVALUE"] = dgr.Cells["TOTALVALUE"].Value;
					_dr["DISCOUNT"] = dgr.Cells["DISCOUNT"].Value;
					_dr["NETVALUE"] = dgr.Cells["NETVALUE"].Value;
					_dr["TOTALVAT"] = dgr.Cells["TOTALVAT"].Value;
					_dr["TOTALAMOUNT"] = dgr.Cells["TOTALAMOUNT"].Value;
					_dt.Rows.Add(_dr);
				}
				dgvSO.DataSource = _dt;

				// remove the selected row from BL-List
				dgvBL.Rows.RemoveAt(dgvBL.SelectedRows[0].Index);
			}

			dgvBL.ResumeLayout();
			FormattingBLGrid();
			GetSOSummary();
			GetBLSummary();
		}

		private void dgvBL_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedSOIdFromBLList = Convert.ToInt32(dgvBL["SOSEQ", e.RowIndex].Value);
			_selectedBLLineIdFromBLList = Convert.ToInt32(dgvBL["BILLLINGSEQ", e.RowIndex].Value);
			UpdateUI();
		}

		#region class field member

		private readonly ActionMode _mode = ActionMode.None;
		private readonly bool _isCallByCustomer;
		private bool _isLabourCharge;
		private string _customerCode = string.Empty;
		private string _customerName = string.Empty;
		private DataTable _dtSO = new DataTable();
		private DataTable _dtBL = new DataTable();
		private readonly int _billId;
		private int _customerId;
		private decimal _vatFactor;
		private int _selectedSOIdFromBLList;
		private int _selectedBLLineIdFromBLList;


		// FOR SO
		private decimal _totalValues;
		private decimal _discount;
		private decimal _netValues;
		private decimal _vatValues;
		private decimal _totalAmount;

		// FOR BL
		private decimal _blTotalValue;
		private decimal _blDiscount;
		private decimal _blNetValue;
		private decimal _blVAT;
		private decimal _blTotalAmount;

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnCustomer.Visible = !_isCallByCustomer;
			btnAddToBilling.Enabled = dgvSO.SelectedRows.Count > 0;
			btnDeleteFromBilling.Enabled = dgvBL.SelectedRows.Count > 0;
			rdoLabour.Enabled = _mode == ActionMode.Add;
			rdoMatCharge.Enabled = rdoLabour.Enabled;
			btnSave.Enabled = dgvBL.Rows.Count > 0; // enabled only when has record in BL Lists
		} // end UpdateUI

		private void GetCustomerInfo(string CustomerCode)
		{
			var _cinfo = new CastingSaleOrderDAL().GetAvailableCustomerInfoForCastingSaleOrder(CustomerCode);
			_customerId = _cinfo.CUSTID;
			_customerName = _cinfo.CUSTNAME;

			if (Information.IsNumeric(_cinfo.VATRATE)) _vatFactor = Convert.ToDecimal(_cinfo.VATRATE);
			else _vatFactor = Convert.ToDecimal(_cinfo.VATRATE.Substring(0, _cinfo.VATRATE.IndexOf("%")));
		} // end GetCustomerInfo


		private void GetBillingHeaderInfo(int BillId, string CustomerCode)
		{
			var _bill = new BILL();

			if (_mode == ActionMode.Add)
			{
				lbBillId.Text = "***AUTO***";
				dtpBillingDate.Value = DateTime.Today;
				dtpDueDate.Value = DateTime.Today.AddDays(15);
				_isLabourCharge = true;
			}
			else
			{
				_bill = new BillingDAL().GetBillHeaderInfo(BillId);
				_customerCode = _bill.CUSTCODE;
				lbBillId.Text = _bill.BILLNO;
				lbBillId.Tag = _bill.BILLID;
				dtpBillingDate.Value = _bill.BILLDATE.Num2Date();
				dtpDueDate.Value = _bill.DUEDATE.Num2Date();
				_isLabourCharge = _bill.SALETYPE == (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial ? false : true;
			}

			// Get Customer Info
			GetCustomerInfo(CustomerCode);

			// map header
			lbCustomerCode.Text = CustomerCode;
			lbCustomerName.Text = _customerName;
			rdoLabour.Checked = _isLabourCharge;

			// Get Bill-Lines
			GetAvailableSOForBilling(_customerCode, BillId);

			UpdateUI();
		} // end GetBillingHeaderInfo

		private void FormattingSOGrid()
		{
			dgvSO.SuspendLayout();
			foreach (DataGridViewColumn dgc in dgvSO.Columns)
			{
				dgc.Visible = false;
				if (dgc.ValueType == typeof(decimal)) dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			}

			dgvSO.Columns["SONO"].Visible = true;
			dgvSO.Columns["ORDERDATE"].Visible = true;
			dgvSO.Columns["TOTALVALUE"].Visible = true;
			dgvSO.Columns["DISCOUNT"].Visible = true;
			dgvSO.Columns["NETVALUE"].Visible = true;
			dgvSO.Columns["TOTALVAT"].Visible = true;
			dgvSO.Columns["TOTALAMOUNT"].Visible = true;

			// formatting ColumnHeaderText
			dgvSO.Columns["SONO"].HeaderText = "เลขที่ใบส่งของ";
			dgvSO.Columns["ORDERDATE"].HeaderText = "วันที่";
			dgvSO.Columns["TOTALVALUE"].HeaderText = "ยอดรวม";
			dgvSO.Columns["DISCOUNT"].HeaderText = "ส่วนลด";
			dgvSO.Columns["NETVALUE"].HeaderText = "ยอดสุทธิ";
			dgvSO.Columns["TOTALVAT"].HeaderText = "ภาษีมูลค่าเพิ่ม";
			dgvSO.Columns["TOTALAMOUNT"].HeaderText = "ยอดรวมทั้งสิ้น";
			dgvSO.ResumeLayout();
		} // end FormattingSOGrid


		private void FormattingBLGrid()
		{
			dgvBL.SuspendLayout();
			foreach (DataGridViewColumn dgc in dgvBL.Columns)
			{
				// setting format
				if (dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
				// hide column
				dgc.Visible = false;
			}

			// set visible column
			dgvBL.Columns["SONO"].Visible = true;
			dgvBL.Columns["ORDERDATE"].Visible = true;
			dgvBL.Columns["TOTALVALUE"].Visible = true;
			dgvBL.Columns["DISCOUNT"].Visible = true;
			dgvBL.Columns["NETVALUE"].Visible = true;
			dgvBL.Columns["TOTALVAT"].Visible = true;
			dgvBL.Columns["TOTALAMOUNT"].Visible = true;

			// formatting ColumnHeaderText
			dgvBL.Columns["SONO"].HeaderText = "เลขที่ใบส่งของ";
			dgvBL.Columns["ORDERDATE"].HeaderText = "วันที่";
			dgvBL.Columns["TOTALVALUE"].HeaderText = "ยอดรวม";
			dgvBL.Columns["DISCOUNT"].HeaderText = "ส่วนลด";
			dgvBL.Columns["NETVALUE"].HeaderText = "ยอดสุทธิ";
			dgvBL.Columns["TOTALVAT"].HeaderText = "ภาษีมูลค่าเพิ่ม";
			dgvBL.Columns["TOTALAMOUNT"].HeaderText = "ยอดรวมทั้งสิ้น";
			dgvBL.ResumeLayout();
		} // end FormattingBLGrid

		private async void GetAvailableSOForBilling(string CustomerCode, int BillId)
		{
			var _dal = new CastingSaleOrderDAL();
			_dtSO = await _dal.GetAvailableSOForBillingAsync(CustomerCode, (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial,
				_isLabourCharge);

			dgvSO.SuspendLayout();
			dgvSO.DataSource = _dtSO;
			dgvSO.ResumeLayout();

			// formatting DataGridView
			FormattingSOGrid();

			if (_mode == ActionMode.Add)
			{
				_dtBL = null;
				dgvBL.DataSource = null;
			}
			// create data table for BILinesDataGridView
			_dtBL = new BillingDAL().GetBillingLines(BillId);

			dgvBL.SuspendLayout();
			dgvBL.DataSource = _dtBL;

			dgvBL.ResumeLayout();

			// hide all columns
			FormattingBLGrid();

			GetSOSummary();
			GetBLSummary();

			UpdateUI();
		} // end GetAvailableSOForBilling

		private void GetSOSummary()
		{
			_totalValues = 0.00m;
			_discount = 0.00m;
			_netValues = 0.00m;
			_vatValues = 0.00m;
			_totalAmount = 0.00m;

			var _dt = (DataTable)dgvSO.DataSource;
			if (_dt.Rows.Count > 0)
			{
				_totalValues = _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALVALUE"));
				_discount = _dt.AsEnumerable().Sum(x => x.Field<decimal>("DISCOUNT"));
				_netValues = _dt.AsEnumerable().Sum(x => x.Field<decimal>("NETVALUE"));
				_vatValues = _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALVAT"));
				_totalAmount = _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALAMOUNT"));
			}

			// display
			lbTotal.Text = $"{_totalValues:N2}";
			lbDiscount.Text = $"{_discount:N2}";
			lbNetValue.Text = $"{_netValues:N2}";
			lbVATValue.Text = $"{_vatValues:N2}";
			lbTotalAmount.Text = $"{_totalAmount:N2}";
			lbSOTitle.Text = $"ใบส่งของ : {_dt.Rows.Count} รายการ";

		} // end GetSummary

		private void GetBLSummary()
		{
			_blTotalValue = 0.00m;
			_blDiscount = 0.00m;
			_blNetValue = 0.00m;
			_blVAT = 0.00m;
			_blTotalAmount = 0.00m;

			if (_dtBL != null)
			{
				var _dt = (DataTable)dgvBL.DataSource;
				if (_dt.Rows.Count > 0)
				{
					_blTotalValue = _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALVALUE"));
					_blDiscount = _dt.AsEnumerable().Sum(x => x.Field<decimal>("DISCOUNT"));
					_blNetValue = _dt.AsEnumerable().Sum(x => x.Field<decimal>("NETVALUE"));
					_blVAT = _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALVAT"));
					_blTotalAmount = _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALAMOUNT"));
				}
			}
			lbBillingTitle.Text = $"ใบส่งของที่เลือกวางบิล : {dgvBL.Rows.Count} รายการ";
			lbBLValues.Text = $"{ _blTotalValue:N2}";
			lbBLDiscount.Text = $"{_blDiscount:N2}";
			lbBLNetValue.Text = $"{_blNetValue:N2}";
			lbBLVAT.Text = $"{_blVAT:N2}";
			lbBLTotalAmount.Text = $"{_blTotalAmount:N2}";


			UpdateUI();
		} // end GetBLSummary


		private void UpdateBillHeaderInfo(int BillId)
		{
			var _bl = new BILL();

			if (_mode == ActionMode.Add)
			{
				_bl.AUDITUSER = omglobal.UserInfo;
				_bl.MODIUSER = omglobal.UserInfo;
				_bl.MODIDATE = DateTime.Now;
				_bl.BILLDATE = dtpBillingDate.Value.Date2Num();
				_bl.BILLNO = "BL";
				_bl.VATFACTOR = _vatFactor;
			}
			else
			{
				_bl = new BillingDAL().GetBillHeaderInfo(BillId);
				_bl.MODIUSER = omglobal.UserInfo;
				_bl.MODIDATE = DateTime.Now;
			}

			_bl.STATUS = lbStatus.Text;
			_bl.CUSTID = _customerId;
			_bl.CUSTCODE = _customerCode;
			_bl.PREFIXID = "BL";
			_bl.DUEDATE = dtpDueDate.Value.Date2Num();
			_bl.FISCPERIOD = dtpBillingDate.Value.Month;
			_bl.FISCYEAR = dtpBillingDate.Value.Year;
			_bl.NUMOFDO = dgvBL.Rows.Count;
			_bl.SALETYPE = _isLabourCharge
				? (int)OMShareCastingEnums.SaleTypeEnumEN.CastingCharge
				: (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial;

			_bl.TOTALVALUE = Convert.ToDecimal(lbBLValues.Text);
			_bl.DISCOUNT = Convert.ToDecimal(lbBLDiscount.Text);
			_bl.NETVALUE = Convert.ToDecimal(lbBLNetValue.Text);
			_bl.TOTALVAT = Convert.ToDecimal(lbBLVAT.Text);
			_bl.TOTALAMOUNT = Convert.ToDecimal(lbBLTotalAmount.Text);
			_bl.TOTALTEXT = ExtensionDouble.ToThaiWord(Convert.ToDouble(lbBLTotalAmount.Text));

			_bl.INVDATE = 0;
			_bl.INVOICENO = "";
			_bl.INVSEQ = 0;
			_bl.TOTALWHTAX = 0.00m;
			_bl.TOTALPAYVALUE = 0.00m;
			_bl.BILLCANCELDATE = 0;
			_bl.COLLECTDATE = 0;

			_bl.ISCANCEL = false;
			_bl.ISCOMPLETE = false;
			_bl.ISDELETE = false;


			if (new BillingDAL().UpdateBillHeaderInfo(_bl, ref dgvBL, _mode) > 0)
				MessageBox.Show("Update Billing successfully....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

			Close();
		} // end UpdateBillHeaderInfo

		#endregion
	}
}