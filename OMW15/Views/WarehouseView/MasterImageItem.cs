using System;
using System.Drawing;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.WarehouseModel;
using OMW15.Shared;

namespace OMW15.Views.WarehouseView
{
	public partial class MasterImageItem : Form
	{
		public MasterImageItem(int masterItemId, string ItemNo, string ItemName, Image ItemImg)
		{
			InitializeComponent();
			CenterToParent();
			_masteritemId = masterItemId;
			txtItemNo.Text = ItemNo;
			txtItemName.Text = ItemName;
			pic.Image = ItemImg;
		}

		private void MasterImageItem_Load(object sender, EventArgs e)
		{
			FindItemProperty(txtItemNo.Text);
			UpdateUI();
		}

		private void btnClearImage_Click(object sender, EventArgs e)
		{
			pic.Image = null;
			UpdateUI();
		}

		private void btnLoadImage_Click(object sender, EventArgs e)
		{
			var _idb = new OMImageDB();
			pic.Image = _idb.GetImageFile(Application.ExecutablePath);
			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			UpdateItemMasterImage();
		}

		#region class field member

		private int _masteritemId;
		private ActionMode _mode = ActionMode.None;

		#endregion
	

		#region class helper method

		private void UpdateUI()
		{
			btnClearImage.Enabled = pic.Image != null;
		} // end UpdateUI

		private void FindItemProperty(string itemNo)
		{
			_mode = new WHDDAL().findMasterItemImageProperty(itemNo) ? ActionMode.Edit : ActionMode.Add;
			lbMode.Text = _mode.ToString();

			// update record infos.
			var r = new WHDDAL().getItemMasterRecord(itemNo);
			lbRefId.Text = $"{_masteritemId} :: { (r==null ? 0 : r.itemid)}";

		} // end FindItemProperty


		private void UpdateItemMasterImage()
		{
			ITEMMASTERIMG  _img = new ITEMMASTERIMG();
			if (_mode == ActionMode.Add)
			{
				_img.itemid = 0;
				_img.masterid = _masteritemId;
				_img.itemno = txtItemNo.Text;
				_img.itempicture = pic.Image == null ? null : pic.Image.ConvertImage2Byte();
			}
			else if (_mode == ActionMode.Edit)
			{
				_img = new WHDDAL().getItemMasterRecord(this.txtItemNo.Text);
				_img.masterid = _masteritemId;
				_img.itempicture = pic.Image == null ? null : pic.Image.ConvertImage2Byte();
			}

			if (new WHDDAL().updateItemMasterImage(_img) > 0)
			{
				// update (insert picture to database complete
			}
		} // end UpdateItemMasterImage

		#endregion
	}
}