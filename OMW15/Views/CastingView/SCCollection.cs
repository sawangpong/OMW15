using System;
using System.Windows.Forms;
using GAF;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView
{
	public partial class SCCollection : Form
	{
		// CONSTRUCTOR
		public SCCollection(int BillId)
		{
			InitializeComponent();
			_blId = BillId;
			GetBillHeaderInfo(BillId);
		}

		private void SCCollection_Load(object sender, EventArgs e)
		{
			CenterToParent();
			GetWHTaxList();
		}

		private void btnInvoiceDate_ButtonClick(object sender, EventArgs e)
		{
			btnInvoiceDate.SelectedDate = Convert.ToDateTime(lbInvoiceDate.Text);
		}

		private void btnInvoiceDate_DateSelected(object sender, EventArgs e)
		{
			lbInvoiceDate.Text = btnInvoiceDate.SelectedDate.ToShortDateString();
		}

		private void cbxWHTaxRate_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_selectedWHTaxRate = Convert.ToDecimal(cbxWHTaxRate.SelectedValue);

			txtWHTaxValue.Text = string.Format("{0:N2}", Convert.ToDecimal(lbNetValue.Text) * (_selectedWHTaxRate / 100.00m));

			// calculate the total collection value
			CalTotalCollection();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			UpdateBL(_blId);
		}

		private void txtTotalCollection_TextChanged(object sender, EventArgs e)
		{
			lbTotalCollectionText.Text = ExtensionDouble.ToThaiWord(Convert.ToDouble(txtTotalCollection.Text));
		}

		private void btnCollectDate_ButtonClick(object sender, EventArgs e)
		{
			btnCollectDate.SelectedDate = Convert.ToDateTime(lbCollectDate.Text);
		}

		private void btnCollectDate_DateSelected(object sender, EventArgs e)
		{
			lbCollectDate.Text = btnCollectDate.SelectedDate.ToShortDateString();
		}

		private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		#region class field member

		private decimal _selectedWHTaxRate;
		private readonly int _blId;

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnSave.Enabled = !string.IsNullOrEmpty(txtInvoiceNo.Text);
		} // end UpdateUI


		private void GetWHTaxList()
		{
			cbxWHTaxRate.DataSource = new BillingDAL().GetWHTaxList();
			cbxWHTaxRate.DisplayMember = "KEYNAME";
			cbxWHTaxRate.ValueMember = "VALUE";
		}

		private void GetBillHeaderInfo(int BillId)
		{
			var _bl = new BillingDAL().GetBillHeaderInfo(BillId);

			lbBillNo.Text = _bl.BILLNO;
			lbBillNo.Tag = _bl.BILLID;
			lbBillDate.Text = _bl.BILLDATE.Num2Date().ToShortDateString();
			lbBillDueDate.Text = _bl.DUEDATE.Num2Date().ToShortDateString();
			lbNetValue.Text = string.Format("{0:N2}", _bl.NETVALUE);
			lbVATValue.Text = string.Format("{0:N2}", _bl.TOTALVAT);
			lbBillingTotalAmount.Text = string.Format("{0:N2}", _bl.TOTALAMOUNT);
			txtInvoiceNo.Text = _bl.INVOICENO;
			lbInvoiceDate.Text = _bl.INVDATE == 0.00m
				? DateTime.Today.ToShortDateString()
				: _bl.INVDATE.Num2Date().ToShortDateString();
			lbCollectDate.Text = _bl.COLLECTDATE == 0.00m
				? DateTime.Today.ToShortDateString()
				: _bl.COLLECTDATE.Num2Date().ToShortDateString();
			cbxWHTaxRate.SelectedValue = 0.00m;
			txtWHTaxValue.Text = string.Format("{0:N2}", _bl.TOTALWHTAX);
			txtTotalCollection.Text = string.Format("{0:N2}", _bl.TOTALPAYVALUE);

			UpdateUI();
		} // end GetBillHeaderInfo

		private void UpdateBL(int BillId)
		{
			var _b = new BillingDAL().GetBillHeaderInfo(BillId);

			_b.ISCOMPLETE = string.IsNullOrEmpty(txtInvoiceNo.Text) ? false : true;
			_b.STATUS = _b.ISCOMPLETE ? "COLLECTED" : _b.STATUS;
			_b.INVSEQ = 0;
			_b.INVOICENO = txtInvoiceNo.Text;
			_b.INVDATE = Convert.ToDateTime(lbInvoiceDate.Text).Date2Num();
			_b.COLLECTDATE = Convert.ToDateTime(lbCollectDate.Text).Date2Num();
			_b.TOTALWHTAX = Convert.ToDecimal(txtWHTaxValue.Text);
			_b.TOTALPAYVALUE = Convert.ToDecimal(txtTotalCollection.Text);
			_b.MODIUSER = omglobal.UserInfo;
			_b.MODIDATE = DateTime.Now;


			if (new BillingDAL().UpdateBillCollectionValue(_b) > 0)
				MessageBox.Show("Update Bill Collection complete......", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
		} // end UpdateBL

		private void CalTotalCollection()
		{
			var _netValue = Convert.ToDecimal(lbNetValue.Text) - Convert.ToDecimal(txtWHTaxValue.Text);
			var _vat = Convert.ToDecimal(lbVATValue.Text);
			txtTotalCollection.Text = string.Format("{0:N2}", _netValue + _vat);
		} // end CalTotalCollection

		#endregion
	}
}