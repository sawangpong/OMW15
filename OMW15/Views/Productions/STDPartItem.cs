using OMControls;
using OMW15.Models.ProductionModel;
using OMW15.Models.WarehouseModel;
using OMW15.Shared;
using OMW15.Views.WarehouseView;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class STDPartItem : Form
	{
		#region class field member

		private PRODUCTIONSTDITEM _item;
		private readonly ActionMode _mode = ActionMode.None;
		private bool _hasImage;
		private int _selectedStdProcessId = 0;
		private decimal _workTime = 0.00m;
		private decimal _stdHour = 0.00m;
		private decimal _stepCost = 0.00m;
		private string _processName = "";
		private int _step = 0;
		private int _processId = 0;

		#endregion

		#region class property

		public int ItemId { get; set; }
		public string ItemNo { get; set; }
		public Image ItemImage { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			txtItemNo.Enabled = _mode == ActionMode.Add;
			btnItemNo.Enabled = txtItemNo.Enabled;
			btnSave.Enabled = !string.IsNullOrEmpty(txtItemNo.Text);
			btnClearPicture.Enabled = _hasImage;

			tsbtnAdd.Enabled = (this.ItemId > 0);
			tsbtnEdit.Enabled = (_selectedStdProcessId > 0);

		} // end UpdateUI

		private void GetStdProcessList(string itemNo)
		{
			// update std hour of each process
			new ProductionDAL().UpdateItemStandardHour(itemNo);

			// load std item and process
			dgvSTDProcess.DataSource = new ProductionDAL().GetStdProcessList(itemNo);
			dgvSTDProcess.Columns["ID"].Visible = false;
			dgvSTDProcess.Columns["REF_STDITEM"].Visible = false;
			dgvSTDProcess.Columns["REF_PROCESS"].Visible = false;
			dgvSTDProcess.Columns["MACHINE_GROUP"].Visible = false;
			dgvSTDProcess.Columns["REF_STDITEMNO"].Visible = false;

			dgvSTDProcess.Columns["MACHINE"].HeaderText = "กลุ่มงาน";

			dgvSTDProcess.Columns["STEP"].HeaderText = "ลำดับ";
			dgvSTDProcess.Columns["PROCESSNAME"].HeaderText = "ขั้นตอนการทำงาน";
			dgvSTDProcess.Columns["PROCESSNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

			dgvSTDProcess.Columns["WORKMINT"].HeaderText = "เวลามาตรฐาน (นาที)";
			dgvSTDProcess.Columns["WORKMINT"].DefaultCellStyle.Format = "N2";
			dgvSTDProcess.Columns["WORKMINT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


			dgvSTDProcess.Columns["STD_HR"].HeaderText = "เวลามาตรฐาน (ชั่วโมง)";
			dgvSTDProcess.Columns["STD_HR"].DefaultCellStyle.Format = "N2";
			dgvSTDProcess.Columns["STD_HR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dgvSTDProcess.Columns["STEP_COST"].HeaderText = "ค่าแรง (ชั่วโมง)";
			dgvSTDProcess.Columns["STEP_COST"].DefaultCellStyle.Format = "N2";
			dgvSTDProcess.Columns["STEP_COST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			_selectedStdProcessId = 0;

			if (dgvSTDProcess.Rows.Count > 0)
			{
				// summary standardHours
				this.txtSTDProductionHour.Text = $"{SummaryStdHours():N2}";
				this.txtWorkTimeMint.Text = $"{SummaryWorkTime():N2}";
				this.txtProductionCost.Text = $"{SummaryWorkCost():N2}";
				this.txtItemCost.Text = $"{SummaryWorkCost() + Convert.ToDecimal(this.txtMatCostPerUnit.Text)}";
			}

			UpdateUI();

		}

		private decimal SummaryWorkCost() => ((DataTable)dgvSTDProcess.DataSource).AsEnumerable().Sum(x => x.Field<decimal>("STEP_COST"));
		private decimal SummaryWorkTime() => ((DataTable)dgvSTDProcess.DataSource).AsEnumerable().Sum(x => x.Field<decimal>("WORKMINT"));
		private decimal SummaryStdHours() => ((DataTable)dgvSTDProcess.DataSource).AsEnumerable().Sum(x => x.Field<decimal>("STD_HR"));

		private void GetItemInfo(int ItemId)
		{
			pnlSTDProcess.Enabled = (_mode == ActionMode.Edit);

			if (_mode == ActionMode.Add)
			{
				_item = new PRODUCTIONSTDITEM();
				_item.ItemId = 0;
				_item.ItemNo = "";
				_item.ItemName = "";

				dtpDrawingDate.Value = DateTime.Today;
			}
			else
			{
				_item = new ProductionDAL().GetProductionItemInfo(ItemId);
				dtpDrawingDate.Value = _item.DrawingDate;
			}

			chkItemLock.Checked = _item.islock;
			txtItemNo.Text = _item.ItemNo;
			txtItemName.Text = _item.ItemName;
			txtUnit.Text = _item.Unit;
			txtDrawingNo.Text = _item.DrawingNo;
			txtDrawingRev.Text = _item.DrawingRev.ToString();
			txtSheetNo.Text = _item.SheetNo;
			txtMatNo.Text = _item.MatNo;
			txtMaterial.Text = _item.Material;
			txtUnitWeight.Text = $"{_item.UnitWeight:N2}";
			txtMatCostPerUnit.Text = $"{_item.MaterialCost:N2}";
			txtWorkTimeMint.Text = $"{_item.WorktimeMint:N2}";
			txtSTDProductionHour.Text = $"{_item.STDProductHours:N2}";
			txtProductionHourCost.Text = $"{_item.ProducionHourCost:N2}";
			txtProductionCost.Text = $"{_item.ProductionCost:N2}";
			txtItemCost.Text = $"{ _item.ItemCost:N2}";

			pic1.Image = ItemImage;
			_hasImage = UpdateImageFlag();

			UpdateUI();

		} // end GetItemIngfo


		private void UpdateItemInfo()
		{
			var _pditem = new PRODUCTIONSTDITEM();
			_pditem.CreateDate = _mode == ActionMode.Add ? DateTime.Now : _item.CreateDate;
			_pditem.CreateUser = _mode == ActionMode.Add ? omglobal.UserName : _item.CreateUser;
			_pditem.DrawingDate = dtpDrawingDate.Value;
			_pditem.DrawingNo = txtDrawingNo.Text;
			_pditem.DrawingRev = Convert.ToInt32(txtDrawingRev.Text);
			_pditem.islock = chkItemLock.Checked;
			_pditem.ItemCost = Convert.ToDecimal(txtItemCost.Text);
			_pditem.ItemId = _mode == ActionMode.Add ? 0 : _item.ItemId;
			_pditem.ItemName = txtItemName.Text;
			_pditem.ItemNo = txtItemNo.Text;
			_pditem.MatNo = txtMatNo.Text;
			_pditem.Material = txtMaterial.Text;
			_pditem.MaterialCost = Convert.ToDecimal(txtMatCostPerUnit.Text);
			_pditem.ModiDate = DateTime.Now;
			_pditem.ModiUser = omglobal.UserName;
			_pditem.ProducionHourCost = Convert.ToDecimal(txtProductionHourCost.Text);
			_pditem.ProductionCost = Convert.ToDecimal(txtProductionCost.Text);
			_pditem.SheetNo = txtSheetNo.Text;
			_pditem.WorktimeMint = Convert.ToDecimal(txtWorkTimeMint.Text);
			_pditem.STDProductHours = Convert.ToDecimal(txtSTDProductionHour.Text);
			_pditem.Unit = txtUnit.Text;
			_pditem.UnitWeight = Convert.ToDecimal(txtUnitWeight.Text);

			if (new ProductionDAL().UpdatePartItemInfo(_pditem) > 0)
			{
				UpdateItemMasterImage();
				MessageBox.Show("Update Info completed....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		} // end UpdateItemInfo

		private bool UpdateImageFlag()
		{
			return pic1.Image != null;
		} // end UpdateImageFlag

		private void UpdateItemMasterImage()
		{
			var _img = new ITEMMASTERIMG();
			if (ItemId == 0)
			{
				_img.itemid = 0;
				_img.itemno = txtItemNo.Text;
				_img.itempicture = pic1.Image.ConvertImage2Byte();
			}
			else
			{
				_img.itemid = ItemId;
				_img.itemno = txtItemNo.Text;
			}

			_img.itempicture = pic1.Image == null ? null : pic1.Image.ConvertImage2Byte();

			if (new WHDDAL().updateItemMasterImage(_img) > 0)
			{
				// update (insert picture to database complete
			}
		} // end UpdateImageToDB


		private void StardardItemProcess(int itemStepId)
		{

			var std = new STDItemProcess(itemStepId, this.ItemId, txtItemNo.Text, txtItemName.Text);
			std.ShowDialog(this);

			// refresh the list and update the total standard time
			tsbtnRefresh.PerformClick();
		}

		#endregion

		private int FindStepNumber(string itemNo)
		{
			if (dgvSTDProcess.Rows.Count == 0)
				return 1;
			else
				return new ProductionDAL().GetMaxStep(itemNo);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			this._selectedStdProcessId = 0;
			_processId = 0;
			_processName = "";
			_step = FindStepNumber(this.ItemNo);
			_stdHour = 0;
			StardardItemProcess(this._selectedStdProcessId);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			StardardItemProcess(this._selectedStdProcessId);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetStdProcessList(this.txtItemNo.Text);

		}

		private void dgvSTDProcess_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedStdProcessId = Convert.ToInt32(dgvSTDProcess["ID", e.RowIndex].Value);
			_processId = Convert.ToInt32(dgvSTDProcess["REF_PROCESS", e.RowIndex].Value);
			_processName = dgvSTDProcess["PROCESSNAME", e.RowIndex].Value.ToString();
			_step = Convert.ToInt32(dgvSTDProcess["STEP", e.RowIndex].Value);
			_stepCost = Convert.ToDecimal(dgvSTDProcess["STEP_COST", e.RowIndex].Value);
			_workTime = Convert.ToDecimal(dgvSTDProcess["WORKMINT", e.RowIndex].Value);
			_stdHour = Convert.ToDecimal(dgvSTDProcess["STD_HR", e.RowIndex].Value);

			tslbId.Text = $"id # {_selectedStdProcessId}";

			this.UpdateUI();
		}

		// constructor
		public STDPartItem(int sourceItemId, string sourceItemNo, Image SourceImage = null)
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgvSTDProcess);

			this.ItemId = sourceItemId;
			this.ItemNo = sourceItemNo;
			this.ItemImage = SourceImage;

			// display ref item-id
			lbItemId.Text = $"id : {this.ItemId}";

			// display mode
			lbMode.Text = (_mode = ItemId == 0 ? ActionMode.Add : ActionMode.Edit).ToString();
		}

		private void STDPartItem_Load(object sender, EventArgs e)
		{
			CenterToParent();
			GetItemInfo(this.ItemId);

			if (this.ItemId > 0)
			{
				GetStdProcessList(this.txtItemNo.Text);
			}
		}

		private void txtItemNo_TextChanged(object sender, EventArgs e)
		{
			txtDrawingNo.Text = txtItemNo.Text;
			UpdateUI();
		}

		private void txtCostUnit_TextChanged(object sender, EventArgs e)
		{
			var _matCost = Convert.ToDecimal(txtMatCostPerUnit.Text);
			var _hourCost = Convert.ToDecimal(txtProductionHourCost.Text);
			var _stdHour = Convert.ToDecimal(txtSTDProductionHour.Text);
			txtProductionCost.Text = $"{(_hourCost * _stdHour):N2}";
			txtItemCost.Text = $"{(_hourCost * _stdHour + _matCost):N2}";
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtItemNo.Text))
				UpdateItemInfo();
		}

		private void btn_Click(object sender, EventArgs e)
		{
			var _cat = OMShareProduction.ProductionOptionEnum.None;
			var _b = sender as OMFlatButton;
			var _tag = _b.Tag.ToString();
			var dt = new DataTable();
			switch (_tag)
			{
				case "UNIT":
					dt = new WHDDAL().getUnitList();
					_cat = OMShareProduction.ProductionOptionEnum.ItemUnit;
					break;
				case "MAT":
					dt = new ProductionDAL().GetMaterialForProduction();
					_cat = OMShareProduction.ProductionOptionEnum.ItemMaterial;
					break;
			}

			if (dt.Rows.Count > 0)
			{
				using (var _opt = new PrdOption(_cat))
				{
					_opt.DataSource = dt;
					if (_opt.ShowDialog() == DialogResult.OK)
					{
						if (_opt.IsEmptyItem == false)
						{
							switch (_tag)
							{
								case "UNIT":
									txtUnit.Text = _opt.SelectedItem;
									break;
								case "MAT":
									txtMaterial.Text = _opt.SelectedItem;
									break;
							}
						}
					}
				}
			}
			else
			{
				MessageBox.Show("No list available...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void btnItemNo_Click(object sender, EventArgs e)
		{
			using (var _im = new StockMaster(ActionMode.Selection))
			{
				_im.StartPosition = FormStartPosition.CenterScreen;
				if (_im.ShowDialog() == DialogResult.OK)
				{
					this.ItemNo = _im.ItemMasterCode;
					txtItemNo.Text = _im.ItemMasterCode;
					txtItemName.Text = _im.ItemMasterNameTH;
					txtUnit.Text = _im.ItemUnit;
					pic1.Image = _im.ItemImage;
				}
			}
		}


		private void btnClearPicture_Click(object sender, EventArgs e)
		{
			pic1.Image = null;
			_hasImage = UpdateImageFlag();
			UpdateUI();
		}

		private void btnLoadPicture_Click(object sender, EventArgs e)
		{
			var _idb = new OMImageDB();

			pic1.Image = _idb.GetImageFile(Application.ExecutablePath);
			_hasImage = UpdateImageFlag();

			UpdateUI();
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("ต้องการลบรายการที่เลือกใช่หรือไม่?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (new ProductionDAL().DeleteStdProcess(_selectedStdProcessId) > 0)
				{
					MessageBox.Show("ลบรายการที่เลือกเรียบร้อยแล้ว", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				tsbtnRefresh.PerformClick();
			}
		}

		private void dgvSTDProcess_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void btnMatNo_Click(object sender, EventArgs e)
		{
			using (var _im = new StockMaster(ActionMode.Selection))
			{
				_im.StartPosition = FormStartPosition.CenterScreen;
				if (_im.ShowDialog() == DialogResult.OK)
				{
					txtMatNo.Text = _im.ItemMasterCode;
					txtMaterial.Text = _im.ItemMasterNameTH;
				}
			}
		}


	}
}