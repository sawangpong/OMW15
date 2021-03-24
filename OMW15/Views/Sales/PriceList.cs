using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.SaleModel;
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class PriceList : Form
	{
		public PriceList(ActionMode viewMode = ActionMode.Selection)
		{
			InitializeComponent();

			_viewMode = viewMode;

			lbMode.Text = _viewMode.ToString();

			OMUtils.SettingDataGridView(ref dgv);

			dgv.BorderStyle = BorderStyle.FixedSingle;

		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void PriceList_Load(object sender, EventArgs e)
		{
			CreateSearchTypeList();
			tsbtnRefresh.PerformClick();
			UpdateUI();
		}

		private void txtFilter_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			SPID = 0;
			ItemNo = string.Empty;
			PriceListItemInfo(SPID, ItemNo);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if(Convert.ToBoolean(dgv["ISACTIVE", e.RowIndex].Value) == true
				&& (_viewMode == ActionMode.Selection || _viewMode == ActionMode.View))
			{
				SPID = Convert.ToInt32(dgv["SPID", e.RowIndex].Value);
				ItemNo = dgv["ITEMID", e.RowIndex].Value.ToString();
				ItemName = dgv["ITEMNAME", e.RowIndex].Value.ToString();
				Unit = dgv["UNIT", e.RowIndex].Value.ToString();
				THBUnitCost = Convert.ToDecimal(dgv["THB_UNITCOST", e.RowIndex].Value);
				THBUnitPrice = Convert.ToDecimal(dgv["THB_UNITPRICE", e.RowIndex].Value);
				USDUnitPrice = Convert.ToDecimal(dgv["USD_UNITPRICE", e.RowIndex].Value);
			}
			else if(Convert.ToBoolean(dgv["ISACTIVE", e.RowIndex].Value) == false
					 && _viewMode == ActionMode.View)
			{
				SPID = Convert.ToInt32(dgv["SPID", e.RowIndex].Value);
				ItemNo = dgv["ITEMID", e.RowIndex].Value.ToString();
				ItemName = string.Empty;
				Unit = string.Empty;
				THBUnitPrice = 0.00m;
				THBUnitCost = 0.00m;
				USDUnitPrice = 0.00m;
			}

			UpdateUI();
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			PriceListItemInfo(SPID, ItemNo);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			// re-loading pricelist
			GetPriceListItems();
		}

		private void cbxSearchType_SelectedIndexChanged(object sender, EventArgs e)
		{
			searchIndex = cbxSearchType.SelectedIndex;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			switch(searchIndex)
			{
				case 0:
					((DataTable)dgv.DataSource).DefaultView.RowFilter = $"ITEMID LIKE '%{txtFilter.Text}%'";
					break;
				case 1:
					((DataTable)dgv.DataSource).DefaultView.RowFilter = $"ITEMNAME LIKE '%{txtFilter.Text}%'";
					break;
				case 2:
					((DataTable)dgv.DataSource).DefaultView.RowFilter = $"FOR_MACHINE LIKE '%{txtFilter.Text}%'";
					break;
			}
		}

		private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
				btnSearch.PerformClick();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			if(_viewMode == ActionMode.Selection)
				btnSelect.PerformClick();
			else
				tsbtnEdit.PerformClick();
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if((bool)dgv["ISACTIVE", e.RowIndex].Value == false)
			{
				e.CellStyle.ForeColor = SystemColors.ControlDark;
			}
		}

		#region class field member

		private readonly ActionMode _viewMode = ActionMode.None;
		private int searchIndex; // 0=By Id, 1=By Name

		#endregion

		#region class property

		public int SPID
		{
			get; set;
		}

		public string ItemNo
		{
			get; set;
		}

		public string ItemName
		{
			get; set;
		}

		public string Unit
		{
			get; set;
		}

		public decimal THBUnitCost
		{
			get; set;
		}

		public decimal THBUnitPrice
		{
			get; set;
		}

		public decimal USDUnitPrice
		{
			get; set;
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			// show / hide selected panel
			pnlSelect.Visible = _viewMode == ActionMode.Selection;
			tsbtnAdd.Visible = !pnlSelect.Visible;
			tsSepAdd.Visible = tsbtnAdd.Visible;
			tsbtnEdit.Visible = tsbtnAdd.Visible;
			tsSepEdit.Visible = tsbtnAdd.Visible;

			// state of search button
			btnSearch.Enabled = !string.IsNullOrEmpty(txtFilter.Text);

			// status of menu buttons
			tsbtnEdit.Enabled = !string.IsNullOrEmpty(ItemNo);
		} // end UpdateUI

		private void CreateSearchTypeList()
		{
			string[] searchType = { "By Item-No.", "By Item name", "Ref. Machine" };
			cbxSearchType.Items.Clear();
			cbxSearchType.Items.AddRange(searchType);

			cbxSearchType.SelectedIndex = 0;

		} // end CreateSearchTypeList

		private async void GetPriceListItems()
		{
			var itemDAL = new SalePriceItemDAL();
			var dt = await itemDAL.GetPriceListItems();

			//
			dgv.SuspendLayout();
			dgv.DataSource = dt;

			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if(dgc.ValueType == typeof(decimal))
				{
					if(dgc.Name != "YMD")
					{
						dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
					}
				}
			}
			// hide columns and header title
			dgv.Columns["SPID"].Visible = false;
			dgv.Columns["ISACTIVE"].Visible = false;
			dgv.Columns["STATUS"].HeaderText = "STATUS";
			dgv.Columns["EFFECTIVE"].HeaderText = "EFFECTIVE";
			dgv.Columns["ITEMID"].HeaderText = "PART-NO.";
			dgv.Columns["ITEMNAME"].HeaderText = "DESCRIPTION";
			dgv.Columns["THB_UNITCOST"].HeaderText = "COST (THB)";
			dgv.Columns["THB_UNITPRICE"].HeaderText = "PRICE (THB)";
			dgv.Columns["USD_UNITPRICE"].HeaderText = "PRICE (USD)";
			dgv.Columns["FOR_MACHINE"].HeaderText = "REF. MACHINE";
			dgv.Columns["FOR_MACHINE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgv.ResumeLayout();

			lbRowCount.Text = $"found {dgv.Rows.Count} item{(dgv.Rows.Count > 1 ? "s" : "")}";

			UpdateUI();

			// incase of filter text is not empty, then filtering as of the filter apply
			if(!string.IsNullOrEmpty(txtFilter.Text))
			{
				btnSearch.PerformClick();
			}

		} // end GetPriceListItems


		private void PriceListItemInfo(int spid, string ItemId)
		{
			using(var plItem = new PriceListItem())
			{
				plItem.StartPosition = FormStartPosition.CenterParent;
				plItem.PriceItemId = ItemId;
				plItem.SPID = spid;

				if(plItem.ShowDialog() == DialogResult.OK)
					tsbtnRefresh.PerformClick();
			}
		} // end PriceListItemInfo

		#endregion
	}
}