using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMW15.Models.ServiceModel;
using System.Transactions;

namespace OMW15.Views.ServiceView
{
	public partial class PM : Form
	{
		#region class field
		private int _selectedMachineId = 0;
		private int _selectedPMContractId = 0;
		private string _selectedPMContractNo = string.Empty;
		private string _selectedModel = string.Empty;
		private string _selectedSN = string.Empty;
		private string _selectedCustomer = string.Empty;
		private string _selectedCustomerCode = string.Empty;
		private int _selectedMaxPM = 0;
		private int _selectedFactor = 0;

		private DateTime _selectedScheduleDate = DateTime.Today;
		private DateTime _selectedContractStartDate = DateTime.Today;
		private int _selectedScheduleId = 0;
		private int _pmNumber = 0;
		private bool _isCompletedSchedule = false;
		#endregion

		#region class property

		#endregion

		#region class helper method

		private void updateUI()
		{
			// machine command
			this.btnEditMachine.Enabled = ((_selectedMachineId > 0));
			this.btnDeleteMachine.Enabled = btnEditMachine.Enabled;
			//this.btnReloadPM.Enabled = btnEditMachine.Enabled;

			// schdule command
			this.btnAddSchedule.Enabled = (_selectedMachineId > 0 && this.dgvSchedule.Rows.Count == 0);
			this.btnEditSchedule.Enabled = (_selectedScheduleId > 0 && _isCompletedSchedule == false);
			this.btnDeleteSchedule.Enabled = this.btnEditSchedule.Enabled;
			this.btnOpenServiceOrder.Enabled = this.btnEditSchedule.Enabled;
			this.btnMatchingJob.Enabled = this.btnEditSchedule.Enabled;
		}

		private void getPMList()
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = new Models.ServiceModel.PMDal().getPMList();

			this.dgv.Columns["PMID"].Visible = false;
			this.dgv.Columns["MCID"].Visible = false;
			this.dgv.Columns["CODE"].Visible = false;
			this.dgv.Columns["TYPEID"].Visible = false;
			this.dgv.Columns["PM_FACTOR"].Visible = false;

			this.dgv.Columns["CONTRACTNO"].HeaderText = "เลขที่สัญญา";
			this.dgv.Columns["CUSTOMER"].HeaderText = "ลูกค้า";
			this.dgv.Columns["PM_START"].HeaderText = "วันที่เริ่มสัญญา";
			this.dgv.Columns["PM_END"].HeaderText = "วันที่สิ้นสุดสัญญา";
			this.dgv.Columns["MODEL"].HeaderText = "รุ่นเครื่อง";
			this.dgv.Columns["SERIAL"].HeaderText = "หมายเลขเครื่อง";
			this.dgv.Columns["PM_TYPE"].HeaderText = "ประเภทของสัญญา";
			this.dgv.Columns["PM_MAX"].HeaderText = "จำนวนครั้ง";

			this.dgv.ResumeLayout();

			this.updateUI();

		} // end getPMList


		private void getPMInfo()
		{
			using (PMInfo pminfo = new PMInfo())
			{
				pminfo.PMCall = PMServiceCall.PMCallNormal;
				pminfo.PMContractId = _selectedPMContractId;
				pminfo.PMContractNo = _selectedPMContractNo;
				pminfo.StartPosition = FormStartPosition.CenterParent;

				if (pminfo.ShowDialog(this) == DialogResult.OK)
				{
					// code for information
				}
			}
		}

		private void getMachineSchedule(int machineId)
		{
			_selectedScheduleId = 0;
			this.dgvSchedule.SuspendLayout();
			this.dgvSchedule.DataSource = new PMDal().getAllMachineSchedule(machineId);
			this.dgvSchedule.ResumeLayout();

			this.dgvSchedule.Columns["ISCOMPLETE"].Visible = false;
			this.dgvSchedule.Columns["MC_KEY"].Visible = false;
			this.dgvSchedule.Columns["SCH_ID"].Visible = false;

			this.dgvSchedule.Columns["PM_SERIES"].HeaderText = "ลำดับที่";
			this.dgvSchedule.Columns["PMDATE"].HeaderText = "วันที่กำหนด";
			this.dgvSchedule.Columns["PMJOBNO"].HeaderText = "เลขที่ใบงาน";
			this.dgvSchedule.Columns["ACTUALPMDATE"].HeaderText = "วันที่ทำจริง";

			this.updateUI();
		}

		private void matchingPMJob(string customerCode, int contractId, int scheduleId, string Model, string serialNo)
		{
			using (PMMatching _match = new PMMatching())
			{
				_match.Customer = _selectedCustomer;
				_match.CustomerCode = customerCode;
				_match.PMContractId = contractId;
				_match.PMScheduleId = scheduleId;
				_match.MachineModel = Model;
				_match.SerialNo = serialNo;
				_match.StartPosition = FormStartPosition.CenterScreen;
				if (_match.ShowDialog() == DialogResult.OK)
				{
					int _pmOrderId = _match.PMJobId;
					string _pmOrderNo = _match.PMJobNumber;

					if (MessageBox.Show($"ต้องการจับคู่กำหนดงานซ่อมบำรุง\n สัญญา :{_selectedPMContractNo} \n กับใบงานเลขที่ : {_match.PMJobNumber} \n\n ที่เลือกใช่ไหม?", "Matching", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						// update schedule 
						new PMDal().updateScheduleAfterTakeServiceJob(scheduleId, _match.PMJobNumber, _match.OrderDate);

						// update service order
						if (new PMDal().updateServiceOrderWithPMSchedule(_match.PMJobId, contractId, scheduleId) > 0)
						{
							MessageBox.Show("Update successfully !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
					// refresh machine schedule
					this.getMachineSchedule(_selectedMachineId);
				}
			}
		}


		#endregion

		public PM()
		{
			InitializeComponent();

			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			OMControls.OMUtils.SettingDataGridView(ref this.dgvSchedule);

			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

			this.CenterToParent();
		}

		private void PM_Load(object sender, EventArgs e)
		{
				this.getPMList();
			this.updateUI();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			int.TryParse(this.dgv["MCID", e.RowIndex].Value.ToString(), out _selectedMachineId);
			int.TryParse(this.dgv["PMID", e.RowIndex].Value.ToString(), out _selectedPMContractId);
			int.TryParse(this.dgv["PM_MAX", e.RowIndex].Value.ToString(), out _selectedMaxPM);
			int.TryParse(this.dgv["PM_FACTOR", e.RowIndex].Value.ToString(), out _selectedFactor);

			_selectedContractStartDate = DateTime.Parse(this.dgv["PM_START", e.RowIndex].Value.ToString());

			_selectedPMContractNo = this.dgv["CONTRACTNO", e.RowIndex].Value.ToString();
			_selectedModel = this.dgv["MODEL", e.RowIndex].Value.ToString();
			_selectedSN = this.dgv["SERIAL", e.RowIndex].Value.ToString();
			_selectedCustomer = this.dgv["CUSTOMER", e.RowIndex].Value.ToString();
			_selectedCustomerCode = this.dgv["CODE", e.RowIndex].Value.ToString();

			lbMachineId.Text = $"machine id : {_selectedMachineId}";

			this.getMachineSchedule(_selectedMachineId);

			this.lbScheduleHeader.Invoke(new Action(() =>
			{
				lbScheduleHeader.Text = $"กำหนดการซ่อมบำรุงของเครื่องจักร {_selectedModel} เลขเครื่อง {_selectedSN} ตามสัญญาเลขที่ : {_selectedPMContractNo}";
			}));

			updateUI();
		}

		private void btnEditMachine_Click(object sender, EventArgs e)
		{
			if (new PMDal().findMachineWasPM(_selectedPMContractId) == false)
			{
				this.getPMInfo();
			}
			else
			{
				MessageBox.Show("ไมสามารถแก้ไขข้อมูลได้ !!! \n เนื่องจากว่าข้อมูลได้ถูกนำไปใช้อ้างอิงสำหรับงานบริการแล้ว", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void btnDeleteMachine_Click(object sender, EventArgs e)
		{
			// find that machine was taken for pm-service?
			if (new PMDal().findMachineWasPM(_selectedPMContractId) == false)
			{
				if (MessageBox.Show($"รายการที่เลือก : \n สัญญาเลขที่: {_selectedPMContractNo} \n รุ่นเครื่องจักร: {_selectedModel} \n เลขเครื่องจักร: {_selectedSN} \n\n ต้องการลบข้อมูลออกจากรายการที่แสดงอยู่ใช่หรือไม่ ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					// remove the machine
					if (new PMDal().deletePMMachine(_selectedMachineId) > 0)
					{
						Controllers.ToolController.Alert.DisplayAlert("Delete", "ลบรายการเรียบร้อยแล้ว");
					}
				}
			}
			else
			{
				MessageBox.Show("ม่สามารถลบข้อมูลที่เลือกได้ !!! \n เนื่องจากว่าข้อมูลได้ถูกนำไปใช้อ้างอิงสำหรับงานบริการแล้ว", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void btnReloadPM_Click(object sender, EventArgs e)
		{
			this.getPMList();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAddSchedule_Click(object sender, EventArgs e)
		{
			PMMC _mc = new PMDal().getContractMC(_selectedMachineId);
			int _duration = (_selectedFactor / _selectedMaxPM);
			DateTime _pmStart = _selectedContractStartDate;
			//_mc.PMSCHEDULEs = new List<PMSCHEDULE>();

			try
			{
				for (int i = 1; i <= _selectedMaxPM; i++)
				{
					// add schedule date
					_pmStart = (i > 1 ? _pmStart.AddMonths(_duration) : _pmStart);

					// initial object for PM-schedule
					PMSCHEDULE _sch = new PMSCHEDULE();
					_sch.AUDITUSER = omglobal.UserInfo;
					_sch.iscomplete = false;
					_sch.isdelete = false;
					_sch.LASTMODIFY = DateTime.Now;
					_sch.PMMC.PM_MC = _selectedMachineId;
					_sch.PMDate = _pmStart;
					_sch.PM_series = i;

					// add the schedule
					_mc.PMSCHEDULEs.Add(_sch);
				}
			}
			catch (Exception ex)
			{
				Controllers.ToolController.Alert.DisplayAlert("Error", "Error during add the machine schedule..", ex.ToString());
			}

			if (new PMDal().addPMScheduleList(_mc) > 0)
			{
				Controllers.ToolController.Alert.DisplayAlert("Message", "Add Schedule successfully..");
			}

			this.getMachineSchedule(_selectedMachineId);
		}

		private void dgvSchedule_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			int.TryParse(this.dgvSchedule["SCH_ID", e.RowIndex].Value.ToString(), out _selectedScheduleId);

			int.TryParse(this.dgvSchedule["PM_SERIES", e.RowIndex].Value.ToString(), out _pmNumber);

			DateTime.TryParse(this.dgvSchedule["PMDATE", e.RowIndex].Value.ToString(), out _selectedScheduleDate);

			_isCompletedSchedule = Convert.ToBoolean(this.dgvSchedule["ISCOMPLETE", e.RowIndex].Value);

			this.updateUI();
		}

		private void btnDeleteSchedule_Click(object sender, EventArgs e)
		{
			// find that machine was taken for pm-service?
			if (new PMDal().findScheduleWasPM(_selectedScheduleId) == false)
			{
				if (MessageBox.Show($"รายการที่เลือก : \n สัญญาเลขที่: {_selectedPMContractNo} \n รุ่นเครื่องจักร: {_selectedModel} \n เลขเครื่องจักร: {_selectedSN} \n กำหนดการซ่อมบำรุงวันที่:{_selectedScheduleDate.ToShortDateString()} \n\n ต้องการลบข้อมูลออกจากรายการที่แสดงอยู่ใช่หรือไม่ ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					// remove the machine
					if (new PMDal().removePMMachineShedule(_selectedScheduleId) > 0)
					{
						Controllers.ToolController.Alert.DisplayAlert("Delete", "ลบรายการเรียบร้อยแล้ว");
					}
				}
			}
			else
			{
				MessageBox.Show("ม่สามารถลบข้อมูลที่เลือกได้ !!! \n เนื่องจากว่าข้อมูลได้ถูกนำไปใช้อ้างอิงสำหรับงานบริการแล้ว", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			// refresh machine schedule
			this.getMachineSchedule(_selectedMachineId);

		}

		private void btnEditSchedule_Click(object sender, EventArgs e)
		{
			if (new PMDal().findScheduleWasPM(_selectedScheduleId) == false)
			{
				using (ScheduleInfo _schInfo = new ScheduleInfo())
				{
					_schInfo.Model = _selectedModel;
					_schInfo.ScheduleId = _selectedScheduleId;
					_schInfo.ShowDialog(this);
				}
			}
			else
			{
				MessageBox.Show("ไม่สามารถแก้ไขข้อมูลได้ !!! \n เนื่องจากว่าข้อมูลได้ถูกนำไปใช้อ้างอิงสำหรับงานบริการแล้ว", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			// refresh machine schedule
			this.getMachineSchedule(_selectedMachineId);

		}

		private void dgvSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (bool.Parse(this.dgvSchedule["ISCOMPLETE", e.RowIndex].Value.ToString()) == true)
			{
				e.CellStyle.BackColor = Color.Gray;
				e.CellStyle.ForeColor = Color.Black;
			}
		}

		private void dgvSchedule_DoubleClick(object sender, EventArgs e)
		{
			this.btnEditSchedule.PerformClick();
		}

		private void btnOpenServiceOrder_Click(object sender, EventArgs e)
		{
			using (ServiceJobInfo _job = new ServiceJobInfo(0, "PM"))
			{
				_job.Customer = _selectedCustomer;
				_job.CustomerCode = _selectedCustomerCode;
				_job.MachineModel = _selectedModel;
				_job.SerialNo = _selectedSN;
				_job.ContractNo = _selectedPMContractNo;
				_job.ContractId = _selectedPMContractId;
				_job.ScheduleId = _selectedScheduleId;
				_job.PMNumber = _pmNumber;
				_job.PMDate = _selectedScheduleDate;
				_job.AppCall = Shared.OMShareServiceEnums.ServiceAppCallEnum.PMAppointment;
				_job.ShowDialog();
			}

			// refresh machine schedule
			this.getMachineSchedule(_selectedMachineId);

		}

		private void btnMatchingJob_Click(object sender, EventArgs e)
		{
			this.matchingPMJob(_selectedCustomerCode, _selectedPMContractId, _selectedScheduleId, _selectedModel, _selectedSN);
		}


	}
}
