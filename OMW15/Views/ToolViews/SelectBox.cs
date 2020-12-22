using System;
using System.Data;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ToolModel;
using OMW15.Shared;

namespace OMW15.Views.ToolViews
{
	public partial class SelectBox : Form
	{
		public SelectBox()
		{
			InitializeComponent();
		}

		public SelectBox(SelectTypeOption Option)
		{
			_selectOption = Option;
		}

		private void SelectBox_Load(object sender, EventArgs e)
		{
			SetTitle(_selectOption);
			GetData(_selectOption, _filterId);
			UpdateUI();
		}

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				// select name 
				SelectedName = lst.Text;

				// check type of the value member
				// if int -> select to Id
				// if string -> select to Code
				if (lst.SelectedValue.GetType() == typeof(string)) SelectedCode = lst.SelectedValue.ToString();
				else if (lst.SelectedValue.GetType() == typeof(int)) SelectedId = Convert.ToInt32(lst.SelectedValue);
			}
			catch (IndexOutOfRangeException ex)
			{
				SelectedId = 0;
				SelectedCode = string.Empty;
				SelectedName = string.Empty;

				throw new Exception("Error selected item in ListBox", ex);
			}
		}

		private void lst_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			var _title = "Select....";
			switch (_selectOption)
			{
				case SelectTypeOption.Country:
					_title = "Country Name";
					break;
				case SelectTypeOption.Customer:
					_title = "Customer Name";
					break;
				case SelectTypeOption.Material:
					_title = "Material Name";
					break;
				case SelectTypeOption.UnitCount:
					_title = "Unit Name";
					break;
				case SelectTypeOption.WorkerByCode:
					_title = "Worker Name";
					break;
				case SelectTypeOption.WorkerById:
					_title = "Worker Name (ID)";
					break;
				case SelectTypeOption.District:
					_title = "District Name";
					break;
				case SelectTypeOption.ProductionProcess:
					_title = "Production Process";
					break;
			}

			// search by string input for customer name
			//(lst.DataSource as DataTable).DefaultView.RowFilter = string.Format(
			//	"[{0}] LIKE '%{1}%'", "value", OMDataUtils.GetFilter<string>(_title));

			(lst.DataSource as DataTable).DefaultView.RowFilter = $"[{"value"}] LIKE '%{OMDataUtils.GetFilter<string>(_title)}%'";


			lst.SetSelected(0, true);
		}

		#region class field member

		private SelectTypeOption _selectOption = SelectTypeOption.None;
		private int _filterId;

		#endregion

		#region class property

		public SelectTypeOption SelectOption
		{
			set { _selectOption = value; }
		}

		public int FilterId
		{
			set { _filterId = value; }
		}

		public string SelectedName { get; private set; } = string.Empty;

		public string SelectedCode { get; private set; } = string.Empty;

		public int SelectedId { get; private set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnSearch.Visible = lst.Items.Count > 20;
		} // end UpdateUI

		private void SetTitle(SelectTypeOption Option)
		{
			switch (Option)
			{
				case SelectTypeOption.Customer:
					lbTitle.Text = "รายชื่อลูกค้า";
					break;
				case SelectTypeOption.Currency:
					lbTitle.Text = "สกุลเงิน";
					break;
				case SelectTypeOption.Department:
					lbTitle.Text = "แผนกงาน";
					break;
				case SelectTypeOption.District:
					lbTitle.Text = "อำเภอ";
					break;
				case SelectTypeOption.Province:
					lbTitle.Text = "จังหวัด";
					break;
				case SelectTypeOption.Country:
					lbTitle.Text = "ประเทศ";
					break;
				case SelectTypeOption.ItemNo:
					lbTitle.Text = "รหัสสินค้า";
					break;
				case SelectTypeOption.Material:
					lbTitle.Text = "วัสดุ";
					break;
				case SelectTypeOption.SaleMan:
					lbTitle.Text = "พนักงานขาย";
					break;
				case SelectTypeOption.SaleType:
					lbTitle.Text = "ประเภทงานขาย";
					break;
				case SelectTypeOption.VatRate:
					lbTitle.Text = "อัตราภาษีมูลค่าเพิ่ม";
					break;
				case SelectTypeOption.CastingCode:
					lbTitle.Text = "ประเภทงาน";
					break;
				case SelectTypeOption.WorkerByCode:
					lbTitle.Text = "พนักงาน";
					break;
				case SelectTypeOption.WorkerById:
					lbTitle.Text = "พนักงาน - ID";
					break;
				case SelectTypeOption.UnitCount:
					lbTitle.Text = "หน่วยนับ";
					break;
				case SelectTypeOption.Sex:
					lbTitle.Text = "เพศ";
					break;
				case SelectTypeOption.ProductStyle:
					lbTitle.Text = "รูปแบบงาน";
					break;
				case SelectTypeOption.FamilyStatus:
					lbTitle.Text = "สถานะครอบครัว";
					break;
				case SelectTypeOption.ProductionProcess:
					lbTitle.Text = "กระบวนการทำงาน";
					break;
			}
		} // end SetTitle

		private void GetData(SelectTypeOption Option)
		{
			GetData(Option, 0);
		} // end GetData

		private void GetData(SelectTypeOption Option, int FilterId)
		{
			lst.DataSource = new SelectOptions().GetDataByOption(Option, FilterId);
			lst.DisplayMember = "value";
			lst.ValueMember = "key";
			lst.SetSelected(0, true);
		} // end GetData

		#endregion
	}
}