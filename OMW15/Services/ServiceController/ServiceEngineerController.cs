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

namespace OMW15.Services.ServiceController
{
	public enum EngineerStatusEnum
	{
		Working = 0,
		Resign =1
	}

	public enum EngineerViewState
	{
		Normal,
		Select
	}

	public class ServiceEngineerController
	{

		public DataTable GetSeviceEngineerList()
		{
			DataTable _result = new DataTable();
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var engs = (from eng in _srv.ENGINEERs
						   orderby eng.curr
						   select new
						   {
							   eng.engiseq,
							   eng.id,
							   engineer = eng.name + " " + eng.lastname,
							   status = eng.curr
						   }).ToList();

				if (engs.Count > 0)
				{
					_result = OMControls.OMDataUtils.ToDataTable(engs);
				}
			}

			return _result;

		} // end GetSeviceEngineerList


		public static ENGINEER GetEngineer(int EngineerSEQ)
		{
			using (SERVICEEF _srv = new SERVICEEF())
			{
				return _srv.ENGINEERs.FirstOrDefault(x => x.engiseq == EngineerSEQ);
			}

		} // end GetEngineer

		//public static DataTable GetEngineerStatus()
		//{
		//	//return OMControls.OMDataUtils.ToDataTable((IEnumerator)EngineerStatusEnum)
		//}


		public static int UpdateEngineerInfo(ActionMode Mode,ENGINEER source)
		{
			int _result = 0;
			using (var _scope = new TransactionScope())
			{
				SERVICEEF _srv = new SERVICEEF();
				try
				{
					switch (Mode)
					{
						case ActionMode.Add:
							_srv.ENGINEERs.Add(source);
							_result = _srv.SaveChanges();
							break;
						case ActionMode.Edit:
							var _eng = _srv.ENGINEERs.SingleOrDefault(x => x.engiseq == source.engiseq);

							_eng.curr = source.curr;
							_eng.empcode = source.empcode;
							_eng.Status = source.Status;
							_eng.name = source.name;
							_eng.lastname = source.lastname;
							_eng.resigndate = source.resigndate;

							_result = _srv.SaveChanges();

							break;

					}

					_scope.Complete();
				}
				catch( OptimisticConcurrencyException ex)
				{
					_result = 0;
					throw new Exception("Can't update Engineer record....", ex);
				}

			}

			return _result;
		} // end UpdateEngineerInfo
	}
}
