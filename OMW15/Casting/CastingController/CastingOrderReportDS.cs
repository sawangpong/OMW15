using System;
using System.Collections.Generic;
using System.Data;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingController
{
	public class CastingOrderReportDS : List<Casting.CastingController.CastingOrderReportDataItem> 
	{
		private OLDMOONEF _om;

		#region class private method

		private void GetCastingJobOrderRecords(int JobNo)
		{
		DataTable _source = this.GetJobPrintingRecord(JobNo);
			foreach (DataRow dr in _source.Rows)
			{
				this.Add(new Casting.CastingController.CastingOrderReportDataItem(dr));
			}

		} // end GetCastingJobOrderRecords

		#endregion

		#region class public method

		public DataTable GetActiveQCJob(int Status)
		{
			DataTable _result = new DataTable();
				var job = (from j in _om.JOBORDERS
						   join c in _om.CUSTPRICELISTs on j.ITEMID equals c.PRICESEQ
						   join ct in _om.CUSTOMER1 on j.CUSTCODE equals ct.CUSTCODE
						   join m in _om.SYSDATAs on c.MATERIAL.ToString() equals m.KEYVALUE
						   where j.STATUS == Status
						   && j.ISCANCEL == false
						   && m.GROUPTITLE == "MATERIAL"
						   select new
						   {
							   j.CUSTCODE,
							   ct.CUSTNAME,
							   WORKTYPE = j.ISREWORKS == true ? "งานซ่อม" : "ปรกติ",
							   STATUS = j.STATUS == 1 ? "ACTIVE" : "COMPLETE",
							   j.CUSTPO,
							   j.JOBNO,
							   j.JOBDATE,
							   j.DUEDATE,
							   JOBCAT = (j.PREFIX == "R" ? "ฉีด/หล่อ" : (j.PREFIX == "W" ? "หล่อแวกส์" : (j.PREFIX == "S" ? "ให้เทียน" : "ทำก้อนยาง"))),
							   j.PREFIX,
							   j.ITEMNO,
							   ITEMNUMBER = "[" + j.PREFIX + "]" + j.ITEMNO,
							   j.ITEMNAME,
							   MATERIAL = m.THKEYNAME,
							   j.ORDERUNIT,
							   j.ORDERQTY,
							   j.REMARK,
							   c.IMAGE_LOCATION
						   }).AsEnumerable().Select(x => new
						   {
							   x.CUSTCODE,
							   x.CUSTNAME,
							   x.WORKTYPE,
							   x.STATUS,
							   x.CUSTPO,
							   x.JOBNO,
							   JOBDATE = OMControls.OMUtils.Num2Date((object)x.JOBDATE),
							   DUEDATE = OMControls.OMUtils.Num2Date((object)x.DUEDATE),
							   x.JOBCAT,
							   x.PREFIX,
							   x.ITEMNO,
							   x.ITEMNUMBER,
							   x.ITEMNAME,
							   x.MATERIAL,
							   x.ORDERUNIT,
							   x.ORDERQTY,
							   x.REMARK,
							   PICTURE = OMControls.OMUtils.ConvertImage2Byte(Casting.CastingController.PriceListDAL.GetPriceListItemPicture(x.IMAGE_LOCATION))

						   }).AsParallel();

				if (job != null)
				{
					_result = OMControls.OMDataUtils.ToDataTable(job.ToList());
				}

			return _result;

		} // end GetActiveQCJob

		public DataTable GetJobPrintingRecord(int JobNo)
		{
			DataTable _result = new DataTable();
				int[] status = new[] { 1, 2 };
				var job = (from j in _om.JOBORDERS
						   join c in _om.CUSTPRICELISTs on j.ITEMID equals c.PRICESEQ
						   join ct in _om.CUSTOMER1 on j.CUSTCODE equals ct.CUSTCODE
						   join m in _om.SYSDATAs on c.MATERIAL.ToString() equals m.KEYVALUE
						   where j.JOBNO == JobNo
						   && j.ISCANCEL == false
						   && m.GROUPTITLE == "MATERIAL"
						   && status.Contains(j.STATUS)
						   select new
						   {
							   j.CUSTCODE,
							   ct.CUSTNAME,
							   WORKTYPE = j.ISREWORKS == true ? "งานซ่อม" : "ปรกติ",
							   STATUS = j.STATUS == 1 ? "ACTIVE" : "COMPLETE",
							   j.CUSTPO,
							   j.JOBNO,
							   j.JOBDATE,
							   j.DUEDATE,
							   JOBCAT = (j.PREFIX == "R" ? "ฉีด/หล่อ" : (j.PREFIX == "W" ? "หล่อแวกส์" : (j.PREFIX == "S" ? "ให้เทียน" : "ทำก้อนยาง"))),
							   j.PREFIX,
							   j.ITEMNO,
							   ITEMNUMBER = "[" + j.PREFIX + "]" + j.ITEMNO,
							   j.ITEMNAME,
							   MATERIAL = m.THKEYNAME,
							   j.ORDERUNIT,
							   j.ORDERQTY,
							   j.REMARK,
							   c.IMAGE_LOCATION
						   }).AsEnumerable().Select(x => new
						   {
							   x.CUSTCODE,
							   x.CUSTNAME,
							   x.WORKTYPE,
							   x.STATUS,
							   x.CUSTPO,
							   x.JOBNO,
							   JOBDATE = OMControls.OMUtils.Num2Date((object)x.JOBDATE),
							   DUEDATE = OMControls.OMUtils.Num2Date((object)x.DUEDATE),
							   x.JOBCAT,
							   x.PREFIX,
							   x.ITEMNO,
							   x.ITEMNUMBER,
							   x.ITEMNAME,
							   x.MATERIAL,
							   x.ORDERUNIT,
							   x.ORDERQTY,
							   x.REMARK,
							   PICTURE = OMControls.OMUtils.ConvertImage2Byte(Casting.CastingController.PriceListDAL.GetPriceListItemPicture(x.IMAGE_LOCATION))
							  
						   }).AsParallel();

				if (job != null)
				{
					_result = OMControls.OMDataUtils.ToDataTable(job.ToList());
				}
			
			return _result;
		
		} // end GetJobPrintingRecord

		#endregion

		public CastingOrderReportDS()
		{
			_om= new OLDMOONEF();
		}

		public CastingOrderReportDS(int JobOrder)
		{
			_om= new OLDMOONEF();
			this.GetCastingJobOrderRecords(JobOrder);
		}

		//protected virtual void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		// dispose managed resources
		//		_om.Dispose();
		//	}
		//	// free native resources
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}
	}
}
