using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15
{
	public class DatabaseServerList
	{
		private DataTable CreateDatabaseServerListTable()
		{
			DataTable dt = new DataTable();
			DataColumn dc = new DataColumn("ServerName", typeof(System.String));
			dt.Columns.Add(dc);
			return dt;

		} // end CreateDatabaseServerListTable

		public DataTable GetServerItems()
		{
			DataTable _dtServerList = this.CreateDatabaseServerListTable();
			using (DataTable dt = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources())
			{
				// debug the instance count
				//System.Windows.Forms.MessageBox.Show(dt.Rows.Count.ToString());
				// end debug

				foreach (DataRow dr in dt.Rows)
				{
					try
					{
						DataRow _dr = _dtServerList.NewRow();
						if (string.IsNullOrEmpty(dr["InstanceName"].ToString()))
						{
							_dr["ServerName"] = string.Format("{0}", dr["ServerName"]);
						}
						else
						{
							_dr["ServerName"] = string.Format("{0}\\{1}", dr["ServerName"], dr["InstanceName"]);
						}
						_dtServerList.Rows.Add(_dr);

					}
					catch (Exception ex)
					{
						throw new Exception("Error loading Database server!!!", ex);
					}
				}
			}

			return _dtServerList;

		} // GetServerItems

	}
}
