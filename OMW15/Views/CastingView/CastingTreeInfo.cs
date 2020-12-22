using System;
using System.ComponentModel;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;
using OMW15.Views.ToolViews;
using OMControls.Controls;

namespace OMW15.Views.CastingView
{
    public partial class CastingTreeInfo : Form
    {
        public CastingTreeInfo()
        {
            InitializeComponent();
        }

        #region class property

        public int TreeId
        {
            get; set;
        }

        #endregion

        private void CastingTreeInfo_Load(object sender, EventArgs e)
        {
            CenterToParent();
            _mode = TreeId == 0 ? ActionMode.Add : ActionMode.Edit;
            GetAlloyList();
            GetOtherMatList();

            groupBox1.Text = $"รายละเอียดต้นเทียน :: [{_mode}]";
            Text = $"CASTING TREE INFO [{_mode}]";

            GetTreeInformation(TreeId, _mode);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            using (var _jc = new CastingCustomer())
            {
                _jc.StartPosition = FormStartPosition.CenterScreen;
                if (_jc.ShowDialog(this) == DialogResult.OK)
                {
                    lbCustCode.Tag = _jc.CustomerId;
                    lbCustCode.Text = _jc.CustomerCode;
                    lbCustomerName.Text = _jc.CustomerName;
                }
            }
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            using (var ml = new CastingMatList(ActionMode.Selection))
            {
                ml.StartPosition = FormStartPosition.CenterScreen;
                if (ml.ShowDialog(this) == DialogResult.OK)
                {
                    _matGroup = ml.MatGroup;
                    _matConvertFactor = ml.ConvertFactor;
                    lbMatGroup.Text = _matGroup;
                    lbMaterial.Text = ml.MatName;
                    lbMaterial.Tag = ml.MatId;
                    lbMatFactor.Text = $"{ml.MatFactor:N2}";
                    ntxtFlaskTemp.Text = $"{ml.FlaskTemp:N2}";
                    ntxtCastingTemp.Text = $"{ml.CastingTemp:N2}";
                }
                else
                {
                    _matGroup = string.Empty;
                    _matConvertFactor = 0.00m;
                }

                lbMatGroup.Text = _matGroup;
                lbConvertFactor.Text = $"{_matConvertFactor:N4}";

                UpdateUI();
            }
        }

        private void btnRubberBase_Click(object sender, EventArgs e)
        {
            using (var rb = new RBList(ActionMode.Selection))
            {
                rb.StartPosition = FormStartPosition.CenterScreen;
                if (rb.ShowDialog(this) == DialogResult.OK)
                {
                    lbBaseSize.Text = rb.BaseSize;
                    lbBaseNo.Text = rb.BaseNo;
                    ntxtBaseWeight.Text = $"{rb.BaseWeight:N2}";
                }
            }
        }

        private void btnCastingMan_Click(object sender, EventArgs e)
        {
            var _selectBox = new SelectBox();
            _selectBox.SelectOption = SelectTypeOption.WorkerById;
            _selectBox.StartPosition = FormStartPosition.CenterScreen;
            if (_selectBox.ShowDialog() == DialogResult.OK)
                txtCaster.Text = _selectBox.SelectedName;
        }

        private void ntxtBase_TextChanged(object sender, EventArgs e)
        {
            // calculate metal
            CalMetal();
        }

        private void ntxtSV_TextChanged(object sender, EventArgs e)
        {
            CalActualMetalWeight();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveWaxTree(_mode);
        }

        private void ntxtLoss_TextChanged(object sender, EventArgs e)
        {
            CalLoss();
        }

        private void cbxOtherMat_TextChanged(object sender, EventArgs e)
        {
            ntxtOtherMatWT.Text = !string.IsNullOrEmpty(cbxOtherMat.Text) ? ntxtOtherMatWT.Text : "0.00";
            ntxtOtherMatWT.Enabled = !string.IsNullOrEmpty(cbxOtherMat.Text);
        }

        private void cbxAlloyType_TextChanged(object sender, EventArgs e)
        {
            ntxtAlloyWT.Text = !string.IsNullOrEmpty(cbxAlloyType.Text) ? ntxtAlloyWT.Text : "0.00";
            ntxtAlloyWT.Enabled = !string.IsNullOrEmpty(cbxAlloyType.Text);
        }

        private void dtpBuildDate_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidTheBuidingDate(dtpBuildDate.Value))
            {
                e.Cancel = true;
                dtpBuildDate.Focus();
            }
        }

        private void dtpBuildDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private bool ValidTheBuidingDate(DateTime processDate)
        {
            if (processDate > DateTime.Today.AddDays(5))
            {
                Alert.DisplayAlert("วันที่ผิด", "ไม่สามารถเลือกวันที่เกินกว่าวันที่ปัจจุบันได้");
                return false;
            }
            return true;
        }

        #region class field member

        private WAXTREE _tree;
        private ActionMode _mode = ActionMode.None;
        private string _matGroup = string.Empty;
        private decimal _matConvertFactor;
        private decimal sil95Rate = 0.00m;
        private decimal sil94Rate = 0.00m;

        #endregion

        #region class helper method

        private void UpdateUI()
        {
            ntxtSV100.Enabled = _matGroup == "SILVER";
            ntxtSV94.Enabled = ntxtSV100.Enabled;
            ntxtSV95.Enabled = ntxtSV100.Enabled;
            ntxtGold100.Enabled = _matGroup == "GOLD";
        } // end UpdateUI


        private void GetTreeInformation(int TreeId, ActionMode Mode)
        {
            switch (Mode)
            {
                case ActionMode.Add:
                    _tree = new WAXTREE();
                    _tree.AUDITUSER = omglobal.UserInfo;
                    _tree.MODIUSER = omglobal.UserInfo;
                    _tree.BUILDDATE = DateTime.Today.Date2Num();
                    _tree.GOLD100 = 0.00m;
                    _tree.SILVER100 = 0.00m;
                    _tree.SILVER94 = 0.00m;
                    _tree.SILVER95 = 0.00m;
                    _tree.ALLOYWEIGHT = 0.00m;
                    _tree.ACTUALMATWEIGHT = 0.00m;
                    _tree.ACTUALTEMP = 0.00m;
                    _tree.ACTUALWAX = 0.00m;
                    _tree.BASENWAXWG = 0.00m;
                    _tree.BASEWEIGHT = 0.00m;
                    _tree.CASTINGTEMP = 0.00m;
                    _tree.FURNACETEMP = 0.00m;
                    _tree.MATADDWEIGHT = 0.00m;
                    _tree.MATCASTING = 0;
                    _tree.MATFACTOR = 0.00m;
                    _tree.MATWEIGHTAF = 0.00m;
                    _tree.MATWEIGHTBF = 0.00m;
                    _tree.MATWEIGHTLOSS = 0.00m;
                    _tree.OTHERMATWEIGHT = 0.00m;
                    break;
                case ActionMode.Edit:
                    _tree = new CastingTreeController().GetWaxTreeInfo(TreeId);
                    break;
            }

            MapData(_tree);

        } // end GetTreeInformation

        private void MapData(WAXTREE source)
        {
            dtpBuildDate.Value = source.BUILDDATE.Num2Date();
            lbCustCode.Tag = source.CUSTID;
            lbCustCode.Text = source.CUSTCODE;
            lbCustomerName.Text = source.CUSTID > 0 ? FindCustomerName(source.CUSTID) : string.Empty;
            lbMaterial.Tag = source.MATCASTING;
            lbMatFactor.Text = source.MATFACTOR.ToString();
            lbMaterial.Text = source.MATCASTING > 0 ? FindMaterialName(source.MATCASTING) : string.Empty;

            lbBaseSize.Text = !string.IsNullOrEmpty(source.RUBBERBASENO) ? FindBaseSize(source.RUBBERBASENO) : string.Empty;
            lbBaseNo.Text = source.RUBBERBASENO;
            ntxtActualWeight.Text = $"{(_mode == ActionMode.Add ? 0 : (source.ALLOYWEIGHT + source.SILVER100 + source.SILVER94 + source.SILVER95)):N2}";
            ntxtBaseWeight.Text = $"{source.BASEWEIGHT:N2}";
            ntxtBaseWithWax.Text = $"{source.BASENWAXWG:N2}";
            ntxtWaxWT.Text = $"{(source.BASENWAXWG - source.BASEWEIGHT):N2}";
            ntxtMatAddWT.Text = $"{source.MATADDWEIGHT:N2}";
            ntxtWTBeforeCast.Text = $"{source.MATWEIGHTBF:N2}";

            ntxtFlaskTemp.Text = $"{source.FURNACETEMP:N2}";
            ntxtCastingTemp.Text = $"{source.CASTINGTEMP:N2}";

            // -- suspectation divide by zero ??????
            ntxtActualCastingTemp.Text = $"{source.ACTUALTEMP:N2}";

            txtCaster.Text = source.CASTINGBY;
            txtRemark.Text = source.REMARK;

            cbxAlloyType.Text = source.ALLOYTYPE;
            ntxtAlloyWT.Text = $"{source.ALLOYWEIGHT:N2}";

            ntxtSV95.Text = $"{source.SILVER95:N2}";
            udnSilver95MixRate.Value = (source.SILVER95 / (_mode == ActionMode.Add ? 1 : source.MATWEIGHTBF) * 100);

            flagFocus = source.SILVER94 == 0.00m ? (source.SILVER95 == 0.00m ? "" : "SIL95") : "SIL94";

            ntxtSV94.Text = $"{source.SILVER94:N2}";
            udnSilver94MixRate.Value = (source.SILVER94 / (_mode == ActionMode.Add ? 1 : source.MATWEIGHTBF) * 100);

            ntxtSV100.Text = $"{source.SILVER100:N2}";

            ntxtGold100.Text = $"{source.GOLD100:N2}";
            cbxOtherMat.Text = source.OTHERMAT;
            ntxtOtherMatWT.Text = $"{source.OTHERMATWEIGHT:N2}";

            ntxtWTAfterCast.Text = $"{source.MATWEIGHTAF:N2}";
            ntxtMatWTwithContainer.Text = $"{source.WEIGHTWITHCONTAINER:N2}";
            ntxtSlagWT.Text = $"{source.SLAG:N2}";
            ntxtWTLoss.Text = $"{source.MATWEIGHTLOSS:N2}";
            lbPercentLoss.Text = "0.00%";

            lbFocus.Text = flagFocus;

            UpdateUI();
        } // end MapData

        private string FindCustomerName(int CustomerId)
        {
            return new JobDAL().FindCastingCustomer(CustomerId);
        } // end FindCustomerName

        private string FindMaterialName(int MatId)
        {
            var _matName = new MaterialDAL().FindMaterialName(MatId, out _matGroup, out _matConvertFactor);
            lbMatGroup.Text = _matGroup;
            lbConvertFactor.Text = $"{_matConvertFactor:N4}";

            return _matName;
        } // end FindMaterialName

        private string FindBaseSize(string BaseNo)
        {
            return new CastingRubberBase().FindBaseSize(BaseNo);
        } // end FindBaseSize

        private void GetAlloyList()
        {
            cbxAlloyType.DataSource = new CastingTreeController().GetAlloyList();
            cbxAlloyType.DisplayMember = "ALLOYTYPE";
            cbxAlloyType.ValueMember = "ALLOYTYPE";
        } // end GetAlloyList

        private void GetOtherMatList()
        {
            cbxOtherMat.DataSource = new CastingTreeController().GetOtherMatList();
            cbxOtherMat.DisplayMember = "OTHERMAT";
            cbxOtherMat.ValueMember = "OTHERMAT";
        } // end GetOtherMatList

        private string flagFocus = "";

        /// <summary>
        /// activated when material value for sil95 & sil94 was changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calPercent(object sender, EventArgs e)
        {
            NumericTextBox t = sender as NumericTextBox;
            string flag = t.Tag.ToString();
            decimal weightBeforeCast = decimal.Parse(ntxtWTBeforeCast.Text) <= 0.00m ? 1 : decimal.Parse(ntxtWTBeforeCast.Text);

            switch (flag)
            {
                case "SIL95":
                    if (flagFocus == "P95")
                    {
                        if (t.Text.IsNumeric())
                        {
                            decimal rate95 = (decimal.Parse(t.Text) / weightBeforeCast) * 100m;
                            udnSilver95MixRate.Value = rate95 > 100.00m ? 100 : rate95;
                        }
                    }
                    break;
                case "SIL94":
                    if (flagFocus == "P94")
                    {
                        if (t.Text.IsNumeric())
                        {
                            decimal rate94 = (decimal.Parse(t.Text) / weightBeforeCast) * 100m;
                            udnSilver94MixRate.Value = rate94 > 100.00m ? 100 : rate94;
                        }
                    }
                    break;
            }

            CalActualMetalWeight();
        }

        private void CalMetal()
        {
            var _netWax = 0.00m;
            var _matAddWeight = 0.00m;
            var _weightNeed = 0.00m;
            var _matFactor = string.IsNullOrEmpty(lbMatFactor.Text) ? 0.00m : Convert.ToDecimal(lbMatFactor.Text);
            var _baseWeight = string.IsNullOrEmpty(ntxtBaseWeight.Text) ? 0.00m : Convert.ToDecimal(ntxtBaseWeight.Text);
            var _baseWithWax = string.IsNullOrEmpty(ntxtBaseWithWax.Text) ? 0.00m : Convert.ToDecimal(ntxtBaseWithWax.Text);

            if (_baseWithWax > 0.00m)
            {
                _netWax = _baseWithWax - _baseWeight;
                _matAddWeight = string.IsNullOrEmpty(ntxtMatAddWT.Text) ? 0.00m : Convert.ToDecimal(ntxtMatAddWT.Text);
                _weightNeed = _netWax * _matFactor + _matAddWeight;
            }

            // display
            ntxtWaxWT.Text = $"{_netWax:N2}";
            ntxtWTBeforeCast.Text = $"{_weightNeed:N2}";

            var _alloyWeight = 0.00m;
            var _gold100 = 0.00m;
            var _silver100 = 0.00m;

            if (Convert.ToDecimal(ntxtAlloyWT.Text) <= 0.00m)
            {
                _alloyWeight = _weightNeed * (1 - _matConvertFactor);
                ntxtAlloyWT.Text = $"{_alloyWeight:N2}";
            }

            switch (_matGroup)
            {
                case "GOLD":
                    if (Convert.ToDecimal(ntxtGold100.Text) <= 0.00m)
                    {
                        _gold100 = _weightNeed - _alloyWeight;
                        ntxtGold100.Text = $"{_gold100:N2}";
                    }
                    break;
                case "SILVER":
                    if (Convert.ToDecimal(ntxtSV100.Text) <= 0.00m)
                    {
                        _silver100 = _weightNeed - _alloyWeight;
                        ntxtSV100.Text = $"{_silver100:N2}";
                    }
                    break;
            }
        } // end CalMetal

        /// <summary>
        /// cal all weight
        /// </summary>
        private void CalActualMetalWeight()
        {
            var _otherMat = string.IsNullOrEmpty(ntxtOtherMatWT.Text) ? 0.00m : Convert.ToDecimal(ntxtOtherMatWT.Text);
            var _gold = 0.00m;
            var _sv95 = 0.00m;
            var _sv94 = 0.00m;
            var _sv100 = 0.00m;
            var _sv100Net = 0.00m;
            var _alloyWeight = 0.00m;


            switch (_matGroup)
            {
                case "GOLD":
                    _gold = string.IsNullOrEmpty(ntxtGold100.Text) ? 0.00m : Convert.ToDecimal(ntxtGold100.Text);
                    ntxtActualWeight.Text = $"{(_alloyWeight + _otherMat + _gold):N2}";
                    break;

                case "SILVER":
                    _sv95 = sil95Rate * (string.IsNullOrEmpty(ntxtWTBeforeCast.Text) ? 0.00m : decimal.Parse(ntxtWTBeforeCast.Text));
                    _sv94 = sil94Rate * (string.IsNullOrEmpty(ntxtWTBeforeCast.Text) ? 0.00m : decimal.Parse(ntxtWTBeforeCast.Text));
                    _sv100 = ((string.IsNullOrEmpty(ntxtWTBeforeCast.Text) ? 0.00m : decimal.Parse(ntxtWTBeforeCast.Text)) - _sv95 - _sv94 - _otherMat);
                    _alloyWeight = ((1 - decimal.Parse(lbConvertFactor.Text)) * _sv100);
                    _sv100Net = (_sv100 - _alloyWeight);

                    ntxtActualWeight.Text = $"{(_alloyWeight + _otherMat + _sv100Net + _sv94 + _sv95):N2}";
                    break;

                case "BRASS":
                case "BRONZE":
                default:
                    ntxtActualWeight.Text = $"{(_alloyWeight + _otherMat):N2}";
                    break;
            }

            ntxtAlloyWT.Text = $"{_alloyWeight:N2}";
            ntxtSV100.Text = $"{_sv100Net:N2}";
            ntxtSV94.Text = flagFocus == "SIL94" ? $"{_sv94:N2}" : ntxtSV94.Text;
            ntxtSV95.Text = flagFocus == "SIL95" ? $"{_sv95:N2}" : ntxtSV95.Text;


        } // end CalActualMetalWeight

        private void CalLoss()
        {
            var _actualWeight = string.IsNullOrEmpty(ntxtActualWeight.Text) ? 0.00m : Convert.ToDecimal(ntxtActualWeight.Text);
            var _weightAfterCast = string.IsNullOrEmpty(ntxtWTAfterCast.Text) ? 0.00m : Convert.ToDecimal(ntxtWTAfterCast.Text);

            var _slagWeight = string.IsNullOrEmpty(ntxtSlagWT.Text) ? 0.00m : Convert.ToDecimal(ntxtSlagWT.Text);

            var _weightLoss = _actualWeight - _weightAfterCast;
            var _weightLossWithSlag = _actualWeight - (_weightAfterCast + _slagWeight);

            var _lossPercent = _weightLoss / (_actualWeight > 0.00m ? _actualWeight : 1.0m);
            var _lossWithSlagPercent = _weightLossWithSlag / (_actualWeight > 0.00m ? _actualWeight : 1.0m);

            ntxtWTLoss.Text = $"{_weightLoss:N2}";
            lbPercentLoss.Text = $"{_lossPercent:P2}";
            lbLossWithSlag.Text = $"{_lossWithSlagPercent:P2}";
        } // end CalLoss


        private void SaveWaxTree(ActionMode Mode)
        {
            _tree.ACTUALMATWEIGHT = string.IsNullOrEmpty(ntxtActualWeight.Text)
                ? 0.00m
                : Convert.ToDecimal(ntxtActualWeight.Text);

            _tree.ACTUALTEMP = string.IsNullOrEmpty(ntxtActualCastingTemp.Text)
                ? 0.00m
                : Convert.ToDecimal(ntxtActualCastingTemp.Text);

            _tree.ACTUALWAX = string.IsNullOrEmpty(ntxtWaxWT.Text) ? 0.00m : Convert.ToDecimal(ntxtWaxWT.Text);

            _tree.ALLOYTYPE = cbxAlloyType.Text;

            _tree.ALLOYWEIGHT = string.IsNullOrEmpty(ntxtAlloyWT.Text) ? 0.00m : Convert.ToDecimal(ntxtAlloyWT.Text);

            _tree.AUDITUSER = _mode == ActionMode.Add ? omglobal.UserInfo : _tree.AUDITUSER;

            _tree.BASENWAXWG = string.IsNullOrEmpty(ntxtBaseWithWax.Text) ? 0.00m : Convert.ToDecimal(ntxtBaseWithWax.Text);

            _tree.BASEWEIGHT = string.IsNullOrEmpty(ntxtBaseWeight.Text) ? 0.00m : Convert.ToDecimal(ntxtBaseWeight.Text);

            _tree.BUILDDATE = dtpBuildDate.Value.Date2Num();

            _tree.CASTINGBY = txtCaster.Text;

            _tree.CASTINGTEMP = string.IsNullOrEmpty(ntxtCastingTemp.Text) ? 0.00m : Convert.ToDecimal(ntxtCastingTemp.Text);

            _tree.CUSTCODE = lbCustCode.Text;

            _tree.CUSTID = lbCustCode.Tag == null ? 0 : Convert.ToInt32(lbCustCode.Tag.ToString());

            _tree.FURNACETEMP = string.IsNullOrEmpty(ntxtFlaskTemp.Text) ? 0.00m : Convert.ToDecimal(ntxtFlaskTemp.Text);

            _tree.GOLD100 = string.IsNullOrEmpty(ntxtGold100.Text) ? 0.00m : Convert.ToDecimal(ntxtGold100.Text);

            _tree.ISDELETE = false;

            _tree.MATADDWEIGHT = string.IsNullOrEmpty(ntxtMatAddWT.Text) ? 0.00m : Convert.ToDecimal(ntxtMatAddWT.Text);

            _tree.MATCASTING = lbMaterial.Tag == null ? 0 : Convert.ToInt32(lbMaterial.Tag.ToString());

            _tree.MATFACTOR = string.IsNullOrEmpty(lbMatFactor.Text) ? 0.00m : Convert.ToDecimal(lbMatFactor.Text);

            _tree.MATWEIGHTAF = string.IsNullOrEmpty(ntxtWTAfterCast.Text) ? 0.00m : Convert.ToDecimal(ntxtWTAfterCast.Text);

            _tree.MATWEIGHTBF = string.IsNullOrEmpty(ntxtWTBeforeCast.Text) ? 0.00m : Convert.ToDecimal(ntxtWTBeforeCast.Text);

            _tree.MATWEIGHTLOSS = string.IsNullOrEmpty(ntxtWTLoss.Text) ? 0.00m : Convert.ToDecimal(ntxtWTLoss.Text);

            _tree.MODIDATE = DateTime.Now;

            _tree.MODIUSER = omglobal.UserInfo;

            _tree.OTHERMAT = cbxOtherMat.Text;

            _tree.OTHERMATWEIGHT = string.IsNullOrEmpty(ntxtOtherMatWT.Text) ? 0.00m : Convert.ToDecimal(ntxtOtherMatWT.Text);

            _tree.REMARK = txtRemark.Text;

            _tree.RUBBERBASENO = lbBaseNo.Text;

            _tree.SILVER100 = string.IsNullOrEmpty(ntxtSV100.Text) ? 0.00m : Convert.ToDecimal(ntxtSV100.Text);

            _tree.SILVER94 = string.IsNullOrEmpty(ntxtSV94.Text) ? 0.00m : Convert.ToDecimal(ntxtSV94.Text);

            _tree.SILVER95 = string.IsNullOrEmpty(ntxtSV95.Text) ? 0.00m : Convert.ToDecimal(ntxtSV95.Text);

            _tree.SLAG = string.IsNullOrEmpty(ntxtSlagWT.Text) ? 0.00m : Convert.ToDecimal(ntxtSlagWT.Text);

            _tree.WEIGHTWITHCONTAINER = string.IsNullOrEmpty(ntxtMatWTwithContainer.Text)
                ? 0.00m
                : Convert.ToDecimal(ntxtMatWTwithContainer.Text);

            if (new CastingTreeController().UpdateWatTree(Mode, _tree) > 0)
                MessageBox.Show(string.Format("{0} record successfully....", Mode == ActionMode.Add ? "insert" : "update"),
                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // end SaveWaxTree

        #endregion

        private void udnMixRate_ValueChanged(object sender, EventArgs e)
        {

            NumericUpDown nud = sender as NumericUpDown;

            switch (nud.Tag.ToString())
            {
                case "P95":
                    sil95Rate = nud.Value / 100.0m;
                    //if(flagFocus == "SIL95")
                    //{
                    //}
                    break;

                case "P94":
                    sil94Rate = nud.Value / 100.0m;
                    //if(flagFocus == "SIL94")
                    //{
                    //}
                    break;
            }

            CalActualMetalWeight();
        }

        private void udnMixRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalActualMetalWeight();
            }
        }

        private void ntxtSV95_Enter(object sender, EventArgs e)
        {
            flagFocus = "P95";
            lbFocus.Text = flagFocus;
        }

        private void udnSilver95MixRate_Enter(object sender, EventArgs e)
        {
            flagFocus = "SIL95";
            lbFocus.Text = flagFocus;
        }

        private void ntxtSV94_Enter(object sender, EventArgs e)
        {
            flagFocus = "P94";
            lbFocus.Text = flagFocus;
        }

        private void udnSilver94MixRate_Enter(object sender, EventArgs e)
        {
            flagFocus = "SIL94";
            lbFocus.Text = flagFocus;

        }

        private void ntxtSV100_TextChanged(object sender, EventArgs e)
        {
            CalActualMetalWeight();
        }
    }
}