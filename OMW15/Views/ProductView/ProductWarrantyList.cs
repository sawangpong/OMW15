using System;
using System.ComponentModel;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ProductModel;

namespace OMW15.Views.ProductView
{
	public partial class ProductWarrantyList : Form
	{
		public ProductWarrantyList()
		{
			InitializeComponent();
		}

		private void ProductWarrantyList_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			GetWarrantyList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			WarrantyId = Convert.ToInt32(dgv["WARRANTYID", e.RowIndex].Value);
			WarrantyMonthFactor = Convert.ToInt32(dgv["WARRANTYMONTHFACTOR", e.RowIndex].Value);
			WarrantyTerm = dgv["WARRANTYNAME", e.RowIndex].Value.ToString();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		#region class field member

		#endregion

		#region class property

		[DefaultValue(0)]
		public int WarrantyId { get; set; }

		[DefaultValue(0)]
		public int WarrantyMonthFactor { get; set; }

		[DefaultValue("")]
		public string WarrantyTerm { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnSelect.Enabled = WarrantyId > 0;
		} // end UpdateUI

		private void GetWarrantyList()
		{
			dgv.SuspendLayout();
			dgv.DataSource = new ProductDAL().GetWarrantyTermList();
			dgv.Columns["WARRANTYID"].Visible = false;
			dgv.Columns["RVMAX"].Visible = false;
			dgv.Columns["WARRANTYMONTHFACTOR"].Visible = false;
			//			this.dgv.Columns["WARRANTYID"].Visible = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ColumnHeadersVisible = false;

			dgv.ResumeLayout();
		} // end GetWarrantyList

		#endregion
	}
}