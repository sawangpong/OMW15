using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Data.EntityClient;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Warehouse.WarehouseContoller
{
	public enum WarehouseSPViewMode
	{
		WarehouseAdmin,
		Select,
		View
	}

	public class WHDocuments
	{
		private SERVICEEF _srv;
		private ERP _erp;
		#region constructor

		public WHDocuments()
		{
			_srv = new SERVICEEF();
			_erp = new ERP();
		}

		#endregion

		#region static class method

		public DataTable GetIssueDocumentType(string DocPrefix, int Level)
		{
			DataTable _result = new DataTable();
			var DT = (from dt in _erp.DOCTYPEs.AsParallel()
					  orderby dt.DT_THAIDESC
					  where dt.DT_DOCCODE.StartsWith(DocPrefix)
					  select new
					  {
						  Key = dt.DT_KEY,
						  DocCode = dt.DT_DOCCODE,
						  DocName = dt.DT_THAIDESC
					  });
			if (DT.ToList().Count > 0)
			{
				if (Level == 1)
				{
					var items = DT.Where(x => x.DocCode.Length == 2).ToList();
					_result = OMControls.OMDataUtils.ToDataTable(items);
				}
				else
				{
					var items = DT.Where(x => x.DocCode.Length > 2).ToList();
					_result = OMControls.OMDataUtils.ToDataTable(items);
				}
			}

			return _result;

		} // end GetIssueDocumentType

		public int GetDocumentId(string DocumentCode)
		{
			var _codeId = (from dt in _erp.DOCTYPEs
						   where dt.DT_DOCCODE == DocumentCode
						   select new
						   {
							   dt.DT_KEY
						   }).FirstOrDefault();
			return _codeId.DT_KEY;
		} // end GetDocumentId

		public DataTable GetDocumentYearList<T>(T Document)
		{
			DataTable _result = new DataTable();
			int _docid = Document.GetType() == typeof(System.Int32) ? Convert.ToInt32(Document) : 0;
			string _doccode = Document.GetType() == typeof(System.String) ? Document.ToString() : string.Empty;

			if (Document.GetType() == typeof(System.Int32))
			{
				var DI = (from di in _erp.DOCINFOes
						  orderby di.DI_DATE.Year
						  where di.DI_DT == _docid
						  select new
						  {
							  YearCode = di.DI_DATE.Year
						  }).Distinct().ToList();

				if (DI != null)
				{
					_result = OMControls.OMDataUtils.ToDataTable(DI);
				}

			}
			else if (Document.GetType() == typeof(System.String))
			{
				int _id = GetDocumentId(_doccode);
				var DII = (from di in _erp.DOCINFOes
						   orderby di.DI_DATE.Year
						   where di.DI_DT == _id
						   select new
						   {
							   YearCode = di.DI_DATE.Year
						   }).Distinct().ToList();
				if (DII != null)
				{
					_result = OMControls.OMDataUtils.ToDataTable(DII);
				}
			}

			return _result;

		} // end GetDocumentYearList

		public DataTable GetDocumentPeriodListByDocumentTyte(int DocumentKey, int YearFilter)
		{
			DataTable _result = new DataTable();
			var DI = (from di in _erp.DOCINFOes
					  orderby di.DI_DATE
					  where di.DI_DT == DocumentKey
					  && di.DI_DATE.Year == YearFilter
					  select new
					  {
						  Period = di.DI_DATE.Month,
					  }).Distinct().ToList();

			var dp = (from d in DI
					  orderby d.Period
					  select new
					  {
						  d.Period,
						  PeriodName = OMControls.OMUtils.GetThaiMonthName(d.Period)
					  }).ToList();

			if (dp != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(dp);
			}

			return _result;

		} // end GetDocumentPeriodListByDocumentTyte

		public string GetProjectName(int ProjectId)
		{
			string _result = string.Empty;

			var prj = (from pj in _erp.PRJTABs
					   where pj.PRJ_KEY == ProjectId
					   select new
					   {
						   pj.PRJ_KEY,
						   pj.PRJ_CODE,
						   pj.PRJ_NAME
					   }).FirstOrDefault();

			_result = string.Format("[{0}] {1}#{2}", prj.PRJ_KEY, prj.PRJ_CODE, prj.PRJ_NAME);

			return _result;

		} // end GetProjectName

		#endregion

		#region public class method

		public DataTable GetSparePartByOrder(int OrderId)
		{
			DataTable _result = new DataTable();
			var sps = (from sp in _srv.ORDERSPAREPARTS
					   where sp.orderid == OrderId
					   && sp.isdelete == false
					   select sp).ToList();

			if (sps != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(sps);
			}

			return _result;

		} // end GetSparePartByOrder

		#endregion
	}
}
