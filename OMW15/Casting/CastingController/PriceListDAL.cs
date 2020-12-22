using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingController
{
	public class PriceListDAL 
	{
		private OLDMOONEF _om;

		#region constructor and destructor

		public PriceListDAL()
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
		//		// dispose managed resources
		//		_om.Dispose();
		//	}
		//	disposed = true;
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}

		//~PriceListDAL()
		//{
		//	Dispose(true);
		//}
		#endregion


		public int GetCustomerId(string CustomerCode)
		{
			int _result = 0;
			if (!string.IsNullOrEmpty(CustomerCode))
			{
				var _customer = (from c in _om.CUSTOMER1
								 where c.CUSTCODE == CustomerCode
								 select new
								 {
									 c.CUSTID
								 }).FirstOrDefault();
				_result = _customer.CUSTID;
			} // end
			return _result;
		}

		public static string GetCustomerName(string CustomerCode)
		{
			string _result = string.Empty;
			DataTable _dt = Tools.SelectOptions.GetCustomerData();
			foreach (DataRow _dr in _dt.Rows)
			{
				if (_dr["KEY"].ToString() == CustomerCode)
				{
					_result = _dr["VALUE"].ToString();
					break;
				}
			}

			return _result;

		} // end GetCustomerName

		public static Image GetPriceListItemPictureByItemNo(string ItemNo)
		{
			Image _result = null;
			string imgFileName = omglobal.IMAGE_LOCATION_PATH + "\\" + ItemNo + omglobal.IMAGE_EXTENSION;

			if (File.Exists(@imgFileName))
			{
				_result = Image.FromFile(@imgFileName);
			}
			return _result;

		} // end GetPriceListItemPictureByItemNo

		public static string CreateImageFilePath(string ItemNo)
		{
			return string.Format("{0}\\{1}{2}", omglobal.IMAGE_LOCATION_PATH, ItemNo, omglobal.IMAGE_EXTENSION);

		} // end CreateImageFilePath

		public static Image GetPriceListItemPicture(string ImageFilePath)
		{
			Image _result = null;
			try
			{
				if (File.Exists(@ImageFilePath))
				{
					//_result = Image.FromFile(@ImageFilePath,true);
					using (var fs = new System.IO.FileStream(@ImageFilePath, FileMode.Open, FileAccess.Read))
					{
						_result = System.Drawing.Image.FromStream(fs);
						//fs.Close();
					}
				}
			}
			catch
			{
				_result = null;
			}
			//return _result;
			return new Bitmap(_result);

		} // end GetPriceListItemPicture


		public CUSTPRICELIST GetCustomerPriceListItemInfo(int ItemId)
		{
			return _om.CUSTPRICELISTs.FirstOrDefault(x => x.PRICESEQ == ItemId);

		} // end GetCustomerPriceListItemInfo

		public DataTable GetPriceListByCustomer(string CustomerCode)
		{
			DataTable _result = new DataTable();

			// retrieve Material
			var _material = (from mat in _om.SYSDATAs.AsParallel()
							 where mat.GROUPTITLE == "MATERIAL"
							 orderby mat.KEYVALUE
							 select new
							 {
								 Id = mat.KEYVALUE,
								 Name = mat.THKEYNAME
							 }).ToList();

			// retrieve Product-Style
			var _styles = (from ps in _om.SYSDATAs.AsParallel()
						   where ps.GROUPTITLE == "PRODUCTSTYLE"
						   orderby ps.KEYVALUE
						   select new
						   {
							   Id = ps.KEYVALUE,
							   Name = ps.THKEYNAME
						   }).ToList();

			// retrieve item-code
			var _codes = (from code in _om.ITEMCODEs.AsParallel()
						  select new
						  {
							  prefix = code.ITEMCODE1,
							  prefixname = code.ITEMCODENAME_TH
						  }).ToList();

			// retrieve Price List
			var _priceLists = (from p in _om.CUSTPRICELISTs.AsParallel()
							   where p.CUSTCODE.Trim() == CustomerCode
							   && p.ISDELETE == false
							   orderby p.ITEMNO, p.PREFIX
							   select new
							   {
								   Id = p.PRICESEQ,
								   CustomerCode = p.CUSTCODE,
								   ItemCode = p.PREFIX,
								   ItemNo = p.ITEMNO,
								   ItemName = p.ITEMNAME,
								   Style = p.PRODUCTSTYLE,
								   Material = p.MATERIAL,
								   Unit = p.UNITCOUNT,
								   CastingPrice = p.CASTINGPRICE,
								   UnitPrice = p.UNITPRICE,
								   Weight = p.UNITWEIGHT,
								   score = p.SCOREPRICE,
								   HasImage = p.HASPICTURE,
								   ImageLocation = p.IMAGE_LOCATION
							   }).ToList();

			// main list price
			var _pl = (from pl in _priceLists
					   join px in _codes on pl.ItemCode equals px.prefix
					   join sy in _styles on pl.Style equals Convert.ToInt32(sy.Id)
					   join mat in _material on pl.Material equals Convert.ToInt32(mat.Id)
					   select new
					   {
						   Id = pl.Id,
						   CustomerCode = pl.CustomerCode,
						   ItemType = px.prefixname,
						   ItemCode = pl.ItemCode,
						   ItemNo = pl.ItemNo,
						   ItemName = pl.ItemName,
						   MaterialId = pl.Material,
						   Material = mat.Name,
						   StyleId = pl.Style,
						   Style = sy.Name,
						   Unit = pl.Unit,
						   CastingPrice = pl.CastingPrice,
						   UnitPrice = pl.UnitPrice,
						   score = pl.score,
						   Weight = pl.Weight,
						   HasImage = pl.HasImage,
						   pl.ImageLocation
					   }).OrderBy(o => o.ItemNo).AsParallel();
			_result = OMControls.OMDataUtils.ToDataTable(_pl.ToList());


			return _result;

		} // end GetPriceListByCustomer

		public static decimal GetMaterialSI(int MaterialId)
		{
			decimal _result = 0.00m;

			DataTable _dt = Tools.SelectOptions.GetMaterialSI();
			foreach (DataRow _dr in _dt.Rows)
			{
				if (_dr["KEY"].ToString() == MaterialId.ToString())
				{
					_result = Convert.ToDecimal(_dr["VALUE"]);
					break;
				}
			}

			return _result;
		} // end GetMaterialSI

		public static string GetProductStyle(int StyleId)
		{
			string _result = string.Empty;
			DataTable _dt = Tools.SelectOptions.GetProductStyleData();
			foreach (DataRow _dr in _dt.Rows)
			{
				if (_dr["KEY"].ToString() == StyleId.ToString())
				{
					_result = _dr["VALUE"].ToString();
					break;
				}
			}

			return _result;
		} // end GetProductStyle

		public static string GetMaterialName(int MaterailId)
		{
			string _result = string.Empty;
			DataTable _dt = Tools.SelectOptions.GetMaterialData();
			foreach (DataRow _dr in _dt.Rows)
			{
				if (_dr["KEY"].ToString() == MaterailId.ToString())
				{
					_result = _dr["VALUE"].ToString();
					break;
				}
			}

			return _result;

		} // end GetMaterialName

		public int UpdateHasPictureFlag(string CustomerCode)
		{
			int _result = 0;
			var _flagList = (from flag in _om.CUSTPRICEITEMPICs
							 join pl in _om.CUSTPRICELISTs
							 on flag.ITEMSEQ equals pl.PRICESEQ
							 where pl.CUSTCODE == CustomerCode
							 && pl.HASPICTURE == false
							 select new
							 {
								 flag.ITEMSEQ,
								 flag.ITEMPICID
							 }).ToList();

			if (_flagList.Count > 0)
			{
				using (var _scope = new System.Transactions.TransactionScope())
				{
					foreach (var item in _flagList)
					{
						try
						{
							var priceItems = (from pItem in _om.CUSTPRICELISTs
											  where pItem.PRICESEQ == item.ITEMSEQ
											  && pItem.CUSTCODE == CustomerCode
											  select pItem).FirstOrDefault();

							if (priceItems != null)
							{
								priceItems.HASPICTURE = true;
								_result = 1;
							}
						}
						catch
						{
							_result = 0;
							break;
						}
					}
					if (_result == 1)
					{
						_om.SaveChanges();
						_scope.Complete();
					}
					else
					{
						//_scope.Dispose();
					}
				} // end 
			}
			else
			{
				_result = -1;
			}

			return _result;

		} // end UpdateHasPictureFlag

		public int SaveImageLocation(int Id, string ImageLocation)
		{
			int _result = 0;
			using (var _scope = new System.Transactions.TransactionScope())
			{
				var cp = (from p in _om.CUSTPRICELISTs
						  where p.PRICESEQ == Id
						  select p).FirstOrDefault();

				try
				{
					cp.IMAGE_LOCATION = ImageLocation;
					_result = _om.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Save image location error !!!!", ex);
				}
			}

			return _result;

		} // end SaveImageLocation

		public static ImageCodecInfo GetEncoderInfo(String mimeType)
		{
			int j;
			ImageCodecInfo[] encoders;
			encoders = ImageCodecInfo.GetImageEncoders();
			for (j = 0; j < encoders.Length; ++j)
			{
				if (encoders[j].MimeType == mimeType)
					return encoders[j];
			}
			return null;

		} // end ImageCodecInfo

		public static int SaveImageToFile(int Id, string ImageFileLocation, byte[] Img)
		{
			int _result = 0;
			string _exportFileName = string.Empty;

			if (Img.Length > 0)
			{
				//string _fileName = string.Format("{0}{1}", ItemNo,omglobal.IMAGE_EXTENSION);
				//string _pathName = string.Format("{0}\\{1}", ImageFileLocation, _fileName);

				ImageCodecInfo myImageCodecInfo;
				System.Drawing.Imaging.Encoder myEncoder;
				EncoderParameter myEncoderParameter;
				EncoderParameters myEncoderParameters;

				// Get an ImageCodecInfo object that represents the JPEG codec.
				myImageCodecInfo = GetEncoderInfo("image/jpeg");

				// Create an Encoder object based on the GUID 
				// for the Quality parameter category.
				myEncoder = System.Drawing.Imaging.Encoder.Quality;

				// Create an EncoderParameters object. 
				// An EncoderParameters object has an array of EncoderParameter 
				// objects. In this case, there is only one 
				// EncoderParameter object in the array.
				myEncoderParameters = new EncoderParameters(1);

				try
				{
					// Save the bitmap as a JPEG file with quality level 75.
					myEncoderParameter = new EncoderParameter(myEncoder, 75L);
					myEncoderParameters.Param[0] = myEncoderParameter;

					MemoryStream ms = new MemoryStream(Img);
					Bitmap bmp = new Bitmap(ms);
					Image x = System.Drawing.Image.FromStream(ms);
					//imga.Save(file path);

					// display filename with full path
					//_exportFileName = ImageFileLocation;

					// save image to file (type jpg)
					x.Save(@ImageFileLocation, myImageCodecInfo, myEncoderParameters);

					// save file name to CUSTPRICELIST-TABLE <field=ImageLocation>
					// -- TODO CODE HERE 
					//this.SaveImageLocation(Id, @_pathName);
					//SaveImageLocation(Id, @_pathName);

					// return value due to save complete
					_result = 1;
				}
				catch (ArgumentNullException ex)
				{
					//_result = 0;
					//this.lbImageLocationPath.Text = string.Empty;
					throw new Exception("Saving Image error !!!!!!!", ex);
				}
			}
			else
			{
				//_result = 0;
				//this.lbImageLocationPath.Text = string.Empty;
				MessageBox.Show("Can't save image with (0)zero byte !!!!!!!");
			}

			return _result;

		} // end SaveImageToFile
	}
}
