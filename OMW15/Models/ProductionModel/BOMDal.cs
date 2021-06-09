using OMW15.Models.ToolModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OMW15.Models.ProductionModel
{
	public class BOMDal
	{
		private readonly OLDMOONEF1 _om;

		public BOMDal()
		{
			_om = new OLDMOONEF1();
		}

		#region BOM - MC BOM

		public DataTable GetTopBomItem(string model)
		{
			return _om.MCBOMs.Where(m => m.MODEL == model
										&& m.LEVEL == 0
										&& m.ISACTIVE == true)
										.Select(s => new
										{
											s.ID,
											s.LEVEL,
											s.PARENT_ID,
											s.REF_NO,
											s.REF_REV,
											s.PARTNO,
											s.PART_REV,
											s.ITEMNAME,
											s.UNIT,
											s.Qty,
											s.UNITCOST
										}).AsParallel().ToDataTable();
		}

		public DataTable GetBomItems(string model, string partno, int partRev, int parentId)
		{
			return _om.MCBOMs.Where(x => x.MODEL == model
										&& x.ISACTIVE == true
										&& x.PARENT_ID == parentId
										&& x.REF_NO == partno
										&& x.REF_REV == partRev
										&& x.LEVEL > 0)
										.Select(s => new
										{
											s.ID,
											s.LEVEL,
											s.PARENT_ID,
											s.REF_NO,
											s.REF_REV,
											s.PARTNO,
											s.PART_REV,
											s.ITEMNAME,
											s.UNIT,
											s.Qty,
											s.UNITCOST
										}).OrderBy(o => o.ID).ToDataTable();
		}


		public bool GetNodeAvailable(string model, string parentno)
		{
			return (_om.MCBOMs.Where(x => x.MODEL == model && x.REF_NO == parentno).Any());
		}

		public MCBOM GetBomItem(int itemId)
		{
			return _om.MCBOMs.Find(itemId);
		}

		public DataTable GetBomModel()
		{
			return _om.MCBOMs.Select(x => new
			{
				x.MODEL
			}).Distinct().AsParallel().ToDataTable();
		}

		public DataTable getPartCategoryFromBOM()
		{
			return _om.MCBOMs.Select(x => new
			{
				x.CATEGORY
			}).Distinct().AsParallel().ToDataTable();
		}

		public DataTable getUnit()
		{
			return (_om.MCBOMs.Select(x => new
			{
				x.UNIT
			}).Distinct().AsParallel().ToDataTable());
		}


		public DataTable getMaker()
		{
			return _om.MCBOMs.Select(x => new
			{
				x.MAKER
			}).Distinct().AsParallel().ToDataTable();
		}
		#endregion

		#region EPR - FORMULA

		public DataTable GetProductionFormulaList()
		{
			return new DataConnect().GetDataTable($"EXEC dbo.usp_OM_ERP_FORMULA_HEADER ");
		}

		public DataTable GetProductionFormulaItemDetails(int formulaId, string itemno,decimal demandQty)
		{
			return new DataConnect().GetDataTable($"EXEC dbo.usp_OM_ERP_BOM_REQUEST_EXTEND @formulaid={formulaId},@partno='{itemno}',@demandqty={demandQty} ");
		}

		public DataTable GetFormulaHeaderInfo(int orderId)
		{
			return new DataConnect().GetDataTable($"EXEC dbo.usp_OM_ERP_FORMULA_MAP_TO_ORDER @orderid={orderId}");
		}

		public async Task<DataTable> GetTotalProductionRequirePartsAsync()
			=> await Task.Run(() =>
										{
											return new DataConnect().GetDataTable($"EXEC dbo.usp_PRODUCTION_DEMAND_PARTS");
										});

		public DataTable GetTotalProductionRequireParts()
			=> new DataConnect().GetDataTable($"EXEC dbo.usp_PRODUCTION_DEMAND_PARTS");

		public DataTable GetTrackingProductionOrder (string partno)
			=> new DataConnect().GetDataTable($"EXEC dbo.usp_OM_PRODUCTION_PARTS_TRACKING @partno='{partno}'");

		#endregion

	}
}
