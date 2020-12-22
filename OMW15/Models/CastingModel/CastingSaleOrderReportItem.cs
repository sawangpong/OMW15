using System;
using System.Data;

namespace OMW15.Models.CastingModel
{
	public class CastingSaleOrderReportItem
	{
		public CastingSaleOrderReportItem(DataRow RowSource)
		{
		}

		#region properties

		public int SaleOrderId { get; set; }

		public string SaleOrderNumber { get; set; }

		public DateTime SaleOrderDate { get; set; }

		public DateTime ActualDeliveryDate { get; set; }

		public DateTime Duedate { get; set; }

		public int CustomerId { get; set; }

		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }

		public string CustomerBranch { get; set; }

		public string CustomerAddress { get; set; }

		public string ContactPerson { get; set; }

		public decimal TotalValues { get; set; }

		public decimal TotalDiscount { get; set; }

		public decimal TotalNetValues { get; set; }

		public decimal VatRate { get; set; }

		public decimal TotalVATValues { get; set; }

		public decimal TotalAmountValues { get; set; }

		public string TotalAmountText { get; set; }

		public int DeliveredMaterialId { get; set; }

		public string DeliveredMaterial { get; set; }

		public decimal DeliveredWeight { get; set; }

		public decimal TotalLineWeight { get; set; }

		public string SaleOrderRemark { get; set; }

		public int SOLineId { get; set; }

		public string ItemPrefix { get; set; }

		public string ItemNo { get; set; }

		public string ItemName { get; set; }

		public string ItemUnit { get; set; }

		public decimal DeliveredItemQty { get; set; }

		public decimal ItemUnitPrice { get; set; }

		public decimal ItemDiscountValue { get; set; }

		public decimal TotalValue { get; set; }

		public decimal ItemNetValue { get; set; }

		public decimal ItemVATValue { get; set; }

		public decimal ItemTotalValues { get; set; }

		public decimal UnitWeight { get; set; }

		public string ItemRemark { get; set; }

		public string CustomerTaxId { get; set; }

		public string Branch { get; set; }

		#endregion
	}
}