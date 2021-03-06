﻿using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.SaleModel;
using OMW15.Shared;
using OMW15.Views.Reports;

namespace OMW15.Views.Sales
{
	public partial class Quotations : Form
	{
		#region Singleton
		private static Quotations _instance;
		public static Quotations GetInstance
		{
			get
			{
				if(_instance == null || _instance.IsDisposed)
				{
					_instance = new Quotations();
				}
				return _instance;
			}
		}
		#endregion

		#region class field members

		private OMShareSaleEnum.QoutationStatus _selectedQTStatus = OMShareSaleEnum.QoutationStatus.None;
		private OMShareSaleEnum.QuotationType _qtType = OMShareSaleEnum.QuotationType.Unknow;
		private int _rowCount;

		#endregion

		#region class helper methods

		private void UpdateMenuItems()
		{
			mnuMasterQT.Enabled = omglobal.PermisionId >= (int)OMShareSysConfigEnums.UserPermission.Manager;
			mnuAllQT.Enabled = mnuMasterQT.Enabled;

			UpdateUI();
		} // end UpdateMenuItems

		private void UpdateUI()
		{
			tsbtnEdit.Enabled = (QuotationId > 0);
			tsbtnPrintQT.Enabled = tsbtnEdit.Enabled;

			// display selected menuitem
			stlbStatus.Text = $"id={QuotationId}";
		} // end UpdateUI


		private void GetQuotationList(OMShareSaleEnum.QuotationType QTType)
		{
			dgv.SuspendLayout();

			// load data
			dgv.DataSource = new SaleQTDAL().GetQuotationList(QTType);
			_rowCount = dgv.Rows.Count;
			// formatting DataGridView
			dgv.Columns["QT_ID"].Visible = false;
			dgv.Columns["MASTER"].Visible = false;
			dgv.Columns["QT_PREFIX"].Visible = false;
			dgv.Columns["QT_STATUS"].Visible = false;

			dgv.Columns["NUMBER"].HeaderText = "OFFER NO.";
			dgv.Columns["VALIDDATE"].HeaderText = "VALID UNTIL";
			dgv.Columns["TOTAL_PRICE"].HeaderText = "TOTAL PRICE";
			dgv.Columns["TOTAL_DISCOUNT"].HeaderText = "DISCOUNT";
			dgv.Columns["NET_VALUE"].HeaderText = "NET VALUE";
			dgv.Columns["GOODSAMOUNT"].HeaderText = "TOTAL GOODS AMT";
			dgv.Columns["TOTALAMOUNT"].HeaderText = "TOTAL AMOUNT";

			dgv.Columns["SALEMAN"].HeaderText = "SALE CONTACT PERSON";


			//dgv.Columns["CUSTOMER"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["CURRENCY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["TOTAL_PRICE"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.Columns["TOTAL_DISCOUNT"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.Columns["NET_VALUE"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.Columns["VAT"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.Columns["GOODSAMOUNT"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.Columns["PACKING"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.Columns["SHIPPING"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgv.Columns["TOTALAMOUNT"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgv.ResumeLayout();

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
			lbQTCount.Text = $"found: {dgv.Rows.Count}";

			UpdateUI();
		} // end GetQuotationList

		private void GetQTInfo(int QTHeaderId)
		{
			var _qtInfo = new QTInfo(QTHeaderId);
			_qtInfo.StartPosition = FormStartPosition.CenterScreen;

			if (_qtInfo.ShowDialog(this) == DialogResult.OK)
			{
			}

			tsbtnRefresh.PerformClick();
		} // end GetQTInfo

		#endregion

		public Quotations()
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgv);
		}

		#region class property

		public int QuotationId { get; set; }

		#endregion

		private void tsbtnClose_Click(object sender, EventArgs e) => Close();

		private void Quotations_Load(object sender, EventArgs e) => UpdateMenuItems();

		private void mnuQT_Click(object sender, EventArgs e)
		{
			var _mnu = sender as ToolStripMenuItem;

			// update selected view menu
			tsmnuQTView.Text = $"View : {_mnu.Tag.ToString()}";

			var _tag = _mnu.Tag.ToString().ToUpper();

			switch (_tag)
			{
				case "MASTER":
					_qtType = OMShareSaleEnum.QuotationType.Master;
					break;
				case "LOCAL":
					_qtType = OMShareSaleEnum.QuotationType.Local;
					break;
				case "INTER":
					_qtType = OMShareSaleEnum.QuotationType.International;
					break;
				case "ALL":
					_qtType = OMShareSaleEnum.QuotationType.Unknow;
					break;
			}

			// load Quotation
			GetQuotationList(_qtType);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e) => GetQTInfo(QuotationId = 0);

		private void tsbtnEdit_Click(object sender, EventArgs e) => GetQTInfo(QuotationId);

		private void dgv_DoubleClick(object sender, EventArgs e) => tsbtnEdit.PerformClick();

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_rowCount == dgv.Rows.Count)
			{
				QuotationId = Convert.ToInt32(dgv["QT_ID", e.RowIndex].Value);
				_selectedQTStatus =
					(OMShareSaleEnum.QoutationStatus)
					Enum.Parse(typeof(OMShareSaleEnum.QoutationStatus), dgv["QT_STATUS", e.RowIndex].Value.ToString());
			}

			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e) => GetQuotationList(_qtType);

		private void tsbtnPrintQT_Click(object sender, EventArgs e)
		{
			var _rptv = new ReportView(PrintDocumentType.SaleOfferEN);
			_rptv.DocumentId = QuotationId;
			_rptv.MdiParent = ParentForm;
			_rptv.WindowState = FormWindowState.Maximized;
			_rptv.Show();
		}
	
	}
}