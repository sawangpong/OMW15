using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.SaleModel;
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class MasterQTList : Form
	{
		public MasterQTList(OMShareSaleEnum.MasterQuotationListStyle DisplayStyle, string CurrencyCode)
		{
			InitializeComponent();
			_currencyCode = CurrencyCode;
			_displayStyle = DisplayStyle;
		}

		private void MasterQTList_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			tsbtnRefresh.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			switch (_displayStyle)
			{
				case OMShareSaleEnum.MasterQuotationListStyle.QuotationHeader:
					SelectedMasterQuotationId = Convert.ToInt32(dgv["ID", e.RowIndex].Value);

					tslbSelectedId.Text = SelectedMasterQuotationId.ToString();
					break;

				case OMShareSaleEnum.MasterQuotationListStyle.QuotationItem:
					ItemNo = dgv["ITEMNO", e.RowIndex].Value.ToString();
					ItemName = dgv["ITEMNAME", e.RowIndex].Value.ToString();
					ItemInfo = dgv["ITEMINFO", e.RowIndex].Value.ToString();
					Unit = dgv["UNIT", e.RowIndex].Value.ToString();
					CurrencyCode = dgv["CURR", e.RowIndex].Value.ToString();
					Qty = Convert.ToDecimal(dgv["QTY", e.RowIndex].Value);
					UnitPrice = Convert.ToDecimal(dgv["UNITPRICE", e.RowIndex].Value);
					LineTotalValue = Convert.ToDecimal(dgv["LINETOTAL", e.RowIndex].Value);

					break;
			}

			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			SelectedMasterQuotationId = 0;
			GetMasterQuotation(_displayStyle, _currencyCode);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		#region class field member

		private readonly string _currencyCode = string.Empty;
		private readonly OMShareSaleEnum.MasterQuotationListStyle _displayStyle;

		#endregion

		#region class property

		public int SelectedMasterQuotationId { get; set; }

		public string ItemNo { get; set; }

		public string ItemName { get; set; }

		public string ItemInfo { get; set; }

		public string Unit { get; set; }

		public decimal Qty { get; set; }

		public decimal UnitPrice { get; set; }

		public string CurrencyCode { get; set; }

		public decimal LineTotalValue { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnSelect.Enabled = _displayStyle == OMShareSaleEnum.MasterQuotationListStyle.QuotationHeader
				? SelectedMasterQuotationId > 0
				: !string.IsNullOrEmpty(ItemNo);
		} // end UpdateUI

		private void GetMasterQuotation(OMShareSaleEnum.MasterQuotationListStyle DisplayStyle, string CurrencyCode)
		{
			dgv.SuspendLayout();

			switch (DisplayStyle)
			{
				case OMShareSaleEnum.MasterQuotationListStyle.QuotationHeader:
					Text = "MASTER QUOTATION LIST";

					dgv.DataSource = new SaleQTDAL().GetMasterQuotationList(CurrencyCode);

					dgv.Columns["MASTER"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

					break;

				case OMShareSaleEnum.MasterQuotationListStyle.QuotationItem:
					Text = "MASTER QUOTATION ITEM LIST";

					dgv.DataSource = new SaleQTDAL().GetMasterQuotationItem(CurrencyCode);

					dgv.Columns["ITEMINFO"].Visible = false;

					dgv.Columns["QTY"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

					dgv.Columns["UNITPRICE"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

					dgv.Columns["LINETOTAL"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

					break;
			}

			dgv.ResumeLayout();

			UpdateUI();
		} // end GetMasterQuotation

		#endregion
	}
}