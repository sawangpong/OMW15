using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace OMW15
{
	public static class omdal
	{
		#region Class Field Member
		private static string connectionString = string.Empty;
		private static string selectCommand = string.Empty;
		private static DataTable dt;

		#endregion //end Class Field Member

		//#region Class Property
		//public static string ConnectionString
		//{
		//	get
		//	{
		//		return connectionString;
		//	}
		//	set
		//	{
		//		connectionString = value;
		//	}
		//}


		//public static string SelectCommand
		//{
		//	get
		//	{
		//		return selectCommand;
		//	}
		//	set
		//	{
		//		selectCommand = value;
		//	}
		//}

		//#endregion //end Class Property

		#region Class Constructor

		#endregion // end Construture

		#region Class Method

		#region Generic static method for <T> as enumerator

		//public static DataTable ToDataTable<T>(this T[] source)
		//{
		//	if (source == null || source.Length == 0)
		//	{
		//		return null;
		//	}
		//	else
		//	{
		//		DataTable _dt = new DataTable();
		//		var _source = source[0];
		//		_dt.Columns.AddRange(_source.GetType().GetFields().Select(field => new DataColumn(field.Name, field.FieldType)).ToArray());
		//		int _fieldCount = _source.GetType().GetFields().Count();
		//		source.All(s =>
		//		{
		//			_dt.Rows.Add(Enumerable.Range(0, _fieldCount).Select(index => s.GetType().GetFields()[index].GetValue(s)).ToArray());
		//			return true;
		//		});
		//		return _dt;
		//	}
		//} // end ToDataTable

		//public static IEnumerable<KeyValuePair<int, string>> GetValueList<T>() where T : struct
		//{
		//	if (!typeof(T).IsEnum)
		//	{
		//		throw new ArgumentException("Method parameter accept only enums values");
		//	}

		//	return (Enum.GetValues(typeof(T)).Cast<T>().Select(id => new KeyValuePair<int, string>(Convert.ToInt32(id), id.ToString()))).ToList();

		//} // end GetValueList<T> -- enum parameter

		//public static IEnumerable<object> ToList(DataTable dt)
		//{
		//	var data = dt.AsEnumerable().Select(row =>
		//				new
		//				{
		//					Key = (int)row["Key"],
		//					Value = (string)row["Value"]
		//				});

		//	return data.ToList();
		//} // end ToList

		//public static DataTable ToDataTable<T>(IEnumerable<T> Items)
		//{
		//	var tb = new DataTable(typeof(T).Name);
		//	PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
		//	foreach (var prop in props)
		//	{
		//		Type propType = prop.PropertyType;
		//		if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable)))
		//		{
		//			propType = new NullableConverter(propType).UnderlyingType;
		//		}
		//		tb.Columns.Add(prop.Name, propType);
		//	}

		//	foreach (var item in Items)
		//	{
		//		var values = new object[props.Length];
		//		for (int i = 0; i < props.Length; i++)
		//		{
		//			values[i] = props[i].GetValue(item, null);
		//		}
		//		tb.Rows.Add(values);
		//	}

		//	return tb;

		//} // end ToDataTable

		// extense method for LINQ with Rollup
		//		public static List<TElement> WithRollup<TElement, TKey>(this IEnumerable<TElement> elements,
		//	Func<TElement, TKey> primaryKeyOfElement,
		//	Func<IGrouping<TKey, TElement>, TElement> calculateSubTotalElement,
		//	TElement grandTotalElement)
		//		{
		//			// Create a new list the items, subtotals, and the grand total.
		//			List<TElement> results = new List<TElement>();
		//			var lookup = elements.ToLookup(primaryKeyOfElement);
		//			foreach(var group in lookup)
		//			{
		//				// Add items in the current group
		//				results.AddRange(group);
		//				// Add subTotal for current group
		//				results.Add(calculateSubTotalElement(group));
		//			}
		//			// Add grand total
		//			results.Add(grandTotalElement);

		//			return results;

		//		} // end WithRollup


		//		public static List<TElement> WithRollup<TElement, TKey>(this IEnumerable<TElement> elements,
		//Func<TElement, TKey> primaryKeyOfElement,
		//Func<IGrouping<TKey, TElement>, TElement> calculateSubTotalElement,
		//TElement grandTotalElement)
		//		{
		//			// Create a new list the items, subtotals, and the grand total.
		//			List<TElement> results = new List<TElement>();
		//			var lookup = elements.ToLookup(primaryKeyOfElement);
		//			foreach(var group in lookup)
		//			{
		//				// Add items in the current group
		//				results.AddRange(group);
		//				// Add subTotal for current group
		//				results.Add(calculateSubTotalElement(group));
		//			}
		//			// Add grand total
		//			results.Add(grandTotalElement);

		//			return results;

		//		} // end WithRollup

		#endregion

		//#region Classic ADO.NET
		//public static DataTable GetRecords(string ConnectionString, String SelectCommand)
		//{
		//	using (SqlCommand cmd = new SqlCommand(SelectCommand, new SqlConnection(ConnectionString)))
		//	{
		//		dt = new DataTable();
		//		cmd.Connection.Open();
		//		try
		//		{
		//			SqlDataReader rd = cmd.ExecuteReader();
		//			dt.Load(rd, LoadOption.OverwriteChanges);
		//		}
		//		catch (SqlException ex)
		//		{
		//			dt = null;
		//			throw new Exception("Error : Get record failed...", ex);
		//		}
		//	} // end command
		//	return dt;

		//} // end GetRerords       

		//public static DataTable GetRecords(string ConnectionString, String SelectCommand, string ParentCall)
		//{
		//	using (SqlCommand cmd = new SqlCommand(SelectCommand, new SqlConnection(ConnectionString)))
		//	{
		//		dt = new DataTable();
		//		cmd.Connection.Open();
		//		try
		//		{
		//			SqlDataReader rd = cmd.ExecuteReader();
		//			dt.Load(rd, LoadOption.OverwriteChanges);
		//		}
		//		catch (SqlException ex)
		//		{
		//			dt = null;
		//			throw new Exception(string.Format("Error : {0}\\n from module : {1}", "Get record failed...", ParentCall, ex));
		//		}
		//	} // end command
		//	return dt;

		//} // end GetRerords       

		//public static SqlConnection GetConnection(string ConnectionString)
		//{
		//	try
		//	{
		//		SqlConnection con = new SqlConnection(ConnectionString);
		//		return con;
		//	}
		//	catch
		//	{
		//		return null;
		//	}
		//} // end GetConnection

		//#endregion

		#endregion //end Class Method

	}
}
