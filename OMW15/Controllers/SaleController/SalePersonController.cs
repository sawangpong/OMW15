using System.Windows.Forms;
using OMW15.Shared;
using OMW15.Views.Sales;

namespace OMW15.Controllers.SaleController
{
	public class SalePersonController
	{
		public SalePersonController(ActionMode Mode = ActionMode.Recording)
		{
			IsEmptyResult = true;
			GetSaleManInfo(Mode);
		}

		public bool IsEmptyResult { get; set; }

		public string SalePersonName { get; set; }

		public string SaleContractNo { get; set; }

		public string SaleEmail { get; set; }

		#region class helper methods

		private void GetSaleManInfo(ActionMode Mode)
		{
			using (var _sm = new SaleMan(Mode))
			{
				_sm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
				_sm.StartPosition = FormStartPosition.CenterScreen;

				if (_sm.ShowDialog() == DialogResult.OK)
				{
					IsEmptyResult = false;
					SaleContractNo = _sm.SaleContactNumber;
					SaleEmail = _sm.SaleEmail;
					SalePersonName = _sm.SalePersonName;
				}
			}
		} // end GetSaleManInfo

		#endregion
	}
}