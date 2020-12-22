using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.ModelDataExtend
{
	public class ProductionJobInfoDS
	{
		public string Erp_Order { get; set; }
		public string WORKERNAME { get; set; }
		public DateTime DATETIME_START { get; set; }
		public int STEP { get; set; }
		public string PROCESS { get; set; }
		public string DRAWINGNO { get; set; }
		public decimal INPROCESS_QTY { get; set; }
		public decimal GOOD_QTY { get; set; }
		public decimal BAD_QTY { get; set; }
		public decimal TOTALQTY { get; set; }
		public decimal REGULAR_HR_RATE { get; set; }
		public decimal TOTAL_NORMAL_HR { get; set; }
		public decimal TOTAL_OT_HR { get; set; }
		public decimal TOTAL_HRS { get; set; }

	}
}
