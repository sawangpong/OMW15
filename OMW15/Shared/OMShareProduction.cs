using System.ComponentModel;

namespace OMW15.Shared
{
	public static class OMShareProduction
	{
		public enum HourType
		{
			UnSpecifify,
			NormalTime,
			Overtime,
			NormalTimeInHoliday,
			OvertimeInHoliday
		}

		public enum ICCodeEnum
		{
			SemiFG = 101,
			RawMaterial = 114
		}

		public enum ProductionJobStatus
		{
			None = 0,
			Active = 1,
			Closed = 2
		}

		public enum ProductionOptionEnum
		{
			None,
			ItemUnit,
			ItemMaterial,
			Machine
		}

		public enum SearchType
		{
			None,
			ItemNumber,
			TaskNumber
		}

		public enum SearchSTDItem
		{
			None,
			ItemNumber,
			ItemDescription
		}

		public enum WorkingDayCategory
		{
			NormalDay,
			Holiday
		}

		public enum ProductionJobType
		{
			Production = 0,
			Project = 1
		}

		public static string[] ProductionTransformCode = {"DTFG", "DTMG", "DTPS"};
		public static string[] ProductionPrefixGroup = {"DT", "IP"};
		public static string[] ProductionRequestCode = { "RMFG", "RMMG", "RMPS" };
	}
}