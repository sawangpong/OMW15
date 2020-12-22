using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMControls;

namespace OMW15.Tools.ToolController
{
	public class ExchangeCurrencyController
	{
		public static DataTable GetCurrencyExchangeList(string Currency,int FiscYear)
		{
			DataTable _result = new DataTable();
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _exch = from exch in _oldmoon.EXCHCURRs.AsParallel()
							where exch.CURRENCY == Currency
							&& exch.FISCYEAR == FiscYear
							select new
							{
								exch.LINEID,
								Effective = exch.EFFECTIVEDT,
								Expire = exch.EXPIREDT,
								Rate = exch.EXCHANGERATE
							};
				var exchList = (from ex in _exch.AsEnumerable()
							   select new
							   {
								   ex.LINEID,
								   ex.Effective,
								   DateEffective = OMControls.OMUtils.Num2Date(ex.Effective).ToShortDateString(),
								   DateExpire = OMControls.OMUtils.Num2Date(ex.Expire).ToShortDateString(),
								   ex.Rate
							   }).OrderByDescending(x=>x.Effective);

				if (exchList != null)
				{
					_result = OMControls.OMDataUtils.ToDataTable(exchList.ToList());
				}
			}
			return _result;

		} // end GetCurrencyExchangeList

		public static DataTable GetAvgExchangeByMonth(string Currency, int FiscYear)
		{
			DataTable _result = new DataTable();
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _exchByMonth = (from exch in _oldmoon.EXCHCURRs.AsParallel()
									where exch.CURRENCY == Currency 
									&& exch.FISCYEAR == FiscYear
									orderby exch.FISCPERIOD ascending
									group exch by new
									{
										period = exch.FISCPERIOD,
										currency = exch.CURRENCY,
										fiscyear = exch.FISCYEAR
									} into avgrate
									select new
									{
										month = OMControls.OMUtils.GetMonthName(avgrate.Key.period),
										avg = avgrate.Average(i => i.EXCHANGERATE)
									}).ToList();

				if (_exchByMonth != null)
				{
					_result = OMControls.OMDataUtils.ToDataTable(_exchByMonth);
				}
			}

			return _result;
		} // end GetAvgExchangeByMonth

		public static decimal GetAvgExchangeRateByYear(string Currency, int FiscYear)
		{
			decimal result = 0.00m;
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				//var _exchList = (from exch in _oldmoon.EXCHCURRs.AsParallel()
				//				 where exch.CURRENCY == Currency
				//				 && exch.FISCYEAR == FiscYear
				//				 group exch by new
				//				 {
				//					 currency = exch.CURRENCY,
				//					 fiscyear = exch.FISCYEAR
				//				 } into avgrate
				//				 select new
				//				 {
				//					 avg = avgrate.Average(i => i.EXCHANGERATE)
				//				 }).FirstOrDefault();

				//if (_exchList != null)
				//{
				//	return _exchList.avg;
				//}
				result = _oldmoon.EXCHCURRs.Where(x => x.CURRENCY == Currency && x.FISCYEAR == FiscYear).Average(x => x.EXCHANGERATE);

			} // end 

			return result;

		} // end GetAvgExchangeRate
	}
}
