using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMW15.Shared;

namespace OMW15.Models.CastingModel
{
	public class CastingWorkerDAL
	{

		private int[] _empActiveGroup = new int[] { 1, 6, 7, 8 };
		private readonly OLDMOONEF1 _om;

		public CastingWorkerDAL()
		{
			_om = new OLDMOONEF1();

			//_empStatus = status;

		}

		private DataTable getCastingWorkerDataById()
		{
			return _om.EMPLOYEEs.Where(d => d.DEPARTMENTID == 102 || d.DEPARTMENTID == 110).Select(x => new
			{
				Id = x.EMPSEQ,
				Name = x.EMPFIRSTNAME.Trim() + " " + x.EMPLASTNAME.Trim()
			}).OrderBy(o => o.Name).ToDataTable();

		} // end GetWorkerDataById


		private DataTable getCastingWorkerDataById(int status)
		{
			return _om.EMPLOYEEs.Where(d => (d.DEPARTMENTID == 102 || d.DEPARTMENTID == 110 ) 
					&& _empActiveGroup.Contains(d.STATUS)).Select(x => new
			{
				Id = x.EMPSEQ,
				Name = x.EMPFIRSTNAME.Trim() + " " + x.EMPLASTNAME.Trim()
			}).OrderBy(o => o.Name).ToDataTable();

		} // end GetWorkerDataById


		public DataTable getWorkerList(EmployeeStatus status)
		{
			DataTable dtWorkers = new DataTable();
			switch (status)
			{
				case EmployeeStatus.All:
					dtWorkers = getCastingWorkerDataById();
					break;

				case EmployeeStatus.Active:
					dtWorkers = getCastingWorkerDataById((int)status);
					break;
			}

			return dtWorkers;
		}


	}
}
