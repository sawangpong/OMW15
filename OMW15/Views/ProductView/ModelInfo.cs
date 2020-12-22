using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.ProductView
{
	public partial class ModelInfo : Form
	{

		#region class field member

		private PRODUCT product;
		private Shared.ActionMode mode = Shared.ActionMode.None;

		#endregion

		#region class property

		#endregion

		#region class helper methods

		private void updateUI()
		{
			txtProductId.Enabled = false;
			txtModel.Enabled = (mode == Shared.ActionMode.Add);

			btnDeletePic.Enabled = (pic.Image != null);

		} // end updateUI

		private void getProductGroupList()
		{
			cbxProductGroup.DataSource = null;
			cbxProductGroup.DataSource = new Models.ProductModel.ProductDAL().getProductGroups();
			cbxProductGroup.DisplayMember = "PRODUCTGROUPNAME";
			cbxProductGroup.ValueMember = "PRODUCTGROUPID";


		} // end getProductGroupList


		private void getProductInfo(string productId)
		{
			product = new PRODUCT();
			if(string.IsNullOrEmpty(productId))
			{
				product.id = "*AUTO*";
				product.isdelete = false;
				product.isBuyForTread = false;
				product.hasAfterSaleService = true;
				product.isOffProduction = false;
				product.isOwnProduct = true;
				product.isSpecialProduct = false;
				product.productGroupID = 1;
				product.productpic = null;
				product.products = "";
				product.type = "";
			}
			else
			{
				product = new Models.ProductModel.ProductDAL().getProductInfo(productId);
			}


			// map data
			chkAfterSaleService.Checked = product.hasAfterSaleService;
			chkDiscontinue.Checked = product.isOffProduction;
			chkOwnProduct.Checked = product.isOwnProduct;
			chkSpecialProduct.Checked = product.isSpecialProduct;
			chkBuyForTread.Checked = product.isBuyForTread;
			txtProductId.Text = product.id;
			txtModel.Text = product.type;
			txtProductDetail.Text = product.products;
			cbxProductGroup.SelectedValue = product.productGroupID;
			pic.Image = ( product.productpic != null ? product.productpic.ToImageFromByte() : null);


			updateUI();

		} // end getProductInfo

		private void updateProductInfo(Shared.ActionMode Mode)
		{
			switch(Mode)
			{
				case Shared.ActionMode.Add:
					product = new PRODUCT();
					product.id = null;
					product.type = txtModel.Text;
					break;

				case Shared.ActionMode.Edit:
					product = new Models.ProductModel.ProductDAL().getProductInfo(txtProductId.Text);
				
					break;
			}

			product.hasAfterSaleService = chkAfterSaleService.Checked;
			product.isBuyForTread = chkBuyForTread.Checked;
			product.isdelete = false;
			product.isOffProduction = chkDiscontinue.Checked;
			product.isOwnProduct = chkOwnProduct.Checked;
			product.isSpecialProduct = chkSpecialProduct.Checked;
			product.productGroupID = (int)cbxProductGroup.SelectedValue;
			product.productpic = pic.Image == null ? null : pic.Image.ConvertImage2Byte();
			product.products = txtProductDetail.Text;

			if(new Models.ProductModel.ProductDAL().updateProductInfo(product) > 0)
			{
				MessageBox.Show("Update Product Info successfully.....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}


		} // end updateProductInfo



		#endregion

		public ModelInfo(string productId)
		{
			InitializeComponent();
			getProductGroupList();
			mode = (string.IsNullOrEmpty(productId) ? Shared.ActionMode.Add : Shared.ActionMode.Edit);
			getProductInfo(productId);


		}

		private void ModelInfo_Load(object sender, EventArgs e)
		{
			CenterToParent();
			lbMode.Text = mode.ToString();
			updateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			updateProductInfo(mode);
		}

		private void btnDeletePic_Click(object sender, EventArgs e)
		{
			pic.Image = null;

			updateUI();
		}

		private void btnFindPic_Click(object sender, EventArgs e)
		{
			OMControls.OMImageDB idb = new OMControls.OMImageDB();
			pic.Image = idb.GetImageFile();
		}
	}
}
