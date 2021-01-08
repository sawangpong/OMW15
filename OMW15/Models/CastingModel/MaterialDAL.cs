using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;

namespace OMW15.Models.CastingModel
{
	public class MaterialDAL
	{
		private readonly OLDMOONEF1 _om;

		#region constructor and destructor

		public MaterialDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		public DataTable GetMaterialLisyInfoByCustomer(string customerCode)
		{
			var _result = new DataTable();

			var _ml = (from m in _om.SYSDATAs
						  join f in
						  (from fg in _om.FGSTOCKs
							orderby fg.MATID
							where fg.ISCOMPLETION == false
						 && fg.CUSTCODE == customerCode
							select new
							{
								fg.MATID
							}).Distinct()
						  on m.KEYVALUE equals f.MATID.ToString()
						  where m.GROUPTITLE == "MATERIAL"
						  select new
						  {
							  MaterialId = f.MATID,
							  Material = m.THKEYNAME,
							  Category = m.CATEGORY,
							  m.SI,
							  Factor = m.CONVERTFACTOR
						  }).OrderBy(x => x.Material);

			if (_ml != null)
				_result = _ml.ToDataTable();

			return _result;
		} // end GetMaterialLisyInfoByCustomer

		public DataTable GetMaterialLisyInfoByCustomer(string customerCode, string materialCategory)
		{
			var _result = new DataTable();

			var _ml = from m in _om.SYSDATAs
						 orderby m.THKEYNAME
						 where m.GROUPTITLE == "MATERIAL" && m.CATEGORY == materialCategory
						 select new
						 {
							 MaterialId = m.KEYVALUE,
							 Material = m.THKEYNAME,
							 Category = m.CATEGORY,
							 m.SI,
							 Factor = m.CONVERTFACTOR
						 };

			if (_ml != null)
				_result = _ml.ToDataTable();

			return _result;
		} // end GetMaterialLisyInfoByCustomer

		public string GetMaterialCategoryForSell(int MaterialId)
		{
			return
				_om.SYSDATAs.Single(x => x.GROUPTITLE == "MATERIAL" && x.KEYVALUE.ToString() == MaterialId.ToString()).CATEGORY;
		} // end GetMaterialCategoryForSell


		public DataTable GetMaterialForSaleList()
		{
			DataTable _result;
			var mats = (from m in _om.MATSALEs
							orderby m.MATNAME
							select new
							{
								m.MATID,
								m.MATNAME
							}).AsParallel();

			_result = mats.ToDataTable();

			return _result;
		} // end GetMaterialForSaleList

		public DataTable GetMaterialYearSale()
		{
			DataTable result = new DataTable();
			var matYearSale = (from y in _om.MATPRICES
									 select new
									 {
										 FiscYear = y.FISCYEAR.Value
									 }).Distinct().OrderByDescending(o => o.FiscYear).AsParallel();
			result = matYearSale.ToDataTable();
			return result;
		} // end GetMaterialYearSale

		public DataTable GetMaterialPriceRecords(int yearSale, int materialId)
		{
			var _result = new DataTable();
			var mp = from m in _om.MATPRICES.AsEnumerable()
						where m.FISCYEAR == yearSale
							  && m.MATID == materialId
						orderby m.PRICEDATE descending
						select new
						{
							m.SEQ,
							PriceDate = m.PRICEDATE.Value.Num2Date(),
							PriceTHGram = m.PRICETHBGRAM.Value
						};
			if (mp != null)
			{
				_result = mp.ToDataTable();
			}

			return _result;
		} // end GetMaterialPriceRecords

		public DataTable GetMaterialPriceRecords(int yearSale, int monthSale, int materialId)
		{
			var _result = new DataTable();

			var mp = (from m in _om.MATPRICES.AsEnumerable()
						 where m.FISCYEAR == yearSale
							  && m.FISCPERIOD == monthSale
							  && m.MATID == materialId
						 group m by m.EXCHDATE
				into md
						 select new
						 {
							 PriceDate = md.Key.Value.Num2Date(),
							 PriceTHGram = md.Max(x => x.PRICETHBGRAM.Value)
						 }).OrderByDescending(x => x.PriceDate).AsParallel();

			if (mp != null)
				_result = mp.ToDataTable();
			else
				_result = null;

			return _result;
		} // end GetMaterialPriceRecords


		public DataTable GetMaterialPriceAVGByMonth(int YearSale, int MaterialId)
		{
			var _result = new DataTable();
			var _mavg = (from mp in _om.MATPRICES.AsEnumerable()
							 where mp.FISCYEAR == YearSale
									&& mp.MATID == MaterialId
							 group mp by mp.FISCPERIOD
				into mpavg
							 orderby mpavg.Key
							 select new
							 {
								 Month = DateAndTime.MonthName((int)mpavg.Key, false),
								 YAVG = mpavg.Average(ii => ii.PRICETHBGRAM.Value)
							 }).AsParallel();

			if (_mavg != null)
				_result = _mavg.ToDataTable();
			else
				_result = null;
			return _result;
		} // end GetMaterialPriceAVGByMonth

		public decimal GetMaterialPriceAvgByYear(int yearSale, int materialId)
		{
			Decimal result = 0.00m;
			var priceAvg = (from mp in _om.MATPRICES
								 where mp.FISCYEAR == yearSale
										&& mp.MATID == materialId
								 group mp by mp.MATID
				into mpavg
								 select new
								 {
									 YAVG = mpavg.Average(ii => ii.PRICETHBGRAM.Value)
								 }).FirstOrDefault();

			if (priceAvg != null)
			{
				result = (decimal)priceAvg.YAVG;
			}
			return result;

		} // end GetMaterialPriceAVGByYear

		public MATPRICE GetMatPriceRecordInfo(int Id)
		{
			return _om.MATPRICES.Single(x => x.SEQ == Id);
		} // end GetMatPriceRecordInfo


		public DataTable GetExchangeRateList(string Currency, int FiscYear, int FiscPeriod)
		{
			var _result = new DataTable();
			var _exhr = from ex in _om.EXCHCURRs.AsEnumerable()
							where ex.CURRENCY == Currency
								  && ex.FISCYEAR == FiscYear
								  && ex.FISCPERIOD == FiscPeriod
							orderby ex.EFFECTIVEDT descending
							select new
							{
								EFFECTDATE = ex.EFFECTIVEDT.Num2Date(),
								ex.EXCHANGERATE
							};

			if (_exhr != null)
				_result = _exhr.ToDataTable();
			else
				_result = null;

			return _result;
		} // end GetExchangeRateList

		public int InsertMatPrice(MATPRICE MatPriceRecord)
		{
			var _result = 0;
			try
			{
				_om.MATPRICES.Add(MatPriceRecord);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Insert Record Failed.....", ex);
			}

			return _result;
		} // end InsertMatPrice

		public int UpdateMatPrice(MATPRICE MatPriceRecord, int Id)
		{
			var _result = 0;
			try
			{
				var mp = _om.MATPRICES.Single(x => x.SEQ == Id);
				mp.COSTTHBGRAM = MatPriceRecord.COSTTHBGRAM;
				mp.EXCHANGERATE = MatPriceRecord.EXCHANGERATE;
				mp.EXCHDATE = MatPriceRecord.EXCHDATE;
				mp.FISCPERIOD = MatPriceRecord.FISCPERIOD;
				mp.FISCYEAR = MatPriceRecord.FISCYEAR;
				mp.MATID = MatPriceRecord.MATID;
				mp.MODIDATE = MatPriceRecord.MODIDATE;
				mp.MODIUSER = MatPriceRecord.MODIUSER;
				mp.ORGPRICEUSD = MatPriceRecord.ORGPRICEUSD;
				mp.PRICEDATE = MatPriceRecord.PRICEDATE;
				mp.PRICETHBGRAM = MatPriceRecord.PRICETHBGRAM;
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Update Record Failed.....", ex);
			}

			return _result;
		} // end UpdateMatPrice

		public DataTable GetMaterialCategory()
		{
			return _om.SYSDATAs.Where(x => x.GROUPTITLE == "MATERIAL" && x.CATEGORY != "").Select(x => new
			{
				x.CATEGORY
			}).Distinct().OrderBy(o => o.CATEGORY).ToDataTable();
		} // end GetMaterialCategory


		public DataTable GetCastingMaterial(string MaterialCategory)
		{
			var _result = new DataTable();

			var mat = (from m in _om.SYSDATAs
						  where m.CATEGORY == MaterialCategory
								&& m.GROUPTITLE == "MATERIAL"
								&& m.CATEGORY != ""
						  select new
						  {
							  m.Inused,
							  m.LINESEQ,
							  m.KEYVALUE,
							  m.THKEYNAME,
							  MaterialName = m.ENKEYNAME + "  (" + m.THKEYNAME + ")",
							  m.CONVERTFACTOR,
							  m.MATFACTOR,
							  m.FURNACETEMP,
							  m.CASTINGTEMP
						  }).OrderBy(o => o.THKEYNAME).AsParallel();

			if (mat != null)
				_result = mat.ToDataTable();
			else
				_result = null;

			return _result;
		} // end GetCastingMaterial

		public SYSDATA GetMaterialInfo(int RecordId)
		{
			return _om.SYSDATAs.Single(x => x.LINESEQ == RecordId);
		} // end GetMaterialInfo

		public void GetMaterialInfoByMaterialId(int MaterialId, ref decimal SIPercent, ref decimal MatFactor)
		{
			var mat = (from m in _om.SYSDATAs
						  where m.GROUPTITLE == "MATERIAL"
								&& m.KEYVALUE == MaterialId.ToString()
						  select new
						  {
							  m.CONVERTFACTOR,
							  m.SI
						  }).AsParallel().FirstOrDefault();

			MatFactor = mat.CONVERTFACTOR;
			SIPercent = mat.SI;
		} // end GetMaterialInfoByMaterialId

		public int InsertCastingMaterialInfo(SYSDATA MaterialInfo)
		{
			var _result = 0;
			try
			{
				_om.SYSDATAs.Add(MaterialInfo);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Insert Material Info Record Failed.....", ex);
			}

			return _result;
		} // end InsertCastingMaterialInfo

		public int UpdateCastingMaterialInformation(SYSDATA MaterialInfo, int RecordId)
		{
			var _result = 0;
			try
			{
				var mi = _om.SYSDATAs.FirstOrDefault(x => x.LINESEQ == RecordId);
				mi.Inused = MaterialInfo.Inused;
				mi.CASTINGTEMP = MaterialInfo.CASTINGTEMP;
				mi.CONVERTFACTOR = MaterialInfo.CONVERTFACTOR;
				//mi.ENKEYNAME = MaterialInfo.ENKEYNAME;
				mi.FURNACETEMP = MaterialInfo.FURNACETEMP;
				mi.MATFACTOR = MaterialInfo.MATFACTOR;
				mi.THKEYNAME = MaterialInfo.THKEYNAME;
				mi.SI = MaterialInfo.SI;
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Update Material Info Record Failed.....", ex);
			}
			return _result;
		} // end UpdateCastingMaterialInformation

		public int GetMaxIndexForMaterial(string GroupName)
		{
			var _result = 0;
			try
			{
				var mat = (from m in _om.SYSDATAs
							  where m.GROUPTITLE == GroupName
							  select new
							  {
								  m.KEYVALUE
							  }).AsEnumerable().Select(x => new
							  {
								  Index = Convert.ToInt32(x.KEYVALUE)
							  }).Max(id => id.Index);
				_result = Convert.ToInt32(mat);
			}
			catch
			{
				_result = 0;
			}
			return _result;
		} // end GetMaxIndexForCastingMaterial

		public string FindMaterialName(int MatId, out string MatGroup, out decimal MatConvertFactor)
		{
			var mat = _om.SYSDATAs.SingleOrDefault(x => x.GROUPTITLE == "MATERIAL" && x.KEYVALUE == MatId.ToString());
			MatConvertFactor = mat.CONVERTFACTOR;
			MatGroup = mat.CATEGORY;
			return mat.THKEYNAME;
		} // end FindMaterialName

		public string GetMaterialNameById(int MaterialId)
		{
			return _om.SYSDATAs.Single(x => x.GROUPTITLE == "MATERIAL" && x.KEYVALUE == MaterialId.ToString()).THKEYNAME;
		} // end GetMaterialNameById
	}
}