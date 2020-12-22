using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;

namespace OMW15.Tools
{
	public partial class UserPermissionManager : Form
	{
		#region class field member
		private OLDMOONEF _om;
		private int _selectedMemberId = 0;

		#endregion

		#region class properties

		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.tsbtnEditMember.Enabled = (_selectedMemberId > 0);

		} // end UpdateUI

		private string GetUserPermissionClass(int PermissionId)
		{
			return Enum.GetName(typeof(OMShareSysConfigEnums.UserPermission), PermissionId).ToString();
		}

		private void GetUserMembers()
		{
			//var permissions = OMControls.OMDataUtils.GetValueList<UserPermission>();
			// ---- Look here
			// get user list from login
			//var users = (from u in _om.LOGINs
			//			 select u).ToList();

			// join 2 queries 
			var members = from u in _om.LOGINs
						  select new
						  {
							  id = u.id,
							  UserName = u.uname,
							  Password = u.password,
							  PermisionId = u.permissionid,
							  Class = u.auditclass,
							  Active = u.islock == true ? "N" : "Y"
						  };
			this.dgv.SuspendLayout();
			this.dgv.DataSource = members.ToList();
			this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv.Columns["id"].Visible = false;
			this.dgv.Columns["Password"].Visible = false;
			this.dgv.Columns["PermisionId"].Visible = false;
			this.dgv.Columns["Active"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dgv.ResumeLayout();
	
			// update members count
			this.lbMembers.Text = string.Format("Active Members : {0}", members.Count(x => x.Active == "Y"));

			_selectedMemberId = 0;
			this.UpdateUI();

		} // end GetUserMembers

		private void AddEditMember(int UserId)
		{
			using (Tools.Member _member = new Member())
			{
				_member.UserId = UserId;
				_member.StartPosition = FormStartPosition.CenterScreen;
				_member.ShowDialog(this);
			}

			this.tsbtnRefresh.PerformClick();

		} // end AddEditMember

		#endregion

		public UserPermissionManager()
		{
			InitializeComponent();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.GetUserMembers();
		}

		private void UserPermissionManager_Load(object sender, EventArgs e)
		{
			// setting DataGridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			// create object
			_om = new OLDMOONEF();

			// loading data
			this.tsbtnRefresh.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedMemberId = Convert.ToInt32(this.dgv["id", e.RowIndex].Value);
			this.tslbMemberId.Text = string.Format("id:{0}", _selectedMemberId);
			this.UpdateUI();
		}

		private void tsbtnEditMember_Click(object sender, EventArgs e)
		{
			this.AddEditMember(_selectedMemberId);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.tsbtnEditMember.PerformClick();
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (this.dgv["Active", e.RowIndex].Value.ToString() == "N")
			{
				e.CellStyle.Font = new Font(this.dgv.Font, FontStyle.Bold);
				e.CellStyle.ForeColor = Color.Red;
				e.CellStyle.BackColor = Color.Yellow;
			}
		}

		private void tsbtnAddMember_Click(object sender, EventArgs e)
		{
			_selectedMemberId = 0;
			this.AddEditMember(_selectedMemberId);
		}

		private void UserPermissionManager_FormClosing(object sender, FormClosingEventArgs e)
		{
			//_om.Dispose();
		}
	}
}
