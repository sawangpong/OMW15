using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.SaleModel;
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class DelTerm : Form
	{
		public DelTerm(OMShareSaleEnum.SaleContentInfo ContentInfo)
		{
			InitializeComponent();
			_content = ContentInfo;
		}

		#region class property

		public string Result { get; set; }

		#endregion

		private void DelTerm_Load(object sender, EventArgs e)
		{
			// formatting DataGridView
			OMUtils.SettingDataGridView(ref dgv);

			// loading data
			GetContentData(_content);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			Result = dgv[0, e.RowIndex].Value.ToString();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			//this.Close();
			btnSelect.PerformClick();
		}

		#region class field member

		private readonly OMShareSaleEnum.SaleContentInfo _content = OMShareSaleEnum.SaleContentInfo.None;
		private string _title = string.Empty;

		#endregion

		#region class helper method

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetContentData(OMShareSaleEnum.SaleContentInfo ContentType)
		{
			dgv.SuspendLayout();

			switch (ContentType)
			{
				case OMShareSaleEnum.SaleContentInfo.Country:
					_title = "Country";
					dgv.DataSource = new SaleDAL().GetSaleToCountry();
					break;
				case OMShareSaleEnum.SaleContentInfo.DeliveryTerm:
					_title = "Delivery Term";
					dgv.DataSource = new SaleDAL().GetDeliveryTerm();
					break;

				case OMShareSaleEnum.SaleContentInfo.DeliveryTime:
					_title = "Delivery Time";
					dgv.DataSource = new SaleDAL().GetDeliveryTime();
					break;

				case OMShareSaleEnum.SaleContentInfo.PaymentTerm:
					_title = "Payment Term";
					dgv.DataSource = new SaleDAL().GetPaymentTerm();
					break;

				case OMShareSaleEnum.SaleContentInfo.SaleContactCountry:
					_title = "Sale Contact Country";
					dgv.DataSource = new SaleDAL().GetSaleContactCountry();
					break;
			}
			lbTitle.Text = _title;
			Text = _title;

			dgv.ColumnHeadersVisible = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			dgv.ResumeLayout();
		} // end GetContentData

		#endregion
	}
}