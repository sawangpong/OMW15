using System;
using System.ComponentModel;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ProductModel;

namespace OMW15.Views.ProductView
{
	public partial class ProductList : Form
	{
		// CONSTRUCTOR
		public ProductList()
		{
			InitializeComponent();
		}

		private void ProductList_Load(object sender, EventArgs e)
		{
			// setting DataGridView
			OMUtils.SettingDataGridView(ref dgv);
			CenterToParent();

			GetProductList();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetProductList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			ModelId = dgv["ModelId", e.RowIndex].Value.ToString();
			ModelName = dgv["Model", e.RowIndex].Value.ToString();

			UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		#region class field member

		#endregion

		#region class property

		[DefaultValue("")]
		public string ModelId { get; set; }

		[DefaultValue("")]
		public string ModelName { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnSelect.Enabled = !string.IsNullOrEmpty(ModelId);
		} // end updateUI

		private void GetProductList()
		{
			dgv.SuspendLayout();
			dgv.DataSource = new ProductDAL().GetProdcutModelList();
			dgv.Columns["ModelId"].Visible = false;
			dgv.Columns["ModelDisplay"].Visible = false;
			dgv.Columns["ModelName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.ColumnHeadersVisible = false;
			dgv.ResumeLayout();

			UpdateUI();
		} // end GetProductList

		#endregion
	}
}