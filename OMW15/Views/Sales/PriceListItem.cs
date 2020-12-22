using System;
using System.Windows.Forms;
using OMW15.Models.SaleModel;
using OMW15.Shared;
using OMW15.Views.WarehouseView;
using OMControls.Controls;

namespace OMW15.Views.Sales
{
	public partial class PriceListItem : Form
	{
		public PriceListItem()
		{
			InitializeComponent();
		}

		private void PriceListItem_Load(object sender, EventArgs e)
		{
			CenterToParent();

			mode = string.IsNullOrEmpty(PriceItemId) ? ActionMode.Add : ActionMode.Edit;
			lbMode.Text = mode.ToString();

			GetItemPriceListInfo(PriceItemId);
		}

		private void btnItemSearch_Click(object sender, EventArgs e)
		{
			GetMasterPriceItem();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			itemPL = new ITEMSPRICELIST();
			switch(mode)
			{
				case ActionMode.Add:
					itemPL.SPID = 0;
					itemPL.AUDITUSER = omglobal.UserInfo;
					break;

				case ActionMode.Edit:
					itemPL.SPID = SPID;
					break;
			}

			itemPL.EFFECTIVE = txtEffective.Text.Date2Num();
			itemPL.EXPIRE = txtExpireDate.Text.Date2Num();
			itemPL.FOR_MACHINE = txtPartForMC.Text;
			itemPL.ITEMID = txtItemNo.Text;
			itemPL.ITEMNAME = txtItemName.Text;
			itemPL.LASTUPDATE = DateTime.Now;
			itemPL.MODIUSER = omglobal.UserInfo;
			itemPL.THB_UNITCOST = Convert.ToDecimal(txtTHBCost.Text);
			itemPL.SOURCE_FACTOR = Convert.ToDecimal(txtExchange.Text);
			itemPL.THB_UNITPRICE = Convert.ToDecimal(txtTHBUnitPrice.Text);
			itemPL.UNIT = txtUnit.Text;
			itemPL.USD_UNITPRICE = Convert.ToDecimal(txtUSDUnitPrice.Text);
			itemPL.ISACTIVE = chkIsActive.Checked;

			if(new SalePriceItemDAL().UpdatePriceListItem(itemPL) > 0)
			{
				MessageBox.Show("Update price list successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void btnPriceEffective_ButtonClick(object sender, EventArgs e)
		{
			btnPriceEffective.SelectedDate = string.IsNullOrEmpty(txtEffective.Text) ? DateTime.Today : txtEffective.Text.Num2Date();
		}

		private void btnPriceEffective_DateSelected(object sender, EventArgs e)
		{
			txtEffective.Text = btnPriceEffective.SelectedDate.ToShortDateString();
		}

		#region class field member

		private ActionMode mode = ActionMode.None;
		private ITEMSPRICELIST itemPL;

		#endregion

		#region class property

		public int SPID
		{
			get; set;
		}

		public string PriceItemId
		{
			get; set;
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnItemSearch.Enabled = mode == ActionMode.Add;
			txtItemNo.Enabled = mode == ActionMode.Add;

		} // end UpdateUI

		private void GetItemPriceListInfo(string ItemId)
		{
			switch(mode)
			{
				case ActionMode.Add:
					itemPL = new ITEMSPRICELIST();
					txtExchange.Text = $"{omglobal.SOURCE_CURRENCY_VALUE:N2}";
					txtEffective.Text = DateTime.Today.ToShortDateString();
					chkIsActive.Checked = true;

					break;

				case ActionMode.Edit:
					itemPL = new SalePriceItemDAL().GetPriceListItem(ItemId);

					// display info
					txtEffective.Text = itemPL.EFFECTIVE.Num2Date().ToShortDateString();
					txtExpireDate.Text = itemPL.EXPIRE.Num2Date().ToShortDateString();
					txtItemNo.Text = itemPL.ITEMID;
					txtItemName.Text = itemPL.ITEMNAME;
					txtUnit.Text = itemPL.UNIT;
					txtTHBCost.Text = $"{itemPL.THB_UNITCOST:N2}";
					txtTHBUnitPrice.Text = $"{itemPL.THB_UNITPRICE:N2}";
					txtExchange.Text = $"{(itemPL.SOURCE_FACTOR == 0.00m ? omglobal.SOURCE_CURRENCY_VALUE : itemPL.SOURCE_FACTOR):N2}";
					txtUSDUnitPrice.Text = $"{itemPL.USD_UNITPRICE:N2}";
					txtPartForMC.Text = itemPL.FOR_MACHINE;
					chkIsActive.Checked = itemPL.ISACTIVE;

					// get master item picture

					break;
			}

			UpdateUI();
		} // end GetItemPriceListInfo

		private void GetMasterPriceItem()
		{
			using(var stdPriceItem = new STDPriceList(ActionMode.Selection, OMShareWarehouseEnums.StockAppCall.StockMaster))
			{
				if(stdPriceItem.ShowDialog() == DialogResult.OK)
				{
					txtItemNo.Text = stdPriceItem.PartNo;
					txtItemName.Text = string.IsNullOrEmpty(stdPriceItem.PartName)
						? stdPriceItem.PartName
						: stdPriceItem.PartName;
					txtUnit.Text = stdPriceItem.Unit;
					txtTHBCost.Text = $"{stdPriceItem.ThUnitCost:N2}";
					txtTHBUnitPrice.Text = $"{stdPriceItem.ThUnitPrice:N2}";

					decimal thbUnitPrice = 0.00m;
					decimal.TryParse(txtTHBUnitPrice.Text, out thbUnitPrice);

					txtUSDUnitPrice.Text = $"{(Convert.ToDecimal(txtExchange.Text) == 0.00m ? 0 : (Convert.ToDecimal(txtTHBUnitPrice.Text) / Convert.ToDecimal(txtExchange.Text))):N2}";
					pic.Image = stdPriceItem.ItemImage;
				}
			}
		} // end GetMasterStockItem

		#endregion


		private void txtEffective_TextChanged(object sender, EventArgs e)
		{
			if(txtEffective.Text.IsDate())
			{
				txtExpireDate.Text = Convert.ToDateTime(txtEffective.Text).AddMonths(6).ToShortDateString();
			}
			else
			{
				txtExpireDate.Text = DateTime.Today.AddMonths(6).ToShortDateString();
			}
		}

		private void btnPriceExpireDate_ButtonClick(object sender, EventArgs e)
		{
			btnPriceExpireDate.SelectedDate = string.IsNullOrEmpty(txtExpireDate.Text) ? Convert.ToDateTime(txtEffective.Text).AddMonths(6) : txtExpireDate.Text.Num2Date();
		}

		private void btnPriceExpireDate_DateSelected(object sender, EventArgs e)
		{
			txtExpireDate.Text = btnPriceExpireDate.SelectedDate.ToShortDateString();
		}


		private void txt_TextChanged(object sender, EventArgs e)
		{

			if(!txtTHBUnitPrice.Text.IsNumeric())
			{
				return;
			}

			if(!txtUSDUnitPrice.Text.IsNumeric())
			{
				return;
			}

			NumericTextBox nt = sender as NumericTextBox;
			string code = nt.Tag.ToString();

			switch(code)
			{
				case "EX":
					if(lbEnterFlag.Text == "US")
					{
						try
						{
							decimal exchangeRate = decimal.Parse(txtExchange.Text) == 0.00m ? 1.00m : decimal.Parse(txtExchange.Text);
							if(exchangeRate == 1.00m)
							{
								txtUSDUnitPrice.Text = "0.00";
							}
							else
							{
								txtUSDUnitPrice.Text = $"{(Convert.ToDecimal(txtTHBUnitPrice.Text) / exchangeRate):N2}";
							}
						}
						catch
						{
							txtUSDUnitPrice.Text = "0.00";
						}
					}

					break;
				case "US":
					if(lbEnterFlag.Text == "EX")
					{


						try
						{
							decimal exchangeRate = (decimal.Parse(txtTHBUnitPrice.Text) / (decimal.Parse(txtUSDUnitPrice.Text) == 0.00m ? omglobal.SOURCE_CURRENCY_VALUE : decimal.Parse(txtUSDUnitPrice.Text)));

							txtExchange.Text = $"{exchangeRate:N2}";
						}
						catch
						{
							txtExchange.Text = "0.00";
						}
					}
					break;
			}
		}

		private void txtUSDUnitPrice_Enter(object sender, EventArgs e)
		{
			lbEnterFlag.Text = "EX";
		}

		private void txtExchange_Enter(object sender, EventArgs e)
		{
			lbEnterFlag.Text = "US";
		}

		private void txtTHBUnitPrice_TextChanged(object sender, EventArgs e)
		{
			if(!txtExchange.Text.IsNumeric())
			{
				return;
			}
			if(!txtTHBUnitPrice.Text.IsNumeric())
			{
				return;
			}

			try
			{
				decimal exchangeRate = decimal.Parse(txtExchange.Text);

				if(exchangeRate <= 0.00m)
				{
					exchangeRate = omglobal.SOURCE_CURRENCY_VALUE;
				}

				txtUSDUnitPrice.Text = $"{(decimal.Parse(txtTHBUnitPrice.Text) / exchangeRate):N2}";
			}
			catch { }
		}

	}
}