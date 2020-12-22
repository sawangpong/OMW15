using System;

namespace OMW15.Models.CastingModel
{
	public class CastingReportFields
	{
		public int SALEGROUPID { get; set; }

		public string SALEGROUPNAME { get; set; }

		public int SALETYPE { get; set; }

		public string SONO { get; set; }

		public DateTime SIDate { get; set; }

		public string CUSTCODE { get; set; }

		public string CUSTNAME { get; set; }

		public decimal TOTALVALUE { get; set; }

		public decimal DISCOUNT { get; set; }

		public decimal NETVALUE { get; set; }

		public decimal VATVALUE { get; set; }

		public decimal TOTALAMOUNT { get; set; }

		public string CATEGORY { get; set; }

		public string MATERIAL { get; set; }

		public decimal DELIVERWEIGHT { get; set; }

		public decimal SIWEIGHT { get; set; }

		public string UNIT { get; set; }

		public decimal UNITPRICE { get; set; }

		public decimal DELIVEREDQTY { get; set; }
	}
}