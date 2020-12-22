using System.Windows.Forms;
using OMW15.Shared;
using OMW15.Views.Sales;

namespace OMW15.Controllers.SaleController
{
	public class MasterQTController
	{
		#region class Constructor

		public MasterQTController(OMShareSaleEnum.MasterQuotationListStyle DisplayStyle, string CurrencyCode)
		{
			IsEmptyResult = true;
			GetMasterQTList(DisplayStyle, CurrencyCode);
		}

		#endregion

		#region class helper Method

		private void GetMasterQTList(OMShareSaleEnum.MasterQuotationListStyle DisplayStyle, string CurrencyCode)
		{
			using (var _master = new MasterQTList(DisplayStyle, CurrencyCode))
			{
				_master.StartPosition = FormStartPosition.CenterScreen;
				if (_master.ShowDialog() == DialogResult.OK)
				{
					IsEmptyResult = false;
					switch (DisplayStyle)
					{
						case OMShareSaleEnum.MasterQuotationListStyle.QuotationHeader:
							MasterQuotationId = _master.SelectedMasterQuotationId;
							break;

						case OMShareSaleEnum.MasterQuotationListStyle.QuotationItem:
							ItemNo = _master.ItemNo;
							ItemName = _master.ItemName;
							ItemInfo = _master.ItemInfo;
							Unit = _master.Unit;
							Qty = _master.Qty;
							UnitPrice = _master.UnitPrice;
							Currency = _master.CurrencyCode;
							LineTotalValue = _master.LineTotalValue;

							break;
					}
				}
			}
		} // end getMasterQT

		#endregion

		#region class property

		public bool IsEmptyResult { get; set; }

		public int MasterQuotationId { get; set; }

		public string ItemNo { get; set; }

		public string ItemName { get; set; }

		public string ItemInfo { get; set; }

		public string Currency { get; set; }

		public string Unit { get; set; }

		public decimal Qty { get; set; }

		public decimal UnitPrice { get; set; }

		public decimal LineTotalValue { get; set; }

		#endregion
	}
}