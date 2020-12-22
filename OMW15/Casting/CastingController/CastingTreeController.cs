using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using OMControls;
using OMW15.Shared;

namespace OMW15.Casting.CastingController
{
	public class CastingTreeController 
	{
		private OLDMOONEF _om;
		
		#region constructor and destructor

		public CastingTreeController()
		{
			_om = new OLDMOONEF();
		}

		//protected virtual void Dispose(bool disposing)
		//{
		//	if (disposed)
		//	{
		//		return;
		//	}

		//	if (disposing)
		//	{
		//		// dispose managed resources
		//		_om.Dispose();
		//	}

		//	disposed = true;
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}

		//~CastingTreeController()
		//{
		//	Dispose(true);
		//}

		#endregion

		#region  class method

		public DataTable GetCastingTrees(DateTime CurrentDate)
		{
			decimal _currentDate = (Decimal)OMControls.OMUtils.Date2Num(CurrentDate);
			DataTable _result = new DataTable();
			var ct = (from c in _om.WAXTREES
					  join s in _om.SYSDATAs on c.MATCASTING.ToString() equals s.KEYVALUE
					  orderby s.CATEGORY, c.MATCASTING
					  where s.GROUPTITLE == "MATERIAL"
					  && c.ISDELETE == false
					  && c.BUILDDATE == _currentDate
					  select new
					  {
						  c.BUILDDATE,
						  c.WAXTREEID,
						  c.MATCASTING,
						  s.THKEYNAME,
						  c.RUBBERBASENO,
						  c.BASEWEIGHT,
						  c.BASENWAXWG,
						  waxweight = c.BASENWAXWG - c.BASEWEIGHT,
						  c.MATFACTOR,
						  c.MATADDWEIGHT,
						  c.MATWEIGHTBF,
						  c.ACTUALMATWEIGHT,
						  c.MATWEIGHTAF,
						  c.MATWEIGHTLOSS,
						  c.WEIGHTWITHCONTAINER,
						  S100 = c.SILVER100,
						  S94 = c.SILVER94,
						  S95 = c.SILVER95,
						  MAT = c.OTHERMAT,
						  MATWEIGHT = c.OTHERMATWEIGHT,
						  G100 = c.GOLD100.Value,
						  c.ALLOYTYPE,
						  c.ALLOYWEIGHT
					  }).ToList();

			var t = ct.AsEnumerable().Select((x, Index) => new
					  {
						  RowNo = Index + 1,
						  TreeId = x.WAXTREEID,
						  Date = OMControls.OMUtils.Num2Date(x.BUILDDATE).ToShortDateString(),
						  MatId = x.MATCASTING,
						  MatName = x.THKEYNAME,
						  Factor = x.MATFACTOR,
						  BaseNo = x.RUBBERBASENO,
						  WTBase = x.BASEWEIGHT,
						  BaseWithWax = x.BASENWAXWG,
						  WTNetWax = x.waxweight,
						  WTNeed = (x.waxweight * x.MATFACTOR),
						  AddMat = x.MATADDWEIGHT,
						  WTTotal = x.MATADDWEIGHT + (x.waxweight * x.MATFACTOR),
						  WTBeforeCast = x.MATWEIGHTBF,
						  ActualWeight = x.ACTUALMATWEIGHT,
						  WTGold = x.G100,
						  WTSV100 = x.S100,
						  WTSV95 = x.S95,
						  WTSV94 = x.S94,
						  ExtraMAT = x.MAT,
						  WTExtraMat = x.MATWEIGHT,
						  Alloy = x.ALLOYTYPE,
						  WTAlloy = x.ALLOYWEIGHT,
						  WTAfterCast = x.MATWEIGHTAF,
						  WTLoss = x.MATWEIGHTLOSS,
						  RealLoss = (x.ACTUALMATWEIGHT > 0.00m ? ((x.MATWEIGHTLOSS > 0.00m ? x.MATWEIGHTLOSS : 0) / x.ACTUALMATWEIGHT) : 0),
						  Loss = string.Format("{0:P2}", (x.ACTUALMATWEIGHT > 0 ? ((x.MATWEIGHTLOSS > 0.00m ? x.MATWEIGHTLOSS : 0) / x.ACTUALMATWEIGHT) : 0))
					  });

			if (t != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(t);
			}

			return _result;

		} // end GetCastingTrees

		public DataTable GetDailySummaryCastingInfo(DateTime SelectedDate)
		{
			decimal _currentDate = (Decimal)OMControls.OMUtils.Date2Num(SelectedDate);
			DataTable _result = new DataTable();
			var dc = (from wt in _om.WAXTREES
					  join sd in _om.SYSDATAs on wt.MATCASTING.ToString() equals sd.KEYVALUE
					  orderby sd.CATEGORY, wt.MATCASTING
					  where wt.ISDELETE == false
					  && sd.GROUPTITLE == "MATERIAL"
					  && wt.BUILDDATE == _currentDate
					  && wt.ACTUALMATWEIGHT > 0.00m
					  && (wt.ACTUALMATWEIGHT - wt.MATWEIGHTAF) > 0.00m
					  group wt by new
					  {
						  sd.THKEYNAME,
						  wt.MATCASTING,
						  wt.BUILDDATE,
						  wt.ALLOYTYPE,
						  wt.OTHERMAT
					  } into qt
					  select new
					  {
						  Material = qt.Key.THKEYNAME,
						  QFlusk = qt.Count(),
						  Gold = qt.Sum(x => x.GOLD100.Value),
						  SV100 = qt.Sum(x => x.SILVER100),
						  SV95 = qt.Sum(x => x.SILVER95),
						  SV94 = qt.Sum(x => x.SILVER94),
						  Alloy = qt.Key.ALLOYTYPE,
						  TotalAlloy = qt.Sum(x => x.ALLOYWEIGHT),
						  OtherMaterial = qt.Key.OTHERMAT,
						  TotalOtherMat = qt.Sum(x => x.OTHERMATWEIGHT),
						  TotalWeightBF = qt.Sum(x => x.MATWEIGHTBF),
						  TotalActualWeight = qt.Sum(x => x.ACTUALMATWEIGHT),
						  TotalWeightAF = qt.Sum(x => x.MATWEIGHTAF),
						  Slag = qt.Sum(x => x.SLAG),
						  WTLoss = (qt.Sum(x => x.ACTUALMATWEIGHT) - qt.Sum(x => x.MATWEIGHTAF) + qt.Sum(x => x.SLAG)),
						  Loss = (qt.Sum(x => x.ACTUALMATWEIGHT) - qt.Sum(x => x.MATWEIGHTAF) + qt.Sum(x => x.SLAG)) / qt.Sum(x => x.ACTUALMATWEIGHT)
					  }).ToList();

			if (dc != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(dc);
			}
			return _result;

		} // end GetDailySummaryCastingInfo

		public DataTable GetYearSummaryLossCasting(int FiscYear)
		{
			DataTable _result = new DataTable();
			string _yearText = FiscYear.ToString();
			var dc = (from wt in _om.WAXTREES
					  join sd in _om.SYSDATAs on wt.MATCASTING.ToString() equals sd.KEYVALUE
					  where wt.ISDELETE == false
					  && sd.GROUPTITLE == "MATERIAL"
					  && wt.ACTUALMATWEIGHT > 0.00m
					  && (wt.ACTUALMATWEIGHT - wt.MATWEIGHTAF - wt.SLAG) > 0.00m
					  && wt.BUILDDATE.ToString().Substring(0, 4) == _yearText
					  select new
					  {
						  Group = sd.CATEGORY,
						  CastDT = wt.BUILDDATE,
						  ActualWT = wt.ACTUALMATWEIGHT,
						  weightAF = (wt.MATWEIGHTAF + wt.SLAG),
						  loss = (wt.ACTUALMATWEIGHT - wt.MATWEIGHTAF - wt.SLAG)
					  }).ToList();

			var r = (from d in dc
					 select new
					 {
						 d.Group,
						 m = d.CastDT.Num2Date().Month,
						 d.ActualWT,
						 AfterCast = d.weightAF,
						 Loss = d.loss < 0.00m ? 0 : d.loss
					 }).OrderBy(x => x.Group).ToList();


			var l = (from e in r
					 group e by e.Group into rg
					 select new
					 {
						 Group = rg.Key,
						 Jan = rg.Sum(x => (x.m == 1 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 1 ? x.ActualWT : 1.00m)),

						 Feb = rg.Sum(x => (x.m == 2 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 2 ? x.ActualWT : 1.00m)),

						 Mar = rg.Sum(x => (x.m == 3 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 3 ? x.ActualWT : 1.00m)),

						 Apr = rg.Sum(x => (x.m == 4 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 4 ? x.ActualWT : 1.00m)),

						 May = rg.Sum(x => (x.m == 5 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 5 ? x.ActualWT : 1.00m)),

						 Jun = rg.Sum(x => (x.m == 6 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 6 ? x.ActualWT : 1.00m)),

						 Jul = rg.Sum(x => (x.m == 7 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 7 ? x.ActualWT : 1.00m)),

						 Aug = rg.Sum(x => (x.m == 8 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 8 ? x.ActualWT : 1.00m)),

						 Sep = rg.Sum(x => (x.m == 9 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 9 ? x.ActualWT : 1.00m)),

						 Oct = rg.Sum(x => (x.m == 10 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 10 ? x.ActualWT : 1.00m)),

						 Nov = rg.Sum(x => (x.m == 11 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 11 ? x.ActualWT : 1.00m)),

						 Dec = rg.Sum(x => (x.m == 12 ? (x.ActualWT - x.AfterCast) : 0.00m)) / rg.Sum(x => (x.m == 12 ? x.ActualWT : 1.00m)),

						 totalLossP = rg.Sum(x => (x.ActualWT - x.AfterCast)) / rg.Sum(x => x.ActualWT)

					 }).ToList();

			if (l != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(l);
			}

			return _result;

		} // end GetYearSummaryLossCasting

		public WAXTREE GetWaxTreeInfo(int TreeId)
		{
			return _om.WAXTREES.FirstOrDefault(x => x.WAXTREEID == TreeId);

		} // end GetWaxTreeInfo

		public DataTable GetAlloyList()
		{
			DataTable _result = new DataTable();
			var al = (from a in _om.WAXTREES
					  orderby a.ALLOYTYPE
					  select new
					  {
						  a.ALLOYTYPE
					  }).Distinct();
			if (al != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(al.ToList());
			}
			return _result;

		} // end GetAlloyList

		public DataTable GetOtherMatList()
		{
			DataTable _result = new DataTable();
			var al = (from a in _om.WAXTREES
					  orderby a.OTHERMAT
					  select new
					  {
						  a.OTHERMAT
					  }).Distinct();
			if (al != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(al.ToList());
			}
			return _result;

		} // end GetOtherMatList

		public DataTable GetYearCastingWaxTree()
		{
			DataTable _result = new DataTable();
			var y = (from w in _om.WAXTREES
					 orderby w.BUILDDATE
					 where w.ISDELETE == false
					 select new
					 {
						 w.BUILDDATE
					 });

			var yy = (from s in y.ToList()
					  select new
					  {
						  FY = OMControls.OMUtils.Num2Date(s.BUILDDATE).Year
					  }).Distinct().OrderByDescending(x => x.FY);


			if (yy != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(yy.ToList());
			}
			return _result;

		} // end GetYearCastingWaxTree


		#endregion


		#region public class method

		public int UpdateWatTree(ActionMode Mode, WAXTREE source)
		{
			int _result = 0;
			using (var scope = new System.Transactions.TransactionScope())
			{
				try
				{
					switch (Mode)
					{
						case ActionMode.Add:
							_om.WAXTREES.Add(source);
							_result = _om.SaveChanges();
							break;

						case ActionMode.Edit:
							WAXTREE wax = _om.WAXTREES.FirstOrDefault(x => x.WAXTREEID == source.WAXTREEID);

							wax.ACTUALMATWEIGHT = source.ACTUALMATWEIGHT;
							wax.ACTUALTEMP = source.ACTUALTEMP;
							wax.ACTUALWAX = source.ACTUALWAX;
							wax.ALLOYTYPE = source.ALLOYTYPE;
							wax.ALLOYWEIGHT = source.ALLOYWEIGHT;
							wax.AUDITUSER = source.AUDITUSER;
							wax.BASENWAXWG = source.BASENWAXWG;
							wax.BASEWEIGHT = source.BASEWEIGHT;
							wax.BUILDDATE = source.BUILDDATE;
							wax.CASTINGBY = source.CASTINGBY;
							wax.CASTINGTEMP = source.CASTINGTEMP;
							wax.CUSTCODE = source.CUSTCODE;
							wax.CUSTID = source.CUSTID;
							wax.FURNACETEMP = source.FURNACETEMP;
							wax.GOLD100 = source.GOLD100;
							wax.ISDELETE = source.ISDELETE;
							wax.MATADDWEIGHT = source.MATADDWEIGHT;
							wax.MATCASTING = source.MATCASTING;
							wax.MATFACTOR = source.MATFACTOR;
							wax.MATWEIGHTAF = source.MATWEIGHTAF;
							wax.MATWEIGHTBF = source.MATWEIGHTBF;
							wax.MATWEIGHTLOSS = source.MATWEIGHTLOSS;
							wax.MODIDATE = source.MODIDATE;
							wax.MODIUSER = source.MODIUSER;
							wax.OTHERMAT = source.OTHERMAT;
							wax.OTHERMATWEIGHT = source.OTHERMATWEIGHT;
							wax.REMARK = source.REMARK;
							wax.RUBBERBASENO = source.RUBBERBASENO;
							wax.SILVER100 = source.SILVER100;
							wax.SILVER94 = source.SILVER94;
							wax.SILVER95 = source.SILVER95;
							wax.SLAG = source.SLAG;
							wax.WEIGHTWITHCONTAINER = source.WEIGHTWITHCONTAINER;

							_result = _om.SaveChanges();

							break;
					}

					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception(string.Format("Can't {0} record.....", Mode == ActionMode.Add ? "insert" : "update"), ex);
				}
			}

			return _result;

		} // end UpdateWatTree

		#endregion
	}
}
