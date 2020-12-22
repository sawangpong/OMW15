using System;
using System.Data;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CustomerModel;

namespace OMW15.Views.CustomerView
{
	public partial class CustomerGroupList : Form
	{
		// CONSTRUCTOR
		public CustomerGroupList()
		{
			InitializeComponent();
		}

		private void CustomerGroupList_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgvMaster);
			OMUtils.SettingDataGridView(ref dgvMember);
			tsbtnRefresh.PerformClick();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetMasterCustomerGroupList();
		}

		private void dgvMaster_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedCustomerId = Convert.ToInt32(dgvMaster["CUSTID", e.RowIndex].Value);
			_selectedCustomerCode = dgvMaster["CUSTCODE", e.RowIndex].Value.ToString();
			_selectedCustomerName = dgvMaster["CUSTNAME", e.RowIndex].Value.ToString();
			_selectedCustomerGroupKey = dgvMaster["CUSTGROUPKEY", e.RowIndex].Value.ToString();

			GetAsyncCustomerGroupMembers(_selectedCustomerGroupKey);
		}

		private void btnFindMasterCustomer_Click(object sender, EventArgs e)
		{
			// search by string input for customer name
			(dgvMaster.DataSource as DataTable).DefaultView.RowFilter = string.Format(
				"[{0}] LIKE '%{1}%'", "CUSTNAME", OMDataUtils.GetFilter<string>("กำหนดชื่อลูกค้าที่ต้องการค้นหา"));
		}

		private void tsbtnAddGroup_Click(object sender, EventArgs e)
		{
			CustomerGroupInfo();
			//this.tsbtnRefresh.PerformClick();
		}

		private void tsbtnEditGroup_Click(object sender, EventArgs e)
		{
			CustomerGroupInfo();
			//this.tsbtnRefresh.PerformClick();
		}

		private void tsbtnDeleteGroup_Click(object sender, EventArgs e)
		{
			DeleteCustomerGroup(_selectedCustomerGroupKey);
		}

		private void tsbtnDeleteMember_Click(object sender, EventArgs e)
		{
			if (new CustomerDAL().DeleteCustomerGroupMember(_selectedCustomerMemberCode) > 0)
				MessageBox.Show("Delete Member successfully....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			tsbtnRefreshMember.PerformClick();
		}

		private void dgvMember_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedCustomerMemberCode = dgvMember["CUSTCODE", e.RowIndex].Value.ToString();

			UpdateUI();
		}

		private void tsbtnRefreshMember_Click(object sender, EventArgs e)
		{
			GetAsyncCustomerGroupMembers(_selectedCustomerGroupKey);
		}

		#region class field member

		private string _selectedCustomerMemberCode = string.Empty;
		private string _selectedCustomerGroupKey = string.Empty;
		private string _selectedCustomerName = string.Empty;
		private string _selectedCustomerCode = string.Empty;
		private int _selectedCustomerId;

		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			tsbtnEditGroup.Enabled = dgvMaster.Rows.Count > 0 && _selectedCustomerCode != "";
			tsbtnDeleteGroup.Enabled = tsbtnEditGroup.Enabled;
			btnFindMasterCustomer.Enabled = tsbtnEditGroup.Enabled;
			tsbtnDeleteMember.Enabled = !string.IsNullOrEmpty(_selectedCustomerMemberCode);
		} // end UpdateUI

		private async void GetMasterCustomerGroupList()
		{
			var _dal = new CustomerDAL();
			var _dt = await _dal.GetCustomerGroupAsync();

			dgvMaster.SuspendLayout();
			dgvMaster.DataSource = _dt;
			dgvMaster.Columns["CUSTID"].Visible = false;
			dgvMaster.Columns["CUSTGROUPKEY"].Visible = false;
			dgvMaster.Columns["CUSTNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvMaster.Columns["CUSTCODE"].HeaderText = "รหัส";
			dgvMaster.Columns["CUSTNAME"].HeaderText = "ชื่อลูกค้า";
			dgvMaster.ResumeLayout();

			UpdateUI();

			lbMasterCount.Text = $"found : {dgvMaster.Rows.Count}";
		} // end GetMasterCustomerGroupList


		private async void GetAsyncCustomerGroupMembers(string GroupKey)
		{
			var _dal = new CustomerDAL();
			var _dt = await _dal.GetCustomerGroupMemberAsync(GroupKey);

			dgvMember.SuspendLayout();
			dgvMember.DataSource = _dt;
			dgvMember.Columns["CUSTID"].Visible = false;
			dgvMember.Columns["CUSTGROUPKEY"].Visible = false;
			dgvMember.Columns["CUSTNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvMember.Columns["CUSTCODE"].HeaderText = "รหัส";
			dgvMember.Columns["CUSTNAME"].HeaderText = "ชื่อลูกค้า";
			dgvMember.ResumeLayout();

			lbMemberCount.Text = $"found : {dgvMember.Rows.Count}";

			UpdateUI();
		} // end GetAsyncCustomerGroupMembers

		private void CustomerGroupInfo()
		{
			using (var _cgr = new CustomerGroups())
			{
				_cgr.CustomerId = _selectedCustomerId;
				_cgr.CustomerName = _selectedCustomerName;
				_cgr.CustomerCode = _selectedCustomerCode;
				_cgr.CustomerGroupKey = _selectedCustomerGroupKey;
				_cgr.StartPosition = FormStartPosition.CenterParent;
				if (_cgr.ShowDialog() == DialogResult.OK)
				{
				}
			}
		} // end CustomerGroupInfo

		private void DeleteCustomerGroup(string GroupKey)
		{
			if (new CustomerDAL().DeleteCustomerGroup(GroupKey) > 0)
				MessageBox.Show("Delete Customer Group successfully....", "Message", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
		} // end DeleteCustomerGroup

		#endregion
	}
}