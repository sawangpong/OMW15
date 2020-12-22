using OMControls;
using OMW15.Models.ProductionModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class REQISU : Form
	{
		#region class field
		private int _issueYear = DateTime.Today.Year;
		private string _selectedIssueNo = "";
		#endregion

		#region class helper

		private async void GetIssueYear()
		{
			cbxDocYear.SuspendLayout();
			cbxDocYear.DataSource = await new ProductionDAL().GetProductionYearListAsync();
			cbxDocYear.DisplayMember = "YearCode";
			cbxDocYear.ValueMember = "YearCode";
			cbxDocYear.ResumeLayout();
		}

		private void GetIssueItems(string issueNo)
		{
			dgvIssueItems.SuspendLayout();
			DataTable dt = new ProductionDAL().GetIssueItems(issueNo);

			//MessageBox.Show(dt.Rows.Count.ToString());


			if (dt == null)
			{
				dgvIssueItems.DataSource = null;
				return;
			}

			dgvIssueItems.DataSource = dt;

			// formatting DataGridView

			dgvIssueItems.Columns["ISSUELINEID"].Visible = false;
			dgvIssueItems.Columns["ORDERNUMBER"].Visible = false;
			dgvIssueItems.Columns["PROJECTNO"].Visible = false;
			dgvIssueItems.Columns["DOCUMENTKEY"].Visible = false;
			dgvIssueItems.Columns["DOCUMENTNO"].Visible = false;
			dgvIssueItems.Columns["DEPARTMENTID"].Visible = false;
			dgvIssueItems.Columns["DEPARTMENTCODE"].Visible = false;
			dgvIssueItems.Columns["SHIPTOTALVAT"].Visible = false;
			dgvIssueItems.Columns["SHIPGRANDTOTAL"].Visible = false;

			dgvIssueItems.Columns["Index"].HeaderText = "#";
			dgvIssueItems.Columns["SHIPITEMNO"].HeaderText = "Part-No.";
			dgvIssueItems.Columns["SHIPITEMNAME"].HeaderText = "Part Name";
			dgvIssueItems.Columns["SHIPUNIT"].HeaderText = "Unit";
			dgvIssueItems.Columns["SHIPQTY"].HeaderText = "Qty.";
			dgvIssueItems.Columns["SHIPUNITPRICE"].HeaderText = "Unit price";
			dgvIssueItems.Columns["SHIPTOTALVALUE"].HeaderText = "Total values";

			dgvIssueItems.Columns["SHIPQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvIssueItems.Columns["SHIPQTY"].DefaultCellStyle.Format = "N2";

			dgvIssueItems.Columns["SHIPUNITPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvIssueItems.Columns["SHIPUNITPRICE"].DefaultCellStyle.Format = "N2";

			dgvIssueItems.Columns["SHIPTOTALVALUE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvIssueItems.Columns["SHIPTOTALVALUE"].DefaultCellStyle.Format = "N2";

			dgvIssueItems.ResumeLayout();

			//decimal _totalMatCost = 0m;
			//foreach (DataRow dr in dt.Rows)
			//{
			//	_totalMatCost += Convert.ToDecimal(dr["SHIPTOTALVALUE"].ToString());
			//}

			lbIssueItemCount.Text = $"{dgvIssueItems.Rows.Count} รายการ";

		}

		#endregion

		public REQISU()
		{
			InitializeComponent();

			OMUtils.SettingDataGridView(ref dgv);
			OMUtils.SettingDataGridView(ref dgvIssueItems);
		}

		private void REQISU_Load(object sender, EventArgs e)
		{
			GetIssueYear();
		}

		private async void loadData(int year,string[] codemap)
		{
			var _pd = new ProductionDAL();
			dgv.SuspendLayout();
			dgv.DataSource = await _pd.IssueRQAsync(codemap,year);
			dgv.Columns["ReqNo"].HeaderText = "หมายเลขใบขอแปร";
			dgv.Columns["ReqId"].HeaderText = "Id";
			dgv.Columns["IssueNo"].HeaderText = "หมายเลขใบแปร";
			dgv.Columns["IssueId"].HeaderText = "Id";
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();
			lb.Text = $"found issue # {dgv.Rows.Count } รายการ";
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			loadData(_issueYear,OMShareProduction.ProductionRequestCode);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedIssueNo = dgv["IssueNo",e.RowIndex].Value.ToString();

			dgvIssueItems.DataSource = null;
			dgvIssueItems.Rows.Clear();

			btnLoadIssueItems.Text = $"Load [{_selectedIssueNo}]";

		}

		private void cbxDocYear_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_issueYear = Int32.Parse(cbxDocYear.SelectedValue.ToString());
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnLoadIssueItems.PerformClick();
		}

		private void btnLoadIssueItems_Click(object sender, EventArgs e)
		{
			GetIssueItems(_selectedIssueNo);
		}
	}
}
