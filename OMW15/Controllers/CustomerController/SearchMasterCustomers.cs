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
using System.Transactions;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;
using OMW15.Views;
using OMW15.Models;

namespace OMW15.Controllers.CustomerController
{

	public class SearchMasterCustomers 
	{
		private ERP _erp;

		#region class Constructor

		public SearchMasterCustomers()
		{
			_erp = new ERP();

		} // end constructor

		//protected virtual void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		// dispose managed resources
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

		#region public class method

		//
		// signature type as System.String
		//
		public DataTable GetMasterCustomer<T>(T Filter)
		{
			DataTable _dt = new DataTable();
			var _custs = (from _adb in _erp.ADDRBOOKs
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
							  District = _adb.ADDB_ADDB_3,
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
						  }).AsParallel();

			// check type of parameter
			if (Filter.GetType() == typeof(System.String))
			{
				string _filter = Filter.ToString();

				if (string.IsNullOrEmpty(_filter))
				{
					_dt = OMControls.OMDataUtils.ToDataTable(_custs);
				}
				else
				{
					var _result = (from c in _custs.AsParallel()
								   where c.CustomerName.Contains(_filter)
								   orderby c.CustomerName
								   select c);
					_dt = OMControls.OMDataUtils.ToDataTable(_result);
				}
			}
			else if (Filter.GetType() == typeof(System.Int32))
			{
				int _filter = Convert.ToInt32(Filter);
				var _result = (from c in _custs.AsParallel()
							   where c.CategoryKey.Equals(_filter)
							   orderby c.CustomerName
							   select c);

				_dt = OMControls.OMDataUtils.ToDataTable(_result);
			}

			return _dt;

		} // end GetMasterCustomer

		public DataTable GetERPCustomerCategory()
		{
			DataTable _result = new DataTable();
			var _cat = (from c in _erp.ARCATs
						orderby c.ARCAT_NAME
						select new
						{
							c.ARCAT_KEY,
							c.ARCAT_NAME
						}).AsParallel();
			if (_cat != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(_cat.ToList());
			}
			return _result;

		} // end GetERPCustomerCategory

		#endregion



		#region static class methods

		public static bool FindExistCustomerInLocalDB(string CustomerCode)
		{
			bool _result = false;
			using (OLDMOONEF _om = new OLDMOONEF())
			{
				var cust = (from c in _om.CUSTOMER1
							where c.CUSTCODE.Trim() == CustomerCode.Trim()
							select c).FirstOrDefault();

				if (cust != null)
				{
					_result = true;
				}
			}

			return _result;

		} // end FindExistCustomerInLocalDB

		public static int InsertCustomerForLocalDB(CUSTOMER1 Customer)
		{
			int _result = 0;

			using (var scope = new System.Transactions.TransactionScope())
			{
				OLDMOONEF _om = new OLDMOONEF();
				try
				{
					_om.CUSTOMER1.Add(Customer);
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					_result = 0;
					//scope.Dispose();
					throw new Exception("Insert Customer record into local DB failed.....", ex);
				}
			}

			return _result;

		} // end InsertCustomerForLocalDB

		public static int UpdateCustomerForLocalDB(CUSTOMER1 Customer, string CustomerCode)
		{
			int _result = 0;

			using (var scope = new System.Transactions.TransactionScope())
			{
				OLDMOONEF _om = new OLDMOONEF();
				CUSTOMER1 cust = _om.CUSTOMER1.FirstOrDefault(x => x.CUSTCODE == CustomerCode);
				try
				{
					if (cust != null)
					{
						cust.CUSTTAXID = Customer.CUSTTAXID;
						cust.CUSTNAME = Customer.CUSTNAME;
						cust.ADDRESS = Customer.ADDRESS;
						cust.POSTAL = Customer.POSTAL;
						cust.DISTRICT = Customer.DISTRICT;
						cust.PROVINCE = Customer.PROVINCE;
						cust.CONTACTPERSON = Customer.CONTACTPERSON;
						cust.CUSTEMAIL = Customer.CUSTEMAIL;
						cust.CUSTWWW = Customer.CUSTWWW;
						cust.TEL = Customer.TEL;
						cust.FAX = Customer.FAX;
						cust.CREDITLIMIT = Customer.CREDITLIMIT;
						cust.MATERIALLIMIT = Customer.MATERIALLIMIT;
						cust.MODIUSER = Customer.MODIUSER;
						cust.MODIDATE = Customer.MODIDATE;
						_result = _om.SaveChanges();
						scope.Complete();
					}
				}
				catch (OptimisticConcurrencyException ex)
				{
					_result = 0;
					throw new Exception("Update Customer record into local DB failed.....", ex);
				}
			}

			return _result;

		} // end UpdateCustomerForLocalDB

		#endregion
	}
}
