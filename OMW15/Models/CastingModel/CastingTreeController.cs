using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using OMW15.Shared;

namespace OMW15.Models.CastingModel
{
	public class CastingTreeController
	{
		private readonly OLDMOONEF1 _om;

		#region constructor and destructor

		public CastingTreeController()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		#region public class method

		public int UpdateWatTree(ActionMode Mode, WAXTREE source)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
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
							var wax = _om.WAXTREES.Single(x => x.WAXTREEID == source.WAXTREEID);

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

		#region  class method

		public DataTable GetAsyncCastingTrees(DateTime CurrentDate)
		{
			var _currentDate = CurrentDate.Date2Num();
			var _result = new DataTable();
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
					  }).AsParallel();

			var t = ct.AsEnumerable().Select((x, Index) => new
			{
				RowNo = Index + 1,
				TreeId = x.WAXTREEID,
				BuildWaxDate = x.BUILDDATE.Num2Date(),
				MatId = x.MATCASTING,
				MatName = x.THKEYNAME,
				x.MATFACTOR,
				x.RUBBERBASENO,
				RubberBaseWeight = x.BASEWEIGHT,
				RBaseWithWax = x.BASENWAXWG,
				NetWaxWeight = x.waxweight,
				WeightNeed = x.waxweight * x.MATFACTOR,
				WeightAdd = x.MATADDWEIGHT,
				TotalWeight = x.MATADDWEIGHT + x.waxweight * x.MATFACTOR,
				WeightBeforeCast = x.MATWEIGHTBF,
				ActualWeight = x.ACTUALMATWEIGHT,
				GoldWeight = x.G100,
				SV100Weight = x.S100,
				SV95Weight = x.S95,
				SV94Weight = x.S94,
				OtherMat = x.MAT,
				OtherMatWeight = x.MATWEIGHT,
				AlloyName = x.ALLOYTYPE,
				AlloyWeight = x.ALLOYWEIGHT,
				WeightAfterCast = x.MATWEIGHTAF,
				LossWeight = x.MATWEIGHTLOSS,
				RealLoss = x.ACTUALMATWEIGHT > 0.00m ? (x.MATWEIGHTLOSS > 0.00m ? x.MATWEIGHTLOSS : 0) / x.ACTUALMATWEIGHT : 0,
				Loss =
				string.Format("{0:P2}",
					x.ACTUALMATWEIGHT > 0 ? (x.MATWEIGHTLOSS > 0.00m ? x.MATWEIGHTLOSS : 0) / x.ACTUALMATWEIGHT : 0)
			}).AsParallel();

			if (t != null)
				_result = t.ToDataTable();


			return _result;


		} // end GetAsyncCastingTrees

		public DataTable GetAsyncDailySummaryCastingInfo(DateTime SelectedDate)
		{
			var _currentDate = SelectedDate.Date2Num();
			var _result = new DataTable();
			var dc = (from wt in _om.WAXTREES
					  join sd in _om.SYSDATAs on wt.MATCASTING.ToString() equals sd.KEYVALUE
					  orderby sd.CATEGORY, wt.MATCASTING
					  where wt.ISDELETE == false
							&& sd.GROUPTITLE == "MATERIAL"
							&& wt.BUILDDATE == _currentDate
					  group wt by new
					  {
						  sd.THKEYNAME
					  }
				into qt
					  select new
					  {
						  Material = qt.Key.THKEYNAME,
						  QFlask = qt.Count(),
						  Gold = qt.Sum(x => x.GOLD100.Value),
						  SV100 = qt.Sum(x => x.SILVER100),
						  SV95 = qt.Sum(x => x.SILVER95),
						  SV94 = qt.Sum(x => x.SILVER94),
						  Alloy = qt.FirstOrDefault().ALLOYTYPE,
						  TotalAlloy = qt.Sum(x => x.ALLOYWEIGHT),
						  OtherMaterial = qt.FirstOrDefault().OTHERMAT,
						  TotalOtherMat = qt.Sum(x => x.OTHERMATWEIGHT),
						  TotalWeightBF = qt.Sum(x => x.MATWEIGHTBF),
						  TotalActualWeight = qt.Sum(x => x.ACTUALMATWEIGHT),
						  TotalWeightAF = qt.Sum(x => x.MATWEIGHTAF),
						  Slag = qt.Sum(x => x.SLAG),
						  WTLoss = qt.Sum(x => x.ACTUALMATWEIGHT) - qt.Sum(x => x.MATWEIGHTAF) + qt.Sum(x => x.SLAG),
						  Loss =
						  (qt.Sum(x => x.ACTUALMATWEIGHT) - qt.Sum(x => x.MATWEIGHTAF) + qt.Sum(x => x.SLAG)) /
						  qt.Sum(x => x.ACTUALMATWEIGHT > 0.00m ? x.ACTUALMATWEIGHT : 1.00m)
					  }).AsParallel();

			if (dc != null)
				_result = dc.ToDataTable();
			return _result;

		} // end GetAsyncDailySummaryCastingInfo

		public async Task<DataTable> GetAsyncYearSummaryLossCasting(int FiscYear)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var _yearText = FiscYear.ToString();
				var dc = (from wt in _om.WAXTREES
						  join sd in _om.SYSDATAs on wt.MATCASTING.ToString() equals sd.KEYVALUE
						  where wt.ISDELETE == false
								&& sd.GROUPTITLE == "MATERIAL"
								&& wt.ACTUALMATWEIGHT > 0.00m
								&& wt.ACTUALMATWEIGHT - wt.MATWEIGHTAF - wt.SLAG > 0.00m
								&& wt.BUILDDATE.ToString().Substring(0, 4) == _yearText
						  select new
						  {
							  Group = sd.CATEGORY,
							  CastDT = wt.BUILDDATE,
							  ActualWT = wt.ACTUALMATWEIGHT,
							  weightAF = wt.MATWEIGHTAF + wt.SLAG,
							  loss = wt.ACTUALMATWEIGHT - wt.MATWEIGHTAF - wt.SLAG
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


				var l = from e in r
						group e by e.Group
					into rg
						select new
						{
							Group = rg.Key,
							Jan = rg.Sum(x => x.m == 1 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 1 ? x.ActualWT : 1.00m),
							Feb = rg.Sum(x => x.m == 2 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 2 ? x.ActualWT : 1.00m),
							Mar = rg.Sum(x => x.m == 3 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 3 ? x.ActualWT : 1.00m),
							Apr = rg.Sum(x => x.m == 4 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 4 ? x.ActualWT : 1.00m),
							May = rg.Sum(x => x.m == 5 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 5 ? x.ActualWT : 1.00m),
							Jun = rg.Sum(x => x.m == 6 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 6 ? x.ActualWT : 1.00m),
							Jul = rg.Sum(x => x.m == 7 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 7 ? x.ActualWT : 1.00m),
							Aug = rg.Sum(x => x.m == 8 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 8 ? x.ActualWT : 1.00m),
							Sep = rg.Sum(x => x.m == 9 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 9 ? x.ActualWT : 1.00m),
							Oct = rg.Sum(x => x.m == 10 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 10 ? x.ActualWT : 1.00m),
							Nov = rg.Sum(x => x.m == 11 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 11 ? x.ActualWT : 1.00m),
							Dec = rg.Sum(x => x.m == 12 ? x.ActualWT - x.AfterCast : 0.00m) / rg.Sum(x => x.m == 12 ? x.ActualWT : 1.00m),
							totalLossP = rg.Sum(x => x.ActualWT - x.AfterCast) / rg.Sum(x => x.ActualWT)
						};

				if (l != null)
					_result = l.ToDataTable();

				return _result;
			});
		} // end GetAsyncYearSummaryLossCasting

		public WAXTREE GetWaxTreeInfo(int TreeId)
		{
			return _om.WAXTREES.Single(x => x.WAXTREEID == TreeId);

		} // end GetWaxTreeInfo

		public DataTable GetAlloyList()
		{
			return _om.WAXTREES.Select(x => new
			{
				x.ALLOYTYPE
			}).Distinct().OrderBy(o => o.ALLOYTYPE).AsParallel().ToDataTable();

		} // end GetAlloyList

		public DataTable GetOtherMatList()
		{
			return _om.WAXTREES.Select(x => new
			{
				x.OTHERMAT
			}).Distinct().OrderBy(o => o.OTHERMAT).AsParallel().ToDataTable();
			
		} // end GetOtherMatList

		public DataTable GetYearCastingWaxTree()
		{
			return _om.WAXTREES.AsEnumerable().Where(x => x.ISDELETE == false).Select(x => new
			{
				FY = x.BUILDDATE.Num2Date().Year
			}).Distinct().OrderByDescending(o => o.FY).ToDataTable();
			
		} // end GetYearCastingWaxTree

		#endregion
	}
}