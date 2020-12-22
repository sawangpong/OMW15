using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;


namespace OMW15.Casting.CastingView
{
	public partial class CastingSaleOrderInfo : Form
	{
		#region class field members
		private const string AUTO_SC_NUMBER = "***AUTO***";
		private OLDMOONEF _om;
		private ActionMode _mode = ActionMode.None;
		private int _castingSaleOrderId = 0;
		private int _customerId = 0;
		private string _customerCode = string.Empty;

		// private int _SC_SEQ_RANDOM = 0;
		private bool _isVAT = false;
		private string _customerVATRate = "0%";
		private string _selectedSaleMaterialCode = string.Empty;
		private OMShareCastingEnums.SaleTypeEnum _selectedSaleType = OMShareCastingEnums.SaleTypeEnum.ไม่ระบุ;

		#endregion

		#region class property
		public int CastingSaleOrderId
		{
			set
			{
				_castingSaleOrderId = value;
				
				// update mode
				_mode = (_castingSaleOrderId == 0 ? ActionMode.Add : ActionMode.Edit);
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
			this.lbMode.Text = _mode.ToString();
		
		} // end UpdateUI

		#region customer information and etc

		private void GetCustomerInfo(string CustomerCode)
		{
			//var _cinfo = (from c in _oldmoon.CUSTOMER1
			//			  where c.CUSTCODE == CustomerCode
			//			  select c).FirstOrDefault();

			CUSTOMER1 _cinfo = _om.CUSTOMER1.FirstOrDefault(x => x.CUSTCODE == CustomerCode);

			if (_cinfo != null)
			{
				// define variable values
				_isVAT = _cinfo.VATABLE;
				this.chkVAT.Checked = _isVAT;
				_customerVATRate = _cinfo.VATRATE;

				this.lbCustomerCode.Text = _cinfo.CUSTCODE;
				this.lbCustomerName.Text = _cinfo.CUSTNAME;
				_customerId = _cinfo.CUSTID;
				this.txtContactPerson.Text = _cinfo.CONTACTPERSON;
				this.txtCreditCode.Text = _cinfo.CREDITCODE;
				this.txtCreditDuration.Text = string.Format("{0}", Tools.SelectOptions.GetCreditDuration(_cinfo.CREDITCODE));
				this.txtCreditLimit.Text = string.Format("{0:N2}",_cinfo.CREDITLIMIT);
			}

		} // end GetCustomerInfo

		private void GetVatList()
		{
			this.cbxVAT.DataSource = Tools.SelectOptions.GetVatRateData();
			this.cbxVAT.DisplayMember = "VALUE";
			this.cbxVAT.ValueMember = "KEY";

		} // end GetVatList

		private void GetMaterialList()
		{
			this.cbxMaterial.DataSource = Tools.SelectOptions.GetMaterialData();
			this.cbxMaterial.DisplayMember = "VALUE";
			this.cbxMaterial.ValueMember = "KEY";
		}

		private void CalSIWeight(object sender, EventArgs e)
		{
			decimal _siWeight = 0.00m;

			// calculate remaining weight
			this.CalRemainWeight();

			// calculate SI weight
			try
			{
				decimal _deliverWeight = Convert.ToDecimal(this.txtDeliverWeight.Text);
				decimal _siRate = Convert.ToDecimal(this.txtSIRate.Text) / 100 ;
				if( _deliverWeight > 0.00m)
 				{
					_siWeight = _deliverWeight * _siRate;
				}
			}
			catch
			{
				_siWeight = 0.00m;
			}
				
			// display SI weight
			this.txtSIWeight.Text = string.Format("{0:N2}", _siWeight);

		} // end CalSIWeight


		private void CalRemainWeight()
		{
		} // end CalRemainWeight
		#endregion



		#region Casting Sale Order Information

		private void SetNewCastingSaleOrderInfo(string CustomerCode)
		{
			if (!string.IsNullOrEmpty(CustomerCode))
			{
				this.GetCustomerInfo(CustomerCode);
			}

			this.chkAutoSONumber.Checked = true;
			this.txtDeliverWeight.Text = "0.00";
			this.txtRemainWeight.Text = "0.00";

		} // end SetNewCastingSaleOrderInfo

		private void GetCastingSaleOrderInfo(int CastingSaleOrderId)
		{
		} // end GetCastingSaleOrderInfo

		#endregion

		#endregion


		public CastingSaleOrderInfo()
		{
			InitializeComponent();
		}

		private void CastingSaleOrderInfo_Load(object sender, EventArgs e)
		{
			// formatting DataGridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			// create object
			_om = new OLDMOONEF();

			// initial data
			this.GetVatList();
			this.GetMaterialList();

			// select Data
			switch(_mode)
			{
				case ActionMode.Add:
					this.SetNewCastingSaleOrderInfo(_customerCode);
					break;
				case ActionMode.Edit:
					this.GetCastingSaleOrderInfo(_castingSaleOrderId);
					break;
			}

			// update UI
			this.UpdateUI();

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void chkVAT_CheckedChanged(object sender, EventArgs e)
		{
			this.lbVATFlag.Text = string.Format("{0}", (this.chkVAT.Checked == true ? "T" : "F"));

			this.cbxVAT.SelectedValue = _customerVATRate;
			this.cbxVAT.Text = _customerVATRate;

			this.cbxVAT.Enabled = this.chkVAT.Checked;


			// test
			string _scOrderNumber = string.Empty;
			int _scOrderId = 0;

			_scOrderId = new OMW15.Casting.CastingController.SCOrderDAL().GetNewSaleOrderNumber(this.chkVAT.Checked, DateTime.Today, out _scOrderNumber);

			if (this.chkAutoSONumber.Checked)
			{
				this.txtSONumber.Text = _scOrderNumber;

				//this.txtSONumber.Text = AUTO_SC_NUMBER;
				this.txtSONumber.Enabled = false;
			}
			else
			{
				this.txtSONumber.Text = string.Empty;
				this.txtSONumber.Enabled = true;
			}

		}

		private void cbxMaterial_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cbxMaterial.SelectedValue.GetType() == typeof(System.String))
			{
				_selectedSaleMaterialCode = this.cbxMaterial.SelectedValue.ToString();
			}
			else
			{
				_selectedSaleMaterialCode= string.Empty;
				this.txtSIRate.Text = string.Format("{0:N2}", 0);
			}
			
			// display selected Material Code
			this.lbMatId.Text = string.Format("{0}", _selectedSaleMaterialCode);

			// get material SI
			this.txtSIRate.Text = (string.IsNullOrEmpty(_selectedSaleMaterialCode) ? string.Empty :  string.Format("{0:N2}", Tools.SelectOptions.GetMaterialSI(_selectedSaleMaterialCode)));

		}

		private void chkAutoSONumber_CheckedChanged(object sender, EventArgs e)
		{
			//test
			string _scOrderNumber = string.Empty;
			int _scOrderId = 0;

			_scOrderId = new OMW15.Casting.CastingController.SCOrderDAL().GetNewSaleOrderNumber(this.chkVAT.Checked, DateTime.Today, out _scOrderNumber);

			if (this.chkAutoSONumber.Checked)
			{
				
				this.txtSONumber.Text = _scOrderNumber;

				//this.txtSONumber.Text = AUTO_SC_NUMBER;
				this.txtSONumber.Enabled = false;
			}
			else
			{
				this.txtSONumber.Text = string.Empty;
				this.txtSONumber.Enabled = true;
			}
		}

		private void rdoSaleType_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton _rdo = sender as RadioButton;

			if (_rdo.Checked)
			{
				switch(Convert.ToInt32(_rdo.Tag.ToString()))
				{
					case (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ:
						_selectedSaleType = OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ;
						break;
					
					default:
						_selectedSaleType = OMShareCastingEnums.SaleTypeEnum.ค่าบริการ;
						break;
				}
			}
		}
	}
}
