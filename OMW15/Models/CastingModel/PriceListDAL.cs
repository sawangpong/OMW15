using OMW15.Models.ToolModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Models.CastingModel
{
	public class IMat
	{
		public int MatId { get; set; }

		public string MatName { get; set; }
	}

	public class PriceListDAL
	{

		#region constructor and destructor
		private readonly OLDMOONEF1 _om;

		public PriceListDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion
		public static string CreateImageFilePath(string ItemNo) => $"{omglobal.IMAGE_LOCATION_PATH}\\{ItemNo}{omglobal.IMAGE_EXTENSION}";

		public string GetProductStyle(int StyleId) => _om.SYSDATAs.Single(x => x.GROUPTITLE == "PRODUCTSTYLE" && x.KEYVALUE == StyleId.ToString()).THKEYNAME;

		public int GetCustomerId(string CustomerCode) => _om.CUSTOMERS.Single(x => x.CUSTCODE == CustomerCode).CUSTID;

		public string GetItemCodeText(string Code) => _om.ITEMCODEs.Single(x => x.ITEMCODE1 == Code).ITEMCODENAME_TH;

		public string GetCustomerName(string CustomerCode) => _om.CUSTOMERS.Single(x => x.CUSTCODE == CustomerCode).CUSTNAME;

		public Image GetItemImageFromItemId(int itemId) => GetPriceListItemPicture(_om.CUSTPRICELISTs.FirstOrDefault(x => x.PRICESEQ == itemId).IMAGE_LOCATION);

		public CUSTPRICELIST GetCustomerPriceListItemInfo(int ItemId) => _om.CUSTPRICELISTs.Single(x => x.PRICESEQ == ItemId);

		public DataTable GetPriceTableById(int itemId, int matId) => new DataConnect($"EXEC dbo.usp_OM_CASTING_PRICELIST_TABLE {itemId},{matId}", omglobal.SysConnectionString).ToDataTable;

		public DataTable GetPriceTableById(int itemId, int matId, int yearSale, string unitName) => new DataConnect($"EXEC dbo.usp_OM_CASTING_PRICELIST_TABLE {itemId},{matId},{yearSale},'{unitName}'", omglobal.SysConnectionString).ToDataTable;

		public Image GetPriceListItemPictureByItemId(int itemId)
		{
			// first find the image part from price list
			var imgPath = _om.CUSTPRICELISTs.FirstOrDefault(x => x.PRICESEQ == itemId).IMAGE_LOCATION;
			Image _result = null;
			if (File.Exists(imgPath))
				_result = Image.FromFile(imgPath);
			return _result;
		} // end GetPriceListItemPictureByItemId


		public Image GetItemPicture(int itemId)
		{
			var imagePath = _om.CUSTPRICELISTs.FirstOrDefault(x => x.PRICESEQ == itemId).IMAGE_LOCATION;
			Image _result = null;
			try
			{
				if (File.Exists(imagePath))
					using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
					{
						_result = Image.FromStream(fs);
						return new Bitmap(_result);
					}
				return null;
			}
			catch
			{
				return null;
			}
		} // end GetItemPicture

		public static Image GetPriceListItemPicture(string ImageFilePath)
		{
			Image _result = null;
			try
			{
				if (File.Exists(ImageFilePath))
					using (var fs = new FileStream(ImageFilePath, FileMode.Open, FileAccess.Read))
					{
						_result = Image.FromStream(fs);
						return new Bitmap(_result);
					}
				return null;
			}
			catch
			{
				return null;
			}
		} // end GetPriceListItemPicture

		public IList<IMat> GetMaterialListFromCustomerPriceList(string customerCode)
		{
			var m = (from cp in _om.CUSTPRICELISTs
						join sy in _om.SYSDATAs on cp.MATERIAL.ToString() equals sy.KEYVALUE
						where sy.GROUPTITLE == "MATERIAL"
							  && cp.CUSTCODE == customerCode
						select new IMat
						{
							MatId = cp.MATERIAL,
							MatName = sy.THKEYNAME
						}).Distinct().OrderBy(o => o.MatName).AsParallel();

			return m.ToList();

		} // end GetMaterialListByCustomerPriceList

		public async Task<DataTable> GetPriceListByCustomerAsync(string customerCode, int matId = 0)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				// retrieve Price List
				var _priceLists = (from p in _om.CUSTPRICELISTs
										 join cd in _om.ITEMCODEs on p.PREFIX equals cd.ITEMCODE1
										 join m in _om.SYSDATAs.AsEnumerable() on p.MATERIAL.ToString() equals m.KEYVALUE
										 join s in _om.SYSDATAs.AsEnumerable() on p.PRODUCTSTYLE.ToString() equals s.KEYVALUE
										 where p.ISDELETE == false
											  && p.CUSTCODE.Trim() == customerCode
											  && m.GROUPTITLE == "MATERIAL"
											  && s.GROUPTITLE == "PRODUCTSTYLE"
										 orderby p.ITEMNO, p.PREFIX
										 select new
										 {
											 Id = p.PRICESEQ,
											 CustomerCode = p.CUSTCODE,
											 ItemType = cd.ITEMCODENAME_TH,
											 ItemCode = p.PREFIX,
											 ItemNo = p.ITEMNO,
											 ItemName = p.ITEMNAME,
											 MaterialId = p.MATERIAL,
											 Material = m.THKEYNAME,
											 StyleId = p.PRODUCTSTYLE,
											 Style = s.THKEYNAME,
											 Unit = p.UNITCOUNT,
											 CastingPrice = p.CASTINGPRICE,
											 UnitPrice = p.UNITPRICE,
											 Score = p.SCOREPRICE,
											 Weight = p.UNITWEIGHT,
											 HasImage = p.HASPICTURE,
											 ImageLocation = p.IMAGE_LOCATION,
											 FlaskTemp = p.FLASK_TEMP,
											 CastTemp = p.CAST_TEMP
										 }).AsParallel();

				if (matId > 0)
					_result = _priceLists.Where(x => x.MaterialId == matId).AsParallel().ToDataTable();
				else
					_result = _priceLists.ToDataTable();

				return _result;
			});
		} // end GetPriceListByCustomerAsync


		public int SaveImageLocation(int Id, string ImageLocation)
		{
			var _result = 0;
			var cp = (from p in _om.CUSTPRICELISTs
						 where p.PRICESEQ == Id
						 select p).FirstOrDefault();

			try
			{
				cp.IMAGE_LOCATION = ImageLocation;
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Save image location error !!!!", ex);
			}

			return _result;
		} // end SaveImageLocation

		public static ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			int j;
			ImageCodecInfo[] encoders;
			encoders = ImageCodecInfo.GetImageEncoders();
			for (j = 0; j < encoders.Length; ++j)
				if (encoders[j].MimeType == mimeType)
					return encoders[j];
			return null;
		} // end ImageCodecInfo

		public static int SaveImageToFile(int Id, string ImageFileLocation, byte[] Img)
		{
			var _result = 0;
			var _exportFileName = string.Empty;

			if (Img.Length > 0)
			{
				ImageCodecInfo myImageCodecInfo;
				Encoder myEncoder;
				EncoderParameter myEncoderParameter;
				EncoderParameters myEncoderParameters;

				// Get an ImageCodecInfo object that represents the JPEG codec.
				myImageCodecInfo = GetEncoderInfo("image/jpeg");

				// Create an Encoder object based on the GUID 
				// for the Quality parameter category.
				myEncoder = Encoder.Quality;

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

					var ms = new MemoryStream(Img);
					var bmp = new Bitmap(ms);
					var x = Image.FromStream(ms);
					//imga.Save(file path);

					// display filename with full path
					//_exportFileName = ImageFileLocation;

					// save image to file (type jpg)
					x.Save(ImageFileLocation, myImageCodecInfo, myEncoderParameters);

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



		#region CastingPrices
		public CUSTPRICETAB GetCastingPriceItem(int id) => _om.CUSTPRICETABs.Find(id);

		public int UpdateCustPriceTable(CUSTPRICETAB cpt)
		{
			if (cpt.ID == 0)
			{
				_om.CUSTPRICETABs.Add(cpt);
			}
			else
			{
				CUSTPRICETAB _cpt = GetCastingPriceItem(cpt.ID);
				_cpt.ISMATINCLUDE = cpt.ISMATINCLUDE;
				_cpt.MATERIAL = cpt.MATERIAL;
				_cpt.PRICEUNITNAME = cpt.PRICEUNITNAME;
				_cpt.PRICE_YEAR = cpt.PRICE_YEAR;
				_cpt.UNITPRICE = cpt.UNITPRICE;
			}

			return _om.SaveChanges();
		}

		public int DeleteCustingPriceTableItem(int id)
		{
			_om.CUSTPRICETABs.Remove(GetCastingPriceItem(id));
			return _om.SaveChanges();
		}


		#endregion

	}
}