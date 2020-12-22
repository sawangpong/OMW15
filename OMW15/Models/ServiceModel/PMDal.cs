using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Transactions;

namespace OMW15.Models.ServiceModel
{
	public class PMDal
	{
		private readonly OLDMOONEF1 _om;

		public PMDal()
		{
			_om = new OLDMOONEF1();
		}

		#region class methods

		public PMMC getContractMC(int machineId)
		{
			return _om.PMMCs.Find(machineId);
		}

		public DataTable getPMList()
		{
			var pmlist = (from pmc in _om.PMMCs
						  //join pc in _om.PMCONTRACTs on pmc..CONTRACT_KEY equals pc.PM_CONTRACT_KEY
						  join w in _om.WARRANTIES on pmc.PM_TYPE_KEY equals w.WARRANTYID
						  orderby pmc.PMCONTRACT.PM_CONTRACT_KEY
						  select new
						  {
							  pmid = pmc.PMCONTRACT.ID,
							  mcid = pmc.PM_MC,
							  status = pmc.PMCONTRACT.PM_STATUS,
							  contractno = pmc.PMCONTRACT.PM_CONTRACT_KEY,
							  code = pmc.PMCONTRACT.PM_CUSTCODE,
							  customer = pmc.PMCONTRACT.PM_CUSTOMER,
							  pm_start = pmc.PMCONTRACT.PM_START,
							  pm_end = pmc.PMCONTRACT.PM_END,
							  model = pmc.PM_MC_MODEL,
							  serial = pmc.PM_MC_SN,
							  typeid = pmc.PM_TYPE_KEY,
							  pm_type = w.WARRANTYNAME,
							  pm_factor = w.WARRANTYMONTHFACTOR,
							  pm_max = w.RVMAX
						  }).AsParallel();

			if (pmlist != null)
			{
				var contracts = pmlist.AsEnumerable().Select((x, Index) => new
				{
					Row = Index + 1,
					x.pmid,
					x.mcid,
					status = x.status == 1 ? "Active" : "Completed",
					x.contractno,
					x.code,
					x.customer,
					x.pm_start,
					x.pm_end,
					x.model,
					x.serial,
					x.typeid,
					x.pm_type,
					x.pm_max,
					x.pm_factor
				}).AsParallel();
				return contracts.ToDataTable();
			}

			return null;

		} // end getPMList

		public PMCONTRACT getPMMaster(string contractNo)
		{
			return _om.PMCONTRACTs.Single(x => x.PM_CONTRACT_KEY == contractNo);

		} // end getPMMaster

		public string getPMType(int pmTypeId, out int maxPM, out int pmMonthFactor)
		{
			pmMonthFactor = 0;
			maxPM = 0;
			var w = (from wr in _om.WARRANTIES
					 where wr.WARRANTYID == pmTypeId
					 select new
					 {
						 wr.WARRANTYID,
						 wr.WARRANTYMONTHFACTOR,
						 wr.WARRANTYNAME,
						 wr.RVMAX
					 }).SingleOrDefault();

			if (w != null)
			{
				pmMonthFactor = w.WARRANTYMONTHFACTOR;
				maxPM = w.RVMAX;
				return w.WARRANTYNAME;
			}
			return null;

		} // end getPMType

		public DataTable getPMType()
		{
			return _om.WARRANTIES.Select(x => new
			{
				x.WARRANTYID,
				x.WARRANTYNAME
			}).OrderBy(o => o.WARRANTYNAME).AsParallel().ToDataTable();

		} // end getPMType


		public DataTable getPMMachineList(string contractNo)
		{
			var mcl = (from mc in _om.PMMCs
					   join w in _om.WARRANTIES on mc.PM_TYPE_KEY equals w.WARRANTYID
					   where mc.PMCONTRACT.PM_CONTRACT_KEY == contractNo
					   orderby mc.PM_MC
					   select new
					   {
						   mc.PM_MC,
						   mc.PM_MC_MODEL,
						   mc.PM_MC_SN,
						   mc.PM_TYPE_KEY,
						   w.WARRANTYNAME,
						   mc.PM_MAX
					   }).AsParallel();

			if (mcl != null)
			{
				return mcl.ToDataTable();
			}

			return null;
		}

		public int updatePMContractMachine(PMMC mc)
		{
			int _result = 0;
			using (var scope = new System.Transactions.TransactionScope())
			{
				try
				{
					if (mc.PM_MC == 0)
					{
						_om.PMMCs.Add(mc);
					}
					else
					{
						PMMC m = _om.PMMCs.Find(mc.PM_MC);
						m.PM_MAX = mc.PM_MAX;
						m.PM_MC_MODEL = mc.PM_MC_MODEL;
						m.PM_MC_SN = mc.PM_MC_SN;
						m.PM_TYPE_KEY = mc.PM_TYPE_KEY;
						m.MODIUSER = mc.MODIUSER;
						m.MODIDATE = mc.MODIDATE;
					}
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					Controllers.ToolController.Alert.DisplayAlert("Error updating PM Contract Machine !!!!!", ex.ToString());
				}
			}

			return _result;
		}

		/// <summary>
		/// Add or Edit PM-Contract into database as of given informatiom
		/// </summary>
		/// <param name="pmContract"></param>
		/// <returns></returns>
		public int updatePMContract(PMCONTRACT pmContract)
		{
			int _result = 0;
			try
			{
				if (pmContract.ID == 0) // add PMContract
				{
					_om.PMCONTRACTs.Add(pmContract);
				}
				else // update
				{
					PMCONTRACT p = _om.PMCONTRACTs.Single(x => x.ID == pmContract.ID);
					p.MODIDATE = pmContract.MODIDATE;
					p.MODIUSER = pmContract.MODIUSER;
					p.PM_CONTRACT_DATE = pmContract.PM_CONTRACT_DATE;
					p.PM_CUSTCODE = pmContract.PM_CUSTCODE;
					p.PM_CUSTOMER = pmContract.PM_CUSTOMER;
					p.PM_END = pmContract.PM_END;
					p.PM_START = pmContract.PM_START;
					p.PM_STATUS = pmContract.PM_STATUS;
				}
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				Controllers.ToolController.Alert.DisplayAlert("Error updating PM Contract !!!!!", ex.ToString());
			}

			return _result;
		}

		/// <summary>
		/// Insert all PM-Machines
		/// </summary>
		/// <param name="pmList"></param>
		/// <returns></returns>
		public int insertPMMachine(List<PMMC> pmList)
		{
			int _result = 0;
			try
			{
				_om.PMMCs.AddRange(pmList);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				Controllers.ToolController.Alert.DisplayAlert("Can't insert machine for PM-Contract !!!!!", ex.ToString());
			}

			return _result;
		}

		public PMSCHEDULE getScheduleInfo(int scheduleId)
		{
			return _om.PMSCHEDULEs.Find(scheduleId);
		}

		public int updatePMSchedule(PMSCHEDULE schedule)
		{
			int _result = 0;
			using (TransactionScope scope = new TransactionScope())
			{
				try
				{
					var _sch = _om.PMSCHEDULEs.Find(schedule.sch_id);
					_sch.LASTMODIFY = DateTime.Now;
					_sch.PMDate = schedule.PMDate;
					_sch.PMJobNo = schedule.PMJobNo;
					_sch.ActualPMDate = schedule.ActualPMDate;
					_sch.isdelete = schedule.isdelete;
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					Controllers.ToolController.Alert.DisplayAlert("Error updating PM-Schedule Machine !!!!!", ex.ToString());
				}
			}

			return _result;
		}

		public int deletePMMachine(int pmMachineItemId)
		{
			int _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.PMMCs.Remove(_om.PMMCs.Find(pmMachineItemId));
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					Controllers.ToolController.Alert.DisplayAlert("Can't remove selected record !!!!!", ex.ToString());
				}
			}

			return _result;
		}

		public int getLatestPMContract(string pmYear)
		{
			int _result = 0;

			int _row = _om.PMCONTRACTs.Where(x => x.PMY == pmYear).ToList().Count();

			if (_row > 0)
			{
				_result = (_om.PMCONTRACTs.Where(x => x.PMY == pmYear).Max(x => x.RUNNUM));
			}

			return _result;
		}


		#region PM-SCHEDULE

		//public DataTable getMachineSchedule(int machineId)
		//{
		//	var s = _om.PMSCHEDULEs.Where(x => x.MC_Key == machineId).Select(x => new
		//	{
		//		x.MC_Key,
		//		x.sch_id,
		//		x.PMDate,
		//		x.PMJobNo
		//	}).OrderBy(o => o.sch_id).AsParallel();

		//	if (s != null)
		//	{
		//		return s.ToDataTable();
		//	}

		//	return null;
		//}

		public DataTable getAllMachineSchedule(int machineId)
		{
			var s = _om.PMSCHEDULEs.Where(x => x.PMMC.PM_MC == machineId).Select(x => new
			{
				x.iscomplete,
				x.PMMC.PM_MC,
				x.sch_id,
				x.PM_series,
				x.PMDate,
				x.PMJobNo,
				x.ActualPMDate
			}).OrderBy(o => o.PM_series).AsParallel();

			if (s != null)
			{
				return s.ToDataTable();
			}

			return null;
		}

		public int addPMScheduleList(PMMC mc)
		{
			int _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					PMMC m = _om.PMMCs.Find(mc.PM_MC);
					m.MODIDATE = DateTime.Now;
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					Controllers.ToolController.Alert.DisplayAlert("Can't insert schedule !!!!!", ex.ToString());
				}
			}

			return _result;
		}

		public int removePMMachineShedule(int scheduleId)
		{
			int _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.PMSCHEDULEs.Remove(_om.PMSCHEDULEs.Find(scheduleId));
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					Controllers.ToolController.Alert.DisplayAlert("ไม่สามารถลบข้อมูลได้ !!!!!", ex.ToString());
				}
			}
			return _result;
		}

		public int updateServiceOrderWithPMSchedule(int orderId, int PMContractId, int scheduleId)
		{
			int _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					ORDERMAINTENANCE _ord = _om.ORDERMAINTENANCEs.Find(orderId);
					_ord.isPM = true;
					_ord.pmmasterline = PMContractId;
					_ord.pmschline = scheduleId;
					_ord.modiuser = omglobal.UserInfo;
					_ord.modidt = DateTime.Now;
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					Controllers.ToolController.Alert.DisplayAlert("ไม่สามารถปรับปรุงข้อมูลได้ !!!!!", ex.ToString());
				}
			}
			return _result;
		}

		public int updateScheduleAfterTakeServiceJob(int scheduleId, string jobNo, DateTime jobDate)
		{
			int _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					PMSCHEDULE _sch = _om.PMSCHEDULEs.Find(scheduleId);
					_sch.iscomplete = true;
					_sch.PMJobNo = jobNo;
					_sch.ActualPMDate = jobDate;
					_sch.LASTMODIFY = DateTime.Now;
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					Controllers.ToolController.Alert.DisplayAlert("ไม่สามารถปรับปรุงข้อมูลได้ !!!!!", ex.ToString());
				}
			}
			return _result;
		}

		public bool findMachineWasPM(int pmContractId)
		{
			return _om.ORDERMAINTENANCEs.Any(x => x.pmmasterline == pmContractId);
		}

		public bool findScheduleWasPM(int scheduleId)
		{
			return _om.ORDERMAINTENANCEs.Any(x => x.pmschline == scheduleId);
		}

		public DataTable getJobListForPMMatching(string customerCode, string jobCode, string machineModel, string serialNo)
		{
			var jobs = _om.ORDERMAINTENANCEs
				.Where(c => c.isPM == true
				&& c.acccustcode == customerCode
				&& c.orderCode == jobCode
				&& c.type == machineModel
				&& c.s_no == serialNo).Select(s => new
				{
					s.orderid,
					s.status,
					statusname = (s.status == (int)Shared.OMShareServiceEnums.OrderStatusEnum.ACTIVE ? Shared.OMShareServiceEnums.OrderStatusEnum.ACTIVE.ToString() : 
					Shared.OMShareServiceEnums.OrderStatusEnum.CLOSED.ToString()),
					Jobno = s.orderCode + "-" + s.s_order,
					s.orderdate,
					s.duedate,
					s.finishdate,
					s.type,
					s.s_no
				}).OrderBy(o => o.Jobno).AsParallel();

			if (jobs != null)
			{
				return jobs.ToDataTable();
			}

			return null;
		}



		#endregion

		#region Warranty




		#endregion



		#endregion
	}
}
