using OMW15.Shared;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Models.CastingModel
{
	public class BillingDAL
	{
		#region class field member

		private readonly OLDMOONEF1 _om;

		#endregion

		// CONSTRUCTOR
		public BillingDAL()
		{
			_om = new OLDMOONEF1();
		}

		#region class helper method

		private void updateBillingStatus()
		{
			using (var scope = new System.Transactions.TransactionScope())
			{
				try
				{
					_om.BILLS.AsEnumerable().Where(x => x.ISDELETE == false
					&& x.ISCANCEL == false
					&& x.ISCOMPLETE == false).ToList().ForEach(c =>
						{
							c.STATUS = (c.DUEDATE.Num2Date() < DateTime.Today ? "LATE" : "NORMAL");
						});

					_om.SaveChanges();
					scope.Complete();
				}
				catch { }
			}
		} // end updateBillingStatus

		public DataTable GetActiveBL()
		{
			// update status for active billing
			updateBillingStatus();

			var _result = new DataTable();

			var _bl = (from b in _om.BILLS.AsEnumerable()
					   join c in _om.CUSTOMERS on b.CUSTCODE equals c.CUSTCODE
					   where b.ISDELETE == false
							 && b.ISCANCEL == false
							 && b.ISCOMPLETE == false
							 && b.INVOICENO == ""
					   orderby b.BILLNO
					   select new
					   {
						   b.BILLID,
						   b.STATUS,
						   b.BILLNO,
						   BLDate = b.BILLDATE.Num2Date(),
						   BLDue = b.DUEDATE.Num2Date(),
						   b.CUSTCODE,
						   c.CUSTNAME,
						   b.TOTALVALUE,
						   b.DISCOUNT,
						   NETTOTAL = b.NETVALUE,
						   b.TOTALVAT,
						   b.TOTALAMOUNT
					   }).AsParallel();

			if (_bl != null)
				_result = _bl.ToDataTable();

			return _result;

		} // end GetActiveBL

		public BILL GetBillHeaderInfo(int BillId)
		{
			return _om.BILLS.Single(x => x.BILLID == BillId);

		} // end GetBillHeaderInfo

		public DataTable GetBillingLines(int BillId)
		{
			return _om.BILLLINES.Where(x => x.BILLID == BillId).OrderBy(x => x.SONO).AsEnumerable().Select(c => new
			{
				c.BILLLINGSEQ,
				c.BILLID,
				c.SALETYPE,
				c.SOSEQ,
				c.SONO,
				ORDERDATE = c.SODATE.Num2Date(),
				c.TOTALVALUE,
				c.DISCOUNT,
				c.NETVALUE,
				c.TOTALVAT,
				c.TOTALAMOUNT
			}).AsParallel().ToDataTable();

		} // end GetBillingLines

		public int UpdateBillHeaderInfo(BILL BL, ref DataGridView BLLines, ActionMode Mode)
		{
			var _result = 0;
			var _lastBLId = 0;
			var _billId = BL.BILLID;
			try
			{
				// Add Bill header 
				if (BL.BILLID == 0)
				{
					_om.BILLS.Add(BL);
					_result = _om.SaveChanges();

					// find latest BL-Number Id
					_lastBLId = _om.BILLS.Max(x => x.BILLID);

					// update to BL-Number in Bill-Header
					_om.BILLS.Single(x => x.BILLID == _lastBLId).BILLNO = "BL" + _lastBLId;

					_result = _om.SaveChanges();
				}
				else // Edit Bill header
				{
					var _bl = _om.BILLS.FirstOrDefault(x => x.BILLID == BL.BILLID);
					_bl.MODIDATE = BL.MODIDATE;
					_bl.MODIUSER = BL.MODIUSER;
					_bl.BILLDATE = BL.BILLDATE;
					_bl.DUEDATE = BL.DUEDATE;
					_bl.TOTALVALUE = BL.TOTALVALUE;
					_bl.DISCOUNT = BL.DISCOUNT;
					_bl.NETVALUE = BL.NETVALUE;
					_bl.TOTALVAT = BL.TOTALVAT;
					_bl.TOTALAMOUNT = BL.TOTALAMOUNT;
					_bl.TOTALTEXT = BL.TOTALTEXT;
					_bl.NUMOFDO = BL.NUMOFDO;
					_bl.SALETYPE = BL.SALETYPE.Value;
					_bl.STATUS = BL.STATUS;
					_bl.BILLCANCELDATE = BL.BILLCANCELDATE;
					_bl.CUSTID = BL.CUSTID;
					_bl.INVSEQ = BL.INVSEQ.Value;
					_bl.INVOICENO = BL.INVOICENO;
					_bl.INVDATE = _bl.INVDATE;
					_bl.COLLECTDATE = 0;
					_bl.TOTALWHTAX = BL.TOTALWHTAX;
					_bl.VATFACTOR = BL.VATFACTOR;
					_bl.TOTALPAYVALUE = BL.TOTALPAYVALUE;
					_bl.ISCANCEL = BL.ISCANCEL;
					_bl.ISCOMPLETE = BL.ISCOMPLETE;
					_bl.ISDELETE = BL.ISDELETE;

					_result = _om.SaveChanges();
				}
				// end Update BILL-Header

				// save BL items
				switch (Mode)
				{
					case ActionMode.Add:
						foreach (DataRow _dr in ((DataTable)BLLines.DataSource).Rows)
						{
							var _bLine = new BILLLINE();
							_bLine.AUDITUSER = omglobal.UserInfo;
							_bLine.MODIUSER = omglobal.UserInfo;
							_bLine.MODIDATE = DateTime.Now;
							_bLine.ISDELETE = false;
							_bLine.BILLID = _lastBLId;
							_bLine.SALETYPE = Convert.ToInt32(_dr["SALETYPE"]);
							_bLine.SODATE = Convert.ToDateTime(_dr["ORDERDATE"]).Date2Num();
							_bLine.SONO = _dr["SONO"].ToString();
							_bLine.SOSEQ = Convert.ToInt32(_dr["SOSEQ"]);
							_bLine.TOTALVALUE = Convert.ToDecimal(_dr["TOTALVALUE"]);
							_bLine.DISCOUNT = Convert.ToDecimal(_dr["DISCOUNT"]);
							_bLine.NETVALUE = Convert.ToDecimal(_dr["NETVALUE"]);
							_bLine.TOTALVAT = Convert.ToDecimal(_dr["TOTALVAT"]);
							_bLine.TOTALAMOUNT = Convert.ToDecimal(_dr["TOTALAMOUNT"]);

							_om.BILLLINES.Add(_bLine);
							_result += _om.SaveChanges();
						}
						break;
					case ActionMode.Edit:

						foreach (DataRow _dr in ((DataTable)BLLines.DataSource).Rows)
						{
							var _blineId = Convert.ToInt32(_dr["BILLLINGSEQ"]);
							if (_blineId > 0)
							{
								_om.BILLLINES.Where(x => x.BILLLINGSEQ == _blineId).ToList().ForEach(c =>
								{
									c.MODIDATE = DateTime.Now;
									c.MODIUSER = omglobal.UserInfo;
									c.BILLID = _billId;
									c.TOTALVALUE = Convert.ToDecimal(_dr["TOTALVALUE"]);
									c.DISCOUNT = Convert.ToDecimal(_dr["DISCOUNT"]);
									c.NETVALUE = Convert.ToDecimal(_dr["NETVALUE"]);
									c.TOTALVAT = Convert.ToDecimal(_dr["TOTALVAT"]);
									c.TOTALAMOUNT = Convert.ToDecimal(_dr["TOTALAMOUNT"]);
								});
								_om.SaveChanges();
							}
							else
							{
								var _bLine = new BILLLINE();
								_bLine.AUDITUSER = omglobal.UserInfo;
								_bLine.MODIUSER = omglobal.UserInfo;
								_bLine.MODIDATE = DateTime.Now;
								_bLine.ISDELETE = false;
								_bLine.BILLID = _billId;
								_bLine.SALETYPE = Convert.ToInt32(_dr["SALETYPE"]);
								_bLine.SODATE = Convert.ToDateTime(_dr["ORDERDATE"]).Date2Num();
								_bLine.SONO = _dr["SONO"].ToString();
								_bLine.SOSEQ = Convert.ToInt32(_dr["SOSEQ"]);
								_bLine.TOTALVALUE = Convert.ToDecimal(_dr["TOTALVALUE"]);
								_bLine.DISCOUNT = Convert.ToDecimal(_dr["DISCOUNT"]);
								_bLine.NETVALUE = Convert.ToDecimal(_dr["NETVALUE"]);
								_bLine.TOTALVAT = Convert.ToDecimal(_dr["TOTALVAT"]);
								_bLine.TOTALAMOUNT = Convert.ToDecimal(_dr["TOTALAMOUNT"]);

								_om.BILLLINES.Add(_bLine);
								_result += _om.SaveChanges();
							}
						}

						break;
				}

				// update SO
				((DataTable)BLLines.DataSource).AsEnumerable().Select(b => new
				{
					SOID = b.Field<int>("SOSEQ")
				}).ToList().ForEach(c =>
				{
					_om.SALEORDERS.Where(x => x.SOSEQ == c.SOID).ToList().ForEach(d =>
					{
						d.BILLSEQ = Mode == ActionMode.Add ? _lastBLId : _billId;
						d.BILLNO = "BL" + (Mode == ActionMode.Add ? _lastBLId.ToString() : _billId.ToString());
						d.BILLDATE = BL.BILLDATE;
						d.BILLDUEDATE = BL.DUEDATE;
						d.ISCOMPLETE = true;
					});
					_result += _om.SaveChanges();
				});
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't updating Bill Header Information !!!!", ex);
			}

			return _result;
		} // end UpdateBillHeaderInfo

		public int DeleteBill(int BillId)
		{
			var _result = 0;
			try
			{
				// create list of Billing lines that contain information of SaleOrder
				// and update SALEORDER 
				_om.BILLLINES.Where(b => b.BILLID == BillId).Select(l => new
				{
					l.SOSEQ
				}).ToList().ForEach(c =>
				{
					// update SaleOrderFirst
					_om.SALEORDERS.Where(x => x.SOSEQ == c.SOSEQ).ToList().ForEach(d =>
					{
						d.BILLDATE = 0;
						d.BILLDUEDATE = 0;
						d.BILLNO = "";
						d.BILLSEQ = 0;
						d.ISCOMPLETE = false;
					});
				});

				_result = _om.SaveChanges();

				// delete records from Bill-lines
				_om.BILLLINES.RemoveRange(_om.BILLLINES.Where(x => x.BILLID == BillId));
				_result += _om.SaveChanges();

				// delete bill header
				_om.BILLS.Remove(_om.BILLS.Single(x => x.BILLID == BillId));
				_result += _om.SaveChanges();

				// complete mission without error
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't delete the selected Bill...", ex);
			}

			return _result;
		} // end DeleteBill

		public DataTable GetBillingRecords(int BillId)
		{
			var _result = new DataTable();

			var _b = (from b in _om.BILLS.AsEnumerable()
					  join c in _om.CUSTOMERS on b.CUSTCODE equals c.CUSTCODE
					  join bl in _om.BILLLINES.AsEnumerable() on b.BILLID equals bl.BILLID
					  join so in _om.SALEORDERS on bl.SOSEQ equals so.SOSEQ
					  where b.ISCANCEL == false
							&& b.ISDELETE == false
							&& b.BILLID == BillId
					  orderby bl.SONO
					  select new BillInfoReportDAL
					  {
						  BillId = b.BILLID,
						  BillNo = b.BILLNO,
						  BillDate = b.BILLDATE.Num2Date(),
						  CustomerCode = b.CUSTCODE,
						  Customer = c.CUSTNAME,
						  BillDue = b.DUEDATE.Num2Date(),
						  DOCount = b.NUMOFDO,
						  TotalValue = b.TOTALVALUE,
						  TotalVAT = b.TOTALVAT,
						  TotalAmount = b.TOTALAMOUNT,
						  TotalAmountText = b.TOTALTEXT,
						  SONumber = bl.SONO,
						  DODate = bl.SODATE.Num2Date(),
						  SaleInfo = so.SALEDETAILS,
						  SOTotalValue = bl.TOTALVALUE,
						  SODiscount = bl.DISCOUNT,
						  SONetValue = bl.NETVALUE,
						  SOVAT = bl.TOTALVAT,
						  SOAmount = bl.TOTALAMOUNT
					  }).AsParallel();

			return _b.ToDataTable();
		} // end GetBillingRecords

		public DataTable GetWHTaxList()
		{
			return _om.SYSDATAs.Where(x => x.GROUPTITLE == "WHTAX").Select(s => new
			{
				KeyName = s.THKEYNAME,
				Value = s.KEYVALUE
			}).OrderBy(o => o.KeyName).AsParallel().ToDataTable();
		} // end GetWHTaxList

		public int UpdateBillCollectionValue(BILL BL)
		{
			var _result = 0;
			try
			{
				_om.BILLS.Where(x => x.BILLID == BL.BILLID).ToList().ForEach(c =>
				{
					c.ISCOMPLETE = BL.ISCOMPLETE;
					c.STATUS = BL.STATUS;
					c.INVSEQ = BL.INVSEQ;
					c.INVOICENO = BL.INVOICENO;
					c.INVDATE = BL.INVDATE;
					c.COLLECTDATE = BL.COLLECTDATE;
					c.TOTALWHTAX = BL.TOTALWHTAX;
					c.TOTALPAYVALUE = BL.TOTALPAYVALUE;
					c.MODIDATE = DateTime.Now;
					c.MODIUSER = omglobal.UserInfo;
				});

				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Error update Billing Collection....", ex);
			}
			return _result;
		} // end UpdateBillCollectionValue

		#endregion
	}
}