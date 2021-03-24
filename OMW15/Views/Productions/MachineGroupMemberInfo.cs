using OMW15.Models.ProductModel;
using OMW15.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class MachineGroupMemberInfo : Form
	{
		#region class field
		private PRODUCTION_MC_MEMBER _mcMember = new PRODUCTION_MC_MEMBER();
		private ActionMode _mode = ActionMode.None;
		private int _machineMemberId = 0;
		private int _machineGroupId = 0;
		private string _machineGroupName = string.Empty;	

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnSave.Enabled = (!String.IsNullOrEmpty(txtMachineName.Text) 
									&& !String.IsNullOrEmpty(txtMachineNumber.Text)
									&& !string.IsNullOrEmpty(txtMachineGroup.Text)
									);
		}

		private void GetMCGroupMemberInfo(int id)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_mcMember = new PRODUCTION_MC_MEMBER();
					_mcMember.MC_GROUP = _machineGroupId;
					_mcMember.MC_NAME = "";
					_mcMember.MC_NUMBER = "";
					break;

				case ActionMode.Edit:
					_mcMember = new ProductionMachineDAL().GetMachineGroupMemberInfo(id);
					break;
			}
			txtMachineGroup.Text = _machineGroupName;
			txtMachineGroup.Tag = _mcMember.MC_GROUP;
			txtMachineName.Text = _mcMember.MC_NAME;
			txtMachineNumber.Text = _mcMember.MC_NUMBER;

			UpdateUI();

		}


		#endregion



		public MachineGroupMemberInfo(int machineGroupId,string machineGroupName, int machineMemberId)
		{
			InitializeComponent();
			_machineGroupName = machineGroupName;
			_machineGroupId = machineGroupId;
			_machineMemberId = machineMemberId;
			_mode = _machineMemberId == 0 ? ActionMode.Add : ActionMode.Edit;

			lbTitle.Text = $"เครื่องจักร #{_machineGroupName}";
			lbMode.Text = _mode.ToString().Substring(0, 1).ToUpper();

			GetMCGroupMemberInfo(_machineMemberId);

		}

		private void MachineGroupMemberInfo_Load(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			_mcMember.MC_NAME = txtMachineName.Text;
			_mcMember.MC_NUMBER = txtMachineNumber.Text;

			if(new ProductionMachineDAL().UpdateMachineGroupMember(_mcMember) > 0)
			{
				MessageBox.Show($"{(_mode == ActionMode.Add ? "Machine member added to group": "Update Machine member successfully!")}", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
