using System;

namespace OMW15.Models.CastingModel
{
	public class CastingJobList
	{
		public int Status { get; set; }

		public string JobStatusName { get; set; }

		public string JobNo { get; set; }

		public DateTime OrderDate { get; set; }

		public DateTime Start { get; set; }

		public DateTime Due { get; set; }

		public DateTime Finish { get; set; }

		public int rd { get; set; }

		public int CustomerId { get; set; }

		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }

		public int ItemId { get; set; }

		public string CAT { get; set; }

		public string ItemNo { get; set; }

		public string ItemName { get; set; }

		public string Material { get; set; }

		public string Unit { get; set; }

		public decimal Qty { get; set; }

		public decimal Remain { get; set; }
	}
}