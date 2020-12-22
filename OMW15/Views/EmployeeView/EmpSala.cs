using OMControls;
using OMW15.ModelDataExtend;
using OMW15.Models.EmployeeModel;
using System;
using System.Data;
using System.Windows.Forms;

namespace OMW15.Views.EmployeeView
{
	public partial class EmpSala : Form
	{
		#region class field

		private string _empCode = "";
		private EmployeeDisplayRecord _empRecord = new EmployeeDisplayRecord();
		private int _empSalId = 0;
		#endregion

		#region class helper

		private void UpdateUI()
		{
			tsbtnAdd.Enabled = !String.IsNullOrEmpty(_empCode);
			tsbtnEdit.Enabled = (_empSalId > 0);
			tsbtnDelete.Enabled = tsbtnEdit.Enabled;
		}

		private void GetEmpSalaryInfoList(string empCode)
		{
			if (!String.IsNullOrEmpty(empCode))
			{
				dgvSal.SuspendLayout();
				DataTable _dt = new EmployeeDAL().GetSalaryList(empCode);
				dgvSal.DataSource = _dt;


				// formatting display record
				dgvSal.Columns["EMPSALSEQ"].Visible = false;
				dgvSal.Columns["EMPCODE"].Visible = false;

				dgvSal.Columns["YEARSAL"].HeaderText = "ปี";

				dgvSal.Columns["EMPNAME"].HeaderText = "ชื่อพนักงาน";

				dgvSal.Columns["AvgHourCost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dgvSal.Columns["AvgHourCost"].DefaultCellStyle.Format = "N2";
				dgvSal.Columns["AvgHourCost"].HeaderText = "ค่าแรงเฉลี่ย / ช.ม.";

				dgvSal.Columns["AvgActualHourCost"].HeaderText = "ค่าแรจริง / ช.ม.";
				dgvSal.Columns["AvgActualHourCost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dgvSal.Columns["AvgActualHourCost"].DefaultCellStyle.Format = "N2";

				dgvSal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

				dgvSal.ResumeLayout();
			}

			_empSalId = 0;
			UpdateUI();
		}

		private void GetEmpSalInfo(int id)
		{
			using (var ei = new EmpSalInfo(id, _empCode, lbDepartment.Tag.ToString() , lbDepartment.Text))
			{
				ei.StartPosition = FormStartPosition.CenterScreen;
				ei.ShowDialog(this);
			}

			GetEmpSalaryInfoList(_empCode);
		}

		#endregion


		public EmpSala()
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgvSal);
			CenterToScreen();

			_empCode = "";
			lbFullname.Text = "";
		}

		public EmpSala(string empCode, string fullname)
		{
			InitializeComponent();
			CenterToScreen();
			OMUtils.SettingDataGridView(ref dgvSal);

			_empCode = empCode;
			lbFullname.Text = $"{_empCode}::{fullname}";
		}

		private void EmpSala_Load(object sender, EventArgs e)
		{
			pnlResign.Visible = false;

			GetEmpSalaryInfoList(_empCode);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tsbtnEmployee_Click(object sender, EventArgs e)
		{
			using (var el = new EmpList())
			{
				if (el.ShowDialog(this) == DialogResult.OK)
				{
					_empRecord = el.EmpSelected;
					_empCode = _empRecord.EmpCode;
					lbFullname.Text = $"{_empRecord.EmpCode} :: {_empRecord.FullName}";

					lbEmpStatus.Text = _empRecord.StatusName;
					lbEmpStatus.Tag = _empRecord.Status;

					lbDepartment.Text = _empRecord.Department;
					lbDepartment.Tag = _empRecord.DepartmentId;

					switch (_empRecord.Status)
					{
						case 2:
						case 3:
						case 4:
							pnlResign.Visible = true;
							lbResignDate.Text = _empRecord.ResignDate.Num2Date().ToShortDateString();
							break;
						default:
							pnlResign.Visible = false;
							lbResignDate.Text = "";
							break;
					}
				}
			}

			GetEmpSalaryInfoList(_empCode);

			UpdateUI();
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			GetEmpSalInfo(_empSalId);
		}

		private void dgvSal_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_empSalId = int.Parse(dgvSal["EMPSALSEQ", e.RowIndex].Value.ToString());

			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetEmpSalaryInfoList(_empCode);
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("ต้องการลบรายการที่เลือก?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (new EmployeeDAL().DeleteEmpSal(_empSalId) == 0)
				{
					MessageBox.Show("ไม่สามารถลบรายการที่เลือกได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					GetEmpSalaryInfoList(_empCode);
				}
			}
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_empSalId = 0;
			GetEmpSalInfo(_empSalId);
		}

		private void dgvSal_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}
	}
}
