using OMControls;
using OMW15.Models.ProductionModel;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class ProductionSendStock : Form
	{
		#region class field
		private string _orderNo = string.Empty;
		private string _itemNo = string.Empty;
		private string _selectedReceiveNo = string.Empty;
		private int _selectedReceiveId = 0;
		#endregion

		#region class property
		public string ReceiveUnit { get; set; }
		public decimal TotalReceiveQty { get; set; }
		public decimal TotalReceiveCost { get; set; }
		public decimal AvgReceiveUCost { get; set; }
		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnEdit.Enabled = (!String.IsNullOrEmpty(_selectedReceiveNo));
		}

		private void GetIssueList(string orderNo)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new ProductionDAL().GetSend2WHList(orderNo);

			dgv.Columns["RECEIVEID"].Visible = false;
			dgv.Columns["REF_ISSUE_ID"].Visible = false;
			dgv.Columns["REF_TRANSFER_DOC"].Visible = false;
			dgv.Columns["RECEIVE_NO"].HeaderText = "เลขที่ใบแปร";
			dgv.Columns["RECEIVE_DATE"].HeaderText = "วันที่";
			dgv.Columns["RECEIVE_BY"].HeaderText = "รับโดย";
			dgv.Columns["RECEIVE_UNIT"].HeaderText = "หน่วยที่รับ";
			dgv.Columns["RECEIVE_QTY"].HeaderText = "จำนวนที่รับ";
			dgv.Columns["RECEIVE_COST"].HeaderText = "ต้นทุนทั้งหมด";
			dgv.Columns["RECEIVE_AVG_UCOST"].HeaderText = "ต้นทุน/หน่วย";

			dgv.Columns["RECEIVE_AVG_UCOST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["RECEIVE_COST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["RECEIVE_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dgv.ResumeLayout();

			_selectedReceiveNo = "";

			UpdateUI();

		}

		private void ReceiveItem(string receiveNo)
		{
			using (var _receive = new Receive2WH(_orderNo, receiveNo, _itemNo, this.ReceiveUnit))
			{
				_receive.StartPosition = FormStartPosition.CenterScreen;
				if (_receive.ShowDialog(this) == DialogResult.OK)
				{

				}
				else
				{
				}
			}

			GetIssueList(_orderNo);

		}

		private void SumMatCost()
		{
			if (dgv.Rows.Count > 0)
			{
				decimal _receiveQty = 0m;
				decimal _receiveCost = 0m;
				foreach (DataGridViewRow dgr in dgv.Rows)
				{
					_receiveQty += Convert.ToDecimal(dgr.Cells["RECEIVE_QTY"].Value);
					_receiveCost += Convert.ToDecimal(dgr.Cells["RECEIVE_COST"].Value);
				}
				this.AvgReceiveUCost = _receiveCost / (_receiveQty == 0m ? 1m : _receiveQty);
				this.TotalReceiveCost = _receiveCost;
				this.TotalReceiveQty = _receiveQty;
			}
		}



		#endregion


		public ProductionSendStock(string orderNo, string itemNo, string unitReceive)
		{
			InitializeComponent();

			_orderNo = orderNo;
			_itemNo = itemNo;
			this.ReceiveUnit = unitReceive;

			lbTitle.Text = $"ใบแปร (#{_orderNo}) >> {_itemNo}";

			OMUtils.SettingDataGridView(ref dgv);
		}

		private void ProductionSendStock_Load(object sender, EventArgs e)
		{
			GetIssueList(_orderNo);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedReceiveNo = dgv["RECEIVE_NO", e.RowIndex].Value.ToString();
			_selectedReceiveId = Convert.ToInt32(dgv["RECEIVEID", e.RowIndex].Value);
			UpdateUI();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			SumMatCost();

			this.Close();
		}

		private void btnAddIssue_Click(object sender, EventArgs e)
		{
			_selectedReceiveId = 0;
			_selectedReceiveNo = "";

			ReceiveItem(_selectedReceiveNo);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			ReceiveItem(_selectedReceiveNo);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnEdit.PerformClick();
		}

		private void btnReload_Click(object sender, EventArgs e)
		{
			GetIssueList(_orderNo);

		}
	}
}
