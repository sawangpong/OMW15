using System;
using System.Windows.Forms;
using OMW15.Models.SaleModel;
using OMW15.Shared;
using OMW15.Views.CustomerView;

namespace OMW15.Views.Sales
{
	public partial class SaleContactInfo : Form
	{
		public SaleContactInfo(int ContactId)
		{
			InitializeComponent();
			this.ContactId = ContactId;
		}

		#region class property

		public int ContactId { get; set; }

		#endregion

		private void SaleContactInfo_Load(object sender, EventArgs e)
		{
			CenterToParent();
			lbMode.Text = (_mode = ContactId == 0 ? ActionMode.Add : ActionMode.Edit).ToString();

			GetContactInfo(ContactId);
		}

		private void btnSearchCustomer_Click(object sender, EventArgs e)
		{
			GetCustomerInfo();
		}

		private void btnCountry_Click(object sender, EventArgs e)
		{
			var _delTerm = new DelTerm(OMShareSaleEnum.SaleContentInfo.SaleContactCountry);
			_delTerm.StartPosition = FormStartPosition.CenterScreen;
			if (_delTerm.ShowDialog(this) == DialogResult.OK) txtCounrty.Text = _delTerm.Result;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			AddOrUpdateSaleContact();
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		#region class field member

		private ActionMode _mode = ActionMode.None;
		private int _customerId;

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnSave.Enabled = !string.IsNullOrEmpty(txtContactId.Text)
			                  && !string.IsNullOrEmpty(txtContactName.Text)
			                  && !string.IsNullOrEmpty(txtCounrty.Text);
		} // end UpdateUI

		private void GetContactInfo(int ContactId)
		{
			var _scon = new SALE_CONTACTS();

			// when ContactId value
			// Add		= 0
			// Modify	> 0

			if (ContactId > 0) // modify
			{
				_scon = new SaleDAL().GetSaleContactInfo(ContactId);
				txtContactId.Text = _scon.CONTACT_ID.ToString();
			}
			else
			{
				txtContactId.Text = "***NEW***";
			}

			_customerId = _mode == ActionMode.Add ? 0 : _scon.CUSTID;
			txtContactName.Text = _scon.CONTACT_NAME;
			txtAddress.Text = _scon.ADDRESS;
			txtCounrty.Text = _scon.COUNTRY;
			txtCompany.Text = _scon.COMPANY;
			txtCompany.Tag = _mode == ActionMode.Add ? "" : _scon.CUSTCODE;
			txtPerson.Text = _scon.CONTACT_PERSON;
			txtMoblie.Text = _scon.MOBILE;
			txtEmail.Text = _scon.EMAIL;
			txtPhone.Text = _scon.TEL;
			txtFax.Text = _scon.FAX;
			txtPostal.Text = _scon.POSTAL;

			UpdateUI();
		} // end GetContactInfo


		private void GetCustomerInfo()
		{
			using (var _cust = new CustomerSearch())
			{
				_cust.FormBorderStyle = FormBorderStyle.SizableToolWindow;
				if (_cust.ShowDialog(this) == DialogResult.OK)
				{
					txtCompany.Text = _cust.CustomerName;
					_customerId = _cust.ERPCustomerId;
					txtCompany.Tag = _cust.ERPCustomerCode;
					txtAddress.Text = _cust.CustomerAddress;
					txtFax.Text = _cust.Fax;
					txtPostal.Text = _cust.Postal;
					txtPhone.Text = _cust.Phone;
					txtEmail.Text = _cust.Email;
				}
			}
		} // end GetCustomer

		private void AddOrUpdateSaleContact()
		{
			var _scon = new SALE_CONTACTS();

			switch (_mode)
			{
				case ActionMode.Add:
					_customerId = 0;
					_scon.CONTACT_ID = 0;
					break;
				case ActionMode.Edit:
					_scon = new SaleDAL().GetSaleContactInfo(ContactId);
					_scon.CONTACT_ID = ContactId;
					break;
			}

			_scon.CONTACT_NAME = txtContactName.Text;
			_scon.CUSTCODE = string.IsNullOrEmpty(txtCompany.Tag.ToString()) ? "" : txtCompany.Tag.ToString().ToUpper();
			_scon.CUSTID = _customerId;
			_scon.COMPANY = txtCompany.Text;
			_scon.ADDRESS = txtAddress.Text;
			_scon.COUNTRY = txtCounrty.Text;
			_scon.POSTAL = txtPostal.Text;
			_scon.CONTACT_PERSON = txtPerson.Text;
			_scon.EMAIL = txtEmail.Text;
			_scon.TEL = txtPhone.Text;
			_scon.FAX = txtFax.Text;
			_scon.MOBILE = txtMoblie.Text;

			if (new SaleDAL().UpdateSaleContact(_scon) > 0)
				MessageBox.Show("Insert/Update Sale Contact successfully", "Message", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
		} // end AddOrUpdateSaleContact

		#endregion
	}
}