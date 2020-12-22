namespace OMW15.Shared
{
	public class OMShareCustomerEnums
	{
		public enum AddressSource
		{
			ProvinceFromCardId,
			ProvinceCurrentAddress,
			CountryFromCardId,
			CountryCurrentAddress
		}

		public enum CustomerSearchOptions
		{
			SearchNone = 0,
			SearchByCustomerName = 1,
			SearchByCustomerCode = 2
		}

		//public enum FindMasterCustomer
		//{
		//	AllCustomers,
		//	CustomerByCategory,
		//	CustomerByName
		//}

		public enum MasterCustomerAction
		{
			None = 0,
			SearchOnly = 1
		}
	}
}