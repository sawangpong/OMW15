using OMW15.Controllers.ToolController;
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
	public class SaleDAL
	{
		#region constructor
		private readonly OLDMOONEF1 _om;

		public SaleDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		#region class methods

		public DataTable DeliveryTermTable()
		{
			var _result = new DataTable();
			var _dc = new DataColumn("TERM", typeof(string));
			_result.Columns.Add(_dc);
			var _dr = _result.NewRow();
			_dr["TERM"] = "EX-WORK";
			_result.Rows.Add(_dr);

			_dr = _result.NewRow();
			_dr["TERM"] = "F.O.B.";
			_result.Rows.Add(_dr);

			_dr = _result.NewRow();
			_dr["TERM"] = "C&F";
			_result.Rows.Add(_dr);

			_dr = _result.NewRow();
			_dr["TERM"] = "C.F.R.";
			_result.Rows.Add(_dr);

			_dr = _result.NewRow();
			_dr["TERM"] = "C.I.F.";
			_result.Rows.Add(_dr);


			return _result;
		} // end DeliveryTermTable

		public DataTable GetSaleToCountry()
		{
			var _result = new DataTable();
			var _det = (from _pi in _om.PI_INVOICE
							orderby _pi.PI_COUNTRY
							select new
							{
								_pi.PI_COUNTRY
							}).AsNoTracking().Distinct();

			if (_det != null)
				_result = _det.ToDataTable();

			return _result;
		} // end GetDeliveryTerm

		public DataTable GetPaymentTerm()
		{
			var _result = new DataTable();
			var _pay = (from _pi in _om.PI_INVOICE
							orderby _pi.PI_PAYMENT_TERM
							select new
							{
								_pi.PI_PAYMENT_TERM
							}).AsNoTracking().Distinct();

			if (_pay != null)
				_result = _pay.ToDataTable();

			return _result;
		} // end GetPaymentTerm

		public DataTable GetDeliveryTime()
		{
			var _result = new DataTable();
			var _deti = (from _pi in _om.PI_INVOICE
							 orderby _pi.PI_DELIVERY_TIME
							 select new
							 {
								 _pi.PI_DELIVERY_TIME
							 }).AsNoTracking().Distinct();

			if (_deti != null)
				_result = _deti.ToDataTable();

			return _result;
		} // end GetDeliveryTime

		public DataTable GetDeliveryTerm()
		{
			var _result = new DataTable();
			var _det = (from _pi in _om.PI_INVOICE
							orderby _pi.PI_DELIVERY_TERM
							select new
							{
								_pi.PI_DELIVERY_TERM
							}).AsNoTracking().Distinct();

			if (_det != null)
				_result = _det.ToDataTable();

			return _result;
		} // end GetDeliveryTerm

		public DataTable GetPIYear()
		{
			var _result = new DataTable();

			var _piyr = (from pi in _om.PI_INVOICE
							 select new
							 {
								 pi.PI_YEAR
							 }).AsNoTracking().Distinct().OrderByDescending(x => x.PI_YEAR);

			if (_piyr != null)
				_result = _piyr.ToDataTable();

			return _result;
		} // end GetPIYear

		public DataTable GetPIList(int PIYear)
		{
			var _result = new DataTable();

			var _pis = (from pi in _om.PI_INVOICE
							orderby pi.PINO
							where pi.PI_YEAR == PIYear
							select new
							{
								pi.PIID,
								PI_Number = pi.PINO,
								pi.PI_DATE,
								Customer = pi.PI_CUSTNAME,
								Country = pi.PI_COUNTRY,
								Delivery_Term = pi.PI_DELIVERY_TERM,
								Delivery_Time = pi.PI_DELIVERY_TIME,
								Total_Values = pi.PI_LINE_TOTAL,
								Packing = pi.PI_PACKING,
								Delivery = pi.PI_DELIVERY,
								Total_Amount = pi.PI_TOTAL_VALUES
							}).AsNoTracking();

			if (_pis != null)
				_result = _pis.ToDataTable();

			return _result;
		} // end GetPIList


		public PI_INVOICE GetPIHeaderInfo(int PIId)
		{
			return _om.PI_INVOICE.Single(x => x.PIID == PIId);
		} // end GetPIHeaderInfo


		public int GetMaxPINumber(int PIYear)
		{
			var _result = 0;

			var _pi = (from p in _om.PI_INVOICE
						  where p.PI_YEAR == PIYear
						  select new
						  {
							  p.PI_COUNT
						  }).ToList();

			if (_pi.Count > 0)
				_result = _pi.Max(x => x.PI_COUNT);
			else
				_result = 0;

			return _result;
		} // end GetMaxPINumber


		public int UpdatePIHeader(PI_INVOICE PIHeader)
		{
			var _result = 0;

			using (var scope = new TransactionScope())
			{
				try
				{
					if (PIHeader.PIID == 0)
					{
						// insert PI header
						_om.PI_INVOICE.Add(PIHeader);
						_result = _om.SaveChanges();
					}
					else
					{
						// update PI header

						var pi = _om.PI_INVOICE.FirstOrDefault(x => x.PIID == PIHeader.PIID);
						pi.PI_CUSTID = PIHeader.PI_CUSTID;
						pi.PI_CUSTCODE = PIHeader.PI_CUSTCODE;
						pi.PI_CUSTNAME = PIHeader.PI_CUSTNAME;
						pi.PI_ADDRESS = PIHeader.PI_ADDRESS;
						pi.PI_COUNTRY = PIHeader.PI_COUNTRY;
						pi.PI_YEAR = PIHeader.PI_YEAR;
						pi.PI_DATE = PIHeader.PI_DATE;
						pi.PI_BANKINFO = PIHeader.PI_BANKINFO;
						pi.PI_CURRENCY = PIHeader.PI_CURRENCY;
						pi.PI_DELIVERY_TERM = PIHeader.PI_DELIVERY_TERM;
						pi.PI_DELIVERY_TIME = PIHeader.PI_DELIVERY_TIME;
						pi.PI_PAYMENT_TERM = PIHeader.PI_PAYMENT_TERM;
						pi.PI_LINE_TOTAL = PIHeader.PI_LINE_TOTAL;
						pi.PI_PACKING = PIHeader.PI_PACKING;
						pi.PI_DELIVERY = PIHeader.PI_DELIVERY;
						pi.PI_TOTAL_VALUES = PIHeader.PI_TOTAL_VALUES;
						pi.LASTUPDATE = PIHeader.LASTUPDATE;
						pi.MODIUSER = PIHeader.MODIUSER;

						_result = _om.SaveChanges();
					}

					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception(string.Format("Can't {0} Proforma Invoice..", PIHeader.PIID == 0 ? "insert" : "update "), ex);
				}
			}

			return _result;
		} // end UpdatePIHeader

		public int UpdateRefPIHeaderIdInPILine(int Index, int RefIndex)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				var _om = new OLDMOONEF1();
				try
				{
					_om.PI_ITEMS.Where(x => x.REF_INDEX == RefIndex).ToList().ForEach(c => c.PI_ID = Index);
					_om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't update PI-Line info", ex);
				}
			}
			return _result;
		} // end UpdateRefPIHeaderIdInPILine


		public int GetLatestPIHeaderId()
		{
			return _om.PI_INVOICE.Max(x => x.PIID);
		} // end GetLatestPIHeaderId


		public PI_ITEMS GetPIItemInfo(int Id)
		{
			return _om.PI_ITEMS.FirstOrDefault(x => x.PI_ITEM == Id);
		} // end GetPIItemInfo

		public DataTable GetPIItemList(int PIHeaderId)
		{
			var _result = new DataTable();
			var _pil = from pl in _om.PI_ITEMS
						  where pl.PI_ID == PIHeaderId
						  select new
						  {
							  pl.PI_ID,
							  pl.PI_ITEM,
							  ItemNo = pl.PI_ITEMNO,
							  Description = pl.PI_ITEMNAME,
							  Unit = pl.PI_ITEM_UNIT,
							  Qty = pl.PI_ITEM_QTY,
							  UnitPrice = pl.PI_ITEM_PRICE,
							  Amount = pl.PI_ITEM_AMOUNT,
							  Remark = pl.PI_ITEM_REMARK
						  };


			if (_pil != null)
				_result = _pil.ToDataTable();

			return _result;
		} // end GetPIItemList


		public DataTable GetBankName()
		{
			var _result = new DataTable();

			var _bank = (from b in _om.BANKS
							 orderby b.BANKNAME
							 select new
							 {
								 b.BANKID,
								 Name = b.BANKNAME + " " + b.ACCOUNTBRANCH + " " + b.ACCOUNTTYPE,
								 b.BANKNAME,
								 b.ACCOUNTBRANCH,
								 b.ACCOUNTTYPE,
								 b.ACCOUNTNAME,
								 b.ACCOUNTNO,
								 b.SWIFTCODE
							 }).AsNoTracking();

			if (_bank != null)
				_result = _bank.ToDataTable();
			return _result;
		} // end GetBankName


		public int InsertOrUpdatePILine(PI_ITEMS PISource)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					if (PISource.PI_ITEM == 0)
					{
						_om.PI_ITEMS.Add(PISource);
						_result = _om.SaveChanges();
					}
					else
					{
						var _p = _om.PI_ITEMS.FirstOrDefault(x => x.PI_ID == PISource.PI_ID);
						_p.PI_ITEM_AMOUNT = PISource.PI_ITEM_AMOUNT;
						_p.PI_ITEM_PRICE = PISource.PI_ITEM_PRICE;
						_p.PI_ITEM_QTY = PISource.PI_ITEM_QTY;
						_p.PI_ITEM_REMARK = PISource.PI_ITEM_REMARK;
						_p.PI_ITEM_UNIT = PISource.PI_ITEM_UNIT;
						_p.PI_ITEMNAME = PISource.PI_ITEMNAME;
						_p.PI_ITEMNO = PISource.PI_ITEMNO;
						_p.MODIUSER = PISource.MODIUSER;
						_p.LASTUPDATE = PISource.LASTUPDATE;

						_result = _om.SaveChanges();
					}
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception(
						string.Format("Can't {0} PI-Line, please check !!!!!", PISource.PI_ITEM == 0 ? "Insert" : "Edit"), ex);
				}
			}

			return _result;
		} // end InsertOrUpdatePILine

		public int DeleteMultiplePILineItems(int PIHeaderId)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.PI_ITEMS.RemoveRange(_om.PI_ITEMS.Where(x => x.REF_INDEX == PIHeaderId));
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't delete PI lines....", ex);
				}
			}


			return _result;
		} // end DeleteMultiplePILineItems

		public int DeletePILine(int PILineId)
		{
			var _result = 0;

			using (var scope = new TransactionScope())
			{
				try
				{
					_om.PI_ITEMS.Remove(_om.PI_ITEMS.Where(x => x.PI_ITEM == PILineId).FirstOrDefault());
					_result = _om.SaveChanges();

					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't remove the specify record", ex);
				}
			}

			return _result;
		} // end DeletePILine

		public BANKINFO GetBankInfo(int BankId)
		{
			return _om.BANKINFOes.FirstOrDefault(x => x.BK_ID == BankId);
		} // end GetBankInfo



		public DataTable GetYearSaleByGroup() //int groupNo)
		{
			return new DataConnect($"EXEC dbo.usp_OM_ERP_SALE_YEARSALE ", omglobal.SysConnectionString).ToDataTable;
		}


		public DataTable GetSaleSummary(int yearSale)
		{
			return new DataConnect($"EXEC dbo.usp_OM_ERP_SALE_SALEBYCAT {yearSale}", omglobal.SysConnectionString).ToDataTable;

		}

		public DataTable GetSaleSummaryByCategory(string category, int yearSale)
		{
			return new DataConnect($"EXEC dbo.usp_OM_ERP_SALE_YEARSALE_SUMMARY_BY_CAT '{category}',{yearSale}", omglobal.SysConnectionString).ToDataTable;
		}


		public DataTable GetSaleHistoryByCustomer(string customerCode)
		{
			return new DataConnect($"EXEC dbo.usp_OM_ERP_SALE_HISTORY '{customerCode}'", omglobal.SysConnectionString).ToDataTable;
		}

		#endregion

		#region Sale Contact

		public DataTable GetSaleContactSearchList(OMShareSaleEnum.SaleContactFilterType SearchType, string Filter)
		{
			var _result = new DataTable();

			var _scl = (from scon in _om.SALE_CONTACTS
							orderby scon.CONTACT_NAME
							select new
							{
								ID = scon.CONTACT_ID,
								NAME = scon.CONTACT_NAME,
								scon.CUSTID,
								scon.CUSTCODE,
								scon.COMPANY,
								scon.ADDRESS,
								scon.COUNTRY,
								scon.POSTAL,
								PERSON = scon.CONTACT_PERSON,
								scon.MOBILE,
								scon.TEL,
								scon.FAX,
								scon.EMAIL
							}).AsParallel();

			if (SearchType == OMShareSaleEnum.SaleContactFilterType.AllSaleContact)
			{
				if (_scl != null)
					_result = _scl.ToDataTable();
			}
			else
			{
				switch (SearchType)
				{
					case OMShareSaleEnum.SaleContactFilterType.SaleContactByCompany:
						_result = _scl.Where(x => x.COMPANY.ToUpper().Contains(Filter.ToUpper())).ToDataTable();
						break;
					case OMShareSaleEnum.SaleContactFilterType.SaleContactByName:
						_result = _scl.Where(x => x.NAME.ToUpper().Contains(Filter.ToUpper())).ToDataTable();
						break;
				}
			}

			return _result;
		} // end GetSaleContactList

		public DataTable GetSaleContactList()
		{
			var _result = new DataTable();

			var _scl = (from scon in _om.SALE_CONTACTS
							orderby scon.CONTACT_NAME
							select new
							{
								ID = scon.CONTACT_ID,
								NAME = scon.CONTACT_NAME,
								scon.COMPANY,
								scon.COUNTRY,
								PERSON = scon.CONTACT_PERSON,
								scon.MOBILE,
								scon.EMAIL
							}).AsNoTracking().AsParallel();

			if (_scl != null)
				_result = _scl.ToDataTable();
			return _result;
		} // end GetSaleContactList

		public SALE_CONTACTS GetSaleContactInfo(int ContactId)
		{
			return _om.SALE_CONTACTS.Single(x => x.CONTACT_ID == ContactId);
		} // end GetSaleContactInfo

		public int DeleteContact(int ContactId)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.SALE_CONTACTS.Remove(_om.SALE_CONTACTS.FirstOrDefault(x => x.CONTACT_ID == ContactId));
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (System.Data.Entity.Core.OptimisticConcurrencyException ex)
				{
					Alert.DisplayAlert("Can't delete selected contact !!!!!", ex.ToString());
				}
			}

			return _result;
		} // end DeleteContact

		public DataTable GetSaleContactCountry()
		{
			var _result = new DataTable();
			var scc = (from sc in _om.SALE_CONTACTS
						  orderby sc.COUNTRY
						  select new
						  {
							  sc.COUNTRY
						  }).AsNoTracking().Distinct().AsParallel();

			if (scc != null)
				_result = scc.ToDataTable();

			return _result;
		} // end GetPaymentTerm

		public int UpdateSaleContact(SALE_CONTACTS SaleContact)
		{
			var _result = 0;

			using (var scope = new TransactionScope())
			{
				try
				{
					// add SaleContact when CONTACT_ID = 0
					// otherwise update
					if (SaleContact.CONTACT_ID == 0)
					{
						_om.SALE_CONTACTS.Add(SaleContact);
						_result = _om.SaveChanges();
					}
					else
					{
						var scon = _om.SALE_CONTACTS.FirstOrDefault(x => x.CONTACT_ID == SaleContact.CONTACT_ID);
						scon.ADDRESS = SaleContact.ADDRESS;
						scon.COMPANY = SaleContact.COMPANY;
						scon.CONTACT_NAME = SaleContact.CONTACT_NAME;
						scon.CONTACT_PERSON = SaleContact.CONTACT_PERSON;
						scon.COUNTRY = SaleContact.COUNTRY;
						scon.CUSTCODE = SaleContact.CUSTCODE;
						scon.CUSTID = SaleContact.CUSTID;
						scon.EMAIL = SaleContact.EMAIL;
						scon.MOBILE = SaleContact.MOBILE;
						scon.POSTAL = SaleContact.POSTAL;
						scon.TEL = SaleContact.TEL;
						scon.FAX = SaleContact.FAX;

						_result = _om.SaveChanges();
					}

					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Update Sale Contact failed....", ex);
				}
			}

			return _result;
		} // end UpdateSaleContact

		#endregion

		#region QUOTATION

		#endregion
	}
}