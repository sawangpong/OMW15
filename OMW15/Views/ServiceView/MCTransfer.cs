using System;
using System.Windows.Forms;
using OMW15.Models.ServiceModel;
using OMW15.Views.CustomerView;
using OMW15.Views.ProductView;

namespace OMW15.Views.ServiceView
{
	public partial class MCTransfer : Form
	{
		public MCTransfer()
		{
			InitializeComponent();
		}

		private void MCTransfer_Load(object sender, EventArgs e)
		{
			CenterToParent();
			// setting info
			SettingMCTransferInfo();
		}

		private void btnNewCustomer_Click(object sender, EventArgs e)
		{
			GetCustomer();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			// update transfer

			var mc = new MIX();

			mc.isnewproduct = rdoNewMC.Checked;
			mc.acccustcode = txtNewOwner.Tag.ToString();
			mc.auditdt = DateTime.Now;
			mc.audituser = omglobal.UserInfo;
			mc.cus_na = txtNewOwner.Text;
			mc.custid = _newOwnerId;
			mc.transferdate = dtpTransferDate.Value;
			mc.sale_date = dtpTransferDate.Value;
			mc.exp = dtpTransferDate.Value;
			mc.remark = txtRemark.Text;
			mc.istransfer = false;
			mc.isdelete = false;
			mc.isexpire = true;
			mc.modidt = DateTime.Now;
			mc.modiuser = omglobal.UserInfo;
			mc.monthexpire = dtpTransferDate.Value.Month;
			mc.monthfactor = Convert.ToInt32(txtWarranty.Tag);
			mc.monthsale = dtpTransferDate.Value.Month;
			mc.productid = ModelId;
			mc.type = txtModel.Text;
			mc.s_no = txtSN.Text;
			mc.qtysale = 1;
			mc.warrantyterm = _warrantyTerm;
			mc.yearexpire = dtpTransferDate.Value.Year;
			mc.yearsale = dtpTransferDate.Value.Year;

			if (new MachineDAL().UpdateTransferMachine(mc) > 0)
			{
				this.IsSuccessTransferred = true;
				this.TransferDate = mc.transferdate.Value;
				//if (new MachineDAL().UpdateLastOwnerBeforeTransferMachine(MachineId, mc.transferdate.Value) > 0)
				//{
				//	MessageBox.Show("Transfer Machine successfully....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//}
			}
		}

		private void btnWarranty_Click(object sender, EventArgs e)
		{
			using (var _wl = new ProductWarrantyList())
			{
				if (_wl.ShowDialog(this) == DialogResult.OK)
				{
					_warrantyTerm = _wl.WarrantyId;
					txtWarranty.Text = _wl.WarrantyTerm;
					txtWarranty.Tag = _wl.WarrantyMonthFactor;
				}
			}
		}

		private void txtLastOwner_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void txtModel_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		#region class field member

		private int _newOwnerId;
		private int _warrantyTerm;

		#endregion

		#region class property

		public int MachineId { get; set; }

		public int CustomerId { get; set; }

		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }

		public string Model { get; set; }

		public string ModelId { get; set; }

		public string SerialNo { get; set; }

		public bool IsSuccessTransferred { get; set; }
		public DateTime TransferDate { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetCustomer()
		{
			using (var _cust = new CustomerSearch())
			{
				if (_cust.ShowDialog(this) == DialogResult.OK)
				{
					txtNewOwner.Text = _cust.CustomerName;
					txtNewOwner.Tag = _cust.ERPCustomerCode;
					_newOwnerId = _cust.ERPCustomerId;
				}
				else
				{
					txtNewOwner.Text = "";
					txtNewOwner.Tag = "";
					_newOwnerId = 0;
				}
			}
		} // end GetCustomer

		private void SettingMCTransferInfo()
		{
			txtLastOwner.Text = CustomerName;
			txtModel.Text = Model;
			txtSN.Text = SerialNo;

			dtpTransferDate.Value = DateTime.Today;
			rdoUsedMC.Checked = true;
		} // end SettingMCTransferInfo

		#endregion
	}
}