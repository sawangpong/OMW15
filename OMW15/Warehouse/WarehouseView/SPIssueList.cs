using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Warehouse.WarehouseView
{
	public partial class SPIssueList : Form
	{
		#region class field member
		private Warehouse.WarehouseContoller.WarehouseSPViewMode _viewMode = WarehouseContoller.WarehouseSPViewMode.View;
		private string _selectedDocumentCode = string.Empty;
		private string _selectedIssueNumber = string.Empty;
		private int _selectedDocumentKey = 0;
		private int _selectedDocumentYear = DateTime.Today.Year;
		private int _selectedDocumentPeriod = DateTime.Today.Month;
		private int _selectedDocId = 0;
		private int _selectedProjectId = 0;

		#endregion

		#region class property
		public string SelectedTitle
		{
			get;
			set;
		}

		public int OrderId
		{
			get;
			set;
		}
		public string OrderCode
		{
			get;
			set;
		}

		public string OrderNumber
		{
			get;
			set;
		}


		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.btnPostToOrder.Visible = (_viewMode == WarehouseContoller.WarehouseSPViewMode.Select);
			this.tslbOrderNo.Visible = this.btnPostToOrder.Visible;

			switch (_viewMode)
			{
				case WarehouseContoller.WarehouseSPViewMode.Select:
					this.tslbOrderNo.Text = string.Format("{0}{1}", this.OrderCode, this.OrderNumber);
					break;
				case WarehouseContoller.WarehouseSPViewMode.View:
					break;
			}

		} // end UpdateUI

		private void GetYearList<T>(T DocumentKey)
		{
			DataTable _dt = new  Warehouse.WarehouseContoller.WHDocuments().GetDocumentYearList(DocumentKey);
			if (_dt.Rows.Count > 0)
			{
				this.cbxYear.DataSource = _dt;
				this.cbxYear.DisplayMember = "YEARCODE";
				this.cbxYear.ValueMember = "YEARCODE";
			}
			else
			{
				this.cbxYear.DataSource = null;
			}

			// set default selected
			this.cbxYear.SelectedValue = DateTime.Today.Year;

		} // end GetIssueYear

		private void GetPeriodList(int DocumentKey, int SelectedYear)
		{
			DataTable _dt = new Warehouse.WarehouseContoller.WHDocuments().GetDocumentPeriodListByDocumentTyte(DocumentKey, SelectedYear);
			if (_dt.Rows.Count > 0)
			{
				this.cbxPeriod.DataSource = _dt;
				this.cbxPeriod.DisplayMember = "PERIODNAME";
				this.cbxPeriod.ValueMember = "PERIOD";
			}
			else
			{
				this.cbxPeriod.DataSource = null;
			}

			// set default selected
			this.cbxPeriod.SelectedValue = DateTime.Today.Month;

		} // end GetIssueYear

		private void GetIssueList(int DocKey, int YearIssue, int PeriodIssue)
		{
			DataTable _dt = new Warehouse.WarehouseContoller.IssueController().GetServiceSparePartIssueList(DocKey, YearIssue, PeriodIssue);
			this.dgvDocH.SuspendLayout();
			this.dgvDocH.DataSource = _dt;
			this.dgvDocH.Columns["DOCKEY"].Visible = false;
			this.dgvDocH.Columns["REMARK"].Visible = false;
			this.dgvDocH.Columns["UPDATEBY"].Visible = false;
			this.dgvDocH.Columns["LASTUPDATE"].Visible = false;
			this.dgvDocH.Columns["WORKSTATION"].Visible = false;
			this.dgvDocH.ResumeLayout();

		} // end GetIssueList

		private void CalTotalValues()
		{
			var items = ((DataTable)this.dgvIssueItems.DataSource).AsEnumerable();

			var total = (from item in items.AsParallel()
						 group item by item["DOCUMENTKEY"] into vsum
						 select new
						 {
							 vsum.Key,
							 vtotal = vsum.Sum(x => (decimal)x["SHIPTOTALVALUE"]),
							 gVat = vsum.Sum(x => (decimal)x["SHIPTOTALVAT"]),
							 GTotal = vsum.Sum(x => (decimal)x["SHIPGRANDTOTAL"])
						 }).ToList();

			foreach (var d in total)
			{
				this.txtTotal.Text = string.Format("{0:N2}", d.vtotal);
				this.txtVAT.Text = string.Format("{0:N2}", d.gVat);
				this.txtGrandTotal.Text = string.Format("{0:N2}", d.GTotal);
			}
		}

		private void GetIssueItem(int DocKey)
		{
			this.dgvIssueItems.SuspendLayout();

			this.dgvIssueItems.DataSource = new Warehouse.WarehouseContoller.IssueController().GetIssueItems(DocKey);

			// formatting the columns
			this.dgvIssueItems.Columns["ISSUELINEID"].Visible = false;
			this.dgvIssueItems.Columns["DOCUMENTKEY"].Visible = false;
			this.dgvIssueItems.Columns["DOCUMENTDATE"].Visible = false;
			this.dgvIssueItems.Columns["DOCUMENTNO"].Visible = false;
			this.dgvIssueItems.Columns["DEPARTMENTID"].Visible = false;
			this.dgvIssueItems.Columns["DEPARTMENTCODE"].Visible = false;
			this.dgvIssueItems.Columns["PROJECTNO"].Visible = false;

			foreach (DataGridViewColumn dgc in this.dgvIssueItems.Columns)
			{
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
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
						dgc.DefaultCellStyle.Format = "N2";
						dgc.HeaderText = "SHIP QTY.";
						break;

					case "SHIPUNITPRICE":
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
						dgc.DefaultCellStyle.Format = "N2";
						dgc.HeaderText = "UNIT PRICE";
						break;

					case "SHIPTOTALVALUE":
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
						dgc.DefaultCellStyle.Format = "N2";
						dgc.HeaderText = "TOTAL VALUE";
						break;

					case "SHIPTOTALVAT":
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
						dgc.DefaultCellStyle.Format = "N2";
						dgc.HeaderText = "TOTAL VAT";
						break;

					case "SHIPGRANDTOTAL":
						dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
						dgc.DefaultCellStyle.Format = "N2";
						dgc.HeaderText = "GRAND TOTAL";
						break;
				}
			}

			this.dgvIssueItems.ResumeLayout();

			this.CalTotalValues();


			this.UpdateUI();

		} // end GetIssueItem


		#endregion


		public SPIssueList(int DocumentKey, Warehouse.WarehouseContoller.WarehouseSPViewMode ViewMode = WarehouseContoller.WarehouseSPViewMode.View)
		{
			_viewMode = ViewMode;

			InitializeComponent();
			_selectedDocumentKey = DocumentKey;
			_selectedDocumentCode = string.Empty;
		}

		public SPIssueList(string DocumentCode, Warehouse.WarehouseContoller.WarehouseSPViewMode ViewMode = WarehouseContoller.WarehouseSPViewMode.View)
		{
			InitializeComponent();

			_viewMode = ViewMode;

			_selectedDocumentCode = DocumentCode;
			_selectedDocumentKey = new Warehouse.WarehouseContoller.WHDocuments().GetDocumentId(_selectedDocumentCode);
		}


		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SPIssueList_Load(object sender, EventArgs e)
		{
			// setting datagrid
			OMControls.OMUtils.SettingDataGridView(ref this.dgvDocH);
			OMControls.OMUtils.SettingDataGridView(ref this.dgvIssueItems);

			// display Title
			this.tslbTitle.Text = this.SelectedTitle;

			// loading issue document
			if (_selectedDocumentKey == 0)
			{
				this.GetYearList(_selectedDocumentCode);
			}
			else
			{
				this.GetYearList(_selectedDocumentKey);
			}

		}

		private void cbxYear_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedDocumentYear = Convert.ToInt32(this.cbxYear.SelectedValue);
			}
			catch
			{
				_selectedDocumentYear = DateTime.Today.Year;
			}

			this.GetPeriodList(_selectedDocumentKey, _selectedDocumentYear);

		}

		private void dgvDocH_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				_selectedDocId = Convert.ToInt32(this.dgvDocH["DOCKEY", e.RowIndex].Value);
				_selectedIssueNumber = this.dgvDocH["DOCNUMBER", e.RowIndex].Value.ToString();

				this.txtRemark.Text = this.dgvDocH["REMARK", e.RowIndex].Value.ToString();

				this.lbUpdateBy.Text = this.dgvDocH["UPDATEBY", e.RowIndex].Value.ToString();

				this.lbLastUpdate.Text = this.dgvDocH["LASTUPDATE", e.RowIndex].Value.ToString();

				this.lbWorkStation.Text = this.dgvDocH["WORKSTATION", e.RowIndex].Value.ToString();

				this.lbSelectIssueDate.Text = _selectedIssueNumber;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				_selectedDocId = 0;
				this.txtRemark.Text = string.Empty;
			}

			// display DI_KEY
			this.lbDI_KEY.Text = _selectedDocId.ToString();

			this.GetIssueItem(_selectedDocId);
		}

		private void cbxPeriod_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedDocumentPeriod = Convert.ToInt32(this.cbxPeriod.SelectedValue);
			}
			catch
			{
				_selectedDocumentPeriod = DateTime.Today.Month;
			}

			this.GetIssueList(_selectedDocumentKey, _selectedDocumentYear, _selectedDocumentPeriod);
		}

		private void dgvIssueItems_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedProjectId = Convert.ToInt32(this.dgvIssueItems["PROJECTNO", e.RowIndex].Value);

			if (_selectedProjectId > 0)
			{
				this.lbProject.Text = new Warehouse.WarehouseContoller.WHDocuments().GetProjectName(_selectedProjectId);
			}
			else
			{
				this.lbProject.Text = string.Empty;
			}
		}

		private void btnPostToOrder_Click(object sender, EventArgs e)
		{
			int _result = new Warehouse.WarehouseContoller.IssueController().SaveIssueItemToServiceOrder(this.OrderId, this.OrderNumber, this.OrderCode, _selectedIssueNumber, ref this.dgvIssueItems);

			StringBuilder s = new StringBuilder();
			s.AppendFormat("Update Issue {0} Items successfully", _result);
			s.AppendLine();
			s.AppendLine();
			s.Append("Do you want more select records from Issue List ?");

			if (_result > 0)
			{
				if (MessageBox.Show(s.ToString(), "Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
				{
					this.tsbtnClose.PerformClick();
				}
				else
				{
					this.btnRefresh.PerformClick();
				}
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			this.GetIssueItem(_selectedDocId);
		}
	}
}
