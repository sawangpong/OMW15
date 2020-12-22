using System;
using System.Collections.Generic;
using System.Data;
using System.Data.EntityClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingController
{
	public class CastingOrderReportDataItem
	{
		#region class Property
		public string CustomerCode
		{
			get;
			set;
		}
		public string CustomerName
		{
			get;
			set;
		}
		public string WorkType
		{
			get;
			set;
		}
		public string Status
		{
			get;
			set;
		}
		public string CustPO
		{
			get;
			set;
		}
		public int JobNo
		{
			get;
			set;
		}
		public DateTime JobDate
		{
			get;
			set;
		}
		public DateTime DueDate
		{
			get;
			set;
		}
		public string JobCat
		{
			get;
			set;
		}
		public string Prefix
		{
			get;
			set;
		}
		public string ItemNo
		{
			get;
			set;
		}
		public string ItemName
		{
			get;
			set;
		}
		public string Material
		{
			get;
			set;
		}
		public string OrderUnit
		{
			get;
			set;
		}
		public decimal OrderQty
		{
			get;
			set;
		}
		public string Remark
		{
			get;
			set;
		}
		public Image Picture
		{
			get;
			set;
		}

		#endregion


		public CastingOrderReportDataItem(DataRow Source)
		{
			this.CustomerCode = Source["CUSTCODE"].ToString();
			this.CustomerName = Source["CUSTNAME"].ToString();
			this.WorkType = Source["WORKTYPE"].ToString();
			this.Status = Source["STATUS"].ToString();
			this.CustPO = Source["CUSTPO"].ToString();
			this.DueDate = Convert.ToDateTime(Source["DUEDATE"]);
			this.ItemName = Source["ITEMNAME"].ToString();
			this.ItemNo = Source["ITEMNO"].ToString();
			this.JobCat = Source["JOBCAT"].ToString();
			this.JobDate = Convert.ToDateTime(Source["JOBDATE"]);
			this.JobNo = Convert.ToInt32(Source["JOBNO"]);
			this.Material = Source["MATERIAL"].ToString();
			this.OrderQty = Convert.ToDecimal(Source["ORDERQTY"]);
			this.OrderUnit = Source["ORDERUNIT"].ToString();
			this.Picture = OMControls.OMUtils.GetImage((Byte[])Source["PICTURE"]);
			this.Prefix = Source["PREFIX"].ToString();
			this.Remark = Source["REMARK"].ToString();

		}
	}
}
