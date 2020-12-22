using Microsoft.VisualBasic;
using OMW15.Shared;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OMW15.Models.CastingModel
{
	public class ReturnMaterialDAL
	{
		private readonly OLDMOONEF1 _om;

		//CONSTRUCTOR
		public ReturnMaterialDAL()
		{
			_om = new OLDMOONEF1();
		}

		public async Task<DataTable> GetAsyncIssueMaterial(string MaterialCategory)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var cat = (from cl in _om.SYSDATAs
						   orderby cl.ENKEYNAME
						   where cl.CATEGORY == MaterialCategory
						   select new
						   {
							   cl.KEYVALUE,
							   cl.THKEYNAME
						   }).Distinct().AsParallel();

				var mat = (from so in _om.SALEORDERS.AsEnumerable()
						   join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
						   join mtype in cat.ToList() on so.DELIVERMAT.ToString() equals mtype.KEYVALUE
						   where so.ISDELETE == false
								 && so.ISCANCEL == false
						   group so by new
						   {
							   so.CUSTCODE,
							   c.CUSTNAME,
							   IssueDate = so.ACTUALDELIVERDT.Num2Date().ToShortDateString(),
							   mtype.THKEYNAME
						   }
					into issue
						   select new
						   {
							   issue.Key.CUSTCODE,
							   Customer = issue.Key.CUSTNAME,
							   issue.Key.IssueDate,
							   Material = issue.Key.THKEYNAME,
							   Total = issue.Sum(x => x.DELIVERWEIGHT)
						   }).OrderBy(o => o.IssueDate).AsParallel();

				// convert result set to datatable
				var m = mat.ToDataTable();

				// create dummy datatable and copy structure and detail
				var _t = m.Copy();

				// remove the un-used columns
				_t.Columns.Remove("Material");
				_t.Columns.Remove("Total");

				// create string array for new Column
				var pkCol = _t.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
				_result = _t.DefaultView.ToTable(true, pkCol).Copy();
				_result.PrimaryKey = _result.Columns.Cast<DataColumn>().ToArray();

				// add last column into result table
				_result.Columns.Add("Total", typeof(decimal));

				m.AsEnumerable()
					.Select(r => r["Material"].ToString())
					.Distinct()
					.ToList()
					.ForEach(c => _result.Columns.Add(c, typeof(decimal)));


				// load data from master table (m) into result table
				// and add zero (0.00) into field that no data
				//
				foreach (DataRow dr in m.Rows)
				{
					var _totalWeight = 0.00m;
					var _row = _result.Rows.Find(pkCol.Select(x => dr[x]).ToArray());
					_row[dr["Material"].ToString()] = dr["Total"];

					foreach (DataColumn dc in _result.Columns)
					{
						if (dc.DataType == typeof(decimal) && dc.ColumnName != "Total")
						{
							if (Convert.IsDBNull(_row[dc.ColumnName]) == false)
							{
								_totalWeight += Convert.ToDecimal(_row[dc.ColumnName]);
							}
							else
							{
								_row[dc.ColumnName] = 0.00m;
							}
						}
					}
					_row["Total"] = _totalWeight;
				}

				// add summary row
				var _sumRow = _result.NewRow();
				foreach (DataColumn dc in _result.Columns)
				{
					var _sumWeight = 0.00m;
					if (dc.ColumnName == "CUSTCODE" || dc.ColumnName == "Customer" || dc.ColumnName == "IssueDate")
					{
						if (dc.ColumnName == "CUSTCODE")
						{
							_sumRow[dc.ColumnName] = "";
						}
						else
						{
							_sumRow[dc.ColumnName] = "Total Weight";
						}
					}
					else
					{
						foreach (DataRow dr in _result.Rows)
						{
							_sumWeight += Convert.ToDecimal(dr[dc.ColumnName]);
						}
						_sumRow[dc.ColumnName] = _sumWeight;
					}
				}

				_result.Rows.Add(_sumRow);
				_result.DefaultView.Sort = "IssueDate ASC, Total";

				return _result;
			});
		} // end GetAsyncIssueMaterial


		public async Task<DataTable> GetAsyncIssueMaterialByCustomer(string CustomerCode, string MaterialCategory,
			int IssueYear, int IssueMonth)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var cat = (from cl in _om.SYSDATAs
						   orderby cl.ENKEYNAME
						   where cl.CATEGORY == MaterialCategory
						   select new
						   {
							   cl.KEYVALUE,
							   cl.THKEYNAME
						   }).Distinct().AsParallel();

				var mat = (from so in _om.SALEORDERS.AsEnumerable()
						   join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
						   join mtype in cat.ToList() on so.DELIVERMAT.ToString() equals mtype.KEYVALUE
						   where so.ISDELETE == false
								 && so.ISCANCEL == false
								 && so.CUSTCODE == CustomerCode
								 && so.SODATE.Num2Date().Year == IssueYear
								 && so.SODATE.Num2Date().Month == IssueMonth
						   group so by new
						   {
							   so.CUSTCODE,
							   c.CUSTNAME,
							   IssueDate = so.SODATE.Num2Date().ToShortDateString(),
							   mtype.THKEYNAME
						   }
					into issue
						   select new
						   {
							   issue.Key.CUSTCODE,
							   Customer = issue.Key.CUSTNAME,
							   issue.Key.IssueDate,
							   Material = issue.Key.THKEYNAME,
							   Total = issue.Sum(x => x.DELIVERWEIGHT)
						   }).OrderBy(o => o.IssueDate).AsParallel();

				// convert result set to datatable
				var m = mat.ToDataTable();

				// create dummy datatable and copy structure and detail
				var _t = m.Copy();

				// remove the un-used columns
				_t.Columns.Remove("Material");
				_t.Columns.Remove("Total");

				// create string array for new Column
				var pkCol = _t.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
				_result = _t.DefaultView.ToTable(true, pkCol).Copy();
				_result.PrimaryKey = _result.Columns.Cast<DataColumn>().ToArray();

				// add last column into result table
				_result.Columns.Add("Total", typeof(decimal));

				m.AsEnumerable()
					.Select(r => r["Material"].ToString())
					.Distinct()
					.ToList()
					.ForEach(c => _result.Columns.Add(c, typeof(decimal)));


				// load data from master table (m) into result table
				// and add zero (0.00) into field that no data
				//
				foreach (DataRow dr in m.Rows)
				{
					var _totalWeight = 0.00m;
					var _row = _result.Rows.Find(pkCol.Select(x => dr[x]).ToArray());
					_row[dr["Material"].ToString()] = dr["Total"];

					foreach (DataColumn dc in _result.Columns)
						if (dc.DataType == typeof(decimal)
							&& dc.ColumnName != "Total")
							if (Convert.IsDBNull(_row[dc.ColumnName]) == false) _totalWeight += Convert.ToDecimal(_row[dc.ColumnName]);
							else _row[dc.ColumnName] = 0.00m;
					_row["Total"] = _totalWeight;
				}

				// add summary row
				var _sumRow = _result.NewRow();
				foreach (DataColumn dc in _result.Columns)
				{
					var _sumWeight = 0.00m;
					if (dc.ColumnName == "CUSTCODE" || dc.ColumnName == "Customer" || dc.ColumnName == "IssueDate")
					{
						if (dc.ColumnName == "CUSTCODE") _sumRow[dc.ColumnName] = "";
						else _sumRow[dc.ColumnName] = "Total Weight";
					}
					else
					{
						foreach (DataRow dr in _result.Rows) _sumWeight += Convert.ToDecimal(dr[dc.ColumnName]);
						_sumRow[dc.ColumnName] = _sumWeight;
					}
				}

				_result.Rows.Add(_sumRow);
				_result.DefaultView.Sort = "IssueDate ASC, Total";


				return _result;
			});
		} // end GetAsyncIssueMaterialByCustomer


		public async Task<DataTable> GetAsyncCustomerReturnMaterial(string MaterialCategory, int ReturnYear, int ReturnMonth)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var cat = (from cl in _om.SYSDATAs
						   orderby cl.ENKEYNAME
						   where cl.CATEGORY == MaterialCategory
						   select new
						   {
							   cl.KEYVALUE,
							   cl.THKEYNAME
						   }).Distinct().AsParallel();

				var mat = (from grv in _om.MATRECEIVEs.AsEnumerable()
						   join c in _om.CUSTOMERS on grv.CUSTCODE equals c.CUSTCODE
						   join mtype in cat.ToList() on grv.MATTYPE.ToString() equals mtype.KEYVALUE
						   where grv.ISDELETE == false
								 && grv.RECEIVEDATE.Num2Date().Year == ReturnYear
								 && grv.RECEIVEDATE.Num2Date().Month == ReturnMonth
						   group grv by new
						   {
							   grv.CUSTCODE,
							   c.CUSTNAME,
							   grvdate = grv.RECEIVEDATE.Num2Date().ToShortDateString(),
							   mtype.THKEYNAME
						   }
					into matgrv
						   select new
						   {
							   matgrv.Key.CUSTCODE,
							   Customer = matgrv.Key.CUSTNAME,
							   matgrv.Key.grvdate,
							   Material = matgrv.Key.THKEYNAME,
							   Total = matgrv.Sum(x => x.RECEIVEWEIGHT)
						   }).OrderBy(o => o.grvdate).AsParallel();

				// convert result set to datatable
				var m = mat.ToDataTable();

				// create dummy datatable and copy structure and detail
				var _t = m.Copy();

				// remove the un-used columns
				_t.Columns.Remove("Material");
				_t.Columns.Remove("Total");

				// create string array for new Column
				var pkCol = _t.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
				_result = _t.DefaultView.ToTable(true, pkCol).Copy();
				_result.PrimaryKey = _result.Columns.Cast<DataColumn>().ToArray();

				// add last column into result table
				_result.Columns.Add("Total", typeof(decimal));

				m.AsEnumerable()
					.Select(r => r["Material"].ToString())
					.Distinct()
					.ToList()
					.ForEach(c => _result.Columns.Add(c, typeof(decimal)));


				// load data from master table (m) into result table
				// and add zero (0.00) into field that no data
				//
				foreach (DataRow dr in m.Rows)
				{
					var _totalWeight = 0.00m;
					var _row = _result.Rows.Find(pkCol.Select(x => dr[x]).ToArray());
					_row[dr["Material"].ToString()] = dr["Total"];

					foreach (DataColumn dc in _result.Columns)
						if (dc.DataType == typeof(decimal)
							&& dc.ColumnName != "Total")
							if (Convert.IsDBNull(_row[dc.ColumnName]) == false) _totalWeight += Convert.ToDecimal(_row[dc.ColumnName]);
							else _row[dc.ColumnName] = 0.00m;
					_row["Total"] = _totalWeight;
				}

				// add summary row
				var _sumRow = _result.NewRow();
				foreach (DataColumn dc in _result.Columns)
				{
					var _sumWeight = 0.00m;
					if (dc.ColumnName == "CUSTCODE" || dc.ColumnName == "Customer" || dc.ColumnName == "grvdate")
					{
						if (dc.ColumnName == "CUSTCODE") _sumRow[dc.ColumnName] = "";
						else _sumRow[dc.ColumnName] = "Total Weight";
					}
					else
					{
						foreach (DataRow dr in _result.Rows) _sumWeight += Convert.ToDecimal(dr[dc.ColumnName]);
						_sumRow[dc.ColumnName] = _sumWeight;
					}
				}

				_result.Rows.Add(_sumRow);
				_result.DefaultView.Sort = "GRVDate ASC, Total";


				return _result;
			});
		} // end GetAsyncCustomerReturnMaterial


		public async Task<DataTable> GetAsyncCustomerReturnMaterial(string CustomerCode, string MaterialCategory,
			int YearReceive, int MonthReceive)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var cat = (from cl in _om.SYSDATAs
						   orderby cl.ENKEYNAME
						   where cl.CATEGORY == MaterialCategory
						   select new
						   {
							   cl.KEYVALUE,
							   cl.THKEYNAME
						   }).Distinct().AsParallel();

				var mat = (from grv in _om.MATRECEIVEs.AsEnumerable()
						   join c in _om.CUSTOMERS on grv.CUSTCODE equals c.CUSTCODE
						   join mtype in cat.ToList() on grv.MATTYPE.ToString() equals mtype.KEYVALUE
						   where grv.ISDELETE == false
								 && grv.CUSTCODE == CustomerCode
								 && grv.RECEIVEDATE.Num2Date().Year == YearReceive
								 && grv.RECEIVEDATE.Num2Date().Month == MonthReceive
						   group grv by new
						   {
							   grv.CUSTCODE,
							   c.CUSTNAME,
							   grvdate = grv.RECEIVEDATE.Num2Date().ToShortDateString(),
							   mtype.THKEYNAME
						   }
					into matgrv
						   select new
						   {
							   matgrv.Key.CUSTCODE,
							   Customer = matgrv.Key.CUSTNAME,
							   matgrv.Key.grvdate,
							   Material = matgrv.Key.THKEYNAME,
							   Total = matgrv.Sum(x => x.RECEIVEWEIGHT),
							   TotalBalance = matgrv.Sum(x => x.BALANCEWEIGHT)
						   }).OrderBy(o => o.grvdate).AsParallel();

				// convert result set to datatable
				var m = mat.ToDataTable();

				// create dummy datatable and copy structure and detail
				var _t = m.Copy();

				// remove the un-used columns
				_t.Columns.Remove("Material");
				_t.Columns.Remove("Total");

				// create string array for new Column
				var pkCol = _t.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
				_result = _t.DefaultView.ToTable(true, pkCol).Copy();
				_result.PrimaryKey = _result.Columns.Cast<DataColumn>().ToArray();

				// add last column into result table
				_result.Columns.Add("Total", typeof(decimal));

				m.AsEnumerable()
					.Select(r => r["Material"].ToString())
					.Distinct()
					.ToList()
					.ForEach(c => _result.Columns.Add(c, typeof(decimal)));


				// load data from master table (m) into result table
				// and add zero (0.00) into field that no data
				//
				foreach (DataRow dr in m.Rows)
				{
					var _totalWeight = 0.00m;
					var _row = _result.Rows.Find(pkCol.Select(x => dr[x]).ToArray());
					_row[dr["Material"].ToString()] = dr["Total"];

					foreach (DataColumn dc in _result.Columns)
						if (dc.DataType == typeof(decimal)
							&& dc.ColumnName != "Total")
							if (Convert.IsDBNull(_row[dc.ColumnName]) == false) _totalWeight += Convert.ToDecimal(_row[dc.ColumnName]);
							else _row[dc.ColumnName] = 0.00m;
					_row["Total"] = _totalWeight;
				}

				// add summary row
				var _sumRow = _result.NewRow();
				foreach (DataColumn dc in _result.Columns)
				{
					var _sumWeight = 0.00m;
					if (dc.ColumnName == "CUSTCODE" || dc.ColumnName == "Customer" || dc.ColumnName == "grvdate")
					{
						if (dc.ColumnName == "CUSTCODE") _sumRow[dc.ColumnName] = "";
						else _sumRow[dc.ColumnName] = "Total Weight";
					}
					else
					{
						foreach (DataRow dr in _result.Rows) _sumWeight += Convert.ToDecimal(dr[dc.ColumnName]);
						_sumRow[dc.ColumnName] = _sumWeight;
					}
				}

				_result.Rows.Add(_sumRow);
				_result.DefaultView.Sort = "GRVDate ASC, Total";


				return _result;
			});
		} // end GetAsyncCustomerReturnMaterial


		public DataTable GetMaterialCategory(string CustomerCode)
		{
			var _result = new DataTable();
			var cat = (from m in _om.MATRECEIVEs
					   join c in _om.SYSDATAs on m.MATTYPE.ToString() equals c.KEYVALUE
					   orderby c.CATEGORY
					   where c.GROUPTITLE == "MATERIAL"
							 && m.CUSTCODE == CustomerCode
					   select new
					   {
						   c.CATEGORY
					   }).Distinct().AsParallel();

			if (cat != null) _result = cat.ToDataTable();
			else _result = null;

			return _result;
		} // end GetMaterialCategory

		public DataTable GetMaterialDeliveryYear(string Category)
		{
			var matYear = (from m in _om.SALEORDERS.AsEnumerable()
						   join s in _om.SYSDATAs on m.DELIVERMAT.ToString() equals s.KEYVALUE
						   where s.CATEGORY == Category
						   select new
						   {
							   Y = m.SODATE.Num2Date().Year
						   }).Distinct().OrderByDescending(o => o.Y).AsParallel();

			return matYear.ToDataTable();
		} // end GetMaterialDeliveryYear


		public DataTable GetMaterialReciveYear(string Category)
		{
			var matYear = (from m in _om.MATRECEIVEs.AsEnumerable()
						   join s in _om.SYSDATAs on m.MATTYPE.ToString() equals s.KEYVALUE
						   where s.CATEGORY == Category
						   select new
						   {
							   Y = m.RECEIVEDATE.Num2Date().Year
						   }).Distinct().OrderByDescending(o => o.Y).AsParallel();

			return matYear.ToDataTable();
		} // end GetMaterialReciveYear

		public DataTable GetMaterialReciveMonth(string Category, int YearReceive)
		{
			var matMonth = (from m in _om.MATRECEIVEs.AsEnumerable()
							join s in _om.SYSDATAs on m.MATTYPE.ToString() equals s.KEYVALUE
							where s.CATEGORY == Category
								  && m.RECEIVEDATE.Num2Date().Year == YearReceive
							select new
							{
								Mname = DateAndTime.MonthName(m.RECEIVEDATE.Num2Date().Month, true),
								M = m.RECEIVEDATE.Num2Date().Month
							}).Distinct().OrderByDescending(o => o.M).AsParallel();

			return matMonth.ToDataTable();
		} // end GetMaterialReciveMonth

		public DataTable GetMaterialDeliveryMonth(string Category, int YearDelivery)
		{
			var matMonth = (from m in _om.SALEORDERS.AsEnumerable()
							join s in _om.SYSDATAs on m.DELIVERMAT.ToString() equals s.KEYVALUE
							where s.CATEGORY == Category
								  && m.SODATE.Num2Date().Year == YearDelivery
							select new
							{
								Mname = DateAndTime.MonthName(m.SODATE.Num2Date().Month, true),
								M = m.SODATE.Num2Date().Month
							}).Distinct().OrderByDescending(o => o.M).AsParallel();

			return matMonth.ToDataTable();
		} // end GetMaterialDeliveryMonth


		public async Task<DataTable> GetIssueWithSI(string MaterialCategory, int IssueYear, int IssueMonth)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var cat = (from cl in _om.SYSDATAs
						   join so in _om.SALEORDERS.AsEnumerable() on cl.KEYVALUE equals so.DELIVERMAT.ToString()
						   orderby cl.ENKEYNAME
						   where cl.CATEGORY == MaterialCategory
								 && so.ISCANCEL == false
								 && so.ISDELETE == false
								 && so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
						   select new
						   {
							   so.DELIVERMAT,
							   cl.THKEYNAME,
							   Factor = cl.SI / (cl.CONVERTFACTOR * 100 + cl.SI == 0.00m ? 1.00m : cl.CONVERTFACTOR * 100 + cl.SI)
						   }).Distinct().OrderBy(o => o.THKEYNAME).AsParallel();

				var mat = (from so in _om.SALEORDERS.AsEnumerable()
						   join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
						   join mtype in cat.ToList() on so.DELIVERMAT equals mtype.DELIVERMAT
						   where so.ISDELETE == false
								 && so.ISCANCEL == false
								 && so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
								 && so.SODATE.Num2Date().Year == IssueYear
								 && so.SODATE.Num2Date().Month == IssueMonth
						   group new
						   {
							   so,
							   mtype
						   } by new
						   {
							   so.CUSTCODE,
							   c.CUSTNAME,
							   mtype.THKEYNAME
						   }
					into issue
						   select new
						   {
							   issue.Key.CUSTCODE,
							   Customer = issue.Key.CUSTNAME,
							   Material = issue.Key.THKEYNAME,
							   TotalDelivery = issue.Sum(x => x.so.DELIVERWEIGHT),
							   TotalSI = issue.Sum(x => x.so.DELIVERWEIGHT * x.mtype.Factor)
						   }).OrderBy(o => o.TotalDelivery).AsParallel();

				// convert result set to datatable
				var m = mat.ToDataTable();

				// create dummy datatable and copy structure and detail
				var _t = m.Copy();

				// remove the un-used columns
				_t.Columns.Remove("Material");
				_t.Columns.Remove("TotalDelivery");
				_t.Columns.Remove("TotalSI");

				// create string array for new Column
				var pkCol = _t.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
				_result = _t.DefaultView.ToTable(true, pkCol).Copy();
				_result.PrimaryKey = _result.Columns.Cast<DataColumn>().ToArray();

				// add last column into result table
				_result.Columns.Add("TotalDelivery", typeof(decimal));
				_result.Columns.Add("TotalSI", typeof(decimal));

				m.AsEnumerable()
					.Select(r => r["Material"].ToString())
					.Distinct()
					.ToList()
					.ForEach(c => _result.Columns.Add(c, typeof(decimal)));


				// load data from master table (m) into result table
				// and add zero (0.00) into field that no data
				//
				foreach (DataRow dr in m.Rows)
				{
					var _totalDeliveryWeight = 0.00m;
					var _totalSI = 0.00m;
					var _row = _result.Rows.Find(pkCol.Select(x => dr[x]).ToArray());
					_row[dr["Material"].ToString()] = dr["TotalDelivery"];

					//_row["TotalSI"] = dr["TotalSI"];

					foreach (DataColumn dc in _result.Columns)
						if (dc.DataType == typeof(decimal)
							&& dc.ColumnName != "TotalDelivery")
							if (Convert.IsDBNull(_row[dc.ColumnName]) == false)
								if (dc.ColumnName == "TotalSI") _totalSI += Convert.ToDecimal(_row[dc.ColumnName]);
								else _totalDeliveryWeight += Convert.ToDecimal(_row[dc.ColumnName]);
							else _row[dc.ColumnName] = 0.00m;
					_row["TotalDelivery"] = _totalDeliveryWeight;
					_row["TotalSI"] = _totalSI + Convert.ToDecimal(dr["TotalSI"]);
				}

				// add summary row
				var _sumRow = _result.NewRow();
				foreach (DataColumn dc in _result.Columns)
				{
					var _sumWeight = 0.00m;
					if (dc.ColumnName == "CUSTCODE"
						|| dc.ColumnName == "Customer")
					{
						if (dc.ColumnName == "CUSTCODE") _sumRow[dc.ColumnName] = "";
						else _sumRow[dc.ColumnName] = "Total Weight";
					}
					else
					{
						foreach (DataRow dr in _result.Rows) _sumWeight += Convert.ToDecimal(dr[dc.ColumnName]);
						_sumRow[dc.ColumnName] = _sumWeight;
					}
				}

				_result.Rows.Add(_sumRow);
				_result.DefaultView.Sort = "TotalDelivery";


				return _result;
			});
		} // end GetIssueWithSI


		public async Task<DataTable> GetIssueWithSI(string CustomerCode, string MaterialCategory, int IssueYear,
			int IssueMonth)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var cat = (from cl in _om.SYSDATAs
						   join so in _om.SALEORDERS.AsEnumerable() on cl.KEYVALUE equals so.DELIVERMAT.ToString()
						   orderby cl.ENKEYNAME
						   where cl.CATEGORY == MaterialCategory
								 && so.ISCANCEL == false
								 && so.ISDELETE == false
								 && so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
								 && so.SODATE.Num2Date().Year == IssueYear
								 && so.SODATE.Num2Date().Month == IssueMonth
								 && so.CUSTCODE == CustomerCode
						   select new
						   {
							   so.DELIVERMAT,
							   cl.THKEYNAME,
							   Factor = cl.SI / (cl.CONVERTFACTOR * 100 + cl.SI == 0.00m ? 1.00m : cl.CONVERTFACTOR * 100 + cl.SI)
						   }).Distinct().OrderBy(o => o.THKEYNAME).AsParallel();


				var mat = (from so in _om.SALEORDERS.AsEnumerable()
						   join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
						   join mtype in cat.ToList() on so.DELIVERMAT equals mtype.DELIVERMAT
						   where so.ISDELETE == false
								 && so.ISCANCEL == false
								 && so.CUSTCODE == CustomerCode
								 && so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
								 && so.SODATE.Num2Date().Year == IssueYear
								 && so.SODATE.Num2Date().Month == IssueMonth
						   group new
						   {
							   so,
							   mtype
						   } by new
						   {
							   so.CUSTCODE,
							   c.CUSTNAME,
							   mtype.THKEYNAME
						   }
					into issue
						   select new
						   {
							   issue.Key.CUSTCODE,
							   Customer = issue.Key.CUSTNAME,
							   Material = issue.Key.THKEYNAME,
							   TotalDelivery = issue.Sum(x => x.so.DELIVERWEIGHT),
							   TotalSI = issue.Sum(x => x.so.DELIVERWEIGHT * x.mtype.Factor)
						   }).OrderBy(o => o.TotalDelivery).AsParallel();

				// convert result set to datatable
				var m = mat.ToDataTable();

				// create dummy datatable and copy structure and detail
				var _t = m.Copy();

				// remove the un-used columns
				_t.Columns.Remove("Material");
				_t.Columns.Remove("TotalDelivery");
				_t.Columns.Remove("TotalSI");

				// create string array for new Column
				var pkCol = _t.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
				_result = _t.DefaultView.ToTable(true, pkCol).Copy();
				_result.PrimaryKey = _result.Columns.Cast<DataColumn>().ToArray();

				// add last column into result table
				_result.Columns.Add("TotalDelivery", typeof(decimal));
				_result.Columns.Add("TotalSI", typeof(decimal));

				m.AsEnumerable()
					.Select(r => r["Material"].ToString())
					.Distinct()
					.ToList()
					.ForEach(c => _result.Columns.Add(c, typeof(decimal)));


				// load data from master table (m) into result table
				// and add zero (0.00) into field that no data
				//
				foreach (DataRow dr in m.Rows)
				{
					var _totalDeliveryWeight = 0.00m;
					var _totalSI = 0.00m;
					var _row = _result.Rows.Find(pkCol.Select(x => dr[x]).ToArray());
					_row[dr["Material"].ToString()] = dr["TotalDelivery"];

					//_row["TotalSI"] = dr["TotalSI"];

					foreach (DataColumn dc in _result.Columns)
						if (dc.DataType == typeof(decimal)
							&& dc.ColumnName != "TotalDelivery")
							if (Convert.IsDBNull(_row[dc.ColumnName]) == false)
								if (dc.ColumnName == "TotalSI") _totalSI += Convert.ToDecimal(_row[dc.ColumnName]);
								else _totalDeliveryWeight += Convert.ToDecimal(_row[dc.ColumnName]);
							else _row[dc.ColumnName] = 0.00m;
					_row["TotalDelivery"] = _totalDeliveryWeight;
					_row["TotalSI"] = _totalSI + Convert.ToDecimal(dr["TotalSI"]);
				}

				// add summary row
				var _sumRow = _result.NewRow();
				foreach (DataColumn dc in _result.Columns)
				{
					var _sumWeight = 0.00m;
					if (dc.ColumnName == "CUSTCODE"
						|| dc.ColumnName == "Customer")
					{
						if (dc.ColumnName == "CUSTCODE") _sumRow[dc.ColumnName] = "";
						else _sumRow[dc.ColumnName] = "Total Weight";
					}
					else
					{
						foreach (DataRow dr in _result.Rows) _sumWeight += Convert.ToDecimal(dr[dc.ColumnName]);
						_sumRow[dc.ColumnName] = _sumWeight;
					}
				}

				_result.Rows.Add(_sumRow);
				_result.DefaultView.Sort = "TotalDelivery";


				return _result;
			});
		} // end GetIssueWithSI


		public async Task<DataTable> GetAsyncTotalDeliveryCasting(string MaterialCategory, int YearDelivery, int MonthDelivery)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				var _issue = (from so in _om.SALEORDERS.AsEnumerable()
							  join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
							  join s in _om.SYSDATAs on so.DELIVERMAT.ToString() equals s.KEYVALUE
							  where s.GROUPTITLE == "MATERIAL"
									&& s.CATEGORY == MaterialCategory
									&& so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
									&& so.ISCANCEL == false
									&& so.ISDELETE == false
									&& so.SODATE.Num2Date().Year == YearDelivery
									&& so.SODATE.Num2Date().Month == MonthDelivery
							  group new
							  {
								  so,
								  s
							  } by new
							  {
								  c.CUSTNAME,
								  s.THKEYNAME
							  }
					into sales
							  select new
							  {
								  Code = sales.FirstOrDefault().so.CUSTCODE,
								  Customer = sales.Key.CUSTNAME,
								  Material = sales.Key.THKEYNAME,
								  DeliveryQty = sales.Sum(x => x.so.DELIVERWEIGHT),
								  SI =
								  sales.Sum(
									  x =>
										  x.so.DELIVERWEIGHT * (x.s.SI / 100.0m))
							  }).OrderBy(o => o.DeliveryQty).AsParallel();

				//
				// OLD FORMULAR FOR CAL SI
				//	(x.s.SI / (x.s.CONVERTFACTOR * 100 + x.s.SI == 0.00m ? 1.00m : x.s.CONVERTFACTOR * 100 + x.s.SI)))
				//
				// add summary row
				if (_issue.ToList().Count > 1)
				{
					_result = _issue.ToDataTable();

					var _dr = _result.NewRow();
					foreach (DataColumn _dc in _result.Columns)
						if (_dc.ColumnName == "Customer"
							|| _dc.ColumnName == "Code"
							|| _dc.ColumnName == "Material")
						{
							if (_dc.ColumnName == "Code") _dr[_dc.ColumnName] = "";
							if (_dc.ColumnName == "Customer") _dr[_dc.ColumnName] = "Total Delivery Weight";
							else if (_dc.ColumnName == "Material") _dr[_dc.ColumnName] = "";
						}
						else
						{
							_dr[_dc.ColumnName] = _result.AsEnumerable().ToList().Sum(x => x.Field<decimal>(_dc.ColumnName));
						}
					_result.Rows.Add(_dr);
				}

				return _result;
			});
		} // end   GetAsyncTotalDeliveryCasting


		public async Task<DataTable> GetAsyncDeliveryMaterialByCustomer(string CustomerCode, string MaterialCategory,
			int DeliveryYear, int DeliveryMonth)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				// find the delivered material name 
				var cat = (from cl in _om.SYSDATAs
						   join so in _om.SALEORDERS.AsEnumerable() on cl.KEYVALUE equals so.DELIVERMAT.ToString()
						   orderby cl.ENKEYNAME
						   where cl.CATEGORY == MaterialCategory
								 && so.ISCANCEL == false
								 && so.ISDELETE == false
								 && so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
								 && so.CUSTCODE == CustomerCode
						   select new
						   {
							   so.DELIVERMAT,
							   cl.THKEYNAME
						   }).Distinct().OrderBy(o => o.THKEYNAME).AsParallel();


				var _issue = (from so in _om.SALEORDERS.AsEnumerable()
							  join m in cat.ToList() on so.DELIVERMAT equals m.DELIVERMAT
							  join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
							  where so.ISDELETE == false
									&& so.ISCANCEL == false
									&& so.CUSTCODE == CustomerCode
									&& so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
									&& so.SODATE.Num2Date().Year == DeliveryYear
									&& so.SODATE.Num2Date().Month == DeliveryMonth
							  group new
							  {
								  so,
								  m
							  } by new
							  {
								  so.CUSTCODE,
								  c.CUSTNAME,
								  so.SONO,
								  DeliveryDate = so.SODATE.Num2Date().ToShortDateString(),
								  m.THKEYNAME
							  }
					into issue
							  select new
							  {
								  Code = issue.Key.CUSTCODE,
								  Customer = issue.Key.CUSTNAME,
								  issue.Key.SONO,
								  issue.Key.DeliveryDate,
								  Material = issue.Key.THKEYNAME,
								  TotalDelivery = issue.Sum(x => x.so.DELIVERWEIGHT)
							  }).OrderBy(o => Convert.ToDateTime(o.DeliveryDate)).AsParallel();

				// convert result set to datatable
				var _m = _issue.ToDataTable();

				// create dummy datatable and copy structure and detail
				var _t = _m.Copy();

				// remove the un-used columns
				_t.Columns.Remove("Material");
				_t.Columns.Remove("TotalDelivery");

				// create string array for new Column
				var pkCol = _t.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
				_result = _t.DefaultView.ToTable(true, pkCol).Copy();
				_result.PrimaryKey = _result.Columns.Cast<DataColumn>().ToArray();

				_m.AsEnumerable()
					.Select(r => r["Material"].ToString())
					.Distinct()
					.ToList()
					.ForEach(c => _result.Columns.Add(c, typeof(decimal)));

				// add last column into result table
				_result.Columns.Add("TotalDelivery", typeof(decimal));


				// load data from master table (m) into result table
				// and add zero (0.00) into field that no data
				//
				foreach (DataRow dr in _m.Rows)
				{
					var _totalDeliveryWeight = 0.00m;
					var _row = _result.Rows.Find(pkCol.Select(x => dr[x]).ToArray());
					_row[dr["Material"].ToString()] = dr["TotalDelivery"];

					foreach (DataColumn dc in _result.Columns)
						if (dc.DataType == typeof(decimal)
							&& dc.ColumnName != "TotalDelivery")
						{
							if (Convert.IsDBNull(_row[dc.ColumnName]) == false)
								_totalDeliveryWeight += Convert.ToDecimal(_row[dc.ColumnName]);
							else _row[dc.ColumnName] = 0.00m;
						}
						else if (dc.DataType == typeof(DateTime))
						{
						}
					_row["TotalDelivery"] = _totalDeliveryWeight;
				}

				//_result.Rows.Add(_sumRow);
				_result.DefaultView.Sort = "DeliveryDate";

				return _result;
			});
		} // end GetAsyncDeliveryMaterialByCustomer


		public decimal GetLastOpenBalance(string CustomerCode, string MaterialCategory, int DeliveryYear)
		{
			// find the last open balance for last year
			var _prevoiusYear = DeliveryYear - 1;
			var _lastOpenBalance = 0.00m;
			var _ly =
				_om.MATOPENBALANCEs.Where(
					x => x.OPENYEAR == _prevoiusYear && x.CUSTCODE == CustomerCode && x.MATCAT == MaterialCategory);
			if (_ly.Count() > 0)
				_lastOpenBalance =
					_om.MATOPENBALANCEs.Single(
						x => x.OPENYEAR == _prevoiusYear && x.CUSTCODE == CustomerCode && x.MATCAT == MaterialCategory).BALANCE12;

			return _lastOpenBalance;
		} // end GetLastOpenBalance


		public async Task<DataTable> GetAsyncMaterialCardByCustomer(string CustomerCode, string MaterialCategory,
			int DeliveryYear, int DeliveryMonth)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				// create list of material receive

				var issue = (from s in _om.SALEORDERS.AsEnumerable()
							 join sy in _om.SYSDATAs on s.DELIVERMAT.ToString() equals sy.KEYVALUE
							 orderby s.SODATE, s.SONO
							 where sy.CATEGORY == MaterialCategory
								   && sy.GROUPTITLE == "MATERIAL"
								   && s.ISDELETE == false
								   && s.ISCANCEL == false
								   && s.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
								   && s.CUSTCODE == CustomerCode
								   && s.SODATE.Num2Date().Year == DeliveryYear
								   && s.SODATE.Num2Date().Month == DeliveryMonth
							 select new
							 {
								 DocNumber = s.SONO,
								 DocDate = s.SODATE.Num2Date(),
								 Mat = sy.THKEYNAME,
								 KeyType = "OUT",
								 Qty = s.DELIVERWEIGHT,
								 Balance = 0.00m,
								 s.REMARK
							 }).AsParallel().ToList();

				// create list of material issue

				var grv = (from mr in _om.MATRECEIVEs.AsEnumerable()
						   join sy in _om.SYSDATAs on mr.MATTYPE.ToString() equals sy.KEYVALUE
						   orderby mr.RECEIVEDATE, mr.GRVSEQ
						   where sy.CATEGORY == MaterialCategory
								 && sy.GROUPTITLE == "MATERIAL"
								 && mr.ISDELETE == false
								 && mr.CUSTCODE == CustomerCode
								 && mr.RECEIVEDATE.Num2Date().Year == DeliveryYear
								 && mr.RECEIVEDATE.Num2Date().Month == DeliveryMonth
						   select new
						   {
							   DocNumber = mr.CUSTDOCNO == "" ? mr.GRVSEQ.ToString() : mr.CUSTDOCNO,
							   DocDate = mr.RECEIVEDATE.Num2Date(),
							   Mat = sy.THKEYNAME,
							   KeyType = "IN",
							   Qty = mr.RECEIVEWEIGHT,
							   Balance = 0.00m,
							   REMARK = mr.DESCRIPTION
						   }).AsParallel().ToList();

				// join of both list together by keyword "UNION
				var source = issue.Union(grv).AsParallel();

				//.OrderBy(d => d.DocDate).ThenBy(c => c.DocNumber).AsParallel().ToList();

				// create pivot table card
				var cardSource = (from s in source.ToList()
								  group s by new
								  {
									  s.DocNumber,
									  s.DocDate,
									  s.Mat,
									  s.REMARK
								  }
					into card
								  select new
								  {
									  Doc = card.Key.DocNumber,
									  card.Key.DocDate,
									  Material = card.Key.Mat,
									  IN = card.Sum(x => x.KeyType == "IN" ? x.Qty : 0.00m),
									  OUT = card.Sum(x => x.KeyType == "OUT" ? x.Qty : 0.00m),
									  Balance = 0.00m,
									  card.Key.REMARK
								  }).OrderBy(o => o.DocDate).ThenBy(o => o.Doc).AsParallel();

				_result = cardSource.ToDataTable();

				return _result;
			});
		} // end GetAsyncMaterialCardByCustomer


		public DataTable GetOpenBalanceYearList()
		{
			return _om.SALEORDERS.Select(x => new
			{
				x.FISCYEAR
			}).Distinct().AsParallel().ToDataTable();
		}
	}
}