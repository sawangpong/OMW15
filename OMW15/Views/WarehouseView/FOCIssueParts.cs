using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using OMControls;
using OMW15.Models.ServiceModel;
using OMW15.Models.WarehouseModel;
using FOCItems = OMW15.Views.WarehouseReports.FOCItems;

namespace OMW15.Views.WarehouseView
{
	public partial class FOCIssueParts : Form
	{
		public FOCIssueParts()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void FOCIssueParts_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);

			GetYearList();
		}

		private void cbxYear_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				selectedYear = Convert.ToInt32(cbxYear.SelectedValue);
			}
			catch
			{
				selectedYear = DateTime.Today.Year;
			}

			getOrderCodeList(selectedYear);
		}

		private void chlOrderCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			countChecked = chlOrderCode.CheckedItems.Count;
			UpdateUI();
		}

		private void btnLoadData_Click(object sender, EventArgs e)
		{
			orderCodes = new string[chlOrderCode.CheckedItems.Count];
			for (var i = 0; i < chlOrderCode.CheckedItems.Count; i++)
				orderCodes[i] = chlOrderCode.CheckedItems[i].ToString().Substring(0, 2);

			// get spare part items
			getSparepartList(selectedYear, orderCodes);
		}

		private void rdo_CheckedChanged(object sender, EventArgs e)
		{
			var rdo = sender as RadioButton;
			reportType = rdo.Tag.ToString();

			selectedItems = new List<string>();
			if (reportType == "ALL")
				foreach (DataGridViewRow dgr in dgv.Rows) selectedItems.Add(dgr.Cells["ITEMNO"].Value.ToString());
			else selectedItems.Add(dgv["ITEMNO", 0].Value.ToString());

			dgv.Enabled = reportType == "ALL" ? false : true;
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			selectedItems = new List<string>();
			selectedItems.Add(dgv["ITEMNO", e.RowIndex].Value.ToString());
		}

		private void btnDisplayReport_Click(object sender, EventArgs e)
		{
			DisplayReport(selectedItems);
		}

		#region class field

		private int countChecked;
		private int selectedYear = DateTime.Today.Year;
		private string[] orderCodes;
		private string reportType = "ALL";
		private List<string> selectedItems;

		#endregion

		#region class helper Method

		private void UpdateUI()
		{
			btnLoadData.Enabled = countChecked > 0;
			pnlItemOption.Enabled = btnLoadData.Enabled;
		} // end UpdateUI


		private void GetYearList()
		{
			var dt = new FOCIssueDAL().getServiceOrderYearList(omglobal.FOCOrderCode);
			cbxYear.DataSource = dt;
			cbxYear.DisplayMember = "YEAR";
			cbxYear.ValueMember = "YEAR";
			cbxYear.SelectedIndex = 0;
		} // end GetIssueYear

		private void getSparepartList(int Year, string[] codeList)
		{
			var dt = new FOCIssueDAL().getSparePartItems(Year, codeList);

			dgv.SuspendLayout();
			dgv.DataSource = dt;

			// keep all items
			selectedItems = new List<string>();
			foreach (DataGridViewRow dgr in dgv.Rows) selectedItems.Add(dgr.Cells["ITEMNO"].Value.ToString());
			dgv.ResumeLayout();

			rdoAllItems.Checked = true;
			lbCount.Text = $"found : {dgv.Rows.Count}";
		} // end getSpareList


		private void getOrderCodeList(int selectedYear)
		{
			var dt = new ServiceJobDAL().GetJobCodeList(selectedYear);
			chlOrderCode.SuspendLayout();

			// clear order code list
			chlOrderCode.Items.Clear();

			foreach (DataRow dr in dt.Rows) chlOrderCode.Items.Add(dr["Value"]);

			chlOrderCode.ResumeLayout();
		} // end getOrderCodeList


		private void DisplayReport(List<string> itemNo)
		{
			ReportDocument rpt = new FOCItems();
			rpt.SetDataSource(new FOCIssueDAL().getSparePartItemsWithFullDetails(selectedYear, orderCodes, itemNo));
			rpt.SetParameterValue(0, omglobal.COMPANY_NAME_TH);
			rpv.ReportSource = rpt;
		} // end DisplayReport

		#endregion
	}
}