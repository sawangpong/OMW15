using Microsoft.VisualBasic;
using OMW15.Models.ProductionModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Windows.Forms;
using static OMW15.Shared.OMShareProduction;

namespace OMW15.Views.Productions
{
	public partial class PRDHOURSINFO : Form
	{
		#region class field member

		private PRODUCTIONJOBINFO _hr;
		private ActionMode _mode = ActionMode.None;
		private ProductionJobType _jobType = ProductionJobType.Production;
		private WorkingDayCategory _timeCat = WorkingDayCategory.NormalDay;
		private DataTable _dtValidTime = null;
		private DateTime _timeCheckIn = DateTime.Today;
		private DateTime _timeCheckOut = DateTime.Today;
		private int step = 1;
		private int _selectedMachineGroup = 0;
		private int _selectedMachineId = 0;
		private bool canProcessInfo = false;
		private bool _canSaveRecord = false;
		private bool _isFirstLoad = false;
		private int _currentDayOfWeek;
		private string _checkin = "";
		private string _checkout = "";
		private double _normalHourRate = 0d;
		private decimal _validHour = 0m;

		#endregion

		#region class property

		public int RecordId { get; set; }
		public string ERPOrder { get; set; }
		public int RecordAffect { get; set; }
		public string WorkerCode { get; set; }
		public string WorkerName { get; set; }
		public string ItemNo { get; set; }
		public string ItemName { get; set; }
		public string DrawingNo { get; set; }
		public int ItemId { get; set; }
		public decimal QOrder { get; set; }
		public string UnitOrder { get; set; }

		#endregion

		#region OVERLOAD CONSTRUCTOR
		public PRDHOURSINFO(int itemRecordId, string ERP_Order)
		{
			InitializeComponent();
			this.ERPOrder = ERP_Order;
			this.RecordId = itemRecordId;

			UpdateUI();
		}

		public PRDHOURSINFO(int itemRecordId, string ERP_Order, string itemNo, string itemName, string workerCode, string workerName)
		{
			InitializeComponent();

			this.ERPOrder = ERP_Order;
			this.RecordId = itemRecordId;
			this.WorkerCode = workerCode;
			this.WorkerName = workerName;
			this.ItemNo = ItemNo;
			this.ItemName = itemName;

			lbMode.Text = (_mode = this.RecordId == 0 ? ActionMode.Add : ActionMode.Edit).ToString();

			if (itemRecordId == 0)
			{
				this.dtpWorkDate.Value = DateTime.Today;
			}

			lbEmpId.Text = $"{this.WorkerCode}";

			UpdateUI();
		}

		#endregion

		private void PRDHOURSINFO_Load(object sender, EventArgs e)
		{
			// display info
			lbHourRate.Visible = (omglobal.PermisionId >= (int)OMShareSysConfigEnums.UserPermission.Manager);
			txtHourRate.Visible = lbHourRate.Visible;
			lbTotalHrCost.Visible = lbHourRate.Visible;
			txtTotalHourCost.Visible = lbHourRate.Visible;

			lbTotalHourError.Visible = false;

			rdoWorkingday.Checked = true;
			grpPdHour.Text = $"Production Time Record : [{this.RecordId}]";

			/////////////////////////////
			// load data
			/////////////////////////////

			_isFirstLoad = _mode == ActionMode.Edit ? true : false;
			GetMachineGroup();
			GetProductionHourRecord(this.RecordId);

			_isFirstLoad = false;
		}

		private void dtpWorkTime_ValueChanged(object sender, EventArgs e) => CalWorkTime(dtpWorkTimeStart.Value);

		private void btnProcess_Click(object sender, EventArgs e)
			=> GetWorkProcess(this.ItemId, this.txtItemNo.Text, this.txtItemName.Text);

		private void txtWorker_TextChanged(object sender, EventArgs e) => UpdateUI();

		private void btnSave_Click(object sender, EventArgs e) => UpdateProductionTimeInfo();

		private void rdoWorkingday_CheckedChanged(object sender, EventArgs e)
		{
			var rdo = sender as RadioButton;

			if (rdo.Checked)
			{
				if (rdo.Tag.ToString() == "NORMAL")
				{
					_timeCat = OMShareProduction.WorkingDayCategory.NormalDay;
					chkgNormalTime.Checked = true;
				}
				else
				{
					_timeCat = OMShareProduction.WorkingDayCategory.Holiday;
					if (_currentDayOfWeek == 0)
					{
						chkgOT.Text = "ล่วงเวลา(08:00 - 17:00)";
						chkgOT.Checked = true;
					}
					else
					{
						chkgOT.Text = "ล่วงเวลา(18:00 - 22:00)";
					}
				}
			}
		}

		private void txtQty_TextChanged(object sender, EventArgs e)
		{
			txtTotalQty.Text = $"{Convert.ToDecimal(txtGoodQty.Text) + Convert.ToDecimal(txtBadQty.Text):N2}";
			UpdateUI();
		}

		private void txtProcess_TextChanged(object sender, EventArgs e) => UpdateUI();

		private void ResetTimeValidDisplay()
		{
			lbValidTime.Text = "";
			_checkin = "";
			_checkout = "";
			_validHour = 0m;
		}

		private void dtpWorkDate_ValueChanged(object sender, EventArgs e)
		{
			// initial normal hour for giving worker code
			_normalHourRate = Convert.ToDouble(GetWorkerHourRate(dtpWorkTimeStart.Value, this.WorkerCode));

			if (!string.IsNullOrEmpty(txtProductionJob.Text))
			{
				if (dtpWorkDate.Value.Date > DateTime.Today)
				{
					MessageBox.Show("วันที่ทำงานต้องไม่มากกว่าวันที่ปัจจุบัน", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					dtpWorkDate.Focus();
					grpTimeRecord.Enabled = false;
					ResetTimeValidDisplay();
				}
				else
				{
					canProcessInfo = CheckValidWoringDate(this.WorkerCode, dtpWorkDate.Value);

					if (canProcessInfo)
					{
						string _chkIn = _timeCheckIn.ToString("dd/MM/yyyy HH:mm");
						string _chkOut = _timeCheckOut.ToString("dd/MM/yyyy HH:mm");

						lbValidTime.Text = $"เข้า: {_chkIn} - ออก: {_chkOut} - รวม: {_validHour:N2} ชั่วโมง";

						grpTimeRecord.Enabled = true;
						_currentDayOfWeek = (int)dtpWorkDate.Value.DayOfWeek;

						if (_currentDayOfWeek == (int)DayOfWeek.Saturday) rdoHolidayWork.Checked = true;

						grpTimeRecord.Text = $"วัน [{dtpWorkDate.Value.DayOfWeek.ToString()}] / เวลาทำงาน ";
						if (_mode == ActionMode.Add)
						{
							dtpWorkTimeStart.Value = new DateTime(dtpWorkDate.Value.Year, dtpWorkDate.Value.Month, dtpWorkDate.Value.Day, 8, 0, 0);
							dtpWorkTimeEnd.Value = dtpWorkTimeStart.Value.AddHours(4);
							txtBreak1.Text = "0";
						}
						else if (_mode == ActionMode.Edit)
						{
							dtpWorkTimeStart.Value = new DateTime(dtpWorkDate.Value.Year, dtpWorkDate.Value.Month, dtpWorkDate.Value.Day,
								dtpWorkTimeStart.Value.Hour, dtpWorkTimeStart.Value.Minute, 0);
							dtpWorkTimeEnd.Value = new DateTime(dtpWorkDate.Value.Year, dtpWorkDate.Value.Month, dtpWorkDate.Value.Day,
								dtpWorkTimeEnd.Value.Hour, dtpWorkTimeEnd.Value.Minute, 0);
						}
					}
					else
					{
						MessageBox.Show("ไม่มีข้อมูลสำหรับวันที่เลือก", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						grpTimeRecord.Enabled = false;
						ResetTimeValidDisplay();
					}
				}
			}

			// update hour rate
			txtHourRate.Text = $"{ GetWorkerHourRate(dtpWorkDate.Value, this.WorkerCode):N2}";

			UpdateUI();
		}

		#region class helper method

		private decimal GetWorkerHourRate(DateTime validDateTime, string workerId)
			=> new ProductionDAL().GetAvgActualHourCostByWorker(validDateTime, workerId);

		private bool CheckValidWoringDate(string workerId, DateTime workDate)
		{
			bool _result = false;
			DateTime _d = DateTime.Today;
			DateTime _in = DateTime.Today;
			DateTime _out = DateTime.Today;

			_dtValidTime = new ProductionDAL().ActualTimeRecord(workDate, workerId);

			// found the record available in database
			if (_dtValidTime.Rows.Count > 0)
			{
				_d = Convert.ToDateTime(_dtValidTime.Rows[0]["Date_only"].ToString());
				_in = Convert.ToDateTime(_dtValidTime.Rows[0]["time_checkin"].ToString());
				_out = Convert.ToDateTime(_dtValidTime.Rows[0]["time_checkout"].ToString());

				_timeCheckIn = new DateTime(_d.Year, _d.Month, _d.Day, _in.Hour, _in.Minute, 0);
				_timeCheckOut = new DateTime(_d.Year, _d.Month, _d.Day, _out.Hour, _out.Minute, 0);

				_checkin = _in.ToString();
				_checkout = _out.ToString();

				_validHour = Convert.ToDecimal(_dtValidTime.Rows[0]["ValidHour"]);

				if (_validHour < 0m) _validHour = 0m;

				lbValidTime.Text = $"{_timeCheckIn} - {_timeCheckOut} - {_validHour:N2} ";

				_result = true;
			}
			else
			{
				_timeCheckIn = DateTime.Today;
				_timeCheckOut = DateTime.Today;
				_checkin = "";
				_checkout = "";
				_result = false;
			}
			return _result;
		}

		private void UpdateUI()
		{
			grpPdHour.Enabled = !string.IsNullOrEmpty(txtProductionJob.Text);

			lbBadUnit.Text = this.UnitOrder;
			lbGoodUnit.Text = lbBadUnit.Text;
			lbTotalUnit.Text = lbBadUnit.Text;
			lbUnitProcess.Text = lbBadUnit.Text;
			btnWorkSource.Enabled = false;
			btnProductionJob.Enabled = (_mode == ActionMode.Add);
			txtItemNo.Enabled = String.IsNullOrEmpty(this.ItemNo);
			txtItemName.Enabled = txtItemNo.Enabled;

			// PROCESS BUTTON
			btnProcess.Enabled = (canProcessInfo && txtProductionJob.Text.ToUpper().Substring(0, 3) != "PDT");
			cbxMachineGroup.Enabled = (_jobType == ProductionJobType.Project);

			txtProcessDetail.Enabled = (canProcessInfo || !btnProcess.Enabled);

			switch (_jobType)
			{
				case ProductionJobType.Production:
					btnSave.Enabled = !string.IsNullOrEmpty(txtProductionJob.Text)
										&& !string.IsNullOrEmpty(txtItemNo.Text)
										&& !string.IsNullOrEmpty(txtWorker.Text)
										&& !string.IsNullOrEmpty(txtProcess.Text)
										&& (Convert.ToDecimal(txtInprocessQty.Text) == 0m
											? (Convert.ToDecimal(txtGoodQty.Text) >= 0m && Convert.ToDecimal(txtTotalQty.Text) > 0m)
											: Convert.ToDecimal(txtInprocessQty.Text) > 0)
										&& Convert.ToDecimal(txtTotalWorkHours.Text) > 0m
										&& (_selectedMachineGroup > 0)
										&& _canSaveRecord;
					break;

				case ProductionJobType.Project:
					btnSave.Enabled = !string.IsNullOrEmpty(txtProductionJob.Text)
										&& !string.IsNullOrEmpty(txtWorker.Text)
										&& (!string.IsNullOrEmpty(txtProcessDetail.Text))
										&& (Convert.ToDecimal(txtInprocessQty.Text) == 0m
											? (Convert.ToDecimal(txtGoodQty.Text) >= 0m && Convert.ToDecimal(txtTotalQty.Text) > 0m)
											: Convert.ToDecimal(txtInprocessQty.Text) > 0)
									&& Convert.ToDecimal(txtTotalWorkHours.Text) > 0m
										&& (_selectedMachineGroup > 0)
										&& _canSaveRecord;
					break;
			}

		} // end UpdateUI

		private bool IsValidWorkInfo()
		{
			if (_jobType == ProductionJobType.Project)
			{
				return (txtProcessDetail.Text.Length > 0);
			}
			else
			{
				return true;
			}
		}

		private bool IsValidProcess()
		{
			if (_jobType == ProductionJobType.Production)
			{
				return (txtProcess.Text.Length > 0);
			}
			else
			{
				return true;
			}
		}

		private void GetMachineGroup()
		{
			cbxMachineGroup.DataSource = new ProductionMachineDAL().GetMachineGroup();
			cbxMachineGroup.DisplayMember = "MC_GROUPNAME";
			cbxMachineGroup.ValueMember = "MC_GROUPID";
		}

		private void GetMachineByGroup(int mcGroupId)
		{
			cbxMachine.DataSource = new ProductionMachineDAL().GetMachineMemberByGroup(mcGroupId);
			cbxMachine.DisplayMember = "MachineDetail";
			cbxMachine.ValueMember = "ID";
		}

		private void GetProductionHourRecord(int ProductionHourItem)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_hr = new PRODUCTIONJOBINFO();
					rdoWorkingday.Checked = true;
					_hr.PRDINFOID = 0;
					_hr.ERP_ORDER = this.ERPOrder;
					_hr.PROCESSID = 0;
					_hr.PROCESSNAME = string.Empty;
					_hr.PROCESSDETAIL = "";
					_hr.MACHINEGROUP = 0;
					_hr.MACHINEID = 0;
					_hr.MACHINENAME = string.Empty;
					_hr.TIME_CAT = WorkingDayCategory.NormalDay.ToString();
					_hr.DATETIME_START = new DateTime(dtpWorkDate.Value.Year, dtpWorkDate.Value.Month, dtpWorkDate.Value.Day, 8, 0, 0);
					_hr.DATETIME_END = _hr.DATETIME_START;
					_hr.OT_START = new DateTime(dtpWorkDate.Value.Year, dtpWorkDate.Value.Month, dtpWorkDate.Value.Day, 18, 0, 0);
					_hr.OT_END = _hr.OT_START;
					_hr.ITEMNO = this.ItemNo;
					_hr.DRAWINGNO = this.DrawingNo;
					_hr.WORKERID = this.WorkerCode;
					_hr.WORKERNAME = this.WorkerName;
					_hr.REGULAR_HR_RATE = GetWorkerHourRate(_hr.DATETIME_START.Value, _hr.WORKERID);
					_hr.BREAK_HRS = 60m;
					_hr.INPROCESS_QTY = 0m;
					_hr.GOOD_QTY = 0m;
					_hr.BAD_QTY = 0m;
					_hr.TOTALQTY = 0m;
					_hr.CREATEUSER = omglobal.UserName;
					_hr.CREATEDATE = DateTime.Now;
					_hr.MODIDATE = DateTime.Now;
					_hr.MODIUSER = omglobal.UserName;

					switch (_jobType)
					{
						case ProductionJobType.Production:
							_hr.MACHINEGROUP = 0;
							break;
						case ProductionJobType.Project:
							_hr.MACHINEGROUP = 11;
							break;
					}
					break;

				case ActionMode.Edit:
					_hr = new ProductionDAL().GetProductionHourItemInfo(ProductionHourItem);

					var _productionJobHeader = new ProductionDAL().GetProductionJobHeader(_hr.ERP_ORDER);
					this.UnitOrder = _productionJobHeader.UNITORDER;
					this.QOrder = _productionJobHeader.QORDER;

					lbQOrder.Text = $"Order Qty: {this.QOrder:N2} {this.UnitOrder}";
					break;
			}

			_jobType = (ProductionJobType)Enum.Parse(typeof(ProductionJobType), _hr.WORKCAT.ToString(), true);
			lbJobType.Text = _jobType.ToString();

			txtProductionJob.Text = _hr.ERP_ORDER;
			txtWorker.Text = _hr.WORKERNAME;
			txtWorker.Tag = _hr.WORKERID;
			txtItemNo.Text = _hr.ITEMNO;
			txtDrawing.Text = String.IsNullOrEmpty(_hr.DRAWINGNO) ? "" : _hr.DRAWINGNO;
			txtItemName.Text = this.ItemName;
			txtProcess.Text = _hr.PROCESSNAME;
			txtProcess.Tag = _hr.PROCESSID;
			txtProcessDetail.Text = _hr.PROCESSDETAIL;
			cbxMachineGroup.SelectedValue = _hr.MACHINEGROUP;

			GetMachineByGroup(_hr.MACHINEGROUP.Value);
			cbxMachine.SelectedValue = _hr.MACHINEID;
			lbMachineGroup.Text = $"กลุ่มงาน #[{_hr.MACHINEGROUP}] :";

			step = _hr.STEP;
			lbStep.Text = $"ขั้นตอนการผลิต: #[{step}] :";

			dtpWorkDate.Value = _hr.DATETIME_START.Value;

			if (_hr.TIME_CAT == WorkingDayCategory.NormalDay.ToString())
			{
				rdoWorkingday.Checked = true;
				_timeCat = WorkingDayCategory.NormalDay;
			}
			else
			{
				rdoHolidayWork.Checked = true;
				_timeCat = WorkingDayCategory.Holiday;
			}

			chkgNormalTime.Checked = _hr.TOTAL_NORMAL_HR > 0.00m;
			chkgOT.Checked = _hr.TOTAL_OT_HR > 0.00m;

			dtpWorkTimeStart.Value = _hr.DATETIME_START.Value;
			dtpWorkTimeEnd.Value = _hr.DATETIME_END.Value;
			txtBreak1.Text = _hr.BREAK_HRS.ToString();
			txtTotalNormalHours.Text = $"{_hr.TOTAL_NORMAL_HR:N2}";
			dtpOTStart.Value = _hr.OT_START.Value;
			dtpOTEnd.Value = _hr.OT_END.Value;
			txtOTBreak.Text = _hr.OT_BREAK.ToString();
			txtTotalOTHours.Text = $"{_hr.TOTAL_OT_HR:N2}";
			txtTotalWorkHours.Text = $"{_hr.TOTAL_HRS:N2}";
			txtHourRate.Text = $"{_hr.REGULAR_HR_RATE:N2}";
			txtRemark.Text = _hr.REMARK;
			txtInprocessQty.Text = _hr.INPROCESS_QTY.ToString();
			txtGoodQty.Text = _hr.GOOD_QTY.ToString();
			txtBadQty.Text = _hr.BAD_QTY.ToString();
			txtTotalHourCost.Text = $"{_hr.TOTAL_COST:N2}";

			lbBadUnit.Text = this.UnitOrder;
			lbGoodUnit.Text = lbBadUnit.Text;
			lbTotalUnit.Text = lbBadUnit.Text;
			lbUnitProcess.Text = lbBadUnit.Text;

			// find itemId from ItemNo
			DataTable _item = new ProductionDAL().GetStdProcessList(txtItemNo.Text);

			if (_item.Rows.Count > 0)
			{
				foreach (DataRow stdItem in _item.Rows)
				{
					this.ItemId = Convert.ToInt32(stdItem["REF_STDITEM"].ToString());
					break;
				}
			}

			UpdateUI();

		} // end GetProductionHourRecord

		private void CalWorkTime(DateTime currentDT)
		{
			if (_isFirstLoad) return;

			var _normalHour = 0.00d;
			var _otHour = 0.00d;

			// Normal time block
			if (chkgNormalTime.Checked)
			{
				// check hour-in
				DateTime _timeIn = dtpWorkTimeStart.Value;
				DateTime _timeOut = dtpWorkTimeEnd.Value;

				if (_timeCheckIn.CompareTo(_timeIn) <= 0 && _timeCheckOut.CompareTo(_timeOut) >= 0)
				{
					lbNTCheck.Text = "OK";
					var _normalTime = dtpWorkTimeEnd.Value.Subtract(dtpWorkTimeStart.Value);
					_normalHour = _normalTime.TotalHours -
								  (Information.IsNumeric(txtBreak1.Text) ? Convert.ToDouble(txtBreak1.Text) / 60 : 0.00D);

					if (_normalHour < 0d)
					{
						MessageBox.Show("ชั่วโมงงานต้องไม่เป็นค่าติดลบ", "Normal-hour Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					lbNTCheck.Text = "-";
					_normalHour = 0d;
					MessageBox.Show("เวลาไม่ตรงกับฐานข้อมูล, โปรดปรับช่วงเวลาให้ถูกต้อง", "Normal Time input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			if (chkgOT.Checked)
			{
				// Overtime Block
				DateTime _otIn = new DateTime(dtpWorkDate.Value.Year, dtpWorkDate.Value.Month, dtpWorkDate.Value.Day, dtpOTStart.Value.Hour, dtpOTStart.Value.Minute, 0);
				DateTime _otOut = new DateTime(dtpWorkDate.Value.Year, dtpWorkDate.Value.Month, dtpWorkDate.Value.Day, dtpOTEnd.Value.Hour, dtpOTEnd.Value.Minute, 0);
				lbOTCheck.Text = "OK";
				var _otTime = dtpOTEnd.Value.Subtract(dtpOTStart.Value);
				_otHour = _otTime.TotalHours -
						  (Information.IsNumeric(txtOTBreak.Text) ? Convert.ToDouble(txtOTBreak.Text) / 60 : 0.00D);
				if (_otHour < 0d)
				{
					MessageBox.Show("ชั่วโมงงานต้องไม่เป็นค่าติดลบ", "Overtime-hour Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			txtTotalNormalHours.Text = $"{_normalHour:N2}";
			txtTotalOTHours.Text = $"{_otHour:N2}";
			txtTotalWorkHours.Text = $"{(_normalHour + _otHour):N2}";

			lbActualAvgHourRate.Text = $"{_normalHourRate:N2}";

			//  Convert.ToDouble(txtHourRate.Text);
			var _normalOTHourRate = _normalHourRate * (double)omglobal.NORMAL_OT_FACTOR;
			var _holidayHourRate = _normalHourRate * (double)omglobal.HOLIDAY_WORK_FACTOR;
			var _holidayOTHourRate = _normalOTHourRate * (double)omglobal.HOLIDAY_OT_FACTOR;

			var _totalNormalHourCost = 0.00d;
			var _totalHolidayHourCost = 0.00d;

			// calculate for HOUR COST as worktime category NORMAL_DAY_WORK OR HOLIDAY_WORK
			switch (_timeCat)
			{
				case WorkingDayCategory.NormalDay:
					_totalNormalHourCost = (_normalHour * _normalHourRate) + (_otHour * _normalOTHourRate);
					break;

				case WorkingDayCategory.Holiday:
					_totalHolidayHourCost = (_normalHour * _holidayHourRate) + (_otHour * _holidayOTHourRate);
					break;
			}

			txtTotalHourCost.Text = $"{(_totalNormalHourCost + _totalHolidayHourCost):N2}";

		} // end CalWorkTime

		private void GetWorkProcess(int itemId, string itemNo, string itemName)
		{
			string _process = txtProcess.Text;
			int _processId = Convert.ToInt32(txtProcess.Tag);
			int _step = step;

			using (WorkProcess workProcess = new WorkProcess(itemId, itemNo, itemName))
			{
				if (workProcess.ShowDialog(this) == DialogResult.OK)
				{
					txtProcess.Text = workProcess.ProcessName;
					txtProcess.Tag = workProcess.ProcessId;
					step = workProcess.Step;
					_selectedMachineGroup = workProcess.SelectedMachineGroupId;

					cbxMachineGroup.SelectedValue = _selectedMachineGroup;
				}
				else
				{
					txtProcess.Text = _process;
					txtProcess.Tag = _processId;
					step = _step;
				}

				_hr.STEP = step;
				_hr.PROCESSID = Convert.ToInt32(txtProcess.Tag.ToString());
				_hr.PROCESSNAME = txtProcess.Text;
				_hr.MACHINEGROUP = _selectedMachineGroup;

				lbMachineGroup.Text = $"กลุ่มงาน #[{_selectedMachineGroup}] :";
				GetMachineByGroup(_selectedMachineGroup);

				lbStep.Text = $"ขั้นตอนการผลิต #[{_hr.STEP}] :";
			}

			UpdateUI();
		} // end  GetProcess

		private void UpdateProductionTimeInfo()
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_hr.CREATEUSER = omglobal.UserName;
					_hr.CREATEDATE = DateTime.Now;
					_hr.ERP_ORDER = ERPOrder;
					break;

				case ActionMode.Edit:
					break;
			}

			_hr.WORKCAT = (int)_jobType;
			_hr.MODIUSER = omglobal.UserName;
			_hr.MODIDATE = DateTime.Now;
			_hr.AVG75_HR_RATE = 0.00m;
			_hr.AVG85_HR_RATE = 0.00m;
			_hr.NET75_HR_RATE = 0.00m;
			_hr.NET85_HR_RATE = 0.00m;
			_hr.TOTAL_COST75 = 0.00m;
			_hr.TOTAL_AVG_COST75 = 0.00m;
			_hr.TOTAL_AVG_COST85 = 0.00m;
			_hr.TOTAL_COST85 = 0.00m;
			_hr.COSTCENTER = "";
			_hr.WORKYEAR = dtpWorkDate.Value.Year;
			_hr.WORKPERIOD = dtpWorkDate.Value.Month;
			_hr.WORKDAY = dtpWorkDate.Value.Day;
			_hr.WORKERID = txtWorker.Tag.ToString();
			_hr.WORKERNAME = txtWorker.Text;
			_hr.ITEMNO = txtItemNo.Text;
			_hr.DRAWINGNO = this.DrawingNo;
			_hr.STEP = step;
			_hr.PROCESSID = Convert.ToInt32(txtProcess.Tag.ToString());
			_hr.PROCESSNAME = txtProcess.Text;
			_hr.PROCESSDETAIL = txtProcessDetail.Text;

			_hr.MACHINEGROUP = _selectedMachineGroup;
			_hr.MACHINEID = _selectedMachineId;
			_hr.MACHINENAME = cbxMachine.Text;

			_hr.INPROCESS_QTY = Convert.ToDecimal(txtInprocessQty.Text);
			_hr.GOOD_QTY = Convert.ToDecimal(txtGoodQty.Text);
			_hr.BAD_QTY = Convert.ToDecimal(txtBadQty.Text);
			_hr.TOTALQTY = _hr.GOOD_QTY + _hr.BAD_QTY;
			_hr.TIME_CAT = _timeCat.ToString();
			_hr.DATETIME_START = dtpWorkTimeStart.Value;
			_hr.DATETIME_END = dtpWorkTimeEnd.Value;
			_hr.BREAK_HRS = Convert.ToDecimal(txtBreak1.Text);
			_hr.TOTAL_NORMAL_HR = Convert.ToDecimal(txtTotalNormalHours.Text);
			_hr.OT_START = dtpOTStart.Value;
			_hr.OT_END = dtpOTEnd.Value;
			_hr.OT_BREAK = Convert.ToDecimal(txtOTBreak.Text);
			_hr.TOTAL_OT_HR = Convert.ToDecimal(txtTotalOTHours.Text);
			_hr.TOTAL_HRS = Convert.ToDecimal(txtTotalWorkHours.Text);
			_hr.REGULAR_HR_RATE = GetWorkerHourRate(_hr.DATETIME_START.Value, _hr.WORKERID);
			_hr.TOTAL_COST = Convert.ToDecimal(txtTotalHourCost.Text);

			_hr.REMARK = txtRemark.Text;

			if ((RecordAffect = new ProductionDAL().UpdateProductionHourItem(_hr)) > 0)
			{
				MessageBox.Show("Update Production item successfully !!!", "MESSAGE", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		} // end UpdateProductionTimeInfo

		#endregion

		private void btnProductionJob_Click(object sender, EventArgs e)
		{
			// find-out production job
			using (ActiveProductionJobs jobs = new ActiveProductionJobs((int)ProductionJobStatus.Active, 0, txtProductionJob.Text))
			{
				jobs.StartPosition = FormStartPosition.CenterScreen;
				if (jobs.ShowDialog(this) == DialogResult.OK)
				{
					this.ItemName = jobs.ItemName;
					this.ItemNo = jobs.ItemNo;
					this.DrawingNo = jobs.DrawingNo;
					this.ERPOrder = jobs.ProductionJob;
					this.QOrder = jobs.JobQty;
					this.UnitOrder = jobs.UnitOrder;
					_jobType = jobs.JobType;
				}
				else
				{
					this.ItemName = "";
					this.ItemNo = "";
					this.DrawingNo = "";
					this.ERPOrder = "";
					this.QOrder = 0m;
					this.UnitOrder = "";
					_jobType = ProductionJobType.Production;
				}
			}

			// display selected value
			txtProductionJob.Text = this.ERPOrder;
			txtItemName.Text = this.ItemName;
			txtItemNo.Text = this.ItemNo;
			txtDrawing.Text = this.DrawingNo;
			lbJobType.Text = _jobType.ToString();
			lbQOrder.Text = $"Order Qty: {this.QOrder} {this.UnitOrder}";

			UpdateUI();
		}

		private void txtProductionJob_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnProductionJob.PerformClick();
			}
		}

		private void txtTotalWorkHours_TextChanged(object sender, EventArgs e) => UpdateUI();

		private void btnCancel_Click(object sender, EventArgs e) => this.Close();

		private void chkgNormalTime_CheckedChanged(object sender, EventArgs e) => txtBreak1.Text = "0";

		private void txtTotalNormalHours_TextChanged(object sender, EventArgs e)
		{
			try
			{
				decimal _totalNT = Convert.ToDecimal(txtTotalNormalHours.Text);
				if (_totalNT >= 0 && _totalNT > _validHour)
				{
					lbTotalHourError.Visible = true;
					lbTotalHourError.Text = $"** ข้อมูลชั่วโมงการทำงานไม่ถูกต้อง **";
					_canSaveRecord = false;
				}
				else
				{
					lbTotalHourError.Visible = false;
					lbTotalHourError.Text = "";
					_canSaveRecord = true;
				}
				if (_validHour == 0m) _canSaveRecord = true;
			}
			catch (Exception)
			{
				lbTotalHourError.Visible = true;
				lbTotalHourError.Text = $"** ข้อมูลชั่วโมงการทำงานไม่ถูกต้อง **";
				_canSaveRecord = false;
			}

			UpdateUI();
		}

		private void dtpWorkTimeEnd_ValueChanged(object sender, EventArgs e) => CalWorkTime(dtpWorkTimeEnd.Value);

		private void dtpOTStart_ValueChanged(object sender, EventArgs e) => CalWorkTime(dtpOTStart.Value);

		private void dtpOTEnd_ValueChanged(object sender, EventArgs e) => CalWorkTime(dtpOTEnd.Value);

		private void txtDrawing_TextChanged(object sender, EventArgs e) => this.DrawingNo = txtDrawing.Text;

		private void txtTotalOTHours_TextChanged(object sender, EventArgs e)
		{
			_canSaveRecord = (Convert.ToDecimal(txtTotalOTHours.Text) > 0);
			UpdateUI();
		}

		private void txtInprocessQty_TextChanged(object sender, EventArgs e) => UpdateUI();

		private void txtTotalQty_TextChanged(object sender, EventArgs e) => UpdateUI();

		private void txtProcessDetail_Validated(object sender, EventArgs e)
		{
			if (IsValidWorkInfo())
			{
				workInfoErrorProvider.SetError(this.txtProcessDetail, string.Empty);
			}
			else
			{
				workInfoErrorProvider.SetError(this.txtProcessDetail, "ในกรณีที่เป็นงาน Project ต้องใส่รายละเอียดการทำงาน");
			}
		}

		private void txtProcess_Validated(object sender, EventArgs e)
		{
			if (_jobType == ProductionJobType.Production)
			{
				if (IsValidProcess())
				{
					ProcessErrorProvider.SetError(this.txtProcess, string.Empty);
				}
				else
				{
					ProcessErrorProvider.SetError(this.txtProcess, "ในกรณีที่เป็นงาน Production ต้องใส่ขั้นตอนการทำงาน");
				}
			}
		}

		private void cbxMachine_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedMachineId = Convert.ToInt32(cbxMachine.SelectedValue);
				_hr.MACHINEID = _selectedMachineId;
			}
			catch
			{
				_selectedMachineId = 0;
			}
		}

		private void cbxMachineGroup_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedMachineGroup = Convert.ToInt32(cbxMachineGroup.SelectedValue.ToString());
				_hr.MACHINEGROUP = _selectedMachineGroup;
			}
			catch { }

			GetMachineByGroup(_selectedMachineGroup);

			lbMachineGroup.Text = $"กลุ่มงาน #[{_selectedMachineGroup}] :";
		}
	}
}