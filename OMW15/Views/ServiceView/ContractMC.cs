using OMW15.Models.ServiceModel;
using OMW15.Shared;
using System;
using System.Windows.Forms;

namespace OMW15.Views.ServiceView
{
	public partial class ContractMC : Form
	{
		#region class field

		private ActionMode _mode = ActionMode.None;
		private int _duration = 0;
		private int _pmMonthFactor = 0;
		private int _pmMax = 0;
		private int _pmTypeId = 0;
		private int _pmMachineItemId = 0;
		//private int _selectedScheduleItemId = 0;
		private string _contractNo = string.Empty;
		private string _customerName = string.Empty;
		private string _customerCode = string.Empty;
		private string _model = string.Empty;
		private string _sn = string.Empty;

		private PMMC mc;
		//private List<PMSCHEDULE> machineSchedule = new List<PMSCHEDULE>();


		#endregion

		#region class property
		public ActionMode HeaderMode { get; set; }
		public DateTime PMStartDate { get; set; }
		public PMMC PMMachine { get; set; }
		//public List<PMSCHEDULE> MachineSchedule
		//{
		//	get; set;
		//}

		#endregion

		#region class method

		private void updateUI()
		{
			this.btnSave.Enabled = (!string.IsNullOrEmpty(this.txtModel.Text));
		}

		private void getPMTypeList()
		{
			this.cbxPMType.DataSource = new PMDal().getPMType();
			this.cbxPMType.ValueMember = "WARRANTYID";
			this.cbxPMType.DisplayMember = "WARRANTYNAME";
		}

		private void getPMMcInfo(string customerCode, string customerName, string model, string sn, int pmMachineItemId)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_pmTypeId = 7;
					_pmMax = 2;
					_pmMonthFactor = 12 / _pmMax;
					mc = new PMMC();
					mc.PMCONTRACT.PM_CONTRACT_KEY = _contractNo;
					mc.PM_MC = 0;
					mc.PM_MC_MODEL = model;
					mc.PM_MC_SN = sn;
					mc.PM_TYPE_KEY = _pmTypeId;
					mc.PM_MAX = _pmMax;

					break;

				case ActionMode.Edit:
					mc = new PMDal().getContractMC(pmMachineItemId);
					_pmTypeId = mc.PM_TYPE_KEY;
					_pmMax = mc.PM_MAX;

					break;
			}

			this.txtContractNo.Text = mc.PMCONTRACT.PM_CONTRACT_KEY;
			this.txtCustomerCode.Text = customerCode;
			this.txtCustomer.Text = customerName;
			this.txtModel.Text = mc.PM_MC_MODEL;
			this.txtSN.Text = mc.PM_MC_SN;
			this.Text = mc.PM_MC_SN;
			this.cbxPMType.SelectedValue = mc.PM_TYPE_KEY;
			this.txtPMQty.Text = mc.PM_MAX.ToString();

			this.lbPMTypeId.Text = $"{mc.PM_TYPE_KEY}";

			// get max pm
			this.getMaxPM(_pmTypeId);

			// update UI
			this.updateUI();
		}

		private void getMaxPM(int pmTypeId)
		{
			_pmMonthFactor = 0;
			new PMDal().getPMType(pmTypeId, out _pmMax, out _pmMonthFactor);
			this.txtPMQty.Text = $"{_pmMax}";
			this.lbFactor.Text = $"{_pmMonthFactor}";
			_duration = (_pmMonthFactor / (_pmMax == 0 ? 1 : _pmMax));

			this.lbDuration.Text = $"{_duration}";
		}

		//private void createMachineSchedule()
		//{
		//	// add machine schedule
		//	if (_mode == ActionMode.Add)
		//	{
		//		machineSchedule = new List<PMSCHEDULE>();
		//		DateTime _pmdate = this.PMStartDate;
		//		for (int i = 1; i <= _pmMax; i++)
		//		{
		//			PMSCHEDULE _schedule = new PMSCHEDULE();
		//			_pmdate = _pmdate.AddMonths(_duration);
		//			_schedule.SCH_ID = 0;
		//			_schedule.MC_KEY = 0;
		//			_schedule.PM_series = i;
		//			_schedule.PMDate = _pmdate;
		//			_schedule.PMJobNo = "";
		//			_schedule.iscomplete = false;
		//			_schedule.isdelete = false;
		//			_schedule.AUDITUSER = omglobal.UserInfo;
		//			_schedule.LASTMODIFY = DateTime.Now;

		//			machineSchedule.Add(_schedule);
		//		}

		//		// display schule
		//		this.dgvSch.SuspendLayout();
		//		this.dgvSch.DataSource = machineSchedule.ToList();
		//		this.dgvSch.ResumeLayout();
		//	}
		//}

		#endregion

		public ContractMC(string contractNo, string customerCode, string customerName, int pmMachineItemId)
		{
			InitializeComponent();

			_contractNo = contractNo;
			_pmMachineItemId = pmMachineItemId;
			_customerCode = customerCode;
			_customerName = customerName;

			this.pnlHeader.BackColor = omglobal.FB_BLUE;
			this.lbMode.Text = (_mode = _pmMachineItemId == 0 ? ActionMode.Add : ActionMode.Edit).ToString();
		}

		private void PMMC_Load(object sender, EventArgs e)
		{
			getPMTypeList();

			getPMMcInfo(_customerCode, _customerName, _model, _sn, _pmMachineItemId);

			// display header-mode
			this.txtHeaderMode.Text = this.HeaderMode.ToString().Substring(0, 1);
		}

		private void btnMCList_Click(object sender, EventArgs e)
		{
			Controllers.ServiceController.PMController pmMachine = new Controllers.ServiceController.PMController();

			pmMachine.getMachineForPM(_customerCode, _customerName, out _model, out _sn);

			this.txtModel.Text = _model;
			this.txtSN.Text = _sn;

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			mc = new PMMC();
			switch (_mode)
			{
				case ActionMode.Add:
					mc.AUDITUSER = omglobal.UserInfo;
					mc.MODIDATE = DateTime.Now;
					mc.MODIUSER = omglobal.UserInfo;
					mc.PMCONTRACT.PM_CONTRACT_KEY = this.txtContractNo.Text;
					mc.PM_MAX = _pmMax;
					mc.PM_MC = 0;
					mc.PM_MC_MODEL = this.txtModel.Text;
					mc.PM_MC_SN = this.txtSN.Text;
					mc.PM_TYPE_KEY = _pmTypeId;

					this.PMMachine = mc;

					break;

				case ActionMode.Edit:
					mc = new PMDal().getContractMC(_pmMachineItemId);
					mc.MODIDATE = DateTime.Now;
					mc.MODIUSER = omglobal.UserInfo;
					mc.PM_MC_MODEL = this.txtModel.Text;
					mc.PM_MC_SN = this.txtSN.Text;
					mc.PM_TYPE_KEY = _pmTypeId;
					mc.PM_MAX = _pmMax;

					break;
			}

			switch (this.HeaderMode)
			{
				case ActionMode.Add:
					break;

				case ActionMode.Edit:
					if (new PMDal().updatePMContractMachine(mc) > 0)
					{
						MessageBox.Show("Update completed.......", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					break;
			}

		}

		private void cbxPMType_SelectedValueChanged(object sender, EventArgs e)
		{
			int.TryParse(cbxPMType.SelectedValue.ToString(), out _pmTypeId);

			lbPMTypeId.Text = $"{_pmTypeId}";

			// get max pm
			this.getMaxPM(_pmTypeId);
		}

		private void txtModel_TextChanged(object sender, EventArgs e)
		{
			this.updateUI();
		}

		private void txtPMQty_TextChanged(object sender, EventArgs e)
		{
			int _max = 0;
			if (this.txtPMQty.Text.IsNumeric())
			{
				int.TryParse(this.txtPMQty.Text, out _max);
			}

			this.updateUI();
		}

	}
}
