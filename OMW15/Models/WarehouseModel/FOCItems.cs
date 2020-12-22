using System;

namespace OMW15.Models.WarehouseModel
{
	public class FOCItems
	{
		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }

		public string ItemNo { get; set; }

		public string ItemName { get; set; }

		public DateTime IssueDate { get; set; }

		public string IssueNo { get; set; }

		public string MachineSN { get; set; }

		public DateTime ContractDate { get; set; }

		public string ContractNumber { get; set; }

		public string Unit { get; set; }

		public decimal IssueQty { get; set; }

		public string Remark { get; set; }
	}
}