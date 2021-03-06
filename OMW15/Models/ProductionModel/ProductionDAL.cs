﻿using OMW15.ModelDataExtend;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OMW15.Shared.OMShareProduction;

namespace OMW15.Models.ProductionModel
{
	public class ProductionDAL
	{
		#region constructor
		private readonly OLDMOONEF1 _om;
		private readonly ERP _erp;
		public ProductionDAL()
		{
			_om = new OLDMOONEF1();
			_erp = new ERP();
		}

		#endregion

		#region class helper methods

		#region call sproc

		public DataTable GetYearForTimeRecord(string workerCode)
			=> new DataConnect($" EXEC dbo.usp_OM_PRODUCTION_WORKER_WORKYEARS @workerid='{workerCode}'", omglobal.SysConnectionString).ToDataTable;

		public DataTable GetMonthForTimeRecord(string workerCode, int jobYear)
		{
			return _om.PRODUCTIONJOBINFOes.AsEnumerable()
						.Where(x => x.WORKERID == workerCode && x.WORKYEAR == jobYear)
						.Select(x => new
						{
							jobMonth = x.WORKPERIOD.Value,
							jobMonthName = x.WORKPERIOD.Value.GetThaiMonthName()
						})
						.Distinct()
						.OrderByDescending(o => o.jobMonth)
						.ToDataTable();
		}

		#endregion

		#region PRODUCTION PROCESS

		public List<ProductionYear> GetProductionYearByStatus(int status)
		{
			if (status == (int)ProductionJobStatus.Active)
			{
				return _om.PRODUCTIONJOBS.Where(x => x.STATUS == status)
					.Select(x => new ProductionYear
					{
						JobYear = x.RELEASEDATE.Value.Year
					}).Distinct()
					.OrderByDescending(o => o.JobYear)
					.ToList();
			}
			else // Status = Closed
			{
				return _om.PRODUCTIONJOBS.Where(x => x.STATUS == status)
					.Select(x => new ProductionYear
					{
						JobYear = x.COMPLETEDATE.Value.Year
					}).Distinct()
					.OrderByDescending(o => o.JobYear)
					.ToList();
			}
		}

		public DataTable GetProductionProcess()
		{
			var _result = new DataTable();

			var pc = (from pdc in _om.PRDPROCESSes
						 orderby pdc.PROCESSNAME
						 select new
						 {
							 key = pdc.PRDPROCESSID,
							 value = pdc.PROCESSNAME
						 }).AsParallel();

			if (pc != null)
				_result = pc.ToDataTable();

			return _result;
		} // end GetProductionProcess

		public DataTable GetProductionProcessList()
		{
			var _result = new DataTable();
			var pc = (from p in _om.PRDPROCESSes
						 orderby p.PROCESSNAME
						 select new
						 {
							 p.PRDPROCESSID,
							 p.PROCESSNAME,
							 p.MACHINE_GROUP,
							 p.MACHINE,
							 p.SCORE
						 }).AsParallel();

			if (pc != null)
				_result = pc.ToDataTable();

			return _result;
		} // end GetProductionProcessList

		public int GetNewProductionProcessId() => (Convert.ToInt32(_om.PRDPROCESSes.Max(x => x.PRDPROCESSID)) + 1);

		public PRDPROCESS GetProcessInfo(int ProcessId) => (_om.PRDPROCESSes.Single(x => x.PRDPROCESSID == ProcessId));

		public int UpdateProductionProcess(PRDPROCESS PrdProcess, ActionMode Mode)
		{
			var _result = 0;
			try
			{
				if (Mode == ActionMode.Add)
				{
					_om.PRDPROCESSes.Add(PrdProcess);
					_result = _om.SaveChanges();
				}
				else if (Mode == ActionMode.Edit)
				{
					var p = _om.PRDPROCESSes.FirstOrDefault(x => x.PRDPROCESSID == PrdProcess.PRDPROCESSID);
					p.PROCESSNAME = PrdProcess.PROCESSNAME;
					p.MACHINE = PrdProcess.MACHINE;
					p.MACHINE_GROUP = PrdProcess.MACHINE_GROUP;
					p.SCORE = PrdProcess.SCORE;
					p.STDHOUR = PrdProcess.STDHOUR;
					_result = _om.SaveChanges();
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update production process", ex);
			}

			return _result;
		} // end UpdateProductionProcess

		public int DeleteProductionProcess(int ProductionProcessId)
		{
			var _result = 0;
			var pc = _om.PRDPROCESSes.FirstOrDefault(x => x.PRDPROCESSID == ProductionProcessId);
			try
			{
				_om.PRDPROCESSes.Remove(pc);

				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't delete the selected production process.......", ex);
			}

			return _result;
		} // end DeleteProductionProcess

		#endregion

		public async Task<DataTable> GetProductionJobHistoryCompareAsync(string itemNo)
		{
			return await Task.Run(() =>
			{
				return new DataConnect($" EXEC dbo.usp_OM_PRODUCTION_HIST_COMPARE @itemNo='{itemNo}'", omglobal.SysConnectionString).ToDataTable;
			});
		}

		public async Task<DataTable> GetProductionJobHistoryListAsync(string itemNo)
		{
			return await Task.Run(() =>
			{
				return new DataConnect($" EXEC dbo.usp_OM_PRODUCTION_JOB_HISTORY @itemno='{itemNo}'", omglobal.SysConnectionString).ToDataTable;
			});
		}

		public async Task<DataTable> GetProductionJobsAsync(int Status, int jobYear, string filter = "")
		{
			return await Task.Run(() =>
			{
				return new DataConnect($"EXEC dbo.usp_OM_PRODUCTION_JOBORDERS @JobStatus={Status},@JobYear={jobYear},@JobFilter='{filter}'", omglobal.SysConnectionString).ToDataTable;
			});
		}

		public async Task<DataTable> GetProductionYearListAsync()
		{
			return await Task.Run(() =>
			{
				return (_erp.DOCINFOes.Select(y => new
				{
					YearCode = y.DI_DATE.Year
				}).Distinct().OrderByDescending(o => o.YearCode).AsParallel().ToDataTable());
			});

		} // end GetProductionYearList

		public DataTable GetProductionYearList(string CodePrefix, string connectionString)
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine(" SELECT ");
			s.AppendLine(" DOC_YEAR");
			s.AppendLine(" FROM OM_ERP_PRODUCTION_DOCYEAR");
			s.AppendLine($" WHERE DOC_REF = '{CodePrefix}' ");
			s.AppendLine(" ORDER BY DOC_YEAR DESC");

			return new DataConnect(s.ToString(), connectionString).ToDataTable;
		}

		public DataTable GetProjects(string connectionString)
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine(" SELECT ");
			s.AppendLine(" * ");
			s.AppendLine(" FROM OM_ERP_PRODUCTION_PROJECT ");
			s.AppendLine(" ORDER BY PRJ_CODE ");

			return new DataConnect(s.ToString(), connectionString).ToDataTable;
		}

		public DataTable GetProductionWorkYear()
		{
			return _om.PRODUCTIONJOBINFOes.Select(x => new
			{
				x.WORKYEAR
			}).Distinct().OrderByDescending(o => o.WORKYEAR).ToDataTable();
		}

		public DataTable GetWokerByYear(int workYear)
		{
			return _om.PRODUCTIONJOBINFOes
						.Where(x => x.WORKYEAR == workYear)
						.Select(x => new
						{
							x.WORKERID,
							x.WORKERNAME
						}).Distinct().OrderBy(o => o.WORKERNAME).ToDataTable();
		}

		public DataTable GetWorkInfo(int workYear, string workerId)
		{
			return new DataConnect($"EXEC dbo.usp_OM_PRODUCTION_WORKINFO @workyear={workYear},@workerid='{workerId}'", omglobal.SysConnectionString).ToDataTable;
		}

		//public DataTable GetPendingProductionOrderList1() => _om.OM_ERP_PRODUCTION_REQUEST_TRANSFER_LIST.ToDataTable();

		public DataTable GetPendingProductionOrderList1()
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine(" SELECT ");
			s.AppendLine(" di.DI_KEY ");
			s.AppendLine(",di.DI_ACTIVE ");
			s.AppendLine(",CASE WHEN di.DI_ACTIVE = 2 THEN 'CANCELED' ELSE 'ACTIVE' END AS [STATUS] ");
			s.AppendLine(",SUBSTRING(di.DI_REF,1,4) AS [CODE] ");
			s.AppendLine(",di.DI_REF ");
			s.AppendLine(",CAST(di.DI_DATE AS DATE) AS [REQ_DATE] ");
			s.AppendLine(",MONTH(di.DI_DATE) AS [PERIOD]");
			s.AppendLine(",YEAR(di.DI_DATE) AS [YEAR]");
			s.AppendLine(",trd.TRD_KEYIN AS [PARTNO]");
			s.AppendLine(",trd.TRD_SH_NAME AS [PARTNAME]");
			s.AppendLine(",trd.TRD_QTY AS [QTY]");
			s.AppendLine(",trd.TRD_UTQNAME AS [UNIT]");
			s.AppendLine(",ISNULL(di.DI_REMARK,'') AS [REMARK]");
			s.AppendLine(" FROM ERP.dbo.DOCINFO AS di ");
			s.AppendLine(" LEFT JOIN ERP.dbo.TRANSTKH AS trh ON di.DI_KEY = trh.TRH_DI ");
			s.AppendLine(" LEFT JOIN ERP.dbo.TRANSTKD AS trd ON trh.TRH_KEY = trd.TRD_TRH ");
			s.AppendLine(" WHERE (SUBSTRING(di.DI_REF,1,4) IN ('RMFG','RMMG','RMPS'))");
			s.AppendLine(" AND trd.TRD_SEQ = 1");

			s.AppendLine(" AND di.DI_KEY NOT IN (SELECT p.ERP_DI FROM dbo.PRODUCTIONJOBS p WHERE SUBSTRING(p.ERP_ORDER,1,4) IN ('RMFG','RMMG','RMPS'))");
			
			// FOR WHAT ??
			s.AppendLine(" AND di.DI_REF NOT IN (SELECT DISTINCT t.TRD_REFER_REF FROM ERP.dbo.TRANSTKD t WHERE (t.TRD_REFER_REF IS NOT NULL) AND (SUBSTRING(t.TRD_REFER_REF,1,4) IN ('RMFG','RMMG','RMPS'))) ");

			s.AppendLine(" ORDER BY di.DI_REF");
			return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;
		}

		public DataTable GetProductionOrderList(string prefixDICode, string connectionString)
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine(" SELECT ");
			s.AppendLine(" prd.* ");
			s.AppendLine(" FROM OM_ERP_PRODUCTION_REQLIST prd ");
			s.AppendLine(" ORDER BY prd.DI_REF ");

			return new DataConnect(s.ToString(), connectionString).ToDataTable;

		} // end GetProductionOrderList

		public async Task<List<IssueMap>> IssueRQAsync(string[] rqcode, int year = 0)
		{
			return await Task.Run(() =>
			{
				var issue = (from di in _erp.DOCINFOes
								 join trh in _erp.TRANSTKHs on di.DI_KEY equals trh.TRH_DI
								 join trd in _erp.TRANSTKDs on trh.TRH_KEY equals trd.TRD_TRH
								 where trd.TRD_REFER_REF != null
								 && OMShareProduction.ProductionRequestCode.Contains(trd.TRD_REFER_REF.Substring(0, 4))
								 select new
								 {
									 ReqNo = trd.TRD_REFER_REF,
									 ReqId = trd.TRD_REFER_DI.Value,
									 IssueNo = di.DI_REF,
									 IssueId = di.DI_KEY,
									 DocYear = di.DI_DATE.Year
								 }).Distinct().OrderBy(o => o.ReqNo);

				if (year == 0)
				{
					return issue.AsEnumerable().Select((r, i) => new IssueMap
					{
						Index = ++i,
						ReqNo = r.ReqNo,
						ReqId = r.ReqId,
						IssueNo = r.IssueNo,
						IssueId = r.IssueId
					}).OrderBy(o => o.ReqNo).ToList();
				}
				else
				{
					return issue.AsEnumerable().Where(y => y.DocYear == year).Select((r, i) => new IssueMap
					{
						Index = ++i,
						ReqNo = r.ReqNo,
						ReqId = r.ReqId,
						IssueNo = r.IssueNo,
						IssueId = r.IssueId
					}).OrderBy(o => o.ReqNo).ToList();
				}
			});
		}

		public async Task<DataTable> GetProductionJobCodeListAsync(string[] CodeList)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var pt = (from d in _erp.DOCTYPEs
							 orderby d.DT_PREFIX
							 where CodeList.Contains(d.DT_DOCCODE)
							 select new
							 {
								 d.DT_DOCCODE,
								 Name = d.DT_THAIDESC
							 }).AsParallel();

				if (pt != null)
					_result = pt.ToDataTable();

				return _result;
			});

		} // end GetProductionTransformCodeList

		#endregion

		#region PRODUCTION DATA

		public int UpdateItemStandardHour(string itemno = "")
		{
			return DataConnect.ExcuteSP($" EXEC dbo.usp_OM_PRODUCTION_UPDATE_STD_ITEM_HOUR_WORK @itemno='{itemno}'", omglobal.SysConnectionString);
		}

		public int UpdateProductionJobHours()
		{
			return DataConnect.ExcuteSP($" EXECUTE dbo.usp_OM_PRODUCTION_UPDATE_JOBHOURS ", omglobal.SysConnectionString);
		}

		public DataTable ActualTimeRecord(DateTime workDate, string empCode)
		{
			return new DataConnect($" EXECUTE dbo.usp_ValidTimeRecord @EmpCode='{empCode}',@Y={workDate.Year},@M={workDate.Month},@D={workDate.Day}", omglobal.SysConnectionString).ToDataTable;
		}

		public PRODUCTIONJOB GetProductionJobHeader(string eprOrderNo) => _om.PRODUCTIONJOBS.SingleOrDefault(x => x.ERP_ORDER == eprOrderNo);

		public int UpdateProductionHeader(PRODUCTIONJOB p, int ProductionJobId)
		{
			var _result = 0;
			try
			{
				if (ProductionJobId == 0)
				{
					_om.PRODUCTIONJOBS.Add(p);
				}
				else // 
				{
					var j = _om.PRODUCTIONJOBS.Single(x => x.ERP_ORDER == p.ERP_ORDER);
					j.CREATEDATE = p.CREATEDATE;
					j.RELEASEDATE = p.RELEASEDATE;
					j.DUEDATE = p.DUEDATE;
					j.COMPLETEDATE = p.COMPLETEDATE;
					j.JOBYEAR = p.JOBYEAR;
					j.SN = p.SN;
					j.STATUS = p.STATUS;
					j.DRAWINGNO = p.DRAWINGNO;
					j.DRAWINGREV = p.DRAWINGREV;
					j.FORMULA_ID = p.FORMULA_ID;
					j.FORMULA_NUMBER = p.FORMULA_NUMBER;
					j.ERP_ISSUE = p.ERP_ISSUE;
					j.ISSUE_ID = p.ISSUE_ID;
					j.ITEMNO = p.ITEMNO;
					j.ITEMNAME = p.ITEMNAME;
					j.ITEMNOTE = p.ITEMNOTE;
					j.JOBTYPE = p.JOBTYPE;
					j.LASTMODIFY = p.LASTMODIFY;
					j.MODIUSER = p.MODIUSER;
					j.UNITORDER = p.UNITORDER;
					j.QORDER = p.QORDER;
					j.REMAINQTY = p.REMAINQTY;
					j.SHIPQTY = p.SHIPQTY;
					j.RECEIVEDBY = p.RECEIVEDBY;
					j.RECEIVEDDATE = p.RECEIVEDDATE;
					j.STD_MATCOST = p.STD_MATCOST;
					j.STD_UNITHOUR = p.STD_UNITHOUR;
					j.TOTAL_OUTSOURCE_COST = p.TOTAL_OUTSOURCE_COST;
					j.TOTAL_HOUR_COST = p.TOTAL_HOUR_COST;
					j.TOTAL_HOURS = p.TOTAL_HOURS;
					j.TOTAL_MAT_COST = p.TOTAL_MAT_COST;
					j.TOTAL_PRODUCTION_COST = p.TOTAL_PRODUCTION_COST;
					j.LABOUR_HR_COST = p.LABOUR_HR_COST;
				}
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update Production Job Information !!!!", ex);
			}

			return _result;
		} // end UpdateProductionHeader

		public int RemoveProductionHeader(string ProductionOrder)
		{
			var _result = 0;
			try
			{
				var productionHeader = (from p in _om.PRODUCTIONJOBS
												where p.ERP_ORDER == ProductionOrder
												select p).Single();
				_om.PRODUCTIONJOBS.Remove(productionHeader);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't remove the record....", ex);
			}

			return _result;

		} // end RemoveProductionHeader

		public DataTable GetProductionHourByOrder(string ProductionOrder)
		{
			var _result = new DataTable();
			var phItem = (from p in _om.PRODUCTIONJOBINFOes
							  orderby p.DATETIME_START
							  where p.ERP_ORDER == ProductionOrder
							  select new
							  {
								  Id = p.PRDINFOID,
								  p.WORKERID,
								  p.WORKERNAME,
								  p.PROCESSID,
								  p.PROCESSNAME,
								  p.TIME_CAT,
								  starttime = p.DATETIME_START.Value,
								  endtime = p.TOTAL_OT_HR == 0.00m ? p.DATETIME_END.Value : p.OT_END.Value,
								  HourRate = p.REGULAR_HR_RATE,
								  NORMAL = p.TOTAL_NORMAL_HR,
								  OT = p.TOTAL_OT_HR,
								  TOTAL = p.TOTAL_HRS,
								  HOURCOST = p.TOTAL_COST,
								  p.INPROCESS_QTY,
								  p.GOOD_QTY,
								  p.BAD_QTY,
								  p.TOTALQTY
							  }).AsNoTracking();

			if (phItem != null)
				_result = phItem.ToDataTable();

			return _result;

		} // end GetProductionHourByOrderAsync

		public DataTable ProductionHourStatByOrder(string productionJob)
		{
			var h = (from j in _om.PRODUCTIONJOBINFOes.AsEnumerable()
						where j.ERP_ORDER == productionJob
						select new
						{
							j.WORKERNAME,
							WorkDay = Convert.ToDateTime(j.DATETIME_START.Value.ToShortDateString()).Day,
							j.TOTAL_NORMAL_HR,
							j.TOTAL_OT_HR,
							j.TOTAL_HRS
						}).ToList();


			var p = (from j in h
						group j by j.WORKERNAME into jstat
						select new
						{
							Name = jstat.Key,
							Days = jstat.Count(),
							NormalTime = jstat.Sum(x => x.TOTAL_NORMAL_HR),
							Overtime = jstat.Sum(x => x.TOTAL_OT_HR),
							TotalTime = jstat.Sum(x => x.TOTAL_HRS),
							AvgHourDay = jstat.Sum(x => x.TOTAL_NORMAL_HR) / (jstat.Count() == 0 ? 1 : jstat.Count()),
							AvgOTDay = jstat.Sum(x => x.TOTAL_OT_HR) / (jstat.Count() == 0 ? 1 : jstat.Count()),
						}).OrderBy(o => o.TotalTime).ToDataTable();
			return p;
		}

		public DataTable GetSummaryActualHourCost(string JobOrder, string connectionString)
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine(" SELECT * FROM dbo.OM_PRODUCTION_SUMMARY_ACTUAL_HOUR_COST ");
			s.AppendLine($" WHERE ERP_ORDER ='{JobOrder}' ");

			return new DataConnect(s.ToString(), connectionString).ToDataTable;
		}

		public PRODUCTIONJOBINFO GetProductionHourItemInfo(int ItemId) => _om.PRODUCTIONJOBINFOes.Single(x => x.PRDINFOID == ItemId);

		public int UpdateProductionHourItem(PRODUCTIONJOBINFO ph)
		{
			var _result = 0;
			try
			{
				if (ph.PRDINFOID == 0)
				{
					_om.PRODUCTIONJOBINFOes.Add(ph);
					_result = _om.SaveChanges();
				}
				else
				{
					var pi = _om.PRODUCTIONJOBINFOes.FirstOrDefault(x => x.PRDINFOID == ph.PRDINFOID);
					pi.WORKCAT = ph.WORKCAT;
					pi.STEP = ph.STEP;
					pi.PROCESSID = ph.PROCESSID;
					pi.AVG75_HR_RATE = ph.AVG75_HR_RATE;
					pi.AVG85_HR_RATE = ph.AVG85_HR_RATE;
					pi.BAD_QTY = ph.BAD_QTY;
					pi.BREAK_HRS = ph.BREAK_HRS;
					pi.COSTCENTER = ph.COSTCENTER;
					pi.ITEMNO = ph.ITEMNO;
					pi.DRAWINGNO = ph.DRAWINGNO;
					pi.TIME_CAT = ph.TIME_CAT;
					pi.DATETIME_END = ph.DATETIME_END;
					pi.DATETIME_START = ph.DATETIME_START;
					pi.BREAK_HRS = ph.BREAK_HRS;
					pi.TOTAL_NORMAL_HR = ph.TOTAL_NORMAL_HR;
					pi.OT_START = ph.OT_START;
					pi.OT_END = ph.OT_END;
					pi.OT_BREAK = ph.OT_BREAK;
					pi.TOTAL_OT_HR = ph.TOTAL_OT_HR;
					pi.ERP_ORDER = ph.ERP_ORDER;
					pi.INPROCESS_QTY = ph.INPROCESS_QTY;
					pi.GOOD_QTY = ph.GOOD_QTY;
					pi.NET75_HR_RATE = ph.NET75_HR_RATE;
					pi.NET85_HR_RATE = ph.NET85_HR_RATE;
					pi.PROCESSNAME = ph.PROCESSNAME;
					pi.PROCESSDETAIL = ph.PROCESSDETAIL;

					pi.MACHINEGROUP = ph.MACHINEGROUP;
					pi.MACHINEID = ph.MACHINEID;
					pi.MACHINENAME = ph.MACHINENAME;

					pi.REGULAR_HR_RATE = ph.REGULAR_HR_RATE;
					pi.TOTAL_COST75 = ph.TOTAL_COST75;
					pi.TOTAL_AVG_COST75 = ph.TOTAL_AVG_COST75;
					pi.TOTAL_AVG_COST85 = ph.TOTAL_AVG_COST85;
					pi.TOTAL_COST = ph.TOTAL_COST;
					pi.TOTAL_COST85 = ph.TOTAL_COST85;
					pi.TOTAL_HRS = ph.TOTAL_HRS;
					pi.TOTALQTY = ph.TOTALQTY;
					pi.WORKERID = ph.WORKERID;
					pi.WORKERNAME = ph.WORKERNAME;
					pi.WORKPERIOD = ph.WORKPERIOD;
					pi.WORKYEAR = ph.WORKYEAR;
					pi.WORKDAY = ph.WORKDAY;
					pi.MODIUSER = ph.MODIUSER;
					pi.MODIDATE = ph.MODIDATE;
					pi.REMARK = ph.REMARK;

					_result = _om.SaveChanges();
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update Production Hour Item information", ex);
			}

			return _result;
		} // end UpdateProductionHourItme

		public DataTable GetProductionTimeItemByWorker(string workerCode, int workYear, int workMonth)
		{
			return new DataConnect($"EXEC dbo.usp_OM_PRODUCTION_WORKTIMEBYWORKER @workercode='{workerCode}',@workyear={workYear},@workmonth={workMonth}", omglobal.SysConnectionString).ToDataTable;
		}

		public DataTable GetProductionTimeItemByOrder(string workOrder)
		{
			return new DataConnect($"EXEC dbo.usp_OM_PRODUCTION_WORKTIME_BY_ORDER @workOrder='{workOrder}'", omglobal.SysConnectionString).ToDataTable;
		}

		public int RemoveTimeRecord(int recordId)
		{
			_om.PRODUCTIONJOBINFOes.Remove(_om.PRODUCTIONJOBINFOes.Find(recordId));
			return _om.SaveChanges();
		}

		public int RemoveProductionHourItems(string ProductionOrder)
		{
			var _result = 0;
			try
			{
				var groupdelete = (from p in _om.PRODUCTIONJOBINFOes
										 where p.ERP_ORDER == ProductionOrder
										 select p).ToList();
				_om.PRODUCTIONJOBINFOes.RemoveRange(groupdelete);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't remove the record....", ex);
			}

			return _result;

		} // end RemoveProductionHourItems

		public int StandardPartItemLock(int ItemId)
		{
			var _result = 0;
			try
			{
				_om.PRODUCTIONSTDITEMS.Where(x => x.ItemId == ItemId).ToList().ForEach(c => c.islock = true);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't lock the selected item", ex);
			}
			return _result;
		} // end StandardPartItemLock

		public int UpdatePartItemInfo(PRODUCTIONSTDITEM Item)
		{
			var _result = 0;
			try
			{
				if (Item.ItemId == 0)
				{
					_om.PRODUCTIONSTDITEMS.Add(Item);
				}
				else
				{
					var p = _om.PRODUCTIONSTDITEMS.Single(x => x.ItemNo == Item.ItemNo);
					p.DrawingDate = Item.DrawingDate;
					p.DrawingNo = Item.DrawingNo;
					p.DrawingRev = Item.DrawingRev;
					p.islock = Item.islock;
					p.ItemCost = Item.ItemCost;
					p.ItemName = Item.ItemName;
					p.MatNo = Item.MatNo;
					p.Material = Item.Material;
					p.MaterialCost = Item.MaterialCost;
					p.ModiDate = Item.ModiDate;
					p.ModiUser = Item.ModiUser;
					p.WorktimeMint = Item.WorktimeMint;
					p.ProducionHourCost = Item.ProducionHourCost;
					p.ProductionCost = Item.ProductionCost;
					p.SheetNo = Item.SheetNo;
					p.STDProductHours = Item.STDProductHours;
					p.Unit = Item.Unit;
					p.UnitWeight = Item.UnitWeight;
				}
				_result = _om.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception("Can't update Standard Part Item Info !!!!!!", ex);
			}
			return _result;
		} // end UpdatePartItemInfo

		public async Task<DataTable> GetWorkHistory(string filter = "") => await Task.Run(() =>
	{
		return new DataConnect($"EXEC dbo.usp_OM_PRODUCTION_WORK_HISTORY @filter='{filter}'", omglobal.SysConnectionString).ToDataTable;
	});

		public DataTable GetProductionItemList(string filter = "") => new DataConnect($" EXEC dbo.usp_OM_PRODUCTION_STD_ITEMS @itemfilter='{filter}'", omglobal.SysConnectionString).ToDataTable;

		public DataTable GetProductionItemProperty(string filter = "") =>
			new DataConnect($" EXEC dbo.usp_OM_PRODUCTION_STD_ITEM @itemfilter='{filter}'", omglobal.SysConnectionString).ToDataTable;

		public PRODUCTIONSTDITEM GetProductionItemInfo(int ItemId) =>
			_om.PRODUCTIONSTDITEMS.Single(x => x.ItemId == ItemId);

		#endregion

		#region Production Process

		#endregion

		#region Production Hours Report

		public async Task<DataTable> GetWorkCostAsync(int year)
		{
			return await Task.Run(() =>
			{
				var p = (from pj in _om.PRODUCTIONJOBINFOes.AsEnumerable()
							join ph in _om.PRODUCTIONJOBS on pj.ERP_ORDER equals ph.ERP_ORDER
							orderby pj.ERP_ORDER, pj.DATETIME_START
							where pj.WORKYEAR == year
							select new
							{
								pj.ERP_ORDER,
								ph.ERP_ORDERINFO,
								pj.WORKERID,
								pj.WORKERNAME,
								pj.PROCESSNAME,
								pj.PROCESSDETAIL,
								DayName = ((int)pj.DATETIME_START.Value.DayOfWeek).ToString() + " " + pj.DATETIME_START.Value.DayOfWeek.ToString(),
								IsHoliday = (int)pj.DATETIME_START.Value.DayOfWeek == 0 ? true : false,
								WorkDate = pj.DATETIME_START.Value.DayOfWeek.ToString().Substring(0, 3) + " - " + pj.DATETIME_START.Value.ToShortDateString(),
								pj.TOTAL_NORMAL_HR,
								pj.TOTAL_OT_HR
							}).ToList();

				DataTable hc = (from pd in p
									 join e in _om.EMPLOYEEs on pd.WORKERID equals e.EMPCODE
									 select new
									 {
										 pd.ERP_ORDER,
										 pd.ERP_ORDERINFO,
										 pd.WORKERNAME,
										 pd.PROCESSNAME,
										 pd.PROCESSDETAIL,
										 pd.WorkDate,
										 NormalTimeCost = pd.IsHoliday ? pd.TOTAL_NORMAL_HR * e.GetHolidayHourRate() : pd.TOTAL_NORMAL_HR * e.GetHourRate(),
										 OvertimeCost = pd.IsHoliday ? pd.TOTAL_OT_HR * e.GetHolidayOTHourRate() : pd.TOTAL_OT_HR * e.GetOTHourRate()
									 }).ToDataTable();


				return hc ?? hc;
			});
		}

		#endregion

		#region PRODUCTION OPTIONAL

		public DataTable GetMaterialForProduction()
		{
			return (from mat in _om.PRODUCTIONSTDITEMS
					  where mat.Material != null
					  select new
					  {
						  mat.Material
					  }).Distinct().ToDataTable();
		}

		//public DataTable GetProcessMachineList() => 
		//	(_om.PRDPROCESSes.Where(x => x.MACHINE != null).Select(x => new { x.MACHINE }).Distinct().ToDataTable());

		public DataTable GetProcessMachineList()
		{
			//_om.PRDPROCESSes.Where(x => x.MACHINE != null).Select(x => new { x.MACHINE }).Distinct().ToDataTable());

			return _om.PRODUCTION_MACHINEGROUP
						.Select(x => new
						{
							x.MC_GROUPID,
							x.MC_GROUPNAME
						})
						.OrderBy(o => o.MC_GROUPNAME)
						.ToDataTable();
		}
		#endregion

		#region STANDARD PROCESS FOR EACH PART-NO.

		public string GetProcessName(int processId) =>
			(_om.PRDPROCESSes.Where(x => x.PRDPROCESSID == processId).FirstOrDefault().PROCESSNAME);

		public int GetMaxStep(string itemNo)
		{
			int _result = 1;
			try
			{
				var _step = _om.PDITEMPROCESSes.Where(x => x.REF_STDITEMNO == itemNo).ToList();

				if (_step == null || _step.Count == 0)
				{
					_result = 1;
				}
				else
				{
					_result = (_om.PDITEMPROCESSes.Where(x => x.REF_STDITEMNO == itemNo).Max(x => x.STEP) + 1);
				}
			}
			catch
			{
				_result = 1;
			}

			return _result;
		}

		public PDITEMPROCESS GetItemProcessInfo(int id) => (_om.PDITEMPROCESSes.Find(id));

		public DataTable GetStdProcessList(string itemNo)
		{
			return (from std in _om.PDITEMPROCESSes
					  join p in _om.PRDPROCESSes on std.REF_PROCESS equals p.PRDPROCESSID
					  orderby std.STEP
					  where std.REF_STDITEMNO == itemNo
					  select new
					  {
						  std.ID,
						  std.STEP,
						  std.REF_STDITEM,
						  std.REF_STDITEMNO,
						  std.REF_PROCESS,
						  p.PROCESSNAME,
						  p.MACHINE_GROUP,
						  p.MACHINE,
						  std.WORKMINT,
						  std.STD_HR,
						  std.STEP_COST
					  }).ToDataTable();
		}

		public int UpdateStdProcess(PDITEMPROCESS stdProcess)
		{
			var _result = 0;
			try
			{
				if (stdProcess.ID == 0)
				{
					_om.PDITEMPROCESSes.Add(stdProcess);
					_result = _om.SaveChanges();
				}
				else
				{
					var p = _om.PDITEMPROCESSes.Single(x => x.ID == stdProcess.ID);
					p.REF_PROCESS = stdProcess.REF_PROCESS;
					p.MATID = stdProcess.MATID;
					p.MATNAME = stdProcess.MATNAME;
					p.REF_STDITEM = stdProcess.REF_STDITEM;
					p.REF_STDITEMNO = stdProcess.REF_STDITEMNO;
					p.WORKMINT = stdProcess.WORKMINT;
					p.STD_HR = stdProcess.STD_HR;
					p.HOUR_FACTOR = stdProcess.HOUR_FACTOR;
					p.STEP = stdProcess.STEP;
					p.STEP_COST = stdProcess.STEP_COST;
					p.ModifyBy = stdProcess.ModifyBy;
					p.ModifyDate = stdProcess.ModifyDate;
					_result = _om.SaveChanges();
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update Standard process !!!!!!", ex);
			}

			return _result;
		}

		public int DeleteStdProcess(int id)
		{
			var _result = 0;
			try
			{
				var pr = _om.PDITEMPROCESSes.Single(x => x.ID == id);
				var p = _om.PDITEMPROCESSes.Remove(pr);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't delete Standard process !!!!!!", ex);
			}
			return _result;
		}

		#endregion

		#region Producion Used Material

		public DataTable GetIssueByProductionOrder(string orderNo) =>
			new DataConnect($"EXEC dbo.usp_OM_PRODUCTION_ISSUES @orderno ='{orderNo}'", omglobal.SysConnectionString).ToDataTable;

		public DataTable GetSend2WHList(string orderNo) =>
			new DataConnect($"EXEC dbo.usp_OM_PRODUCTION_TO_WH @docno='{orderNo}'", omglobal.SysConnectionString).ToDataTable;

		public PRODUCTION_WH_RECEIVE GetReceiveItem(string receiveNo) =>
			_om.PRODUCTION_WH_RECEIVE.Where(x => x.RECEIVE_NO == receiveNo).FirstOrDefault();

		public int UpdateReceiveItem(PRODUCTION_WH_RECEIVE item)
		{
			if (item.RECEIVEID == 0)
			{
				_om.PRODUCTION_WH_RECEIVE.Add(item);
			}
			else
			{
				PRODUCTION_WH_RECEIVE _item = GetReceiveItem(item.RECEIVE_NO);
				_item.RECEIVE_AVG_UCOST = item.RECEIVE_AVG_UCOST;
				_item.RECEIVE_BY = item.RECEIVE_BY;
				_item.RECEIVE_COST = item.RECEIVE_COST;
				_item.RECEIVE_DATE = item.RECEIVE_DATE;
				_item.RECEIVE_QTY = item.RECEIVE_QTY;
				_item.RECEIVE_UNIT = item.RECEIVE_UNIT;
				_item.REF_ISSUE_ID = item.REF_ISSUE_ID;
				_item.REF_TRANSFER_DOC = item.REF_TRANSFER_DOC;
			}

			return _om.SaveChanges();
		}

		public int DeleteReceiveItem(string receiveNo)
		{
			_om.PRODUCTION_WH_RECEIVE.Remove(GetReceiveItem(receiveNo));
			return _om.SaveChanges();
		}

		public DataTable GetReceiveItemCost(string itemno, string docNo)
		{
			return new DataConnect($"EXEC dbo.usp_OM_WH_RECEIVE_ITEM @itemno='{itemno}',@docfilter='{docNo}'", omglobal.SysConnectionString).ToDataTable;
		}

		public IssueRequestHeader FindIssueHeader(string productionJobNo)
		{
			IssueRequestHeader _result;
			try
			{
				var _issue = _om.OM_ERP_PRODUCTION_ISSUE_REQ
						.FirstOrDefault(x => x.REQNO == productionJobNo);

				_result = new IssueRequestHeader();
				_result.REQNO = _issue.REQNO;
				_result.REQID = _issue.REQID.Value;
				_result.ISSUEID = _issue.ISSUEID;
				_result.ISSUENO = _issue.ISSUENO;
			}
			catch
			{
				_result = null;
			}

			return _result;
		}

		public DataTable GetIssueItems(string issueNo)
		{
			DataTable dt = new DataTable();

			try
			{
				dt = _om.OM_ERP_WH_ISSUE_ITEMS.AsEnumerable()
					.Where(x => x.DOCUMENTNO == issueNo && x.ICCODE != "ST03")
					.Select((r, i) => new IssueItem
					{
						Index = ++i,
						DepartmentCode = r.DEPARTMENTCODE,
						DepartmentId = r.DEPARTMENTID,
						DocumentDate = r.DOCUMENTDATE,
						DocumentKey = r.DOCUMENTKEY,
						DocumentNo = r.DOCUMENTNO,
						ICCode = r.ICCODE,
						ICKey = r.ICKEY,
						ICName = r.ICNAME,
						IssueLineId = r.ISSUELINEID,
						OrderNumber = r.ORDERNUMBER,
						ProjectNo = r.PROJECTNO,
						ShipGrandTotal = r.SHIPGRANDTOTAL,
						ShipItemNo = r.SHIPITEMNO,
						ShipItemName = r.SHIPITEMNAME,
						ShipUnit = r.SHIPUNIT,
						ShipQty = r.SHIPQTY,
						ShipUnitPrice = r.SHIPUNITPRICE,
						ShipTotalVAT = r.SHIPTOTALVAT,
						ShipTotalValue = r.SHIPTOTALVALUE
					})
					.OrderBy(o => o.Index).ToDataTable();
			}
			catch (Exception ex)
			{
				dt = null;
				throw new Exception($"Error occured - {ex.Message}");
			}
			return dt;
		}

		public async Task<DataTable> GetIssueItemsAsync(string issueNo, string itemno)
		{
			return await Task.Run(() =>
			{
				return new DataConnect($"EXEC dbo.usp_OM_ERP_WH_ISSUE_ITEMS @issueno='{issueNo}',@itemno='{itemno}'", omglobal.SysConnectionString).ToDataTable;
			});
		}

		public decimal GetAvgActualHourCostByWorker(DateTime workDate, string workerId)
		{
			var _record = _om.EMPSALs.Where(x => x.YEARSAL == workDate.Year && x.EMPCODE == workerId).ToList();
			if (_record == null || _record.Count == 0) return 0m;
			return _record.Select(x => new { x.ACTUALAVGHOURCOST }).Single().ACTUALAVGHOURCOST;
		}

		#endregion


		#region PRODUCTION PLAN

		public DataTable GetMachineColumns() => _om.PRDPROCESSes.ToDataTable();

		public DataTable GetActualMachine(string itemno, int status = 0, int workyear = 0)
		{
			if ((status != (int)ProductionJobStatus.None) && (workyear != 0))
			{
				return (from pi in _om.PRODUCTIONJOBINFOes
						  join p in _om.PRODUCTIONJOBS on pi.ERP_ORDER equals p.ERP_ORDER
						  join c in _om.PRDPROCESSes on pi.PROCESSID equals c.PRDPROCESSID
						  where p.ITEMNO == itemno
								  && p.STATUS == status
									&& (status == 2 ? p.COMPLETEDATE.Value.Year == workyear : p.JOBYEAR == workyear)
						  orderby pi.STEP
						  select new
						  {
							  pi.STEP,
							  c.PROCESSNAME,
							  c.MACHINE
						  }).Distinct().ToDataTable();
			}
			else
			{
				return (from pi in _om.PRODUCTIONJOBINFOes
						  join p in _om.PRODUCTIONJOBS on pi.ERP_ORDER equals p.ERP_ORDER
						  join c in _om.PRDPROCESSes on pi.PROCESSID equals c.PRDPROCESSID
						  where p.ITEMNO == itemno
						  orderby pi.STEP
						  select new
						  {
							  pi.STEP,
							  c.PROCESSNAME,
							  c.MACHINE
						  }).Distinct().ToDataTable();
			}
		}

		public DataTable GetWorkItem(int status, int workyear = 0)
		{
			if (workyear > 0)
			{
				return (from pj in _om.PRODUCTIONJOBS
						  join std in _om.PRODUCTIONSTDITEMS on pj.ITEMNO equals std.ItemNo
						  where pj.STATUS == status
								 && (status == 2 ? pj.COMPLETEDATE.Value.Year == workyear : pj.JOBYEAR == workyear)
						  orderby pj.ITEMNO
						  select new
						  {
							  pj.ITEMNO,
							  ItemName = "[" + pj.ITEMNO.Trim() + "] ## " + std.ItemName.Trim()
						  }
					).Distinct().ToDataTable();
			}
			else
			{
				return (from pj in _om.PRODUCTIONJOBS
						  join std in _om.PRODUCTIONSTDITEMS on pj.ITEMNO equals std.ItemNo
						  //where pj.STATUS == status
						  orderby pj.ITEMNO
						  select new
						  {
							  pj.ITEMNO,
							  ItemName = pj.ITEMNO + " :: " + std.ItemName
						  }
					).Distinct().ToDataTable();
			}
		}

		public DataTable GetProductionPlan(int status, int jobYear, string itemno)
		{
			return new DataConnect($"EXEC dbo.usp_OM_PRODUCTION_MACHINE_PLAN @jobstatus={status},@jobyear={jobYear},@itemnumber='{itemno}'", omglobal.SysConnectionString).ToDataTable;
		}

		#endregion


		#region Miss Report

		public DataTable GetProductionMissReport()
		{
			return new DataConnect($" EXEC dbo.usp_OM_PRODUCTION_MISS_REPORT", omglobal.SysConnectionString).ToDataTable;
		}

		public DataTable GetProductionMissReportDetails(string empId)
		{
			return new DataConnect($" EXEC dbo.usp_OM_PRODUCTION_MISS_REPORT_DETAILS @empCode='{empId}'", omglobal.SysConnectionString).ToDataTable;
		}
		#endregion

	}

	public class IssueMap
	{
		public int Index { get; set; }
		public int IssueId { get; set; }
		public string IssueNo { get; set; }
		public string ReqNo { get; set; }
		public int ReqId { get; set; }
	}

	public class ExitstProductionJob
	{
		public string ProductionJobNo { get; set; }
	}

	public class ProductionYear
	{
		public int JobYear { get; set; }
	}

	public class TimeRecordInfo
	{
		public DateTime WorkDate { get; set; }
		public int RecordId { get; set; }
		public string ProductionJob { get; set; }
		public string ItemNo { get; set; }
		public string ItemName { get; set; }
		public string DrawingNo { get; set; }
		public int ProcessId { get; set; }
		public string ProcessName { get; set; }
		public string WorkerId { get; set; }
		public string WorkerName { get; set; }
		public DateTime FromTime { get; set; }
		public DateTime ToTime { get; set; }
		public string OTFrom { get; set; }
		public string OTEnd { get; set; }
		public decimal TotalTime { get; set; }
		public decimal InWorkProcessQty { get; set; }
		public decimal GoodQty { get; set; }
		public decimal BadQty { get; set; }
		public decimal TotalQty { get; set; }

	}




}

