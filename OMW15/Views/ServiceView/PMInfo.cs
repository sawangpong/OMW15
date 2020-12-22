using OMControls;
using OMW15.Shared;
using OMW15.Models;
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
using OMW15.Controllers.ServiceController;

namespace OMW15.Views.ServiceView
{
	public enum PMServiceCall
	{
		PMCallByMCRecord,
		PMCallNormal
	}

	public enum PMContractStatus
	{
		Active = 1,
		Completed = 2
	}

	public partial class PMInfo : Form
	{
		#region class field member

		private PMCONTRACT pm;
		private List<PMMC> mcList = new List<PMMC>();
		private List<PMSCHEDULE> mcSchedules = new List<PMSCHEDULE>();

		private ActionMode _contractMode = ActionMode.None;

		private int pmTypeId = 7;          // free service 2 times/year
		private int pmMaxPerYear = 2;      // factor for free service/year
		//private int pmMonthFactor = 12;    // factor for total period
		private int selectedPMMachineItemId = 0;
		private string selectedModel = string.Empty;
		private string selectedSN = string.Empty;

		#endregion

		#region class property
		public PMServiceCall PMCall
		{
			get; set;
		}
		public int PMContractId
		{
			get; set;
		}
		public string PMContractNo
		{
			get; set;
		}
		public string CustomerCode
		{
			get; set;
		}
		public string CustomerName
		{
			get; set;
		}
		public string Model
		{
			get; set;
		}
		public string SN
		{
			get; set;
		}

		#endregion

		#region class helper methods

		private void updateMainUI()
		{
			this.txtPMContractNo.Enabled = ((_contractMode == ActionMode.Add) && (this.chkAutoContractNo.Checked == false));

			this.btnRefresh.Enabled = (_contractMode != ActionMode.Add);

		} // end updateUI

		private void updateMachineListUI()
		{
			this.btnEditMC.Enabled = (this.dgvMC.Rows.Count > 0);
			this.btnDeleteMC.Enabled = this.btnEditMC.Enabled;

		} // end updateMachineListUI();

		private void insertPMMachine(string contractNo, string model, string sn)
		{
			PMMC mc = new PMMC();
			mc.AUDITUSER = omglobal.UserInfo;
			mc.MODIDATE = DateTime.Now;
			mc.MODIUSER = omglobal.UserInfo;
			mc.PMCONTRACT.PM_CONTRACT_KEY = contractNo;
			mc.PM_MC = 0;
			mc.PM_MC_MODEL = model;
			mc.PM_MC_SN = sn;
			mc.PM_TYPE_KEY = pmTypeId;
			mc.PM_MAX = pmMaxPerYear;

			// add new pm-contract into object
			this.mcList.Add(mc);
		}

		private void getPMContractInfo(string contractNo)
		{
			switch (_contractMode)
			{
				case ActionMode.Add:
					pm = new PMCONTRACT();
					pm.PM_CONTRACT_DATE = DateTime.Today;
					pm.PM_START = DateTime.Today;
					pm.PM_END = pm.PM_START.AddMonths(12);
					pm.PM_STATUS = (int)PMContractStatus.Active;

					chkAutoContractNo.Enabled = true;
					chkAutoContractNo.Checked = true;
					pm.PM_CONTRACT_KEY = txtPMContractNo.Text;

					if (this.PMCall == PMServiceCall.PMCallByMCRecord)
					{
						pm.PM_CUSTCODE = this.CustomerCode;
						pm.PM_CUSTOMER = this.CustomerName;
					}

					break;

				case ActionMode.Edit:
					pm = new Models.ServiceModel.PMDal().getPMMaster(contractNo);
					pm.PM_STATUS = ((pm.PM_END < DateTime.Today) ? (int)PMContractStatus.Completed : (int)PMContractStatus.Active);
					chkAutoContractNo.Checked = false;
					chkAutoContractNo.Enabled = false;
					txtPMContractNo.Text = pm.PM_CONTRACT_KEY;
					break;
			}

			txtCustCode.Text = pm.PM_CUSTCODE;
			txtCustName.Text = pm.PM_CUSTOMER;
			dtpPMContractDate.Value = pm.PM_CONTRACT_DATE;
			dtpStartDate.Value = pm.PM_START;
			dtpEndDate.Value = pm.PM_END;
			this.lbContractStatus.Tag = pm.PM_STATUS;
			this.lbContractStatus.Text = (pm.PM_STATUS == (int)PMContractStatus.Active ? PMContractStatus.Active.ToString() : PMContractStatus.Completed.ToString());

			// display all machines in PM-contract
			this.showPMMachineList(contractNo);


			this.updateMainUI();
			this.updateMachineListUI();

		} // end getPMContractInfo


		private void showPMMachineList(string contractNo)
		{
			this.dgvMC.SuspendLayout();
			switch (_contractMode)
			{
				case ActionMode.Add:
					this.dgvMC.DataSource = null;
					this.dgvMC.DataSource = mcList.ToList();
					break;

				case ActionMode.Edit:
					this.dgvMC.DataSource = null;

					// get machine from database
					this.dgvMC.DataSource = new PMDal().getPMMachineList(contractNo);

					break;
			}

			this.dgvMC.ResumeLayout();

			this.updateMachineListUI();
		}

		private void pmMachineInfo(string contractNo, string customerCode, string customer, int machineId)
		{
			using (ContractMC _mcContract = new ContractMC(contractNo, customerCode, customer, machineId))
			{
				_mcContract.HeaderMode = _contractMode;
				_mcContract.PMStartDate = this.dtpStartDate.Value;
				_mcContract.StartPosition = FormStartPosition.CenterScreen;

				if (_mcContract.ShowDialog() == DialogResult.OK)
				{
					// re-load machine list
					// update machine list for PM
					if (_contractMode == ActionMode.Add)
					{
						mcList.Add(_mcContract.PMMachine);
					}

					this.showPMMachineList(contractNo);
				}
			}
		}

		private void updatePMContract()
		{
			switch (_contractMode)
			{
				case ActionMode.Add:
					string _pmYear = string.Empty;
					int _latestPMNumber = 0;
					pm = new PMCONTRACT();
					pm.ID = 0;
					pm.MODIDATE = DateTime.Now;
					pm.MODIUSER = omglobal.UserInfo;
					pm.AUDIUSER = omglobal.UserInfo;
					pm.PM_CONTRACT_DATE = this.dtpPMContractDate.Value;

					if (this.chkAutoContractNo.Checked == true)
					{
						this.txtPMContractNo.Text = new PMController().getNewPMContractNo(this.dtpPMContractDate.Value, out _pmYear, out _latestPMNumber);
						pm.PM_CONTRACT_KEY = this.txtPMContractNo.Text;
						pm.PMY = _pmYear;
						pm.RUNNUM = (_latestPMNumber + 1);
					}
					else
					{
						pm.PM_CONTRACT_KEY = this.txtPMContractNo.Text;
						pm.PMY = this.txtPMContractNo.Text.Substring(0, 4);
						pm.RUNNUM = (int.Parse(this.txtPMContractNo.Text.Substring(5)));
					}
					pm.PM_CUSTCODE = this.txtCustCode.Text;
					pm.PM_CUSTOMER = this.txtCustName.Text;
					pm.PM_END = this.dtpEndDate.Value;
					pm.PM_START = this.dtpStartDate.Value;
					pm.PM_STATUS = int.Parse(this.lbContractStatus.Tag.ToString());
					pm.PMMCs = new List<PMMC>();

					foreach (PMMC _mc in mcList.ToList())
					{
						pm.PMMCs.Add(_mc);
					}

					break;

				case ActionMode.Edit:
					pm = new PMDal().getPMMaster(this.txtPMContractNo.Text);
					pm.MODIDATE = DateTime.Now;
					pm.MODIUSER = omglobal.UserInfo;
					pm.PM_START = this.dtpStartDate.Value;
					pm.PM_END = this.dtpEndDate.Value;
					pm.PM_STATUS = int.Parse(this.lbContractStatus.Tag.ToString());
					break;
			}

			// call update PMContract
			// 
			if (new PMDal().updatePMContract(pm) > 0)
			{
				MessageBox.Show($"{(_contractMode == ActionMode.Add ? "Insert" : "Update")} PM Contract successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		#endregion

		public PMInfo()
		{
			InitializeComponent();
		}

		private void dtpStartDate_ValueChanged(object sender, EventArgs e)
		{
			this.dtpEndDate.Value = this.dtpStartDate.Value.AddMonths(12);
		}

		private void PMInfo_Load(object sender, EventArgs e)
		{
			// set the form to center of parent
			this.CenterToParent();
			OMUtils.SettingDataGridView(ref this.dgvMC);

			this.lbMode.Text = (_contractMode = (string.IsNullOrEmpty(this.PMContractNo) ? ActionMode.Add : ActionMode.Edit)).ToString();

			this.getPMContractInfo(this.PMContractNo);
		}

		private void chkAutoContractNo_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkAutoContractNo.Checked)
			{
				txtPMContractNo.Text = "***AUTO***";
				txtPMContractNo.Enabled = false;
			}
			else
			{
				txtPMContractNo.Enabled = true;
				txtPMContractNo.Text = "";
			}
		}

		private void btnAddMC_Click(object sender, EventArgs e)
		{
			selectedPMMachineItemId = 0;

			this.pmMachineInfo(this.txtPMContractNo.Text, this.txtCustCode.Text, this.txtCustName.Text, selectedPMMachineItemId);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void dgvMC_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			int.TryParse(this.dgvMC["PM_MC", e.RowIndex].Value.ToString(), out selectedPMMachineItemId);
			selectedModel = this.dgvMC["PM_MC_MODEL", e.RowIndex].Value.ToString();
			selectedSN = this.dgvMC["PM_MC_SN", e.RowIndex].Value.ToString();

			this.updateMachineListUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.updatePMContract();

			this.Close();
		}

		private void btnEditMC_Click(object sender, EventArgs e)
		{
			this.pmMachineInfo(this.txtPMContractNo.Text, this.txtCustCode.Text, this.txtCustName.Text, selectedPMMachineItemId);
		}

		private void btnDeleteMC_Click(object sender, EventArgs e)
		{
			// delete method, must be delete pm-schedule too
			// only incase of pm-schedule was taken to 
			// service it it not allow to delete.

			switch (_contractMode)
			{
				case ActionMode.Add:

					// check, selected record has row id?
					if (MessageBox.Show("Do you want to delete machine?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						if (this.selectedPMMachineItemId == 0)
						{
							mcList.Remove(mcList.Single(x => x.PM_MC_MODEL == selectedModel && x.PM_MC_SN == selectedSN));

							// refresh UI
							this.dgvMC.DataSource = mcList.ToList();
							this.dgvMC.Refresh();
						}
					}

					break;

				case ActionMode.Edit:
					if (MessageBox.Show($" Select machine : \n Contract-No: {this.txtPMContractNo.Text} \n Machine Model : {selectedModel} \n Serial-No. : {selectedSN} \n\n Do you want to remove form the list ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						// remove the machine
						if (new PMDal().deletePMMachine(selectedPMMachineItemId) > 0)
						{
							Controllers.ToolController.Alert.DisplayAlert("Delete", "Delete machine successfully");
						}
					}

					break;
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			// re-load machine list
			//this.getPMMachines(_pmGuid);
		}

		private void dtpEndDate_ValueChanged(object sender, EventArgs e)
		{
			PMContractStatus _status = ((this.dtpEndDate.Value < DateTime.Today) ? PMContractStatus.Completed : PMContractStatus.Active);
			this.lbContractStatus.Tag = (int)_status;
			this.lbContractStatus.Text = _status.ToString();
		}
	}
}
