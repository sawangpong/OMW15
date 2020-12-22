using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMControls;

namespace OMW15.Services.ServiceController
{
	public static class MachineRecordController
	{
		
		public static DataTable GetMachineByCustomer(string CustomerCode) 
		{
			DataTable _result = new DataTable();

			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _m = (from m in _srv.MIXes.AsParallel()
						  orderby m.type
						  where m.isdelete == false
						  && m.acccustcode == CustomerCode
						  select new
						  {
							  KEY = m.type,
							  VALUE = m.productid 
						  }).Distinct();

				_result = OMControls.OMDataUtils.ToDataTable(_m.ToList());
			}

			return _result;

		} // end GetMachineByCustomer


		public static DataTable GetMachineSerialNoByModel(string CustomerCode,string Model)
		{
			DataTable _result = new DataTable();

			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _m = (from m in _srv.MIXes.AsParallel()
						  orderby m.type
						  where m.isdelete == false
						  && m.acccustcode == CustomerCode
						  && m.type == Model
						  select new
						  {
							  VALUE = m.s_no,
							  KEY = m.s_no
						  }).Distinct();

				_result = OMControls.OMDataUtils.ToDataTable(_m.ToList());
			}

			return _result;

		} // end GetMachineByCustomer

	}
}
