using OMW15.Models.ToolModel;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace OMW15.Models.WarehouseModel
{
	public class IssueDAL
	{

		#region constructor
		private readonly ERP _erp;
		private readonly OLDMOONEF1 _om;

		public IssueDAL()
		{
			_om = new OLDMOONEF1();
			_erp = new ERP();
		}

		#endregion

		#region static class method

		public int DeleteIssueItem(int IssueRowId)
		{
			var _result = 0;

			using (var _scope = new TransactionScope())
			{
				try
				{
					var _item = (from sp in _om.ORDERSPAREPARTS
								 where sp.spLine == IssueRowId
								 select sp).Single();

					_om.ORDERSPAREPARTS.Remove(_item);
					_result = _om.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't remove the selected item.....", ex);
				}
			}
			return _result;
		}

		public ORDERSPAREPART GetIssueItemInfo(int Id)
		{
			return _om.ORDERSPAREPARTS.Single(x => x.spLine == Id);
		} // end GetIssueItemInfo

		#endregion

		#region public class method

		public int UpdateIssueItemInfo(int SPLineId, ORDERSPAREPART IssueItem)
		{
			var _result = 0;
			using (var _scope = new TransactionScope())
			{
				if (SPLineId == 0) // add item
					try
					{
						_om.ORDERSPAREPARTS.Add(IssueItem);
						_result = _om.SaveChanges();
						_scope.Complete();
					}
					catch (OptimisticConcurrencyException ex)
					{
						throw new Exception("Can't insert new Issue Item", ex);
					}
				else // edit
					try
					{
						var _issue = _om.ORDERSPAREPARTS.Single(x => x.spLine == SPLineId);
						_issue.qtyneed = IssueItem.qtyneed;
						_issue.uprice = IssueItem.uprice;
						_issue.discount = IssueItem.discount;
						_issue.netuprice = IssueItem.netuprice;
						_issue.totalprice = IssueItem.totalprice;
						_issue.itemremark = IssueItem.itemremark;
						_issue.modidt = IssueItem.modidt;
						_issue.modiuser = IssueItem.modiuser;
						_result = _om.SaveChanges();
						_scope.Complete();
					}
					catch (OptimisticConcurrencyException ex)
					{
						throw new Exception("Can't update Issue item ", ex);
					}
			}

			return _result;
		} // end UpdateIssueItemInfo

		public async Task<DataTable> GetIssueItemsAsync(int IssueNo)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var _docs = (from di in _erp.DOCINFOes
							 join trh in _erp.TRANSTKHs on di.DI_KEY equals trh.TRH_DI
							 join trd in _erp.TRANSTKDs on trh.TRH_KEY equals trd.TRD_TRH
							 join dept in _erp.DEPTTABs on trh.TRH_DEPT equals dept.DEPT_KEY
							 join sku in _erp.SKUMASTERs on trd.TRD_SKU equals sku.SKU_KEY
							 join icat in _erp.ICCATs on sku.SKU_ICCAT equals icat.ICCAT_KEY
							 where di.DI_KEY == IssueNo
							 orderby trd.TRD_SH_CODE
							 select new
							 {
								 IssueLineId = trh.TRH_KEY,
								 DocumentKey = di.DI_KEY,
								 ProjectNo = trh.TRH_PRJ,
								 OrderNumber = trh.TRH_REFER_IREF,
								 DocumentNo = di.DI_REF,
								 DocumentDate = di.DI_DATE,
								 ICKey = icat.ICCAT_KEY,
								 ICCode = icat.ICCAT_CODE,
								 ICName = icat.ICCAT_NAME,
								 DepartmentId = trh.TRH_DEPT,
								 DepartmentCode = dept.DEPT_CODE,
								 ShipItemNo = trd.TRD_SH_CODE,
								 ShipItemName = trd.TRD_SH_NAME,
								 ShipUnit = trd.TRD_UTQNAME,
								 ShipQty = trd.TRD_SH_QTY,
								 ShipUnitPrice = trd.TRD_SH_UPRC,
								 ShipTotalValue = trd.TRD_SH_GSELL,
								 ShipTotalVAT = trd.TRD_SH_GVAT,
								 ShipGrandTotal = trd.TRD_SH_GAMT
							 }).AsParallel();
				if (_docs != null)
					_result = _docs.ToDataTable();
				return _result;
			});
		} // end GetIssueItemsAsync

		public async Task<DataTable> GetIssueItemsAsync(int IssueNo,string connectionString)
		{
			return await Task.Run(() =>
			{
				StringBuilder s = new StringBuilder();
				s.AppendLine(" SELECT ");
				s.AppendLine(" * ");
				s.AppendLine(" FROM OM_ERP_WH_ISSUE_ITEMS issue");
				s.AppendLine($" WHERE issue.DOCUMENTKEY = {IssueNo}");
				s.AppendLine(" ORDER BY issue.DOCUMENTNO, issue.ICKEY");
				return new DataConnect(s.ToString(), connectionString).ToDataTable;
			});
		} // end GetIssueItemsAsync

		public DataTable GetServiceSparePartIssueList(int IssueDocKey, int YearIssue, int PeriodIssue)
		{
			var _result = new DataTable();
			var _docs = (from di in _erp.DOCINFOes
						 where di.DI_DATE.Year == YearIssue
							   && di.DI_DATE.Month == PeriodIssue
							   && di.DI_DT == IssueDocKey
							   && !di.DI_REF.StartsWith("*")
						 select new
						 {
							 DocKey = di.DI_KEY,
							 DocNumber = di.DI_REF,
							 DocDate = di.DI_DATE,
							 Remark = di.DI_REMARK,
							 LastUpdate = di.DI_UPD_DATE,
							 UpdateBy = di.DI_UPD_BY,
							 WorkStation = di.DI_UPD_CPTN
						 }).OrderBy(x => x.DocNumber).AsParallel();

			if (_docs != null)
				_result = _docs.ToDataTable();
			return _result;

		} // end GetServiceSparepartIssueList

		public DataTable GetSparePartItems(int OrderId)
		{
			var _result = new DataTable();
			var rsp = (from r in _om.ORDERSPAREPARTS
					   where r.ORDERMAINTENANCE.orderid == OrderId
							 && r.isdelete == false
					   select new
					   {
						   IssueNo = r.issueno,
						   ItemNo = r.itemno,
						   Description = r.itemname,
						   Unit = r.uom,
						   Qty = r.qtyneed,
						   UnitPrice = r.uprice,
						   Discount = r.discount,
						   NettPrice = r.netuprice,
						   Total = r.totalprice
					   }).AsParallel();

			if (rsp != null)
				_result = rsp.ToDataTable();

			return _result;
		} // end GetSparePartItems

		public DataTable GetSparePartItems(string OrderCode, int OrderId)
		{
			var _result = new DataTable();
			var rsp = (from r in _om.ORDERSPAREPARTS
					   where r.ordercode == OrderCode
							 && r.ORDERMAINTENANCE.orderid == OrderId
							 && r.isdelete == false
					   select new
					   {
						   r.spLine,
						   r.issueno,
						   r.orderid,
						   r.ordercode,
						   r.indatabase,
						   r.itemno,
						   r.itemname,
						   r.uom,
						   r.qtyneed,
						   r.ucost,
						   r.uprice,
						   r.discount,
						   r.netuprice,
						   r.totalprice,
						   r.itemremark,
						   Audit = r.auditdt.Value,
						   r.modiuser,
						   LastUpdate = r.modidt.Value
					   }).AsParallel();

			if (rsp != null)
				_result = rsp.ToDataTable();

			return _result;
		} // end GetSparePartItems


		public int SaveIssueItemToServiceOrder(int OrderId, string OrderNumber, string OrderCode, string IssueNumber,
			ref DataGridView Source)
		{
			var _result = 0;
			var _itemno = string.Empty;
			var _jobOrder = OrderCode + OrderNumber;

			using (var _scope = new TransactionScope())
			{
				try
				{
					foreach (DataGridViewRow _dgr in Source.Rows)
					{
						_itemno = _dgr.Cells["ShipItemNo"].Value.ToString();

						// check for exist item in spare part list
						var spItem = (from sp in _om.ORDERSPAREPARTS
									  where sp.ORDERMAINTENANCE.orderid == OrderId
											&& sp.issueno == IssueNumber
											&& sp.itemno == _itemno
									  select sp).SingleOrDefault();

						// item not found --> add item
						if (spItem == null)
						{
							var _issueItem = new ORDERSPAREPART();
							_issueItem.auditdt = DateTime.Now;
							_issueItem.audituser = omglobal.UserName;
							_issueItem.dateneed = Convert.ToDateTime(_dgr.Cells["DocumentDate"].Value);
							_issueItem.indatabase = true;
							_issueItem.isdelete = false;
							_issueItem.issueno = IssueNumber;
							_issueItem.ordercode = OrderCode;
							_issueItem.orderid = OrderId;
							_issueItem.s_order = OrderNumber;
							_issueItem.itemremark = string.Empty;
							_issueItem.itemno = _dgr.Cells["ShipItemNo"].Value.ToString();
							_issueItem.itemname = _dgr.Cells["ShipItemName"].Value.ToString();

							_issueItem.uom = _dgr.Cells["ShipUnit"].Value.ToString();
							_issueItem.qtyneed = Convert.ToDecimal(_dgr.Cells["ShipQty"].Value);
							_issueItem.ucost = Convert.ToDecimal(_dgr.Cells["ShipUnitPrice"].Value);
							_issueItem.discount = 0.00m;
							_issueItem.netuprice = 0.00m;
							_issueItem.totalprice = 0.00m;
							_issueItem.uprice = 0.00m;

							_issueItem.modidt = DateTime.Now;
							_issueItem.modiuser = omglobal.UserName;

							_om.ORDERSPAREPARTS.Add(_issueItem);
							_result += _om.SaveChanges();
						}
					}

					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					_result = 0;
					throw new Exception("Update Issue item failed !!!!!!", ex);
				}
			}

			// write the Job Number to Issue Items
			// after completed copy all issue items in DataGridView into local database
			if (_result > 0)
				if (WriteJobOrderToIssueItems(_jobOrder, ref Source) > 0)
					MessageBox.Show("Update ERP completed.....", "Update ERP");

			return _result;
		} // end SaveIssueItemToServiceOrder


		/// <summary>
		/// UPDATE SERVICE JOB-ORDER INTO ISSUE HEADER FILE IN ERP SYSTEM
		/// </summary>
		/// <param name="JobOrderNumber"></param>
		/// <param name="Source"></param>
		/// <returns></returns>
		public int WriteJobOrderToIssueItems(string JobOrderNumber, ref DataGridView Source)
		{
			var _result = 0;
			var _issueLineId = 0;

			using (var _scope = new TransactionScope())
			{
				try
				{
					foreach (DataGridViewRow dgr in Source.Rows)
						if (_issueLineId != Convert.ToInt32(dgr.Cells["ISSUELINEID"].Value))
						{
							_issueLineId = Convert.ToInt32(dgr.Cells["ISSUELINEID"].Value);

							// create LINQ statement
							var _trh = _erp.TRANSTKHs.Single(x => x.TRH_KEY == _issueLineId);

							_trh.TRH_REFER_IREF = JobOrderNumber;
							_result += _erp.SaveChanges();
						}
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					_result = 0;
					throw new Exception("Error update Issue Item......", ex);
				}
			}

			return _result;
		} // end WriteJobOrderToIssueItems

		#endregion
	}
}