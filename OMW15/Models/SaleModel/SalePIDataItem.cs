using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using OMControls;

namespace OMW15.Models.SaleModel
{
	public class PIReportDataSource : List<SalePIDataItem>
	{
		// constructor
		public PIReportDataSource(int PIHeaderId)
		{
			GetPIDataSource(CreatePIDataTable(PIHeaderId));
		} // end PIReportDataSource
		// crate report DataSource
		private void GetPIDataSource(DataTable PIDataSource)
		{
			foreach (DataRow dr in PIDataSource.Rows)
				Add(new SalePIDataItem(dr));

		} // end GetPIDataSource


		public DataTable CreatePIDataTable(int PIHeaderId)
		{
			var _result = new DataTable();

			using (var om = new OLDMOONEF1())
			{
				var pirows = (from pi in om.PI_INVOICE
					join pl in om.PI_ITEMS on pi.PIID equals pl.PI_ID
					where pi.PIID == PIHeaderId
					select new
					{
						PINumber = pi.PINO,
						PIDate = pi.PI_DATE,
						CustomerName = pi.PI_CUSTNAME,
						CustomerAddress = pi.PI_ADDRESS,
						BankInfo = pi.PI_BANKINFO,
						PaymentTerm = pi.PI_PAYMENT_TERM,
						DeliveryTerm = pi.PI_DELIVERY_TERM,
						DeliveryTime = pi.PI_DELIVERY_TIME,
						Currency = pi.PI_CURRENCY,
						TotalPILine = pi.PI_LINE_TOTAL,
						PackingCost = pi.PI_PACKING,
						DeliveryCost = pi.PI_DELIVERY,
						PITotalAmount = pi.PI_TOTAL_VALUES,
						ItemNo = pl.PI_ITEMNO,
						ItemName = pl.PI_ITEMNAME,
						ItemRemark = pl.PI_ITEM_REMARK,
						Unit = pl.PI_ITEM_UNIT,
						Qty = pl.PI_ITEM_QTY,
						UnitPrice = pl.PI_ITEM_PRICE,
						LineTotal = pl.PI_ITEM_AMOUNT
					}).AsParallel();

				if (pirows != null)
					_result = pirows.ToDataTable();
			}

			return _result;
		} // end CreatePIDataTable
	} // end class PIReportDataSource


	public class SalePIDataItem
	{
		// constructor
		public SalePIDataItem(DataRow Source)
		{
			PINumber = Source["PINUMBER"].ToString();
			PIDate = Convert.ToDateTime(Source["PIDATE"]);
			CustomerName = Source["CUSTOMERNAME"].ToString();
			CustomerAddress = Source["CUSTOMERADDRESS"].ToString();
			BankInfo = Source["BANKINFO"].ToString();
			Currency = Source["CURRENCY"].ToString();
			PaymentTerm = Source["PAYMENTTERM"].ToString();
			DeliveryTerm = Source["DELIVERYTERM"].ToString();
			DeliveryTime = Source["DELIVERYTIME"].ToString();
			TotalPILine = Convert.ToDecimal(Source["TOTALPILINE"]);
			PackingCost = Convert.ToDecimal(Source["PACKINGCOST"]);
			DeliveryCost = Convert.ToDecimal(Source["DELIVERYCOST"]);
			PITotalAmount = Convert.ToDecimal(Source["PITOTALAMOUNT"]);
			ItemNo = Source["ITEMNO"].ToString();
			ItemName = Source["ITEMNAME"].ToString();
			ItemRemark = Source["ITEMREMARK"].ToString();
			Unit = Source["UNIT"].ToString();
			Qty = Convert.ToDecimal(Source["QTY"]);
			UnitPrice = Convert.ToDecimal(Source["UNITPRICE"]);
			LineTotal = Convert.ToDecimal(Source["LINETOTAL"]);
		}

		#region class property

		public string PINumber { get; set; }

		public DateTime PIDate { get; set; }

		public string CustomerName { get; set; }

		public string CustomerAddress { get; set; }

		public string BankInfo { get; set; }

		public string PaymentTerm { get; set; }

		public string DeliveryTerm { get; set; }

		public string DeliveryTime { get; set; }

		public string Currency { get; set; }

		public decimal TotalPILine { get; set; }

		public decimal PackingCost { get; set; }

		public decimal PITotalAmount { get; set; }

		public decimal DeliveryCost { get; set; }

		public string ItemNo { get; set; }

		public string ItemName { get; set; }

		public string ItemRemark { get; set; }

		public string Unit { get; set; }

		public decimal Qty { get; set; }

		public decimal UnitPrice { get; set; }

		public decimal LineTotal { get; set; }

		#endregion
	}
}