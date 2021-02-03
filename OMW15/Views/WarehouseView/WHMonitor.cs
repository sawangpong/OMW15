using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.WarehouseModel;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OMW15.Views.WarehouseView
{
	public partial class WHMonitor : Form
	{
		#region Singleton

		public static WHMonitor _instance;
		public static WHMonitor GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed) _instance = new WHMonitor();
				return _instance;
			}
		}

		#endregion

		#region class field member
		private string _selectedCategoryCode = "";
		private string _selectedItemNo = "";
#pragma warning disable CS0414 // The field 'WHMonitor._selectedItemId' is assigned but its value is never used
		private int _selectedItemId = 0;
#pragma warning restore CS0414 // The field 'WHMonitor._selectedItemId' is assigned but its value is never used
		private int _selectedSearchIndex = 0;

		private DataTable dt = new DataTable();

		#endregion

		#region class property

		#endregion

		public WHMonitor()
		{
			InitializeComponent();
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);
			OMUtils.SettingDataGridView(ref dgvOnHand);
		}

		private void WHMonitor_Load(object sender, EventArgs e)
		{

			// establish search type list
			getSearchType();

			// loading Stock summary (separate by class A,B,C,D
			getStockSummaryByClassAsync();

			// show on-hand stock be category
			//getStockOnhandByCategoryAsync(_selectedCategoryCode);
			getStockOnhandByCategoryAsync();

			// update UI
			updateUI();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				string _text = dgv["CATEGORY", e.RowIndex].Value.ToString();

				if (_text != "TOTAL AMOUNT")
				{
					this.lbCatCode.Text = _text;
					_selectedCategoryCode = _text.Substring(0, _text.LastIndexOf(':'));
				}
				else
				{
					_selectedCategoryCode = "";
					this.lbCatCode.Text = "";
					dgvOnHand.DataSource = null;
				}
			}
			catch
			{
				dgvOnHand.DataSource = null;
			}

			//updateUI();
			updateStatusMonitor();
		}


		private void dgvOnHand_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			//_selectedItemId = Convert.ToInt32(dgvOnHand["ID", e.RowIndex].Value);

			_selectedItemNo = dgvOnHand["ITEMNO", e.RowIndex].Value.ToString();
			this.getItemMasterImage(_selectedItemNo);
			//lbId.Text = $"Item Id :: {_selectedItemId}";

			updateStatusMonitor();
		}

		private async void getItemMasterImage(string itemno)
		{
			var _wh = new WHDDAL();
			pic1.Image = (await _wh.getItemMasterImageAsync(itemno));
		}

		private void dgvOnHand_DoubleClick(object sender, EventArgs e)
		{
			var _scd = new WHStockCard(_selectedItemNo);
			_scd.StartPosition = FormStartPosition.CenterScreen;
			_scd.MdiParent = ParentForm;
			_scd.Show();
		}

		private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				btnSearch.PerformClick();
		}

		private void txtFilter_TextChanged(object sender, EventArgs e)
		{
			updateUI();
		}

		private void cbxSearchType_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedSearchIndex = cbxSearchType.SelectedIndex;
			}
			catch
			{
				_selectedSearchIndex = 0;
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			var _searchPhase = "";
			_searchPhase = $"ITEMNO LIKE '%{txtFilter.Text}%' OR ITEMNAME LIKE '%{txtFilter.Text}%' ";

			//if (_selectedSearchIndex == 0)
			//{
			//	_searchPhase = $"ITEMNO LIKE '%{txtFilter.Text}%' OR ITEMNAME LIKE '%{txtFilter.Text}%' ";
			//}
			//else
			//{
			//	_searchPhase = $"ITEMNAME LIKE '%{txtFilter.Text}%'";
			//}

			//(dgvOnHand.DataSource as DataTable).DefaultView.RowFilter = _searchPhase;

			dt.DefaultView.RowFilter = _searchPhase;

			displayStockOnHand(dt);

			updateStatusMonitor();
		}

		#region class helper method

		private void updateUI()
		{
			//pnlSearch.Enabled = (dgvOnHand.Rows.Count > 0);

			btnSearch.Enabled = (!string.IsNullOrEmpty(txtFilter.Text));

		} // end UpdateUI

		//private DataTable addRollup(DataTable Source)
		//{
		//	var _t = Source.Copy();
		//	var _dr = _t.NewRow();
		//	foreach (DataColumn dc in Source.Columns)
		//		if (dc.DataType == typeof(decimal))
		//			_dr[dc.ColumnName] = Source.AsEnumerable().Sum(x => x.Field<decimal>(dc.ColumnName));
		//		else if (dc.DataType == typeof(string))
		//			if (dc.Ordinal == 0)
		//				_dr[dc.Ordinal] = "Total";
		//			else
		//				_dr[dc.Ordinal] = "";
		//	_t.Rows.Add(_dr);
		//	return _t;
		//} // end AddRollup


		private async void getStockSummaryByClassAsync()
		{
			dgv.SuspendLayout();

			//var dt = new WHDDAL().GetStockSummaryByClassValues(_classA, _classB, _classC, _classD);
			//var dtSum = AddRollup(dt);

			var _wh = new WHDDAL();
			dgv.DataSource = await _wh.GetStockSummaryByClassValuesAsync(omglobal.SysConnectionString);
			foreach (DataGridViewColumn dgr in dgv.Columns)
			{
				if (dgr.ValueType == typeof(decimal))
				{
					dgr.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
			}

			dgv.Columns["A"].HeaderText = $"A > {omglobal._classA} ";
			dgv.Columns["B"].HeaderText = $"{omglobal._classB} > B < {omglobal._classA}";
			dgv.Columns["C"].HeaderText = $"{omglobal._classC} > C < {omglobal._classB}";
			dgv.Columns["D"].HeaderText = $"D < {omglobal._classC}";
			dgv.Columns["TOTAL"].HeaderText = "รวมทั้งสิ้น";

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			dgv.ResumeLayout();

		} // end GetStockSummaryByClass

		private async void getStockOnhandByCategoryAsync(string categoryCode = "")
		{
			var _wh = new WHDDAL();

			dt = await _wh.getStockOnhandByCategoryGroupAsync(categoryCode, omglobal.SysConnectionString);


		} // end ShowStockOnhand

		private void displayStockOnHand(DataTable Source)
		{
			dgvOnHand.SuspendLayout();
			dgvOnHand.DataSource = Source;
			dgvOnHand.Columns["ON_HAND"].DefaultCellStyle.Font = new Font(dgvOnHand.DefaultCellStyle.Font, FontStyle.Bold);

			dgvOnHand.Columns["CAT_KEY"].Visible = false;
			dgvOnHand.Columns["CAT_CODE"].Visible = false;

			dgvOnHand.Columns["LOCATION"].HeaderText = "คลังวัสดุ";
			dgvOnHand.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			dgvOnHand.Columns["ITEMNAME"].HeaderText = "รายละเอียด";
			dgvOnHand.Columns["UNIT"].HeaderText = "หน่วยนับ";
			dgvOnHand.Columns["UNIT_COST"].HeaderText = "ต้นทุนต่อหน่วย";
			//dgvOnHand.Columns["UNIT_PRICE"].HeaderText = "ราคาขายหน่วย";
			dgvOnHand.Columns["ON_HAND"].HeaderText = "จำนวนคงคลัง";
			dgvOnHand.Columns["MIN_QTY"].HeaderText = "จำนวนต่ำสุด";
			//dgvOnHand.Columns["MIN_ORDER"].HeaderText = "จำนวนสั่งต่ำสุด";
			dgvOnHand.Columns["MAX_QTY"].HeaderText = "จำนวนสูงสุด";
			//dgvOnHand.Columns["MAX_ORDER"].HeaderText = "จำนวนสั่งสูงสุด";

			foreach (DataGridViewColumn dgc in dgvOnHand.Columns)
			{
				if (dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
			}


			dgvOnHand.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			dgvOnHand.ResumeLayout();
			updateUI();

		} // end DisplayStockOnHand

		private void getSearchType()
		{
			string[] _searchType = { "By Item No.", "By Item name" };
			cbxSearchType.Items.Clear();
			cbxSearchType.Items.AddRange(_searchType);
			cbxSearchType.SelectedIndex = 0;

		} // end GetSearchType

		private void updateStatusMonitor()
		{
			//lbItemId.Text = $"Item Id :: {_selectedItemId}";
			lbOnHandRowCount.Text = $"found :: {dgvOnHand.Rows.Count} รายการ";

		} // end UpdateStatusMonitor

		#endregion

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(_selectedCategoryCode))
			{
				// clear search textbox
				this.txtFilter.Text = "";
			}
		}

		private void dgv_Resize(object sender, EventArgs e)
		{
			this.pnlHolder.Height = (this.dgv.Height + this.pnlSearch.Height);
		}
	}
}