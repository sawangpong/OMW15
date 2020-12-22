using System;
using System.Data;
using System.Data.Sql;

namespace OMW15.Models.ToolModel
{
	public class DatabaseServerList
	{
		private DataTable CreateDatabaseServerListTable()
		{
			var dt = new DataTable();
			dt.Columns.Add(new DataColumn("ServerName", typeof(string)));
			return dt;
		} // end CreateDatabaseServerListTable

		public DataTable GetServerItems()
		{
			var _dtServerList = CreateDatabaseServerListTable();
			using (var dt = SqlDataSourceEnumerator.Instance.GetDataSources())
			{
				foreach (DataRow dr in dt.Rows)
					try
					{
						var _dr = _dtServerList.NewRow();
						if (string.IsNullOrEmpty(dr["InstanceName"].ToString()))
							_dr["ServerName"] = $"{dr["ServerName"].ToString()}";
						else _dr["ServerName"] = $"{dr["ServerName"].ToString()}\\{dr["InstanceName"].ToString()}";
						_dtServerList.Rows.Add(_dr);
					}
					catch (Exception ex)
					{
						throw new Exception("Error loading Database server!!!", ex);
					}
			}

			return _dtServerList;
		} // GetServerItems
	}
}