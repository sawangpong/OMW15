using System;
using System.Windows.Forms;
using OMW15.Shared;
using OMW15.Views.CastingView;

namespace OMW15.Controllers.CastingController
{
	public class CastingReportControllers
	{
		// Constructor

		// public method 

		public void CastingMonthlyReport(PrintDocumentType PrintType)
		{
			var _yearReport = DateTime.Today.Year;
			var _monthReport = DateTime.Today.Month;

			using (var _option = new MonthYearOption())
			{
				_option.Option = MonthYearOption.MonthYearOptionScope.None;
				_option.MaterialCategory = "";

				if (_option.ShowDialog() == DialogResult.OK)
				{
					_yearReport = _option.SelectedYear;
					_monthReport = _option.SelectedMonth;
				}
			}

			// create report document object
			var _showReport = new CastingReportView(_yearReport, _monthReport);
			// show Report
			_showReport.PrintWhat = PrintType;

			_showReport.WindowState = FormWindowState.Maximized;
			_showReport.Show();
		} // end CastingMonthlyReport
	}
}