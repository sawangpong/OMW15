using OMW15.Controllers.ToolController;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OMW15.Models.CustomerModel
{
	public class CustomerDAL
	{
		private readonly ERP _erp;
		private readonly OLDMOONEF1 _om;

		#region Constructor and Destructor

		public CustomerDAL()
		{
			_om = new OLDMOONEF1();
			_erp = new ERP();
		}

		#endregion

		public DataTable FindNoneExistLocalCustomers(string connectionString)
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine(" EXEC dbo.usp_OM_ERP_FindNonExistCustomer");
			return new DataConnect(s.ToString(), connectionString).ToDataTable;

			// create local customer list
			//var _lc = _om.CUSTOMERS.OrderBy(o => o.CUSTCODE).Select(x => x.CUSTCODE).AsNoTracking().AsParallel().ToList();
			//// create list of master customer in ERP
			//var _mc = (from ar in _erp.ARFILEs
			//		   orderby ar.AR_CODE
			//		   where !_lc.Contains(ar.AR_CODE)
			//		   select new
			//		   {
			//			   CUSTCODE = ar.AR_CODE,
			//			   CUSTNAME = ar.AR_NAME
			//		   }).AsParallel();
			//if (_mc != null)
			//	_result = _mc.ToDataTable();
			//return _result;

		} // end AsyncFindNoneExistLocalCustomers

		//public async Task<DataTable> GetCustomerListAsync(OMShareCustomerEnums.CustomerSearchOptions SearchOption,
		//	string SearchKey)
		//{
		//	return await Task.Run(() =>
		//	{
		//		// find the customer-id from customer table in OLDMOON database
		//		var omCustomer = (from c in _om.CUSTOMERS.AsNoTracking()
		//						  select new
		//						  {
		//							  c.CUSTID,
		//							  c.CUSTCODE,
		//							  c.CUSTNAME
		//						  })
		//						  .Where(
		//							x =>
		//				SearchOption == OMShareCustomerEnums.CustomerSearchOptions.SearchByCustomerCode
		//					? x.CUSTCODE.Contains(SearchKey)
		//					: x.CUSTNAME.Contains(SearchKey)).AsParallel();

		//		var _erpCust = (from _adb in _erp.ADDRBOOKs
		//						join _ara in _erp.ARADDRESSes on _adb.ADDB_KEY equals _ara.ARA_ADDB
		//						join _ar in _erp.ARFILEs on _ara.ARA_AR equals _ar.AR_KEY
		//						join _arCat in _erp.ARCATs on _ar.AR_ARCAT equals _arCat.ARCAT_KEY
		//						where _ara.ARA_DEFAULT == "Y"
		//						select new
		//						{
		//							ERPCustomerId = _ar.AR_KEY,
		//							CustomerCode = _ar.AR_CODE,
		//							CustomerName = _ar.AR_NAME,
		//							Address1 = _adb.ADDB_ADDB_1,
		//							Address2 = _adb.ADDB_ADDB_2,
		//							Address3 = _adb.ADDB_ADDB_3,
		//							Province = _adb.ADDB_PROVINCE,
		//							Postal = _adb.ADDB_POST,
		//							Phone = _adb.ADDB_PHONE,
		//							Fax = _adb.ADDB_FAX,
		//							Email = _adb.ADDB_EMAIL,
		//							Web = _adb.ADDB_WEBSITE,
		//							Branch = _adb.ADDB_BRANCH,
		//							TaxId = _adb.ADDB_TAX_ID,
		//							CategoryName = _arCat.ARCAT_NAME,
		//							CategoryKey = _arCat.ARCAT_KEY,
		//							CustomerCategoryKey = _ar.AR_ARCAT
		//						}).Where(
		//			x =>
		//				SearchOption == OMShareCustomerEnums.CustomerSearchOptions.SearchByCustomerCode
		//					? x.CustomerCode.Contains(SearchKey)
		//					: x.CustomerName.Contains(SearchKey)).AsNoTracking().AsParallel();

		//		var result = (from cl in omCustomer
		//					  join ce in _erpCust on cl.CUSTCODE equals ce.CustomerCode
		//					  where cl.CUSTCODE == ce.CustomerCode
		//					  select new
		//					  {
		//						  InternalCustId = cl.CUSTID,
		//						  ce.ERPCustomerId,
		//						  ce.CustomerCode,
		//						  ce.CustomerName,
		//						  ce.Address1,
		//						  ce.Address2,
		//						  ce.Address3,
		//						  ce.Province,
		//						  ce.Postal,
		//						  ce.Phone,
		//						  ce.Fax,
		//						  ce.Email,
		//						  ce.Web,
		//						  ce.Branch,
		//						  ce.TaxId,
		//						  ce.CategoryName,
		//						  ce.CategoryKey,
		//						  ce.CustomerCategoryKey
		//					  }).OrderBy(o => o.CustomerName).AsParallel();

		//		return result.ToDataTable();
		//	});

		//} // end GetCustomerListAsync

		//
		// signature type as System.String
		//

		//public DataTable GetMasterCustomer<T>(T Filter)
		//{
		//	var _dt = new DataTable();
		//	var _custs = (from _adb in _erp.ADDRBOOKs
		//				  join _ara in _erp.ARADDRESSes on _adb.ADDB_KEY equals _ara.ARA_ADDB
		//				  join _ar in _erp.ARFILEs on _ara.ARA_AR equals _ar.AR_KEY
		//				  join _arCat in _erp.ARCATs on _ar.AR_ARCAT equals _arCat.ARCAT_KEY
		//				  where _ara.ARA_DEFAULT == "Y"
		//				  orderby _ar.AR_NAME
		//				  select new
		//				  {
		//					  CustomerId = _ar.AR_KEY,
		//					  CustomerCode = _ar.AR_CODE,
		//					  CustomerName = _ar.AR_NAME,
		//					  Address1 = _adb.ADDB_ADDB_1,
		//					  Address2 = _adb.ADDB_ADDB_2,
		//					  District = _adb.ADDB_ADDB_3,
		//					  Province = _adb.ADDB_PROVINCE,
		//					  Postal = _adb.ADDB_POST,
		//					  Phone = _adb.ADDB_PHONE,
		//					  Fax = _adb.ADDB_FAX,
		//					  Email = _adb.ADDB_EMAIL,
		//					  Web = _adb.ADDB_WEBSITE,
		//					  Branch = _adb.ADDB_BRANCH,
		//					  TaxId = _adb.ADDB_TAX_ID,
		//					  CategoryName = _arCat.ARCAT_NAME,
		//					  CategoryKey = _arCat.ARCAT_KEY,
		//					  CustomerCategoryKey = _ar.AR_ARCAT
		//				  }).AsNoTracking().AsParallel();

		//	// check type of parameter
		//	if (Filter.GetType() == OMCommonTypes.TypeOfString)
		//	{
		//		var _filter = Filter.ToString();

		//		if (string.IsNullOrEmpty(_filter))
		//		{
		//			_dt = _custs.ToDataTable();
		//		}
		//		else
		//		{
		//			var _result = (from c in _custs
		//						   where c.CustomerName.Contains(_filter)
		//						   select c).AsParallel();
		//			_dt = _result.ToDataTable();
		//		}
		//	}
		//	else if (Filter.GetType() == OMCommonTypes.TypeOfInt32)
		//	{
		//		var _filter = Convert.ToInt32(Filter);
		//		var _result = (from c in _custs
		//					   where c.CategoryKey.Equals(_filter)
		//					   select c).AsParallel();

		//		_result.ToDataTable();
		//	}

		//	return _dt;

		//} // end GetMasterCustomer

		public async Task<DataTable> GetMasterCustomerAsync(string connectionString, string filter = "''", OMShareCustomerEnums.CustomerSearchOptions SearchOption = OMShareCustomerEnums.CustomerSearchOptions.SearchNone)
		{
			return await Task.Run(() =>
			{
				StringBuilder s = new StringBuilder();
				int _searchOption = (int)SearchOption;
				//string _filter = string.IsNullOrEmpty(filter) ? "''" : filter;
				s.AppendLine($" EXEC dbo.usp_OM_ERP_CUSTOMERS ");
				s.AppendLine($" @FilterText = '{filter}',");
				s.AppendLine($" @SearchType = {_searchOption}");
				return new DataConnect(s.ToString(), connectionString).ToDataTable;
			});
		}

		//public DataTable GetMasterCustomer<T>(string[] Filter, OMShareCustomerEnums.CustomerSearchOptions SearchOption)
		//{
		//	var _dt = new DataTable();
		//	var _custs = (from _adb in _erp.ADDRBOOKs
		//				  join _ara in _erp.ARADDRESSes
		//				  on _adb.ADDB_KEY equals _ara.ARA_ADDB
		//				  join _ar in _erp.ARFILEs
		//				  on _ara.ARA_AR equals _ar.AR_KEY
		//				  join _arCat in _erp.ARCATs
		//				  on _ar.AR_ARCAT equals _arCat.ARCAT_KEY
		//				  orderby _ar.AR_NAME
		//				  select new
		//				  {
		//					  CustomerId = _ar.AR_KEY,
		//					  CustomerCode = _ar.AR_CODE,
		//					  CustomerName = _ar.AR_NAME,
		//					  Address1 = _adb.ADDB_ADDB_1,
		//					  Address2 = _adb.ADDB_ADDB_2,
		//					  District = _adb.ADDB_ADDB_3,
		//					  Province = _adb.ADDB_PROVINCE,
		//					  Postal = _adb.ADDB_POST,
		//					  Phone = _adb.ADDB_PHONE,
		//					  Fax = _adb.ADDB_FAX,
		//					  Email = _adb.ADDB_EMAIL,
		//					  Web = _adb.ADDB_WEBSITE,
		//					  Branch = _adb.ADDB_BRANCH,
		//					  TaxId = _adb.ADDB_TAX_ID,
		//					  CategoryName = _arCat.ARCAT_NAME,
		//					  CategoryKey = _arCat.ARCAT_KEY,
		//					  CustomerCategoryKey = _ar.AR_ARCAT
		//				  }).AsNoTracking().AsParallel();

		//	if (Filter == null)
		//		_dt = _custs.ToDataTable();
		//	else
		//		switch (SearchOption)
		//		{
		//			case OMShareCustomerEnums.CustomerSearchOptions.SearchByCustomerCode:
		//				var _custByCode = (from c in _custs
		//								   where Filter.Contains(c.CustomerCode)
		//								   select c).AsParallel();
		//				_dt = _custByCode.ToDataTable();
		//				break;
		//			case OMShareCustomerEnums.CustomerSearchOptions.SearchByCustomerName:
		//				var _custByName = (from c in _custs
		//								   where Filter.Contains(c.CustomerName)
		//								   select c).AsParallel();
		//				_dt = _custByName.ToDataTable();
		//				break;
		//		}

		//	return _dt;
		//} // end GetMasterCustomer

		public DataTable GetERPCustomerCategory()
		{
			var _result = new DataTable();
			var _cat = (from c in _erp.ARCATs
							orderby c.ARCAT_NAME
							select new
							{
								c.ARCAT_KEY,
								c.ARCAT_NAME
							}).AsNoTracking().AsParallel();
			if (_cat != null)
				_result = _cat.ToDataTable();
			return _result;

		} // end GetERPCustomerCategory

		public bool FindExistCustomerInLocalDB(string CustomerCode)
		{
			return _om.CUSTOMERS.Any(c => c.CUSTCODE == CustomerCode);
		} // end FindExistCustomerInLocalDB

		public int InsertCustomerForLocalDB(CUSTOMER Customer)
		{
			var _result = 0;

			using (var scope = new TransactionScope())
			{
				try
				{
					_om.CUSTOMERS.Add(Customer);
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Insert Customer record into local DB failed.....", ex);
				}
			}

			return _result;
		} // end InsertCustomerForLocalDB

		public int UpdateCustomerForLocalDB(CUSTOMER Customer, string CustomerCode)
		{
			var _result = 0;
			var cust = _om.CUSTOMERS.FirstOrDefault(x => x.CUSTCODE == CustomerCode);
			try
			{
				if (cust != null)
				{
					cust.CURRENCY = Customer.CURRENCY;
					cust.COUNTRY = Customer.COUNTRY;
					cust.VATRATE = Customer.VATRATE;
					cust.DISTRICT = Customer.DISTRICT;
					cust.CREDITLIMIT = Customer.CREDITLIMIT;
					cust.SALEPERSON = Customer.SALEPERSON;
					cust.MATERIALLIMIT = Customer.MATERIALLIMIT;
					cust.ISHEADQUARTERS = Customer.ISHEADQUARTERS;
					cust.VATABLE = Customer.VATABLE;
					cust.CUSTTAXID = Customer.CUSTTAXID;
					cust.CUSTNAME = Customer.CUSTNAME;
					cust.ADDRESS = Customer.ADDRESS;
					cust.POSTAL = Customer.POSTAL;
					cust.PROVINCE = Customer.PROVINCE;
					cust.CUSTWWW = Customer.CUSTWWW;
					cust.CONTACTPERSON = Customer.CONTACTPERSON;
					cust.CUSTEMAIL = Customer.CUSTEMAIL;
					cust.TEL = Customer.TEL;
					cust.FAX = Customer.FAX;
					cust.CELLPHONE1 = Customer.CELLPHONE1;
					cust.CUSTREMARK = Customer.CUSTREMARK;
					cust.MODIUSER = Customer.MODIUSER;
					cust.MODIDATE = Customer.MODIDATE;
					_result = _om.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Update Customer Information to local DB failed.....", ex);
			}

			return _result;
		} // end UpdateCustomerForLocalDB

		public CUSTOMER GetLocalCustomerRecord(string CustomerCode)
		{
			return _om.CUSTOMERS.Single(x => x.CUSTCODE == CustomerCode);
		} // end GetLocalCustomerRecord

		#region Customer Group

		public async Task<DataTable> GetCustomerGroupAsync()
		{
			return await Task.Run(() =>
			{
				var _cg = (from c in _om.CUSTOMERS
							  where c.CUSTGROUPKEY != ""
							  orderby c.CUSTNAME
							  select new
							  {
								  c.CUSTID,
								  c.CUSTGROUPKEY,
								  c.CUSTCODE,
								  c.CUSTNAME
							  }).Distinct().AsParallel();
				return _cg.ToDataTable();
			});
		} // end GetAsyncCustomerGroupAsync

		public async Task<DataTable> GetCustomerGroupMemberAsync(string GroupKey)
		{
			return await Task.Run(() =>
			{
				var _cg = (from c in _om.CUSTOMERS
							  where c.CUSTGROUPKEY == GroupKey
									&& c.CUSTCODE != GroupKey
							  orderby c.CUSTNAME
							  select new
							  {
								  c.CUSTID,
								  c.CUSTGROUPKEY,
								  c.CUSTCODE,
								  c.CUSTNAME
							  }).Distinct().AsParallel();
				return _cg.ToDataTable();
			});
		} // end GetCustomerGroupMemberAsync

		public int UpdateCustomerGroups(string GroupKey, string[] CustomerCodeList)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.CUSTOMERS.Where(x => CustomerCodeList.Contains(x.CUSTCODE))
						.ToList()
						.ForEach(c =>
						{
							c.CUSTGROUPKEY = GroupKey;
						});

					_result += _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					var _e = new Exception("Can't update Customer Group......", ex);
					Alert.DisplayAlert("Error", ex.ToString());
				}
			}

			return _result;
		} // end UpdateCustomerGroups

		public int DeleteCustomerGroup(string GroupKey)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.CUSTOMERS.Where(x => x.CUSTGROUPKEY == GroupKey && x.CUSTCODE != GroupKey)
						.ToList()
						.ForEach(c =>
						{
							c.CUSTGROUPKEY = c.CUSTCODE;
						});
					_result += _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					var _e = new Exception("Can't delete Customer Group......", ex);
					Alert.DisplayAlert("Error", ex.ToString());
				}
			}

			return _result;
		} // end DeleteCustomerGroup

		public int DeleteCustomerGroupMember(string CustomerCode)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.CUSTOMERS.Where(x => x.CUSTCODE == CustomerCode).ToList().ForEach(c =>
					{
						c.CUSTGROUPKEY = c.CUSTCODE;
					});
					_result += _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					var _e = new Exception("Can't delete Customer Group......", ex);
					Alert.DisplayAlert("Error", ex.ToString());
				}
			}

			return _result;
		} // end DeleteCustomerGroupMember

		#endregion
	}
}