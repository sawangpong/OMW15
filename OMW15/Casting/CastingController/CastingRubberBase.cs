using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;


namespace OMW15.Casting.CastingController
{
	public class CastingRubberBase
	{
		#region static class method
		public static string FindBaseSize(string BaseNo)
		{
			using(OLDMOONEF om = new OLDMOONEF())
			{
				var rb = om.RUBBERBASEs.FirstOrDefault(x => x.BASENO == BaseNo);
				return rb.BASESIZE;
			}
		} // end FindBaseSize


		public static DataTable GetRBSize()
		{
			DataTable _result = new DataTable();
			using (OLDMOONEF _om = new OLDMOONEF())
			{
				var rbs = (from rb in _om.RUBBERBASEs
						   where rb.INACTIVE == false
						   select new
						   {
							   rb.BASESIZE,
						   }).Distinct().OrderBy(x => x.BASESIZE);
				if (rbs != null)
				{
					_result = OMControls.OMDataUtils.ToDataTable(rbs.ToList());
				}
			}
			return _result;
		
		} // end GetRBSize

		public static DataTable GetRBList(string RBSize)
		{
			DataTable _result = new DataTable();
			using (OLDMOONEF _om = new OLDMOONEF())
			{
				var rbs = (from r in _om.RUBBERBASEs
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
						  }).ToList();

				if (rbs != null)
				{
					_result = OMControls.OMDataUtils.ToDataTable(rbs);
				}
			}
			return _result;
		
		} // end GetRBList

		public static RUBBERBASE GetRubberBaseInfo(int BaseId)
		{
			using (OLDMOONEF _om = new OLDMOONEF())
			{
				return _om.RUBBERBASEs.FirstOrDefault(x => x.BASEID == BaseId);
			}
		} // end GetRubberBaseInfo

		public static int SaveOrUpdateRubber(ActionMode Mode, RUBBERBASE Source)
		{
			int _result = 0;
			using (var scope = new System.Transactions.TransactionScope())
			{
				OLDMOONEF _om = new OLDMOONEF();

				try
				{
					switch (Mode)
					{
						case ActionMode.Add:
							_om.RUBBERBASEs.Add(Source);
							_result = _om.SaveChanges();

							break;
						case ActionMode.Edit:
							RUBBERBASE rb = _om.RUBBERBASEs.FirstOrDefault(x => x.BASEID == Source.BASEID);
							rb.INACTIVE = Source.INACTIVE;
							rb.BASESIZE = Source.BASESIZE;
							rb.REMARK = Source.REMARK;
							rb.WEIGHTGRAM= Source.WEIGHTGRAM;

							_result = _om.SaveChanges();
							break;
					}

					scope.Complete();
				}
				catch(OptimisticConcurrencyException ex)
				{
					throw new Exception(string.Format("{0}",Mode == ActionMode.Add ? "Insert new Rubber failed..." : "Update Rubber Information failed..."), ex);
				}
			}

			return _result;
		} // end SaveOrUpdateRubber

		#endregion
	}
}
