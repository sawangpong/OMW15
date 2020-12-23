using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Controllers.WarehouseContoller;
using OMW15.Models.WarehouseModel;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.WarehouseView
{
	public partial class WHStockCard : Form
	{
		#region class field

		private readonly string _itemNo;

		#endregion

		// CONSTRUCTOR 
		public WHStockCard(string ItemNo = "")
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgv);

			_itemNo = ItemNo;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void WHStockCard_Load(object sender, EventArgs e)
		{
			btnReload.PerformClick();
		}

		private void btnReload_Click(object sender, EventArgs e)
		{
			GetStockMoveInfo(_itemNo);
		}

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			txtItemNo.ReadOnly = String.IsNullOrEmpty(_itemNo);
			btnItemNoSearch.Enabled = !txtItemNo.ReadOnly;
		} // end UpdateUI

		private async void GetStockMoveInfo(string itemNo)
		{
			var _stock = new WHDDAL();
			var _dt = await _stock.getStockOnhandMovingInfoByItemId(itemNo);

			// calculated Stock-Onhand for each giving itemId
			CalculateStockOnhand(_dt);

			// call the stock-card data source
			CreateStockCard(_dt);
		} // end GetStockMoveInfo


		private void CreateStockCard(DataTable Source)
		{
			var _scd = new StockCards();
			StockCardItem _sci;
			var _balance = 0.00m;

			foreach (DataRow dr in Source.Rows)
			{
				_sci = new StockCardItem();
				_sci.Id = Convert.ToInt32(dr["ID"]);
				_sci.DocumentNo = dr["DI_REF"].ToString();
				_sci.DocumentDate = Convert.ToDateTime(dr["DI_DATE"]);
				_sci.ItemNo = dr["ITEMNO"].ToString();
				_sci.ItemName = dr["ITEMNAME"].ToString();
				_sci.ItemUOM = dr["UNIT"].ToString();
				_sci.UnitCost = Convert.ToDecimal(dr["UNIT_COST"]);
				_sci.ReceiveQty = Convert.ToDecimal(dr["ONHAND"]) >= 0.00m ? Convert.ToDecimal(dr["ONHAND"]) : 0.00m;
				_sci.IssueQty = Convert.ToDecimal(dr["ONHAND"]) < 0.00m ? Convert.ToDecimal(dr["ONHAND"]) : 0.00m;
				_sci.BalanceQty = _balance + _sci.ReceiveQty + _sci.IssueQty;
				_balance = _sci.BalanceQty;

				_scd.Add(_sci);
			}
			lbRowCount.Text = string.Format("found : {0} รายการ", _scd.Count);

			dgv.SuspendLayout();
			dgv.DataSource = _scd.ToList();
			dgv.Columns["BALANCEQTY"].DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Bold);

			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.ValueType == typeof(decimal)) dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			// hide column
			dgv.Columns["ID"].Visible = false;
			dgv.Columns["ITEMNO"].Visible = false;
			dgv.Columns["ITEMNAME"].Visible = false;
			dgv.ResumeLayout();
		} // end CreateStockCard


		private void CalculateStockOnhand(DataTable Stock)
		{
			var _onhand = 0.00m;
			Stock.AsEnumerable().ToList().ForEach(c =>
			{
				txtItemNo.Text = c.Field<string>("ITEMNO");
				txtItemName.Text = c.Field<string>("ITEMNAME");
				txtUOM.Text = c.Field<string>("UNIT");
				_onhand += c.Field<decimal>("ONHAND");
			});

			txtOnHand.Text = string.Format("{0:N2}", _onhand);
		} // end CalculateStockOnhand

		#endregion
	}
}