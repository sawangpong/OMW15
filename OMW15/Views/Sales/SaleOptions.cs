using System;
using System.Data;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class SaleOptions : Form
	{
		public SaleOptions(OMShareSaleEnum.SaleQuotationOptions Option, DataTable Source)
		{
			InitializeComponent();

			_option = Option;
			DataSource = Source;
		}

		private void SaleOptions_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			IsEmptyResult = true;

			switch (_option)
			{
				case OMShareSaleEnum.SaleQuotationOptions.Country:
					GetQTOptionList(DataSource);
					lbTitle.Text = "Country";
					break;
				case OMShareSaleEnum.SaleQuotationOptions.DeliveryTerm:
					GetQTTermList(DataSource);
					lbTitle.Text = "Delivery Term";
					break;
				case OMShareSaleEnum.SaleQuotationOptions.DeliveryTime:
					GetQTTermList(DataSource);
					lbTitle.Text = "Delivery Time";
					break;
				case OMShareSaleEnum.SaleQuotationOptions.PaymentTerm:
					GetQTTermList(DataSource);
					lbTitle.Text = "Payment Term";
					break;
				case OMShareSaleEnum.SaleQuotationOptions.SalePerson:
					GetQTOptionList(DataSource);
					lbTitle.Text = "Sale Person";
					break;
				case OMShareSaleEnum.SaleQuotationOptions.Training:
					GetQTTermList(DataSource);
					lbTitle.Text = "Training";
					break;
				case OMShareSaleEnum.SaleQuotationOptions.Warranty:
					GetQTTermList(DataSource);
					lbTitle.Text = "Warranty Term";
					break;
			}
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_rowCount == dgv.Rows.Count)
			{
				IsEmptyResult = false;
				Value = dgv[0, e.RowIndex].Value.ToString();
			}
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			IsEmptyResult = true;
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			IsEmptyResult = false;
		}

		#region class field member

		private readonly OMShareSaleEnum.SaleQuotationOptions _option = OMShareSaleEnum.SaleQuotationOptions.None;
		private int _rowCount;

		#endregion

		#region class property

		public bool IsEmptyResult { get; set; }

		public DataTable DataSource { get; set; }

		public string Value { get; set; }

		#endregion

		#region class helper methods

		private void GetQTOptionList(DataTable Source)
		{
			_rowCount = Source.Rows.Count;

			dgv.SuspendLayout();
			dgv.DataSource = Source;
			dgv.ColumnHeadersVisible = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
			dgv.ResumeLayout();
		} // end GetQTCountryList


		private void GetQTTermList(DataTable Source)
		{
			_rowCount = Source.Rows.Count;

			dgv.SuspendLayout();
			dgv.DataSource = Source;
			dgv.ColumnHeadersVisible = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
			dgv.ResumeLayout();
		} // end GetQTCountryList

		#endregion
	}
}