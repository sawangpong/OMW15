using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Products
{
	public partial class ProductList : Form
	{
		#region class field member
		
		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end updateUI

		private void GetProductList()
		{
			using(OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				//var _products = from p in _oldmoon.PRODUCTS
				//				where p.isdelete == false
				//				select p;

				//this.dgv.DataSource = _products.ToList();
			}

		} // end GetProductList

		#endregion


		public ProductList()
		{
			InitializeComponent();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ProductList_Load(object sender, EventArgs e)
		{
			// setting DataGridView
			omglobal.SettingGrid(ref this.dgv);

			this.tsbtnRefresh.PerformClick();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.GetProductList();
		}
	}
}
