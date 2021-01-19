using OMControls;
using OMW15.Models.ServiceModel;
using OMW15.Shared;
using OMW15.Views.ServiceReports;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace OMW15.Views.ServiceView
{
	public partial class MCInfo : Form
	{

		#region class field member

		private string _machineModel = string.Empty;
		private string _snFilter = string.Empty;
		private string _customerFilter = string.Empty;
		private string _selectedModelId = string.Empty;
		private string _selectedModel = string.Empty;
		private string _selectedCustCode = string.Empty;
		private string _selectedCustomerName = string.Empty;
		private string _selectedSN = string.Empty;
		private int _selectedCustomerId = 0;
		private int _mcId;
		private int _serviceJobId;
		private int[] _serviceJobs;

		#endregion

		#region class properties

		#endregion

		#region class helper

		private void UpdateUI()
		{
			tsbtnMCInfo.Enabled = _mcId > 0;
			tsbtnDeleteMCRecord.Enabled = tsbtnMCInfo.Enabled;
			tsbtnMCHistory.Enabled = dgvJobs.Rows.Count > 0 && _serviceJobId > 0;
			tsbtnOpenServiceJob.Enabled = tsbtnMCInfo.Enabled;
			tsbtnPM.Enabled = tsbtnMCInfo.Enabled;

			if (!chkModel.Checked && !chkSN.Checked && !chkCustomer.Checked)
			{
				btnSearch.Enabled = false;
			}
			else if ((chkModel.Checked && cbxModel.Text != "") 
						|| (chkSN.Checked && txtSNFilter.Text != "") 
						|| (chkCustomer.Checked && txtCustomerFilter.Text != ""))
			{
				btnSearch.Enabled = true;
			}
			else
			{
				btnSearch.Enabled = false;
			}

		} // end UpdateUI


		private void GetMachineModelList()
		{
			cbxModel.DataSource = new MachineDAL().GetMachineModels();
			cbxModel.DisplayMember = "Model";
			cbxModel.ValueMember = "Model";

		} // end GetMachineModelList

		private async void GetMachineList(string Model, string SN, string Customer)
		{
			dgv.DataSource = null;

			var _dal = new MachineDAL();
			var _dt = await _dal.GetAsyncMachineList(Model, SN, Customer);

			dgv.SuspendLayout();
			dgv.DataSource = _dt;

			dgv.Columns["ID"].Visible = false;
			dgv.Columns["MODELID"].Visible = false;
			dgv.Columns["CUSTID"].Visible = false;

			dgv.Columns["Transfer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["NewMC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			dgv.ResumeLayout();


			lbFound.Text = $"match = {dgv.Rows.Count}";

		} // end GetMachineList


		private void GetJobHistory(string CustomerCode, string Model, string SN)
		{
			dgvJobs.SuspendLayout();
			DataTable dt = new ServiceJobDAL().GetOrderList(CustomerCode, Model, SN);

			// debug
			// MessageBox.Show($"found : {dt.Rows.Count}");
			// end debug

			dgvJobs.DataSource = dt;

			// hiding columns
			dgvJobs.Columns["ID"].Visible = false;
			dgvJobs.Columns["CODE"].Visible = false;

			dgvJobs.ResumeLayout();

			lbCountJobs.Text = $"found = {dgvJobs.Rows.Count}";

			if (dgvJobs.Rows.Count > 0)
			{
				var _ids = new ArrayList();
				foreach (DataGridViewRow dgr in dgvJobs.Rows)
					_ids.Add(Convert.ToInt32(dgr.Cells["ID"].Value));

				_serviceJobs = (int[])_ids.ToArray(typeof(int));
			}
		} // end GetJobHistory

		private void GetMCRegiterInfo(int MachineId)
		{
			using (var _mcInfo = new MCRegister(MachineId))
			{
				_mcInfo.StartPosition = FormStartPosition.CenterParent;
				if (_mcInfo.ShowDialog() == DialogResult.OK)
				{
				}
			}
		} // end GetMCRegiterInfo

		#endregion

		public MCInfo()
		{
			InitializeComponent();

			OMUtils.SettingDataGridView(ref dgv);
			OMUtils.SettingDataGridView(ref dgvJobs);
			CenterToParent();

			chkSN.Checked = false;
			chkModel.Checked = false;
			chkCustomer.Checked = false;
		}

		private void MCInfo_Load(object sender, EventArgs e)
		{

			UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void chkModel_CheckedChanged(object sender, EventArgs e)
		{
			if (chkModel.Checked)
				GetMachineModelList();
			else
				_machineModel = "";
			cbxModel.Enabled = chkModel.Checked;
			UpdateUI();
		}

		private void chkSN_CheckedChanged(object sender, EventArgs e)
		{
			txtSNFilter.Enabled = chkSN.Checked;
			txtSNFilter.Text = chkSN.Checked ? txtSNFilter.Text : "";
			UpdateUI();
		}

		private void chkCustomer_CheckedChanged(object sender, EventArgs e)
		{
			txtCustomerFilter.Enabled = chkCustomer.Checked;
			txtCustomerFilter.Text = chkCustomer.Checked ? txtCustomerFilter.Text : "";
			UpdateUI();
		}

		private void cbxModel_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_machineModel = cbxModel.SelectedValue.ToString();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			lbMCId.Text = $"idx = {_mcId = 0}";
			lbSN.Text = $"SN:{_selectedSN = ""}";
			lbModel.Text = $"{_selectedModel = ""}";
			lbCustCode.Text = $"{_selectedCustCode = ""}";

			GetMachineList(_machineModel, _snFilter, _customerFilter);

		}

		private void txtSNFilter_TextChanged(object sender, EventArgs e)
		{
			_snFilter = txtSNFilter.Text;
			UpdateUI();
		}

		private void txtCustomerFilter_TextChanged(object sender, EventArgs e)
		{
			_customerFilter = txtCustomerFilter.Text;
			UpdateUI();
		}

		private void txt_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				btnSearch.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_mcId = Convert.ToInt32(dgv["ID", e.RowIndex].Value);
			_selectedCustomerName = dgv["CUSTOMER", e.RowIndex].Value.ToString();
			_selectedCustCode = dgv["CUSTOMERCODE", e.RowIndex].Value.ToString();
			_selectedCustomerId = Convert.ToInt32(dgv["CUSTID", e.RowIndex].Value);
			_selectedModel = dgv["MODEL", e.RowIndex].Value.ToString();
			_selectedModelId = dgv["MODELID", e.RowIndex].Value.ToString();
			_selectedSN = dgv["SERIALNO", e.RowIndex].Value.ToString();


			lbMCId.Text = $"idx = {_mcId}";
			lbSN.Text = $"SN:{_selectedSN}";
			lbModel.Text = $"{_selectedModel}";
			lbCustCode.Text = $"{_selectedCustCode}";
			UpdateUI();

			GetJobHistory(_selectedCustCode.Trim(), _selectedModel.Trim(), _selectedSN.Trim());
		}

		private void dgvJobs_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_serviceJobId = Convert.ToInt32(dgvJobs["ID", e.RowIndex].Value);
			UpdateUI();
		}

		private void dgvJobs_DoubleClick(object sender, EventArgs e)
		{
			mnuJobHistory.PerformClick();
		}

		private void mnuJobHistory_Click(object sender, EventArgs e)
		{
			var _p = new ServicePrintHost();
			_p.OrderId = _serviceJobId;
			_p.ReportType = MachineHistoryDisplayStyle.DisplayHistory;
			_p.WindowState = FormWindowState.Maximized;
			_p.Show();
		}

		private void mnuAllJobHistories_Click(object sender, EventArgs e)
		{
			var _p = new ServicePrintHost();
			_p.OrderIds = _serviceJobs;
			_p.ReportType = MachineHistoryDisplayStyle.DisplayHistories;
			_p.WindowState = FormWindowState.Maximized;
			_p.Show();
		}

		private void tsbtnMCInfo_Click(object sender, EventArgs e)
		{
			GetMCRegiterInfo(_mcId);
		}

		private void tsbtnMCRegister_Click(object sender, EventArgs e)
		{
			_mcId = 0;
			GetMCRegiterInfo(_mcId);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnMCInfo.PerformClick();
		}

		private void tsbtnDeleteMCRecord_Click(object sender, EventArgs e)
		{
			// delete record
			if (MessageBox.Show("ต้องการลบรายการที่เลือกใช่หรือไม่?", "Delete Machine Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (new Models.ServiceModel.MachineDAL().deleteMachine(_mcId, _machineModel, _selectedSN, _selectedCustCode) > 0)
				{
					MessageBox.Show("Delete record successfully...");
				}
			}

			// reload 
			btnSearch.PerformClick();
		}

		private void tsbtnOpenServiceJob_Click(object sender, EventArgs e)
		{

			using (ServiceJobInfo jobInfo = new ServiceJobInfo(jobId: 0, orderCode: "SV", modelId: _selectedModelId, model: _selectedModel, serialNo: _selectedSN, customerId: _selectedCustomerId, customerCode: _selectedCustCode, customerName: _selectedCustomerName))
			{
				jobInfo.StartPosition = FormStartPosition.CenterParent;

				if (jobInfo.ShowDialog(this) == DialogResult.OK)
				{
				}
			}
		}

		private void tsbtnProduct_Click(object sender, EventArgs e)
		{
			Views.ProductView.MCModelList product = new ProductView.MCModelList();
			product.StartPosition = FormStartPosition.CenterScreen;
			product.MdiParent = this.ParentForm;
			product.Show();
		}

		private void tsbtnPM_Click(object sender, EventArgs e)
		{
			PMInfo pminfo = new PMInfo();
			pminfo.PMCall = PMServiceCall.PMCallByMCRecord;
			pminfo.PMContractNo = "";
			pminfo.SN = _selectedSN;
			pminfo.Model = _selectedModel;
			pminfo.CustomerCode = _selectedCustCode;
			pminfo.CustomerName = _selectedCustomerName;
			pminfo.StartPosition = FormStartPosition.CenterParent;
			pminfo.Show();

		}

		private void cbxModel_EnabledChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void txtSNFilter_EnabledChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void txtCustomerFilter_EnabledChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}
	}
}