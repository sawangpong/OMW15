namespace OMW15.Shared
{
	public class OMShareSaleEnum
	{
		public enum MasterQuotationListStyle
		{
			None,
			QuotationHeader,
			QuotationItem
		}

		public enum QoutationStatus
		{
			None,
			Active,
			Expire,
			Ordered,
			Drop
		}

		public enum QuotationType
		{
			Unknow,
			International,
			Local,
			Master
		}

		public enum SaleContactFilterType
		{
			None,
			AllSaleContact,
			SaleContactByName,
			SaleContactByCompany
		}

		public enum SaleContentInfo
		{
			None,
			Country,
			DeliveryTime,
			DeliveryTerm,
			PaymentTerm,
			SaleContactCountry
		}

		public enum SaleQuotationOptions
		{
			None,
			Country,
			DeliveryTerm,
			DeliveryTime,
			PaymentTerm,
			SalePerson,
			Training,
			Warranty
		}

		public enum StockFilterType
		{
			None,
			AllItems,
			ByItemNo,
			ByItemName,
			ByStockCategory
		}

		public enum PriceListItemFilterCategory
		{
			AllCategory,
			ByItemNo,
			ByItemName
		}
	}
}