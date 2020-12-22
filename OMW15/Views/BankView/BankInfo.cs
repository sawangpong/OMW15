using System;
using System.Windows.Forms;
using OMW15.Models.BankModel;
using OMW15.Shared;

namespace OMW15.Views.BankView
{
	public partial class BankInfo : Form
	{
		public BankInfo(int BankId)
		{
			InitializeComponent();

			_mode = BankId == 0 ? ActionMode.Add : ActionMode.Edit;
			lbTitle.Text = $"Bank Account Info ({_mode})";
			this.BankId = BankId;
		}

		#region class property

		public int BankId { get; set; }

		#endregion

		private void BankInfo_Load(object sender, EventArgs e)
		{
			CenterToParent();
			GetBankAccountType();
			GetBankInfo(_mode, BankId);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var _b = new BANK();
			switch (_mode)
			{
				case ActionMode.Add:
					_b.BANKID = 0;
					break;
				case ActionMode.Edit:
					_b.BANKID = BankId;
					break;
			}

			_b.ACCOUNTBRANCH = txtBranch.Text;
			_b.ACCOUNTNAME = txtACName.Text;
			_b.ACCOUNTNO = txtACNo.Text;
			_b.ACCOUNTTYPE = cbxACType.Text;
			_b.BANKCODE = txtBankCode.Text;
			_b.BANKNAME = txtBankNameEn.Text;
			_b.BANKTHNAME = txtBankNameTh.Text;
			_b.INACTIVE = cbxAccountDisable.Text == "No" ? false : true;
			_b.SWIFTCODE = txtSwift.Text;

			if (new BankDAL().UpdateBankInfo(_b) > 0)
				MessageBox.Show(_mode == ActionMode.Add ? "Add Bank Info successfully" : "Update Bank Info successfully..",
					"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#region class field member

		private readonly ActionMode _mode = ActionMode.None;
		private BANK _bank = new BANK();

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			txtBankCode.Enabled = _mode == ActionMode.Add;
		} // end UpdateUI


		private void GetBankAccountType()
		{
			cbxACType.DataSource = new BankDAL().GetBankAccountTypeList();
			cbxACType.DisplayMember = "ACCOUNTTYPE";
			cbxACType.ValueMember = "ACCOUNTTYPE";
		} // end GetBankAccountType


		private void GetBankInfo(ActionMode Mode, int BankId)
		{
			switch (Mode)
			{
				case ActionMode.Add:
					_bank.SWIFTCODE = string.Empty;
					_bank.ACCOUNTBRANCH = string.Empty;
					_bank.ACCOUNTNAME = string.Empty;
					_bank.ACCOUNTNO = string.Empty;
					_bank.ACCOUNTTYPE = string.Empty;
					_bank.BANKCODE = string.Empty;
					_bank.BANKNAME = string.Empty;
					_bank.BANKTHNAME = string.Empty;
					_bank.INACTIVE = false;

					break;
				case ActionMode.Edit:
					_bank = new BankDAL().GetBankInfo(BankId);
					break;
			}

			// mapping data to control
			txtBankCode.Text = _bank.BANKCODE;
			txtBankNameEn.Text = string.IsNullOrEmpty(_bank.BANKNAME) ? string.Empty : _bank.BANKNAME;
			txtBankNameTh.Text = string.IsNullOrEmpty(_bank.BANKTHNAME) ? string.Empty : _bank.BANKTHNAME;
			txtBranch.Text = string.IsNullOrEmpty(_bank.ACCOUNTBRANCH) ? string.Empty : _bank.ACCOUNTBRANCH;
			cbxACType.SelectedValue = string.IsNullOrEmpty(_bank.ACCOUNTTYPE) ? string.Empty : _bank.ACCOUNTTYPE;
			txtACName.Text = string.IsNullOrEmpty(_bank.ACCOUNTNAME) ? string.Empty : _bank.ACCOUNTNAME;
			txtACNo.Text = string.IsNullOrEmpty(_bank.ACCOUNTNO) ? string.Empty : _bank.ACCOUNTNO;
			txtSwift.Text = string.IsNullOrEmpty(_bank.SWIFTCODE) ? string.Empty : _bank.SWIFTCODE;
			cbxAccountDisable.Text = _bank.INACTIVE ? "Yes" : "No";
			UpdateUI();
		}

		#endregion
	}
}