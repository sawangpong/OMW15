using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Transactions;
using OMW15.Models.SaleModel;
using OMW15.Shared;

namespace OMW15.Controllers.SaleController
{
	public class SaleQuotationController
	{
		public int GetMaxQuotationNumber(string QTPrefix)
		{
			return new SaleQTDAL().GetMaxQuotationNumber(DateTime.Today.Year, QTPrefix);
		} // end GetMaxQuotationNumber

		public int CopyMasterQuotation(int MasterQuotationId, string Currency, string QTPrefix)
		{
			var _result = 0;
			var _newQuotationId = 0;
			var _qtHeader = new SaleQTDAL().GetQuotationHeader(MasterQuotationId);

			_qtHeader.QT_ID = 0;
			_qtHeader.QT_PREFIX = QTPrefix;
			_qtHeader.QT_INBOUND = QTPrefix == "QI" ? false : true;
			_qtHeader.QT_MASTER = false;
			_qtHeader.QT_COUNT = GetMaxQuotationNumber(QTPrefix) + 1;
			_qtHeader.QT_NUMBER =
				OMShareMethods.GetOMNumberThaiFormat(_qtHeader.QT_COUNT);
			_qtHeader.QT_CURRENCY = Currency;
			_qtHeader.QT_DATE = DateTime.Today;
			_qtHeader.QT_VALIDATIONDATE = DateTime.Today.AddMonths(6);
			_qtHeader.QT_YEAR = DateTime.Today.Year;
			_qtHeader.QT_STATUS = (int) OMShareSaleEnum.QoutationStatus.Active;

			_qtHeader.QT_CUSTID = 0;
			_qtHeader.QT_ADDRESS = "";
			_qtHeader.QT_CONTACT_PERSON = "";
			_qtHeader.QT_CONTACTNO = "";
			_qtHeader.QT_COUNTRY = "";
			_qtHeader.QT_CUST_EMAIL = "";
			_qtHeader.QT_CUSTCODE = "";
			_qtHeader.QT_CUSTID = 0;
			_qtHeader.QT_CUSTOMER = "";
			_qtHeader.QT_EXTRADISCOUNT = 0.00m;
			_qtHeader.QT_REF_KEY = 0;
			_qtHeader.QT_REVISION = 0;
			_qtHeader.QT_SHIPPINGVALUE = 0.00m;
			_qtHeader.QT_TOTALAMOUNT = 0.00m;


			_qtHeader.AUDITUSER = omglobal.UserName;
			_qtHeader.MODIDATE = DateTime.Now;
			_qtHeader.MODIUSER = omglobal.UserName;


			if (new SaleQTDAL().InsertUpdateQuotationHeader(_qtHeader) > 0)
			{
				_newQuotationId = new SaleQTDAL().GetLatestQuotationHeaderId();

				// debug
				//MessageBox.Show(string.Format("New Quotation Id = {0}", _newQuotationId.ToString()), "DEBUG");
				// end debug

				// add the Quotation Line from the Master Quotation
				using (var scope = new TransactionScope())
				{
					var om = new OLDMOONEF1();
					var _ql = (from ql in om.QUOTATIONLLs
						where ql.QL_QT == MasterQuotationId
						select ql).ToList();

					foreach (var l in _ql.AsEnumerable())
						try
						{
							var _qtLines = new QUOTATIONLL();
							_qtLines.QL_QT = _newQuotationId;
							_qtLines.AUDITUSER = _qtHeader.AUDITUSER;
							_qtLines.MODIDATE = DateTime.Now;
							_qtLines.MODIUSER = _qtHeader.MODIUSER;
							_qtLines.QL_CURRENCY = Currency;
							_qtLines.QL_ITEMINFO = l.QL_ITEMINFO;
							_qtLines.QL_ITEMNAME = l.QL_ITEMNAME;
							_qtLines.QL_ITEMNO = l.QL_ITEMNO;
							_qtLines.QL_QTY = l.QL_QTY;
							_qtLines.QL_REFID = _newQuotationId;
							_qtLines.QL_TOTAL = l.QL_TOTAL;
							_qtLines.QL_UNIT = l.QL_UNIT;
							_qtLines.QL_UNITPRICE = l.QL_UNITPRICE;

							om.QUOTATIONLLs.Add(_qtLines);
							om.SaveChanges();

							_result += 1;
							if (_result == _ql.Count)
								scope.Complete();
						}
						catch (OptimisticConcurrencyException ex)
						{
							throw new Exception("Copy the quotation failed....", ex);
						}
				}
			}

			return _newQuotationId;
		} // end CopyMasterQuotation


		public int ClearUnpostedQuotationData(int QuotationId)
		{
			// HOW TO PROCESS CLEARING UN-POSTED QUOTATION DATA
			// 1. Find and delete data row from QUOTATIONLL table <=== Quotation KEY
			// 2. Find and delete data row from QUOTATIONHH table <=== Quotation KEY

			var _result = 0;

			if (new SaleQTDAL().DeleteMultipleQuotationLines(QuotationId) > 0)
				_result = new SaleQTDAL().DeleteQuotationHeader(QuotationId);

			return _result;
		} // end ClearUnpostedQuotationData
	}
}