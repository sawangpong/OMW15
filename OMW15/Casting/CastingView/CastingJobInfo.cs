using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using OMControls;
using OMW15.Shared;

namespace OMW15.Casting.CastingView
{
	public partial class CastingJobInfo : Form
	{
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

		private ActionMode _mode = ActionMode.None;
		private OMShareJobEnums.JobOrderCreatedMode _createMode = OMShareJobEnums.JobOrderCreatedMode.CreateFromJobOrderList;
		private int _customerId = 0;
		private int _jobId = 0;
		private int _selectedJobStatus = (int)OMShareJobEnums.JobStatusEnum.Wait;
		private string _customerCode = string.Empty;
		private string _customerName = string.Empty;

		private Image _itemImage = null;
		private int _itemId = 0;
		private int _styleId = 0;
		private int _materialId = 0;
		private int _itemScore = 0;
		private string _itemNo = string.Empty;
		private string _itemName = string.Empty;
		private string _itemCode = string.Empty;
		private string _styleName = string.Empty;
		private string _material = string.Empty;
		private string _jobCategory = string.Empty;


		#endregion

		#region class property
		public OMShareJobEnums.JobOrderCreatedMode CreateMode
		{
			set
			{
				_createMode = value;
			}
		}

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

		public int JobId
		{
			set
			{
				_jobId = value;
			}
		}

		public int ItemId
		{
			set
			{
				_itemId = value;
			}
		}

		public int StyleId
		{

			set
			{
				_styleId = value;
			}
		}

		public string StyleName
		{
			set
			{
				_styleName = value;
			}
		}

		public string ItemNo
		{
			set
			{
				_itemNo = value;
			}
		}

		public string ItemName
		{
			set
			{
				_itemName = value;
			}
		}

		public string ItemCode
		{
			set
			{
				_itemCode = value;
			}
		}

		public int MaterialId
		{
			set
			{
				_materialId = value;
			}
		}

		public string Material
		{
			set
			{
				_material = value;
			}
		}

		public Image ItemImage
		{
			set
			{
				_itemImage = value;
			}
		}

		public string JobCategory
		{
			set
			{
				_jobCategory = value;
			}
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			switch (_createMode)
			{
				case OMShareJobEnums.JobOrderCreatedMode.CreateFromJobOrderList:
					this.btnCustomer.Enabled = (_mode == ActionMode.Add);
					this.btnItemNo.Enabled = (this.btnCustomer.Enabled && (!string.IsNullOrEmpty(_customerCode)));
					break;
				case OMShareJobEnums.JobOrderCreatedMode.CreateFromPriceList:
					this.btnCustomer.Enabled = false;
					this.btnItemNo.Enabled = (this.btnCustomer.Enabled && (!string.IsNullOrEmpty(_customerCode)));
					break;
			}

			this.lbCustomerCode.Text = string.Format("CID::{0}", _customerId);
			this.btnSave.Enabled = (Convert.ToDecimal(this.txtOrderQty.Text) > 0.00m);

		} // end UpdateUI

		private void GetJobStatus()
		{
			this.cbxJobStatus.DataSource = OMControls.OMDataUtils.GetValueList<OMShareJobEnums.JobStatusEnum>();
			this.cbxJobStatus.DisplayMember = "Value";
			this.cbxJobStatus.ValueMember = "Key";
		}

		#region Overload Method GetFieldOption

		private void GetItemPriceInfo(string CustomerCode)
		{
			using (OMW15.Casting.CastingView.PriceListByCustomerId _pinfo = new PriceListByCustomerId())
			{
				_pinfo.Title = "Select Item-No.";
				_pinfo.CustomerCode = CustomerCode;
				_pinfo.CustomerId = _customerId;
				_pinfo.CustomerName = this.txtCustomerName.Text;
				_pinfo.StartPosition = FormStartPosition.CenterScreen;

				if (_pinfo.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					_itemId = _pinfo.ItemId;
					_itemCode = _pinfo.ItemPrefix;
					this.txtJobCategory.Text = _pinfo.ItemCategory;
					this.txtItemPrefix.Text = _itemCode;
					this.txtItemNo.Text = _pinfo.ItemNo;
					this.txtItemName.Text = _pinfo.ItemName;
					this.txtUnitOrder.Text = _pinfo.Unit;
					this.txtCastingPrice.Text = string.Format("{0:N2}", _pinfo.CastingUnitPrice);
					this.txtUnitPrice.Text = string.Format("{0:N2}", _pinfo.UnitPrice);
					_itemScore = (int)_pinfo.ItemScore;
					_materialId = _pinfo.ItemMaterial;
					this.txtMaterial.Text = _pinfo.ItemMaterialName;
					this.txtSI.Text = string.Format("{0:N2}", OMW15.Casting.CastingController.PriceListDAL.GetMaterialSI(_materialId));
					_styleId = _pinfo.ItemStyle;
					this.txtProductStyle.Text = _pinfo.ItemStyleName;

					// display picture
					this.pic.Image = OMW15.Casting.CastingController.PriceListDAL.GetPriceListItemPicture(_pinfo.ItemNo);
				}
			}
		} // end GetItemPriceInfo

		private void GetFieldOption(FieldNeed Field, SelectTypeOption Option)
		{
			this.GetFieldOption(Field, Option, 0);

		} // end GetFieldOption

		private void GetFieldOption(FieldNeed Field, SelectTypeOption Option, int FilterId)
		{
			//
			// this method will loading select-box depend on the option giving
			//
			string _name = string.Empty;
			string _code = string.Empty;
			int _id = 0;

			switch (Field)
			{
				case FieldNeed.Customer:
					_name = this.txtCustomerName.Text;
					_code = this.txtCustomerCode.Text;
					_id = _customerId;
					break;
				case FieldNeed.Material:
					_name = this.txtMaterial.Text;
					_code = _materialId.ToString();
					_id = _materialId;
					break;
				case FieldNeed.ProductStyle:
					_name = this.txtProductStyle.Text;
					_code = _styleId.ToString();
					_id = _styleId;
					break;
				case FieldNeed.Unit:
					_name = this.txtUnitOrder.Text;
					break;
				case FieldNeed.WaxFinisher:
					_name = this.txtWaxFinisher.Text;
					break;
				case FieldNeed.WaxInjectWorker:
					_name = this.txtWaxInjector.Text;
					break;
			}

			// call option 
			Tools.SelectOptions.GetData(Option, ref _name, ref _code, ref _id);

			switch (Field)
			{
				case FieldNeed.Customer:
					this.txtCustomerName.Text = _name;
					_customerCode = _code;
					this.txtCustomerCode.Text = _customerCode;
					_customerId = new OMW15.Casting.CastingController.PriceListDAL().GetCustomerId(_code);
					break;
				case FieldNeed.ProductStyle:
					this.txtProductStyle.Text = _name;
					_styleId = Convert.ToInt32(_code);
					break;
				case FieldNeed.Material:
					this.txtMaterial.Text = _name;
					_materialId = Convert.ToInt32(_code);

					// get material SI
					this.txtSI.Text = string.Format("{0:N2}", OMW15.Casting.CastingController.PriceListDAL.GetMaterialSI(_materialId));
					break;
				case FieldNeed.Unit:
					this.txtUnitOrder.Text = _name;
					break;
				case FieldNeed.WaxFinisher:
					this.txtWaxFinisher.Text = _name;
					break;
				case FieldNeed.WaxInjectWorker:
					this.txtWaxInjector.Text = _name;
					break;
			}

			this.UpdateUI();

		} // end GetFieldOption

		#endregion

		private void SetNewJobOrder(int ItemId, OMShareJobEnums.JobOrderCreatedMode CreateMode)
		{
			// map data from properties - default
			this.cbxJobStatus.SelectedValue = 1;
			this.txtJobCategory.Text = _jobCategory;
			this.txtJobCategory.Tag = _itemCode;
			this.txtCustomerName.Text = _customerName;
			this.txtCustomerCode.Text = _customerCode;
			this.txtCustomerCode.Tag = _customerId;
			this.txtJobNo.Text = "***NEW***";
			this.txtOrderQty.Text = "0";
			this.txtFinishQty.Text = "0";
			this.txtBackOrderQty.Text = "0";
			this.txtCustPODate.Text = DateTime.Today.ToShortDateString();
			this.txtJobDate.Text = DateTime.Today.ToShortDateString();
			this.txtDueDate.Text = DateTime.Today.AddDays(3).ToShortDateString();
			this.txtProductStyle.Text = _styleName;
			this.txtMaterial.Text = _material;
			this.pic.Image = _itemImage;
			this.txtSI.Text = string.Format("{0:N2}", OMW15.Casting.CastingController.PriceListDAL.GetMaterialSI(_materialId));

			// select data as giving CreateMode
			switch (CreateMode)
			{
				case OMShareJobEnums.JobOrderCreatedMode.CreateFromJobOrderList:
					_itemScore = 0;
					this.txtItemPrefix.Text = string.Empty;
					this.txtItemNo.Text = string.Empty;
					this.txtItemName.Text = string.Empty;
					this.txtCastingPrice.Text = string.Format("{0:N2}", 0);
					this.txtUnitPrice.Text = string.Format("{0:N2}", 0);
					this.txtUnitOrder.Text = string.Empty;
					this.pic.Image = null;
					break;

				case OMShareJobEnums.JobOrderCreatedMode.CreateFromPriceList:
					// loading price list item from given item-id
					// otherwise, manual search
					if (ItemId > 0)
					{
						CUSTPRICELIST cp = new Casting.CastingController.PriceListDAL().GetCustomerPriceListItemInfo(ItemId);
						_itemScore = (int)cp.SCOREPRICE;
						this.txtItemPrefix.Text = cp.PREFIX;
						this.txtItemNo.Text = cp.ITEMNO;
						this.txtItemName.Text = cp.ITEMNAME;
						this.txtUnitOrder.Text = cp.UNITCOUNT;
						this.txtCastingPrice.Text = string.Format("{0:N2}", cp.CASTINGPRICE);
						this.txtUnitPrice.Text = string.Format("{0:N2}", cp.UNITPRICE);

						// get image
						// --- add code for finding image
						if (_itemImage != null)
						{
							this.pic.Image = _itemImage;
						}
					}
					break;
			}
		} // end SetNewJobOrder

		private void GetJobOrderInfo(int JobId)
		{
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				JOBORDER _job = new Casting.CastingController.JobDAL().GetJobOrderInfo(JobId);

				// map to control
				_customerCode = _job.CUSTCODE;
				_customerId = _job.CUSTID;
				_selectedJobStatus = _job.STATUS;

				_itemId = (int)_job.ITEMID;
				_materialId = _job.MATERIALTYPE;
				_styleId = _job.ITEMSTYLE;
				_jobCategory = _job.PREFIX;
				_itemCode = _job.PREFIX;
				_itemNo = _job.ITEMNO;
				_itemName = _job.ITEMNAME;

				this.chkRepairJob.Checked = _job.ISREWORKS;
				this.cbxJobStatus.SelectedValue = _selectedJobStatus;
				this.txtCustomerCode.Text = _customerCode;
				this.txtCustomerName.Text = OMW15.Casting.CastingController.PriceListDAL.GetCustomerName(_customerCode);
				this.txtJobDate.Text = OMControls.OMUtils.Num2Date(_job.JOBDATE).ToShortDateString();
				this.txtJobNo.Text = _job.JOBNO.ToString();
				this.txtCustPO.Text = _job.CUSTPO;
				this.txtCustPODate.Text = (_job.PODATE == 0 ? string.Empty : OMControls.OMUtils.Num2Date(_job.PODATE).ToShortDateString());
				this.txtStartDate.Text = (_job.STARTDATE == 0 ? string.Empty : OMControls.OMUtils.Num2Date(_job.STARTDATE).ToShortDateString());
				this.txtDueDate.Text = (_job.DUEDATE == 0 ? string.Empty : OMControls.OMUtils.Num2Date(_job.DUEDATE).ToShortDateString());
				this.txtJobCategory.Text = new OMW15.Casting.CastingController.JobDAL().GetItemCategory(_itemCode);
				this.txtItemPrefix.Text = _itemCode;
				this.txtItemNo.Text = _itemNo;
				this.txtItemName.Text = _itemName;
				this.txtProductStyle.Text = OMW15.Casting.CastingController.PriceListDAL.GetProductStyle(_styleId);
				this.txtMaterial.Text = OMW15.Casting.CastingController.PriceListDAL.GetMaterialName(_materialId);
				this.txtSI.Text = string.Format("{0:N2}", _job.SI);
				this.txtUnitOrder.Text = _job.ORDERUNIT;
				this.txtOrderQty.Text = string.Format("{0:N2}", _job.ORDERQTY);
				this.txtFinishQty.Text = string.Format("{0:N2}", _job.FINISHEDQTY);
				this.txtBackOrderQty.Text = string.Format("{0:N2}", _job.BACKORDQTY);
				this.txtCastingPrice.Text = String.Format("{0:N2}", _job.CASTINGPRICE);
				this.txtTotalCastingPrice.Text = string.Format("{0:N2}", _job.TOTALCASTINGPRICE);
				this.txtUnitPrice.Text = string.Format("{0:N2}", _job.UNITPRICE);
				this.txtTotalPrice.Text = string.Format("{0:N2}", _job.TOTALPRICE);
				this.txtScore.Text = string.Format("{0:N0}", 0);
				this.txtWaxInjector.Text = _job.WAXWORKER;
				this.txtWaxFinisher.Text = _job.FINISHINGWORKER;
				this.txtRemark.Text = _job.REMARK;

			} // end

			// get more property info for PriceListItem
			CUSTPRICELIST cp = new Casting.CastingController.PriceListDAL().GetCustomerPriceListItemInfo(_itemId);
			_itemScore = (int)cp.SCOREPRICE;

			this.pic.Image = _itemImage;

		} // end GetJobOrderInfo

		private decimal CalBackOrderQty(decimal OrderQty, decimal FinishQty)
		{
			return (OrderQty - FinishQty);

		} // end CalBackOrderQty

		private int CalScore(decimal FinishQty, decimal ItemScore)
		{
			return (int)(FinishQty * ItemScore);
		}

		private void SaveNewJobOrder()
		{
			JOBORDER _jobOrder = new JOBORDER();
			_jobOrder.ACTUALPRODUCTIONQTY = 0;
			_jobOrder.AUDITDATE = OMControls.OMUtils.Date2Num(DateTime.Today);
			_jobOrder.AUDITUSER = omglobal.UserName;
			_jobOrder.CASTINGPRICE = Convert.ToDecimal(this.txtCastingPrice.Text);
			_jobOrder.CUSTCODE = _customerCode;
			_jobOrder.CUSTID = _customerId;
			_jobOrder.CUSTPO = this.txtCustPO.Text;
			_jobOrder.DELIVERYDATE = 0;
			_jobOrder.DELIVERYQTY = 0;
			_jobOrder.DOCNUM = string.Empty;
			_jobOrder.STARTDATE = OMControls.OMUtils.Date2Num(this.txtStartDate.Text);
			_jobOrder.RELEASEDATE = OMControls.OMUtils.Date2Num(this.txtStartDate.Text);
			_jobOrder.DUEDATE = OMControls.OMUtils.Date2Num(this.txtDueDate.Text);
			_jobOrder.FINISHDATE = 0;
			_jobOrder.FINISHEDQTY = Convert.ToDecimal(this.txtFinishQty.Text);
			_jobOrder.FINISHINGWORKER = this.txtWaxFinisher.Text;
			_jobOrder.ISCANCEL = false;
			_jobOrder.ISPRINTED = false;
			_jobOrder.ISREWORKS = this.chkRepairJob.Checked;
			_jobOrder.ITEMID = _itemId;
			_jobOrder.ITEMNAME = this.txtItemName.Text;
			_jobOrder.ITEMNO = this.txtItemNo.Text;
			_jobOrder.ITEMSTYLE = _styleId;
			_jobOrder.JOBDATE = OMControls.OMUtils.Date2Num(this.txtJobDate.Text);
			_jobOrder.MATERIALTYPE = _materialId;
			_jobOrder.MODIDATE = OMControls.OMUtils.Date2Num(DateTime.Today);
			_jobOrder.MODIUSER = omglobal.UserName;
			_jobOrder.ORDERQTY = Convert.ToDecimal(this.txtOrderQty.Text);
			_jobOrder.ORDERUNIT = this.txtUnitOrder.Text;
			_jobOrder.PODATE = OMControls.OMUtils.Date2Num(this.txtCustPODate.Text);
			_jobOrder.PREFIX = this.txtItemPrefix.Text;
			_jobOrder.REMARK = this.txtRemark.Text;
			_jobOrder.SI = Convert.ToDecimal(this.txtSI.Text);
			_jobOrder.STARTDATE = OMControls.OMUtils.Date2Num(this.txtStartDate.Text);
			_jobOrder.STATUS = Convert.ToInt32(this.cbxJobStatus.SelectedValue);
			_jobOrder.TOTALCASTINGPRICE = Convert.ToDecimal(this.txtTotalCastingPrice.Text);
			_jobOrder.TOTALPRICE = Convert.ToDecimal(this.txtTotalPrice.Text);
			_jobOrder.TOTALWAXWEIGHT = 0.00m;
			_jobOrder.TOTALWEIGHT = 0.00m;
			_jobOrder.UNITPRICE = Convert.ToDecimal(this.txtUnitPrice.Text);
			_jobOrder.UNITWEIGHT = 0.00m;
			_jobOrder.WAXUNITWEIGHT = 0.00m;
			_jobOrder.WAXWORKER = this.txtWaxInjector.Text;
			_jobOrder.CASTING = (this.txtItemPrefix.Text == "S" || this.txtItemPrefix.Text == "R" ? true : false);
			_jobOrder.WAX = (this.txtItemPrefix.Text == "W" ? true : false);
			_jobOrder.MAKEBLOCK = (this.txtItemPrefix.Text == "L" || this.txtItemPrefix.Text == "M" ? true : false);

			if (new Casting.CastingController.JobDAL().AddJobOrder(_jobOrder) > 0)
			{
				omglobal.DisplayAlert("Message", "Add Job Order Completed.....");
			}

		} // end SaveNewJobOrder

		private void UpdateJobOrder(int JobNo)
		{
			JOBORDER _jobOrder = new JOBORDER();

			_jobOrder.ACTUALPRODUCTIONQTY = 0;
			_jobOrder.MODIDATE = OMControls.OMUtils.Date2Num(DateTime.Today);
			_jobOrder.MODIUSER = omglobal.UserName;
			_jobOrder.STATUS = Convert.ToInt32(this.cbxJobStatus.SelectedValue);
			_jobOrder.CUSTCODE = _customerCode;
			_jobOrder.CUSTID = _customerId;
			_jobOrder.PODATE = OMControls.OMUtils.Date2Num(this.txtCustPODate.Text);
			_jobOrder.CUSTPO = this.txtCustPO.Text;
			_jobOrder.JOBDATE = OMControls.OMUtils.Date2Num(this.txtJobDate.Text);
			_jobOrder.STARTDATE = OMControls.OMUtils.Date2Num(this.txtStartDate.Text);
			_jobOrder.RELEASEDATE = OMControls.OMUtils.Date2Num(this.txtStartDate.Text);
			_jobOrder.DUEDATE = OMControls.OMUtils.Date2Num(this.txtDueDate.Text);
			_jobOrder.FINISHEDQTY = Convert.ToDecimal(this.txtFinishQty.Text);
			_jobOrder.ISCANCEL = false;
			_jobOrder.ISPRINTED = false;
			_jobOrder.ISREWORKS = this.chkRepairJob.Checked;
			_jobOrder.ITEMID = _itemId;
			_jobOrder.PREFIX = this.txtItemPrefix.Text;
			_jobOrder.ITEMNO = this.txtItemNo.Text;
			_jobOrder.ITEMNAME = this.txtItemName.Text;
			_jobOrder.ITEMSTYLE = _styleId;
			_jobOrder.MATERIALTYPE = _materialId;
			_jobOrder.ORDERQTY = Convert.ToDecimal(this.txtOrderQty.Text);
			_jobOrder.ORDERUNIT = this.txtUnitOrder.Text;
			_jobOrder.REMARK = this.txtRemark.Text;
			_jobOrder.SI = Convert.ToDecimal(this.txtSI.Text);
			_jobOrder.CASTINGPRICE = Convert.ToDecimal(this.txtCastingPrice.Text);
			_jobOrder.TOTALCASTINGPRICE = Convert.ToDecimal(this.txtTotalCastingPrice.Text);
			_jobOrder.UNITPRICE = Convert.ToDecimal(this.txtUnitPrice.Text);
			_jobOrder.TOTALPRICE = Convert.ToDecimal(this.txtTotalPrice.Text);
			_jobOrder.TOTALWAXWEIGHT = 0.00m;
			_jobOrder.TOTALWEIGHT = 0.00m;
			_jobOrder.UNITWEIGHT = 0.00m;
			_jobOrder.WAXUNITWEIGHT = 0.00m;
			_jobOrder.WAXWORKER = this.txtWaxInjector.Text;
			_jobOrder.FINISHINGWORKER = this.txtWaxFinisher.Text;
			_jobOrder.CASTING = (this.txtItemPrefix.Text == "S" || this.txtItemPrefix.Text == "R" ? true : false);
			_jobOrder.WAX = (this.txtItemPrefix.Text == "W" ? true : false);
			_jobOrder.MAKEBLOCK = (this.txtItemPrefix.Text == "L" || this.txtItemPrefix.Text == "M" ? true : false);

			if (new Casting.CastingController.JobDAL().UpdateJobOrder(JobNo, _jobOrder) > 0)
			{
				omglobal.DisplayAlert("Message", string.Format("Update Job Order {0} Completed.....", JobNo));
			}
		} // end UpdateJobOrder


		#endregion

		public CastingJobInfo()
		{
			InitializeComponent();
		}

		private void CastingJobInfo_Load(object sender, EventArgs e)
		{
			// update Mode
			_mode = (_jobId == 0 ? ActionMode.Add : ActionMode.Edit);

			// display mode
			this.lbMode.Text = _mode.ToString();
			this.GetJobStatus();

			// select loading data as giving mode
			switch (_mode)
			{
				case ActionMode.Add:
					this.SetNewJobOrder(_itemId, _createMode);
					break;
				case ActionMode.Edit:
					this.GetJobOrderInfo(_jobId);
					break;
			}

			// update-UI
			this.UpdateUI();
		}

		private void cbxJobStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cbxJobStatus.SelectedValue.GetType() == typeof(System.Int32))
			{
				_selectedJobStatus = Convert.ToInt32(this.cbxJobStatus.SelectedValue);
			}
			else
			{
				_selectedJobStatus = (int)OMShareJobEnums.JobStatusEnum.Wait;
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.pic.Image = null;
		}

		private void txtSI_Leave(object sender, EventArgs e)
		{
			this.txtSI.Text = string.Format("{0:P2}", this.txtSI.Text);
		}

		private void txtJobDate_TextChanged(object sender, EventArgs e)
		{
			this.txtStartDate.Text = (OMControls.OMUtils.IsDate(this.txtJobDate.Text) ? this.txtJobDate.Text : DateTime.Today.ToShortDateString());
		}

		private void txtStartDate_TextChanged(object sender, EventArgs e)
		{
			this.txtDueDate.Text = (OMControls.OMUtils.IsDate(this.txtStartDate.Text) ? Convert.ToDateTime(this.txtStartDate.Text).AddDays(3).ToShortDateString() : DateTime.Today.AddDays(3).ToShortDateString());
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			OMControls.OMImageDB _imageDB = new OMControls.OMImageDB();
			this.pic.Image = _imageDB.GetImageFile();
		}

		private void txtFinishQty_TextChanged(object sender, EventArgs e)
		{
			if (Information.IsNumeric(this.txtFinishQty.Text))
			{
				this.txtBackOrderQty.Text = string.Format("{0}", (Convert.ToDecimal(this.txtOrderQty.Text) - Convert.ToDecimal(this.txtFinishQty.Text)));
			}
			else
			{
				this.txtBackOrderQty.Text = this.txtOrderQty.Text;
			}

			if (Information.IsNumeric(this.txtFinishQty.Text))
			{
				this.txtScore.Text = string.Format("{0:N0}", _itemScore * Convert.ToDecimal(this.txtFinishQty.Text));
			}

			//if (OMControls.OMUtils.IsNumeric(this.txtFinishQty.Text))
			//{
			//	this.txtScore.Text = string.Format("{0:N0}", _itemScore * Convert.ToDecimal(this.txtFinishQty.Text));
			//}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					this.SaveNewJobOrder();
					break;
				case ActionMode.Edit:
					this.UpdateJobOrder(_jobId);
					break;
			}
		}

		#region Search Box Event

		private void btnSearch_Click(object sender, EventArgs e)
		{
			OMControls.OMFlatButton
			_btn = sender as OMControls.OMFlatButton;
			string _tag = _btn.Tag.ToString();
			FieldNeed _fieldName = FieldNeed.None;
			SelectTypeOption _option = SelectTypeOption.None;

			switch (_tag)
			{
				case "CUST":
					_fieldName = FieldNeed.Customer;
					_option = SelectTypeOption.Customer;
					break;
				//case "ITEM":
				//	_fieldName = FieldNeed.ItemNo;
				//	_option = SelectTypeOption.ItemNo;
				//	break;
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
					_option = SelectTypeOption.Worker;
					break;
				case "FINER":
					_fieldName = FieldNeed.WaxFinisher;
					_option = SelectTypeOption.Worker;
					break;
			}

			if (_tag == "ITEM")
			{
				this.GetItemPriceInfo(_customerCode);
			}
			else
			{
				this.GetFieldOption(_fieldName, _option);
			}
		}

		#endregion


		#region Month button Event

		private void btn_ButtonClick(object sender, EventArgs e)
		{
			OMControls.MonthPopup
			_btn = sender as OMControls.MonthPopup;
			string _title = "Select Date";
			string _tag = _btn.Tag.ToString();
			DateTime _defaultDate = DateTime.Today;

			switch (_tag)
			{
				case "JOB_DATE":
					_title = "Select Job Date";
					_defaultDate = string.IsNullOrEmpty(this.txtJobDate.Text) ? DateTime.Today : Convert.ToDateTime(this.txtJobDate.Text);
					break;
				case "PO_DATE":
					_title = "Select Customer P/O Date";
					_defaultDate = string.IsNullOrEmpty(this.txtCustPODate.Text) ? DateTime.Today : Convert.ToDateTime(this.txtCustPODate.Text);
					break;
				case "DO_DATE":
					_title = "Select Job Start Date";
					_defaultDate = string.IsNullOrEmpty(this.txtStartDate.Text) ? DateTime.Today : Convert.ToDateTime(this.txtStartDate.Text);
					break;
				case "DUE_DATE":
					_title = "Select Job Due Date";
					_defaultDate = string.IsNullOrEmpty(this.txtDueDate.Text) ? DateTime.Today : Convert.ToDateTime(this.txtDueDate.Text);
					break;
			}

			// send data to control
			_btn.Title = _title;
			_btn.SelectedDate = _defaultDate;

		}

		private void btn_DateSelected(object sender, EventArgs e)
		{
			OMControls.MonthPopup _btn = sender as OMControls.MonthPopup;
			string _tag = _btn.Tag.ToString();
			DateTime _result = OMControls.OMUtils.IsDate(_btn.SelectedDate) ? _btn.SelectedDate : DateTime.Today;

			switch (_tag)
			{
				case "JOB_DATE":
					this.txtJobDate.Text = _result.ToShortDateString();
					break;
				case "PO_DATE":
					this.txtCustPODate.Text = _result.ToShortDateString();
					break;
				case "DO_DATE":
					this.txtStartDate.Text = _result.ToShortDateString();
					break;
				case "DUE_DATE":
					this.txtDueDate.Text = _result.ToShortDateString();
					break;
			}
		}

		#endregion

		private void txtQty_TextChanged(object sender, EventArgs e)
		{
			// calculate Back-order-qty
			decimal _orderQty = (Information.IsNumeric(this.txtOrderQty.Text) ? Convert.ToDecimal(this.txtOrderQty.Text) : 0.00m);
			decimal _finishQty = (Information.IsNumeric(this.txtFinishQty.Text) ? Convert.ToDecimal(this.txtFinishQty.Text) : 0.00m);

			this.txtBackOrderQty.Text = string.Format("{0:N2}", this.CalBackOrderQty(_orderQty, _finishQty));

			// calculate - score
			this.txtScore.Text = string.Format("{0}", this.CalScore(_finishQty, _itemScore));

			// cal total-casting price
			this.txtTotalCastingPrice.Text = string.Format("{0:N2}", (_finishQty * Convert.ToDecimal(this.txtCastingPrice.Text)));

			// cal total - price
			this.txtTotalPrice.Text = string.Format("{0:N2}", _finishQty * Convert.ToDecimal(this.txtUnitPrice.Text));

			// update-UI
			this.UpdateUI();
		}

	}
}
