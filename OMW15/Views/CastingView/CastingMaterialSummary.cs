using OMControls;
using OMW15.Controllers.CastingController;
using OMW15.Models.CastingModel;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingMaterialSummary : Form
	{
		#region Singleton
		private static CastingMaterialSummary _instance;
		public static CastingMaterialSummary GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new CastingMaterialSummary();
				}
				return _instance;
			}
		}
		#endregion

		// CONSTRUCTOR
		public CastingMaterialSummary()
		{
			InitializeComponent();

			// setting datagridview
			OMUtils.SettingDataGridView(ref dgv);
			OMUtils.SettingDataGridView(ref dgvListSO);

		}

		private void CastingMaterialSummary_Load(object sender, EventArgs e)
		{

			// loading material category list (combobox)
			GetMaterialCategory();

			UpdateUI();
		}

		private void cbxMaterialCAT_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_selectedMaterialCategory = cbxMaterialCAT.SelectedValue.ToString();
			UpdateUI();
			btnRefresh.PerformClick();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dgv_Resize(object sender, EventArgs e)
		{
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			CreatePivotForMaterialSummaryByMaterialCategort(_selectedMaterialCategory);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (!string.IsNullOrEmpty(dgv["CUSTCODE", e.RowIndex].Value.ToString()))
			{
				lbCustCode.Text = dgv["CUSTCODE", e.RowIndex].Value.ToString();
				lbCustomerName.Text = dgv["CUSTOMER", e.RowIndex].Value.ToString();
				_totalWeightForSelectedCustomer = Convert.ToDecimal(dgv["TOTAL", e.RowIndex].Value);

				lbTotalWeightForSelectedCustomer.Text =
					$"Pending weight for Customer : {lbCustomerName.Text} =  {_totalWeightForSelectedCustomer:N2} (g)";

				GetPendingReturnMaterialList(lbCustCode.Text, _selectedMaterialCategory);
			}
			else
			{
				lbCustomerName.Text = "";
				lbCustCode.Text = "";
				if (dgvListSO.Rows.Count > 0) dgvListSO.DataSource = null;
			}

			UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnReceiveMat.PerformClick();
		}

		private void btnReceiveMat_Click(object sender, EventArgs e)
		{
			using (var _matReceive = new MaterialClearing(lbCustCode.Text, lbCustomerName.Text))
			{
				_matReceive.MaterialCategory = _selectedMaterialCategory;
				_matReceive.TotalPendingWeight = _totalWeightForSelectedCustomer;
				_matReceive.StartPosition = FormStartPosition.CenterScreen;
				_matReceive.ShowDialog(this);
			}
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			using (var _report = new CastingWebReport((DataTable)dgv.DataSource, _selectedMaterialCategory))
			{
				_report.StartPosition = FormStartPosition.CenterScreen;
				_report.ShowDialog(this);
			}
		}

		private void btnDeliverySummary_Click(object sender, EventArgs e)
		{
			var _issueMat = new MaterialDeliveryController();
			_issueMat.ViewDeliveryMaterialSummary(_selectedMaterialCategory);
		}

		private void btnMatCard_Click(object sender, EventArgs e)
		{
		}

		#region class field member

		private string _selectedMaterialCategory = string.Empty;
		private decimal _totalWeightForSelectedCustomer;

		#endregion

		#region class properties

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnRefresh.Enabled = !string.IsNullOrEmpty(_selectedMaterialCategory);
			btnDeliverySummary.Enabled = btnRefresh.Enabled;
			btnReceiveMat.Enabled = dgv.RowCount > 0
									&& string.IsNullOrEmpty(lbCustCode.Text) == false;
			btnPrint.Enabled = btnReceiveMat.Enabled;
			btnMatCard.Enabled = btnDeliverySummary.Enabled;
		} // end UpdateUI


		private void GetMaterialCategory()
		{
			cbxMaterialCAT.DataSource = new MaterialDAL().GetMaterialCategory();
			cbxMaterialCAT.DisplayMember = "CATEGORY";
			cbxMaterialCAT.ValueMember = "CATEGORY";
		} // end GetMaterialCategory

		private async void CreatePivotForMaterialSummaryByMaterialCategort(string Category)
		{
			dgv.DataSource = null;

			var _dal = new CastingSaleOrderDAL();

			var dt = await _dal.GetAsyncMaterialSummaryForCastingSaleOrder(Category);

			dgv.SuspendLayout();
			dgv.DataSource = dt;
			dgv.Columns["CUSTCODE"].Visible = false;
			dgv.Columns["TOTAL"].HeaderText = "Total Weight (กรัม)";

			OMUtils.SetDataGridViewColumnsForNumberFormat(ref dgv);

			dgv.Columns["CUSTOMER"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["TOTAL"].Frozen = true;

			dgv.ResumeLayout();

			// display total pending
			GetTotalPendingWeight();
		} // end CreatePivotForMaterialSummaryByMaterialCategort

		private void GetTotalPendingWeight()
		{
			foreach (DataGridViewRow dgr in dgv.Rows)
			{
				if (dgr.Cells["Customer"].Value.ToString() == "Total Weight")
				{
					lbTotalPendingWT.Text = $"Total weight (g) : {dgr.Cells["Total"].Value:N2}";
				}
			}
		} // end GetTotalPendingWeight

		private void GetPendingReturnMaterialList(string CustomerCode, string MaterialCategory)
		{
			var _dt = new CastingSaleOrderDAL().GetPendingReturnMaterialByCustomer(CustomerCode, MaterialCategory);
			var _totalWeight = 0.00m;

			if (_dt.Rows.Count > 0)
			{
				_totalWeight = _dt.AsEnumerable().ToList().Sum(x => x.Field<decimal>("DELIVERWEIGHT"));
			}

			lbMatSum.Text = $"Total Weight (g) = {_totalWeight:N2}";

			dgvListSO.SuspendLayout();

			if (_dt.Rows.Count > 0)
			{
				dgvListSO.DataSource = _dt;
				OMUtils.SetDataGridViewColumnsForNumberFormat(ref dgvListSO);
				dgvListSO.Columns["SOSEQ"].Visible = false;
				dgvListSO.Columns["SONO"].HeaderText = "เลขที่ใบส่งของ";
				dgvListSO.Columns["ORDERDATE"].HeaderText = "วันที่ส่งของ";
				dgvListSO.Columns["THKEYNAME"].HeaderText = "ประเภทวัสดุ";
				dgvListSO.Columns["DELIVERWEIGHT"].HeaderText = "ส่งวัสดุ (กรัม)";
				dgvListSO.Columns["RECEIVEWEIGHT"].HeaderText = "คืนวัสดุ (กรัม)";
				dgvListSO.Columns["OUTSTANDWEIGHT"].HeaderText = "คงเหลือ (กรัม)";
				dgvListSO.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			}
			else
			{
				dgvListSO.DataSource = null;
			}

			dgvListSO.ResumeLayout();
		} // end GetPendingReturnMaterialList

		#endregion
	}
}