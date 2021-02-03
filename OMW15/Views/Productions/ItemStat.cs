using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.ProductionModel;
using OMW15.Shared;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class ItemStat : Form
	{
		#region Singleton
		private static ItemStat _instance;
		public static ItemStat GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new ItemStat();
				}
				return _instance;
			}
		}

		#endregion


		#region class fields

#pragma warning disable CS0414 // The field 'ItemStat._searchType' is assigned but its value is never used
		private OMShareProduction.SearchSTDItem _searchType = OMShareProduction.SearchSTDItem.None;
#pragma warning restore CS0414 // The field 'ItemStat._searchType' is assigned but its value is never used
		private string _selectedStdItemNo = "";
#pragma warning disable CS0414 // The field 'ItemStat._selectedItemNo' is assigned but its value is never used
		private string _selectedItemNo = "";
#pragma warning restore CS0414 // The field 'ItemStat._selectedItemNo' is assigned but its value is never used
		private int _selectedYearProduction = DateTime.Today.Year;
		private int _selectedMonthProduction = DateTime.Today.Month;

		private string _filter = "";

		//private ContextMenu _ctmTask;

		#endregion

		#region class helper
		private void updateUI()
		{

		}

		private async void GetWorkHistory(string filter)
		{
			var _pd = new ProductionDAL();
			var dt = await _pd.GetWorkHistory(filter);

			dgvSTD.SuspendLayout();
			dgvSTD.DataSource = dt;

			dgvSTD.Columns["ITEMNO"].HeaderText = "Item-No.";
			dgvSTD.Columns["ITEMNAME"].HeaderText = "Description";
			dgvSTD.Columns["TOTAL_QTY"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
			dgvSTD.Columns["TOTAL_QTY"].HeaderText = "Total Qty";
			dgvSTD.Columns["UNITORDER"].HeaderText = "Unit";
			dgvSTD.Columns["UNITORDER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvSTD.Columns["WORK_ACTIVE"].HeaderText = "Active";
			dgvSTD.Columns["WORK_ACTIVE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvSTD.Columns["WORK_COMPLETED"].HeaderText = "Completed";
			dgvSTD.Columns["WORK_COMPLETED"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			dgvSTD.Columns[1].Frozen = true;

			dgvSTD.ResumeLayout();

			this.sbstdlbCount.Text = $"found: {this.dgvSTD.Rows.Count}";

		}

		//private async void getStandardItemProperty(OMShareProduction.SearchSTDItem searchType = OMShareProduction.SearchSTDItem.None, string filterString = "")
		//{
		//	this.dgvSTD.SuspendLayout();

		//	var _pd = new ProductionDAL();
		//	var dt = await _pd.GetProductionItemListAsync(searchType, filterString);

		//	if (dt == null || dt.Rows.Count == 0)
		//	{
		//		this.dgvSTD.DataSource = null;
		//	}

		//	dgvSTD.DataSource = dt;
		//	dgvSTD.Columns["ISLOCK"].Visible = false;
		//	dgvSTD.Columns["ITEMID"].Visible = false;
		//	dgvSTD.Columns["STATUS"].Visible = false;
		//	dgvSTD.Columns["DRAWINGREV"].Visible = false;
		//	dgvSTD.Columns["DRAWINGNO"].Visible = false;
		//	dgvSTD.Columns["SHEETNO"].Visible = false;
		//	dgvSTD.Columns["MATERIAL"].Visible = false;

		//	dgvSTD.Columns["STDPRODUCTHOURS"].HeaderText = "STD Hours";
		//	dgvSTD.Columns["STDPRODUCTHOURS"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

		//	dgvSTD.Columns["MATERIALCOST"].HeaderText = "Material Cost";
		//	dgvSTD.Columns["MATERIALCOST"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

		//	this.dgvSTD.ResumeLayout();

		//	this.sbstdlbCount.Text = $"found: {this.dgvSTD.Rows.Count}";
		//}

		//private async void getItemStat(string itemFilter)
		//{
		//	this.dgvSTAT.SuspendLayout();

		//	var _pd = new ProductionDAL();
		//	var dt = await _pd.GetProductionSummaryAsync(itemFilter, omglobal.SysConnectionString);

		//	if (dt == null || dt.Rows.Count == 0)
		//	{
		//		this.dgvSTAT.DataSource = null;
		//	}

		//	this.dgvSTAT.DataSource = dt;

		//	// formatting cell for numerial value
		//	foreach (DataGridViewColumn dgc in this.dgvSTAT.Columns)
		//	{
		//		if (dgc.ValueType == typeof(decimal))
		//		{
		//			dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
		//		}
		//	}

		//	this.dgvSTAT.ResumeLayout();
		//}

		//private async void getItemAvgByYear(string itemFilter)
		//{
		//	this.dgvStatByYear.SuspendLayout();

		//	var _pd = new ProductionDAL();
		//	var dt = await _pd.GetProductionAvgByYearAsync(itemFilter, omglobal.SysConnectionString);

		//	if (dt == null || dt.Rows.Count == 0)
		//	{
		//		this.dgvStatByYear.DataSource = null;
		//	}

		//	this.dgvStatByYear.DataSource = dt;

		//	// formatting cell for numerial value
		//	foreach (DataGridViewColumn dgc in this.dgvStatByYear.Columns)
		//	{
		//		if (dgc.ValueType == typeof(decimal))
		//		{
		//			dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
		//		}
		//	}

		//	this.dgvStatByYear.ResumeLayout();
		//}


		private async void GetProductionHistoryAsync(string itemno)
		{
			dgvProduction.SuspendLayout();
			dgvProduction.DataSource = null;

			try
			{
				var p = new ProductionDAL();
				var dt = await p.GetProductionJobHistoryListAsync(itemno);

				if (dt == null || dt.Rows.Count == 0)
				{
					this.dgvProduction.DataSource = null;
				}
				else
				{
					dgvProduction.DataSource = dt;

					// formated cell for numerial value
					foreach (DataGridViewColumn dgc in this.dgvProduction.Columns)
					{
						if (dgc.ValueType == typeof(decimal))
						{
							dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
						}
					}

					dgvProduction.Columns["PDJOBID"].Visible = false;
					dgvProduction.Columns["STATUS"].Visible = false;

					// formated HeaderText
					dgvProduction.Columns["STATUSNAME"].HeaderText = "STATUS";
					dgvProduction.Columns["JOBYEAR"].HeaderText = "YEAR";
					dgvProduction.Columns["ERP_ORDER"].HeaderText = "JOB-NO.";
					dgvProduction.Columns["UNITORDER"].HeaderText = "UNIT";
					dgvProduction.Columns["QORDER"].HeaderText = "QTY";
					dgvProduction.Columns["TOTAL_HOURS"].HeaderText = "Total-Hours";
					dgvProduction.Columns["TOTAL_OUTSOURCE_COST"].HeaderText = "Outsource";
					dgvProduction.Columns["TOTAL_MAT_COST"].HeaderText = "Mat-Cost";
					dgvProduction.Columns["TOTAL_PRODUCTION_COST"].HeaderText = "Total-Cost";
					dgvProduction.Columns["UNITCOST"].HeaderText = "AVG. U-COST";


				}
				dgvProduction.Columns[4].Frozen = true;
			}
			catch
			{
				dgvProduction.DataSource = null;
			}
			dgvProduction.ResumeLayout();

			tslbProductionHistoryFound.Text = $"found : {dgvProduction.Rows.Count} row{(dgvProduction.Rows.Count > 1 ? "s" : " ")}";

		}

		/*
		private void CreateTaskContextMenu()
		{
			_ctmTask = new ContextMenu();

			var _mnu = new MenuItem("ค้นหาจากรายละเอียดสินค้า", SearchDescription);
			_ctmTask.MenuItems.Add(_mnu);

			_mnu = new MenuItem("ค้นหาจากรหัสสินค้า", SearchItemNo);
			_ctmTask.MenuItems.Add(_mnu);

			_mnu = new MenuItem("แสดงทุกรายการ", ReloadProductionTasks);
			_ctmTask.MenuItems.Add(_mnu);
		}

	
		private void ReloadProductionTasks(object sender, EventArgs e)
		{
			//_searchType = OMShareProduction.SearchSTDItem.None;
			//getStandardItemProperty(_searchType, "");
			GetWorkHistory(_filter);

		}

		private void SearchDescription(object sender, EventArgs e)
		{
			_searchType = OMShareProduction.SearchSTDItem.ItemDescription;
			// get input string filter for task name
			string _filterText = OMDataUtils.GetFilter<string>("หมายเลขงาน");

			getStandardItemProperty(_searchType, _filterText.ToUpper());
		} // end CreateTaskContextMenu

		private void SearchItemNo(object sender, EventArgs e)
		{
			_searchType = OMShareProduction.SearchSTDItem.ItemNumber;
			// get input string filter for task name
			string _filterText = OMDataUtils.GetFilter<string>("รหัสสินค้า");

			getStandardItemProperty(_searchType, _filterText.ToUpper());

		} // end SearchItemNo
		*/

		private async void DisplayCompareJobs(string itemNo)
		{
			string foundRecord = "";
			lbJobCompare.Text = $"Job compare - {itemNo} {foundRecord}";

			dgvCompare.SuspendLayout();
			dgvCompare.DataSource = null;

			var p = new ProductionDAL();
			var dt = await p.GetProductionJobHistoryCompareAsync(itemNo);

			if (dt == null || dt.Rows.Count == 0)
			{
				dgvCompare.DataSource = null;
				foundRecord = "No record for comparing!";
				return;
			}

			dgvCompare.DataSource = dt;

			// formated cell for numerial value
			if (dt != null)
			{
				foreach (DataGridViewColumn dgc in this.dgvCompare.Columns)
				{
					if (dgc.Name == "PROCESS" || dgc.Name == "MACHINE" || dgc.Name == "MAKER")
					{
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
					}
					else if (dgc.Name == "SOURCE" || dgc.Name == "STEP")
					{
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					}
					else
					{
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					}
				}

				dgvCompare.Columns[5].Frozen = true;
				dgvCompare.ResumeLayout();

				foundRecord = "";
			}
			lbJobCompare.Text = $"Job compare - {itemNo} {foundRecord}";

			updateUI();
		}



		#endregion

		public ItemStat()
		{
			InitializeComponent();

			OMUtils.SettingDataGridView(ref dgvSTD);
			OMUtils.SettingDataGridView(ref dgvProduction);
			OMUtils.SettingDataGridView(ref dgvCompare);


			//OMUtils.SettingDataGridView(ref dgvStatByYear);

		}

		private void ItemStat_Load(object sender, EventArgs e)
		{
			//getStandardItemProperty();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void dgvSTD_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedStdItemNo = this.dgvSTD["ITEMNO", e.RowIndex].Value.ToString();
			tslbSelectedItemNo.Text = $"selected item : {_selectedStdItemNo}";

			GetProductionHistoryAsync(_selectedStdItemNo);

			DisplayCompareJobs(_selectedStdItemNo);


			//if (string.IsNullOrEmpty(_selectedStdItemNo))
			//{
			//	this.dgvSTAT.DataSource = null;
			//	this.dgvStatByYear.DataSource = null;
			//	return;
			//}

			//this.getItemStat(_selectedStdItemNo);
			//this.getItemAvgByYear(_selectedStdItemNo);
		}

		private void dgvSTAT_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			//_selectedItemNo = dgvSTAT["ITEMNO", e.RowIndex].Value.ToString();
			//_selectedYearProduction = Convert.ToInt32(dgvSTAT["Y", e.RowIndex].Value);
			//_selectedMonthProduction = Convert.ToInt32(dgvSTAT["M", e.RowIndex].Value);

			//// update heder for production Job History
			//lbProductiontionJob.Text = $"Production Histories in {_selectedMonthProduction.GetMonthName()}/{_selectedYearProduction}";

			//getProductionHistoryAsync(_selectedItemNo, _selectedYearProduction, _selectedMonthProduction);
		}

		private void dgvSTD_MouseClick(object sender, MouseEventArgs e)
		{
			//if (e.Button == MouseButtons.Right)
			//{
			//	CreateTaskContextMenu();
			//	_ctmTask.Show(dgvSTD, new Point(e.X, e.Y));
			//}
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			//getStandardItemProperty();
			GetWorkHistory(_filter);
		}

		private void tsbtnSearch_Click(object sender, EventArgs e)
		{
			_filter = tsTxtFilter.Text;
			GetWorkHistory(_filter);
		}

		private void tsTxtFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tsbtnSearch.PerformClick();
			}
		}

		private void dgvProduction_CellEnter(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void ItemStat_Resize(object sender, EventArgs e)
		{
			dgvSTD.Update();
			dgvProduction.Update();
			dgvCompare.Update();

		}
	}
}
