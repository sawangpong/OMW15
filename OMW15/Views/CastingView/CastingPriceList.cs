using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;
using OMW15.Views.CustomerView;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingPriceList : Form
	{
		#region class field member

		private enum FindWhat
		{
			รหัสสินค้า,
			ชื่อสินค้า
		}

		private int _rowCount;

		private FindWhat _findOption = FindWhat.รหัสสินค้า;
		private ActionMode _mode = ActionMode.None;
		private Image _selectedItemImage;

		private bool _selectedItemHasImage;

#pragma warning disable CS0169 // The field 'CastingPriceList._selectedCustomerMatId' is never used
		private int _selectedCustomerMatId; // all materials
#pragma warning restore CS0169 // The field 'CastingPriceList._selectedCustomerMatId' is never used
		private int _erpCustomerId;
		private int _internalCustomerId;
		private int _selectedPriceListItemId;
		private int _selectedItemStyleId;

		//private int _selectedItemMaterialId;

		private string _customerCode = string.Empty;
		private string _customerName = string.Empty;
		private string _selectedItemStyle = string.Empty;
		
		//private string _selectedItemMaterial = string.Empty;

		private string _selectedItemName = string.Empty;
		private string _selectedItemNo = string.Empty;
		private string _selectedItemCode = string.Empty;

		private string _selectedItemCategory = string.Empty;

		private string _selectedImageFilePath = string.Empty;

		private string _selectedCastingTemp = string.Empty;
		private string _selectedFalskTemp = string.Empty;

		private string _selectedWorkType = string.Empty;

		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnRefresh.Enabled = dgv.Rows.Count > 0;
			cbxFindItem.Enabled = btnRefresh.Enabled;
			btnNew.Enabled = !string.IsNullOrEmpty(_customerCode);
			btnEdit.Enabled = _selectedPriceListItemId > 0;
			btnJobHistory.Enabled = btnEdit.Enabled;
			btnOpenJob.Enabled = btnEdit.Enabled;
		} // end updateUI

		private void GetCustomer()
		{
			using (var _cs = new CustomerSearch())
			{
				_cs.StartPosition = FormStartPosition.CenterParent;
				if (_cs.ShowDialog(this) == DialogResult.OK)
				{
					_erpCustomerId = _cs.ERPCustomerId;
					_internalCustomerId = _cs.InternalCustomerId;
					_customerCode = _cs.ERPCustomerCode;
					_customerName = _cs.CustomerName;
				}
			}

			// create list of material for given the customerCode
			GetWorkType(_customerCode);

			// load data
			tslbSelectedCustomer.Text = $"({_internalCustomerId}):[{_customerCode}] - {_customerName}";

			UpdateUI();
		} // end GetCustomer

		//private void GetMaterialList(string customerCode)
		//{
		//	var mat = new PriceListDAL().GetMaterialListFromCustomerPriceList(customerCode);

		//	mat.Add(new IMat
		//	{
		//		MatId = 0,
		//		MatName = "วัสดุทั้งหมด"
		//	});
		//	mat.OrderBy(o => o.MatId);

		//	cbxWorkType.DataSource = mat;
		//	cbxWorkType.DisplayMember = "MatName";
		//	cbxWorkType.ValueMember = "MatId";
		//}


		private void GetWorkType(string customerCode)
		{
			cbxWorkType.DataSource = new PriceListDAL().GetWorkTypeByCustomer(customerCode);
			cbxWorkType.DisplayMember = "WORKTYPE_NAME";
			cbxWorkType.ValueMember = "PREFIX";
		}

		private void GetItemPicture(string ImageFilePath)
		{
			_selectedItemImage = PriceListDAL.GetPriceListItemPicture(ImageFilePath);
			pic.Image = _selectedItemImage;
		} // end GetItemPicture

		//private async void GetPriceListByCustomer(string customerCode, int matId)
		private async void GetPriceListByCustomer(string customerCode, string workType)
		{
			// binding data to DataGridView
			var dal = new PriceListDAL();
			//var dt = await dal.GetPriceListByCustomerAsync(customerCode, matId);
			var dt = await dal.GetPriceListByCustomerAsync(customerCode, workType);

			_rowCount = dt.Rows.Count;

			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = dt;

			// hide column
			dgv.Columns["ID"].Visible = false;
			dgv.Columns["CUSTOMERCODE"].Visible = false;
			//dgv.Columns["MATERIALID"].Visible = false;
			dgv.Columns["STYLEID"].Visible = false;
			dgv.Columns["HASIMAGE"].Visible = false;
			dgv.Columns["IMAGELOCATION"].Visible = false;
			dgv.Columns["FLASKTEMP"].Visible = false;
			dgv.Columns["CASTTEMP"].Visible = false;
			//dgv.Columns["CASTINGPRICE"].Visible = false;
			//dgv.Columns["UNITPRICE"].Visible = false;
			//dgv.Columns["SCORE"].Visible = false;

			// formatting DataGridView
			// format alignment
			dgv.Columns["ITEMCODE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			foreach (DataGridViewColumn dgr in dgv.Columns)
			{
				if (dgr.ValueType == typeof(decimal))
				{
					dgr.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
			}

			// set Column-Header-Text
			dgv.Columns["ITEMTYPE"].HeaderText = "ประเภทงาน";
			dgv.Columns["ITEMCODE"].HeaderText = "รหัสงาน";
			dgv.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			dgv.Columns["ITEMNAME"].HeaderText = "ชื่อสนค้า / รายละเอียด";
			//dgv.Columns["MATERIAL"].HeaderText = "วัสดุ";
			dgv.Columns["STYLE"].HeaderText = "แบบ";
			//dgv.Columns["UNIT"].HeaderText = "หน่วยนับ";

			//dgv.Columns["CASTINGPRICE"].HeaderText = "ค่าแรงหล่อ (THB)";
			//dgv.Columns["UNITPRICE"].HeaderText = "ค่าหล่อรวมวัสดุ (THB)";
			//dgv.Columns["SCORE"].HeaderText = "คะแนน";
			dgv.Columns["WEIGHT"].HeaderText = "น้ำหนัก (กรัม)";
			dgv.Columns["FLASKTEMP"].HeaderText = "อุณหภูมิเบ้า";
			dgv.Columns["CASTTEMP"].HeaderText = "อุณหภูมิหล่อ";

			// set display column-mode
			dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
			//dgv.Columns["ITEMNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["ITEMNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			//dgv.Columns["MATERIAL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgv.ResumeLayout();

			// update-UI
			lbRowFound.Text = $"found : {dgv.Rows.Count} record{(dgv.Rows.Count > 1 ? "s" : "")}";
			UpdateUI();

		} // end GetPriceListByCustomer

		private void GetPriceListItemInfo(ActionMode Mode, int ItemId, Image ItemImage)
		{
			using (var _priceItemInfo = new CastingPriceListItemInfo())
			{
				_priceItemInfo.ItemImage = ItemImage;
				_priceItemInfo.StartPosition = FormStartPosition.CenterScreen;
				_priceItemInfo.ItemId = ItemId;
				//_priceItemInfo.MaterialId = matId;
				_priceItemInfo.CustomerCode = _customerCode;
				_priceItemInfo.CustomerName = _customerName;
				_priceItemInfo.CustomerId = _internalCustomerId;

				if (_priceItemInfo.ShowDialog(this) == DialogResult.OK)
				{
				}
			}
		} // end GetPriceListItemInfo

		private void AddJobOrder(int ItemId)
		{
			using (var jobInfo = new CastingJobInfo())
			{
				jobInfo.StartPosition = FormStartPosition.CenterScreen;
				jobInfo.CreateMode = OMShareJobEnums.JobOrderCreatedMode.CreateFromPriceList;
				jobInfo.ItemId = ItemId;
				jobInfo.CustomerId = _internalCustomerId;
				jobInfo.CustomerCode = _customerCode;
				jobInfo.CustomerName = _customerName;
				jobInfo.ItemImage = _selectedItemImage;
				jobInfo.JobId = 0;
				jobInfo.JobCategory = _selectedItemCategory;
				jobInfo.StyleId = _selectedItemStyleId;
				jobInfo.StyleName = _selectedItemStyle;
				
				//jobInfo.MaterialId = _selectedItemMaterialId;
				//jobInfo.Material = _selectedItemMaterial;

				jobInfo.CastingTemp = _selectedCastingTemp;
				jobInfo.FlaskTemp = _selectedFalskTemp;

				jobInfo.ShowDialog(this);
			} // end 
		} // end AddJobOrder

		private void CreateFindList()
		{
			cbxFindItem.DataSource = OMDataUtils.GetValueList<FindWhat>();
			cbxFindItem.DisplayMember = "Value";
			cbxFindItem.ValueMember = "Key";
		} // end CreateFindList

		private async void GetJobHistory(int ItemId)
		{
			dgvJobs.SuspendLayout();

			//var _jobs = await Task.Run(() =>
			//{
			//	return new JobDAL().SelectJobHistory(ItemId);
			//});

			dgvJobs.DataSource = await Task.Run(() =>
			{
				return new JobDAL().SelectJobHistory(ItemId);
			});

			foreach (DataGridViewColumn dgc in dgvJobs.Columns)
				if (dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
			dgvJobs.ResumeLayout();
		} // end GetJobHistory

		#endregion


		// CONSTRUCTOR
		public CastingPriceList()
		{
			InitializeComponent();
			SetStyle(ControlStyles.AllPaintingInWmPaint
					 | ControlStyles.OptimizedDoubleBuffer
					 | ControlStyles.ResizeRedraw
					 | ControlStyles.UserPaint
					 | ControlStyles.SupportsTransparentBackColor, true);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CastingPriceList_Load(object sender, EventArgs e)
		{
			// formatting DataGridView
			OMUtils.SettingDataGridView(ref dgv);
			OMUtils.SettingDataGridView(ref dgvJobs);

			CreateFindList();

			UpdateUI();
		}

		private void tsbtnSelectCustomer_Click(object sender, EventArgs e)
		{
			GetCustomer();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			GetPriceListByCustomer(_customerCode, _selectedWorkType);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			// selected price list item-id
			if (_rowCount == dgv.Rows.Count)
			{
				_selectedItemHasImage = Convert.ToBoolean(dgv["HASIMAGE", e.RowIndex].Value);
				_selectedPriceListItemId = Convert.ToInt32(dgv["ID", e.RowIndex].Value);
				_selectedItemCode = dgv["ITEMCODE", e.RowIndex].Value.ToString();
				_selectedItemNo = dgv["ITEMNO", e.RowIndex].Value.ToString();
				_selectedItemName = dgv["ITEMNAME", e.RowIndex].Value.ToString();
				_selectedItemStyleId = Convert.ToInt32(dgv["STYLEID", e.RowIndex].Value);
				_selectedItemStyle = dgv["STYLE", e.RowIndex].Value.ToString();

				//_selectedItemMaterialId = Convert.ToInt32(dgv["MATERIALID", e.RowIndex].Value);
				//_selectedItemMaterial = dgv["MATERIAL", e.RowIndex].Value.ToString();

				_selectedItemCategory = dgv["ITEMTYPE", e.RowIndex].Value.ToString();
				_selectedCastingTemp = dgv["CASTTEMP", e.RowIndex].Value.ToString();
				_selectedFalskTemp = dgv["FLASKTEMP", e.RowIndex].Value.ToString();
				_selectedImageFilePath = dgv["IMAGELOCATION", e.RowIndex].Value.ToString();

				// display item-picture
				lbFileName.Text = _selectedImageFilePath;

				if (string.IsNullOrEmpty(_selectedImageFilePath))
				{
					pic.Image = null;
				}
				else {
					GetItemPicture(_selectedImageFilePath);
				}
			}
			else
			{
				_selectedPriceListItemId = 0;
				_selectedImageFilePath = string.Empty;
			}

			// display selected item-id
			lbItemId.Text = $"id : {_selectedPriceListItemId}";

			// update-UI
			UpdateUI();
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			_mode = ActionMode.Add;
			_selectedPriceListItemId = 0;
			GetPriceListItemInfo(_mode, _selectedPriceListItemId, null);

			// update 
			btnRefresh.PerformClick();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			_mode = ActionMode.Edit;
			GetPriceListItemInfo(_mode, _selectedPriceListItemId,pic.Image);

			// update 
			btnRefresh.PerformClick();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnEdit.PerformClick();
		}

		private void btnOpenJob_Click(object sender, EventArgs e)
		{
			AddJobOrder(_selectedPriceListItemId);
		}

		private void cbxFindItem_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbxFindItem.SelectedValue.GetType() == typeof(int))
			{
				_findOption = (FindWhat)Enum.ToObject(typeof(FindWhat), Convert.ToInt32(cbxFindItem.SelectedValue));
				if (dgv.Rows.Count > 0)
				{
					(dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(
						"[{0}] LIKE '%{1}%'",
						_findOption == FindWhat.รหัสสินค้า ? "ITEMNO" : "ITEMNAME",
						OMDataUtils.GetFilter<string>(string.Format("กำหนด{0}ที่ต้องการค้นหา",
							_findOption == FindWhat.รหัสสินค้า ? "รหัสสินค้า" : "ชื่อสินค้า")));

					_rowCount = dgv.Rows.Count;
				}
			}
		}

		private void btnJobHistory_Click(object sender, EventArgs e)
		{
			GetJobHistory(_selectedPriceListItemId);
		}

		private void dgv_SelectionChanged(object sender, EventArgs e)
		{
			dgvJobs.DataSource = null;
		}

		//private void cbxMaterials_SelectionChangeCommitted(object sender, EventArgs e)
		//{
		//	try
		//	{
		//		_selectedCustomerMatId = Convert.ToInt32(cbxWorkType.SelectedValue);
		//	}
		//	catch
		//	{
		//		_selectedCustomerMatId = 0;
		//	}

		//	// price list items
		//	GetPriceListByCustomer(_customerCode, _selectedCustomerMatId);
		//}

		

		private void cbxWorkType_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedWorkType = cbxWorkType.SelectedValue.ToString();
				GetPriceListByCustomer(_customerCode, _selectedWorkType);
			}
			catch
			{

			}
			// price list items
			//GetPriceListByCustomer(_customerCode, _selectedCustomerMatId);
		}

		private void cbxWorkType_SelectedValueChanged(object sender, EventArgs e)
		{

		}
	}
}