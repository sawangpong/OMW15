using System.Data;
using System.Windows.Forms;
using OMW15.Models.SaleModel;
using OMW15.Shared;
using OMW15.Views.Sales;

namespace OMW15.Controllers.SaleController
{
	public class SaleOptionController
	{
		private readonly OMShareSaleEnum.SaleQuotationOptions _option = OMShareSaleEnum.SaleQuotationOptions.None;

		public SaleOptionController(OMShareSaleEnum.SaleQuotationOptions Option)
		{
			IsEmptyResult = true;
			_option = Option;
			GetSaleQuotationOption(_option);
		}

		#region class helper method

		private void GetSaleQuotationOption(OMShareSaleEnum.SaleQuotationOptions Option)
		{
			var dt = new DataTable();
			switch (Option)
			{
				case OMShareSaleEnum.SaleQuotationOptions.Country:
					dt = new SaleQTDAL().GetQuotationCountry();
					break;

				case OMShareSaleEnum.SaleQuotationOptions.DeliveryTerm:
					dt = new SaleQTDAL().GetQuotationDeliveryTerm();
					break;

				case OMShareSaleEnum.SaleQuotationOptions.DeliveryTime:
					dt = new SaleQTDAL().GetQuotationDeliveryTime();
					break;

				case OMShareSaleEnum.SaleQuotationOptions.PaymentTerm:
					dt = new SaleQTDAL().GetQuotationPaymentTerm();
					break;

				case OMShareSaleEnum.SaleQuotationOptions.SalePerson:
					//dt = new Models.SaleModel.SaleQTDAL().GetQuotationDeliveryTerm();
					break;

				case OMShareSaleEnum.SaleQuotationOptions.Training:
					dt = new SaleQTDAL().GetQuotationTraining();
					break;

				case OMShareSaleEnum.SaleQuotationOptions.Warranty:
					dt = new SaleQTDAL().GetQuotationWarrantyTerm();
					break;
			}

			using (var _opt = new SaleOptions(_option, dt))
			{
				_opt.StartPosition = FormStartPosition.CenterScreen;
				_opt.ShowDialog();
				if (_opt.IsEmptyResult == false)
				{
					IsEmptyResult = _opt.IsEmptyResult;
					Value = _opt.Value;
				}
			}
		} // end GetSaleQuotationOption

		#endregion

		#region class property

		public bool IsEmptyResult { get; set; }

		public string Value { get; set; }

		#endregion
	}
}