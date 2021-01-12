using OMW15.Models.ProductionModel;
using OMW15.Models.WarehouseModel;
using OMW15.Shared;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class SupInfo : Form
	{
		#region class field member

		private ActionMode _mode = ActionMode.None;
		private string _erpOrder = "";
		private int _outsourceItemId = 0;
		private PRODUCTION_OUTSOURCE _outsource;

		#endregion


		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnSave.Enabled = (!String.IsNullOrEmpty(txtAP_NAME.Text)
									&& !String.IsNullOrEmpty(txtUnit.Text)
									&& (Convert.ToDecimal(txtQty.Text) > 0m)
									&& (Convert.ToDecimal(txtLaborCost.Text) >= 0m)
									&& (Convert.ToDecimal(txtMatCost.Text) >= 0m)
									&& (Convert.ToDecimal(txtOtherCost.Text) >= 0m)
									&& (Convert.ToDecimal(txtTotalCost.Text) >= 0m)
									);
		}


		private void GetSupplierItem(int id)
		{
			switch (_mode)
			{
				case ActionMode.Add:

					_outsource = new PRODUCTION_OUTSOURCE();
					_outsource.Id = 0;
					_outsource.ERP_ORDER = _erpOrder;
					_outsource.AP_CODE = "";
					_outsource.AP_NAME = "";
					_outsource.BUILD_DETAIL = "";
					_outsource.BUILD_QTY = 0m;
					_outsource.DATESTART = DateTime.Today;
					_outsource.DATEFINISH = _outsource.DATESTART.AddDays(5);
					_outsource.DRAWINGNO = "";
					_outsource.DRAWING_REV = "";
					_outsource.ITEMNAME = "";
					_outsource.ITEMNO = "";
					_outsource.STEP = 0;
					_outsource.LABOR_COST = 0m;
					_outsource.MATERIAL_COST = 0m;
					_outsource.OTHER_COST = 0m;
					_outsource.TOTAL_COST = 0m;
					_outsource.UNIT = "";

					break;

				case ActionMode.Edit:

					_outsource = new SupplierDAL().GetOutsourceItem(id);
					break;
			}

			txtAP_NAME.Text = _outsource.AP_NAME;
			txtDrawing.Text = _outsource.DRAWINGNO;
			txtItemName.Text = _outsource.ITEMNAME;
			txtItemNo.Text = _outsource.ITEMNO;
			txtStep.Text = $"{_outsource.STEP}";
			txtLaborCost.Text = $"{_outsource.LABOR_COST:N2}";
			txtMatCost.Text = $"{_outsource.MATERIAL_COST:N2}";
			txtOtherCost.Text = $"{_outsource.OTHER_COST:N2}";
			txtQty.Text = $"{_outsource.BUILD_QTY:N2}";
			txtRevNo.Text = _outsource.DRAWING_REV;
			txtTotalCost.Text = $"{_outsource.TOTAL_COST:N2}";
			txtUnit.Text = _outsource.UNIT;

			UpdateUI();
		}

		private void SumCostOfOutSource()
		{
			decimal _matCost = Convert.ToDecimal(txtMatCost.Text);
			decimal _laborCost = Convert.ToDecimal(txtLaborCost.Text);
			decimal _otherCost = Convert.ToDecimal(txtOtherCost.Text);
			decimal _totalCost = _matCost + _laborCost + _otherCost;

			txtMatCost.Text = $"{_matCost:N2}";
			txtLaborCost.Text = $"{_laborCost:N2}";
			txtOtherCost.Text = $"{_otherCost:N2}";
			txtTotalCost.Text = $"{_totalCost:N2}";
		}

		private void GetItemInformation(string itemFilter)
		{
			//using (var _p = new STDParts(ActionMode.Selection, itemFilter))
			using (STDParts _p = new STDParts())
			{
				_p.ViewMode = ActionMode.Selection;
				_p.Filter = itemFilter;
				_p.StartPosition = FormStartPosition.CenterParent;
				if (_p.ShowDialog(this) == DialogResult.OK)
				{
					pic.Image = _p.ItemImage;
					txtItemNo.Text = _p.ItemNo;
					txtItemName.Text = _p.ItemName;
					txtUnit.Text = _p.Unit;
					txtDrawing.Text = _p.DrawingNo;
					txtRevNo.Text = _p.DrawingRevision.ToString();
				}
			}
		} // end GetItemInformation


		private void UpdateOutsourceItem(PRODUCTION_OUTSOURCE outsourceItem)
		{
			int _result = new SupplierDAL().UpdateProductionOutSource(outsourceItem);

			if (_result > 0)
			{
				//MessageBox.Show("Update outsource item completed..", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Update failed..", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
 
		#endregion

		public SupInfo(string erpOrder, int outsourceItemId)
		{
			InitializeComponent();
			_erpOrder = erpOrder;
			_outsourceItemId = outsourceItemId;

			lbERPOrder.Text = _erpOrder;

			_mode = _outsourceItemId == 0 ? ActionMode.Add : ActionMode.Edit;
			lbMode.Text = _mode.ToString();

		}

		private void SupInfo_Load(object sender, EventArgs e)
		{
			GetSupplierItem(_outsourceItemId);

			UpdateUI();

		}

		private void btnSearchSup_Click(object sender, EventArgs e)
		{
			using (var _supList = new SupplierList(txtAP_NAME.Text))
			{

				if (_supList.ShowDialog(this) == DialogResult.OK)
				{
					txtAP_NAME.Text = _supList.Supplier.AP_NAME;
					lbAP_CODE.Text = _supList.Supplier.AP_CODE;
				}
			}
		}

		private void txtAP_NAME_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnSearchSup.PerformClick();
			}
		}

		private void btnUnit_Click(object sender, EventArgs e)
		{
			var _cat = OMShareProduction.ProductionOptionEnum.ItemUnit;
			var dt = new WHDDAL().getUnitList();

			if (dt.Rows.Count > 0)
			{
				using (var _opt = new PrdOption(_cat))
				{
					_opt.DataSource = dt;
					if (_opt.ShowDialog() == DialogResult.OK)
					{
						if (!_opt.IsEmptyItem == false)
						{
							txtUnit.Text = _opt.SelectedItem;
						}
					}
				}
			}
			else
			{
				MessageBox.Show("No list available...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void txtUnit_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void dtpStart_ValueChanged(object sender, EventArgs e)
		{
			dtpFinish.Value = dtpStart.Value.AddDays(5);
		}

		private void btnItemNo_Click(object sender, EventArgs e)
		{
			GetItemInformation(txtItemNo.Text);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SumCostOfOutSource();

			_outsource.AP_CODE = lbAP_CODE.Text;
			_outsource.AP_NAME = txtAP_NAME.Text;
			_outsource.BUILD_DETAIL = txtBuildDetail.Text;
			_outsource.BUILD_QTY = Convert.ToDecimal(txtQty.Text);
			_outsource.DATEFINISH = dtpFinish.Value;
			_outsource.DATESTART = dtpStart.Value;
			_outsource.DRAWINGNO = txtDrawing.Text;
			_outsource.DRAWING_REV = txtRevNo.Text;
			_outsource.ERP_ORDER = lbERPOrder.Text;
			_outsource.ITEMNAME = txtItemName.Text;
			_outsource.ITEMNO = txtItemNo.Text;
			_outsource.STEP = String.IsNullOrEmpty(txtStep.Text) ? 0 : txtStep.Text.IsNumeric() ? Convert.ToInt32(txtStep.Text) : 0;
			_outsource.LABOR_COST = Convert.ToDecimal(txtLaborCost.Text);
			_outsource.MATERIAL_COST = Convert.ToDecimal(txtMatCost.Text);
			_outsource.OTHER_COST = Convert.ToDecimal(txtOtherCost.Text);
			_outsource.TOTAL_COST = Convert.ToDecimal(txtTotalCost.Text);
			_outsource.UNIT = txtUnit.Text;

			UpdateOutsourceItem(_outsource);
		}

		private void txt_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
			{
				SumCostOfOutSource();
				UpdateUI();
			}
		}

		private void txtItemNo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
			{
				btnItemNo.PerformClick();
			}
		}

		private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
			{
				UpdateUI();
			}
		}
		private void txt_Leave(object sender, EventArgs e)
		{
			SumCostOfOutSource();
		}
	}
}