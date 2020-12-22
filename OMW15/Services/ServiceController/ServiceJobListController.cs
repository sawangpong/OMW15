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
	public class ServiceJobListController
	{
		#region class Helper Methods
		#region Error Record
		
		public static DataTable GetErrorList()
		{
			DataTable _result = new DataTable();

			using (SERVICEEF _srv = new SERVICEEF())
			{
				var errs = from er in _srv.ERRORCATEGORies
						   select new
						   {
							   er.errorcatid,
							   er.errorcode,
							   er.errorcatname
						   };

				if (errs != null)
				{
					_result = OMControls.OMDataUtils.ToDataTable(errs.ToList());
				}
			}

			return _result;

		} // end GetErrorList

		public ERRORCATEGORY GetErrorItem(int ErrorCatId)
		{
			using (SERVICEEF _srv = new SERVICEEF())
			{
				return _srv.ERRORCATEGORies.FirstOrDefault(x => x.errorcatid == ErrorCatId);
			}

		} // end GetErrorItem

		public int AddEditErrorCategory(ERRORCATEGORY Err, ActionMode Mode)
		{
			int _result = 0;
			using (var _scope = new TransactionScope())
			{
				SERVICEEF _srv = new SERVICEEF();
				try
				{
					switch (Mode)
					{
						case ActionMode.Add:
							_srv.ERRORCATEGORies.Add(Err);
							_result = _srv.SaveChanges();
							_scope.Complete();

							break;
						case  ActionMode.Edit:
							var er = (from error in _srv.ERRORCATEGORies select error).Where(x=>x.errorcatid == Err.errorcatid).FirstOrDefault();							
							er.errorcatid = Err.errorcatid;
							er.errorcatname = Err.errorcatname;
							er.errorcode = Err.errorcode;

							_result = _srv.SaveChanges();
							_scope.Complete();

							break;
					}
				}
				catch(OptimisticConcurrencyException ex)
				{
					_result = 0;
					throw new Exception("Can't update record!!!", ex);
				}
			}


			return _result;

		} // end AddEditErrorCategory

		#endregion


		public static DataTable GetServiceYearList()
		{
			DataTable _result;
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _yl = (from s in _srv.ORDERMAINTENANCEs
						   where s.isdelete == false
						   select new
						   {
							   Y = s.fiscyear
						   }).Distinct().OrderByDescending(x => x.Y);
				_result = OMControls.OMDataUtils.ToDataTable(_yl.ToList());
			}

			return _result;

		} // end GetServiceYearList

		public static DataTable GetJobCodeList(int YearService)
		{
			DataTable _result;

			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _ordTypes = (from ordCode in _srv.ORDERTYPEs
								 join jobCode in _srv.ORDERMAINTENANCEs on ordCode.ordertypecode equals jobCode.orderCode
								 select new
								 {
									 Code = jobCode.orderCode,
									 CodeName = ordCode.ordertypename,
									 Value = jobCode.orderCode + " - " + ordCode.ordertypename
								 }).Distinct().OrderBy(x => x.Code);


				_result = OMControls.OMDataUtils.ToDataTable(_ordTypes.ToList());
			}

			return _result;

		} // end GetJobCodeList

		public DataTable GetJobList(int SelectedYear, string JobCode , OrderStatusEnum Status)
		{
			//CultureInfo _culture = new CultureInfo("en-EN");
			//DateTimeFormatInfo dt_format = _culture.DateTimeFormat;

			//string _format = @"dd\/MM\/yyyy";

			DataTable _result = new DataTable();
			using (SERVICEEF _srv = new SERVICEEF())
			{
				switch (Status)
				{
					case OrderStatusEnum.ALL:
						var _job = (from j in _srv.ORDERMAINTENANCEs
								   orderby j.s_order
								   where j.isdelete == false 
								   && j.fiscyear == SelectedYear
								   select new
								   {
									   j.orderid,
									   j.orderCode,
									   orderno = j.s_order,
									   year = j.fiscyear,
									   status = j.status.Value == 1 ? "ACTIVE" : "CLOSED",
									   jobno = "[" + j.orderCode + "] :: " + j.s_order,
									   orderdate = j.orderdate.Value,
									   duedate = j.duedate,
									   finish =  (j.finishdate.HasValue == true ? j.finishdate.Value.ToString() : string.Empty),
									   customercode = j.acccustcode,
									   customer = j.cus_na,
									   model = j.type,
									   serial = j.s_no,
									   j.errorcode,
									   j.error
								   }).AsParallel();

						var _dt = from _r in _job.AsEnumerable()
									  select new
									  {
										  _r.orderid,
										  _r.orderCode,
										  _r.orderno,
										  _r.year,
										  _r.status,
										  _r.jobno,
										  opendate = _r.orderdate.ToShortDateString(),
										  duedate = (_r.duedate == 0 ? string.Empty : OMControls.OMUtils.Num2Date(_r.duedate).ToShortDateString()),
										  finish = (string.IsNullOrEmpty(_r.finish) ? string.Empty : Convert.ToDateTime(_r.finish).ToShortDateString()),
										  _r.customercode,
										  _r.customer,
										  _r.model,
										  _r.serial,
										  _r.errorcode,
										  _r.error
									  };

						_result = OMControls.OMDataUtils.ToDataTable(_dt.ToList());

						break;

					case OrderStatusEnum.ACTIVE:
						var _ja = (from j in _srv.ORDERMAINTENANCEs
								   where j.isdelete == false
								   && j.orderCode == JobCode
								   && j.fiscyear == SelectedYear
								   && j.status == (int)OrderStatusEnum.ACTIVE
								   select new
								   {
									   j.orderid,
									   j.orderCode,
									   orderno = j.s_order,
									   year = j.fiscyear,
									   jobno = "[" + j.orderCode + "] :: " + j.s_order,
									   orderdate = j.orderdate.Value,
									   customercode = j.acccustcode,
									   customer = j.cus_na,
									   model = j.type,
									   serial = j.s_no,
									   j.errorcode,
									   j.error
								   }).AsParallel();

						if (_ja != null)
						{
							_result = OMControls.OMDataUtils.ToDataTable(_ja.ToList());
						}
						else
						{
							_result = null;
						}

						break;

					case OrderStatusEnum.COMPLETED:
						var _jc = (from j in _srv.ORDERMAINTENANCEs
								   orderby j.s_order
								   where j.isdelete == false 
								   && j.orderCode == JobCode 
								   && j.finishdate.Value.Year == SelectedYear
								   && (int)j.status == (int)OrderStatusEnum.COMPLETED
								   select new
								   {
									   j.orderid,
									   j.orderCode,
									   orderno= j.s_order,
									   year = j.fiscyear,
									   jobno = "[" + j.orderCode + "] :: " + j.s_order,
									   orderdate = j.orderdate.Value,
									   finish = j.finishdate.Value,
									   customercode = j.acccustcode,
									   customer = j.cus_na,
									   model = j.type,
									   serial = j.s_no,
									   j.errorcode,
									   j.error
								   }).AsParallel();

						if (_jc != null)
						{
							_result = OMControls.OMDataUtils.ToDataTable(_jc.ToList());
						}
						else
						{
							_result = null;
						}
						break;
				}
			}
			return _result;

		} // end GetJobList

		public string GetJobFixed(int JobId)
		{
			string _result = string.Empty;

			using(SERVICEEF _om=new SERVICEEF())
			{
				StringBuilder _fixs = new StringBuilder();
				var _fix = (from f in _om.ORDERFIXEDs
						   where f.orderid == JobId
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
				{
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
						}
						_result = _fixs.ToString();
					}
					else
					{
						_result = string.Empty;
					}
				}
				else
				{
					_result = string.Empty;
				}
			}

			return _result;

		} // end GetJobFixed

		public DataTable GetOrderListByMachine(string CustomerCode, string MachineModel, string SerialNo)
		{
			DataTable _result = new DataTable();
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _orders = (from ord in _srv.ORDERMAINTENANCEs
							   orderby ord.orderdate, ord.orderCode, ord.s_order
							   where ord.isdelete == false
							   && ord.acccustcode == CustomerCode
							   && ord.type == MachineModel
							   && ord.s_no == SerialNo
							   select new
							   {
								   id = ord.orderid,
								   ord.orderCode,
								   status = ord.status.Value == 1 ? "Active" : "Closed",
								   OrderNo = ord.orderCode + "-" + ord.s_order,
								   Date = ord.orderdate.Value
							   }).ToList();
				
				var _ords = (from x in _orders.AsEnumerable()
							select new
							   {
								   x.id,
								   x.orderCode,
								   x.status,
								   x.OrderNo,
								   Date = x.Date.ToShortDateString()
							   }).ToList();

				_result = OMControls.OMDataUtils.ToDataTable(_ords);
			}

			return _result;

		} // end GetOrderListByMachine


		#endregion

		public ServiceJobListController()
		{
		} // end constructor
	}
}
