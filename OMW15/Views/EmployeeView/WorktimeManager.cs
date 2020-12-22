using OMControls;
using OMW15.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.EmployeeView
{
	public partial class WorktimeManager : Form
	{
		#region Singleton
		public static WorktimeManager _instance;

		public static WorktimeManager GetInstance
		{
			get
			{
				if(_instance == null || _instance.IsDisposed)
				{
					_instance = new WorktimeManager();
				}
				return _instance;
			}
		}

		#endregion

		#region class field
		private bool _canSearch = false;
		private DateTime _selectWorkDate = DateTime.Today;
		#endregion

		#region class helper
		private void UpdateUI()
		{
			btnSearchWorkDate.Enabled = _canSearch;
		}


		#endregion


		public WorktimeManager()
		{
			InitializeComponent();
			_canSearch = false;

			OMUtils.SettingDataGridView(ref dgv);
		}

		private void WorktimeManager_Load(object sender, EventArgs e)
		{
			chkAllRecordInMonth.Checked = true;
			UpdateUI();
		}

		private void btnSearchEmp_Click(object sender, EventArgs e)
		{
			using(var emplist = new ActiveEmps(txtEmpName.Text))
			{
				emplist.WindowState = FormWindowState.Normal;
				emplist.StartPosition = FormStartPosition.CenterScreen;

				if(emplist.ShowDialog(this) == DialogResult.OK)
				{
					txtEmpName.Text = emplist.EmpName;
					lbEmpCode.Text = emplist.EmpCode;
				}
				else
				{
					txtEmpName.Text = "";
					lbEmpCode.Text = "";
				}
			}

			UpdateUI();

			dgv.DataSource = null;
		}


		private void monthPopup1_DateSelected(object sender, EventArgs e)
		{
			if (monthPopup1.SelectedDate <= DateTime.Today)
			{
				_selectWorkDate = monthPopup1.SelectedDate;
				txtDate.Text = monthPopup1.SelectedDate.ToShortDateString();
				_canSearch = true;
			}
			else
			{
				MessageBox.Show("วันที่ทำงานเลือกต้องไม่มากกว่าวันที่ปัจจุบัน","วันที่ทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtDate.Text = DateTime.Today.ToShortDateString();
				_canSearch = false;
			}

			UpdateUI();
		}

		private void monthPopup1_ButtonClick(object sender, EventArgs e)
		{
			monthPopup1.SelectedDate = (string.IsNullOrEmpty(txtDate.Text) ? DateTime.Today : (txtDate.Text.IsDate() ? Convert.ToDateTime(txtDate.Text) : DateTime.Today));
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSearchWorkDate_Click(object sender, EventArgs e)
		{
			//MessageBox.Show($"{_selectWorkDate.Day}");
			dgv.SuspendLayout();
			dgv.DataSource = new EmployeeDAL().GetWorktimeInfo(lbEmpCode.Text, _selectWorkDate, chkAllRecordInMonth.Checked);

			dgv.Columns["hour_in"].Visible = false;
			dgv.Columns["min_in"].Visible = false;
			dgv.Columns["hour_out"].Visible = false;
			dgv.Columns["min_out"].Visible = false;
			dgv.Columns["ValidHour"].Visible = false;
			dgv.Columns["UserCode"].Visible = false;
			dgv.Columns["Y"].Visible = false;
			dgv.Columns["M"].Visible = false;
			dgv.Columns["D"].Visible = false;



			dgv.Columns["EmpCode"].HeaderText = "รหัสพนักงาน";
			dgv.Columns["FullName"].HeaderText = "ชื่อพนักงาน";
			dgv.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["Date_only"].HeaderText = "วันที่ทำงาน";
			dgv.Columns["time_checkin"].HeaderText = "เวลาเข้า";
			dgv.Columns["time_checkout"].HeaderText = "เวลาออก";

	
			dgv.ResumeLayout();
		}

		private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
			{
				btnSearchEmp.PerformClick();
			}
		}
	}
}
