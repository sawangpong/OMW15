using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers;
using OMW15.Models;
using OMW15.Shared;
using OMW15.Views;

namespace OMW15.Casting.CastingView
{
	public partial class CastingPriceList : Form
	{

		#region class field member

		private enum FindWhat
		{
			รหัสสินค้า,
			ชื่อสินค้า
		}

		private FindWhat _findOption = FindWhat.รหัสสินค้า;
		private ActionMode _mode = ActionMode.None;
		private bool _selectedItemHasImage = false;
		private Image _selectedItemImage = null;
		private int _customerId = 0;
		private int _sysCustomerId = 0;
		private int _selectedPriceListItemId = 0;
		private int _selectedItemStyleId = 0;
		private int _selectedItemMaterialId = 0;
		private string _customerCode = string.Empty;
		private string _customerName = string.Empty;
		private string _selectedItemStyle = string.Empty;
		private string _selectedItemMaterial = string.Empty;
		private string _selectedItemName = string.Empty;
		private string _selectedItemNo = string.Empty;
		private string _selectedItemCode = string.Empty;
		private string _selectedItemCategory = string.Empty;
		private string _selectedImageFilePath = string.Empty;

		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.btnRefresh.Enabled = (this.dgv.Rows.Count > 0);
			this.cbxFindItem.Enabled = this.btnRefresh.Enabled;
			this.btnNew.Enabled = !string.IsNullOrEmpty(_customerCode);
			this.btnEdit.Enabled = (_selectedPriceListItemId > 0);
			this.btnOpenJob.Enabled = this.btnEdit.Enabled;

		} // end updateUI

		private void GetCustomer()
		{
			using (Views.CustomerView.CustomerSearch _cs = new Views.CustomerView.CustomerSearch())
			{
				_cs.StartPosition = FormStartPosition.CenterScreen;
				if (_cs.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					_customerId = _cs.CustomerId;
					_sysCustomerId = _cs.SysCustomerId;
					_customerCode = _cs.CustomerCode;
					_customerName = _cs.CustomerName;
				}
			}

			// load data
			this.tslbSelectedCustomer.Text = string.Format("({0}):[{1}] - {2}", _sysCustomerId, _customerCode, _customerName);
			this.GetPriceListByCustomer(_customerCode);

			this.UpdateUI();

		} // end GetCustomer


		private void GetItemPicture(string ImageFilePath)
		{
			_selectedItemImage = Casting.CastingController.PriceListDAL.GetPriceListItemPicture(ImageFilePath);
			this.pic.Image = _selectedItemImage;

		} // end GetItemPicture

		private void GetPriceListByCustomer(string CustomerCode)
		{
			//
			// update flag "HasPicture" in table CustPriceList
			//
			switch (new OMW15.Casting.CastingController.PriceListDAL().UpdateHasPictureFlag(CustomerCode))
			{
				case -1:
					//omglobal.DisplayAlert("Update Price List", "No record for update!!!");
					break;
				case 0:
					omglobal.DisplayAlert("Update Price List", "Update image Failed....");
					break;
				case 1:
					//omglobal.DisplayAlert("Update Price List", "Update successfully....");
					break;
			}

			this.dgv.SuspendLayout();

			// binding data to DataGridView
			this.dgv.DataSource = new Casting.CastingController.PriceListDAL().GetPriceListByCustomer(CustomerCode);

			// formatting DataGridView

			// hide column
			this.dgv.Columns["ID"].Visible = false;
			this.dgv.Columns["CUSTOMERCODE"].Visible = false;
			this.dgv.Columns["MATERIALID"].Visible = false;
			this.dgv.Columns["STYLEID"].Visible = false;
			this.dgv.Columns["HASIMAGE"].Visible = false;
			this.dgv.Columns["IMAGELOCATION"].Visible = false;

			// format alignment
			this.dgv.Columns["ITEMCODE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dgv.Columns["CASTINGPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["UNITPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["SCORE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["WEIGHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			// set Column-Header-Text
			this.dgv.Columns["ITEMTYPE"].HeaderText = "ประเภทงาน";
			this.dgv.Columns["ITEMCODE"].HeaderText = "รหัสงาน";
			this.dgv.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			this.dgv.Columns["ITEMNAME"].HeaderText = "ชื่อสนค้า";
			this.dgv.Columns["MATERIAL"].HeaderText = "วัสดุ";
			this.dgv.Columns["STYLE"].HeaderText = "แบบ";
			this.dgv.Columns["UNIT"].HeaderText = "หน่วยนับ";

			this.dgv.Columns["CASTINGPRICE"].HeaderText = "ค่าแรงหล่อ (THB)";
			this.dgv.Columns["UNITPRICE"].HeaderText = "ค่าหล่อรวมวัสดุ (THB)";
			this.dgv.Columns["SCORE"].HeaderText = "คะแนน";
			this.dgv.Columns["WEIGHT"].HeaderText = "น้ำหนัก (กรัม)";

			// set display column-mode
			this.dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
			this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgv.ResumeLayout();

			// update-UI
			this.lbRowFound.Text = string.Format("found : {0} record{1}", this.dgv.Rows.Count, (this.dgv.Rows.Count > 1 ? "s" : ""));
			this.UpdateUI();

		} // end GetPriceListByCustomer

		private void GetPriceListItemInfo(ActionMode Mode, int ItemId)
		{
			OMW15.Casting.CastingView.CastingPriceListItemInfo _priceItemInfo = new CastingPriceListItemInfo();
			_priceItemInfo.StartPosition = FormStartPosition.CenterScreen;
			_priceItemInfo.ItemId = _selectedPriceListItemId;
			_priceItemInfo.CustomerCode = _customerCode;
			_priceItemInfo.CustomerName = _customerName;
			_priceItemInfo.CustomerId = _sysCustomerId;
			//_priceItemInfo.CustomerId = _customerId;

			if (_priceItemInfo.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
			}

		} // end GetPriceListItemInfo

		private void AddJobOrder(int ItemId)
		{
			using (OMW15.Casting.CastingView.CastingJobInfo jobInfo = new CastingJobInfo())
			{
				jobInfo.StartPosition = FormStartPosition.CenterScreen;
				jobInfo.CreateMode = OMShareJobEnums.JobOrderCreatedMode.CreateFromPriceList;
				jobInfo.ItemId = ItemId;
				//jobInfo.CustomerId = _customerId;
				jobInfo.CustomerId = _sysCustomerId;
				jobInfo.CustomerCode = _customerCode;
				jobInfo.CustomerName = _customerName;
				jobInfo.ItemImage = _selectedItemImage;
				jobInfo.JobId = 0;
				jobInfo.JobCategory = _selectedItemCategory;
				jobInfo.StyleId = _selectedItemStyleId;
				jobInfo.StyleName = _selectedItemStyle;
				jobInfo.MaterialId = _selectedItemMaterialId;
				jobInfo.Material = _selectedItemMaterial;
				jobInfo.ShowDialog(this);

			} // end 
		} // end AddJobOrder

		private void CreateFindList()
		{
			this.cbxFindItem.DataSource = OMControls.OMDataUtils.GetValueList<FindWhat>();
			this.cbxFindItem.DisplayMember = "Value";
			this.cbxFindItem.ValueMember = "Key";

		} // end CreateFindList

		#endregion

		public CastingPriceList()
		{
			InitializeComponent();
			this.SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw
				| ControlStyles.UserPaint
				| ControlStyles.SupportsTransparentBackColor, true);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CastingPriceList_Load(object sender, EventArgs e)
		{
			// formatting DataGridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.CreateFindList();

			this.UpdateUI();
		}

		private void tsbtnSelectCustomer_Click(object sender, EventArgs e)
		{
			this.GetCustomer();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			this.GetPriceListByCustomer(_customerCode);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			// selected price list item-id
			_selectedItemHasImage = Convert.ToBoolean(this.dgv["HASIMAGE", e.RowIndex].Value);
			_selectedImageFilePath = this.dgv["IMAGELOCATION", e.RowIndex].Value.ToString();
			_selectedPriceListItemId = Convert.ToInt32(this.dgv["ID", e.RowIndex].Value);
			_selectedItemCode = this.dgv["ITEMCODE", e.RowIndex].Value.ToString();
			_selectedItemNo = this.dgv["ITEMNO", e.RowIndex].Value.ToString();
			_selectedItemName = this.dgv["ITEMNAME", e.RowIndex].Value.ToString();
			_selectedItemStyleId = Convert.ToInt32(this.dgv["STYLEID", e.RowIndex].Value);
			_selectedItemStyle = this.dgv["STYLE", e.RowIndex].Value.ToString();
			_selectedItemMaterialId = Convert.ToInt32(this.dgv["MATERIALID", e.RowIndex].Value);
			_selectedItemMaterial = this.dgv["MATERIAL", e.RowIndex].Value.ToString();
			_selectedItemCategory = this.dgv["ITEMTYPE", e.RowIndex].Value.ToString();

			// display selected item-id
			this.lbItemId.Text = string.Format("id : {0}", _selectedPriceListItemId);

			// display item-picture
			this.lbFileName.Text = _selectedImageFilePath;
			if (!string.IsNullOrEmpty(_selectedImageFilePath))
			{
				this.GetItemPicture(_selectedImageFilePath);
			}

			// update-UI
			this.UpdateUI();
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			_mode = ActionMode.Add;
			_selectedPriceListItemId = 0;
			this.GetPriceListItemInfo(_mode, _selectedPriceListItemId);

			// update 
			this.btnRefresh.PerformClick();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			_mode = ActionMode.Edit;
			this.GetPriceListItemInfo(_mode, _selectedPriceListItemId);

			// update 
			this.btnRefresh.PerformClick();

		}

		private void btnRefresh_Click_1(object sender, EventArgs e)
		{
			// load data
			this.GetPriceListByCustomer(_customerCode);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.btnEdit.PerformClick();
		}

		private void btnOpenJob_Click(object sender, EventArgs e)
		{
			this.AddJobOrder(_selectedPriceListItemId);
		}

		private void cbxFindItem_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.cbxFindItem.SelectedValue.GetType() == typeof(System.Int32))
			{
				_findOption = (FindWhat)Enum.ToObject(typeof(FindWhat), Convert.ToInt32(this.cbxFindItem.SelectedValue));
				if (this.dgv.Rows.Count > 0)
				{
					(this.dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(
		"[{0}] LIKE '%{1}%'", _findOption == FindWhat.รหัสสินค้า ? "ITEMNO" : "ITEMNAME", OMControls.OMDataUtils.GetFilter<string>(string.Format("กำหนด{0}ที่ต้องการค้นหา", _findOption == FindWhat.รหัสสินค้า ? "รหัสสินค้า" : "ชื่อสินค้า")));
				}
			}
		}
	}
}
