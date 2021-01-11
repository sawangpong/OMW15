using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingPriceItem : Form
	{
		#region class field

		private CUSTPRICETAB _cpt;
		private ActionMode _mode = ActionMode.None;
		private int _id = 0;
		private int _itemId = 0;
		private int _matId = 0;
		private int _priceYear = DateTime.Today.Year;
		private string _unitName = string.Empty;
		private string _materialName = string.Empty;
		#endregion

		#region class helper
		private void UpdateUI()
		{

		}

		private void GetCastingPriceItem(int id)
		{
			if(_mode == ActionMode.Add)
			{
				_cpt = new CUSTPRICETAB();
				_cpt.CPT_CP = _itemId;
				_cpt.MATERIAL = _matId;
				_cpt.PRICE_YEAR = _priceYear;
				_cpt.PRICEUNITNAME = _unitName;
			}
			else
			{
				_cpt = new PriceListDAL().GetCastingPriceItem(id);

			}

			chkIsMatInclude.Checked = _cpt.ISMATINCLUDE;
			txtUnitPrice.Text = $"{_cpt.UNITPRICE:N2}";
			txtUnitName.Text = _cpt.PRICEUNITNAME;
			txtPriceYear.Text = _cpt.PRICE_YEAR.ToString();

		}

		#endregion

		public CastingPriceItem(int id, int itemId, int matId, int priceYear, string unitName = "", string materialName = "")
		{
			InitializeComponent();
			_id = id;
			_itemId = itemId;
			_matId = matId;
			_priceYear = priceYear;
			_unitName = unitName;
			_materialName = materialName;

			_mode = _id == 0 ? ActionMode.Add : ActionMode.Edit;
			lbMode.Text = _mode.ToString();
		}

		private void CastingPriceItem_Load(object sender, EventArgs e)
		{
			GetCastingPriceItem(_id);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			_cpt.ISMATINCLUDE = chkIsMatInclude.Checked;
			_cpt.MATERIAL = _matId;
			_cpt.UNITPRICE = Convert.ToDecimal(txtUnitPrice.Text);
			_cpt.PRICEUNITNAME = txtUnitName.Text;
			_cpt.PRICE_YEAR = Convert.ToInt32(txtPriceYear.Text);
			_cpt.CPT_CP = _itemId;

			int _result = new PriceListDAL().UpdateCustPriceTable(_cpt);
 
		}

		private void btnUnitName_Click(object sender, EventArgs e)
		{
			string _value = string.Empty;
			string _code = string.Empty;
			int _id = 0;

			ToolGetData.GetData(SelectTypeOption.UnitCount, ref _value, ref _code, ref _id);
			txtUnitName.Text = _value;
			UpdateUI();
		}
	}
}
