using Microsoft.VisualBasic;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingPriceListItemInfo : Form
	{
		// CONSTRUCTOR
		public CastingPriceListItemInfo()
		{
			InitializeComponent();
		}

		private void CastingPriceListItemInfo_Load(object sender, EventArgs e)
		{
			// loading select-data
			GetMaterial();
			GetProductStyle();

			// set mode
			_mode = ItemId == 0 ? ActionMode.Add : ActionMode.Edit;

			// display-mode
			lbMode.Text = _mode.ToString().ToUpper();
			lbItemId.Text = string.Format("{0}", ItemId);

			switch (_mode)
			{
				case ActionMode.Add:
					_isModifyImage = true;
					SetNewItemInfo();
					break;
				case ActionMode.Edit:
					GetPriceItemInfo(ItemId);
					break;
			}
		}

		private void btnLoadPicture_Click(object sender, EventArgs e)
		{
			var _imageDB = new OMImageDB();
			pic.Image = _imageDB.GetImageFile();
			_isModifyImage = pic.Image == null ? false : true;
		}

		private void btnItemCode_Click(object sender, EventArgs e)
		{
			GetFieldOption(SelectTypeOption.CastingCode);
			txtItemType.Text = _value;
			lbItemCode.Text = _code;
			UpdateUI();
		}

		private void bthStartDate_ButtonClick(object sender, EventArgs e)
		{
			btnStartDate.SelectedDate = string.IsNullOrEmpty(txtStartDate.Text)
				? DateTime.Today
				: Convert.ToDateTime(txtStartDate.Text);
		}

		private void btnStartDate_DateSelected(object sender, EventArgs e)
		{
			// get value back from month selected
			var _startDate = btnStartDate.SelectedDate.IsDate() ? btnStartDate.SelectedDate : DateTime.Today;

			// display selected date
			txtStartDate.Text = _startDate.ToShortDateString();
		}

		private void btnAutoCreateItemNo_Click(object sender, EventArgs e)
		{
			txtItemNo.Text = CreateAutoNumber(CustomerCode, CustomerId);
		}

		private void cbxMaterial_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				lbMatId.Text = cbxMaterial.SelectedValue.ToString();
			}
			catch
			{
				lbMatId.Text = "";
			}
		}

		private void btnEndDate_ButtonClick(object sender, EventArgs e)
		{
			btnEndDate.SelectedDate = string.IsNullOrEmpty(txtEndDate.Text)
				? DateTime.Today
				: Convert.ToDateTime(txtEndDate.Text);
		}

		private void btnEndDate_DateSelected(object sender, EventArgs e)
		{
			var _endDate = btnEndDate.SelectedDate.IsDate() ? btnEndDate.SelectedDate : DateTime.Today;
			txtEndDate.Text = _endDate.ToShortDateString();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			pic.Image = null;
			_isModifyImage = true;
		}

		private void btnUnit_Click(object sender, EventArgs e)
		{
			GetFieldOption(SelectTypeOption.UnitCount);
			txtUnitCount.Text = _value;
			UpdateUI();
		}

		private void txtStartDate_TextChanged(object sender, EventArgs e)
		{
			if (txtStartDate.Text.IsDate())
				txtEndDate.Text = Convert.ToDateTime(txtStartDate.Text).AddDays(60).ToShortDateString();
			else
				txtEndDate.Text = DateTime.Today.AddDays(60).ToShortDateString();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					SaveNewPriceItem();
					break;
				case ActionMode.Edit:
					UpdatePriceItem(ItemId);
					break;
			}

			Close();
		}

		private void txtUnitCount_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		//private void txtScore_Validating(object sender, CancelEventArgs e)
		//{
		//	if (Information.IsNumeric(txtScore.Text))
		//		if (Convert.ToDecimal(txtScore.Text) < 0.00m || Convert.ToDecimal(txtScore.Text) > 5.00m)
		//		{
		//			MessageBox.Show("ไม่สามารถใส่ค่าที่น้อยกว่าศูนย์ (0) หรือ มากกว่าห้า (5)ได้", "Error", MessageBoxButtons.OK,
		//				MessageBoxIcon.Error);
		//			txtScore.Focus();
		//			e.Cancel = false;
		//		}
		//		else
		//		{
		//			e.Cancel = true;
		//		}
		//}

		private void txtScore_Validated(object sender, EventArgs e)
		{
			if (Information.IsNumeric(txtScore.Text))
				if (Convert.ToDecimal(txtScore.Text) < 0.00m || Convert.ToDecimal(txtScore.Text) > 5.00m)
				{
					MessageBox.Show("ไม่สามารถใส่ค่าที่น้อยกว่าศูนย์ (0) หรือ มากกว่าห้า (5)ได้", "Error", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					txtScore.Focus();
				}
		}

		private void txtScore_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
				if (Information.IsNumeric(txtScore.Text))
					if (Convert.ToDecimal(txtScore.Text) < 0.00m || Convert.ToDecimal(txtScore.Text) > 5.00m)
					{
						MessageBox.Show("ไม่สามารถใส่ค่าที่น้อยกว่าศูนย์ (0) หรือ มากกว่าห้า (5)ได้", "Error", MessageBoxButtons.OK,
							MessageBoxIcon.Error);
						txtScore.Focus();
					}
		}

		private void cbxMaterial_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_selectedMaterialId = Convert.ToInt32(cbxMaterial.SelectedValue);
			lbMatId.Text = _selectedMaterialId.ToString();
		}

		private void lbItemCode_TextChanged(object sender, EventArgs e)
		{
			switch (lbItemCode.Text)
			{
				case "L":
				case "M":
					_selectMaterialCategory = "SILICONE";
					break;
				case "S":
				case "R":
				case "W":
				case "P":
					_selectMaterialCategory = "";
					break;
				default:
					_selectMaterialCategory = "";
					break;
			}

			if (_mode == ActionMode.Add)
			{
				GetMaterial(_selectMaterialCategory);
			}
			else
			{
				GetMaterial();
			}
		}

		#region class field member

		private ActionMode _mode = ActionMode.None;
		private bool _isModifyImage = true;
		private string _selectMaterialCategory = string.Empty;
		private string _value = string.Empty;
		private string _code = string.Empty;
		private int _selectedMaterialId;
		private int _id;

		#endregion

		#region class properties

		public int CustomerId
		{
			get; set;
		}

		public string CustomerCode
		{
			get; set;
		}

		public string CustomerName
		{
			get; set;
		}

		public int ItemId
		{
			get; set;
		}

		public Image ItemImage
		{
			get; set;
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			switch (_mode)
			{
				case ActionMode.Add:
					btnItemCode.Enabled = true;
					btnAutoCreateItemNo.Enabled = btnItemCode.Enabled;
					txtItemNo.Enabled = btnItemCode.Enabled;
					break;
				case ActionMode.Edit:
					btnItemCode.Enabled = false;
					btnAutoCreateItemNo.Enabled = btnItemCode.Enabled;
					txtItemNo.Enabled = btnItemCode.Enabled;
					break;
			}

			if (!string.IsNullOrEmpty(txtItemType.Text) &&
				!string.IsNullOrEmpty(txtItemNo.Text) &&
				!string.IsNullOrEmpty(txtUnitCount.Text))
				btnSave.Enabled = true;
			else
				btnSave.Enabled = false;
		} // end UpdateUI

		private void SetNewItemInfo()
		{
			txtStartDate.Text = DateTime.Today.ToShortDateString();
			cbxProductStyle.SelectedValue = "1";
			cbxMaterial.SelectedValue = "1";
			txtCastingPrice.Text = "0.00";
			txtUnitPrice.Text = "0.00";
			txtWaxWeight.Text = "0.00";
			txtUnitWeight.Text = "0.00";
			txtScore.Text = "1.00";
			txtCastTemp.Text = "0";
			txtFalskTemp.Text = "0";

			UpdateUI();
		} // end SetNewItemInfo

		private void GetPriceItemInfo(int ItemId)
		{
			var _imageLocation = string.Empty;
			using (var _oldmoon = new OLDMOONEF1())
			{
				var pl = _oldmoon.CUSTPRICELISTs.Single(x => x.PRICESEQ == ItemId);

				// more - code here
				_imageLocation = pl.IMAGE_LOCATION;

				// display image location
				_selectedMaterialId = pl.MATERIAL;
				lbImagePath.Text = _imageLocation;
				lbItemCode.Text = pl.PREFIX;
				txtItemType.Text = new PriceListDAL().GetItemCodeText(pl.PREFIX);
				txtItemNo.Text = pl.ITEMNO;
				txtItemName.Text = pl.ITEMNAME;
				cbxMaterial.SelectedValue = _selectedMaterialId;
				cbxProductStyle.SelectedValue = pl.PRODUCTSTYLE;
				txtCastingPrice.Text = string.Format("{0:N2}", pl.CASTINGPRICE);
				txtUnitPrice.Text = string.Format("{0:N2}", pl.UNITPRICE);
				txtStartDate.Text = pl.PRICEEFFECTIVEDATE.Num2Date().ToShortDateString();
				txtEndDate.Text = pl.PRICEEXPIREDATE.Num2Date().ToShortDateString();
				txtScore.Text = string.Format("{0:N2}", pl.SCOREPRICE);
				txtUnitCount.Text = pl.UNITCOUNT;
				txtWaxWeight.Text = string.Format("{0:N2}", pl.WAXWEIGHT);
				txtUnitWeight.Text = string.Format("{0:N2}", pl.UNITWEIGHT);
				txtCastTemp.Text = pl.CAST_TEMP;
				txtFalskTemp.Text = pl.FLASK_TEMP;

				if (!string.IsNullOrEmpty(_imageLocation))
				{
					pic.Image = ItemImage;
				}
				else
				{
					pic.Image = null;
				}
			}

			UpdateUI();
		} // end GetPriceItemInfo

		private void GetMaterial()
		{
			cbxMaterial.DataSource = new CastingDAL().GetMaterialData();
			cbxMaterial.DisplayMember = "VALUE";
			cbxMaterial.ValueMember = "KEY";
		} // end GetMaterial

		private void GetMaterial(string Category)
		{
			cbxMaterial.DataSource = new CastingDAL().GetMaterialData(Category);
			cbxMaterial.DisplayMember = "VALUE";
			cbxMaterial.ValueMember = "KEY";
		}

		private void GetProductStyle()
		{
			cbxProductStyle.DataSource = new SelectOptions().GetProductStyleData();
			cbxProductStyle.DisplayMember = "VALUE";
			cbxProductStyle.ValueMember = "KEY";
		}

		private void SaveNewPriceItem()
		{
			var fullPathName = string.Empty;
			var _newId = 0;
			var itemNoStr = lbItemCode.Text + CustomerId + txtItemNo.Text;
			if (pic.Image != null)
				fullPathName = PriceListDAL.CreateImageFilePath(itemNoStr);

				using (var _oldmoon = new OLDMOONEF1())
				{
					var _cp = new CUSTPRICELIST();
					_cp.CUSTID = CustomerId;
					_cp.CUSTCODE = CustomerCode;
					_cp.IMAGE_LOCATION = fullPathName;
					_cp.PREFIX = lbItemCode.Text;
					_cp.ITEMNO = txtItemNo.Text.ToUpper();
					_cp.ITEMNAME = txtItemName.Text.ToUpper();
					_cp.HASPICTURE = pic.Image != null ? true : false;
					_cp.MATERIAL = Convert.ToInt32(lbMatId.Text);
					_cp.FLASK_TEMP = txtFalskTemp.Text;
					_cp.CAST_TEMP = txtCastTemp.Text;
					_cp.PRICEEFFECTIVEDATE = txtStartDate.Text.Date2Num();
					_cp.PRICEEXPIREDATE = txtEndDate.Text.Date2Num();
					_cp.PRODUCTSTYLE = Convert.ToInt32(cbxProductStyle.SelectedValue);
					_cp.SCOREPRICE = Convert.ToDecimal(txtScore.Text);
					_cp.UNITCOUNT = txtUnitCount.Text;
					_cp.CASTINGPRICE = Convert.ToDecimal(txtCastingPrice.Text);
					_cp.UNITPRICE = Convert.ToDecimal(txtUnitPrice.Text);
					_cp.UNITWEIGHT = Convert.ToDecimal(txtUnitWeight.Text);
					_cp.WAXWEIGHT = Convert.ToDecimal(txtWaxWeight.Text);
					_cp.AUDITUSER = omglobal.UserInfo;
					_cp.DATEENTRY = DateTime.Now;
					_cp.MODIUSER = omglobal.UserInfo;
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

					}
					catch (OptimisticConcurrencyException ex)
					{
						throw new Exception("Add new Price Item failed....", ex);
					}
			} // end scope

			// Add/Update Item-Picture
			if (!string.IsNullOrEmpty(fullPathName))
			{
				AddUpdatePriceItemPicture(fullPathName);
			}

		} // end SaveNewPriceItem

		private void UpdatePriceItem(int ItemId)
		{
			//string _fileName = string.Empty;
			var itemNoStr = lbItemCode.Text + CustomerId + txtItemNo.Text;

			var fullPathName = string.Empty;
			if (pic.Image != null)
				fullPathName = PriceListDAL.CreateImageFilePath(itemNoStr);

			// display full path for saving image
			lbImagePath.Text = fullPathName;

			using (var _oldmoon = new OLDMOONEF1())
			{
				var pl = (from p in _oldmoon.CUSTPRICELISTs
							 where p.PRICESEQ == ItemId
							 select p).Single();

				try
				{
					pl.PREFIX = lbItemCode.Text;
					pl.ITEMNAME = txtItemName.Text;
					pl.HASPICTURE = pic.Image == null ? false : true;
					pl.IMAGE_LOCATION = fullPathName;
					pl.MATERIAL = Convert.ToInt32(lbMatId.Text);
					pl.FLASK_TEMP = txtFalskTemp.Text;
					pl.CAST_TEMP = txtCastTemp.Text;
					pl.PRICEEFFECTIVEDATE = txtStartDate.Text.Date2Num();
					pl.PRICEEXPIREDATE = txtEndDate.Text.Date2Num();
					pl.PRODUCTSTYLE = Convert.ToInt32(cbxProductStyle.SelectedValue);
					pl.SCOREPRICE = Convert.ToDecimal(txtScore.Text);
					pl.UNITCOUNT = txtUnitCount.Text;
					pl.CASTINGPRICE = Convert.ToDecimal(txtCastingPrice.Text);
					pl.UNITPRICE = Convert.ToDecimal(txtUnitPrice.Text);
					pl.UNITWEIGHT = Convert.ToDecimal(txtUnitWeight.Text);
					pl.WAXWEIGHT = Convert.ToDecimal(txtWaxWeight.Text);
					pl.MODIUSER = omglobal.UserInfo;
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
					Alert.DisplayAlert("Update", "Update Price Item success....");
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Update Price Item information failed...", ex);
				}
			} // end scope

			// update Item-Picture
			if (_isModifyImage)
			{
				AddUpdatePriceItemPicture(fullPathName);
			}

		} // end UpdatePriceItem

		private void AddUpdatePriceItemPicture(string FullPathImageFileName)
		{
			// prepare the image before save
			//OMControls.OMImageDB _imgDb;
			//_imgDb = new OMControls.OMImageDB();

			if (pic.Image != null)
			{
				pic.Image.ToImageResize(150, 170).SaveImageToFile(FullPathImageFileName);
			}

		} // end AddUpdatePriceItemPicture


		private string CreateAutoNumber(string CustomerCode, int CustomerId)
		{
			var _result = string.Empty;
			var _lastNumber = 0;

			using (var _om = new OLDMOONEF1())
			{
				var priceItem = (from p in _om.CUSTPRICELISTs
									  select p).ToList();

				_lastNumber = Convert.ToInt32(priceItem.Count()) + 1;
			}

			var _newItem = "000000".Substring(0, 6 - _lastNumber.ToString().Length) + _lastNumber;

			// set result for return
			_result = $"{CustomerId}-{_newItem}";

			return _result;
		} // end CreateAutoNumber

		private void GetFieldOption(SelectTypeOption Option)
		{
			//
			// this method will loading select-box depend on the option giving
			//
			ToolGetData.GetData(Option, ref _value, ref _code, ref _id);

		} // end GetFieldOption

		#endregion
	}
}