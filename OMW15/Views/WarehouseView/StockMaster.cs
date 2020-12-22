using OMControls;
using OMControls.OMView;
using OMW15.Controllers.ToolController;
using OMW15.Models.SaleModel;
using OMW15.Models.WarehouseModel;
using OMW15.Shared;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OMW15.Views.WarehouseView
{
	public partial class StockMaster : Form
	{
		#region Singleton

		public static StockMaster _instance;
		public static StockMaster GetInstance {
			get
			{
				if (_instance == null || _instance.IsDisposed) _instance = new StockMaster();
				return _instance;
			}
		}

		#endregion


		#region class field member

		private int _rowCount;
		//private int _selectedStockCategory = 0;
		private string _selectedSearchTag = "ID";
		private string _setFilter = string.Empty;

		private OMShareSaleEnum.StockFilterType _stockFilterType = OMShareSaleEnum.StockFilterType.None;

		#endregion

		#region class property

		public ActionMode ModeStyle { get; set; }

		public int ItemMasterId { get; set; }

		public string ItemMasterCode { get; set; }

		public string ItemMasterNameTH { get; set; }

		public string ItemMasterNameEN { get; set; }

		public string ItemUnit { get; set; }

		public decimal ItemUnitCostTHB { get; set; }

		public decimal ItemUnitPriceTHB { get; set; }

		public decimal ItemUnitPriceUSD { get; set; }

		public Image ItemImage { get; set; }

		#endregion

		public StockMaster(ActionMode Mode = ActionMode.View,
			OMShareWarehouseEnums.StockAppCall App = OMShareWarehouseEnums.StockAppCall.StockMaster
		)
		{
			InitializeComponent();

			// setting datagridview
			OMUtils.SettingDataGridView(ref dgv);

			if (Mode == ActionMode.View)
			{
				WindowState = FormWindowState.Maximized;
			}
			else
			{
				WindowState = FormWindowState.Normal;
			}

			ModeStyle = Mode;
			tslbAppCall.Text = App.ToString();
			Text = App.ToString();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void StockMaster_Load(object sender, EventArgs e)
		{
			_setFilter = string.Empty;
			UpdateUI();
		}

		private void tsmnuSearchChild_Click(object sender, EventArgs e)
		{
			var _mnu = sender as ToolStripMenuItem;
			_selectedSearchTag = _mnu.Tag.ToString().ToUpper();

			if (_selectedSearchTag == "ALL")
			{
				_stockFilterType = OMShareSaleEnum.StockFilterType.AllItems;
				GetStockMasterListAsync(_stockFilterType, "");
			}
			else
			{
				switch (_selectedSearchTag)
				{
					case "ID":
						_stockFilterType = OMShareSaleEnum.StockFilterType.ByItemNo;
						break;

					case "NAME":
						_stockFilterType = OMShareSaleEnum.StockFilterType.ByItemName;
						break;
				}

				_setFilter = GetFilter(_stockFilterType);
				if (!string.IsNullOrEmpty(_setFilter))
				{
					GetStockMasterListAsync(_stockFilterType, _setFilter);
				}
			}

			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetStockMasterListAsync(_stockFilterType, _setFilter);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_rowCount == dgv.Rows.Count)
			{
				this.ItemMasterId = Convert.ToInt32(dgv["ID", e.RowIndex].Value);
				this.ItemMasterCode = dgv["ITEMNO", e.RowIndex].Value.ToString();
				this.ItemMasterNameTH = dgv["ITEMNAMETH", e.RowIndex].Value.ToString();
				this.ItemUnit = dgv["UNIT", e.RowIndex].Value.ToString();
				this.ItemUnitCostTHB = Convert.ToDecimal(dgv["UNITCOST_THB", e.RowIndex].Value);

				//pic1.Image = ItemImage = new WHDDAL().getItemMasterImage(ItemMasterCode);
			}
			tsslbId.Text = $"Id:{this.ItemMasterId}";

			getItemMasterImage(this.ItemMasterCode);

			UpdateUI();
		}

		private async void getItemMasterImage(string itemno)
		{
			var _wh = new WHDDAL();
			pic1.Image = ItemImage = (await _wh.getItemMasterImageAsync(itemno));
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			//if (Convert.ToDecimal(this.dgv["P_R", e.RowIndex].Value) < 0.5m)
			//{
			//	e.CellStyle.BackColor = Color.Red;
			//	e.CellStyle.ForeColor = Color.Yellow;
			//}
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			if (ModeStyle == ActionMode.Selection)
			{
				btnSelect.PerformClick();
			}
		}

		private void btnUpdatePicture_Click(object sender, EventArgs e)
		{
			using (
				var _mi = new MasterImageItem(ItemMasterId, ItemMasterCode,
					string.IsNullOrEmpty(ItemMasterNameEN) ? ItemMasterNameTH : ItemMasterNameEN, pic1.Image))
			{
				_mi.StartPosition = FormStartPosition.CenterScreen;
				if (_mi.ShowDialog(this) == DialogResult.OK)
					tsbtnRefresh.PerformClick();
			}
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
		}

		#region class helper method

		private void UpdateUI()
		{
			pnlCommand.Visible = ModeStyle == ActionMode.Selection;
			tsbtnClose.Visible = !pnlCommand.Visible;
			btnUpdatePicture.Enabled = (dgv.Rows.Count > 0 && ItemMasterId > 0);

		} // end UpdateUI


		private string GetFilter(OMShareSaleEnum.StockFilterType FilterType)
		{
			// get the filter text as of the selection the search menu
			// only for by part-no or part-name
			var _filter = string.Empty;
			var _ipb =
				new InputBox(FilterType == OMShareSaleEnum.StockFilterType.ByItemNo ? "Item No." : "Item Name or Description",
					InputTypeValue.Text);
			_ipb.StartPosition = FormStartPosition.CenterScreen;

			if (_ipb.ShowDialog(this) == DialogResult.OK)
			{
				_filter = _ipb.DefaultValue.ToUpper();
			}
			else
			{
				_filter = string.Empty;
			}

			return _filter;

		} // end GetFilter

		private async void GetStockMasterListAsync(OMShareSaleEnum.StockFilterType FilterType, string Filter)
		{
			var _stock = new StockDAL();
			var dt = await _stock.GetMasterItemsAsync(FilterType, Filter);
			_rowCount = dt.Rows.Count;

			dgv.SuspendLayout();
			dgv.DataSource = dt;

			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if (dgc.ValueType == typeof(decimal) || dgc.ValueType == typeof(int))
				{
					if (dgc.Name == "P_R")
					{
						dgc.DefaultCellStyle = DataGridViewSettingStyle.PercentCellStyle();
					}
					else
					{
						dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
					}
				}
			}
			dgv.Columns["ID"].Visible = false;
			dgv.Columns["CATID"].Visible = false;

			dgv.ResumeLayout();

			// display item found
			stbCount.Text = $"{dgv.Rows.Count} record(s)";

			UpdateUI();
		} // end GetStockMasterList

		#endregion
	}
}