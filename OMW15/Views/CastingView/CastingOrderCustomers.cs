using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class CastingOrderCustomers : Form
	{
		// CONSTRUCTOR
		public CastingOrderCustomers(string FilterText = "",
			OMShareCastingEnums.CustomerList CustomerListType = OMShareCastingEnums.CustomerList.OnlyForCastingSaleOrders)
		{
			InitializeComponent();
			customerListType = CustomerListType;
			_filterText = FilterText;
		}

		private void CastingOrderCustomers_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);

			tsbtnRefresh.PerformClick();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetAvailableCustomers(_filterText);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (dgv.Rows.Count == _rowCount)
			{
				CustomerCode = dgv["CUSTCODE", e.RowIndex].Value.ToString();
				CustomerName = dgv["CUSTNAME", e.RowIndex].Value.ToString();
				CustomerId = Convert.ToInt32(dgv["CUSTID", e.RowIndex].Value);
			}
			UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			CustomerId = 0;
			CustomerCode = string.Empty;
			CustomerName = string.Empty;
		}

		private void tsbtnFilterCustomer_Click(object sender, EventArgs e)
		{
			// search by string input for customer name
			//(this.dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(
			//	"[{0}] LIKE '%{1}%'", "CUSTOMERNAME", OMControls.OMDataUtils.GetFilter<string>("กำหนดชื่อลูกค้าที่ต้องการค้นหา"));
			//this.lbFilter.Text = _filterText;

			_filterText = OMDataUtils.GetFilter<string>("กำหนดบางส่วนของชื่อลูกค้าที่ต้องการค้นหา");

			GetAvailableCustomers(_filterText);
		}

		#region class field member

		private readonly OMShareCastingEnums.CustomerList customerListType = OMShareCastingEnums.CustomerList.All;
		private int _rowCount;
		private string _filterText = string.Empty;

		#endregion

		#region class property

		public int CustomerId { get; set; }

		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnSelect.Enabled = dgv.Rows.Count > 0 && CustomerId > 0;
		} // end UpdateUI


		private async void GetAvailableCustomers(string FilterText)
		{
			var _dal = new CastingSaleOrderDAL();


			dgv.SuspendLayout();

			switch (customerListType)
			{
				case OMShareCastingEnums.CustomerList.OnlyForCastingSaleOrders:
					dgv.DataSource = await _dal.GetAvailableCustomerForCastingOrderAsync(FilterText);
					break;

				case OMShareCastingEnums.CustomerList.OnlyForMaterialCards:
					dgv.DataSource = await _dal.GetAvailableCustomerForMaterialBalanceAsync(FilterText);
					break;
			}

			dgv.Columns["CUSTID"].Visible = false;
			dgv.Columns["CUSTNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.ResumeLayout();

			lbRowCount.Text = string.Format("found : {0}", _rowCount = dgv.Rows.Count);

			UpdateUI();
		} // end GetAvailableCustomers

		#endregion
	}
}