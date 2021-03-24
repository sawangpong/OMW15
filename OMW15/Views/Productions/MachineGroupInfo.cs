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
	public partial class MachineGroupInfo : Form
	{
		#region class field
		private ActionMode _mode = ActionMode.None;
		private int _groupId = 0;

		#endregion

		#region Class helper
		private void UpdateUI()
		{
			btnSave.Enabled = (!String.IsNullOrEmpty(txtMCGroupName.Text));
		} 

		#endregion

		public MachineGroupInfo(int groupId, string groupName)
		{
			InitializeComponent();
			_groupId = groupId;
			txtMCGroupName.Text = groupName;

			_mode = _groupId > 0 ? ActionMode.Edit : ActionMode.Add;

		}

		private void txtMCGroupName_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			PRODUCTION_MACHINEGROUP mcGroup = new PRODUCTION_MACHINEGROUP();
			mcGroup.MC_GROUPID = _groupId;
			mcGroup.MC_GROUPNAME = txtMCGroupName.Text;

			if(new ProductionMachineDAL().UpdateMachineGroup(mcGroup) > 0)
			{
				MessageBox.Show($"Machine Group {(_mode == ActionMode.Add ? "Added" : "Update successfully.")}", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void txtMCGroupName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
			{
				if (!String.IsNullOrEmpty(txtMCGroupName.Text))
				{
					btnSave.PerformClick();
				}
			}
		}
	}
}
