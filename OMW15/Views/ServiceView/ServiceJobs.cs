using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ServiceModel;
using OMW15.Shared;
using OMW15.Views.ServiceReports;
using System.Drawing;

namespace OMW15.Views.ServiceView
{
	public partial class ServiceJobs : Form
	{
		public ServiceJobs()
		{
			InitializeComponent();
		}

		private async void getActiveServiceOrderSummaryByOrderCode()
		{
			var _dal = new ServiceJobDAL();
			var _dt = await _dal.getSummaryActiveServiceOrderByOrderCodeAsync();
			//_dt.DefaultView.Sort = "Qty";

			this.dgvByOrderCode.SuspendLayout();
			this.dgvByOrderCode.Font = new Font(this.dgvByOrderCode.Font, FontStyle.Bold);
			this.dgvByOrderCode.DataSource = _dt;
			this.dgvByOrderCode.Columns["CODE"].HeaderText = "รหัสใบงาน";

			this.dgvByOrderCode.Columns["QTY"].HeaderText = "จำนวนงาน";
			this.dgvByOrderCode.Columns["QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dgvByOrderCode.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvByOrderCode.ResumeLayout();

		}

		private async void getActiveServiceOrderSummaryByModel()
		{
			var _dal = new ServiceJobDAL();
			var _dt = await _dal.getSummaryActiveServiceOrderByModelAsync();
			//_dt.DefaultView.Sort = "Qty";

			this.dgvByModel.SuspendLayout();
			this.dgvByModel.Font = new Font(this.dgvByModel.Font, FontStyle.Bold);
			this.dgvByModel.DataSource = _dt;
			this.dgvByModel.Columns["MODEL"].HeaderText = "รหัสใบงาน";

			this.dgvByModel.Columns["QTY"].HeaderText = "จำนวนงาน";
			this.dgvByModel.Columns["QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dgvByModel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvByModel.ResumeLayout();

		}

		private void ServiceJobs_Load(object sender, EventArgs e)
		{
			// setting datagridView
			OMUtils.SettingDataGridView(ref dgv);
			OMUtils.SettingDataGridView(ref dgvByOrderCode);
			OMUtils.SettingDataGridView(ref dgvByModel);

			// display summary active orders
			this.getActiveServiceOrderSummaryByOrderCode();
			this.getActiveServiceOrderSummaryByModel();

			// call jobstatus
			GetJobStatusList();

			// setting default parameter values
			_selectedJobId = 0;

			// call year list
			GetYearList(_selectedJobstatus);

			UpdateUI();
		}

		private void cbxJobStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedJobstatus =
					(OMShareServiceEnums.OrderStatusEnum)Enum.Parse(typeof(OMShareServiceEnums.OrderStatusEnum), cbxJobStatus.Text);
			}
			catch
			{
				_selectedJobstatus = OMShareServiceEnums.OrderStatusEnum.ACTIVE;
			}


			lbJobCAT.Visible = _selectedJobstatus != OMShareServiceEnums.OrderStatusEnum.ALL;
			cbxJobCat.Visible = lbJobCAT.Visible;

			if (lbJobCAT.Visible)
			{
				// call year list
				GetYearList(_selectedJobstatus);
			}

			lbStatus.Text = $"Status [{(int)_selectedJobstatus}] : ";
		}

		private void cbxJobCat_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_selectedSeviceJobCat = cbxJobCat.SelectedValue.ToString();
			}
			catch
			{
				_selectedSeviceJobCat = "R";
			}
			lbJobCAT.Text = $"รหัสใบงาน [{_selectedSeviceJobCat}]:";
		}

		private void btnLoadData_Click(object sender, EventArgs e)
		{
			lbSelectYear.Text = _selectedJobYear.ToString();

			GetJobList(_selectedJobYear, _selectedSeviceJobCat, _selectedJobstatus);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cbxJobYear_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedJobYear = Convert.ToInt32(cbxJobYear.SelectedValue);
			}
			catch
			{
				_selectedJobYear = DateTime.Today.Year;
			}


			GetJobCATBySelectedYear(_selectedJobYear, _selectedJobstatus);

		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_rowCount == dgv.Rows.Count)
			{
				_selectedJobId = Convert.ToInt32(dgv["ORDERID", e.RowIndex].Value);
				_selectedJobCodeFromOrderList = dgv["ORDERCODE", e.RowIndex].Value.ToString();

				lbSelectedOrderId.Text = $"ord-index :: {_selectedJobId}";

				// for display error
				var _sbError = new StringBuilder();
				_sbError.AppendFormat("Error Code : {0}", dgv["ERRORCODE", e.RowIndex].Value);
				_sbError.AppendLine();
				_sbError.Append(dgv["ERROR", e.RowIndex].Value);

				ShowError(_sbError.ToString());

				// get order fixed details
				txtFixed.Text = new ServiceJobDAL().GetJobFixed(_selectedJobId);
			}

			// update UI
			UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			GetJobOrderInfo(_selectedJobId = 0,
				string.IsNullOrEmpty(_selectedSeviceJobCat) ? _selectedJobCodeFromOrderList : _selectedSeviceJobCat);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			GetJobOrderInfo(_selectedJobId, _selectedJobCodeFromOrderList);
		}

		private void tsbtnFind_Click(object sender, EventArgs e)
		{
			// search by string input 
			(dgv.DataSource as DataTable).DefaultView.RowFilter = GetFilter();

			_rowCount = dgv.Rows.Count;

			UpdateUI();
		}

		private void tsbtnPrint_Click(object sender, EventArgs e)
		{
			var _pHost = new ServicePrintHost();
			_pHost.OrderId = _selectedJobId;
			_pHost.ReportType = MachineHistoryDisplayStyle.DisplayOrderForm;
			_pHost.MdiParent = ParentForm;
			_pHost.WindowState = FormWindowState.Maximized;
			_pHost.Show();
		}


		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			btnLoadData.PerformClick();
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("ต้องการลบข้อมูลที่เลือกใช่ไหม?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				DialogResult.Yes)
			{

				int result = new ServiceJobDAL().DeleteJobOrder(_selectedJobId);
				if (result >= 0)
				{
					MessageBox.Show("Delete Job order completed....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (result < 0)
				{
					MessageBox.Show("Can't Delete Job order...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		#region class field members

		private int _rowCount;
		private int _selectedJobId;
		private int _selectedJobYear = DateTime.Today.Year;
		private string _selectedSeviceJobCat = "SV";
		private string _selectedJobCodeFromOrderList = string.Empty;
		private OMShareServiceEnums.OrderStatusEnum _selectedJobstatus = OMShareServiceEnums.OrderStatusEnum.ACTIVE;

		#endregion

		#region class property

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			// count records
			lbCount.Text = string.Format("found : {0}", dgv.Rows.Count);

			tsbtnAdd.Enabled = !string.IsNullOrEmpty(_selectedSeviceJobCat);
			tsbtnEdit.Enabled = _selectedJobId > 0;
			tsbtnDelete.Enabled = tsbtnEdit.Enabled;
			tsbtnPrint.Enabled = tsbtnEdit.Enabled;
			tsbtnFind.Enabled = dgv.Rows.Count > 0;

		} // end UpdateUI

		private void GetJobStatusList()
		{
			cbxJobStatus.DataSource = OMDataUtils.GetValueList<OMShareServiceEnums.OrderStatusEnum>();
			cbxJobStatus.DisplayMember = "Value";
			cbxJobStatus.ValueMember = "Key";
			cbxJobStatus.SelectedValue = (int)_selectedJobstatus;

			UpdateUI();
		} // end GetJobStatusList

		private void GetYearList(OMShareServiceEnums.OrderStatusEnum jobStatus)
		{
			cbxJobYear.DataSource = new ServiceJobDAL().GetServiceYearList(jobStatus);
			cbxJobYear.DisplayMember = "Y";
			cbxJobYear.ValueMember = "Y";
			cbxJobYear.SelectedValue = (lbSelectYear.Text.IsNumeric() ? Convert.ToInt32(lbSelectYear.Text) : _selectedJobYear);

			UpdateUI();

		} // end GetYearList


		private void GetJobCATBySelectedYear(int SelectedYear, OMShareServiceEnums.OrderStatusEnum jobStatus)
		{
			cbxJobCat.DataSource = new ServiceJobDAL().GetJobCodeList(SelectedYear, jobStatus);
			cbxJobCat.DisplayMember = "VALUE";
			cbxJobCat.ValueMember = "CODE";
			cbxJobCat.SelectedValue = _selectedSeviceJobCat;

			UpdateUI();
		} // end GetJobCodeBySelectedYear


		private void GetJobList(int YearSelect, string JobCode, OMShareServiceEnums.OrderStatusEnum Status)
		{
			var dt = new ServiceJobDAL().GetServiceJobList(YearSelect, JobCode, Status);
			_rowCount = dt.Rows.Count;

			dgv.DataSource = dt;

			dgv.SuspendLayout();
			dgv.Columns["YEAR"].Visible = false;
			dgv.Columns["JOBSTATUS"].Visible = false;
			dgv.Columns["STATUSNAME"].HeaderText = "Status";
			dgv.Columns["ORDERID"].Visible = false;
			dgv.Columns["ORDERCODE"].Visible = false;
			dgv.Columns["ORDERNO"].Visible = false;
			dgv.Columns["ERRORCODE"].Visible = false;
			dgv.Columns["ERROR"].Visible = false;
			dgv.Columns["ACTIONPIORITY"].Visible = false;
			dgv.Columns["FINISH"].Visible = !(Status == OMShareServiceEnums.OrderStatusEnum.ACTIVE);
			dgv.Columns["CUSTOMER"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			dgv.ResumeLayout();

			dgv.Columns["SERVICECOST"].HeaderText = "Service Charge";
			dgv.Columns["SERVICECOST"].DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.NumericCellStyle();
			dgv.Columns["SPAREPARTCOST"].HeaderText = "Spare part";
			dgv.Columns["SPAREPARTCOST"].DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.NumericCellStyle();
			dgv.Columns["OTHERCOST"].HeaderText = "Other Charge";
			dgv.Columns["OTHERCOST"].DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.NumericCellStyle();

			lbCount.Text = $"found : {_rowCount}";

			UpdateUI();
		} // end GetJobList


		private void ShowError(string Error)
		{
			txtError.Text = Error;
		} // end ShowError


		private void GetJobOrderInfo(int JobId, string OrderCode = "")
		{
			using (var _srvInfo = new ServiceJobInfo(JobId, OrderCode))
			{
				_srvInfo.StartPosition = FormStartPosition.CenterScreen;
				_srvInfo.ShowDialog(this);
			}

			// refresh year list
			GetYearList(_selectedJobstatus);

			// refresh UI
			tsbtnRefresh.PerformClick();

		} // end GetJobOrderInfo

		private string GetFilter()
		{
			var _result = string.Empty;
			using (var _search = new JobSearch())
			{
				if (_search.ShowDialog() == DialogResult.OK)
					_result = _search.FilterResult;
				else
					_result = string.Empty;
			}
			return _result;
		} // end GetFilter

		#endregion


		private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}