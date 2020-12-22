using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OMW15.Models.WarehouseModel
{
	public class FOCIssueDAL
	{
		#region class field
			private readonly OLDMOONEF1 _om;
		private readonly ERP erpEF;
			
		// CONSTRUCTOR
		public FOCIssueDAL()
		{
			// create model object
			_om = new OLDMOONEF1();
			erpEF = new ERP();
		}
		
		#endregion
 
		#region class helper method

		public DataTable getServiceOrderYearList(string[] orderCodeAvailable)
		{
			var yearList = (from ord in _om.ORDERMAINTENANCEs
							where orderCodeAvailable.Contains(ord.orderCode)
							select new
							{
								Year = ord.fiscyear
							}).Distinct().OrderByDescending(o => o.Year).AsParallel();

			return yearList.ToDataTable();
		} // end getServiceOrderYearList


		public DataTable getSparePartItems(int Year, string[] orderCodeAvailable)
		{
			var sp = (from osp in _om.ORDERSPAREPARTS
					  //join osp in _om.ORDERSPAREPARTS on ord.orderid equals osp.orderid
					  where osp.ORDERMAINTENANCE.fiscyear == Year
							&& orderCodeAvailable.Contains(osp.ORDERMAINTENANCE.orderCode)
					  select new
					  {
						  osp.itemno,
						  osp.itemname
					  }).Distinct().OrderBy(o => o.itemno).AsParallel();

			return sp.ToDataTable();
		} // end getSparePartItems


		public DataTable getSparePartItemsWithFullDetails(int Year, string[] orderCodeAvailable, List<string> items)
		{
			var result = new DataTable();

			var sp = (//from ord in _om.ORDERMAINTENANCEs
					  from osp in _om.ORDERSPAREPARTS //on ord.orderid equals osp.orderid
					  where osp.ORDERMAINTENANCE.fiscyear == Year
							&& orderCodeAvailable.Contains(osp.ORDERMAINTENANCE.orderCode)
					  select new
					  {
						  CustomerCode = osp.ORDERMAINTENANCE.acccustcode,
						  CustomerName = osp.ORDERMAINTENANCE.cus_na,
						  MachineSN = osp.ORDERMAINTENANCE.s_no,
						  ItemNo = osp.itemno,
						  ItemName = osp.itemname,
						  IssueDate = osp.dateneed,
						  IssueNo = osp.issueno,
						  ContractNumber = osp.ORDERMAINTENANCE.orderCode + osp.ORDERMAINTENANCE.s_order,
						  ContractDate = osp.ORDERMAINTENANCE.orderdate.Value,
						  Unit = osp.uom,
						  IssueQty = osp.qtyneed,
						  Remark = osp.itemremark
					  }).OrderBy(o => o.ItemNo).ThenBy(o => o.IssueDate).AsParallel();

			if (items.Count == 0 || items == null)
				result = sp.ToDataTable();
			else
				result = sp.Where(x => items.Contains(x.ItemNo)).ToDataTable();

			return result;
		} // end getSparePartItemsWithFullDetails

		#endregion
	}
}