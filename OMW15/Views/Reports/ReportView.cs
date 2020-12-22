using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using OMW15.Models.SaleModel;
using OMW15.Shared;

namespace OMW15.Views.Reports
{
	public partial class ReportView : Form
	{
		#region class field member

		private readonly PrintDocumentType _printDoc;

		#endregion

		public ReportView(PrintDocumentType Doc = PrintDocumentType.None)
		{
			InitializeComponent();

			_printDoc = Doc;
		}

		#region class property

		public int DocumentId { get; set; }

		#endregion

		private void ReportView_Load(object sender, EventArgs e)
		{
			switch (_printDoc)
			{
				case PrintDocumentType.SaleInvoiceEN:
					break;
				case PrintDocumentType.SaleInvoiceTH:
					break;
				case PrintDocumentType.SaleOfferEN:
				case PrintDocumentType.SaleOfferTH:
					PrintSaleOffer(_printDoc, DocumentId);
					break;
				case PrintDocumentType.SalePI:
					ViewSalePI(DocumentId);
					break;
			}
		}

		#region class helper methods	

		private void ViewSalePI(int PIHeaderId)
		{
			ReportDocument _rpt = new SalePIForm();
			_rpt.SetDataSource(new PIReportDataSource(PIHeaderId));
			crview.ReportSource = _rpt;
		} // end ViewSalePI

		private void PrintSaleOffer(PrintDocumentType DocType, int OfferId)
		{
			var _rpt = new ReportDocument();

			switch (DocType)
			{
				case PrintDocumentType.SaleOfferEN:
					_rpt = new SaleQTEn();
					break;

				case PrintDocumentType.SaleOfferTH:
					//_rpt = new Views.Reports.SaleQTEn();
					break;
			}

			_rpt.SetDataSource(new SaleQTDataSource(OfferId));
			crview.ReportSource = _rpt;
		}

		#endregion
	}
}