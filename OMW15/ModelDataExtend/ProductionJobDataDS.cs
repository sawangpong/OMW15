using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.ModelDataExtend
{
	public class ProductionJobDataDS
	{
		public int STATUS { get; set; }
		public string ERP_ORDER { get; set; }
		public DateTime RELEASEDATE { get; set; }
		public DateTime COMPLETEDATE { get; set; }
		public string ITEMNO { get; set; }
		public string ITEMNAME { get; set; }
		public string UNITORDER { get; set; }
		public decimal QORDER { get; set; }
		public decimal TOTAL_HOURS { get; set; }
		public decimal TOTAL_HOUR_COST { get; set; }
		public decimal TOTAL_OUTSOURCE_COST { get; set; }
		public decimal TOTAL_MAT_COST { get; set; }
		public decimal TOTAL_PRODUCTION_COST { get; set; }
		public string WORKERNAME { get; set; }
		public DateTime DATETIME_START { get; set; }
		public int STEP { get; set; }
		public string PROCESS { get; set; }
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
