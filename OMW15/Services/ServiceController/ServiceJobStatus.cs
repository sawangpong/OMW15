using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.Services.ServiceController
{
	public static class ServiceJobStatus
	{
		#region STATIC Class Method
		
		public static DataTable GetJobStatusList()
		{
			List<Tools.ToolController.ContractStatus> _status = new List<Tools.ToolController.ContractStatus>();
			
			_status .Add(new Tools.ToolController.ContractStatus(){Value = 0,Key = "Complete"});
			_status.Add(new Tools.ToolController.ContractStatus(){Value = 1, Key="Active"});

			return OMControls.OMDataUtils.ToDataTable(_status);

		} // end GetJobStatusList

		public static string GetOrderType(string OrderTypeCode)
		{
			string _result = string.Empty;
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _ot = (from ot in _srv.ORDERTYPEs.AsParallel()
						   where ot.ordertypecode == OrderTypeCode
						  select new
						  {
							  ot.ordertypename
						  }).FirstOrDefault();
				_result = _ot.ordertypename;
			}

			return _result;
		} // end GetOrderType

		#endregion

	}
}
