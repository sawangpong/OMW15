using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView
{
	public partial class MaterialClearing : Form
	{
		// CONSTRUCTOR
		public MaterialClearing()
		{
			InitializeComponent();
			WindowState = FormWindowState.Maximized;
			_customerCode = "";
			_appMode = string.IsNullOrEmpty(_customerCode)
				? MaterialReceiveViewMode.NonSpecifyCustomer
				: MaterialReceiveViewMode.SpecifyCustomer;
		}

		public MaterialClearing(string CustomerCode, string CustomerName)
		{
			InitializeComponent();
			_customerCode = CustomerCode;
			_appMode = string.IsNullOrEmpty(CustomerCode)
				? MaterialReceiveViewMode.NonSpecifyCustomer
				: MaterialReceiveViewMode.SpecifyCustomer;
			lbCustomerCode.Text = _customerCode;
			txtCustomerName.Text = CustomerName;
		}

		private void MaterialClearing_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgvGRV);
			OMUtils.SettingDataGridView(ref dgvMatchIssue);
			OMUtils.SettingDataGridView(ref dgvClearList);

			// display pending
			tslbPendingWeight.Text = $"Pending : {TotalPendingWeight:N2}";

			UpdateUI();

			tsbtnRefresh.PerformClick();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dgvGRV_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_isSale = Convert.ToBoolean(dgvGRV["ISFORSALE", e.RowIndex].Value);
			_selectedGRVId = Convert.ToInt32(dgvGRV["GRV", e.RowIndex].Value);
			_selectedSaleOrder = dgvGRV["REFSONUMBER", e.RowIndex].Value.ToString();
			_selectedGRVBalance = Convert.ToDecimal(dgvGRV["BALANCE", e.RowIndex].Value);
			_selectedGRVReceiveDate = Convert.ToDateTime(dgvGRV["DATE", e.RowIndex].Value);
			_selectedDocument = dgvGRV["DOCUMENT", e.RowIndex].Value.ToString();
			_selectedMaterialId = Convert.ToInt32(dgvGRV["MATTYPE", e.RowIndex].Value);
			_selectedGRVClearing = Convert.ToDecimal(dgvGRV["CLEARING", e.RowIndex].Value);

			lbRefSO.Text = _selectedSaleOrder;

			_matchItems = 0;
			btnMatch.Enabled = _selectedGRVBalance > 0.00m;

			// Get Clearing Order List
			ClearingOrderList(_selectedGRVId);
			UpdateUI();
		}

		private void tsbtnMatReceive_Click(object sender, EventArgs e)
		{
			GRVInfo(_selectedGRVId = 0);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			GRVInfo(_selectedGRVId);
		}

		private void dgvGRV_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetGRVList(_customerCode);
		}

		private void btnMatch_Click(object sender, EventArgs e)
		{
			GetAvailableIssueList(_customerCode, MaterialCategory, _isSale, _selectedSaleOrder);
		}

		private void btnConfirmClearing_Click(object sender, EventArgs e)
		{
			// Confirm to Clear Material out standing from Customer
			ConfirmClearing(_selectedGRVId, _selectedGRVReceiveDate, _selectedDocument, _selectedMaterialId);

			// refresh
			tsbtnRefresh.PerformClick();
		}

		private void dgvGRV_SelectionChanged(object sender, EventArgs e)
		{
			dgvMatchIssue.DataSource = null;
			lbMatchItems.Text = dgvMatchIssue.DataSource == null ? "" : lbMatchItems.Text;
			UpdateUI();
		}

		private void btnFindCustomer_Click(object sender, EventArgs e)
		{
			using (var customers = new CastingOrderCustomers(""))
			{
				customers.StartPosition = FormStartPosition.CenterScreen;
				if (customers.ShowDialog(this) == DialogResult.OK)
				{
					txtCustomerName.Text = customers.CustomerName;
					_customerCode = customers.CustomerCode;
					lbCustomerCode.Text = _customerCode;
					lbCustomerCode.Tag = customers.CustomerId;
				}
			}
			UpdateUI();

			if (_customerCode != "") tsbtnRefresh.PerformClick();
		}

		private void tsbtnTotalReceiveMat_Click(object sender, EventArgs e)
		{
			var _mr = new SummaryMatReceive(_customerCode);
			_mr.StartPosition = FormStartPosition.CenterScreen;
			_mr.MdiParent = ParentForm;

			_mr.Show();
		}

		#region class field member

		private enum MaterialReceiveViewMode
		{
			Unknow,
			NonSpecifyCustomer,
			SpecifyCustomer
		}

		private readonly MaterialReceiveViewMode _appMode = MaterialReceiveViewMode.Unknow;
		private bool _isSale;
		private int _selectedGRVId;
		private int _selectedMaterialId;
		private int _matchItems;
		private string _customerCode = string.Empty;
		private string _selectedSaleOrder = string.Empty;
		private string _selectedDocument = string.Empty;
		private decimal _selectedGRVBalance;
		private decimal _totalClearing;
		private decimal _selectedGRVClearing;
		private DateTime _selectedGRVReceiveDate = DateTime.Today;

		#endregion

		#region class properties

		public string MaterialCategory { get; set; }

		public decimal TotalPendingWeight { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			txtCustomerName.ReadOnly = true;
			btnFindCustomer.Visible = _appMode == MaterialReceiveViewMode.NonSpecifyCustomer;
			tsbtnMatReceive.Enabled = !string.IsNullOrEmpty(_customerCode);
			tsbtnEdit.Enabled = _selectedGRVId > 0 && _selectedGRVClearing == 0.00m;
			btnMatch.Enabled = _selectedGRVId > 0 && _selectedGRVBalance > 0.00m;
			btnConfirmClearing.Enabled = dgvMatchIssue.Rows.Count > 0;
		} // end UpdateUI


		private async void GetGRVList(string CustomerCode)
		{
			var _dal = new CastingSaleOrderDAL();

			var _dt = await _dal.GetAsyncGRVList(CustomerCode);

			dgvGRV.SuspendLayout();
			dgvGRV.DataSource = _dt;
			dgvGRV.Columns["ISFORSALE"].Visible = false;
			dgvGRV.Columns["CUSTCODE"].Visible = false;
			dgvGRV.Columns["MATTYPE"].Visible = false;
			dgvGRV.Columns["SOSEQ"].Visible = false;
			dgvGRV.Columns["REFSONUMBER"].Visible = false;
			dgvGRV.Columns["CUSTOMER"].Visible = btnFindCustomer.Visible;

			dgvGRV.Columns["GRV"].HeaderText = "เลขที่รับ";
			dgvGRV.Columns["DATE"].HeaderText = "วันที่รับ";
			dgvGRV.Columns["DOCUMENT"].HeaderText = "เอกสารอ้างอิง";
			dgvGRV.Columns["MATERIAL"].HeaderText = "วัสดุ";
			dgvGRV.Columns["UNIT"].HeaderText = "หน่วยนับ";
			dgvGRV.Columns["RECEIVE"].HeaderText = "รับเข้า (กรัม)";
			dgvGRV.Columns["CLEARING"].HeaderText = "หักออก (กรัม)";
			dgvGRV.Columns["BALANCE"].HeaderText = "คงเหลือ (กรัม)";
			dgvGRV.Columns["REMARK"].HeaderText = "หมายเหตุ";

			// formatting DataGridView
			foreach (DataGridViewColumn dgc in dgvGRV.Columns)
				if (dgc.ValueType == typeof(decimal)) dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgvGRV.ResumeLayout();

			if (dgvGRV.Rows.Count > 0)
				tslbStockRemainWeight.Text =
					$"คงค้าง (กรัม) : {(dgvGRV.DataSource as DataTable).AsEnumerable().Sum(x => x.Field<decimal>("BALANCE")):N2}";

			// clear all 
			dgvMatchIssue.DataSource = null;
			dgvMatchIssue.Rows.Clear();
			dgvMatchIssue.Columns.Clear();
		} // end GetGRVList

		private void GRVInfo(int GRVId)
		{
			using (var _grv = new GRVInfo(GRVId))
			{
				_grv.CustomerCode = lbCustomerCode.Text;
				_grv.CustomerName = txtCustomerName.Text;
				_grv.MaterialCategory = MaterialCategory;
				_grv.StartPosition = FormStartPosition.CenterScreen;
				if (_grv.ShowDialog() == DialogResult.OK)
				{
				}
			}

			tsbtnRefresh.PerformClick();
		} // end GRVInfo


		private async void GetAvailableIssueList(string CustomerCode, string MaterialCategory, bool ForSale,
			string SaleOrderNo)
		{
			var _dal = new CastingSaleOrderDAL();
			var _dtIssueList = new DataTable();
			var _balance = _selectedGRVBalance;
			var _issue = 0.00m;
			var _remain = 0.00m;

			// clear all contents
			dgvMatchIssue.DataSource = null;

			if (ForSale)
			{
				_dtIssueList = await _dal.GetAsyncCastingSaleOrderListForClearing(CustomerCode, MaterialCategory, SaleOrderNo);
				try
				{
					if (_dtIssueList.Rows.Count == 0)
						_dtIssueList = await _dal.GetAsyncCastingSaleOrderListForClearing(CustomerCode, MaterialCategory);
				}
				catch
				{
					_dtIssueList = _dal.GetCastingSaleOrderListForClearing(CustomerCode, MaterialCategory);
				}
			}
			else
			{
				_dtIssueList = await _dal.GetAsyncCastingSaleOrderListForClearing(CustomerCode, MaterialCategory);
			}

			// start Clearing Material
			foreach (DataRow _dr in _dtIssueList.Rows)
			{
				++_matchItems;
				_remain = Convert.ToDecimal(_dr["REMAIN"]);
				if (_balance >= _remain)
				{
					_issue = _remain;
					_balance -= _issue;
				}
				else if (_balance < _remain)
				{
					_issue = _balance;
					_balance = 0.00m;
				}

				_dr["CLEARING"] = _issue;
				_dr["BALANCE"] = _balance;

				if (_balance == 0.00m) break;
			}

			lbMatchItems.Text = $"match : {_matchItems}";
			dgvMatchIssue.SuspendLayout();
			dgvMatchIssue.DataSource = _dtIssueList;
			dgvMatchIssue.Columns["SOSEQ"].Visible = false;
			dgvMatchIssue.Columns["MATID"].Visible = false;
			dgvMatchIssue.Columns["ISSUEQTY"].HeaderText = "Delivered-Qty (g)";
			dgvMatchIssue.Columns["REMAIN"].HeaderText = "Outstanding-Qty (g)";
			dgvMatchIssue.Columns["BALANCE"].HeaderText = "GRV-Balance";

			foreach (DataGridViewColumn dgc in dgvMatchIssue.Columns)
				if (dgc.ValueType == typeof(decimal)) dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgvMatchIssue.ResumeLayout();

			// Get Total Clearing (issue)
			_totalClearing = Convert.ToDecimal(_dtIssueList.AsEnumerable().Sum(x => x.Field<decimal>("CLEARING")));
			lbTotalClearing.Text = $"Total Clearing : {_totalClearing:N2} (กรัม)";

			UpdateUI();
		} // end GetAvailableIssueList

		private void ConfirmClearing(int GRVNumber, DateTime ReceiveDate, string Document, int MaterialId)
		{
			if (
				new CastingSaleOrderDAL().ConfirmClearingMaterial(ref dgvMatchIssue, GRVNumber, ReceiveDate, Document, MaterialId) >
				0) MessageBox.Show("Clearing material completed....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
		} // end ConfirmClearing

		private void ClearingOrderList(int GRVId)
		{
			dgvClearList.SuspendLayout();
			dgvClearList.DataSource = new CastingSaleOrderDAL().GetCustomerClearingList(GRVId);
			dgvClearList.Columns["REFSONO"].HeaderText = "เลขที่ใบส่งของ";
			dgvClearList.Columns["CLEARINGDATE"].HeaderText = "วันที่คืน";
			dgvClearList.Columns["RETURNWEIGHT"].HeaderText = "น.น. ที่คืน";
			dgvClearList.Columns["RETURNWEIGHT"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgvClearList.ResumeLayout();

			// display Total Return Weight
			var _totalReturnWeight = 0.00m;
			if (dgvClearList.Rows.Count > 0)
				_totalReturnWeight =
					Convert.ToDecimal(((DataTable) dgvClearList.DataSource).AsEnumerable().Sum(x => x.Field<decimal>("RETURNWEIGHT")));

			lbTotalReturnWeight.Text = $"รวมน้ำหนักคืน (กรัม) : {_totalReturnWeight:N2}";
		} // end ClearingOrderList

		#endregion
	}
}