using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace OMW15.Master.MasterView
{
	public partial class MasterCustomerInfo : Form
	{
		#region class field member

		private string _customerCode = string.Empty;
		private ActionMode _mode = ActionMode.None;
		private SelectTypeOption _option = SelectTypeOption.None;

		#endregion

		#region class property

		public ActionMode Mode
		{
			set
			{
				_mode = value;
			}
		}

		public string CustomerCode
		{
			set
			{
				_customerCode = value;
			}
		}


		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.pnlCommand.Visible = (_mode == ActionMode.Edit);
			switch(_mode)
			{
				case ActionMode.View:
					foreach(Control ctl in this.Controls)
					{
						if(ctl is Panel)
						{
							foreach(Control c in ctl.Controls)
							{
								if(c is TextBox)
								{
									((TextBox)c).ReadOnly = true;
								}
								if(c is CheckBox)
								{
									(c as CheckBox).Enabled = false;
								}
								if(c is Button)
								{
									(c as Button).Enabled = false;
								}
							}
						}
					}
					break;
				case ActionMode.Edit:
					this.txtContactPerson.ReadOnly = false;
					this.txtCountry.ReadOnly = this.txtContactPerson.ReadOnly;
					this.txtCurrency.ReadOnly = this.txtContactPerson.ReadOnly;
					this.txtDistrict.ReadOnly = this.txtContactPerson.ReadOnly;
					this.txtLabourCreditAmount.ReadOnly = this.txtContactPerson.ReadOnly;
					this.txtMatCreditAmount.ReadOnly = this.txtContactPerson.ReadOnly;
					this.txtSalePerson.ReadOnly = this.txtContactPerson.ReadOnly;
					this.txtVATRate.ReadOnly = this.txtContactPerson.ReadOnly;
					this.btnCountry.Enabled = true;
					this.btnCurrency.Enabled = this.btnCountry.Enabled;
					this.btnDistrict.Enabled = this.btnCountry.Enabled;
					this.btnSalePerson.Enabled = this.btnCountry.Enabled;
					this.btnVAT.Enabled = this.btnCountry.Enabled;
					break;
			}

		} // end UpdateUI

		private void GetCustomerInfo(string CustomerCode)
		{
			// get local-customer info
			OLDMOONEF _oldmoon = new OLDMOONEF();
			var _localCusts = (from c in _oldmoon.CUSTOMER1.AsParallel()
							   where c.CUSTCODE == CustomerCode
							   select c).ToList();

			if(_localCusts == null)
			{
				omglobal.DisplayAlert("Alert", "Can't find this customer for local database....");
			}


			// get master-customer info
			ERP _erp = new ERP();
			var _custs = (from _adb in _erp.ADDRBOOKs
						  join _ara in _erp.ARADDRESSes on _adb.ADDB_KEY equals _ara.ARA_ADDB
						  join _ar in _erp.ARFILEs on _ara.ARA_AR equals _ar.AR_KEY
						  join _arCat in _erp.ARCATs on _ar.AR_ARCAT equals _arCat.ARCAT_KEY
						  where _ar.AR_CODE == CustomerCode
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
							  CustomerCategoryKey = _ar.AR_ARCAT,
						  }).ToList();

			// join customer-info
			var _custInfo = (from ar in _custs
							 join lc in _localCusts on ar.CustomerCode equals lc.CUSTCODE
							 select new
							 {
								 CustomerCode = ar.CustomerCode,
								 CustomerName = ar.CustomerName,
								 Branch = ar.Branch,
								 IsHeadQuarters = lc.ISHEADQUARTERS,
								 BranchNumber = lc.BRANCHNUMBER,
								 TaxId = ar.TaxId,
								 Address1 = ar.Address1,
								 Address2 = ar.Address2,
								 address3 = ar.Address3,
								 District = lc.DISTRICT,
								 Province = ar.Province,
								 Country = lc.COUNTRY,
								 Postal = ar.Postal,
								 Phone = ar.Phone,
								 Fax = ar.Fax,
								 Mobile = lc.CELLPHONE1,
								 Email = ar.Email,
								 Web = ar.Web,
								 ContactName = lc.CONTACTPERSON,
								 SalePerson = lc.SALEPERSON,
								 IsVAT = lc.VATABLE,
								 VatRate = lc.VATRATE,
								 Currency = lc.CURRENCY,
								 Credit = lc.CREDITLIMIT,
								 MaterialCredit = lc.MATERIALLIMIT
							 }).FirstOrDefault();

			// map to control for display
			// 

			if(_custInfo != null)
			{
				this.txtCustomerCode.Text = _custInfo.CustomerCode;
				this.txtCustomerName.Text = _custInfo.CustomerName;
				this.txtAdd1.Text = _custInfo.Address1;
				this.txtAdd2.Text = _custInfo.Address2;
				this.txtAdd3.Text = _custInfo.address3;
				this.txtDistrict.Text = _custInfo.District;
				this.txtProvince.Text = _custInfo.Province;
				this.txtCountry.Text = _custInfo.Country;
				this.txtPostal.Text = _custInfo.Postal;
				this.txtPhone.Text = _custInfo.Phone;
				this.txtFax.Text = _custInfo.Fax;
				this.txtTaxId.Text = _custInfo.TaxId;
				this.txtBranch.Text = _custInfo.Branch;
				this.chkIsHeadQuarters.Checked = (bool)_custInfo.IsHeadQuarters;
				this.txtBranchNumber.Text = _custInfo.BranchNumber.ToString();
				this.txtEmail.Text = _custInfo.Email;
				this.txtWebsite.Text = _custInfo.Web;
				this.txtCurrency.Text = _custInfo.Currency;
				this.txtLabourCreditAmount.Text = string.Format("{0:N0}", _custInfo.Credit);
				this.txtMatCreditAmount.Text = string.Format("{0:N0}", _custInfo.MaterialCredit);
				this.chkVATable.Checked = _custInfo.IsVAT;
				this.txtVATRate.Text = _custInfo.VatRate;
				this.txtSalePerson.Text = _custInfo.SalePerson;
				this.txtContactPerson.Text = _custInfo.ContactName;
			}
			else
			{
				omglobal.DisplayAlert("Alert", "Can't find the specify Customer....");
			}

		} // end GetCustomerInfo

		private void GetSelectOption(SelectTypeOption Option)
		{
			SelectTypeOption option = Option;
			string _currentName = string.Empty;
			string _currentCode = string.Empty;
			string _currentId = string.Empty;

			string _selectedName = string.Empty;
			string _selectedCode = string.Empty;
			int _selectedId = 0;

			switch(Option)
			{
				case SelectTypeOption.District:
					_currentName = this.txtDistrict.Text;
					break;
				case SelectTypeOption.Country:
					_currentName = this.txtCountry.Text;
					break;
				case SelectTypeOption.Currency:
					_currentCode = this.txtCurrency.Text;
					break;
				case SelectTypeOption.VatRate:
					_currentName = this.txtVATRate.Text;
					break;
				case SelectTypeOption.SaleMan:
					_currentName = this.txtSalePerson.Text;
					break;
			}

			Tools.SelectOptions.GetData(option, ref _selectedName, ref _selectedCode, ref _selectedId);


			//Tools.SelectBox _selectBox = new Tools.SelectBox();
			//_selectBox.SelectOption = Option;
			//_selectBox.StartPosition = FormStartPosition.CenterScreen;
			//if (_selectBox.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			//{
			switch(Option)
			{
				case SelectTypeOption.District:
					this.txtDistrict.Text = string.IsNullOrEmpty(_selectedName) ? _currentName : _selectedName;
					break;
				case SelectTypeOption.Country:
					this.txtCountry.Text = string.IsNullOrEmpty(_selectedName) ? _currentName : _selectedName;
					break;
				case SelectTypeOption.Currency:
					this.txtCurrency.Text = string.IsNullOrEmpty(_selectedCode) ? _currentCode : _selectedCode;
					break;
				case SelectTypeOption.VatRate:
					this.txtVATRate.Text = string.IsNullOrEmpty(_selectedName) ? _currentName : _selectedName;
					break;
				case SelectTypeOption.SaleMan:
					this.txtSalePerson.Text = string.IsNullOrEmpty(_selectedName) ? _currentName : _selectedName;
					break;
			}
			//}

		} // end GetSelectOption

		private void UpdateCustomerInfo(string CustomerCode)
		{
			//using(var scope = new System.Transactions.TransactionScope())
			//{
				OLDMOONEF _oldmoon = new OLDMOONEF();
				var _custInfo = (from c in _oldmoon.CUSTOMER1
								 where c.CUSTCODE == CustomerCode
								 select c).FirstOrDefault();
				try
				{
					//CUSTOMER1 _custInfo = new CUSTOMER1();
					_custInfo.CONTACTPERSON = this.txtContactPerson.Text;
					_custInfo.CURRENCY = this.txtCurrency.Text;
					_custInfo.COUNTRY = this.txtCountry.Text;
					_custInfo.VATRATE = this.txtVATRate.Text;
					_custInfo.DISTRICT = this.txtDistrict.Text;
					_custInfo.SALEPERSON = this.txtSalePerson.Text;
					_custInfo.CREDITLIMIT = Convert.ToDecimal(this.txtLabourCreditAmount.Text);
					_custInfo.MATERIALLIMIT = Convert.ToDecimal(this.txtMatCreditAmount.Text);
					_custInfo.MODIDATE = DateTime.Now;
					_custInfo.MODIUSER = omglobal.UserName;
					_custInfo.ISHEADQUARTERS = this.chkIsHeadQuarters.Checked;
					_custInfo.VATABLE = this.chkVATable.Checked;

					if(Master.MasterController.SearchMasterCustomers.UpdateCustomerForLocalDB(_custInfo, CustomerCode) > 0)
					{
						omglobal.DisplayAlert("Update", "Update Customer Info (local DB) successfully....");
					}

					//_oldmoon.SaveChanges();
					//scope.Complete();
				}
				catch(OptimisticConcurrencyException ex)
				{
					//scope.Dispose();
					throw new Exception("Update Customer Info (IN) error!!!!!", ex);
				}
				


		} // end UpdateCustomerInfo


		#endregion

		public MasterCustomerInfo()
		{
			InitializeComponent();
		}

		private void MasterCustomerInfo_Load(object sender, EventArgs e)
		{
			// Disply-Mode call
			this.tslbMode.Text = string.Format("({0})", _mode.ToString());

			// Get Customer-Info by mode
			this.GetCustomerInfo(_customerCode);

			// Update-UI
			this.UpdateUI();

		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOption_Click(object sender, EventArgs e)
		{
			Button b = sender as Button;
			switch(b.Tag.ToString().ToUpper())
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
			this.GetSelectOption(_option);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.UpdateCustomerInfo(_customerCode);
		}
	}
}
