using System.Data;
using System.Linq;

namespace OMW15.Models.CastingModel
{
	public class CastingSaleOrderDataSource
	{
		#region class field member

		private readonly OLDMOONEF1 _om;

		 // Constructor
		public CastingSaleOrderDataSource()
		{
			_om = new OLDMOONEF1();
		}       
		
		#endregion

		#region class helper method

		public DataTable CastingSaleOrderRowSource(int SaleOrderId)
		{
			var _result = new DataTable();

			// getting data
			var so = (from s in _om.SALEORDERS.AsEnumerable()
					  join c in _om.CUSTOMERS on s.CUSTCODE equals c.CUSTCODE
					  join sl in _om.SOLINES on s.SOSEQ equals sl.SOSEQ
					  join m in _om.SYSDATAs on s.DELIVERMAT.ToString() equals m.KEYVALUE
					  where s.ISCANCEL == false
							&& s.ISDELETE == false
							&& m.GROUPTITLE == "MATERIAL"
							&& s.SOSEQ == SaleOrderId

					  select new
					  {
						  SaleOrderId = s.SOSEQ,
						  SaleOrderNumber = s.SONO,
						  SaleOrderDate = s.SODATE.Num2Date(),
						  ActualDeliveryDate = s.ACTUALDELIVERDT.Num2Date(),
						  DueDate = s.DUEDATE.Num2Date(),
						  CustoemrId = c.CUSTID,
						  CustomerCode = c.CUSTCODE,
						  CustomerName = c.CUSTNAME,
						  CustomerBranch = c.ISHEADQUARTERS == true ? "(สำนักงานใหญ่)" : "สาขาที่ " + c.BRANCHNUMBER.Value,
						  CustomerAddress =
						  c.ADDRESS + " " + c.DISTRICT + " " + c.PROVINCE + " " + c.POSTAL + " โทร : " + c.TEL + "  โทรสาร :" + c.FAX,
						  CustomerTaxId = c.CUSTTAXID,
						  ContactPerson = s.CONTACT_PERSON,
						  DeliveredMaterialId = s.DELIVERMAT,
						  DeliveredMaterial = m.THKEYNAME,
						  DeliveredWeight = s.DELIVERWEIGHT,
						  TotalLineWeight = sl.TOTALWEIGHT,
						  TotalValues = s.TOTALVALUE,
						  TotalDiscount = s.DISCOUNT,
						  TotalNetValues = s.NETVALUE,
						  VATRate = s.VATPERCENT,
						  TotalVATValues = s.VATVALUE,
						  TotalAmountValues = s.TOTALAMOUNT,
						  TotalAmountText = s.TOTALAMOUNTTEXT,
						  SaleOrderRemark = s.REMARK,
						  SOLineId = sl.SOLINESEQ,
						  ItemPrefix = sl.PREFIX,
						  sl.ITEMNO,
						  sl.ITEMNAME,
						  ItemUnit = sl.UNIT,
						  DeliveredItemQty = sl.DELIVEREDQTY,
						  ItemUnitPrice = sl.UNITPRICE,
						  ItemDiscountValue = sl.UNITDISCOUNT,
						  TotalValue = sl.DELIVEREDQTY * sl.UNITPRICE,
						  ItemNetValue = sl.NETTUNITVALUE,
						  ItemVATValue = sl.VATVALUE,
						  ItemTotalValues = sl.LINEAMOUNT,
						  UnitWeight = sl.AVGUNITWEIGHT,
						  ItemRemark = sl.SOLINEREMARK,
						  s.ISVAT
					  }).OrderBy(x => x.ITEMNO);

			if (so != null)
			{
				if (omglobal.NONVAT_DISPLAY)
				{
					_result = so.ToDataTable();
				}
				else
				{
					_result = so.Where(v => v.ISVAT == omglobal.NONVAT_DISPLAY).ToDataTable();
				}
			}
			return _result;

		} // end CastingSaleOrderRowSource

		#endregion
	}
}