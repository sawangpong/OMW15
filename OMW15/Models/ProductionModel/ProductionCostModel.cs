using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.Models.ProductionModel
{
	public class ProductionCostModel
	{
		public DateTime ReceiveDate { get; set; }
		public string Group { get; set; }
		public string ErpOrder { get; set; }
		public string IssueNo { get; set; }
		public string ItemNo { get; set; }
		public string ItemName { get; set; }
		public string ReceiveUnit { get; set; }
		public decimal ReceiveQty { get; set; }
		public decimal MatCostUnit { get; set; }
		public decimal TotalMatCost { get; set; }
		public decimal HourCostUnit { get; set; }
		public decimal TotalHourCost { get; set; }
		public decimal OutsourceUnit { get; set; }
		public decimal TotalOutsource { get; set; }
		public decimal NetUnitCost { get; set; }
		public decimal TotalCost { get; set; }

	}
}
