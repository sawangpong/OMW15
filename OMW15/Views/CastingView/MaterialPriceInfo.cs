using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;
using OMW15.Views.ToolViews;
using System;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class MaterialPriceInfo : Form
	{
		public MaterialPriceInfo()
		{
			InitializeComponent();
		}

		private void MaterialPriceInfo_Load(object sender, EventArgs e)
		{
			grp.Text = string.Format("คำนวนราคาขายวัสดุ ({0})", _mode);
			lbId.Text = string.Format("Id:({0})", _id);
			GetMaterialList();

			switch (_mode)
			{
				case ActionMode.Add:
					SetMatPriceInfoUI();
					break;
				case ActionMode.Edit:
					GetMatPriceInfo(_id);
					break;
			}
		}

		private void btnExchnageRate_Click(object sender, EventArgs e)
		{
			var _exlist = new SelectExchangeList("USD", dtpPriceDate.Value.Year, dtpPriceDate.Value.Month);
			_exlist.StartPosition = FormStartPosition.CenterScreen;
			if (_exlist.ShowDialog(this) == DialogResult.OK)
			{
				txtExchangeRate.Text = string.Format("{0:N4}", _exlist.ExchangeRate);
				lbExchangeDate.Text = _exlist.ExchangeDate.ToShortDateString();
			}
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			CalMaterialPrice(Convert.ToDecimal(txtMatCostUSD.Text), Convert.ToDecimal(txtExchangeRate.Text),
				omglobal.DEFAULT_MATERIAL_CONVERT_FACTOR, _markup);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			InsertOrUpdateMatpriceRecord(_mode, _id);
		}

		private void cbxMaterial_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbxMaterial.SelectedValue.GetType() == typeof(int))
				_selectedMatId = Convert.ToInt32(cbxMaterial.SelectedValue);

			switch (_selectedMatId)
			{
				case 2: // silver
					_markup = omglobal.DEFAULT_SILVER_MARKUP_FACTOR;
					break;
				case 12: // gold
					_markup = omglobal.DEFAULT_GOLD_MARKUP_FACTOR;
					break;
				default: // for general material for sell
					_markup = omglobal.DEFAULT_SILVER_MARKUP_FACTOR;
					break;
			}

			lbMarkup.Text = $"{_markup:N2}";
		}

		#region class field member

		private int _id;
		private ActionMode _mode = ActionMode.None;
		private decimal _markup = omglobal.DEFAULT_SILVER_MARKUP_FACTOR;

		private int _selectedMatId;

		#endregion

		#region class Property

		public int MatPriceRecordId
		{
			set
			{
				_id = value;
				_mode = _id > 0 ? ActionMode.Edit : ActionMode.Add;
			}
		}

		private void InsertOrUpdateMatpriceRecord(ActionMode Mode, int RecordId)
		{
			var _recordAffect = 0;
			var _matPrice = new MATPRICE();

			_matPrice.AUDITDATE = DateTime.Today.Date2Num();
			_matPrice.AUDITUSER = omglobal.UserInfo;
			_matPrice.COSTTHBGRAM = Convert.ToDecimal(lbMatCost.Text);
			_matPrice.EXCHANGERATE = Convert.ToDecimal(txtExchangeRate.Text);
			_matPrice.EXCHDATE = lbExchangeDate.Text.Date2Num();
			_matPrice.FISCPERIOD = dtpPriceDate.Value.Month;
			_matPrice.FISCYEAR = dtpPriceDate.Value.Year;
			_matPrice.MATID = _selectedMatId;
			_matPrice.MODIDATE = DateTime.Today.Date2Num();
			_matPrice.MODIUSER = omglobal.UserInfo;
			_matPrice.ORGPRICEUSD = Convert.ToDecimal(txtMatCostUSD.Text);
			_matPrice.PRICEDATE = dtpPriceDate.Text.Date2Num();
			_matPrice.PRICETHBGRAM = Convert.ToDecimal(lbMatPrice.Text);

			switch (Mode)
			{
				case ActionMode.Add:
					_recordAffect = new MaterialDAL().InsertMatPrice(_matPrice);
					break;
				case ActionMode.Edit:
					_matPrice.SEQ = RecordId;
					_recordAffect = new MaterialDAL().UpdateMatPrice(_matPrice, RecordId);
					break;
			}

			if (_recordAffect > 0)
				Alert.DisplayAlert("Message",
					Mode == ActionMode.Add ? "Insert Record Successfully..." : "Update Record Successfully....");
		} // end InsertOrUpdateMatpriceRecord

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			cbxMaterial.Enabled = _mode == ActionMode.Add;
		} // end UpdateUI

		private void CalMaterialPrice(decimal CostInUSD, decimal ExchangeRate, decimal Factor, decimal Markup)
		{
			var _matCostInTHB = 0.00m;
			var _matPriceInTHB = 0.00m;

			try
			{
				_matCostInTHB = CostInUSD * ExchangeRate / Factor;
				_matPriceInTHB = _matCostInTHB * Markup;
			}
			catch
			{
				_matCostInTHB = 0.00m;
				_matPriceInTHB = 0.00m;
			}

			lbMatCost.Text = $"{_matCostInTHB:N2}";
			lbMatPrice.Text = $"{_matPriceInTHB:N2}";
		} // end CalMaterialPrice

		private void GetMaterialList()
		{
			cbxMaterial.DataSource = new MaterialDAL().GetMaterialForSaleList();
			cbxMaterial.DisplayMember = "MATNAME";
			cbxMaterial.ValueMember = "MATID";
		} // end getMaterialList


		private void GetMatPriceInfo(int RecordId)
		{
			// Get Data
			var _mp = new MaterialDAL().GetMatPriceRecordInfo(RecordId);

			// binding to controls
			cbxMaterial.SelectedValue = _mp.MATID;
			txtExchangeRate.Text = $"{_mp.EXCHANGERATE:N2}";
			txtMatCostUSD.Text = $"{_mp.ORGPRICEUSD:N2}";
			dtpPriceDate.Value = _mp.PRICEDATE.Value.Num2Date();
			lbExchangeDate.Text = _mp.EXCHDATE.Value.Num2Date().ToShortDateString();
			lbMatCost.Text = $"{_mp.COSTTHBGRAM:N2}";
			lbMatPrice.Text = $"{_mp.PRICETHBGRAM:N2}";

			UpdateUI();
		} // end GetMatPriceInfo

		private void SetMatPriceInfoUI()
		{
			dtpPriceDate.Value = DateTime.Today;
			txtExchangeRate.Text = "0.00";
			txtMatCostUSD.Text = "0.00";
		} // end SetMatPriceInfoUI

		#endregion

		private void cbxMaterial_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}