using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMControls;

namespace OMW15.Models.CastingModel
{
	public class CastingPerformanceDAL
	{
		private readonly OLDMOONEF1 _om;

		// constructor class
		public CastingPerformanceDAL()
		{
			_om = new OLDMOONEF1();
		}

		#region public class methods

		public DataTable getCastingPerformaceMenus()
		{
			DataTable result = new DataTable();
			DataColumn dc = new DataColumn("value", typeof(System.Int32));
			result.Columns.Add(dc);
			dc = new DataColumn("name", typeof(System.String));
			result.Columns.Add(dc);

			DataRow dr = result.NewRow();
			dr["value"] = 1;
			dr["Name"] = "ยอดผลิตเฉพาะส่วนที่เกิน";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["value"] = 2;
			dr["Name"] = "สรุปยอดการหล่อ (ปี)";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["value"] = 3;
			dr["Name"] = "ยอดการผลิตรวมรายเดือน";
			result.Rows.Add(dr);

			dr = result.NewRow();
			dr["value"] = 4;
			dr["Name"] = "ยอดการผลิตรายพนักงาน";
			result.Rows.Add(dr);

			return result;

		} // end getCastingPerformaceMenus

		public DataTable getWorkingMonth(int workingYear)
		{
			//DataTable result = new DataTable();
 			//var y = (from j in _om.JOBORDERS.AsEnumerable()
			//		 where j.JOBDATE.Num2Date().Year == workingYear
			//		 select new
			//		 {
			//			 WorkMonth = j.JOBDATE.Num2Date().Month,
			//			 MonthName = j.JOBDATE.Num2Date().Month.GetMonthName()
			//		 }).Distinct().OrderByDescending(o => o.WorkMonth);
 			//if (y != null)
			//	return y.ToDataTable();

			var p = _om.JOBINFOS.AsEnumerable().Where(x => x.FISCYEAR.Value == workingYear && x.ISDELETE == false).Select(x => new
			{
				WorkMonth = x.FISCPERIOD.Value ,
				MonthName = x.FISCPERIOD.Value.GetMonthName()
			}).Distinct().OrderByDescending(o => o.WorkMonth).ToDataTable();
 
			return p;

		} // end getWorkingMonth
   
		public DataTable getWorkingYear()
		{
			//DataTable result = new DataTable();
 			//var y = (from j in _om.JOBORDERS.AsEnumerable()
			//		 select new
			//		 {
			//			 WorkYear = j.JOBDATE.Num2Date().Year
			//		 }).Distinct().OrderByDescending(o => o.WorkYear);
  			//if (y != null)
			//	return y.ToDataTable();
  			//return result;

			return (_om.JOBINFOS.Where(x=>x.ISDELETE == false).Select(x=> new
			{
				WorkYear = x.FISCYEAR.Value 
			}).Distinct().OrderByDescending(o=>o.WorkYear).ToDataTable());

		} // end getworkingYear

		public DataTable getOverCastingProduction(int fiscyear)
		{
			DataTable result = new DataTable();

			var p = (from j in _om.JOBINFOS
						where j.JOBORDER.ISCANCEL == false
						&& j.JOBORDER.PREFIX == "R"
						&& j.JOBORDER.JOBDATE.Num2Date().Year == fiscyear
						&& (j.TOTALQTY - j.JOBORDER.ORDERQTY) > 0
						group j by j.GROUPCODE into op
						select new
						{
							op.Key,
							Jan = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 1 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							Feb = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 2 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							Mar = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 3 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							Apr = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 4 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							May = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 5 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							Jun = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 6 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							Jul = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 7 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							Aug = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 8 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							Sep = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 9 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							Oct = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 10 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							Nov = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 11 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							Dec = op.Sum(x => x.JOBORDER.JOBDATE.Num2Date().Month == 12 ? (x.TOTALQTY - x.JOBORDER.ORDERQTY) : 0),
							Total = op.Sum(x => (x.TOTALQTY - x.JOBORDER.ORDERQTY))
						});


			//var p = (from j in _om.JOBORDERS.AsEnumerable()
			//		join i in _om.JOBINFOS on j.JOBNO equals i.JOBNO
			//		where j.ISCANCEL == false
			//		&& j.PREFIX == "R"
			//		&& j.JOBDATE.Num2Date().Year == fiscyear
			//		&& (i.TOTALQTY - j.ORDERQTY) > 0
			//		group new
			//		{
			//			j,
			//			i
			//		} by new
			//		{
			//			i.GROUPCODE
			//		} into op
			//		select new
			//		{
			//			op.Key.GROUPCODE,
			//			Jan = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 1 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			Feb = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 2 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			Mar = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 3 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			Apr = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 4 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			May = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 5 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			Jun = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 6 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			Jul = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 7 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			Aug = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 8 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			Sep = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 9 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			Oct = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 10 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			Nov = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 11 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			Dec = op.Sum(x => x.j.JOBDATE.Num2Date().Month == 12 ? (x.i.TOTALQTY - x.j.ORDERQTY) : 0),
			//			Total = op.Sum(x => (x.i.TOTALQTY - x.j.ORDERQTY))
			//		}).AsParallel();

			if (p != null)
				return p.AsParallel().ToDataTable();


			return result;

		} // end getOverCastingProduction

		public DataTable getJobByWorkerWork(int workerId,decimal workDate)
		{
			return (from ji in _om.JOBINFOS
				orderby ji.FINISHDATE
				where ji.ISDELETE == false
				      && ji.OPERATORID == workerId
				      && ji.FINISHDATE == workDate
				select new
				{
					ji.JOBORDER.JOBNO,
					ji.GROUPCODE,
					ji.ACCEPTQTY

				}).AsParallel().ToDataTable();
		}


		#endregion
	}
}
