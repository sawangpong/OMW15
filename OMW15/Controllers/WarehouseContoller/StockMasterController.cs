using System.Windows.Forms;
using OMW15.Shared;
using OMW15.Views.WarehouseView;

namespace OMW15.Controllers.WarehouseContoller
{
	public class StockMasterController
	{
		private readonly ActionMode _mode = ActionMode.None;

		#region class constructor

		public StockMasterController(ActionMode Mode = ActionMode.View)
		{
			_mode = Mode;
			IsEmptyResult = true;

			GetStockItem(_mode);
		}

		#endregion

		#region class helper method

		public void GetStockItem(ActionMode mode)
		{
			var _pl = new Views.Sales.PriceList(ActionMode.Selection);
			_pl.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			_pl.StartPosition = FormStartPosition.CenterScreen;
			if (_pl.ShowDialog() == DialogResult.OK)
			{
				IsEmptyResult = false;
				ItemNo = _pl.ItemNo;
				ItemNameTH = _pl.ItemName;
				ItemNameEN = _pl.ItemName;
				ItemUnit = _pl.Unit;
				THBUnitCost = _pl.THBUnitCost;
				THBUnitPrice = _pl.THBUnitPrice;
				USDUnitPrice = _pl.USDUnitPrice;
			}
			else
			{
				IsEmptyResult = true;
			}
		}

		#endregion

		#region class property

		public bool IsEmptyResult
		{
			get; set;
		}

		public string ItemNo
		{
			get; set;
		}

		public string ItemNameTH
		{
			get; set;
		}

		public string ItemNameEN
		{
			get; set;
		}

		public string ItemUnit
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
	}
}