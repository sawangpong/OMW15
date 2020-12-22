using GAF;
using Microsoft.VisualBasic;
using OMControls;
using OMW15.Controllers.CastingController;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
    public partial class CastingSaleOrderInfo : Form
    {
        // ====================================================================
        // CONSTRUCTOR
        public CastingSaleOrderInfo(int CastingOrderId, string CustCode = "")
        {
            InitializeComponent();
            pnlTop.BackColor = omglobal.FB_BLUE;
            CustomerCode = CustCode;
            CastingSaleOrderId = CastingOrderId;

            // update mode
            _soHeaderMode = CastingSaleOrderId == 0 ? ActionMode.Add : ActionMode.Edit;
            lbMode.Text = _soHeaderMode.ToString();
        }

        //
        // =====================================================================
        //

        private void CastingSaleOrderInfo_Load(object sender, EventArgs e)
        {
            // formatting DataGridView
            OMUtils.SettingDataGridView(ref dgv);

            // initial data
            GetVATMethodCalculationList();
            GetVatList();

            // Retrieve the customer information
            GetCustomerInfo(CustomerCode);

            // load order information
            GetCastingSaleOrderHeaderInfo(CastingSaleOrderId);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // must clearing all items select from fg before leave 

            if (_soHeaderMode == ActionMode.Add)
            {
                if (new CastingSaleOrderDAL().RemoveAllSOLinesWhenCancelInAddMode(_refSOId) > 0)
                    MessageBox.Show("Remove items completed....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Close();
        }

        private void chkVAT_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkAutoSONumber_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoSONumber.Checked)
                switch (_soHeaderMode)
                {
                    case ActionMode.Add:
                        if (_selectedSaleType != OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
                        {
                            txtSONumber.Text = omglobal.AUTO_SI_NUMBER;
                            txtSONumber.Enabled = false;
                        }
                        else
                        {
                            txtSONumber.Text = omglobal.AUTO_SI_NUMBER;
                            txtSONumber.Enabled = false;
                        }
                        break;
                    case ActionMode.Edit:
                        break;
                }
            else
                switch (_soHeaderMode)
                {
                    case ActionMode.Add:
                        if (_selectedSaleType != OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
                        {
                            txtSONumber.Text = string.Empty;
                            txtSONumber.Enabled = true;
                        }
                        else
                        {
                            txtSONumber.Enabled = true;
                        }
                        break;
                    case ActionMode.Edit:
                        break;
                }

            UpdateUI();
        }

        private void rdoSaleType_CheckedChanged(object sender, EventArgs e)
        {
            var _rdo = sender as RadioButton;
            if (_rdo != null)
                if (_rdo.Checked)
                    switch (_rdo.Tag.ToString())
                    {
                        case "LABOUR":
                            _selectedSaleType = OMShareCastingEnums.SaleTypeEnum.ค่าบริการ;
                            cbxCalVATMethod.SelectedValue = (int)OMShareCastingEnums.CalVATMethod.ExcludeVAT;
                            break;

                        case "MATERIAL":
                            _selectedSaleType = OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ;
                            cbxCalVATMethod.SelectedValue = (int)OMShareCastingEnums.CalVATMethod.IncludeVAT;
                            break;

                        case "REPAIR":
                            _selectedSaleType = OMShareCastingEnums.SaleTypeEnum.งานซ่อม;
                            cbxCalVATMethod.SelectedValue = (int)OMShareCastingEnums.CalVATMethod.NoVAT;
                            break;

                        case "TEST":
                            _selectedSaleType = OMShareCastingEnums.SaleTypeEnum.ทดลองหล่อ;
                            cbxCalVATMethod.SelectedValue = (int)OMShareCastingEnums.CalVATMethod.NoVAT;
                            break;
                    }

            //
            // select CastingSaleOrder for Selling Material...
            //
            if (_selectedSaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
                && _rdo.Checked)
            {
                if (_soHeaderMode == ActionMode.Add)
                {
                    GetOrderListForSellingMaterial(CustomerCode);
                }
            }

            UpdateUI();
        }

        private void txtSODate_TextChanged(object sender, EventArgs e)
        {
            if (_soHeaderMode == ActionMode.Add)
                txtDueDate.Text = Convert.ToDateTime(txtSODate.Text).AddDays(1).ToShortDateString();
        }

        private void btnSODate_ButtonClick(object sender, EventArgs e)
        {
            btnSODate.SelectedDate = string.IsNullOrEmpty(txtSODate.Text) ? DateTime.Today : Convert.ToDateTime(txtSODate.Text);
        }

        private void btnSODate_DateSelected(object sender, EventArgs e)
        {
            txtSODate.Text = btnSODate.SelectedDate.ToShortDateString();
        }

        private void btnDueDate_ButtonClick(object sender, EventArgs e)
        {
            btnDueDate.SelectedDate = string.IsNullOrEmpty(txtDueDate.Text)
                ? DateTime.Today.AddDays(1)
                : Convert.ToDateTime(txtDueDate.Text);
        }

        private void btnDueDate_DateSelected(object sender, EventArgs e)
        {
            txtDueDate.Text = btnDueDate.SelectedDate.ToShortDateString();
        }

        private void btnActualDeliveryDate_ButtonClick(object sender, EventArgs e)
        {
            btnActualDeliveryDate.SelectedDate = string.IsNullOrEmpty(txtActualDeliveryDate.Text)
                ? DateTime.Today
                : Convert.ToDateTime(txtActualDeliveryDate.Text);
        }

        private void btnActualDeliveryDate_DateSelected(object sender, EventArgs e)
        {
            txtActualDeliveryDate.Text = btnActualDeliveryDate.SelectedDate.ToShortDateString();
        }


        private void txtTotalAmountValues_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var _totalAmount =
                    Convert.ToDouble(Information.IsNumeric(txtTotalAmountValues.Text) ? txtTotalAmountValues.Text : "0.00");
                txtTotalAmountText.Text = ExtensionDouble.ToThaiWord(_totalAmount);
            }
            catch
            {
                txtTotalAmountText.Text = "";
            }
        }

        private void cbxVAT_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                _customerVATFactor = Convert.ToDecimal(cbxVAT.SelectedValue) / 100.00m;
                lbVATFactor.Text = cbxVAT.SelectedValue.ToString();
                lbVATChange.Text = $"{_customerVATFactor}";
            }
            catch
            {
                _customerVATFactor = 0.00m;
            }

            CalSOAmount(_customerVATFactor);
        }

        private void txtValues_TextChanged(object sender, EventArgs e)
        {
            // Re-calculate the total amount value
            CalSOAmount(_customerVATFactor);

            //var _txt = sender as TextBox;
            //if (_txt.Name == "txtDiscountValue")
            //{
            //	if (_txt.Text.IsNumeric())
            //	{
            //		if (Convert.ToDecimal(_txt.Text) > 0.00m)
            //		{
            //			CalSOAmount(_customerVATFactor);
            //		}
            //	}
            //}
            //else
            //{
            //	CalSOAmount(_customerVATFactor);
            //}
        }

        private void tsbtnAddQCItems_Click(object sender, EventArgs e)
        {
            using (var _fg = new CastingFGItems())
            {
                _fg.SOHeaderMode = _soHeaderMode;
                _fg.ActualDeliveryDate = Convert.ToDateTime(txtActualDeliveryDate.Text);
                _fg.CustomerCode = CustomerCode;
                _fg.CustomerId = _customerId;
                _fg.CustomerName = lbCustomerName.Text;
                _fg.RefSOId = _refSOId;
                _fg.SOGuid = _soGuid;
                _fg.SaleType = _selectedSaleType;
                _fg.MaterialId = _selectedSaleMaterialId;
                _fg.MaterialName = txtMaterial.Text;
                _fg.SONumber = txtSONumber.Text;
                _fg.VATFactor = _customerVATFactor;
                _fg.HasItem = dgv.Rows.Count > 0 ? true : false; // use for filtering the existing items
                _fg.StartPosition = FormStartPosition.CenterParent;

                if (_fg.ShowDialog(this) == DialogResult.OK)
                {
                }
            }

            // re-load SO-Lines
            GetCastingSaleOrderItemList(_refSOId, _soGuid);

        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            _selectedSOLineSEQ = Convert.ToInt32(dgv["SOLINESEQ", e.RowIndex].Value);
            _selectedFGLineSEQ = Convert.ToInt32(dgv["FGLINESEQ", e.RowIndex].Value);

            // display
            lbJob.Text = $"Job : {dgv["JOBNO", e.RowIndex].Value.ToString()}";
            lbSOLineIndex.Text = $"Line Index : {_selectedSOLineSEQ}";
            lbFGSEQ.Text = $"FG Index : {_selectedFGLineSEQ}";
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            GetCastingSaleOrderItemList(_refSOId, _soGuid);
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            // deleting separated in 2 modes Add and Edit
            // 'Add' mode => delete record without update with FG-Stock record
            // 'Edit mode => before delete must updating the FG-Stock
            // expected the return the value back to FG-Stock like QTY & WEIGHT
            switch (_soHeaderMode)
            {
                case ActionMode.Add:
                    if (new CastingSaleOrderDAL().RemoveCastingSaleOrderItem(_selectedSOLineSEQ) > 0)
                        MessageBox.Show("Delete item success...", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case ActionMode.Edit:

                    if (_selectedSaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
                    {
                        if (new CastingSaleOrderDAL().RemoveCastingSaleOrderItem(_selectedSOLineSEQ) > 0)
                            MessageBox.Show("Delete item success...", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (new CastingSaleOrderDAL().UpdateFGStockForRemoveSOLines(_selectedSOLineSEQ) > 0)
                            MessageBox.Show("Delete/update item success...", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
            }


            tsbtnRefresh.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //
            // save or update SALEORDER
            //
            UpdateCastingSaleOrderHeader(_refSOId);
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            tsbtnEdit.PerformClick();
        }

        private void tsbtn_Click(object sender, EventArgs e)
        {
            var _tsbtn = sender as ToolStripButton;

            switch (_tsbtn.Tag.ToString())
            {
                case "ADD":
                    _selectedSOLineSEQ = 0;
                    break;

                case "EDIT":
                    break;
            }

            using (var _soline = new CastingSaleOrderItemInfo(_selectedSOLineSEQ, _soHeaderMode))
            {
                _soline.VATFactor = _customerVATFactor;
                _soline.VATRate = cbxVAT.Text;
                _soline.StartPosition = FormStartPosition.CenterParent;
                _soline.CustomerId = _customerId;
                _soline.CustomerCode = lbCustomerCode.Text;
                _soline.SaleOrderId = _refSOId;
                _soline.SaleOrderNumber = txtSONumber.Text;
                _soline.SaleType = _selectedSaleType;
                _soline.MaterialId = _selectedSaleMaterialId;
                _soline.MaterialCategory = _materialCategory;
                _soline.MaterialName = txtMaterial.Text;
                _soline.OrderDate = Convert.ToDateTime(txtSODate.Text);
                _soline.TotalWeight = Convert.ToDecimal(txtDeliveryWeight.Text);
                _soline.StartPosition = FormStartPosition.CenterParent;

                if (_soline.ShowDialog(this) == DialogResult.OK)
                {
                    _selectedSaleMaterialId = _soline.MaterialId;
                    txtMaterial.Text = _soline.MaterialName;
                }
            }

            GetCastingSaleOrderItemList(_refSOId, _soGuid);
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            GetMaterialList(CustomerCode);
        }

        private void cbxCalVATMethod_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                _calVATMethod =
                    (OMShareCastingEnums.CalVATMethod)
                    Enum.ToObject(typeof(OMShareCastingEnums.CalVATMethod), Convert.ToInt32(cbxCalVATMethod.SelectedValue));
            }
            catch
            {
                _calVATMethod = OMShareCastingEnums.CalVATMethod.NoVAT;
            }

            lbVATMethod.Text = ((int)_calVATMethod).ToString();

            // update flag _isVAT (true == cal VAT otherwise none)
            _isVAT = _calVATMethod == OMShareCastingEnums.CalVATMethod.NoVAT ? false : true;

            lbVATFlag.Text = $"{_isVAT.ToString().Substring(0, 1)}";

            // update VAT Factor as per default vat
            _customerVATFactor = _isVAT ? omglobal.DEFAULT_SYSTEM_VAT_FACTOR : omglobal.DEFAULT_SYSTEM_NON_VAT_FACTOR;

            //debug
            lbVATChange.Text = _customerVATFactor.ToString();
            //end debug

            cbxVAT.SelectedValue = _customerVATFactor == 0.00m
                ? 0.0m
                : Convert.ToDecimal($"{(_customerVATFactor * 100):N1}");

            CalSOAmount(_customerVATFactor);

            UpdateUI();
        }

        #region class field members

        private readonly ActionMode _soHeaderMode = ActionMode.None;
        private OMShareCastingEnums.SaleTypeEnum _selectedSaleType = OMShareCastingEnums.SaleTypeEnum.ไม่ระบุ;
        private OMShareCastingEnums.CalVATMethod _calVATMethod = OMShareCastingEnums.CalVATMethod.NoVAT;
        private DataGridViewRow _sourceDataForSellMaterial = new DataGridViewRow();
        private bool _isVAT;
        private decimal _customerVATFactor = omglobal.DEFAULT_SYSTEM_VAT_FACTOR;
        private decimal _returnWeight;
        private decimal _siFactor;
        private int _selectedSaleMaterialId;
        private int _customerId;
        private int _refSOId = 0; // random the number for reference id of SOHeader
        private Guid _soGuid;
        private int _selectedSOLineSEQ;
        private int _selectedFGLineSEQ;
        private string _materialCategory = string.Empty;
        private string _refMasterSaleOrderForSellingMaterial = string.Empty;

        #endregion

        #region class property

        public int CastingSaleOrderId
        {
            get; set;
        }

        public string CustomerCode
        {
            get; set;
        }

        #endregion

        #region class helper

        private void UpdateUI()
        {
            var _rowCount = dgv.Rows.Count;
            pnlSaleType.Enabled = _soHeaderMode == ActionMode.Add;
            txtSODate.Enabled = pnlSaleType.Enabled;
            btnSODate.Enabled = pnlSaleType.Enabled;
            chkAutoSONumber.Enabled = _soHeaderMode == ActionMode.Add;
            txtSONumber.Enabled = chkAutoSONumber.Enabled;

            cbxVAT.Enabled = _isVAT;
            txtVatValues.Enabled = cbxVAT.Enabled;
            btnMaterial.Visible = _selectedSaleType != OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ;
            btnMaterial.Enabled = _soHeaderMode == ActionMode.Edit ? false : _rowCount == 0;

            rdoServiceCharge.Enabled = btnMaterial.Enabled;

            rdoMaterialCharge.Enabled = rdoServiceCharge.Enabled;
            rdoTest.Enabled = rdoServiceCharge.Enabled;
            rdoRepair.Enabled = rdoServiceCharge.Enabled;

            tsbtnAddQCItems.Visible = _selectedSaleType != OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ;
            tsbtnAddItem.Visible = _selectedSaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ;
            tsSepAdd.Visible = tsbtnAddItem.Visible;
            tsbtnEdit.Enabled = _rowCount > 0;
            tsbtnDelete.Enabled = tsbtnEdit.Enabled;

            txtSIRate.Enabled = btnMaterial.Enabled;
            txtSIWeight.Enabled = txtSIRate.Enabled;
        } // end UpdateUI

        #region customer information and etc

        private void GetCustomerInfo(string CustomerCode)
        {
            var _cinfo = new CastingSaleOrderDAL().GetAvailableCustomerInfoForCastingSaleOrder(CustomerCode);

            if (_cinfo != null)
            {
                // define variable values
                _customerId = _cinfo.CUSTID;
                _isVAT = _cinfo.VATABLE;
                cbxCalVATMethod.SelectedValue = _isVAT
                    ? (int)OMShareCastingEnums.CalVATMethod.ExcludeVAT
                    : (int)OMShareCastingEnums.CalVATMethod.NoVAT;
                cbxVAT.SelectedText = _cinfo.VATRATE;
                lbCustomerCode.Text = _cinfo.CUSTCODE;
                lbCustomerName.Text = _cinfo.CUSTNAME;
                txtContactPerson.Text = _cinfo.CONTACTPERSON;
                txtCreditCode.Text = _cinfo.CREDITCODE;
                txtCreditDuration.Text = $"{new SelectOptions().GetCreditDuration(_cinfo.CREDITCODE)}";
                txtCreditLimit.Text = $"{_cinfo.CREDITLIMIT}";
            }
        } // end GetCustomerInfo

        private void GetVATMethodCalculationList()
        {
            cbxCalVATMethod.DataSource = new CastingSaleOrderDAL().CalVATMethods();
            cbxCalVATMethod.DisplayMember = "METHOD_NAME";
            cbxCalVATMethod.ValueMember = "METHOD_ID";
        }

        private void GetVatList()
        {
            var dt = new SelectOptions().GetVatRateData();
            cbxVAT.DataSource = dt;
            cbxVAT.DisplayMember = "VALUE";
            cbxVAT.ValueMember = "KEY";
        } // end GetVatList

        private void GetMaterialList(string CustomerCode)
        {
            using (var _ml = new MaterialList(CustomerCode))
            {
                _ml.StartPosition = FormStartPosition.CenterScreen;
                if (_ml.ShowDialog(this) == DialogResult.OK)
                {
                    txtMaterial.Text = _ml.MaterialName;
                    _selectedSaleMaterialId = _ml.MaterialId;
                    _materialCategory = _ml.MaterialCategory;

                    // display selected Material Code
                    lbMatId.Text = $"{_selectedSaleMaterialId}";

                    // get material SI
                    if (_selectedSaleType != OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
                    {
                        txtSIRate.Text = _selectedSaleMaterialId == 0 ? string.Empty : $"{_ml.MaterialSI:N2}";
                        _siFactor = _ml.MaterialSI / 100.00m;
                    }
                    else
                    {
                        txtSIRate.Text = "0";
                        txtSIWeight.Text = "0";
                        _siFactor = 0.00m;
                    }
                }
            }
        } // end GetMaterialList

        #endregion

        #region Calculate VALUES

        private void CalSIWeight(object sender, EventArgs e)
        {
            decimal _siWeight = 0.00m;
            decimal _deliverWeight = 0.00m;

            // calculate remaining weight
            CalRemainWeight();

            // calculate SI weight
            try
            {
                _siWeight = Convert.ToDecimal(txtSIWeight.Text);
                _deliverWeight = Convert.ToDecimal(txtDeliveryWeight.Text);

                if (_deliverWeight > 0.00m)
                {
                    var _factor = (Convert.ToDecimal(txtSIRate.Text) / 100m);
                    _siWeight = (_deliverWeight * _factor);
                }
            }
            catch
            {
                _siWeight = Convert.ToDecimal(txtSIWeight.Text);
            }

            // display SI weight
            txtSIWeight.Text = $"{_siWeight:N2}";

        } // end CalSIWeight

        private void CalRemainWeight()
        {
            txtRemainWeight.Text = $"{(decimal.Parse(txtDeliveryWeight.Text) - _returnWeight):N2}";
        } // end CalRemainWeight


        private void CalSOAmount(decimal VATFactor)
        {
            if (dgv.DataSource != null)
            {
                //var _rowCount = dgv.Rows.Count;
                var _dt = (DataTable)dgv.DataSource;
                //var _totalDeliveryWeight = _rowCount == 0 ? 0.00m : _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALWEIGHT"));

                var _totalDeliveryWeight = _dt.Rows.Count == 0 ? 0.00m : _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALWEIGHT"));

                var _totalValue = _dt.Rows.Count == 0 ? 0.00m : _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALVALUE"));
                var _totalDiscount = Convert.ToDecimal(txtDiscountValue.Text);
                var _totalNetValueBeforeVAT = 0.00m;
                var _totalVAT = 0.00m;
                var _totalAmountValues = 0.00m;
                var _netAmount = 0.00m;

                if (_calVATMethod == OMShareCastingEnums.CalVATMethod.ExcludeVAT
                    || _calVATMethod == OMShareCastingEnums.CalVATMethod.NoVAT)
                {
                    //_totalValue = _dt.Rows.Count == 0 ? 0.00m : _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALVALUE"));
                    _totalNetValueBeforeVAT = _totalValue - _totalDiscount;
                    _totalVAT = _totalNetValueBeforeVAT * VATFactor;
                    _totalAmountValues = _totalNetValueBeforeVAT + _totalVAT;
                }
                else //if (_calVATMethod == OMShareCastingEnums.CalVATMethod.IncludeVAT)
                {
                    //_totalAmountValues = _dt.Rows.Count == 0 ? 0.00m : _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALVALUE"));
                    _totalAmountValues = _totalValue;
                    _netAmount = _totalAmountValues - _totalDiscount;
                    _totalValue = _netAmount / (1 + VATFactor);
                    _totalVAT = _totalValue * VATFactor;
                    _totalNetValueBeforeVAT = _netAmount - _totalVAT;
                }

                txtTotalValues.Text = $"{_totalValue:N2}";
                txtNetValue.Text = $"{_totalNetValueBeforeVAT:N2}";
                txtVatValues.Text = $"{_totalVAT:N2}";
                txtTotalAmountValues.Text = $"{(_calVATMethod == OMShareCastingEnums.CalVATMethod.IncludeVAT ? _netAmount : _totalAmountValues):N2}";
                txtDeliveryWeight.Text = $"{_totalDeliveryWeight:N2}";
            }

        } // end CalSOLineAmount

        #endregion

        #region Casting Sale Order Information

        private void GetCastingSaleOrderHeaderInfo(int SaleCastingOrderId)
        {
            var soh = new SALEORDER();

            switch (_soHeaderMode)
            {
                case ActionMode.Add:

                    // Get available reference key number for new SALE ORDER ONLY
                    // when SALETYPE != SaleMaterial (value = 2)
                    // otherwise create random ID
                    _refSOId = _soHeaderMode == ActionMode.Add
                        ? new CastingControllerUtils().GetAvailableReferenceSOKey(_customerId)
                        : SaleCastingOrderId;
                    _soGuid = Guid.NewGuid();


                    soh.SALETYPE = (int)OMShareCastingEnums.SaleTypeEnum.ค่าบริการ;

                    _isVAT = soh.ISVAT;
                    cbxCalVATMethod.SelectedValue = soh.VATCAL;

                    rdoServiceCharge.Checked = true;
                    txtSODate.Text = DateTime.Today.ToShortDateString();

                    soh.ISCANCEL = false;
                    soh.ISCOMPLETE = false;
                    soh.ISDELETE = false;
                    soh.ISAUTONUMBER = true;
                    soh.SO_GUID = _soGuid;
                    soh.SOSEQ = 0;
                    soh.AUDITUSER = omglobal.UserName;
                    soh.AUDITTIME = DateTime.Now;
                    soh.MODIUSER = soh.AUDITUSER;
                    soh.MODIFYTIME = DateTime.Now;

                    soh.CREDITCODE = txtCreditCode.Text;
                    soh.CREDITTERM = Convert.ToInt32(txtCreditDuration.Text);
                    soh.CUSTCODE = CustomerCode;
                    soh.CUSTID = _customerId;

                    soh.BILLDATE = 0;
                    soh.BILLDUEDATE = 0;
                    soh.BILLNO = "";
                    soh.BILLSEQ = 0;
                    soh.INVOICEDATE = 0;
                    soh.INVOICENO = "";
                    soh.INVSEQ = 0;

                    break;

                case ActionMode.Edit:
                    soh = new CastingSaleOrderDAL().GetSaleCastingOrderHeaderInfo(SaleCastingOrderId);
                    _refSOId = soh.SOSEQ;
                    _soGuid = soh.SO_GUID.Value;

                    txtSONumber.Text = soh.SONO;
                    switch (soh.SALETYPE)
                    {
                        case (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ:
                            rdoMaterialCharge.Checked = true;
                            break;
                        case (int)OMShareCastingEnums.SaleTypeEnum.ค่าบริการ:
                            rdoServiceCharge.Checked = true;
                            break;
                        case (int)OMShareCastingEnums.SaleTypeEnum.งานซ่อม:
                            rdoRepair.Checked = true;
                            break;
                        case (int)OMShareCastingEnums.SaleTypeEnum.ทดลองหล่อ:
                            rdoTest.Checked = true;
                            break;
                    }
                    txtSONumber.Text = soh.SONO;
                    txtContactPerson.Text = soh.CONTACT_PERSON;
                    _isVAT = soh.ISVAT;
                    cbxCalVATMethod.SelectedValue = soh.VATCAL;

                    if (soh.DELIVERMAT == 0)
                        soh.DELIVERMAT =
                            new CastingSaleOrderDAL().GetMissingMaterialIdForSaleMaterialOrder(soh.SONO.Substring(0,
                                soh.SONO.LastIndexOf("-")));

                    _selectedSaleMaterialId = soh.DELIVERMAT;
                    _materialCategory = new MaterialDAL().GetMaterialCategoryForSell(_selectedSaleMaterialId);

                    txtMaterial.Text = new MaterialDAL().GetMaterialNameById(_selectedSaleMaterialId);

                    break;
            }

            chkAutoSONumber.Checked = soh.ISAUTONUMBER;
            txtSODate.Text = soh.SODATE.Num2Date().ToShortDateString();
            txtDueDate.Text = soh.DUEDATE.Num2Date().ToShortDateString();
            txtActualDeliveryDate.Text = soh.ACTUALDELIVERDT.Num2Date().ToShortDateString();
            txtSODetails.Text = soh.SALEDETAILS;
            txtDeliveryWeight.Text = $"{soh.DELIVERWEIGHT:N2}";
            txtSIRate.Text = $"{soh.SI:N2}";
            txtSIWeight.Text = $"{soh.SIWEIGHT:N2}";
            _returnWeight = soh.RECEIVEWEIGHT;
            txtRemainWeight.Text = $"{soh.OUTSTANDWEIGHT:N2}";
            txtTotalValues.Text = $"{soh.TOTALVALUE:N2}";
            txtDiscountValue.Text = $"{soh.DISCOUNT:N2}";
            txtNetValue.Text = $"{soh.NETVALUE:N2}";
            txtVatValues.Text = $"{soh.VATVALUE:N2}";
            txtTotalAmountValues.Text = $"{soh.TOTALAMOUNT:N2}";
            txtTotalAmountText.Text = soh.TOTALAMOUNTTEXT;
            txtRemark.Text = soh.REMARK;

            // show latest order number
            txtLatestSONumber.Text = GetLatestCastingSaleOrderNumber(soh.SODATE.Num2Date(), _isVAT, _selectedSaleType, soh.SONO);

            // update group title
            gbSO.Text = $"Order Information (ref-id : {_soGuid.ToString()})";

            GetCastingSaleOrderItemList(_refSOId, _soGuid);

            UpdateUI();

        } // end GetCastingSaleOrderInfo

        private string GetLatestCastingSaleOrderNumber(DateTime OrderDate, bool VATAble,
            OMShareCastingEnums.SaleTypeEnum SaleType, string MasterOrder)
        {
            if (SaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
            {
                return new CastingSaleOrderDAL().GetLatestSaleMaterialOrder(MasterOrder, OrderDate, VATAble, SaleType);
            }
            return new CastingSaleOrderDAL().GetLatestCastingOrderNumber(OrderDate, VATAble, SaleType);

        } // end GetLatestCastingSaleOrderNumber

        private void GetCastingSaleOrderItemList(int SOId, Guid soGuid)
        {
            DataTable dt = new DataTable();
            var _dal = new CastingSaleOrderDAL();
            dt = _dal.GetSaleCastingItems(SOId);
            dgv.DataSource = dt;

            dgv.SuspendLayout();
            dgv.Columns["SOLINESEQ"].Visible = false;
            dgv.Columns["FGLINESEQ"].Visible = false;
            dgv.Columns["SO_GUID"].Visible = false;
            dgv.Columns["REFSOKEY"].Visible = false;
            dgv.Columns["SOSEQ"].Visible = false;
            dgv.Columns["SALETYPE"].Visible = false;
            dgv.Columns["ITEMID"].Visible = false;
            dgv.Columns["PO"].Visible = false;
            dgv.Columns["JOBNO"].Visible = false;

            dgv.Columns["PREFIX"].HeaderText = "รหัส";
            dgv.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
            dgv.Columns["ITEMNAME"].HeaderText = "ชื่อสินค้า / รายละเอียด";
            dgv.Columns["UNIT"].HeaderText = "หน่วยนับ";
            dgv.Columns["UNITPRICE"].HeaderText = "ราคาต่อหน่วย (บาท)";
            dgv.Columns["TOTALVALUE"].HeaderText = "รวมราคา (บาท)";

            dgv.Columns["TOTALWEIGHT"].HeaderText = "รวมน้ำหนัก (กรัม)";
            dgv.Columns["AVGUNITWEIGHT"].HeaderText = "น.น/หน่วย (กรัม)";
            dgv.Columns["AVGPRICEUNITWEIGHT"].HeaderText = "ราคาเฉลี่ย/น.น (บาท/กรัม)";


            foreach (DataGridViewColumn dgc in dgv.Columns)
            {
                if (dgc.ValueType == typeof(decimal))
                {
                    dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
                }
            }

            dgv.ResumeLayout();

            lbRowCount.Text = $"Rows : {dgv.Rows.Count}";

            CalSOAmount(_customerVATFactor);

            UpdateUI();

        } // end GetCastingSaleOrderItemList

        public void UpdateCastingSaleOrderHeader(int CastingOrderId)
        {
            var soHeader = new SALEORDER();

            switch (_soHeaderMode)
            {
                case ActionMode.Add:
                    // get new order-number and id
                    if (_selectedSaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
                    {
                        // check newest SaleOrderNumber
                        if (chkAutoSONumber.Checked)
                            soHeader.SONO = new CastingControllerUtils().GetNewSaleMaterialOrderNumber(
                                _refMasterSaleOrderForSellingMaterial, Convert.ToDateTime(txtSODate.Text), _isVAT, _selectedSaleType);
                        else
                            soHeader.SONO = txtSONumber.Text;
                    }
                    else
                    {
                        if (chkAutoSONumber.Checked)
                        {
                            soHeader.SONO = OMShareCastingEnums.CASTING_ORDER_PREFIX +
                                            new CastingControllerUtils().GetNewCastingOrderNumber(Convert.ToDateTime(txtSODate.Text), _isVAT,
                                                _selectedSaleType);
                            txtSONumber.Text = soHeader.SONO;
                        }
                        else
                        {
                            if (txtSONumber.Text != omglobal.AUTO_SI_NUMBER)
                            {
                                soHeader.SONO = txtSONumber.Text;
                            }
                            else
                            {
                                if (MessageBox.Show("Error", "หมายเลขใบส่งสินค้าไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error) ==
                                    DialogResult.OK)
                                    return;
                            }
                        }
                    }

                    soHeader.RUNNINGNO =
                        new CastingControllerUtils().GetLastRunningNo(Convert.ToDateTime(txtSODate.Text), _isVAT, _selectedSaleType,
                            _refMasterSaleOrderForSellingMaterial) + 1;

                    soHeader.SO_GUID = _soGuid;
                    soHeader.AUDITTIME = DateTime.Now;
                    soHeader.AUDITUSER = omglobal.UserInfo;

                    soHeader.CUSTID = _customerId;
                    soHeader.CUSTCODE = CustomerCode;
                    soHeader.CREDITCODE = txtCreditCode.Text;
                    soHeader.CREDITTERM = Convert.ToInt32(txtCreditDuration.Text);

                    soHeader.ISAUTONUMBER = chkAutoSONumber.Checked;
                    soHeader.ISVAT = _isVAT;
                    soHeader.SALETYPE = (int)_selectedSaleType;
                    soHeader.DELIVERMAT = _selectedSaleMaterialId;
                    soHeader.SODATE = txtSODate.Text.Date2Num();
                    soHeader.FISCPERIOD = Convert.ToDateTime(txtSODate.Text).Month;
                    soHeader.FISCYEAR = Convert.ToDateTime(txtSODate.Text).Year;
                    soHeader.RECEIVEWEIGHT = 0.00m;
                    soHeader.OUTSTANDWEIGHT = Convert.ToDecimal(txtDeliveryWeight.Text);
                    soHeader.VATCAL = (int)_calVATMethod;
                    soHeader.SOCANCELDATE = 0;
                    soHeader.ISCANCEL = false;
                    soHeader.ISCOMPLETE = false;
                    soHeader.ISDELETE = false;

                    soHeader.BILLDATE = 0;
                    soHeader.BILLDUEDATE = 0;
                    soHeader.BILLNO = "";
                    soHeader.BILLSEQ = 0;
                    soHeader.INVOICEDATE = 0;
                    soHeader.INVOICENO = "";
                    soHeader.INVSEQ = 0;
                    soHeader.MATDOCNO = "";
                    soHeader.SALEMATID = 0;
                    break;

                case ActionMode.Edit:
                    soHeader = new CastingSaleOrderDAL().GetSaleCastingOrderHeaderInfo(CastingOrderId);
                    soHeader.ISVAT = _isVAT;
                    soHeader.OUTSTANDWEIGHT = Convert.ToDecimal(txtDeliveryWeight.Text) - soHeader.RECEIVEWEIGHT;

                    break;
            }

            soHeader.MODIFYTIME = DateTime.Now;
            soHeader.MODIUSER = omglobal.UserInfo;


            // and & update information
            soHeader.DUEDATE = txtDueDate.Text.Date2Num();
            soHeader.ACTUALDELIVERDT = txtActualDeliveryDate.Text.Date2Num();
            soHeader.CONTACT_PERSON = txtContactPerson.Text;
            soHeader.SALEDETAILS = txtSODetails.Text;
            soHeader.TOTALVALUE = Convert.ToDecimal(txtTotalValues.Text);
            soHeader.DISCOUNT = Convert.ToDecimal(txtDiscountValue.Text);
            soHeader.NETVALUE = Convert.ToDecimal(txtNetValue.Text);
            soHeader.VATPERCENT = cbxVAT.Text;
            soHeader.VATVALUE = Convert.ToDecimal(txtVatValues.Text);
            soHeader.TOTALAMOUNT = Convert.ToDecimal(txtTotalAmountValues.Text);
            soHeader.TOTALAMOUNTTEXT = txtTotalAmountText.Text;
            soHeader.SOLINECOUNT = dgv.Rows.Count;
            soHeader.DELIVERMAT = _selectedSaleMaterialId;
            soHeader.SI = Convert.ToDecimal(txtSIRate.Text);
            soHeader.SIWEIGHT = Convert.ToDecimal(txtSIWeight.Text);
            soHeader.DELIVERWEIGHT = Convert.ToDecimal(txtDeliveryWeight.Text);
            soHeader.REMARK = txtRemark.Text;

            if (soHeader.SONO != omglobal.AUTO_SI_NUMBER)
            {
                if (new CastingSaleOrderDAL().UpdateCastingSaleOrderHeader(soHeader, _refSOId) > 0)
                {
                    MessageBox.Show("Update Casting Order successfully....", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                btnCancel.PerformClick();
            }
        } // end UpdateCastingSaleOrderHeader

        #endregion

        private void GetOrderListForSellingMaterial(string CustomerCode)
        {
            // popping select window for Casting Order list for selling the material
            _refMasterSaleOrderForSellingMaterial = string.Empty;

            using (var _sm = new CastingSaleOrderForSaleMaterial(CustomerCode, lbCustomerName.Text))
            {
                _sm.StartPosition = FormStartPosition.CenterScreen;

                if (_sm.ShowDialog(this) == DialogResult.OK)
                {
                    _sourceDataForSellMaterial = _sm.RowSource;
                    chkAutoSONumber.Checked = true;
                    chkAutoSONumber.Enabled = true;
                    _refMasterSaleOrderForSellingMaterial = _sm.MasterSaleOrderNumber;
                    txtSONumber.Text = new CastingControllerUtils().GetNewSaleMaterialOrderNumber(
                        _refMasterSaleOrderForSellingMaterial, Convert.ToDateTime(txtSODate.Text), _isVAT, _selectedSaleType);

                    _materialCategory = new MaterialDAL().GetMaterialCategoryForSell(_sm.DeliveredMaterialId);

                    txtDeliveryWeight.Text = _sm.DeliveredMaterialWeight.ToString();
                }
                else
                {
                    _sourceDataForSellMaterial = null;
                    MessageBox.Show("ต้องกำหนดหมายเลขใบส่งสินค้า ในการเปิดใบส่งสินค้าสำหรับวัสดุ", "ERROR", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Close();
                }
            }

            // apply value for new order
            if (_sourceDataForSellMaterial != null)
                txtLatestSONumber.Text = GetLatestCastingSaleOrderNumber(Convert.ToDateTime(txtSODate.Text), _isVAT,
                    _selectedSaleType, _refMasterSaleOrderForSellingMaterial);
        } // end GetOrderListForSellingMaterial

        #endregion

        private void CbxCalVATMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}