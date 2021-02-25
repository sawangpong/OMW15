using System;
using System.Data;
using System.Data.SqlClient;


namespace OMW15.Models.ToolModel
{
	public class DataConnect
	{
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

		public DataConnect(string selectCommand, string connectionString)
		{
			using (SqlCommand cmd = new SqlCommand(selectCommand, new SqlConnection(connectionString)))
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
			}//end command
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
