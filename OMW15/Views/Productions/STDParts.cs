using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.ProductionModel;
using OMW15.Models.WarehouseModel;
using OMW15.Shared;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class STDParts : Form
	{
		#region Singleton
		private static STDParts _instance;
		public static STDParts GetInstance
		{
			get {
				if(_instance == null || _instance.IsDisposed)
				{
					_instance = new STDParts();
				}
				return _instance;
			}
		}
 
		#endregion


		#region class field member

		private readonly ActionMode _viewMode = ActionMode.Recording;
		private bool _isLock = false;
		private int _rowCount = 0;
		private int _selectedItemId = 0;
		private string _selectedItemNo = string.Empty;

		#endregion

		#region class property

		public bool IsEmptyResult { get; set; }
		public int ItemId { get; set; }
		public string ItemNo { get; set; }

		public string ItemName { get; set; }

		public string Unit { get; set; }

		public decimal StandardHour { get; set; }

		public decimal StandardMaterialCost { get; set; }

		public string DrawingNo { get; set; }

		public int DrawingRevision { get; set; }

		public string SheetNo { get; set; }

		public Image ItemImage { get; set; }

		public int TotalStep { get; set; }

		public string Filter { get; set; }

		public ActionMode ViewMode { get; set; } = ActionMode.Recording;

		#endregion

		#region class helper method

		private void UpdateUI()
		{

			tslbRecordCount.Text = $"found: {_rowCount}";

			// defind _viewMode by calling type
			//_viewMode == ActionMode.Recording ? true : false;
			bool _isVisibleToolBarButton = (_viewMode == ActionMode.Recording ? true : false);

			this.tsbtnAdd.Visible = _isVisibleToolBarButton;
			this.tsbtnEdit.Visible = this.tsbtnAdd.Visible;
			this.tsSepAdd.Visible = this.tsbtnAdd.Visible;
			this.tsbtnLock.Visible = this.tsbtnAdd.Visible;
			this.tsSepEdit.Visible = this.tsbtnAdd.Visible;

			st.Visible = _isVisibleToolBarButton;
			pnlCommand.Visible = (_viewMode == ActionMode.Selection ? true : false);
			tsbtnLock.Visible = omglobal.PermisionId >= (int)OMShareSysConfigEnums.UserPermission.Manager;
			tsbtnEdit.Enabled = (dgv.Rows.Count > 0);

			if (_viewMode == ActionMode.Selection)
			{
				btnSelect.Enabled = !_isLock;
			}

		} // end UpdateUI

		private void FormatGrid()
		{
			DataGridViewCellStyle _cellStyle = DataGridViewSettingStyle.NumericCellStyle();
			var dt = new ProductionDAL().GetProductionItemList("1=1");
			dgv.DataSource = dt;
			dgv.Columns["ISLOCK"].Visible = false;
			dgv.Columns["ITEMID"].Visible = false;
			dgv.Columns["STDPRODUCTHOURS"].HeaderText = "STD Hours";
			dgv.Columns["STDPRODUCTHOURS"].DefaultCellStyle = _cellStyle;
			dgv.Columns["MATERIALCOST"].DefaultCellStyle = _cellStyle;
			dgv.Columns["PRODUCTIONCOST"].DefaultCellStyle = _cellStyle;
			dgv.Columns["ITEMCOST"].DefaultCellStyle = _cellStyle;

			dgv.Columns["STATUS"].HeaderText = "สถานะ";
			dgv.Columns["ITEMNO"].HeaderText = "รหัสชิ้นงาน";
			dgv.Columns["ITEMNAME"].HeaderText = "ชื่อชิ้นงาน";
			dgv.Columns["DRAWINGNO"].HeaderText = "เลขที่แบบ";
			dgv.Columns["DRAWINGREV"].HeaderText = "เวอร์ชั่น";
			dgv.Columns["SHEETNO"].HeaderText = "แผ่นที่";
			dgv.Columns["MATNO"].HeaderText = "หมายเลขวัสดุ";
			dgv.Columns["MATERIAL"].HeaderText = "วัสดุ";
			dgv.Columns["UNIT"].HeaderText = "หน่วยนับ";
			dgv.Columns["STDPRODUCTHOURS"].HeaderText = "ช.ม.มาตรฐาน";
			dgv.Columns["MATERIALCOST"].HeaderText = "ต้นทุนวัสดุ";
			dgv.Columns["PRODUCTIONCOST"].HeaderText = "รวมค่าแรง";
			dgv.Columns["ITEMCOST"].HeaderText = "รวมต้นทุนการผลิต";
		}


		//private async void GetSTDParts()
		private void GetSTDParts(string filter)
		{
			dgv.SuspendLayout();
			var _pd = new ProductionDAL();
			//var dt = _pd.GetProductionItemList(OMShareProduction.SearchSTDItem.ItemNumber,filter);

			var dt = _pd.GetProductionItemList(filter);

			_rowCount = dt.Rows.Count;
			dgv.DataSource = dt;

			dgv.Columns["ISLOCK"].Visible = false;
			dgv.Columns["ITEMID"].Visible = false;
			dgv.Columns["STDPRODUCTHOURS"].HeaderText = "STD Hours";
			//dgv.Columns["STDPRODUCTHOURS"].DefaultCellStyle = _cellStyle;
			//dgv.Columns["MATERIALCOST"].DefaultCellStyle = _cellStyle;
			//dgv.Columns["PRODUCTIONCOST"].DefaultCellStyle = _cellStyle;
			//dgv.Columns["ITEMCOST"].DefaultCellStyle = _cellStyle;

			dgv.Columns["STATUS"].HeaderText = "สถานะ";
			dgv.Columns["ITEMNO"].HeaderText = "รหัสชิ้นงาน";
			dgv.Columns["ITEMNAME"].HeaderText = "ชื่อชิ้นงาน";
			dgv.Columns["DRAWINGNO"].HeaderText = "เลขที่แบบ";
			dgv.Columns["DRAWINGREV"].HeaderText = "เวอร์ชั่น";
			dgv.Columns["SHEETNO"].HeaderText = "แผ่นที่";
			dgv.Columns["MATNO"].HeaderText = "หมายเลขวัสดุ";
			dgv.Columns["MATERIAL"].HeaderText = "วัสดุ";
			dgv.Columns["UNIT"].HeaderText = "หน่วยนับ";
			dgv.Columns["STDPRODUCTHOURS"].HeaderText = "ช.ม.มาตรฐาน";
			dgv.Columns["MATERIALCOST"].HeaderText = "ต้นทุนวัสดุ";
			dgv.Columns["PRODUCTIONCOST"].HeaderText = "รวมค่าแรง";
			dgv.Columns["ITEMCOST"].HeaderText = "รวมต้นทุนการผลิต";
			dgv.Columns["TOTAL_STEP"].HeaderText = "ขั้นตอนการผลิต";
			dgv.Columns["TOTAL_STEP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.ResumeLayout();

			UpdateUI();

		} // end GetSTDParts

		private void GetSTDPartInfo(int itemId, string itemNo)
		{
			using (var pInfo = new STDPartItem(itemId, itemNo, pic1.Image))
			{
				pInfo.StartPosition = FormStartPosition.CenterParent;
				if (pInfo.ShowDialog(this) == DialogResult.OK)
				{
				}
			}

			tsbtnRefresh.PerformClick();
		} // end GetSTDPartInfo

		#endregion


		#region Constructor



		//public STDParts(ActionMode ViewMode = ActionMode.Recording, string filter = "")
		public STDParts()
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgv);
			dgv.AlternatingRowsDefaultCellStyle.BackColor = dgv.BackgroundColor;

			FormatGrid();

			//this.ItemNo = filter;

			_viewMode = ViewMode;
			FormBorderStyle = _viewMode == ActionMode.Recording ? FormBorderStyle.Sizable : FormBorderStyle.SizableToolWindow;

			this.Text = (_viewMode == ActionMode.Recording ? "Standard Item Info." : "Select Standard Item Info.");
			this.UpdateUI();
		}

		#endregion

		private void STDParts_Load(object sender, EventArgs e)
		{
			CenterToParent();

			IsEmptyResult = true;
			this.ItemNo = this.Filter;

			// load data - if the filter item is not null or empty
			if (!String.IsNullOrEmpty(this.ItemNo)) GetSTDParts(this.ItemNo);


		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_isLock = Convert.ToBoolean(dgv["ISLOCK", e.RowIndex].Value);
			_selectedItemId = Convert.ToInt32(dgv["ITEMID", e.RowIndex].Value);
			_selectedItemNo = dgv["ITEMNO", e.RowIndex].Value.ToString();
			this.ItemId = _selectedItemId;
			this.ItemNo = _selectedItemNo;
			this.ItemName = dgv["ITEMNAME", e.RowIndex].Value.ToString();
			this.Unit = dgv["UNIT", e.RowIndex].Value.ToString();
			this.DrawingNo = dgv["DRAWINGNO", e.RowIndex].Value.ToString();
			this.DrawingRevision = Convert.ToInt32(dgv["DRAWINGREV", e.RowIndex].Value);
			this.SheetNo = dgv["SHEETNO", e.RowIndex].Value.ToString();
			this.StandardHour = Convert.ToDecimal(dgv["STDPRODUCTHOURS", e.RowIndex].Value);
			this.StandardMaterialCost = Convert.ToDecimal(dgv["MATERIALCOST", e.RowIndex].Value);
			this.TotalStep = Convert.ToInt32(dgv["TOTAL_STEP", e.RowIndex].Value);

			// display itemImage
			this.ItemImage = new WHDDAL().getItemMasterImage(ItemNo);
			pic1.Image = this.ItemImage;

			sblbItemID.Text = $"Id : {_selectedItemId}";

			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.ItemNo = "";
			GetSTDParts(this.ItemNo);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			pic1.Image = null;
			_selectedItemId = 0;
			_selectedItemNo = "";

			GetSTDPartInfo(_selectedItemId, _selectedItemNo);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			if (_viewMode == ActionMode.Recording)
			{
				tsbtnEdit.PerformClick();
			}
			else if (_viewMode == ActionMode.Selection)
			{
				if (_isLock)
				{
					MessageBox.Show("Can't select the item when status is 'Disabled'....", "Message", MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
				}
				else
				{
					btnSelect.PerformClick();
				}
			}
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			GetSTDPartInfo(_selectedItemId, _selectedItemNo);
		}

		private void tsbtnLock_Click(object sender, EventArgs e)
		{
			if (new ProductionDAL().StandardPartItemLock(_selectedItemId) > 0)
			{
				MessageBox.Show("The selected Item had been locked...", "Lock", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			tsbtnRefresh.PerformClick();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			IsEmptyResult = true;
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			IsEmptyResult = false;
		}

		private void tsbtnSearch_Click(object sender, EventArgs e)
		{
			// search by string input for customer name
			string _filterString = OMDataUtils.GetFilter<string>("กำหนดหมายเลขที่ต้องการค้นหา");

			GetSTDParts(_filterString);


			//(dgv.DataSource as DataTable).DefaultView.RowFilter = $"[{"ITEMNO"}] LIKE '%{_filterString}%'";

			UpdateUI();
		}
	}
}