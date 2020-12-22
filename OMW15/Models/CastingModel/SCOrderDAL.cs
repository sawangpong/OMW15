using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using OMW15.Shared;

namespace OMW15.Models.CastingModel
{
    public class SCOrderDAL
    {
        private readonly OLDMOONEF1 _om;

        #region constructor and destructor

        public SCOrderDAL()
        {
            _om = new OLDMOONEF1();
        }

        #endregion

        public DataTable GetSCYearList()
        {
            return _om.SALEORDERS.Where(x => x.ISDELETE == false).Select(s => new
            {
                s.FISCYEAR
            }).Distinct().OrderByDescending(o => o.FISCYEAR).ToDataTable();

        } // end GetSCYearList


        public async Task<DataTable> GetAsyncSISummaryCasting(int FiscYear)
        {
            return await Task.Run(() =>
            {
                var _t = new DataTable();

                var _s = _om.SALEORDERS.Where(x => x.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
                                       && x.FISCYEAR == FiscYear
                                       && x.ISCANCEL == false
                                       && x.ISDELETE == false).AsEnumerable();

                var _so = (omglobal.NONVAT_DISPLAY == false
                    ? _s.Where(v => v.ISVAT == true).AsParallel()
                    : _s.AsParallel());

                var _sc = (from sc in _so.AsEnumerable()
                           join c in _om.CUSTOMERS on sc.CUSTCODE equals c.CUSTCODE
                           group new
                           {
                               sc,
                               c
                           } by new
                           {
                               sc.CUSTCODE
                           }
                    into sg
                           select new
                           {
                               sg.FirstOrDefault().c.CUSTNAME,
                               Jan = sg.Sum(x => x.sc.FISCPERIOD == 1 ? x.sc.NETVALUE : 0),
                               Feb = sg.Sum(x => x.sc.FISCPERIOD == 2 ? x.sc.NETVALUE : 0),
                               Mar = sg.Sum(x => x.sc.FISCPERIOD == 3 ? x.sc.NETVALUE : 0),
                               Apr = sg.Sum(x => x.sc.FISCPERIOD == 4 ? x.sc.NETVALUE : 0),
                               May = sg.Sum(x => x.sc.FISCPERIOD == 5 ? x.sc.NETVALUE : 0),
                               Jun = sg.Sum(x => x.sc.FISCPERIOD == 6 ? x.sc.NETVALUE : 0),
                               Jul = sg.Sum(x => x.sc.FISCPERIOD == 7 ? x.sc.NETVALUE : 0),
                               Aug = sg.Sum(x => x.sc.FISCPERIOD == 8 ? x.sc.NETVALUE : 0),
                               Sep = sg.Sum(x => x.sc.FISCPERIOD == 9 ? x.sc.NETVALUE : 0),
                               Oct = sg.Sum(x => x.sc.FISCPERIOD == 10 ? x.sc.NETVALUE : 0),
                               Nov = sg.Sum(x => x.sc.FISCPERIOD == 11 ? x.sc.NETVALUE : 0),
                               Dec = sg.Sum(x => x.sc.FISCPERIOD == 12 ? x.sc.NETVALUE : 0),
                               Total = sg.Sum(x => x.sc.NETVALUE)
                           }).OrderBy(o => o.Total).AsParallel();

                if (_sc != null)
                    _t = _sc.ToDataTable();
                return _t;
            });
        } // end GetAsyncSISummaryCasting


        public async Task<DataTable> AsyncSISummarySaleMaterial(int FiscYear)
        {
            return await Task.Run(() =>
            {
                var _t = new DataTable();

                var _s = _om.SALEORDERS.Where(x =>
                    x.SALETYPE == (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
                    && x.FISCYEAR == FiscYear
                    && x.ISDELETE == false
                    && x.ISCANCEL == false).AsEnumerable();

                var _so = (omglobal.NONVAT_DISPLAY == false
                    ? _s.Where(v => v.ISVAT == true).AsParallel()
                    : _s.AsParallel());

                var _sc = (from sc in _so.AsEnumerable()
                           join c in _om.CUSTOMERS on sc.CUSTCODE equals c.CUSTCODE
                           group new
                           {
                               sc,
                               c
                           } by new
                           {
                               sc.CUSTCODE
                           }
                        into sg
                           select new
                           {
                               sg.FirstOrDefault().c.CUSTNAME,
                               Jan = sg.Sum(x => x.sc.FISCPERIOD == 1 ? x.sc.NETVALUE : 0),
                               Feb = sg.Sum(x => x.sc.FISCPERIOD == 2 ? x.sc.NETVALUE : 0),
                               Mar = sg.Sum(x => x.sc.FISCPERIOD == 3 ? x.sc.NETVALUE : 0),
                               Apr = sg.Sum(x => x.sc.FISCPERIOD == 4 ? x.sc.NETVALUE : 0),
                               May = sg.Sum(x => x.sc.FISCPERIOD == 5 ? x.sc.NETVALUE : 0),
                               Jun = sg.Sum(x => x.sc.FISCPERIOD == 6 ? x.sc.NETVALUE : 0),
                               Jul = sg.Sum(x => x.sc.FISCPERIOD == 7 ? x.sc.NETVALUE : 0),
                               Aug = sg.Sum(x => x.sc.FISCPERIOD == 8 ? x.sc.NETVALUE : 0),
                               Sep = sg.Sum(x => x.sc.FISCPERIOD == 9 ? x.sc.NETVALUE : 0),
                               Oct = sg.Sum(x => x.sc.FISCPERIOD == 10 ? x.sc.NETVALUE : 0),
                               Nov = sg.Sum(x => x.sc.FISCPERIOD == 11 ? x.sc.NETVALUE : 0),
                               Dec = sg.Sum(x => x.sc.FISCPERIOD == 12 ? x.sc.NETVALUE : 0),
                               Total = sg.Sum(x => x.sc.NETVALUE)
                           }).OrderBy(o => o.Total).AsParallel();

                if (_sc != null)
                    _t = _sc.ToDataTable();
                return _t;
            });
        } // end AsyncSISummarySaleMaterial


        public async Task<DataTable> GetAsyncSIAging()
        {
            return await Task.Run(() =>
            {
                var _result = new DataTable();

                var _ag = (from b in _om.BILLS.AsEnumerable()
                           join c in _om.CUSTOMERS
                           on b.CUSTCODE equals c.CUSTCODE
                           where b.ISCANCEL == false
                                 && b.ISDELETE == false
                                 && b.ISCOMPLETE == false
                                 && b.TOTALPAYVALUE == 0.00m
                           group new
                           {
                               b,
                               c
                           } by new
                           {
                               b.CUSTCODE
                           }
                    into bl
                           select new
                           {
                               bl.FirstOrDefault().c.CUSTNAME,
                               OnDue =
                               bl.Sum(x => DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) <= 1 ? x.b.NETVALUE : 0),
                               Over1_30 =
                               bl.Sum(
                                   x =>
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) > 1 &&
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) <= 30
                                           ? x.b.NETVALUE
                                           : 0),
                               Over31_60 =
                               bl.Sum(
                                   x =>
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) >= 31 &&
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) <= 60
                                           ? x.b.NETVALUE
                                           : 0),
                               Over61_90 =
                               bl.Sum(
                                   x =>
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) >= 61 &&
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) <= 90
                                           ? x.b.NETVALUE
                                           : 0),
                               Over91_120 =
                               bl.Sum(
                                   x =>
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) >= 91 &&
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) <= 120
                                           ? x.b.NETVALUE
                                           : 0),
                               Over120_150 =
                               bl.Sum(
                                   x =>
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) >= 121 &&
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) <= 150
                                           ? x.b.NETVALUE
                                           : 0),
                               Over150_180 =
                               bl.Sum(
                                   x =>
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) >= 151 &&
                                       DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) <= 180
                                           ? x.b.NETVALUE
                                           : 0),
                               Over180 =
                               bl.Sum(
                                   x => DateAndTime.DateDiff(DateInterval.Day, x.b.DUEDATE.Num2Date(), DateTime.Today) > 180 ? x.b.NETVALUE : 0),
                               TOTAL = bl.Sum(x => x.b.NETVALUE)
                           }).OrderBy(o => o.TOTAL).AsParallel();

                if (_ag != null)
                    _result = _ag.ToDataTable();
                return _result;
            });
        } // end  GetAsyncSIAging


        public async Task<DataTable> AsyncCommulativeCastingValues(int FiscYear)
        {
            return await Task.Run(() =>
            {
                var _result = new DataTable();

                var _s = _om.SALEORDERS.Where(x =>
                    x.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
                    && x.FISCYEAR == FiscYear
                    && x.ISDELETE == false
                    && x.ISCANCEL == false).AsEnumerable();

                var _so = (omglobal.NONVAT_DISPLAY == false
                    ? _s.Where(v => v.ISVAT == true).AsParallel()
                    : _s.AsParallel());

                var _cs = (from s in _so.AsEnumerable()
                           join c in _om.CUSTOMERS on s.CUSTCODE equals c.CUSTCODE
                           group new
                           {
                               s,
                               c
                           } by new
                           {
                               s.CUSTCODE
                           }
                    into sc
                           select new
                           {
                               sc.FirstOrDefault().c.CUSTNAME,
                               Jan = sc.Sum(x => x.s.FISCPERIOD <= 1 ? x.s.NETVALUE : 0),
                               Feb = sc.Sum(x => x.s.FISCPERIOD <= 2 ? x.s.NETVALUE : 0),
                               Mar = sc.Sum(x => x.s.FISCPERIOD <= 3 ? x.s.NETVALUE : 0),
                               Apr = sc.Sum(x => x.s.FISCPERIOD <= 4 ? x.s.NETVALUE : 0),
                               May = sc.Sum(x => x.s.FISCPERIOD <= 5 ? x.s.NETVALUE : 0),
                               Jun = sc.Sum(x => x.s.FISCPERIOD <= 6 ? x.s.NETVALUE : 0),
                               Jul = sc.Sum(x => x.s.FISCPERIOD <= 7 ? x.s.NETVALUE : 0),
                               Aug = sc.Sum(x => x.s.FISCPERIOD <= 8 ? x.s.NETVALUE : 0),
                               Sep = sc.Sum(x => x.s.FISCPERIOD <= 9 ? x.s.NETVALUE : 0),
                               Oct = sc.Sum(x => x.s.FISCPERIOD <= 10 ? x.s.NETVALUE : 0),
                               Nov = sc.Sum(x => x.s.FISCPERIOD <= 11 ? x.s.NETVALUE : 0),
                               Dec = sc.Sum(x => x.s.FISCPERIOD <= 12 ? x.s.NETVALUE : 0),
                               Total = sc.Sum(x => x.s.NETVALUE)
                           }).OrderBy(o => o.Total).AsParallel();

                if (_cs != null)
                    _result = _cs.ToDataTable();

                return _result;
            });
        } // end AsyncCommulativeCastingValues

        public async Task<DataTable> AsyncCommulativeMaterialSell(int FiscYear)
        {
            return await Task.Run(() =>
            {
                var _result = new DataTable();

                var _s = _om.SALEORDERS.Where(x =>
                    x.SALETYPE == (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
                    && x.FISCYEAR == FiscYear
                    && x.ISCANCEL == false
                    && x.ISDELETE == false).AsEnumerable();

                var _so = (omglobal.NONVAT_DISPLAY == false
                    ? _s.Where(v => v.ISVAT == true).AsParallel()
                    : _s.AsParallel());



                var _cs = (from s in _so.AsEnumerable()
                           join c in _om.CUSTOMERS on s.CUSTCODE equals c.CUSTCODE
                           group new
                           {
                               s,
                               c
                           } by new
                           {
                               s.CUSTCODE
                           }
                    into sc
                           select new
                           {
                               sc.FirstOrDefault().c.CUSTNAME,
                               Jan = sc.Sum(x => x.s.FISCPERIOD <= 1 ? x.s.NETVALUE : 0),
                               Feb = sc.Sum(x => x.s.FISCPERIOD <= 2 ? x.s.NETVALUE : 0),
                               Mar = sc.Sum(x => x.s.FISCPERIOD <= 3 ? x.s.NETVALUE : 0),
                               Apr = sc.Sum(x => x.s.FISCPERIOD <= 4 ? x.s.NETVALUE : 0),
                               May = sc.Sum(x => x.s.FISCPERIOD <= 5 ? x.s.NETVALUE : 0),
                               Jun = sc.Sum(x => x.s.FISCPERIOD <= 6 ? x.s.NETVALUE : 0),
                               Jul = sc.Sum(x => x.s.FISCPERIOD <= 7 ? x.s.NETVALUE : 0),
                               Aug = sc.Sum(x => x.s.FISCPERIOD <= 8 ? x.s.NETVALUE : 0),
                               Sep = sc.Sum(x => x.s.FISCPERIOD <= 9 ? x.s.NETVALUE : 0),
                               Oct = sc.Sum(x => x.s.FISCPERIOD <= 10 ? x.s.NETVALUE : 0),
                               Nov = sc.Sum(x => x.s.FISCPERIOD <= 11 ? x.s.NETVALUE : 0),
                               Dec = sc.Sum(x => x.s.FISCPERIOD <= 12 ? x.s.NETVALUE : 0),
                               Total = sc.Sum(x => x.s.NETVALUE)
                           }).OrderBy(o => o.Total).AsParallel();

                if (_cs != null)
                    _result = _cs.ToDataTable();

                return _result;
            });
        } // end AsyncCommulativeMaterialSell


        public async Task<DataTable> AsyncBillCollectionSummary(int FiscYear)
        {
            return await Task.Run(() =>
            {
                var _result = new DataTable();

                var _bc = (from b in _om.BILLS.Where(x => x.TOTALPAYVALUE > 0.00m).AsEnumerable()
                           join c in _om.CUSTOMERS
                           on b.CUSTCODE equals c.CUSTCODE
                           where b.ISCANCEL == false
                                 && b.ISDELETE == false
                                 && b.ISCOMPLETE
                                 && b.INVDATE.Num2Date().Year == FiscYear
                           group new
                           {
                               b,
                               c
                           } by new
                           {
                               b.CUSTCODE
                           }
                    into bl
                           select new
                           {
                               bl.FirstOrDefault().c.CUSTNAME,
                               Jan = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 1 ? x.b.TOTALPAYVALUE : 0),
                               Feb = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 2 ? x.b.TOTALPAYVALUE : 0),
                               Mar = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 3 ? x.b.TOTALPAYVALUE : 0),
                               Apr = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 4 ? x.b.TOTALPAYVALUE : 0),
                               May = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 5 ? x.b.TOTALPAYVALUE : 0),
                               Jun = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 6 ? x.b.TOTALPAYVALUE : 0),
                               Jul = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 7 ? x.b.TOTALPAYVALUE : 0),
                               Aug = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 8 ? x.b.TOTALPAYVALUE : 0),
                               Sep = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 9 ? x.b.TOTALPAYVALUE : 0),
                               Oct = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 10 ? x.b.TOTALPAYVALUE : 0),
                               Nov = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 11 ? x.b.TOTALPAYVALUE : 0),
                               Dec = bl.Sum(x => x.b.INVDATE.Num2Date().Month == 12 ? x.b.TOTALPAYVALUE : 0),
                               Total = bl.Sum(x => x.b.TOTALPAYVALUE)
                           }).OrderBy(o => o.Total).AsParallel();

                if (_bc != null)
                    _result = _bc.ToDataTable();

                return _result;
            });
        } // end AsyncBillCollectionSummary

        public async Task<DataTable> AsyncNonBillingSIOrders(int Fiscyear)
        {
            return await Task.Run(() =>
            {
                var _nbsi = (from s in _om.SALEORDERS
                             join c in _om.CUSTOMERS on s.CUSTCODE equals c.CUSTCODE
                             orderby s.CUSTCODE
                             where s.ISCOMPLETE == false
                                   && s.ISCANCEL == false
                                   && s.ISDELETE == false
                                   && s.BILLSEQ == 0
                                   && s.FISCYEAR == Fiscyear
                             group new
                             {
                                 s,
                                 c
                             } by new
                             {
                                 s.CUSTCODE
                             }
                    into _si
                             select new
                             {
                                 _si.FirstOrDefault().c.CUSTNAME,
                                 Jan = _si.Sum(x => x.s.FISCPERIOD == 1 ? x.s.NETVALUE : 0),
                                 Feb = _si.Sum(x => x.s.FISCPERIOD == 2 ? x.s.NETVALUE : 0),
                                 Mar = _si.Sum(x => x.s.FISCPERIOD == 3 ? x.s.NETVALUE : 0),
                                 Apr = _si.Sum(x => x.s.FISCPERIOD == 4 ? x.s.NETVALUE : 0),
                                 May = _si.Sum(x => x.s.FISCPERIOD == 5 ? x.s.NETVALUE : 0),
                                 Jun = _si.Sum(x => x.s.FISCPERIOD == 6 ? x.s.NETVALUE : 0),
                                 Jul = _si.Sum(x => x.s.FISCPERIOD == 7 ? x.s.NETVALUE : 0),
                                 Aug = _si.Sum(x => x.s.FISCPERIOD == 8 ? x.s.NETVALUE : 0),
                                 Sep = _si.Sum(x => x.s.FISCPERIOD == 9 ? x.s.NETVALUE : 0),
                                 Oct = _si.Sum(x => x.s.FISCPERIOD == 10 ? x.s.NETVALUE : 0),
                                 Nov = _si.Sum(x => x.s.FISCPERIOD == 11 ? x.s.NETVALUE : 0),
                                 Dec = _si.Sum(x => x.s.FISCPERIOD == 12 ? x.s.NETVALUE : 0),
                                 Total = _si.Sum(x => x.s.NETVALUE)
                             }).AsParallel();

                return _nbsi.ToDataTable();
            });
        } // end AsyncNonBillingSIOrders
    }
}