using System;
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
		public Quotations()
		{
			InitializeComponent();
		}

		#region class property

		public int QuotationId { get; set; }

		#endregion

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Quotations_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);

			UpdateMenuItems();
		}

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

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			GetQTInfo(QuotationId = 0);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			GetQTInfo(QuotationId);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_rowCount == dgv.Rows.Count)
			{
				QuotationId = Convert.ToInt32(dgv["QT_ID", e.RowIndex].Value);
				_selectedQTStatus =
					(OMShareSaleEnum.QoutationStatus)
					Enum.Parse(typeof(OMShareSaleEnum.QoutationStatus), dgv["QT_STATUS", e.RowIndex].Value.ToString());
				//_isMaster = this.dgv["MASTER", e.RowIndex].Value.ToString();
			}

			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			// load Quotation
			GetQuotationList(_qtType);
		}

		private void tsbtnPrintQT_Click(object sender, EventArgs e)
		{
			var _rptv = new ReportView(PrintDocumentType.SaleOfferEN);
			_rptv.DocumentId = QuotationId;
			_rptv.MdiParent = ParentForm;
			_rptv.WindowState = FormWindowState.Maximized;
			_rptv.Show();
		}

		#region class field members

		//private string _isMaster = "N";
		private OMShareSaleEnum.QoutationStatus _selectedQTStatus = OMShareSaleEnum.QoutationStatus.None;
		private OMShareSaleEnum.QuotationType _qtType = OMShareSaleEnum.QuotationType.Unknow;
		private int _rowCount;

		#endregion

		#region class helper methods

		private void UpdateMenuItems()
		{
			mnuMasterQT.Enabled = omglobal.PermisionId >= (int) OMShareSysConfigEnums.UserPermission.Manager;
			//this.mnuSep1.Visible = (this.mnuMasterQT.Visible == true);
			mnuAllQT.Enabled = mnuMasterQT.Enabled;

			UpdateUI();
		} // end UpdateMenuItems

		private void UpdateUI()
		{
			tsbtnEdit.Enabled = QuotationId > 0;
			tsbtnPrintQT.Enabled = tsbtnEdit.Enabled;

			// display selected menuitem
			stlbStatus.Text = string.Format("id={0} [status {1}:{2}]", QuotationId, (int) _selectedQTStatus, _selectedQTStatus);
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

			dgv.Columns["CUSTOMER"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["CURRENCY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["TOTALAMOUNT"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();


			dgv.ResumeLayout();

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
	}
}