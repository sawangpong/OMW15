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

		#endregion

		#region class property

		#endregion

		#region class helper
		private void UpdateUI()
		{

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
					lbCustCode.Text = cust.ERPCustomerCode;
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
	}
}
