namespace OMW15.Shared
{
	public class OMShareJobEnums
	{
		public enum JobPriority
		{
			ปรกติ = 0,
			ด่วน = 1,
			ด่วนมาก = 2,
			ด่วนที่สุด = 3
		}


		//public enum EngineerRecordModeEnum
		//{
		//	None = 0,
		//	AddEdit = 1,
		//	Selection = 2
		//}

		public enum FindList
		{
			None = 0,
			หมายเลขใบงาน = 1,
			ชื่อลูกค้า = 2
		}

		public enum JobOrderCreatedMode
		{
			CreateFromPriceList,
			CreateFromJobOrderList
		}

		public enum JobStatusEnumEN
		{
			Active = 1,
			Closed = 2
		}

		public enum JobStatusEnumTH
		{
			เริ่มผลิต = 1,
			ผลิตเสร็จ = 2
		}

		//public enum ServiceOrderPiorityEnum
		//{
		//	Waitting = 0,
		//	Urgent = 1,
		//	Normal = 2,
		//	Appointment = 3
		//}

		//public enum ServiecTypeEnum
		//{
		//	SERVICE = 0,
		//	PM = 1,
		//	NONE = 3
		//}
	}
}