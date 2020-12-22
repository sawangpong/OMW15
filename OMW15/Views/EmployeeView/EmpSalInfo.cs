using OMControls.Controls;
using OMW15.Controllers.ToolController;
using OMW15.Models.EmployeeModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Windows.Forms;

namespace OMW15.Views.EmployeeView
{
	public partial class EmpSalInfo : Form
	{
		#region class field
		private int _id = 0;
		private string _department = "";
		private string _departmentCode = "";
		private EMPSAL _empSal;
		private EMPLOYEE _employee;
		private ActionMode _mode = ActionMode.None;

		#endregion

		#region class helper

		private void UpdateUI()
		{
			chkAllYear.Visible = (_mode == ActionMode.Add);

			btnSave.Enabled = !String.IsNullOrEmpty(ntxtCurrentSalary.Text)
									&& !String.IsNullOrEmpty(_empSal.WORKGROUP);
		}

		private void CreateWorkGroups()
		{
			cbxWorkGroup.DataSource = new SelectOptions().GetWorkGroup();
			cbxWorkGroup.DisplayMember = "Value";
			cbxWorkGroup.ValueMember = "Value";
		}

		private void CreateYears()
		{
			cbxYear.DataSource = DataTableTools.GetGeneralYearList();
			cbxYear.DisplayMember = "Y";
			cbxYear.ValueMember = "Y";
		}

		private void GetEmpSal(int id)
		{
			if (id == 0)
			{
				_empSal = new EMPSAL();
				_empSal.AUDITUSER = omglobal.UserName;
				_empSal.MODIUSER = omglobal.UserName;
				_empSal.MODIDATE = DateTime.Now;
				_empSal.ACTUALAVGHOURCOST = 0m;
				_empSal.AVGHOURCOST = 0m;
				_empSal.CURRENT_SAL = 0m;
				_empSal.EMPCODE = "";
				_empSal.EMPCODE = _employee.EMPCODE;
				_empSal.DEPARTMENT = _employee.DEPARTMENTID.ToString();
				_empSal.WORKGROUP = "";
				_empSal.EMPNAME = _employee.EMPFIRSTNAME.Trim() + " " + _employee.EMPLASTNAME;
				_empSal.YEARSAL = DateTime.Today.Year;
				_empSal.PSAL1 = 0m;
				_empSal.PSAL2 = 0m;
				_empSal.PSAL3 = 0m;
				_empSal.PSAL4 = 0m;
				_empSal.PSAL5 = 0m;
				_empSal.PSAL6 = 0m;
				_empSal.PSAL7 = 0m;
				_empSal.PSAL8 = 0m;
				_empSal.PSAL9 = 0m;
				_empSal.PSAL10 = 0m;
				_empSal.PSAL11 = 0m;
				_empSal.PSAL12 = 0m;
			}
			else
			{
				_empSal = new EmployeeDAL().GetEmpSalById(id);
			}

			lbEmpName.Text = $"{_employee.EMPCODE} :: {_empSal.EMPNAME}";
			cbxWorkGroup.SelectedValue = _empSal.WORKGROUP;
			ntxtCurrentSalary.Text = $"{_empSal.CURRENT_SAL:N2}";
			ntxtSalJan.Text = $"{_empSal.PSAL1:N2}";
			ntxtSalFeb.Text = $"{_empSal.PSAL2:N2}";
			ntxtSalMar.Text = $"{_empSal.PSAL3:N2}";
			ntxtSalApr.Text = $"{_empSal.PSAL4:N2}";
			ntxtSalMay.Text = $"{_empSal.PSAL5:N2}";
			ntxtSalJun.Text = $"{_empSal.PSAL6:N2}";
			ntxtSalJul.Text = $"{_empSal.PSAL7:N2}";
			ntxtSalAug.Text = $"{_empSal.PSAL8:N2}";
			ntxtSalSep.Text = $"{_empSal.PSAL9:N2}";
			ntxtSalOct.Text = $"{_empSal.PSAL10:N2}";
			ntxtSalNov.Text = $"{_empSal.PSAL11:N2}";
			ntxtSalDec.Text = $"{_empSal.PSAL12:N2}";
			cbxWorkGroup.SelectedValue = _empSal.WORKGROUP;
			cbxYear.SelectedValue = _empSal.YEARSAL;

			UpdateUI();
		}

		private void GetAverageHourCost(EMPSAL empsal)
		{
			decimal _result = 0m;
			int _base = 0;

			if (empsal.PSAL1 > 0)
			{
				_base++;
				_result += empsal.PSAL1;
			}

			if (empsal.PSAL2 > 0)
			{
				_base++;
				_result += empsal.PSAL2;
			}

			if (empsal.PSAL3 > 0)
			{
				_base++;
				_result += empsal.PSAL3;
			}

			if (empsal.PSAL4 > 0)
			{
				_base++;
				_result += empsal.PSAL4;
			}

			if (empsal.PSAL5 > 0)
			{
				_base++;
				_result += empsal.PSAL5;
			}

			if (empsal.PSAL6 > 0)
			{
				_base++;
				_result += empsal.PSAL6;
			}

			if (empsal.PSAL7 > 0)
			{
				_base++;
				_result += empsal.PSAL7;
			}

			if (empsal.PSAL8 > 0)
			{
				_base++;
				_result += empsal.PSAL8;
			}

			if (empsal.PSAL9 > 0)
			{
				_base++;
				_result += empsal.PSAL9;
			}

			if (empsal.PSAL10 > 0)
			{
				_base++;
				_result += empsal.PSAL10;
			}

			if (empsal.PSAL11 > 0)
			{
				_base++;
				_result += empsal.PSAL11;
			}

			if (empsal.PSAL12 > 0)
			{
				_base++;
				_result += empsal.PSAL12;
			}

			ntxtAvgHourCost.Text = $"{(_result / (_base == 0 ? 1 : _base) / omglobal.TOTAL_MONTH_HOURS):N2}";
			ntxtActualAvgHourCost.Text = $"{(_result / (_base == 0 ? 1 : _base) / omglobal.TOTAL_ACTUAL_MONTH_HOURS):N2}";

		}

		private EMPLOYEE GetEmployeeInfo(string empId) => new EmployeeDAL().GetEmployeeInfo(empId);


		#endregion



		public EmpSalInfo(int empSalId, string empCode, string departmentCode, string department)
		{
			InitializeComponent();
			_id = empSalId;
			_department = department;
			_departmentCode = departmentCode;
			_employee = GetEmployeeInfo(empCode);

			_mode = (_id == 0 ? ActionMode.Add : ActionMode.Edit);

			lbMode.Text = _mode.ToString();
			lbDepartment.Text = _department;

			CreateYears();
			CreateWorkGroups();
		}

		private void EmpSalInfo_Load(object sender, EventArgs e)
		{
			GetEmpSal(_id);

			UpdateUI();
		}

		private void chkAllYear_CheckedChanged(object sender, EventArgs e)
		{
			if (chkAllYear.Checked)
			{
				ntxtSalJan.Text = ntxtCurrentSalary.Text;
				ntxtSalFeb.Text = ntxtCurrentSalary.Text;
				ntxtSalMar.Text = ntxtCurrentSalary.Text;
				ntxtSalApr.Text = ntxtCurrentSalary.Text;
				ntxtSalMay.Text = ntxtCurrentSalary.Text;
				ntxtSalJun.Text = ntxtCurrentSalary.Text;
				ntxtSalJul.Text = ntxtCurrentSalary.Text;
				ntxtSalAug.Text = ntxtCurrentSalary.Text;
				ntxtSalSep.Text = ntxtCurrentSalary.Text;
				ntxtSalOct.Text = ntxtCurrentSalary.Text;
				ntxtSalNov.Text = ntxtCurrentSalary.Text;
				ntxtSalDec.Text = ntxtCurrentSalary.Text;
				ntxtAvgHourCost.Text = $"{(Convert.ToDecimal(ntxtCurrentSalary.Text) / omglobal.TOTAL_MONTH_HOURS):N2}";
				ntxtActualAvgHourCost.Text = $"{(Convert.ToDecimal(ntxtCurrentSalary.Text) / omglobal.TOTAL_ACTUAL_MONTH_HOURS):N2}";
			}
		}

		private void cbxYear_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_empSal.YEARSAL = Convert.ToInt32(cbxYear.SelectedValue);
		}

		private void ntxt_TextChanged(object sender, EventArgs e)
		{
			NumericTextBox ntxt = sender as NumericTextBox;

			int _tag = int.Parse(ntxt.Tag.ToString());
			decimal _value = 0m;

			if (ntxt.Text.IsNumeric())
			{
				_value = decimal.Parse(ntxt.Text);

				switch (_tag)
				{
					case 0:
						_empSal.CURRENT_SAL = _value;
						break;
					case 1:
						_empSal.PSAL1 = _value;
						break;
					case 2:
						_empSal.PSAL2 = _value;
						break;
					case 3:
						_empSal.PSAL3 = _value;
						break;
					case 4:
						_empSal.PSAL4 = _value;
						break;
					case 5:
						_empSal.PSAL5 = _value;
						break;
					case 6:
						_empSal.PSAL6 = _value;
						break;
					case 7:
						_empSal.PSAL7 = _value;
						break;
					case 8:
						_empSal.PSAL8 = _value;
						break;
					case 9:
						_empSal.PSAL9 = _value;
						break;
					case 10:
						_empSal.PSAL10 = _value;
						break;
					case 11:
						_empSal.PSAL11 = _value;
						break;
					case 12:
						_empSal.PSAL12 = _value;
						break;
					case 13:
						_empSal.AVGHOURCOST = _value;
						break;
					case 14:
						_empSal.ACTUALAVGHOURCOST = _value;
						break;
				}

				GetAverageHourCost(_empSal);
			}

			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (new EmployeeDAL().UpdateEmpSal(_empSal) > 0)
			{
				MessageBox.Show("Employee Info successfully updated.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void cbxWorkGroup_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_empSal.WORKGROUP = cbxWorkGroup.SelectedValue.ToString();
			UpdateUI();
		}
	}
}
