using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class SumOfDelivery : Form
	{
		public SumOfDelivery(string MatCategory)
		{
			InitializeComponent();
			MaterialCategory = MatCategory;
			lbTitle.Text = $"สรุป ยืม / คืน วัสดุ ({MaterialCategory})";
		}

		#region class property

		public string MaterialCategory
		{
			get; set;
		}

		#endregion

		private void SumOfDelivery_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgvIssue);
			OMUtils.SettingDataGridView(ref dgvReturn);

			//this.ShowAllDelivery(this.MaterialCategory, 2016, 6);
			GetMaterialDeliveryYear(MaterialCategory);
		}

		private void cbxYear_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedYear = Convert.ToInt32(cbxYear.SelectedValue);
			}
			catch
			{
				_selectedYear = DateTime.Today.Year;
			}

			GetMaterialDeliveryMonth(MaterialCategory, _selectedYear);
		}

		private void cbxMonth_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_selectedMonth = Convert.ToInt32(cbxMonth.SelectedValue);
			}
			catch
			{
				_selectedMonth = DateTime.Today.Month;
			}

			ShowAllDelivery(MaterialCategory, _selectedYear, _selectedMonth);
		}

		private void dgvIssue_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedCustomerCode = dgvIssue["CODE", e.RowIndex].Value.ToString();

			ShowCustomerReturnMaterial(_selectedCustomerCode, MaterialCategory, _selectedYear, _selectedMonth);

			if (_selectedCustomerCode != "")
			{
				lbSelectedCustomer.Text = dgvIssue["Customer", e.RowIndex].Value.ToString();
				GetSummaryBySelectedCustomer((DataTable)dgvIssue.DataSource, _selectedCustomerCode);
			}
			else
			{
				lbSelectedCustomer.Text = "";
				lbTotalDeliveryForSelectedCustomer.Text = "";
				lbTotalSIForSelectedCustomer.Text = "";
			}
		}

		#region class field member

		private string _selectedCustomerCode = string.Empty;
		private int _selectedYear = DateTime.Today.Year;
		private int _selectedMonth = DateTime.Today.Month;

		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetMaterialDeliveryYear(string Category)
		{
			cbxYear.DataSource = new ReturnMaterialDAL().GetMaterialDeliveryYear(Category);
			cbxYear.DisplayMember = "Y";
			cbxYear.ValueMember = "Y";
		} // end GetMaterialDeliveryYear

		private void GetMaterialDeliveryMonth(string Category, int YearReceice)
		{
			cbxMonth.DataSource = new ReturnMaterialDAL().GetMaterialDeliveryMonth(Category, YearReceice);
			cbxMonth.DisplayMember = "Mname";
			cbxMonth.ValueMember = "M";
		} // end GetMaterialDeliveryMonth


		private async void ShowAllDelivery(string MaterCategory, int YearDelivery, int MonthDelivery)
		{
			var _dal = new ReturnMaterialDAL();
			var _dt = await _dal.GetAsyncTotalDeliveryCasting(MaterCategory, YearDelivery, MonthDelivery);

			dgvIssue.SuspendLayout();
			dgvIssue.DataSource = _dt;

			// calculate for delivery
			GetDeliverySummary(_dt);

			foreach (DataGridViewColumn dgc in dgvIssue.Columns)
			{
				if (dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
			}

			dgvIssue.Columns["CODE"].Visible = false;
			dgvIssue.ResumeLayout();

		} // end ShowAllDelivery

		private async void ShowCustomerReturnMaterial(string CustomerCode, string MaterialCategory, int YearReturn,
			int MonthReturn)
		{
			var _dal = new ReturnMaterialDAL();
			var _dt = await _dal.GetAsyncCustomerReturnMaterial(CustomerCode, MaterialCategory, YearReturn, MonthReturn);

			// calculate for return 
			GetReturnSummary(_dt);

			dgvReturn.SuspendLayout();
			dgvReturn.DataSource = _dt;
			foreach (DataGridViewColumn dgc in dgvReturn.Columns)
			{
				if (dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
			}

			dgvReturn.Columns["CUSTCODE"].Visible = false;
			dgvReturn.Columns["CUSTOMER"].Visible = false;
			dgvReturn.Columns["GRVDATE"].HeaderText = "Date";

			dgvReturn.ResumeLayout();
		} // end ShowCustomerReturnMaterial

		private void GetDeliverySummary(DataTable SourceData)
		{
			var _totalDelivery = SourceData.AsEnumerable()
					.Where(v => v.Field<string>("Customer") != "Total Delivery Weight")
					.Sum(x => x.Field<decimal>("DeliveryQty"));

			var _totalSI = SourceData.AsEnumerable()
					.Where(v => v.Field<string>("Customer") != "Total Delivery Weight")
					.Sum(x => x.Field<decimal>("SI"));

			lbTotalDelivery.Text = $"ยืม (ส่ง) ทั้งหมด = {_totalDelivery:N2} กรัม";
			lbSI.Text = $"SI ทั้งหมด = {_totalSI:N2} กรัม";
		} // end GetDeliverySummary


		private void GetSummaryBySelectedCustomer(DataTable Source, string CustomerCode)
		{
			var _totalDeliveryByCustomer = Source.AsEnumerable()
					.Where(x => x.Field<string>("Code") == CustomerCode
					&& x.Field<string>("Customer") != "Total Delivery Weight")
					.Sum(s => s.Field<decimal>("DeliveryQty"));

			var _totalSIByCustomer = Source.AsEnumerable()
					.Where(x => x.Field<string>("Code") == CustomerCode
					&& x.Field<string>("Customer") != "Total Delivery Weight")
					.Sum(s => s.Field<decimal>("SI"));

			lbTotalDeliveryForSelectedCustomer.Text = $"ยืม (ส่ง) ทั้งหมด = {_totalDeliveryByCustomer:N2} กรัม";
			lbTotalSIForSelectedCustomer.Text = $"SI ทั้งหมด = {_totalSIByCustomer:N2} กรัม";

		} // end GetSummaryBySelectedCustomer


		private void GetReturnSummary(DataTable SourceData)
		{
			var _totalReturn = SourceData.AsEnumerable()
					.Where(v => v.Field<string>("grvdate") != "Total Weight")
					.Sum(x => x.Field<decimal>("TotalBalance"));

			var _totalRemain = SourceData.AsEnumerable()
					.Where(v => v.Field<string>("grvdate") != "Total Weight")
					.Sum(x => x.Field<decimal>("Total"));

			lbBalance.Text = $"คงเหลือ = {_totalReturn:N2} กรัม";
			lbTotalReturn.Text = $"คงเหลือ = {_totalRemain:N2} กรัม";

		} // end GetReturnSummary

		#endregion

		
	}
}