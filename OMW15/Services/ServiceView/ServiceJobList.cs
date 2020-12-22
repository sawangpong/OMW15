using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Services.ServiceView
{
	public partial class ServiceJobList : Form
	{

		#region class Field Member
		private int _selectedJobId = 0;
		private int _selectedJobYear = DateTime.Today.Year;
		private string _selectedJobCode = string.Empty;
		private string _selectedJobCodeFromOrderList = string.Empty;
		private OrderStatusEnum _selectedJobstatus = OrderStatusEnum.ALL;

		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			// count records
			this.lbJobCount.Text = string.Format("found : {0}", this.dgv.Rows.Count);

			this.lbSelectedYear.Text = string.Format("Selected :: {0}/{1}", _selectedJobYear, _selectedJobCode);
			this.tsbtnAddJob.Enabled = !string.IsNullOrEmpty(_selectedJobCode);
			this.tsbtnEditJob.Enabled = (_selectedJobId > 0);
			this.tsbtnPrintOrder.Enabled = this.tsbtnEditJob.Enabled;
			this.tsbtnDelete.Enabled = this.tsbtnEditJob.Enabled;
			this.tsbtnJobFilter.Enabled = (this.dgv.Rows.Count >0);
			
			//this.tsbtnStatistic.Enabled = this.tsbtnEditJob.Enabled;

		} // end UpdateUI

		private void GetYearList()
		{
			this.tscbxJobYear.ComboBox.DataSource = Services.ServiceController.ServiceJobListController.GetServiceYearList();
			this.tscbxJobYear.ComboBox.DisplayMember = "Y";
			this.tscbxJobYear.ComboBox.ValueMember = "Y";

		} // end GetYearList

		private void GetJobCodeBySelectedYear(int SelectedYear)
		{
			this.lst.DataSource = Services.ServiceController.ServiceJobListController.GetJobCodeList(SelectedYear);
			this.lst.DisplayMember = "VALUE";
			this.lst.ValueMember = "CODE";

		} // end GetJobCodeBySelectedYear


		private void GetJobList(int YearSelect, string JobCode, OrderStatusEnum Status)
		{
			this.dgv.DataSource = new Services.ServiceController.ServiceJobListController().GetJobList(YearSelect, JobCode, Status);

			this.dgv.SuspendLayout();
			this.dgv.Columns["ORDERID"].Visible = false;
			this.dgv.Columns["ORDERCODE"].Visible = false;
			this.dgv.Columns["ORDERNO"].Visible = false;
			this.dgv.Columns["ERRORCODE"].Visible = false;
			this.dgv.Columns["ERROR"].Visible = false;

			this.dgv.ResumeLayout();

			this.UpdateUI();

		} // end GetJobList

		private void DisplayOption(OrderStatusEnum Option)
		{
			switch (Option)
			{
				case OrderStatusEnum.ALL:
					this.pnlJobType.Visible = false;
					this.pnlJobListHeader.Visible = this.pnlJobType.Visible;
					break;
				case OrderStatusEnum.ACTIVE:
				case OrderStatusEnum.COMPLETED:
					// call job code list
					this.pnlJobType.Visible = true;
					this.pnlJobListHeader.Visible = this.pnlJobType.Visible;
					this.lbStatus.Text = Option.ToString();
					this.GetJobCodeBySelectedYear(_selectedJobYear);
					break;
			}
		} // end DisplayOption

		private void ShowError(string Error)
		{
			this.txtError.Text = Error;

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

		private void GetJobOrderInfo(int JobId,string OrderCode = "")
		{
			using (ServiceView.ServiceJobInfo _srvInfo = new ServiceJobInfo(JobId,OrderCode))
			{
				_srvInfo.StartPosition = FormStartPosition.CenterScreen;
				_srvInfo.ShowDialog(this);
			}

			// refresh UI
			this.tsbtnRefresh.PerformClick();

		} // end GetJobOrderInfo


		#endregion


		public ServiceJobList()
		{
			InitializeComponent();
		}

		private void ServiceJobList_Load(object sender, EventArgs e)
		{
			// setting datagridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			// setting default parameter values
			_selectedJobId = 0;

			// call year list
			this.GetYearList();

		}

		private void tscbxJobYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedJobYear = Convert.ToInt32(this.tscbxJobYear.ComboBox.SelectedValue.ToString());
			}
			catch
			{
				_selectedJobYear = DateTime.Today.Year;
			}

			// display the selected job year
			this.UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void lst_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.lst.SelectedValue.GetType() == typeof(System.String))
				{
					_selectedJobCode = this.lst.SelectedValue.ToString();
				}
			}
			catch
			{
				_selectedJobCode = string.Empty;
			}

			this.UpdateUI();
		}

		private void rdo_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton _rdo = sender as RadioButton;

			if (_rdo.Checked == true)
			{
				switch (_rdo.Tag.ToString())
				{
					case "ALL":
						_selectedJobstatus = OrderStatusEnum.ALL;
						break;

					case "ACTIVE":
						_selectedJobstatus = OrderStatusEnum.ACTIVE;
						break;

					case "COMPLETED":
						_selectedJobstatus = OrderStatusEnum.COMPLETED;
						break;
				}

				this.DisplayOption(_selectedJobstatus);
			}
		}

		private void btnLoadJobs_Click(object sender, EventArgs e)
		{
			this.GetJobList(_selectedJobYear, _selectedJobCode, _selectedJobstatus);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedJobId = Convert.ToInt32(this.dgv["ORDERID", e.RowIndex].Value);
			_selectedJobCodeFromOrderList = this.dgv["ORDERCODE", e.RowIndex].Value.ToString();
			
			this.lbSelectedOrderId.Text = _selectedJobId.ToString();

			// for display error
			StringBuilder _sbError = new StringBuilder();
			_sbError.AppendFormat("Error Code : {0}", this.dgv["ERRORCODE", e.RowIndex].Value);
			_sbError.AppendLine();
			_sbError.Append(this.dgv["ERROR", e.RowIndex].Value.ToString());

			this.ShowError(_sbError.ToString());

			// get order fixed details
			this.txtFixed.Text = new ServiceController.ServiceJobListController().GetJobFixed(_selectedJobId);

			// update UI
			this.UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.btnLoadJobs.PerformClick();
		}

		private void tsbtnJobFilter_Click(object sender, EventArgs e)
		{
			// search by string input 
			(this.dgv.DataSource as DataTable).DefaultView.RowFilter = this.GetFilter();

			this.UpdateUI();
		}

		private void lst_DoubleClick(object sender, EventArgs e)
		{
			this.btnLoadJobs.PerformClick();
		}

		private void tsbtnAddJob_Click(object sender, EventArgs e)
		{
			_selectedJobId = 0;
			this.GetJobOrderInfo(_selectedJobId,(string.IsNullOrEmpty(_selectedJobCode) ? _selectedJobCodeFromOrderList : _selectedJobCode));
		}

		private void tsbtnEditJob_Click(object sender, EventArgs e)
		{
			this.GetJobOrderInfo(_selectedJobId, _selectedJobCodeFromOrderList);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.tsbtnEditJob.PerformClick();
		}

		private void tsbtnPrintOrder_Click(object sender, EventArgs e)
		{
			Services.ServiceReports.ServicePrintHost _pHost = new ServiceReports.ServicePrintHost();
			_pHost.OrderId = _selectedJobId;
			_pHost.ReportType = MachineHistoryDisplayStyle.DisplayOrderForm;
			_pHost.MdiParent = this.ParentForm;
			_pHost.WindowState = FormWindowState.Maximized;
			_pHost.Show();
		}
	}
}
