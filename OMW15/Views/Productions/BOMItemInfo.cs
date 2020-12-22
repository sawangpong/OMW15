using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMW15.Models;
using OMW15.Models.ProductionModel;
using OMW15.Shared;

namespace OMW15.Views.Productions
{
	public partial class BOMItemInfo : Form
	{
		#region class field

		private ActionMode mode = ActionMode.None;

		private int itemId = 0;


		#endregion

		#region class helper

		private void updateUI()
		{
		}

		private void getCategory()
		{
			this.cbxCategory.DataSource = new BOMDal().getPartCategoryFromBOM();
			this.cbxCategory.DisplayMember = "Category";
			this.cbxCategory.ValueMember = "Category";
		}

		private void getUnit()
		{
			this.cbxUnit.DataSource = new BOMDal().getUnit();
			this.cbxUnit.DisplayMember = "Unit";
			this.cbxUnit.ValueMember = "Unit";
		}


		private void getMaker()
		{
			this.cbxMaker.DataSource = new BOMDal().getMaker();
			this.cbxMaker.DisplayMember = "Maker";
			this.cbxMaker.ValueMember = "Maker";
		}
		private void getBomItem(int itemId)
		{
			MCBOM item = new BOMDal().GetBomItem(itemId);

			lbModelName.Text = item.MODEL;
			txtParentId.Text = $"{item.PARENT_ID}";
			txtParentRev.Text = $"{item.REF_REV}";
			txtParentNo.Text = item.REF_NO;
			txtLevel.Text = item.LEVEL.ToString();
			txtPosition.Text = $"{item.POSITION}";
			txtPartNo.Text = item.PARTNO;
			txtPartRev.Text = $"{item.PART_REV}";
			txtPartName.Text = item.ITEMNAME;
			txtDrawingNo.Text = item.DRAWINGNO;
			cbxUnit.SelectedValue = item.UNIT;
			txtQTY.Text = $"{item.Qty:N2}";
			txtMaterial.Text = item.MATERIAL;
			txtSize.Text = item.SIZE;

			cbxCategory.SelectedValue = item.CATEGORY;
			cbxMaker.SelectedValue = item.MAKER;
			txtProcess.Text = item.PROCESS;
		}

		#endregion


		public BOMItemInfo(int id)
		{
			InitializeComponent();
			itemId = id;
			this.lbItemId.Text = $"{itemId}";
			mode = (itemId == 0 ? ActionMode.Add : ActionMode.Edit);
			this.lbStatus.Text = mode.ToString();
		}

		private void BOMItemInfo_Load(object sender, EventArgs e)
		{
			this.getCategory();
			this.getUnit();
			this.getMaker();
			this.getBomItem(itemId);
		}
	}
}
