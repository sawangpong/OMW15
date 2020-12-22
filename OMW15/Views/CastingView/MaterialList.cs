using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView
{
	public partial class MaterialList : Form
	{
		#region class field member

		private readonly string _customerCode = string.Empty;

		#endregion

		// CONSTRUCTOR
		public MaterialList(string CustomerCode)
		{
			InitializeComponent();
			_customerCode = CustomerCode;
		}

		public MaterialList(string CustomerCode, string MaterialCat)
		{
			InitializeComponent();
			_customerCode = CustomerCode;
			MaterialCategory = MaterialCat;
		}


		private void MaterialList_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);
			GetMaterialList(_customerCode, MaterialCategory);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			MaterialId = Convert.ToInt32(dgv["MATERIALID", e.RowIndex].Value);
			MaterialName = dgv["MATERIAL", e.RowIndex].Value.ToString();
			MaterialSI = Convert.ToDecimal(dgv["SI", e.RowIndex].Value);
			SIFactor = Convert.ToDecimal(dgv["FACTOR", e.RowIndex].Value);
			MaterialCategory = dgv["CATEGORY", e.RowIndex].Value.ToString();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		#region class property

		public int MaterialId { get; set; }

		public string MaterialName { get; set; }

		public string MaterialCategory { get; set; }

		public decimal SIFactor { get; set; }

		public decimal MaterialSI { get; set; }

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			btnSelect.Enabled = dgv.Rows.Count > 0;
		} // end UpdateUI

		private void GetMaterialList(string CustomerCode, string Category)
		{
			dgv.SuspendLayout();
			dgv.DataSource = string.IsNullOrEmpty(Category)
				? new MaterialDAL().GetMaterialLisyInfoByCustomer(CustomerCode)
				: new MaterialDAL().GetMaterialLisyInfoByCustomer(CustomerCode, Category);

			dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
			dgv.Columns["MATERIALID"].Visible = false;
			dgv.Columns["MATERIAL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["CATEGORY"].HeaderText = "Material Category";
			dgv.Columns["SI"].HeaderText = "SI %";

			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.ValueType == typeof(decimal))
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgv.ResumeLayout();

			UpdateUI();
		} // end GetMaterialList

		#endregion
	}
}