using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;

namespace OMW15.Casting.CastingController
{
	public class JobDAL 
	{
		//bool disposed = false;

		private OLDMOONEF _om;

		#region constructor and destructor

		public JobDAL()
		{
			_om = new OLDMOONEF();
		}

		//protected virtual void Dispose(bool disposing)
		//{
		//	if (disposed)
		//	{
		//		return;
		//	}

		//	if (disposing)
		//	{
		//		// dispose managed resources
		//		_om.Dispose();
		//	}

		//	disposed = true;
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}

		//~JobDAL()
		//{
		//	Dispose(true);
		//}

		#endregion


		#region static class method
		public DataTable CastingCustomerList()
		{
			DataTable _result = new DataTable();
			var cust = (from j in _om.JOBORDERS
						join c in _om.CUSTOMER1 on j.CUSTCODE equals c.CUSTCODE
						where j.ISCANCEL == false
						select new
						{
							c.CUSTID,
							j.CUSTCODE,
							c.CUSTNAME
						}).Distinct().OrderBy(x => x.CUSTNAME);

			if (cust != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(cust.ToList());
			}
			return _result;

		} // end CastingCustomerList

		public string FindCastingCustomer(int CustomerId)
		{
			string _result = string.Empty;
			var cust = (from j in _om.JOBORDERS
						join c in _om.CUSTOMER1 on j.CUSTCODE equals c.CUSTCODE
						where j.ISCANCEL == false
						&& c.CUSTID == CustomerId
						select new
						{
							c.CUSTID,
							j.CUSTCODE,
							c.CUSTNAME
						}).Distinct().FirstOrDefault();
			return cust.CUSTNAME;

		} // end FindCastingCustomer

		public DataTable CreateJobYearList()
		{
			DataTable _result = new DataTable();
			var y = (from j in _om.JOBINFOS
					 where j.ISDELETE == false
					 && j.FISCYEAR > 0
					 select new
					 {
						 JOBYEAR = j.FISCYEAR.Value
					 }).Distinct().OrderByDescending(o => o.JOBYEAR).AsParallel();

			if (y != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(y.ToList());
			}

			return _result;

		} // end CreateJobYearList


		public DataTable GetJobInfoDetailForUpdate(int JobNo)
		{
			DataTable _result = new DataTable();
			var jlines = (from jobinfo in _om.JOBINFOS
						  where (jobinfo.GROUPCODE == "FG"
						  || jobinfo.GROUPCODE == "BLOCK")
						  && jobinfo.ISDELETE == false
						  && jobinfo.JOBNO == JobNo
						  group jobinfo by new
						  {
							  jobinfo.JOBNO,
							  jobinfo.GROUPCODE,
							  jobinfo.MATERIALID,
						  }
							  into jisum
							  select new
							  {
								  jisum.Key.JOBNO,
								  jisum.Key.GROUPCODE,
								  jisum.Key.MATERIALID,
								  LastFinishDate = jisum.Max(x => x.FINISHDATE),
								  TotalFinish = jisum.Sum(x => x.ACCEPTQTY),
								  totalWeight = jisum.Sum(t => t.TOTALWEIGHT)
							  }).AsParallel().AsEnumerable();

			var jobs = from j in _om.JOBORDERS
					   join ji in jlines
					   on j.JOBNO equals ji.JOBNO
					   where j.STATUS == 1
					   select new
					   {
						   j.JOBNO,
						   j.CUSTID,
						   j.CUSTCODE,
						   j.PREFIX,
						   j.ITEMID,
						   j.ITEMNO,
						   j.ITEMNAME,
						   j.ORDERUNIT,
						   MaterialId = ji.MATERIALID.Value,
						   ji.TotalFinish,
						   ji.totalWeight,
						   ji.GROUPCODE
					   };

			_result = OMControls.OMDataUtils.ToDataTable(jobs.ToList());

			return _result;

		} // end GetJobInfoDetailForUpdate

		public DataTable GetSummaryJobInfoByGroupCode(int JobId)
		{
			DataTable _result = new DataTable();
				var jobinfos = from job in _om.JOBINFOS
							   where job.JOBNO == JobId
							   && job.ISDELETE == false
							   group job by job.GROUPCODE into q
							   select new
							   {
								   q.Key,
								   fg = q.Sum(i => i.ACCEPTQTY)
							   };

				_result = OMControls.OMDataUtils.ToDataTable(jobinfos.ToList());

			return _result;

		} // end GetSummaryJobInfoByGroupCode

		public DataTable GetSummaryJobActive()
		{
			DataTable _result = new DataTable();
			var jobs = (from job in _om.JOBORDERS.AsParallel()
						where job.STATUS == (int)OMShareJobEnums.OrderStatusEnum.ACTIVE
						&& job.PREFIX != ""
						group job by job.PREFIX into q
						select new
						{
							Q = q.Key,
							BQ = q.Sum(i => i.BACKORDQTY.Value)
						}).ToList();
			if (jobs != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(jobs);
			}
			else
			{
				_result = null;
			}

			return _result;

		} // end GetSummaryJobActive

		public DataTable GetJobOrderList(string JobCategory, int JobStatus)
		{
			DataTable _result = new DataTable();
			var _material = (from _m in _om.SYSDATAs.AsParallel()
							 where _m.GROUPTITLE == "MATERIAL"
							 select new
							 {
								 MatId = _m.KEYVALUE,
								 MatName = _m.THKEYNAME
							 }).ToList();

			var _customers = (from _cust in _om.CUSTOMER1.AsParallel()
							  select new
							  {
								  _cust.CUSTCODE,
								  _cust.CUSTNAME
							  }).ToList();

			var _jobs = (from job in _om.JOBORDERS.AsParallel()
						 where job.ISCANCEL == false
						 && job.PREFIX == JobCategory
						 && job.STATUS == JobStatus
						 select new
						 {
							 Status = job.STATUS,
							 JobNo = job.JOBNO,
							 OrderDate = job.JOBDATE,
							 Start = job.STARTDATE,
							 rd = job.REMAINDAY.Value,
							 Due = job.DUEDATE,
							 CustomerId = job.CUSTID,
							 CustomerCode = job.CUSTCODE,
							 ItemId = job.ITEMID.Value,
							 CAT = job.PREFIX,
							 ItemNo = job.ITEMNO,
							 ItemName = job.ITEMNAME,
							 Material = job.MATERIALTYPE,
							 Unit = job.ORDERUNIT,
							 Qty = job.ORDERQTY,
							 remain = job.BACKORDQTY.Value,
							 style = job.ITEMSTYLE
						 }).ToList();

			var _jobOrders = (from j in _jobs
							  join c in _customers on j.CustomerCode equals c.CUSTCODE
							  join m in _material on j.Material.ToString() equals m.MatId
							  select new
							  {
								  j.Status,
								  j.JobNo,
								  j.OrderDate,
								  j.Start,
								  j.Due,
								  j.rd,
								  j.CustomerId,
								  j.CustomerCode,
								  CustomerName = c.CUSTNAME,
								  j.ItemId,
								  j.CAT,
								  j.ItemNo,
								  j.ItemName,
								  Material = m.MatName,
								  j.Unit,
								  j.Qty,
								  j.remain,
								  j.style
							  }).Select(x => new
							  {
								  x.Status,
								  JobNo = x.JobNo.ToString(),
								  OrderDate = OMControls.OMUtils.Num2Date(x.OrderDate),
								  Start = OMControls.OMUtils.Num2Date(x.Start),
								  Due = OMControls.OMUtils.Num2Date(x.Due),
								  x.rd,
								  x.CustomerId,
								  x.CustomerCode,
								  x.CustomerName,
								  x.ItemId,
								  x.CAT,
								  x.ItemNo,
								  x.ItemName,
								  x.Material,
								  x.Unit,
								  x.Qty,
								  x.remain,
								  x.style
							  }).OrderBy(o => o.JobNo).AsParallel();

			_result = OMControls.OMDataUtils.ToDataTable(_jobOrders.ToList());

			return _result;

		} // end GetJobOrderList

		public string GetItemCategory(string ItemCode)
		{
			ITEMCODE _ic = _om.ITEMCODEs.FirstOrDefault(x => x.ITEMCODE1 == ItemCode);
			return _ic.ITEMCODENAME_TH;

		} // end GetItemCategory

		public JOBORDER GetJobOrderInfo(int JobId)
		{
			return _om.JOBORDERS.FirstOrDefault(x => x.JOBNO == JobId);
		} // end GetJobItemInfo

		public JOBINFO GetJobInfoItem(int JobInfoId)
		{
			return _om.JOBINFOS.FirstOrDefault(x => x.LINESEQ == JobInfoId);
		
		} // end GetJobInfoItem

		public DataTable GetJobInfoByGroupCode(int JobId, string GroupCode)
		{
			DataTable _result = new DataTable();
			var jobinfos = (from job in _om.JOBINFOS
							where job.ISDELETE == false
							&& job.GROUPCODE == GroupCode
							&& job.JOBNO == JobId
							orderby job.FINISHDATE
							select new
							{
								job.LINESEQ,
								job.FGLINESEQ,
								job.GROUPCODE,
								ITEMID = job.ITEMID.Value == null ? 0 : job.ITEMID.Value,
								job.ITEMPREFIX,
								job.ITEMNO,
								job.OPERATORNAME,
								job.FINISHDATE,
								job.ACCEPTQTY,
								job.REJECTQTY,
								job.TOTALQTY,
								job.TOTALWEIGHT,
								job.AVGWEIGHT
							}).AsParallel();
			if (jobinfos != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(jobinfos.ToList());
			}

			return _result;

		} // end GetJobInfoByGroupCode

		public DataTable GetJobFG(int JobNo, int Status)
		{
			DataTable dt = GetJobFG(Status);
			dt.DefaultView.RowFilter = string.Format("{0} = {1}", "JOBNO", JobNo);
			return dt;
		} // end GetJobFG

		public DataTable GetJobFG(int Status)
		{
			DataTable _result = new DataTable();
			// summary job info for FG only
			var fg = (from ji in _om.JOBINFOS
					  where ji.ISDELETE == false
					  group ji by new
					  {
						  ji.JOBNO
					  } into g
					  select new
					  {
						  JOBNO = g.Key.JOBNO,
						  block = g.Sum(i => i.GROUPCODE == "BLOCK" ? i.ACCEPTQTY : 0),
						  wax = g.Sum(i => i.GROUPCODE == "WAX" ? i.ACCEPTQTY : 0),
						  finishing = g.Sum(i => i.GROUPCODE == "FINIHSING" ? i.ACCEPTQTY : 0),
						  tree = g.Sum(i => i.GROUPCODE == "TREE" ? i.ACCEPTQTY : 0),
						  Casting = g.Sum(i => i.GROUPCODE == "FG" ? i.ACCEPTQTY : 0),
						  avgwt = g.Average(ii => ii.AVGWEIGHT),
						  totalWeight = g.Sum(t => t.TOTALWEIGHT)
					  }).AsParallel().ToList();

			// select job records only for active jobs
			var jobs = (from j in _om.JOBORDERS
						where j.STATUS == Status
						&& j.ORDERQTY > 0
						&& j.ISCANCEL == false
						orderby j.JOBNO
						select new
						{
							j.STATUS,
							j.JOBNO,
							j.PREFIX,
							j.ITEMNO,
							j.ITEMNAME,
							j.ORDERUNIT,
							j.ORDERQTY,
							j.DELIVERYQTY
						}).AsParallel().ToList();

			//// join with 2 dataset
			var fx = (from jo in jobs
					  from ji in fg
					  where jo.JOBNO == ji.JOBNO
					  orderby jo.JOBNO
					  select new
					  {
						  jo.STATUS,
						  complete = ji.Casting / jo.ORDERQTY,
						  jo.JOBNO,
						  jo.PREFIX,
						  jo.ITEMNO,
						  jo.ITEMNAME,
						  jo.ORDERUNIT,
						  jo.ORDERQTY,
						  ji.block,
						  ji.wax,
						  ji.finishing,
						  ji.tree,
						  ji.Casting,
						  Remain = jo.ORDERQTY - ji.Casting,
						  AvgWeight = ji.avgwt,
						  ji.totalWeight,
						  jo.DELIVERYQTY
					  }).OrderBy(o => o.complete).AsParallel();

			_result = OMControls.OMDataUtils.ToDataTable(fx.ToList());

			return _result;

		} // end GetJobFG

		#endregion

		// update FISCYEAR & FISCPERIOD for Jobinfos
		public int UpdateYearPeriodForJobInfos()
		{
			int _result = 0;
			using (var scope = new System.Transactions.TransactionScope())
			{
				var jobs = from j in _om.JOBINFOS.AsParallel()
						   where j.ISDELETE == false
							   && j.FISCYEAR == 0
						   select j;

				if (jobs.ToList().Count > 0)
				{
					try
					{
						foreach (var ji in jobs.ToList())
						{
							ji.FISCYEAR = OMControls.OMUtils.Num2Date(ji.FINISHDATE).Year;
							ji.FISCPERIOD = OMControls.OMUtils.Num2Date(ji.FINISHDATE).Month;
						}

						_result = _om.SaveChanges();
						scope.Complete();
					}
					catch (OptimisticConcurrencyException ex)
					{
						_result = -1;
						//scope.Dispose();
						throw new Exception("Update Job Infos (Y/P) failed....", ex);
					}
				}
				else
				{
					_result = 0;
				}
			} // end scope

			return _result;

		} // end UpdateYearPeriodForJobInfos

		// update joborder status by updating finish-qty from jobinfos 
		// and setting into joborder

		public int UpdateJobOrdersStatusByFinishQty(int JobNo, string Group)
		{
			int _result = 0;

			using (var scope = new System.Transactions.TransactionScope())
			{
				var jlines = (from jobinfo in _om.JOBINFOS
							  where jobinfo.ISDELETE == false
							  && jobinfo.JOBNO == JobNo
							  && jobinfo.GROUPCODE == Group
							  group jobinfo by jobinfo.JOBNO into jisum
							  select new
							  {
								  jisum.Key,
								  LastFinishDate = jisum.Max(x => x.FINISHDATE),
								  TotalFinish = jisum.Sum(x => x.ACCEPTQTY),
								  totalWeight = jisum.Sum(t => t.TOTALWEIGHT)
							  }).AsParallel().AsEnumerable();

				var jobs = from j in _om.JOBORDERS
						   join ji in jlines
						   on j.JOBNO equals ji.Key
						   where j.JOBNO == JobNo
						   select new
						   {
							   j,
							   ji
						   };
				try
				{
					foreach (var o in jobs.ToList())
					{
						o.j.FINISHEDQTY = (decimal)o.ji.TotalFinish;
						o.j.TOTALWEIGHT = (decimal)o.ji.totalWeight;
						o.j.STATUS = (o.j.ORDERQTY <= (decimal)o.ji.TotalFinish ? 2 : 1);
						o.j.FINISHDATE = (o.j.ORDERQTY <= (decimal)o.ji.TotalFinish ? (decimal)o.ji.LastFinishDate : 0);
					}
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					_result = -1;
					omglobal.DisplayAlert("ERROR", ex.ToString());
				}
			} // end scope

			return _result;

		} // end UpdateJobOrdersStatusByFinishQty

		public int UpdateJobOrdersStatusByFinishQty()
		{
			string[] _group = new string[] { "FG" };
			int _result = 0;

			using (var scope = new System.Transactions.TransactionScope())
			{
				var jlines = (from jobinfo in _om.JOBINFOS
							  where jobinfo.ISDELETE == false
							  && _group.Contains(jobinfo.GROUPCODE)
							  group jobinfo by jobinfo.JOBNO into jisum
							  select new
							  {
								  jisum.Key,
								  LastFinishDate = jisum.Max(x => x.FINISHDATE),
								  TotalFinish = jisum.Sum(x => x.ACCEPTQTY),
								  totalWeight = jisum.Sum(t => t.TOTALWEIGHT)
							  }).AsParallel().AsEnumerable();

				var jobs = from j in _om.JOBORDERS
						   join ji in jlines
						   on j.JOBNO equals ji.Key
						   where j.STATUS == 1
						   select new
						   {
							   j,
							   ji
						   };
				try
				{
					foreach (var o in jobs.ToList())
					{
						o.j.FINISHEDQTY = (decimal)o.ji.TotalFinish;
						o.j.TOTALWEIGHT = (decimal)o.ji.totalWeight;
						o.j.STATUS = (o.j.ORDERQTY <= (decimal)o.ji.TotalFinish ? 2 : 1);
						o.j.FINISHDATE = (o.j.ORDERQTY <= (decimal)o.ji.TotalFinish ? (decimal)o.ji.LastFinishDate : 0);
					}
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					_result = -1;
					omglobal.DisplayAlert("ERROR", ex.ToString());
				}
			} // end scope

			return _result;

		} // end UpdateJobOrdersStatusByFinishQty

		public int UpdateFGSByFinishQty(int JobNo, string Group)
		{
			bool _isNewRecord = false;
			string _appGroup = (Group == "FG" ? "QC-FG" : "QC-BLOCK");
			int _result = 0;

			// find the job-no in FG-Stock Table
			var fgs = (from fg in _om.FGSTOCKs
					   where fg.DOCNO == JobNo.ToString()
					   && fg.APPCODE == _appGroup
					   select fg).FirstOrDefault();

			_isNewRecord = (fgs == null ? true : false);

			// insert or update FG-Stock Table
			using (var scope = new System.Transactions.TransactionScope())
			{
				var jlines = (from jobinfo in _om.JOBINFOS
							  where jobinfo.GROUPCODE == Group
							  && jobinfo.JOBNO == JobNo
							  && jobinfo.ISDELETE == false
							  group jobinfo by new
							  {
								  jobinfo.JOBNO,
								  jobinfo.GROUPCODE,
								  jobinfo.MATERIALID,
							  }
								  into jisum
								  select new
								  {
									  jisum.Key.JOBNO,
									  jisum.Key.GROUPCODE,
									  jisum.Key.MATERIALID,
									  LastFinishDate = jisum.Max(x => x.FINISHDATE),
									  TotalFinish = jisum.Sum(x => x.ACCEPTQTY),
									  totalWeight = jisum.Sum(t => t.TOTALWEIGHT)
								  }).AsParallel().AsEnumerable();

				var jobs = (from j in _om.JOBORDERS
							join ji in jlines
							on j.JOBNO equals ji.JOBNO
							select new
							{
								j.JOBNO,
								j.CUSTID,
								j.CUSTCODE,
								j.PREFIX,
								j.ITEMID,
								j.ITEMNO,
								j.ITEMNAME,
								j.ORDERUNIT,
								ji.MATERIALID,
								ji.TotalFinish,
								ji.totalWeight,
								ji.GROUPCODE
							}).FirstOrDefault();

				// create FGStock Object
				FGSTOCK f = new FGSTOCK();
				try
				{
					if (_isNewRecord == true) // add FG-Stock
					{
						f.APPCODE = _appGroup;
						f.DOCNO = JobNo.ToString();
						f.DOCDATE = 0m;
						f.CUSTCODE = jobs.CUSTCODE;
						f.CUSTID = jobs.CUSTID;
						f.DELIVERYQTY = 0.00m;
						f.ISCOMPLETION = false;
						f.PREFIX = jobs.PREFIX;
						f.ITEMID = (int)jobs.ITEMID;
						f.ITEMNAME = jobs.ITEMNAME;
						f.ITEMNO = jobs.ITEMNO;
						f.MATID = (int)jobs.MATERIALID;
						f.TOTALLINEWT = jobs.totalWeight;
						f.QTY = jobs.TotalFinish;
						f.UNIT = jobs.ORDERUNIT;
						f.AUDITUSER = omglobal.UserName;
						f.MODIUSER = omglobal.UserName;
						f.MODIDATE = DateTime.Now;
						f.QCSEQ = 0;
						f.SOSEQ = 0;
						f.SOLINESEQ = 0;
						f.REMARK = string.Empty;

						_om.FGSTOCKs.Add(f);
						_result = _om.SaveChanges();
						scope.Complete();
					}
					else // update FG-Stock
					{
						f.PREFIX = jobs.PREFIX;
						f.ITEMID = (int)jobs.ITEMID;
						f.ITEMNO = jobs.ITEMNO;
						f.ITEMNAME = jobs.ITEMNAME;
						f.QTY = jobs.TotalFinish;
						f.TOTALLINEWT = jobs.totalWeight;
						f.MODIUSER = omglobal.UserName;
						f.MODIDATE = DateTime.Now;

						var fg = (from _fg in _om.FGSTOCKs
								  where _fg.DOCNO == JobNo.ToString()
								  && _fg.APPCODE == _appGroup
								  select _fg).FirstOrDefault();

						fg.QTY = f.QTY;
						fg.TOTALLINEWT = f.TOTALLINEWT;
						fg.MODIUSER = f.MODIUSER;
						fg.MODIDATE = f.MODIDATE;

						_result = _om.SaveChanges();
						scope.Complete();
					}
				}
				catch (OptimisticConcurrencyException ex)
				{
					//scope.Dispose();
					throw new Exception(string.Format("มีความผิดพลาดระหว่าง{0}ข้อมูลของสต็อกสินค้า...", (_isNewRecord == true ? "เพิ่ม" : "ปรับปรุง")), ex);
				}
			} // end scope

			return _result;

		} // end UpdateFGSByFinishQty

		#region Class method Save / Update JobOrder

		public int AddJobOrder(JOBORDER JobOrder)
		{
			int _result = 0;
			using (var scope = new System.Transactions.TransactionScope())
			{
				try
				{
					_om.JOBORDERS.Add(JobOrder);
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Add new Job Order Failed...", ex);
				}
			}

			return _result;

		} // end AddJobOrder

		public int UpdateJobOrder(int JobNo, JOBORDER JobOrder)
		{
			int _result = 0;

			using (var scope = new System.Transactions.TransactionScope())
			{
				var _jobOrder = (from j in _om.JOBORDERS
								 where j.JOBNO == JobNo
								 select j).FirstOrDefault();

				_jobOrder.ISREWORKS = JobOrder.ISREWORKS;
				_jobOrder.STATUS = JobOrder.STATUS;
				_jobOrder.CUSTID = JobOrder.CUSTID;
				_jobOrder.CUSTCODE = JobOrder.CUSTCODE;
				_jobOrder.CUSTPO = JobOrder.CUSTPO;
				_jobOrder.RELEASEDATE = JobOrder.RELEASEDATE;
				_jobOrder.STARTDATE = JobOrder.STARTDATE;
				_jobOrder.DUEDATE = JobOrder.DUEDATE;
				_jobOrder.ITEMNAME = JobOrder.ITEMNAME;
				_jobOrder.MATERIALTYPE = JobOrder.MATERIALTYPE;
				_jobOrder.ORDERUNIT = JobOrder.ORDERUNIT;
				_jobOrder.ORDERQTY = JobOrder.ORDERQTY;
				_jobOrder.UNITPRICE = JobOrder.UNITPRICE;
				_jobOrder.TOTALCASTINGPRICE = JobOrder.TOTALCASTINGPRICE;
				_jobOrder.FINISHEDQTY = JobOrder.FINISHEDQTY;
				_jobOrder.TOTALPRICE = JobOrder.TOTALPRICE;
				_jobOrder.SI = JobOrder.SI;
				_jobOrder.WAXWORKER = JobOrder.WAXWORKER;
				_jobOrder.FINISHINGWORKER = JobOrder.FINISHINGWORKER;
				_jobOrder.REMARK = JobOrder.REMARK;
				_jobOrder.MODIDATE = JobOrder.MODIDATE;
				_jobOrder.MODIUSER = JobOrder.MODIUSER;

				try
				{
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception(string.Format("Update Job Order <<{0}>> Failed...", JobNo), ex);
				}
			}

			return _result;

		} // end UpdateJobOrder

		public DataTable GetJobReportForm()
		{
			DataTable _dt = new DataTable();
			DataColumn _dc = new DataColumn("KEY", typeof(System.Int32));
			_dt.Columns.Add(_dc);
			_dc = new DataColumn("NAME", typeof(System.String));
			_dt.Columns.Add(_dc);

			DataRow _dr = _dt.NewRow();
			_dr["KEY"] = 1;
			_dr["NAME"] = "ใบงาน";
			_dt.Rows.Add(_dr);

			_dr = _dt.NewRow();
			_dr["KEY"] = 2;
			_dr["NAME"] = "ใบ QC งานหล่อ";
			_dt.Rows.Add(_dr);

			_dr = _dt.NewRow();
			_dr["KEY"] = 3;
			_dr["NAME"] = "ใบสรุบงานหล่อ";
			_dt.Rows.Add(_dr);

			return _dt;

		} // end GetJobReportForm

		public DataTable GetSummaryJobInfoByYear()
		{
			DataTable _dt = new DataTable();
			var ji = from j in _om.JOBINFOS.AsParallel()
					 where j.ISDELETE == false
					 && j.FISCYEAR > 0
					 && j.GROUPCODE == "FG"
					 group j by j.FISCYEAR into jsum
					 select new
					 {
						 Year = jsum.Key.ToString(),
						 jan = jsum.Sum(x => x.FISCPERIOD == 1 ? x.ACCEPTQTY : 0),
						 feb = jsum.Sum(x => x.FISCPERIOD == 2 ? x.ACCEPTQTY : 0),
						 mar = jsum.Sum(x => x.FISCPERIOD == 2 ? x.ACCEPTQTY : 0),
						 apr = jsum.Sum(x => x.FISCPERIOD == 4 ? x.ACCEPTQTY : 0),
						 may = jsum.Sum(x => x.FISCPERIOD == 5 ? x.ACCEPTQTY : 0),
						 jun = jsum.Sum(x => x.FISCPERIOD == 6 ? x.ACCEPTQTY : 0),
						 jul = jsum.Sum(x => x.FISCPERIOD == 7 ? x.ACCEPTQTY : 0),
						 aug = jsum.Sum(x => x.FISCPERIOD == 8 ? x.ACCEPTQTY : 0),
						 sep = jsum.Sum(x => x.FISCPERIOD == 9 ? x.ACCEPTQTY : 0),
						 oct = jsum.Sum(x => x.FISCPERIOD == 10 ? x.ACCEPTQTY : 0),
						 nov = jsum.Sum(x => x.FISCPERIOD == 11 ? x.ACCEPTQTY : 0),
						 dec = jsum.Sum(x => x.FISCPERIOD == 12 ? x.ACCEPTQTY : 0),
						 total = jsum.Sum(x => x.ACCEPTQTY)
					 };

			if (ji != null)
			{
				_dt = OMControls.OMDataUtils.ToDataTable(ji.ToList());
			}
			return _dt;

		} // end GetSummaryJobInfoByYear

		public DataTable GetProgressJobInfos(int WorkYear, int WorkPeriod)
		{
			DataTable _result = new DataTable();
			var jp = (from j in _om.JOBINFOS
					  orderby j.FINISHDATE
					  where j.ISDELETE == false
					  && j.FISCPERIOD.Value == WorkPeriod
					  && j.FISCYEAR.Value == WorkYear
					  group j by j.FINISHDATE into pr
					  select new
					  {
						  pr.Key,
						  BLOCK = pr.Sum(i => i.GROUPCODE == "BLOCK" ? i.ACCEPTQTY : 0),
						  WAX = pr.Sum(i => i.GROUPCODE == "WAX" ? i.ACCEPTQTY : 0),
						  FINISHING = pr.Sum(i => i.GROUPCODE == "FINISHING" ? i.ACCEPTQTY : 0),
						  TREE = pr.Sum(i => i.GROUPCODE == "TREE" ? i.ACCEPTQTY : 0),
						  CAST_GOOD = pr.Sum(i => i.GROUPCODE == "FG" ? i.ACCEPTQTY : 0),
						  CAST_BAD = pr.Sum(i => i.GROUPCODE == "FG" ? i.REJECTQTY : 0),
						  TOTAL_CAST = pr.Sum(i => i.GROUPCODE == "FG" ? i.ACCEPTQTY + i.REJECTQTY : 0),
					  }).ToList();

			var p = jp.Select(x => new
			{
				day = string.Format("{0: ddd}", OMControls.OMUtils.Num2Date(x.Key)),
				workdate = OMControls.OMUtils.Num2Date(x.Key).ToShortDateString(),
				x.BLOCK,
				x.WAX,
				x.FINISHING,
				x.TREE,
				x.CAST_GOOD,
				x.CAST_BAD,
				x.TOTAL_CAST
			}).AsParallel();

			if (p != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(p.ToList());
			}

			return _result;

		} // end GetProgressJobInfos

		public DataTable GetAVGProgressByMonth(int Period, int WorkYear)
		{
			DataTable _result = new DataTable();
			string[] _code = new string[] { "BLOCK", "WAX", "FINISHING" };

			var dw = (from d in _om.JOBINFOS
					  where d.ISDELETE == false
					  && _code.Contains(d.GROUPCODE)
					  && d.FISCPERIOD.Value == Period
					  && d.FISCYEAR.Value == WorkYear
					  group d by new
					  {
						  d.FISCPERIOD.Value,
						  d.OPERATORNAME,
					  } into wd
					  select new
					  {
						  worker = wd.Key.OPERATORNAME,
						  N = wd.Select(x => x.FINISHDATE).Distinct().Count(),
						  Total = wd.Sum(x => x.ACCEPTQTY),
						  AVG = wd.Sum(x => x.ACCEPTQTY) / wd.Select(x => x.FINISHDATE).Distinct().Count(),
						  Performance = wd.Sum(x => x.ACCEPTQTY) / _om.JOBINFOS.Where(j => j.ISDELETE == false && _code.Contains(j.GROUPCODE)
					  && j.FISCPERIOD.Value == Period
					  && j.FISCYEAR.Value == WorkYear).Sum(x => x.ACCEPTQTY)
					  }).OrderBy(o => o.Performance).AsParallel();

			if (dw != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(dw);
			}
			return _result;

		} // end GetAVGProgressByMonth

		public DataTable GetWorkDetailsByDay(decimal WorkDate)
		{
			DataTable _result = new DataTable();
			var jd = (from j in _om.JOBINFOS
					  where j.FINISHDATE == WorkDate
					  && j.ISDELETE == false
					  group j by new
					  {
						  j.OPERATORNAME,
						  j.GROUPCODE
					  } into jp
					  select new
					  {
						  jp.Key.OPERATORNAME,
						  BLOCK = jp.Sum(x => x.GROUPCODE == "BLOCK" ? x.ACCEPTQTY : 0),
						  WAX = jp.Sum(x => x.GROUPCODE == "WAX" ? x.ACCEPTQTY : 0),
						  FINISHING = jp.Sum(x => x.GROUPCODE == "FINISHING" ? x.ACCEPTQTY : 0),
						  TREE = jp.Sum(x => x.GROUPCODE == "TREE" ? x.ACCEPTQTY : 0),
						  CAST_GOOD = jp.Sum(x => x.GROUPCODE == "FG" ? x.ACCEPTQTY : 0),
						  CAST_BAD = jp.Sum(x => x.GROUPCODE == "FG" ? x.REJECTQTY : 0),
						  WORK_TOTAL = jp.Sum(x => x.TOTALQTY)
					  }).OrderBy(x => x.WORK_TOTAL).ThenBy(y => y.OPERATORNAME).AsParallel();

			if (jd != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(jd.ToList());
			}

			return _result;

		} // end GetWorkDetailsByDay


		public DataTable GetSummaryByWorker(int WorkYear)
		{
			DataTable _result = new DataTable();
			string[] _worktype = new string[] { "BLOCK", "WAX", "FINISHING" };

			var worksum = (from j in _om.JOBINFOS
						   where j.ISDELETE == false
							   && j.FISCYEAR.Value == WorkYear
							   && _worktype.Contains(j.GROUPCODE)
						   group j by j.OPERATORNAME into ji
						   select new
						   {
							   ji.Key,
							   rate = ji.Sum(x => x.ACCEPTQTY) /
							   _om.JOBINFOS.Where(o => o.ISDELETE == false && _worktype.Contains(o.GROUPCODE)
					   && o.FISCYEAR.Value == WorkYear).Sum(x => x.ACCEPTQTY),
							   jan = ji.Sum(x => x.FISCPERIOD.Value <= 1 ? x.ACCEPTQTY : 0),
							   feb = ji.Sum(x => x.FISCPERIOD.Value <= 2 ? x.ACCEPTQTY : 0),
							   mar = ji.Sum(x => x.FISCPERIOD.Value <= 3 ? x.ACCEPTQTY : 0),
							   apr = ji.Sum(x => x.FISCPERIOD.Value <= 4 ? x.ACCEPTQTY : 0),
							   may = ji.Sum(x => x.FISCPERIOD.Value <= 5 ? x.ACCEPTQTY : 0),
							   jun = ji.Sum(x => x.FISCPERIOD.Value <= 6 ? x.ACCEPTQTY : 0),
							   jul = ji.Sum(x => x.FISCPERIOD.Value <= 7 ? x.ACCEPTQTY : 0),
							   aug = ji.Sum(x => x.FISCPERIOD.Value <= 8 ? x.ACCEPTQTY : 0),
							   sep = ji.Sum(x => x.FISCPERIOD.Value <= 9 ? x.ACCEPTQTY : 0),
							   oct = ji.Sum(x => x.FISCPERIOD.Value <= 10 ? x.ACCEPTQTY : 0),
							   nov = ji.Sum(x => x.FISCPERIOD.Value <= 11 ? x.ACCEPTQTY : 0),
							   dec = ji.Sum(x => x.FISCPERIOD.Value <= 12 ? x.ACCEPTQTY : 0),
							   total = ji.Sum(x => x.ACCEPTQTY)
						   }).OrderBy(o => o.rate).AsParallel();

			if (worksum != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(worksum.ToList());
			}

			return _result;

		} // end GetSummaryByWorker

		#endregion

	} // end class

} // end namespace
