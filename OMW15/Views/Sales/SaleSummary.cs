﻿using OMControls;
using OMW15.Models.SaleModel;
using System;
using System.Data;
using System.Windows.Forms;

namespace OMW15.Views.Sales
{

	public enum SaleGroups
	{
		ALL = 0,
		EXPORT = 1,
		LOCAL = 2
	}


	public partial class SaleSummary : Form
	{

		#region Singleton
		private static SaleSummary _instance;

		public static SaleSummary GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new SaleSummary();
				}
				return _instance;
			}
		}
		#endregion

		#region class field

		private int _saleYear = DateTime.Today.Year;
		private string _selectedSaleCategory = string.Empty;
		private string _selectedCategory = string.Empty;

		private bool _loadDataCompleted = false;
		private bool _columnsHadFormated = false;

		#endregion

		#region class properties
		public string Title { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			tsslbYearSale.Text = _saleYear.ToString();

			btnLoadData.Enabled = (_saleYear > 0);
		}

		private void GetSaleGroups()
		{
			cbxSaleGroup.DataSource = OMDataUtils.GetValueList<SaleGroups>().ToDataTable();
			cbxSaleGroup.DisplayMember = "VALUE";
			cbxSaleGroup.ValueMember = "KEY";
		}

		private void GetYearSale() //int saleGroup)
		{
			cbxSaleYear.DataSource = new SaleDAL().GetYearSaleByGroup();
			cbxSaleYear.DisplayMember = "YR";
			cbxSaleYear.ValueMember = "YR";
		}

		private void GetSaleSummary(int saleYear)
		{
			_loadDataCompleted = false;
			DataTable _dt = new SaleDAL().GetSaleSummary(saleYear);

			if (_dt.Rows.Count == 0)
			{
				MessageBox.Show($"No data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
	
			#region SummaryRow
			/*
				// add summary row
				DataRow _dr = _dt.NewRow();
				//StringBuilder s = new StringBuilder();
				foreach (DataColumn dc in _dt.Columns)
				{
					if (dc.ColumnName == "CATEGORY" || dc.ColumnName == "TYPE" || dc.ColumnName == "CODE")
					{
						_dr[dc.ColumnName] = "";
					}
					else if (dc.ColumnName == "CUSTOMER")
					{
						_dr[dc.ColumnName] = "TOTAL";
					}
					else
					{
						decimal _value = 0m;

						foreach (DataRow dr in _dt.Rows)
						{
							_value += Convert.ToDecimal(dr[dc.ColumnName].ToString());
						}
						// debug
						// s.AppendLine($"{dc.ColumnName} : {_value:N2} ");
						// MessageBox.Show(s.ToString(),"Debug");
						// end debug

						_dr[dc.ColumnName] = _value;
					}
				}

				// add summary row to datatable
				_dt.Rows.Add(_dr);

				// finish add summary row
				*/
			#endregion

			// binding data to datagridview

			dgv.SuspendLayout();
			dgv.DataSource = _dt;

			// format datagridview cell -> only numeric cell
			foreach (DataColumn _dc in _dt.Columns)
			{
				if (_dc.ColumnName != "CATEGORY")
				{
					dgv.Columns[_dc.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgv.Columns[_dc.ColumnName].DefaultCellStyle.Format = "N0";
				}
			}

			_loadDataCompleted = true;

			dgv.Columns["CATEGORY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.ResumeLayout();
			tsslbRows.Text = $"found : {dgv.Rows.Count} record{ (dgv.Rows.Count <= 1 ? string.Empty : "s")}";
			UpdateUI();
		}

		private void GetSummarySellDataStructure(string saleCategory, int yearSale)
		{
			DataTable _dt = new SaleDAL().GetSaleSummaryByCategory(saleCategory, yearSale);
			// format datagridview cell -> only numeric cell

			DataTable _dtEmty = _dt.Clone();

			dgvSellCat.DataSource = _dtEmty;
			foreach (DataColumn _dc in _dtEmty.Columns)
			{
				if (_dc.ColumnName != "CODE" && _dc.ColumnName != "CUSTOMER")
				{
					dgvSellCat.Columns[_dc.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgvSellCat.Columns[_dc.ColumnName].DefaultCellStyle.Format = "N0";
				}
			}
			_columnsHadFormated = true;
		}

		private void GetSummarySellByCategory(string saleCategory, int yearSale)
		{
			DataTable _dt = new SaleDAL().GetSaleSummaryByCategory(saleCategory, yearSale);

			dgvSellCat.SuspendLayout();

			// formating data columns
			if (_columnsHadFormated == false)
			{
				DataTable _dtEmty = _dt.Clone();
				dgvSellCat.DataSource = _dtEmty;
				foreach (DataColumn _dc in _dtEmty.Columns)
				{
					if (_dc.ColumnName != "CODE" && _dc.ColumnName != "CUSTOMER")
					{
						dgvSellCat.Columns[_dc.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
						dgvSellCat.Columns[_dc.ColumnName].DefaultCellStyle.Format = "N0";
					}
				}
				_columnsHadFormated = true;
			}

			// map data to datagridview
			dgvSellCat.DataSource = _dt;

			// format datagridview cell -> only numeric cell
			//if (_columnsHadFormated == false)
			//{
			//	foreach (DataColumn _dc in _dt.Columns)
			//	{
			//		if (_dc.ColumnName != "CODE" && _dc.ColumnName != "CUSTOMER")
			//		{
			//			dgvSellCat.Columns[_dc.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//			dgvSellCat.Columns[_dc.ColumnName].DefaultCellStyle.Format = "N0";
			//		}
			//	}
			//	_columnsHadFormated = true;
			//}

			dgvSellCat.Columns["CUSTOMER"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvSellCat.ResumeLayout();
			UpdateUI();

			lbSaleCategory.Text = $"{lbSaleCategory.Text} : ({dgvSellCat.Rows.Count})";
		}

		#endregion


		public SaleSummary()
		{
			InitializeComponent();

			OMControls.OMUtils.SettingDataGridView(ref dgv);
			OMControls.OMUtils.SettingDataGridView(ref dgvSellCat);

			_loadDataCompleted = false;
			_columnsHadFormated = false;
		}

		private void SaleSummary_Load(object sender, EventArgs e)
		{
			lbTitle.Text = this.Title;

			// create structure datable
			// GetSummarySellDataStructure("30", DateTime.Today.Year);

			GetYearSale();
		}

		private void btnLoadData_Click(object sender, EventArgs e)
		{
			dgvSellCat.DataSource = null;
			_columnsHadFormated = false;
			lbSaleCategory.Text = string.Empty;
	
			_loadDataCompleted = false;
			GetSaleSummary(_saleYear);
		}

		private void cbxSaleYear_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_saleYear = Convert.ToInt32(cbxSaleYear.SelectedValue.ToString());
			}
			catch
			{
				_saleYear = 0;
			}
			UpdateUI();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_loadDataCompleted)
			{
				_selectedSaleCategory = dgv["CATEGORY", e.RowIndex].Value.ToString().Substring(0, 2);

				if (_selectedSaleCategory.IsNumeric())
				{
					_selectedCategory = dgv["CATEGORY", e.RowIndex].Value.ToString().Substring(3);
					lbSaleCategory.Text = _selectedCategory;
					GetSummarySellByCategory(_selectedSaleCategory, _saleYear);
				}
				else
				{
					_selectedCategory = string.Empty;
					dgvSellCat.DataSource = null;
					_columnsHadFormated = false;
					lbSaleCategory.Text = _selectedCategory;
				}
			}
		}
	}
}
