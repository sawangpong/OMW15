using OMControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class ItemImageResize : Form
	{
		public ItemImageResize()
		{
			InitializeComponent();
		}

		private void ItemImageResize_Load(object sender, EventArgs e)
		{
			//this.GetImageSizeProperty();

			// initial variable
			_selectedImageQuality = omglobal.DEFAULT_IMAGE_QUALITY;

			trackBar1.Value = _selectedImageQuality;
			lbQualityValue.Text = string.Format("{0}", trackBar1.Value);
			lbImageLocationPath.Text = omglobal.IMAGE_LOCATION_PATH;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnSearchItemItemId_Click(object sender, EventArgs e)
		{
			// get casting item image id
			// code here

			GetOriginalImageProperty();
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			_selectedImageQuality = trackBar1.Value;
			lbQualityValue.Text = string.Format("{0}", _selectedImageQuality);
			if (_selectedImageId > 0)
				picResult.Image = GenerateImageResult(
					(Bitmap)picOriginal.Image,
					_resultImageWidth,
					_resultImageHeight,
					_selectedImageQuality);
		}

		private void splitter_SplitterMoving(object sender, SplitterEventArgs e)
		{
			//this.GetImageSizeProperty();
			if (_selectedImageId > 0)
				picResult.Image = GenerateImageResult((Bitmap)picOriginal.Image, _resultImageWidth, _resultImageHeight,
					_selectedImageQuality);
		}

		private void btn_Click(object sender, EventArgs e)
		{
			var _btn = sender as Button;

			GetAllImageItems(_btn.Tag.ToString());
		}

		private void bgwork_DoWork(object sender, DoWorkEventArgs e)
		{
			var b = sender as BackgroundWorker;
			//string _itemNo = string.Empty;

			using (var _om = new OLDMOONEF1())
			{
				var imgList = (from cp in _om.CUSTPRICELISTs
									join ci in _om.CUSTPRICEITEMPICs on cp.PRICESEQ equals ci.ITEMSEQ
									orderby cp.PRICESEQ
									where cp.ISDELETE == false
									select new
									{
										cp.PRICESEQ,
										ci.ITEMPICID,
										cp.ITEMNO,
										cp.ITEMNAME
									}).AsParallel().ToList();
				_count = 0;
				_maxRecordProcess = imgList.Count;
				foreach (var img in imgList)
				{
					// testing save image
					//if(_count == 200)
					//{
					//	break;
					//}
					// end test

					++_count;
					_priceSeqId = img.PRICESEQ;
					_selectedImageId = img.ITEMPICID;
					_id = _selectedImageId;
					_itemNo = img.ITEMNO;
					b.ReportProgress(_count * 100 / _maxRecordProcess);
					lbItemNo.Text = string.Format("({0}):{1}", _selectedImageId, _itemNo);

					ShowSelectedImage(_selectedImageId, _itemNo, _priceSeqId);
				} // end loop
			} // end connection
		}

		private void bgwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// set progress bar value
			progressBar1.Value = e.ProgressPercentage;

			// cal elaps time
			var _tp = DateTime.Now - _startTime;

			// display status
			lbValue.Text = string.Format("{0} of {1} :: {2}%  Elapsed time : {3:0#}:{4:0#}:{5:#0}", _count, _maxRecordProcess,
				progressBar1.Value, _tp.Hours, _tp.Minutes, _tp.Seconds);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			bgwork.CancelAsync();
		}

		private void bgwork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//omglobal.DisplayAlert("COMPLETE", e.Result.ToString()); 
		}

		#region class field members

		private int _selectedImageQuality = omglobal.DEFAULT_IMAGE_QUALITY;
		private int _resultImageWidth = omglobal.DEFAULT_IMAGE_WIDTH;
		private int _resultImageHeight = omglobal.DEFAULT_IMAGE_HEIGHT;
		private int _selectedImageId;
		private int _maxRecordProcess;
		private int _count;
		private int _saveCount;
		private int _priceSeqId;
		private string _flag = string.Empty;
		private DateTime _startTime = DateTime.Now;
		//private Thread _theThread = null;

		private int _id;
		private string _itemNo = string.Empty;

		#endregion

		#region class header

		private void UpdateUI()
		{
			lbImageItemID.Text = string.Format("{0}", _selectedImageId);
		}

		private void GetImageSizeProperty()
		{
			_resultImageWidth = picResult.Width;
			_resultImageHeight = picResult.Height;

			lbImageResultHeader.Text = string.Format("Result Image (W:{0},H:{1})", _resultImageWidth, _resultImageHeight);
		} // end GetImageSizeProperty

		private void GetOriginalImageProperty()
		{
			var _imgSelect = new ItemImageSelector();

			_imgSelect.ShowDialog(this);

			if (_imgSelect.DialogResult == DialogResult.OK)
			{
				_selectedImageId = _imgSelect.ItemImageId;
				picOriginal.Image = _imgSelect.SelectedImage;
			}
			else
			{
				_selectedImageId = 0;
				picOriginal.Image = null;
			}
			lbImageItemID.Text = _selectedImageId.ToString();

			if (picOriginal.Image != null)
				GenerateImageResult((Bitmap)picOriginal.Image, _resultImageWidth, _resultImageHeight, _selectedImageQuality);
		} // end GetOriginalImageProperty

		private Image GenerateImageResult(Bitmap SourceImage, int ImageWidth, int ImageHeight, int Quality)
		{
			Image _result = null;
			if (SourceImage != null)
				try
				{
					var _imgdb = new OMImageDB();
					_result = _imgdb.ResizeImage(SourceImage, ImageWidth, ImageHeight, Quality);
				}
				catch
				{
					picResult.Image = null;
					_result = null;
				}

			return _result;
		} // end GenerateImageResult

		private void GetAllImageItems(string Flag)
		{
			_flag = Flag;
			_saveCount = 0;
			_startTime = DateTime.Now;

			progressBar1.Maximum = 100;
			progressBar1.Minimum = 0;
			progressBar1.Step = 1;
			progressBar1.Value = 0;

			bgwork.RunWorkerAsync();
		}

		private void ShowSelectedImage(int Id, string ItemNo, int MasterPriceId)
		{
			// object for keeping the result image
			var _resultByteImage = new byte[0];

			var _fullPathImageFileName = string.Format("{0}\\{1}{2}", omglobal.IMAGE_LOCATION_PATH, ItemNo,
				omglobal.IMAGE_EXTENSION);

			// retrieve image from database
			using (var _om = new OLDMOONEF1())
			{
				var img = (from ci in _om.CUSTPRICEITEMPICs
							  where ci.ITEMPICID == Id
							  select ci).FirstOrDefault();

				if (img != null)
					try
					{
						// create object
						var _imgDb = new OMImageDB();

						// get source Image from Database
						var _sourceImg = _imgDb.GetImageFromByte(img.ITEMPIC);

						if (_sourceImg != null)
						{
							// show result image after resize
							try
							{
								picResult.Image = GenerateImageResult((Bitmap)_sourceImg, _resultImageWidth, _resultImageHeight,
									_selectedImageQuality);
								switch (_flag)
								{
									case "SCAN":
										_saveCount++;
										break;
									case "EXPORT":
										_resultByteImage =
											GenerateImageResult((Bitmap)_sourceImg, _resultImageWidth, _resultImageHeight,
												_selectedImageQuality).ConvertImage2Byte();

										_saveCount += OMUtils.SaveImageToFile(_fullPathImageFileName, _resultByteImage);

										break;
									case "PROC":
										if (picResult.Image != null)
										{
											_resultByteImage =
												GenerateImageResult((Bitmap)_sourceImg, _resultImageWidth, _resultImageHeight,
													_selectedImageQuality).ConvertImage2Byte();

											_saveCount += SaveImageToDatabase(Id, _resultByteImage);
										}
										break;
								}
							}
							catch
							{
								picResult.Image = null;
								picOriginal.Image = null;
							}

							// show original Image
							picOriginal.Image = _sourceImg;
							lbDecoder.Text = string.Format("{0} pass : {1} ", _saveCount,
								_flag == "SCAN" ? "Scan" : (_flag == "PROC" ? "Save" : "Export"));
						}
						else
						{
							picOriginal.Image = null;
							picResult.Image = null;
						}
					}
					catch
					{
						picOriginal.Image = null;
						picResult.Image = null;
					}
			}
		} // end ShowSelectedImage

		//private ImageCodecInfo GetEncoderInfo(String mimeType)
		//{
		//	int j;
		//	ImageCodecInfo[] encoders;
		//	encoders = ImageCodecInfo.GetImageEncoders();
		//	for(j = 0; j < encoders.Length; ++j)
		//	{
		//		if(encoders[j].MimeType == mimeType)
		//			return encoders[j];
		//	}
		//	return null;
		//}

		//private int SaveImageToFile(int Id, string ItemNo, byte[] Img)
		//{
		//	int _result = 0;

		//	if(Img.Length > 0)
		//	{
		//		string _fileName = string.Format("{0}.jpg", ItemNo);
		//		string _pathName = string.Format("{0}\\{1}", this.lbImageLocationPath.Text, _fileName);

		//		ImageCodecInfo myImageCodecInfo;
		//		System.Drawing.Imaging.Encoder myEncoder;
		//		EncoderParameter myEncoderParameter;
		//		EncoderParameters myEncoderParameters;

		//		// Get an ImageCodecInfo object that represents the JPEG codec.
		//		myImageCodecInfo = GetEncoderInfo("image/jpeg");

		//		// Create an Encoder object based on the GUID 
		//		// for the Quality parameter category.
		//		myEncoder = System.Drawing.Imaging.Encoder.Quality;

		//		// Create an EncoderParameters object. 
		//		// An EncoderParameters object has an array of EncoderParameter 
		//		// objects. In this case, there is only one 
		//		// EncoderParameter object in the array.
		//		myEncoderParameters = new EncoderParameters(1);

		//		try
		//		{
		//			// Save the bitmap as a JPEG file with quality level 75.
		//			myEncoderParameter = new EncoderParameter(myEncoder, 75L);
		//			myEncoderParameters.Param[0] = myEncoderParameter;

		//			MemoryStream ms = new MemoryStream(Img);
		//			Bitmap bmp = new Bitmap(ms);
		//			Image x = System.Drawing.Image.FromStream(ms);
		//			//imga.Save(file path);

		//			// display filename with full path
		//			this.lbExportFileName.Text = @_pathName;

		//			// save image to file (type jpg)
		//			x.Save(@_pathName, myImageCodecInfo, myEncoderParameters);

		//			// save file name to CUSTPRICELIST-TABLE <field=ImageLocation>
		//			// -- TODO CODE HERE 
		//			//this.SaveImageLocation(Id, @_pathName);
		//			Casting.CastingController.PriceListDAL.SaveImageLocation(Id, @_pathName);


		//			// return value due to save complete
		//			_result = 1;
		//		}
		//		catch(ArgumentNullException ex)
		//		{
		//			_result = 0;
		//			this.lbImageLocationPath.Text = string.Empty;
		//			throw new Exception("Saving Image error !!!!!!!", ex);
		//		}
		//	}
		//	else
		//	{
		//		_result = 0;
		//		this.lbImageLocationPath.Text = string.Empty;
		//		MessageBox.Show(string.Format("Item Item No : {0} , index : {1} is empty byte...", ItemNo, Id));
		//	}

		//	return _result;

		//} // end SaveImageToFile

		//private int SaveImageLocation(int Id, string ImageLocation)
		//{
		//	int _result = 0;
		//	using(var _scope = new System.Transactions.TransactionScope())
		//	{
		//		OLDMOONEF _om = new OLDMOONEF();
		//		var cp = (from p in _om.CUSTPRICELISTs
		//				  where p.PRICESEQ == Id
		//				  select p).FirstOrDefault();

		//		try
		//		{
		//			cp.IMAGE_LOCATION = ImageLocation;
		//			_result = _om.SaveChanges();
		//			_scope.Complete();
		//		}
		//		catch(OptimisticConcurrencyException ex)
		//		{
		//			_result = 0;
		//			//_scope.Dispose();
		//			throw new Exception("Save image location error !!!!", ex);
		//		}
		//	}

		//	return _result;

		//} // end SaveImageLocation


		private int SaveImageToDatabase(int Id, byte[] Img)
		{
			var _result = 0;

			var _om = new OLDMOONEF1();
			var img = (from ci in _om.CUSTPRICEITEMPICs
						  where ci.ITEMPICID == Id
						  select ci).FirstOrDefault();

			try
			{
				img.ITEMPIC = Img;
				_result = _om.SaveChanges();
			}
			catch
			{
				_result = 0;
			}
			return _result;
		}

		#endregion
	}
}