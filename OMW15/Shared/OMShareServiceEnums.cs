namespace OMW15.Shared
{
	public class OMShareServiceEnums
	{
		public enum EngineerStatusEnum
		{
			All = -1,
			Working = 0,
			Resign = 1
		}

		public enum EngineerViewState
		{
			Normal,
			Select
		}

		public enum OrderStatusEnum
		{
			CLOSED = 0,
			ACTIVE = 1,
			ALL = 2
		}

		//public enum PMTypeView
		//{
		//	None,
		//	AllPMView,
		//	AfterSaleServiceView,
		//	ContractPMView
		//}

		public enum ServiceAppCallEnum
		{
			ServiceOrder = 0,
			PMAppointment = 1
		}
	}
}