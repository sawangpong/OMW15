using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.Models.SaleModel
{
	public class ERPPriceDAL
	{
		#region class field

		private readonly ERP erp;
 
		public ERPPriceDAL()
		{
			erp = new ERP();
		}

		#endregion


		#region class helper

		public DataTable getErpPriceList(string codeFilter, string nameFilter)
		{
			var goods = from good in erp.GOODSMASTERs
						join ar in (from ar in erp.ARPLUs join art in erp.ARPRICETABs on ar.ARPLU_ARPRB equals art.ARPRB_KEY select new { ar.ARPLU_KEY, ar.ARPLU_GOODS, ar.ARPLU_U_PRC, ar.ARPLU_U_DSC, art.ARPRB_CODE })
						on good.GOODS_KEY equals ar.ARPLU_GOODS
						where ar.ARPRB_CODE == "1"
						select new
						{
							good.GOODS_KEY,
							good.GOODS_CODE,
							good.GOODS_SKU,
							good.GOODS_UTQ,
							ar.ARPLU_U_PRC,
							ar.ARPLU_U_DSC
						};

			var pl = (from sku in erp.SKUMASTERs
					  join good in goods on sku.SKU_KEY equals good.GOODS_SKU
					  join utq in erp.UOFQTies on good.GOODS_UTQ equals utq.UTQ_KEY
					  select new
					  {
						  StockKey = sku.SKU_KEY,
						  GoodsKey = good.GOODS_KEY,
						  PartNo = good.GOODS_CODE,
						  PartName = sku.SKU_NAME,
						  StockUnit = sku.SKU_S_UTQ,
						  MasterUnit = good.GOODS_UTQ,
						  Unit = utq.UTQ_NAME,
						  UnitFactor = utq.UTQ_QTY,
						  UnitCostWOLabour = sku.SKU_LAST_UCCOST,
						  UnitCostTH = sku.SKU_STD_COST * utq.UTQ_QTY,
						  UnitPriceTH = good.ARPLU_U_PRC
					  }).OrderBy(o => o.PartNo).AsParallel();
			if(pl != null)
			{
				if(string.IsNullOrEmpty(codeFilter) && string.IsNullOrEmpty(nameFilter))
				{
					return pl.ToDataTable();
				}

				if(!string.IsNullOrEmpty(codeFilter))
				{
					return pl.Where(x => x.PartNo.Contains(codeFilter)).ToDataTable();
				}
				else
				{
					return pl.Where(x => x.PartName.Contains(nameFilter)).ToDataTable();
				}
			}

			return null;
		}


		#endregion



	}
}
