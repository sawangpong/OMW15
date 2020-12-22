using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OMW15.Controllers.ToolController
{
	public static class DataTableTools
	{
		public static async Task<DataTable> AsyncAddRollup(DataTable Source)
		{
			return await Task.Run(() =>
			{
				var _t = Source.Copy();
				var _dr = _t.NewRow();
				foreach (DataColumn dc in Source.Columns)
				{
					if (dc.DataType == typeof(decimal))
					{
						_dr[dc.ColumnName] = Source.AsEnumerable().Sum(x => x.Field<decimal>(dc.ColumnName));
					}
					else if (dc.DataType == typeof(Int32))
					{
						_dr[dc.ColumnName] = Source.AsEnumerable().Sum(x => x.Field<Int32>(dc.ColumnName));
					}
					else if (dc.DataType == typeof(string))
					{
						if (dc.Ordinal == 0)
						{
							_dr[dc.Ordinal] = "TOTAL";
						}
					}
				}
				_t.Rows.Add(_dr);
				return _t;
			});
		} // end AsyncAddRollup


		public static DataTable GetGeneralYearList()
		{
			var dtYear = new DataTable();
			dtYear.Columns.Add(new DataColumn("Y", typeof(int)));

			var _y = DateTime.Today.Year;
			var dr = dtYear.NewRow();

			for (var i = 0; i <= 10; i++)
			{
				if (_y > 2010)
				{
					dr = dtYear.NewRow();
					dr["Y"] = _y;
					dtYear.Rows.Add(dr);
					--_y;
				}
				else
				{
					break;
				}
			}

			return dtYear;
		} // end GetGeneralYearList

	} // end DataTableTools
}