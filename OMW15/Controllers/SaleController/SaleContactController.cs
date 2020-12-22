using System.Windows.Forms;
using OMW15.Shared;
using OMW15.Views.Sales;

namespace OMW15.Controllers.SaleController
{
	public class SaleContactController
	{
		// constructor
		public SaleContactController(ActionMode Mode = ActionMode.View)
		{
			GetSelectionSaleContact(Mode);
		}


		public void GetSelectionSaleContact(ActionMode Mode)
		{
			using (var _sc = new SaleContact(ActionMode.Selection))
			{
				_sc.StartPosition = FormStartPosition.CenterScreen;
				if (_sc.ShowDialog() == DialogResult.OK)
				{
					IsEmptyResult = false;
					CustomerName = _sc.TheCompanyName;
					CustomerCode = _sc.CustomerCode;
					CustomerId = _sc.CustomerId;
					CustomerAddress = _sc.Address;
					Country = _sc.Country;
					CustomerEmail = _sc.Email;
					ContactPerson = _sc.ContactPerson;
					ContactNumber = _sc.Phone + "/ " + _sc.Mobile;
				}
				else
				{
					IsEmptyResult = true;
				}
			}
		} // end GetSelectionSaleContact

		#region class property

		public bool IsEmptyResult { get; set; }

		public string CustomerName { get; set; }

		public string CustomerCode { get; set; }

		public int CustomerId { get; set; }

		public string CustomerAddress { get; set; }

		public string Country { get; set; }

		public string ContactPerson { get; set; }

		public string PersonContact { get; set; }

		public string CustomerEmail { get; set; }

		public string ContactNumber { get; set; }

		#endregion
	}
}