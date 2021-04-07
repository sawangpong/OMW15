using System;
using System.Data;
using System.Data.SqlClient;


namespace OMW15.Models.ToolModel
{
	public class DataConnect
	{
		private string _connectionString = string.Empty;
		private DataTable _dbTable;

		public DataTable ToDataTable
		{
			get
			{
				return _dbTable;
			}
			private set
			{
				_dbTable = value;
			}
		}

		public DataConnect(string connectionString = "")
		{
			if (String.IsNullOrEmpty(connectionString))
			{
				_connectionString = omglobal.SysConnectionString;
			}
			else
			{
				_connectionString = connectionString;
			}
		}

		public DataConnect(string selectCommand, string connectionString = "")
		{
			if (String.IsNullOrEmpty(connectionString))
			{
				_connectionString = omglobal.SysConnectionString;
			}
			else
			{
				_connectionString = connectionString;
			}

			using (SqlCommand cmd = new SqlCommand(selectCommand, new SqlConnection(_connectionString)))
			{
				cmd.Connection.Open();
				cmd.CommandType = CommandType.Text;
				try
				{
					SqlDataReader rd = cmd.ExecuteReader();
					_dbTable = new DataTable();
					_dbTable.Load(rd, LoadOption.OverwriteChanges);


					cmd.Connection.Close();

				}
				catch (SqlException ex)
				{
					_dbTable = null;
					throw new Exception($"{selectCommand} \n\n {ex.ToString()}");
				}
			} //end command
		}

		public DataTable GetDataTable(string selectCommand, string connectionString = "")
		{
			DataTable _dt = new DataTable();
			if (String.IsNullOrEmpty(connectionString))
			{
				_connectionString = omglobal.SysConnectionString;
			}
			else
			{
				_connectionString = connectionString;
			}

			using (SqlCommand cmd = new SqlCommand(selectCommand, new SqlConnection(_connectionString)))
			{
				cmd.Connection.Open();
				cmd.CommandType = CommandType.Text;
				try
				{
					SqlDataReader rd = cmd.ExecuteReader();
					_dt.Load(rd, LoadOption.OverwriteChanges);
				}
				catch (SqlException)
				{
					_dt = null;
				}
			} //end command
			return _dt;
		}

		public static int ExcuteSP(string commandString, string connectionString)
		{
			int _result = 0;
			using (SqlCommand cmd = new SqlCommand(commandString, new SqlConnection(connectionString)))
			{
				cmd.Connection.Open();
				cmd.CommandType = CommandType.StoredProcedure;
				try
				{
					_result = cmd.ExecuteNonQuery();
				}
				catch
				{
					_result = 0;
				}
			}
			return _result;
		}
	}
}
