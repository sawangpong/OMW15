using System;

namespace OMW15.Model.Extend
{
	public class ValidProductionTime
	{
		public string Badgenumber { get; set; }
		public string name { get; set; }
		public string EMPCODE { get; set; }
		public string fname { get; set; }
		public DateTime Date_Only { get; set; }
		public int Y { get; set; }
		public int M { get; set; }
		public int D { get; set; }
		public TimeSpan time_checkin { get; set; }
		public TimeSpan time_checkout { get; set; }
		public string status { get; set; }
		public int ValidHour { get; set; }
	}
}
