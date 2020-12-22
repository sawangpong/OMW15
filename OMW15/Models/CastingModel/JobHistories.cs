using System;

namespace OMW15.Models.CastingModel
{
	public class JobHistories
	{
		public string Status { get; set; }

		public int JobNo { get; set; }

		public DateTime JobOpen { get; set; }

		public DateTime JobDue { get; set; }

		public string CustomerCode { get; set; }

		public string ItemNo { get; set; }

		public string ItemName { get; set; }

		public string OrderUnit { get; set; }

		public decimal OrderQty { get; set; }
	}
}