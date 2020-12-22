using System;
using System.Collections.Generic;
using System.Data;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMControls;

namespace OMW15.Services.ServiceController
{
	public class ServiceReportDataSource : List<ServiceOrderDataItem>
	{
		#region class helper method

		private void GetServoiceOrderDataRecord(int OrderId)
		{
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _items = (from ord in _srv.ORDERMAINTENANCEs
							  join orf in _srv.ORDERFIXEDs on ord.orderid equals orf.orderid
							  join cust in _srv.CUSTOMERS on ord.acccustcode equals cust.CUSTCODE
							  where ord.orderid == OrderId
							  select new
							  {
								  StatusId = ord.status.Value,
								  StatusName = ord.status.Value == 1 ? "ACTIVE" : "CLOSE",
								  ord.orderid,
								  ord.orderCode,
								  OrderNumber = ord.s_order,
								  OrderDate = ord.orderdate.Value,
								  CustCode = ord.acccustcode,
								  Customer = ord.cus_na,
								  Address = cust.ADDRESS,
								  cust.TEL,
								  cust.FAX,
								  MachineModel = ord.type,
								  SN = ord.s_no,
								  ErrorInfo = ord.error == null ? "N/A" : ord.error,
								  FixedInfo = orf.fixeddetail == null ? "N/A" : orf.fixeddetail,
								  ServiceCost = ord.servicecost,
								  SparePartCost = ord.sparepartcost,
								  Engineer1 = orf.engineer1 == null ? "" : orf.engineer1,
								  Engineer2 = orf.engineer2 == null ? "" : orf.engineer2,
								  Engineer3 = orf.engineer3 == null ? "" : orf.engineer3,
								  Engineer4 = orf.engineer4 == null ? "" : orf.engineer4
							  }).ToList();

				if (_items != null)
				{
					DataTable _dt = OMControls.OMDataUtils.ToDataTable(_items);
					foreach (DataRow dr in _dt.Rows)
					{
						this.Add(new ServiceOrderDataItem(dr));
					}
				}
			}

		} // end GetServoiceOrderDataRecord

		#endregion

		public ServiceReportDataSource(int OrderId)
		{
			this.GetServoiceOrderDataRecord(OrderId);
		}
	}


	public class ServiceOrderDataItem
	{
		#region class property

		public string OrderCode
		{
			get;
			set;
		}

		public int OrderId
		{
			get;
			set;
		}

		public string Address
		{
			get;
			set;
		}

		public string Tel
		{
			get;
			set;
		}

		public string Fax
		{
			get;
			set;
		}

		public string OrderNumber
		{
			get;
			set;
		}
		public int StatusId
		{
			get;
			set;
		}

		public string Status
		{
			get;
			set;
		}
		public DateTime OrderDate
		{
			get;
			set;
		}

		//public DateTime FinishDate
		//{
		//	get;
		//	set;
		//}

		//public DateTime DueDate
		//{
		//	get;
		//	set;
		//}

		public Decimal ServiceCost
		{
			get;
			set;
		}

		public decimal SparePartCost
		{
			get;
			set;
		}

		public string Customer
		{
			get;
			set;
		}
		public string CustomerCode
		{
			get;
			set;
		}

		public string ErrorInfo
		{
			get;
			set;
		}
		public string FixedInfo
		{
			get;
			set;
		}

		public string MachineModel
		{
			get;
			set;
		}

		public string SerialNo
		{
			get;
			set;
		}

		public string Engineer1
		{
			get;
			set;
		}

		public string Engineer2
		{
			get;
			set;
		}

		public string Engineer3
		{
			get;
			set;
		}

		public string Engineer4
		{
			get;
			set;
		}
		#endregion


		public ServiceOrderDataItem(DataRow Source)
		{
			this.Address = Source["ADDRESS"].ToString();
			this.Customer = Source["CUSTOMER"].ToString();
			this.CustomerCode = Source["CUSTCODE"].ToString();
			//this.DueDate = OMControls.OMUtils.Num2Date(Source["DUEDATE"]);
			this.Engineer1 = Source["ENGINEER1"].ToString();
			this.Engineer2 = Source["ENGINEER2"].ToString();
			this.Engineer3 = Source["ENGINEER3"].ToString();
			this.Engineer4 = Source["ENGINEER4"].ToString();
			this.ErrorInfo = Source["ERRORINFO"].ToString();
			this.Fax = Source["FAX"].ToString();
			//this.FinishDate = Convert.ToDateTime(Source["FINISHDATE"]);
			this.FixedInfo = Source["FIXEDINFO"].ToString();
			this.MachineModel = Source["MACHINEMODEL"].ToString();
			this.OrderCode = Source["ORDERCODE"].ToString();
			this.OrderDate = Convert.ToDateTime(Source["ORDERDATE"]);
			this.OrderId = Convert.ToInt32(Source["ORDERID"]);
			this.OrderNumber = Source["ORDERNUMBER"].ToString();
			this.SerialNo = Source["SN"].ToString();
			this.ServiceCost = Convert.ToDecimal(Source["SERVICECOST"]);
			this.SparePartCost = Convert.ToDecimal(Source["SPAREPARTCOST"]);
			this.Status = Source["STATUSNAME"].ToString();
			this.StatusId = Convert.ToInt32(Source["STATUSID"]);
			this.Tel = Source["TEL"].ToString();
		}
	}
}
