using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers;
using OMW15.Models;
using OMW15.Shared;
using OMW15.Views;

namespace OMW15.Controllers.CustomerController
{
	public class CustomerSearch 
	{
		private OLDMOONEF _om;
		private ERP _erp;

		public DataTable GetCustomerList(OMShareCustomerEnums.CustomerSearchOptions SearchOption, string SearchKey)
		{
			DataTable _dt = new DataTable();
			
			// find the customer-id from customer table in OLDMOON database
			var omCustomer = (from c in _om.CUSTOMER1
							  select new 
							  {
								  c.CUSTID,
								  c.CUSTCODE,
								  c.CUSTNAME
							  }).Where(x => SearchOption == OMShareCustomerEnums.CustomerSearchOptions.SearchByCustomerCode ? x.CUSTCODE.Contains(SearchKey) : x.CUSTNAME.Contains(SearchKey)).AsParallel();

				var _cust = (from _adb in _erp.ADDRBOOKs
							 join _ara in _erp.ARADDRESSes
							 on _adb.ADDB_KEY equals _ara.ARA_ADDB
							 join _ar in _erp.ARFILEs
							 on _ara.ARA_AR equals _ar.AR_KEY
							 join _arCat in _erp.ARCATs
							 on _ar.AR_ARCAT equals _arCat.ARCAT_KEY
							 select new
							 {
								 CustomerId = _ar.AR_KEY,
								 CustomerCode = _ar.AR_CODE,
								 CustomerName = _ar.AR_NAME,
								 Address1 = _adb.ADDB_ADDB_1,
								 Address2 = _adb.ADDB_ADDB_2,
								 Address3 = _adb.ADDB_ADDB_3,
								 Province = _adb.ADDB_PROVINCE,
								 Postal = _adb.ADDB_POST,
								 Phone = _adb.ADDB_PHONE,
								 Fax = _adb.ADDB_FAX,
								 Email = _adb.ADDB_EMAIL,
								 Web = _adb.ADDB_WEBSITE,
								 Branch = _adb.ADDB_BRANCH,
								 TaxId = _adb.ADDB_TAX_ID,
								 CategoryName = _arCat.ARCAT_NAME,
								 CategoryKey = _arCat.ARCAT_KEY,
								 CustomerCategoryKey = _ar.AR_ARCAT,
							 }).Where(x => SearchOption == OMShareCustomerEnums.CustomerSearchOptions.SearchByCustomerCode ? x.CustomerCode.Contains(SearchKey) : x.CustomerName.Contains(SearchKey)).AsParallel();

				var result = (from cl in omCustomer
							 join ce in _cust on cl.CUSTCODE equals ce.CustomerCode
							 where cl.CUSTCODE == ce.CustomerCode
							 select new
							 {
								 cl.CUSTID,
								 ce.CustomerId,
								 ce.CustomerCode,
								 ce.CustomerName,
								 ce.Address1,
								 ce.Address2,
								 ce.Address3,
								 ce.Province,
								 ce.Postal,
								 ce.Phone,
								 ce.Fax,
								 ce.Email,
								 ce.Web,
								 ce.Branch,
								 ce.TaxId,
								 ce.CategoryName,
								 ce.CategoryKey,
								 ce.CustomerCategoryKey
							 }).OrderBy(o=>o.CustomerName).AsParallel();

				_dt = OMControls.OMDataUtils.ToDataTable(result.ToList());
				
			return _dt;

		} // end GetCustomerList

		#region Constructor and Destructor
		public CustomerSearch()
		{
			_om = new OLDMOONEF();
			_erp = new ERP();
		}

		//protected virtual void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		// dispose managed resources
		//		_om.Dispose();
		//		_erp.Dispose();
		//	}
		//	// free native resources
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}

		#endregion
	}
}
