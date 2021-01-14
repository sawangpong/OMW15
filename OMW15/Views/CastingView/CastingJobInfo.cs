using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;
using static OMW15.Shared.OMShareJobEnums;

namespace OMW15.Views.CastingView
{


	public partial class CastingJobInfo : Form
	{
		public CastingJobInfo()
		{
			InitializeComponent();
		}

		private void CastingJobInfo_Load(object sender, EventArgs e)
		{
			CenterToParent();
			// update Mode
			_mode = _jobId == 0 ? ActionMode.Add : ActionMode.Edit;

			// display mode
			lbMode.Text = _mode.ToString();
			getJobPriority();
			GetJobStatus();

			// select loading data as giving mode
			switch (_mode)
			{
				case ActionMode.Add:
					SetNewJobOrder(_itemId, _createMode);
					break;
				case ActionMode.Edit:
					GetJobOrderInfo(_jobId);
					break;
			}

			// update-UI
			UpdateUI();
		}

		private void cbxJobStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbxJobStatus.SelectedValue.GetType() == typeof(int))
				_selectedJobStatus = Convert.ToInt32(cbxJobStatus.SelectedValue);
			else _selectedJobStatus = (int) OMShareJobEnums.JobStatusEnumEN.Active;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			pic.Image = null;
		}

		private void txtSI_Leave(object sender, EventArgs e)
		{
			txtSI.Text = $"{txtSI.Text:P2}";
		}

		private void txtJobDate_TextChanged(object sender, EventArgs e)
		{
			txtStartDate.Text = txtJobDate.Text.IsDate() ? txtJobDate.Text : DateTime.Today.ToShortDateString();
		}

		private void txtStartDate_TextChanged(object sender, EventArgs e)
		{
			txtDueDate.Text = txtStartDate.Text.IsDate()
				? Convert.ToDateTime(txtStartDate.Text).AddDays(omglobal.CASTING_DURATION_DAYS).ToShortDateString()
				: DateTime.Today.AddDays(omglobal.CASTING_DURATION_DAYS).ToShortDateString();
		}

		private void txtFinishQty_TextChanged(object sender, EventArgs e)
		{
			if (Information.IsNumeric(txtFinishQty.Text))
				txtBackOrderQty.Text = $"{decimal.Parse(txtOrderQty.Text) - Convert.ToDecimal(txtFinishQty.Text)}";
			else txtBackOrderQty.Text = txtOrderQty.Text;

			if (Information.IsNumeric(txtFinishQty.Text)) txtScore.Text = $"{_itemScore * decimal.Parse(txtFinishQty.Text):N0}";
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					SaveNewJobOrder();
					break;
				case ActionMode.Edit:
					UpdateJobOrder(_jobId);
					break;
			}
		}

		#region Search Box Event

		private void btnSearch_Click(object sender, EventArgs e)
		{
			var _btn = sender as OMFlatButton;
			var _tag = _btn.Tag.ToString();
			var _fieldName = FieldNeed.None;
			var _option = SelectTypeOption.None;

			switch (_tag)
			{
				case "CUST":
					_fieldName = FieldNeed.Customer;
					_option = SelectTypeOption.Customer;
					break;

				case "STYLE":
					_fieldName = FieldNeed.ProductStyle;
					_option = SelectTypeOption.ProductStyle;
					break;

				case "MAT":
					_fieldName = FieldNeed.Material;
					_option = SelectTypeOption.Material;
					break;

				case "UNIT":
					_fieldName = FieldNeed.Unit;
					_option = SelectTypeOption.UnitCount;
					break;

				case "WAXER":
					_fieldName = FieldNeed.WaxInjectWorker;
					_option = SelectTypeOption.WorkerById;
					break;

				case "FINER":
					_fieldName = FieldNeed.WaxFinisher;
					_option = SelectTypeOption.WorkerById;
					break;
			}

			//if (_tag == "ITEM") GetItemPriceInfo(_customerCode);
			//else 
			GetFieldOption(_fieldName, _option);
		}

		#endregion

		private void txtQty_TextChanged(object sender, EventArgs e)
		{
			// initial variables
			var _orderQty = Information.IsNumeric(txtOrderQty.Text) ? decimal.Parse(txtOrderQty.Text) : 0.00m;

			var _finishQty = Information.IsNumeric(txtFinishQty.Text) ? decimal.Parse(txtFinishQty.Text) : 0.00m;

			var _castingPrice = Information.IsNumeric(txtCastingPrice.Text) ? decimal.Parse(txtCastingPrice.Text) : 0.00m;

			// Back Order Qty
			txtBackOrderQty.Text = $"{CalBackOrderQty(_orderQty, _finishQty):N2}";

			// calculate - score
			txtScore.Text = $"{CalScore(_finishQty, _itemScore)}";

			// cal total-casting price
			txtTotalCastingPrice.Text = $"{_finishQty * _castingPrice:N2}";

			// update-UI
			UpdateUI();
		}

		private void rdoPrice_CheckedChanged(object sender, EventArgs e)
		{
			if (_itemId > 0)
			{
				priceItemInfo = GetItemPriceInfo(_itemId);
				castingWithMatPrice = priceItemInfo.UNITPRICE;
				castingPrice = priceItemInfo.CASTINGPRICE;
			}

			var rdo = sender as RadioButton;
			if (rdo.Checked)
				switch (rdo.Tag.ToString())
				{
					case "L":
						isPriceWithMat = false;
						txtCastingPrice.Text = $"{castingPrice:N2}";
						break;
					case "LM":
						isPriceWithMat = true;
						txtCastingPrice.Text = $"{castingWithMatPrice:N2}";
						break;
				}
		}

		#region class field member

		private enum FieldNeed
		{
			None,
			CastingCode,
			Customer,
			ItemNo,
			Material,
			ProductStyle,
			WaxInjectWorker,
			WaxFinisher,
			Unit
		}

		private readonly CastingDAL _m = new CastingDAL();
		private CUSTPRICELIST priceItemInfo;
		private ActionMode _mode = ActionMode.None;
		private OMShareJobEnums.JobOrderCreatedMode _createMode = OMShareJobEnums.JobOrderCreatedMode.CreateFromJobOrderList;
		private int _customerId;
		private int _jobId;
		private int _selectedJobStatus = (int) OMShareJobEnums.JobStatusEnumEN.Active;
		private string _customerCode = string.Empty;
		private string _customerName = string.Empty;

		private Image _itemImage;
		private int _itemId;
		private int _styleId;
		private int _materialId;
		private int _itemScore;
		private string _itemNo = string.Empty;
		private string _itemName = string.Empty;
		private string _itemCode = string.Empty;
		private string _styleName = string.Empty;
		private string _material = string.Empty;
		private string _jobCategory = string.Empty;

		private decimal castingPrice;
		private decimal castingWithMatPrice;
		private bool isPriceWithMat;

		#endregion

		#region class property

		public OMShareJobEnums.JobOrderCreatedMode CreateMode
		{
			set { _createMode = value; }
		}

		public int CustomerId
		{
			set { _customerId = value; }
		}

		public string CustomerCode
		{
			set { _customerCode = value; }
		}

		public string CustomerName
		{
			set { _customerName = value; }
		}

		public int JobId
		{
			set { _jobId = value; }
		}

		public int ItemId
		{
			set { _itemId = value; }
		}

		public int StyleId
		{
			set { _styleId = value; }
		}

		public string StyleName
		{
			set { _styleName = value; }
		}

		public string ItemNo
		{
			set { _itemNo = value; }
		}

		public string ItemName
		{
			set { _itemName = value; }
		}

		public string ItemCode
		{
			set { _itemCode = value; }
		}

		public int MaterialId
		{
			set { _materialId = value; }
		}

		public string Material
		{
			set { _material = value; }
		}

		public Image ItemImage
		{
			set { _itemImage = value; }
		}

		public string JobCategory
		{
			set { _jobCategory = value; }
		}

		public string CastingTemp { get; set; }

		public string FlaskTemp { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			switch (_createMode)
			{
				case OMShareJobEnums.JobOrderCreatedMode.CreateFromJobOrderList:
					btnCustomer.Enabled = _mode == ActionMode.Add;
					btnItemNo.Enabled = btnCustomer.Enabled && !string.IsNullOrEmpty(_customerCode);
					break;
				case OMShareJobEnums.JobOrderCreatedMode.CreateFromPriceList:
					btnCustomer.Enabled = false;
					btnItemNo.Enabled = btnCustomer.Enabled && !string.IsNullOrEmpty(_customerCode);
					break;
			}

			lbCustomerCode.Text = $"CID::{_customerId}";
			btnSave.Enabled = Convert.ToDecimal(txtOrderQty.Text) > 0.00m;
		} // end UpdateUI

		private void getJobPriority()
		{
			this.cbxPriority.DataSource = OMControls.EnumWithName<JobPriority>.ParseEnum();
			this.cbxPriority.DisplayMember = "NAME";
			this.cbxPriority.ValueMember = "VALUE";

		}

		private void GetJobStatus()
		{
			cbxJobStatus.DataSource = OMDataUtils.GetValueList<OMShareJobEnums.JobStatusEnumEN>();
			cbxJobStatus.DisplayMember = "Value";
			cbxJobStatus.ValueMember = "Key";
		}

		#region Overload Method GetFieldOption

		private void GetItemPriceInfo(string CustomerCode)
		{
			using (var _pinfo = new PriceListByCustomerId())
			{
				_pinfo.Title = "Select Item-No.";
				_pinfo.CustomerCode = CustomerCode;
				_pinfo.CustomerId = _customerId;
				_pinfo.CustomerName = txtCustomerName.Text;
				_pinfo.StartPosition = FormStartPosition.CenterScreen;

				castingPrice = _pinfo.CastingUnitPrice;
				castingWithMatPrice = _pinfo.UnitPrice;

				if (_pinfo.ShowDialog(this) == DialogResult.OK)
				{
					_itemId = _pinfo.ItemId;
					_itemCode = _pinfo.ItemPrefix;
					_itemScore = (int) _pinfo.ItemScore;
					_materialId = _pinfo.ItemMaterial;
					_styleId = _pinfo.ItemStyle;
					txtJobCategory.Text = _pinfo.ItemCategory;
					txtItemPrefix.Text = _itemCode;
					txtItemNo.Text = _pinfo.ItemNo;
					txtItemName.Text = _pinfo.ItemName;
					txtUnitOrder.Text = _pinfo.Unit;
					txtMaterial.Text = _pinfo.ItemMaterialName;
					txtSI.Text = string.Format("{0:N2}", _m.GetMaterialSI(_materialId));
					txtProductStyle.Text = _pinfo.ItemStyleName;
					txtFalskTemp.Text = _pinfo.FlaskTemp;
					txtCastTemp.Text = _pinfo.CastTemp;

					// display picture
					pic.Image = PriceListDAL.GetPriceListItemPicture(_pinfo.ItemPictureLocation);
				}
			}
		} // end GetItemPriceInfo

		private void GetFieldOption(FieldNeed Field, SelectTypeOption Option)
		{
			GetFieldOption(Field, Option, 0);
		} // end GetFieldOption

		private void GetFieldOption(FieldNeed Field, SelectTypeOption Option, int FilterId)
		{
			//
			// this method will loading select-box depend on the option giving
			//
			var _name = string.Empty;
			var _code = string.Empty;
			var _id = 0;

			switch (Field)
			{
				case FieldNeed.Customer:
					_name = txtCustomerName.Text;
					_code = txtCustomerCode.Text;
					_id = _customerId;
					break;
				case FieldNeed.Material:
					_name = txtMaterial.Text;
					_code = _materialId.ToString();
					_id = _materialId;
					break;
				case FieldNeed.ProductStyle:
					_name = txtProductStyle.Text;
					_code = _styleId.ToString();
					_id = _styleId;
					break;
				case FieldNeed.Unit:
					_name = txtUnitOrder.Text;
					break;
				case FieldNeed.WaxFinisher:
					_name = txtWaxFinisher.Text;
					break;
				case FieldNeed.WaxInjectWorker:
					_name = txtWaxInjector.Text;
					break;
			}

			// call option 
			ToolGetData.GetData(Option, ref _name, ref _code, ref _id);

			switch (Field)
			{
				case FieldNeed.Customer:
					txtCustomerName.Text = _name;
					_customerCode = _code;
					txtCustomerCode.Text = _customerCode;
					_customerId = new PriceListDAL().GetCustomerId(_code);
					break;
				case FieldNeed.ProductStyle:
					txtProductStyle.Text = _name;
					_styleId = Convert.ToInt32(_code);
					break;
				case FieldNeed.Material:
					txtMaterial.Text = _name;
					_materialId = Convert.ToInt32(_code);

					// get material SI
					txtSI.Text = string.Format("{0:N2}", new CastingDAL().GetMaterialSI(_materialId));
					break;
				case FieldNeed.Unit:
					txtUnitOrder.Text = _name;
					break;
				case FieldNeed.WaxFinisher:
					txtWaxFinisher.Text = _name;
					break;
				case FieldNeed.WaxInjectWorker:
					txtWaxInjector.Text = _name;
					break;
			}

			UpdateUI();
		} // end GetFieldOption

		#endregion

		private void SetNewJobOrder(int ItemId, OMShareJobEnums.JobOrderCreatedMode CreateMode)
		{
			// map data from properties - default
			cbxPriority.SelectedValue = (int)JobPriority.ปรกติ;
			cbxJobStatus.SelectedValue = 1;
			txtJobCategory.Text = _jobCategory;
			txtJobCategory.Tag = _itemCode;
			txtCustomerName.Text = _customerName;
			txtCustomerCode.Text = _customerCode;
			txtCustomerCode.Tag = _customerId;
			txtJobNo.Text = "***NEW***";
			txtOrderQty.Text = "0";
			txtFinishQty.Text = "0";
			txtBackOrderQty.Text = "0";
			txtCustPODate.Text = DateTime.Today.ToShortDateString();
			txtJobDate.Text = DateTime.Today.ToShortDateString();
			txtDueDate.Text = DateTime.Today.AddDays(3).ToShortDateString();
			txtProductStyle.Text = _styleName;
			txtMaterial.Text = _material;
			txtCastTemp.Text = CastingTemp;
			txtFalskTemp.Text = FlaskTemp;
			pic.Image = _itemImage;
			txtSI.Text = string.Format("{0:N2}", _m.GetMaterialSI(_materialId));
			rdoLabour.Checked = true;

			// select data as giving CreateMode
			switch (CreateMode)
			{
				case OMShareJobEnums.JobOrderCreatedMode.CreateFromJobOrderList:
					_itemScore = 0;
					txtItemPrefix.Text = string.Empty;
					txtItemNo.Text = string.Empty;
					txtItemName.Text = string.Empty;
					txtCastingPrice.Text = string.Format("{0:N2}", 0);
					txtUnitOrder.Text = string.Empty;
					pic.Image = null;
					break;

				case OMShareJobEnums.JobOrderCreatedMode.CreateFromPriceList:
					// loading price list item from given item-id
					// otherwise, manual search
					if (ItemId > 0)
					{
						// get information for price of the given item
						priceItemInfo = GetItemPriceInfo(ItemId);
						castingPrice = priceItemInfo.CASTINGPRICE;
						castingWithMatPrice = priceItemInfo.UNITPRICE;

						// mapping 
						_itemScore = (int) priceItemInfo.SCOREPRICE;
						txtItemPrefix.Text = priceItemInfo.PREFIX;
						txtItemNo.Text = priceItemInfo.ITEMNO;
						txtItemName.Text = priceItemInfo.ITEMNAME;
						txtUnitOrder.Text = priceItemInfo.UNITCOUNT;
						txtCastingPrice.Text = string.Format("{0:N2}", isPriceWithMat ? castingWithMatPrice : castingPrice);
						txtFalskTemp.Text = priceItemInfo.FLASK_TEMP;
						txtCastTemp.Text = priceItemInfo.CAST_TEMP;

						// get image
						// --- add code for finding image
						if (_itemImage != null) pic.Image = _itemImage;
					}
					break;
			}
		} // end SetNewJobOrder

		private CUSTPRICELIST GetItemPriceInfo(int itemId)
		{
			return new PriceListDAL().GetCustomerPriceListItemInfo(itemId);
		} // end GetItemPriceInfo


		private void GetJobOrderInfo(int JobId)
		{
			// get more property info for PriceListItem

			var _job = new JobDAL().GetJobHeaderInfo(JobId);

			// map to control
			_customerCode = _job.CUSTCODE;
			_customerId = _job.CUSTID;
			_selectedJobStatus = _job.STATUS;

			_itemId = (int) _job.ITEMID;
			_materialId = _job.MATERIALTYPE;
			_styleId = _job.ITEMSTYLE;
			_jobCategory = _job.PREFIX;
			_itemCode = _job.PREFIX;
			_itemNo = _job.ITEMNO;
			_itemName = _job.ITEMNAME;

			priceItemInfo = GetItemPriceInfo(_itemId);
			castingPrice = priceItemInfo.CASTINGPRICE;
			castingWithMatPrice = priceItemInfo.UNITPRICE;
			_itemScore = (int) priceItemInfo.SCOREPRICE;

			isPriceWithMat = _job.ISPRICEWITHMAT;
			cbxPriority.SelectedValue = _job.PRIORITY;
			chkRepairJob.Checked = _job.ISREWORKS;
			cbxJobStatus.SelectedValue = _selectedJobStatus;
			txtCustomerCode.Text = _customerCode;
			txtCustomerName.Text = new PriceListDAL().GetCustomerName(_customerCode);
			txtJobDate.Text = _job.JOBDATE.Num2Date().ToShortDateString();
			txtJobNo.Text = _job.JOBNO.ToString();

			// test generate barcode

			picBarCode.Image = Barcode.GenerateBitmapBarcode(txtJobNo.Text);

			// end

			txtCustPO.Text = _job.CUSTPO;
			txtCustPODate.Text = _job.PODATE == 0 ? string.Empty : _job.PODATE.Num2Date().ToShortDateString();
			txtStartDate.Text = _job.STARTDATE == 0 ? string.Empty : _job.STARTDATE.Num2Date().ToShortDateString();
			txtDueDate.Text = _job.DUEDATE == 0 ? string.Empty : _job.DUEDATE.Num2Date().ToShortDateString();
			txtJobCategory.Text = new JobDAL().GetItemCategory(_itemCode);
			txtItemPrefix.Text = _itemCode;
			txtItemNo.Text = _itemNo;
			txtItemName.Text = _itemName;
			txtProductStyle.Text = new PriceListDAL().GetProductStyle(_styleId);
			txtMaterial.Text = new CastingDAL().GetMaterialName(_materialId);
			txtCastTemp.Text = _job.CAST_TEMP;
			txtFalskTemp.Text = _job.FLASK_TEMP;
			txtSI.Text = string.Format("{0:N2}", _job.SI);
			txtUnitOrder.Text = _job.ORDERUNIT;
			txtOrderQty.Text = string.Format("{0:N2}", _job.ORDERQTY);
			txtFinishQty.Text = string.Format("{0:N2}", _job.FINISHEDQTY);
			txtBackOrderQty.Text = string.Format("{0:N2}", _job.BACKORDQTY);

			//this.rdoLabour.Checked = _job.ISPRICEWITHMAT;
			if (isPriceWithMat) rdoLabourWithMat.Checked = true;
			else rdoLabour.Checked = true;

			txtCastingPrice.Text = $"{_job.CASTINGPRICE:N2}";
			txtTotalCastingPrice.Text = $"{_job.TOTALCASTINGPRICE:N2}";
			txtScore.Text = string.Format("{0:N0}", 0);
			txtWaxInjector.Text = _job.WAXWORKER;
			txtWaxFinisher.Text = _job.FINISHINGWORKER;
			txtRemark.Text = _job.REMARK;
			pic.Image = _itemImage;
		} // end GetJobOrderInfo

		private decimal CalBackOrderQty(decimal OrderQty, decimal FinishQty)
		{
			return OrderQty - FinishQty;
		} // end CalBackOrderQty

		private int CalScore(decimal FinishQty, decimal ItemScore)
		{
			return (int) (FinishQty * ItemScore);
		}

		private void SaveNewJobOrder()
		{
			var _jobOrder = new JOBORDER();
			_jobOrder.ACTUALPRODUCTIONQTY = 0;
			_jobOrder.AUDITDATE = DateTime.Today.Date2Num();
			_jobOrder.AUDITUSER = omglobal.UserInfo;
			_jobOrder.CUSTCODE = _customerCode;
			_jobOrder.CUSTID = _customerId;
			_jobOrder.CUSTPO = txtCustPO.Text;
			_jobOrder.DELIVERYDATE = 0;
			_jobOrder.DELIVERYQTY = 0;
			_jobOrder.DOCNUM = string.Empty;
			_jobOrder.STARTDATE = txtStartDate.Text.Date2Num();
			_jobOrder.RELEASEDATE = txtStartDate.Text.Date2Num();
			_jobOrder.DUEDATE = txtDueDate.Text.Date2Num();
			_jobOrder.FINISHDATE = 0;
			_jobOrder.FINISHEDQTY = decimal.Parse(txtFinishQty.Text);
			_jobOrder.FINISHINGWORKER = txtWaxFinisher.Text;
			_jobOrder.ISCANCEL = false;
			_jobOrder.ISPRINTED = false;
			_jobOrder.ISREWORKS = chkRepairJob.Checked;
			_jobOrder.ITEMID = _itemId;
			_jobOrder.ITEMNAME = txtItemName.Text;
			_jobOrder.ITEMNO = txtItemNo.Text;
			_jobOrder.ITEMSTYLE = _styleId;
			_jobOrder.JOBDATE = txtJobDate.Text.Date2Num();
			_jobOrder.MATERIALTYPE = _materialId;
			_jobOrder.CAST_TEMP = txtCastTemp.Text;
			_jobOrder.FLASK_TEMP = txtFalskTemp.Text;
			_jobOrder.MODIDATE = DateTime.Today.Date2Num();
			_jobOrder.MODIUSER = omglobal.UserInfo;
			_jobOrder.ORDERQTY = decimal.Parse(txtOrderQty.Text);
			_jobOrder.ORDERUNIT = txtUnitOrder.Text;
			_jobOrder.PRIORITY = int.Parse(this.cbxPriority.SelectedValue.ToString());
			_jobOrder.PODATE = txtCustPODate.Text.Date2Num();
			_jobOrder.PREFIX = txtItemPrefix.Text;
			_jobOrder.REMARK = txtRemark.Text;
			_jobOrder.SI = decimal.Parse(txtSI.Text);
			_jobOrder.STARTDATE = txtStartDate.Text.Date2Num();
			_jobOrder.STATUS = Convert.ToInt32(cbxJobStatus.SelectedValue);
			_jobOrder.ISPRICEWITHMAT = isPriceWithMat;
			_jobOrder.CASTINGPRICE = decimal.Parse(txtCastingPrice.Text);
			_jobOrder.TOTALCASTINGPRICE = decimal.Parse(txtTotalCastingPrice.Text);
			_jobOrder.WAXUNITWEIGHT = 0.00m;
			_jobOrder.TOTALWAXWEIGHT = 0.00m;
			_jobOrder.UNITWEIGHT = 0.00m;
			_jobOrder.TOTALWEIGHT = 0.00m;
			_jobOrder.UNITPRICE = 0.00m;
			_jobOrder.TOTALPRICE = 0.00m;
			_jobOrder.WAXWORKER = txtWaxInjector.Text;
			_jobOrder.CASTING = txtItemPrefix.Text == "S" || txtItemPrefix.Text == "R" ? true : false;
			_jobOrder.WAX = txtItemPrefix.Text == "W" ? true : false;
			_jobOrder.MAKEBLOCK = txtItemPrefix.Text == "L" || txtItemPrefix.Text == "M" ? true : false;

			if (new JobDAL().AddJobOrder(_jobOrder) > 0) Alert.DisplayAlert("Message", "Add Job Order Completed.....");
		} // end SaveNewJobOrder

		private void UpdateJobOrder(int JobNo)
		{
			var _jobOrder = new JobDAL().GetJobHeaderInfo(JobNo);

			_jobOrder.ACTUALPRODUCTIONQTY = 0;
			_jobOrder.MODIDATE = DateTime.Today.Date2Num();
			_jobOrder.MODIUSER = omglobal.UserInfo;
			_jobOrder.STATUS = Convert.ToInt32(cbxJobStatus.SelectedValue);
			_jobOrder.CUSTCODE = _customerCode;
			_jobOrder.CUSTID = _customerId;
			_jobOrder.PODATE = txtCustPODate.Text.Date2Num();
			_jobOrder.CUSTPO = txtCustPO.Text;
			_jobOrder.JOBDATE = txtJobDate.Text.Date2Num();
			_jobOrder.STARTDATE = txtStartDate.Text.Date2Num();
			_jobOrder.RELEASEDATE = txtStartDate.Text.Date2Num();
			_jobOrder.DUEDATE = txtDueDate.Text.Date2Num();
			_jobOrder.FINISHEDQTY = decimal.Parse(txtFinishQty.Text);
			_jobOrder.ISCANCEL = false;
			_jobOrder.ISPRINTED = false;
			_jobOrder.ISREWORKS = chkRepairJob.Checked;
			_jobOrder.ITEMID = _itemId;
			_jobOrder.PREFIX = txtItemPrefix.Text;
			_jobOrder.ITEMNO = txtItemNo.Text;
			_jobOrder.ITEMNAME = txtItemName.Text;
			_jobOrder.ITEMSTYLE = _styleId;
			_jobOrder.MATERIALTYPE = _materialId;
			_jobOrder.CAST_TEMP = txtCastTemp.Text;
			_jobOrder.FLASK_TEMP = txtFalskTemp.Text;
			_jobOrder.ORDERQTY = decimal.Parse(txtOrderQty.Text);
			_jobOrder.ORDERUNIT = txtUnitOrder.Text;
			_jobOrder.PRIORITY = int.Parse(this.cbxPriority.SelectedValue.ToString());
			_jobOrder.REMARK = txtRemark.Text;
			_jobOrder.SI = decimal.Parse(txtSI.Text);
			_jobOrder.ISPRICEWITHMAT = isPriceWithMat;
			_jobOrder.CASTINGPRICE = decimal.Parse(txtCastingPrice.Text);
			_jobOrder.TOTALCASTINGPRICE = decimal.Parse(txtTotalCastingPrice.Text);
			_jobOrder.UNITPRICE = 0.00m;
			_jobOrder.TOTALPRICE = 0.00m;
			_jobOrder.TOTALWAXWEIGHT = 0.00m;
			_jobOrder.TOTALWEIGHT = 0.00m;
			_jobOrder.UNITWEIGHT = 0.00m;
			_jobOrder.WAXUNITWEIGHT = 0.00m;
			_jobOrder.WAXWORKER = txtWaxInjector.Text;
			_jobOrder.FINISHINGWORKER = txtWaxFinisher.Text;
			_jobOrder.CASTING = txtItemPrefix.Text == "S" || txtItemPrefix.Text == "R" ? true : false;
			_jobOrder.WAX = txtItemPrefix.Text == "W" ? true : false;
			_jobOrder.MAKEBLOCK = txtItemPrefix.Text == "L" || txtItemPrefix.Text == "M" ? true : false;

			if (new JobDAL().UpdateJobOrder(JobNo, _jobOrder) > 0)
				Alert.DisplayAlert("Message", string.Format("Update Job Order {0} Completed.....", JobNo));
		} // end UpdateJobOrder

		#endregion

		#region Month button Event

		private void btn_ButtonClick(object sender, EventArgs e)
		{
			var _btn = sender as MonthPopup;
			var _title = "Select Date";
			var _tag = _btn.Tag.ToString();
			var _defaultDate = DateTime.Today;

			switch (_tag)
			{
				case "JOB_DATE":
					_title = "Select Job Date";
					_defaultDate = string.IsNullOrEmpty(txtJobDate.Text) ? DateTime.Today : Convert.ToDateTime(txtJobDate.Text);
					break;
				case "PO_DATE":
					_title = "Select Customer P/O Date";
					_defaultDate = string.IsNullOrEmpty(txtCustPODate.Text) ? DateTime.Today : Convert.ToDateTime(txtCustPODate.Text);
					break;
				case "DO_DATE":
					_title = "Select Job Start Date";
					_defaultDate = string.IsNullOrEmpty(txtStartDate.Text) ? DateTime.Today : Convert.ToDateTime(txtStartDate.Text);
					break;
				case "DUE_DATE":
					_title = "Select Job Due Date";
					_defaultDate = string.IsNullOrEmpty(txtDueDate.Text) ? DateTime.Today : Convert.ToDateTime(txtDueDate.Text);
					break;
			}

			// send data to control
			_btn.Title = _title;
			_btn.SelectedDate = _defaultDate;
		}

		private void btn_DateSelected(object sender, EventArgs e)
		{
			var _btn = sender as MonthPopup;
			var _tag = _btn.Tag.ToString();
			var _result = _btn.SelectedDate.IsDate() ? _btn.SelectedDate : DateTime.Today;

			switch (_tag)
			{
				case "JOB_DATE":
					txtJobDate.Text = _result.ToShortDateString();
					break;
				case "PO_DATE":
					txtCustPODate.Text = _result.ToShortDateString();
					break;
				case "DO_DATE":
					txtStartDate.Text = _result.ToShortDateString();
					break;
				case "DUE_DATE":
					txtDueDate.Text = _result.ToShortDateString();
					break;
			}
		}

		#endregion
	}
}