using System;
using System.Data.Entity.Core;
using System.Linq;

namespace OMW15.Models.ToolModel
{
	public class CompanyProfileModel
	{
		private readonly OLDMOONEF1 _om;

		#region constructor

		public CompanyProfileModel() => _om = new OLDMOONEF1();

		#endregion

		public COMPANY_PROFILES GetCpmpanyProfileInfo(string CompanyId)
		{
			return _om.COMPANY_PROFILES.FirstOrDefault(x => x.COMPANYID == CompanyId);

		} // end GetCpmpanyProfileInfo

		public bool CheckCompanyProfile(string CompanyId)
		{
			var _result = false;
			//var _cprofile = (from c in _om.COMPANY_PROFILES
			//	where c.COMPANYID == CompanyId
			//	select c).FirstOrDefault();

			var _cprofile = GetCpmpanyProfileInfo(CompanyId);

			if (_cprofile != null)
			{
				// loading company profile information
				omglobal.COMPANY_NAME = _cprofile.COMPANYNAME;
				omglobal.DEFAULT_SYSTEM_NON_VAT = _cprofile.NON_VAT_RATE;
				omglobal.DEFAULT_SYSTEM_NON_VAT_FACTOR = _cprofile.NON_VAT_FACTOR;
				omglobal.DEFAULT_SYSTEM_VAT = _cprofile.VAT_RATE;
				omglobal.DEFAULT_SYSTEM_VAT_FACTOR = _cprofile.VAT_FACTOR;
				omglobal.SILVER_MARKUP_FACTOR = _cprofile.MATERIAL_MARKUP_FACTOR;
				omglobal.IMAGE_LOCATION_PATH = _cprofile.IMAGE_LOCATION;
				omglobal.SOURCE_CURRENCY = _cprofile.SOURCE_CURRENCY;
				omglobal.SOURCE_CURRENCY_VALUE = _cprofile.SOURCE_VALUE.Value;
				omglobal.HOME_CURRENCY = _cprofile.HOME_CURRENCY;
				omglobal.PRODUCTION_HOUR_RATE = _cprofile.PRODUCTION_HOUR_RATE;
				omglobal.NONVAT_DISPLAY = _cprofile.NONVAT_DISPLAY;
				_result = true;
			}
			else
			{
				_result = false;
			}

			return _result;
		} // end CheckCompanyProfile

		public void ReadCurrentCompanyProfile(string CompanyId)
		{
			// loading company profile information
			//var _cprofile = (from c in _om.COMPANY_PROFILES
			//	where c.COMPANYID == CompanyId
			//	select c).FirstOrDefault();

			var _cprofile = GetCpmpanyProfileInfo(CompanyId);

			if (_cprofile != null)
			{
				// loading company profile information
				omglobal.COMPANY_NAME = _cprofile.COMPANYNAME;
				omglobal.DEFAULT_SYSTEM_NON_VAT = _cprofile.NON_VAT_RATE;
				omglobal.DEFAULT_SYSTEM_NON_VAT_FACTOR = _cprofile.NON_VAT_FACTOR;
				omglobal.DEFAULT_SYSTEM_VAT = _cprofile.VAT_RATE;
				omglobal.DEFAULT_SYSTEM_VAT_FACTOR = _cprofile.VAT_FACTOR;
				omglobal.SILVER_MARKUP_FACTOR = _cprofile.MATERIAL_MARKUP_FACTOR;
				omglobal.SOURCE_CURRENCY = _cprofile.SOURCE_CURRENCY;
				omglobal.SOURCE_CURRENCY_VALUE = _cprofile.SOURCE_VALUE.Value;
				omglobal.HOME_CURRENCY = _cprofile.HOME_CURRENCY;
				omglobal.PRODUCTION_HOUR_RATE = _cprofile.PRODUCTION_HOUR_RATE;
				omglobal.IMAGE_LOCATION_PATH = _cprofile.IMAGE_LOCATION;
				omglobal.NONVAT_DISPLAY = _cprofile.NONVAT_DISPLAY;
			}
			else
			{
				omglobal.COMPANY_NAME = string.Empty;
				omglobal.DEFAULT_SYSTEM_NON_VAT = string.Empty;
				omglobal.DEFAULT_SYSTEM_NON_VAT_FACTOR = 0.00m;
				omglobal.DEFAULT_SYSTEM_VAT = string.Empty;
				omglobal.DEFAULT_SYSTEM_VAT_FACTOR = 0.00m;
				omglobal.SILVER_MARKUP_FACTOR = omglobal.DEFAULT_SILVER_MARKUP_FACTOR;
				omglobal.SOURCE_CURRENCY = "";
				omglobal.SOURCE_CURRENCY_VALUE = 0.00m;
				omglobal.HOME_CURRENCY = "THB";
				omglobal.PRODUCTION_HOUR_RATE = 0.00m;
				omglobal.IMAGE_LOCATION_PATH = "";
				omglobal.NONVAT_DISPLAY = false;
			}
		} // end ReadCurrentCompanyProfile


		public int UpdateCompanyProfile(COMPANY_PROFILES cf)
		{
			var _result = 0;

			try
			{
				if (cf.ID == 0)
				{
					_om.COMPANY_PROFILES.Add(cf);
				}
				else
				{
					var c = GetCpmpanyProfileInfo(cf.COMPANYID);
					c.COMPANYNAME = cf.COMPANYNAME;
					c.COUNTRY = cf.COUNTRY;
					c.ADDRESS = cf.ADDRESS;
					c.HOME_CURRENCY = cf.HOME_CURRENCY;
					c.IMAGE_LOCATION = cf.IMAGE_LOCATION;
					c.MATERIAL_MARKUP_FACTOR = cf.MATERIAL_MARKUP_FACTOR;
					c.NON_VAT_FACTOR = cf.NON_VAT_FACTOR;
					c.NON_VAT_RATE = cf.NON_VAT_RATE;
					c.POSTAL = cf.POSTAL;
					c.PRODUCTION_HOUR_RATE = cf.PRODUCTION_HOUR_RATE;
					c.PROVINCE = c.PROVINCE;
					c.SOURCE_CURRENCY = cf.SOURCE_CURRENCY;
					c.SOURCE_VALUE = cf.SOURCE_VALUE;
					c.TAXID = cf.TAXID;
					c.VAT_FACTOR = cf.VAT_FACTOR;
					c.VAT_RATE = cf.VAT_RATE;
					c.NONVAT_DISPLAY = cf.NONVAT_DISPLAY;
				}
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception(string.Format("Can't not {0} the Company Profile !!!!! ", cf.ID == 0 ? "insert" : "update"), ex);
			}

			return _result;
		} // end UpdateCompanyProfile
}
}