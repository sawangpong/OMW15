using OMW15.Controllers.ToolController;
using OMW15.Models.CustomerModel;
using OMW15.Shared;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.CustomerView
{
	public partial class MasterCustomerInfo : Form
	{
		public MasterCustomerInfo()
		{
			InitializeComponent();
		}

		private void MasterCustomerInfo_Load(object sender, EventArgs e)
		{
			CenterToParent();
			// Display-Mode call
			tslbMode.Text = string.Format("({0})", _mode);

			// Get Customer-Info by mode
			GetCustomerInfo(_customerCode);

			// Update-UI
			UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOption_Click(object sender, EventArgs e)
		{
			var b = sender as Button;
			switch (b.Tag.ToString().ToUpper())
			{
				case "CURRENCY":
					_option = SelectTypeOption.Currency;
					break;
				case "COUNTRY":
					_option = SelectTypeOption.Country;
					break;
				case "DISTRICT":
					_option = SelectTypeOption.District;
					break;
				case "VAT_RATE":
					_option = SelectTypeOption.VatRate;
					break;
				case "SALE_MAN":
					_option = SelectTypeOption.SaleMan;
					break;
			}
			GetSelectOption(_option);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			UpdateCustomerInfo(_customerCode);
		}

		#region class field member

		private string _customerCode = string.Empty;
		private ActionMode _mode = ActionMode.None;
		private SelectTypeOption _option = SelectTypeOption.None;

		#endregion

		#region class property

		public ActionMode Mode
		{
			set { _mode = value; }
		}

		public string CustomerCode
		{
			set { _customerCode = value; }
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			pnlCommand.Visible = _mode == ActionMode.Edit;
			switch (_mode)
			{
				case ActionMode.View:
					foreach (Control ctl in Controls)
						if (ctl is Panel)
							foreach (Control c in ctl.Controls)
							{
								if (c is TextBox) ((TextBox)c).ReadOnly = true;
								if (c is CheckBox) (c as CheckBox).Enabled = false;
								if (c is Button) (c as Button).Enabled = false;
							}
					break;
				case ActionMode.Edit:
					txtContactPerson.ReadOnly = false;
					txtCountry.ReadOnly = txtContactPerson.ReadOnly;
					txtCurrency.ReadOnly = txtContactPerson.ReadOnly;
					txtDistrict.ReadOnly = txtContactPerson.ReadOnly;
					txtLabourCreditAmount.ReadOnly = txtContactPerson.ReadOnly;
					txtMatCreditAmount.ReadOnly = txtContactPerson.ReadOnly;
					txtSalePerson.ReadOnly = txtContactPerson.ReadOnly;
					txtVATRate.ReadOnly = true;
					txtContactPhone.ReadOnly = txtContactPerson.ReadOnly;
					txtContactFax.ReadOnly = txtContactPerson.ReadOnly;
					txtContactMobile.ReadOnly = txtContactPerson.ReadOnly;
					txtContactEmail.ReadOnly = txtContactPerson.ReadOnly;
					txtWebsite.ReadOnly = txtContactPerson.ReadOnly;
					txtCustomerRemark.ReadOnly = txtContactPerson.ReadOnly;

					btnCountry.Enabled = true;
					btnCurrency.Enabled = btnCountry.Enabled;
					btnDistrict.Enabled = btnCountry.Enabled;
					btnSalePerson.Enabled = btnCountry.Enabled;
					btnVAT.Enabled = btnCountry.Enabled;
					break;
			}
		} // end UpdateUI

		private void GetCustomerInfo(string CustomerCode)
		{
			// get local-customer info
			var _oldmoon = new OLDMOONEF1();
			var _localCusts = (from c in _oldmoon.CUSTOMERS.AsParallel()
									 where c.CUSTCODE == CustomerCode
									 select c).ToList();

			if (_localCusts == null) Alert.DisplayAlert("Alert", "Can't find this customer for local database....");

			// get master-customer info
			var _erp = new ERP();
			var _custs = (from _adb in _erp.ADDRBOOKs
							  join _ara in _erp.ARADDRESSes on _adb.ADDB_KEY equals _ara.ARA_ADDB
							  join _ar in _erp.ARFILEs on _ara.ARA_AR equals _ar.AR_KEY
							  join _arCat in _erp.ARCATs on _ar.AR_ARCAT equals _arCat.ARCAT_KEY
							  where _ar.AR_CODE == CustomerCode && _ara.ARA_DEFAULT == "Y"

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
								  TaxId = _adb.ADDB_TAX_ID,
								  Branch = _adb.ADDB_BRANCH,
								  CategoryName = _arCat.ARCAT_NAME,
								  CategoryKey = _arCat.ARCAT_KEY,
								  CustomerCategoryKey = _ar.AR_ARCAT
							  }).ToList();

			// join customer-info
			var _custInfo = (from ar in _custs
								  join lc in _localCusts on ar.CustomerCode equals lc.CUSTCODE
								  select new
								  {
									  ar.CustomerCode,
									  ar.CustomerName,
									  ar.Branch,
									  IsHeadQuarters = lc.ISHEADQUARTERS,
									  BranchNumber = lc.BRANCHNUMBER,
									  ar.TaxId,
									  ar.Address1,
									  ar.Address2,
									  address3 = ar.Address3,
									  District = lc.DISTRICT,
									  ar.Province,
									  Country = lc.COUNTRY,
									  ar.Postal,
									  ar.Phone,
									  ar.Fax,
									  ar.Email,
									  ContactName = lc.CONTACTPERSON,
									  ContactPhone = lc.TEL,
									  ContactFax = lc.FAX,
									  ContactMobile = lc.CELLPHONE1,
									  ContactEmail = lc.CUSTEMAIL,
									  Web = lc.CUSTWWW,
									  SalePerson = lc.SALEPERSON,
									  IsVAT = lc.VATABLE,
									  VatRate = lc.VATRATE,
									  Currency = lc.CURRENCY,
									  Credit = lc.CREDITLIMIT,
									  MaterialCredit = lc.MATERIALLIMIT,
									  CustRemark = lc.CUSTREMARK
								  }).FirstOrDefault();

			// map to control for display
			// 

			if (_custInfo != null)
			{
				txtCustomerCode.Text = _custInfo.CustomerCode;
				txtCustomerName.Text = _custInfo.CustomerName;
				txtAdd1.Text = _custInfo.Address1;
				txtAdd2.Text = _custInfo.Address2;
				txtAdd3.Text = _custInfo.address3;
				txtDistrict.Text = _custInfo.District;
				txtProvince.Text = _custInfo.Province;
				txtCountry.Text = _custInfo.Country;
				txtPostal.Text = _custInfo.Postal;
				txtPhone.Text = _custInfo.Phone;
				txtFax.Text = _custInfo.Fax;
				txtTaxId.Text = _custInfo.TaxId;
				txtBranch.Text = _custInfo.Branch;
				chkIsHeadQuarters.Checked = (bool)_custInfo.IsHeadQuarters;
				txtBranchNumber.Text = _custInfo.BranchNumber.ToString();
				txtEmail.Text = _custInfo.Email;
				txtWebsite.Text = _custInfo.Web;
				txtCurrency.Text = _custInfo.Currency;
				txtLabourCreditAmount.Text = string.Format("{0:N0}", _custInfo.Credit);
				txtMatCreditAmount.Text = string.Format("{0:N0}", _custInfo.MaterialCredit);
				chkVATable.Checked = _custInfo.IsVAT;
				txtVATRate.Text = _custInfo.VatRate;
				txtSalePerson.Text = _custInfo.SalePerson;
				txtContactPerson.Text = _custInfo.ContactName;
				txtContactPhone.Text = _custInfo.ContactPhone;
				txtContactFax.Text = _custInfo.ContactFax;
				txtContactMobile.Text = _custInfo.ContactMobile;
				txtContactEmail.Text = _custInfo.ContactEmail;
				txtCustomerRemark.Text = _custInfo.CustRemark;
			}
			else
			{
				Alert.DisplayAlert("Alert", "Can't find the specify Customer....");
			}
		} // end GetCustomerInfo

		private void GetSelectOption(SelectTypeOption Option)
		{
			var option = Option;
			var _currentName = string.Empty;
			var _currentCode = string.Empty;
			var _currentId = string.Empty;

			var _selectedName = string.Empty;
			var _selectedCode = string.Empty;
			var _selectedId = 0;

			switch (Option)
			{
				case SelectTypeOption.District:
					_currentName = txtDistrict.Text;
					break;
				case SelectTypeOption.Country:
					_currentName = txtCountry.Text;
					break;
				case SelectTypeOption.Currency:
					_currentCode = txtCurrency.Text;
					break;
				case SelectTypeOption.VatRate:
					_currentName = txtVATRate.Text;
					break;
				case SelectTypeOption.SaleMan:
					_currentName = txtSalePerson.Text;
					break;
			}

			ToolGetData.GetData(option, ref _selectedName, ref _selectedCode, ref _selectedId);

			switch (Option)
			{
				case SelectTypeOption.District:
					txtDistrict.Text = string.IsNullOrEmpty(_selectedName) ? _currentName : _selectedName;
					break;
				case SelectTypeOption.Country:
					txtCountry.Text = string.IsNullOrEmpty(_selectedName) ? _currentName : _selectedName;
					break;
				case SelectTypeOption.Currency:
					txtCurrency.Text = string.IsNullOrEmpty(_selectedCode) ? _currentCode : _selectedCode;
					break;
				case SelectTypeOption.VatRate:
					txtVATRate.Text = string.IsNullOrEmpty(_selectedName) ? _currentName : _selectedName;
					break;
				case SelectTypeOption.SaleMan:
					txtSalePerson.Text = string.IsNullOrEmpty(_selectedName) ? _currentName : _selectedName;
					break;
			}
		} // end GetSelectOption

		private void UpdateCustomerInfo(string CustomerCode)
		{
			// retrieve Customer Data from the database
			var _custInfo = new CustomerDAL().GetLocalCustomerRecord(CustomerCode);

			// put the update information
			_custInfo.CONTACTPERSON = txtContactPerson.Text;
			_custInfo.TEL = txtContactPhone.Text;
			_custInfo.FAX = txtContactFax.Text;
			_custInfo.CELLPHONE1 = txtContactMobile.Text;
			_custInfo.CUSTEMAIL = txtContactEmail.Text;
			_custInfo.DISTRICT = txtDistrict.Text;
			_custInfo.COUNTRY = txtCountry.Text;
			_custInfo.CURRENCY = txtCurrency.Text;
			_custInfo.VATRATE = txtVATRate.Text;
			_custInfo.SALEPERSON = txtSalePerson.Text;
			_custInfo.CREDITLIMIT = Convert.ToDecimal(txtLabourCreditAmount.Text);
			_custInfo.MATERIALLIMIT = Convert.ToDecimal(txtMatCreditAmount.Text);
			_custInfo.ISHEADQUARTERS = chkIsHeadQuarters.Checked;
			_custInfo.VATABLE = chkVATable.Checked;
			_custInfo.CUSTREMARK = txtCustomerRemark.Text;
			_custInfo.MODIUSER = omglobal.UserInfo;
			_custInfo.MODIDATE = DateTime.Now;

			if (new CustomerDAL().UpdateCustomerForLocalDB(_custInfo, CustomerCode) > 0)
				Alert.DisplayAlert("Update", "Update Customer Info (local DB) successfully....");
		} // end UpdateCustomerInfo

		#endregion
	}
}