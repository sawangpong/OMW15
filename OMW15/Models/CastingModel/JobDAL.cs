using Microsoft.VisualBasic;
using OMW15.Controllers.ToolController;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using OMW15.Views.CastingView.CastingUserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace OMW15.Models.CastingModel
{
	public class JobDAL
	{
		#region constructor and destructor
		private readonly OLDMOONEF1 _om;
		public JobDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		public async Task<DataTable> GetCastingCustomerListAsync()
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var cust = (from j in _om.JOBORDERS
								join c in _om.CUSTOMERS on j.CUSTCODE equals c.CUSTCODE
								where j.ISCANCEL == false
								select new
								{
									c.CUSTID,
									j.CUSTCODE,
									c.CUSTNAME
								}).Distinct().OrderBy(x => x.CUSTNAME).AsParallel();

				if (cust != null)
					_result = cust.ToDataTable();
				return _result;
			});
		} // end GetCastingCustomerListAsync

		public string FindCastingCustomer(int CustomerId)
		{
			return (from j in _om.JOBORDERS
					  join c in _om.CUSTOMERS on j.CUSTCODE equals c.CUSTCODE
					  where j.ISCANCEL == false
					  select new
					  {
						  c.CUSTID,
						  j.CUSTCODE,
						  c.CUSTNAME
					  }).Distinct().Single(x => x.CUSTID == CustomerId).CUSTNAME;

		} // end FindCastingCustomer

		public DataTable GetYearFinish()
		{
			var _result = new DataTable();
			var y = (from j in _om.JOBORDERS.AsEnumerable()
						where j.ISCANCEL == false
							  && j.FINISHDATE > 0
						select new
						{
							YearClose = j.FINISHDATE.Num2Date().Year
						}).Distinct().OrderByDescending(x => x.YearClose).AsParallel();

			if (y != null)
				_result = y.ToDataTable();

			return _result;
		} // end GetYearFinish

		public DataTable GetMonthFinish(int FinishYear)
		{
			var _result = new DataTable();
			var m = (from j in _om.JOBORDERS.AsEnumerable()
						where j.ISCANCEL == false
							  && j.FINISHDATE > 0
							  && j.FINISHDATE.Num2Date().Year == FinishYear
						select new
						{
							MonthClose = j.FINISHDATE.Num2Date().Month,
							MonthName = DateAndTime.MonthName(j.FINISHDATE.Num2Date().Month)
						}).Distinct().OrderByDescending(x => x.MonthClose).AsParallel();

			if (m != null)
				_result = m.ToDataTable();

			return _result;
		} // end GetMonthFinish

		public DataTable GetYearActive()
		{
			var _result = new DataTable();
			var y = (from j in _om.JOBORDERS.AsEnumerable()
						where j.ISCANCEL == false
							  && j.JOBDATE > 0
						select new
						{
							YearActive = j.JOBDATE.Num2Date().Year
						}).Distinct().OrderByDescending(x => x.YearActive).AsParallel();

			if (y != null)
				_result = y.ToDataTable();

			return _result;

		} // end GetYearActive

		public DataTable GetMonthActive(int ActiveYear)
		{
			var _result = new DataTable();
			var m = (from j in _om.JOBORDERS.AsEnumerable()
						where j.ISCANCEL == false
							  && j.JOBDATE > 0
							  && j.JOBDATE.Num2Date().Year == ActiveYear
						select new
						{
							MonthActive = j.JOBDATE.Num2Date().Month,
							MonthName = DateAndTime.MonthName(j.JOBDATE.Num2Date().Month)
						}).Distinct().OrderByDescending(x => x.MonthActive).AsParallel();

			if (m != null)
				_result = m.ToDataTable();

			return _result;

		} // end GetMonthActive

		public DataTable CreateJobYearList()
		{
			var _result = new DataTable();
			var y = (from j in _om.JOBINFOS
						where j.ISDELETE == false
							  && j.FISCYEAR > 0
						select new
						{
							JOBYEAR = j.FISCYEAR.Value
						}).Distinct().OrderByDescending(o => o.JOBYEAR).AsParallel();

			if (y != null)
				_result = y.ToDataTable();

			return _result;
		} // end CreateJobYearList

		public DataTable GetSummaryJobInfoByGroupCode(int JobId)
		{
			var _result = new DataTable();
			var jobinfos = (from job in _om.JOBINFOS
								 where job.ISDELETE == false
										&& job.JOBORDER.JOBNO == JobId
								 group job by job.GROUPCODE
				into q
								 select new
								 {
									 q.Key,
									 fg = q.Sum(i => i.ACCEPTQTY)
								 }).OrderBy(o => o.Key).AsParallel();

			_result = jobinfos.ToDataTable();
			return _result;
		} // end GetSummaryJobInfoByGroupCode

		public async Task<DataTable> getJobPrioritySummaryAsync()
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				int j = _om.JOBORDERS.Where(x => x.ISCANCEL == false
											&& x.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
											&& x.PREFIX != "")
									.Count();
				int n = j == 0 ? 1 : j;
				var g = _om.JOBORDERS.Where(x => x.ISCANCEL == false
											&& x.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
											&& x.PREFIX != "")
									.GroupBy(x => x.PRIORITY)
									.Select(x => new
									{
										priority = x.Key,
										count = x.Count(),
										ratio = ((x.Count() / n) * 100)
									}).OrderBy(o => o.priority).AsParallel();

				var p = g.AsEnumerable().Select(x => new
				{
					Q = this.getJobPriority(x.priority),
					BQ = x.count,
					R = (x.count / (decimal)n)
				});

				_result = p.ToDataTable();
				return _result;
			});
		} // end getJobPrioritySummaryAsync

		public async Task<DataTable> GetSummaryJobActiveAsync()
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var jobs = (from job in _om.JOBORDERS
								where job.ISCANCEL == false
									  && job.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
									  && job.PREFIX != ""
								group job by job.PREFIX
					into q
								select new
								{
									Q = q.Key,
									BQ = q.Sum(i => i.BACKORDQTY.Value)
								}).AsParallel();
				if (jobs != null)
					_result = jobs.ToDataTable();

				return _result;
			});
		} // end GetSummaryJobActiveAsync

		public async Task<List<CastingJobList>> GetJobOrderListAsync(string FilterText, OMShareJobEnums.FindList FilterOption)
		{
			return await Task.Run(() =>
			{
				var _j = new List<CastingJobList>();
				var _jobs = (from job in _om.JOBORDERS.AsEnumerable()
								 join c in _om.CUSTOMERS on job.CUSTCODE equals c.CUSTCODE
								 join m in _om.SYSDATAs on job.MATERIALTYPE.ToString() equals m.KEYVALUE
								 where job.ISCANCEL == false
										&& m.GROUPTITLE == "MATERIAL"
								 select new CastingJobList
								 {
									 Status = job.STATUS,
									 JobStatusName =
										 job.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
											 ? OMShareJobEnums.JobStatusEnumEN.Active.ToString()
											 : OMShareJobEnums.JobStatusEnumEN.Closed.ToString(),
									 JobNo = job.JOBNO.ToString(),
									 OrderDate = job.JOBDATE.Num2Date(),
									 Start = job.STARTDATE.Num2Date(),
									 Due = job.DUEDATE.Num2Date(),
									 rd = job.REMAINDAY.Value,
									 CustomerId = job.CUSTID,
									 CustomerCode = job.CUSTCODE,
									 CustomerName = c.CUSTNAME,
									 ItemId = job.ITEMID.Value,
									 CAT = job.PREFIX,
									 ItemNo = job.ITEMNO,
									 ItemName = job.ITEMNAME,
									 Material = m.THKEYNAME,
									 Unit = job.ORDERUNIT,
									 Qty = job.ORDERQTY,
									 Remain = job.BACKORDQTY.Value
								 }).AsParallel();
				if (!string.IsNullOrEmpty(FilterText))
					if (FilterOption == OMShareJobEnums.FindList.ชื่อลูกค้า)
						_j = _jobs.Where(x => x.CustomerName.Contains(FilterText)).ToList();
					else if (FilterOption == OMShareJobEnums.FindList.หมายเลขใบงาน)
						_j = _jobs.Where(x => x.JobNo.Contains(FilterText)).ToList();
				return _j;
			});
		} // end GetJobOrderListAsync

		public string getJobPriority(int priority)
		{
			return Enum.GetName(typeof(Shared.OMShareJobEnums.JobPriority), priority).ToString();
		}

		public async Task<DataTable> GetJobOrderListAsync(OMShareJobEnums.FindList FilterOption, string JobCategory, int JobStatus, int JobYear, int JobMonth, string FilterText, string connectionString)
		{
			return await Task.Run(() =>
				{
					int _findOption = (int)Enum.Parse(typeof(OMShareJobEnums.FindList), FilterOption.ToString());
					string _filterText = string.IsNullOrEmpty(FilterText) ? "''" : FilterText;
					StringBuilder s = new StringBuilder();
					s.AppendLine($" EXEC dbo.usp_OM_CASTING_ORDERS ");
					s.AppendLine($" @JobCategory ='{JobCategory}',");
					s.AppendLine($" @Status ={JobStatus},");
					s.AppendLine($" @JobYear ={JobYear},");
					s.AppendLine($" @JobMonth ={JobMonth},");
					s.AppendLine($" @SearchOption ={_findOption},");
					s.AppendLine($" @SearchFilterText ='{_filterText}'");
					return new DataConnect(s.ToString(), connectionString).ToDataTable;
				});
		} // end GetJobOrderListAsync

		public string GetItemCategory(string ItemCode)
		{
			return _om.ITEMCODEs.Single(x => x.ITEMCODE1 == ItemCode).ITEMCODENAME_TH;
		} // end GetItemCategory

		public JOBORDER GetJobHeaderInfo(int JobId)
		{
			return _om.JOBORDERS.Find(JobId);
		} // end GetJobItemInfo

		public JOBINFO GetJobInfoItem(int JobInfoId)
		{
			return _om.JOBINFOS.Single(x => x.LINESEQ == JobInfoId);
		} // end GetJobInfoItem

		public DataTable GetJobInfoByGroupCode(int JobId, string GroupCode, string connectionString)
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine($" EXECUTE dbo.usp_OM_GetJobInfoByGroupCode {JobId}, '{GroupCode}'");

			return new DataConnect(s.ToString(), connectionString).ToDataTable;
		}

		public async Task<DataTable> GetJobInfoByGroupCodeAsync(int JobId, string GroupCode)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				// JobInfo List
				var jobinfos = (from job in _om.JOBINFOS.AsEnumerable()
									 where job.ISDELETE == false
											&& job.GROUPCODE == GroupCode
											&& job.JOBORDER.JOBNO == JobId
									 orderby job.FINISHDATE
									 select new
									 {
										 job.LINESEQ,
										 job.FGLINESEQ,
										 job.GROUPCODE,
										 ITEMID = job.ITEMID.Value,
										 job.ITEMPREFIX,
										 job.ITEMNO,
										 job.FLASK_TEMP,
										 job.CAST_TEMP,
										 job.OPERATORNAME,
										 FinishDate = job.FINISHDATE.Num2Date(),
										 job.ACCEPTQTY,
										 job.REJECTQTY,
										 job.TOTALQTY,
										 job.TOTALWEIGHT,
										 job.AVGWEIGHT
									 }).AsParallel();
				if (jobinfos != null)
				{
					_result = jobinfos.ToDataTable();
				}
				return _result;
			});

		} // end GetJobInfoByGroupCode

		public async Task<DataTable> GetJobFGAsync(int Status, int YearClose)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				// summary job info for FG only
				var fg = (from ji in _om.JOBINFOS
							 where ji.ISDELETE == false
							 group ji by new
							 {
								 ji.JOBORDER.JOBNO
							 }
					into g
							 select new
							 {
								 g.Key,
								 block = g.Sum(i => i.GROUPCODE == "BLOCK" ? i.ACCEPTQTY : 0),
								 resin = g.Sum(i => i.GROUPCODE == "RESIN" ? i.ACCEPTQTY : 0),
								 wax = g.Sum(i => i.GROUPCODE == "WAX" ? i.ACCEPTQTY : 0),
								 finishing = g.Sum(i => i.GROUPCODE == "FINISHING" ? i.ACCEPTQTY : 0),
								 tree = g.Sum(i => i.GROUPCODE == "TREE" ? i.ACCEPTQTY : 0),
								 Casting = g.Sum(i => i.GROUPCODE == "FG" ? i.ACCEPTQTY : 0),
								 avgwt = g.Average(ii => ii.AVGWEIGHT),
								 totalWeight = g.Sum(t => t.TOTALWEIGHT)
							 }).AsParallel().ToList();

				// select job records only for active jobs
				var jobs = (from j in _om.JOBORDERS.AsEnumerable()
								where j.ISCANCEL == false
									  && j.STATUS == Status
									  && j.ORDERQTY > 0
									  && j.FINISHDATE.Num2Date().Year == YearClose
								orderby j.JOBNO
								select new
								{
									j.STATUS,
									j.JOBNO,
									j.PREFIX,
									j.ITEMNO,
									j.ITEMNAME,
									j.ORDERUNIT,
									j.ORDERQTY
								}).AsParallel().ToList();

				//// join with 2 dataset
				var fx = (from jo in jobs
							 from ji in fg
							 where jo.JOBNO == ji.Key.JOBNO
							 orderby jo.JOBNO
							 select new
							 {
								 jo.STATUS,
								 complete = string.Format("{0:P2}", ji.Casting / jo.ORDERQTY),
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
								 ji.totalWeight,
								 AvgWeight = ji.avgwt
							 }).OrderBy(o => o.complete).AsParallel();

				_result = fx.ToDataTable();

				return _result;
			});
		} // end GetJobFGAsync

		public async Task<DataTable> getJobInfoDetailByJobAsync(int jobNo)
		{
			return await Task.Run(() =>
			{
				return (from ji in _om.JOBINFOS
						  where ji.ISDELETE == false
						  && ji.JOBORDER.JOBNO == jobNo
						  orderby ji.FINISHDATE
						  select new
						  {
							  id = ji.LINESEQ,
							  workdate = ji.FINISHDATE,
							  worker = ji.OPERATORNAME,
							  code = ji.GROUPCODE,
							  goodqty = ji.ACCEPTQTY,
							  badqty = ji.REJECTQTY,
							  total = ji.TOTALQTY
						  }).AsParallel().ToDataTable();
			});

		} // end getJobInfoDetailByJobAsync


		public async Task<DataTable> getFGByJobNoAsync(int jobNo)
		{
			return await Task.Run(() =>
			{
				return (from fg in _om.FGSTOCKs
						  where fg.DOCNO == jobNo
						  select new
						  {
							  status = (fg.ISCOMPLETION == true ? "COMPLETE" : "STOK"),
							  stock = fg.QTY,
							  delivery = fg.DELIVERYQTY,
							  onhand = fg.REMAINFG
						  }).AsParallel().ToDataTable();
			});
		} // end getFGByJobNoAsync

		public async Task<DataTable> getJobItemDeliveryAsync(int jobNo)
		{
			return await Task.Run(() =>
			{
				return (from sl in _om.SOLINES
						  where sl.ISDELETE == false
								 && sl.JOBNO == jobNo
						  select new
						  {
							  sl.SONO,
							  DeliveryDate = sl.DELIVERDATE,
							  item = sl.PREFIX + sl.ITEMNO,
							  sl.ITEMNAME,
							  sl.UNIT,
							  sl.DELIVEREDQTY,
							  sl.TOTALWEIGHT
						  }).AsParallel().ToDataTable();
			});
		} // end getJobItemDeliveryAsync

		public async Task<DataTable> getJobDoingAsync(int JobNo)
		{
			return await Task.Run(() =>
			{
				// summary job info for FG only
				return (from ji in _om.JOBINFOS
						  where ji.ISDELETE == false && ji.JOBORDER.JOBNO == JobNo
						  group ji by ji.JOBORDER.JOBNO
							into g
						  select new
						  {
							  JobNumber = "Job-No : " + g.Key,
							  block = "ทำก้อนยาง : " + g.Sum(i => i.GROUPCODE == "BLOCK" ? i.ACCEPTQTY : 0).ToString(),
							  resin = "พิมพ์เรชิ่น : " + g.Sum(i => i.GROUPCODE == "RESIN" ? i.ACCEPTQTY : 0).ToString(),
							  wax = "ฉีดเทียน : " + g.Sum(i => i.GROUPCODE == "WAX" ? i.ACCEPTQTY : 0).ToString(),
							  finishing = "แต่งเทียน : " + g.Sum(i => i.GROUPCODE == "FINISHING" ? i.ACCEPTQTY : 0).ToString(),
							  tree = "ติดต้น : " + g.Sum(i => i.GROUPCODE == "TREE" ? i.ACCEPTQTY : 0).ToString(),
							  Casting = "หล่องาน : " + g.Sum(i => i.GROUPCODE == "FG" ? i.ACCEPTQTY : 0).ToString()
						  }).AsParallel().ToList().ToDataTable();
			});
		} // end getJobDoingAsync

		public async Task<DataTable> GetJobFGAsync(int Status)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				// summary job info for FG only
				var fg = (from ji in _om.JOBINFOS
							 where ji.ISDELETE == false
							 && ji.JOBORDER.STATUS == Status
							 && ji.JOBORDER.ISCANCEL == false
							 && ji.JOBORDER.ORDERQTY > 0
							 group ji by new
							 {
								 ji.JOBORDER
							 }
								into g
							 select new
							 {
								 g.Key.JOBORDER.JOBNO,
								 g.Key.JOBORDER.JOBDATE,
								 g.Key.JOBORDER.ORDERQTY,
								 g.Key.JOBORDER.STATUS,
								 g.Key.JOBORDER.PREFIX,
								 g.Key.JOBORDER.ITEMNO,
								 g.Key.JOBORDER.ITEMNAME,
								 g.Key.JOBORDER.ORDERUNIT,
								 block = g.Sum(i => i.GROUPCODE == "BLOCK" ? i.ACCEPTQTY : 0),
								 resin = g.Sum(i => i.GROUPCODE == "RESIN" ? i.ACCEPTQTY : 0),
								 wax = g.Sum(i => i.GROUPCODE == "WAX" ? i.ACCEPTQTY : 0),
								 finishing = g.Sum(i => i.GROUPCODE == "FINISHING" ? i.ACCEPTQTY : 0),
								 tree = g.Sum(i => i.GROUPCODE == "TREE" ? i.ACCEPTQTY : 0),
								 Casting = g.Sum(i => i.GROUPCODE == "FG" ? i.ACCEPTQTY : 0),
								 avgwt = g.Average(ii => ii.AVGWEIGHT),
								 totalWeight = g.Sum(t => t.TOTALWEIGHT)
							 }).AsParallel().ToList();

				// select job records only for active jobs
				//var jobs = (from j in _om.JOBORDERS
				//				where j.ISCANCEL == false
				//					  && j.STATUS == Status
				//					  && j.ORDERQTY > 0
				//				orderby j.JOBNO
				//				select new
				//				{
				//					j.STATUS,
				//					j.JOBDATE,
				//					j.JOBNO,
				//					j.PREFIX,
				//					j.ITEMNO,
				//					j.ITEMNAME,
				//					j.ORDERUNIT,
				//					j.ORDERQTY
				//				}).AsParallel().ToList();

				// join with 2 dataset
				//var fx = (from jo in jobs
				//			 from ji in fg
				//			 where jo.JOBNO == ji.JOBNO
				//			 orderby jo.JOBNO

				var fx = (from ji in fg
							 orderby ji.JOBNO
							 select new
							 {
								 ji.STATUS,
								 complete = string.Format("{0:P2}",
																				((ji.block / ji.ORDERQTY) 
																				+ (ji.resin / ji.ORDERQTY) 
																				+ (ji.wax / ji.ORDERQTY) 
																				+ (ji.finishing / ji.ORDERQTY) 
																				+ (ji.tree / ji.ORDERQTY) 
																				+ (ji.Casting / ji.ORDERQTY)) / 6),
								 DATE = ji.JOBDATE.Num2Date(),
								 JOBORDER = ji.JOBNO.ToString(),
								 ji.PREFIX,
								 ji.ITEMNO,
								 ji.ITEMNAME,
								 ji.ORDERUNIT,
								 ji.ORDERQTY,
								 ji.block,
								 ji.resin,
								 ji.wax,
								 ji.finishing,
								 ji.tree,
								 ji.Casting,
								 Remain = ji.ORDERQTY - ji.Casting,
								 ji.totalWeight,
								 AvgWeight = ji.avgwt
							 }).OrderBy(o => o.complete).AsParallel();

				_result = fx.ToDataTable();

				return _result;
			});
		} // end GetJobFGAsync

		// update FISCYEAR & FISCPERIOD for Jobinfos
		public int UpdateYearPeriodForJobInfos()
		{
			var _result = 0;
			if (_om.JOBINFOS.Where(x => x.ISDELETE == false && x.FISCYEAR == 0).Count() > 0)
			{
				try
				{
					_om.JOBINFOS.Where(x => x.FISCYEAR == 0 && x.ISDELETE == false).ToList().ForEach(c =>
					{
						c.FISCYEAR = c.FINISHDATE.Num2Date().Year;
						c.FISCPERIOD = c.FINISHDATE.Num2Date().Month;
					});
					_result = _om.SaveChanges();
				}
				catch (OptimisticConcurrencyException ex)
				{
					_result = -1;
					throw new Exception("Update Job Infos (Year/Month) failed....", ex);
				}
			}
			return _result;
		} // end UpdateYearPeriodForJobInfos

		// update joborder status by updating finish-qty from jobinfos 
		// and setting into joborder

		public int UpdateJobOrdersStatusByFinishQty(int JobNo, string Group)
		{
			var _result = 0;
			var jlines = (from jobinfo in _om.JOBINFOS
							  where jobinfo.ISDELETE == false
									&& jobinfo.JOBORDER.JOBNO == JobNo
									&& jobinfo.GROUPCODE == Group
							  group jobinfo by jobinfo.JOBORDER.JOBNO
				into jisum
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
					o.j.MODIUSER = omglobal.UserInfo;
					o.j.MODIDATE = DateTime.Today.Date2Num();
					o.j.FINISHEDQTY = o.ji.TotalFinish;
					o.j.TOTALWEIGHT = o.ji.totalWeight;
					o.j.STATUS = o.j.ORDERQTY <= o.ji.TotalFinish
						? (int)OMShareJobEnums.JobStatusEnumEN.Closed
						: (int)OMShareJobEnums.JobStatusEnumEN.Active;
					o.j.FINISHDATE = o.j.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Closed ? o.ji.LastFinishDate : 0;
				}
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				_result = -1;
				Alert.DisplayAlert("ERROR", ex.ToString());
			}

			return _result;

		} // end UpdateJobOrdersStatusByFinishQty

		public int UpdateJobOrdersStatusByFinishQty()
		{
			string[] _group = { "FG", "BLOCK", "RESIN" };
			var _result = 0;
			var jobs = (from jobinfo in _om.JOBINFOS
							  //join j in _om.JOBORDERS on jobinfo.JOBNO equals j.JOBNO
							  where jobinfo.ISDELETE == false
									&& jobinfo.JOBORDER.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
									&& _group.Contains(jobinfo.GROUPCODE)
							  group jobinfo by new
							  {
								  jobinfo.JOBORDER.JOBNO,
								  jobinfo.JOBORDER

							  }
								into jisum
							  select new
							  {
								  jisum.Key,
								  jisum.Key.JOBORDER.STATUS,
								  jisum.Key.JOBORDER.MODIDATE,
								  jisum.Key.JOBORDER.MODIUSER,
								  jisum.Key.JOBORDER.FINISHEDQTY,
								  jisum.Key.JOBORDER.TOTALWEIGHT,
								  LastFinishDate = jisum.Max(x => x.FINISHDATE),
								  TotalFinish = jisum.Sum(x => x.ACCEPTQTY),
								  totalWeight = jisum.Sum(t => t.TOTALWEIGHT)
							  }).AsParallel().AsEnumerable();

			//var jobs = from j in _om.JOBORDERS
			//			  join ji in jlines
			//			  on j.JOBNO equals ji.Key
			//			  where j.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
			//			  select new
			//			  {
			//				  j,
			//				  ji
			//			  };
			try
			{
				foreach (var o in jobs.ToList())
				{
					o.Key.JOBORDER.MODIUSER = omglobal.UserInfo;
					o.Key.JOBORDER.MODIDATE = DateTime.Today.Date2Num();
					o.Key.JOBORDER.FINISHEDQTY = o.TotalFinish;
					o.Key.JOBORDER.TOTALWEIGHT = o.totalWeight;
					o.Key.JOBORDER.STATUS = o.Key.JOBORDER.ORDERQTY <= o.TotalFinish
						? (int)OMShareJobEnums.JobStatusEnumEN.Closed
						: (int)OMShareJobEnums.JobStatusEnumEN.Active;
					o.Key.JOBORDER.FINISHDATE = o.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Closed ? o.LastFinishDate : 0;
				}
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				_result = -1;
				Alert.DisplayAlert("ERROR", ex.ToString());
			}

			return _result;
		} // end UpdateJobOrdersStatusByFinishQty

		#region FG

		public int saveFGLog(FGLogInfo log)
		{
			int _result = 0;
			try
			{
				_om.FGLogInfoes.Add(log);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				Alert.DisplayAlert("ERROR", ex.ToString());
			}
			return _result;
		}

		/// <summary>
		/// RETURN true = found that record was taken for delivered, otherwise = false
		/// </summary>
		/// <param name="jobno"></param>
		/// <returns></returns>
		public bool findRecordWasDelivered(int jobno, string groupCode)
		{
			return _om.FGSTOCKs.Any(x => x.DOCNO == jobno && x.DELIVERYQTY > 0 && x.APPCODE == groupCode);
		}

		public DataTable findEditableRecord(int jobno, string groupCode)
		{
			int _todayDate = DateTime.Today.Date2Num();
			return _om.JOBINFOS.Where(x => x.JOBORDER.JOBNO == jobno && x.FINISHDATE == _todayDate && x.GROUPCODE == groupCode).ToDataTable();
		}

		public decimal findRemainFGQty(int jobno, string groupCode)
		{
			return (decimal)_om.FGSTOCKs.Single(x => x.DOCNO == jobno && x.APPCODE == groupCode).REMAINFG.Value;
		}

		public int UpdateFGSByFinishQty(int JobNo, string Group)
		{
			int _fgRecordId = 0;
			var _isNewRecord = false;
			var _result = 0;

			// TODO
			// Changing code for FG
			//var _fgGroup = (Group == "FG" ? "QC-FG" : "QC-BLOCK");

			string _fgGroup = "QC-FG";

			switch (Group)
			{
				case "FG":
					_fgGroup = "QC-FG";
					break;

				case "BLOCK":
					_fgGroup = "QC-BLOCK";
					break;

				case "RESIN":
					_fgGroup = "QC-RESIN";
					break;
			}

			// the any keyword, return TRUE = contains any element
			// otherwise, return FALSE
			// In case, return TRUE, must checking that record
			_isNewRecord = (_om.FGSTOCKs.Any(x => x.APPCODE == _fgGroup && x.DOCNO == JobNo) == true ? false : true);

			// insert or update FG-Stock Table
			var jlines = (from jobinfo in _om.JOBINFOS
							  where jobinfo.ISDELETE == false
									&& jobinfo.GROUPCODE == Group
									&& jobinfo.JOBORDER.JOBNO == JobNo
							  group jobinfo by new
							  {
								  jobinfo.JOBORDER.JOBNO,
								  jobinfo.GROUPCODE,
								  jobinfo.MATERIALID
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
							}).Single();

			// create FGStock Object
			var f = new FGSTOCK();
			try
			{
				if (_isNewRecord) // add FG-Stock
				{
					f.APPCODE = _fgGroup;
					f.DOCNO = JobNo;
					f.DOCDATE = DateTime.Today.Date2Num();
					f.CUSTCODE = jobs.CUSTCODE;
					f.CUSTID = jobs.CUSTID;
					f.DELIVERYQTY = 0.00m;
					f.ISCOMPLETION = false;
					f.PREFIX = jobs.PREFIX;
					f.ITEMID = jobs.ITEMID.Value;
					f.ITEMNAME = jobs.ITEMNAME;
					f.ITEMNO = jobs.ITEMNO;
					f.MATID = jobs.MATERIALID.Value;
					f.TOTALLINEWT = jobs.totalWeight;
					f.QTY = jobs.TotalFinish;
					f.UNIT = jobs.ORDERUNIT;
					f.AUDITUSER = omglobal.UserInfo;
					f.MODIUSER = omglobal.UserInfo;
					f.MODIDATE = DateTime.Now;
					f.REMARK = string.Empty;

					_om.FGSTOCKs.Add(f);
					_result = _om.SaveChanges();
				}
				else // update FG-Stock
				{
					f.PREFIX = jobs.PREFIX;
					f.ITEMID = jobs.ITEMID.Value;
					f.ITEMNO = jobs.ITEMNO;
					f.ITEMNAME = jobs.ITEMNAME;
					f.QTY = jobs.TotalFinish;
					f.TOTALLINEWT = jobs.totalWeight;
					f.MODIUSER = omglobal.UserInfo;
					f.MODIDATE = DateTime.Now;

					var _fg = _om.FGSTOCKs.Single(x => x.DOCNO == JobNo && x.APPCODE == _fgGroup);

					// get FG-Stock RecordId
					_fgRecordId = _fg.FGSEQ;

					// Update FG-Stock Record
					_fg.ISCOMPLETION = (f.DELIVERYQTY != f.QTY ? false : true);
					_fg.QTY = f.QTY;
					_fg.TOTALLINEWT = f.TOTALLINEWT;
					_fg.MODIUSER = f.MODIUSER;
					_fg.MODIDATE = f.MODIDATE;

					_result = _om.SaveChanges();
				}

				// log file
				FGLogInfo _log = new FGLogInfo();

				string _matname = new Models.CastingModel.MaterialDAL().GetMaterialNameById(jobs.MATERIALID.Value);

				_log.action = $"{ (_isNewRecord ? "Add FG" : "Edit FG")}";
				_log.logdate = DateTime.Now;
				_log.modulename = "FG-STOCK";
				_log.partname = jobs.ITEMNAME;
				_log.partno = jobs.ITEMNO;
				_log.qty = jobs.TotalFinish;
				_log.recordid = _fgRecordId;
				_log.jobno = jobs.JOBNO;
				_log.type = _fgGroup;
				_log.unit = jobs.ORDERUNIT;
				_log.woker = omglobal.UserName;
				_log.workstation = omglobal.WorkStation;
				_log.material = $"{jobs.MATERIALID} : {_matname} ";
				_log.matweight = jobs.totalWeight;

				_om.FGLogInfoes.Add(_log);

				_om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				//scope.Dispose();
				throw new Exception(
					string.Format("มีความผิดพลาดระหว่าง{0}ข้อมูลของสต็อกสินค้า...", _isNewRecord ? "เพิ่ม" : "ปรับปรุง"), ex);
			}
			return _result;
		} // end UpdateFGSByFinishQty

		public int updateFGStockForDeletionJobInfoRecord(int jobNo, string fgGroup, int jobinfoRecordId)
		{
			int _result = 0;

			// 1. Find how many rows in JobInfos Table for FG group

			var _jinfoRows = _om.JOBINFOS.Where(x => x.JOBORDER.JOBNO == jobNo && x.GROUPCODE == fgGroup).AsParallel();

			if (_jinfoRows.ToList().Count == 1)
			{
				// delete row from FG-Stock and JobInfos Table
				// 1. find row for delete from FG-Stock
				//var _fgGroup = (fgGroup == "FG" ? "QC-FG" : "QC-BLOCK");

				string _fgGroup = "QC-FG";
				switch (fgGroup)
				{
					case "FG":
						_fgGroup = "QC-FG";
						break;

					case "BLOCK":
						_fgGroup = "QC-BLOCK";
						break;

					case "RESIN":
						_fgGroup = "QC-RESIN";
						break;
				}


				// the any keyword, return TRUE = contains any element
				// otherwise, return FALSE
				// In case, return TRUE, must checking that record
				int _id = (_om.FGSTOCKs.Single(x => x.APPCODE == _fgGroup && x.DOCNO == jobNo).FGSEQ);

				// remove FG-Stock record
				if (this.removeRecordFromFGStock(_id) > 0)
				{
					// success remove record from FG-Stok
					// remove record from JobInfos
					_result = this.removeRecordForJobInfo(jobinfoRecordId);
					if (_result > 0)
					{
						// success remove record from JobInfos
					}
				}
			}
			else // in case of 
			{
				_result = this.removeRecordForJobInfo(jobinfoRecordId);
				if (_result > 0)
				{
					this.UpdateFGSByFinishQty(jobNo, fgGroup);
				}
			}

			return _result;

		}

		public int removeRecordFromFGStock(int fgRecordId)
		{
			int _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					// keep log
					this.logForDeletionRecordFromFGStock(fgRecordId);

					// remove record
					_om.FGSTOCKs.Remove(_om.FGSTOCKs.Single(x => x.FGSEQ == fgRecordId));
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch
				{
				}
			}

			return _result;
		}

		private void logForDeletionRecordFromFGStock(int fgRecordId)
		{
			FGSTOCK _fg = _om.FGSTOCKs.Single(x => x.FGSEQ == fgRecordId);
			string _matname = new MaterialDAL().GetMaterialNameById(_fg.MATID);

			// get information for FG-Log
			FGLogInfo _log = new FGLogInfo();
			_log.action = "Delete";
			_log.jobno = _fg.DOCNO;
			_log.logdate = DateTime.Now;
			_log.material = $"{_fg.MATID} : {_matname}";
			_log.matweight = _fg.TOTALLINEWT;
			_log.modulename = "FG-STOCK";
			_log.partname = _fg.ITEMNAME;
			_log.partno = _fg.ITEMNO;
			_log.qty = _fg.QTY;
			_log.recordid = _fg.FGSEQ;
			_log.type = _fg.APPCODE;
			_log.unit = _fg.UNIT;
			_log.woker = omglobal.UserName;
			_log.workstation = omglobal.WorkStation;

			// add log
			this.saveFGLog(_log);
		}

		#endregion

		public int AddJobOrder(JOBORDER JobOrder)
		{
			var _result = 0;
			try
			{
				_om.JOBORDERS.Add(JobOrder);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Add new Job Order Failed...", ex);
			}
			return _result;
		} // end AddJobOrder

		public int UpdateJobOrder(int JobNo, JOBORDER JobOrder)
		{
			var _result = 0;
			var _jobOrder = _om.JOBORDERS.Single(x => x.JOBNO == JobNo);
			try
			{
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
				_jobOrder.FLASK_TEMP = JobOrder.FLASK_TEMP;
				_jobOrder.CAST_TEMP = JobOrder.CAST_TEMP;
				_jobOrder.ORDERUNIT = JobOrder.ORDERUNIT;
				_jobOrder.ORDERQTY = JobOrder.ORDERQTY;
				_jobOrder.PRIORITY = JobOrder.PRIORITY;
				_jobOrder.FINISHEDQTY = JobOrder.FINISHEDQTY;
				_jobOrder.CASTINGPRICE = JobOrder.CASTINGPRICE;
				_jobOrder.ISPRICEWITHMAT = JobOrder.ISPRICEWITHMAT;
				_jobOrder.UNITPRICE = JobOrder.UNITPRICE;
				_jobOrder.TOTALCASTINGPRICE = JobOrder.TOTALCASTINGPRICE;
				_jobOrder.TOTALPRICE = JobOrder.TOTALPRICE;
				_jobOrder.SI = JobOrder.SI;
				_jobOrder.WAXWORKER = JobOrder.WAXWORKER;
				_jobOrder.FINISHINGWORKER = JobOrder.FINISHINGWORKER;
				_jobOrder.REMARK = JobOrder.REMARK;
				_jobOrder.MODIDATE = JobOrder.MODIDATE;
				_jobOrder.MODIUSER = JobOrder.MODIUSER;

				_result = _om.SaveChanges();

				_om.JOBINFOS.Where(x => x.JOBORDER.JOBNO == JobNo).ToList().ForEach(u =>
				{
					u.MATERIALID = JobOrder.MATERIALTYPE;
					u.MODIDATE = DateTime.Now;
					u.MODIUSER = JobOrder.MODIUSER;
				});
				_result += _om.SaveChanges();

				// update FG-STOCK
				_om.FGSTOCKs.Where(x => x.DOCNO == JobNo).ToList().ForEach(u =>
				{
					u.MATID = JobOrder.MATERIALTYPE;
					u.UNIT = JobOrder.ORDERUNIT;
					u.MODIDATE = DateTime.Now;
					u.MODIUSER = JobOrder.MODIUSER;
				});
				_result += _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception(string.Format("Update Job Order <<{0}>> Failed...", JobNo), ex);
			}
			return _result;
		} // end UpdateJobOrder

		public async Task<DataTable> GetSummaryJobInfoByYearAsync()
		{
			return await Task.Run(() =>
			{
				var _dt = new DataTable();
				var ji = (from j in _om.JOBINFOS
							 where j.ISDELETE == false
								  && j.FISCYEAR > 0
								  && j.GROUPCODE == "FG"
							 // summary for casting only.
							 group j by j.FISCYEAR
					into jsum
							 select new
							 {
								 Year = jsum.Key.ToString(),
								 jan = jsum.Sum(x => x.FISCPERIOD == 1 ? x.ACCEPTQTY : 0),
								 feb = jsum.Sum(x => x.FISCPERIOD == 2 ? x.ACCEPTQTY : 0),
								 mar = jsum.Sum(x => x.FISCPERIOD == 3 ? x.ACCEPTQTY : 0),
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
							 }).OrderBy(x => x.Year).AsParallel();

				if (ji != null)
					_dt = ji.ToDataTable();
				return _dt;
			});
		} // end GetSummaryJobInfoByYearAsync

		public async Task<DataTable> GetProgressJobInfoAsync(int WorkYear, int WorkPeriod)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var jp = (from j in _om.JOBINFOS.AsEnumerable()
							 orderby j.FINISHDATE
							 where j.ISDELETE == false
								  && j.FISCPERIOD.Value == WorkPeriod
								  && j.FISCYEAR.Value == WorkYear
							 group j by j.FINISHDATE
					into pr
							 select new
							 {
								 day = pr.Key.Num2Date().ToString("ddd"),
								 workdate = pr.Key.Num2Date().ToShortDateString(),
								 BLOCK = pr.Sum(i => i.GROUPCODE == "BLOCK" ? i.ACCEPTQTY : 0),
								 RESIN = pr.Sum(i => i.GROUPCODE == "RESIN" ? i.ACCEPTQTY : 0),
								 WAX = pr.Sum(i => i.GROUPCODE == "WAX" ? i.ACCEPTQTY : 0),
								 FINISHING = pr.Sum(i => i.GROUPCODE == "FINISHING" ? i.ACCEPTQTY : 0),
								 TREE = pr.Sum(i => i.GROUPCODE == "TREE" ? i.ACCEPTQTY : 0),
								 CAST_GOOD = pr.Sum(i => i.GROUPCODE == "FG" ? i.ACCEPTQTY : 0),
								 CAST_BAD = pr.Sum(i => i.GROUPCODE == "FG" ? i.REJECTQTY : 0),
								 TOTAL_CAST = pr.Sum(i => i.GROUPCODE == "FG" ? i.ACCEPTQTY + i.REJECTQTY : 0)
							 }).AsParallel();
				if (jp != null)
					_result = jp.ToDataTable();

				return _result;
			});
		} // end GetProgressJobInfoAsync

		public async Task<DataTable> GetAVGProgressByMonthAsync(int Period, int WorkYear)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				string[] _code = { "BLOCK", "WAX", "FINISHING" };

				var dw = (from d in _om.JOBINFOS
							 where d.ISDELETE == false
								  && _code.Contains(d.GROUPCODE)
								  && d.FISCPERIOD.Value == Period
								  && d.FISCYEAR.Value == WorkYear
							 group d by new
							 {
								 d.FISCPERIOD.Value,
								 d.OPERATORNAME
							 }
					into wd
							 select new
							 {
								 worker = wd.Key.OPERATORNAME,
								 N = wd.Select(x => x.FINISHDATE).Distinct().Count(),
								 Total = wd.Sum(x => x.ACCEPTQTY),
								 AVG = wd.Sum(x => x.ACCEPTQTY) / wd.Select(x => x.FINISHDATE).Distinct().Count(),
								 Performance =
								 wd.Sum(x => x.ACCEPTQTY) / _om.JOBINFOS.Where(j => j.ISDELETE == false && _code.Contains(j.GROUPCODE)
																					&& j.FISCPERIOD.Value == Period
																					&& j.FISCYEAR.Value == WorkYear).Sum(x => x.ACCEPTQTY)
							 }).OrderBy(o => o.Performance).AsParallel();

				if (dw != null)
					_result = dw.ToDataTable();
				return _result;
			});
		} // end GetAVGProgressByMonthAsync

		public async Task<DataTable> GetWorkDetailsByDayAsync(decimal WorkDate)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var jd = (from j in _om.JOBINFOS
							 where j.FINISHDATE == WorkDate
								  && j.ISDELETE == false
							 group j by new
							 {
								 j.OPERATORID,
								 j.OPERATORNAME,
								 j.GROUPCODE
							 }
					into jp
							 select new
							 {
								 jp.Key.OPERATORID,
								 jp.Key.OPERATORNAME,
								 BLOCK = jp.Sum(x => x.GROUPCODE == "BLOCK" ? x.ACCEPTQTY : 0),
								 RESIN = jp.Sum(x => x.GROUPCODE == "RESIN" ? x.ACCEPTQTY : 0),
								 WAX = jp.Sum(x => x.GROUPCODE == "WAX" ? x.ACCEPTQTY : 0),
								 FINISHING = jp.Sum(x => x.GROUPCODE == "FINISHING" ? x.ACCEPTQTY : 0),
								 TREE = jp.Sum(x => x.GROUPCODE == "TREE" ? x.ACCEPTQTY : 0),
								 CAST_GOOD = jp.Sum(x => x.GROUPCODE == "FG" ? x.ACCEPTQTY : 0),
								 CAST_BAD = jp.Sum(x => x.GROUPCODE == "FG" ? x.REJECTQTY : 0),
								 WORK_TOTAL = jp.Sum(x => x.TOTALQTY)
							 }).OrderBy(x => x.WORK_TOTAL).ThenBy(y => y.OPERATORNAME).AsParallel();

				if (jd != null)
					_result = jd.ToDataTable();

				return _result;
			});
		} // end GetWorkDetailsByDayAsync

		public async Task<DataTable> GetSummaryByWorkerAsync(int WorkYear)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				string[] _worktype = { "BLOCK", "WAX", "FINISHING" };

				var worksum = (from j in _om.JOBINFOS
									where j.ISDELETE == false
										 && j.FISCYEAR.Value == WorkYear
										 && _worktype.Contains(j.GROUPCODE)
									group j by j.OPERATORNAME
					into ji
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
					_result = worksum.ToDataTable();

				return _result;
			});
		} // end GetSummaryByWorkerAsync

		public async Task<DataTable> GetSummaryBadCastingByStyleAsync(int workYear, workCatenum selectedCat)
		{
			return await Task.Run(() =>
			{
				var result = new DataTable();

				var dailyWork = (from ji in _om.JOBINFOS
									  join cp in _om.CUSTPRICELISTs on ji.ITEMID equals cp.PRICESEQ
									  join sd in _om.SYSDATAs on cp.PRODUCTSTYLE.ToString() equals sd.KEYVALUE
									  where ji.ISDELETE == false
											 && sd.GROUPTITLE == "PRODUCTSTYLE"
											 && ji.FISCYEAR == workYear
											 &&
											 (selectedCat == workCatenum.NonCasting
												 ? ji.GROUPCODE != "FG"
												 : (selectedCat == workCatenum.OnlyCasting
													 ? ji.GROUPCODE == "FG"
													 : ji.GROUPCODE == "FG" || ji.GROUPCODE != "FG"))
									  group new
									  {
										  ji,
										  sd
									  } by new
									  {
										  sd.THKEYNAME
									  }
					into dw
									  select new
									  {
										  Style = dw.Key.THKEYNAME,
										  Jan = dw.Sum(x => x.ji.FISCPERIOD == 1 ? x.ji.REJECTQTY : 0),
										  Feb = dw.Sum(x => x.ji.FISCPERIOD == 2 ? x.ji.REJECTQTY : 0),
										  Mar = dw.Sum(x => x.ji.FISCPERIOD == 3 ? x.ji.REJECTQTY : 0),
										  Apr = dw.Sum(x => x.ji.FISCPERIOD == 4 ? x.ji.REJECTQTY : 0),
										  May = dw.Sum(x => x.ji.FISCPERIOD == 5 ? x.ji.REJECTQTY : 0),
										  Jun = dw.Sum(x => x.ji.FISCPERIOD == 6 ? x.ji.REJECTQTY : 0),
										  Jul = dw.Sum(x => x.ji.FISCPERIOD == 7 ? x.ji.REJECTQTY : 0),
										  Aug = dw.Sum(x => x.ji.FISCPERIOD == 8 ? x.ji.REJECTQTY : 0),
										  Sep = dw.Sum(x => x.ji.FISCPERIOD == 9 ? x.ji.REJECTQTY : 0),
										  Oct = dw.Sum(x => x.ji.FISCPERIOD == 10 ? x.ji.REJECTQTY : 0),
										  Nov = dw.Sum(x => x.ji.FISCPERIOD == 11 ? x.ji.REJECTQTY : 0),
										  Dec = dw.Sum(x => x.ji.FISCPERIOD == 12 ? x.ji.REJECTQTY : 0)
									  }).OrderBy(x => x.Style).AsParallel();

				if (dailyWork != null)
					result = dailyWork.ToDataTable();

				return result;
			});
		} // end GetSummaryBadCastingByStyleAsync

		#region JOB-INFO

		public int removeRecordForJobInfo(int jobInfoId)
		{
			int _result = 0;
			try
			{
				// keep log
				this.logForDeletionRecordFromJobInfo(jobInfoId);

				// remove record
				_om.JOBINFOS.Remove(_om.JOBINFOS.Single(x => x.LINESEQ == jobInfoId));
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("มีข้อผิดพลาด ไม่สามารถลบรายการที่เลือกได้ !!!!", ex);
			}
			return _result;
		}

		private void logForDeletionRecordFromJobInfo(int jobInfoRecordId)
		{
			// get jobinfo 
			JOBINFO _j = _om.JOBINFOS.Single(x => x.LINESEQ == jobInfoRecordId);
			string _matname = new MaterialDAL().GetMaterialNameById(_j.MATERIALID.Value);
			string _unit = string.Empty;
			string _partName = string.Empty;
			_om.JOBORDERS.Where(x => x.JOBNO == _j.JOBORDER.JOBNO).ToList().ForEach(s =>
			{
				_unit = s.ORDERUNIT;
				_partName = s.ITEMNAME;
			});

			FGLogInfo _log = new FGLogInfo();
			_log.action = "Delete";
			_log.jobno = _j.JOBORDER.JOBNO;
			_log.logdate = DateTime.Now;
			_log.material = $"{_j.MATERIALID} : {_matname}";
			_log.matweight = _j.TOTALWEIGHT;
			_log.modulename = "JOBINFO";
			_log.partname = _partName;
			_log.partno = _j.ITEMNO;
			_log.qty = _j.ACCEPTQTY;
			_log.recordid = _j.LINESEQ;
			_log.type = _j.GROUPCODE;
			_log.unit = _unit;
			_log.woker = omglobal.UserName;
			_log.workstation = omglobal.WorkStation;

			// add log
			this.saveFGLog(_log);

		} // end logForDeletionRecordFromJobInfo


		public int UpdateJobInfoItem(JOBINFO JobInfo)
		{
			var _result = 0;
			try
			{
				if (JobInfo.LINESEQ == 0)
				{
					_om.JOBINFOS.Add(JobInfo);
					_result = _om.SaveChanges();
				}
				else
				{
					var ji = _om.JOBINFOS.Single(x => x.LINESEQ == JobInfo.LINESEQ);
					ji.ACCEPTQTY = JobInfo.ACCEPTQTY;
					ji.AVGWEIGHT = JobInfo.AVGWEIGHT;
					ji.BADSCORE = JobInfo.BADSCORE;
					ji.CUSTCODE = JobInfo.CUSTCODE;
					ji.CUSTID = JobInfo.CUSTID;
					ji.ERRORID = JobInfo.ERRORID;
					ji.FINISHDATE = JobInfo.FINISHDATE;
					ji.FISCPERIOD = JobInfo.FISCPERIOD;
					ji.FISCYEAR = JobInfo.FISCYEAR;
					ji.GOODSCORE = JobInfo.GOODSCORE;
					ji.GROUPCODE = JobInfo.GROUPCODE;
					ji.ISDELETE = JobInfo.ISDELETE;
					ji.ITEMID = JobInfo.ITEMID;
					ji.ITEMNO = JobInfo.ITEMNO;
					ji.ITEMPREFIX = JobInfo.ITEMPREFIX;
					ji.JOBORDER.JOBNO = JobInfo.JOBORDER.JOBNO;
					ji.MATERIALID = JobInfo.MATERIALID;
					ji.MODIDATE = JobInfo.MODIDATE;
					ji.MODIUSER = JobInfo.MODIUSER;
					ji.OPERATORID = JobInfo.OPERATORID;
					ji.OPERATORNAME = JobInfo.OPERATORNAME;
					ji.FLASK_TEMP = JobInfo.FLASK_TEMP;
					ji.CAST_TEMP = JobInfo.CAST_TEMP;
					ji.RECORDDATE = JobInfo.RECORDDATE;
					ji.RECORDEDBY = JobInfo.RECORDEDBY;
					ji.REJECTQTY = JobInfo.REJECTQTY;
					ji.TOTALQTY = JobInfo.TOTALQTY;
					ji.TOTALWEIGHT = JobInfo.TOTALWEIGHT;

					_result = _om.SaveChanges();
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return _result;
		} // end UpdateJobInfoItem

		#endregion

		#region JOBS HISTORY

		public List<JobHistories> SelectJobHistory(int ItemId)
		{
			var _jh = (from j in _om.JOBORDERS.AsEnumerable()
						  where j.ISCANCEL == false
								&& j.ITEMID == ItemId
						  select new JobHistories
						  {
							  CustomerCode = j.CUSTCODE,
							  Status =
								  j.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
									  ? OMShareJobEnums.JobStatusEnumEN.Active.ToString()
									  : OMShareJobEnums.JobStatusEnumEN.Closed.ToString(),
							  JobNo = j.JOBNO,
							  JobOpen = j.JOBDATE.Num2Date(),
							  JobDue = j.DUEDATE.Num2Date(),
							  ItemNo = j.PREFIX + j.ITEMNO,
							  ItemName = j.ITEMNAME,
							  OrderUnit = j.ORDERUNIT,
							  OrderQty = j.ORDERQTY
						  }).AsParallel();

			return _jh.ToList();

		} // end SelectJobHistoty

		public void GetJobHistory(ref DataGridView Source, int ItemId)
		{
			var _jh = (from j in _om.JOBORDERS.AsEnumerable()
						  where j.ISCANCEL == false
								&& j.ITEMID == ItemId
						  orderby j.JOBNO
						  select new
						  {
							  j.JOBNO,
							  Date = j.JOBDATE.Num2Date(),
							  j.CUSTCODE,
							  ID = j.ITEMID.Value,
							  j.PREFIX,
							  j.ITEMNO,
							  j.ITEMNAME,
							  j.ORDERUNIT,
							  j.ORDERQTY,
							  j.CASTINGPRICE
						  }).AsParallel().ToList();

			if (_jh != null)
				Source.DataSource = _jh.ToList();
		} // end GetJobHistory

		#endregion
	} // end class
} // end namespace