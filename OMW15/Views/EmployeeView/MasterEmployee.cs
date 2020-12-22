using OMControls;
using OMW15.Models.EmployeeModel;
using OMW15.Models.ToolModel;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.EmployeeView
{
	public partial class MasterEmployee : Form
	{
		#region Singleton
		public static MasterEmployee _instance;
		public static MasterEmployee GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed) _instance = new MasterEmployee();
				return _instance;
			}
		}
		#endregion


		#region class field member

		private int _selectedDepartmentId;
		private string _selectedEmployeeCode = string.Empty;
		private int _selectedEmployeeId;

		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			tsbtnEditEmployeeInfo.Enabled = _selectedEmployeeId > 0;
		} // end UpdateUI


		private void GetEmployeeList(int DepartmentId)
		{
			dgv.SuspendLayout();

			// binding data to datagridview by change type from IEnumerable
			// to datatable
			dgv.DataSource = new EmployeeDAL().GetEmployeeList(DepartmentId);

			// formatting datagridview
			dgv.Columns["DEPARTMENTID"].Visible = false;
			dgv.Columns["EMPSEQ"].Visible = false;
			dgv.Columns["STATUS"].Visible = false;

			dgv.Columns["EMPCODE"].HeaderText = "รหัสพนักงาน";
			dgv.Columns["GROUPACCOUNT"].HeaderText = "แผนก";
			dgv.Columns["DEPARTMENTID"].HeaderText = "รหัสแผนก";
			dgv.Columns["EMPNAME"].HeaderText = "ชื่อ - สกุล พนักงาน";
			dgv.Columns["EMPNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["EMPSTATUS"].HeaderText = "สถานะการจ้างงาน";

			dgv.ResumeLayout();
			lbCount.Text = $"found : {dgv.Rows.Count}";

			// clear picture
			pictureBox1.Image = null;

			GetEmployeeStatusSummary();

			UpdateUI();
		} // end GetEmployeeList

		private void GetEmployeeStatusSummary()
		{
			dgvStatus.SuspendLayout();
			dgvStatus.DataSource = new EmployeeDAL().GetSummaryEmployeeStatus();
			dgvStatus.Columns["STATUS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvStatus.ResumeLayout();
		} // end GetEmployeeStatusSummary

		private void DisplayEmployeePicture(string EmployeeCode)
		{
			pictureBox1.Image = new EmployeeDAL().GetEmployeeImage(EmployeeCode);
		} // end DisplayEmployeePicture

		private void GetEmployeeInfo(int EmployeeId)
		{
			var _empInfo = new MasterEmployeeInfo(EmployeeId, pictureBox1.Image);

			//_empInfo.EmployeeId = EmployeeId;
			//_empInfo.EmployeeImage = pictureBox1.Image;

			_empInfo.StartPosition = FormStartPosition.CenterParent;

			if (_empInfo.ShowDialog(this) == DialogResult.OK)
			{
				tsbtnRefresh.PerformClick();
			}

		} // end GetEmployeeInfo


		private void CreateDepartmentMenus()
		{
			var mnu = new ToolStripMenuItem("แสดงรายชื่อทั้งหมด");
			mnu.Tag = 0;
			mnu.Click += mnu_click;
			tsbtnEmpDepartment.DropDownItems.Add(mnu);
			var sep = new ToolStripSeparator();
			tsbtnEmpDepartment.DropDownItems.Add(sep);

			var dt = new SelectOptions().GetDepartmentCode();
			foreach (DataRow dr in dt.Rows)
			{
				mnu = new ToolStripMenuItem(dr["VALUE"].ToString());
				mnu.Tag = dr["KEY"].ToString();
				mnu.Click += mnu_click;
				tsbtnEmpDepartment.DropDownItems.Add(mnu);
			}

		} // end CreateDepartmentMenus

		private void mnu_click(object sender, EventArgs e)
		{
			var mnu = sender as ToolStripMenuItem;
			tsbtnEmpDepartment.Text = $"รายชื่อพนักงาน : ({mnu.Text})";
			_selectedDepartmentId = int.Parse(mnu.Tag.ToString());

			// load employee by Department
			GetEmployeeList(_selectedDepartmentId);

		} // end mnu_click




		#endregion

		public MasterEmployee()
		{
			InitializeComponent();

			// setting DataGridView
			OMUtils.SettingDataGridView(ref dgv);
			OMUtils.SettingDataGridView(ref dgvStatus);

			tsbtnHourCost.Visible = (omglobal.PermisionId == (int)Shared.OMShareSysConfigEnums.UserPermission.SuperAdmin);

			// create menus
			CreateDepartmentMenus();

			_selectedEmployeeId = 0;
			_selectedEmployeeCode = string.Empty;

			this.UpdateUI();

		}

		private void MasterEmployee_Load(object sender, EventArgs e)
		{
			CenterToParent();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedEmployeeCode = dgv["EMPCODE", e.RowIndex].Value.ToString();
			_selectedEmployeeId = Convert.ToInt32(dgv["EMPSEQ", e.RowIndex].Value);

			DisplayEmployeePicture(_selectedEmployeeCode);

			//tsbtnEditEmployeeInfo.Enabled = String.IsNullOrEmpty(_selectedEmployeeCode);

			UpdateUI();
		}

		private void tsbtnEditEmployeeInfo_Click(object sender, EventArgs e)
		{
			GetEmployeeInfo(_selectedEmployeeId);
		}

		private void tsbtnAddEmployee_Click(object sender, EventArgs e)
		{
			_selectedEmployeeId = 0;
			GetEmployeeInfo(_selectedEmployeeId);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetEmployeeList(_selectedDepartmentId);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEditEmployeeInfo.PerformClick();
		}

		private void tsbtnHourCost_Click(object sender, EventArgs e)
		{
			var hc = new Hourcost();
			hc.StartPosition = FormStartPosition.CenterScreen;
			hc.MdiParent = this.ParentForm;
			hc.Show();
		}
	}
}