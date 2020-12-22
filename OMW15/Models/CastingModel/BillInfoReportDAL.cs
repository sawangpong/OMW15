using System;

namespace OMW15.Models.CastingModel
{
	public class BillInfoReportDAL
	{
		// CONSTRUCTOR

		#region class property

		public int BillId { get; set; }

		public string BillNo { get; set; }

		public DateTime BillDate { get; set; }

		public string CustomerCode { get; set; }

		public string Customer { get; set; }

		public DateTime BillDue { get; set; }

		public int DOCount { get; set; }

		public decimal TotalValue { get; set; }

		public decimal TotalVAT { get; set; }

		public decimal TotalAmount { get; set; }

		public string TotalAmountText { get; set; }

		public string SONumber { get; set; }

		public DateTime DODate { get; set; }

		public string SaleInfo { get; set; }

		public decimal SOTotalValue { get; set; }


		public decimal SODiscount { get; set; }

		public decimal SONetValue { get; set; }

		public decimal SOVAT { get; set; }

		public decimal SOAmount { get; set; }

		#endregion
	}
}