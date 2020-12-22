using OMW15.Shared;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OMW15.Models.ServiceModel
{
	public class ServiceJobDAL
	{
		private readonly OLDMOONEF1 _om;
		private readonly ERP _erp;

		#region constructor

		public ServiceJobDAL()
		{
			_om = new OLDMOONEF1();
			_erp = new ERP();
		}

		#endregion

		public string GetOrderType(string OrderTypeCode)
		{
			return _om.ORDERTYPEs.SingleOrDefault(x => x.ordertypecode == OrderTypeCode).ordertypename;

		} // end GetOrderType

		public DataTable GetServiceYearList(OMShareServiceEnums.OrderStatusEnum status)
		{

			return _om.ORDERMAINTENANCEs.Where(x => x.isdelete == false && x.status.Value == (int)status).Select(x => new
			{
				Y = x.fiscyear
			}).Distinct().OrderByDescending(o => o.Y).AsParallel().ToDataTable();

		} // end GetServiceYearList

		public DataTable GetOrderCodeList()
		{
			return _om.ORDERTYPEs.Select(x => new
			{
				Code = x.ordertypecode,
				CodeName = x.ordertypecode + "-" + x.ordertypename
			}).OrderBy(o => o.CodeName).AsParallel().ToDataTable();
		} // end GetOrderCodeList

		public DataTable GetJobCodeList(int YearService)
		{
			var _ordTypes = (from ordCode in _om.ORDERTYPEs
							 join jobCode in _om.ORDERMAINTENANCEs on ordCode.ordertypecode equals jobCode.orderCode
							 where jobCode.fiscyear == YearService
							 select new
							 {
								 Code = jobCode.orderCode,
								 CodeName = ordCode.ordertypename,
								 Value = jobCode.orderCode + " - " + ordCode.ordertypename
							 }).Distinct().OrderBy(x => x.Code).AsParallel();
			return _ordTypes.ToDataTable();

		} // end GetJobCodeList

		public DataTable GetJobCodeList(int YearService, OMShareServiceEnums.OrderStatusEnum jobStatus)
		{
			var _ordTypes = (from ordCode in _om.ORDERTYPEs
							 join jobCode in _om.ORDERMAINTENANCEs on ordCode.ordertypecode equals jobCode.orderCode
							 where jobCode.fiscyear == YearService
							 && jobCode.status == (int)jobStatus
							 select new
							 {
								 Code = jobCode.orderCode,
								 CodeName = ordCode.ordertypename,
								 Value = jobCode.orderCode + " - " + ordCode.ordertypename
							 }).Distinct().OrderBy(x => x.Code).AsParallel();
			return _ordTypes.ToDataTable();

		} // end GetJobCodeList

		public DataTable GetServiceJobList(int SelectedYear, string JobCode, OMShareServiceEnums.OrderStatusEnum Status)
		{
			var _result = new DataTable();
			var _job = (from j in _om.ORDERMAINTENANCEs.Where(job => job.fiscyear == SelectedYear && job.isdelete == false).AsEnumerable()
						join p in _om.ORDERPIORITies on j.actionpiority equals p.piorityid
						orderby j.s_order
						select new
						{
							j.orderid,
							j.orderCode,
							orderno = j.s_order,
							year = j.fiscyear,
							JobStatus = j.status.Value,
							statusname =
							j.status.Value == (int)OMShareServiceEnums.OrderStatusEnum.ACTIVE
								? OMShareServiceEnums.OrderStatusEnum.ACTIVE.ToString()
								: OMShareServiceEnums.OrderStatusEnum.CLOSED.ToString(),
							j.actionpiority,
							piority = p.piorityname,
							jobno = j.orderCode + "-" + j.s_order,
							Jobdate = j.orderdate.Value,
							due = j.duedate.Num2Date(),
							finish = j.finishdate.HasValue ? j.finishdate.Value : DateTime.Today,
							customercode = j.acccustcode,
							customer = j.cus_na,
							model = j.type,
							serial = j.s_no,
							j.errorcode,
							j.error,
							j.servicecost,
							j.sparepartcost,
							j.othercost
						}).AsParallel();

			if (_job != null)
				if (Status == OMShareServiceEnums.OrderStatusEnum.ALL)
					_result = _job.ToDataTable();
				else
					_result = _job.Where(x => x.JobStatus == (int)Status && x.orderCode == JobCode).ToDataTable();

			return _result;

		} // end GetServiceJobList

		public string GetJobFixed(int JobId)
		{
			var _result = string.Empty;

			var _fixs = new StringBuilder();
			var _fix = (from f in _om.ORDERFIXEDs
						where f.ORDERMAINTENANCE.orderid == JobId
						select new
						{
							f.datefixed,
							f.fixeddetail,
							f.engineer1,
							f.engineer2,
							f.engineer3,
							f.engineer4
						}).AsParallel().ToList();

			if (_fix != null)
				if (_fix.Count > 0)
				{
					_fixs = new StringBuilder();
					foreach (var ff in _fix)
					{
						_fixs.AppendFormat("วันที่ซ่อม {0}", ff.datefixed.ToShortDateString());
						_fixs.AppendLine();
						_fixs.Append("รายระเอียดการซ่อม");
						_fixs.AppendLine();
						_fixs.AppendFormat("{0}", ff.fixeddetail);
						_fixs.AppendLine();
						_fixs.AppendFormat("ช่าง :{0}", ff.engineer1);
						if (!string.IsNullOrEmpty(ff.engineer2))
						{
							_fixs.AppendLine();
							_fixs.AppendFormat("ช่าง :{0}", ff.engineer2);
						}
						if (!string.IsNullOrEmpty(ff.engineer3))
						{
							_fixs.AppendLine();
							_fixs.AppendFormat("ช่าง :{0}", ff.engineer3);
						}

						if (!string.IsNullOrEmpty(ff.engineer4))
						{
							_fixs.AppendLine();
							_fixs.AppendFormat("ช่าง :{0}", ff.engineer4);
						}
						_fixs.AppendLine();
						_fixs.Append("+++++++++++++++++");
						_fixs.AppendLine();
					}
					_result = _fixs.ToString();
				}
				else
				{
					_result = string.Empty;
				}
			else
				_result = string.Empty;

			return _result;
		} // end GetJobFixed

		public DataTable GetOrderList(string CustomerCode, string MachineModel, string SerialNo)
		{
			return (_om.ORDERMAINTENANCEs
				.AsEnumerable()
				.Where(x => x.isdelete == false
				&& x.acccustcode == CustomerCode
				&& x.type == MachineModel
				&& x.s_no == SerialNo)
				.Select(s => new
				{
					id = s.orderid,
					Code = s.orderCode,
					Status = s.status.Value == 1 ? "Active" : "Closed",
					OrderNo = s.orderCode + "-" + s.s_order,
					Date = s.orderdate.Value.ToShortDateString(),
					Model = s.type,
					SN = s.s_no,
					Erro = s.error
				}).OrderBy(o => o.OrderNo).ToDataTable());

		} // end GetOrderListByMachine

		public DataTable GetErrorList()
		{
			return _om.ERRORCATEGORies.Select(x => new
			{
				x.errorcatid,
				x.errorcode,
				x.errorcatname
			}).OrderBy(o => o.errorcode).AsParallel().ToDataTable();

		} // end GetErrorList

		public ERRORCATEGORY GetErrorItem(int ErrorCatId)
		{
			return _om.ERRORCATEGORies.Single(x => x.errorcatid == ErrorCatId);
		} // end GetErrorItem

		public int AddEditErrorCategory(ERRORCATEGORY Err, ActionMode Mode)
		{
			var _result = 0;
			try
			{
				switch (Mode)
				{
					case ActionMode.Add:
						_om.ERRORCATEGORies.Add(Err);
						_result = _om.SaveChanges();
						break;

					case ActionMode.Edit:
						var er = (from error in _om.ERRORCATEGORies
								  select error).Where(x => x.errorcatid == Err.errorcatid).Single();
						er.errorcatid = Err.errorcatid;
						er.errorcatname = Err.errorcatname;
						er.errorcode = Err.errorcode;
						_result = _om.SaveChanges();
						break;
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				_result = 0;
				throw new Exception("Can't update record!!!", ex);
			}

			return _result;
		} // end AddEditErrorCategory


		public DataTable GetSeviceEngineerList(int EngineerStatus)
		{
			var _result = new DataTable();
			var engs = (from eng in _om.ENGINEERs
						orderby eng.curr
						select new
						{
							eng.engiseq,
							eng.id,
							engineer = eng.name + " " + eng.lastname,
							statusid = eng.Status,
							status = eng.curr
						}).AsParallel();

			if (engs.Count() > 0)
				switch (EngineerStatus)
				{
					case 0:
					case 1:
						_result = engs.Where(x => x.statusid == EngineerStatus).ToDataTable();
						break;

					default:
						_result = engs.ToDataTable();
						break;
				}

			return _result;

		} // end GetSeviceEngineerList

		public ENGINEER GetEngineer(int EngineerSEQ)
		{
			return _om.ENGINEERs.Single(x => x.engiseq == EngineerSEQ);
		} // end GetEngineer

		public int UpdateEngineerInfo(ActionMode Mode, ENGINEER source)
		{
			var _result = 0;
			try
			{
				switch (Mode)
				{
					case ActionMode.Add:
						_om.ENGINEERs.Add(source);
						break;
					case ActionMode.Edit:
						var _eng = _om.ENGINEERs.Single(x => x.engiseq == source.engiseq);

						_eng.curr = source.curr;
						_eng.empcode = source.empcode;
						_eng.Status = source.Status;
						_eng.name = source.name;
						_eng.lastname = source.lastname;
						_eng.resigndate = source.resigndate;

						break;
				}

				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				_result = 0;
				throw new Exception("Can't update Engineer record....", ex);
			}

			return _result;
		} // end UpdateEngineerInfo

		public int DeleteJobOrder(int orderId)
		{
			var _result = 0;
			try
			{
				if (updateTransferSparePartItemInErp(orderId) < 0) return -1;

				// 1. delete order fixed item
				_om.ORDERFIXEDs.RemoveRange(_om.ORDERFIXEDs.Where(x => x.ORDERMAINTENANCE.orderid == orderId).ToList());

				// 2. delete delete order spare part
				_om.ORDERSPAREPARTS.RemoveRange(_om.ORDERSPAREPARTS.Where(x => x.ORDERMAINTENANCE.orderid == orderId).ToList());

				// 3. delete main job order
				_om.ORDERMAINTENANCEs.Remove(_om.ORDERMAINTENANCEs.Single(x => x.orderid == orderId));
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("ไม่สามารถลบรายการที่เลือกได้", ex);
			}

			return _result;

		} // end DeleteOrderRepairItem

		public int updateTransferSparePartItemInErp(int orderId)
		{
			int result = 0;
			try
			{
				// 4. reset field erp.transthk.trh_refer_iref to "" (empty string)
				var sp = _om.ORDERSPAREPARTS.Where(x => x.ORDERMAINTENANCE.orderid == orderId).Distinct().ToList();

				foreach (var item in sp)
				{
					try
					{
						var tr = (from di in _erp.DOCINFOes
								  join trh in _erp.TRANSTKHs on di.DI_KEY equals trh.TRH_DI
								  where di.DI_REF == item.issueno
								  select new
								  {
									  di.DI_REF,
									  trh.TRH_KEY
								  }).ToList();

						if (tr.Count == 0 || tr == null)
						{
							return 0;
						}

						foreach (var doc in tr)
						{
							_erp.TRANSTKHs.Where(x => x.TRH_KEY == doc.TRH_KEY).ToList().ForEach(x =>
							{
								x.TRH_REFER_IREF = "";
							});
							result += _erp.SaveChanges();
						}
					}
					catch (Exception)
					{
						return 0;
					}
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				result = -1;
				throw new Exception("Error update info in ERP....", ex);
			}
			return result;
		}

		#region JOBINFOS

		public int AddOrUpdateOrderFixedInfo(ActionMode Mode, ORDERFIXED OrderFixInfo)
		{
			var _result = 0;
			try
			{
				switch (Mode)
				{
					case ActionMode.Add:
						_om.ORDERFIXEDs.Add(OrderFixInfo);
						_result = _om.SaveChanges();

						break;

					case ActionMode.Edit:
						var _of = _om.ORDERFIXEDs.Single(x => x.lineid == OrderFixInfo.lineid);
						_of.datefixed = OrderFixInfo.datefixed;
						_of.fixeddetail = OrderFixInfo.fixeddetail;
						_of.engcode1 = OrderFixInfo.engcode1;
						_of.engineer1 = OrderFixInfo.engineer1;
						_of.engcode2 = OrderFixInfo.engcode2;
						_of.engineer2 = OrderFixInfo.engineer2;
						_of.engcode3 = OrderFixInfo.engcode3;
						_of.engineer3 = OrderFixInfo.engineer3;
						_of.engcode4 = OrderFixInfo.engcode4;
						_of.engineer4 = OrderFixInfo.engineer4;

						_result = _om.SaveChanges();

						break;
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				_result = 0;
				throw new Exception(string.Format("{0} Order Fixed Info failed !!!!", Mode == ActionMode.Add ? "Add" : "Update"),
					ex);
			}

			return _result;
		} // end AddOrUpdateOrderFixedInfo

		public ORDERMAINTENANCE GetJobOrderInfo(int JobId)
		{
			return _om.ORDERMAINTENANCEs.FirstOrDefault(x => x.orderid == JobId);
		} // end GetJobOrderInfo

		public DataTable GetJobOrderFixedItems(string OrderCode, int orderId)
		{
			return _om.ORDERFIXEDs.Where(x => x.ORDERMAINTENANCE.orderid == orderId && x.isdelete == false).Select(f => new
			{
				f.lineid,
				f.datefixed,
				f.fixeddetail,
				f.engcode1,
				f.engineer1,
				f.engcode2,
				f.engineer2,
				f.engcode3,
				f.engineer3,
				f.engcode4,
				f.engineer4
			}).OrderBy(o => o.datefixed).AsParallel().ToDataTable();

		} // end GetJobOrderFixedItems

		public ORDERFIXED GetOrderFixItem(int LineId)
		{
			return _om.ORDERFIXEDs.Single(x => x.lineid == LineId);
		} // end  GetOrderFixItem

		public int UpdateOrderInfo(ORDERMAINTENANCE Order, ActionMode Mode)
		{
			var _result = 0;

			try
			{
				switch (Mode)
				{
					case ActionMode.Add:
						_om.ORDERMAINTENANCEs.Add(Order);
						_result = _om.SaveChanges();
						break;

					case ActionMode.Edit:
						var _ord = _om.ORDERMAINTENANCEs.Single(x => x.orderid == Order.orderid);
						_ord.status = Order.status;
						_ord.or_date = Order.or_date;
						_ord.orderdate = Order.orderdate;
						_ord.duedate = Order.duedate;
						_ord.year = Order.year;
						_ord.finishdate = Order.finishdate;
						_ord.actionpiority = Order.actionpiority;
						_ord.fiscyear = Order.fiscyear;
						_ord.productid = Order.productid;
						_ord.type = Order.type;
						_ord.s_no = Order.s_no;
						_ord.errorcode = Order.errorcode;
						_ord.error = Order.error;
						_ord.servicecost = Order.servicecost;
						_ord.sparepartcost = Order.sparepartcost;
						_ord.othercost = Order.othercost;
						_ord.otherdetails = Order.otherdetails;
						_ord.isnocharge = Order.isnocharge;
						_ord.nochargedetail = Order.nochargedetail;
						_ord.inWarrantyService = Order.inWarrantyService;
						_ord.invoiceno = Order.invoiceno;
						_ord.modidt = Order.modidt;
						_ord.modiuser = Order.modiuser;

						_result = _om.SaveChanges();
						break;
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update the record!!!!!", ex);
			}

			return _result;

		} // end UpdateOrderInfo

		public DataTable GetJobPiorityList()
		{
			var _p = (from rp in _om.ORDERPIORITies
					  orderby rp.piorityname
					  select new
					  {
						  Value = rp.piorityid,
						  Key = rp.piorityname
					  }).AsParallel();

			return _p.ToDataTable();

		} // end GetJobPiorityList


		public DataTable GetJobErrorList()
		{
			var _err = (from err in _om.ERRORCATEGORies
						select new
						{
							Value = err.errorcode,
							Key = err.errorcatname
						}).AsParallel();

			return _err.ToDataTable();
		} // end GetJobErrorList

		public DataTable GetCustomerForJobOrder()
		{
			var _cust = _om.CUSTOMERS.Where(x => x.ISDELETE == false).Select(s => new
			{
				VALUE = s.CUSTCODE,
				KEY = s.CUSTNAME
			}).OrderBy(o => o.KEY).AsParallel();

			if (_cust != null)
			{
				return _cust.ToDataTable();
			}

			return null;

		} // end GetCustomerForJobOrder

		public DataTable GetMachineSerialNoByCustomer(string CustomerCode, string Model)
		{
			var mix = _om.MIXes.Where(x => x.isdelete == false && x.acccustcode == CustomerCode && x.type == Model).Select(s => new
			{
				VALUE = s.s_no,
				KEY = s.s_no
			}).Distinct().AsParallel();

			if (mix != null)
			{
				return mix.ToDataTable();
			}

			return null;

		} // end GetMachineSerialNoByCustomer

		public string CreateServiceOrderNumber(string OrderCode, DateTime orderDate)
		{
			//int _lastorder = 0;
			string _orderNumber = string.Empty;
			int _currentYear = Convert.ToInt32(orderDate.GetThaiYearFormat());

			// find the last order of given order code
			var lastorder = _om.ORDERMAINTENANCEs
								.Where(x => x.orderCode == OrderCode && x.yearservice == _currentYear)
								.Max(m => m.ordercountno);

			_orderNumber = $"{_currentYear}-{(lastorder + 1):000#}";
			return _orderNumber;

		} // end 


		public string getLastOrder(string orderCode, DateTime currentJobYear)
		{
			string _lastJobNumber = string.Empty;
			int _currentYear = int.Parse(currentJobYear.GetThaiYearFormat());

			try
			{
				var jl = _om.ORDERMAINTENANCEs.Where(x => x.orderCode == orderCode && x.yearservice == _currentYear).Select(m => new
				{
					m.s_order,
					m.ordercountno
				}).Max(x => x.ordercountno);

				_lastJobNumber = $"{orderCode}-{jl:000#}";
			}
			catch
			{
				_lastJobNumber = $"{orderCode}-{0:000#}";
			}

			return _lastJobNumber;
		}

		public int DeleteOrderRepairItem(int LineId, int OrderId)
		{
			var _result = 0;
			using (var _scope = new TransactionScope())
			{
				try
				{
					_om.ORDERFIXEDs.Remove(_om.ORDERFIXEDs.Single(x => x.lineid == LineId && x.ORDERMAINTENANCE.orderid == OrderId));
					_result = _om.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("ไม่สามารถลบรายการที่เลือกได้", ex);
				}
			}

			return _result;
		} // end DeleteOrderRepairItem

		public async Task<DataTable> getSummaryActiveServiceOrderByOrderCodeAsync()
		{
			return await Task.Run(() =>
			{
				return _om.ORDERMAINTENANCEs
				.Where(s => s.status == (int)Shared.OMShareServiceEnums.OrderStatusEnum.ACTIVE
							&& s.orderCode != ""
							&& s.isdelete == false
				).GroupBy(g => g.orderCode).Select(ord => new
				{
					Code = ord.Key,
					Qty = ord.Count()
				}).OrderBy(o => o.Code).AsParallel().ToDataTable();
			});
		}

		public async Task<DataTable> getSummaryActiveServiceOrderByModelAsync()
		{
			return await Task.Run(() =>
			{
				return _om.ORDERMAINTENANCEs
				.Where(s => s.status == (int)Shared.OMShareServiceEnums.OrderStatusEnum.ACTIVE
							&& s.orderCode != ""
							&& s.isdelete == false
				).GroupBy(g => g.type).Select(ord => new
				{
					Model = ord.Key,
					Qty = ord.Count()
				}).OrderBy(o => o.Model).AsParallel().ToDataTable();
			});
		}

		#endregion
	}
}