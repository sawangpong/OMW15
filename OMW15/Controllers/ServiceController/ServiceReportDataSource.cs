using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OMW15.Controllers.ServiceController
{
	public class ServiceReportDataSource : List<ServiceOrderDataItem>
	{
		public ServiceReportDataSource(int OrderId)
		{
			GetServoiceOrderDataRecord(OrderId);
		}

		#region class helper method

		private void GetServoiceOrderDataRecord(int OrderId)
		{
			using (var _om = new OLDMOONEF1())
			{
				//var _r = ( //from ord in _om.ORDERMAINTENANCEs
				//		  from orf in _om.ORDERFIXEDs on ord.orderid equals orf.orderid into rf
				var _r = (from sr in _om.ORDERFIXEDs
							 where sr.ORDERMAINTENANCE.orderid == OrderId
							 select new
							 {
								 CustCode = sr.ORDERMAINTENANCE.acccustcode,
								 StatusId = sr.ORDERMAINTENANCE.status.Value,
								 StatusName = sr.ORDERMAINTENANCE.status.Value == 1 ? "ACTIVE" : "CLOSE",
								 sr.ORDERMAINTENANCE.orderid,
								 sr.ORDERMAINTENANCE.orderCode,
								 OrderNumber = sr.ORDERMAINTENANCE.s_order,
								 OrderDate = sr.ORDERMAINTENANCE.orderdate.Value,
								 MachineModel = sr.ORDERMAINTENANCE.type,
								 SN = sr.ORDERMAINTENANCE.s_no,
								 ErrorInfo = sr.ORDERMAINTENANCE.error == null ? "N/A" : sr.ORDERMAINTENANCE.error,
								 ServiceCost = sr.ORDERMAINTENANCE.servicecost,
								 SparePartCost = sr.ORDERMAINTENANCE.sparepartcost,
								 OtherCharge = sr.ORDERMAINTENANCE.othercost,
								 OtherDetails = sr.ORDERMAINTENANCE.otherdetails,
								 sr.ORDERMAINTENANCE.inWarrantyService,
								 sr.ORDERMAINTENANCE.invoiceno,
								 FixedInfo = sr.fixeddetail == null ? "N/A" : sr.fixeddetail,
								 Engineer1 = sr.engineer1 == null ? "" : sr.engineer1,
								 Engineer2 = sr.engineer2 == null ? "" : sr.engineer2,
								 Engineer3 = sr.engineer3 == null ? "" : sr.engineer3,
								 Engineer4 = sr.engineer4 == null ? "" : sr.engineer4,
								 sr.ORDERMAINTENANCE.isnocharge,
								 sr.ORDERMAINTENANCE.nochargedetail
							 }).DefaultIfEmpty();

				var _items = (from r in _r.ToList()
							  join cust in _om.CUSTOMERS on r.CustCode equals cust.CUSTCODE
							  select new
							  {
								  r.StatusId,
								  r.StatusName,
								  r.CustCode,
								  Customer = cust.CUSTNAME,
								  Address = cust.ADDRESS + " " + cust.PROVINCE + " " + cust.COUNTRY + " " + "\n" + cust.CONTACTPERSON,
								  cust.TEL,
								  cust.FAX,
								  r.orderid,
								  r.orderCode,
								  r.OrderNumber,
								  r.OrderDate,
								  r.MachineModel,
								  r.SN,
								  r.ServiceCost,
								  r.SparePartCost,
								  r.OtherCharge,
								  r.OtherDetails,
								  r.inWarrantyService,
								  r.invoiceno,
								  r.ErrorInfo,
								  r.FixedInfo,
								  r.Engineer1,
								  r.Engineer2,
								  r.Engineer3,
								  r.Engineer4,
								  r.isnocharge,
								  r.nochargedetail
							  }).AsParallel();

				if (_items != null)
				{
					var _dt = _items.ToDataTable();
					foreach (DataRow dr in _dt.Rows)
					{
						Add(new ServiceOrderDataItem(dr));
					}
				}
			}
		} // end GetServoiceOrderDataRecord

		#endregion
	}


	public class ServiceOrderDataItem
	{
		public ServiceOrderDataItem(DataRow Source)
		{
			Address = Source["ADDRESS"].ToString();
			Customer = Source["CUSTOMER"].ToString();
			CustomerCode = Source["CUSTCODE"].ToString();
			Engineer1 = Source["ENGINEER1"].ToString();
			Engineer2 = Source["ENGINEER2"].ToString();
			Engineer3 = Source["ENGINEER3"].ToString();
			Engineer4 = Source["ENGINEER4"].ToString();
			ErrorInfo = Source["ERRORINFO"].ToString();
			IsNoCharge = Convert.ToBoolean(Source["ISNOCHARGE"]);
			NoChargeDetail = Source["NOCHARGEDETAIL"].ToString();
			Tel = Source["TEL"].ToString();
			Fax = Source["FAX"].ToString();
			FixedInfo = Source["FIXEDINFO"].ToString();
			MachineModel = Source["MACHINEMODEL"].ToString();
			OrderCode = Source["ORDERCODE"].ToString();
			OrderDate = Convert.ToDateTime(Source["ORDERDATE"]);
			OrderId = Convert.ToInt32(Source["ORDERID"]);
			OrderNumber = Source["ORDERNUMBER"].ToString();
			SerialNo = Source["SN"].ToString();
			ServiceCost = Convert.ToDecimal(Source["SERVICECOST"]);
			SparePartCost = Convert.ToDecimal(Source["SPAREPARTCOST"]);
			OtherCharge = Convert.ToDecimal(Source["OTHERCHARGE"]);
			OtherDetails = Source["OTHERDETAILS"].ToString();
			InWarranty = Convert.ToBoolean(Source["INWARRANTYSERVICE"]);

			InvoiceNo = Source["INVOICENO"].ToString();
			Status = Source["STATUSNAME"].ToString();
			StatusId = Convert.ToInt32(Source["STATUSID"]);
		}

		#region class property

		public string OrderCode
		{
			get; set;
		}

		public int OrderId
		{
			get; set;
		}

		public string Address
		{
			get; set;
		}

		public string Tel
		{
			get; set;
		}

		public string Fax
		{
			get; set;
		}

		public string OrderNumber
		{
			get; set;
		}

		public int StatusId
		{
			get; set;
		}

		public string Status
		{
			get; set;
		}

		public DateTime OrderDate
		{
			get; set;
		}

		public decimal ServiceCost
		{
			get; set;
		}

		public decimal SparePartCost
		{
			get; set;
		}
		public decimal OtherCharge
		{
			get; set;
		}

		public string OtherDetails
		{
			get; set;
		}

		public bool InWarranty
		{
			get; set;
		}
		public string InvoiceNo
		{
			get; set;
		}
		public string Customer
		{
			get; set;
		}

		public string CustomerCode
		{
			get; set;
		}

		public string ErrorInfo
		{
			get; set;
		}

		public string FixedInfo
		{
			get; set;
		}

		public string MachineModel
		{
			get; set;
		}

		public string SerialNo
		{
			get; set;
		}

		public string Engineer1
		{
			get; set;
		}

		public string Engineer2
		{
			get; set;
		}

		public string Engineer3
		{
			get; set;
		}

		public string Engineer4
		{
			get; set;
		}

		public bool IsNoCharge
		{
			get; set;
		}
		public string NoChargeDetail
		{
			get; set;
		}

		#endregion
	}
}