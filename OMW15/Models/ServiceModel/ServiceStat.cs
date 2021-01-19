using OMW15.Models.ToolModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.Models.ServiceModel
{
	public enum ServiceStatType
	{
		SUM_WORKS,
		ORDER_PIORITY,
		SUM_SERVICE_INCOME,
		SUM_SPAREPART_INCOME,
		SUM_TOTAL_INCOME,
		COM_SERVICE_INCOME,
		COM_SPAREPART_INCOME,
		COM_TOTAL_INCOME,
		SERVICE_INCOME_BY_CUSTOMER,
		SPARE_PART_INCOME_BY_CUSTOMER,
		TOTAL_INCOME_BY_CUSTOMER,
		SUM_SERVICE_INCOME_BY_YEAR,
		SUM_SPAREPART_INCOME_BY_YEAR,
		SUM_INCOME_BY_YEAR
	}

	public class ServiceStat
	{
		private readonly OLDMOONEF1 _om;


		public ServiceStat()
		{
			_om = new OLDMOONEF1();

		}

		#region class method

		public DataTable getStatType()
		{
			DataTable result = new DataTable();
			result.Columns.Add(new DataColumn("StatCode", typeof(System.String)));
			result.Columns.Add(new DataColumn("StatName", typeof(System.String)));

			DataRow dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.SUM_WORKS.ToString();
			dr["StatName"] = "ปริมาณงานประจำปี";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.ORDER_PIORITY.ToString();
			dr["StatName"] = "สรุปประเภทงานประจำปี";
			result.Rows.Add(dr);


			dr = result.NewRow();
			dr["StatCode"] = "";
			dr["StatName"] = "-------------------";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.SUM_SERVICE_INCOME.ToString();
			dr["StatName"] = "รายได้ค่าบริการประจำปี";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.SUM_SPAREPART_INCOME.ToString();
			dr["StatName"] = "รายได้ค่าอะไหล่ประจำปี";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.SUM_TOTAL_INCOME.ToString();
			dr["StatName"] = "รายได้รวมประจำปี";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = "";
			dr["StatName"] = "-------------------";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.COM_SERVICE_INCOME.ToString();
			dr["StatName"] = "รายได้ค่าบริการสะสมประจำปี";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.COM_SPAREPART_INCOME.ToString();
			dr["StatName"] = "รายได้ค่าอะไหล่สะสมประจำปี";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.COM_TOTAL_INCOME.ToString();
			dr["StatName"] = "รายได้สะสมประจำปี";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = "";
			dr["StatName"] = "-------------------";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.SERVICE_INCOME_BY_CUSTOMER.ToString();
			dr["StatName"] = "รายได้ค่าบริการแยกตามลูกค้า";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.SPARE_PART_INCOME_BY_CUSTOMER.ToString();
			dr["StatName"] = "รายได้ค่าอะไหล่แยกตามลูกค้า";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.TOTAL_INCOME_BY_CUSTOMER.ToString();
			dr["StatName"] = "รายได้สะสมแยกตามลูกค้า";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = "";
			dr["StatName"] = "-------------------";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.SUM_SERVICE_INCOME_BY_YEAR.ToString();
			dr["StatName"] = "สรุปรายได้ค่าบริการแยกรายปี";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.SUM_SPAREPART_INCOME_BY_YEAR.ToString();
			dr["StatName"] = "สรุปรายได้ค่าอะไหล่แยกรายปี";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["StatCode"] = ServiceStatType.SUM_INCOME_BY_YEAR.ToString();
			dr["StatName"] = "สรุปรายได้แยกรายปี";
			result.Rows.Add(dr);
  
			return result;
		}

		public DataTable getServiceStatYearList()
		{
			return _om.ORDERMAINTENANCEs.Where(x => x.isdelete == false).Select(x => new
			{
				Y = x.fiscyear
			}).Distinct().OrderByDescending(o => o.Y).AsParallel().ToDataTable();

		} // end getServiceStatYearList


		public DataTable getServiceStat(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_SERVICE_JOBS_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
			//DataTable result = new DataTable();
			//var stats = from rm in _om.ORDERMAINTENANCEs
			//			join oty in _om.ORDERTYPEs on rm.orderCode equals oty.ordertypecode
			//			where rm.isdelete == false
			//			&& rm.fiscyear == fiscYear
			//			orderby rm.orderCode
			//			group new
			//			{
			//				rm,
			//				oty
			//			} by new
			//			{
			//				rm.orderCode,
			//			} into stat
			//			select new
			//			{
			//				OrderName = stat.Key.orderCode + "-" + stat.FirstOrDefault().oty.ordertypename,
			//				Jan = stat.Sum(x => x.rm.period == 1 ? 1 : 0),
			//				Feb = stat.Sum(x => x.rm.period == 2 ? 1 : 0),
			//				Mar = stat.Sum(x => x.rm.period == 3 ? 1 : 0),
			//				Apr = stat.Sum(x => x.rm.period == 4 ? 1 : 0),
			//				May = stat.Sum(x => x.rm.period == 5 ? 1 : 0),
			//				Jun = stat.Sum(x => x.rm.period == 6 ? 1 : 0),
			//				Jul = stat.Sum(x => x.rm.period == 7 ? 1 : 0),
			//				Aug = stat.Sum(x => x.rm.period == 8 ? 1 : 0),
			//				Sep = stat.Sum(x => x.rm.period == 9 ? 1 : 0),
			//				Oct = stat.Sum(x => x.rm.period == 10 ? 1 : 0),
			//				Nov = stat.Sum(x => x.rm.period == 11 ? 1 : 0),
			//				Dec = stat.Sum(x => x.rm.period == 12 ? 1 : 0),
			//				Total = stat.Count()
			//			};
			//if(stats != null)
			//{
			//	result = stats.OrderBy(o => o.OrderName).ToDataTable();
			//}
			//return result;
		} // end getServiceStat

		public DataTable getServiceActionStat(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_PIORITY_JOBS_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
			//DataTable result = new DataTable();

			//var stats = from rm in _om.ORDERMAINTENANCEs
			//			join oty in _om.ORDERTYPEs on rm.orderCode equals oty.ordertypecode
			//			join ac in _om.ORDERPIORITies on rm.actionpiority equals ac.piorityid
			//			where rm.isdelete == false
			//			&& rm.fiscyear == fiscYear
			//			orderby rm.orderCode
			//			group new
			//			{
			//				rm,
			//				oty,
			//				ac
			//			} by new
			//			{
			//				rm.orderCode,
			//				ac.piorityname
			//			} into stat
			//			select new
			//			{
			//				Action = "(" + stat.Key.piorityname + ") " + stat.Key.orderCode + "-" + stat.FirstOrDefault().oty.ordertypename,
			//				Jan = stat.Sum(x => x.rm.period == 1 ? 1 : 0),
			//				Feb = stat.Sum(x => x.rm.period == 2 ? 1 : 0),
			//				Mar = stat.Sum(x => x.rm.period == 3 ? 1 : 0),
			//				Apr = stat.Sum(x => x.rm.period == 4 ? 1 : 0),
			//				May = stat.Sum(x => x.rm.period == 5 ? 1 : 0),
			//				Jun = stat.Sum(x => x.rm.period == 6 ? 1 : 0),
			//				Jul = stat.Sum(x => x.rm.period == 7 ? 1 : 0),
			//				Aug = stat.Sum(x => x.rm.period == 8 ? 1 : 0),
			//				Sep = stat.Sum(x => x.rm.period == 9 ? 1 : 0),
			//				Oct = stat.Sum(x => x.rm.period == 10 ? 1 : 0),
			//				Nov = stat.Sum(x => x.rm.period == 11 ? 1 : 0),
			//				Dec = stat.Sum(x => x.rm.period == 12 ? 1 : 0),
			//				Total = stat.Count()
			//			};

			//if(stats != null)
			//{
			//	result = stats.OrderBy(o => o.Action).ToDataTable();
			//}
			//return result;

		} // end getServiceActionStat



		public DataTable getServiceLaborIncomeStat(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_LABOR_INCOME_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
			//DataTable result = new DataTable();
			//var stats = from rm in _om.ORDERMAINTENANCEs
			//			join oty in _om.ORDERTYPEs on rm.orderCode equals oty.ordertypecode
			//			where rm.isdelete == false
			//			&& rm.servicecost > 0
			//			&& rm.fiscyear == fiscYear
			//			orderby rm.orderCode
			//			group new
			//			{
			//				rm,
			//				oty
			//			} by new
			//			{
			//				rm.orderCode,
			//			} into stat
			//			select new
			//			{
			//				OrderName = stat.Key.orderCode + "-" + stat.FirstOrDefault().oty.ordertypename,
			//				Jan = stat.Sum(x => x.rm.period == 1 ? x.rm.servicecost : 0),
			//				Feb = stat.Sum(x => x.rm.period == 2 ? x.rm.servicecost : 0),
			//				Mar = stat.Sum(x => x.rm.period == 3 ? x.rm.servicecost : 0),
			//				Apr = stat.Sum(x => x.rm.period == 4 ? x.rm.servicecost : 0),
			//				May = stat.Sum(x => x.rm.period == 5 ? x.rm.servicecost : 0),
			//				Jun = stat.Sum(x => x.rm.period == 6 ? x.rm.servicecost : 0),
			//				Jul = stat.Sum(x => x.rm.period == 7 ? x.rm.servicecost : 0),
			//				Aug = stat.Sum(x => x.rm.period == 8 ? x.rm.servicecost : 0),
			//				Sep = stat.Sum(x => x.rm.period == 9 ? x.rm.servicecost : 0),
			//				Oct = stat.Sum(x => x.rm.period == 10 ? x.rm.servicecost : 0),
			//				Nov = stat.Sum(x => x.rm.period == 11 ? x.rm.servicecost : 0),
			//				Dec = stat.Sum(x => x.rm.period == 12 ? x.rm.servicecost : 0),
			//				Total = stat.Sum(x => x.rm.servicecost)
			//			};

			//if(stats != null)
			//{
			//	result = stats.ToDataTable();
			//}
			//return result;

		} // end getServiceIncomeStat

		public DataTable getSparepartIncomeStat(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_SPAREPART_INCOME_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;


			//DataTable result = new DataTable();

			//var stats = from rm in _om.ORDERMAINTENANCEs
			//			join oty in _om.ORDERTYPEs on rm.orderCode equals oty.ordertypecode
			//			where rm.isdelete == false
			//			&& rm.sparepartcost > 0
			//			&& rm.fiscyear == fiscYear
			//			orderby rm.orderCode
			//			group new
			//			{
			//				rm,
			//				oty
			//			} by new
			//			{
			//				rm.orderCode,
			//			} into stat
			//			select new
			//			{
			//				OrderName = stat.Key.orderCode + "-" + stat.FirstOrDefault().oty.ordertypename,
			//				Jan = stat.Sum(x => x.rm.period == 1 ? x.rm.sparepartcost : 0),
			//				Feb = stat.Sum(x => x.rm.period == 2 ? x.rm.sparepartcost : 0),
			//				Mar = stat.Sum(x => x.rm.period == 3 ? x.rm.sparepartcost : 0),
			//				Apr = stat.Sum(x => x.rm.period == 4 ? x.rm.sparepartcost : 0),
			//				May = stat.Sum(x => x.rm.period == 5 ? x.rm.sparepartcost : 0),
			//				Jun = stat.Sum(x => x.rm.period == 6 ? x.rm.sparepartcost : 0),
			//				Jul = stat.Sum(x => x.rm.period == 7 ? x.rm.sparepartcost : 0),
			//				Aug = stat.Sum(x => x.rm.period == 8 ? x.rm.sparepartcost : 0),
			//				Sep = stat.Sum(x => x.rm.period == 9 ? x.rm.sparepartcost : 0),
			//				Oct = stat.Sum(x => x.rm.period == 10 ? x.rm.sparepartcost : 0),
			//				Nov = stat.Sum(x => x.rm.period == 11 ? x.rm.sparepartcost : 0),
			//				Dec = stat.Sum(x => x.rm.period == 12 ? x.rm.sparepartcost : 0),
			//				Total = stat.Sum(x => x.rm.sparepartcost)
			//			};

			//if(stats != null)
			//{
			//	result = stats.ToDataTable();
			//}
			//return result;

		} // end getSparepartIncomeStat


		public DataTable getTotalIncomeStat(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_TOTAL_INCOME_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
			//DataTable result = new DataTable();

			//var stats = from rm in _om.ORDERMAINTENANCEs
			//			join oty in _om.ORDERTYPEs on rm.orderCode equals oty.ordertypecode
			//			where rm.isdelete == false
			//			&& (rm.servicecost + rm.sparepartcost) > 0
			//			&& rm.fiscyear == fiscYear
			//			orderby rm.orderCode
			//			group new
			//			{
			//				rm,
			//				oty
			//			} by new
			//			{
			//				rm.orderCode,
			//			} into stat
			//			select new
			//			{
			//				OrderName = stat.Key.orderCode + "-" + stat.FirstOrDefault().oty.ordertypename,
			//				Jan = stat.Sum(x => x.rm.period == 1 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Feb = stat.Sum(x => x.rm.period == 2 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Mar = stat.Sum(x => x.rm.period == 3 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Apr = stat.Sum(x => x.rm.period == 4 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				May = stat.Sum(x => x.rm.period == 5 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Jun = stat.Sum(x => x.rm.period == 6 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Jul = stat.Sum(x => x.rm.period == 7 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Aug = stat.Sum(x => x.rm.period == 8 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Sep = stat.Sum(x => x.rm.period == 9 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Oct = stat.Sum(x => x.rm.period == 10 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Nov = stat.Sum(x => x.rm.period == 11 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Dec = stat.Sum(x => x.rm.period == 12 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Total = stat.Sum(x => (x.rm.servicecost + x.rm.sparepartcost))
			//			};

			//if(stats != null)
			//{
			//	result = stats.ToDataTable();
			//}
			//return result;

		} // end getTotalIncomeStat


		public DataTable GetCommulatedServiceIncomeByServiceCode(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_LABOR_COM_INCOME_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
			//DataTable result = new DataTable();

			//var stats = from rm in _om.ORDERMAINTENANCEs
			//			join oty in _om.ORDERTYPEs on rm.orderCode equals oty.ordertypecode
			//			where rm.isdelete == false
			//			&& rm.servicecost > 0
			//			&& rm.fiscyear == fiscYear
			//			orderby rm.orderCode
			//			group new
			//			{
			//				rm,
			//				oty
			//			} by new
			//			{
			//				rm.orderCode,
			//			} into stat
			//			select new
			//			{
			//				OrderName = stat.Key.orderCode + "-" + stat.FirstOrDefault().oty.ordertypename,
			//				Jan = stat.Sum(x => x.rm.period <= 1 ? x.rm.servicecost : 0),
			//				Feb = stat.Sum(x => x.rm.period <= 2 ? x.rm.servicecost : 0),
			//				Mar = stat.Sum(x => x.rm.period <= 3 ? x.rm.servicecost : 0),
			//				Apr = stat.Sum(x => x.rm.period <= 4 ? x.rm.servicecost : 0),
			//				May = stat.Sum(x => x.rm.period <= 5 ? x.rm.servicecost : 0),
			//				Jun = stat.Sum(x => x.rm.period <= 6 ? x.rm.servicecost : 0),
			//				Jul = stat.Sum(x => x.rm.period <= 7 ? x.rm.servicecost : 0),
			//				Aug = stat.Sum(x => x.rm.period <= 8 ? x.rm.servicecost : 0),
			//				Sep = stat.Sum(x => x.rm.period <= 9 ? x.rm.servicecost : 0),
			//				Oct = stat.Sum(x => x.rm.period <= 10 ? x.rm.servicecost : 0),
			//				Nov = stat.Sum(x => x.rm.period <= 11 ? x.rm.servicecost : 0),
			//				Dec = stat.Sum(x => x.rm.period <= 12 ? x.rm.servicecost : 0)
			//			};

			//if(stats != null)
			//{
			//	result = stats.ToDataTable();
			//}
			//return result;
		} // end getCommulatedIncomeByServiceCode


		public DataTable GetCommulatedSparepartIncomeByServiceCode(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_SPAREPART_COM_INCOME_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;

			//DataTable result = new DataTable();

			//var stats = from rm in _om.ORDERMAINTENANCEs
			//			join oty in _om.ORDERTYPEs on rm.orderCode equals oty.ordertypecode
			//			where rm.isdelete == false
			//			&& rm.sparepartcost > 0
			//			&& rm.fiscyear == fiscYear
			//			orderby rm.orderCode
			//			group new
			//			{
			//				rm,
			//				oty
			//			} by new
			//			{
			//				rm.orderCode,
			//			} into stat
			//			select new
			//			{
			//				OrderName = stat.Key.orderCode + "-" + stat.FirstOrDefault().oty.ordertypename,
			//				Jan = stat.Sum(x => x.rm.period <= 1 ? x.rm.sparepartcost : 0),
			//				Feb = stat.Sum(x => x.rm.period <= 2 ? x.rm.sparepartcost : 0),
			//				Mar = stat.Sum(x => x.rm.period <= 3 ? x.rm.sparepartcost : 0),
			//				Apr = stat.Sum(x => x.rm.period <= 4 ? x.rm.sparepartcost : 0),
			//				May = stat.Sum(x => x.rm.period <= 5 ? x.rm.sparepartcost : 0),
			//				Jun = stat.Sum(x => x.rm.period <= 6 ? x.rm.sparepartcost : 0),
			//				Jul = stat.Sum(x => x.rm.period <= 7 ? x.rm.sparepartcost : 0),
			//				Aug = stat.Sum(x => x.rm.period <= 8 ? x.rm.sparepartcost : 0),
			//				Sep = stat.Sum(x => x.rm.period <= 9 ? x.rm.sparepartcost : 0),
			//				Oct = stat.Sum(x => x.rm.period <= 10 ? x.rm.sparepartcost : 0),
			//				Nov = stat.Sum(x => x.rm.period <= 11 ? x.rm.sparepartcost : 0),
			//				Dec = stat.Sum(x => x.rm.period <= 12 ? x.rm.sparepartcost : 0)
			//			};

			//if(stats != null)
			//{
			//	result = stats.ToDataTable();
			//}
			//return result;

		} // end getCommulatedSparepartIncomeByServiceCode

		public DataTable GetCommulatedIncomeStat(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_TOTAL_COM_INCOME_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;

			//DataTable result = new DataTable();

			//var stats = from rm in _om.ORDERMAINTENANCEs
			//			join oty in _om.ORDERTYPEs on rm.orderCode equals oty.ordertypecode
			//			where rm.isdelete == false
			//			&& (rm.servicecost + rm.sparepartcost) > 0
			//			&& rm.fiscyear == fiscYear
			//			orderby rm.orderCode
			//			group new
			//			{
			//				rm,
			//				oty
			//			} by new
			//			{
			//				rm.orderCode,
			//			} into stat
			//			select new
			//			{
			//				OrderName = stat.Key.orderCode + "-" + stat.FirstOrDefault().oty.ordertypename,
			//				Jan = stat.Sum(x => x.rm.period <= 1 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Feb = stat.Sum(x => x.rm.period <= 2 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Mar = stat.Sum(x => x.rm.period <= 3 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Apr = stat.Sum(x => x.rm.period <= 4 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				May = stat.Sum(x => x.rm.period <= 5 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Jun = stat.Sum(x => x.rm.period <= 6 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Jul = stat.Sum(x => x.rm.period <= 7 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Aug = stat.Sum(x => x.rm.period <= 8 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Sep = stat.Sum(x => x.rm.period <= 9 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Oct = stat.Sum(x => x.rm.period <= 10 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Nov = stat.Sum(x => x.rm.period <= 11 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//				Dec = stat.Sum(x => x.rm.period <= 12 ? (x.rm.servicecost + x.rm.sparepartcost) : 0),
			//			};

			//if(stats != null)
			//{
			//	result = stats.ToDataTable();
			//}
			//return result;

		} // end getCommulatedIncomeStat

		public DataTable getServiceIncomeByCustomer(int fiscYear)
		{
			DataTable result = new DataTable();

			var stats = from rm in _om.ORDERMAINTENANCEs
						where rm.isdelete == false
						&& rm.servicecost > 0
						&& rm.fiscyear == fiscYear
						group rm by rm.cus_na into stat
						select new
						{
							Customer = stat.Key,
							Jan = stat.Sum(x => x.period == 1 ? x.servicecost : 0),
							Feb = stat.Sum(x => x.period == 2 ? x.servicecost : 0),
							Mar = stat.Sum(x => x.period == 3 ? x.servicecost : 0),
							Apr = stat.Sum(x => x.period == 4 ? x.servicecost : 0),
							May = stat.Sum(x => x.period == 5 ? x.servicecost : 0),
							Jun = stat.Sum(x => x.period == 6 ? x.servicecost : 0),
							Jul = stat.Sum(x => x.period == 7 ? x.servicecost : 0),
							Aug = stat.Sum(x => x.period == 8 ? x.servicecost : 0),
							Sep = stat.Sum(x => x.period == 9 ? x.servicecost : 0),
							Oct = stat.Sum(x => x.period == 10 ? x.servicecost : 0),
							Nov = stat.Sum(x => x.period == 11 ? x.servicecost : 0),
							Dec = stat.Sum(x => x.period == 12 ? x.servicecost : 0),
							Total = stat.Sum(x => x.servicecost)
						};
			if(stats != null)
			{
				var t = stats.OrderBy(o => o.Total).AsEnumerable().Select((x, Index) => new
				{
					RowNo = (Index + 1).ToString(),
					x.Customer,
					x.Jan,
					x.Feb,
					x.Mar,
					x.Apr,
					x.May,
					x.Jun,
					x.Jul,
					x.Aug,
					x.Sep,
					x.Oct,
					x.Nov,
					x.Dec,
					x.Total
				}).AsParallel();
				result = t.ToDataTable();
			}
			return result;

		} // end getServiceIncomeByCustomer

		public DataTable getSparepartIncomeByCustomer(int fiscYear)
		{
			DataTable result = new DataTable();

			var stats = from rm in _om.ORDERMAINTENANCEs
						where rm.isdelete == false
						&& rm.sparepartcost > 0
						&& rm.fiscyear == fiscYear
						group rm by rm.cus_na into stat
						select new
						{
							Customer = stat.Key,
							Jan = stat.Sum(x => x.period == 1 ? x.sparepartcost : 0),
							Feb = stat.Sum(x => x.period == 2 ? x.sparepartcost : 0),
							Mar = stat.Sum(x => x.period == 3 ? x.sparepartcost : 0),
							Apr = stat.Sum(x => x.period == 4 ? x.sparepartcost : 0),
							May = stat.Sum(x => x.period == 5 ? x.sparepartcost : 0),
							Jun = stat.Sum(x => x.period == 6 ? x.sparepartcost : 0),
							Jul = stat.Sum(x => x.period == 7 ? x.sparepartcost : 0),
							Aug = stat.Sum(x => x.period == 8 ? x.sparepartcost : 0),
							Sep = stat.Sum(x => x.period == 9 ? x.sparepartcost : 0),
							Oct = stat.Sum(x => x.period == 10 ? x.sparepartcost : 0),
							Nov = stat.Sum(x => x.period == 11 ? x.sparepartcost : 0),
							Dec = stat.Sum(x => x.period == 12 ? x.sparepartcost : 0),
							Total = stat.Sum(x => x.sparepartcost)
						};


			if(stats != null)
			{
				var t = stats.OrderBy(o => o.Total).AsEnumerable().Select((x, Index) => new
				{
					RowNo = (Index + 1).ToString(),
					x.Customer,
					x.Jan,
					x.Feb,
					x.Mar,
					x.Apr,
					x.May,
					x.Jun,
					x.Jul,
					x.Aug,
					x.Sep,
					x.Oct,
					x.Nov,
					x.Dec,
					x.Total
				}).AsParallel();
				result = t.ToDataTable();
			}
			return result;

		} // end getSparepartIncomeByCustomer

		public DataTable getTotalIncomeByCustomer(int fiscYear)
		{
			DataTable result = new DataTable();

			var stats = from rm in _om.ORDERMAINTENANCEs
						where rm.isdelete == false
						&& (rm.sparepartcost + rm.servicecost) > 0
						&& rm.fiscyear == fiscYear
						group rm by rm.cus_na into stat
						select new
						{
							Customer = stat.Key,
							Jan = stat.Sum(x => x.period == 1 ? (x.sparepartcost + x.servicecost) : 0),
							Feb = stat.Sum(x => x.period == 2 ? (x.sparepartcost + x.servicecost) : 0),
							Mar = stat.Sum(x => x.period == 3 ? (x.sparepartcost + x.servicecost) : 0),
							Apr = stat.Sum(x => x.period == 4 ? (x.sparepartcost + x.servicecost) : 0),
							May = stat.Sum(x => x.period == 5 ? (x.sparepartcost + x.servicecost) : 0),
							Jun = stat.Sum(x => x.period == 6 ? (x.sparepartcost + x.servicecost) : 0),
							Jul = stat.Sum(x => x.period == 7 ? (x.sparepartcost + x.servicecost) : 0),
							Aug = stat.Sum(x => x.period == 8 ? (x.sparepartcost + x.servicecost) : 0),
							Sep = stat.Sum(x => x.period == 9 ? (x.sparepartcost + x.servicecost) : 0),
							Oct = stat.Sum(x => x.period == 10 ? (x.sparepartcost + x.servicecost) : 0),
							Nov = stat.Sum(x => x.period == 11 ? (x.sparepartcost + x.servicecost) : 0),
							Dec = stat.Sum(x => x.period == 12 ? (x.sparepartcost + x.servicecost) : 0),
							Total = stat.Sum(x => (x.sparepartcost + x.servicecost))
						};

			if(stats != null)
			{
				var t = stats.OrderBy(o => o.Total).AsEnumerable().Select((x, Index) => new
				{
					RowNo = (Index + 1).ToString(),
					x.Customer,
					x.Jan,
					x.Feb,
					x.Mar,
					x.Apr,
					x.May,
					x.Jun,
					x.Jul,
					x.Aug,
					x.Sep,
					x.Oct,
					x.Nov,
					x.Dec,
					x.Total
				}).AsParallel();

				result = t.ToDataTable();
			}
			return result;

		} // end getTotalIncomeByCustomer


		public DataTable getServiceIncomeByYear()
		{
			DataTable result = new DataTable();

			var stats = from rm in _om.ORDERMAINTENANCEs
						where rm.isdelete == false
						&& (rm.servicecost) > 0
						group rm by rm.fiscyear into stat
						select new
						{
							Year = stat.Key.ToString(),
							Jan = stat.Sum(x => x.period == 1 ? (x.servicecost) : 0),
							Feb = stat.Sum(x => x.period == 2 ? (x.servicecost) : 0),
							Mar = stat.Sum(x => x.period == 3 ? (x.servicecost) : 0),
							Apr = stat.Sum(x => x.period == 4 ? (x.servicecost) : 0),
							May = stat.Sum(x => x.period == 5 ? (x.servicecost) : 0),
							Jun = stat.Sum(x => x.period == 6 ? (x.servicecost) : 0),
							Jul = stat.Sum(x => x.period == 7 ? (x.servicecost) : 0),
							Aug = stat.Sum(x => x.period == 8 ? (x.servicecost) : 0),
							Sep = stat.Sum(x => x.period == 9 ? (x.servicecost) : 0),
							Oct = stat.Sum(x => x.period == 10 ? (x.servicecost) : 0),
							Nov = stat.Sum(x => x.period == 11 ? (x.servicecost) : 0),
							Dec = stat.Sum(x => x.period == 12 ? (x.servicecost) : 0),
							Total = stat.Sum(x => (x.servicecost))
						};

			if(stats != null)
			{
				result = stats.OrderBy(o => o.Year).ToDataTable();
			}
			return result;

		} // end getServiceIncomeByYear

		public DataTable getSparepartIncomeByYear()
		{
			DataTable result = new DataTable();

			var stats = from rm in _om.ORDERMAINTENANCEs
						where rm.isdelete == false
						&& (rm.sparepartcost) > 0
						group rm by rm.fiscyear into stat
						select new
						{
							Year = stat.Key.ToString(),
							Jan = stat.Sum(x => x.period == 1 ? (x.sparepartcost) : 0),
							Feb = stat.Sum(x => x.period == 2 ? (x.sparepartcost) : 0),
							Mar = stat.Sum(x => x.period == 3 ? (x.sparepartcost) : 0),
							Apr = stat.Sum(x => x.period == 4 ? (x.sparepartcost) : 0),
							May = stat.Sum(x => x.period == 5 ? (x.sparepartcost) : 0),
							Jun = stat.Sum(x => x.period == 6 ? (x.sparepartcost) : 0),
							Jul = stat.Sum(x => x.period == 7 ? (x.sparepartcost) : 0),
							Aug = stat.Sum(x => x.period == 8 ? (x.sparepartcost) : 0),
							Sep = stat.Sum(x => x.period == 9 ? (x.sparepartcost) : 0),
							Oct = stat.Sum(x => x.period == 10 ? (x.sparepartcost) : 0),
							Nov = stat.Sum(x => x.period == 11 ? (x.sparepartcost) : 0),
							Dec = stat.Sum(x => x.period == 12 ? (x.sparepartcost) : 0),
							Total = stat.Sum(x => (x.sparepartcost))
						};

			if(stats != null)
			{
				result = stats.OrderBy(o => o.Year).ToDataTable();
			}
			return result;

		} // end getSparepartIncomeByYear

		public DataTable getTotalIncomeByYear()
		{
			DataTable result = new DataTable();

			var stats = from rm in _om.ORDERMAINTENANCEs
						where rm.isdelete == false
						&& (rm.sparepartcost + rm.servicecost) > 0
						group rm by rm.fiscyear into stat
						select new
						{
							Year = stat.Key.ToString(),
							Jan = stat.Sum(x => x.period == 1 ? (x.sparepartcost + x.servicecost) : 0),
							Feb = stat.Sum(x => x.period == 2 ? (x.sparepartcost + x.servicecost) : 0),
							Mar = stat.Sum(x => x.period == 3 ? (x.sparepartcost + x.servicecost) : 0),
							Apr = stat.Sum(x => x.period == 4 ? (x.sparepartcost + x.servicecost) : 0),
							May = stat.Sum(x => x.period == 5 ? (x.sparepartcost + x.servicecost) : 0),
							Jun = stat.Sum(x => x.period == 6 ? (x.sparepartcost + x.servicecost) : 0),
							Jul = stat.Sum(x => x.period == 7 ? (x.sparepartcost + x.servicecost) : 0),
							Aug = stat.Sum(x => x.period == 8 ? (x.sparepartcost + x.servicecost) : 0),
							Sep = stat.Sum(x => x.period == 9 ? (x.sparepartcost + x.servicecost) : 0),
							Oct = stat.Sum(x => x.period == 10 ? (x.sparepartcost + x.servicecost) : 0),
							Nov = stat.Sum(x => x.period == 11 ? (x.sparepartcost + x.servicecost) : 0),
							Dec = stat.Sum(x => x.period == 12 ? (x.sparepartcost + x.servicecost) : 0),
							Total = stat.Sum(x => (x.sparepartcost + x.servicecost))
						};

			if(stats != null)
			{
				result = stats.OrderBy(o => o.Year).ToDataTable();
			}
			return result;

		} // end getTotalIncomeByYear

		#endregion

	}
}
