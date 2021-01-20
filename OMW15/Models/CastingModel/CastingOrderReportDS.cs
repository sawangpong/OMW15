using OMControls;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OMW15.Models.CastingModel
{
	public class CastingOrderReportDS : List<CastingOrderReportDataItem>
	{
		private readonly OLDMOONEF1 _om;
		public CastingOrderReportDS()
		{
			_om = new OLDMOONEF1();
		}

		public CastingOrderReportDS(int JobOrder)
		{
			_om = new OLDMOONEF1();
			GetCastingJobOrderRecords(JobOrder);
		}

		#region class private method

		private void GetCastingJobOrderRecords(int JobNo)
		{
			var _source = GetJobPrintingRecord(JobNo);
			foreach (DataRow dr in _source.Rows)
				Add(new CastingOrderReportDataItem(dr));

		} // end GetCastingJobOrderRecords

		#endregion

		#region class public method

		public async Task<int> GetNumberOfQCJob(int Status, string JobCategory, string CustomerCode)
		{
			return await Task.Run(() =>
			{
				var _n = 0;
				var _j = _om.JOBORDERS.Where(x => x.STATUS == Status).ToList();

				if (JobCategory != "" && CustomerCode != "")
					_n = _j.Where(x => x.PREFIX == JobCategory).Where(x => x.CUSTCODE == CustomerCode).AsParallel().ToList().Count();
				else if (JobCategory == "" && CustomerCode != "")
					_n = _j.Where(x => x.CUSTCODE == CustomerCode).AsParallel().ToList().Count();
				else if (JobCategory != "" && CustomerCode == "")
					_j.Where(x => x.PREFIX == JobCategory).AsParallel().ToList().Count();

				return _n;
			});
		} // end GetNumberOfQCJob

		//public async Task<DataTable> GetActiveQCJob(int Status, string JobCategory, string CustomerCode, int[] JobList)
		//{
		//	return await Task.Run(() =>
		//	{
		//		var _result = new DataTable();
		//		var job = (from j in _om.JOBORDERS
		//				   join c in _om.CUSTPRICELISTs on j.ITEMID equals c.PRICESEQ
		//				   join ct in _om.CUSTOMERS on j.CUSTCODE equals ct.CUSTCODE
		//				   join m in _om.SYSDATAs on j.MATERIALTYPE.ToString() equals m.KEYVALUE
		//				   where j.STATUS == Status
		//						 && j.ISCANCEL == false
		//						 && m.GROUPTITLE == "MATERIAL"
		//				   select new
		//				   {
		//					   j.CUSTCODE,
		//					   ct.CUSTNAME,
		//					   WORKTYPE = j.ISREWORKS ? "งานซ่อม" : "ปรกติ",
		//					   STATUS =
		//					   j.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
		//						   ? OMShareJobEnums.JobStatusEnumEN.Active.ToString()
		//						   : OMShareJobEnums.JobStatusEnumEN.Closed.ToString(),
		//					   j.CUSTPO,
		//					   j.JOBNO,
		//					   j.JOBDATE,
		//					   j.DUEDATE,
		//					   JOBCAT =
		//				   j.PREFIX == "R" ? "ฉีด/หล่อ" : (j.PREFIX == "W" ? "หล่อแวกส์" : (j.PREFIX == "S" ? "ให้เทียน" : (j.PREFIX == "P" ? "3D เรซิ่น" : "ทำก้อนยาง"))),
		//					   j.ISPRICEWITHMAT,
		//					   j.PREFIX,
		//					   j.ITEMNO,
		//					   ITEMNUMBER = "[" + j.PREFIX + "]" + j.ITEMNO,
		//					   j.ITEMNAME,
		//					   MATERIAL = m.THKEYNAME,
		//					   j.ORDERUNIT,
		//					   j.ORDERQTY,
		//					   j.REMARK,
		//					   c.IMAGE_LOCATION
		//				   }).AsEnumerable().Select(x => new
		//				   {
		//					   x.CUSTCODE,
		//					   x.CUSTNAME,
		//					   x.WORKTYPE,
		//					   x.STATUS,
		//					   x.CUSTPO,
		//					   x.JOBNO,
		//					   JOBDATE = x.JOBDATE.Num2Date(),
		//					   DUEDATE = x.DUEDATE.Num2Date(),
		//					   x.JOBCAT,
		//					   x.ISPRICEWITHMAT,
		//					   x.PREFIX,
		//					   x.ITEMNO,
		//					   x.ITEMNUMBER,
		//					   x.ITEMNAME,
		//					   x.MATERIAL,
		//					   x.ORDERUNIT,
		//					   x.ORDERQTY,
		//					   x.REMARK,
		//					   PICTURE = PriceListDAL.GetPriceListItemPicture(x.IMAGE_LOCATION).ConvertImage2Byte()
		//				   }).OrderBy(o => o.JOBNO).AsParallel();

		//		if (job != null)
		//			_result = job.Where(x => JobList.Contains(x.JOBNO)).AsParallel().ToDataTable();

		//		return _result;
		//	});

		//} // end GetActiveQCJob

		public DataTable GetJobQCList(int Status)
		{
			var _result = new DataTable();
			var job = (from j in _om.JOBORDERS.AsEnumerable()
					   join ct in _om.CUSTOMERS on j.CUSTCODE equals ct.CUSTCODE
					   join m in _om.SYSDATAs on j.MATERIALTYPE.ToString() equals m.KEYVALUE
					   orderby j.JOBNO
					   where j.ISCANCEL == false
							 && j.STATUS == Status
							 && m.GROUPTITLE == "MATERIAL"
					   select new
					   {
						   PRIORITYCLASS = priorityName(j.PRIORITY),
						   STATUS =
						   j.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
							   ? OMShareJobEnums.JobStatusEnumEN.Active.ToString()
							   : OMShareJobEnums.JobStatusEnumEN.Closed.ToString(),
						   j.PREFIX,
						   JOBCAT =
						   j.PREFIX == "R" ? "ฉีด/หล่อ" : (j.PREFIX == "W" ? "หล่อแวกส์" : (j.PREFIX == "S" ? "ให้เทียน" : (j.PREFIX == "P" ? "3D เรซิ่น" : "ทำก้อนยาง"))),
						   j.CUSTCODE,
						   ct.CUSTNAME,
						   WORKTYPE = j.ISREWORKS ? "งานซ่อม" : "ปรกติ",
						   j.CUSTPO,
						   j.JOBNO,
						   OpenDate = j.JOBDATE.Num2Date(),
						   Due = j.DUEDATE.Num2Date(),
						   j.ITEMNO,
						   ITEMNUMBER = "[" + j.PREFIX + "]" + j.ITEMNO,
						   j.ITEMNAME,
						   MATERIAL = m.THKEYNAME,
						   j.ORDERUNIT,
						   j.ORDERQTY,
						   j.REMARK
					   }).AsParallel();

			_result = job.ToDataTable();

			return _result;

		} // end GetJobQCList


		public async Task<DataTable> GetJobList(int Status, string JobCategory, string CustomerCode)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				var job = (from j in _om.JOBORDERS.AsEnumerable()
						   join ct in _om.CUSTOMERS on j.CUSTCODE equals ct.CUSTCODE
						   join m in _om.SYSDATAs on j.MATERIALTYPE.ToString() equals m.KEYVALUE
						   orderby j.PRIORITY, j.JOBNO
						   where j.STATUS == Status
								 && j.ISCANCEL == false
								 && m.GROUPTITLE == "MATERIAL"
						   select new
						   {
							   PRIORITYCLASS = priorityName(j.PRIORITY),
							   STATUS =
							   j.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
								   ? OMShareJobEnums.JobStatusEnumEN.Active.ToString()
								   : OMShareJobEnums.JobStatusEnumEN.Closed.ToString(),
							   j.PREFIX,
							   JOBCAT =
							   j.PREFIX == "R" ? "ฉีด/หล่อ" : (j.PREFIX == "W" ? "หล่อแวกส์" : (j.PREFIX == "S" ? "ให้เทียน" : (j.PREFIX == "P" ? "3D เรซิ่น" : "ทำก้อนยาง"))),
							   j.CUSTCODE,
							   ct.CUSTNAME,
							   WORKTYPE = j.ISREWORKS ? "งานซ่อม" : "ปรกติ",
							   j.CUSTPO,
							   j.JOBNO,
							   OpenDate = j.JOBDATE.Num2Date(),
							   Due = j.DUEDATE.Num2Date(),
							   j.ITEMNO,
							   ITEMNUMBER = "[" + j.PREFIX + "]" + j.ITEMNO,
							   j.ITEMNAME,
							   MATERIAL = m.THKEYNAME,
							   j.ORDERUNIT,
							   j.ORDERQTY,
							   j.REMARK
						   }).AsParallel();

				if (JobCategory == "" && CustomerCode == "")
					_result = job.ToDataTable();
				else if (JobCategory != "" && CustomerCode != "")
					_result = job.Where(x => x.PREFIX == JobCategory).Where(x => x.CUSTCODE == CustomerCode).AsParallel().ToDataTable();
				else if (JobCategory != "" && CustomerCode == "")
					_result = job.Where(x => x.PREFIX == JobCategory).AsParallel().ToDataTable();
				else if (JobCategory == "" && CustomerCode != "")
					_result = job.Where(x => x.CUSTCODE == CustomerCode).AsParallel().ToDataTable();

				return _result;
			});
		} // end GetJobQCList

		public DataTable GetActiveQCJob(int Status, int[] JobList)
		{
			var _result = new DataTable();
			var job = (from j in _om.JOBORDERS
					   join c in _om.CUSTPRICELISTs on j.ITEMID equals c.PRICESEQ
					   join ct in _om.CUSTOMERS on j.CUSTCODE equals ct.CUSTCODE
					   join m in _om.SYSDATAs on j.MATERIALTYPE.ToString() equals m.KEYVALUE
					   where j.STATUS == Status
							 && j.ISCANCEL == false
							 && m.GROUPTITLE == "MATERIAL"
					   select new
					   {
						   j.CUSTCODE,
						   ct.CUSTNAME,
						   WORKTYPE = j.ISREWORKS ? "งานซ่อม" : "ปรกติ",
						   j.PRIORITY,
						   STATUS =
						   j.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
							   ? OMShareJobEnums.JobStatusEnumEN.Active.ToString()
							   : OMShareJobEnums.JobStatusEnumEN.Closed.ToString(),
						   j.CUSTPO,
						   j.JOBNO,
						   j.JOBDATE,
						   j.DUEDATE,
						   JOBCAT =
						   j.PREFIX == "R" ? "ฉีด/หล่อ" : (j.PREFIX == "W" ? "หล่อแวกส์" : (j.PREFIX == "S" ? "ให้เทียน" : (j.PREFIX =="P" ? "3D เรซิ่น" : "ทำก้อนยาง"))),
						   j.ISPRICEWITHMAT,
						   j.PREFIX,
						   j.ITEMNO,
						   ITEMNUMBER = "[" + j.PREFIX + "]" + j.ITEMNO,
						   j.ITEMNAME,
						   MATERIAL = m.THKEYNAME,
						   j.ORDERUNIT,
						   j.ORDERQTY,
						   j.REMARK,
						   j.FLASK_TEMP,
						   j.CAST_TEMP,
						   c.IMAGE_LOCATION
					   }).AsEnumerable().Select(x => new
					   {
						   x.CUSTCODE,
						   x.CUSTNAME,
						   x.WORKTYPE,
						   PRIORITYCLASS = priorityName(x.PRIORITY),
						   x.STATUS,
						   x.CUSTPO,
						   x.JOBNO,
						   JOBDATE = x.JOBDATE.Num2Date(),
						   DUEDATE = x.DUEDATE.Num2Date(),
						   x.JOBCAT,
						   x.ISPRICEWITHMAT,
						   x.PREFIX,
						   x.ITEMNO,
						   x.ITEMNUMBER,
						   x.ITEMNAME,
						   x.MATERIAL,
						   x.ORDERUNIT,
						   x.ORDERQTY,
						   FlaskTemp = x.FLASK_TEMP,
						   CastTemp = x.CAST_TEMP,
						   x.REMARK,
						   PICTURE = PriceListDAL.GetPriceListItemPicture(x.IMAGE_LOCATION).ConvertImage2Byte()
					   }).OrderBy(o => o.JOBNO).AsParallel();

			if (job != null)
				_result = job.Where(x => JobList.Contains(x.JOBNO)).AsParallel().ToDataTable();

			return _result;
		} // end GetActiveQCJob

		// print all record list
		public async Task<DataTable> GetJobPrintingRecords(int[] JobNo)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				int[] status = { 1, 2 };
				var job = (from j in _om.JOBORDERS.AsEnumerable()
						   join c in _om.CUSTPRICELISTs on j.ITEMID equals c.PRICESEQ
						   join ct in _om.CUSTOMERS on j.CUSTCODE equals ct.CUSTCODE
						   join m in _om.SYSDATAs on j.MATERIALTYPE.ToString() equals m.KEYVALUE
						   where JobNo.Contains(j.JOBNO)
								 && j.ISCANCEL == false
								 && m.GROUPTITLE == "MATERIAL"
								 && status.Contains(j.STATUS)
						   select new
						   {
							   j.ISREWORKS,
							   j.PRIORITY,
							   j.CUSTCODE,
							   ct.CUSTNAME,
							   WORKTYPE = j.ISREWORKS ? "งานซ่อม" : "ปรกติ",
							   STATUS =
							   j.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
								   ? OMShareJobEnums.JobStatusEnumEN.Active.ToString()
								   : OMShareJobEnums.JobStatusEnumEN.Closed.ToString(),
							   j.CUSTPO,
							   j.JOBNO,
							   j.JOBDATE,
							   j.DUEDATE,
							   JOBCAT =
							   j.PREFIX == "R" ? "ฉีด/หล่อ" : (j.PREFIX == "W" ? "หล่อแวกส์" : (j.PREFIX == "S" ? "ให้เทียน" : (j.PREFIX == "P" ? "3D เรซิ่น" : "ทำก้อนยาง"))),
							   j.ISPRICEWITHMAT,
							   j.PREFIX,
							   j.ITEMNO,
							   ITEMNUMBER = "[" + j.PREFIX + "]" + j.ITEMNO,
							   j.ITEMNAME,
							   MATERIAL = m.THKEYNAME,
							   FlaskTemp = j.FLASK_TEMP,
							   CastTemp = j.CAST_TEMP,
							   j.ORDERUNIT,
							   j.ORDERQTY,
							   j.REMARK,
							   c.IMAGE_LOCATION
						   }).AsEnumerable().Select(x => new
						   {
							   x.ISREWORKS,
							   x.CUSTCODE,
							   x.CUSTNAME,
							   x.WORKTYPE,
							   PRIORITYCLASS = priorityName(x.PRIORITY),
							   x.STATUS,
							   x.CUSTPO,
							   x.JOBNO,
							   JOBDATE = x.JOBDATE.Num2Date(),
							   DUEDATE = x.DUEDATE.Num2Date(),
							   x.JOBCAT,
							   x.ISPRICEWITHMAT,
							   x.PREFIX,
							   x.ITEMNO,
							   x.ITEMNUMBER,
							   x.ITEMNAME,
							   x.MATERIAL,
							   x.FlaskTemp,
							   x.CastTemp,
							   x.ORDERUNIT,
							   x.ORDERQTY,
							   x.REMARK,
							   PICTURE = PriceListDAL.GetPriceListItemPicture(x.IMAGE_LOCATION).ConvertImage2Byte(),
							   BarCode = Barcode.GetBarcode(x.JOBNO.ToString())
						   }).OrderBy(o => o.JOBNO).AsParallel();

				if (job != null)
					_result = job.ToDataTable();

				return _result;
			});
		} // end GetJobPrintingRecords

		private string priorityName(int priority)
		{
			return new JobDAL().getJobPriority(priority);
		}


		// print only one record
		public DataTable GetJobPrintingRecord(int JobNo)
		{
			var _result = new DataTable();
			int[] status = { 1, 2 };
			var job = (from j in _om.JOBORDERS.AsEnumerable()
					   join c in _om.CUSTPRICELISTs on j.ITEMID equals c.PRICESEQ
					   join ct in _om.CUSTOMERS on j.CUSTCODE equals ct.CUSTCODE
					   join m in _om.SYSDATAs on j.MATERIALTYPE.ToString() equals m.KEYVALUE
					   where j.JOBNO == JobNo
							 && j.ISCANCEL == false
							 && m.GROUPTITLE == "MATERIAL"
							 && status.Contains(j.STATUS)
					   select new
					   {
						   j.ISREWORKS,
						   j.PRIORITY,
						   j.CUSTCODE,
						   ct.CUSTNAME,
						   WORKTYPE = j.ISREWORKS ? "งานซ่อม" : "ปรกติ",
						   STATUS =
						   j.STATUS == (int)OMShareJobEnums.JobStatusEnumEN.Active
							   ? OMShareJobEnums.JobStatusEnumEN.Active.ToString()
							   : OMShareJobEnums.JobStatusEnumEN.Closed.ToString(),
						   j.CUSTPO,
						   j.JOBNO,
						   j.JOBDATE,
						   j.DUEDATE,
						   JOBCAT =
						   j.PREFIX == "R" ? "ฉีด/หล่อ" : (j.PREFIX == "W" ? "หล่อแวกส์" : (j.PREFIX == "S" ? "ให้เทียน" : (j.PREFIX == "P" ? "3D เรซิ่น" :"ทำก้อนยาง"))),
						   j.ISPRICEWITHMAT,
						   j.PREFIX,
						   j.ITEMNO,
						   ITEMNUMBER = "[" + j.PREFIX + "]" + j.ITEMNO,
						   j.ITEMNAME,
						   MATERIAL = m.THKEYNAME,
						   FlaskTemp = j.FLASK_TEMP,
						   CastTemp = j.CAST_TEMP,
						   j.ORDERUNIT,
						   j.ORDERQTY,
						   j.REMARK,
						   c.IMAGE_LOCATION
					   }).AsEnumerable().Select(x => new
					   {
						   x.ISREWORKS,
						   PRIORITYCLASS = priorityName(x.PRIORITY),
						   x.CUSTCODE,
						   x.CUSTNAME,
						   x.WORKTYPE,
						   x.STATUS,
						   x.CUSTPO,
						   x.JOBNO,
						   JOBDATE = x.JOBDATE.Num2Date(),
						   DUEDATE = x.DUEDATE.Num2Date(),
						   x.JOBCAT,
						   x.ISPRICEWITHMAT,
						   x.PREFIX,
						   x.ITEMNO,
						   x.ITEMNUMBER,
						   x.ITEMNAME,
						   x.MATERIAL,
						   x.FlaskTemp,
						   x.CastTemp,
						   x.ORDERUNIT,
						   x.ORDERQTY,
						   x.REMARK,
						   PICTURE = OMUtils.ConvertImage2Byte(PriceListDAL.GetPriceListItemPicture(x.IMAGE_LOCATION)),
						   BarCode = Barcode.GetBarcode(x.JOBNO.ToString())
					   }).OrderBy(o => o.JOBNO).AsParallel();

			if (job != null)
				_result = job.ToDataTable();

			return _result;
		} // end GetJobPrintingRecord

		#endregion

		#region CastingOrderReportDataSource

		public async Task<DataTable> GetAsyncCastingSaleOrderReportDataSource(PrintDocumentType ReportType, int YearReport,
			int MonthReport)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				var _source = from so in _om.SALEORDERS.AsEnumerable()
							  join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
							  join s in _om.SYSDATAs on so.DELIVERMAT.ToString() equals s.KEYVALUE
							  where so.ISDELETE == false
									&& so.ISCANCEL == false
									&& s.GROUPTITLE == "MATERIAL"
									&& so.SODATE.Num2Date().Year == YearReport
									&& so.SODATE.Num2Date().Month == MonthReport
							  select new
							  {
								  so.ISVAT,
								  SALEGROUPID =
								  so.SALETYPE == (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
									  ? (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
									  : (int)OMShareCastingEnums.SaleTypeEnum.ค่าบริการ,
								  SALEGROUPNAME = Enum.GetName(typeof(OMShareCastingEnums.SaleTypeEnum), so.SALETYPE),
								  so.SALETYPE,
								  so.SONO,
								  SIDate = so.SODATE.Num2Date(),
								  so.CUSTCODE,
								  c.CUSTNAME,
								  so.TOTALVALUE,
								  so.DISCOUNT,
								  so.NETVALUE,
								  so.VATVALUE,
								  so.TOTALAMOUNT,
								  s.CATEGORY,
								  MATERIAL = s.THKEYNAME,
								  so.DELIVERWEIGHT,
								  SIWEIGHT = so.DELIVERWEIGHT * (s.SI / 100.00m)
							  };


				switch (ReportType)
				{
					case PrintDocumentType.CastingMonthlyReportByCustomerAndMaterial:
						_source.OrderBy(o => o.SALEGROUPID)
							.ThenBy(o => o.SALETYPE)
							.ThenBy(o => o.CATEGORY)
							.ThenBy(o => o.MATERIAL)
							.ThenBy(o => o.CUSTNAME)
							.ThenBy(o => o.SONO)
							.AsParallel();
						break;

					case PrintDocumentType.CastingMonthlyReportByCustomerGroup:
						_source.OrderBy(o => o.CUSTNAME).ThenBy(o => o.SALETYPE).ThenBy(o => o.SONO).AsParallel();
						break;

					case PrintDocumentType.CastingMonthlyReportByDocNo:
						_source.OrderBy(o => o.SONO).ThenBy(o => o.SALETYPE).AsParallel();
						break;
				}

				if (omglobal.NONVAT_DISPLAY)
				{
					return _source.ToDataTable();
				}
				else
				{
					return _source.Where(v => v.ISVAT == true).ToDataTable();
				}
			});
		} // end GetAsyncCastingSaleOrderRoptDataSource


		public async Task<DataTable> GetAsyncCastingSaleMaterialReportDataSource(PrintDocumentType ReportType, int YearReport,
			int MonthReport)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				var _source = from so in _om.SALEORDERS.AsEnumerable()
							  join sl in _om.SOLINES.AsEnumerable() on so.SOSEQ equals sl.SOSEQ
							  join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
							  join s in _om.SYSDATAs on so.DELIVERMAT.ToString() equals s.KEYVALUE
							  where so.ISDELETE == false
									&& so.ISCANCEL == false
									&& s.GROUPTITLE == "MATERIAL"
									&& so.SALETYPE == (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
									&& so.SODATE.Num2Date().Year == YearReport
									&& so.SODATE.Num2Date().Month == MonthReport
							  select new
							  {
								  SALEGROUPID =
								  so.SALETYPE == (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
									  ? (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
									  : (int)OMShareCastingEnums.SaleTypeEnum.ค่าบริการ,
								  SALEGROUPNAME = Enum.GetName(typeof(OMShareCastingEnums.SaleTypeEnum), so.SALETYPE),
								  so.SALETYPE,
								  so.SONO,
								  SIDate = so.SODATE.Num2Date(),
								  so.CUSTCODE,
								  c.CUSTNAME,
								  sl.UNIT,
								  sl.UNITPRICE,
								  sl.DELIVEREDQTY,
								  so.TOTALVALUE,
								  so.DISCOUNT,
								  so.NETVALUE,
								  so.VATVALUE,
								  so.TOTALAMOUNT,
								  s.CATEGORY,
								  MATERIAL = s.THKEYNAME,
								  so.DELIVERWEIGHT,
								  SIWEIGHT = so.DELIVERWEIGHT * (s.SI / 100.00m)
							  };


				switch (ReportType)
				{
					case PrintDocumentType.CastingMonthlySaleMaterialReport:
						_source.OrderBy(o => o.CATEGORY).ThenBy(o => o.SONO).ThenBy(o => o.CUSTNAME).AsParallel();
						break;
				}

				return _source.ToDataTable();
			});
		} // end GetAsyncCastingSaleMaterialReportDataSource

		public async Task<DataTable> GetCastingWorkSummaryAsync(int YearReport)
		{
			return await Task.Run(() =>
			{
				return new DataConnect($"EXEC dbo.usp_OM_CASTING_WORK_SCORE @workyear={YearReport}", omglobal.SysConnectionString).ToDataTable;
			});
		}



		#endregion
	}
}