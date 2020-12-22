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
using System.Transactions;
using System.Windows.Forms;

namespace OMW15.Master.MasterController
{
	public class EmployeeDAL 
	{
		private OLDMOONEF _om;

		#region Constructor and Destructor

		public EmployeeDAL()
		{
			_om = new OLDMOONEF();
		}

		//protected virtual void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		// dispose managed resources
		//		_om.Dispose();
		//	}
		//	// free native resources
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}
		#endregion


		#region Employee Province

		public DataTable GetCardCountry()
		{
			DataTable _result = new DataTable();
			var _countries = (from country in _om.EMPLOYEEs.AsParallel()
							  orderby country.CARDPROVINCE
							  select new
							  {
								  key = country.CARDCOUNTRY,
								  value = country.CARDCOUNTRY
							  }).Distinct().ToList();

			_result = OMControls.OMDataUtils.ToDataTable(_countries);


			return _result;

		} // end GetCardCountry

		public DataTable GetCurrentCountry()
		{
			DataTable _result = new DataTable();
			var _countries = (from country in _om.EMPLOYEEs.AsParallel()
							  orderby country.CURRENTCOUNTRY
							  select new
							  {
								  key = country.CURRENTCOUNTRY,
								  value = country.CURRENTCOUNTRY
							  }).Distinct().ToList();

			_result = OMControls.OMDataUtils.ToDataTable(_countries);

			return _result;

		} // end GetCurrentCountry


		public DataTable GetCardProvice()
		{
			DataTable _result = new DataTable();
			var _provinces = (from province in _om.EMPLOYEEs.AsParallel()
							  orderby province.CARDPROVINCE
							  select new
							  {
								  key = province.CARDPROVINCE,
								  value = province.CARDPROVINCE
							  }).Distinct().ToList();

			_result = OMControls.OMDataUtils.ToDataTable(_provinces);

			return _result;

		} // end GetCardProvice


		public DataTable GetCurrentProvice()
		{
			DataTable _result = new DataTable();
			var _provinces = (from province in _om.EMPLOYEEs.AsParallel()
							  orderby province.CURRENTPROVINCE
							  select new
							  {
								  key = province.CURRENTPROVINCE,
								  value = province.CURRENTPROVINCE
							  }).Distinct().ToList();

			_result = OMControls.OMDataUtils.ToDataTable(_provinces);

			return _result;

		} // end GetCurrentProvice

		public DataTable GetEmployeeEducation()
		{
			DataTable _result = new DataTable();
			var _edu = (from e in _om.EMPLOYEEs.AsParallel()
						orderby e.EDUCATION
						select new
						{
							key = e.EDUCATION,
							value = e.EDUCATION
						}).Distinct().ToList();

			_result = OMControls.OMDataUtils.ToDataTable(_edu);

			return _result;
		} // end GetEmployeeEducation

		#endregion

		#region Employee Records

		public DataTable GetEmployeeList()
		{
			DataTable _result = new DataTable();

			var _status = (from s in _om.EMPSTATUS.AsParallel()
						   orderby s.STATUSTH
						   select new
						   {
							   Key = s.STATUSID,
							   Value = s.STATUSTH
						   }).Distinct().ToList();

			var emp = (from e in _om.EMPLOYEEs.AsParallel()
					   where e.ISDELETE == false
					   select new
					   {
						   e.EMPSEQ,
						   e.EMPCODE,
						   e.DEPARTMENTID,
						   e.GROUPACCOUNT,
						   empName = e.EMPFIRSTNAME + " " + e.EMPLASTNAME,
						   e.STATUS,
						   e.EMPLOYDATE
					   }).ToList();

			var emps = (from e in emp
						join s in _status on e.STATUS equals s.Key
						select new
						{
							e.EMPSEQ,
							e.EMPCODE,
							e.DEPARTMENTID,
							e.GROUPACCOUNT,
							e.empName,
							e.STATUS,
							s.Value,
							e.EMPLOYDATE
						}).ToList();

			var ep = emps.Select(x => new
			{
				x.EMPSEQ,
				x.EMPCODE,
				x.DEPARTMENTID,
				x.GROUPACCOUNT,
				x.empName,
				EmpDate = OMControls.OMUtils.Num2Date(x.EMPLOYDATE).ToShortDateString(),
				x.STATUS,
				EmpStatus = x.Value
			}).OrderBy(o => o.EmpStatus).AsParallel();

			if (ep != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(ep.ToList());
			}

			return _result;

		} // end GetEmployeeList

		public DataTable GetSummaryEmployeeStatus()
		{
			DataTable _result = new DataTable();

			var _status = (from s in _om.EMPSTATUS.AsParallel()
						   orderby s.STATUSTH
						   select new
						   {
							   Key = s.STATUSID,
							   Value = s.STATUSTH
						   }).Distinct().ToList();

			var emp = (from e in _om.EMPLOYEEs.AsParallel()
					   where e.ISDELETE == false
					   select new
					   {
						   e.EMPSEQ,
						   e.EMPCODE,
						   e.DEPARTMENTID,
						   e.GROUPACCOUNT,
						   empName = e.EMPFIRSTNAME + " " + e.EMPLASTNAME,
						   e.STATUS,
						   e.EMPLOYDATE
					   }).ToList();

			var emps = (from e in emp
						join s in _status on e.STATUS equals s.Key
						select new
						{
							e.EMPSEQ,
							e.EMPCODE,
							e.DEPARTMENTID,
							e.GROUPACCOUNT,
							e.empName,
							e.STATUS,
							s.Value,
							e.EMPLOYDATE
						}).ToList();

			var ep = from ee in emps
					 group ee by ee.Value into qq
					 select new
					 {
						 status = qq.Key,
						 qty = qq.Count()
					 };

			if (ep != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(ep.ToList());
			}

			return _result;
		}

		public Image GetEmployeeImage(string EmployeeCode)
		{
			Image _result = null;

			var img = (from ep in _om.EMPLOYPICs
					   where ep.EMPCODE == EmployeeCode
					   && ep.EMPIMG != null
					   select ep).FirstOrDefault();

			if (img != null)
			{
				OMControls.OMImageDB _idb = new OMControls.OMImageDB();
				_result = _idb.GetImageFromByte(img.EMPIMG);
			}
			else
			{
				_result = null;
			}

			return _result;

		} // end GetEmployeeImage

		public EMPLOYEE GetEmployeeInfo(int EmployeeId)
		{
			var emp = (from e in _om.EMPLOYEEs
					   where e.EMPSEQ == EmployeeId
					   select e).FirstOrDefault();

			return (EMPLOYEE)emp;

		} // end GetEmployeeInfo

		public int InsertOrUpdateEmployeeImage(EMPLOYPIC EmployeePic, string EmployeeCode)
		{
			int _result = 0;

			using (var scope = new System.Transactions.TransactionScope())
			{
				try
				{
					if (string.IsNullOrEmpty(EmployeeCode) == true) // add employee picture
					{
						_om.EMPLOYPICs.Add(EmployeePic);
						_result = _om.SaveChanges();
					}
					else // update employee picture
					{
						var empic = (from e in _om.EMPLOYPICs
									 where e.EMPCODE == EmployeeCode
									 select e).FirstOrDefault();
						empic.EMPCODE = EmployeePic.EMPCODE;
						empic.EMPIMG = EmployeePic.EMPIMG;
						_result = _om.SaveChanges();
					}
					scope.Complete();

				}
				catch (OptimisticConcurrencyException ex)
				{
					_result = 0;
					throw new Exception(string.Format("เกิดข้อผิดพลาดระหว่าง{0}ข้อมูลพนักงาน", (string.IsNullOrEmpty(EmployeeCode) ? "เพิ่ม" : "ปรับปรุง")), ex);
				}
			}

			return _result;

		} // end InsertOrUpdateEmployeeImage

		public int InsertOrUpdateEmployeeInfo(EMPLOYEE EmployeeInfo, int EmployeeId)
		{
			int _result = 0;

			using (var scope = new System.Transactions.TransactionScope())
			{
				try
				{
					if (EmployeeId > 0) // update information
					{
						var emp = (from e in _om.EMPLOYEEs
								   where e.EMPSEQ == EmployeeId
								   select e).FirstOrDefault();

						emp.STATUS = EmployeeInfo.STATUS;
						emp.GROUPACCOUNT = EmployeeInfo.GROUPACCOUNT;
						emp.DEPARTMENTID = EmployeeInfo.DEPARTMENTID;
						emp.POSITIONID = EmployeeInfo.POSITIONID;
						emp.EDUCATION = EmployeeInfo.EDUCATION;

						emp.IDCARDNUMBER = EmployeeInfo.IDCARDNUMBER;
						emp.EMPFIRSTNAME = EmployeeInfo.EMPFIRSTNAME;
						emp.EMPLASTNAME = EmployeeInfo.EMPLASTNAME;
						emp.SEX = EmployeeInfo.SEX;
						emp.TITLENAME = EmployeeInfo.TITLENAME;
						emp.CELLPHONE = EmployeeInfo.CELLPHONE;
						emp.HOMEPHONE = EmployeeInfo.HOMEPHONE;
						emp.EMAIL = EmployeeInfo.EMAIL;
						emp.FAMILYSTATUS = EmployeeInfo.FAMILYSTATUS;

						emp.CARDADDRESS1 = EmployeeInfo.CARDADDRESS1;
						emp.CARDADDRESS2 = EmployeeInfo.CARDADDRESS2;
						emp.CARDPROVINCE = EmployeeInfo.CARDPROVINCE;
						emp.CARDZIPCODE = EmployeeInfo.CARDZIPCODE;
						emp.CARDCOUNTRY = EmployeeInfo.CARDCOUNTRY;

						emp.CURRENTADDRESS1 = EmployeeInfo.CURRENTADDRESS1;
						emp.CURRENTADDRESS2 = EmployeeInfo.CURRENTADDRESS2;
						emp.CURRENTPROVINCE = EmployeeInfo.CURRENTPROVINCE;
						emp.CURRENTZIPCODE = EmployeeInfo.CURRENTZIPCODE;
						emp.CURRENTCOUNTRY = EmployeeInfo.CURRENTCOUNTRY;

						emp.EMPLOYDATE = EmployeeInfo.EMPLOYDATE;
						emp.PROBATIONDAY = EmployeeInfo.PROBATIONDAY;
						emp.ENDPROBATIONDATE = EmployeeInfo.ENDPROBATIONDATE;
						emp.DAYRATE = EmployeeInfo.DAYRATE;
						emp.MONTHRATE = EmployeeInfo.MONTHRATE;
						emp.NUMBEROFKID = EmployeeInfo.NUMBEROFKID;

						_result = _om.SaveChanges();

					}
					else
					{
						_om.EMPLOYEEs.Add(EmployeeInfo);
						_result = _om.SaveChanges();
					}
					scope.Complete();

				}
				catch (OptimisticConcurrencyException ex)
				{
					_result = 0;
					throw new Exception(string.Format("เกิดข้อผิดพลาดระหว่าง{0}ข้อมูลพนักงาน", (EmployeeId > 0 ? "ปรับปรุง" : "เพิ่ม")), ex);
				}

			} // end scope

			return _result;

		} // end InsertOrUpdateEmployeeInfo


		#endregion
	} // end constructor
}
