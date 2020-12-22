using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OMW15.Tools.Controller
{
	public class ImageDB
	{
		#region Class Member Field
		private OpenFileDialog selectFileDialog = null;
		private byte[] byteImage;
		private Image selectedImgage = null;
		private string selectedFilename = null;
		private string connectionString = null;
		private string imageQuery = null;
		private Size _selectedSize = new Size(80, 120);

		#endregion //end class member field

		#region Class Property
		public string ImageFileName
		{
			get
			{
				return this.selectedFilename;
			}
			set
			{
				this.selectedFilename = value;
			}
		}

		public string ConnectionString
		{
			get
			{
				return connectionString;
			}
			set
			{
				connectionString = value;
			}
		}

		public string ImageQuery
		{
			get
			{
				return imageQuery;
			}
			set
			{
				imageQuery = value;
			}
		}

		public Image GetImage
		{
			get
			{
				return this.selectedImgage;
			}
		}


		#endregion // end class property

		#region class Helper

		#region Overload Method GetImageFromDB

		//
		// Call by No parameter
		public Image GetImageFromDB()
		{
			return GetImageFromDB();
		
		}//end GetImageFromDB

		//
		// Call by given parameter "PictureSizeMode"
		public Image GetImageFromDB(string ImageQuery, string ConnectionString)
		{
			Bitmap dbBmp = null;
			DataTable dt = omdal.GetRecords(ImageQuery, ConnectionString);
			try
			{
				if (dt != null)
				{
					if (Convert.IsDBNull(dt.Rows[0][0]))
					{
						return null;
					}
					else
					{
						Byte[] b = (byte[])dt.Rows[0][0];
						using (MemoryStream ms = new MemoryStream())
						{
							ms.Write(b, 0, b.Length);
							dbBmp = new Bitmap(ms);
							using (Graphics gBmp = Graphics.FromImage(dbBmp))
							{
								gBmp.InterpolationMode = InterpolationMode.HighQualityBicubic;
								gBmp.DrawImage(dbBmp, new RectangleF(0.0f, 0.0f, (float)dbBmp.Width, (float)dbBmp.Height));
							} // end graphic object
						} // end memorystream  object   
					}
				}
			}
			catch
			{
				dbBmp = null;
			}

			return (Image)dbBmp;

		} // end GetImageFromDB

		#endregion //end GetImageFromDB

		#region "Overload Method GetImageListFromDB"

		public ImageList GetImageListFromDB(string ImageQuery, string ConnectionString)
		{
			ImageList imgList = new ImageList();
			Image img = null;
			imgList.ImageSize = new Size(50, 80);
			DataTable dt = omdal.GetRecords(ImageQuery, ConnectionString);

			// Get Image from Database field
			foreach (DataRow dr in dt.Rows)
			{
				if (Convert.IsDBNull(dr[1]))
				{
					img = null;
				}
				else
				{
					Byte[] b = (byte[])dr[1];
					using (MemoryStream ms = new MemoryStream())
					{
						ms.Write(b, 0, b.Length);
						img = Image.FromStream(ms, true, true);
						img.Tag = dr[0].ToString();
					} // end MemoryStream object
					imgList.Images.Add(dr[0].ToString(), img);
				}
			} //end loop record
			return imgList;
		} // end GetImageListFromDB

		#endregion "Overload Method GetImageListFromDB"

		#region "Overload Method GetImageFromField

		public Image GetImageFromByte(byte[] ObjectImage)
		{
			Image imgResult;
			using(MemoryStream ms = new MemoryStream())
			{
				ms.Write(ObjectImage, 0, ObjectImage.Length);
				imgResult = Image.FromStream(ms, true, true);
			}

			return imgResult;

		} // end GetImageFromByte

		public Image GetImageFromField(object ImageField)
		{
			try
			{
				if (ImageField != null)
				{
					Image imgResult;
					Byte[] b = (byte[])ImageField;
					using (MemoryStream ms = new MemoryStream())
					{
						ms.Write(b, 0, b.Length);
						imgResult = Image.FromStream(ms, true, true);
					} // end memorystream
					return imgResult;
				}
				else
				{
					return null;
				}
			}
			catch
			{
				return null;
			}
		} // end GetImageFromField

		#endregion // Overload Method GetImageFromField

		#region "Overload Method GetImageFile"
		public Image GetImageFile()
		{
			// initial OpenFileDialog for all Image extension
			this.selectFileDialog = new OpenFileDialog();
			this.selectFileDialog.InitialDirectory = (omglobal.LastSelectedPath == null ? System.Environment.CurrentDirectory.ToString() : omglobal.LastSelectedPath);
			this.selectFileDialog.Title = "Select Picture File";
			this.selectFileDialog.DefaultExt = "*.BMP";
			this.selectFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

			//chk selected image
			if (this.selectFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.selectedFilename = this.selectFileDialog.FileName.ToString();
				try
				{
					using (FileStream fs = new FileStream(this.selectedFilename, FileMode.Open, FileAccess.Read))
					{
						omglobal.LastSelectedPath = this.selectFileDialog.FileName.Substring(1, this.selectFileDialog.FileName.LastIndexOf("\\"));

						this.byteImage = new byte[Convert.ToInt32(fs.Length)];
						fs.Read(this.byteImage, 0, Convert.ToInt32(fs.Length));
						this.selectedImgage = Image.FromFile(this.selectFileDialog.FileName.ToString(), false);
					}//end filestream object
				}
				catch
				{
					MessageBox.Show("ไม่สามารถสร้างรูปภาพได้จากไฟล์ที่เลือก", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.selectedImgage = null;
				}
			}
			else
			{
				this.selectedImgage = null;
			}

			return this.selectedImgage;
		} // end GetImageFile

		#endregion "Overload Method GetImageFile"

		public ImageList GetImageList(string QueryString, string ConnectionString)
		{
			ImageList imgList = new ImageList();
			imgList.TransparentColor = Color.White;

			Bitmap bmp;
			DataTable dt = omdal.GetRecords(QueryString, ConnectionString);
			foreach (DataRow dr in dt.Rows)
			{
				if (Convert.IsDBNull(dr[1]))
				{
					PictureBox p = new PictureBox();
					imgList.Images.Add(dr[0].ToString(), p.ErrorImage);
				}
				else
				{
					Byte[] b = (byte[])dr[1];
					using (MemoryStream ms = new MemoryStream())
					{
						ms.Write(b, 0, b.Length);
						bmp = new Bitmap(ms, true);
						imgList.Images.Add(dr[0].ToString(), (Image)bmp);
					} // end memorystream object
				}
			} // end record loop
			return imgList;
		} // end GeiImageList

		#region Get Image 

		//public Image GetFixImage(Bitmap sourceImage, int width, int height, int quality, string filePath)
		//{

		//	Bitmap _fixBmp = null;
		//	try
		//	{
		//		byte[] b;
		//		using(MemoryStream ms = new MemoryStream())
		//		{
		//			_fixBmp = this.ResizeImage(sourceImage, 100, 200, 50);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new Exception("Can't fixed image", ex);
		//	}

		//} // end GetFixImage

		#endregion


		#region "Overload Method ResizeImage"

		private Bitmap ResizeImage(Bitmap SourceImage, Size NewSize)
		{
			return ResizeImage(SourceImage, NewSize.Width, NewSize.Height);

		} // end ResizeImage

		private Bitmap ResizeImage(Bitmap sourceImage, int width, int height)
		{
			Bitmap bmp = new Bitmap(sourceImage, new Size(width, height));
			using (Graphics grp = Graphics.FromImage(bmp))
			{
				grp.PixelOffsetMode = PixelOffsetMode.None;
				grp.InterpolationMode = InterpolationMode.HighQualityBicubic;
				grp.DrawImage(bmp, new RectangleF(0.0f, 0.0f, (float)bmp.Width, (float)bmp.Height));
			}
			return bmp;

		} // end ResizeImage

		public Image ResizeImage(Bitmap sourceImage, int width, int height, int quality)
		{
			Image _result = null;
			try
			{

				// get the original image width and height
				int _originalWidth = sourceImage.Width;
				int _originalHeight = sourceImage.Height;

				// to preserve the aspect ratio
				float ratioX = (float)width / (float)_originalWidth;
				float ratioY = (float)height / (float)_originalHeight;
				float ratio = Math.Min(ratioX, ratioY);

				// new width and height based on aspect ratio
				int newWidth = (int)(_originalWidth * ratio);
				int newHeight = (int)(_originalHeight * ratio);

				// convert other formats (including CMYK) to RGB
				Bitmap _newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

				// draw the image in the specified size with quality mode set to HighQuality
				using(Graphics g = Graphics.FromImage(_newImage))
				{
					g.CompositingQuality = CompositingQuality.HighQuality;
					g.InterpolationMode = InterpolationMode.HighQualityBicubic;
					g.SmoothingMode = SmoothingMode.HighQuality;
					g.DrawImage(sourceImage, 0, 0, newWidth, newHeight);
				}

				// get an ImageCodecInfo object that represents the JPEG codec.
				ImageCodecInfo imageCodecInfo = GetEncoderInfo(ImageFormat.Jpeg);

				// create and Encoder object for the Quality parameter
				System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;

				// create and EncoderParameters object
				EncoderParameters encoderParameters = new EncoderParameters(1);

				// save the image as a jpeg file quality level
				EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
				encoderParameters.Param[0] = encoderParameter;

				//byte[] b;
				Image _img;
				using(MemoryStream ms = new MemoryStream())
				{
					Bitmap _bmp = new Bitmap(_newImage);
					_bmp.Save(ms, imageCodecInfo, encoderParameters);
					_img = Image.FromStream(ms, true, true);
				}
				_result= _img;
			}
			catch
			{
				_result = null;
			}

			return _result;

		} // end

		private ImageCodecInfo GetEncoderInfo(ImageFormat format)
		{
			return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
		}

		#endregion "Overload Method ResizeImage"

		#endregion // end class helper


		#region Class Constructor

		public ImageDB()
		{
		} // end constructor ImageDB

		#endregion // end class constructor

	}//end class ImageDB 
}
