using OMW15.Model.Extend;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15
{
	public partial class OLDMOONEF1 : DbContext
	{
		#region DataSet

		public virtual DbSet<ValidProductionTime> ValidTimeRecord { get; set; }

		#endregion

		#region Methods

		//public IQueryable<ValidProductionTime> sp_validTimeRecord() => ValidTimeRecord.FromSqlInterpolated($"EXEC dbo.usp_ValidTimeRecord");

		#endregion


	}
}
