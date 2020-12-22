using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingController
{
	public class MaterialDAL 
	{
		private OLDMOONEF _om;
		private bool disposed = false;
		#region constructor and destructor
		public MaterialDAL()
		{
			_om = new OLDMOONEF();
		}

		//protected virtual void Dispose(bool disposing)
		//{
		//	if (disposed)
		//	{
		//		return;
		//	}

		//	if (disposing)
		//	{
		//		// Free any other managed objects here. 
		//		_om.Dispose();
		//	}

		//	// Free any unmanaged objects here. 
		//	//
		//	disposed = true;
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}

		//~MaterialDAL()
		//{
		//	Dispose(true);
		//}

		#endregion

		public DataTable GetMaterialForSaleList()
		{
			DataTable _result;
			var mats = from m in _om.MATSALEs.AsParallel()
					   orderby m.MATNAME
					   select new
					   {
						   m.MATID,
						   m.MATNAME
					   };
			_result = OMControls.OMDataUtils.ToDataTable(mats.ToList());

			return _result;

		} // end GetMaterialForSaleList

		public DataTable GetMaterialYearSale()
		{
			DataTable _result;
			var _matYearSale = (from y in _om.MATPRICES.AsParallel()
								orderby y.FISCYEAR descending
								select new
								{
									FiscYear = y.FISCYEAR.Value
								}).Distinct();
			_result = OMControls.OMDataUtils.ToDataTable(_matYearSale.ToList());
			return _result;

		} // end GetMaterialYearSale

		public DataTable GetMaterialPriceRecords(int YearSale, int MaterialId)
		{
			DataTable _result = new DataTable();
			var mp = from m in _om.MATPRICES.AsParallel()
					 where m.FISCYEAR == YearSale
					 && m.MATID == MaterialId
					 orderby m.PRICEDATE descending
					 select new
					 {
						 m.SEQ,
						 PriceDate = OMControls.OMUtils.Num2Date((object)m.PRICEDATE.Value),
						 PriceTHGram = m.PRICETHBGRAM.Value
					 };
			if (mp != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(mp);
			}
			else
			{
				_result = null;
			}

			return _result;

		} // end GetMaterialPriceRecords

		public DataTable GetMaterialPriceAVGByMonth(int YearSale, int MaterialId)
		{
			DataTable _result = new DataTable();
			var _mavg = (from mp in _om.MATPRICES.AsParallel()
						 where mp.FISCYEAR == YearSale
						 && mp.MATID == MaterialId
						 group mp by mp.FISCPERIOD into mpavg
						 orderby mpavg.Key
						 select new
						 {
							 Month = Microsoft.VisualBasic.DateAndTime.MonthName((int)mpavg.Key, false),
							 YAVG = mpavg.Average(ii => ii.PRICETHBGRAM.Value)
						 }).ToList();

			if (_mavg != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(_mavg);
			}
			else
			{
				_result = null;
			}
			return _result;

		} // end GetMaterialPriceAVGByMonth

		public Decimal GetMaterialPriceAVGByYear(int YearSale, int MaterialId)
		{
			Decimal _result = 0.00m;
			var _mavg = (from mp in _om.MATPRICES.AsParallel()
						 where mp.FISCYEAR == YearSale
						 && mp.MATID == MaterialId
						 group mp by mp.MATID into mpavg
						 select new
						 {
							 YAVG = mpavg.Average(ii => ii.PRICETHBGRAM.Value)
						 }).FirstOrDefault();

			if (_mavg != null)
			{
				_result = (decimal)_mavg.YAVG;
			}
			return _result;

		} // end GetMaterialPriceAVGByYear

		public MATPRICE GetMatPriceRecordInfo(int Id)
		{
			return _om.MATPRICES.FirstOrDefault(x => x.SEQ == Id);
		} // end GetMatPriceRecordInfo


		public DataTable GetExchangeRateList(string Currency, int FiscYear, int FiscPeriod)
		{
			DataTable _result = new DataTable();
			var _exhr = from ex in _om.EXCHCURRs.AsParallel()
						where ex.CURRENCY == Currency
						&& ex.FISCYEAR == FiscYear
						&& ex.FISCPERIOD == FiscPeriod
						orderby ex.EFFECTIVEDT descending
						select new
						{
							EFFECTDATE = OMControls.OMUtils.Num2Date((object)ex.EFFECTIVEDT),
							ex.EXCHANGERATE
						};

			if (_exhr != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(_exhr);
			}
			else
			{
				_result = null;
			}

			return _result;

		} // end GetExchangeRateList

		public int InsertMatPrice(MATPRICE MatPriceRecord)
		{
			int _result = 0;

			using (var _scope = new System.Transactions.TransactionScope())
			{
				try
				{
					_om.MATPRICES.Add(MatPriceRecord);
					_result = _om.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Insert Record Failed.....", ex);
				}
			}

			return _result;

		} // end InsertMatPrice

		public int UpdateMatPrice(MATPRICE MatPriceRecord, int Id)
		{
			int _result = 0;

			using (var _scope = new System.Transactions.TransactionScope())
			{
				try
				{
					var mp = (from m in _om.MATPRICES
							  where m.SEQ == Id
							  select m).FirstOrDefault();
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
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Update Record Failed.....", ex);
				}
			}

			return _result;

		} // end UpdateMatPrice

		public DataTable GetMaterialCategory()
		{
			DataTable _result = new DataTable();
			var cat = (from c in _om.SYSDATAs
					   where c.GROUPTITLE == "MATERIAL"
					   select new
					   {
						   c.CATEGORY
					   }).Distinct().AsParallel();

			if (cat != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(cat.ToList());
			}
			else
			{
				_result = null;
			}

			return _result;
		} // end GetMaterialCategory


		public DataTable GetCastingMaterial(string MaterialCategory)
		{
			DataTable _result = new DataTable();

			var mat = from m in _om.SYSDATAs.AsParallel()
					  where m.CATEGORY == MaterialCategory
					  && m.GROUPTITLE == "MATERIAL"
					  select new
					  {
						  m.LINESEQ,
						  m.KEYVALUE,
						  m.ENKEYNAME,
						  MaterialName = m.ENKEYNAME + "  (" + m.THKEYNAME + ")",
						  m.CONVERTFACTOR,
						  m.MATFACTOR,
						  m.FURNACETEMP,
						  m.CASTINGTEMP
					  };

			if (mat != null)
			{
				_result = OMControls.OMDataUtils.ToDataTable(mat.ToList());
			}
			else
			{
				_result = null;
			}

			return _result;

		} // end GetCastingMaterial

		public SYSDATA GetMaterialInfo(int RecordId)
		{
			return _om.SYSDATAs.FirstOrDefault(x => x.LINESEQ == RecordId);

		} // end GetMaterialInfo

		public int InsertCastingMaterialInfo(SYSDATA MaterialInfo)
		{
			int _result = 0;
			using (var _scope = new System.Transactions.TransactionScope())
			{
				try
				{
					_om.SYSDATAs.Add(MaterialInfo);
					_result = _om.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Insert Material Info Record Failed.....", ex);
				}
			}

			return _result;

		} // end InsertCastingMaterialInfo

		public int UpdateCastingMaterialInformation(SYSDATA MaterialInfo, int RecordId)
		{
			int _result = 0;
			using (var _scope = new System.Transactions.TransactionScope())
			{
				try
				{
					SYSDATA mi = _om.SYSDATAs.FirstOrDefault(x => x.LINESEQ == RecordId);
					mi.CASTINGTEMP = MaterialInfo.CASTINGTEMP;
					mi.CONVERTFACTOR = MaterialInfo.CONVERTFACTOR;
					mi.ENKEYNAME = MaterialInfo.ENKEYNAME;
					mi.FURNACETEMP = MaterialInfo.FURNACETEMP;
					mi.MATFACTOR = MaterialInfo.MATFACTOR;
					mi.THKEYNAME = MaterialInfo.THKEYNAME;
					mi.SI = MaterialInfo.SI;

					_result = _om.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Update Material Info Record Failed.....", ex);
				}
			}

			return _result;

		} // end UpdateCastingMaterialInformation

		public int GetMaxIndexForMaterial(string GroupName)
		{
			int _result = 0;
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
			SYSDATA mat = _om.SYSDATAs.FirstOrDefault(x => x.GROUPTITLE == "MATERIAL" && x.KEYVALUE == MatId.ToString());
			MatConvertFactor = mat.CONVERTFACTOR;
			MatGroup = mat.CATEGORY;
			return mat.THKEYNAME;
		} // end FindMaterialName

	}
}
