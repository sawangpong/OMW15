using System;

namespace OMW15.Controllers.WarehouseContoller
{
	public class StockCardItem
	{
		public int Id { get; set; }

		public string DocumentNo { get; set; }

		public DateTime DocumentDate { get; set; }

		public string ItemNo { get; set; }

		public string ItemName { get; set; }

		public string ItemUOM { get; set; }

		public decimal UnitCost { get; set; }

		public decimal ReceiveQty { get; set; }

		public decimal IssueQty { get; set; }

		public decimal BalanceQty { get; set; }

		public decimal TotalCost { get; set; }
	}
}