namespace OMW15.Shared
{
	public class OMShareCastingEnums
	{
		public enum CalVATMethod
		{
			NoVAT = 0,
			ExcludeVAT = 1,
			IncludeVAT = 2
		}

		public enum CastingOrderCallType
		{
			None = 0,
			AvailableOrderForSell = 1,
			CastingOrderList = 2
		}

		public enum CastingOrderStatus
		{
			All = 0,
			Active = 1,
			Closed = 2
		}


		public enum CustomerList
		{
			All,
			OnlyForCastingSaleOrders,
			OnlyForMaterialCards
		}

		public enum SaleTypeEnum
		{
			ไม่ระบุ = 0,
			ค่าบริการ = 1,
			ขายวัสดุ = 2,
			ทดลองหล่อ = 4,
			งานซ่อม = 5
		}

		public enum SaleTypeEnumEN
		{
			None = 0,
			CastingCharge = 1,
			SaleMaterial = 2,
			TestCasting = 4,
			RepairWork = 5
		}

		public enum UpdateMaterialOpenBalanceMode
		{
			AllCustomers,
			SelectedCustomerOnly
		}

		public const string CASTING_ORDER_PREFIX = "SI";
		public const string CASTING_INVOICE_PREFIX = "IV";
		public const string CASTING_BILLING_PREFIX = "BL";
	}
}