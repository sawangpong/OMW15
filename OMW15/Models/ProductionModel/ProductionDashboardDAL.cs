using OMW15.Models.ToolModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.Models.ProductionModel
{
	public class ProductionDashboardDAL
	{
		#region constructor
		private readonly OLDMOONEF1 _om;
		public ProductionDashboardDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		#region Class MethodHelper

		public DataTable GetProductionJobInfoDataChanged() 
			=> new DataConnect($" EXEC dbo.usp_OM_PRODUCTION_SUMMARY_DEMAND_BY_MCGROUP ", omglobal.SysConnectionString).ToDataTable;


		#endregion


	}
}
