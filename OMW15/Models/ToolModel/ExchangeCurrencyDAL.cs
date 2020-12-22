using System.Data;
using System.Data.Entity;
using System.Linq;
using OMControls;

namespace OMW15.Models.ToolModel
{
	public class ExchangeCurrencyDAL
	{
		private readonly OLDMOONEF1 _om;

		#region constructor

		public ExchangeCurrencyDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		public DataTable GetCurrencyExchangeList(string Currency, int FiscYear)
		{
			var _result = new DataTable();
			var _exch = (from exch in _om.EXCHCURRs.AsEnumerable()
				where exch.CURRENCY == Currency
				      && exch.FISCYEAR == FiscYear
				select new
				{
					exch.LINEID,
					Effective = exch.EFFECTIVEDT,
					DateEffective = exch.EFFECTIVEDT.Num2Date().ToShortDateString(),
					DateExpire = exch.EXPIREDT.Num2Date().ToShortDateString(),
					Rate = exch.EXCHANGERATE
				}).OrderByDescending(o => o.Effective);


			if (_exch != null) _result = _exch.ToDataTable();
			return _result;
		} // end GetCurrencyExchangeList

		public DataTable GetAvgExchangeByMonth(string Currency, int FiscYear)
		{
			var _result = new DataTable();
			var _exchByMonth = (from exch in _om.EXCHCURRs.AsEnumerable()
				where exch.CURRENCY == Currency
				      && exch.FISCYEAR == FiscYear
				orderby exch.FISCPERIOD ascending
				group exch by new
				{
					period = exch.FISCPERIOD,
					currency = exch.CURRENCY,
					fiscyear = exch.FISCYEAR
				}
				into avgrate
				select new
				{
					month = OMUtils.GetMonthName(avgrate.Key.period),
					avg = avgrate.Average(i => i.EXCHANGERATE)
				}).AsParallel();

			if (_exchByMonth != null) _result = _exchByMonth.ToDataTable();

			return _result;
		} // end GetAvgExchangeByMonth

		public decimal GetAvgExchangeRateByYear(string Currency, int FiscYear)
		{
			var result = 0.00m;

			result = _om.EXCHCURRs.Where(x => x.CURRENCY == Currency && x.FISCYEAR == FiscYear).Average(x => x.EXCHANGERATE);

			return result;
		} // end GetAvgExchangeRate

		public DataTable GetCurrencyUnitList()
		{
			var _result = new DataTable();
			var _currencyList = (from cr in _om.CURRENCies
				orderby cr.CURCODE
				select new
				{
					cr.CURCODE
				}).AsNoTracking().Distinct();

			if (_currencyList != null) _result = _currencyList.ToDataTable();

			return _result;
		}


		public DataTable GetCurrencyListByYear(int FiscYear)
		{
			return _om.EXCHCURRs.Where(x => x.FISCYEAR == FiscYear).Select(x => new
			{
				x.CURRENCY
			}).Distinct().ToDataTable();
		} // end GetCurrencyListByYear

		public DataTable GetExchangeYearList()
		{
			var _result = new DataTable();

			var _exch = (from ex in _om.EXCHCURRs
				select new
				{
					ex.FISCYEAR
				}).Distinct().OrderByDescending(x => x.FISCYEAR);

			if (_exch != null) _result = _exch.ToDataTable();

			return _result;
		} // end GetExchangeYearList
	}
}