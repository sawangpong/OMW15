using OMW15.Models.ProductionModel;
using System;
using System.Data;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class ProductionFormulaBox : Form
	{
		#region field
		private DataTable _dtFormula;
		private int _selectedFormulaKey = 0;
		#endregion

		#region Properties
		public int FormulaKey { get; set; }
		public string FormulaName { get; set; }
		#endregion


		#region Methods

		private void UpdateUI()
		{
			btnSelect.Enabled = (_selectedFormulaKey > 0 && dgv.Rows.Count > 0);
		}

		private void GetFormulaList()
		{
			_dtFormula = new BOMDal().GetProductionFormulaList();
			lbCount.Text = $"{_dtFormula.Rows.Count}";
		}

		private void ShowFormulaHeader(string filter)
		{
			string _filter = $"FORMULA_ID LIKE '%{filter}%' ";
			_dtFormula.DefaultView.RowFilter = _filter;
			lbCount.Text = $"{_dtFormula.Rows.Count}";

			dgv.SuspendLayout();
			dgv.DataSource = _dtFormula;
			dgv.Columns["DI_KEY"].Visible = false;

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();

			UpdateUI();
		}


		#endregion



		public ProductionFormulaBox(string formulaFilter)
		{
			InitializeComponent();
			OMControls.OMUtils.SettingDataGridView(ref dgv);

			GetFormulaList();

			txtFildFormula.Text = formulaFilter;

			if (!String.IsNullOrEmpty(formulaFilter)) ShowFormulaHeader(formulaFilter);

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ProductionFormulaBox_Load(object sender, EventArgs e)
		{

		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedFormulaKey = Convert.ToInt32(dgv["DI_KEY", e.RowIndex].Value.ToString());
			this.FormulaKey = _selectedFormulaKey;
			this.FormulaName = dgv["FORMULA_ID", e.RowIndex].Value.ToString();

			UpdateUI();

		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void txtFildFormula_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter) btnSearch.PerformClick();
		}

		private void btnSearch_Click(object sender, EventArgs e) => ShowFormulaHeader(txtFildFormula.Text);

	}
}
