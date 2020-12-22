using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.ModelDataExtend
{
	public class ProductionJobHeaderDS
	{
		public int Status { get; set; }
		public string StatusName { get; set; }
		public string Erp_Order { get; set; }
		public DateTime ReleaseDate { get; set; }
		public DateTime CompleteDate { get; set; }
		public int JobYear { get; set; }
		public string ItemNo { get; set; }
		public string ItemName { get; set; }
		public string UnitOrder { get; set; }
		public decimal Qorder { get; set; }
		public decimal ShipQty { get; set; }
		public DateTime ReceivedDate { get; set; }
		public string ReceivedBy { get; set; }
		public decimal Total_Hours { get; set; }
		public decimal Total_Hour_Cost { get; set; }
		public decimal Total_Outsource_Cost { get; set; }
		public decimal Total_Mat_Cost { get; set; }
		public decimal Total_Production_Cost { get; set; }
		public int ProcessCount { get; set; }
		public int Outsource { get; set; }
	}
}
