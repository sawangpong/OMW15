using OMW15.Models.SaleModel;
using OMW15.Views.CustomerView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.Sales
{
	public partial class SaleHistory : Form
	{
		#region Singleton
		private static SaleHistory _instance;
		public static SaleHistory GetInstance {
			get {
				if(_instance == null || _instance.IsDisposed)
				{
					_instance = new SaleHistory();
				}
				return _instance;
			}
		}
		#endregion

		#region class field

		private string _selectedCustomerCode = string.Empty;
		private bool _columnsHadFormated = false;
		private DataTable _histDt;

		#endregion

		#region class property

		#endregion

		#region class helper
		private void UpdateUI()
		{

		}

		private void GetHistory(string customerCode)
		{
			_histDt = new SaleDAL().GetSaleHistoryByCustomer(customerCode);

			// formatting data columns
			if(!_columnsHadFormated)
			{
				DataTable _cloneDt = _histDt.Clone();
				dgv.DataSource = _cloneDt;
				foreach (DataColumn _dc in _cloneDt.Columns)
				{
					if(_dc.DataType == typeof(System.Decimal))
						{
						dgv.Columns[_dc.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
						dgv.Columns[_dc.ColumnName].DefaultCellStyle.Format = "N2";
					}
				}

				_columnsHadFormated = true;
			}
 
			dgv.SuspendLayout();

			dgv.DataSource = _histDt;
			dgv.Columns["CUSTCODE"].Visible = false;
			dgv.Columns["CUSTOMERNAME"].Visible = false;

			dgv.ResumeLayout();

			sstlbRowFound.Text = $"found : {dgv.Rows.Count}";

		}


		private void searchItems(string filter)
		{
			string _filterText = $"ITEMNO LIKE '%{filter}%' OR ITEMNAME LIKE '%{filter}%'";

		 	DataTable _gridTable = (DataTable)dgv.DataSource;
			_gridTable.DefaultView.RowFilter = _filterText;

			sstlbRowFound.Text = $"found : {dgv.Rows.Count}";
		}

		#endregion



		public SaleHistory()
		{
			InitializeComponent();

			OMControls.OMUtils.SettingDataGridView(ref dgv);

		}

		private void SaleHistory_Load(object sender, EventArgs e)
		{

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();

		}

		private void btnCustomerSearch_Click(object sender, EventArgs e)
		{
			using(var cust = new CustomerSearch(txtCustomerFilter.Text , Shared.OMShareCustomerEnums.CustomerSearchOptions.SearchByCustomerName))
			{
				if(cust.ShowDialog() == DialogResult.OK)
				{
					_selectedCustomerCode = cust.ERPCustomerCode;
					lbCustCode.Text = _selectedCustomerCode;
					txtCustomerFilter.Text = cust.CustomerName;
				}
			}
		}

		private void txtCustomerFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
			{
				btnCustomerSearch.PerformClick();
			}
		}

		private void btnLoadData_Click(object sender, EventArgs e)
		{
			GetHistory(_selectedCustomerCode);
		}

		private void txtItemSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
			{
				btnSearchItem.PerformClick();
			}
		}

		private void btnSearchItem_Click(object sender, EventArgs e)
		{
			searchItems(txtItemSearch.Text);
		}
	}
}
