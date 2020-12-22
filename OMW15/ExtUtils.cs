using Microsoft.VisualBasic;
using OMControls.OMView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15
{
	public static class ExtUtils
	{

		public static DataTable ToDataTable<T>(this IEnumerable<T> entity)
		{
			var properties = typeof(T).GetProperties();
			var table = new DataTable();
			foreach (var property in properties)
			{
				var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
				table.Columns.Add(property.Name, type);
			}

			foreach (var item in entity)
			{
				table.Rows.Add(properties.Select(p => p.GetValue(item) ?? DBNull.Value).ToArray());
			}

			return table;
		} // end ToDataTable

		#region formAsync	

		public static async Task<DialogResult> ShowDialogAsync(this Form @this)
		{
			await Task.Yield();
			if (@this.IsDisposed)
				return DialogResult.OK;

			return @this.ShowDialog();
		}

		#endregion

		#region IMAGE

		public static byte[] ConvertImage2Byte(this Image SourceImg)
		{
			byte[] b = null;
			try
			{
				if (SourceImg != null)
					using (var ms = new MemoryStream())
					{
						var bp = new Bitmap(SourceImg);
						bp.Save(ms, ImageFormat.Jpeg);
						b = ms.GetBuffer();
					}
			}
			catch (Exception ex)
			{
				throw new Exception("Error Conversion Image !!!!!! ", ex);
			}

			return b;
		} // end ConvertImage2Byte

		public static Image ToImageResize(this Image currentBitmap, int newWidth, int newHeight)
		{
			if (newWidth != 0 && newHeight != 0)
			{
				var temp = (Bitmap)currentBitmap;
				var bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

				var nWidthFactor = temp.Width / (double)newWidth;
				var nHeightFactor = temp.Height / (double)newHeight;

				double fx, fy, nx, ny;
				int cx, cy, fr_x, fr_y;
				var color1 = new Color();
				var color2 = new Color();
				var color3 = new Color();
				var color4 = new Color();
				byte nRed, nGreen, nBlue;

				byte bp1, bp2;

				for (var x = 0; x < bmap.Width; ++x)
					for (var y = 0; y < bmap.Height; ++y)
					{
						fr_x = (int)Math.Floor(x * nWidthFactor);
						fr_y = (int)Math.Floor(y * nHeightFactor);
						cx = fr_x + 1;
						if (cx >= temp.Width)
							cx = fr_x;
						cy = fr_y + 1;
						if (cy >= temp.Height)
							cy = fr_y;
						fx = x * nWidthFactor - fr_x;
						fy = y * nHeightFactor - fr_y;
						nx = 1.0 - fx;
						ny = 1.0 - fy;

						color1 = temp.GetPixel(fr_x, fr_y);
						color2 = temp.GetPixel(cx, fr_y);
						color3 = temp.GetPixel(fr_x, cy);
						color4 = temp.GetPixel(cx, cy);

						// Blue
						bp1 = (byte)(nx * color1.B + fx * color2.B);

						bp2 = (byte)(nx * color3.B + fx * color4.B);

						nBlue = (byte)(ny * bp1 + fy * bp2);

						// Green
						bp1 = (byte)(nx * color1.G + fx * color2.G);

						bp2 = (byte)(nx * color3.G + fx * color4.G);

						nGreen = (byte)(ny * bp1 + fy * bp2);

						// Red
						bp1 = (byte)(nx * color1.R + fx * color2.R);

						bp2 = (byte)(nx * color3.R + fx * color4.R);

						nRed = (byte)(ny * bp1 + fy * bp2);

						bmap.SetPixel(x, y, Color.FromArgb
							(255, nRed, nGreen, nBlue));
					}
				return (Image)bmap.Clone();
			}
			return null;
		} // end ToImageResize


		public static Image ToImageFromByte(this byte[] ObjectImage)
		{
			Image imgResult;
			using (var ms = new MemoryStream())
			{
				ms.Write(ObjectImage, 0, ObjectImage.Length);
				imgResult = Image.FromStream(ms, true, true);
			}

			return imgResult;
		} // end ToImageFromByte

		private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
		{
			return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
		}

		public static int SaveImageToFile(this Image SourceImg, string FullPathName)
		{
			var _result = 0;

			byte[] _byteImg = SourceImg.ConvertImage2Byte();

			if (_byteImg.Length > 0)
			{
				ImageCodecInfo myImageCodecInfo;
				Encoder myEncoder;
				EncoderParameter myEncoderParameter;
				EncoderParameters myEncoderParameters;

				// Get an ImageCodecInfo object that represents the JPEG codec.
				myImageCodecInfo = GetEncoderInfo(ImageFormat.Jpeg);

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
					using (var ms = new MemoryStream(_byteImg))
					{
						var x = Image.FromStream(ms);
						//x.Save(FullPathName, myImageCodecInfo, myEncoderParameters);
						System.IO.File.WriteAllBytes(FullPathName, _byteImg);
					}

					// return value due to save complete
					_result = 1;
				}
				catch (ExternalException ex)
				{
					using (var _a = new Alert("Save Image Error", ex.ToString()))
					{
						_a.ShowDialog();
					}
				}
			}

			return _result;
		} // end SaveImageToFile

		#endregion

		#region Compare number

		public static bool IsNumeric(this decimal value)
		{
			return Microsoft.VisualBasic.Information.IsNumeric(value);
		}

		public static bool IsNumeric(this int value)
		{
			return Microsoft.VisualBasic.Information.IsNumeric(value);
		}

		public static bool IsNumeric(this string value)
		{
			return Microsoft.VisualBasic.Information.IsNumeric(value);
		}

		#endregion

		#region Date Converter

		public static string GetFullThaiYearFormat(this DateTime CurrentDate)
		{
			var thai_culture = new CultureInfo("th-TH");
			var dt_format = thai_culture.DateTimeFormat;
			return CurrentDate.ToString("yyyy", dt_format);
		} // end GetThaiYearFormat

		public static string GetThaiYearFormat(this DateTime CurrentDate)
		{
			var thai_culture = new CultureInfo("th-TH");
			var dt_format = thai_culture.DateTimeFormat;
			return CurrentDate.ToString("yy", dt_format);
		} // end GetThaiYearFormat

		public static string GetThaiYearFormat()
		{
			var CurrentDate = DateTime.Today;
			var thai_culture = new CultureInfo("th-TH");
			var dt_format = thai_culture.DateTimeFormat;
			return CurrentDate.ToString("yy", dt_format);
		} // end GetThaiYearFormat

		public static DateTime Num2Date(this decimal NumDate)
		{
			DateTime retDate;
			var sDate = string.Empty;
			try
			{
				sDate = NumDate.ToString();
				retDate = new DateTime(Convert.ToInt32(sDate.Substring(0, 4)), Convert.ToInt32(sDate.Substring(4, 2)),
					Convert.ToInt32(sDate.Substring(6, 2)));
			}
			catch
			{
				retDate = DateTime.Today;
			}
			return retDate;
		} // end Num2Date

		public static DateTime Num2Date(this string NumDate)
		{
			DateTime retDate;
			var sDate = string.Empty;
			try
			{
				sDate = NumDate;
				retDate = new DateTime(Convert.ToInt32(sDate.Substring(0, 4)), Convert.ToInt32(sDate.Substring(4, 2)),
					Convert.ToInt32(sDate.Substring(6, 2)));
			}
			catch
			{
				retDate = DateTime.Today;
			}
			return retDate;
		} // end Num2Date

		public static DateTime Num2Date(this int NumDate)
		{
			DateTime retDate;
			var sDate = string.Empty;
			try
			{
				sDate = NumDate.ToString();
				retDate = new DateTime(Convert.ToInt32(sDate.Substring(0, 4)), Convert.ToInt32(sDate.Substring(4, 2)),
					Convert.ToInt32(sDate.Substring(6, 2)));
			}
			catch
			{
				retDate = DateTime.Today;
			}
			return retDate;
		} // end Num2Date

		public static int Date2Num(object DateValue)
		{
			var ret = 0;
			try
			{
				var d = Convert.ToDateTime(DateValue);
				var dummy = string.Format("{0}{1}{2}", d.Year, "00".Substring(0, 2 - d.Month.ToString().Length) + d.Month,
					"00".Substring(0, 2 - d.Day.ToString().Length) + d.Day);
				ret = Convert.ToInt32(dummy);
			}
			catch
			{
				ret = 0;
			}

			return ret;
		} // end Date2Num

		public static int Date2Num(this DateTime DateValue)
		{
			var ret = 0;
			try
			{
				var d = DateValue;
				var dummy = string.Format("{0}{1}{2}", d.Year, "00".Substring(0, 2 - d.Month.ToString().Length) + d.Month, "00".Substring(0, 2 - d.Day.ToString().Length) + d.Day);
				ret = Convert.ToInt32(dummy);
			}
			catch
			{
				ret = 0;
			}

			return ret;
		} // end Date2Num


		public static int Date2Num(this string DateValue)
		{
			var ret = 0;
			try
			{
				var d = Convert.ToDateTime(DateValue);
				var dummy = string.Format("{0}{1}{2}", d.Year, "00".Substring(0, 2 - d.Month.ToString().Length) + d.Month, "00".Substring(0, 2 - d.Day.ToString().Length) + d.Day);
				ret = Convert.ToInt32(dummy);
			}
			catch
			{
				ret = 0;
			}

			return ret;
		} // end Date2Num

		public static bool IsDate(this DateTime DateValue)
		{
			return Information.IsDate(DateValue);
		}

		public static bool IsDate(this string DateValue)
		{
			return Information.IsDate(DateValue);
		}

		public static string GetThaiMonthName(this int MonthNumber)
		{
			var thai_culture = new CultureInfo("th-TH");
			var dt_format = thai_culture.DateTimeFormat;
			var _theDate = new DateTime(DateTime.Today.Year, MonthNumber, 1);

			return _theDate.ToString("MMMM", dt_format);

		} // end GetThaiMonthName

		public static string GetMonthName(this int MonthNumber)
		{
			return DateAndTime.MonthName(MonthNumber, false);
		} // end GetMonthName




		#endregion
	}
}