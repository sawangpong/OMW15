using OMControls;
using OMW15.Models.ProductionModel;
using OMW15.Shared;
using OMW15.Views.Productions.ProductionReports;
using System;
using System.Windows.Forms;
using static OMW15.Shared.OMShareProduction;

namespace OMW15.Views.Productions
{
	public partial class ProductionJobList : Form
	{
		#region Singleton
		private static ProductionJobList _instance;
		public static ProductionJobList GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new ProductionJobList();
				}
				return _instance;
			}
		}
		#endregion

		#region class field member
		//private ContextMenu _ctmTask;
		private OMShareProduction.SearchType _searchType = OMShareProduction.SearchType.None;
		private int _status = (int)OMShareProduction.ProductionJobStatus.Active;
		private int _selectedJobYear = DateTime.Today.Year;
		private int _rowCount;
		private int _selectedJobId;
		private int _erp_id;
		private string _selectedERP_ORDER = string.Empty;
		private string _reportCode = string.Empty;
		private string _filterText = string.Empty;
		private int _formula_id = 0;
		private ReportDisplayType _reportDisplayType = ReportDisplayType.SingleRecord;
		#endregion

		#region class property

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			ts.Enabled = (dgv.Rows.Count > 0);
			tsbtnEditTask.Enabled = _selectedJobId > 0;
			tsbtnDeleteTask.Enabled = tsbtnEditTask.Enabled;
			tsbtnReport.Enabled = tsbtnEditTask.Enabled;
			btnLoadData.Enabled = (_status > 0 && _selectedJobYear > 0);
			btnUpdateAllJobs.Visible = (omglobal.PermisionId > (int)OMShareSysConfigEnums.UserPermission.Manager);

		} // end UpdateUI

		private string GetDayText(DateTime d, string ColName)
		{
			var _d = new DateTime(d.Year, d.Month, Convert.ToInt32(ColName.Substring(1)));
			return $"{_d.ToString("ddd")}.{_d.Day}";
		} // end GetDayText

		private void GetProductionYear(int status)
		{
			this.cbxProductionYear.DataSource = new ProductionDAL().GetProductionYearByStatus(status);
			this.cbxProductionYear.DisplayMember = "JobYear";
			this.cbxProductionYear.ValueMember = "JobYear";
		}

		private void UpdateProductionJobHours()
		{
			if (new ProductionDAL().UpdateProductionJobHours() == 0)
			{
				MessageBox.Show("Update record successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				btnLoadData.PerformClick();
			}
		}

		private async void GetProductionOrderList(int Status, int jobYear, OMShareProduction.SearchType SearchWhat = SearchType.None, string TextFilter = "")
		{
			var _myTask = new ProductionDAL();
			//var dt = await _myTask.GetProductionJobsAsync(Status, jobYear, SearchWhat, TextFilter);
			var dt = await _myTask.GetProductionJobsAsync(Status, jobYear, TextFilter);

			_rowCount = dt.Rows.Count;

			dgv.SuspendLayout();

			dgv.DataSource = dt;
			dgv.Columns["ERP_DI"].Visible = false;
			dgv.Columns["PDJOBID"].Visible = false;
			dgv.Columns["STATUS"].Visible = false;
			dgv.Columns["JOBYEAR"].Visible = false;
			dgv.Columns["DRAWINGNO"].Visible = false;
			dgv.Columns["FORMULA_ID"].Visible = false;

			dgv.Columns["ITEMNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["StatusName"].HeaderText = "สถานะ";
			dgv.Columns["JOBTYPE"].HeaderText = "งาน";
			dgv.Columns["ERP_ORDER"].HeaderText = "เลขใบขอแปร / โครงการ";
			dgv.Columns["OPENDATE"].HeaderText = "วันที่ขอ";
			dgv.Columns["STARTDATE"].HeaderText = "วันที่เริ่มงาน";
			dgv.Columns["DUE"].HeaderText = "ครบกำหนด";
			dgv.Columns["CLOSEDATE"].Visible = (Status == (int)OMShareProduction.ProductionJobStatus.Closed);
			dgv.Columns["CLOSEDATE"].HeaderText = "วันที่เสร็จ";
			dgv.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			dgv.Columns["ITEMNAME"].HeaderText = "รายละเอียดงาน";
			dgv.Columns["FORMULA_NUMBER"].HeaderText = "สูตรการผลิต";
			dgv.Columns["UNITORDER"].HeaderText = "หน่วยนับ";
			dgv.Columns["QORDER"].HeaderText = "จำนวนผลิต";
			dgv.Columns["QORDER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["TOTAL_HOURS"].HeaderText = "ชั่วโมงรวม";
			dgv.Columns["TOTAL_HOURS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["WorkHourUnit"].HeaderText = "ชั่วโมง/หน่วย";
			dgv.Columns["WorkHourUnit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["WorkHourUnit"].DefaultCellStyle.Format = "N2";

			//foreach (DataGridViewColumn dgc in dgv.Columns)
			//{
			//	if (dgc.ValueType == typeof(decimal))
			//	{
			//		dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			//	}
			//}

			dgv.ResumeLayout();

			// update Task count
			tslbCount.Text = $"found :: {dgv.Rows.Count}";

			if(_selectedJobId > 0)
			{
			
			}


		} // end GetProductionTaskList


		private void GetProductionOrder(int productionJobId, string ProductionOrderNo, int ERP_DI)
		{
			using (var _pOrder = new ProductionOrder(productionJobId, ProductionOrderNo, ERP_DI))
			{
				if (_pOrder.ShowDialog() == DialogResult.OK)
				{
				}
			}

			GetProductionOrderList(_status, _selectedJobYear, _searchType, txtFilter.Text);

			//btnLoadData.PerformClick();

		} // end GetProductionOrderList

		private void DeleteProductionOrder(string ProductionOrderNo)
		{
			// 1. Remove the production hours items
			// 2. Remove the production header 
			if (
				MessageBox.Show("Do you want to delete the selected record?",
								"Delete",
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (new ProductionDAL().RemoveProductionHourItems(ProductionOrderNo) >= 0)
				{
					if (new ProductionDAL().RemoveProductionHeader(ProductionOrderNo) > 0)
					{
						MessageBox.Show("Delete the Production Record successfully.....",
										"Message",
										MessageBoxButtons.OK,
										MessageBoxIcon.Information);
					}
				}
			}

			btnLoadData.PerformClick();

		} // end DeleteProductionOrder


		private void GetStatusList()
		{
			cbxStatus.DataSource = EnumWithName<OMShareProduction.ProductionJobStatus>.ParseEnum();
			cbxStatus.DisplayMember = "Name";
			cbxStatus.ValueMember = "Value";
			cbxStatus.SelectedValue = _status;

		} // end GetStatusList

		private void ShowProductionReport(int reportIndex, int yearReport, int monthReport = 0, int jobStatus = 0, string jobNo = "")
		{
			ProductionReportViewer _report = new ProductionReportViewer(reportIndex, yearReport, monthReport, jobStatus, _reportDisplayType, jobNo);
			_report.WindowState = FormWindowState.Normal;
			_report.StartPosition = FormStartPosition.CenterScreen;
			_report.Show();
		}

		#endregion

		// CONSTRUCTOR
		public ProductionJobList()
		{
			InitializeComponent();
			pnlHeader.BackColor = omglobal.OM_ORANGE_COLOR;

			OMUtils.SettingDataGridView(ref dgv);
			GetStatusList();
		}

		private void ProductionJobList_Load(object sender, EventArgs e) => UpdateUI();

		private void tsbtnClose_Click(object sender, EventArgs e) => Close();

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_rowCount == dgv.Rows.Count)
			{
				_selectedJobId = Convert.ToInt32(dgv["PDJOBID", e.RowIndex].Value);
				_selectedERP_ORDER = dgv["ERP_ORDER", e.RowIndex].Value.ToString();
				_erp_id = Convert.ToInt32(dgv["ERP_DI", e.RowIndex].Value);
				_formula_id = ( Convert.IsDBNull(dgv["FORMULA_ID", e.RowIndex].Value) ? 0 :  Convert.ToInt32(dgv["FORMULA_ID", e.RowIndex].Value));
			}
			lbFormulaId.Text = $"formula-id:{_formula_id}";
			lbJobId.Text = $" Index: [{_selectedJobId}], erp id: [{_erp_id}]";
			UpdateUI();
		}

		private void tsbtn_Click(object sender, EventArgs e)
		{
			var btn = sender as ToolStripButton;

			switch (btn.Tag.ToString().ToUpper())
			{
				case "ADD":
					_selectedJobId = 0;
					GetProductionOrder(_selectedJobId, _selectedERP_ORDER = "", _erp_id = 0);
					break;

				case "EDIT":
					GetProductionOrder(_selectedJobId, _selectedERP_ORDER, _erp_id);
					break;

				case "DEL":
					DeleteProductionOrder(_selectedERP_ORDER);
					break;
			}
		}

					
		private void dgv_DoubleClick(object sender, EventArgs e) 
			=> GetProductionOrder(_selectedJobId, _selectedERP_ORDER, _erp_id);

		//tsbtnEditTask.PerformClick();

		private void cbxStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_status = (int)cbxStatus.SelectedValue;
			}
			catch
			{
				_status = (int)OMShareProduction.ProductionJobStatus.Active;
			}

			if (_status != (int)OMShareProduction.ProductionJobStatus.None)
			{
				GetProductionYear(_status);
			}
			UpdateUI();
		}

		private void btnClose_Click(object sender, EventArgs e) => Close();

		private void cbxProductionYear_SelectedValueChanged(object sender, EventArgs e)
		{
			if (e == null) return;
			try
			{
				_selectedJobYear = (int)cbxProductionYear.SelectedValue;
			}
			catch
			{
				_selectedJobYear = DateTime.Today.Year;
			}

			dgv.DataSource = null;
			dgv.Rows.Clear();

			UpdateUI();
		}

		private void btnLoadData_Click(object sender, EventArgs e)
		{
			_filterText = txtFilter.Text;
			GetProductionOrderList(_status, _selectedJobYear, _searchType, _filterText);
		}

		private void btnUpdateAllJobs_Click(object sender, EventArgs e) => UpdateProductionJobHours();

		private void tsbtnReport_Click(object sender, EventArgs e)
			=> ShowProductionReport(3, _selectedJobYear, 0, _status, _selectedERP_ORDER);


		private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnLoadData.PerformClick();
			}
		}

		private void tsbtnMatRequire_Click(object sender, EventArgs e)
		{
			ProductionRequireParts _demand = ProductionRequireParts.GetInstance;
			_demand.MdiParent = this.ParentForm;
			_demand.StartPosition = FormStartPosition.CenterScreen;
			_demand.Show();
		}
	}
}