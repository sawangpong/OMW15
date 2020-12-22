using System;
using System.Windows.Forms;
using OMW15.Models.CastingModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class GRVInfo : Form
	{
		// CONSTRUCTOR
		public GRVInfo(int GRVID = 0)
		{
			InitializeComponent();
			pnlHeader.BackColor = omglobal.OM_LIGHT_BLUE_COLOR;
			lbMode.Text = (_mode = GRVID == 0 ? ActionMode.Add : ActionMode.Edit).ToString();
			_grvId = GRVID;
		}

		private void GRVInfo_Load(object sender, EventArgs e)
		{
			GetUnitList();
			lbCustomer.Text = CustomerCode + "-" + CustomerName;

			GetGRVInfo(_grvId);

			UpdateUI();
		}

		private void btnMaterial_Click(object sender, EventArgs e)
		{
			GetMaterialList();
		}

		private void chkReturnForSale_CheckedChanged(object sender, EventArgs e)
		{
			if (_mode == ActionMode.Add) btnSelectedSaleMaterialOrder.Visible = chkReturnForSale.Checked;
			else btnSelectedSaleMaterialOrder.Enabled = false;
			txtDescription.Text = chkReturnForSale.Checked ? "RETURN FOR SALE" : "";
		}

		private void btnSendingDate_ButtonClick(object sender, EventArgs e)
		{
			btnSendingDate.SelectedDate = string.IsNullOrEmpty(txtSendingDate.Text)
				? DateTime.Today
				: Convert.ToDateTime(txtSendingDate.Text);
		}

		private void btnSendingDate_DateSelected(object sender, EventArgs e)
		{
			txtSendingDate.Text = btnSendingDate.SelectedDate.ToShortDateString();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			UpdateGRV(_grvId);
		}

		private void btnSelectedSaleMaterialOrder_Click(object sender, EventArgs e)
		{
			using (
				var _so = new AvailbleCastingSaleOrderList(CustomerCode, CustomerName, OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ))
			{
				_so.MaterialCategory = this.MaterialCategory;
				if (_so.ShowDialog(this) == DialogResult.OK)
				{
					_selectedSONo = _so.SaleOrderNo;
					_selectedSOSeq = _so.SaleOrderId;
					_selectedCustomerId = _so.CustomerId;
					
					MaterialId = _so.MaterialId;
					MaterialName = _so.MaterialName;
					txtMaterial.Text = MaterialName;
					txtMaterial.Tag = MaterialId;
					txtRefDocument.Text = _selectedSONo;
					txtReceiveWeight.Text = $"{Convert.ToDecimal(_so.TotalWeight):N2}";
				}
			}
		}

		private void txtMaterial_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void txtReceiveWeight_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void dtpGRVDate_CloseUp(object sender, EventArgs e)
		{
			var _selectedYear = dtpGRVDate.Value.Year;
			var _selectedMonth = dtpGRVDate.Value.Month;

			if (_selectedYear < _currentYerar)
			{
				MessageBox.Show("ไม่สามารถเลือกวันที่น้อยกว่าวันที่ปัจจุบันได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				dtpGRVDate.Value = DateTime.Today;
			}
			else if (_selectedMonth < _currentMonth)
			{
				MessageBox.Show("ไม่สามารถเลือกวันที่น้อยกว่าวันที่ปัจจุบันได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				dtpGRVDate.Value = DateTime.Today;
			}
		}

		#region class field members

		private readonly ActionMode _mode = ActionMode.None;
		private readonly int _currentYerar = DateTime.Today.Year;
		private readonly int _currentMonth = DateTime.Today.Month;
		private readonly int _grvId;
		private int _selectedSOSeq;
		private string _selectedSONo = string.Empty;
		private int _selectedCustomerId;

		#endregion

		#region class property

		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }

		public string MaterialCategory { get; set; }

		public int MaterialId { get; set; }

		public string MaterialName { get; set; }

		public int MatTransformId { get; set; }

		public string MatTransformName { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			txtRefDocument.Enabled = _mode == ActionMode.Add;
			chkReturnForSale.Enabled = _mode == ActionMode.Add;
			btnSave.Enabled = !string.IsNullOrEmpty(txtMaterial.Text);
		} // end UpdateUI


		private void GetUnitList()
		{
			var _dt = new SelectOptions().GetUnitList();

			cbxUnit.DataSource = _dt;
			cbxUnit.DisplayMember = "VALUE";
			cbxUnit.ValueMember = "KEY";
		} // end GetUnitList

		private void GetMaterialList()
		{
			using (var _ml = new MaterialList(CustomerCode, MaterialCategory))
			{
				_ml.StartPosition = FormStartPosition.CenterScreen;
				if (_ml.ShowDialog(this) == DialogResult.OK)
				{
					MaterialId = _ml.MaterialId;
					MaterialName = _ml.MaterialName;
					txtMaterial.Text = MaterialName;
					txtMaterial.Tag = MaterialId;
				}
			} // end 
		} // end GetMaterialList


		private void GetGRVInfo(int GRVId)
		{
			var _grv = new MATRECEIVE();
			var _totalClearingWT = 0.00m;
			switch (_mode)
			{
				case ActionMode.Add:
					MaterialId = 0;
					MatTransformId = 0;
					MaterialName = string.Empty;
					MatTransformName = string.Empty;
					chkReturnForSale.Checked = false;
					lbGRVId.Text = "*** NEW ***";
					dtpGRVDate.Value = DateTime.Today;
					txtMaterial.Text = "";
					break;

				case ActionMode.Edit:
					_grv = new CastingSaleOrderDAL().GetGRVInfo(GRVId);
					lbGRVId.Text = GRVId.ToString();
					chkReturnForSale.Checked = _grv.ISFORSALE;
					dtpGRVDate.Value = _grv.RECEIVEDATE.Num2Date();
					MaterialId = _grv.MATTYPE;
					_totalClearingWT = _grv.TOTALCLEARING;
					txtMaterial.Text = new MaterialDAL().GetMaterialNameById(_grv.MATTYPE);
					break;
			}
			txtRefDocument.Text = _grv.CUSTDOCNO;
			txtDescription.Text = _grv.DESCRIPTION;
			txtMaterial.Tag = MaterialId;
			txtRecever.Text = _grv.RECEIVERNAME;
			txtRefDocument.Text = _grv.CUSTDOCNO;
			txtSender.Text = _grv.SENDERNAME;
			txtSendingDate.Text = _grv.SENDINGDATE.Num2Date().ToShortDateString();
			txtReceiveWeight.Text = _grv.RECEIVEWEIGHT.ToString();
			cbxUnit.SelectedValue = _grv.RECEIVEUNIT;

			if (_mode == ActionMode.Edit) btnSelectedSaleMaterialOrder.Enabled = _totalClearingWT == 0.00m;

			UpdateUI();
		} // end GRVInfo

		private void UpdateGRV(int GRVId)
		{
			var _grv = new MATRECEIVE();

			switch (_mode)
			{
				case ActionMode.Add:
					_grv.AUDITUSER = omglobal.UserInfo;
					_grv.BALANCEWEIGHT = Convert.ToDecimal(txtReceiveWeight.Text);
					_grv.CUSTCODE = CustomerCode;
					_grv.CUSTID = 0;
					_grv.ISCOMPLETE = false;
					_grv.ISDELETE = false;
					_grv.SOSEQ = _selectedSOSeq;
					_grv.TOTALCLEARING = 0.00m;
					break;
				case ActionMode.Edit:
					_grv = new CastingSaleOrderDAL().GetGRVInfo(GRVId);
					_grv.REFSONUMBER = _selectedSONo;
					_grv.ISCOMPLETE = _grv.BALANCEWEIGHT == 0;
					_grv.SOSEQ = _selectedSOSeq;
					_grv.BALANCEWEIGHT = Convert.ToDecimal(txtReceiveWeight.Text) - _grv.TOTALCLEARING;
					break;
			}
			_grv.CUSTID = _selectedCustomerId;
			_grv.CUSTDOCNO = txtRefDocument.Text;
			_grv.REFSONUMBER = _selectedSONo;
			_grv.ISFORSALE = chkReturnForSale.Checked;
			_grv.MATTYPE = MaterialId;
			_grv.RECEIVEDATE = dtpGRVDate.Value.Date2Num();
			_grv.RECEIVERNAME = txtRecever.Text;
			_grv.RECEIVEUNIT = Convert.ToInt32(cbxUnit.SelectedValue);
			_grv.RECEIVEWEIGHT = Convert.ToDecimal(txtReceiveWeight.Text);
			_grv.DESCRIPTION = txtDescription.Text;
			_grv.SENDERNAME = txtSender.Text;
			_grv.SENDINGDATE = Convert.ToDateTime(txtSendingDate.Text).Date2Num();
			_grv.MODIUSER = omglobal.UserInfo;
			_grv.MODIDATE = DateTime.Now;

			if (new CastingSaleOrderDAL().UpdateGRVInfo(_grv) > 0)
				MessageBox.Show("Update complete.....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
		} // end UpdateGRV

		#endregion
	}
}