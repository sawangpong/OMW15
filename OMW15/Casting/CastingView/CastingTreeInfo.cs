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
	public partial class CastingTreeInfo : Form
	{
		#region class field member
		private WAXTREE _tree;
		private ActionMode _mode = ActionMode.None;
		private string _matGroup = string.Empty;
		private decimal _matConvertFactor = 0.00m;

		#endregion

		#region class property
		public int TreeId
		{
			get;
			set;
		}
		#endregion

		#region class helper method

		private void UpdateUI()
		{
			this.ntxtSV100.Enabled = (_matGroup == "SILVER");
			this.ntxtSV94.Enabled = this.ntxtSV100.Enabled;
			this.ntxtSV95.Enabled = this.ntxtSV100.Enabled;
			this.ntxtGold100.Enabled = (_matGroup == "GOLD");

		} // end UpdateUI


		private void GetTreeInformation(int TreeId, ActionMode Mode)
		{
			switch (Mode)
			{
				case ActionMode.Add:
					_tree = new WAXTREE();
					_tree.BUILDDATE = OMControls.OMUtils.Date2Num(DateTime.Today);
					break;
				case ActionMode.Edit:
					_tree = new Casting.CastingController.CastingTreeController().GetWaxTreeInfo(TreeId);
					break;
			}

			this.MapData(_tree);

		} // end GetTreeInformation

		private void MapData(WAXTREE source)
		{
			this.dtpBuildDate.Value = OMControls.OMUtils.Num2Date(source.BUILDDATE);
			this.lbCustCode.Tag = source.CUSTID;
			this.lbCustCode.Text = source.CUSTCODE;
			this.lbCustomerName.Text = ((source.CUSTID > 0) ? this.FindCustomerName(source.CUSTID) : string.Empty);
			this.lbMaterial.Tag = source.MATCASTING;
			this.lbMatFactor.Text = source.MATFACTOR.ToString();
			this.lbMaterial.Text = ((source.MATCASTING > 0) ? this.FindMaterialName(source.MATCASTING) : string.Empty);
			this.lbPercentLoss.Text = "0.00%";
			this.lbBaseSize.Text = ((!string.IsNullOrEmpty(source.RUBBERBASENO)) ? this.FindBaseSize(source.RUBBERBASENO) : string.Empty);
			this.txtCaster.Text = source.CASTINGBY;
			this.ntxtActualCastingTemp.Text = string.Format("{0:N2}", source.ACTUALTEMP);
			this.ntxtActualWeight.Text = string.Format("{0:N2}", source.ACTUALMATWEIGHT);
			this.ntxtAlloyWT.Text = string.Format("{0:N2}", source.ALLOYWEIGHT);
			this.ntxtBaseWeight.Text = string.Format("{0:N2}", source.BASEWEIGHT);
			this.ntxtBaseWithWax.Text = string.Format("{0:N2}", source.BASENWAXWG);
			this.ntxtCastingTemp.Text = string.Format("{0:N2}", source.CASTINGTEMP);
			this.ntxtFlaskTemp.Text = string.Format("{0:N2}", source.FURNACETEMP);
			this.ntxtGold100.Text = string.Format("{0:N2}", source.GOLD100);
			this.ntxtMatAddWT.Text = string.Format("{0:N2}", source.MATADDWEIGHT);
			this.ntxtMatWTwithContainer.Text = string.Format("{0:N2}", source.WEIGHTWITHCONTAINER);
			this.ntxtOtherMatWT.Text = string.Format("{0:N2}", source.OTHERMATWEIGHT);
			this.ntxtSlagWT.Text = string.Format("{0:N2}", source.SLAG);
			this.ntxtSV100.Text = string.Format("{0:N2}", source.SILVER100);
			this.ntxtSV94.Text = string.Format("{0:N2}", source.SILVER94);
			this.ntxtSV95.Text = string.Format("{0:N2}", source.SILVER95);
			this.ntxtWaxWT.Text = string.Format("{0:N2}", (source.BASENWAXWG - source.BASEWEIGHT));
			this.ntxtWTAfterCast.Text = string.Format("{0:N2}", source.MATWEIGHTAF);
			this.ntxtWTBeforeCast.Text = string.Format("{0:N2}", source.MATWEIGHTBF);
			this.ntxtWTLoss.Text = string.Format("{0:N2}", source.MATWEIGHTLOSS);
			this.cbxAlloyType.Text = source.ALLOYTYPE;
			this.lbBaseNo.Text = source.RUBBERBASENO;
			this.cbxOtherMat.Text = source.OTHERMAT;
			this.txtRemark.Text = source.REMARK;

		} // end MapData

		private string FindCustomerName(int CustomerId)
		{
			return new Casting.CastingController.JobDAL().FindCastingCustomer(CustomerId);

		} // end FindCustomerName

		private string FindMaterialName(int MatId)
		{
			string _matName = new Casting.CastingController.MaterialDAL().FindMaterialName(MatId, out _matGroup, out _matConvertFactor);
			this.lbMatGroup.Text = _matGroup;
			this.lbConvertFactor.Text = string.Format("{0:N4}", _matConvertFactor);

			return _matName;

		} // end FindMaterialName

		private string FindBaseSize(string BaseNo)
		{
			return Casting.CastingController.CastingRubberBase.FindBaseSize(BaseNo);
		} // end FindBaseSize

		private void GetAlloyList()
		{
			this.cbxAlloyType.DataSource = new  Casting.CastingController.CastingTreeController().GetAlloyList();
			this.cbxAlloyType.DisplayMember = "ALLOYTYPE";
			this.cbxAlloyType.ValueMember = "ALLOYTYPE";

		} // end GetAlloyList

		private void GetOtherMatList()
		{
			this.cbxOtherMat.DataSource = new Casting.CastingController.CastingTreeController().GetOtherMatList();
			this.cbxOtherMat.DisplayMember = "OTHERMAT";
			this.cbxOtherMat.ValueMember = "OTHERMAT";

		} // end GetOtherMatList


		private void CalMetal()
		{
			decimal _netWax = 0.00m;
			decimal _matAddWeight = 0.00m;
			decimal _weightNeed = 0.00m;
			decimal _matFactor = string.IsNullOrEmpty(this.lbMatFactor.Text) ? 0.00m : Convert.ToDecimal(this.lbMatFactor.Text);
			decimal _baseWeight = string.IsNullOrEmpty(this.ntxtBaseWeight.Text) ? 0.00m : Convert.ToDecimal(this.ntxtBaseWeight.Text);
			decimal _baseWithWax = string.IsNullOrEmpty(this.ntxtBaseWithWax.Text) ? 0.00m : Convert.ToDecimal(this.ntxtBaseWithWax.Text);

			if (_baseWithWax > 0.00m)
			{
				_netWax = (_baseWithWax - _baseWeight);
				_matAddWeight = string.IsNullOrEmpty(this.ntxtMatAddWT.Text) ? 0.00m : Convert.ToDecimal(this.ntxtMatAddWT.Text);
				_weightNeed = ((_netWax * _matFactor) + _matAddWeight);
			}
			else
			{

			}

			// display
			this.ntxtWaxWT.Text = string.Format("{0:N2}", _netWax);
			this.ntxtWTBeforeCast.Text = string.Format("{0:N2}", _weightNeed);

			decimal _alloyWeight = 0.00m;
			decimal _gold100 = 0.00m;
			decimal _silver100 = 0.00m;


			if (Convert.ToDecimal(this.ntxtAlloyWT.Text) <= 0.00m)
			{
				_alloyWeight = (_weightNeed * (1 - _matConvertFactor));
				this.ntxtAlloyWT.Text = string.Format("{0:N2}", _alloyWeight);
			}

			switch (_matGroup)
			{
				case "GOLD":
					if (Convert.ToDecimal(this.ntxtGold100.Text) <= 0.00m)
					{
						_gold100 = (_weightNeed - _alloyWeight);
						this.ntxtGold100.Text = string.Format("{0:N2}", _gold100);
					}
					break;
				case "SILVER":
					if (Convert.ToDecimal(this.ntxtSV100.Text) <= 0.00m)
					{
						_silver100 = (_weightNeed - _alloyWeight);
						this.ntxtSV100.Text = string.Format("{0:N2}", _silver100);
					}
					break;
			}

		} // end CalMetal

		private void CalActualMetalWeight()
		{
			decimal _alloyWeight = string.IsNullOrEmpty(this.ntxtAlloyWT.Text) ? 0.00m : Convert.ToDecimal(this.ntxtAlloyWT.Text);
			decimal _otherMat = string.IsNullOrEmpty(this.ntxtOtherMatWT.Text) ? 0.00m : Convert.ToDecimal(this.ntxtOtherMatWT.Text);
			decimal _gold = 0.00m;
			decimal _sv100 = 0.00m;
			decimal _sv95 = 0.00m;
			decimal _sv94 = 0.00m;

			switch (_matGroup)
			{
				case "GOLD":
					_gold = string.IsNullOrEmpty(this.ntxtGold100.Text) ? 0.00m : Convert.ToDecimal(this.ntxtGold100.Text);
					this.ntxtActualWeight.Text = string.Format("{0:N2}", (_alloyWeight + _otherMat + _gold));
					break;
				case "SILVER":
					_sv100 = string.IsNullOrEmpty(this.ntxtSV100.Text) ? 0.00m : Convert.ToDecimal(this.ntxtSV100.Text);
					_sv95 = string.IsNullOrEmpty(this.ntxtSV95.Text) ? 0.00m : Convert.ToDecimal(this.ntxtSV95.Text);
					_sv94 = string.IsNullOrEmpty(this.ntxtSV94.Text) ? 0.00m : Convert.ToDecimal(this.ntxtSV94.Text);
					this.ntxtActualWeight.Text = string.Format("{0:N2}", (_alloyWeight + _otherMat + _sv100 + _sv94 + _sv95));
					break;
			}

		} // end CalActualMetalWeight

		private void CalLoss()
		{
			decimal _actualWeight = string.IsNullOrEmpty(this.ntxtActualWeight.Text) ? 0.00m : Convert.ToDecimal(this.ntxtActualWeight.Text);
			decimal _weightAfterCast = string.IsNullOrEmpty(this.ntxtWTAfterCast.Text) ? 0.00m : Convert.ToDecimal(this.ntxtWTAfterCast.Text);

			decimal _slagWeight = string.IsNullOrEmpty(this.ntxtSlagWT.Text) ? 0.00m : Convert.ToDecimal(this.ntxtSlagWT.Text);

			decimal _weightLoss = (_actualWeight - _weightAfterCast);
			decimal _weightLossWithSlag = (_actualWeight - (_weightAfterCast + _slagWeight));

			decimal _lossPercent = (_weightLoss / _actualWeight);
			decimal _lossWithSlagPercent = (_weightLossWithSlag / _actualWeight);

			this.ntxtWTLoss.Text = string.Format("{0:N2}", _weightLoss);
			this.lbPercentLoss.Text = string.Format("{0:P2}", _lossPercent);
			this.lbLossWithSlag.Text = string.Format("{0:P2}", _lossWithSlagPercent);

		} // end CalLoss


		private void SaveWaxTree(ActionMode Mode)
		{
			_tree.ACTUALMATWEIGHT = string.IsNullOrEmpty(this.ntxtActualWeight.Text) ? 0.00m : Convert.ToDecimal(this.ntxtActualWeight.Text);

			_tree.ACTUALTEMP = string.IsNullOrEmpty(this.ntxtActualCastingTemp.Text) ? 0.00m : Convert.ToDecimal(this.ntxtActualCastingTemp.Text);

			_tree.ACTUALWAX = string.IsNullOrEmpty(this.ntxtWaxWT.Text) ? 0.00m : Convert.ToDecimal(this.ntxtWaxWT.Text);

			_tree.ALLOYTYPE = this.cbxAlloyType.Text;

			_tree.ALLOYWEIGHT = string.IsNullOrEmpty(this.ntxtAlloyWT.Text) ? 0.00m : Convert.ToDecimal(this.ntxtAlloyWT.Text);

			_tree.AUDITUSER = _mode == ActionMode.Add ? omglobal.UserName : _tree.AUDITUSER;

			_tree.BASENWAXWG = string.IsNullOrEmpty(this.ntxtBaseWithWax.Text) ? 0.00m : Convert.ToDecimal(this.ntxtBaseWithWax.Text);

			_tree.BASEWEIGHT = string.IsNullOrEmpty(this.ntxtBaseWeight.Text) ? 0.00m : Convert.ToDecimal(this.ntxtBaseWeight.Text);

			_tree.BUILDDATE = OMControls.OMUtils.Date2Num(this.dtpBuildDate.Value);

			_tree.CASTINGBY = this.txtCaster.Text;

			_tree.CASTINGTEMP = string.IsNullOrEmpty(this.ntxtCastingTemp.Text) ? 0.00m : Convert.ToDecimal(this.ntxtCastingTemp.Text);

			_tree.CUSTCODE = this.lbCustCode.Text;

			_tree.CUSTID = (this.lbCustCode.Tag == null) ? 0 : Convert.ToInt32(this.lbCustCode.Tag.ToString());

			_tree.FURNACETEMP = string.IsNullOrEmpty(this.ntxtFlaskTemp.Text) ? 0.00m : Convert.ToDecimal(this.ntxtFlaskTemp.Text);

			_tree.GOLD100 = string.IsNullOrEmpty(this.ntxtGold100.Text) ? 0.00m : Convert.ToDecimal(this.ntxtGold100.Text);

			_tree.ISDELETE = false;

			_tree.MATADDWEIGHT = string.IsNullOrEmpty(this.ntxtMatAddWT.Text) ? 0.00m : Convert.ToDecimal(this.ntxtMatAddWT.Text);

			_tree.MATCASTING = (this.lbMaterial.Tag == null) ? 0 : Convert.ToInt32(this.lbMaterial.Tag.ToString());

			_tree.MATFACTOR = string.IsNullOrEmpty(this.lbMatFactor.Text) ? 0.00m : Convert.ToDecimal(this.lbMatFactor.Text);

			_tree.MATWEIGHTAF = string.IsNullOrEmpty(this.ntxtWTAfterCast.Text) ? 0.00m : Convert.ToDecimal(this.ntxtWTAfterCast.Text);

			_tree.MATWEIGHTBF = string.IsNullOrEmpty(this.ntxtWTBeforeCast.Text) ? 0.00m : Convert.ToDecimal(this.ntxtWTBeforeCast.Text);

			_tree.MATWEIGHTLOSS = string.IsNullOrEmpty(this.ntxtWTLoss.Text) ? 0.00m : Convert.ToDecimal(this.ntxtWTLoss.Text);

			_tree.MODIDATE = DateTime.Now;

			_tree.MODIUSER = omglobal.UserName;

			_tree.OTHERMAT = this.cbxOtherMat.Text;

			_tree.OTHERMATWEIGHT = string.IsNullOrEmpty(this.ntxtOtherMatWT.Text) ? 0.00m : Convert.ToDecimal(this.ntxtOtherMatWT.Text);

			_tree.REMARK = this.txtRemark.Text;

			_tree.RUBBERBASENO = this.lbBaseNo.Text;

			_tree.SILVER100 = string.IsNullOrEmpty(this.ntxtSV100.Text) ? 0.00m : Convert.ToDecimal(this.ntxtSV100.Text);

			_tree.SILVER94 = string.IsNullOrEmpty(this.ntxtSV94.Text) ? 0.00m : Convert.ToDecimal(this.ntxtSV94.Text);

			_tree.SILVER95 = string.IsNullOrEmpty(this.ntxtSV95.Text) ? 0.00m : Convert.ToDecimal(this.ntxtSV95.Text);

			_tree.SLAG = string.IsNullOrEmpty(this.ntxtSlagWT.Text) ? 0.00m : Convert.ToDecimal(this.ntxtSlagWT.Text);

			_tree.WEIGHTWITHCONTAINER = string.IsNullOrEmpty(this.ntxtMatWTwithContainer.Text) ? 0.00m : Convert.ToDecimal(this.ntxtMatWTwithContainer.Text);

			if (new Casting.CastingController.CastingTreeController().UpdateWatTree(Mode, _tree) > 0)
			{
				MessageBox.Show(string.Format("{0} record successfully....", Mode == ActionMode.Add ? "insert" : "update"), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		} // end SaveWaxTree

		#endregion


		public CastingTreeInfo()
		{
			InitializeComponent();
		}

		private void CastingTreeInfo_Load(object sender, EventArgs e)
		{
			_mode = this.TreeId == 0 ? ActionMode.Add : ActionMode.Edit;
			this.GetAlloyList();
			this.GetOtherMatList();

			this.groupBox1.Text = string.Format("รายละเอียดต้นเทียน :: [{0}]", _mode.ToString());

			this.GetTreeInformation(this.TreeId, _mode);

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCustomer_Click(object sender, EventArgs e)
		{
			using (Casting.CastingView.CastingCustomer _jc = new CastingCustomer())
			{
				_jc.StartPosition = FormStartPosition.CenterScreen;
				if (_jc.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					this.lbCustCode.Tag = _jc.CustomerId;
					this.lbCustCode.Text = _jc.CustomerCode;
					this.lbCustomerName.Text = _jc.CustomerName;
				}
			}
		}

		private void btnMaterial_Click(object sender, EventArgs e)
		{
			using (Casting.CastingView.CastingMatList ml = new CastingMatList(ActionMode.Selection))
			{
				ml.StartPosition = FormStartPosition.CenterScreen;
				if (ml.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					_matGroup = ml.MatGroup;
					_matConvertFactor = ml.ConvertFactor;
					this.lbMatGroup.Text = _matGroup;
					this.lbMaterial.Text = ml.MatName;
					this.lbMaterial.Tag = ml.MatId;
					this.lbMatFactor.Text = string.Format("{0:N2}", ml.MatFactor);
					this.ntxtFlaskTemp.Text = string.Format("{0:N2}", ml.FlaskTemp);
					this.ntxtCastingTemp.Text = string.Format("{0:N2}", ml.CastingTemp);
				}
				else
				{
					_matGroup = string.Empty;
					_matConvertFactor = 0.00m;
				}

				this.lbMatGroup.Text = _matGroup;
				this.lbConvertFactor.Text = string.Format("{0:N4}", _matConvertFactor);

				this.UpdateUI();
			}
		}

		private void btnRubberBase_Click(object sender, EventArgs e)
		{
			using (Casting.CastingView.RBList rb = new RBList(ActionMode.Selection))
			{
				rb.StartPosition = FormStartPosition.CenterScreen;
				if (rb.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					this.lbBaseSize.Text = rb.BaseSize;
					this.lbBaseNo.Text = rb.BaseNo;
					this.ntxtBaseWeight.Text = string.Format("{0:N2}", rb.BaseWeight);
				}
			}
		}

		private void btnCastingMan_Click(object sender, EventArgs e)
		{
			Tools.SelectBox _selectBox = new Tools.SelectBox();
			_selectBox.SelectOption = SelectTypeOption.Worker;
			//_selectBox.FilterId = FilterId;
			_selectBox.StartPosition = FormStartPosition.CenterScreen;
			if (_selectBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.txtCaster.Text = _selectBox.SelectedName;
				//Code = _selectBox.SelectedCode;
				//Id = _selectBox.SelectedId;
			}
		}

		private void ntxtBase_TextChanged(object sender, EventArgs e)
		{
			// calculate metal
			this.CalMetal();
		}

		private void ntxtSV_TextChanged(object sender, EventArgs e)
		{
			this.CalActualMetalWeight();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.SaveWaxTree(_mode);
		}

		private void ntxtLoss_TextChanged(object sender, EventArgs e)
		{
			this.CalLoss();
		}
	}
}
