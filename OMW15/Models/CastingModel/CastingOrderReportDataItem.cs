using System;
using System.Data;
using System.Drawing;
using OMControls;

namespace OMW15.Models.CastingModel
{
	public class CastingOrderReportDataItem
	{
		public CastingOrderReportDataItem(DataRow Source)
		{
			CustomerCode = Source["CUSTCODE"].ToString();
			CustomerName = Source["CUSTNAME"].ToString();
			WorkType = Source["WORKTYPE"].ToString();
			Status = Source["STATUS"].ToString();
			CustPO = Source["CUSTPO"].ToString();
			DueDate = Convert.ToDateTime(Source["DUEDATE"]);
			IsPriceWithMat = Convert.ToBoolean(Source["ISPRICEWITHMAT"]);
			ItemName = Source["ITEMNAME"].ToString();
			ItemNo = Source["ITEMNO"].ToString();
			JobCat = Source["JOBCAT"].ToString();
			JobDate = Convert.ToDateTime(Source["JOBDATE"]);
			JobNo = Convert.ToInt32(Source["JOBNO"]);
			Material = Source["MATERIAL"].ToString();
			OrderQty = Convert.ToDecimal(Source["ORDERQTY"]);
			OrderUnit = Source["ORDERUNIT"].ToString();
			Picture = OMUtils.GetImage((byte[]) Source["PICTURE"]);
			Prefix = Source["PREFIX"].ToString();
			Remark = Source["REMARK"].ToString();
		}

		#region class Property

		public bool IsPriceWithMat { get; set; }

		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }

		public string WorkType { get; set; }

		public string Status { get; set; }

		public string CustPO { get; set; }

		public int JobNo { get; set; }

		public DateTime JobDate { get; set; }

		public DateTime DueDate { get; set; }

		public string JobCat { get; set; }

		public string Prefix { get; set; }

		public string ItemNo { get; set; }

		public string ItemName { get; set; }

		public string Material { get; set; }

		public string OrderUnit { get; set; }

		public decimal OrderQty { get; set; }

		public string Remark { get; set; }

		public Image Picture { get; set; }

		#endregion
	}
}