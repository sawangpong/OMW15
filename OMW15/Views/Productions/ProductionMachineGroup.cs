using OMControls;
using OMW15.Models.ProductionModel;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class ProductionMachineGroup : Form
	{
		#region Singleton
		private static ProductionMachineGroup _instance;
		public static ProductionMachineGroup GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new ProductionMachineGroup();
				}
				return _instance;
			}
		}
		#endregion

		#region class fields

		private bool _isGroupFocus = false;
		private bool _isMemberFocus = false;
		private int _selectedMachineGroup = 0;
		private int _selectedMachineMemberId = 0;
		private string _selectedMachineGroupName = string.Empty;

		#endregion

		#region class helper
		private void UpdateUI()
		{
			btnAdd.Enabled = _isGroupFocus;
			btnEdit.Enabled = (btnAdd.Enabled && (_selectedMachineGroup > 0));
			btnDelete.Enabled = btnEdit.Enabled;
			btnRefresh.Enabled = btnAdd.Enabled;
			//btnClose.Enabled = btnAdd.Enabled;

			btnAddMember.Enabled = (_selectedMachineGroup > 0);
			btnEditMember.Enabled = ((_selectedMachineMemberId > 0) && (dgvMember.Rows.Count > 0));
			btnDeleteMember.Enabled = btnEditMember.Enabled;

		}

		private void GetMachineGroup()
		{
			dgv.SuspendLayout();
			dgv.DataSource = new ProductionMachineDAL().GetMachineGroup();

			dgv.Columns["MC_GROUPID"].Visible = false;
			dgv.Columns["MC_GROUPNAME"].HeaderText = "กลุ่มเครื่องจักร";
			dgv.Columns["MC_GROUPNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["MC_MEMBER"].HeaderText = "จำนวนเครื่องจักรในกลุ่ม";
			dgv.Columns["MC_MEMBER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.ResumeLayout();

			_isGroupFocus = true;
			_isMemberFocus = !_isMemberFocus;

			UpdateUI();
		}

		private void GetMachineMember(int group)
		{
			dgvMember.SuspendLayout();
			dgvMember.DataSource = new ProductionMachineDAL().GetMachineMember(group);
			dgvMember.Columns["ID"].Visible = false;
			dgvMember.Columns["MC_GROUP"].Visible = false;
			dgvMember.Columns["MC_NAME"].HeaderText = "ชื่อเครื่องจักร";
			dgvMember.Columns["MC_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvMember.Columns["MC_NUMBER"].HeaderText = "หมายเลขเครื่องจักร";
			dgvMember.Columns["MC_NUMBER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvMember.ResumeLayout();
		}

		private void MachineGroupInfo(int id, string info)
		{
			using (var _mg = new MachineGroupInfo(id, info))
			{
				_mg.StartPosition = FormStartPosition.CenterScreen;
				if (_mg.ShowDialog(this) == DialogResult.OK)
				{
					GetMachineGroup();
				}
			}
		}

		private void MachineGroupMemberInfo(int machineGroupId, string machineGroupName, int machineMemberId)
		{
			using (MachineGroupMemberInfo _mcMember = new MachineGroupMemberInfo(machineGroupId, machineGroupName, machineMemberId))
			{
				_mcMember.StartPosition = FormStartPosition.CenterScreen;
				if (_mcMember.ShowDialog(this) == DialogResult.OK)
				{
					GetMachineMember(machineGroupId);
					GetMachineGroup();
				}
			}
		}

		#endregion

		public ProductionMachineGroup()
		{
			InitializeComponent();

			OMUtils.SettingDataGridView(ref dgv);
			OMUtils.SettingDataGridView(ref dgvMember);
		}

		private void btnClose_Click(object sender, EventArgs e) => this.Close();

		private void ProductionMachineGroup_Load(object sender, EventArgs e) => GetMachineGroup();
		
		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedMachineGroup = Convert.ToInt32(dgv["MC_GROUPID", e.RowIndex].Value.ToString());
			_selectedMachineGroupName = dgv["MC_GROUPNAME", e.RowIndex].Value.ToString();

			GetMachineMember(_selectedMachineGroup);

			UpdateUI();
		}

		private void btnRefresh_Click(object sender, EventArgs e) => GetMachineGroup();

		private void dgv_Enter(object sender, EventArgs e)
		{
			_isGroupFocus = true;
			_isMemberFocus = !_isMemberFocus;
			UpdateUI();
		}

		private void dgvMember_Enter(object sender, EventArgs e)
		{
			_isMemberFocus = true;
			_isGroupFocus = !_isMemberFocus;

			UpdateUI();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			_selectedMachineGroup = 0;
			_selectedMachineGroupName = "";
			MachineGroupInfo(_selectedMachineGroup, _selectedMachineGroupName);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			MachineGroupInfo(_selectedMachineGroup, _selectedMachineGroupName);
		}

		private void dgv_DoubleClick(object sender, EventArgs e) => btnEdit.PerformClick();

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("You want to delete this Machine Group?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if (new ProductionMachineDAL().RemoveMachineGroup(_selectedMachineGroup) > 0)
				{
					MessageBox.Show("Delete Machine Group completed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
					GetMachineGroup();
				}
			}
		}

		private void btnAddMember_Click(object sender, EventArgs e)
		{
			_selectedMachineMemberId = 0;

			MachineGroupMemberInfo(_selectedMachineGroup, _selectedMachineGroupName, _selectedMachineMemberId);
		}

		private void btnDeleteMember_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("You want to delete this machine member?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (new ProductionMachineDAL().RemoveMachineGroupMember(_selectedMachineMemberId) == 0)
				{
					MessageBox.Show("Remove record failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnEditMember_Click(object sender, EventArgs e)
		{
			MachineGroupMemberInfo(_selectedMachineGroup, _selectedMachineGroupName, _selectedMachineMemberId);
		}

		private void dgvMember_DoubleClick(object sender, EventArgs e) => btnEditMember.PerformClick();

		private void dgvMember_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedMachineMemberId = Convert.ToInt32(dgvMember["ID", e.RowIndex].Value.ToString());

			UpdateUI();
		}
	}
}
