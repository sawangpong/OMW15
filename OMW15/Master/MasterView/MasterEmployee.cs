using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Master.MasterView
{
	public partial class MasterEmployee : Form
	{
		#region class field member

		private int _selectedDepartmentId = 0;
		private string _selectedEmployeeCode = string.Empty;
		private int _selectedEmployeeId = 0;

		#endregion

		#region class property
		#endregion

		#region class helper

		private void UpdateUI()
		{

			this.tsbtnEditEmployeeInfo.Enabled = (_selectedEmployeeId > 0);

		} // end UpdateUI

		private void AddChkBox()
		{
			CheckBox _chk = new CheckBox();
			_chk.BackColor = SystemColors.Control;
			_chk.Text = "แสดงรายชื่อพนักงานทั้งหมด";
			_chk.CheckedChanged += new EventHandler(this.CheckChanged);
			_chk.Checked = true;
			_selectedDepartmentId = 0;
			ToolStripControlHost _host = new ToolStripControlHost(_chk);
			_host.BackColor = SystemColors.Control;
			this.ts.Items.Insert(2, _host);

		} // end AddChkBox

		private void CheckChanged(object sender, EventArgs e)
		{
			CheckBox chk = sender as CheckBox;

			this.tscbxDepartment.Visible = !chk.Checked;
			this.tslbDepartment.Visible = this.tscbxDepartment.Visible;
			this.lbDepartment.Visible = this.tscbxDepartment.Visible;

			if (this.tscbxDepartment.Visible == true)
			{
				// load department list
				this.tscbxDepartment.ComboBox.DataSource = this.GetDepartmentList();
				this.tscbxDepartment.ComboBox.DisplayMember = "VALUE";
				this.tscbxDepartment.ComboBox.ValueMember = "KEY";
			}
			else
			{
				_selectedDepartmentId = (chk.Checked == true ? 0 : _selectedDepartmentId);
				this.GetEmployeeList();
			}

		} // end AddChkBox

		private DataTable GetDepartmentList()
		{
			return (Tools.SelectOptions.GetDepartmentCode());
		} // end 

		private void GetEmployeeList()
		{
			this.dgv.SuspendLayout();

			// binding data to datagridview by change type from IEnumerable
			// to datatable
			this.dgv.DataSource = new Master.MasterController.EmployeeDAL().GetEmployeeList();

			// formatting datagridview
			this.dgv.Columns["DEPARTMENTID"].Visible = false;
			this.dgv.Columns["EMPSEQ"].Visible = false;
			this.dgv.Columns["STATUS"].Visible = false;

			this.dgv.Columns["EMPCODE"].HeaderText = "รหัสพนักงาน";
			this.dgv.Columns["GROUPACCOUNT"].HeaderText = "แผนก";
			this.dgv.Columns["DEPARTMENTID"].HeaderText = "รหัสแผนก";
			this.dgv.Columns["EMPNAME"].HeaderText = "ชื่อ - สกุล พนักงาน";
			this.dgv.Columns["EMPSTATUS"].HeaderText = "สถานะการจ้างงาน";

			this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgv.ResumeLayout();

			this.GetEmployeeStatusSummary();

			this.UpdateUI();

		} // end GetEmployeeList

		private void GetEmployeeStatusSummary()
		{
			this.dgvStatus.DataSource = new Master.MasterController.EmployeeDAL().GetSummaryEmployeeStatus();

		} // end GetEmployeeStatusSummary

		private void GetWorkerByDepartment(int DepartmentId)
		{
			// search by string input for customer name
			string _filter = string.Format(
				"[{0}] = {1}", "DEPARTMENTID", DepartmentId);

			// filter rows in DataGridView
			(this.dgv.DataSource as DataTable).DefaultView.RowFilter = _filter;

			this.UpdateUI();

		} // end GetWorkerByDepartment

		private void DisplayEmployeePicture(string EmployeeCode)
		{
			this.pictureBox1.Image = new Master.MasterController.EmployeeDAL().GetEmployeeImage(EmployeeCode);

		} // end DisplayEmployeePicture

		private void GetEmployeeInfo(int EmployeeId)
		{
			Master.MasterView.MasterEmployeeInfo _empInfo = new MasterEmployeeInfo();
			_empInfo.EmployeeId = EmployeeId;
			_empInfo.EmployeeImage = this.pictureBox1.Image;
			_empInfo.StartPosition = FormStartPosition.CenterScreen;
			if (_empInfo.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				this.tsbtnRefresh.PerformClick();
			}
		} // end GetEmployeeInfo

		#endregion


		public MasterEmployee()
		{
			InitializeComponent();
		}

		private void MasterEmployee_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			OMControls.OMUtils.SettingDataGridView(ref this.dgvStatus);
			_selectedDepartmentId = 0;
			this.AddChkBox();
		}

		private void tscbxDepartment_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tscbxDepartment.ComboBox.SelectedValue.GetType() == typeof(System.Int32))
			{
				_selectedDepartmentId = Convert.ToInt32(this.tscbxDepartment.ComboBox.SelectedValue);
			}
			else
			{
				_selectedDepartmentId = 0;
			}

			this.lbDepartment.Text = string.Format("({0})::{1}", _selectedDepartmentId, this.tscbxDepartment.ComboBox.Text);

			if (_selectedDepartmentId > 0)
			{
				this.GetWorkerByDepartment(_selectedDepartmentId);
			}
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedEmployeeCode = this.dgv["EMPCODE", e.RowIndex].Value.ToString();
			_selectedEmployeeId = Convert.ToInt32(this.dgv["EMPSEQ", e.RowIndex].Value);

			this.DisplayEmployeePicture(_selectedEmployeeCode);

			this.UpdateUI();
		}

		private void tsbtnEditEmployeeInfo_Click(object sender, EventArgs e)
		{
			this.GetEmployeeInfo(_selectedEmployeeId);
		}

		private void tsbtnAddEmployee_Click(object sender, EventArgs e)
		{
			_selectedEmployeeId = 0;
			this.GetEmployeeInfo(_selectedEmployeeId);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			if (_selectedDepartmentId > 0)
			{
				this.GetWorkerByDepartment(_selectedDepartmentId);
			}
			else
			{
				this.GetEmployeeList();
			}
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.tsbtnEditEmployeeInfo.PerformClick();
		}

		private void panel5_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
