using System.Data;
using System.Linq;
using System.Threading.Tasks;
using OMControls;
using OMW15.Shared;

namespace OMW15.Models.SaleModel
{
	public class StockDAL
	{
		#region class field member

		private readonly ERP _erp;

		#endregion

		#region constructor

		public StockDAL()
		{
			_erp = new ERP();
		}

		#endregion

		#region class helper member

		

		public async Task<DataTable> GetMasterItemsAsync(OMShareSaleEnum.StockFilterType FilterType, string Filter)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
 				var pr = (from g in _erp.GOODSMASTERs
						  join p in _erp.ARPLUs on g.GOODS_KEY equals p.ARPLU_GOODS
						  orderby g.GOODS_SKU
						  where p.ARPLU_ARPRB == 1

						  // price profile w/o tax
						  select new
						  {
							  ItemKey = g.GOODS_SKU,
							  UnitPrice = p.ARPLU_U_PRC
						  }).AsParallel();

				var _items = (from sku in _erp.SKUMASTERs
							  join utq in _erp.UOFQTies on sku.SKU_S_UTQ equals utq.UTQ_KEY
							  join iccat in _erp.ICCATs on sku.SKU_ICCAT equals iccat.ICCAT_KEY
							  orderby sku.SKU_CODE
							  select new
							  {
								  Id = sku.SKU_KEY,
								  CatId = sku.SKU_ICCAT,
								  Category = iccat.ICCAT_NAME,
								  ItemNo = sku.SKU_CODE,
								  ItemNameTH = sku.SKU_NAME,
								  Unit = utq.UTQ_NAME,
								  UnitCost_THB = sku.SKU_STD_COST
							  }).Distinct().AsParallel();

				switch (FilterType)
				{
					case OMShareSaleEnum.StockFilterType.ByItemName:
						var itemByName = _items.Where(x => x.ItemNameTH.Contains(Filter));
						if (itemByName != null)
							_result = itemByName.ToDataTable();
						break;
					case OMShareSaleEnum.StockFilterType.ByItemNo:
						var itemByNo = _items.Where(x => x.ItemNo.Contains(Filter));
						if (itemByNo != null)
							_result = itemByNo.ToDataTable();
						break;
					case OMShareSaleEnum.StockFilterType.AllItems:
						if (_items != null)
							_result = _items.ToDataTable();
						break;
				}
 				return _result;
			});
  
		} // end GetMasterItemsAsync

		public DataTable GetStockCategoryList()
		{
			int[] _cats = { 101, 105, 114 };
			var _result = new DataTable();

			var cat = (from sku in _erp.SKUMASTERs
					   join iccat in _erp.ICCATs
					   on sku.SKU_ICCAT equals iccat.ICCAT_KEY
					   where _cats.Contains(sku.SKU_ICCAT)
					   select new
					   {
						   key = sku.SKU_ICCAT,
						   name = iccat.ICCAT_NAME
					   }).Distinct();

			if (cat != null)
				_result = cat.ToDataTable();

			return _result;
		} // end GetStockCategoryList

		#endregion
	}
}