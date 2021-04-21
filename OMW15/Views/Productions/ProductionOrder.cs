using OMControls;
using OMW15.ModelDataExtend;
using OMW15.Models.ProductionModel;
using OMW15.Models.WarehouseModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static OMW15.Shared.OMShareProduction;

namespace OMW15.Views.Productions
{
	public partial class ProductionOrder : Form
	{
		#region class field member

		private PRODUCTIONJOB _job = new PRODUCTIONJOB();

		private ProductionJobType _jobType = ProductionJobType.Production;
		private ActionMode _mode = ActionMode.None;
		private string _productionOrderNo = string.Empty;
		private int _productionJobHeaderId = 0;
		private int _selectedOutsourceItem = 0;
		private int _epr_order_id = 0;
		private int _jobStatus = (int)OMShareProduction.ProductionJobStatus.None;
		private int _totalStep = 0;

		private decimal _stdProductionHr = 0m;
		private decimal _stdMaterialCost = 0m;
		private decimal _totalProductionHrs = 0m;
		private decimal _totalOutsourceCost = 0m;

		#endregion

		#region Constructor

		public ProductionOrder(int ProductionJobId, string ProductionOrderNo, int EPR_ID)
		{
			InitializeComponent();

			OMUtils.SettingDataGridView(ref dgvIssues);
			OMUtils.SettingDataGridView(ref dgvWorkHour);
			OMUtils.SettingDataGridView(ref dgvHourStat);
			OMUtils.SettingDataGridView(ref dgvOutsourceItems);

			pnlWorkInfo.Visible = (omglobal.PermisionId >= (int)Shared.OMShareSysConfigEnums.UserPermission.Admin);

			_productionJobHeaderId = ProductionJobId;
			_productionOrderNo = ProductionOrderNo;
			_epr_order_id = EPR_ID;
			_mode = string.IsNullOrEmpty(_productionOrderNo) ? ActionMode.Add : ActionMode.Edit;

			lbMode.Text = _mode.ToString();

			tc.TabPages[0].Text = $"Production Hours";
		}

		#endregion

		#region class property
		public int WorkYear { get; set; }

		#endregion

		private void ProductionOrder_Load(object sender, EventArgs e)
		{
			GetProductionStatus();
			if (_mode == ActionMode.Edit)
			{
				GetProductionOrderHeaderInfo(_productionOrderNo);
			}
			UpdateUI();
		}

		private void FindFormulaInfo(int erpOrderId)
		{
			DataTable _formulaDt = new BOMDal().GetFormulaHeaderInfo(erpOrderId);

			foreach(DataRow dr in _formulaDt.Rows)
			{
				txtFormulaName.Text = dr["FORMULA_NO"].ToString();
				txtFormulaName.Tag = $"{dr["TRD_B_GROUP"].ToString()}";
				lbFormulaKey.Text = $"{dr["TRD_B_GROUP"].ToString()}";
			}
		}


		private void btnSearchDocNo_Click(object sender, EventArgs e)
		{
			using (var _di = new ERPPDList())
			{
				_di.StartPosition = FormStartPosition.CenterParent;
				_di.FormBorderStyle = FormBorderStyle.Sizable;
				if (_di.ShowDialog(this) == DialogResult.OK)
				{
					_jobType = _di.JobType;
					lbJobType.Text = $"{(int)_jobType} - {_jobType.ToString()}";
					txtDINumber.Text = _productionOrderNo = _di.DocumentNo;
					txtDIDate.Text = _di.DocumentDate.ToShortDateString();
					txtDIInfo.Text = _di.DocumentInfo;
					_epr_order_id = _di.ERPOrderId;

	
					if (_mode == ActionMode.Add)
					{
						_job = new PRODUCTIONJOB();
						_job.AUDITUSER = omglobal.UserName;
						_job.COMPLETEDATE = null;
						_job.CREATEDATE = _di.DocumentDate;
						_job.CUSTCODE = "";
						_job.CUSTOMERNAME = "";
						_jobStatus = (int)OMShareProduction.ProductionJobStatus.Active;
						_job.DUEDATE = DateTime.Today.AddDays(5);
						_job.DAYREMAIN = 5;
						_job.DRAWINGNO = "";
						_job.DRAWINGREV = "";
						_job.JOBTYPE = _jobType == ProductionJobType.Production
										? ((int)ProductionJobType.Production).ToString()
										: ((int)ProductionJobType.Project).ToString();
						_job.ERP_DI = _epr_order_id;
						// finding formula info
						//FindFormulaInfo(_di.ERPOrderId);
						_job.FORMULA_ID = 0;
						_job.FORMULA_NUMBER = "";

						_job.ERP_ORDER = _di.DocumentNo;
						_job.ERP_ORDERINFO = _di.DocumentInfo;
						_job.ISSUE_ID = _di.ERPOrderId;
						_job.ERP_ISSUE = "";
						_job.ITEMNAME = _di.PartName;
						_job.ITEMNO = _di.PartNo;
						_job.ITEMNOTE = "";
						_job.JOBYEAR = _di.DocumentDate.Year;
						_job.LABOUR_HR_COST = 0m;
						_job.LASTMODIFY = DateTime.Today;
						_job.MODIUSER = omglobal.UserName;
						_job.QORDER = _di.Qty;
						_job.RELEASEDATE = DateTime.Today;
						_job.SHIPQTY = 0m;
						_job.REMAINQTY = _job.QORDER - _job.SHIPQTY;
						_job.SN = "";
						_job.STATUS = _jobStatus;
						_job.STD_MATCOST = 0m;
						_job.STD_UNITHOUR = 0m;
						_job.TOTAL_OUTSOURCE_COST = 0m;
						_job.TOTAL_HOURS = 0m;
						_job.TOTAL_HOUR_COST = 0m;
						_job.TOTAL_MAT_COST = 0m;
						_job.TOTAL_PRODUCTION_COST = 0m;
						_job.UNITORDER = _di.Unit;

						// get more item property
						if (_jobType == ProductionJobType.Production)
						{
							DataTable _itemProperty = GetItemProperties(_di.PartNo);
							if (_itemProperty != null)
							{
								foreach (DataRow dr in _itemProperty.Rows)
								{
									_job.DRAWINGNO = dr["DrawingNo"].ToString();
									_job.DRAWINGREV = dr["DrawingRev"].ToString();
									txtSheetNo.Text = dr["SheetNo"].ToString();
									_totalStep = Convert.ToInt32(dr["Total_Step"]);
									break;
								}
								StepAlert(_totalStep);
							}
						}
					}

					// loading production order
					GetProductionOrderHeaderInfo(_productionOrderNo);
				}
			}
		}

		private DataTable GetItemProperties(string itemNo) => new ProductionDAL().GetProductionItemProperty(itemNo);

		private void StepAlert(int totalStep)
		{
			if (_jobType != ProductionJobType.Project)
			{
				if (totalStep > 0)
				{
					lbTotalStep.Text = $"มี {totalStep} ขั้นตอนการผลิต";
				}
				else
				{
					MessageBox.Show($"รายการนี้ไม่มีการระบุขั้นตอนการผลิตทำให้ไม่สามารถเปิดใบงานได้ \n\n กรุณาตรวจสอบขั้นตอนการผลิตในชิ้นส่วนมาตรฐานก่อน", "PRODUCTION STEP", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void txt_TextChanged(object sender, EventArgs e) => UpdateUI();

		private void btnItemNo_Click(object sender, EventArgs e) => GetItemInformation(txtItemNo.Text);

		private void btnCancel_Click(object sender, EventArgs e) => this.Close();

		private void txtDINumber_TextChanged(object sender, EventArgs e) => UpdateUI();
	
		private void btnSave_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(txtQty.Text)
					|| Convert.ToDecimal(txtQty.Text) == 0.00m
					|| String.IsNullOrEmpty(txtUnit.Text))
			{
				if (MessageBox.Show("จำนวนผลิตชิ้นงาน = 0 หรือ หน่วยนับ เป็นค่าว่าง \n ต้องการยืนยันหรือไม่", "จำนวนผลิตชิ้นงาน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				{
					return;
				}
			}

			UpdateProductionJobInfo();

			Close();
		}

		private void cbxStatus_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_jobStatus = Convert.ToInt32(cbxStatus.SelectedValue);
			}
			catch
			{
				_jobStatus = 0;
			}

			_job.STATUS = _jobStatus;

			checkStatusChanged(_job.STATUS);

			UpdateUI();
		}

		#region class helper methods

		private void UpdateOutsourceToolBar()
		{
			tsbtnEditSup.Enabled = (_selectedOutsourceItem > 0);
			tsbtnDeleteSup.Enabled = tsbtnEditSup.Enabled;
		}

		private void checkStatusChanged(int status)
		{
			switch (status)
			{
				case (int)ProductionJobStatus.Closed:
					if (MessageBox.Show("ต้องการนำส่งชิ้นงานไปที่คลังสินค้าหรือไม่?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						btnReceiveStock.PerformClick();
						// activate runtine for stock receiving
						//if (String.IsNullOrEmpty(_job.RECEIVEDBY))
						//	_job.RECEIVEDBY = omglobal.UserName;
						//if (_job.RECEIVEDDATE == null)
						//	_job.RECEIVEDDATE = DateTime.Today;
					}
					break;
				default:
					break;
			}
		}

		private void UpdateUI()
		{
			grpPrdHeadInfo.Enabled = !string.IsNullOrEmpty(txtDINumber.Text);
			txtDINumber.Enabled = (_mode == ActionMode.Add);
			btnSearchDocNo.Enabled = txtDINumber.Enabled;

			// Show / hide for job complete date
			lbCompleteDate.Visible = _jobStatus == (int)OMShareProduction.ProductionJobStatus.Closed;
			dtpCompleteDate.Visible = lbCompleteDate.Visible;
			pnlStockReceive.Visible = lbCompleteDate.Visible;

			btnSave.Enabled = (!String.IsNullOrEmpty(txtDINumber.Text)
									&& (_job.QORDER > 0)
									&& (_jobType == ProductionJobType.Production ? (_totalStep > 0) : true)
									&& !String.IsNullOrEmpty(txtUnit.Text));

		} // end UpdateUI

		private void GetProductionOrderHeaderInfo(string ProductionOrderNo)
		{
			lbMode.Text = _mode.ToString();
			if (_mode == ActionMode.Edit)
			{
				_job = new ProductionDAL().GetProductionJobHeader(ProductionOrderNo);
				_productionJobHeaderId = _job.PDJOBID;
				_stdMaterialCost = _job.STD_MATCOST;
				_stdProductionHr = _job.STD_UNITHOUR;
				_totalProductionHrs = _job.TOTAL_HOURS;
				_totalOutsourceCost = _job.TOTAL_OUTSOURCE_COST;
				_jobStatus = _job.STATUS;

				if(_jobStatus == 2) // close
				{
					dtpCompleteDate.Value = _job.COMPLETEDATE.Value;
				}
			}

			dtpReleaseDate.Value = _job.RELEASEDATE.Value;
			dtpDueDate.Value = _job.DUEDATE.Value;
			txtDrawingRev.Text = _job.DRAWINGREV;

			txtDINumber.Text = _job.ERP_ORDER;
			txtDIInfo.Text = _job.ERP_ORDERINFO;
			txtDIDate.Text = _job.CREATEDATE.Value.ToShortDateString();

			if (String.IsNullOrEmpty(_job.JOBTYPE))
			{
				lbJobType.Text = $"{(int)ProductionJobType.Production} - {ProductionJobType.Production.ToString()}";
				_jobType = (int)ProductionJobType.Production;
			}
			else
			{
				lbJobType.Text = $"{int.Parse(_job.JOBTYPE)} - {Enum.GetName(typeof(ProductionJobType), int.Parse(_job.JOBTYPE))}";
				_jobType = int.Parse(_job.JOBTYPE) == 0 ? ProductionJobType.Production : ProductionJobType.Project;
			}

			cbxStatus.SelectedValue = _job.STATUS;
			txtItemNo.Text = _job == null ? "" : _job.ITEMNO;
			txtItemName.Text = _job == null ? "" : _job.ITEMNAME;
			txtDrawingNo.Text = _job == null ? "" : _job.DRAWINGNO;
			txtSerialNo.Text = _job == null ? "" : _job.SN;
			txtQty.Text = $"{(_job == null ? 0.00m : _job.QORDER):N2}";
			txtUnit.Text = _job == null ? "" : _job.UNITORDER;

			if (_job.FORMULA_ID == 0)
			{
				FindFormulaInfo(_job.ERP_DI);
				_job.FORMULA_NUMBER = txtFormulaName.Text;
				_job.FORMULA_ID = Convert.ToInt32(lbFormulaKey.Text);
			}
			else
			{
				txtFormulaName.Text = _job.FORMULA_NUMBER;
				txtFormulaName.Tag = _job.FORMULA_ID;
				lbFormulaKey.Text = $"{_job.FORMULA_ID}";
			}

			//txtERP_ISSUE.Text = String.IsNullOrEmpty(_job.ERP_ISSUE) ? "" : _job.ERP_ISSUE;

			txtTotalReceiveQty.Text = $"{_job.SHIPQTY:N2}";
			txtOutsourceCost.Text = $"{(_job == null ? 0.00m : _job.TOTAL_OUTSOURCE_COST):N2}";
			txtTotalMatCost.Text = $"{(_job == null ? 0.00m : _job.TOTAL_MAT_COST):N2}";
			txtTotalProductionHrs.Text = $"{(_job == null ? 0.00m : _job.TOTAL_HOURS):N2}";
			txtTotalActualCost.Text = $"{(_job == null ? 0.00m : _job.TOTAL_HOUR_COST):N2}";
			pic.Image = new WHDDAL().getItemMasterImage(_job.ITEMNO);

			using (DataTable dt = GetItemProperties(txtItemNo.Text))
			{
				foreach (DataRow dr in dt.Rows)
				{
					_totalStep = Convert.ToInt32(dr["TOTAL_STEP"].ToString());
				}

				StepAlert(_totalStep);
			}
 
			// Require permission to display some serect infomation
			if (omglobal.PermisionId >= (int)Shared.OMShareSysConfigEnums.UserPermission.PowerUser)
			{
				try
				{
					if (int.Parse(_job.JOBTYPE) == (int)ProductionJobType.Production)
					{
						GetIssues(_job.ERP_ORDER);

						// check and retrieve data for issue items for this order
						//
						//IssueRequestHeader _issue = new ProductionDAL().FindIssueHeader(_job.ERP_ORDER);
						//if (_issue != null)
						//{
						//	_job.ERP_ISSUE = _issue.ISSUENO;
						//	_job.ISSUE_ID = _issue.ISSUEID;
						//	tc.TabPages[0].Text = $"Production Hours"; // ({_issue.ISSUEID} : {_issue.ISSUENO})";
						//}
					}
					else
					{
						_job.TOTAL_MAT_COST = 0m;
						_job.STD_MATCOST = 0m;
						_job.TOTAL_OUTSOURCE_COST = 0m;
					}
				}
				catch
				{
					_job.TOTAL_MAT_COST = 0m;
					_job.STD_MATCOST = 0m;
					_job.TOTAL_OUTSOURCE_COST = 0m;
				}

				// Get Production Jobinfo
				GetProductionHours(_job.ERP_ORDER);

				// Get outsource data
				GetOutsourceItems(_job.ERP_ORDER);

				// Cal stat from productionJobInfo
				HourStat(_job.ERP_ORDER);
			}
			UpdateUI();

		} // end GetProductionOrderHeaderInfo

		private void GetOutsourceItems(string erpOrder)
		{
			dgvOutsourceItems.SuspendLayout();

			// get outsource items
			dgvOutsourceItems.DataSource = new SupplierDAL().GetProductionOutsourceList(erpOrder);

			dgvOutsourceItems.Columns["Id"].Visible = false;
			dgvOutsourceItems.Columns["ERP_ORDER"].Visible = false;
			dgvOutsourceItems.Columns["AP_CODE"].Visible = false;
			dgvOutsourceItems.Columns["DRAWING_REV"].Visible = false;

			dgvOutsourceItems.Columns["AP_NAME"].HeaderText = "ผู้รับจ้าง / ผู้ผลิต / ผุ้จัดจำหน่าย";
			dgvOutsourceItems.Columns["DATESTART"].HeaderText = "วันที่เริ่ม";
			dgvOutsourceItems.Columns["DATEFINISH"].HeaderText = "วันที่เสร็จ";
			dgvOutsourceItems.Columns["STEP"].HeaderText = "ลำดับการผลิต";
			dgvOutsourceItems.Columns["BUILD_DETAIL"].HeaderText = "รายละเอียด";
			dgvOutsourceItems.Columns["BUILD_QTY"].HeaderText = "จำนวนผลิต";
			dgvOutsourceItems.Columns["BUILD_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvOutsourceItems.Columns["UNIT"].HeaderText = "หน่วย";
			dgvOutsourceItems.Columns["MATERIAL_COST"].HeaderText = "ค่าวัสดุ";
			dgvOutsourceItems.Columns["MATERIAL_COST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvOutsourceItems.Columns["LABOR_COST"].HeaderText = "ค่าจ้าง";
			dgvOutsourceItems.Columns["LABOR_COST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvOutsourceItems.Columns["OTHER_COST"].HeaderText = "ค่าใช้จ่ายอื่นๆ";
			dgvOutsourceItems.Columns["OTHER_COST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvOutsourceItems.Columns["TOTAL_COST"].HeaderText = "ค่าใช้จ่ายรวม";
			dgvOutsourceItems.Columns["TOTAL_COST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvOutsourceItems.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			dgvOutsourceItems.Columns["ITEMNAME"].HeaderText = "ชื่อสินค้า";
			dgvOutsourceItems.Columns["DRAWINGNO"].HeaderText = "หมายเลขแบบ";

			dgvOutsourceItems.ResumeLayout();

			lbOutsourceRows.Text = $"{dgvOutsourceItems.Rows.Count} รายการ";

			txtOutsourceCost.Text = $"{GetOutsourceValues():N2}";

			UpdateOutsourceToolBar();
		}

		private decimal GetOutsourceValues()
		{
			decimal _result = 0.00m;

			foreach (DataGridViewRow dgr in dgvOutsourceItems.Rows)
			{
				_result += Convert.ToDecimal(dgr.Cells["TOTAL_COST"].Value);
			}
			return _result;
		}

		private void HourStat(string productionJob)
		{
			dgvHourStat.SuspendLayout();
			dgvHourStat.DataSource = new ProductionDAL().ProductionHourStatByOrder(productionJob);
			dgvHourStat.Columns["Days"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvHourStat.Columns["NormalTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvHourStat.Columns["Overtime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvHourStat.Columns["TotalTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvHourStat.Columns["AvgHourDay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvHourStat.Columns["AvgOTDay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dgvHourStat.Columns["NormalTime"].DefaultCellStyle.Format = "N2";
			dgvHourStat.Columns["Overtime"].DefaultCellStyle.Format = "N2";
			dgvHourStat.Columns["TotalTime"].DefaultCellStyle.Format = "N2";
			dgvHourStat.Columns["AvgHourDay"].DefaultCellStyle.Format = "N2";
			dgvHourStat.Columns["AvgOTDay"].DefaultCellStyle.Format = "N2";

			dgvHourStat.Columns["Name"].HeaderText = "พนักงาน";
			dgvHourStat.Columns["Days"].HeaderText = "จำนวนวันทำงาน";
			dgvHourStat.Columns["NormalTime"].HeaderText = "จำนวนชั่วโมงทำงานปรกติ";
			dgvHourStat.Columns["Overtime"].HeaderText = "จำนวนชั่วโมงทำงานล่วงเวลา";
			dgvHourStat.Columns["TotalTime"].HeaderText = "จำนวนชั่วโมงทำงานรวม";
			dgvHourStat.Columns["AvgHourDay"].HeaderText = "ชั่วโมงทำงานเฉลี่ย/วัน";
			dgvHourStat.Columns["AvgOTDay"].HeaderText = "ชั่วโมงทำงานล่วงเวลาเฉลี่ย/วัน";

			dgvHourStat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			dgvHourStat.ResumeLayout();

			lbStatCount.Text = $"{dgvHourStat.Rows.Count} รายการ";
		}

		private void GetProductionHours(string productionJob)
		{
			DataTable dt = new ProductionDAL().GetProductionHourByOrder(productionJob);
			dgvWorkHour.SuspendLayout();
			dgvWorkHour.DataSource = dt;

			dgvWorkHour.Columns["PROCESSID"].Visible = false;
			dgvWorkHour.Columns["Id"].Visible = false;
			dgvWorkHour.Columns["TIME_CAT"].Visible = false;
			dgvWorkHour.Columns["HOURCOST"].Visible = false;

			dgvWorkHour.Columns["HOURRATE"].Visible = false;

			dgvWorkHour.Columns["WORKERID"].HeaderText = "รหัสพนักงาน";
			dgvWorkHour.Columns["WORKERNAME"].HeaderText = "พนักงาน";
			dgvWorkHour.Columns["PROCESSNAME"].HeaderText = "ขั้นตอนการปฏิบัติงาน";
			dgvWorkHour.Columns["starttime"].HeaderText = "เริ่ม";
			dgvWorkHour.Columns["endtime"].HeaderText = "สิ้นสุด";
			dgvWorkHour.Columns["NORMAL"].HeaderText = "จำนวนชั่วโมงทำงานปรกติ";
			dgvWorkHour.Columns["OT"].HeaderText = "จำนวนชั่วโมงทำงานล่วงเวลา";
			dgvWorkHour.Columns["TOTAL"].HeaderText = "จำนวนชั่วโมงทำงานรวม";
			dgvWorkHour.Columns["INPROCESS_QTY"].HeaderText = "งานระหว่างทำ";
			dgvWorkHour.Columns["GOOD_QTY"].HeaderText = "งานดี";
			dgvWorkHour.Columns["BAD_QTY"].HeaderText = "งานเสีย";
			dgvWorkHour.Columns["TOTALQTY"].HeaderText = "ปริมาณงาน";

			dgvWorkHour.Columns["NORMAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvWorkHour.Columns["OT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvWorkHour.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvWorkHour.Columns["TOTALQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvWorkHour.Columns["INPROCESS_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvWorkHour.Columns["GOOD_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvWorkHour.Columns["BAD_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dgvWorkHour.Columns["NORMAL"].DefaultCellStyle.Format = "N2";
			dgvWorkHour.Columns["OT"].DefaultCellStyle.Format = "N2";
			dgvWorkHour.Columns["TOTAL"].DefaultCellStyle.Format = "N2";
			dgvWorkHour.Columns["NORMAL"].DefaultCellStyle.Format = "N2";
			dgvWorkHour.Columns["TOTALQTY"].DefaultCellStyle.Format = "N2";
			dgvWorkHour.Columns["INPROCESS_QTY"].DefaultCellStyle.Format = "N2";
			dgvWorkHour.Columns["GOOD_QTY"].DefaultCellStyle.Format = "N2";
			dgvWorkHour.Columns["BAD_QTY"].DefaultCellStyle.Format = "N2";

			dgvWorkHour.ResumeLayout();
			lbHourCount.Text = $"{dt.Rows.Count} รายการ";

			// calculate Hour cost
			GetJobHours(productionJob);
		}

		private void GetIssues(string orderNo)
		{
			dgvIssues.SuspendLayout();
			DataTable dt = new ProductionDAL().GetIssueByProductionOrder(orderNo);

			if (dt == null)
			{
				dgvIssues.DataSource = null;
				return;
			}

			dgvIssues.DataSource = dt;

			// formatting DataGridView
			dgvIssues.Columns["RECEIVEID"].Visible = false;
			dgvIssues.Columns["REF_ISSUE_ID"].Visible = false;
			dgvIssues.Columns["REF_TRANSFER_DOC"].Visible = false;
			dgvIssues.Columns["RECEIVE_BY"].Visible = false;

			dgvIssues.Columns["RECEIVE_NO"].HeaderText = "เลขที่ใบแปร";
			dgvIssues.Columns["RECEIVE_DATE"].HeaderText = "วันที่เบิก";
			dgvIssues.Columns["RECEIVE_DATE"].DefaultCellStyle.Format = "dd/MM/yyyy";
			dgvIssues.Columns["RECEIVE_UNIT"].HeaderText = "หน่วย";
			dgvIssues.Columns["RECEIVE_QTY"].HeaderText = "จำนวนที่ใช้";
			dgvIssues.Columns["RECEIVE_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvIssues.Columns["RECEIVE_QTY"].DefaultCellStyle.Format = "N2";

			dgvIssues.Columns["RECEIVE_AVG_UCOST"].HeaderText = "ต้นทุน/หน่วย";
			dgvIssues.Columns["RECEIVE_AVG_UCOST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvIssues.Columns["RECEIVE_AVG_UCOST"].DefaultCellStyle.Format = "N2";

			dgvIssues.Columns["RECEIVE_COST"].HeaderText = "มูลค่ารวม";
			dgvIssues.Columns["RECEIVE_COST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvIssues.Columns["RECEIVE_COST"].DefaultCellStyle.Format = "N2";

			dgvIssues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			dgvIssues.ResumeLayout();

			decimal _totalMatCost = dt.AsEnumerable().Sum(x => x.Field<decimal>("RECEIVE_COST"));
			_job.TOTAL_MAT_COST = _totalMatCost;
			_job.STD_MATCOST = _totalMatCost / (_job.QORDER == 0 ? 1 : _job.QORDER);

			lbIssueCount.Text = $"{dt.Rows.Count} รายการ";
			txtTotalMatCost.Text = $"{_job.TOTAL_MAT_COST:N2}";
			txtMatCost.Text = $"{_job.STD_MATCOST:N2}";
		}

		private void GetJobHours(string erpOrder)
		{
			DataTable dt = new ProductionDAL().GetSummaryActualHourCost(erpOrder, omglobal.SysConnectionString);

			if (dt != null && dt.Rows.Count > 0)
			{
				_job.TOTAL_HOURS = Convert.ToDecimal(dt.Rows[0]["TOTAL_HRS"]);
				_job.TOTAL_HOUR_COST = Convert.ToDecimal(dt.Rows[0]["TOTAL_ACTUAL_HOUR_COST"]);
				ntxtTotalActualAvgCost.Text = $"{Convert.ToDecimal(dt.Rows[0]["TOTAL_ACTUAL_AVG_HOUR_COST"]):N2}";
			}
			else
			{
				_job.TOTAL_HOURS = 0m;
				_job.TOTAL_HOUR_COST = 0m;
				ntxtTotalActualAvgCost.Text = $"{0:N2}";
			}

			txtTotalProductionHrs.Text = $"{_job.TOTAL_HOURS:N2}";
			txtTotalActualCost.Text = $"{_job.TOTAL_HOUR_COST:N2}";

			decimal _unitHourCost = (_job.TOTAL_HOUR_COST / (_job.QORDER == 0 ? 1 : _job.QORDER));

			txtProductionUnitHr.Text = $"{(_job.TOTAL_HOURS / (_job.QORDER == 0 ? 1 : _job.QORDER)):N2}";
			ntxtProductionHrUnitCost.Text = $"{_unitHourCost:N2}";
			ntxtActualAvgUnitCost.Text = $"{(Convert.ToDecimal(ntxtTotalActualAvgCost.Text) / (_job.QORDER == 0 ? 1 : _job.QORDER)):N2}";
		}

		private void GetItemInformation(string itemFilter)
		{
			using (STDParts _p = new STDParts(ActionMode.Selection, itemFilter))
			{
				//_p.ViewMode = ActionMode.Selection;
				//_p.Filter = itemFilter;
				//_p.ItemNo = itemFilter;
				_p.StartPosition = FormStartPosition.CenterParent;

				if (_p.ShowDialog(this) == DialogResult.OK)
				{
					string _itemno = _p.ItemNo;
					if (new ProductionDAL().GetStdProcessList(_itemno).Rows.Count > 0)
					{
						pic.Image = _p.ItemImage;
						txtItemNo.Text = _p.ItemNo;
						txtItemName.Text = _p.ItemName;
						txtUnit.Text = _p.Unit;
						txtDrawingNo.Text = _p.DrawingNo;
						txtDrawingRev.Text = _p.DrawingRevision.ToString();
						txtSheetNo.Text = _p.SheetNo;
						_stdProductionHr = _p.StandardHour;
						_stdMaterialCost = _p.StandardMaterialCost;

						if (_jobType == ProductionJobType.Production)
						{
							_totalStep = _p.TotalStep;
							StepAlert(_totalStep);
						}
					}
					else
					{
						MessageBox.Show($"ไม่มีขั้นตอนการผลิตสำหรับ รหัสสินค้าหมายเลข {_itemno} นี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						this.Close();
					}
				}
			}
		} // end GetItemInformation

		private void UpdateProductionJobInfo()
		{
			_job.ERP_ORDER = txtDINumber.Text;
			_job.ERP_ORDERINFO = txtDIInfo.Text;
			_job.CREATEDATE = Convert.ToDateTime(txtDIDate.Text);
			_job.MODIUSER = omglobal.UserInfo;
			_job.LASTMODIFY = DateTime.Now;
			_job.FORMULA_ID = (txtFormulaName.Tag != null ? Convert.ToInt32(txtFormulaName.Tag.ToString()) : 0);
			_job.FORMULA_NUMBER = txtFormulaName.Text;

			if (_job.STATUS == (int)OMShareProduction.ProductionJobStatus.Closed)
			{
				_job.COMPLETEDATE = dtpCompleteDate.Value;
			}

			_job.RELEASEDATE = dtpReleaseDate.Value;
			_job.JOBYEAR = _job.RELEASEDATE.Value.Year;
			this.WorkYear = _job.JOBYEAR;
			_job.DUEDATE = dtpDueDate.Value;
			_job.ITEMNO = txtItemNo.Text;
			_job.SN = txtSerialNo.Text;
			_job.ITEMNAME = txtItemName.Text;
			_job.ERP_ISSUE = txtERP_ISSUE.Text;
			_job.DRAWINGNO = txtDrawingNo.Text;
			_job.DRAWINGREV = txtDrawingRev.Text;
			_job.UNITORDER = txtUnit.Text;
			_job.TOTAL_OUTSOURCE_COST = Convert.ToDecimal(txtOutsourceCost.Text);
			_job.TOTAL_PRODUCTION_COST = (_job.TOTAL_HOUR_COST + _job.TOTAL_MAT_COST + _job.TOTAL_OUTSOURCE_COST);

			// update PRODUCTONJOBS
			if (new ProductionDAL().UpdateProductionHeader(_job, _productionJobHeaderId) > 0)
			{
				MessageBox.Show("Update Production Job Info successfully !!!!", "Message", MessageBoxButtons.OK,
					  MessageBoxIcon.Information);
			}

			if (_job.STATUS == (int)OMShareProduction.ProductionJobStatus.Closed)
			{
				new ProductionDAL().UpdateItemStandardHour(_job.ITEMNO);
			}


		} // end UpdateProductionJobInfo

		private void GetProductionStatus()
		{
			// job status
			// 0 = none
			// 1 = active
			// 2 = closed
			//
			cbxStatus.DataSource = EnumWithName<OMShareProduction.ProductionJobStatus>.ParseEnum();
			cbxStatus.DisplayMember = "Name";
			cbxStatus.ValueMember = "Value";
		} // end GetProductionStatus

		#endregion

		private void btnUnit_Click(object sender, EventArgs e)
		{
			var _cat = OMShareProduction.ProductionOptionEnum.ItemUnit;
			var _dt = new WHDDAL().getUnitList();

			if (_dt.Rows.Count > 0)
			{
				using (var _opt = new PrdOption(_cat))
				{
					_opt.DataSource = _dt;
					if (_opt.ShowDialog() == DialogResult.OK)
					{
						if (_opt.IsEmptyItem == false)
						{
							txtUnit.Text = _opt.SelectedItem;
						}
					}
				}
			}
			else
			{
				MessageBox.Show("No list available...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void dtpReleaseDate_ValueChanged(object sender, EventArgs e)
		{
			dtpDueDate.Value = dtpReleaseDate.Value.AddDays(30);
			_job.RELEASEDATE = dtpReleaseDate.Value;
			_job.DUEDATE = dtpDueDate.Value;
		}

		private void txtQty_TextChanged(object sender, EventArgs e)
		{
			_job.QORDER = String.IsNullOrEmpty(txtQty.Text) ? 0m : Convert.ToDecimal(txtQty.Text);
			UpdateUI();
		}

		private void dtpDueDate_ValueChanged(object sender, EventArgs e)
		{
			_job.DUEDATE = dtpDueDate.Value;
		}

		private void dtpCompleteDate_ValueChanged(object sender, EventArgs e)
		{
			_job.COMPLETEDATE = dtpCompleteDate.Value;
		}

		private void txtSerialNo_TextChanged(object sender, EventArgs e)
		{
			_job.SN = txtSerialNo.Text;
		}

		private void txtItemNo_TextChanged(object sender, EventArgs e)
		{
			_job.ITEMNO = txtItemNo.Text;

			UpdateUI();
		}

		private void txtItemName_TextChanged(object sender, EventArgs e)
		{
			_job.ITEMNAME = txtItemName.Text;
		}

		private void txtDrawingNo_TextChanged(object sender, EventArgs e)
		{
			_job.DRAWINGNO = txtDrawingNo.Text;
		}

		private void txtDrawingRev_Validated(object sender, EventArgs e)
		{
			_job.DRAWINGREV = txtDrawingRev.Text;
		}

		private void txtUnit_TextChanged(object sender, EventArgs e)
		{
			_job.UNITORDER = txtUnit.Text;
			UpdateUI();
		}

		private void txtTotalMatCost_TextChanged(object sender, EventArgs e)
		{
			_job.TOTAL_MAT_COST = String.IsNullOrEmpty(txtTotalMatCost.Text) ? 0m : Convert.ToDecimal(txtTotalMatCost.Text);
		}

		private void txtTotalProductionHrs_TextChanged(object sender, EventArgs e)
		{
			_job.TOTAL_HOURS = String.IsNullOrEmpty(txtTotalProductionHrs.Text) ? 0m : Convert.ToDecimal(txtTotalProductionHrs.Text);
		}

		private void txtTotalActualCost_TextChanged(object sender, EventArgs e)
		{
			_job.TOTAL_HOUR_COST = Convert.ToDecimal(txtTotalActualCost.Text);
		}

		private void txtItemNo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnItemNo.PerformClick();
			}
		}

		private void tsbthAddSup_Click(object sender, EventArgs e)
		{
			_selectedOutsourceItem = 0;
			using (SupInfo sup = new SupInfo(txtDINumber.Text, _selectedOutsourceItem))
			{
				sup.StartPosition = FormStartPosition.CenterScreen;
				if (sup.ShowDialog(this) == DialogResult.OK)
				{
					GetOutsourceItems(_job.ERP_ORDER);
				}
			}
		}

		private void txtOutsourceCost_TextChanged(object sender, EventArgs e)
		{
			_job.TOTAL_OUTSOURCE_COST = Convert.ToDecimal(txtOutsourceCost.Text);
		}

		private void dgvOutsourceItems_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedOutsourceItem = Convert.ToInt32(dgvOutsourceItems["Id", e.RowIndex].Value.ToString());
			UpdateOutsourceToolBar();
		}

		private void tsbtnEditSup_Click(object sender, EventArgs e)
		{
			using (SupInfo sup = new SupInfo(txtDINumber.Text, _selectedOutsourceItem))
			{
				sup.StartPosition = FormStartPosition.CenterScreen;
				if (sup.ShowDialog(this) == DialogResult.OK)
				{
					GetOutsourceItems(_job.ERP_ORDER);
				}
			}
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetOutsourceItems(_job.ERP_ORDER);
		}

		private void tsbtnDeleteSup_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("ต้องการลบรายการที่เลือก ?", "ลบรายการ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (new SupplierDAL().DeleteOutsourceItem(_selectedOutsourceItem) > 0)
				{
					_selectedOutsourceItem = 0;
					GetOutsourceItems(_job.ERP_ORDER);
				}
			}
		}

		private void dgvOutsourceItems_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEditSup.PerformClick();
		}

		private void btnReceiveStock_Click(object sender, EventArgs e)
		{
			using(var _receiveStock = new ProductionSendStock(_job))
			{
				_receiveStock.StartPosition = FormStartPosition.CenterScreen;
				if(_receiveStock.ShowDialog() == DialogResult.OK)
				{
					_job.TOTAL_MAT_COST = _receiveStock.TotalReceiveCost;
					_job.STD_MATCOST = _receiveStock.AvgReceiveUCost;
					_job.SHIPQTY = _receiveStock.TotalReceiveQty;
					_job.COMPLETEDATE = _receiveStock.ReceiveDate;

					dtpCompleteDate.Value = _job.COMPLETEDATE.Value;
					txtTotalMatCost.Text = $"{_receiveStock.TotalReceiveCost:N2}";
					txtMatCost.Text = $"{_receiveStock.AvgReceiveUCost:N2}";
					txtTotalReceiveQty.Text = $"{_receiveStock.TotalReceiveQty:N2}";
				}
			}
		}

		private void btnFomula_Click(object sender, EventArgs e)
		{
			using(var _formular = new ProductionFormulaBox(txtFormulaName.Text))
			{
				if(_formular.ShowDialog(this) == DialogResult.OK)
				{
					txtFormulaName.Text = _formular.FormulaName;
					txtFormulaName.Tag = _formular.FormulaKey;
					lbFormulaKey.Text = $"{_formular.FormulaKey}";
				}
			}
		}
	}
}