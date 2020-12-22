using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OMW15.Shared;


namespace OMW15.Views.ServiceView {
	public partial class ServiceJobList : Form
	{

		#region class Field Member
		private int _rowCount = 0;
		private int _selectedJobId = 0;
		private int _selectedJobYear = DateTime.Today.Year;
		private string _selectedJobCode = string.Empty;
		private string _selectedJobCodeFromOrderList = string.Empty;
		private Shared.OMShareServiceEnums.OrderStatusEnum _selectedJobstatus = Shared.OMShareServiceEnums.OrderStatusEnum.ALL;

		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			// count records
			lbJobCount.Text = string.Format("found : {0}", dgv.Rows.Count);

			lbSelectedYear.Text = string.Format("Selected :: {0}/{1}", _selectedJobYear, _selectedJobCode);
			tsbtnAddJob.Enabled = !string.IsNullOrEmpty(_selectedJobCode);
			tsbtnEditJob.Enabled = (_selectedJobId > 0);
			tsbtnPrintOrder.Enabled = tsbtnEditJob.Enabled;
			tsbtnDelete.Enabled = tsbtnEditJob.Enabled;
			tsbtnJobFilter.Enabled = (dgv.Rows.Count > 0);

			//this.tsbtnStatistic.Enabled = this.tsbtnEditJob.Enabled;

		} // end UpdateUI

		private void GetYearList()
		{
			tscbxJobYear.ComboBox.DataSource = new Models.ServiceModel.ServiceJobDAL().GetServiceYearList();
			tscbxJobYear.ComboBox.DisplayMember = "Y";
			tscbxJobYear.ComboBox.ValueMember = "Y";

			tscbxJobYear.ComboBox.SelectedIndex = 0;
			_selectedJobYear = Convert.ToInt32(tscbxJobYear.ComboBox.SelectedValue);

		} // end GetYearList

		private void GetJobCodeBySelectedYear(int SelectedYear)
		{
			lst.DataSource = new Models.ServiceModel.ServiceJobDAL().GetJobCodeList(SelectedYear);
			lst.DisplayMember = "VALUE";
			lst.ValueMember = "CODE";

		} // end GetJobCodeBySelectedYear


		private void GetJobList(int YearSelect, string JobCode, Shared.OMShareServiceEnums.OrderStatusEnum Status)
		{
			DataTable dt = new Models.ServiceModel.ServiceJobDAL().GetServiceJobList(YearSelect, JobCode, Status);
			_rowCount = dt.Rows.Count;
			dgv.DataSource = dt;

			dgv.SuspendLayout();
			dgv.Columns["ORDERID"].Visible = false;
			dgv.Columns["ORDERCODE"].Visible = false;
			dgv.Columns["ORDERNO"].Visible = false;
			dgv.Columns["ERRORCODE"].Visible = false;
			dgv.Columns["ERROR"].Visible = false;

			dgv.ResumeLayout();

			UpdateUI();

		} // end GetJobList

		private void DisplayOption(Shared.OMShareServiceEnums.OrderStatusEnum Option)
		{
			switch (Option)
			{
				case Shared.OMShareServiceEnums.OrderStatusEnum.ALL:
					pnlJobType.Visible = false;
					pnlJobListHeader.Visible = pnlJobType.Visible;
					break;
				case Shared.OMShareServiceEnums.OrderStatusEnum.ACTIVE:
				case Shared.OMShareServiceEnums.OrderStatusEnum.CLOSED:
					// call job code list
					pnlJobType.Visible = true;
					pnlJobListHeader.Visible = pnlJobType.Visible;
					lbStatus.Text = Option.ToString();
					GetJobCodeBySelectedYear(_selectedJobYear);
					break;
			}
		} // end DisplayOption

		private void ShowError(string Error)
		{
			txtError.Text = Error;

		} // end ShowError

		private string GetFilter()
		{
			string _result = string.Empty;
			using (ServiceView.JobSearch _search = new JobSearch())
			{
				if (_search.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					_result = _search.FilterResult;
				}
				else
				{
					_result = string.Empty;
				}
			}
			return _result;

		} // end GetFilter

		private void GetJobOrderInfo(int JobId, string OrderCode = "")
		{
			using (ServiceView.ServiceJobInfo _srvInfo = new ServiceJobInfo(JobId, OrderCode))
			{
				_srvInfo.StartPosition = FormStartPosition.CenterScreen;
				_srvInfo.ShowDialog(this);
			}

			// refresh UI
			tsbtnRefresh.PerformClick();

		} // end GetJobOrderInfo


		#endregion


		public ServiceJobList()
		{
			InitializeComponent();
		}

		private void ServiceJobList_Load(object sender, EventArgs e)
		{
			// setting datagridView
			OMControls.OMUtils.SettingDataGridView(ref dgv);

			// setting default parameter values
			_selectedJobId = 0;

			// call year list
			GetYearList();

		}

		private void tscbxJobYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedJobYear = Convert.ToInt32(tscbxJobYear.ComboBox.SelectedValue.ToString());
			}
			catch
			{
				_selectedJobYear = DateTime.Today.Year;
			}

			// display the selected job year
			UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lst_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (lst.SelectedValue.GetType() == typeof(System.String))
				{
					_selectedJobCode = lst.SelectedValue.ToString();
				}
			}
			catch
			{
				_selectedJobCode = string.Empty;
			}

			UpdateUI();
		}

		private void rdo_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton _rdo = sender as RadioButton;

			if (_rdo.Checked == true)
			{
				switch (_rdo.Tag.ToString())
				{
					case "ALL":
						_selectedJobstatus = Shared.OMShareServiceEnums.OrderStatusEnum.ALL;
						break;

					case "ACTIVE":
						_selectedJobstatus = Shared.OMShareServiceEnums.OrderStatusEnum.ACTIVE;
						break;

					case "CLOSED":
						_selectedJobstatus = Shared.OMShareServiceEnums.OrderStatusEnum.CLOSED;
						break;
				}

				DisplayOption(_selectedJobstatus);
			}
		}

		private void btnLoadJobs_Click(object sender, EventArgs e)
		{
			GetJobList(_selectedJobYear, _selectedJobCode, _selectedJobstatus);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_rowCount == dgv.Rows.Count)
			{
				_selectedJobId = Convert.ToInt32(dgv["ORDERID", e.RowIndex].Value);
				_selectedJobCodeFromOrderList = dgv["ORDERCODE", e.RowIndex].Value.ToString();

				lbSelectedOrderId.Text = _selectedJobId.ToString();

				// for display error
				StringBuilder _sbError = new StringBuilder();
				_sbError.AppendFormat("Error Code : {0}", dgv["ERRORCODE", e.RowIndex].Value);
				_sbError.AppendLine();
				_sbError.Append(dgv["ERROR", e.RowIndex].Value.ToString());

				ShowError(_sbError.ToString());

				// get order fixed details
				txtFixed.Text = new Models.ServiceModel.ServiceJobDAL().GetJobFixed(_selectedJobId);
			}

			// update UI
			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			btnLoadJobs.PerformClick();
		}

		private void tsbtnJobFilter_Click(object sender, EventArgs e)
		{
			// search by string input 
			(dgv.DataSource as DataTable).DefaultView.RowFilter = GetFilter();

			UpdateUI();
		}

		private void lst_DoubleClick(object sender, EventArgs e)
		{
			btnLoadJobs.PerformClick();
		}

		private void tsbtnAddJob_Click(object sender, EventArgs e)
		{
			_selectedJobId = 0;
			GetJobOrderInfo(_selectedJobId, (string.IsNullOrEmpty(_selectedJobCode) ? _selectedJobCodeFromOrderList : _selectedJobCode));
		}

		private void tsbtnEditJob_Click(object sender, EventArgs e)
		{
			GetJobOrderInfo(_selectedJobId, _selectedJobCodeFromOrderList);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEditJob.PerformClick();
		}

		private void tsbtnPrintOrder_Click(object sender, EventArgs e)
		{
			Views.ServiceReports.ServicePrintHost _pHost = new ServiceReports.ServicePrintHost();
			_pHost.OrderId = _selectedJobId;
			_pHost.ReportType = MachineHistoryDisplayStyle.DisplayOrderForm;
			_pHost.MdiParent = ParentForm;
			_pHost.WindowState = FormWindowState.Maximized;
			_pHost.Show();
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{

		}
	}
}
