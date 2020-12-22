using System.Data;
using System.Linq;
using OMW15.Shared;

namespace OMW15.Models.ServiceModel
{
	public class ServiceReportDAL
	{
		private readonly OLDMOONEF1 _om;

		// CONSTRUCTOR
		public ServiceReportDAL()
		{
			_om = new OLDMOONEF1();
		}

		#region class Methods

		public DataTable GetServiceJobHistory(int OrderId)
		{
			//var _j = (from o in _om.ORDERMAINTENANCEs
			//	join f in _om.ORDERFIXEDs on o.orderid equals f.ORDERMAINTENANCE.orderid
			//	where o..orderid == OrderId

			var _j = (from o in _om.ORDERFIXEDs
						 where o.ORDERMAINTENANCE.orderid ==  OrderId
				select new
				{
					o.ORDERMAINTENANCE.orderid,
					Status =
					o.ORDERMAINTENANCE.status == (int) OMShareServiceEnums.OrderStatusEnum.ACTIVE
						? OMShareServiceEnums.OrderStatusEnum.ACTIVE.ToString()
						: (o.ORDERMAINTENANCE.status == (int) OMShareServiceEnums.OrderStatusEnum.CLOSED
							? OMShareServiceEnums.OrderStatusEnum.CLOSED.ToString()
							: "N/A"),
					o.ORDERMAINTENANCE.orderCode,
					OrderNo = o.ORDERMAINTENANCE.orderCode + "-" + o.ORDERMAINTENANCE.s_order,
					OrderDate = o.ORDERMAINTENANCE.orderdate.Value,
					SerialNo = o.ORDERMAINTENANCE.s_no,
					Model = o.ORDERMAINTENANCE.type,
					CustCode = o.ORDERMAINTENANCE.acccustcode,
					Customer = o.ORDERMAINTENANCE.cus_na,
					o.ORDERMAINTENANCE.errorcode,
					o.ORDERMAINTENANCE.error,
					o.ORDERMAINTENANCE.servicecost,
					o.ORDERMAINTENANCE.sparepartcost,
					ServiceDate = o.datefixed,
					ServiceMan = o.engineer1 + "," + o.engineer2 + "," + o.engineer3 + ","
					             + o.engineer4,
					ServiceDetails = o.fixeddetail
				}).OrderBy(r => r.OrderNo).AsParallel();


			return _j.ToDataTable();
		} // end GetServiceJobHistory


		public DataTable GetServiceJobHistories(int[] OrderId)
		{
			var _j = (from o in _om.ORDERMAINTENANCEs
				join f in _om.ORDERFIXEDs on o.orderid equals f.ORDERMAINTENANCE.orderid
				where OrderId.Contains(o.orderid)
				select new
				{
					o.orderid,
					Status =
					o.status == (int) OMShareServiceEnums.OrderStatusEnum.ACTIVE
						? OMShareServiceEnums.OrderStatusEnum.ACTIVE.ToString()
						: (o.status == (int) OMShareServiceEnums.OrderStatusEnum.CLOSED
							? OMShareServiceEnums.OrderStatusEnum.CLOSED.ToString()
							: "N/A"),
					o.orderCode,
					OrderNo = o.orderCode + "-" + o.s_order,
					OrderDate = o.orderdate.Value,
					SerialNo = o.s_no,
					Model = o.type,
					CustCode = o.acccustcode,
					Customer = o.cus_na,
					o.errorcode,
					o.error,
					o.servicecost,
					o.sparepartcost,
					ServiceDate = f.datefixed,
					ServiceMan = f.engineer1 + "," + f.engineer2 + "," + f.engineer3 + ","
					             + f.engineer4,
					ServiceDetails = f.fixeddetail
				}).OrderBy(r => r.OrderNo).AsParallel();


			return _j.ToDataTable();
		} // end GetServiceJobHistory


		public DataTable GetServiceOrderSpareParts(int OrderId)
		{
			var sp = (from s in _om.ORDERSPAREPARTS
				where s.ORDERMAINTENANCE.orderid == OrderId
				select new
				{
					s.ORDERMAINTENANCE.orderid,
					s.issueno,
					s.itemno,
					Description = s.itemname,
					Unit = s.uom,
					Qty = s.qtyneed,
					UnitPrice = s.uprice,
					s.discount,
					NetPrice = s.netuprice,
					Total = s.totalprice
				}).OrderBy(o => o.itemno).AsParallel().ToList();

			return sp.ToDataTable();
		} // end GetServiceOrderSpareParts

		public DataTable GetServiceOrderSpareParts(int[] OrderIds)
		{
			var sp = (from s in _om.ORDERSPAREPARTS
				where OrderIds.Contains(s.ORDERMAINTENANCE.orderid)
				select new
				{
					s.ORDERMAINTENANCE.orderid,
					s.issueno,
					s.itemno,
					Description = s.itemname,
					Unit = s.uom,
					Qty = s.qtyneed,
					UnitPrice = s.uprice,
					s.discount,
					NetPrice = s.netuprice,
					Total = s.totalprice
				}).OrderBy(o => o.itemno).AsParallel().ToList();

			return sp.ToDataTable();
		} // end GetServiceOrderSpareParts

		#endregion
	}
}