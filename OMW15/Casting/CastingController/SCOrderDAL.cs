using System;
using System.Collections.Generic;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMW15.Shared;
using OMControls;

namespace OMW15.Casting.CastingController
{
	public class SCOrderDAL
	{
		private bool disposed = false;
		private OLDMOONEF _om;

		#region constructor and destructor

		public SCOrderDAL()
		{
			_om = new OLDMOONEF();
		}

		//~SCOrderDAL()
		//{
		//	Dispose(true);
		//}

		//// Protected implementation of Dispose pattern. 
		//protected virtual void Dispose(bool disposing)
		//{
		//	if (disposed)
		//	{
		//		return;
		//	}

		//	if (disposing)
		//	{
		//		// Free any other managed objects here. 
		//		_om.Dispose();
		//	}

		//	// Free any unmanaged objects here. 
		//	//
		//	disposed = true;
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}

		#endregion

		public int GetNewSaleOrderNumber(Boolean isVAT, DateTime OrderDate, out string NewSaleOrder)
		{
			int NewOrder = 0;
			string saleFormatCode = string.Empty;
			string saleNumber = string.Empty;
			NewSaleOrder = string.Empty;

			// CultureInfo thai_culture = new CultureInfo("th-TH");
			// DateTimeFormatInfo dt_format = thai_culture.DateTimeFormat;
			// string THDate = OrderDate.ToString("yyMM", dt_format);

			var sc = (from s in _om.SALEORDERS
					  where s.ISDELETE == false
					  && s.ISCANCEL == false
					  && s.FISCYEAR == OrderDate.Year
					  && s.FISCPERIOD == OrderDate.Month
					  && s.ISVAT == isVAT
					  && s.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
					  group s by new
					  {
						  y = s.FISCYEAR,
						  p = s.FISCPERIOD
					  } into m
					  select new
					  {
						  id = m.Max(i => i.SOSEQ)
					  }).FirstOrDefault();


			if (sc != null)
			{
				NewOrder = sc.id + 1;
			}
			else
			{
				NewOrder = 1;
			}


			saleFormatCode = (isVAT == true ? OMControls.OMUtils.GetThaiCodeFormat(OrderDate) : OMControls.OMUtils.GetGeneralCodeFormat(OrderDate));

			if (NewOrder.ToString().Length < 3)
			{
				NewSaleOrder = string.Format("{0}{1}{2}", saleFormatCode, ("000".Substring(0, 3 - NewOrder.ToString().Length)), NewOrder);
			}
			else
			{
				NewSaleOrder = string.Format("{0}{1}", saleFormatCode, NewOrder);
			}

			return NewOrder;

		} // end GetNewSaleOrderNumber
	}
}
