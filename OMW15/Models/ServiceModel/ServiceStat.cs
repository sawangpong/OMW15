using OMW15.Models.ToolModel;
using System.Data;
using System.Linq;

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
			return _om.ORDERMAINTENANCEs
					.Where(x => x.isdelete == false)
					.Select(x => new
					{
						Y = x.fiscyear
					})
					.Distinct()
					.OrderByDescending(o => o.Y)
					.AsParallel()
					.ToDataTable();

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
		} // end getServiceIncomeStat

		public DataTable getSparepartIncomeStat(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_SPAREPART_INCOME_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
		} // end getSparepartIncomeStat

		public DataTable getTotalIncomeStat(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_TOTAL_INCOME_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
		} // end getTotalIncomeStat

		public DataTable GetCommulatedServiceIncomeByServiceCode(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_LABOR_COM_INCOME_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
		} // end getCommulatedIncomeByServiceCode

		public DataTable GetCommulatedSparepartIncomeByServiceCode(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_SPAREPART_COM_INCOME_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
		} // end getCommulatedSparepartIncomeByServiceCode

		public DataTable GetCommulatedIncomeStat(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_TOTAL_COM_INCOME_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;

		} // end getCommulatedIncomeStat

		public DataTable getServiceIncomeByCustomer(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_LABOR_INCOME_BY_CUST_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
		} // end getServiceIncomeByCustomer

		public DataTable getSparepartIncomeByCustomer(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_SPAREPART_INCOME_BY_CUST_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
		} // end getSparepartIncomeByCustomer

		public DataTable getTotalIncomeByCustomer(int fiscYear)
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_COM_INCOME_BY_CUST_STAT @workyear={fiscYear}", omglobal.SysConnectionString).ToDataTable;
		} // end getTotalIncomeByCustomer

		public DataTable getServiceIncomeByYear()
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_INCOME_BY_YEAR_STAT", omglobal.SysConnectionString).ToDataTable;
		} // end getServiceIncomeByYear

		public DataTable getSparepartIncomeByYear()
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_SPAREPART_INCOME_BY_YEAR_STAT", omglobal.SysConnectionString).ToDataTable;
		} // end getSparepartIncomeByYear

		public DataTable getTotalIncomeByYear()
		{
			return new DataConnect($"EXEC dbo.usp_OM_SERVICE_TOTAL_INCOME_BY_YEAR_STAT", omglobal.SysConnectionString).ToDataTable;
		} // end getTotalIncomeByYear

		#endregion

	}
}
