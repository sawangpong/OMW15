using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.ModelDataExtend
{
	public class ProductionOutsourceDS
	{
		public string ERPOrder { get; set; }
		public string APName { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime DateFinish { get; set; }
		public string BuildDetail { get; set; }
		public int Step { get; set; }
		public string ItemNo { get; set; }
		public string ItemName { get; set; }
		public string Drawing { get; set; }
		public decimal BuildQty { get; set; }
		public string Unit { get; set; }
		public decimal MaterialCost { get; set; }
		public decimal LaborCost { get; set; }
		public decimal OtherCost { get; set; }
		public decimal TotalCost { get; set; }
	}
}
