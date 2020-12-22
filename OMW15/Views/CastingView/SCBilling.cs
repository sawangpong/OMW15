using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class SCBilling : Form
	{
		public SCBilling()
		{
			InitializeComponent();

			CenterToParent();

			// setting datagridview
			OMUtils.SettingDataGridView(ref dgvBL);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void SCBilling_Load(object sender, EventArgs e)
		{


			GetActiveBillingList();

			//tsbtnRefresh.PerformClick();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetActiveBillingList();
		}

		private void dgvBL_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedBLId = Convert.ToInt32(dgvBL["BILLID", e.RowIndex].Value);
			_selectedCustomerCode = dgvBL["CUSTCODE", e.RowIndex].Value.ToString();
			_selectedCustomerName = dgvBL["CUSTNAME", e.RowIndex].Value.ToString();

			UpdateUI();
		}

		private void tsbtnEditBL_Click(object sender, EventArgs e)
		{
			// call
			GetBillingInfo(_selectedCustomerCode, _selectedCustomerName, _selectedBLId);

			// refresh
			GetActiveBillingList();

			//tsbtnRefresh.PerformClick();
		}

		private void tsbtnAddBL_Click(object sender, EventArgs e)
		{
			// call
			GetBillingInfo(_selectedCustomerCode = "", _selectedCustomerName = "", _selectedBLId = 0);

			// refresh
			GetActiveBillingList();

			//tsbtnRefresh.PerformClick();
		}

		private void tsbtnDeleteBL_Click(object sender, EventArgs e)
		{
			// delete selected bill-no

			if (
				MessageBox.Show("Do you want to delete the selected Bill-Number ?", "Delete", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
				if (new BillingDAL().DeleteBill(_selectedBLId) > 0)
					MessageBox.Show("Delete selected bill successfully ", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void dgvBL_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEditBL.PerformClick();
		}

		private void tsbtnPrint_Click(object sender, EventArgs e)
		{
			using (var _vr = new CastingReportView())
			{
				_vr.BillId = _selectedBLId;
				_vr.PrintWhat = PrintDocumentType.BillingSaleOrder;
				_vr.StartPosition = FormStartPosition.CenterScreen;
				_vr.ShowDialog();
			}
		}

		private void tsbtnInvoice_Click(object sender, EventArgs e)
		{
			using (var _bc = new SCCollection(_selectedBLId))
			{
				_bc.StartPosition = FormStartPosition.CenterParent;
				_bc.ShowDialog();
			}

			tsbtnRefresh.PerformClick();
		}

		#region class field member

		private int _selectedBLId;
		private string _selectedCustomerCode = string.Empty;
		private string _selectedCustomerName = string.Empty;

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			tsbtnEditBL.Enabled = _selectedBLId > 0;
			tsbtnDeleteBL.Enabled = tsbtnEditBL.Enabled;
			tsbtnPrint.Enabled = _selectedBLId > 0;
			tsbtnInvoice.Enabled = tsbtnPrint.Enabled;
		} // end UpdateUI

		private void GetActiveBillingList()
		{
			dgvBL.SuspendLayout();
			dgvBL.DataSource = new BillingDAL().GetActiveBL();

			foreach (DataGridViewColumn dgc in dgvBL.Columns)
				if (dgc.ValueType == typeof(decimal)) dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			// formatting Header Text
			dgvBL.Columns["STATUS"].HeaderText = "สถานะ";
			dgvBL.Columns["BILLNO"].HeaderText = "เลขที่";
			dgvBL.Columns["BLDATE"].HeaderText = "วันที่";
			dgvBL.Columns["BLDUE"].HeaderText = "วันครบกำหนด";
			dgvBL.Columns["CUSTNAME"].HeaderText = "ลูกค้า";
			dgvBL.Columns["TOTALVALUE"].HeaderText = "ยอดรวม";
			dgvBL.Columns["DISCOUNT"].HeaderText = "ส่วนลด";
			dgvBL.Columns["NETTOTAL"].HeaderText = "ยอดสุทธิ";
			dgvBL.Columns["TOTALVAT"].HeaderText = "ภาษีมูลค่าเพิ่ม";
			dgvBL.Columns["TOTALAMOUNT"].HeaderText = "ยอดรวมทั้งสิ้น";
			dgvBL.Columns["BILLID"].Visible = false;
			dgvBL.Columns["CUSTCODE"].Visible = false;
			dgvBL.Columns["CUSTNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvBL.ResumeLayout();

			lbCount.Text = $"found : {dgvBL.Rows.Count} record(s)";
			GetTotalAmountSummary();

			UpdateUI();
		} // end GetActiveBillingList

		private void GetTotalAmountSummary()
		{
			lbTotalAmount.Text = string.Format("Total amount : {0:N2}",
				Convert.ToDecimal(((DataTable) dgvBL.DataSource).AsEnumerable().Sum(x => x.Field<decimal>("TOTALAMOUNT"))));
		} // end GetTotalAmountSummary


		private void GetBillingInfo(string CustomerCode, string CustomerName, int BillId)
		{
			using (var _bl = new CastingOrderBilling(CustomerCode, CustomerName, BillId))
			{
				_bl.StartPosition = FormStartPosition.CenterScreen;
				_bl.ShowDialog(this);
			}
		} // end BillingInfo

		#endregion
	}
}