using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ServiceController;
using OMW15.Models.ProductModel;

namespace OMW15.Views.ServiceView
{
	public partial class MachineList : Form
	{
		public MachineList()
		{
			InitializeComponent();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnCustomer_Click(object sender, EventArgs e)
		{
			SelectCustomer();
		}

		private void MachineList_Load(object sender, EventArgs e)
		{
			// setting DataGridView Format
			OMUtils.SettingDataGridView(ref dgv);
		}

		private void tstxtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char) Keys.Enter) tsbtnCustomer.PerformClick();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetMachineListResult(_customerCode);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_mcRecordId = Convert.ToInt32(dgv["MIXID", e.RowIndex].Value);
			UpdateUI();
		}

		#region class field member

		private string _customerCode = string.Empty;
		private int _mcRecordId;

		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			tsbtnEdit.Enabled = _mcRecordId > 0;
			tsbtnDelete.Enabled = tsbtnEdit.Enabled;
		} // end UpdateUI

		private void SelectCustomer()
		{
			// call controller to fine the given customer hint
			_customerCode = MachineListController.GetCustomer(ref tstxtCustomerName);

			// loading Machine list when the customer code is not empty string
			tsbtnRefresh.PerformClick();
		} // end SelectedCustomer

		private void GetMachineListResult(string CustomerCode)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new ProductDAL().GetMachineListByCustomer(CustomerCode);

			dgv.ResumeLayout();

			// display found records
			lbCount.Text = $"found {dgv.Rows.Count} record{(dgv.Rows.Count > 1 ? "s" : "")} ";
		} // end GetMachineListResult

		#endregion
	}
}