using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using OMControls;
using OMW15.Shared;

namespace OMW15.Tools
{
	public partial class CompanyProfile : Form
	{
		#region class field member
		private ActionMode _mode = ActionMode.None;
		private string _companyId = string.Empty;
		private decimal _nonVATFactor = 0.00m;
		private decimal _vatFactor = 0.00m;

		#endregion

		#region class properties

		public ActionMode Mode
		{
			set
			{
				_mode = value;
			}
		}

		public string CompanyId
		{
			set
			{
				_companyId = value;
			}
		}
		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end UpdateUI

		private void SetCompanyProfileUI()
		{
			this.txtAdddress.Text = string.Empty;
			this.txtCompanyName.Text = string.Empty;
			this.txtCountry.Text = string.Empty;
			this.txtPostal.Text = string.Empty;
			this.txtProvince.Text = string.Empty;
			this.txtTaxId.Text = string.Empty;
			this.txtNonVATRate.Text = string.Empty;
			this.txtVATRate.Text = string.Empty;
			this.txtMaterialMarkupFactor.Text = string.Format("{0:N3}", omglobal.DEFAULT_MATERIAL_MARKUP_FACTOR);
			this.txtHomeCurrency.Text = "THB";
			this.txtImageLocation.Text = omglobal.IMAGE_LOCATION_PATH;

		} // end SetCompanyProfileUI

		private void GetCompanyProfileInfo(string CompanyId)
		{
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var cp = (from f in _oldmoon.COMPANY_PROFILES
						  where f.COMPANYID == CompanyId
						  select f).FirstOrDefault();

				if(cp != null)
				{
					this.txtAdddress.Text = cp.ADDRESS;
					this.txtCompanyName.Text = cp.COMPANYNAME;
					this.txtCountry.Text = cp.COUNTRY;
					this.txtPostal.Text = cp.POSTAL;
					this.txtProvince.Text = cp.PROVINCE;
					this.txtTaxId.Text = cp.TAXID;
					this.txtNonVATRate.Text = cp.NON_VAT_RATE;
					this.txtVATRate.Text = cp.VAT_RATE;
					this.txtMaterialMarkupFactor.Text = string.Format("{0:N3}", cp.MATERIAL_MARKUP_FACTOR);
					this.txtHomeCurrency.Text = cp.HOME_CURRENCY;
					this.txtImageLocation.Text = cp.IMAGE_LOCATION;
				}
				else
				{
					this.txtAdddress.Text = string.Empty;
					this.txtCompanyName.Text = string.Empty;
					this.txtCountry.Text = string.Empty;
					this.txtPostal.Text = string.Empty;
					this.txtProvince.Text = string.Empty;
					this.txtTaxId.Text = string.Empty;
					this.txtNonVATRate.Text = string.Empty;
					this.txtVATRate.Text = string.Empty;
					this.txtMaterialMarkupFactor.Text = string.Format("{0:N3}", omglobal.DEFAULT_MATERIAL_MARKUP_FACTOR);
					this.txtHomeCurrency.Text = omglobal.HOME_CURRENCY;
					this.txtImageLocation.Text = omglobal.IMAGE_LOCATION_PATH;
				}

			} // end 

		} // end GetCompanyProfileInfo


		private bool UpdateCompanyProfileInfo(ActionMode Mode, string CompanyId)
		{
			bool _result = false;
			switch(Mode)
			{
				case ActionMode.Add:
					_result = this.AddCompanyProfileRecord(CompanyId);
					break;
				case ActionMode.Edit:
					_result = this.UpdateCurrentCompanyProfile(CompanyId);
					break;
			}
			return _result;

		} // end UpdateCompanyProfileInfo

		private bool AddCompanyProfileRecord(string CompanyId)
		{
			bool _result = false;
			using(var _scope = new System.Transactions.TransactionScope())
			{
				OLDMOONEF _oldmoon = new OLDMOONEF();
				COMPANY_PROFILES _cprofile = new COMPANY_PROFILES();
				try
				{
					_cprofile.COMPANYID = CompanyId;
					_cprofile.COMPANYNAME = this.txtCompanyName.Text;
					_cprofile.COUNTRY = this.txtCountry.Text;
					_cprofile.ADDRESS = this.txtAdddress.Text;
					_cprofile.NON_VAT_FACTOR = _nonVATFactor;
					_cprofile.NON_VAT_RATE = this.txtNonVATRate.Text;
					_cprofile.POSTAL = this.txtPostal.Text;
					_cprofile.PROVINCE = this.txtProvince.Text;
					_cprofile.TAXID = this.txtTaxId.Text;
					_cprofile.VAT_FACTOR = _vatFactor;
					_cprofile.VAT_RATE = this.txtVATRate.Text;
					_cprofile.MATERIAL_MARKUP_FACTOR = Convert.ToDecimal(this.txtMaterialMarkupFactor.Text);
					_cprofile.HOME_CURRENCY = this.txtHomeCurrency.Text;
					_cprofile.IMAGE_LOCATION = this.txtImageLocation.Text;
					_oldmoon.COMPANY_PROFILES.Add(_cprofile);
					_oldmoon.SaveChanges();
					_scope.Complete();
					_result = true;
				}
				catch(OptimisticConcurrencyException ex)
				{
					_result = false;
					//_scope.Dispose();
					throw new Exception("New Company-Profile error updating.....", ex);
				}
			}
			return _result;

		} // end AddCompanyProfileRecord

		private bool UpdateCurrentCompanyProfile(string CompanyId)
		{
			bool _result = false;

			using(var _scope = new System.Transactions.TransactionScope())
			{
				OLDMOONEF _oldmoon = new OLDMOONEF();
				var _cprofile = (from c in _oldmoon.COMPANY_PROFILES
								 where c.COMPANYID == CompanyId
								 select c).FirstOrDefault();
				try
				{
					_cprofile.COMPANYNAME = this.txtCompanyName.Text;
					_cprofile.ADDRESS = this.txtAdddress.Text;
					_cprofile.COUNTRY = this.txtCountry.Text;
					_cprofile.NON_VAT_FACTOR = _nonVATFactor;
					_cprofile.NON_VAT_RATE = this.txtNonVATRate.Text;
					_cprofile.POSTAL = this.txtPostal.Text;
					_cprofile.PROVINCE = this.txtProvince.Text;
					_cprofile.TAXID = this.txtTaxId.Text;
					_cprofile.VAT_FACTOR = _vatFactor;
					_cprofile.VAT_RATE = this.txtVATRate.Text;
					_cprofile.MATERIAL_MARKUP_FACTOR = Convert.ToDecimal(this.txtMaterialMarkupFactor.Text);
					_cprofile.HOME_CURRENCY = this.txtHomeCurrency.Text;
					_cprofile.IMAGE_LOCATION = this.txtImageLocation.Text;
					_oldmoon.SaveChanges();
					_scope.Complete();
				}
				catch(OptimisticConcurrencyException ex)
				{
					_result = false;
					//_scope.Dispose();
					throw new Exception("Update Company-profile fail....", ex);
				}
			}

			return _result;

		} // end UpdateCurrentCompanyProfile


		#endregion


		public CompanyProfile()
		{
			InitializeComponent();
		}

		private void CompanyProfile_Load(object sender, EventArgs e)
		{
			// display company profile id
			this.lbCompanyId.Text = _companyId;
			this.lbMode.Text = _mode.ToString();

			switch(_mode)
			{
				case ActionMode.Add:
					this.SetCompanyProfileUI();
					break;
				case ActionMode.Edit:
					this.GetCompanyProfileInfo(_companyId);
					break;
			}

			this.UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if(this.UpdateCompanyProfileInfo(_mode, _companyId))
			{
				this.DialogResult = System.Windows.Forms.DialogResult.OK;

				// update global variable
				omglobal.IMAGE_LOCATION_PATH = this.txtImageLocation.Text;
			}
			else
			{
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			}
		}

		private void txtNonVATRate_TextChanged(object sender, EventArgs e)
		{
			if(Information.IsNumeric(this.txtNonVATRate.Text))
			{
				_nonVATFactor = Convert.ToDecimal(this.txtNonVATRate.Text) / 100;
			}
			else
			{
				_nonVATFactor = 0.00m;
			}
		}

		private void txtVATRate_TextChanged(object sender, EventArgs e)
		{
			if (Information.IsNumeric(this.txtVATRate.Text))
			{
				_vatFactor = Convert.ToDecimal(this.txtVATRate.Text) / 100;
			}
			else
			{
				_vatFactor = 0.00m;
			}
		}

		private void btnImageLocation_Click(object sender, EventArgs e)
		{
			this.txtImageLocation.Text = OMControls.OMUtils.GetFolderPath();
		}
	}
}
