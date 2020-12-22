using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.WarehouseModel;
using OMW15.Shared;

namespace OMW15.Views.WarehouseView
{
	public partial class SPIssueList : Form
	{
		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void SPIssueList_Load(object sender, EventArgs e)
		{
			CenterToParent();

			// setting DataGridView
			OMUtils.SettingDataGridView(ref dgvDocH);
			OMUtils.SettingDataGridView(ref dgvIssueItems);

			// display Title
			tslbTitle.Text = SelectedTitle;

			// loading issue document
			if (_appCall != "SERVICE")
				if (_selectedDocumentKey == 0) GetYearList(_selectedDocumentCode);
				else GetYearList(_selectedDocumentKey);
		}

		private void cbxYear_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedDocumentYear = Convert.ToInt32(cbxYear.SelectedValue);
			}
			catch
			{
				_selectedDocumentYear = DateTime.Today.Year;
			}

			GetPeriodList(_selectedDocumentKey, _selectedDocumentYear);
		}

		private void dgvDocH_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (_rowCount == dgvDocH.Rows.Count)
				{
					_selectedDocId = Convert.ToInt32(dgvDocH["DOCKEY", e.RowIndex].Value);
					_selectedIssueNumber = dgvDocH["DOCNUMBER", e.RowIndex].Value.ToString();
					txtRemark.Text = dgvDocH["REMARK", e.RowIndex].Value.ToString();
					lbUpdateBy.Text = dgvDocH["UPDATEBY", e.RowIndex].Value.ToString();
					lbLastUpdate.Text = dgvDocH["LASTUPDATE", e.RowIndex].Value.ToString();
					lbWorkStation.Text = dgvDocH["WORKSTATION", e.RowIndex].Value.ToString();
					lbSelectIssueDate.Text = _selectedIssueNumber;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				_selectedDocId = 0;
				txtRemark.Text = string.Empty;
			}

			// display DI_KEY
			lbDI_KEY.Text = _selectedDocId.ToString();
			GetIssueItem(_selectedDocId);
		}

		private void cbxPeriod_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedDocumentPeriod = Convert.ToInt32(cbxPeriod.SelectedValue);
			}
			catch
			{
				_selectedDocumentPeriod = DateTime.Today.Month;
			}

			GetIssueList(_selectedDocumentKey, _selectedDocumentYear, _selectedDocumentPeriod);
		}

		private void dgvIssueItems_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedProjectId = Convert.ToInt32(dgvIssueItems["PROJECTNO", e.RowIndex].Value);

			if (_selectedProjectId > 0) lbProject.Text = new WHDDAL().getProjectName(_selectedProjectId);
			else lbProject.Text = string.Empty;
		}

		private void btnPostToOrder_Click(object sender, EventArgs e)
		{
			var _result = new IssueDAL().SaveIssueItemToServiceOrder(OrderId, OrderNumber, OrderCode, _selectedIssueNumber,
				ref dgvIssueItems);

			var s = new StringBuilder();
			s.AppendFormat("Update Issue {0} Items successfully", _result);
			s.AppendLine();
			s.AppendLine();
			s.Append("Do you want more select records from Issue List ?");

			if (_result > 0)
				if (MessageBox.Show(s.ToString(), "Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					tsbtnClose.PerformClick();
				else btnRefresh.PerformClick();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			GetIssueItem(_selectedDocId);
		}

		#region class field member

		private readonly OMShareWarehouseEnums.WarehouseSPViewMode _viewMode = OMShareWarehouseEnums.WarehouseSPViewMode.View;
		private readonly string[] _issuecode;
		private readonly string _appCall = string.Empty;
		private int _rowCount;

		private readonly string _selectedDocumentCode = string.Empty;
		private string _selectedIssueNumber = string.Empty;
		private int _selectedDocumentKey;
		private int _selectedDocumentYear = DateTime.Today.Year;
		private int _selectedDocumentPeriod = DateTime.Today.Month;
		private int _selectedDocId;
		private int _selectedProjectId;

		#endregion

		#region class property

		public string SelectedTitle { get; set; }

		public int OrderId { get; set; }

		public string OrderCode { get; set; }

		public string OrderNumber { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnPostToOrder.Visible = _viewMode == OMShareWarehouseEnums.WarehouseSPViewMode.Select;
			tslbOrderNo.Visible = btnPostToOrder.Visible;

			switch (_viewMode)
			{
				case OMShareWarehouseEnums.WarehouseSPViewMode.Select:
					tslbOrderNo.Text = string.Format("{0}{1}", OrderCode, OrderNumber);
					break;
				case OMShareWarehouseEnums.WarehouseSPViewMode.View:
					break;
			}
		} // end UpdateUI

		private void GetYearList<T>(T DocumentKey)
		{
			var _dt = new WHDDAL().getDocumentYearList(DocumentKey);
			if (_dt.Rows.Count > 0)
			{
				cbxYear.DataSource = _dt;
				cbxYear.DisplayMember = "YEARCODE";
				cbxYear.ValueMember = "YEARCODE";
			}
			else
			{
				cbxYear.DataSource = null;
			}

			// set default selected
			cbxYear.SelectedValue = DateTime.Today.Year;
		} // end GetIssueYear

		private void GetPeriodList(int DocumentKey, int SelectedYear)
		{
			var _dt = new WHDDAL().getDocumentPeriodListByDocumentTyte(DocumentKey, SelectedYear);
			if (_dt.Rows.Count > 0)
			{
				cbxPeriod.DataSource = _dt;
				cbxPeriod.DisplayMember = "PERIODNAME";
				cbxPeriod.ValueMember = "PERIOD";
			}
			else
			{
				cbxPeriod.DataSource = null;
			}

			// set default selected
			cbxPeriod.SelectedValue = DateTime.Today.Month;
		} // end GetIssueYear

		private void GetIssueList(int DocKey, int YearIssue, int PeriodIssue)
		{
			var _dt = new IssueDAL().GetServiceSparePartIssueList(DocKey, YearIssue, PeriodIssue);
			_rowCount = _dt.Rows.Count;

			dgvDocH.SuspendLayout();
			dgvDocH.DataSource = _dt;
			dgvDocH.Columns["DOCKEY"].Visible = false;
			dgvDocH.Columns["REMARK"].Visible = false;
			dgvDocH.Columns["UPDATEBY"].Visible = false;
			dgvDocH.Columns["LASTUPDATE"].Visible = false;
			dgvDocH.Columns["WORKSTATION"].Visible = false;
			dgvDocH.ResumeLayout();
		} // end GetIssueList

		private void CalTotalValues()
		{
			var items = ((DataTable) dgvIssueItems.DataSource).AsEnumerable();

			var total = (from item in items.AsParallel()
				group item by item["DOCUMENTKEY"]
				into vsum
				select new
				{
					vsum.Key,
					vtotal = vsum.Sum(x => (decimal) x["SHIPTOTALVALUE"]),
					gVat = vsum.Sum(x => (decimal) x["SHIPTOTALVAT"]),
					GTotal = vsum.Sum(x => (decimal) x["SHIPGRANDTOTAL"])
				}).ToList();

			foreach (var d in total)
			{
				txtTotal.Text = $"{d.vtotal:N2}";
				txtVAT.Text = $"{d.gVat:N2}";
				txtGrandTotal.Text = $"{d.GTotal:N2}";
			}
		} // end CalTotalValues

		private async void GetIssueItem(int DocKey)
		{
			dgvIssueItems.SuspendLayout();

			var _issue = new IssueDAL();
			var dt = await _issue.GetIssueItemsAsync(DocKey);
			dgvIssueItems.DataSource = dt;

			this.lbItemCount.Text = $"found: {dt.Rows.Count}";

			// formatting the columns
			dgvIssueItems.Columns["ISSUELINEID"].Visible = false;
			dgvIssueItems.Columns["DOCUMENTKEY"].Visible = false;
			dgvIssueItems.Columns["DOCUMENTDATE"].Visible = false;
			dgvIssueItems.Columns["DOCUMENTNO"].Visible = false;
			dgvIssueItems.Columns["DEPARTMENTID"].Visible = false;
			dgvIssueItems.Columns["DEPARTMENTCODE"].Visible = false;
			dgvIssueItems.Columns["PROJECTNO"].Visible = false;

			foreach (DataGridViewColumn dgc in dgvIssueItems.Columns)
			{
				if (dgc.ValueType == typeof(decimal)) dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

				switch (dgc.Name.ToUpper())
				{
					case "ORDERNUMBER":
						dgc.HeaderText = "ORDER-NO.";
						break;

					case "SHIPITEMNO":
						dgc.HeaderText = "ITEM NO.";
						break;

					case "SHIPITEMNAME":
						dgc.HeaderText = "ITEM NAME";
						break;

					case "SHIPUNIT":
						dgc.HeaderText = "SHIP UNIT";
						break;

					case "SHIPQTY":
						dgc.HeaderText = "SHIP QTY.";
						break;

					case "SHIPUNITPRICE":
						dgc.HeaderText = "UNIT PRICE";
						break;

					case "SHIPTOTALVALUE":
						dgc.HeaderText = "TOTAL VALUE";
						break;

					case "SHIPTOTALVAT":
						dgc.HeaderText = "TOTAL VAT";
						break;

					case "SHIPGRANDTOTAL":
						dgc.HeaderText = "GRAND TOTAL";
						break;
				}
			}

			dgvIssueItems.ResumeLayout();
			CalTotalValues();
			UpdateUI();
		} // end GetIssueItem

		private void CreateIssueMenuForService(string[] IssueCode)
		{
			var _service = new ToolStripDropDownButton("Service Issue Code");
			var dt = new WHDDAL().getIssueDocumentList(omglobal.SeriveIssueCode);

			foreach (DataRow dr in dt.Rows)
			{
				var _mnu = new ToolStripMenuItem($"{dr["DOCCODE"]} :: {dr["DOCNAME"]}");
				_mnu.Tag = dr["KEY"].ToString();
				_mnu.Click += mnu_Click;
				_service.DropDownItems.Add(_mnu);
			}

			ts.Items.Add(_service);
		} // end CreateIssueMenuForService

		private void mnu_Click(object sender, EventArgs e)
		{
			var _mnu = sender as ToolStripMenuItem;
			_selectedDocumentKey = Convert.ToInt32(_mnu.Tag.ToString());
			tslbIssueCode.Text = $"{_selectedDocumentKey} {_mnu.Text}";
			GetYearList(_selectedDocumentKey);
		} // end mnu_Click

		#endregion

		#region Class Constructor

		public SPIssueList(int DocumentKey,
			OMShareWarehouseEnums.WarehouseSPViewMode ViewMode = OMShareWarehouseEnums.WarehouseSPViewMode.View)
		{
			InitializeComponent();
			_viewMode = ViewMode;
			_selectedDocumentKey = DocumentKey;
			_selectedDocumentCode = string.Empty;
		}

		public SPIssueList(string DocumentCode,
			OMShareWarehouseEnums.WarehouseSPViewMode ViewMode = OMShareWarehouseEnums.WarehouseSPViewMode.View)
		{
			InitializeComponent();
			_viewMode = ViewMode;
			_selectedDocumentCode = DocumentCode;
			_selectedDocumentKey = new WHDDAL().GetDocumentId(_selectedDocumentCode);
		}

		public SPIssueList(string[] IssueCode,
			OMShareWarehouseEnums.WarehouseSPViewMode ViewMode = OMShareWarehouseEnums.WarehouseSPViewMode.View,
			string AppCall = "")
		{
			InitializeComponent();
			_viewMode = ViewMode;
			_issuecode = IssueCode;
			_appCall = AppCall;

			if (_appCall == "SERVICE") CreateIssueMenuForService(_issuecode);
		}

		#endregion
	}
}