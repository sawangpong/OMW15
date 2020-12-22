using System.Windows.Forms;
using OMW15.Shared;
using OMW15.Views.CustomerView;

namespace OMW15.Controllers.ServiceController
{
	public class MachineListController
	{
		public static string GetCustomer(ref ToolStripTextBox CustomerName)
		{
			var _result = string.Empty;

			using (
				var _cust = new CustomerSearch(CustomerName.Text, OMShareCustomerEnums.CustomerSearchOptions.SearchByCustomerName))
			{
				_cust.StartPosition = FormStartPosition.CenterScreen;
				if (_cust.ShowDialog() == DialogResult.OK)
				{
					CustomerName.Text = _cust.CustomerName;
					_result = _cust.ERPCustomerCode;
				}
				else
				{
					CustomerName.Text = string.Empty;
					_result = string.Empty;
				}
			}

			return _result;
		} // end GetCustomer
	}
}