using OMControls;
using OMW15.ModelDataExtend;
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
	public partial class EmpList : Form
	{

		#region class field
		private EmployeeDisplayRecord _empSelected = new EmployeeDisplayRecord();

		#endregion

		#region class properties
		public EmployeeDisplayRecord EmpSelected { get; set; }
		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnSelect.Enabled = (_empSelected.EmpCode != null);
		}

		private void GetAllEmployees()
		{
			dgv.SuspendLayout();
			dgv.DataSource = new EmployeeDAL().GetAllEmployees();
			dgv.Columns["DepartmentId"].Visible = false;
			dgv.Columns["Status"].Visible = false;

			dgv.Columns["Department"].HeaderText = "แผนก";
			dgv.Columns["StatusName"].HeaderText = "สถานะการจ้างงาน";
			dgv.Columns["EmpCode"].HeaderText = "รหัสพนักงาน";
			dgv.Columns["FullName"].HeaderText = "ชื่อ - นามสกุล";
			dgv.Columns["EmployDate"].HeaderText = "วันที่เริ่มงาน";
			dgv.Columns["ResignDate"].HeaderText = "วันที่สิ้นสุดการทำงาน";

			dgv.Columns["EmployDate"].DefaultCellStyle.Format = "####-##-##";
			dgv.Columns["ResignDate"].DefaultCellStyle.Format = "####-##-##";

			dgv.ResumeLayout();

			_empSelected = null;

			//UpdateUI();
		}

		#endregion

		public EmpList()
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgv);
			btnSelect.Enabled = false;

			CenterToScreen();
		}

		private void EmpList_Load(object sender, EventArgs e)
		{
			this.GetAllEmployees();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_empSelected = new EmployeeDisplayRecord();
			_empSelected.Department = dgv["Department", e.RowIndex].Value.ToString();
			_empSelected.DepartmentId = dgv["DepartmentId", e.RowIndex].Value.ToString();
			_empSelected.EmpCode = dgv["EmpCode", e.RowIndex].Value.ToString();
			_empSelected.EmployDate = dgv["EmployDate", e.RowIndex].Value == null ? 0 : 
				Convert.ToDecimal(dgv["EmployDate", e.RowIndex].Value.ToString());
			_empSelected.FullName = dgv["FullName", e.RowIndex].Value.ToString();
			_empSelected.ResignDate = dgv["ResignDate", e.RowIndex].Value == null ? 0 :
				Convert.ToDecimal(dgv["ResignDate", e.RowIndex].Value.ToString());
			_empSelected.Status = Convert.ToInt32(dgv["Status", e.RowIndex].Value.ToString());
			_empSelected.StatusName = dgv["StatusName", e.RowIndex].Value.ToString();

			this.EmpSelected = _empSelected;

			UpdateUI();

		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.btnSelect.PerformClick();
		}
	}
}
