using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using OMControls;

namespace OMW15.Models.SaleModel
{
	public class SaleQTDataSource : List<SaleQTDataItem>
	{
		public SaleQTDataSource(int QuotationId)
		{
			GetQTDataSource(CreateQTDataTable(QuotationId));
		}

		private void GetQTDataSource(DataTable Source)
		{
			foreach (DataRow dr in Source.Rows)
				Add(new SaleQTDataItem(dr));
		} // end GetQTData

		public DataTable CreateQTDataTable(int QuotationId)
		{
			var _result = new DataTable();

			using (var om = new OLDMOONEF1())
			{
				var q = (from qt in om.QUOTATIONHHs
					join ql in om.QUOTATIONLLs on qt.QT_ID equals ql.QL_QT
					where qt.QT_ID == QuotationId
					select new
					{
						QTNumber = qt.QT_PREFIX + qt.QT_NUMBER + (qt.QT_REVISION > 0 ? " /R" + qt.QT_REVISION : ""),
						QTdate = qt.QT_DATE,
						QTExpire = qt.QT_VALIDATIONDATE,
						Customer = qt.QT_CUSTOMER,
						CustomerAddress = qt.QT_ADDRESS,
						Country = qt.QT_COUNTRY,
						ContactPerson = qt.QT_CONTACT_PERSON,
						CustomerContactNo = qt.QT_CONTACTNO,
						Email = qt.QT_CUST_EMAIL,
						Saleman = qt.QT_SALE_PERSON,
						SaleContactNo = qt.QT_SALE_CONTACTNO,
						SaleEmail = qt.QT_SALE_EMAIL,
						Currency = qt.QT_CURRENCY,
						QTRemark = qt.QT_REMARK,
						TotalItemValues = qt.QT_TOTALVALUEITEMS,
						TotalDiscount = qt.QT_TOTALDISCOUNT,
						ExtraDiscount = qt.QT_EXTRADISCOUNT,
						QTNetValues = qt.QT_TOTALNETTVALUES,
						PackingCost = qt.QT_PACKINGVALUE,
						ShippingCost = qt.QT_SHIPPINGVALUE,
						QTTotalAmount = qt.QT_TOTALAMOUNT,
						DeliveryTerm = qt.QT_DELIVERY_TERM,
						DeliverySchedule = qt.QT_DELIVERY_TIME,
						PaymentTerm = qt.QT_PAYMENT_TERM,
						BankInfo = qt.QT_BANKINFO,
						Training = qt.QT_TRAINING,
						WarrantyTerm = qt.QT_WARRANTY,
						ItemNo = ql.QL_ITEMNO,
						ItemName = ql.QL_ITEMNAME,
						ItemInfo = ql.QL_ITEMINFO,
						Unit = ql.QL_UNIT,
						Qty = ql.QL_QTY,
						UnitPrice = ql.QL_UNITPRICE,
						LineTotal = ql.QL_TOTAL
					}).AsNoTracking().AsParallel();

				if (q != null)
					_result = q.ToDataTable();
			}

			return _result;
		} // end CreateQTDataTable
	}

	public class SaleQTDataItem
	{
		public SaleQTDataItem(DataRow Source)
		{
			// binding source to class properties
			QTNumber = Source["QTNUMBER"].ToString();
			QTdate = Convert.ToDateTime(Source["QTDATE"]);
			QTExpire = Convert.ToDateTime(Source["QTExpire"]);
			Customer = Source["CUSTOMER"].ToString();
			CustomerAddress = Source["CUSTOMERADDRESS"].ToString();
			Country = Source["COUNTRY"].ToString();
			ContactPerson = Source["CONTACTPERSON"].ToString();
			CustomerContactNo = Source["CUSTOMERCONTACTNO"].ToString();
			Email = Source["EMAIL"].ToString();
			Saleman = Source["SALEMAN"].ToString();
			SaleContactNo = Source["SALECONTACTNO"].ToString();
			SaleEmail = Source["SALEEMAIL"].ToString();
			Currency = Source["CURRENCY"].ToString();
			QTRemark = Source["QTREMARK"].ToString();
			TotalItemValues = Convert.ToDecimal(Source["TOTALITEMVALUES"]);
			TotalDiscount = Convert.ToDecimal(Source["TOTALDISCOUNT"]);
			ExtraDiscount = Convert.ToDecimal(Source["EXTRADISCOUNT"]);
			QTNetValues = Convert.ToDecimal(Source["QTNetValues"]);
			PackingCost = Convert.ToDecimal(Source["PACKINGCOST"]);
			ShippingCost = Convert.ToDecimal(Source["SHIPPINGCOST"]);
			QTTotalAmount = Convert.ToDecimal(Source["QTTOTALAMOUNT"]);
			DeliveryTerm = Source["DELIVERYTERM"].ToString();
			DeliverySchedule = Source["DELIVERYSCHEDULE"].ToString();
			PaymentTerm = Source["PAYMENTTERM"].ToString();
			BankInfo = Source["BANKINFO"].ToString();
			Training = Source["TRAINING"].ToString();
			WarrantyTerm = Source["WARRANTYTERM"].ToString();
			ItemNo = Source["ITEMNO"].ToString();
			ItemName = Source["ITEMNAME"].ToString();
			ItemInfo = Source["ITEMINFO"].ToString();
			Unit = Source["UNIT"].ToString();
			Qty = Convert.ToDecimal(Source["QTY"]);
			UnitPrice = Convert.ToDecimal(Source["UNITPRICE"]);
			LineTotal = Convert.ToDecimal(Source["LINETOTAL"]);
		}

		#region class properties

		public string QTNumber { get; set; }

		public DateTime QTdate { get; set; }

		public DateTime QTExpire { get; set; }

		public string Customer { get; set; }

		public string CustomerAddress { get; set; }

		public string Country { get; set; }

		public string ContactPerson { get; set; }

		public string CustomerContactNo { get; set; }

		public string Email { get; set; }

		public string Saleman { get; set; }

		public string SaleContactNo { get; set; }

		public string SaleEmail { get; set; }

		public string Currency { get; set; }

		public string QTRemark { get; set; }

		public decimal TotalItemValues { get; set; }

		public decimal TotalDiscount { get; set; }

		public decimal ExtraDiscount { get; set; }

		public decimal QTNetValues { get; set; }

		public decimal PackingCost { get; set; }

		public decimal ShippingCost { get; set; }

		public decimal QTTotalAmount { get; set; }

		public string DeliveryTerm { get; set; }

		public string DeliverySchedule { get; set; }

		public string PaymentTerm { get; set; }

		public string BankInfo { get; set; }

		public string Training { get; set; }

		public string WarrantyTerm { get; set; }

		public string ItemNo { get; set; }

		public string ItemName { get; set; }

		public string ItemInfo { get; set; }

		public string Unit { get; set; }

		public decimal Qty { get; set; }

		public decimal UnitPrice { get; set; }

		public decimal LineTotal { get; set; }

		#endregion
	}
}