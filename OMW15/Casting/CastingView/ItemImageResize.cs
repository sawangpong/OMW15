using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingView
{
	public partial class ItemImageResize : Form
	{
		#region class field members

		private int _selectedImageQuality = omglobal.DEFAULT_IMAGE_QUALITY;
		private int _resultImageWidth = omglobal.DEFAULT_IMAGE_WIDTH;
		private int _resultImageHeight = omglobal.DEFAULT_IMAGE_HEIGHT;
		private int _selectedImageId = 0;
		private int _maxRecordProcess = 0;
		private int _count = 0;
		private int _saveCount = 0;
		private int _priceSeqId = 0;
		private string _flag = string.Empty;
		private DateTime _startTime = DateTime.Now;
		//private Thread _theThread = null;

		private int _id = 0;
		private string _itemNo = string.Empty;


		#endregion

		#region class header

		private void UpdateUI()
		{
			this.lbImageItemID.Text = string.Format("{0}", _selectedImageId);
		}

		private void GetImageSizeProperty()
		{
			_resultImageWidth = this.picResult.Width;
			_resultImageHeight = this.picResult.Height;

			this.lbImageResultHeader.Text = string.Format("Result Image (W:{0},H:{1})", _resultImageWidth, _resultImageHeight);

		} // end GetImageSizeProperty

		private void GetOriginalImageProperty()
		{
			Casting.CastingView.ItemImageSelector _imgSelect = new ItemImageSelector();

			_imgSelect.ShowDialog(this);

			if(_imgSelect.DialogResult == System.Windows.Forms.DialogResult.OK)
			{
				_selectedImageId = _imgSelect.ItemImageId;
				this.picOriginal.Image = _imgSelect.SelectedImage;
			}
			else
			{
				_selectedImageId = 0;
				this.picOriginal.Image = null;
			}
			this.lbImageItemID.Text = _selectedImageId.ToString();

			if(this.picOriginal.Image != null)
			{
				this.GenerateImageResult((Bitmap)this.picOriginal.Image, _resultImageWidth, _resultImageHeight, _selectedImageQuality);
			}
		} // end GetOriginalImageProperty

		private Image GenerateImageResult(Bitmap SourceImage, int ImageWidth, int ImageHeight, int Quality)
		{
			Image _result = null;
			if(SourceImage != null)
			{
				try
				{
					OMControls.OMImageDB _imgdb = new OMControls.OMImageDB();
					_result = _imgdb.ResizeImage(SourceImage, ImageWidth, ImageHeight, Quality);
				}
				catch
				{
					this.picResult.Image = null;
					_result = null;
				}
			}

			return _result;

		} // end GenerateImageResult

		private void GetAllImageItems(string Flag)
		{
			_flag = Flag;
			_saveCount = 0;
			_startTime = DateTime.Now;

			this.progressBar1.Maximum = 100;
			this.progressBar1.Minimum = 0;
			this.progressBar1.Step = 1;
			this.progressBar1.Value = 0;

			this.bgwork.RunWorkerAsync();
		}

		private void ShowSelectedImage(int Id, string ItemNo, int MasterPriceId)
		{
			// object for keeping the result image
			byte[] _resultByteImage = new byte[0];
			
			string _fullPathImageFileName = string.Format("{0}\\{1}{2}",omglobal.IMAGE_LOCATION_PATH,ItemNo,omglobal.IMAGE_EXTENSION);
			
			// retrieve image from database
			using(OLDMOONEF _om = new OLDMOONEF())
			{
				var img = (from ci in _om.CUSTPRICEITEMPICs
						   where ci.ITEMPICID == Id
						   select ci).FirstOrDefault();

				if(img != null)
				{
					try
					{
						// create object
						OMControls.OMImageDB _imgDb = new OMControls.OMImageDB();

						// get source Image from Database
						Image _sourceImg = _imgDb.GetImageFromByte(img.ITEMPIC);

						if(_sourceImg != null)
						{
							// show result image after resize
							try
							{
								this.picResult.Image = this.GenerateImageResult((Bitmap)_sourceImg, _resultImageWidth, _resultImageHeight, _selectedImageQuality);
								switch(_flag)
								{
									case "SCAN":
										_saveCount++;
										break;
									case "EXPORT":
										_resultByteImage = OMControls.OMUtils.ConvertImage2Byte(this.GenerateImageResult((Bitmap)_sourceImg, _resultImageWidth, _resultImageHeight, _selectedImageQuality));
										//_saveCount += this.SaveImageToFile(MasterPriceId, ItemNo, _resultByteImage);

										_saveCount += OMControls.OMUtils.SaveImageToFile(_fullPathImageFileName, _resultByteImage);
											//Casting.CastingController.PriceListDAL.SaveImageToFile(MasterPriceId, ItemNo, omglobal.IMAGE_LOCATION_PATH, _resultByteImage);

										break;
									case "PROC":
										if(this.picResult.Image != null)
										{
											_resultByteImage = OMControls.OMUtils.ConvertImage2Byte(this.GenerateImageResult((Bitmap)_sourceImg, _resultImageWidth, _resultImageHeight, _selectedImageQuality));

											_saveCount += this.SaveImageToDatabase(Id, _resultByteImage);
										}
										break;
								}
							}
							catch
							{
								this.picResult.Image = null;
								this.picOriginal.Image = null;
							}

							// show original Image
							this.picOriginal.Image = _sourceImg;
							this.lbDecoder.Text = string.Format("{0} pass : {1} ", _saveCount, (_flag == "SCAN" ? "Scan" : (_flag == "PROC" ? "Save" : "Export")));
						}
						else
						{
							this.picOriginal.Image = null;
							this.picResult.Image = null;
						}
					}
					catch
					{
						this.picOriginal.Image = null;
						this.picResult.Image = null;
					}
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
			int _result = 0;

			using(var scope = new System.Transactions.TransactionScope())
			{
				OLDMOONEF _om = new OLDMOONEF();
				var img = (from ci in _om.CUSTPRICEITEMPICs
						   where ci.ITEMPICID == Id
						   select ci).FirstOrDefault();

				try
				{
					img.ITEMPIC = Img;
					_result = _om.SaveChanges();
					scope.Complete();
				}
				catch
				{
					_result = 0;
					//scope.Dispose();
				}
			}
			return _result;
		}

		#endregion


		public ItemImageResize()
		{
			InitializeComponent();
		}

		private void ItemImageResize_Load(object sender, EventArgs e)
		{
			//this.GetImageSizeProperty();

			// initial variable
			_selectedImageQuality = omglobal.DEFAULT_IMAGE_QUALITY;

			this.trackBar1.Value = _selectedImageQuality;
			this.lbQualityValue.Text = string.Format("{0}", this.trackBar1.Value);
			this.lbImageLocationPath.Text = omglobal.IMAGE_LOCATION_PATH;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSearchItemItemId_Click(object sender, EventArgs e)
		{
			// get casting item image id
			// code here

			this.GetOriginalImageProperty();

		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			_selectedImageQuality = this.trackBar1.Value;
			this.lbQualityValue.Text = string.Format("{0}", _selectedImageQuality);
			if(_selectedImageId > 0)
			{
				this.picResult.Image = this.GenerateImageResult(
					(Bitmap)this.picOriginal.Image,
					_resultImageWidth,
					_resultImageHeight,
					_selectedImageQuality);
			}
		}

		private void splitter_SplitterMoving(object sender, SplitterEventArgs e)
		{
			//this.GetImageSizeProperty();
			if(_selectedImageId > 0)
			{
				this.picResult.Image = this.GenerateImageResult((Bitmap)this.picOriginal.Image, _resultImageWidth, _resultImageHeight, _selectedImageQuality);
			}
		}

		private void btn_Click(object sender, EventArgs e)
		{
			Button _btn = sender as Button;

			this.GetAllImageItems(_btn.Tag.ToString());
		}

		private void bgwork_DoWork(object sender, DoWorkEventArgs e)
		{
			var b = sender as BackgroundWorker;
			//string _itemNo = string.Empty;

			using(OLDMOONEF _om = new OLDMOONEF())
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
				foreach(var img in imgList)
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
					b.ReportProgress((_count * 100 / _maxRecordProcess));
					this.lbItemNo.Text = string.Format("({0}):{1}", _selectedImageId, _itemNo);

					this.ShowSelectedImage(_selectedImageId, _itemNo, _priceSeqId);
				} // end loop
			} // end connection
		}

		private void bgwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// set progress bar value
			this.progressBar1.Value = e.ProgressPercentage;

			// cal elaps time
			TimeSpan _tp = DateTime.Now - _startTime;

			// display status
			this.lbValue.Text = string.Format("{0} of {1} :: {2}%  Elapsed time : {3:0#}:{4:0#}:{5:#0}", this._count, _maxRecordProcess, this.progressBar1.Value, _tp.Hours, _tp.Minutes, _tp.Seconds);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.bgwork.CancelAsync();
		}

		private void bgwork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//omglobal.DisplayAlert("COMPLETE", e.Result.ToString()); 
		}
	}
}
