using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Master.MasterView
{
	public partial class MasterEmployeeInfo : Form
	{

		#region class field member

		private ActionMode _mode = ActionMode.None;
		private int _selectedDepartmentId = 0;
		private int _selectedEmployeeStatus = 0;
		private int _selectedTitle = 0;
		private int _selectedSex = 0;
		private OMControls.OMImageDB _imgDb = new OMControls.OMImageDB();

		#endregion

		#region class property
		public int EmployeeId
		{
			get;
			set;
		}

		public Image EmployeeImage
		{
			get;
			set;
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.txtEmpCode.Enabled = (_mode == ActionMode.Add);
			this.btnClearPicture.Enabled = (this.pic.Image != null);
			this.btnSave.Enabled = !string.IsNullOrEmpty(this.txtEmpCode.Text);
			this.lbDeptId.Text = string.Format("D:{0}|S:{1}", _selectedDepartmentId, _selectedEmployeeStatus);
		}

		private void CreateEmployeeStatus()
		{
			this.cbxEmpStatus.DataSource = Tools.SelectOptions.GetEmployeeStatus();
			this.cbxEmpStatus.DisplayMember = "VALUE";
			this.cbxEmpStatus.ValueMember = "KEY";

		} // end CreateEmployeeStatus

		private void GetFamilyStatusList()
		{
			this.cbxFamilyStatus.DataSource = Tools.SelectOptions.GetFamilyStatusData();
			this.cbxFamilyStatus.DisplayMember = "VALUE";
			this.cbxFamilyStatus.ValueMember = "KEY";

		} // end GetFamilyStatusList

		private void CreateDepartmentList()
		{
			this.cbxDepartment.DataSource = Tools.SelectOptions.GetDepartmentCode();
			this.cbxDepartment.DisplayMember = "VALUE";
			this.cbxDepartment.ValueMember = "KEY";

		} // end CreateDepartmentList

		private int GetCurrentAge(DateTime BirthDate)
		{
			int _result = (int)Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Year, BirthDate, DateTime.Today);

			return _result;

		} // end GetCurrentAge

		private void SetNewEmployeeUI()
		{
			this.dtpBirthDate.Value = DateTime.Today;
			this.dtpEmployDate.Value = DateTime.Today;

			this.ntxtDayRate.Text = "0";
			this.ntxtMonthRate.Text = "0";
			this.ntxtNumberOfChild.Text = "0";
			this.ntxtProbationDays.Text = "119";

			this.cbxEducation.Text = string.Empty;
			this.cbxDepartment.SelectedValue = 1;
			this.cbxEmpStatus.SelectedValue = 1;
			this.cbxFamilyStatus.SelectedValue = 1;
			this.cbxSex.SelectedValue = 1;
			this.cbxTitle.SelectedValue = 1;

			this.txtCardAddress1.Text = string.Empty;
			this.txtCardAddress2.Text = string.Empty;
			this.txtCardCountry.Text = "ประเทศไทย";
			this.txtCardPostal.Text = string.Empty;
			this.txtCardProvince.Text = string.Empty;
			this.txtCellPhone.Text = string.Empty;
			this.txtCurrentAddress1.Text = string.Empty;
			this.txtCurrentAddress2.Text = string.Empty;
			this.txtCurrentAge.Text = "0";
			this.txtCurrentCountry.Text = "ประเทศไทย";
			this.txtCurrentPostal.Text = string.Empty;
			this.txtCurrentProvince.Text = "กรุงเทพมหานคร";
			this.txtEmail.Text = string.Empty;
			this.txtEmpCode.Text = string.Empty;
			this.txtEmpFirstName.Text = string.Empty;
			this.txtEmpSurname.Text = string.Empty;
			this.txtIdCardNumber.Text = string.Empty;
			this.txtResignDate.Text = string.Empty;
			this.txtTelephone.Text = string.Empty;

			this.pic.Image = null;

			this.UpdateUI();

		} // end SetNewEmployeeUI

		private void GetEmployeeInfo(int EmployeeId)
		{
			EMPLOYEE _emp = new Master.MasterController.EmployeeDAL().GetEmployeeInfo(EmployeeId);
			this.cbxSex.SelectedValue = _emp.SEX;
			this.cbxTitle.SelectedValue = _emp.TITLENAME;
			this.cbxDepartment.SelectedValue = _emp.DEPARTMENTID;
			this.cbxEmpStatus.SelectedValue = _emp.STATUS;
			this.cbxFamilyStatus.SelectedValue = _emp.FAMILYSTATUS;
			this.ntxtNumberOfChild.Text = _emp.NUMBEROFKID.ToString();
			this.cbxEducation.Text = _emp.EDUCATION;

			this.txtEmpCode.Text = _emp.EMPCODE;
			this.txtEmpFirstName.Text = _emp.EMPFIRSTNAME;
			this.txtEmpSurname.Text = _emp.EMPLASTNAME;
			this.dtpBirthDate.Value = OMControls.OMUtils.Num2Date(_emp.BIRTHDATE);
			this.txtEmail.Text = _emp.EMAIL;
			this.txtTelephone.Text = _emp.HOMEPHONE;
			this.txtCellPhone.Text = _emp.CELLPHONE;

			// Card ID address
			this.txtCardAddress1.Text = _emp.CARDADDRESS1;
			this.txtCardAddress2.Text = _emp.CARDADDRESS2;
			this.txtCardPostal.Text = _emp.CARDZIPCODE;
			this.txtCardProvince.Text = _emp.CARDPROVINCE;
			this.txtCardCountry.Text = _emp.CARDCOUNTRY;

			// current address
			this.txtCurrentAddress1.Text = _emp.CURRENTADDRESS1;
			this.txtCurrentAddress2.Text = _emp.CURRENTADDRESS2;
			this.txtCurrentPostal.Text = _emp.CURRENTZIPCODE;
			this.txtCurrentProvince.Text = _emp.CURRENTPROVINCE;
			this.txtCurrentCountry.Text = _emp.CURRENTCOUNTRY;

			this.ntxtNumberOfChild.Text = _emp.NUMBEROFKID.ToString();
			this.dtpEmployDate.Value = OMControls.OMUtils.Num2Date(_emp.EMPLOYDATE);
			this.ntxtProbationDays.Text = _emp.PROBATIONDAY.ToString();
			this.dtpEndProbationDate.Value = OMControls.OMUtils.Num2Date(_emp.EMPLOYDATE).AddDays(Convert.ToDouble(_emp.PROBATIONDAY));
			this.ntxtDayRate.Text = _emp.DAYRATE.ToString();
			this.ntxtMonthRate.Text = _emp.MONTHRATE.ToString();

			this.pic.Image = this.EmployeeImage;

			this.UpdateUI();

		} // end GetEmployeeInfo

		private void SaveUpdateEmployeeInfo(int EmployeeId)
		{
			EMPLOYEE _emp = new EMPLOYEE();

			_emp.IDCARDNUMBER = this.txtIdCardNumber.Text;
			_emp.EMPCODE = this.txtEmpCode.Text;
			_emp.EMPFIRSTNAME = this.txtEmpFirstName.Text;
			_emp.EMPLASTNAME = this.txtEmpSurname.Text;
			_emp.DEPARTMENTID = _selectedDepartmentId;
			_emp.GROUPACCOUNT = this.cbxDepartment.Text;
			_emp.STATUS = _selectedEmployeeStatus;
			_emp.TITLENAME = _selectedTitle.ToString();
			_emp.SEX = _selectedSex.ToString();
			_emp.BIRTHDATE = OMControls.OMUtils.Date2Num(this.dtpBirthDate.Value);
			_emp.HOMEPHONE = this.txtTelephone.Text;
			_emp.CELLPHONE = this.txtCellPhone.Text;
			_emp.EMAIL = this.txtEmail.Text;

			_emp.EDUCATION = this.cbxEducation.Text;
			_emp.NUMBEROFKID = Convert.ToInt32(this.ntxtNumberOfChild.Text);
			_emp.FAMILYSTATUS = Convert.ToInt32(this.cbxFamilyStatus.SelectedValue);

			_emp.CARDADDRESS1 = this.txtCardAddress1.Text;
			_emp.CARDADDRESS2 = this.txtCardAddress2.Text;
			_emp.CARDPROVINCE = this.txtCardProvince.Text;
			_emp.CARDZIPCODE = this.txtCardPostal.Text;
			_emp.CARDCOUNTRY = this.txtCardCountry.Text;

			_emp.CURRENTADDRESS1 = this.txtCurrentAddress1.Text;
			_emp.CURRENTADDRESS2 = this.txtCurrentAddress2.Text;
			_emp.CURRENTPROVINCE = this.txtCurrentProvince.Text;
			_emp.CURRENTZIPCODE = this.txtCurrentPostal.Text;
			_emp.CURRENTCOUNTRY = this.txtCurrentCountry.Text;

			_emp.MONTHRATE = Convert.ToDecimal(this.ntxtMonthRate.Text);
			_emp.DAYRATE = Convert.ToDecimal(this.ntxtDayRate.Text);
			_emp.EMPLOYDATE = OMControls.OMUtils.Date2Num(this.dtpEmployDate.Value);
			_emp.PROBATIONDAY = Convert.ToInt32(this.ntxtProbationDays.Text);
			_emp.ENDPROBATIONDATE = OMControls.OMUtils.Date2Num(this.dtpEndProbationDate.Value);
			_emp.RESIGNDATE = string.IsNullOrEmpty(this.txtResignDate.Text) ? 0 : OMControls.OMUtils.Date2Num(this.txtResignDate.Text);

			if (new Master.MasterController.EmployeeDAL().InsertOrUpdateEmployeeInfo(_emp, EmployeeId) > 0)
			{
				omglobal.DisplayAlert("ข้อมูลพนักงาน", string.Format("ข้อมูลพนักงาน{0}เรียบร้อยแล้ว", EmployeeId > 0 ? "ปรับปรุง" : "ถูกเพิ่มในฐานข้อมูล"));
			}

			if (this.pic.Tag.ToString() == "CHANGE")
			{
				// prepare the image to saving
				_imgDb = new OMControls.OMImageDB();

				EMPLOYPIC _empic = new EMPLOYPIC();
				// resizing the source Image
				this.pic.Image = _imgDb.ResizeImage((Bitmap)this.pic.Image, 150, 175, 80);
				_empic.EMPCODE = this.txtEmpCode.Text;
				_empic.EMPIMG = OMControls.OMUtils.ConvertImage2Byte(this.pic.Image);

				if (new Master.MasterController.EmployeeDAL().InsertOrUpdateEmployeeImage(_empic, this.txtEmpCode.Text) > 0)
				{
					omglobal.DisplayAlert("ข้อมูลพนักงาน", string.Format("รูปภาพพนักงาน{0}เรียบร้อยแล้ว", EmployeeId > 0 ? "ปรับปรุง" : "ถูกเพิ่มในฐานข้อมูล"));
				}
			}

		} // end SaveUpdateEmployeeInfo

		private void GetTitleList()
		{
			this.cbxTitle.DataSource = Tools.SelectOptions.GetTitleTHData();
			this.cbxTitle.DisplayMember = "VALUE";
			this.cbxTitle.ValueMember = "KEY";


		} // end GetTitleList

		private void GetSexList()
		{
			this.cbxSex.DataSource = Tools.SelectOptions.GetSexTHData();
			this.cbxSex.DisplayMember = "VALUE";
			this.cbxSex.ValueMember = "KEY";
		} // end GetSexList

		private void GetEducationList()
		{
			this.cbxEducation.DataSource = new Master.MasterController.EmployeeDAL().GetEmployeeEducation();
			this.cbxEducation.DisplayMember = "VALUE";
			this.cbxEducation.ValueMember = "KEY";

		} // end GetEduationList

		#endregion



		public MasterEmployeeInfo()
		{
			InitializeComponent();
		}

		private void MasterEmployeeInfo_Load(object sender, EventArgs e)
		{
			// create data
			this.CreateDepartmentList();
			this.CreateEmployeeStatus();
			this.GetSexList();
			this.GetTitleList();
			this.GetEducationList();
			this.GetFamilyStatusList();

			_mode = (this.EmployeeId == 0 ? ActionMode.Add : ActionMode.Edit);
			this.lbMode.Text = _mode.ToString();

			switch (_mode)
			{
				case ActionMode.Add:
					this.SetNewEmployeeUI();
					break;
				case ActionMode.Edit:
					this.GetEmployeeInfo(this.EmployeeId);
					break;
			}
		}

		private void cbxDepartment_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.cbxDepartment.SelectedValue.GetType() == typeof(System.Int32))
				{
					_selectedDepartmentId = (int)this.cbxDepartment.SelectedValue;
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

			this.UpdateUI();
		}

		private void cbxEmpStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cbxEmpStatus.SelectedValue.GetType() == typeof(System.Int32))
			{
				_selectedEmployeeStatus = (int)this.cbxEmpStatus.SelectedValue;
			}
			else
			{
				_selectedEmployeeStatus = 0;
			}

			this.UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.SaveUpdateEmployeeInfo(this.EmployeeId);
		}

		private void cbxTitle_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cbxTitle.SelectedValue.GetType() == typeof(System.Int32))
			{
				_selectedTitle = Convert.ToInt32(this.cbxTitle.SelectedValue);
			}
			else
			{
				_selectedTitle = 0;
			}

			this.lbSexTitle.Text = string.Format("Sex[{0}]:Title[{1}]", _selectedSex, _selectedTitle);
		}

		private void cbxSex_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.cbxSex.SelectedValue.GetType() == typeof(System.Int32))
				{
					_selectedSex = Convert.ToInt32(this.cbxSex.SelectedValue);
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

			this.lbSexTitle.Text = string.Format("Sex[{0}]:Title[{1}]", _selectedSex, _selectedTitle);
		}

		private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
		{
			this.txtCurrentAge.Text = this.GetCurrentAge(this.dtpBirthDate.Value).ToString();
		}

		private void btnCurrentProvince_Click(object sender, EventArgs e)
		{
			string _selectedName = this.txtCurrentProvince.Text;
			string _selectedCode = string.Empty;
			int _selectedId = 0;

			Tools.SelectOptions.GetData(SelectTypeOption.Province, ref _selectedName, ref _selectedCode, ref _selectedId);

			this.txtCurrentProvince.Text = _selectedName;

		}

		private void btnProvince_Click(object sender, EventArgs e)
		{
			OMControls.OMFlatButton _btn = sender as OMControls.OMFlatButton;
			AddressSource _source = AddressSource.ProvinceCurrentAddress;
			string _selectedProvice = string.Empty;


			switch (_btn.Tag.ToString().ToUpper())
			{
				case "PROVICE_CURRENT":
					_source = AddressSource.ProvinceCurrentAddress;
					break;
				case "PROVICE_CARD":
					_source = AddressSource.ProvinceFromCardId;
					break;
			}

			using (Master.MasterView.SelectProvince _province = new SelectProvince(_source))
			{
				if (_province.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
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
					this.txtCurrentProvince.Text = string.IsNullOrEmpty(_selectedProvice) ? this.txtCurrentProvince.Text : _selectedProvice;
					break;
				case "PROVICE_CARD":
					this.txtCardProvince.Text = string.IsNullOrEmpty(_selectedProvice) ? this.txtCardProvince.Text : _selectedProvice;
					break;
			}

		}

		private void btnCountry_Click(object sender, EventArgs e)
		{
			OMControls.OMFlatButton _btn = sender as OMControls.OMFlatButton;
			AddressSource _source = AddressSource.CountryCurrentAddress;
			string _selectedCountry = string.Empty;

			switch (_btn.Tag.ToString().ToUpper())
			{
				case "COUNTRY_CURRENT":
					_source = AddressSource.CountryCurrentAddress;
					break;
				case "COUNTRY_CARD":
					_source = AddressSource.CountryFromCardId;
					break;
			}

			using (Master.MasterView.SelectProvince _country = new SelectProvince(_source))
			{
				if (_country.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
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
					this.txtCurrentCountry.Text = string.IsNullOrEmpty(_selectedCountry) ? this.txtCurrentCountry.Text : _selectedCountry;
					break;
				case "COUNTRY_CARD":
					this.txtCardCountry.Text = string.IsNullOrEmpty(_selectedCountry) ? this.txtCardCountry.Text : _selectedCountry;
					break;
			}
		}

		private void btnChangePicture_Click(object sender, EventArgs e)
		{
			this.pic.Tag = "CHANGE";
			_imgDb = new OMControls.OMImageDB();
			Image _img = _imgDb.GetImageFile();
			if (_img != null)
			{
				this.pic.Image = _img;
			}
		}

		private void btnClearPicture_Click(object sender, EventArgs e)
		{
			this.pic.Image = null;
			this.pic.Tag = "CHANGE";
		}
	}
}
