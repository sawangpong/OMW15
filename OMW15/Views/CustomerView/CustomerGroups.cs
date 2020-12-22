using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CustomerModel;

namespace OMW15.Views.CustomerView
{
	public partial class CustomerGroups : Form
	{
		#region class field member

		private DataTable _dtMembers;

		#endregion

		public CustomerGroups()
		{
			InitializeComponent();
		}


		private void CustomerGroups_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgvMember);

			// re-write Group info key
			grp.Text = string.Format("Group Info ({0})", CustomerGroupKey);
			lbCustCode.Text = CustomerCode;
			lbCustCode.Tag = CustomerId;
			lbCustName.Text = CustomerName;
			GetCustomerGroupList(CustomerGroupKey);

			ClearUI();
		}

		private void btnFindMember_Click(object sender, EventArgs e)
		{
			FindMember();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			// Modify Datasource

			var _dr = _dtMembers.NewRow();
			_dr["CUSTGROUPKEY"] = CustomerGroupKey;
			_dr["CUSTID"] = Convert.ToInt32(lbMemberCode.Tag);
			_dr["CUSTCODE"] = lbMemberCode.Text;
			_dr["CUSTNAME"] = lbMemberName.Text;

			_dtMembers.Rows.Add(_dr);
			DisplayMemberList(_dtMembers);

			ClearUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var _codeList = new ArrayList();
			foreach (DataGridViewRow dgr in dgvMember.Rows) _codeList.Add(dgr.Cells["CUSTCODE"].Value.ToString());

			if (new CustomerDAL().UpdateCustomerGroups(CustomerGroupKey, (string[]) _codeList.ToArray(typeof(string))) > 0)
				MessageBox.Show("Update Customer Group successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#region class property

		public string CustomerGroupKey { get; set; }

		public int CustomerId { get; set; }

		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnAdd.Enabled = !string.IsNullOrEmpty(lbMemberName.Text);
		} // end UpdateUI

		private void FindMember()
		{
			using (var _cs = new CustomerSearch())
			{
				_cs.StartPosition = FormStartPosition.CenterParent;
				if (_cs.ShowDialog(this) == DialogResult.OK)
				{
					lbMemberCode.Tag = _cs.ERPCustomerId;
					lbMemberCode.Text = _cs.ERPCustomerCode;
					lbMemberName.Text = _cs.CustomerName;
				}
				else
				{
					lbMemberCode.Tag = "";
					lbMemberCode.Text = "";
					lbMemberName.Text = "";
				}
			}

			UpdateUI();
		} // end FindCustomer

		private void CreateMemberListTable()
		{
			_dtMembers = new DataTable();
			_dtMembers.Columns.Add("GROUPKEY", typeof(string));
			_dtMembers.Columns.Add("ID", typeof(string));
			_dtMembers.Columns.Add("CODE", typeof(string));
			_dtMembers.Columns.Add("NAEM", typeof(string));
		} // end CreateMemberListTable


		private async void GetCustomerGroupList(string GroupKey)
		{
			var _dal = new CustomerDAL();
			var _dt = await _dal.GetCustomerGroupMemberAsync(GroupKey);

			_dtMembers = _dt.Copy();

			DisplayMemberList(_dtMembers);

			//this.lbMemberCount.Text = string.Format("found : {0}", this.dgvMember.Rows.Count);
		} // end GetCustomerGroupList


		private void DisplayMemberList(DataTable source)
		{
			dgvMember.SuspendLayout();
			dgvMember.DataSource = source;
			dgvMember.Columns["CUSTID"].Visible = false;
			dgvMember.Columns["CUSTGROUPKEY"].Visible = false;
			dgvMember.Columns["CUSTNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvMember.Columns["CUSTCODE"].HeaderText = "รหัส";
			dgvMember.Columns["CUSTNAME"].HeaderText = "ชื่อลูกค้า";

			dgvMember.ResumeLayout();
		} // end DisplayMemberList

		private void ClearUI()
		{
			lbMemberName.Text = "";
			lbMemberCode.Text = "";
			lbMemberCode.Tag = "";
			UpdateUI();
		}

		#endregion
	}
}