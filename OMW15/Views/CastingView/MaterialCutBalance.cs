using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class MaterialCutBalance : Form
	{
		// CONSTRUCTOR
		public MaterialCutBalance(string customerCode, string customerName, string materialCategory)
		{
			InitializeComponent();

			CustomerCode = customerCode;
			CustomerName = customerName;
			MaterialCategory = materialCategory;
			lbSelectedCustomer.Text = CustomerName;

			updateMode = CustomerCode == ""
				? OMShareCastingEnums.UpdateMaterialOpenBalanceMode.AllCustomers
				: OMShareCastingEnums.UpdateMaterialOpenBalanceMode.SelectedCustomerOnly;
		}

		public void UpdateProgress(object progress)
		{
			cpb.Invoke((MethodInvoker) delegate { cpb.UpdateProgress(Convert.ToInt32(progress)); });
		}

		private void MaterialCutBalance_Load(object sender, EventArgs e)
		{
			CenterToParent();
			// setting controls
			OMUtils.SettingDataGridView(ref dgvCustomers);
			OMUtils.SettingDataGridView(ref dgvBalance);

			// initial value for parameters
			chkUpdateOpenBalanceForAllCustomers.Checked = updateMode ==
			                                              OMShareCastingEnums.UpdateMaterialOpenBalanceMode.AllCustomers
				? true
				: false;
			CustomerCode = chkUpdateOpenBalanceForAllCustomers.Checked ? "" : CustomerCode;

			chkAllMatCategory.Checked = chkUpdateOpenBalanceForAllCustomers.Checked;
			MaterialCategory = chkAllMatCategory.Checked ? "" : MaterialCategory;

			// loading Material Category list
			GetMaterialCategory();
			GetYearOpenBalance();
			UpdateUI();
		}

		private void btnOpenBalance_Click(object sender, EventArgs e)
		{
			showProgressArea = !showProgressArea;
			UpdateUI();
			CalOpenBalance(int.Parse(cbxOpenYear.Text));
		}

		private void chkUpdateOpenBalanceForAllCustomers_CheckedChanged(object sender, EventArgs e)
		{
			if (updateMode == OMShareCastingEnums.UpdateMaterialOpenBalanceMode.AllCustomers)
				customerSearch.Visible = !chkUpdateOpenBalanceForAllCustomers.Checked;
			else if (updateMode == OMShareCastingEnums.UpdateMaterialOpenBalanceMode.SelectedCustomerOnly)
				customerSearch.Visible = false;
		}

		private void customerSearch_OnSendingFiler(string FilterString)
		{
			using (var customers = new CastingOrderCustomers(FilterString, OMShareCastingEnums.CustomerList.OnlyForMaterialCards)
			)
			{
				customers.StartPosition = FormStartPosition.CenterScreen;
				if (customers.ShowDialog(this) == DialogResult.OK)
				{
					CustomerCode = customers.CustomerCode;
					CustomerName = customers.CustomerName;
				}
				else
				{
					CustomerCode = "";
					CustomerName = "";
				}

				lbSelectedCustomer.Text = CustomerName;
			}

			UpdateUI();
		}

		private void cbxMatCategory_SelectionChangeCommitted(object sender, EventArgs e)
		{
			MaterialCategory = cbxMatCategory.SelectedValue.ToString();
			UpdateUI();
		}

		private void btnLoadCustomer_Click(object sender, EventArgs e)
		{
			GetAsyncCustomerListForBalanceMaterial(int.Parse(cbxOpenYear.Text), CustomerCode, MaterialCategory);
		}

		private void chkAllMatCategory_CheckedChanged(object sender, EventArgs e)
		{
			if (chkAllMatCategory.Checked) MaterialCategory = "";

			switch (updateMode)
			{
				case OMShareCastingEnums.UpdateMaterialOpenBalanceMode.AllCustomers:
					lbMatCat.Visible = !chkAllMatCategory.Checked;
					cbxMatCategory.Enabled = lbMatCat.Visible;

					break;
				case OMShareCastingEnums.UpdateMaterialOpenBalanceMode.SelectedCustomerOnly:
					lbMatCat.Visible = !chkAllMatCategory.Checked;
					cbxMatCategory.Enabled = lbMatCat.Visible;

					break;
			}
		}

		private void btnUpdateOpenBalance_Click(object sender, EventArgs e)
		{
			if (new MaterialBalance().UpdateOpenBalance(openBLs) > 0)
				MessageBox.Show("Update Material Stock successfully !!!", "Message", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cbxOpenYear_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				GetAsyncCustomerListForBalanceMaterial(int.Parse(cbxOpenYear.Text), CustomerCode, MaterialCategory);
			}
			catch
			{
				GetAsyncCustomerListForBalanceMaterial(DateTime.Today.Year, CustomerCode, MaterialCategory);
			}
		}

		#region class field member

		private int totalCustomerFound;
		private bool showProgressArea;

		private readonly OMShareCastingEnums.UpdateMaterialOpenBalanceMode updateMode =
			OMShareCastingEnums.UpdateMaterialOpenBalanceMode.AllCustomers;

		private List<MATOPENBALANCE> openBLs = new List<MATOPENBALANCE>();

		private DataTable customerDataSource;

		#endregion

		#region class property

		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }

		public string MaterialCategory { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			chkUpdateOpenBalanceForAllCustomers.Enabled = updateMode ==
			                                              OMShareCastingEnums.UpdateMaterialOpenBalanceMode.AllCustomers;

			btnOpenBalance.Enabled = dgvCustomers.Rows.Count > 0;
			btnUpdateOpenBalance.Enabled = openBLs.Count > 0;
			pnlProgress.Visible = showProgressArea;
		} // end UpdateUI

		private async void GetAsyncCustomerListForBalanceMaterial(int yearOpenBalance, string CustomerCode,
			string MaterialCategory)
		{
			var dal = new MaterialBalance();
			customerDataSource = await dal.GetAsyncCustomerBalance(yearOpenBalance, CustomerCode, MaterialCategory);

			dgvCustomers.SuspendLayout();
			dgvCustomers.DataSource = customerDataSource;
			dgvCustomers.ResumeLayout();

			totalCustomerFound = dgvCustomers.Rows.Count;
			lbTotalCustomerFound.Text = string.Format("found :: {0}", totalCustomerFound);

			UpdateUI();
		} // end GetAsyncCustomerListForBalanceMaterial

		private async void CalOpenBalance(int openYearBalance)
		{
			// reset object
			openBLs = new List<MATOPENBALANCE>();

			MATOPENBALANCE bl;
			var calRow = 0;
			var initRow = 0;
			var currentProgress = 0;
			var openMonthBalance = 0.00m;
			var customerCode = string.Empty;
			var materialCategory = string.Empty;
			var dal = new ReturnMaterialDAL();

			foreach (DataRow dr in customerDataSource.Rows)
			{
				// initial object MaterialOpenBalace
				bl = new MATOPENBALANCE();
				customerCode = dr["CUSTCODE"].ToString();
				materialCategory = dr["CATEGORY"].ToString();

				// add data into object "MaterialOpenBalace"
				bl.CUSTCODE = customerCode;
				bl.CUSTNAME = dr["CUSTNAME"].ToString();
				bl.MATCAT = materialCategory;
				bl.OPENYEAR = openYearBalance;
				bl.LASTUPDATE = DateTime.Today;

				// initial value for each open balance of each Customer
				openMonthBalance = dal.GetLastOpenBalance(customerCode, materialCategory, bl.OPENYEAR);

				++initRow;

				// loop of each month (period)
				for (var i = 1; i <= 12; i++)
				{
					var source = await dal.GetAsyncMaterialCardByCustomer(customerCode, materialCategory, bl.OPENYEAR, i);

					foreach (DataRow cardRow in source.Rows)
						openMonthBalance += Convert.ToDecimal(cardRow["IN"]) - Convert.ToDecimal(cardRow["OUT"]);

					switch (i)
					{
						case 1:
							bl.BALANCE1 = openMonthBalance;
							break;
						case 2:
							bl.BALANCE2 = openMonthBalance;
							break;
						case 3:
							bl.BALANCE3 = openMonthBalance;
							break;
						case 4:
							bl.BALANCE4 = openMonthBalance;
							break;
						case 5:
							bl.BALANCE5 = openMonthBalance;
							break;
						case 6:
							bl.BALANCE6 = openMonthBalance;
							break;
						case 7:
							bl.BALANCE7 = openMonthBalance;
							break;
						case 8:
							bl.BALANCE8 = openMonthBalance;
							break;
						case 9:
							bl.BALANCE9 = openMonthBalance;
							break;
						case 10:
							bl.BALANCE10 = openMonthBalance;
							break;
						case 11:
							bl.BALANCE11 = openMonthBalance;
							break;
						case 12:
							bl.BALANCE12 = openMonthBalance;
							break;
					}
					txt.Invoke(
						new Action(
							() =>
							{
								txt.AppendText($"{dr["CUSTNAME"],-80}{materialCategory,-25} period ::: {i,-10}{openMonthBalance,-20}\r\n");
							}));

					lbCalCount.Invoke(new Action(() => { lbCalCount.Text = string.Format("cal = {0} row(s)", ++calRow); }));
				} // end loop for month in year

				// calculate the current percentage of progression
				currentProgress = Convert.ToInt32(initRow * 100 / totalCustomerFound);

				// update and display the current progress
				cpb.Invoke(new Action(() => { cpb.UpdateProgress(currentProgress); }));

				// update visible flag of circular progress bar
				showProgressArea = currentProgress == 100 ? false : true;

				// update progress value and show the progress
				lbProgress.Invoke(new Action(() => { lbProgress.Text = string.Format("{0}%", currentProgress); }));

				// add openbalance object for each customer to the list collection
				openBLs.Add(bl);
			} // end loop for each customer

			UpdateUI();

			// mapping openbalance table and display
			dgvBalance.DataSource = null;
			dgvBalance.SuspendLayout();
			dgvBalance.DataSource = openBLs;
			dgvBalance.Columns["ID"].Visible = false;
			dgvBalance.Columns["LASTUPDATE"].Visible = false;

			foreach (DataGridViewColumn dgc in dgvBalance.Columns)
				if (dgc.Name != "CUSTCODE"
				    && dgc.Name != "CUSTNAME"
				    && dgc.Name != "MATCAT"
				    && dgc.Name != "OPENYEAR") dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgvBalance.ResumeLayout();
		} // end CalOpenBalance

		private void GetMaterialCategory()
		{
			cbxMatCategory.DataSource = new MaterialDAL().GetMaterialCategory();
			cbxMatCategory.DisplayMember = "CATEGORY";
			cbxMatCategory.ValueMember = "CATEGORY";

			if (MaterialCategory != "") cbxMatCategory.SelectedValue = MaterialCategory;
		} // end GetMaterialCategory

		private void GetYearOpenBalance()
		{
			cbxOpenYear.DataSource = new ReturnMaterialDAL().GetOpenBalanceYearList();
			cbxOpenYear.DisplayMember = "FISCYEAR";
			cbxOpenYear.ValueMember = "FISCYEAR";
			cbxOpenYear.SelectedIndex = 0;
		}

		#endregion
	}
}