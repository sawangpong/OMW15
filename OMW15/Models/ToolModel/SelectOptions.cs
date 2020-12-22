using OMControls;
using OMW15.Models.CastingModel;
using OMW15.Models.ProductionModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Globalization;
using System.Linq;

namespace OMW15.Models.ToolModel
{
	public class SelectOptions
	{
		#region field member

		private readonly OLDMOONEF1 _om;
		private readonly ERP _erp;

		#endregion
		#region constructor

		public SelectOptions()
		{
			_om = new OLDMOONEF1();
			_erp = new ERP();
		}

		#endregion

		#region helper

		#region General Data

		public DataTable GetDistrictData() => _erp.ADDRBOOKs.Select(a => new
		{
			Key = a.ADDB_ADDB_2,
			Value = a.ADDB_ADDB_2
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _districts = (from m in _erp.ADDRBOOKs.AsParallel()
		//							orderby m.ADDB_ADDB_2
		//							select new
		//							{
		//								Key = m.ADDB_ADDB_2,
		//								Value = m.ADDB_ADDB_2
		//							}).Distinct();
		//	_result = _districts.ToDataTable();

		//	return _result;
		//} // end GetDistrictData

		public DataTable GetProvinceData() => _om.CUSTOMERS.Select(p => new
		{
			Key = p.PROVINCE,
			Value = p.PROVINCE
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _provinces = (from p in _om.CUSTOMERS.AsParallel()
		//							orderby p.PROVINCE
		//							select new
		//							{
		//								Key = p.PROVINCE,
		//								Value = p.PROVINCE
		//							}).Distinct();
		//	_result = _provinces.ToDataTable();
		//	return _result;
		//} // end GetProvinceData

		public DataTable GetCountryData() => _om.CUSTOMERS.Select(c => new
		{
			Key = c.COUNTRY,
			Value = c.COUNTRY
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _countries = (from c in _om.CUSTOMERS.AsParallel()
		//							orderby c.COUNTRY
		//							select new
		//							{
		//								Key = c.COUNTRY,
		//								Value = c.COUNTRY
		//							}).Distinct();
		//	_result = _countries.ToDataTable();

		//	return _result;
		//} // end GetCountryData

		public DataTable GetSaleManData() => _erp.SALESMen.Select(s => new
		{
			Key = s.SLMN_CODE,
			Value = s.SLMN_NAME
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _salemans = (from sa in _erp.SALESMen.AsParallel()
		//						  orderby sa.SLMN_NAME
		//						  select new
		//						  {
		//							  Key = sa.SLMN_CODE,
		//							  Value = sa.SLMN_NAME
		//						  }).Distinct();
		//	_result = _salemans.ToDataTable();
		//	return _result;
		//} // end GetSaleManData

		public DataTable GetSaleTypeData() => EnumWithName<OMShareCastingEnums.SaleTypeEnum>.ParseEnum().ToDataTable();

		//{
		//	var _saleTpye = EnumWithName<OMShareCastingEnums.SaleTypeEnum>.ParseEnum();
		//	return _saleTpye.ToDataTable();
		//} // end GetSaleTypeData

		#endregion

		#region customer

		public DataTable GetCurrencyData() => _om.CURRENCies.Select(cr => new
		{
			Key = cr.CURCODE,
			Value = "(" + cr.CURCODE + ") - " + cr.CURDETAILS
		}).OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _currencies = from c in _om.CURRENCies.AsParallel()
		//							orderby c.CURDETAILS
		//							select new
		//							{
		//								Key = c.CURCODE,
		//								Value = "(" + c.CURCODE + ") - " + c.CURDETAILS
		//							};
		//	_result = _currencies.ToDataTable();
		//	return _result;
		//} // end GetCurrencyData

		public DataTable GetCustomerData() => _om.CUSTOMERS.Select(c => new
		{
			Key = c.CUSTCODE,
			Value = c.CUSTNAME
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _customers = (from c in _om.CUSTOMERS.AsParallel()
		//							orderby c.CUSTNAME
		//							select new
		//							{
		//								Key = c.CUSTCODE,
		//								Value = c.CUSTNAME
		//							}).Distinct();
		//	_result = _customers.ToDataTable();
		//	return _result;
		//} // end GetCustomerData

		public DataTable GetCustomerId(string CustomerCode) => _om.CUSTOMERS.Select(c => new
		{
			Key = c.CUSTID,
			Value = c.CUSTNAME
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _customers = (from c in _om.CUSTOMERS.AsParallel()
		//							where c.CUSTCODE == CustomerCode
		//							orderby c.CUSTNAME
		//							select new
		//							{
		//								Key = c.CUSTID,
		//								Value = c.CUSTNAME
		//							}).Distinct();
		//	_result = _customers.ToDataTable();
		//	return _result;
		//} // endGetCustomerId

		public DataTable GetVatRateData()
		{
			var _culture = new CultureInfo("en-US");
			DataTable _result = null;
			var _vat = from v in _om.SYSDATAs.AsParallel()
						  orderby Convert.ToDecimal(v.KEYVALUE)
						  where v.GROUPTITLE == "VATRATE"
						  select new
						  {
							  /*Key = Convert.ToDecimal(string.Format("{0:N2}", Convert.ToDecimal(v.KEYVALUE))),*/
							  Key = Convert.ToDecimal(v.KEYVALUE),
							  Value = v.THKEYNAME
						  };
			_result = _vat.ToDataTable();
			return _result;
		} // end GetVatRateData

		public DataTable GetCreditDuration() => _om.CRCODEs.Select(cr => new
		{
			Key = cr.CREDITCODE,
			Value = cr.DURATION
		}).OrderBy(o => o.Key).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _cr = from c in _om.CRCODEs.AsParallel()
		//				 orderby c.CREDITCODE
		//				 select new
		//				 {
		//					 Key = c.CREDITCODE,
		//					 Value = c.DURATION
		//				 };
		//	_result = _cr.ToDataTable();
		//	return _result;
		//} // end GetCreditCode

		public int GetCreditDuration(string CreditCode) => _om.CRCODEs.Where(x => x.CREDITCODE == CreditCode).Single().DURATION;
		//{
		//	var _result = 0;
		//	var _cr = (from c in _om.CRCODEs
		//				  orderby c.CREDITCODE
		//				  where c.CREDITCODE == CreditCode
		//				  orderby c.CREDITCODE
		//				  select new
		//				  {
		//					  Key = c.CREDITCODE,
		//					  Value = c.DURATION
		//				  }).Single();

		//	if (_cr != null) _result = _cr.Value;
		//	else _result = 0;
		//	return _result;
		//} // end GetCreditDuration

		#endregion // customer

		#region casting

		public DataTable GetItemCodeData() => _om.ITEMCODEs.Select(i => new
		{
			Key = i.ITEMCODE1,
			Value = i.ITEMCODENAME_TH
		}).OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _codes = (from code in _om.ITEMCODEs
		//					  orderby code.ITEMCODENAME_TH
		//					  select new
		//					  {
		//						  Key = code.ITEMCODE1,
		//						  Value = code.ITEMCODENAME_TH
		//					  }).AsParallel();
		//	_result = _codes.ToDataTable();

		//	return _result;
		//} // end GetItemCodeData

		public DataTable GetUnitCountData() => _om.CUSTPRICELISTs.Select(u => new
		{
			Key = u.UNITCOUNT,
			Value = u.UNITCOUNT
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _units = (from unit in _om.CUSTPRICELISTs.AsParallel()
		//					  orderby unit.UNITCOUNT
		//					  select new
		//					  {
		//						  Key = unit.UNITCOUNT,
		//						  Value = unit.UNITCOUNT
		//					  }).Distinct();
		//	_result = _units.ToDataTable();
		//	return _result;
		//} // end GetUnitCountData

		public DataTable GetUnitList() => _om.SYSDATAs.AsEnumerable().Where(x => x.GROUPTITLE == "UNITCOUNT").Select(u => new
		{
			Key = Convert.ToInt32(u.KEYVALUE),
			Value = u.THKEYNAME
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _units = (from unit in _om.SYSDATAs.AsEnumerable()
		//					  orderby unit.THKEYNAME
		//					  where unit.GROUPTITLE == "UNITCOUNT"
		//					  select new
		//					  {
		//						  Key = Convert.ToInt32(unit.KEYVALUE),
		//						  Value = unit.THKEYNAME
		//					  }).Distinct().AsParallel();

		//	_result = _units.ToDataTable();
		//	return _result;
		//} // end GetUnitList

		public DataTable GetProductStyleData() => _om.SYSDATAs
			.Where(x => x.GROUPTITLE == "PRODUCTSTYLE")
			.Select(p => new
			{
				Key = p.KEYVALUE,
				Value = p.THKEYNAME
			}).OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//var _styles = (from ps in _om.SYSDATAs
		//					orderby ps.THKEYNAME
		//					where ps.GROUPTITLE == "PRODUCTSTYLE"
		//					orderby ps.KEYVALUE
		//					select new
		//					{
		//						Key = ps.KEYVALUE,
		//						Value = ps.THKEYNAME
		//					}).AsParallel();
		//_result = _styles.ToDataTable();

		//	return _result;
		//} // end GetProductStyleData

		//public DataTable GetItemImage(int Id)
		//{
		//	DataTable _result = null;
		//	var _itemImg = (from c in _om.CUSTPRICEITEMPICs.AsParallel()
		//		orderby c.ITEMPICID
		//		where c.ITEMSEQ == Id
		//		orderby c.ITEMSEQ
		//		select new
		//		{
		//			Key = c.ITEMSEQ,
		//			Value = c.ITEMPIC
		//		}).Distinct();
		//	_result = _itemImg.ToDataTable();
		//	return _result;
		//} // end GetItemImage

		#endregion // end casting

		#region Employee-Record

		public DataTable GetEmployeeStatus() => _om.EMPSTATUS.Select(e => new
		{
			Key = e.STATUSID,
			Value = e.STATUSTH
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _status = (from s in _om.EMPSTATUS
		//						orderby s.STATUSTH
		//						select new
		//						{
		//							Key = s.STATUSID,
		//							Value = s.STATUSTH
		//						}).Distinct();
		//	_result = _status.ToDataTable();
		//	return _result;
		//} // end GetEmployeeStatus

		public DataTable GetDepartmentCode() => _erp.DEPTTABs.Select(d => new
		{
			Key = d.DEPT_KEY,
			Value = d.DEPT_THAIDESC
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _departments = (from d in _erp.DEPTTABs.AsParallel()
		//							  orderby d.DEPT_THAIDESC
		//							  select new
		//							  {
		//								  Key = d.DEPT_KEY,
		//								  Value = d.DEPT_THAIDESC
		//							  }).Distinct();
		//	_result = _departments.ToDataTable();
		//	return _result;
		//} // end GetDepartmentCode

		public DataTable GetDepartmentData() => _erp.DEPTTABs.Select(d => new
		{
			Key = d.DEPT_CODE,
			Value = d.DEPT_THAIDESC
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _departments = (from d in _erp.DEPTTABs.AsParallel()
		//							  orderby d.DEPT_THAIDESC
		//							  select new
		//							  {
		//								  Key = d.DEPT_CODE,
		//								  Value = d.DEPT_THAIDESC
		//							  }).Distinct();
		//	_result = _departments.ToDataTable();
		//	return _result;
		//} // end GetDepartmentData

		public DataTable GetWorkGroup() => _om.DEPARTMENTs.Select(wg => new
		{
			Key = wg.DEPARTMENTID,
			Value = wg.DEPARTMENTEN
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _workGroup = (from wg in _om.DEPARTMENTs
		//							  orderby wg.DEPARTMENTEN
		//							  select new
		//							  {
		//								  Key = wg.DEPARTMENTID,
		//								  Value = wg.DEPARTMENTEN
		//							  }).Distinct();
		//	_result = _departments.ToDataTable();
		//	return _result;
		//} // end GetDepartmentData


		public DataTable GetSexTHData() => OMDataUtils.GetValueList<SexTH>().ToDataTable();
		//{
		//	var _result = OMDataUtils.GetValueList<SexTH>();
		//	return _result.ToDataTable();
		//} // end GetSexTHData

		public DataTable GetSexENData() => OMDataUtils.GetValueList<SexEN>().ToDataTable();
		//{
		//	var _result = OMDataUtils.GetValueList<SexEN>();
		//	return _result.ToDataTable();
		//} // end GetSexTHData

		public DataTable GetTitleTHData() => OMDataUtils.GetValueList<PersonTitleTH>().ToDataTable();
		//{
		//	var _result = OMDataUtils.GetValueList<PersonTitleTH>();
		//	return _result.ToDataTable();
		//} // end GetSexTHData

		public DataTable GetFamilyStatusData() => _om.SYSDATAs
				.Where(x => x.GROUPTITLE == "FAMILYSTATUS")
				.Select(f => new
				{
					Key = f.KEYVALUE,
					Value = f.THKEYNAME
				}).OrderBy(o => o.Key).ToDataTable();

		//{
		//	DataTable _result = null;
		//	var _families = (from family in _om.SYSDATAs
		//						  where family.GROUPTITLE == "FAMILYSTATUS"
		//						  orderby family.KEYVALUE
		//						  select new
		//						  {
		//							  Key = family.KEYVALUE,
		//							  Value = family.THKEYNAME
		//						  }).AsParallel();
		//	_result = _families.ToDataTable();

		//	return _result;
		//} // end GetFamilyStatusData


		public DataTable GetWorkerList(int[] departments, int[] status) => _om.EMPLOYEEs
			.Where(x => departments.Contains(x.DEPARTMENTID)
			&& status.Contains(x.STATUS))
			.Select(w => new
			{
				Key = w.EMPCODE,
				Value = w.EMPFIRSTNAME + " " + w.EMPLASTNAME
			}).OrderBy(o => o.Value).ToDataTable();

		//{
		//	DataTable _result = null;
		//var _workers = (from worker in _om.EMPLOYEEs
		//					 where departments.Contains(worker.DEPARTMENTID)
		//					 && status.Contains(worker.STATUS)
		//					 orderby worker.EMPCODE
		//					 select new
		//					 {
		//						 Key = worker.EMPCODE,
		//						 Value = worker.EMPFIRSTNAME + " " + worker.EMPLASTNAME
		//					 }).AsParallel();
		//_result = _workers.ToDataTable();

		//	return _result;
		//} // end GetWorkerDataByCode

	public DataTable GetWorkerDataByCode() => _om.EMPLOYEEs.Select(e => new
	{
		Key = e.EMPCODE,
		Value = e.EMPFIRSTNAME + " " + e.EMPLASTNAME
	}).OrderBy(o => o.Key).ToDataTable();

	//{
	//	DataTable _result = null;
	//	var _workers = (from worker in _om.EMPLOYEEs
	//						 orderby worker.EMPCODE
	//						 select new
	//						 {
	//							 Key = worker.EMPCODE,
	//							 Value = worker.EMPFIRSTNAME + " " + worker.EMPLASTNAME
	//						 }).AsParallel();
	//	_result = _workers.ToDataTable();
	//	return _result;
	//} // end GetWorkerDataByCode

	public DataTable GetWorkerDataById() => _om.EMPLOYEEs.Select(e => new
	{
		Key = e.EMPSEQ,
		Value = e.EMPFIRSTNAME + " " + e.EMPLASTNAME
	}).OrderBy(o => o.Value).ToDataTable();

	//{
	//	DataTable _result = null;
	//	var _workers = (from worker in _om.EMPLOYEEs
	//						 orderby worker.EMPCODE
	//						 select new
	//						 {
	//							 Key = worker.EMPSEQ,
	//							 Value = worker.EMPFIRSTNAME + " " + worker.EMPLASTNAME
	//						 }).AsParallel();
	//	_result = _workers.ToDataTable();
	//	return _result;
	//} // end GetWorkerDataById

	#endregion // end Employee-Record

	public DataTable GetDataByOption(SelectTypeOption Option) => GetDataByOption(Option, 0);
	//{
	//	return GetDataByOption(Option, 0);
	//}

	public DataTable GetDataByOption(SelectTypeOption Option, int Id)
	{
		DataTable _resultTable = null;

		switch (Option)
		{
			case SelectTypeOption.Customer:
				_resultTable = new SelectOptions().GetCustomerData();
				break;
			case SelectTypeOption.Currency:
				_resultTable = new SelectOptions().GetCurrencyData();
				break;
			case SelectTypeOption.Department:
				_resultTable = new SelectOptions().GetDepartmentData();
				break;
			case SelectTypeOption.District:
				_resultTable = new SelectOptions().GetDistrictData();
				break;
			case SelectTypeOption.Province:
				_resultTable = new SelectOptions().GetProvinceData();
				break;
			case SelectTypeOption.Country:
				_resultTable = new SelectOptions().GetCountryData();
				break;
			case SelectTypeOption.Material:
				_resultTable = new CastingDAL().GetMaterialData();
				break;
			case SelectTypeOption.SaleMan:
				_resultTable = new SelectOptions().GetSaleManData();
				break;
			case SelectTypeOption.SaleType:
				_resultTable = new SelectOptions().GetSaleTypeData();
				break;
			case SelectTypeOption.VatRate:
				_resultTable = new SelectOptions().GetVatRateData();
				break;
			case SelectTypeOption.ProductStyle:
				_resultTable = new SelectOptions().GetProductStyleData();
				break;
			case SelectTypeOption.ProductionProcess:
				_resultTable = new ProductionDAL().GetProductionProcess();
				break;
			case SelectTypeOption.CastingCode:
				_resultTable = GetItemCodeData();
				break;
			case SelectTypeOption.Sex:
				_resultTable = GetSexTHData();
				break;
			case SelectTypeOption.UnitCount:
				_resultTable = GetUnitCountData();
				break;
			case SelectTypeOption.WorkerByCode:
				_resultTable = GetWorkerDataByCode();
				break;
			case SelectTypeOption.WorkerById:
				_resultTable = GetWorkerDataById();
				break;
			case SelectTypeOption.FamilyStatus:
				_resultTable = GetFamilyStatusData();
				break;
			case SelectTypeOption.ItemImage:
				//_resultTable = GetItemImage(Id);
				break;
		}

		return _resultTable;
	} // end GetOptionList

	#endregion
}
}