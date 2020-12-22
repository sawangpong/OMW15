using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Transactions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using OMControls;
using OMW15.Shared;


namespace OMW15.Casting.CastingView
{
	public partial class CastingPriceListItemInfo : Form
	{
		#region class field member
		private ActionMode _mode = ActionMode.None;
		private int _itemId = 0;
		private string _customerCode = string.Empty;
		private string _customerName = string.Empty;
		private int _customerId = 0;

		// variable for Item-Code
		private string _value = string.Empty;
		private string _code = string.Empty;
		private int _id = 0;

		#endregion

		#region class properties

		public int CustomerId
		{
			set
			{
				_customerId = value;
			}
		}

		public string CustomerCode
		{
			set
			{
				_customerCode = value;
			}
		}

		public string CustomerName
		{
			set
			{
				_customerName = value;
			}
		}
		public int ItemId
		{
			set
			{
				_itemId = value;
			}
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			switch (_mode)
			{
				case ActionMode.Add:
					this.btnItemCode.Enabled = true;
					this.btnAutoCreateItemNo.Enabled = this.btnItemCode.Enabled;
					this.txtItemNo.Enabled = this.btnItemCode.Enabled;
					break;
				case ActionMode.Edit:
					this.btnItemCode.Enabled = false;
					this.btnAutoCreateItemNo.Enabled = this.btnItemCode.Enabled;
					this.txtItemNo.Enabled = this.btnItemCode.Enabled;
					break;
			}

			if (!string.IsNullOrEmpty(this.txtItemCode.Text) &&
				!string.IsNullOrEmpty(this.txtItemNo.Text) &&
				!string.IsNullOrEmpty(this.txtUnitCount.Text))
			{
				this.btnSave.Enabled = true;
			}
			else
			{
				this.btnSave.Enabled = false;
			}
		} // end UpdateUI

		private void SetNewItemInfo()
		{
			this.txtStartDate.Text = DateTime.Today.ToShortDateString();
			this.cbxProductStyle.SelectedValue = "1";
			this.cbxMaterial.SelectedValue = "1";
			this.txtCastingPrice.Text = "0.00";
			this.txtUnitPrice.Text = "0.00";
			this.txtWaxWeight.Text = "0.00";
			this.txtUnitWeight.Text = "0.00";
			this.txtScore.Text = "1.00";

			this.UpdateUI();

		} // end SetNewItemInfo

		private void GetPriceItemInfo(int ItemId)
		{
			string _imageLocation = string.Empty;
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				// loading price list item - info
				var pl = (from p in _oldmoon.CUSTPRICELISTs
						  where p.PRICESEQ == ItemId
						  select p).FirstOrDefault();

				// more - code here
				_imageLocation = pl.IMAGE_LOCATION;
				this.txtItemCode.Text = this.GetItemCodeText(pl.PREFIX);
				this.txtItemNo.Text = pl.ITEMNO;
				this.txtItemName.Text = pl.ITEMNAME;
				this.lbItemCode.Text = pl.PREFIX;
				this.cbxMaterial.SelectedValue = pl.MATERIAL;
				this.cbxProductStyle.SelectedValue = pl.PRODUCTSTYLE;
				this.txtCastingPrice.Text = string.Format("{0:N2}", pl.CASTINGPRICE);
				this.txtUnitPrice.Text = string.Format("{0:N2}", pl.UNITPRICE);
				this.txtStartDate.Text = OMControls.OMUtils.Num2Date(pl.PRICEEFFECTIVEDATE).ToShortDateString();
				this.txtEndDate.Text = OMControls.OMUtils.Num2Date(pl.PRICEEXPIREDATE).ToShortDateString();
				this.txtScore.Text = string.Format("{0:N2}", pl.SCOREPRICE);
				this.txtUnitCount.Text = pl.UNITCOUNT;
				this.txtWaxWeight.Text = string.Format("{0:N2}", pl.WAXWEIGHT);
				this.txtUnitWeight.Text = string.Format("{0:N2}", pl.UNITWEIGHT);

				if (!string.IsNullOrEmpty(_imageLocation))
				{
					this.pic.Image = Casting.CastingController.PriceListDAL.GetPriceListItemPicture(_imageLocation);
					//Image.FromFile(_imageLocation);
				}
				else
				{
					this.pic.Image = null;
				}
			}

			this.UpdateUI();

		} // end GetPriceItemInfo

		private void GetMaterial()
		{
			this.cbxMaterial.DataSource = Tools.SelectOptions.GetMaterialData();
			this.cbxMaterial.DisplayMember = "VALUE";
			this.cbxMaterial.ValueMember = "KEY";

		} // end GetMaterial

		private void GetProductStyle()
		{
			this.cbxProductStyle.DataSource = Tools.SelectOptions.GetProductStyleData();
			this.cbxProductStyle.DisplayMember = "VALUE";
			this.cbxProductStyle.ValueMember = "KEY";
		}

		private string GetItemCodeText(string Code)
		{
			string _result = string.Empty;

			DataTable _dt = Tools.SelectOptions.GetItemCodeData();
			foreach (DataRow dr in _dt.Rows)
			{
				if (dr["KEY"].ToString() == Code)
				{
					_result = dr["VALUE"].ToString();
					break;
				}
			}

			return _result;

		} // end GetItemCodeText

		private void SaveNewPriceItem()
		{
			//string _fileName = string.Empty;
			string _fullPathName = string.Empty;
			int _newId = 0;

			if (this.pic.Image != null)
			{
				//_fileName = string.Format("{0}{1}", this.txtItemNo.Text, omglobal.IMAGE_EXTENSION);
				//_fullPathName = string.Format("{0}\\{1}", omglobal.IMAGE_LOCATION_PATH, _fileName);
				_fullPathName = Casting.CastingController.PriceListDAL.CreateImageFilePath(this.txtItemNo.Text);
			}

			using (var scope = new System.Transactions.TransactionScope())
			{
				using (OLDMOONEF _oldmoon = new OLDMOONEF())
				{
					CUSTPRICELIST _cp = new CUSTPRICELIST();
					_cp.PREFIX = this.lbItemCode.Text;
					_cp.ITEMNO = this.txtItemNo.Text;
					_cp.ITEMNAME = this.txtItemName.Text;
					_cp.CUSTID = _customerId;
					_cp.CUSTCODE = _customerCode;
					_cp.HASPICTURE = this.pic.Image != null ? true : false;
					_cp.IMAGE_LOCATION = @_fullPathName;
					_cp.MATERIAL = Convert.ToInt32(this.lbMatId.Text);
					_cp.PRICEEFFECTIVEDATE = OMControls.OMUtils.Date2Num(this.txtStartDate.Text);
					_cp.PRICEEXPIREDATE = OMControls.OMUtils.Date2Num(this.txtEndDate.Text);
					_cp.PRODUCTSTYLE = Convert.ToInt32(this.cbxProductStyle.SelectedValue);
					_cp.SCOREPRICE = Convert.ToDecimal(this.txtScore.Text);
					_cp.UNITCOUNT = this.txtUnitCount.Text;
					_cp.CASTINGPRICE = Convert.ToDecimal(this.txtCastingPrice.Text);
					_cp.UNITPRICE = Convert.ToDecimal(this.txtUnitPrice.Text);
					_cp.UNITWEIGHT = Convert.ToDecimal(this.txtUnitWeight.Text);
					_cp.WAXWEIGHT = Convert.ToDecimal(this.txtWaxWeight.Text);
					_cp.AUDITUSER = omglobal.UserName;
					_cp.DATEENTRY = DateTime.Now;
					_cp.DATEMODIFY = DateTime.Now;

					// not define value
					_cp.ISDELETE = false;
					_cp.HASBLOCK = false;
					_cp.SIZE = string.Empty;
					_cp.HEIGHT = 0.00m;
					_cp.WIDTH = 0.00m;
					_cp.THICK = 0.00m;
					_cp.BLOCKID = string.Empty;
					_cp.BLOCKLOC = string.Empty;

					//
					try
					{
						_oldmoon.CUSTPRICELISTs.Add(_cp);
						_oldmoon.SaveChanges();

						// get new record - id
						var _id = (from u in _oldmoon.CUSTPRICELISTs
								   select u).Max(id => id.PRICESEQ);
						_newId = Convert.ToInt32(_id);

						scope.Complete();
					}
					catch (OptimisticConcurrencyException ex)
					{
						throw new Exception("Add new Price Item failed....", ex);
					}
				} //end
			} // end scope

			// Add/Update Item-Picture
			if (!string.IsNullOrEmpty(_fullPathName))
			{
				this.AddUpdatePriceItemPicture(_fullPathName);
			}

		} // end SaveNewPriceItem

		private void UpdatePriceItem(int ItemId)
		{
			//string _fileName = string.Empty;
			string _fullPathName = string.Empty;
			if (this.pic.Image != null)
			{
				_fullPathName = Casting.CastingController.PriceListDAL.CreateImageFilePath(this.txtItemNo.Text);
			}

			using (var scope = new System.Transactions.TransactionScope())
			{
				using (OLDMOONEF _oldmoon = new OLDMOONEF())
				{
					var pl = (from p in _oldmoon.CUSTPRICELISTs
							  where p.PRICESEQ == ItemId
							  select p).FirstOrDefault();

					try
					{
						pl.PREFIX = this.lbItemCode.Text;
						pl.ITEMNAME = this.txtItemName.Text;
						pl.HASPICTURE = this.pic.Image == null ? false : true;
						pl.IMAGE_LOCATION = @_fullPathName;
						pl.MATERIAL = Convert.ToInt32(this.lbMatId.Text);
						pl.PRICEEFFECTIVEDATE = OMControls.OMUtils.Date2Num(this.txtStartDate.Text);
						pl.PRICEEXPIREDATE = OMControls.OMUtils.Date2Num(this.txtEndDate.Text);
						pl.PRODUCTSTYLE = Convert.ToInt32(this.cbxProductStyle.SelectedValue);
						pl.SCOREPRICE = Convert.ToDecimal(this.txtScore.Text);
						pl.UNITCOUNT = this.txtUnitCount.Text;
						pl.CASTINGPRICE = Convert.ToDecimal(this.txtCastingPrice.Text);
						pl.UNITPRICE = Convert.ToDecimal(this.txtUnitPrice.Text);
						pl.UNITWEIGHT = Convert.ToDecimal(this.txtUnitWeight.Text);
						pl.WAXWEIGHT = Convert.ToDecimal(this.txtWaxWeight.Text);
						pl.AUDITUSER = omglobal.UserName;
						pl.DATEMODIFY = DateTime.Now;

						// not define value
						pl.SIZE = string.Empty;
						pl.HEIGHT = 0.00m;
						pl.WIDTH = 0.00m;
						pl.THICK = 0.00m;
						pl.HASBLOCK = false;
						pl.BLOCKID = string.Empty;
						pl.BLOCKLOC = string.Empty;
						//
						_oldmoon.SaveChanges();
						scope.Complete();
						omglobal.DisplayAlert("Update", "Update Price Item success....");
					}
					catch (OptimisticConcurrencyException ex)
					{
						throw new Exception("Update Price Item information failed...", ex);
					}
				} // end
			} // end scope

			// update Item-Picture
			this.AddUpdatePriceItemPicture(@_fullPathName);

		} // end UpdatePriceItem

		private void AddUpdatePriceItemPicture(string FullPathImageFileName)
		{
			// prepare the image before save
			OMControls.OMImageDB _imgDb;
			_imgDb = new OMControls.OMImageDB();

			if (this.pic.Image != null)
			{
				// resizing the source Image
				this.pic.Image = _imgDb.ResizeImage((Bitmap)this.pic.Image, 150, 175, 80);

				OMControls.OMUtils.SaveImageToFile(@FullPathImageFileName, OMControls.OMUtils.ConvertImage2Byte(this.pic.Image));
			}

		} // end AddUpdatePriceItemPicture


		private string CreateAutoNumber(string CustomerCode, int CustomerId)
		{
			string _result = string.Empty;
			int _lastNumber = 0;

			using (OLDMOONEF _om = new OLDMOONEF())
			{
				var priceItem = (from p in _om.CUSTPRICELISTs
								 select p).ToList();

				_lastNumber = Convert.ToInt32(priceItem.Count()) + 1;
			}

			string _newItem = "000000".Substring(0, (6 - _lastNumber.ToString().Length)) + _lastNumber.ToString();

			// set result for return
			_result = string.Format("{0}-{1}", _customerId, _newItem);

			return _result;

		} // end CreateAutoNumber

		private void GetFieldOption(SelectTypeOption Option)
		{
			//
			// this method will loading select-box depend on the option giving
			//
			Tools.SelectOptions.GetData(Option, ref _value, ref _code, ref _id);

		} // end GetFieldOption

		#endregion

		public CastingPriceListItemInfo()
		{
			InitializeComponent();
		}

		private void CastingPriceListItemInfo_Load(object sender, EventArgs e)
		{
			// loading select-data
			this.GetMaterial();
			this.GetProductStyle();

			// set mode
			_mode = (_itemId == 0 ? ActionMode.Add : ActionMode.Edit);

			// display-mode
			this.lbMode.Text = _mode.ToString().ToUpper();
			this.lbItemId.Text = string.Format("{0}", _itemId);

			switch (_mode)
			{
				case ActionMode.Add:
					this.SetNewItemInfo();
					break;
				case ActionMode.Edit:
					this.GetPriceItemInfo(_itemId);
					break;
			}
		}

		private void btnLoadPicture_Click(object sender, EventArgs e)
		{
			OMControls.OMImageDB _imageDB = new OMControls.OMImageDB();
			this.pic.Image = _imageDB.GetImageFile();
		}

		private void btnItemCode_Click(object sender, EventArgs e)
		{
			this.GetFieldOption(SelectTypeOption.CastingCode);
			this.txtItemCode.Text = _value;
			this.lbItemCode.Text = _code;
			this.UpdateUI();
		}

		private void bthStartDate_ButtonClick(object sender, EventArgs e)
		{
			this.btnStartDate.SelectedDate = string.IsNullOrEmpty(this.txtStartDate.Text) ? DateTime.Today : Convert.ToDateTime(this.txtStartDate.Text);
		}

		private void btnStartDate_DateSelected(object sender, EventArgs e)
		{
			// get value back from month selected
			DateTime _startDate = OMControls.OMUtils.IsDate(this.btnStartDate.SelectedDate) ? this.btnStartDate.SelectedDate : DateTime.Today;

			// display selected date
			this.txtStartDate.Text = _startDate.ToShortDateString();

		}

		private void btnAutoCreateItemNo_Click(object sender, EventArgs e)
		{
			this.txtItemNo.Text = this.CreateAutoNumber(_customerCode, _customerId);
		}

		private void cbxMaterial_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cbxMaterial.SelectedValue.GetType() == typeof(System.String))
			{
				this.lbMatId.Text = this.cbxMaterial.SelectedValue.ToString();
			}
		}

		private void cbxProductStyle_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cbxProductStyle.SelectedValue.GetType() == typeof(System.String))
			{
				this.lbMatId.Text = this.cbxProductStyle.SelectedValue.ToString();
			}
		}

		private void btnEndDate_ButtonClick(object sender, EventArgs e)
		{
			this.btnEndDate.SelectedDate = string.IsNullOrEmpty(this.txtEndDate.Text) ? DateTime.Today : Convert.ToDateTime(this.txtEndDate.Text);

		}

		private void btnEndDate_DateSelected(object sender, EventArgs e)
		{
			DateTime _endDate = OMControls.OMUtils.IsDate(this.btnEndDate.SelectedDate) ? this.btnEndDate.SelectedDate : DateTime.Today;

			this.txtEndDate.Text = _endDate.ToShortDateString();

		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.pic.Image = null;
		}

		private void btnUnit_Click(object sender, EventArgs e)
		{
			this.GetFieldOption(SelectTypeOption.UnitCount);
			this.txtUnitCount.Text = _value;
			this.UpdateUI();
		}

		private void txtStartDate_TextChanged(object sender, EventArgs e)
		{
			if (OMControls.OMUtils.IsDate(this.txtStartDate.Text))
			{
				this.txtEndDate.Text = Convert.ToDateTime(this.txtStartDate.Text).AddDays(60).ToShortDateString();
			}
			else
			{
				this.txtEndDate.Text = DateTime.Today.AddDays(60).ToShortDateString();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					this.SaveNewPriceItem();
					break;
				case ActionMode.Edit:
					this.UpdatePriceItem(_itemId);
					break;
			}

			this.Close();
		}

		private void txtUnitCount_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void txtScore_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtScore_Validating(object sender, CancelEventArgs e)
		{
			if (Information.IsNumeric(this.txtScore.Text))
			{
				if ((Convert.ToDecimal(this.txtScore.Text) < 0.00m) || (Convert.ToDecimal(this.txtScore.Text) > 5.00m))
				{
					MessageBox.Show("ไม่สามารถใส่ค่าที่น้อยกว่าศูนย์ (0) หรือ มากกว่าห้า (5)ได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.txtScore.Focus();
					e.Cancel = false;
				}
				else
				{
					e.Cancel = true;
				}
			}
		}

		private void txtScore_Validated(object sender, EventArgs e)
		{
			if (Information.IsNumeric(this.txtScore.Text))
			{
				if ((Convert.ToDecimal(this.txtScore.Text) < 0.00m) || (Convert.ToDecimal(this.txtScore.Text) > 5.00m))
				{
					MessageBox.Show("ไม่สามารถใส่ค่าที่น้อยกว่าศูนย์ (0) หรือ มากกว่าห้า (5)ได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.txtScore.Focus();
				}
			}
		}

		private void txtScore_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Tab))
			{
				if (Information.IsNumeric(this.txtScore.Text))
				{
					if ((Convert.ToDecimal(this.txtScore.Text) < 0.00m) || (Convert.ToDecimal(this.txtScore.Text) > 5.00m))
					{
						MessageBox.Show("ไม่สามารถใส่ค่าที่น้อยกว่าศูนย์ (0) หรือ มากกว่าห้า (5)ได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						this.txtScore.Focus();
					}
				}
			}
		}
	}
}
