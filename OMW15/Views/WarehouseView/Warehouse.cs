using OMW15.Models.WarehouseModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Windows.Forms;

namespace OMW15.Views.WarehouseView
{
	public partial class Warehouse : Form
	{
		#region Singleton
		public static Warehouse _instance;
		public static Warehouse GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new Warehouse();
				}
				return _instance;
			}
		}

		#endregion

		#region class field member

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
		} // end Update UI


		private void GetStockMaster()
		{
		} // end GetStockMaster

		#region Warehouse Menu Items

		private void setupWarehouseMenus()
		{
			// menu level structure declaration 
			// ---Main menu (Warehouse)							--- Level [0]
			//             |
			// 	           ----Document Type					--- Level [1]
			//                  |
			//                  -----DocumentTypeByDepartment	--- Level [2]
			//
			// ---------------------------------------------------------------

			mnuFile.DropDownItems.Add(new ToolStripSeparator());

			var _currentCode = string.Empty;

			foreach (var _s in omglobal.WH_SUB_ITEM)
			{
				ToolStripMenuItem _subMenu;
				if (string.IsNullOrWhiteSpace(_currentCode))
				{
					_subMenu = getWHSubMenus(1, _s, ref mnuFile);

					// call for menu item level-2
					getWHSubMenus(2, _s, ref _subMenu);
				}
				else
				{
					if (_currentCode.Substring(0, 1) == _s.Substring(0, 1))
					{
						_subMenu = getWHSubMenus(1, _s, ref mnuFile);

						// call for menu item level-2
						getWHSubMenus(2, _s, ref _subMenu);
					}
					else
					{
						mnuFile.DropDownItems.Add(new ToolStripSeparator());
						_subMenu = getWHSubMenus(1, _s, ref mnuFile);

						// call for menu item level-2
						getWHSubMenus(2, _s, ref _subMenu);
					}
				}
				_currentCode = _s;
			}
		} // end SetupWarehouseMenus

		private ToolStripMenuItem getWHSubMenus(int Level, string Prefix, ref ToolStripMenuItem Master)
		{
			var _wh = new WHDDAL();
			var dtIssue = _wh.getIssueDocumentType(Prefix, Level);
			var _mnu = new ToolStripMenuItem();
			foreach (DataRow dr in dtIssue.Rows)
			{
				_mnu = new ToolStripMenuItem(dr["DOCNAME"].ToString());
				_mnu.Tag = dr["KEY"].ToString();
				if (Level == 2) _mnu.Click += mnuWHSubItem_Click;
				Master.DropDownItems.Add(_mnu);
			}
			return _mnu;

		} // end GetWHSubMenus

		private void mnuWHSubItem_Click(object sender, EventArgs e)
		{
			var subMnu = sender as ToolStripMenuItem;
			var _documentKey = Convert.ToInt32(subMnu.Tag.ToString());
			var _issue = new SPIssueList(_documentKey);
			_issue.SelectedTitle = subMnu.Text;
			_issue.StartPosition = FormStartPosition.CenterScreen;
			_issue.MdiParent = this;
			_issue.Show();
		}

		#endregion

		#endregion

		public Warehouse()
		{
			InitializeComponent();

			setupWarehouseMenus();
		}

		private void mnuStockMaster_Click(object sender, EventArgs e)
		{
			//var _stockMaster = new StockMaster(ActionMode.View);
			var _stockMaster = StockMaster.GetInstance;
			_stockMaster.MdiParent = this;
			_stockMaster.Show();
		}

		private void tsbtnStockMaster_Click(object sender, EventArgs e)
		{
			mnuStockMaster.PerformClick();
		}

		private void Warehouse_Load(object sender, EventArgs e)
		{
		}

		private void mnuClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void mnuStockMonitor_Click(object sender, EventArgs e)
		{
			var _whm = WHMonitor.GetInstance;
			_whm.StartPosition = FormStartPosition.CenterParent;
			_whm.MdiParent = this;
			_whm.Show();
		}

		private void tsbtnStockMonitor_Click(object sender, EventArgs e)
		{
			mnuStockMonitor.PerformClick();
		}

		private void mnuCascade_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void mnuVertical_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void mnuHorizontal_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void mnuIssueFOCParts_Click(object sender, EventArgs e)
		{
			var foc = new FOCIssueParts();
			foc.StartPosition = FormStartPosition.CenterParent;
			foc.Show();
		}


	}
}