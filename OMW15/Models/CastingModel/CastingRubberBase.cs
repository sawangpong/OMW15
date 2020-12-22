using System;
using System.Data;
using System.Linq;
using System.Transactions;
using OMW15.Shared;
using System.Data.Entity.Core;

namespace OMW15.Models.CastingModel
{
	public class CastingRubberBase
	{
		private readonly OLDMOONEF1 _om;

		#region constructor

		public CastingRubberBase()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		#region static class method

		public string FindBaseSize(string BaseNo)
		{
			var rb = _om.RUBBERBASEs.Single(x => x.BASENO == BaseNo && x.INACTIVE == false);
			return rb.BASESIZE;

		} // end FindBaseSize


		public DataTable GetRBSize()
		{
			var _result = new DataTable();
			var rbs = (from rb in _om.RUBBERBASEs
				where rb.INACTIVE == false
				select new
				{
					rb.BASESIZE
				}).Distinct().OrderBy(x => x.BASESIZE);
			if (rbs != null) _result = rbs.ToDataTable();
			return _result;
		} // end GetRBSize

		public DataTable GetRBList(string RBSize)
		{
			var _result = new DataTable();
			var rbs = from r in _om.RUBBERBASEs
				orderby r.BASENO
				where r.BASESIZE == RBSize
				      && r.INACTIVE == false
				select new
				{
					r.BASEID,
					r.INACTIVE,
					r.BASENO,
					r.BASESIZE,
					r.WEIGHTGRAM,
					r.REMARK
				};

			if (rbs != null) _result = rbs.ToDataTable();
			return _result;
		} // end GetRBList

		public RUBBERBASE GetRubberBaseInfo(int BaseId)
		{
			return _om.RUBBERBASEs.FirstOrDefault(x => x.BASEID == BaseId);
		} // end GetRubberBaseInfo

		public int SaveOrUpdateRubber(ActionMode Mode, RUBBERBASE Source)
		{
			var _result = 0;
				try
				{
					switch (Mode)
					{
						case ActionMode.Add:
							_om.RUBBERBASEs.Add(Source);
							_result = _om.SaveChanges();
							break;

					case ActionMode.Edit:
							var rb = _om.RUBBERBASEs.FirstOrDefault(x => x.BASEID == Source.BASEID);
							rb.INACTIVE = Source.INACTIVE;
							rb.BASESIZE = Source.BASESIZE;
							rb.REMARK = Source.REMARK;
							rb.WEIGHTGRAM = Source.WEIGHTGRAM;

							_result = _om.SaveChanges();
							break;
					}
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception(
						string.Format("{0}",
							Mode == ActionMode.Add ? "Insert new Rubber failed..." : "Update Rubber Information failed..."), ex);
				}
		
			return _result;
		} // end SaveOrUpdateRubber

		#endregion
	}
}