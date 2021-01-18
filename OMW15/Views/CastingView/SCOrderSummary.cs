using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class SCOrderSummary : Form
	{
		#region Singleton
		private static SCOrderSummary _instance;
		public static SCOrderSummary GetInstance
		{
			get
			{
				if(_instance == null || _instance.IsDisposed)
				{
					_instance = new SCOrderSummary();
				}
				return _instance;
			}
		}

		#endregion


		private readonly ArrayList arrColumnLefts = new ArrayList(); //Used to save left coordinates of columns
		private readonly ArrayList arrColumnWidths = new ArrayList(); //Used to save column widths
		private bool bFirstPage; //Used to check whether we are printing first page
		private bool bNewPage; // Used to check whether we are printing a new page
		private int iCellHeight; //Used to get/set the datagridview cell height
		private int iHeaderHeight; //Used for the header height
		private int iRow; //Used as counter
		private int iTotalWidth; //

		private StringFormat strFormat; //Used to format the grid rows.


		// CONSTRUCTOR
		public SCOrderSummary()
		{
			InitializeComponent();
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);
		}


		private void SCOrderSummary_Load(object sender, EventArgs e)
		{
			GetSCYearList();
			var _mnu = new ContextMenu();
			pnlMenuLH.ContextMenu = _mnu;
			_mnu.Show(pnlMenuLH, new Point(0, lbReportTitle.Size.Height));
		}

		private void mnu_Click(object sender, EventArgs e)
		{
			var _mnu = sender as ToolStripMenuItem;
			var _t = _mnu.Text;
			tsmnu.Text = string.Format("ประเภทรายงาน :: {0}", _t);

			switch (_mnu.Tag.ToString().ToUpper())
			{
				case "AR_AGING":
					_reportType = CastingReportSummaryType.AR_Aging;
					break;

				case "LABOUR":
					_reportType = CastingReportSummaryType.Labour;
					break;

				case "LABOUR_COMM":
					_reportType = CastingReportSummaryType.Labour_Comm;
					break;

				case "MATERIAL":
					_reportType = CastingReportSummaryType.Material;
					break;

				case "MATERIAL_COMM":
					_reportType = CastingReportSummaryType.Material_Comm;
					break;

				case "BILL_COLLECTION":
					_reportType = CastingReportSummaryType.BillCollection;
					break;

				case "SI":
					_reportType = CastingReportSummaryType.SI;
					break;

				case "MAT_RETURN":
					_reportType = CastingReportSummaryType.MatReturn;
					break;
			}

			GetSCSummaryReport(_fiscyear, _reportType);
		}

		private void tscbxFiscYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_fiscyear = (int)tscbxFiscYear.ComboBox.SelectedValue;
			}
			catch
			{
				_fiscyear = DateTime.Today.Year;
			}

			if (_reportType != CastingReportSummaryType.None) GetSCSummaryReport(_fiscyear, _reportType);
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button_Click(object sender, EventArgs e)
		{
			var _btn = sender as Button;

			lbReportTitle.Text = _btn.Text;
			switch (_btn.Tag.ToString().ToUpper())
			{
				case "AR_AGING":
					_reportType = CastingReportSummaryType.AR_Aging;
					break;

				case "LABOUR":
					_reportType = CastingReportSummaryType.Labour;
					break;

				case "LABOUR_COMM":
					_reportType = CastingReportSummaryType.Labour_Comm;
					break;

				case "MATERIAL":
					_reportType = CastingReportSummaryType.Material;
					break;

				case "MATERIAL_COMM":
					_reportType = CastingReportSummaryType.Material_Comm;
					break;

				case "BILL_COLLECTION":
					_reportType = CastingReportSummaryType.BillCollection;
					break;

				case "SI_NOBILLING":
					_reportType = CastingReportSummaryType.NonBillingOrder;
					break;

				case "SI":
					_reportType = CastingReportSummaryType.SI;
					break;

				case "MAT_RETURN":
					_reportType = CastingReportSummaryType.MatReturn;
					break;
			}

			GetSCSummaryReport(_fiscyear, _reportType);
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			var printDialog = new PrintDialog();
			printDialog.Document = printDocument1;
			printDialog.UseEXDialog = true;

			// get the document
			if (DialogResult.OK == printDialog.ShowDialog())
			{
				var _preview = new PrintPreviewDialog();
				_preview.Document = printDocument1;
				_preview.ShowDialog();
			}
		}


		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			try
			{
				//Set the left margin
				var iLeftMargin = e.MarginBounds.Left;

				//Set the top margin
				var iTopMargin = e.MarginBounds.Top;

				//Whether more pages have to print or not
				var bMorePagesToPrint = false;
				var iTmpWidth = 0;

				//For the first page to print set the cell width and header height
				if (bFirstPage)
					foreach (DataGridViewColumn GridCol in dgv.Columns)
					{
						iTmpWidth = (int)Math.Floor(GridCol.Width /
															  (double)iTotalWidth * iTotalWidth *
															  (e.MarginBounds.Width / (double)iTotalWidth));

						iHeaderHeight = (int)e.Graphics.MeasureString(GridCol.HeaderText,
												 GridCol.InheritedStyle.Font, iTmpWidth).Height + 11;

						// Save width and height of headres
						arrColumnLefts.Add(iLeftMargin);
						arrColumnWidths.Add(iTmpWidth);
						iLeftMargin += iTmpWidth;
					}
				//Loop till all the grid rows not get printed
				while (iRow <= dgv.Rows.Count - 1)
				{
					var GridRow = dgv.Rows[iRow];
					//Set the cell height
					iCellHeight = GridRow.Height + 5;
					var iCount = 0;
					//Check whether the current page settings more rows to print
					if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
					{
						bNewPage = true;
						bFirstPage = false;
						bMorePagesToPrint = true;
						break;
					}
					if (bNewPage)
					{
						var _font = new Font(dgv.Font, FontStyle.Bold);
						// Draw Header
						e.Graphics.DrawString("Customer Summary", _font,
							Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
																			e.Graphics.MeasureString("Customer Summary", _font, e.MarginBounds.Width)
																				.Height - 13);

						var strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
						//Draw Date
						e.Graphics.DrawString(strDate, _font,
							Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
																			  e.Graphics.MeasureString(strDate, _font, e.MarginBounds.Width).Width),
							e.MarginBounds.Top -
							e.Graphics.MeasureString("Customer Summary", _font, e.MarginBounds.Width).Height - 13);

						// Draw Columns                 
						iTopMargin = e.MarginBounds.Top;
						foreach (DataGridViewColumn GridCol in dgv.Columns)
						{
							e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
								new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
									(int)arrColumnWidths[iCount], iHeaderHeight));

							e.Graphics.DrawRectangle(Pens.Black,
								new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
									(int)arrColumnWidths[iCount], iHeaderHeight));

							e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
								new SolidBrush(GridCol.InheritedStyle.ForeColor),
								new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
									(int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
							iCount++;
						}
						bNewPage = false;
						iTopMargin += iHeaderHeight;
					}
					iCount = 0;
					// Draw Columns Contents                
					foreach (DataGridViewCell Cel in GridRow.Cells)
					{
						if (Cel.Value != null)
							e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
								new SolidBrush(Cel.InheritedStyle.ForeColor),
								new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
									(int)arrColumnWidths[iCount], iCellHeight), strFormat);
						//Drawing Cells Borders 
						e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
							iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

						iCount++;
					}
					iRow++;
					iTopMargin += iCellHeight;
				}

				//If more lines exist, print another page.
				if (bMorePagesToPrint)
					e.HasMorePages = true;
				else
					e.HasMorePages = false;
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
		{
			try
			{
				strFormat = new StringFormat();
				strFormat.Alignment = StringAlignment.Near;
				strFormat.LineAlignment = StringAlignment.Center;
				strFormat.Trimming = StringTrimming.EllipsisCharacter;

				arrColumnLefts.Clear();
				arrColumnWidths.Clear();
				iCellHeight = 0;
				iRow = 0;
				bFirstPage = true;
				bNewPage = true;

				// Calculating Total Widths
				iTotalWidth = 0;
				foreach (DataGridViewColumn dgvGridCol in dgv.Columns) iTotalWidth += dgvGridCol.Width;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#region class field member

		private enum CastingReportSummaryType
		{
			None,
			Labour,
			Labour_Comm,
			Material,
			Material_Comm,
			AR_Aging,
			BillCollection,
			NonBillingOrder,
			SI,
			MatReturn
		}

		private int _fiscyear = DateTime.Today.Year;
		private CastingReportSummaryType _reportType = CastingReportSummaryType.None;
		private DataTable _dt = new DataTable();

		#endregion

		#region class helper method

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetSCYearList()
		{
			var _dt = new SCOrderDAL().GetSCYearList();
			tscbxFiscYear.ComboBox.DataSource = _dt;
			tscbxFiscYear.ComboBox.DisplayMember = "FISCYEAR";
			tscbxFiscYear.ComboBox.ValueMember = "FISCYEAR";
			tscbxFiscYear.SelectedIndex = 0;

		} // end GetSCYearList

		private void FormattingDataGridViewColumnAndRow()
		{
			if (dgv.Rows.Count > 0)
			{
				// formatting DataGridViewColumns -- for numeric type
				foreach (DataGridViewColumn dgc in dgv.Columns)
					if (dgc.ValueType == typeof(decimal)) dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

				dgv.Columns["CUSTNAME"].HeaderText = "ลูกค้า";
				dgv.Columns["CUSTNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}

			// formatting the last row (Total Row)
			foreach (DataGridViewRow dgr in dgv.Rows)
				if (dgr.Index == dgv.Rows.Count - 1)
					if (dgr.Cells["CUSTNAME"].Value.ToString().ToUpper() == "TOTAL")
					{
						dgr.DefaultCellStyle.BackColor = Color.Orange;
						dgr.DefaultCellStyle.ForeColor = Color.DarkBlue;
						dgr.DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Bold);
					}
		} // end FormattingDataGridViewColumnAndRow


		private async void GetAsyncNonBillingSIOrders(int FiscYear)
		{
			var _dal = new SCOrderDAL();

			_dt = await _dal.AsyncNonBillingSIOrders(FiscYear);

			var _source = await DataTableTools.AsyncAddRollup(_dt);

			dgv.SuspendLayout();
			if (_dt != null) dgv.DataSource = null;

			// binding data to DataGridView
			dgv.DataSource = _source;
			FormattingDataGridViewColumnAndRow();
			dgv.ResumeLayout();

			lbSCCount.Text = $"({dgv.Rows.Count - 1}) รายการ";
		} // end GetAsyncNonBillingSIOrders


		private async void GetAsyncSIAging()
		{
			var _dal = new SCOrderDAL();

			_dt = await _dal.GetAsyncSIAging();
			var _source = await DataTableTools.AsyncAddRollup(_dt);

			dgv.SuspendLayout();
			if (_dt != null) dgv.DataSource = null;

			// binding data to DataGridView
			dgv.DataSource = _source;
			FormattingDataGridViewColumnAndRow();
			dgv.ResumeLayout();
			lbSCCount.Text = $"({dgv.Rows.Count - 1}) รายการ";
		} // end GetAsyncSIAging

		private async void GetAsyncSICastingSummary(int FiscYear)
		{
			var _dal = new SCOrderDAL();

			_dt = await _dal.GetAsyncSISummaryCasting(FiscYear);
			var _source = await DataTableTools.AsyncAddRollup(_dt);
			dgv.SuspendLayout();
			if (_dt != null) dgv.DataSource = null;

			// binding data to DataGridView
			dgv.DataSource = _source;
			FormattingDataGridViewColumnAndRow();
			dgv.ResumeLayout();
			lbSCCount.Text = $"({dgv.Rows.Count - 1}) รายการ";
		} // end GetAsyncSICastingSummary

		private async void AsyncCommulativeSICasting(int Fiscyear)
		{
			var _dal = new SCOrderDAL();

			_dt = await _dal.AsyncCommulativeCastingValues(Fiscyear);
			var _source = await DataTableTools.AsyncAddRollup(_dt);
			dgv.SuspendLayout();
			if (_dt != null) dgv.DataSource = null;

			// binding data to DataGridView
			dgv.DataSource = _source;
			FormattingDataGridViewColumnAndRow();
			dgv.ResumeLayout();
			lbSCCount.Text = $"({dgv.Rows.Count - 1}) รายการ";
		} // end GetAsyncCommulativeSICasting


		private async void AsyncCommulativeSIMaterial(int Fiscyear)
		{
			var _dal = new SCOrderDAL();

			_dt = await _dal.AsyncCommulativeMaterialSell(Fiscyear);
			var _source = await DataTableTools.AsyncAddRollup(_dt);
			dgv.SuspendLayout();
			if (_dt != null) dgv.DataSource = null;

			// binding data to DataGridView
			dgv.DataSource = _source;
			FormattingDataGridViewColumnAndRow();
			dgv.ResumeLayout();
			lbSCCount.Text = $"({dgv.Rows.Count - 1}) รายการ";
		} // end AsyncCommulativeSIMaterial


		private async void AsyncSIMaterialSummarySell(int Fiscyear)
		{
			var _dal = new SCOrderDAL();

			_dt = await _dal.AsyncSISummarySaleMaterial(Fiscyear);
			var _source = await DataTableTools.AsyncAddRollup(_dt);
			dgv.SuspendLayout();
			if (_dt != null) dgv.DataSource = null;

			// binding data to DataGridView
			dgv.DataSource = _source;
			FormattingDataGridViewColumnAndRow();
			dgv.ResumeLayout();
			lbSCCount.Text = $"({dgv.Rows.Count - 1}) รายการ";
		} // end AsyncSIMaterialSummarySell

		private async void AsyncBillingCollectionSummary(int Fiscyear)
		{
			var _dal = new SCOrderDAL();

			_dt = await _dal.AsyncBillCollectionSummary(Fiscyear);
			var _source = await DataTableTools.AsyncAddRollup(_dt);
			dgv.SuspendLayout();
			if (_dt != null) dgv.DataSource = null;

			// binding data to DataGridView
			dgv.DataSource = _source;
			FormattingDataGridViewColumnAndRow();
			dgv.ResumeLayout();
			lbSCCount.Text = $"({dgv.Rows.Count - 1}) รายการ";
		} // end AsyncBillingCollectionSummary


		private void GetSCSummaryReport(int FiscYear, CastingReportSummaryType ReportType)
		{
			switch (ReportType)
			{
				case CastingReportSummaryType.AR_Aging:
					GetAsyncSIAging();
					break;

				case CastingReportSummaryType.Labour:
					GetAsyncSICastingSummary(FiscYear);
					break;

				case CastingReportSummaryType.Labour_Comm:
					AsyncCommulativeSICasting(FiscYear);
					break;

				case CastingReportSummaryType.Material:
					AsyncSIMaterialSummarySell(FiscYear);
					break;

				case CastingReportSummaryType.Material_Comm:
					AsyncCommulativeSIMaterial(FiscYear);
					break;

				case CastingReportSummaryType.BillCollection:
					AsyncBillingCollectionSummary(FiscYear);
					break;

				case CastingReportSummaryType.NonBillingOrder:
					GetAsyncNonBillingSIOrders(FiscYear);
					break;

				case CastingReportSummaryType.MatReturn:
					GetAsyncMaterialReturn("SILVER");
					break;

				case CastingReportSummaryType.SI:
					GetAsyncTotalDeliveryWithSI("SILVER");
					break;
			}
		} // end GetSCSummaryReport


		private async void GetAsyncTotalDeliveryWithSI(string MaterialCategory)
		{
			var _year = DateTime.Today.Year;
			var _month = DateTime.Today.Month;

			using (var _option = new MonthYearOption())
			{
				_option.Option = MonthYearOption.MonthYearOptionScope.DeliveryMaterial;
				_option.MaterialCategory = MaterialCategory;
				_option.SelectedMonth = _month;
				_option.SelectedYear = _year;
				_option.StartPosition = FormStartPosition.CenterParent;

				if (_option.ShowDialog(this) == DialogResult.OK)
				{
					_year = _option.SelectedYear;
					_month = _option.SelectedMonth;
				}
			}

			var _dal = new ReturnMaterialDAL();
			var dt = await _dal.GetIssueWithSI(MaterialCategory, _year, _month);

			dgv.SuspendLayout();
			dgv.DataSource = dt;
			dgv.Columns["CUSTCODE"].Visible = false;

			//this.FormattingDataGridViewColumnAndRow();
			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.ValueType == typeof(decimal)) dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.ResumeLayout();
		} // end GetAsyncTotalDeliveryWithSI

		private async void GetAsyncMaterialReturn(string MaterialCategory)
		{
			var _year = DateTime.Today.Year;
			var _month = DateTime.Today.Month;

			using (var _option = new MonthYearOption())
			{
				_option.Option = MonthYearOption.MonthYearOptionScope.ReturnMaterial;
				_option.MaterialCategory = MaterialCategory;
				_option.SelectedMonth = _month;
				_option.SelectedYear = _year;
				_option.StartPosition = FormStartPosition.CenterParent;
				if (_option.ShowDialog(this) == DialogResult.OK)
				{
					_year = _option.SelectedYear;
					_month = _option.SelectedMonth;
				}
			}

			var _dal = new ReturnMaterialDAL();
			var dt = await _dal.GetAsyncCustomerReturnMaterial(MaterialCategory, _year, _month);

			dgv.DataSource = dt;

			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.ValueType == typeof(decimal)) dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.ResumeLayout();
		} // end GetAsyncMaterialReturn

		#endregion
	}
}