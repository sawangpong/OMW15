using System;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;

namespace OMW15.Views.ToolViews
{
	public partial class UserPermissionManager : Form
	{
		public UserPermissionManager()
		{
			InitializeComponent();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetUserMembers();
		}

		private void UserPermissionManager_Load(object sender, EventArgs e)
		{
			// setting DataGridView
			OMUtils.SettingDataGridView(ref dgv);

			// create object
			_om = new OLDMOONEF1();

			// loading data
			tsbtnRefresh.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedMemberId = Convert.ToInt32(dgv["id", e.RowIndex].Value);
			tslbMemberId.Text = $"id:{_selectedMemberId}";
			UpdateUI();
		}

		private void tsbtnEditMember_Click(object sender, EventArgs e)
		{
			AddEditMember(_selectedMemberId);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEditMember.PerformClick();
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if(dgv["Active", e.RowIndex].Value.ToString() == "N")
			{
				e.CellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
				e.CellStyle.ForeColor = Color.Red;
				e.CellStyle.BackColor = Color.Yellow;
			}
		}

		private void tsbtnAddMember_Click(object sender, EventArgs e)
		{
			_selectedMemberId = 0;
			AddEditMember(_selectedMemberId);
		}

		private void UserPermissionManager_FormClosing(object sender, FormClosingEventArgs e)
		{
			//_om.Dispose();
		}

		#region class field member

		private OLDMOONEF1 _om;
		private int _selectedMemberId;

		#endregion

		#region class properties

		#endregion

		#region class helper

		private void UpdateUI()
		{
			tsbtnEditMember.Enabled = _selectedMemberId > 0;

		} // end UpdateUI

		private string GetUserPermissionClass(int PermissionId)
		{
			return Enum.GetName(typeof(OMShareSysConfigEnums.UserPermission), PermissionId);
		}

		private void GetUserMembers()
		{
			dgv.DataSource = null;

			dgv.SuspendLayout();
			dgv.DataSource = new Models.ToolModel.LoginDAL().GetMemberList();

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.Columns["id"].Visible = false;
			dgv.Columns["Password"].Visible = false;
			dgv.Columns["PermisionId"].Visible = false;
			dgv.Columns["Active"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.ResumeLayout();

			// update members count
			lbMembers.Text = $"Active Members : { ((DataTable)dgv.DataSource).AsEnumerable().Count(x => x.Field<string>("Active") == "Y")}";

			_selectedMemberId = 0;
			UpdateUI();

		} // end GetUserMembers

		private void AddEditMember(int UserId)
		{
			using(var _member = new Member())
			{
				_member.UserId = UserId;
				_member.StartPosition = FormStartPosition.CenterParent;
				_member.ShowDialog(this);
			}

			tsbtnRefresh.PerformClick();
		} // end AddEditMember

		#endregion
	}
}