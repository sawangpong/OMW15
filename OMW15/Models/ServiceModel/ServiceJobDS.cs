using System;

namespace OMW15.Models.ServiceModel
{
	public class ServiceJobDS
	{
		public int OrderId { get; set; }

		public string Status { get; set; }

		public string OrderCode { get; set; }

		public string OrderNo { get; set; }

		public DateTime OrderDate { get; set; }

		public string CustCode { get; set; }

		public string Customer { get; set; }

		public string Model { get; set; }

		public string SerialNo { get; set; }

		public string ErrorCode { get; set; }

		public string Error { get; set; }

		public decimal ServiceCost { get; set; }

		public decimal SparepartCost { get; set; }

		public DateTime ServiceDate { get; set; }

		public string ServiceMan { get; set; }

		public string ServiceDetails { get; set; }
	}


	public class ServiceJobSpareparts
	{
		public int OrderId { get; set; }

		public string IssueNo { get; set; }

		public string ItemNo { get; set; }

		public string Description { get; set; }

		public string Unit { get; set; }

		public decimal Qty { get; set; }

		public decimal UnitPrice { get; set; }

		public decimal Discount { get; set; }

		public decimal NetPrice { get; set; }

		public decimal Total { get; set; }
	}
}