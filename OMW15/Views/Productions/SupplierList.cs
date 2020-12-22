using OMControls;
using System;
using System.Windows.Forms;
using OMW15.Models.ProductionModel;

namespace OMW15.Views.Productions
{
	public partial class SupplierList : Form
	{
		private string _filter = "";
		public SupplierModel Supplier { get; set; }


		#region class helper

		private void UpdateUI()
		{

		}

		private void DisplaySupplierList(string filter)
		{
			dgv.SuspendLayout();

			dgv.DataSource = new SupplierDAL().GetSupplierList(filter);

			dgv.Columns["AP_KEY"].Visible = false;
			dgv.Columns["AP_APCAT"].Visible = false;

			dgv.Columns["AP_CODE"].HeaderText = "รหัส";
			dgv.Columns["AP_NAME"].HeaderText = "ชื่อ";
			dgv.Columns["AP_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgv.ResumeLayout();
		}

		#endregion

		public SupplierList(string filter = "")
		{
			InitializeComponent();
			_filter = filter;
			txtSearch.Text = _filter;
			OMUtils.SettingDataGridView(ref dgv);

		}

		private void SupplierList_Load(object sender, EventArgs e)
		{

			DisplaySupplierList(_filter);

		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{

			SupplierModel _sup = new SupplierModel
			{
				AP_KEY = Int32.Parse(dgv["AP_KEY", e.RowIndex].Value.ToString()),
				AP_CODE = dgv["AP_CODE", e.RowIndex].Value.ToString(),
				AP_NAME = dgv["AP_NAME", e.RowIndex].Value.ToString(),
				AP_APCAT = dgv["AP_APCAT", e.RowIndex].Value.ToString(),
			};

			this.Supplier = _sup;

		}

		private void btnSearchSup_Click(object sender, EventArgs e)
		{
			DisplaySupplierList(txtSearch.Text);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
			{
				btnSearchSup.PerformClick();
			}
		}
	}

	public class SupplierModel
	{
		public int AP_KEY { get; set; }
		public string AP_CODE { get; set; }
		public string AP_NAME { get; set; }
		public string AP_APCAT { get; set; }
	}

}
