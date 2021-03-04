using OMW15.Models.ToolModel;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using static OMW15.Shared.OMShareProduction;

namespace OMW15.Models.ProductionModel
{
	public class ProductionStatDAL
	{
		private readonly OLDMOONEF1 _om;
		private readonly ERP _erp;

		#region constructor

		public ProductionStatDAL()
		{
			_om = new OLDMOONEF1();
			_erp = new ERP();
		}

		#endregion


		#region class helper

		public static DataTable GetYearList()
		{
			DataTable _dt = new DataTable();
			_dt.Columns.Add(new DataColumn("KEY", typeof(System.Int32)));
			_dt.Columns.Add(new DataColumn("VALUE", typeof(System.Int32)));

			int _y = DateTime.Today.Year;

			for (int i = 0; i <= 5; i++)
			{
				_y -= i;
				DataRow _dr = _dt.NewRow();
				_dr["KEY"] = _y;
				_dr["VALUE"] = _y;
				_dt.Rows.Add(_dr);
			}
			return _dt;

		}

		public DataTable GetWorkYear(int status)
		{
			DataTable _years = new DataTable();
			if (status == 1)
			{
				_years = _om.PRODUCTIONJOBS
								.Select(x => new
								{
									y = x.JOBYEAR
								})
								.Distinct()
								.OrderByDescending(o => o.y)
								.ToDataTable();
			}
			else
			{
				_years = _om.PRODUCTIONJOBS.AsEnumerable()
								.Where(x => x.COMPLETEDATE != null)
								.Select(x => new
								{
									y = x.COMPLETEDATE.Value.Year
								})
								.Distinct()
								.OrderByDescending(o => o.y)
								.ToDataTable();
			}

			return _years;
		}

		public DataTable GetWorkMonth(int status, int year)
		{
			return _om.PRODUCTIONJOBS.AsEnumerable()
													.Where( x => x.COMPLETEDATE != null 
																&& (status == 1 ? x.JOBYEAR == year : x.COMPLETEDATE.Value.Year == year))
													.Select(x => new
													{
														y = (status == 1 ? x.JOBYEAR : x.COMPLETEDATE.Value.Year),
														m = (status == 1 ? x.RELEASEDATE.Value.Month : x.COMPLETEDATE.Value.Month),
														Name = (status == 1 ? x.RELEASEDATE.Value.Month.GetThaiMonthName() : x.COMPLETEDATE.Value.Month.GetThaiMonthName())
													})
												.Distinct()
												.OrderByDescending(o => o.m)
												.ToDataTable();

		}


		public DataTable GetWorkYear() => _om.PRODUCTIONJOBINFOes
													.Select(x => new { x.WORKYEAR })
													.Distinct()
													.OrderByDescending(o => o.WORKYEAR)
													.ToDataTable();

		public DataTable GetWorkMonth(int year) => _om.PRODUCTIONJOBINFOes.AsEnumerable()
													.Where(x => x.WORKYEAR == year)
														.Select(x => new
														{
															x.WORKPERIOD,
															Name = x.WORKPERIOD.Value.GetThaiMonthName()
														})
													.Distinct()
													.OrderByDescending(o => o.WORKPERIOD)
													.ToDataTable();

		public DataTable GetWorkerList(int yearWork)
		{
			return _om.PRODUCTIONJOBINFOes
							.Where(x => x.WORKYEAR == yearWork)
							.Select(x => new
							{
								x.WORKERID,
								x.WORKERNAME
							})
							.Distinct()
							.OrderBy(o => o.WORKERNAME)
							.ToDataTable();
		}

		public DataTable GetWorkerStatictic(int workYear)
		{
			var _src = _om.PRODUCTIONJOBINFOes.AsEnumerable()
							.Distinct()
							.Where(x => x.WORKYEAR == workYear)
							.Select(x => new
							{
								x.WORKERNAME,
								x.WORKYEAR,
								x.WORKPERIOD,
								DoDate = x.DATETIME_START.Value.Date,
								DayHour = 208,
								x.TOTAL_NORMAL_HR
							})
							.AsParallel()
							.ToList();

			var _wk = (from w in _src
						  group w by new { w.WORKERNAME, w.WORKYEAR, w.WORKPERIOD, w.DoDate } into wk
						  select new
						  {
							  wk.Key.WORKERNAME,
							  wk.Key.WORKYEAR,
							  wk.Key.WORKPERIOD,
							  wk.Key.DoDate,
							  basehour = wk.Max(x => x.DayHour),
							  actual = wk.Sum(x => x.TOTAL_NORMAL_HR),
							  percent = wk.Sum(x => x.TOTAL_NORMAL_HR) / wk.Max(x => x.DayHour)
						  })
								.Distinct()
								.OrderBy(o => o.WORKYEAR)
								.ThenBy(o => o.WORKPERIOD)
								.ThenBy(o => o.DoDate)
								.AsParallel()
								.ToList();

			var _result = (from w in _wk.AsQueryable()
								group w by new { w.WORKERNAME } into stat
								select new
								{
									Worker = stat.Key.WORKERNAME,
									Jan = stat.Sum(x => x.WORKPERIOD == 1 ? x.percent : 0),
									Feb = stat.Sum(x => x.WORKPERIOD == 2 ? x.percent : 0),
									Mar = stat.Sum(x => x.WORKPERIOD == 3 ? x.percent : 0),
									Apr = stat.Sum(x => x.WORKPERIOD == 4 ? x.percent : 0),
									May = stat.Sum(x => x.WORKPERIOD == 5 ? x.percent : 0),
									Jun = stat.Sum(x => x.WORKPERIOD == 6 ? x.percent : 0),
									Jul = stat.Sum(x => x.WORKPERIOD == 7 ? x.percent : 0),
									Aug = stat.Sum(x => x.WORKPERIOD == 8 ? x.percent : 0),
									Sep = stat.Sum(x => x.WORKPERIOD == 9 ? x.percent : 0),
									Oct = stat.Sum(x => x.WORKPERIOD == 10 ? x.percent : 0),
									Nov = stat.Sum(x => x.WORKPERIOD == 11 ? x.percent : 0),
									Dec = stat.Sum(x => x.WORKPERIOD == 12 ? x.percent : 0),
									Avg = stat.Sum(x => x.percent) / 12
								}).AsParallel();


			return _result.ToDataTable();

		}

		#endregion

		#region Report Data

		public DataTable GetProductionJobCostDataSource(int y, int m)
		{
			return new DataConnect($"EXEC dbo.usp_OM_PRODUCTION_PRODUCTION_COST @y={y},@m={m}", omglobal.SysConnectionString).ToDataTable;
		}

		public DataTable GetDataReportByProcess(int year)
		{
			StringBuilder s = new StringBuilder();

			s.AppendLine($" SELECT ");
			s.AppendLine($" 'Process' = ISNULL(a.Process,''), ");
			s.AppendLine($" 'Operator' = ISNULL(a.WORKERNAME,'TOTAL'), ");
			s.AppendLine($" 'jan' = SUM(CASE WHEN a.WORKPERIOD = 1 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'feb' = SUM(CASE WHEN a.WORKPERIOD = 2 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'mar' = SUM(CASE WHEN a.WORKPERIOD = 3 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'apr' = SUM(CASE WHEN a.WORKPERIOD = 4 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'may' = SUM(CASE WHEN a.WORKPERIOD = 5 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'jun' = SUM(CASE WHEN a.WORKPERIOD = 6 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'jul' = SUM(CASE WHEN a.WORKPERIOD = 7 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'aug' = SUM(CASE WHEN a.WORKPERIOD = 8 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'sep' = SUM(CASE WHEN a.WORKPERIOD = 9 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'oct' = SUM(CASE WHEN a.WORKPERIOD = 10 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'nov' = SUM(CASE WHEN a.WORKPERIOD = 11 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'dec' = SUM(CASE WHEN a.WORKPERIOD = 12 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'Total' = SUM(a.NT)");
			s.AppendLine($" FROM ( ");
			s.AppendLine($" SELECT ");
			s.AppendLine($" 'Process' = CASE WHEN pch.PROCESSNAME = '' THEN RTRIM(pch.PROCESSDETAIL) ELSE RTRIM(pch.PROCESSNAME) END,");
			s.AppendLine($" pch.WORKERNAME,");
			s.AppendLine($" pch.WORKPERIOD,");
			s.AppendLine($" 'NT' = pch.TOTAL_NORMAL_HR ");
			s.AppendLine($" FROM dbo.OM_PRODUCTION_COST_HOURS pch ");
			s.AppendLine($" WHERE pch.WORKYEAR = {year} ) a ");
			s.AppendLine($" GROUP BY a.Process, a.WORKERNAME ");

			return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;
		}

		public DataTable GetDataReportByWorker(int year)
		{
			StringBuilder s = new StringBuilder();

			s.AppendLine($" SELECT ");
			s.AppendLine($" 'Operator' = ISNULL(a.WORKERNAME,''), ");
			s.AppendLine($" 'Process' =  ISNULL(a.Process,'TOTAL'), ");
			s.AppendLine($" 'jan' = SUM(CASE WHEN a.WORKPERIOD = 1 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'feb' = SUM(CASE WHEN a.WORKPERIOD = 2 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'mar' = SUM(CASE WHEN a.WORKPERIOD = 3 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'apr' = SUM(CASE WHEN a.WORKPERIOD = 4 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'may' = SUM(CASE WHEN a.WORKPERIOD = 5 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'jun' = SUM(CASE WHEN a.WORKPERIOD = 6 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'jul' = SUM(CASE WHEN a.WORKPERIOD = 7 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'aug' = SUM(CASE WHEN a.WORKPERIOD = 8 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'sep' = SUM(CASE WHEN a.WORKPERIOD = 9 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'oct' = SUM(CASE WHEN a.WORKPERIOD = 10 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'nov' = SUM(CASE WHEN a.WORKPERIOD = 11 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'dec' = SUM(CASE WHEN a.WORKPERIOD = 12 THEN a.NT ELSE 0 END),");
			s.AppendLine($" 'Total' = SUM(a.NT)");
			s.AppendLine($" FROM ( ");
			s.AppendLine($" SELECT ");
			s.AppendLine($" 'Process' = CASE WHEN pch.PROCESSNAME = '' THEN RTRIM(pch.PROCESSDETAIL) ELSE RTRIM(pch.PROCESSNAME) END,");
			s.AppendLine($" pch.WORKERNAME,");
			s.AppendLine($" pch.WORKPERIOD,");
			s.AppendLine($" 'NT' = pch.TOTAL_NORMAL_HR ");
			s.AppendLine($" FROM dbo.OM_PRODUCTION_COST_HOURS pch ");
			s.AppendLine($" WHERE pch.WORKYEAR = {year} ) a ");
			s.AppendLine($" GROUP BY a.WORKERNAME, a.Process ");

			return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;
		}

		public DataTable GetProductionJobData(int year, int jobStatus, string jobOrder = "")
		{
			DataTable _result = new DataTable();
			StringBuilder s = new StringBuilder();

			s.AppendLine(" SELECT ");
			s.AppendLine(" p.STATUS,");
			s.AppendLine(" p.ERP_ORDER,");
			s.AppendLine(" p.RELEASEDATE,");
			s.AppendLine(" p.COMPLETEDATE,");
			s.AppendLine(" p.JOBYEAR,");
			s.AppendLine(" p.ITEMNO,");
			s.AppendLine(" p.ITEMNAME,");
			s.AppendLine(" p.UNITORDER,");
			s.AppendLine(" p.QORDER,");
			s.AppendLine(" p.TOTAL_HOURS,");
			s.AppendLine(" p.TOTAL_HOUR_COST,");
			s.AppendLine(" p.TOTAL_MAT_COST,");
			s.AppendLine(" p.TOTAL_PRODUCTION_COST,");
			s.AppendLine(" pi.WORKERNAME,");
			s.AppendLine(" pi.DATETIME_START,");
			s.AppendLine(" pi.STEP,");
			s.AppendLine(" PROCESS = pi.PROCESSNAME + ' '+ pi.PROCESSDETAIL,");
			s.AppendLine(" pi.INPROCESS_QTY,");
			s.AppendLine(" pi.GOOD_QTY,");
			s.AppendLine(" pi.BAD_QTY,");
			s.AppendLine(" pi.TOTALQTY,");
			s.AppendLine(" p.TOTAL_OUTSOURCE_COST,");
			s.AppendLine(" pi.REGULAR_HR_RATE,");
			s.AppendLine(" pi.TOTAL_NORMAL_HR,");
			s.AppendLine(" pi.TOTAL_OT_HR,");
			s.AppendLine(" pi.TOTAL_HRS");
			s.AppendLine(" FROM PRODUCTIONJOBS p ");
			s.AppendLine(" LEFT JOIN PRODUCTIONJOBINFO pi ON p.ERP_ORDER = pi.ERP_ORDER ");
			s.AppendLine($" WHERE p.STATUS = {jobStatus}");
			if (jobStatus == (int)ProductionJobStatus.Active)
			{
				s.AppendLine($" AND p.JOBYEAR = {year} ");
			}
			else
			{
				s.AppendLine($" AND YEAR(p.COMPLETEDATE) = {year} ");
			}
			if (!String.IsNullOrEmpty(jobOrder))
			{
				s.AppendLine($" AND p.ERP_ORDER ='{jobOrder}'");
			}

			return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;
		}

		public DataTable GetProductionJobHeader(int year, int jobStatus, string jobOrder = "")
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine($"EXECUTE dbo.usp_OM_PRODUCTION_JOBHEADER @status={jobStatus},@year={year}, @jobnumber = '{jobOrder}'");
			return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;
		}

		public DataTable GetProductionJobInfo(string jobOrder)
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine($"EXECUTE dbo.usp_OM_PRODUCTION_JOBINFO @job = '{jobOrder}'");
			return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;
		}

		public DataTable GetProductionOutSource(string ERPOrder)
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine($"EXECUTE dbo.usp_OM_PRODUCTION_OUTSOURCE @OrderNumber = '{ERPOrder}'");
			return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;
		}

		public DataTable GetWorkByMonthData(int yearWork, int monthWork)
		{
			StringBuilder s = new StringBuilder();

			s.AppendLine($" SELECT ");
			s.AppendLine($" ih.STATUS,");
			s.AppendLine($" ih.ERP_ORDER,");
			s.AppendLine($" ih.ERP_ORDERINFO,");
			s.AppendLine($" ih.WORKERNAME,");
			s.AppendLine($" ih.COMPLETEDATE,");
			s.AppendLine($" ih.DATETIME_START,");
			s.AppendLine($" ih.ITEMNO,");
			s.AppendLine($" ih.ITEMNAME,");
			s.AppendLine($" ih.QORDER,");
			s.AppendLine($" ih.UNITORDER,");
			s.AppendLine($" ih.STEP,");
			s.AppendLine($" ih.PROCESS,");
			s.AppendLine($" ih.INPROCESS_QTY,");
			s.AppendLine($" ih.GOOD_QTY,");
			s.AppendLine($" ih.BAD_QTY,");
			s.AppendLine($" ih.TOTALQTY,");
			s.AppendLine($" ih.TOTAL_NORMAL_HR,");
			s.AppendLine($" ih.NT_COST,");
			s.AppendLine($" ih.TOTAL_OT_HR,");
			s.AppendLine($" ih.OT_COST,");
			s.AppendLine($" ih.TOTAL_HRS,");
			s.AppendLine($" ih.TOTAL_HR_COST");
			s.AppendLine($" FROM dbo.OM_PRODUCTION_ITEM_PROCESS_ACTUAL_COST_HOUR ih");
			s.AppendLine($" WHERE ih.WORKYEAR = {yearWork} AND ih.WORKPERIOD = {monthWork}");
			s.AppendLine($" ORDER BY ih.WORKERNAME, ih.ERP_ORDER, ih.DATETIME_START,ih.STEP");

			return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;
		}


		#endregion

	}
}
