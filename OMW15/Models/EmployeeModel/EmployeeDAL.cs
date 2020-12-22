using OMW15.Models.ToolModel;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OMW15.Models.EmployeeModel
{
	public class EmployeeDAL
	{
		private readonly OLDMOONEF1 _om;
		private readonly ERP _erp;

		#region Constructor and Destructor

		public EmployeeDAL()
		{
			_om = new OLDMOONEF1();
			_erp = new ERP();
		}

		#endregion

		#region Employee Province

		public DataTable GetCardCountry() => _om.EMPLOYEEs.Select(pv => new
		{
			Key = pv.CARDCOUNTRY,
			Value = pv.CARDCOUNTRY
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		public DataTable GetCurrentCountry() => _om.EMPLOYEEs.Select(ec => new
		{
			Key = ec.CURRENTCOUNTRY,
			Value = ec.CURRENTCOUNTRY
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		public DataTable GetCardProvice() => _om.EMPLOYEEs.Select(cp => new
		{
			Key = cp.CARDPROVINCE,
			Value = cp.CARDPROVINCE
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		public DataTable GetCurrentProvice() => _om.EMPLOYEEs.Select(cp => new
		{
			Key = cp.CURRENTPROVINCE,
			Value = cp.CURRENTPROVINCE
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		public DataTable GetEmployeeEducation() => _om.EMPLOYEEs.Select(ed => new
		{
			Key = ed.EDUCATION,
			Value = ed.EDUCATION
		}).Distinct().OrderBy(o => o.Value).ToDataTable();

		#endregion

		#region Employee Records
		public DataTable GetAllEmployees()
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine(" SELECT ");
			s.AppendLine(" 'DepartmentId' = e.DEPARTMENTID,");
			s.AppendLine(" 'Department' = d.DEPT_THAIDESC,");
			s.AppendLine(" 'Status' = e.STATUS,");
			s.AppendLine(" 'StatusName'=s.THKEYNAME,");
			s.AppendLine(" 'EmpCode' = e.EMPCODE,");
			s.AppendLine(" 'FullName' = e.EMPFIRSTNAME + ' ' + e.EMPLASTNAME,");
			s.AppendLine(" 'EmployDate' = e.EMPLOYDATE,");
			s.AppendLine(" 'ResignDate' = e.RESIGNDATE");
			s.AppendLine(" FROM EMPLOYEE e");
			s.AppendLine(" LEFT JOIN SYSDATA s ON e.STATUS = s.KEYVALUE AND s.GROUPTITLE = 'EMPLOYSTATUS'");
			s.AppendLine(" INNER JOIN ERP.dbo.DEPTTAB d ON e.DEPARTMENTID = d.DEPT_KEY");
			s.AppendLine(" ORDER BY d.DEPT_THAIDESC, e.STATUS");

			var _result = new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;

			return _result;
		}

		public DataTable GetEmployeeList(int DepartmentId)
		{
			var _result = new DataTable();
			var emp = (from e in _om.EMPLOYEEs.AsEnumerable()
						  join es in _om.EMPSTATUS on e.STATUS equals es.STATUSID
						  where e.ISDELETE == false
						  select new
						  {
							  e.EMPSEQ,
							  e.EMPCODE,
							  e.DEPARTMENTID,
							  e.GROUPACCOUNT,
							  empName = e.EMPFIRSTNAME + " " + e.EMPLASTNAME,
							  EmpDate = e.EMPLOYDATE.Num2Date().ToShortDateString(),
							  e.STATUS,
							  EmpStatus = es.STATUSTH
						  }).AsParallel();

			if (emp != null)
			{
				if (DepartmentId == 0)
				{
					_result = emp.OrderBy(o => o.EmpStatus).ThenBy(o => o.EMPCODE).ToDataTable();
				}
				else
				{
					_result = emp.Where(x => x.DEPARTMENTID == DepartmentId).OrderBy(o => o.EmpStatus).ThenBy(o => o.EMPCODE).ToDataTable();
				}
			}
			return _result;

		} // end GetEmployeeList

		public DataTable GetSummaryEmployeeStatus()
		{
			var _result = new DataTable();

			var emp = (from e in _om.EMPLOYEEs
						  join es in _om.EMPSTATUS on e.STATUS equals es.STATUSID
						  where e.ISDELETE == false
						  group new
						  {
							  e,
							  es
						  } by new
						  {
							  es.STATUSTH
						  }
				into empgrp
						  select new
						  {
							  status = empgrp.Key.STATUSTH,
							  qty = empgrp.Count()
						  }).OrderBy(x => x.status);

			if (emp != null)
				_result = emp.ToDataTable();

			return _result;
		} // end GetSummaryEmployeeStatus

		public Image GetEmployeeImage(string EmployeeCode)
		{
			Image _result = null;

			var img = (from ep in _om.EMPLOYPICs
						  where ep.EMPCODE == EmployeeCode
								&& ep.EMPIMG != null
						  select ep).FirstOrDefault();

			if (img != null)
				_result = img.EMPIMG.ToImageFromByte();
			else
				_result = null;

			return _result;
		} // end GetEmployeeImage

		public EMPLOYEE GetEmployeeInfo(string EmployeeCode) => _om.EMPLOYEEs.Single(x => x.EMPCODE == EmployeeCode);


		public EMPLOYEE GetEmployeeInfo(int EmployeeId) => _om.EMPLOYEEs.Single(x => x.EMPSEQ == EmployeeId);

		public bool CheckValidEmployeeCode(string empCode)
		{
			var _e = _om.EMPLOYEEs.Where(x => x.EMPCODE == empCode).First();

			if (_e != null) return false;

			return true;

		}

		public int InsertOrUpdateEmployeeImage(EMPLOYPIC EmployeePic, string EmployeeCode)
		{
			var _result = 0;

			using (var scope = new TransactionScope())
			{
				try
				{
					if (string.IsNullOrEmpty(EmployeeCode)) // add employee picture
					{
						_om.EMPLOYPICs.Add(EmployeePic);
						_result = _om.SaveChanges();
					}
					else // update employee picture
					{
						var empic = (from e in _om.EMPLOYPICs
										 where e.EMPCODE == EmployeeCode
										 select e).Single();
						empic.EMPCODE = EmployeePic.EMPCODE;
						empic.EMPIMG = EmployeePic.EMPIMG;
						_result = _om.SaveChanges();
					}
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception(
						string.Format("เกิดข้อผิดพลาดระหว่าง{0}ข้อมูลพนักงาน", string.IsNullOrEmpty(EmployeeCode) ? "เพิ่ม" : "ปรับปรุง"),
						ex);
				}
			}

			return _result;
		} // end InsertOrUpdateEmployeeImage

		public int InsertOrUpdateEmployeeInfo(EMPLOYEE EmployeeInfo, int EmployeeId)
		{
			var _result = 0;
			try
			{
				if (EmployeeId > 0) // update information
				{
					var emp = (from e in _om.EMPLOYEEs
								  where e.EMPSEQ == EmployeeId
								  select e).Single();

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
					emp.RESIGNDATE = EmployeeInfo.RESIGNDATE;
					emp.DAYRATE = EmployeeInfo.DAYRATE;
					emp.MONTHRATE = EmployeeInfo.MONTHRATE;
					emp.NUMBEROFKID = EmployeeInfo.NUMBEROFKID;
				}
				else
				{
					_om.EMPLOYEEs.Add(EmployeeInfo);
				}
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception(string.Format("เกิดข้อผิดพลาดระหว่าง{0}ข้อมูลพนักงาน", EmployeeId > 0 ? "ปรับปรุง" : "เพิ่ม"),
					ex);
			}

			return _result;
		} // end InsertOrUpdateEmployeeInfo

		#endregion

		#region Production Avg hour

		public async Task<DataTable> GetProductionAvgCostHourAsync()
		{
			return await Task.Run(() =>
			{
				var h = _om.EMPLOYEEs
							.Where(x => (x.DEPARTMENTID == 111 || x.DEPARTMENTID == 112)
									&& (x.STATUS == 1 || x.STATUS == 6 || x.STATUS == 7 || x.STATUS == 8))
							.Select(e => new
							{
								Department = "Production",
								e.DAYRATE,
								e.MONTHRATE
							}).ToList();

				DataTable eh = (from e in h
									 group e by e.Department into ahr
									 select new
									 {
										 ahr.Key,
										 DayAvgHourCost = ahr.Average(x => x.DAYRATE / omglobal.WORK_HOUR_DAY),
										 MonthAvgHourCost = ahr.Average(x => x.MONTHRATE / omglobal.TOTAL_MONTH_HOURS),
										 MonthActualAvgHourCost = ahr.Average(x => x.MONTHRATE / omglobal.TOTAL_ACTUAL_MONTH_HOURS)
									 }).ToDataTable();
				return eh ?? eh;
			});
		}


		#endregion

		#region Salary

		public EMPSAL GetEmpSalById(int id) => _om.EMPSALs.Where(x => x.EMPSALSEQ == id).Single();

		public int DeleteEmpSal(int id)
		{
			_om.EMPSALs.Remove(GetEmpSalById(id));
			return _om.SaveChanges();
		}

		public int UpdateEmpSal(EMPSAL empSal)
		{
			if (empSal.EMPSALSEQ == 0)
			{
				_om.EMPSALs.Add(empSal);
			}
			else
			{
				var es = GetEmpSalById(empSal.EMPSALSEQ);
				es.AVGHOURCOST = empSal.AVGHOURCOST;
				es.ACTUALAVGHOURCOST = empSal.ACTUALAVGHOURCOST;
				es.CURRENT_SAL = empSal.CURRENT_SAL;
				es.EMPNAME = empSal.EMPNAME;
				es.DEPARTMENT = empSal.DEPARTMENT;
				es.WORKGROUP = empSal.WORKGROUP;
				es.MODIDATE = DateTime.Now;
				es.MODIUSER = omglobal.UserName;
				es.PSAL1 = empSal.PSAL1;
				es.PSAL2 = empSal.PSAL2;
				es.PSAL3 = empSal.PSAL3;
				es.PSAL4 = empSal.PSAL4;
				es.PSAL5 = empSal.PSAL5;
				es.PSAL6 = empSal.PSAL6;
				es.PSAL7 = empSal.PSAL7;
				es.PSAL8 = empSal.PSAL8;
				es.PSAL9 = empSal.PSAL9;
				es.PSAL10 = empSal.PSAL10;
				es.PSAL11 = empSal.PSAL11;
				es.PSAL12 = empSal.PSAL12;
				es.YEARSAL = empSal.YEARSAL;
			}

			return _om.SaveChanges();
		}

		public DataTable GetSalaryList(string empCode)
		{
			DataTable _result = new DataTable();

			_result = (from es in _om.EMPSALs.AsEnumerable()
						  where es.EMPCODE == empCode
						  select new
						  {
							  es.EMPSALSEQ,
							  es.YEARSAL,
							  es.EMPCODE,
							  es.EMPNAME,
							  AvgHourCost = es.AVGHOURCOST,
							  AvgActualHourCost = es.ACTUALAVGHOURCOST
						  })
							.OrderBy(o => o.YEARSAL)
							.ToDataTable();
			return _result;
		}

		#endregion


		#region Available Employee

		public DataTable GetAvailableEmployeeList(string filter = "")
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine($" SELECT * ");
			s.AppendLine($" FROM dbo.OM_EMP_WORK e ");
			if (!String.IsNullOrEmpty(filter))
			{
				s.AppendLine($" WHERE fname LIKE '%{filter}%'");
			}
			s.AppendLine($" ORDER BY e.EMPCODE ");

			return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;

		}

		public DataTable GetWorktimeInfo(string empCode, DateTime workDate,bool allRecordsInMonth = true)
		{
			StringBuilder s = new StringBuilder();

			if (allRecordsInMonth)
			{
				s.AppendLine($" EXEC dbo.usp_ValidTimeRecordByMonth ");
				s.AppendLine($" @EmpCode = '{empCode}',");
				s.AppendLine($" @Y = {workDate.Year},");
				s.AppendLine($" @M = {workDate.Month}");
			}
			else
			{
				s.AppendLine($" EXEC dbo.usp_ValidTimeRecord ");
				s.AppendLine($" @EmpCode = '{empCode}',");
				s.AppendLine($" @Y = {workDate.Year},");
				s.AppendLine($" @M = {workDate.Month},");
				s.AppendLine($" @D = {workDate.Day}");
			}
			//throw new Exception(s.ToString());

			return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;

		}

		#endregion

	}
}