using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMW15.Shared;
using OMControls;

namespace OMW15.Tools
{
	public static class SelectOptions
	{
		#region field member

		#endregion

		#region properties

		#endregion

		#region helper

		#region General Data
	
		public static DataTable GetDistrictData()
		{
			DataTable _result = null;
			using (ERP _erp = new ERP())
			{
				var _districts = (from m in _erp.ADDRBOOKs.AsParallel()
								  orderby m.ADDB_ADDB_2
								  select new
								  {
									  Key = m.ADDB_ADDB_2,
									  Value = m.ADDB_ADDB_2
								  }).Distinct();
				_result = OMControls.OMDataUtils.ToDataTable(_districts.ToList());
			}

			return _result;
		} // end GetDistrictData

		public static DataTable GetProvinceData()
		{
			DataTable _result = null;
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _provinces = (from p in _oldmoon.CUSTOMER1.AsParallel()
								  orderby p.PROVINCE
								  select new
								  {
									  Key = p.PROVINCE,
									  Value = p.PROVINCE
								  }).Distinct();
				_result = OMControls.OMDataUtils.ToDataTable(_provinces.ToList());
			}
			return _result;
		} // end GetProvinceData

		public static DataTable GetCountryData()
		{
			DataTable _result = null;
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _countries = (from c in _oldmoon.CUSTOMER1.AsParallel()
								  orderby c.COUNTRY
								  select new
								  {
									  Key = c.COUNTRY,
									  Value = c.COUNTRY
								  }).Distinct();
				_result = OMControls.OMDataUtils.ToDataTable(_countries.ToList());
			}

			return _result;

		} // end GetCountryData

		public static DataTable GetSaleManData()
		{
			DataTable _result = null;
			using (ERP _erp = new ERP())
			{
				var _salemans = (from sa in _erp.SALESMen.AsParallel()
								 orderby sa.SLMN_NAME
								 select new
								 {
									 Key = sa.SLMN_CODE,
									 Value = sa.SLMN_NAME
								 }).Distinct();
				_result = OMControls.OMDataUtils.ToDataTable(_salemans.ToList());
			}
			return _result;
		} // end GetSaleManData

		public static DataTable GetSaleTypeData()
		{
			var _saleTpye = OMControls.OMDataUtils.GetValueList<OMShareCastingEnums.SaleTypeEnum>();
			return OMControls.OMDataUtils.ToDataTable(_saleTpye);

		} // end GetSaleTypeData

		#endregion

		#region customer

		public static DataTable GetCurrencyData()
		{
			DataTable _result = null;
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _currencies = from c in _oldmoon.CURRENCies.AsParallel()
								  orderby c.CURDETAILS
								  select new
								  {
									  Key = c.CURCODE,
									  Value = "(" + c.CURCODE + ") - " + c.CURDETAILS
								  };
				_result = OMControls.OMDataUtils.ToDataTable(_currencies.ToList());
			}
			return _result;
		} // end GetCurrencyData

		public static DataTable GetCustomerData()
		{
			DataTable _result = null;
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _customers = (from c in _oldmoon.CUSTOMER1.AsParallel()
								  orderby c.CUSTNAME
								  select new
								  {
									  Key = c.CUSTCODE,
									  Value = c.CUSTNAME
								  }).Distinct().ToList();
				_result = OMControls.OMDataUtils.ToDataTable(_customers.ToList());
			}
			return _result;

		} // end GetCustomerData

		public static DataTable GetCustomerId(string CustomerCode)
		{
			DataTable _result = null;
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _customers = (from c in _oldmoon.CUSTOMER1.AsParallel()
								  where c.CUSTCODE == CustomerCode
								  orderby c.CUSTNAME
								  select new
								  {
									  Key = c.CUSTID,
									  Value = c.CUSTNAME
								  }).Distinct().ToList();
				_result = OMControls.OMDataUtils.ToDataTable(_customers.ToList());
			}
			return _result;
		} // endGetCustomerId

		public static DataTable GetVatRateData()
		{
			DataTable _result = null;
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _vat = from v in _oldmoon.SYSDATAs.AsParallel()
						   where v.GROUPTITLE == "VATRATE"
						   orderby v.THKEYNAME
						   select new
						   {
							   Key = v.KEYVALUE,
							   Value = v.THKEYNAME
						   };
				_result = OMControls.OMDataUtils.ToDataTable(_vat.ToList());
			}
			return _result;

		} // end GetVatRateData

		public static DataTable GetCreditDuration()
		{
			DataTable _result = null;
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _cr = from c in _oldmoon.CRCODEs.AsParallel()
						  orderby c.CREDITCODE
						  select new
						  {
							  Key = c.CREDITCODE,
							  Value = c.DURATION
						  };
				_result = OMControls.OMDataUtils.ToDataTable(_cr.ToList());
			}
			return _result;
		} // end GetCreditCode

		public static int GetCreditDuration(string CreditCode)
		{
			int _result = 0;
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _cr = (from c in _oldmoon.CRCODEs
						   where c.CREDITCODE == CreditCode
						   orderby c.CREDITCODE
						   select new
						   {
							   Key = c.CREDITCODE,
							   Value = c.DURATION
						   }).FirstOrDefault();

				if (_cr != null)
				{
					_result = _cr.Value;
				}
				else
				{
					_result = 0;
				}
			}
			return _result;

		} // end GetCreditDuration

		#endregion // customer

		#region casting

		public static DataTable GetMaterialSI()
		{
			DataTable _result = null;
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _matsi = (from m in _oldmoon.SYSDATAs.AsParallel()
							  where m.GROUPTITLE == "MATERIAL"
							  orderby m.KEYVALUE
							  select new
							  {
								  Key = m.KEYVALUE,
								  Value = m.SI
							  }).ToList();
				_result = OMControls.OMDataUtils.ToDataTable(_matsi.ToList());
			}
			return _result;

		} // end GetMaterialSI

		public static decimal GetMaterialSI(string MaterialCode)
		{
			decimal _result = 0.00m;
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				//var _matsi = (from m in _oldmoon.SYSDATAs
				//			  where m.GROUPTITLE == "MATERIAL"
				//			  && m.KEYVALUE == MaterialCode
				//			  orderby m.KEYVALUE
				//			  select new
				//			  {
				//				  Key = m.KEYVALUE,
				//				  Value = m.SI
				//			  }).FirstOrDefault();

				//if(_matsi != null)
				//{
				//	_result = _matsi.Value;
				//}
				//else
				//{
				//	_result = 0.00m;
				//}

				SYSDATA _matSI = _oldmoon.SYSDATAs.SingleOrDefault(x => x.GROUPTITLE == "MATERIAL" && x.KEYVALUE == MaterialCode);
				_result = _matSI.SI;
			}

			return _result;

		} // end GetMaterialSI

		public static DataTable GetItemCodeData()
		{
			DataTable _result = null;
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _codes = (from code in _oldmoon.ITEMCODEs.AsParallel()
							  orderby code.ITEMCODENAME_TH
							  select new
							  {
								  Key = code.ITEMCODE1,
								  Value = code.ITEMCODENAME_TH
							  }).ToList();
				_result = OMControls.OMDataUtils.ToDataTable(_codes.ToList());
			}
			return _result;

		} // end GetItemCodeData

		public static DataTable GetUnitCountData()
		{
			DataTable _result = null;
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _units = (from unit in _oldmoon.CUSTPRICELISTs.AsParallel()
							  select new
							  {
								  Key = unit.UNITCOUNT,
								  Value = unit.UNITCOUNT
							  }).Distinct().ToList();
				_result = OMControls.OMDataUtils.ToDataTable(_units.ToList());
			}
			return _result;

		} // end GetUnitCountData

		public static DataTable GetProductStyleData()
		{
			DataTable _result = null;
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _styles = (from ps in _oldmoon.SYSDATAs.AsParallel()
							   where ps.GROUPTITLE == "PRODUCTSTYLE"
							   orderby ps.KEYVALUE
							   select new
							   {
								   Key = ps.KEYVALUE,
								   Value = ps.THKEYNAME
							   }).ToList();
				_result = OMControls.OMDataUtils.ToDataTable(_styles.ToList());
			}

			return _result;

		} // end GetProductStyleData

		public static DataTable GetItemImage(int Id)
		{
			DataTable _result = null;
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _itemImg = (from c in _oldmoon.CUSTPRICEITEMPICs.AsParallel()
								where c.ITEMSEQ == Id
								orderby c.ITEMSEQ
								select new
								{
									Key = c.ITEMSEQ,
									Value = c.ITEMPIC
								}).Distinct().ToList();
				_result = OMControls.OMDataUtils.ToDataTable(_itemImg.ToList());
			}
			return _result;
		} // end GetItemImage

		public static DataTable GetMaterialData()
		{
			DataTable _result = null;
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _materials = from m in _oldmoon.SYSDATAs.AsParallel()
								 where m.GROUPTITLE == "MATERIAL"
								 orderby m.THKEYNAME
								 select new
								 {
									 Key = m.KEYVALUE,
									 Value = m.THKEYNAME
								 };
				_result = OMControls.OMDataUtils.ToDataTable(_materials.ToList());
			}
			return _result;

		} // end GetMaterialData

		#endregion // end casting

		#region Employee-Record

		public static DataTable GetEmployeeStatus()
		{
			DataTable _result = null;
			using(OLDMOONEF _om = new OLDMOONEF())
			{
				var _status = (from s in _om.EMPSTATUS
									orderby s.STATUSTH
									select new
									{
										Key = s.STATUSID,
										Value = s.STATUSTH
									}).Distinct();
				_result = OMControls.OMDataUtils.ToDataTable(_status.ToList());
			}
			return _result;

		} // end GetEmployeeStatus

		public static DataTable GetDepartmentCode()
		{
			DataTable _result = null;
			using(ERP _erp = new ERP())
			{
				var _departments = (from d in _erp.DEPTTABs.AsParallel()
									orderby d.DEPT_THAIDESC
									select new
									{
										Key = d.DEPT_KEY,
										Value = d.DEPT_THAIDESC
									}).Distinct();
				_result = OMControls.OMDataUtils.ToDataTable(_departments.ToList());
			}
			return _result;

		} // end GetDepartmentCode

		public static DataTable GetDepartmentData()
		{
			DataTable _result = null;
			using(ERP _erp = new ERP())
			{
				var _departments = (from d in _erp.DEPTTABs.AsParallel()
									orderby d.DEPT_THAIDESC
									select new
									{
										Key = d.DEPT_CODE,
										Value = d.DEPT_THAIDESC
									}).Distinct();
				_result = OMControls.OMDataUtils.ToDataTable(_departments.ToList());
			}
			return _result;

		} // end GetDepartmentData

		public static DataTable GetSexTHData()
		{
			var _result = OMControls.OMDataUtils.GetValueList<SexTH>();
			return OMControls.OMDataUtils.ToDataTable(_result);

		} // end GetSexTHData

		public static DataTable GetSexENData()
		{
			var _result = OMControls.OMDataUtils.GetValueList<SexEN>();
			return OMControls.OMDataUtils.ToDataTable(_result);

		} // end GetSexTHData

		public static DataTable GetTitleTHData()
		{
			var _result = OMControls.OMDataUtils.GetValueList<PersonTitleTH>();
			return OMControls.OMDataUtils.ToDataTable(_result);

		} // end GetSexTHData

		public static DataTable GetFamilyStatusData()
		{
			DataTable _result = null;
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _families = (from family in _oldmoon.SYSDATAs.AsParallel()
								 where family.GROUPTITLE == "FAMILYSTATUS"
								 orderby family.KEYVALUE
								 select new
								 {
									 Key = family.KEYVALUE,
									 Value = family.THKEYNAME
								 }).ToList();
				_result = OMControls.OMDataUtils.ToDataTable(_families.ToList());
			}

			return _result;

		} // end GetFamilyStatusData

		public static DataTable GetWorkerData()
		{
			DataTable _result = null;
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _workers = (from worker in _oldmoon.EMPLOYEEs.AsParallel()
								orderby worker.EMPCODE
								select new
								{
									Key = worker.EMPCODE,
									Value = worker.EMPFIRSTNAME + " " + worker.EMPLASTNAME
								}).ToList();
				_result = OMControls.OMDataUtils.ToDataTable(_workers.ToList());
			}
			return _result;

		} // end GetWorkerData

		public static DataTable GetWorkerData2()
		{
			DataTable _result = null;
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _workers = (from worker in _oldmoon.EMPLOYEEs.AsParallel()
								orderby worker.EMPCODE
								select new
								{
									Key = worker.EMPSEQ,
									Value = worker.EMPFIRSTNAME + " " + worker.EMPLASTNAME
								}).ToList();
				_result = OMControls.OMDataUtils.ToDataTable(_workers.ToList());
			}
			return _result;

		} // end GetWorkerData2

		#endregion // end Employee-Record

		public static DataTable GetDataByOption(SelectTypeOption Option)
		{
			return GetDataByOption(Option, 0);
		}

		public static DataTable GetDataByOption(SelectTypeOption Option, int Id)
		{
			DataTable _resultTable = null;

			switch (Option)
			{
				case SelectTypeOption.Customer:
					_resultTable = Tools.SelectOptions.GetCustomerData();
					break;
				case SelectTypeOption.Currency:
					_resultTable = Tools.SelectOptions.GetCurrencyData();
					break;
				case SelectTypeOption.Department:
					_resultTable = Tools.SelectOptions.GetDepartmentData();
					break;
				case SelectTypeOption.District:
					_resultTable = Tools.SelectOptions.GetDistrictData();
					break;
				case SelectTypeOption.Province:
					_resultTable = Tools.SelectOptions.GetProvinceData();
					break;
				//case SelectTypeOption.ItemNo:
				//	_resultTable = Tools.SelectOptions.GetPriceListItemData(Id);
				//	break;
				case SelectTypeOption.Country:
					_resultTable = Tools.SelectOptions.GetCountryData();
					break;
				case SelectTypeOption.Material:
					_resultTable = Tools.SelectOptions.GetMaterialData();
					break;
				case SelectTypeOption.SaleMan:
					_resultTable = Tools.SelectOptions.GetSaleManData();
					break;
				case SelectTypeOption.SaleType:
					_resultTable = Tools.SelectOptions.GetSaleTypeData();
					break;
				case SelectTypeOption.VatRate:
					_resultTable = Tools.SelectOptions.GetVatRateData();
					break;
				case SelectTypeOption.ProductStyle:
					_resultTable = Tools.SelectOptions.GetProductStyleData();
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
				case SelectTypeOption.Worker:
					_resultTable = Tools.SelectOptions.GetWorkerData();
					break;
				case SelectTypeOption.Worker2:
					_resultTable = Tools.SelectOptions.GetWorkerData2();
					break;
				case SelectTypeOption.FamilyStatus:
					_resultTable = GetFamilyStatusData();
					break;
				case SelectTypeOption.ItemImage:
					_resultTable = GetItemImage(Id);
					break;
			}

			return _resultTable;

		} // end GetOptionList


		#region Overload Method GetData
		public static void GetData(SelectTypeOption Option, ref string Name, ref string Code, ref int Id)
		{
			GetData(Option, 0, ref Name, ref Code, ref Id);
		} // end 

		public static void GetData(SelectTypeOption Option, int FilterId, ref string Name, ref string Code, ref int Id)
		{
			Tools.SelectBox _selectBox = new Tools.SelectBox();
			_selectBox.SelectOption = Option;
			_selectBox.FilterId = FilterId;
			_selectBox.StartPosition = FormStartPosition.CenterScreen;
			if (_selectBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Name = _selectBox.SelectedName;
				Code = _selectBox.SelectedCode;
				Id = _selectBox.SelectedId;
			}
		}

		#endregion // Overload Method GetData

		#endregion

	}
}
