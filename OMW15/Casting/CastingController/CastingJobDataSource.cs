using System;
using System.Collections.Generic;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.Casting.CastingController
{
	public class CastingJobDataSource : List<Casting.CastingController.CastingJobOrderDataItem>
	{
		private OLDMOONEF _om;
		//private DataTable dtJobRecords = new DataTable();

		#region Class Methods

		public DataTable GetCastingQCJobs(int JobStatus, string CustomerCode, string JobCode)
		{
			DataTable _result = new DataTable();
			//int[] status = new[] { 1, 2 };
			var job = (from j in _om.JOBORDERS
					   join c in _om.CUSTPRICELISTs on j.ITEMID equals c.PRICESEQ
					   join cp in _om.CUSTPRICEITEMPICs on j.ITEMID equals cp.ITEMSEQ
					   join ct in _om.CUSTOMER1 on j.CUSTCODE equals ct.CUSTCODE
					   join m in _om.SYSDATAs on c.MATERIAL.ToString() equals m.KEYVALUE
					   where j.STATUS == JobStatus
					   && j.CUSTCODE == CustomerCode
					   && j.PREFIX == JobCode
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
						   PICTURE = cp.ITEMPIC
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
							   x.PICTURE
						   }).AsParallel();

			if (job != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(job.ToList());
			}
			else
			{
				_result = null;
			}

			return _result;

		} // end GetCastingQCJobs

		public DataTable GetCastingJobOrderRecords(int JobNumber)
		{
			DataTable _result = new DataTable();

			int[] status = new[] { 1, 2 };
			var job = (from j in _om.JOBORDERS
					   join c in _om.CUSTPRICELISTs on j.ITEMID equals c.PRICESEQ
					   join ct in _om.CUSTOMER1 on j.CUSTCODE equals ct.CUSTCODE
					   join m in _om.SYSDATAs on c.MATERIAL.ToString() equals m.KEYVALUE
					   where j.JOBNO == JobNumber
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
						   PICTURE = Casting.CastingController.PriceListDAL.GetPriceListItemPicture(@c.IMAGE_LOCATION)
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
						   x.PICTURE
					   }).AsParallel();

			if (job != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(job.ToList());
			}
			else
			{
				_result = null;
			}

			return _result;

		} // end GetCastingJobOrderRecords


		#endregion //end Class Methods

		#region constructor and destructor

		public CastingJobDataSource()
		{
			_om = new OLDMOONEF();
		}

		public CastingJobDataSource(int JobNumber)
		{
			_om = new OLDMOONEF();
		} // end constructor

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

		#endregion

	} // end class CastingJobDataSource
}

