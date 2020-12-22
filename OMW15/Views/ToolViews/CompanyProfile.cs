using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using OMControls;
using OMW15.Models.ToolModel;
using OMW15.Shared;

namespace OMW15.Views.ToolViews
{
	public partial class CompanyProfile : Form
	{
		public CompanyProfile()
		{
			InitializeComponent();
			pnlHeader.BackColor = omglobal.OM_ORANGE_COLOR;
		}

		private void CompanyProfile_Load(object sender, EventArgs e)
		{
			// display company profile id
			lbCompanyId.Text = _companyId;
			lbMode.Text = _mode.ToString();

			switch (_mode)
			{
				case ActionMode.Add:
					GetCompanyProfileInfo(_companyId = "");
					break;
				case ActionMode.Edit:
					GetCompanyProfileInfo(_companyId);
					break;
			}

			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (UpdateCompanyProfile(_companyId))
			{
				DialogResult = DialogResult.OK;

				// update global variable
				omglobal.IMAGE_LOCATION_PATH = txtImageLocation.Text;
			}
			else
			{
				DialogResult = DialogResult.Cancel;
			}
		}

		private void txtNonVATRate_TextChanged(object sender, EventArgs e)
		{
			if (Information.IsNumeric(txtNonVATRate.Text)) _nonVATFactor = Convert.ToDecimal(txtNonVATRate.Text) / 100;
			else _nonVATFactor = 0.00m;
		}

		private void txtVATRate_TextChanged(object sender, EventArgs e)
		{
			if (Information.IsNumeric(txtVATRate.Text)) _vatFactor = Convert.ToDecimal(txtVATRate.Text) / 100;
			else _vatFactor = 0.00m;
		}

		private void btnImageLocation_Click(object sender, EventArgs e)
		{
			txtImageLocation.Text = OMUtils.GetFolderPath();
		}

		#region class field member

		private ActionMode _mode = ActionMode.None;
		private string _companyId = string.Empty;
		private decimal _nonVATFactor;
		private decimal _vatFactor;

		#endregion

		#region class properties

		public ActionMode Mode
		{
			set { _mode = value; }
		}

		public string CompanyId
		{
			set { _companyId = value; }
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end UpdateUI


		private void GetCompanyProfileInfo(string CompanyId)
		{
			COMPANY_PROFILES _cf;
			if (string.IsNullOrEmpty(CompanyId))
			{
				_cf = new COMPANY_PROFILES();
				_cf.ADDRESS = string.Empty;
				_cf.COMPANYID = string.Empty;
				_cf.COMPANYNAME = string.Empty;
				_cf.COUNTRY = string.Empty;
				_cf.HOME_CURRENCY = omglobal.HOME_CURRENCY;
				_cf.ID = 0;
				_cf.IMAGE_LOCATION = omglobal.IMAGE_LOCATION_PATH;
				_cf.MATERIAL_MARKUP_FACTOR = omglobal.DEFAULT_SILVER_MARKUP_FACTOR;
				_cf.NON_VAT_FACTOR = 0.00m;
				_cf.NON_VAT_RATE = "0";
				_cf.POSTAL = string.Empty;
				_cf.PRODUCTION_HOUR_RATE = 0.00m;
				_cf.PROVINCE = string.Empty;
				_cf.SOURCE_CURRENCY = "USD";
				_cf.SOURCE_VALUE = 0.00m;
				_cf.TAXID = string.Empty;
				_cf.VAT_FACTOR = 7.00m;
				_cf.VAT_RATE = "7.00";
			    _cf.NONVAT_DISPLAY = false;
			}
			else
			{
				_cf = new CompanyProfileModel().GetCpmpanyProfileInfo(CompanyId);
			}

			txtAdddress.Text = _cf.ADDRESS;
			txtCompanyName.Text = _cf.COMPANYNAME;
			txtCountry.Text = _cf.COUNTRY;
			txtPostal.Text = _cf.POSTAL;
			txtProvince.Text = _cf.PROVINCE;
			txtTaxId.Text = _cf.TAXID;
			txtNonVATRate.Text = _cf.NON_VAT_RATE;
			txtVATRate.Text = _cf.VAT_RATE;
			txtMaterialMarkupFactor.Text = $"{ _cf.MATERIAL_MARKUP_FACTOR:N3}";
			txtHomeCurrency.Text = _cf.HOME_CURRENCY;
			txtSourceCurrency.Text = _cf.SOURCE_CURRENCY;
			ntxtSourceValue.Text = $"{_cf.SOURCE_VALUE:N2}";
			txtImageLocation.Text = _cf.IMAGE_LOCATION;
			txtProductionHourRate.Text = _cf.PRODUCTION_HOUR_RATE.ToString();
		    chkNonVATDisplay.Checked = _cf.NONVAT_DISPLAY;

		} // end GetCompanyProfileInfo

		private bool UpdateCompanyProfile(string CompanyId)
		{
			var _result = false;

			var cf = new COMPANY_PROFILES();

			switch (_mode)
			{
				case ActionMode.Add:
					cf = new COMPANY_PROFILES();
					cf.COMPANYID = _companyId;
					break;
				case ActionMode.Edit:
					cf = new CompanyProfileModel().GetCpmpanyProfileInfo(CompanyId);
					break;
			}


			cf.COMPANYNAME = txtCompanyName.Text;
			cf.ADDRESS = txtAdddress.Text;
			cf.COUNTRY = txtCountry.Text;
			cf.NON_VAT_FACTOR = _nonVATFactor;
			cf.NON_VAT_RATE = txtNonVATRate.Text;
			cf.POSTAL = txtPostal.Text;
			cf.PROVINCE = txtProvince.Text;
			cf.TAXID = txtTaxId.Text;
			cf.VAT_FACTOR = _vatFactor;
			cf.VAT_RATE = txtVATRate.Text;
			cf.MATERIAL_MARKUP_FACTOR = Convert.ToDecimal(txtMaterialMarkupFactor.Text);
			cf.HOME_CURRENCY = txtHomeCurrency.Text;
			cf.SOURCE_CURRENCY = txtSourceCurrency.Text;
			cf.SOURCE_VALUE = Convert.ToDecimal(ntxtSourceValue.Text);
			cf.IMAGE_LOCATION = txtImageLocation.Text;
			cf.PRODUCTION_HOUR_RATE = Convert.ToDecimal(txtProductionHourRate.Text);
		    cf.NONVAT_DISPLAY = chkNonVATDisplay.Checked;

			if (new CompanyProfileModel().UpdateCompanyProfile(cf) > 0)
			{
				_result = true;
				MessageBox.Show("Company Profile has been updated !!!", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			return _result;
		} // end UpdateCurrentCompanyProfile

		#endregion
	}
}