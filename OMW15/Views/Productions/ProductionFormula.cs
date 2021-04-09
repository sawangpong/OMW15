using OMControls;
using OMW15.Models.ProductionModel;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class ProductionFormula : Form
	{
		#region Call DLL

		[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
		private extern static void ReleaseCapture();

		[DllImport("user32.DLL", EntryPoint = "SendMessage")]
		private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

		#endregion

		#region Singleton
		private static ProductionFormula _instance;
		public static ProductionFormula GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new ProductionFormula();
				}
				return _instance;
			}
		}
		#endregion

		#region field
		private DataTable _dtFormulaHeaderList;
		private int _selectedFormulaId = 0;

		#endregion

		#region methods

		private void GetFormularList()
		{
			string filter = $"FORMULA_ID LIKE '%{txtFormulaFilter.Text}%' ";
			
			//OR PARTNO LIKE '%{txtFormulaFilter.Text}%' OR PART_NAME LIKE '%{txtFormulaFilter.Text}%' ";

			_dtFormulaHeaderList.DefaultView.RowFilter = filter;

			dgvFormula.SuspendLayout();
			dgvFormula.DataSource = _dtFormulaHeaderList;

			dgvFormula.Columns["DI_KEY"].Visible = false;
			//dgvFormula.Columns["CREATE_DATE"].Visible = false;
			//dgvFormula.Columns["UNIT"].Visible = false;
			//dgvFormula.Columns["IC_CATE"].Visible = false;
			//dgvFormula.Columns["TRD_TO_WL"].Visible = false;
			//dgvFormula.Columns["UNIT_COST"].Visible = false;
			//dgvFormula.Columns["TOTAL_LINE_COST"].Visible = false;

			dgvFormula.ResumeLayout();

		}

		private void GetBOMItems(int formulaId, decimal rqQty = 0m)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new BOMDal().GetProductionFormulaItemDetails(formulaId, rqQty);

			dgv.Columns["DI_KEY"].Visible = false;
			dgv.Columns["TRH_KEY"].Visible = false;
			dgv.Columns["TRD_KEY"].Visible = false;
			dgv.Columns["SKU_KEY"].Visible = false;
			dgv.Columns["SKU_S_UTQ"].Visible = false;

			//dgv.Columns["SKU_CODE"].HeaderText = "Part-No.";
			//dgv.Columns["SKU_NAME"].HeaderText = "Part-Name";
			//dgv.Columns["UTQ_NAME"].HeaderText = "Stock Unit";

			dgv.Columns["UNIT_PRICE"].HeaderText = "Unit Price";
			dgv.Columns["UNIT_PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["UNIT_PRICE"].DefaultCellStyle.Format = "N2";

			dgv.Columns["BOM_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["BOM_QTY"].DefaultCellStyle.Format = "N2";

			dgv.Columns["DEMAND_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["DEMAND_QTY"].DefaultCellStyle.Format = "N2";

			dgv.Columns["ON_HAND"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["ON_HAND"].DefaultCellStyle.Format = "N2";

			dgv.Columns["AVAILABLE_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["AVAILABLE_QTY"].DefaultCellStyle.Format = "N2";


			dgv.ResumeLayout();

			tsblbItemCount.Text = $"found: {dgv.Rows.Count} item{(dgv.Rows.Count > 1 ? "s" : "")}";
		}


		#endregion

		public ProductionFormula()
		{
			InitializeComponent();

			OMUtils.SettingDataGridView(ref dgvFormula);
			dgvFormula.BorderStyle = BorderStyle.None;

			OMUtils.SettingDataGridView(ref dgv);
			dgv.BorderStyle = BorderStyle.None;

			_dtFormulaHeaderList = new BOMDal().GetProductionFormulaList();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnMinWindow_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void btnMaxWindow_Click(object sender, EventArgs e)
		{
			this.WindowState = (this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal);
		}

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(this.Handle, 0x112, 0xf012, 0);
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			GetFormularList();
		}

		private void txtFormularFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				GetFormularList();
			}
		}

		private void dgvFormular_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedFormulaId = Convert.ToInt32(dgvFormula["DI_KEY", e.RowIndex].Value.ToString());
			lbFormulaTitle.Text = $"{dgvFormula["FORMULA_ID", e.RowIndex].Value.ToString()} #({_selectedFormulaId})";
		}

		private void txtProductionQty_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				GetBOMItems(_selectedFormulaId, Convert.ToDecimal(txtProductionQty.Text));
			}
		}

		private void txtProductionQty_TextChanged(object sender, EventArgs e)
		{
			txtProductionQty.Text = (String.IsNullOrEmpty(txtProductionQty.Text) ? "0" : txtProductionQty.Text);
		}

		private void btnCalBOM_Click(object sender, EventArgs e)
		{
			GetBOMItems(_selectedFormulaId, Convert.ToDecimal(txtProductionQty.Text));
		}
	}
}
