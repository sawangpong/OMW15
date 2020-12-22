using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.ModelDataExtend
{
	public class ProductionWorkMonth
	{
		public string ERP_ORDER { get; set; }
		public string ERP_ORDERINFO { get; set; }
		public string STATUS { get; set; }
		public int WORKYEAR { get; set; }
		public int WORKPERIOD { get; set; }
		public string WORKERNAME { get; set; }
		public DateTime COMPLETEDATE { get; set; }
		public DateTime DATETIME_START { get; set; }
		public string ITEMNO { get; set; }
		public string ITEMNAME { get; set; }
		public decimal QORDER { get; set; }
		public string UNITORDER { get; set; }
		public int STEP { get; set; }
		public string PROCESS { get; set; }
		public decimal INPROCESS_QTY { get; set; }
		public decimal GOOD_QTY { get; set; }
		public decimal BAD_QTY { get; set; }
		public decimal TOTALQTY { get; set; }
		public decimal TOTAL_NORMAL_HR { get; set; }
		public decimal NT_COST { get; set; }
		public decimal TOTAL_OT_HR { get; set; }
		public decimal OT_COST { get; set; }
		public decimal TOTAL_HRS { get; set; }
		public decimal TOTAL_HR_COST { get; set; }

	}
}
