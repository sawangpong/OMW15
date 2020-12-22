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
    public partial class MCModelList : Form
    {

        #region class field member
        private string selectedProductId = "";
        private int selectedProductuctGroupId = 0;
        #endregion

        #region class property

        #endregion

        #region class helper

        private void updateUI()
        {
            tsbtnEdit.Enabled = (!string.IsNullOrEmpty(selectedProductId));

        } // end updateUI

        private void getProductList()
        {
            dgv.SuspendLayout();
            dgv.DataSource = null;
            dgv.DataSource = new Models.ProductModel.ProductDAL().getProductWithDetailList();

            dgv.Columns["ModelId"].Visible = false;
            dgv.Columns["ProductGroupId"].Visible = false;

            dgv.Columns["OldmoonProduct"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Discontinue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["SpecialProduct"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["TradingProduct"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.ResumeLayout();

            lbrows.Text = $"found:{dgv.Rows.Count} row{(dgv.Rows.Count > 1 ? "s" : string.Empty) }";

            updateUI();

        } // end getProductList

        private void getProductInfo(string productId)
        {
            ProductView.ModelInfo minfo = new ProductView.ModelInfo(productId);
            minfo.StartPosition = FormStartPosition.CenterScreen;

            if(minfo.ShowDialog(this) == DialogResult.OK)
            {

            }


            // reload model list
            tsbtnRefresh.PerformClick();

        } // end getProductInfo

        private void deleteProduct(string productId)
        {
            if(new Models.ProductModel.ProductDAL().deleteProduct(productId) > 0)
            {
                MessageBox.Show("Delete selected record successfully....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Can't delete the selected product because there is registered to Machine Record..... ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // reload model list
            tsbtnRefresh.PerformClick();

        } // end deleteProduct

        #endregion

        public MCModelList()
        {
            InitializeComponent();
        }

        private void MCModelList_Load(object sender, EventArgs e)
        {
            OMControls.OMUtils.SettingDataGridView(ref dgv);

            tsbtnRefresh.PerformClick();
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            getProductList();
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedProductId = dgv["ModelId", e.RowIndex].Value.ToString();
            selectedProductuctGroupId = int.Parse(dgv["ProductGroupId", e.RowIndex].Value.ToString());

            updateUI();

            // get image
            pic.Image = new Models.ProductModel.ProductDAL().getProductImage(selectedProductId);

            lbid.Text = $"id:{selectedProductId}";
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            tsbtnEdit.PerformClick();
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            getProductInfo(selectedProductId);
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            getProductInfo(selectedProductId = "");
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            deleteProduct(selectedProductId);
        }
    }
}
