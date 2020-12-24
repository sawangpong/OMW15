using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using OMControls;
using System.Data.Entity.Core;
using System.Text;
using OMW15.Models.ToolModel;

namespace OMW15.Models.WarehouseModel
{
	public class WHDDAL
	{
		#region constructor
		private readonly ERP _erp;
		private readonly OLDMOONEF1 _om;

		public WHDDAL()
		{
			_om = new OLDMOONEF1();
			_erp = new ERP();
		}

		#endregion

		#region public class method

		public DataTable GetSparePartByOrder(int OrderId)
		{
			return _om.ORDERSPAREPARTS.Where(x => x.isdelete == false && x.ORDERMAINTENANCE.orderid == OrderId).AsParallel().ToDataTable();

		} // end GetSparePartByOrder

		#endregion

		#region static class method

		public DataTable getUnitList()
		{
			return _erp.UOFQTies.Distinct().Where(x => x.UTQ_QTY == 1).Select(x => new
			{
				UNIT = x.UTQ_NAME
			}).OrderBy(o => o.UNIT).AsParallel().ToDataTable();

		} // end GetUnitList

		public DataTable getIssueDocumentList(string[] IssueCode)
		{
			var _result = new DataTable();
			var DT = (from dt in _erp.DOCTYPEs.AsParallel()
					  orderby dt.DT_THAIDESC
					  where IssueCode.Contains(dt.DT_PREFIX)
					  select new
					  {
						  Key = dt.DT_KEY,
						  DocCode = dt.DT_DOCCODE,
						  DocName = dt.DT_THAIDESC
					  }).AsParallel();

			if (DT != null)
				_result = DT.ToDataTable();

			return _result;

		} // end GetIssueDocumentList

		public DataTable getIssueDocumentType(string DocPrefix, int Level)
		{
			var _result = new DataTable();
			var DT = (from dt in _erp.DOCTYPEs.AsParallel()
					  orderby dt.DT_THAIDESC
					  where dt.DT_DOCCODE.StartsWith(DocPrefix)
					  select new
					  {
						  Key = dt.DT_KEY,
						  DocCode = dt.DT_DOCCODE,
						  DocName = dt.DT_THAIDESC
					  }).AsParallel();

			if (DT.ToList().Count > 0)
				if (Level == 1)
					_result = DT.Where(x => x.DocCode.Length == 2).AsParallel().ToDataTable();
				else
					_result = DT.Where(x => x.DocCode.Length > 2).AsParallel().ToDataTable();

			return _result;

		} // end GetIssueDocumentType

		public int GetDocumentId(string DocumentCode)
		{
			return _erp.DOCTYPEs.Single(x => x.DT_DOCCODE == DocumentCode).DT_KEY;
		} // end GetDocumentId

		public DataTable getDocumentYearList<T>(T Document)
		{
			var _result = new DataTable();
			var _docid = Document.GetType() == typeof(int) ? Convert.ToInt32(Document) : 0;

			var _doccode = Document.GetType() == typeof(string) ? Document.ToString() : string.Empty;

			if (Document.GetType() == typeof(int))
			{
				var DI = (from di in _erp.DOCINFOes
						  orderby di.DI_DATE.Year
						  where di.DI_DT == _docid
						  select new
						  {
							  YearCode = di.DI_DATE.Year
						  }).Distinct().AsParallel().ToList();
				if (DI != null)
					_result = DI.ToDataTable();
			}
			else if (Document.GetType() == typeof(string))
			{
				var _id = GetDocumentId(_doccode);
				var DII = (from di in _erp.DOCINFOes
						   orderby di.DI_DATE.Year
						   where di.DI_DT == _id
						   select new
						   {
							   YearCode = di.DI_DATE.Year
						   }).Distinct().AsParallel().ToList();
				if (DII != null)
					_result = DII.ToDataTable();
			}

			return _result;
		} // end GetDocumentYearList

		public DataTable getDocumentPeriodListByDocumentTyte(int DocumentKey, int YearFilter)
		{
			var _result = new DataTable();
			var DI = (from di in _erp.DOCINFOes
					  orderby di.DI_DATE
					  where di.DI_DT == DocumentKey
							&& di.DI_DATE.Year == YearFilter
					  select new
					  {
						  Period = di.DI_DATE.Month
					  }).Distinct().ToList();

			var dp = (from d in DI
					  orderby d.Period
					  select new
					  {
						  d.Period,
						  PeriodName = OMUtils.GetThaiMonthName(d.Period)
					  }).ToList();
			if (dp != null)
				_result = dp.ToDataTable();

			return _result;

		} // end GetDocumentPeriodListByDocumentTyte

		public string getProjectName(int ProjectId)
		{
			var _result = string.Empty;

			var prj = (from pj in _erp.PRJTABs
					   where pj.PRJ_KEY == ProjectId
					   select new
					   {
						   pj.PRJ_KEY,
						   pj.PRJ_CODE,
						   pj.PRJ_NAME
					   }).Single();

			_result = $"[{prj.PRJ_KEY}] {prj.PRJ_CODE}#{prj.PRJ_NAME}";

			return _result;
		} // end GetProjectName

		#endregion

		#region OM_Item_Master

		public bool findMasterItemImageProperty(string itemNo)
		{
			return _om.ITEMMASTERIMGs.Any(x => x.itemno == itemNo);

		} // end FindMasterItemImageProperty

		public ITEMMASTERIMG getItemMasterRecord(string itemNo)
		{
			var r = _om.ITEMMASTERIMGs.Find(itemNo);
			if (r != null)
			{
				return r;
			}
			else
			{
				return null;
			}
		} // end 	 getItemMasterRecord

		public async Task<Image> getItemMasterImageAsync(string ItemNo)
		{
			return await Task.Run(() =>
			{
				var _img = _om.ITEMMASTERIMGs.SingleOrDefault(x => x.itemno == ItemNo);

				if (_img != null)
				{
					if (_img.itempicture != null)
					{
						return _img.itempicture.ToImageFromByte();
					}
					else
					{
						return null;
					}
				}
				return null;
			});
		} // end GetItemMasterImage

		public Image getItemMasterImage(string ItemNo)
		{
			var _img = _om.ITEMMASTERIMGs.SingleOrDefault(x => x.itemno == ItemNo);

			if (_img != null)
			{
				if (_img.itempicture != null)
				{
					return _img.itempicture.ToImageFromByte();
				}
				else
				{
					return null;
				}
			}
			return null;

		} // end GetItemMasterImage

		public int updateItemMasterImage(ITEMMASTERIMG ItemImage)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					if (ItemImage.itemid == 0)
					{
						_om.ITEMMASTERIMGs.Add(ItemImage);
						_result = _om.SaveChanges();
					}
					else
					{
						ITEMMASTERIMG _img = _om.ITEMMASTERIMGs.Single(x => x.itemno == ItemImage.itemno);
						_img.masterid = ItemImage.masterid;
						_img.itempicture = ItemImage.itempicture;
						_result = _om.SaveChanges();
					}

					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't update picture for Item Master...", ex);
				}
			}

			return _result;
		} // UpdateItemMasterImage

		#endregion

		#region STOCK SUMMARY

		public async Task<DataTable> GetStockSummaryByClassValuesAsync(string connectionString)
		{
			return await Task.Run(() =>
			{
				StringBuilder s = new StringBuilder();
				s.AppendLine(" SELECT * ");
				s.AppendLine(" FROM OM_ERP_WH_CLASS_VALUE clv");
				DataTable dt = new DataConnect(s.ToString(), connectionString).ToDataTable;
				return dt;
			});

		} // end GetStockSummaryByClassValues

		public async Task<DataTable> getStockOnhandByCategoryGroupAsync(string categoryCode, string connectionString)
		{
			return await Task.Run(() =>
			{
				StringBuilder s = new StringBuilder();
				s.AppendLine($"EXEC dbo.usp_OM_ERP_WAREHOUSE_STOCK_ONHAND '{categoryCode}'");
				return new DataConnect(s.ToString(), connectionString).ToDataTable;
			});

		} // end GetStockOnhandByCategoryGroup

		public async Task<DataTable> getStockOnhandMovingInfoByItemId(string itemNo)
		{
			return await Task.Run(() =>
			{
				var onhand = (from sku in _erp.SKUMASTERs
							  join skm in _erp.SKUMOVEs on sku.SKU_KEY equals skm.SKM_SKU
							  join di in _erp.DOCINFOes on skm.SKM_DI equals di.DI_KEY
							  join u in _erp.UOFQTies on sku.SKU_S_UTQ equals u.UTQ_KEY
							  where sku.SKU_CODE == itemNo
							  select new
							  {
								  ID = sku.SKU_KEY,
								  di.DI_REF,
								  di.DI_DATE,
								  ITEMNO = sku.SKU_CODE,
								  ITEMNAME = sku.SKU_NAME,
								  UNIT = u.UTQ_NAME,
								  UNIT_COST = sku.SKU_STD_COST,
								  ONHAND = skm.SKM_QTY,
								  TOTAL_COST = skm.SKM_COST
							  }).Distinct().OrderBy(o => o.DI_DATE).AsParallel();

				return onhand.ToDataTable();
			});
		} // end GetStockOnhandMovingInfoByItemId

		#endregion
	}
}