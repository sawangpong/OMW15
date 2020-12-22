using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;

namespace OMW15.Casting.CastingView
{
	public partial class MaterialPriceInfo : Form
	{
		#region class field member

		private int _id = 0;
		private ActionMode _mode = ActionMode.None;

		private int _selectedMatId = 0;

		#endregion

		#region class Property

		public int MatPriceRecordId
		{
			set
			{
				_id = value;
				_mode = (_id > 0 ? ActionMode.Edit : ActionMode.Add);
			}
		}

		private void InsertOrUpdateMatpriceRecord(ActionMode Mode, int RecordId)
		{
			int _recordAffect = 0;
			MATPRICE _matPrice = new MATPRICE();

			_matPrice.AUDITDATE = OMControls.OMUtils.Date2Num(DateTime.Today);
			_matPrice.AUDITUSER = omglobal.UserName;
			_matPrice.COSTTHBGRAM = Convert.ToDecimal(this.lbMatCost.Text);
			_matPrice.EXCHANGERATE = Convert.ToDecimal(this.txtExchangeRate.Text);
			_matPrice.EXCHDATE = OMControls.OMUtils.Date2Num(Convert.ToDateTime(this.lbExchangeDate.Text));
			_matPrice.FISCPERIOD = this.dtpPriceDate.Value.Month;
			_matPrice.FISCYEAR = this.dtpPriceDate.Value.Year;
			_matPrice.MATID = _selectedMatId;
			_matPrice.MODIDATE = OMControls.OMUtils.Date2Num(DateTime.Today);
			_matPrice.MODIUSER = omglobal.UserName;
			_matPrice.ORGPRICEUSD = Convert.ToDecimal(this.txtMatCostUSD.Text);
			_matPrice.PRICEDATE = OMControls.OMUtils.Date2Num(this.dtpPriceDate.Text);
			_matPrice.PRICETHBGRAM = Convert.ToDecimal(this.lbMatPrice.Text);

			switch (Mode)
			{
				case ActionMode.Add:
					_recordAffect = new OMW15.Casting.CastingController.MaterialDAL().InsertMatPrice(_matPrice);
					break;
				case ActionMode.Edit:
					_matPrice.SEQ = RecordId;
					_recordAffect = new OMW15.Casting.CastingController.MaterialDAL().UpdateMatPrice(_matPrice, RecordId);
					break;
			}

			if (_recordAffect > 0)
			{
				omglobal.DisplayAlert("Message", (Mode == ActionMode.Add ? "Insert Record Successfully..." : "Update Record Successfully...."));
			}

		} // end InsertOrUpdateMatpriceRecord


		#endregion

		#region class helper method

		private void UpdateUI()
		{
			this.cbxMaterial.Enabled = (_mode == ActionMode.Add);

		} // end UpdateUI

		private void CalMaterialPrice(decimal CostInUSD, decimal ExchangeRate, decimal Factor, decimal Markup)
		{
			decimal _matCostInTHB = 0.00m;
			decimal _matPriceInTHB = 0.00m;

			try
			{
				_matCostInTHB = ((CostInUSD * ExchangeRate) / Factor);
				_matPriceInTHB = (_matCostInTHB * Markup);
			}
			catch
			{
				_matCostInTHB = 0.00m;
				_matPriceInTHB = 0.00m;
			}

			this.lbMatCost.Text = string.Format("{0:N2}", _matCostInTHB);
			this.lbMatPrice.Text = string.Format("{0:N2}", _matPriceInTHB);

		} // end CalMaterialPrice

		private void GetMaterialList()
		{
			this.cbxMaterial.DataSource = new OMW15.Casting.CastingController.MaterialDAL().GetMaterialForSaleList();
			this.cbxMaterial.DisplayMember = "MATNAME";
			this.cbxMaterial.ValueMember = "MATID";

		} // end getMaterialList


		private void GetMatPriceInfo(int RecordId)
		{
			// Get Data
			MATPRICE _mp = new OMW15.Casting.CastingController.MaterialDAL().GetMatPriceRecordInfo(RecordId);

			// binding to controls
			this.cbxMaterial.SelectedValue = _mp.MATID;
			this.txtExchangeRate.Text = string.Format("{0:N2}", _mp.EXCHANGERATE);
			this.txtMatCostUSD.Text = string.Format("{0:N2}", _mp.ORGPRICEUSD);
			this.dtpPriceDate.Value = OMControls.OMUtils.Num2Date(_mp.PRICEDATE);
			this.lbExchangeDate.Text = OMControls.OMUtils.Num2Date((object)_mp.EXCHDATE).ToShortDateString();
			this.lbMatCost.Text = string.Format("{0:N2}", _mp.COSTTHBGRAM);
			this.lbMatPrice.Text = string.Format("{0:N2}", _mp.PRICETHBGRAM);

			this.UpdateUI();

		} // end GetMatPriceInfo

		private void SetMatPriceInfoUI()
		{
			this.dtpPriceDate.Value = DateTime.Today;
			this.txtExchangeRate.Text = "0.00";
			this.txtMatCostUSD.Text = "0.00";

		} // end SetMatPriceInfoUI

		#endregion


		public MaterialPriceInfo()
		{
			InitializeComponent();
		}

		private void MaterialPriceInfo_Load(object sender, EventArgs e)
		{
			this.grp.Text = string.Format("คำนวนราคาขายวัสดุ ({0})", _mode.ToString());
			this.lbId.Text = string.Format("Id:({0})", _id);
			this.GetMaterialList();

			switch (_mode)
			{
				case ActionMode.Add:
					this.SetMatPriceInfoUI();
					break;
				case ActionMode.Edit:
					this.GetMatPriceInfo(_id);
					break;
			}
		}

		private void btnExchnageRate_Click(object sender, EventArgs e)
		{
			Tools.SelectExchangeList _exlist = new Tools.SelectExchangeList("USD", this.dtpPriceDate.Value.Year, this.dtpPriceDate.Value.Month);
			_exlist.StartPosition = FormStartPosition.CenterScreen;
			if (_exlist.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				this.txtExchangeRate.Text = string.Format("{0:N4}", _exlist.ExchangeRate);
				this.lbExchangeDate.Text = _exlist.ExchangeDate.ToShortDateString();
			}
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			this.CalMaterialPrice(Convert.ToDecimal(this.txtMatCostUSD.Text), Convert.ToDecimal(this.txtExchangeRate.Text), omglobal.DEFAULT_MATERIAL_CONVERT_FACTOR, omglobal.DEFAULT_MATERIAL_MARKUP_FACTOR);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.InsertOrUpdateMatpriceRecord(_mode, _id);
		}

		private void cbxMaterial_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cbxMaterial.SelectedValue.GetType() == typeof(System.Int32))
			{
				_selectedMatId = Convert.ToInt32(this.cbxMaterial.SelectedValue);
			}
		}
	}
}
