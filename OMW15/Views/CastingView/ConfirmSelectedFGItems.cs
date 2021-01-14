using System;
using System.Data;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class ConfirmSelectedFGItems : Form
	{
		#region class field Member

		private ActionMode _soHeaderMode = ActionMode.None;
		private readonly DataTable _dtSource;

		#endregion

		#region class property
		public Guid SOGuid { get; set; }

		public int RefSOId { get; set; }

		public string SONumber { get; set; }

		public int CustomerId { get; set; }

		public string CustomerCode { get; set; }

		public string CustomerName { get; set; }

		public OMShareCastingEnums.SaleTypeEnum SaleType { get; set; }

		public bool IsVAT { get; set; }

		public bool IsVATIncl { get; set; }

		public decimal VATFactor { get; set; }

		public int TotalInsertItems { get; set; }

		public DateTime ActualDeliveryDate { get; set; }

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
		} // end UpdateUI


		private void InsertSOLines()
		{
			if (
			(TotalInsertItems +=
				new CastingSaleOrderDAL().InsertCastingSaleOrderItem(ref dgv, RefSOId, this.SOGuid, SONumber, (int)SaleType, VATFactor,
					ActualDeliveryDate)) > 0)
			{
			}
		} // end InsertSOLines

		private void GetSelectedFGList(DataTable Source)
		{
			dgv.SuspendLayout();
			dgv.DataSource = Source;
			dgv.Columns["ITEMID"].Visible = false;
			dgv.Columns["FGSEQ"].Visible = false;
			dgv.Columns["CUSTID"].Visible = false;
			dgv.Columns["CUSTCODE"].Visible = false;
			dgv.Columns["MATID"].Visible = false;
			dgv.Columns["TOTALDELIVERYWT"].Visible = false;
			dgv.Columns["TOTALLINEWT"].Visible = false;
			//dgv.Columns["UNITPRICE"].Visible = false;

			dgv.Columns["PREFIX"].HeaderText = "ประเภท";
			dgv.Columns["DOCDATE"].HeaderText = "วันที่";
			dgv.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			dgv.Columns["ITEMNAME"].HeaderText = "รายละเอียด";
			dgv.Columns["UNIT"].HeaderText = "หน่วยนับ";
			dgv.Columns["MATERIAL"].HeaderText = "ราคาต่อหน่วย";
			dgv.Columns["QTY"].HeaderText = "จำนวน";
			dgv.Columns["UNITWEIGHT"].HeaderText = "น.น. ต่อหน่วย";
			dgv.Columns["WEIGHT"].HeaderText = "น.น. รวม (กรัม)";

			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.Name != "DOCDATE" && dgc.ValueType == typeof(decimal))
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgv.ResumeLayout();

			lbRowCount.Text = $"found : {dgv.Rows.Count}";
		} // end GetSelectedFGList

		#endregion

		// CONSTRUCTOR
		public ConfirmSelectedFGItems(ActionMode SOHeaderMode, DataTable Source)
		{
			InitializeComponent();
			pnlHeader.BackColor = omglobal.OM_RED_COLOR;
			_dtSource = Source;
			_soHeaderMode = SOHeaderMode;
		}

		private void ConfirmSelectedFGItems_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);
			lbSOId.Text = $"ref:{this.SOGuid} - {SONumber}";
			lbCustomer.Text = $"Customer : {CustomerId} - [{CustomerCode}] {CustomerName}";
			lbVATFactor.Text = $"rate : {VATFactor:N2}";
			GetSelectedFGList(_dtSource);
		}

		private void btnConfirmFG_Click(object sender, EventArgs e)
		{
			InsertSOLines();
		}

	}
}