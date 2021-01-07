using OMW15.Shared;
using OMW15.Views.ProductView;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Sales
{
	public partial class SaleWorks : Form
	{
		#region Singleton

		private static SaleWorks _instance;
		public static SaleWorks GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new SaleWorks();
				}
				return _instance;
			}
		}

		#endregion


		public SaleWorks()
		{
			InitializeComponent();
		}

		#region class helper Methods

		private void UpdateUI()
		{
		} // end UpdateUI

		#endregion

		private void mnuClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnSaleContact_Click(object sender, EventArgs e)
		{
			mnuSaleContact.PerformClick();
		}

		private void tsbtnQT_Click(object sender, EventArgs e)
		{
			mnuQT.PerformClick();
		}

		private void mnuSaleContact_Click(object sender, EventArgs e)
		{
			var _contact = new SaleContact(ActionMode.Recording);
			_contact.WindowState = FormWindowState.Maximized;
			_contact.MdiParent = this;
			_contact.Show();
		}

		private void mnuSalePerson_Click(object sender, EventArgs e)
		{
			var _sale = new SaleMan();
			_sale.StartPosition = FormStartPosition.CenterScreen;
			_sale.MdiParent = this;
			_sale.Show();
		}

		private void mnuQT_Click(object sender, EventArgs e)
		{
			var _qt = new Quotations();
			_qt.WindowState = FormWindowState.Maximized;
			_qt.MdiParent = this;
			_qt.Show();
		}

		private void mnuPI_Click(object sender, EventArgs e)
		{
			var _proforma = new SaleProformaList();
			_proforma.MdiParent = this;
			_proforma.Show();
		}

		private void mnuMachinePriceList_Click(object sender, EventArgs e)
		{
			//Views.WarehouseView.StockMaster _pricelist = new Views.WarehouseView.StockMaster(ActionMode.View, OMShareWarehouseEnums.StockAppCall.PriceList);
			//_pricelist.StartPosition = FormStartPosition.CenterScreen;
			//_pricelist.MdiParent = this;
			//_pricelist.Show();

			//
			var pl = new PriceList(ActionMode.View);
			pl.StartPosition = FormStartPosition.CenterScreen;
			pl.MdiParent = this;
			pl.Show();
		}

		private void mnuProductList_Click(object sender, EventArgs e)
		{
			Views.ProductView.MCModelList _productList = new MCModelList();
			_productList.StartPosition = FormStartPosition.CenterScreen;
			_productList.MdiParent = this;
			_productList.Show();
		}

		private void mnuHorizontalWindows_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void mnuVerticalWindows_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void mnuCascadeWindows_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void tsbtnPriceList_Click(object sender, EventArgs e)
		{
			mnuMachinePriceList.PerformClick();
		}

		private void mnuSTDPriceList_Click(object sender, EventArgs e)
		{
			STDPriceList stdpl = new STDPriceList();
			stdpl.MdiParent = this;
			stdpl.StartPosition = FormStartPosition.CenterParent;
			stdpl.Show();
		}

		private void SaleWorks_Load(object sender, EventArgs e)
		{

		}

		private void tsMCRecord_Click(object sender, EventArgs e)
		{
			Views.ServiceView.MCInfo mc = new ServiceView.MCInfo();
			mc.StartPosition = FormStartPosition.CenterParent;
			mc.MdiParent = this;
			mc.Show();
		}

		private void mnuSaleMachines_Click(object sender, EventArgs e)
		{
			var saleMachine = SaleMachine.GetInstance;
			saleMachine.MdiParent = this;
			saleMachine.StartPosition = FormStartPosition.CenterScreen;
			saleMachine.Show();
		}

		private void mnuSaleSummary_Click(object sender, EventArgs e)
		{
			var saleSummary = SaleSummary.GetInstance;
			saleSummary.Title = mnuSaleSummary.Text;
			saleSummary.MdiParent = this;
			saleSummary.StartPosition = FormStartPosition.CenterScreen;
			saleSummary.Show();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			mnuSaleHistory.PerformClick();
		}

		private void mnuSaleHistory_Click(object sender, EventArgs e)
		{
			//
			//
			//
			//

		}
	}
}