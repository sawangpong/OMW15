using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Warehouse.WarehouseContoller
{
	public class IssueController
	{
		private SERVICEEF _srv;
		private ERP _erp;

		#region constructor
		public IssueController()
		{
			_srv = new SERVICEEF();
			_erp = new ERP();
		}

		#endregion

		#region static class method

		public int DeleteIssueItem(int IssueRowId)
		{
			int _result = 0;

			using (var _scope = new System.Transactions.TransactionScope())
			{
				try
				{
					var _item = (from sp in _srv.ORDERSPAREPARTS
								 where sp.spLine == IssueRowId
								 select sp).FirstOrDefault();

					_srv.ORDERSPAREPARTS.Remove(_item);
					_result = _srv.SaveChanges();
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
			return _srv.ORDERSPAREPARTS.FirstOrDefault(x => x.spLine == Id);
		} // end GetIssueItemInfo


		#endregion

		#region public class method

		public int UpdateIssueItemInfo(int SPLineId, ORDERSPAREPART IssueItem)
		{
			int _result = 0;
			using (var _scope = new System.Transactions.TransactionScope())
			{
				if (SPLineId == 0) // add item
				{
					try
					{
						_srv.ORDERSPAREPARTS.Add(IssueItem);
						_result = _srv.SaveChanges();
						_scope.Complete();
					}
					catch (OptimisticConcurrencyException ex)
					{
						throw new Exception("Can't insert new Issue Item", ex);
					}
				}
				else // edit
				{
					try
					{
						ORDERSPAREPART _issue = _srv.ORDERSPAREPARTS.SingleOrDefault(x => x.spLine == SPLineId);
						_issue.qtyneed = IssueItem.qtyneed;
						_issue.uprice = IssueItem.uprice;
						_issue.discount = IssueItem.discount;
						_issue.netuprice = IssueItem.netuprice;
						_issue.totalprice = IssueItem.totalprice;
						_issue.itemremark = IssueItem.itemremark;
						_issue.modidt = IssueItem.modidt;
						_issue.modiuser = IssueItem.modiuser;
						_result = _srv.SaveChanges();
						_scope.Complete();
					}
					catch (OptimisticConcurrencyException ex)
					{
						throw new Exception("Can't update Issue item ", ex);
					}
				}
			}

			return _result;

		} // end UpdateIssueItemInfo

		public DataTable GetIssueItems(int IssueNo)
		{
			DataTable _result = new DataTable();

			var _docs = (from di in _erp.DOCINFOes
						 join trh in _erp.TRANSTKHs on di.DI_KEY equals trh.TRH_DI
						 join dept in _erp.DEPTTABs on trh.TRH_DEPT equals dept.DEPT_KEY
						 join trd in _erp.TRANSTKDs on trh.TRH_KEY equals trd.TRD_TRH
						 where di.DI_KEY == IssueNo
						 select new
						 {
							 IssueLineId = trh.TRH_KEY,
							 DocumentKey = di.DI_KEY,
							 ProjectNo = trh.TRH_PRJ,
							 OrderNumber = trh.TRH_REFER_IREF,
							 DocumentNo = di.DI_REF,
							 DocumentDate = di.DI_DATE,
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
						 }).ToList();
			if (_docs != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(_docs);
				//if (_docs.Count > 0)
				//{
				//}
			}
			return _result;

		} // end GetSparepartByIssue


		public DataTable GetServiceSparePartIssueList(int IssueDocKey, int YearIssue, int PeriodIssue)
		{
			DataTable _result = new DataTable();
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
						 }).OrderBy(x => x.DocNumber).ToList();

			if (_docs != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(_docs);
			}
			return _result;

		} // end GetServiceSparepartIssueList

		public DataTable GetSparePartItems(int OrderId)
		{
			DataTable _result = new DataTable();
			var rsp = (from r in _srv.ORDERSPAREPARTS
					   where r.orderid == OrderId
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
					   }).ToList();

			if (rsp != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(rsp.ToList());
			}

			return _result;

		} // end GetSparePartItems

		public DataTable GetSparePartItems(string OrderCode, int OrderId)
		{
			DataTable _result = new DataTable();
			var rsp = (from r in _srv.ORDERSPAREPARTS
					   where r.ordercode == OrderCode
					   && r.orderid == OrderId
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
					   }).ToList();

			if (rsp != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(rsp.ToList());
			}

			return _result;

		} // end GetSparePartItems


		public int SaveIssueItemToServiceOrder(int OrderId, string OrderNumber, string OrderCode, string IssueNumber, ref DataGridView Source)
		{
			int _result = 0;
			string _itemno = string.Empty;
			string _jobOrder = OrderCode + OrderNumber;

			using (var _scope = new System.Transactions.TransactionScope())
			{
				try
				{
					foreach (DataGridViewRow _dgr in Source.Rows)
					{
						_itemno = _dgr.Cells["ShipItemNo"].Value.ToString();
						var spItem = (from sp in _srv.ORDERSPAREPARTS
									  where sp.orderid == OrderId
									  && sp.issueno == IssueNumber
									  && sp.itemno == _itemno
									  select sp).FirstOrDefault();

						if (spItem == null)
						{
							ORDERSPAREPART _issueItem = new ORDERSPAREPART();
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

							_srv.ORDERSPAREPARTS.Add(_issueItem);
							_result += _srv.SaveChanges();
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
			{
				if (WriteJobOrderToIssueItems(_jobOrder, ref Source) > 0)
				{
					MessageBox.Show("Update ERP completed.....", "Update ERP");
				}
			}

			return _result;

		} // end SaveIssueItemToServiceOrder

		public int WriteJobOrderToIssueItems(string JobOrderNumber, ref DataGridView Source)
		{
			int _result = 0;
			int _issueLineId = 0;

			using (var _scope = new System.Transactions.TransactionScope())
			{
				try
				{
					foreach (DataGridViewRow dgr in Source.Rows)
					{
						// get issue line id
						if (_issueLineId != Convert.ToInt32(dgr.Cells["ISSUELINEID"].Value))
						{
							_issueLineId = Convert.ToInt32(dgr.Cells["ISSUELINEID"].Value);

							// create LINQ statement
							TRANSTKH _trh = _erp.TRANSTKHs.SingleOrDefault(x => x.TRH_KEY == _issueLineId);

							_trh.TRH_REFER_IREF = JobOrderNumber;
							_result += _erp.SaveChanges();
						}
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
