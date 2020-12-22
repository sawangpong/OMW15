using OMW15.Views.CustomerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Controllers.CustomerController
{
	public class SearchCustomer
	{

		#region class property
		private string _filter = string.Empty;
		public int CustomerId
		{
			get; set;
		}
		public string CustomerCode
		{
			get; set;
		}
		public string CustomerName
		{
			get; set;
		}


		#endregion


		private void getCustomer(string filter)
		{
			using (var _cust = string.IsNullOrEmpty(filter) ? new CustomerSearch() : new CustomerSearch(filter, Shared.OMShareCustomerEnums.CustomerSearchOptions.SearchByCustomerName))
			{
				_cust.StartPosition = FormStartPosition.CenterParent;
				if (_cust.ShowDialog() == DialogResult.OK)
				{
					this.CustomerName = _cust.CustomerName;
					this.CustomerCode = _cust.ERPCustomerCode;
					this.CustomerId = _cust.ERPCustomerId;
				}
			}
		}


		public SearchCustomer()
		{
			_filter = string.Empty;
			getCustomer(_filter);
		}

		public SearchCustomer(string filterText)
		{
			_filter = filterText;
			getCustomer(_filter);
		}

	}
}
