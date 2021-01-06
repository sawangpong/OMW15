using OMControls;
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

		private void GetYearSaleBySaleGroup() //int saleGroup)
		{
			cbxSaleYear.DataSource = new SaleDAL().GetYearSaleByGroup();
			cbxSaleYear.DisplayMember = "YR";
			cbxSaleYear.ValueMember = "YR";
		}

		private void GetSaleSummary(int saleYear)
		{
			DataTable _dt = new SaleDAL().GetSaleSummaryByGroup(saleYear);

			if (_dt.Rows.Count == 0)
			{
				MessageBox.Show($"No data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

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

			// binding data to datagridview

			dgv.SuspendLayout();
			dgv.DataSource = _dt;

			//dgv.Columns["TYPE"].Visible = false;
			//dgv.Columns["CUSTOMER"].Frozen = true;

			/*&& _dc.ColumnName != "CUSTOMER"
		&& _dc.ColumnName != "TYPE")
		*/      // format datagridview cell -> only numeric cell
			foreach (DataColumn _dc in _dt.Columns)
			{
				if (_dc.ColumnName != "CATEGORY")
 				{
					dgv.Columns[_dc.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgv.Columns[_dc.ColumnName].DefaultCellStyle.Format = "N0";
				}
			}

			dgv.ResumeLayout();
			tsslbRows.Text = $"found : {dgv.Rows.Count} record{ (dgv.Rows.Count <= 1 ? string.Empty : "s")}";
			UpdateUI();
		}


		#endregion


		public SaleSummary()
		{
			InitializeComponent();

			OMControls.OMUtils.SettingDataGridView(ref dgv);
			OMControls.OMUtils.SettingDataGridView(ref dgvByGroup);

			//GetSaleGroups();
		}

		private void SaleSummary_Load(object sender, EventArgs e)
		{
			lbTitle.Text = this.Title;
			//cbxSaleGroup.SelectedIndex = 0;
			//_saleGroup = Convert.ToInt32(cbxSaleGroup.SelectedValue.ToString());
			GetYearSaleBySaleGroup();

		}

		//private void cbxSaleGroup_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//	_saleGroup = Convert.ToInt32(cbxSaleGroup.SelectedValue.ToString());

		//	_saleYear = 0;
		//	GetYearSaleBySaleGroup(_saleGroup);
		//	UpdateUI();
		//}

		private void btnLoadData_Click(object sender, EventArgs e)
		{
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
	}
}
