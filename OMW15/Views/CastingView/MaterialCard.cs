using System;
using System.Data;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView {
	public partial class MaterialCard : Form {
		// Constructor
		public MaterialCard() {
			InitializeComponent();
		}

		public MaterialCard(string CustomerCode, string CustomerName, string MaterialCategory, int FiscYear, int FiscPeriod) {
			InitializeComponent();
		}

		private void MaterialCard_Load(object sender, EventArgs e) {
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);
			dtpStockDuration.Value = DateTime.Today;
			GetMaterialCategory();

			UpdateUI();
		}

		private void btnSearchCustomer_Click(object sender, EventArgs e) {
			using (
				var customers = new CastingOrderCustomers(txtCustomer.Text, OMShareCastingEnums.CustomerList.OnlyForMaterialCards)) {
				customers.StartPosition = FormStartPosition.CenterScreen;
				if (customers.ShowDialog(this) == DialogResult.OK) {
					customerName = customers.CustomerName;
					erpCustomerCode = customers.CustomerCode;
				}
				else {
					customerName = "";
					erpCustomerCode = "";
				}

				txtCustomer.Text = customerName;
			}

			// Get OpenBalance Value for selected Material Category
			GetOpenBalance(erpCustomerCode, materialCategory, yearStock, monthStock);

			UpdateUI();
		}

		private void btnCalStock_Click(object sender, EventArgs e) {
			GetAsyncDeliveryRecord(erpCustomerCode, materialCategory, yearStock, monthStock);
		}

		private void cbxMaterialCategory_SelectionChangeCommitted(object sender, EventArgs e) {
			materialCategory = cbxMaterialCategory.SelectedValue.ToString();

			// Get OpenBalance Value for selected Material Category
			GetOpenBalance(erpCustomerCode, materialCategory, yearStock, monthStock);

			UpdateUI();
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnUpdateOpenBalance_Click(object sender, EventArgs e) {
			var openBalance = new MaterialCutBalance(erpCustomerCode, customerName, materialCategory);
			openBalance.StartPosition = FormStartPosition.CenterScreen;
			if (openBalance.ShowDialog(this) == DialogResult.OK) {
			}
		}

		private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == (char)Keys.Enter)
				btnSearchCustomer.PerformClick();
		}

		private void dtpStockDuration_CloseUp(object sender, EventArgs e) {
			yearStock = dtpStockDuration.Value.Year;
			monthStock = dtpStockDuration.Value.Month;

			// Get OpenBalance Value for selected Material Category
			GetOpenBalance(erpCustomerCode, materialCategory, yearStock, monthStock);

			UpdateUI();
		}

		private void btnPrint_Click(object sender, EventArgs e) {
			var rptView = new CastingReportView(_matCardDataSource, dtpStockDuration.Text, customerName,
				Convert.ToDecimal(lbOpenBalance.Text));
			rptView.PrintWhat = PrintDocumentType.MaterialCard;
			rptView.WindowState = FormWindowState.Maximized;
			rptView.Show();
		}

		#region class field member

		private string materialCategory = string.Empty;
		private string customerName = string.Empty;
		private string erpCustomerCode = string.Empty;
		private int yearStock = DateTime.Today.Year;
		private int monthStock = DateTime.Today.Month;
		private decimal stockOpenBalance =0.00m;

		private DataTable _matCardDataSource;

		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI() {
			btnUpdateOpenBalance.Enabled = !string.IsNullOrEmpty(erpCustomerCode) && !string.IsNullOrEmpty(materialCategory);
			btnCalStock.Enabled = !string.IsNullOrEmpty(materialCategory) && !string.IsNullOrEmpty(erpCustomerCode);
			btnPrint.Enabled = dgv.Rows.Count > 0;
		} // end UpdateUI

		private async void GetAsyncDeliveryRecord(string CustomerCode, string MaterialCategory, int SendingYear,
			int SendingMonth) {
			var _dal = new ReturnMaterialDAL();
			_matCardDataSource = await _dal.GetAsyncMaterialCardByCustomer(CustomerCode, MaterialCategory, SendingYear,
				SendingMonth);

			// CALCULATE BALANCE FIELD
			var balance = stockOpenBalance;
			var count = 0;
			foreach (DataRow dr in _matCardDataSource.Rows) {
				// update balance field
				if (count == 0)
					balance = balance + Convert.ToDecimal(_matCardDataSource.Rows[count]["IN"]) -
							  Convert.ToDecimal(_matCardDataSource.Rows[count]["OUT"]);
				else
					balance = balance + Convert.ToDecimal(_matCardDataSource.Rows[count]["IN"]) -
							  Convert.ToDecimal(_matCardDataSource.Rows[count]["OUT"]);
				_matCardDataSource.Rows[count]["Balance"] = balance;
				count++;
			}

			dgv.SuspendLayout();
			dgv.DataSource = _matCardDataSource;

			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.ValueType == typeof(decimal))
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgv.ResumeLayout();

			// display Total delivery Weight
			lbTotalDelivery.Text = $"{CalTotalDeliveryWeight():N2}";

			UpdateUI();
		} // end GetAsyncDeliveryRecord

		private decimal CalTotalDeliveryWeight() {
			var result = 0.00m;
			foreach (DataGridViewRow dgr in dgv.Rows)
				result += Convert.ToDecimal(dgr.Cells["OUT"].Value);

			return result;
		} // end CalTotalDeliveryWeight


		private void GetMaterialCategory() {
			cbxMaterialCategory.DataSource = new MaterialDAL().GetMaterialCategory();
			cbxMaterialCategory.DisplayMember = "CATEGORY";
			cbxMaterialCategory.ValueMember = "CATEGORY";
		} // end GetMaterialCategory

		private void GetOpenBalance(string customerCode, string materialCategory, int currentYearOfOpenBalance,
			int currentMonthOfOpenBalance) {

			if (string.IsNullOrEmpty(materialCategory)) {
				return;
			}

			// Get the current open balance for given customer 
			if (customerCode != ""
			    && materialCategory != ""
			    && currentYearOfOpenBalance != 0
			    && currentMonthOfOpenBalance != 0)
			{
				MaterialBalance dal = new MaterialBalance();

				stockOpenBalance = dal.GetOpenBalanceByCustomer(customerCode, materialCategory,
					currentYearOfOpenBalance, currentMonthOfOpenBalance);

				// display open balance
			}

			lbOpenBalance.Text = $"{stockOpenBalance:N2}";

		} // end GetOpenBalance

		#endregion
	}
}