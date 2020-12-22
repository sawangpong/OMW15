using System.Collections.Generic;
using System.Data;
using System.Linq;
using OMControls;
using OMW15.Shared;

namespace OMW15.Models.CastingModel
{
	public class CastingJobDataSource : List<CastingJobOrderDataItem>
	{
		private readonly OLDMOONEF1 _om;

		#region Class Methods

		public DataTable GetCastingQCJobs(int JobStatus, string CustomerCode, string JobCode)
		{
			var _result = new DataTable();
			var job = (from j in _om.JOBORDERS
					   join c in _om.CUSTPRICELISTs on j.ITEMID equals c.PRICESEQ
					   join cp in _om.CUSTPRICEITEMPICs on j.ITEMID equals cp.ITEMSEQ
					   join ct in _om.CUSTOMERS on j.CUSTCODE equals ct.CUSTCODE
					   join m in _om.SYSDATAs on c.MATERIAL.ToString() equals m.KEYVALUE
					   where j.STATUS == JobStatus
							 && j.CUSTCODE == CustomerCode
							 && j.PREFIX == JobCode
							 && m.GROUPTITLE == "MATERIAL"
					   select new
					   {
						   j.CUSTCODE,
						   ct.CUSTNAME,
						   WORKTYPE = j.ISREWORKS ? "งานซ่อม" : "ปรกติ",
						   STATUS =
						   j.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
							   ? OMShareJobEnums.JobStatusEnumEN.Active.ToString().ToUpper()
							   : OMShareJobEnums.JobStatusEnumEN.Closed.ToString().ToUpper(),
						   j.CUSTPO,
						   j.JOBNO,
						   j.JOBDATE,
						   j.DUEDATE,
						   JOBCAT =
						   j.PREFIX == "R" ? "ฉีด/หล่อ" : (j.PREFIX == "W" ? "หล่อแวกส์" : (j.PREFIX == "S" ? "ให้เทียน" : "ทำก้อนยาง")),
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
						   JOBDATE = x.JOBDATE.Num2Date(),
						   DUEDATE = x.DUEDATE.Num2Date(),
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
				_result = job.ToDataTable();
			else
				_result = null;

			return _result;
		} // end GetCastingQCJobs

		public DataTable GetCastingJobOrderRecords(int JobNumber)
		{
			var _result = new DataTable();

			int[] status = { 1, 2 };
			var job = (from j in _om.JOBORDERS
					   join c in _om.CUSTPRICELISTs on j.ITEMID equals c.PRICESEQ
					   join ct in _om.CUSTOMERS on j.CUSTCODE equals ct.CUSTCODE
					   join m in _om.SYSDATAs on c.MATERIAL.ToString() equals m.KEYVALUE
					   where j.JOBNO == JobNumber
							 && m.GROUPTITLE == "MATERIAL"
							 && status.Contains(j.STATUS)
					   select new
					   {
						   j.CUSTCODE,
						   ct.CUSTNAME,
						   WORKTYPE = j.ISREWORKS ? "งานซ่อม" : "ปรกติ",
						   STATUS =
						   j.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
							   ? OMShareJobEnums.JobStatusEnumEN.Active.ToString().ToUpper()
							   : OMShareJobEnums.JobStatusEnumEN.Closed.ToString().ToUpper(),
						   j.CUSTPO,
						   j.JOBNO,
						   j.JOBDATE,
						   j.DUEDATE,
						   JOBCAT =
						   j.PREFIX == "R" ? "ฉีด/หล่อ" : (j.PREFIX == "W" ? "หล่อแวกส์" : (j.PREFIX == "S" ? "ให้เทียน" : "ทำก้อนยาง")),
						   j.PREFIX,
						   j.ITEMNO,
						   ITEMNUMBER = "[" + j.PREFIX + "]" + j.ITEMNO,
						   j.ITEMNAME,
						   MATERIAL = m.THKEYNAME,
						   j.ORDERUNIT,
						   j.ORDERQTY,
						   j.REMARK,
						   PICTURE = PriceListDAL.GetPriceListItemPicture(c.IMAGE_LOCATION)
					   }).AsEnumerable().Select(x => new
					   {
						   x.CUSTCODE,
						   x.CUSTNAME,
						   x.WORKTYPE,
						   x.STATUS,
						   x.CUSTPO,
						   x.JOBNO,
						   JOBDATE = x.JOBDATE.Num2Date(),
						   DUEDATE = x.DUEDATE.Num2Date(),
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
				_result = job.ToDataTable();
			else
				_result = null;

			return _result;
		} // end GetCastingJobOrderRecords

		#endregion //end Class Methods

		#region constructor and destructor

		public CastingJobDataSource()
		{
			_om = new OLDMOONEF1();
		}

		public CastingJobDataSource(int JobNumber)
		{
			_om = new OLDMOONEF1();
		} // end constructor

		#endregion
	} // end class CastingJobDataSource
}