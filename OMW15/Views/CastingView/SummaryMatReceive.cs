using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView
{
	public partial class SummaryMatReceive : Form
	{
		// CONSTRUCTOR
		public SummaryMatReceive(string CustCode = "")
		{
			InitializeComponent();

			if (CustCode != "") CustomerCode = CustCode;
		}

		#region class property

		public string CustomerCode { get; set; }

		#endregion

		private void SummaryMatReceive_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);
			GetMaterialCategory(CustomerCode);
		}

		private void cbxMaterialCAT_SelectionChangeCommitted(object sender, EventArgs e)
		{
		}

		private void cbxYear_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_selectedYearReceiveMaterial = Convert.ToInt32(cbxYear.SelectedValue);
			}
			catch
			{
				_selectedYearReceiveMaterial = DateTime.Today.Year;
			}

			if (_selectedMaterialCategory != "")
				GetMaterialReceiveMonth(_selectedMaterialCategory, _selectedYearReceiveMaterial);
			UpdateUI();
		}

		private void cbxMonth_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				_selectedMonthReceiveMaterial = Convert.ToInt32(cbxMonth.SelectedValue);
			}
			catch
			{
				_selectedMonthReceiveMaterial = DateTime.Today.Month;
			}

			UpdateUI();
		}

		private void btnShowData_Click(object sender, EventArgs e)
		{
			DisplayMaterialRecive(CustomerCode, _selectedMaterialCategory, _selectedYearReceiveMaterial,
				_selectedMonthReceiveMaterial);
		}

		private void cbxMaterialCAT_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedMaterialCategory = cbxMaterialCAT.SelectedValue.ToString();
			}
			catch
			{
				_selectedMaterialCategory = string.Empty;
			}

			if (_selectedMaterialCategory != "") GetMaterialReceiveYear(_selectedMaterialCategory);
			UpdateUI();
		}

		#region class field member

		private string _selectedMaterialCategory = string.Empty;
		private int _selectedYearReceiveMaterial = DateTime.Today.Year;
		private int _selectedMonthReceiveMaterial = DateTime.Today.Month;

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnShowData.Enabled = !string.IsNullOrEmpty(_selectedMaterialCategory);
		} // end UpdateUI


		private void GetMaterialCategory(string CustomerCode)
		{
			cbxMaterialCAT.DataSource = new ReturnMaterialDAL().GetMaterialCategory(CustomerCode);
			cbxMaterialCAT.DisplayMember = "CATEGORY";
			cbxMaterialCAT.ValueMember = "CATEGORY";
		} // end GetMaterialCategory

		private void GetMaterialReceiveYear(string Category)
		{
			cbxYear.DataSource = new ReturnMaterialDAL().GetMaterialReciveYear(Category);
			cbxYear.DisplayMember = "Y";
			cbxYear.ValueMember = "Y";
		} // end GetMaterialReceiveYear

		private void GetMaterialReceiveMonth(string Category, int YearReceice)
		{
			cbxMonth.DataSource = new ReturnMaterialDAL().GetMaterialReciveMonth(Category, YearReceice);
			cbxMonth.DisplayMember = "Mname";
			cbxMonth.ValueMember = "M";
		} // end GetMaterialReceiveMonth

		private async void DisplayMaterialRecive(string CustomerCode, string Category, int YearReceive, int MonthReceive)
		{
			var _dal = new ReturnMaterialDAL();
			var dt = await _dal.GetAsyncCustomerReturnMaterial(CustomerCode, Category, YearReceive, MonthReceive);

			dgv.SuspendLayout();
			dgv.DataSource = dt;

			//this.FormattingDataGridViewColumnAndRow();
			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.ValueType == typeof(decimal)) dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			dgv.Columns["Total"].Frozen = true;
			dgv.ResumeLayout();
		} // end DisplayMaterialRecive

		#endregion
	}
}