namespace OMW15
{
	using System;
	using System.Collections.Generic;

	public partial class EMPLOYEE
	{
		public int MonthHours { get; set; }
		public decimal HourlyRate { get; set; }

		#region Daily Rate
		// Average Total hours = 240
		public decimal GetDailyHourRate() => DAYRATE / omglobal.WORK_HOUR_DAY;

		public decimal GetDailyHolidayHourRate() => DAYRATE / omglobal.WORK_HOUR_DAY * omglobal.HOLIDAY_WORK_FACTOR;

		public decimal GetDailyOTHourRate() => DAYRATE / omglobal.WORK_HOUR_DAY * omglobal.NORMAL_OT_FACTOR;

		public decimal GetDailyHolidayOTHourRate() => DAYRATE / omglobal.WORK_HOUR_DAY * omglobal.HOLIDAY_OT_FACTOR;

		#endregion

		#region Monthly Rate

		// Average Total hours = 240
		public decimal GetHourRate() => MONTHRATE / omglobal.TOTAL_MONTH_HOURS;

		public decimal GetHolidayHourRate() => MONTHRATE / omglobal.TOTAL_MONTH_HOURS * omglobal.HOLIDAY_WORK_FACTOR;

		public decimal GetOTHourRate() => MONTHRATE / omglobal.TOTAL_MONTH_HOURS * omglobal.NORMAL_OT_FACTOR;
		
		public decimal GetHolidayOTHourRate() => MONTHRATE / omglobal.TOTAL_MONTH_HOURS * omglobal.HOLIDAY_OT_FACTOR;

		// Actual Total hours = 208
		public decimal GetActualHourRate() => MONTHRATE / omglobal.TOTAL_ACTUAL_MONTH_HOURS;

		public decimal GetActualHolidayHourRate() => MONTHRATE / omglobal.TOTAL_ACTUAL_MONTH_HOURS * omglobal.HOLIDAY_WORK_FACTOR;

		public decimal GetActualOTHourRate() => MONTHRATE / omglobal.TOTAL_ACTUAL_MONTH_HOURS * omglobal.NORMAL_OT_FACTOR;

		public decimal GetActualHolidayOTHourRate() => MONTHRATE / omglobal.TOTAL_ACTUAL_MONTH_HOURS * omglobal.HOLIDAY_OT_FACTOR;
		#endregion

	
	}
}
