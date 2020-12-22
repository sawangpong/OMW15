using System;
using System.Windows.Forms;
using OMW15.Models.SaleModel;
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class SalemanInfo : Form
	{
		public SalemanInfo(int SalemanId = 0)
		{
			InitializeComponent();
			_salemanId = SalemanId;
			lbMode.Text = (_mode = _salemanId == 0 ? ActionMode.Add : ActionMode.Edit).ToString();
		}

		private void SalemanInfo_Load(object sender, EventArgs e)
		{
			GetSalemanInfo(_salemanId);
		}

		private void txtSalemanName_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var _s = new SALE_PERSON_PROFILE();
			if (_mode == ActionMode.Add)
				_s.SALEID = 0;
			else
				_s.SALEID = _salemanId;
			_s.ISACTIVE = chkActiveSaleman.Checked;
			_s.EMAIL1 = txtEmail1.Text;
			_s.EMAIL2 = txtEmail2.Text;
			_s.MOBILE = txtMobile.Text;
			_s.SALE_PERSON = txtSalemanName.Text;

			if (new SalemanDAL().UpdateSaleMan(_s) > 0)
				MessageBox.Show("Update Sale Person completed.....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#region class field member

		private SALE_PERSON_PROFILE _sale;
		private readonly ActionMode _mode = ActionMode.None;
		private readonly int _salemanId;

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnSave.Enabled = string.IsNullOrEmpty(txtSalemanName.Text) == false;
		} // end UpdateUI

		private void GetSalemanInfo(int Id)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_sale = new SALE_PERSON_PROFILE();
					chkActiveSaleman.Checked = true;
					break;
				case ActionMode.Edit:
					_sale = new SalemanDAL().GetSalePersonInfo(Id);
					chkActiveSaleman.Checked = _sale.ISACTIVE;
					break;
			}

			txtSalemanName.Text = _sale.SALE_PERSON;
			txtMobile.Text = _sale.MOBILE;
			txtEmail1.Text = _sale.EMAIL1;
			txtEmail2.Text = _sale.EMAIL2;
		} // end GetSalemanInfo

		#endregion
	}
}