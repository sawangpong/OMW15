using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Master.MasterController
{
	public class Departments 
	{
		private ERP _erp;

		#region Constructor and Destructor
		public Departments()
		{
			_erp = new ERP();
		}
		//protected virtual void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		// dispose managed resources
		//		_erp.Dispose();
		//	}
		//	// free native resources
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}

		#endregion

		public DataTable GetDepartmentCode()
		{
			DataTable _result = new DataTable();
				var dept = (from _dept in _erp.DEPTTABs
							select new
							{
								_dept.DEPT_KEY,
								_dept.DEPT_CODE,
								Name = _dept.DEPT_CODE.Trim() + "-" + _dept.DEPT_THAIDESC.Trim()
							}).ToList();

				if (dept.Count > 0)
				{
					_result = OMControls.OMDataUtils.ToDataTable(dept);
				}
			return _result;

		} // end GetDepartmentCode
	}
}
