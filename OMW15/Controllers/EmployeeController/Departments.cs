using System.Data;
using System.Linq;

namespace OMW15.Controllers.EmployeeController
{
	public class Departments
	{
		private readonly ERP _erp;

		#region Constructor and Destructor

		public Departments()
		{
			_erp = new ERP();
		}

		#endregion

		public DataTable GetDepartmentCode()
		{
			var _result = new DataTable();
			var dept = (from _dept in _erp.DEPTTABs
				select new
				{
					_dept.DEPT_KEY,
					_dept.DEPT_CODE,
					Name = _dept.DEPT_CODE.Trim() + "-" + _dept.DEPT_THAIDESC.Trim()
				}).AsParallel();

			if (dept.Count() > 0) _result = dept.ToDataTable();
			return _result;
		} // end GetDepartmentCode
	}
}