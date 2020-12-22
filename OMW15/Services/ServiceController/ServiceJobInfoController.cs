using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Services.ServiceController
{
	public class ServiceJobInfoController
	{
		#region STATIC Helper Method

		public static DataTable GetJobPiorityList()
		{
			DataTable _result = new DataTable();
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _p = from rp in _srv.ORDERPIORITies.AsParallel()

						 select new
						 {
							 Value = rp.piorityid,
							 Key = rp.piorityname
						 };
				_result = OMControls.OMDataUtils.ToDataTable(_p.ToList());
			}
			return _result;

		} // end GetJobPiorityList


		public static DataTable GetJobErrorList()
		{
			DataTable _result = new DataTable();
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _err = from err in _srv.ERRORCATEGORies.AsParallel()
						   select new
						   {
							   Value = err.errorcode,
							   Key = err.errorcatname
						   };
				_result = OMControls.OMDataUtils.ToDataTable(_err.ToList());
			}
			return _result;
		} // end GetJobErrorList

		public static DataTable GetCustomerForJobOrder()
		{
			DataTable _result = new DataTable();
			using (OLDMOONEF _om = new OLDMOONEF())
			{
				var _cus = from c in _om.CUSTOMER1.AsParallel()
						   orderby c.CUSTNAME
						   where c.ISDELETE == false
						   select new
						   {
							   VALUE = c.CUSTCODE,
							   KEY = c.CUSTNAME
						   };

				_result = OMControls.OMDataUtils.ToDataTable(_cus.ToList());
			}

			return _result;

		} // end GetCustomerForJobOrder

		public static DataTable GetMachineSerialNoByCustomer(string CustomerCode, string Model)
		{
			DataTable _result = new DataTable();
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _m = (from m in _srv.MIXes.AsParallel()
						  orderby m.type
						  where m.isdelete == false
						  && m.acccustcode == CustomerCode
						  && m.type == Model
						  select new
						  {
							  VALUE = m.s_no,
							  KEY = m.s_no
						  }).Distinct();

				_result = OMControls.OMDataUtils.ToDataTable(_m.ToList());
			}

			return _result;

		} // end GetMachineSerialNoByCustomer

		public static string CreateServiceOrderNumber(string OrderCode)
		{
			int _lastorder = 0;
			string _orderNumber = string.Empty;
			int _currentYear = Convert.ToInt32(DateTime.Today.GetThaiYearFormat());

			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _m = (from ord in _srv.ORDERMAINTENANCEs
						  where ord.orderCode == OrderCode
						  && ord.yearservice == _currentYear
						  select new
						  {
							  ord.s_order,
							  ord.ordercountno
						  }).ToList();
				int max = _m.Max(i => i.ordercountno);
				var _lastNumber = _m.First(i => i.ordercountno == max);

				if (_lastNumber != null)
				{
					_lastorder = _lastNumber.ordercountno + 1;
					_orderNumber = string.Format("{0}-{1}", _currentYear, ("0000".Substring(0, 4 - _lastorder.ToString().Length) + _lastorder.ToString()));
				}
				else
				{
					_orderNumber = string.Empty;
				}

			}
			return _orderNumber;

		} // end 

		public static string GetLastServiceOrderByOrderType(string OrderCode)
		{
			string _lastJobNumber = string.Empty;
			int _currentYear = Convert.ToInt32(DateTime.Today.GetThaiYearFormat());
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _lastOrder = (from ord in _srv.ORDERMAINTENANCEs
								  where ord.orderCode == OrderCode
								  && ord.yearservice == _currentYear
								  select new
								  {
									  ord.s_order,
									  ord.ordercountno
								  }).ToList();
				int max = _lastOrder.Max(i => i.ordercountno);
				var _m = _lastOrder.First(i => i.ordercountno == max);

				_lastJobNumber = string.Format("{0}{1}", OrderCode, _m.s_order);
				return _lastJobNumber;
			}

		} // end GetLastServiceOrderByOrderType

		public static int DeleteOrderRepairItem(int LineId, int OrderId)
		{
			int _result = 0;
			using (var _scope = new System.Transactions.TransactionScope())
			{
				SERVICEEF _srv = new SERVICEEF();
				var _itemFixed = (from f in _srv.ORDERFIXEDs
								  where f.lineid == LineId
								  && f.orderid == OrderId
								  select f).FirstOrDefault();

				try
				{
					_srv.ORDERFIXEDs.Remove(_itemFixed);
					_result = _srv.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("ไม่สามารถลบรายการที่เลือกได้", ex);
				}
			}

			return _result;

		} // end DeleteOrderRepairItem

		#endregion // static class method

		#region class helper Method
		public int AddOrUpdateOrderFixedInfo(ActionMode Mode, ORDERFIXED OrderFixInfo)
		{
			int _result = 0;
			using (var _scope = new TransactionScope())
			{
				using (SERVICEEF _srv = new SERVICEEF())
				{
					try
					{
						switch (Mode)
						{
							case ActionMode.Add:
								var _rf = new ORDERFIXED();
								_rf.datefixed = OrderFixInfo.datefixed;
								_rf.engcode1 = OrderFixInfo.engcode1;
								_rf.engcode2 = OrderFixInfo.engcode2;
								_rf.engcode3 = OrderFixInfo.engcode3;
								_rf.engcode4 = OrderFixInfo.engcode4;
								_rf.engineer1 = OrderFixInfo.engineer1;
								_rf.engineer2 = OrderFixInfo.engineer2;
								_rf.engineer3 = OrderFixInfo.engineer3;
								_rf.engineer4 = OrderFixInfo.engineer4;
								_rf.fixeddetail = OrderFixInfo.fixeddetail;
								_rf.isdelete = false;
								_rf.ordercode = OrderFixInfo.ordercode;
								_rf.orderid = OrderFixInfo.orderid;
								_rf.s_order = OrderFixInfo.s_order;

								_srv.ORDERFIXEDs.Add(_rf);
								_result = _srv.SaveChanges();

								break;

							case ActionMode.Edit:
								var _of = _srv.ORDERFIXEDs.SingleOrDefault(x => x.lineid == OrderFixInfo.lineid);
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

								_result = _srv.SaveChanges();

								break;
						}
						_scope.Complete();
					}
					catch (OptimisticConcurrencyException ex)
					{
						_result = 0;
						throw new Exception(string.Format("{0} Order Fixed Info failed !!!!", (Mode == ActionMode.Add ? "Add" : "Update")), ex);
					}
				}
			}

			return _result;

		} // end AddOrUpdateOrderFixedInfo

		public ORDERMAINTENANCE GetJobOrderInfo(int JobId)
		{
			using (SERVICEEF _srv = new SERVICEEF())
			{
				return _srv.ORDERMAINTENANCEs.FirstOrDefault(x => x.orderid == JobId);
			}

		} // end GetJobOrderInfo

		public DataTable GetJobOrderFixedItems(string OrderCode, int JobId)
		{
			DataTable _result = new DataTable();
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _jf = from jf in _srv.ORDERFIXEDs.AsParallel()
						  orderby jf.datefixed
						  where jf.ordercode == OrderCode
						  && jf.orderid == JobId
						  && jf.isdelete == false
						  select jf;
				_result = OMControls.OMDataUtils.ToDataTable(_jf.ToList());
			}

			return _result;

		} // end GetJobOrderFixedItems

		public ORDERFIXED GetOrderFixItem(int LineId)
		{
			using (SERVICEEF _srv = new SERVICEEF())
			{
				return _srv.ORDERFIXEDs.FirstOrDefault(x => x.lineid == LineId);
			}
		} // end  GetOrderFixItem

		public int UpdateOrderInfo(ORDERMAINTENANCE Order, ActionMode Mode)
		{
			int _result = 0;
			using (var _scope = new System.Transactions.TransactionScope())
			{
				using (SERVICEEF _srv = new SERVICEEF())
				{
					try
					{
						switch (Mode)
						{
							case ActionMode.Add:
								_srv.ORDERMAINTENANCEs.Add(Order);
								_result = _srv.SaveChanges();
								_scope.Complete();
								break;

							case ActionMode.Edit:

								var _ord = _srv.ORDERMAINTENANCEs.SingleOrDefault(x => x.orderid == Order.orderid);

								_ord.status = Order.status;
								_ord.year = Order.year;
								_ord.finishdate = Order.finishdate;
								_ord.productid = Order.productid;
								_ord.type = Order.type;
								_ord.s_no = Order.s_no;
								_ord.errorcode = Order.errorcode;
								_ord.error = Order.error;
								_ord.servicecost = Order.servicecost;
								_ord.sparepartcost = Order.sparepartcost;
								_ord.modidt = Order.modidt;
								_ord.modiuser = Order.modiuser;

								_result = _srv.SaveChanges();
								_scope.Complete();
								break;
						}
					}
					catch (OptimisticConcurrencyException ex)
					{
						throw new Exception("Can't update the record!!!!!", ex);
					}
				}
			}

			return _result;

		} // end UpdateOrderInfo


		#endregion

	}
}
