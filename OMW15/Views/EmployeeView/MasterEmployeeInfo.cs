using Microsoft.VisualBasic;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.EmployeeModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using OMW15.Views.CustomerView;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OMW15.Views.EmployeeView
{
	public partial class MasterEmployeeInfo : Form
	{
		#region class field member

		private ActionMode _mode = ActionMode.None;
		private int _selectedDepartmentId;
		private int _selectedEmployeeStatus;
		private int _selectedTitle;
		private int _selectedSex;
		private OMImageDB _imgDb = new OMImageDB();
		private EMPLOYEE _emp = new EMPLOYEE();
		private int _employeeId = 0;
		private Image _employeeImage = null;
		private bool _valid = true;

		#endregion

		#region class property

		//public int EmployeeId { get; set; }

		//public Image EmployeeImage { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			txtEmpCode.Enabled = _mode == ActionMode.Add;
			btnClearPicture.Enabled = pic.Image != null;
			btnSave.Enabled = !string.IsNullOrEmpty(txtEmpCode.Text) & !String.IsNullOrEmpty(txtEmpFirstName.Text);
			//lbDeptId.Text = $"D:{_selectedDepartmentId}|S:{_selectedEmployeeStatus}";
		}

		private void CreateEmployeeStatus()
		{
			cbxEmpStatus.DataSource = new SelectOptions().GetEmployeeStatus();
			cbxEmpStatus.DisplayMember = "VALUE";
			cbxEmpStatus.ValueMember = "KEY";
		} // end CreateEmployeeStatus

		private void GetFamilyStatusList()
		{
			cbxFamilyStatus.DataSource = new SelectOptions().GetFamilyStatusData();
			cbxFamilyStatus.DisplayMember = "VALUE";
			cbxFamilyStatus.ValueMember = "KEY";
		} // end GetFamilyStatusList

		private void CreateDepartmentList()
		{
			cbxDepartment.DataSource = new SelectOptions().GetDepartmentCode();
			cbxDepartment.DisplayMember = "VALUE";
			cbxDepartment.ValueMember = "KEY";
		} // end CreateDepartmentList

		private int GetCurrentAge(DateTime BirthDate)
		{
			var _result = (int)DateAndTime.DateDiff(DateInterval.Year, BirthDate, DateTime.Today);

			return _result;
		} // end GetCurrentAge

		private void SetNewEmployeeUI()
		{
			dtpBirthDate.Value = DateTime.Today;
			dtpEmployDate.Value = DateTime.Today;

			ntxtDayRate.Text = "0";
			ntxtMonthRate.Text = "0";
			ntxtNumberOfChild.Text = "0";
			ntxtProbationDays.Text = "119";

			cbxEducation.Text = string.Empty;
			cbxDepartment.SelectedValue = 1;
			cbxEmpStatus.SelectedValue = 1;
			cbxFamilyStatus.SelectedValue = 1;
			cbxSex.SelectedValue = 1;
			cbxTitle.SelectedValue = 1;

			txtCardAddress1.Text = string.Empty;
			txtCardAddress2.Text = string.Empty;
			txtCardCountry.Text = "ประเทศไทย";
			txtCardPostal.Text = string.Empty;
			txtCardProvince.Text = string.Empty;
			txtCellPhone.Text = string.Empty;
			txtCurrentAddress1.Text = string.Empty;
			txtCurrentAddress2.Text = string.Empty;
			txtCurrentAge.Text = "0";
			txtCurrentCountry.Text = "ประเทศไทย";
			txtCurrentPostal.Text = string.Empty;
			txtCurrentProvince.Text = "กรุงเทพมหานคร";
			txtEmail.Text = string.Empty;
			txtEmpCode.Text = string.Empty;
			txtEmpFirstName.Text = string.Empty;
			txtEmpSurname.Text = string.Empty;
			txtIdCardNumber.Text = string.Empty;
			txtResignDate.Text = string.Empty;
			txtTelephone.Text = string.Empty;

			pic.Image = null;

			UpdateUI();
		} // end SetNewEmployeeUI

		private void GetEmployeeInfo(int EmployeeId)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_emp = new EMPLOYEE();
					_emp.DEPARTMENTID = 111;
					_emp.SEX = "1";
					_emp.TITLENAME = "2";
					_emp.STATUS = 1;
					_emp.FAMILYSTATUS = 1;
					_emp.EDUCATION = "";
					_emp.EMPCODE = "";
					_emp.PROBATIONDAY = 119;
					_emp.EMPLOYDATE = DateTime.Today.Date2Num();
					_emp.ENDPROBATIONDATE = DateTime.Today.AddDays(_emp.PROBATIONDAY.Value).Date2Num();
					_emp.DAYRATE = 0;
					_emp.MONTHRATE = 0;

					break;

				case ActionMode.Edit:
					_emp = new EmployeeDAL().GetEmployeeInfo(EmployeeId);
					break;
			}
			if (_emp != null)
			{
				cbxSex.SelectedValue = _emp.SEX;
				cbxTitle.SelectedValue = _emp.TITLENAME;
				cbxDepartment.SelectedValue = _emp.DEPARTMENTID;
				cbxEmpStatus.SelectedValue = _emp.STATUS;
				cbxFamilyStatus.SelectedValue = _emp.FAMILYSTATUS;
				ntxtNumberOfChild.Text = _emp.NUMBEROFKID.ToString();
				cbxEducation.Text = _emp.EDUCATION;

				txtEmpCode.Text = _emp.EMPCODE;
				txtEmpFirstName.Text = _emp.EMPFIRSTNAME;
				txtEmpSurname.Text = _emp.EMPLASTNAME;
				dtpBirthDate.Value = _emp.BIRTHDATE.Num2Date();
				txtEmail.Text = _emp.EMAIL;
				txtTelephone.Text = _emp.HOMEPHONE;
				txtCellPhone.Text = _emp.CELLPHONE;

				//card ID address
				txtCardAddress1.Text = _emp.CARDADDRESS1;
				txtCardAddress2.Text = _emp.CARDADDRESS2;
				txtCardPostal.Text = _emp.CARDZIPCODE;
				txtCardProvince.Text = _emp.CARDPROVINCE;
				txtCardCountry.Text = _emp.CARDCOUNTRY;

				// currrent address
				txtCurrentAddress1.Text = _emp.CURRENTADDRESS1;
				txtCurrentAddress2.Text = _emp.CURRENTADDRESS2;
				txtCurrentPostal.Text = _emp.CURRENTZIPCODE;
				txtCurrentProvince.Text = _emp.CURRENTPROVINCE;
				txtCurrentCountry.Text = _emp.CURRENTCOUNTRY;

				ntxtNumberOfChild.Text = _emp.NUMBEROFKID.ToString();
				dtpEmployDate.Value = _emp.EMPLOYDATE.Num2Date();
				ntxtProbationDays.Text = _emp.PROBATIONDAY.ToString();
				dtpEndProbationDate.Value = _emp.EMPLOYDATE.Num2Date().AddDays(Convert.ToDouble(_emp.PROBATIONDAY));
				txtResignDate.Text = _emp.RESIGNDATE == 0 ? "" : _emp.RESIGNDATE.Num2Date().ToShortDateString();
				ntxtDayRate.Text = $"{_emp.DAYRATE.ToString():N2}";
				ntxtMonthRate.Text = $"{_emp.MONTHRATE.ToString():N2}";
				pic.Image = _employeeImage;

				HourRateInfo(_emp);

			}

			UpdateUI();
		} // end GetEmployeeInfo

		private void HourRateInfo(EMPLOYEE emp)
		{  // daily Rate
			ntxtHourDayRate.Text = $"{emp.GetDailyHourRate():N2}";
			ntxtOTDayRate.Text = $"{emp.GetDailyOTHourRate():N2}";
			ntxtHolidayOTDayRate.Text = $"{emp.GetDailyHolidayOTHourRate():N2}";

			// monthly Rate
			ntxtHourRate.Text = $"{emp.GetHourRate():N2}";
			ntxtOTRate.Text = $"{emp.GetOTHourRate():N2}";
			ntxtHolidayOTRate.Text = $"{emp.GetHolidayOTHourRate():N2}";

			ntxtActualHourRate.Text = $"{emp.GetActualHourRate():N2}";
			ntxtActualOTRate.Text = $"{emp.GetActualOTHourRate():N2}";
			ntxtActualHolidayOTRate.Text = $"{emp.GetActualHolidayHourRate():N2}";
		}

		private void SaveUpdateEmployeeInfo(int EmployeeId)
		{
			var _emp = new EMPLOYEE();

			_emp.IDCARDNUMBER = txtIdCardNumber.Text;
			_emp.EMPCODE = txtEmpCode.Text;
			_emp.EMPFIRSTNAME = txtEmpFirstName.Text;
			_emp.EMPLASTNAME = txtEmpSurname.Text;
			_emp.DEPARTMENTID = _selectedDepartmentId;
			_emp.GROUPACCOUNT = cbxDepartment.Text;
			_emp.STATUS = _selectedEmployeeStatus;
			_emp.TITLENAME = _selectedTitle.ToString();
			_emp.SEX = _selectedSex.ToString();
			_emp.BIRTHDATE = dtpBirthDate.Value.Date2Num();
			_emp.HOMEPHONE = txtTelephone.Text;
			_emp.CELLPHONE = txtCellPhone.Text;
			_emp.EMAIL = txtEmail.Text;

			_emp.EDUCATION = cbxEducation.Text;
			_emp.NUMBEROFKID = Convert.ToInt32(ntxtNumberOfChild.Text);
			_emp.FAMILYSTATUS = Convert.ToInt32(cbxFamilyStatus.SelectedValue);

			_emp.CARDADDRESS1 = txtCardAddress1.Text;
			_emp.CARDADDRESS2 = txtCardAddress2.Text;
			_emp.CARDPROVINCE = txtCardProvince.Text;
			_emp.CARDZIPCODE = txtCardPostal.Text;
			_emp.CARDCOUNTRY = txtCardCountry.Text;

			_emp.CURRENTADDRESS1 = txtCurrentAddress1.Text;
			_emp.CURRENTADDRESS2 = txtCurrentAddress2.Text;
			_emp.CURRENTPROVINCE = txtCurrentProvince.Text;
			_emp.CURRENTZIPCODE = txtCurrentPostal.Text;
			_emp.CURRENTCOUNTRY = txtCurrentCountry.Text;

			_emp.MONTHRATE = Convert.ToDecimal(ntxtMonthRate.Text);
			_emp.DAYRATE = Convert.ToDecimal(ntxtDayRate.Text);
			_emp.EMPLOYDATE = dtpEmployDate.Value.Date2Num();
			_emp.PROBATIONDAY = Convert.ToInt32(ntxtProbationDays.Text);
			_emp.ENDPROBATIONDATE = dtpEndProbationDate.Value.Date2Num();
			_emp.RESIGNDATE = txtResignDate.Text.Date2Num();

			if (new EmployeeDAL().InsertOrUpdateEmployeeInfo(_emp, EmployeeId) > 0)
			{
				Alert.DisplayAlert("ข้อมูลพนักงาน",
					string.Format("ข้อมูลพนักงาน{0}เรียบร้อยแล้ว", EmployeeId > 0 ? "ปรับปรุง" : "ถูกเพิ่มในฐานข้อมูล"));
			}

			if (pic.Tag.ToString() == "CHANGE")
			{
				// prepare the image to saving
				//_imgDb = new OMControls.OMImageDB();

				var _empic = new EMPLOYPIC();
				// resizing the source Image
				pic.Image = pic.Image.ToImageResize(150, 175);
				_empic.EMPCODE = txtEmpCode.Text;
				_empic.EMPIMG = pic.Image.ConvertImage2Byte();

				if (new EmployeeDAL().InsertOrUpdateEmployeeImage(_empic, txtEmpCode.Text) > 0)
				{
					Alert.DisplayAlert("ข้อมูลพนักงาน",
						string.Format("รูปภาพพนักงาน{0}เรียบร้อยแล้ว", EmployeeId > 0 ? "ปรับปรุง" : "ถูกเพิ่มในฐานข้อมูล"));
				}
			}
		} // end SaveUpdateEmployeeInfo

		private void GetTitleList()
		{
			cbxTitle.DataSource = new SelectOptions().GetTitleTHData();
			cbxTitle.DisplayMember = "VALUE";
			cbxTitle.ValueMember = "KEY";
		} // end GetTitleList

		private void GetSexList()
		{
			cbxSex.DataSource = new SelectOptions().GetSexTHData();
			cbxSex.DisplayMember = "VALUE";
			cbxSex.ValueMember = "KEY";
		} // end GetSexList

		private void GetEducationList()
		{
			cbxEducation.DataSource = new EmployeeDAL().GetEmployeeEducation();
			cbxEducation.DisplayMember = "VALUE";
			cbxEducation.ValueMember = "KEY";
		} // end GetEduationList

		#endregion

		public MasterEmployeeInfo(int empId, Image empImage)
		{
			InitializeComponent();

			_employeeId = empId;
			_employeeImage = empImage;

			// create data
			CreateDepartmentList();
			CreateEmployeeStatus();
			GetSexList();
			GetTitleList();
			GetEducationList();
			GetFamilyStatusList();

			_mode = _employeeId == 0 ? ActionMode.Add : ActionMode.Edit;
			lbMode.Text = _mode.ToString();
		}

		private void MasterEmployeeInfo_Load(object sender, EventArgs e)
		{
			CenterToParent();
			GetEmployeeInfo(_employeeId);

			//switch (_mode)
			//{
			//	case ActionMode.Add:
			//		SetNewEmployeeUI();
			//		break;
			//	case ActionMode.Edit:
			//		GetEmployeeInfo(EmployeeId);
			//		break;
			//}
		}

		private void cbxDepartment_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (cbxDepartment.SelectedValue.GetType() == typeof(int))
				{
					_selectedDepartmentId = (int)cbxDepartment.SelectedValue;
				}
				else
				{
					_selectedDepartmentId = 0;
				}
			}
			catch
			{
				_selectedDepartmentId = 0;
			}

			UpdateUI();
		}

		private void cbxEmpStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbxEmpStatus.SelectedValue.GetType() == typeof(int))
			{
				_selectedEmployeeStatus = (int)cbxEmpStatus.SelectedValue;
			}
			else
			{
				_selectedEmployeeStatus = 0;
			}

			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveUpdateEmployeeInfo(_employeeId);
		}

		private void cbxTitle_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbxTitle.SelectedValue.GetType() == typeof(int))
			{
				_selectedTitle = Convert.ToInt32(cbxTitle.SelectedValue);
			}
			else
			{
				_selectedTitle = 0;
			}

			//lbSexTitle.Text = string.Format("Sex[{0}]:Title[{1}]", _selectedSex, _selectedTitle);
		}

		private void cbxSex_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (cbxSex.SelectedValue.GetType() == typeof(int))
				{
					_selectedSex = Convert.ToInt32(cbxSex.SelectedValue);
				}
				else
				{
					_selectedSex = 1;
				}
			}
			catch
			{
				_selectedSex = 1;
			}

			//lbSexTitle.Text = $"Sex[{_selectedSex}]:Title[{_selectedTitle}]";
		}

		private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
		{
			txtCurrentAge.Text = GetCurrentAge(dtpBirthDate.Value).ToString();
		}

		private void btnCurrentProvince_Click(object sender, EventArgs e)
		{
			var _selectedName = txtCurrentProvince.Text;
			var _selectedCode = string.Empty;
			var _selectedId = 0;

			ToolGetData.GetData(SelectTypeOption.Province, ref _selectedName, ref _selectedCode, ref _selectedId);

			txtCurrentProvince.Text = _selectedName;
		}

		private void btnProvince_Click(object sender, EventArgs e)
		{
			var _btn = sender as OMFlatButton;
			var _source = OMShareCustomerEnums.AddressSource.ProvinceCurrentAddress;
			var _selectedProvice = string.Empty;

			switch (_btn.Tag.ToString().ToUpper())
			{
				case "PROVICE_CURRENT":
					_source = OMShareCustomerEnums.AddressSource.ProvinceCurrentAddress;
					break;
				case "PROVICE_CARD":
					_source = OMShareCustomerEnums.AddressSource.ProvinceFromCardId;
					break;
			}

			using (var _province = new SelectProvince(_source))
			{
				if (_province.ShowDialog(this) == DialogResult.OK)
				{
					_selectedProvice = _province.SelectedResut;
				}
				else
				{
					_selectedProvice = string.Empty;
				}
			}

			switch (_btn.Tag.ToString().ToUpper())
			{
				case "PROVICE_CURRENT":
					txtCurrentProvince.Text = string.IsNullOrEmpty(_selectedProvice) ? txtCurrentProvince.Text : _selectedProvice;
					break;
				case "PROVICE_CARD":
					txtCardProvince.Text = string.IsNullOrEmpty(_selectedProvice) ? txtCardProvince.Text : _selectedProvice;
					break;
			}
		}

		private void btnCountry_Click(object sender, EventArgs e)
		{
			var _btn = sender as OMFlatButton;
			var _source = OMShareCustomerEnums.AddressSource.CountryCurrentAddress;
			var _selectedCountry = string.Empty;

			switch (_btn.Tag.ToString().ToUpper())
			{
				case "COUNTRY_CURRENT":
					_source = OMShareCustomerEnums.AddressSource.CountryCurrentAddress;
					break;
				case "COUNTRY_CARD":
					_source = OMShareCustomerEnums.AddressSource.CountryFromCardId;
					break;
			}

			using (var _country = new SelectProvince(_source))
			{
				if (_country.ShowDialog(this) == DialogResult.OK)
				{
					_selectedCountry = _country.SelectedResut;
				}
				else
				{
					_selectedCountry = string.Empty;
				}
			}

			switch (_btn.Tag.ToString().ToUpper())
			{
				case "COUNTRY_CURRENT":
					txtCurrentCountry.Text = string.IsNullOrEmpty(_selectedCountry) ? txtCurrentCountry.Text : _selectedCountry;
					break;
				case "COUNTRY_CARD":
					txtCardCountry.Text = string.IsNullOrEmpty(_selectedCountry) ? txtCardCountry.Text : _selectedCountry;
					break;
			}
		}

		private void btnChangePicture_Click(object sender, EventArgs e)
		{
			pic.Tag = "CHANGE";
			_imgDb = new OMImageDB();
			var _img = _imgDb.GetImageFile();
			if (_img != null) pic.Image = _img.ToImageResize(150, 175);
		}

		private void btnClearPicture_Click(object sender, EventArgs e)
		{
			pic.Image = null;
			pic.Tag = "CHANGE";
		}

		private void btnWorkEndDate_ButtonClick(object sender, EventArgs e)
		{
			var _btn = sender as MonthPopup;
			_btn.SelectedDate = string.IsNullOrEmpty(txtResignDate.Text)
				? DateTime.Today
				: Convert.ToDateTime(txtResignDate.Text);
		}

		private void btnWorkEndDate_DateSelected(object sender, EventArgs e)
		{
			var _btn = sender as MonthPopup;

			txtResignDate.Text = _btn.SelectedDate.IsDate()
				? _btn.SelectedDate.ToShortDateString()
				: DateTime.Today.ToShortDateString();
		}

		private void ntxtHourRate_TextChanged(object sender, EventArgs e)
		{
			EMPLOYEE _empHourRate = new EMPLOYEE();
			decimal _dailyRate = String.IsNullOrEmpty(ntxtDayRate.Text) ? 0m : Convert.ToDecimal(ntxtDayRate.Text);
			decimal _monthlyRate = String.IsNullOrEmpty(ntxtMonthRate.Text) ? 0m : Convert.ToDecimal(ntxtMonthRate.Text);

			_empHourRate.DAYRATE = _dailyRate;
			_empHourRate.MONTHRATE = _monthlyRate;

			HourRateInfo(_empHourRate);
		}


		private void txtEmpCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//if(_valid == false)
			//{
			//	e.Cancel = true;
			//}

		}

		private void txtEmpCode_Validated(object sender, EventArgs e)
		{
			_valid = new EmployeeDAL().CheckValidEmployeeCode(txtEmpCode.Text);
			if (_valid)
			{
				MessageBox.Show("This code already use by another employee..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

			}
		}

		//private void btnSalary_Click(object sender, EventArgs e)
		//{
		//	string _fullName = _emp.EMPFIRSTNAME.Trim() + " " + _emp.EMPLASTNAME;
		//	using (EmpSala sala = new EmpSala(_emp.EMPCODE, _fullName))
		//	{
		//		sala.ShowDialog(this);
		//	}
		//}
	}
}