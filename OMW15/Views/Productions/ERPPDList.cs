using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.ProductionModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Windows.Forms;
using static OMW15.Shared.OMShareProduction;

namespace OMW15.Views.Productions
{
	public partial class ERPPDList : Form
	{
		#region class field members

		private DataTable _dtERP_Orders = new DataTable();
		private int _rowCount;
		private int _selectedProductionYear = DateTime.Today.Year;
		private int _selectedProductionPeriod = DateTime.Today.Month;
		private ProductionJobType _jobType = ProductionJobType.Production;

		#endregion

		#region class property
		public string ProductionCode { get; set; }

		public int ProductionCodePrefixId { get; set; }

		public string DocumentNo { get; set; }

		public DateTime DocumentDate { get; set; }

		public int IssueId { get; set; }

		public string DocumentInfo { get; set; }
		public decimal Qty { get; set; }

		public string PartNo { get; set; }
		public string PartName { get; set; }
		public string Unit { get; set; }

		public ProductionJobType JobType { get; set; }

		#endregion

		public ERPPDList()
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgv);
			OMUtils.SettingDataGridView(ref dgvProductionCode);
			CenterToParent();
		}

		private void ERPPDList_Load(object sender, EventArgs e)
		{

			//_dtERP_Orders = new ProductionDAL().GetPendingProductionOrderList(omglobal.SysConnectionString);

			_dtERP_Orders = new ProductionDAL().GetPendingProductionOrderList1();
			rdoTransform.Checked = true;
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{

			switch (_jobType)
			{
				case ProductionJobType.Production:
					this.DocumentNo = dgv["DI_REF", e.RowIndex].Value.ToString();
					this.DocumentDate = Convert.ToDateTime(dgv["REQ_DATE", e.RowIndex].Value);
					this.IssueId = Convert.ToInt32(dgv["DI_KEY", e.RowIndex].Value);
					this.DocumentInfo = dgv["REMARK", e.RowIndex].Value.ToString();
					this.Qty = Convert.ToDecimal(dgv["Qty", e.RowIndex].Value.ToString());
					this.PartNo = dgv["PARTNO", e.RowIndex].Value.ToString();
					this.PartName = dgv["PARTNAME", e.RowIndex].Value.ToString();
					this.Unit = dgv["UNIT", e.RowIndex].Value.ToString();
					this.JobType = _jobType;
					break;

				case ProductionJobType.Project:
					this.DocumentNo = dgv["PRJ_CODE", e.RowIndex].Value.ToString();
					this.DocumentDate = Convert.ToDateTime(dgv["PRJ_FM_DATE", e.RowIndex].Value);
					this.IssueId = Convert.ToInt32(dgv["PRJ_KEY", e.RowIndex].Value);
					this.DocumentInfo = $"{dgv["PRJ_NAME", e.RowIndex].Value.ToString()}\n{dgv["PRJ_REMARK", e.RowIndex].Value.ToString()}";
					this.JobType = _jobType;
					break;
			}

			UpdateUI();
		}


		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		#region class helper methods

		private void UpdateUI()
		{
			btnSelect.Enabled = (IssueId > 0);
			txtRequestFilter.Text = (this.dgv.Rows.Count == 0) ? "" : txtRequestFilter.Text;
			txtRequestFilter.Enabled = (this.dgv.Rows.Count > 0);
			btnSearchRequest.Enabled = !String.IsNullOrEmpty(txtRequestFilter.Text);

			this.lbCount.Text = $"found # {dgv.Rows.Count} row(s)";

		} // end UpdateUI

		private void UpdateUI2(ProductionJobType jobType)
		{
			switch (jobType)
			{
				case ProductionJobType.Production:
					pnlLeft.Visible = true;
					splitter1.Visible = pnlLeft.Visible;
					pnlTopRight.Visible = pnlLeft.Visible;
					break;

				case ProductionJobType.Project:
					pnlLeft.Visible = false;
					splitter1.Visible = pnlLeft.Visible;
					pnlTopRight.Visible = pnlLeft.Visible;
					break;
			}
		}

		private void GetProjectList()
		{
			dgv.SuspendLayout();

			// clear content
			dgv.DataSource = null;
			dgv.Rows.Clear();
			dgv.Columns.Clear();

			var _pd = new ProductionDAL();
			var _dt = _pd.GetProjects(omglobal.SysConnectionString);

			// get total rows
			_rowCount = _dt.Rows.Count;

			dgv.DataSource = _dt;
			dgv.Columns["PRJ_KEY"].Visible = false;
			dgv.Columns["PERIOD"].Visible = false;
			dgv.Columns["YEAR"].Visible = false;

			dgv.Columns["PRJ_CODE"].HeaderText = "Project Number";
			dgv.Columns["PRJ_NAME"].HeaderText = "Description";
			dgv.Columns["PRJ_FM_DATE"].HeaderText = "Date";
			dgv.Columns["PRJ_FM_DATE"].DefaultCellStyle = DataGridViewSettingStyle.DateCellStyle();
			dgv.Columns["PRJ_REMARK"].HeaderText = "Remark!";

			dgv.ResumeLayout();

			UpdateUI();
		}

		private async void GetProductionCodeListAsync()
		{
			// clear all content
			dgvProductionCode.DataSource = null;
			dgvProductionCode.Rows.Clear();
			dgvProductionCode.Columns.Clear();

			var _pd = new ProductionDAL();
			var dt = await _pd.GetProductionJobCodeListAsync(OMShareProduction.ProductionRequestCode);

			dgvProductionCode.SuspendLayout();

			dgvProductionCode.ColumnHeadersVisible = false;
			dgvProductionCode.CellBorderStyle = DataGridViewCellBorderStyle.None;
			dgvProductionCode.DataSource = dt;
			dgvProductionCode.Columns["DT_DOCCODE"].DefaultCellStyle.Font = new System.Drawing.Font(dgvProductionCode.Font, System.Drawing.FontStyle.Bold);
			dgvProductionCode.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvProductionCode.ResumeLayout();

			this.UpdateUI();

		} // end GetProductionCodeList


		//private void GetYearOrderList(string CodePrefix)
		//{
		//	// clear all content in datagridView
		//	this.dgv.DataSource = null;
		//	this.dgv.Rows.Clear();
		//	this.dgv.Columns.Clear();

		//	var _pd = new ProductionDAL();
		//	//cbxYearRequest.DataSource = await _pd.GetProductionYearListAsync(DocumentPrefixId);
		//	cbxYearRequest.DataSource = _pd.GetProductionYearList(CodePrefix, omglobal.SysConnectionString);
		//	cbxYearRequest.DisplayMember = "DOC_YEAR";
		//	cbxYearRequest.ValueMember = "DOC_YEAR";
		//	cbxYearRequest.SelectedIndex = 0;

		//} // end GetYearOrderList

		//private void GetProductionList(string codePrefix, int productionYear)
		private void GetProductionList(string codePrefix)
		{
			dgv.SuspendLayout();

			// clear content
			dgv.DataSource = null;
			dgv.Rows.Clear();
			dgv.Columns.Clear();

			//var _pd = new ProductionDAL();
			//var _dt = _pd.GetProductionOrderList(codePrefix, productionYear, omglobal.SysConnectionString);
			//var _dt = _pd.GetProductionOrderList(codePrefix, omglobal.SysConnectionString);

			_dtERP_Orders.DefaultView.RowFilter = $"code = '{codePrefix}'";


			// get total rows
			//_rowCount = _dt.Rows.Count;
			_rowCount = _dtERP_Orders.Rows.Count;
			dgv.DataSource = _dtERP_Orders;

			dgv.Columns["DI_ACTIVE"].Visible = false;
			dgv.Columns["CODE"].Visible = false;
			dgv.Columns["DI_KEY"].Visible = false;
			dgv.Columns["PERIOD"].Visible = false;
			dgv.Columns["YEAR"].Visible = false;

			//dgv.Columns["REVISION"].Visible = false;
			//dgv.Columns["SUB-DI"].Visible = false;


			dgv.Columns["DI_REF"].HeaderText = "[ERP] Order Number";
			dgv.Columns["REQ_DATE"].HeaderText = "Date";
			dgv.Columns["REQ_DATE"].DefaultCellStyle = DataGridViewSettingStyle.DateCellStyle();
			dgv.Columns["QTY"].DefaultCellStyle.Format = "N2";
			dgv.Columns["REMARK"].HeaderText = "DESCRIPTION";

			dgv.ResumeLayout();

			UpdateUI();

		} // end GetProductionTransformList

		#endregion

		private void btnFindData_Click(object sender, EventArgs e)
		{
			//GetProductionList(ProductionCode, _selectedProductionYear);
			GetProductionList(ProductionCode);
		}

		private void txtRequestFilter_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void btnSearchRequest_Click(object sender, EventArgs e)
		{
			// filtring data from DataGrid
			((DataTable)dgv.DataSource).DefaultView.RowFilter = $"DI_REF LIKE '%{txtRequestFilter.Text}%'";

			// updating UI
			txtRequestFilter.Text = "";
			UpdateUI();
		}

		private void txtRequestFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnSearchRequest.PerformClick();
			}
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			this.JobType = _jobType;
		}


		private void cbxYearRequest_SelectionChangeCommitted(object sender, EventArgs e)
		{
			//dgv.DataSource = null;
			//dgv.Rows.Clear();
			//dgv.Columns.Clear();
		}

		private void dgvProductionCode_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			Text = dgvProductionCode["NAME", e.RowIndex].Value.ToString();
			//ProductionCode = dgvProductionCode["DT_DOCCODE",e.RowIndex].Value.ToString();
			ProductionCode = dgvProductionCode["DT_DOCCODE", e.RowIndex].Value.ToString();

			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.ResumeLayout();


			//GetYearOrderList(ProductionCode);
			GetProductionList(ProductionCode); //, _selectedProductionYear);

		}

		private void rdo_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton rdo = sender as RadioButton;

			if (rdo.Checked)
			{
				string _tag = rdo.Tag.ToString();

				// loading data
				switch (_tag)
				{
					case "RM":
						_jobType = ProductionJobType.Production;
						GetProductionCodeListAsync();
						break;

					case "PJ":
						_jobType = ProductionJobType.Project;
						GetProjectList();
						break;
				}

				this.JobType = _jobType;

				UpdateUI2(_jobType);

				lbJobType.Text = $"({_tag} {(int)_jobType})";
			}
		}


		private void cbxYearRequest_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedProductionYear = Convert.ToInt32(cbxYearRequest.SelectedValue);
			}
			catch
			{
				_selectedProductionYear = DateTime.Today.Year;
			}
		}
	}
}