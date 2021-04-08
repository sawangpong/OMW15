using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Transactions;

namespace OMW15.Models.SaleModel
{
	public class SaleQTDAL
	{
		#region class field

		private readonly OLDMOONEF1 _om;

		#endregion

		#region constructor

		#region constructor

		public SaleQTDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		#endregion

		#region class helper method

		public DataTable GetQuotationList(OMShareSaleEnum.QuotationType QTType)
		{
			return new DataConnect().GetDataTable($"EXEC dbo.usp_OM_SALE_QUOTATION_LIST @qttype={(int)QTType}");
			#region UNUSED
			/*
			var _qtType = (int)QTType;
			var _result = new DataTable();

			var qt = (from q in _om.QUOTATIONHHs
						 orderby q.QT_NUMBER
						 select new
						 {
							 q.QT_ID,
							 MASTER = q.QT_MASTER ? "Y" : "N",
							 q.QT_STATUS,
							 STATUS =
							 q.QT_STATUS == (int)OMShareSaleEnum.QoutationStatus.Active
								 ? OMShareSaleEnum.QoutationStatus.Active.ToString()
								 : (q.QT_STATUS == (int)OMShareSaleEnum.QoutationStatus.Expire
									 ? OMShareSaleEnum.QoutationStatus.Expire.ToString()
									 : (q.QT_STATUS == (int)OMShareSaleEnum.QoutationStatus.Drop
										 ? OMShareSaleEnum.QoutationStatus.Drop.ToString()
										 : (q.QT_STATUS == (int)OMShareSaleEnum.QoutationStatus.Ordered
											 ? OMShareSaleEnum.QoutationStatus.Ordered.ToString()
											 : "N/A"))),
							 q.QT_PREFIX,
							 NUMBER = q.QT_PREFIX + q.QT_NUMBER + (q.QT_REVISION > 0 ? "/R" + q.QT_REVISION : ""),
							 DATE = q.QT_DATE,
							 VALIDDATE = q.QT_VALIDATIONDATE,
							 CUSTOMER = q.QT_CUSTOMER,
							 SALEMAN = q.QT_SALE_PERSON,
							 NET_VALUE = q.QT_TOTALNETTVALUES,
							 VAT = q.QT_VATVALUES,
							 GOODSAMOUNT = q.QT_TOTALGOODSAMT,
							 PACKING = q.QT_PACKINGVALUE,
							 DELIVERY = q.QT_SHIPPINGVALUE,
							 TOTALAMOUNT = q.QT_TOTALAMOUNT,
							 CURRENCY = q.QT_CURRENCY
						 }).AsNoTracking();

			switch (QTType)
			{
				case OMShareSaleEnum.QuotationType.Master:
					_result = qt.Where(x => x.MASTER == "Y").ToDataTable();
					break;

				case OMShareSaleEnum.QuotationType.Local:
					_result = qt.Where(x => x.QT_PREFIX == "QL").ToDataTable();
					break;

				case OMShareSaleEnum.QuotationType.International:
					_result = qt.Where(x => x.QT_PREFIX == "QI").ToDataTable();
					break;
				default:
					_result = qt.ToDataTable();
					break;
			}

			return _result;
			*/
			#endregion
		} // end GetQuotationList


		public DataTable GetMasterQuotationList(string CurrencyCode)
		{
			var _result = new DataTable();

			var qt = (from q in _om.QUOTATIONHHs
						 orderby q.QT_NUMBER
						 where q.QT_MASTER && q.QT_CURRENCY == CurrencyCode
						 select new
						 {
							 ID = q.QT_ID,
							 NUMBER = q.QT_PREFIX + q.QT_NUMBER + (q.QT_REVISION > 0 ? "/R" + q.QT_REVISION : ""),
							 MASTER = q.QT_CUSTOMER,
							 SALEMAN = q.QT_SALE_PERSON,
							 CURRENCY = q.QT_CURRENCY,
							 EXPIRED = q.QT_VALIDATIONDATE
						 }).AsNoTracking();

			if (qt != null)
				_result = qt.ToDataTable();

			return _result;
		} // end GetMasterQuotationList


		public DataTable GetMasterQuotationItem(string CurrencyCode)
		{
			var _result = new DataTable();

			var qi = (from q in _om.QUOTATIONLLs
						 orderby q.QL_ITEMNO
						 where q.QL_CURRENCY == CurrencyCode
						 select new
						 {
							 ItemNo = q.QL_ITEMNO,
							 ItemName = q.QL_ITEMNAME,
							 ItemInfo = q.QL_ITEMINFO,
							 Unit = q.QL_UNIT,
							 Qty = q.QL_QTY,
							 UnitPrice = q.QL_UNITPRICE,
							 LineTotal = q.QL_TOTAL,
							 Curr = q.QL_CURRENCY
						 }).Distinct();

			if (qi != null)
				_result = qi.ToDataTable();

			return _result;
		} // end GetMasterQuotationItem

		public int GetLatestQuotationHeaderId()
		{
			return _om.QUOTATIONHHs.Max(x => x.QT_ID);
		} // end GetLatestQuotationHeaderId

		public QUOTATIONHH GetQuotationHeader(int QTHeaderId)
		{
			return _om.QUOTATIONHHs.FirstOrDefault(x => x.QT_ID == QTHeaderId);

		} // GetQuotationHeader

		public QUOTATIONLL GetQuotationItem(int QTLineItem)
		{
			return _om.QUOTATIONLLs.FirstOrDefault(x => x.QL_ID == QTLineItem);
		} // end GetQuotationItem

		public DataTable GetQuotationItems(int QuotationId)
		{
			var _result = new DataTable();

			var ql = from q in _om.QUOTATIONLLs
						orderby q.QL_ID
						where q.QL_QT == QuotationId
						select new
						{
							ID = q.QL_ID,
							REFID = q.QL_QT,
							ITEMNO = q.QL_ITEMNO,
							ITEMNAME = q.QL_ITEMNAME,
							ITEMINFO = q.QL_ITEMINFO,
							UNIT = q.QL_UNIT,
							QTY = q.QL_QTY,
							CURR = q.QL_CURRENCY,
							UNITPRICE = q.QL_UNITPRICE,
							TOTAL = q.QL_TOTAL,
							q.AUDITUSER,
							q.MODIUSER,
							MODIDATE = q.MODIDATE.Value
						};

			if (ql != null)
				_result = ql.ToDataTable();

			return _result;
		} // end GetQuotationItems

		public int UpdateQTLine(QUOTATIONLL Item)
		{
			var _result = 0;

			using (var scope = new TransactionScope())
			{
				try
				{
					if (Item.QL_ID == 0)
					{
						_om.QUOTATIONLLs.Add(Item);
						_result = _om.SaveChanges();
					}
					else
					{
						var ql = (from q in _om.QUOTATIONLLs
									 where q.QL_ID == Item.QL_ID
									 select q).FirstOrDefault();
						ql.QL_REFID = Item.QL_REFID;
						ql.QL_QT = Item.QL_QT;
						ql.QL_ITEMINFO = Item.QL_ITEMINFO;
						ql.QL_ITEMNAME = Item.QL_ITEMNAME;
						ql.QL_ITEMNO = Item.QL_ITEMNO;
						ql.QL_QTY = Item.QL_QTY;
						ql.QL_TOTAL = Item.QL_TOTAL;
						ql.QL_UNIT = Item.QL_UNIT;
						ql.QL_UNITPRICE = Item.QL_UNITPRICE;
						ql.MODIUSER = Item.MODIUSER;
						ql.MODIDATE = Item.MODIDATE;

						_result = _om.SaveChanges();
					}
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't update Quotation Item info.", ex);
				}
			}


			return _result;
		} // end UpdateQTLine

		public int DeleteQuotationHeader(int QuotationId)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.QUOTATIONHHs.Remove(_om.QUOTATIONHHs.Where(x => x.QT_ID == QuotationId).FirstOrDefault());
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't clearing the specify <header> data", ex);
				}
			}

			return _result;
		} //  end DeleteQuotationHeader

		public int DeleteMultipleQuotationLines(int QuotationId)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.QUOTATIONLLs.RemoveRange(_om.QUOTATIONLLs.Where(x => x.QL_QT == QuotationId));
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't clearing the specify <Line> data", ex);
				}
			}

			return _result;
		} // end DeleteMultipleQuotationLines

		public int DeleteQuotationLine(int QuotationLineId)
		{
			var _result = 0;

			using (var scope = new TransactionScope())
			{
				try
				{
					_om.QUOTATIONLLs.Remove(_om.QUOTATIONLLs.Where(x => x.QL_ID == QuotationLineId).FirstOrDefault());
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't delete the record, try again.....", ex);
				}
			}

			return _result;
		} // end DeleteQuotationLine


		public int GetMaxQuotationNumber(int QTYear, string QTPrefix)
		{
			var _result = 0;

			var _qt = (from q in _om.QUOTATIONHHs
						  where q.QT_PREFIX == QTPrefix
								&& q.QT_YEAR == QTYear
						  select new
						  {
							  q.QT_COUNT
						  }).ToList();

			if (_qt.Count > 0)
				_result = _qt.Max(x => x.QT_COUNT);
			else
				_result = 0;

			return _result;
		} // end GetMaxPINumber


		public int InsertUpdateQuotationHeader(QUOTATIONHH QT)
		{
			var _result = 0;

			try
			{
				// QT_ID == 0  -> new record, otherwise update
				if (QT.QT_ID == 0)
				{
					_om.QUOTATIONHHs.Add(QT);
				}
				else
				{
					var qt = (from qh in _om.QUOTATIONHHs
								 where qh.QT_ID == QT.QT_ID
								 select qh).FirstOrDefault();

					// mapping data
					qt.QT_INBOUND = QT.QT_INBOUND;
					qt.QT_MASTER = QT.QT_MASTER;

					qt.QT_STATUS = QT.QT_STATUS;
					qt.QT_PREFIX = QT.QT_PREFIX;
					qt.QT_NUMBER = QT.QT_NUMBER;
					qt.QT_REVISION = QT.QT_REVISION;
					qt.QT_YEAR = QT.QT_YEAR;
					qt.QT_DATE = QT.QT_DATE;
					qt.QT_VALIDATIONDATE = QT.QT_VALIDATIONDATE;
					qt.QT_BANKINFO = QT.QT_BANKINFO;
					qt.QT_CURRENCY = QT.QT_CURRENCY;
					qt.QT_CONTACT_PERSON = QT.QT_CONTACT_PERSON;
					qt.QT_CUSTID = QT.QT_CUSTID;
					qt.QT_CUSTCODE = QT.QT_CUSTCODE;
					qt.QT_CUSTOMER = QT.QT_CUSTOMER;
					qt.QT_CONTACTNO = QT.QT_CONTACTNO;
					qt.QT_CUST_EMAIL = QT.QT_CUST_EMAIL;
					qt.QT_ADDRESS = QT.QT_ADDRESS;
					qt.QT_COUNTRY = QT.QT_COUNTRY;
					qt.QT_SALE_PERSON = QT.QT_SALE_PERSON;
					qt.QT_SALE_CONTACTNO = QT.QT_SALE_CONTACTNO;
					qt.QT_SALE_EMAIL = QT.QT_SALE_EMAIL;
					qt.QT_DELIVERY_TERM = QT.QT_DELIVERY_TERM;
					qt.QT_DELIVERY_TIME = QT.QT_DELIVERY_TIME;
					qt.QT_PAYMENT_TERM = QT.QT_PAYMENT_TERM;
					qt.QT_TRAINING = QT.QT_TRAINING;
					qt.QT_WARRANTY = QT.QT_WARRANTY;
					qt.QT_REMARK = QT.QT_REMARK;
					qt.QT_TOTALVALUEITEMS = QT.QT_TOTALVALUEITEMS;
					qt.QT_TOTALDISCOUNT = QT.QT_TOTALDISCOUNT;
					qt.QT_EXTRADISCOUNT = QT.QT_EXTRADISCOUNT;
					qt.QT_TOTALNETTVALUES = QT.QT_TOTALNETTVALUES;
					qt.QT_VATRATE = QT.QT_VATRATE;
					qt.QT_VATVALUES = QT.QT_VATVALUES;
					qt.QT_TOTALGOODSAMT = QT.QT_TOTALGOODSAMT;
					qt.QT_PACKINGVALUE = QT.QT_PACKINGVALUE;
					qt.QT_SHIPPINGVALUE = QT.QT_SHIPPINGVALUE;
					qt.QT_TOTALAMOUNT = QT.QT_TOTALAMOUNT;
					qt.MODIUSER = QT.MODIUSER;
					qt.MODIDATE = QT.MODIDATE;

				}
				_result = _om.SaveChanges();

			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception($"Can't {(QT.QT_ID == 0 ? "Insert" : "Update")} the record, try again....", ex);
			}

			return _result;
		} // end InsertUpdateQuotationHeader

		public int UpdateRefQTHeaderIdInQTLine(int Index, int RefIndex)
		{
			var _result = 0;
			try
			{
				_om.QUOTATIONLLs.Where(x => x.QL_REFID == RefIndex).ToList().ForEach(c => c.QL_QT = Index);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update the reference Quotation Header Index", ex);
			}

			return _result;
		} // end UpdateRefQTHeaderIdInQTLine


		public DataTable GetQuotationCountry()
		{
			var _result = new DataTable();

			var c = (from qc in _om.QUOTATIONHHs
						orderby qc.QT_COUNTRY
						select new
						{
							Value = qc.QT_COUNTRY
						}).Distinct();

			if (c != null)
				_result = c.ToDataTable();

			return _result;
		} // end GetQuotationCountry


		public DataTable GetQuotationDeliveryTime()
		{
			var _result = new DataTable();

			var c = (from qc in _om.QUOTATIONHHs
						orderby qc.QT_DELIVERY_TIME
						select new
						{
							Value = qc.QT_DELIVERY_TIME
						}).Distinct();

			if (c != null)
				_result = c.ToDataTable();

			return _result;
		} // end GetQuotationDeliveryTime


		public DataTable GetQuotationDeliveryTerm()
		{
			var _result = new DataTable();

			var c = (from qc in _om.QUOTATIONHHs
						orderby qc.QT_DELIVERY_TERM
						select new
						{
							Value = qc.QT_DELIVERY_TERM
						}).Distinct();

			if (c != null)
				_result = c.ToDataTable();

			return _result;
		} // end GetQuotationDeliveryTerm


		public DataTable GetQuotationPaymentTerm()
		{
			var _result = new DataTable();

			var c = (from qc in _om.QUOTATIONHHs
						orderby qc.QT_PAYMENT_TERM
						select new
						{
							Value = qc.QT_PAYMENT_TERM
						}).Distinct();

			if (c != null)
				_result = c.ToDataTable();

			return _result;
		} // end GetQuotationPaymentTerm


		public DataTable GetQuotationTraining()
		{
			var _result = new DataTable();

			var c = (from qc in _om.QUOTATIONHHs
						orderby qc.QT_TRAINING
						select new
						{
							Value = qc.QT_TRAINING
						}).Distinct();

			if (c != null)
				_result = c.ToDataTable();

			return _result;
		} // end GetQuotationTraining


		public DataTable GetQuotationWarrantyTerm()
		{
			var _result = new DataTable();

			var c = (from qc in _om.QUOTATIONHHs
						orderby qc.QT_WARRANTY
						select new
						{
							Value = qc.QT_WARRANTY
						}).Distinct();

			if (c != null)
				_result = c.ToDataTable();

			return _result;
		} // end GetQuotationWarrantyTerm

		#endregion
	}
}