using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.Models.ProductionModel
{
	public class IssueItem
	{
		public int Index { get; set; }
		public string DepartmentCode { get; set; }
		public int DepartmentId { get; set; }
		public DateTime DocumentDate { get; set; }
		public int DocumentKey { get; set; }
		public string DocumentNo { get; set; }
		public string ICCode { get; set; }
		public int ICKey { get; set; }
		public string ICName { get; set; }
		public int IssueLineId { get; set; }
		public string OrderNumber { get; set; }
		public int ProjectNo { get; set; }
		public decimal ShipGrandTotal { get; set; }
		public string ShipItemNo { get; set; }
		public string ShipItemName { get; set; }
		public string ShipUnit { get; set; }
		public decimal ShipQty { get; set; }
		public decimal ShipUnitPrice { get; set; }
		public decimal ShipTotalVAT { get; set; }
		public decimal ShipTotalValue { get; set; }
	}
}
