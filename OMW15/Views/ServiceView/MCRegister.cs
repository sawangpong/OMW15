using Microsoft.VisualBasic;
using OMW15.Models.ProductModel;
using OMW15.Models.ServiceModel;
using OMW15.Shared;
using OMW15.Views.CustomerView;
using OMW15.Views.ProductView;
using System;
using System.Data;
using System.Windows.Forms;

namespace OMW15.Views.ServiceView
{
	public partial class MCRegister : Form
	{
		// CONSTRUCTOR
		public MCRegister(int MachineRegisterId = 0)
		{
			InitializeComponent();
			WindowState = FormWindowState.Normal;
			_mcRegisterId = MachineRegisterId;

			lbMode.Text = (_mode = _mcRegisterId == 0 ? ActionMode.Add : ActionMode.Edit).ToString();
		}

		private void MCRegister_Load(object sender, EventArgs e)
		{
			CenterToParent();
			GetMachineInfo(_mcRegisterId);
			UpdateUI();
		}

		private void dtpExpire_ValueChanged(object sender, EventArgs e)
		{
			lbStatus.Text = DateAndTime.DateDiff(DateInterval.Day, DateTime.Today, dtpExpire.Value) >= 0 ? "ACTIVE" : "EXPIRED";

			_isExpired = lbStatus.Text == "EXPIRED" ? true : false;
		}

		private void chkTransfer_Click(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void chkTransfer_CheckedChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnTransferMC_Click(object sender, EventArgs e)
		{
			lbISTransfer.Visible = true;
			using (var _mtr = new MCTransfer())
			{
				_mtr.CustomerName = txtCustomerName.Text;
				_mtr.CustomerCode = txtCustCode.Text;
				_mtr.CustomerId = _erpCustId;
				_mtr.ModelId = txtModel.Tag.ToString();
				_mtr.Model = txtModel.Text;
				_mtr.SerialNo = txtSN.Text;
				_mtr.MachineId = _mcRegisterId;

				_mtr.StartPosition = FormStartPosition.CenterParent;
				if (_mtr.ShowDialog(this) == DialogResult.OK)
				{
					_isSuccessTransferred = _mtr.IsSuccessTransferred;
					_trasferDate = _mtr.TransferDate;
				}

				lbISTransfer.Visible = false;
			}
		}

		private void btnWarranty_Click(object sender, EventArgs e)
		{
			using (var _wl = new ProductWarrantyList())
			{
				if (_wl.ShowDialog(this) == DialogResult.OK)
				{
					_warrantyId = _wl.WarrantyId;
					txtTerm.Text = _warrantyId.ToString();
					txtWarranty.Text = _wl.WarrantyTerm;
					txtWarranty.Tag = _wl.WarrantyMonthFactor;
					dtpExpire.Value = dtpSaleDate.Value.AddMonths(_wl.WarrantyMonthFactor);
				}
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			// Update Machine Record...
			UpdateMachineRecord(_mcRegisterId);
		}

		private void btnModel_Click(object sender, EventArgs e)
		{
			using (var _product = new ProductList())
			{
				_product.StartPosition = FormStartPosition.CenterScreen;

				if (_product.ShowDialog(this) == DialogResult.OK)
				{
					txtModel.Tag = _product.ModelId;
					txtModel.Text = _product.ModelName;
				}
			}
		}

		private void btnCustomer_Click(object sender, EventArgs e)
		{
			GetCustomer();
		}

		private void txtModel_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void txtCustomerName_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		#region class field member

		private readonly ActionMode _mode = ActionMode.None;
		private readonly int _mcRegisterId;
		private int _erpCustId;
		private int _warrantyId;
		private bool _isTransfered;
		private bool _isExpired;
		private bool _isSuccessTransferred = false;
		private DateTime _trasferDate = DateTime.Today;

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnModel.Enabled = btnCustomer.Enabled;
			btnTransferMC.Visible = _mode != ActionMode.Add;
			btnTransferMC.Enabled = !_isTransfered;

			btnSave.Enabled = !string.IsNullOrEmpty(txtCustomerName.Text)
							  && !string.IsNullOrEmpty(txtModel.Text);
		} // end UpdateUI

		private void GetMachineInfo(int MachineRegisterId)
		{
			var _m = new MIX();

			switch (_mode)
			{
				case ActionMode.Add:
					_m.isnewproduct = true;
					_m.istransfer = false;
					_isExpired = false;
					_m.isexpire = false;
					_m.sale_date = DateTime.Today;
					_m.exp = _m.sale_date.Value.AddYears(1);
					_m.cus_na = "";
					_m.warrantyterm = 8;
					_m.qtysale = 1;
					_isTransfered = false;
					break;
				case ActionMode.Edit:
					_m = new MachineDAL().GetMachineRegisterInfo(MachineRegisterId);
					_isTransfered = _m.istransfer;
					_isExpired = _m.isexpire;
					_warrantyId = _m.warrantyterm;

					break;
			}

			// map data

			_erpCustId = _m.custid;
			txtCustCode.Text = _m.acccustcode;
			txtCustomerName.Text = _m.cus_na;
			txtModel.Text = _m.type;
			txtModel.Tag = _m.productid;
			txtSN.Text = _m.s_no;
			dtpSaleDate.Value = _m.sale_date.Value;
			dtpExpire.Value = _m.exp.Value;
			txtQty.Text = _m.qtysale.ToString();
			txtTerm.Text = _warrantyId.ToString();
			txtWarranty.Text = new ProductDAL().GetWarrantyName(_m.warrantyterm);
			txtWarranty.Tag = _m.monthfactor;

			if (_m.isnewproduct) rdoNewMC.Checked = _m.isnewproduct;
			else rdoUsedMC.Checked = true;

			lbStatus.Tag = _m.isexpire;

			grpTransfer.Visible = _isTransfered;
			if (_isTransfered)
			{
				// get current owner

				var _mc = new MachineDAL().GetCurrentMachineOwner(_m.type, _m.s_no);
				foreach (DataRow dr in _mc.Rows)
				{
					txtCurrentOwner.Text = dr["CurrentOwner"].ToString();
					txtTransferDate.Text = Convert.ToDateTime(dr["Date"]).ToShortDateString();
				}
			}

			UpdateUI();
		} // end GetMachineInfo

		private void UpdateMachineRecord(int MachineId)
		{
			// search exist machine
			if (_mode == ActionMode.Add)
			{
				// find duplicate machine before adding into "MachineRecord"
				if (new MachineDAL().existMachine(txtSN.Text, txtModel.Text, this.txtCustCode.Text) == true)
				{
					MessageBox.Show("เครื่องจักรที่ต้องการบันทึกอาจมีอยู่แล้วในฐานข้อมูลโปรดตรวจสอบอีกครั้ง!!!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			var mc = new MIX();
			switch (_mode)
			{
				case ActionMode.Add:
					mc.auditdt = DateTime.Now;
					mc.audituser = omglobal.UserInfo;
					break;

				case ActionMode.Edit:
					mc = new MachineDAL().GetMachineRegisterInfo(MachineId);
					mc.modidt = DateTime.Now;
					mc.modiuser = omglobal.UserInfo;

					break;
			}

			mc.custid = _erpCustId;
			mc.acccustcode = txtCustCode.Text;
			mc.cus_na = txtCustomerName.Text;
			mc.exp = dtpExpire.Value;
			mc.isdelete = false;
			mc.isexpire = _isExpired;
			mc.isnewproduct = rdoNewMC.Checked ? true : false;
			mc.istransfer = _isSuccessTransferred;
			mc.modidt = DateTime.Now;
			mc.modiuser = omglobal.UserInfo;
			mc.monthexpire = dtpExpire.Value.Month;
			mc.monthfactor = Convert.ToInt32(txtWarranty.Tag);
			mc.monthsale = dtpSaleDate.Value.Month;
			mc.productid = new ProductDAL().GetProductId(txtModel.Text);
			mc.qtysale = 1;
			mc.remark = txtRemark.Text;
			mc.s_no = txtSN.Text;
			mc.sale_date = dtpSaleDate.Value;
			mc.transferdate = _trasferDate;
			mc.type = txtModel.Text;
			mc.warrantyterm = _warrantyId;
			mc.yearexpire = mc.exp.Value.Year;
			mc.yearsale = mc.sale_date.Value.Year;

			if (new MachineDAL().UpdateMachineRecord(mc) > 0)
			{
				MessageBox.Show("Update Machine record successfully...");
			}

		} // end 

		private void GetCustomer()
		{
			using (var _cust = new CustomerSearch())
			{
				_cust.StartPosition = FormStartPosition.CenterParent;
				if (_cust.ShowDialog(this) == DialogResult.OK)
				{
					txtCustomerName.Text = _cust.CustomerName;
					txtCustCode.Text = _cust.ERPCustomerCode;
					_erpCustId = _cust.ERPCustomerId;
				}
			}
		} // end GetCustomer

		#endregion
	}
}