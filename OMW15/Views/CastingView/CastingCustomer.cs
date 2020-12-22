using System;
using System.Data;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView
{
	public partial class CastingCustomer : Form
	{
		public CastingCustomer()
		{
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CastingCustomer_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			CustomerList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			CustomerId = Convert.ToInt32(dgv["CUSTID", e.RowIndex].Value);
			CustomerCode = dgv["CUSTCODE", e.RowIndex].Value.ToString();
			CustomerName = dgv["CUSTNAME", e.RowIndex].Value.ToString();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void txtCustomerNameFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char) Keys.Enter) btnSearch.PerformClick();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			((DataTable) dgv.DataSource).DefaultView.RowFilter = $"CUSTNAME LIKE '%{txtCustomerNameFilter.Text}%'";
		}

		#region class property

		public int CustomerId { get; set; }

		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			btnSelect.Enabled = !string.IsNullOrEmpty(CustomerCode);
		} // end UpdateUI

		private async void CustomerList()
		{
			var _dal = new JobDAL();
			var _customerList = await _dal.GetCastingCustomerListAsync();
			dgv.SuspendLayout();
			dgv.DataSource = _customerList;
			dgv.ColumnHeadersVisible = false;
			dgv.Columns["CUSTID"].Visible = false;
			dgv.Columns["CUSTNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.ResumeLayout();
		} // end CustomerList

		#endregion
	}
}