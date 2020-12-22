using OMW15.Models.EmployeeModel;
using System;
using System.Windows.Forms;

namespace OMW15.Views.EmployeeView
{
	public partial class ActiveEmps : Form
	{
		#region class field 
		private string _nameFilter = "";
		#endregion

		#region class properties
		public string EmpCode { get; set; }
		public string EmpName { get; set; }
		#endregion

		#region class helper
		private void UpdateUI()
		{
			btnSelect.Enabled = (!string.IsNullOrEmpty(this.EmpCode) && dgv.Rows.Count > 0);
		}

		private void GetAvailableEmpList(string nameFilter = "")
		{
			dgv.SuspendLayout();
			dgv.DataSource = new EmployeeDAL().GetAvailableEmployeeList(nameFilter);

			dgv.Columns["EMPCODE"].HeaderText = "รหัสพนักงาน";
			dgv.Columns["FNAME"].HeaderText = "ชื่อพนักงาน";
			dgv.Columns["GROUPACCOUNT"].HeaderText = "สังกัด";
			dgv.Columns["FNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgv.ResumeLayout();

			UpdateUI();
		}

		#endregion


		public ActiveEmps(string nameFilter = "")
		{
			InitializeComponent();

			_nameFilter = nameFilter;
			txtName.Text = _nameFilter;

			OMControls.OMUtils.SettingDataGridView(ref dgv);

			GetAvailableEmpList(_nameFilter);

		}

		private void ActiveEmps_Load(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			this.EmpCode = dgv["EMPCODE", e.RowIndex].Value.ToString();
			this.EmpName = dgv["FNAME", e.RowIndex].Value.ToString();

			UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.EmpCode = "";
			this.EmpName = "";

		}

		private void btnSearchName_Click(object sender, EventArgs e)
		{
			GetAvailableEmpList(txtName.Text);
		}

		private void txtName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
			{
				btnSearchName.PerformClick();
			}
		}
	}
}
