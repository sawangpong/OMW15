using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;

namespace OMW15.Tools
{
	public partial class SelectBox : Form
	{
		#region class field member

		private SelectTypeOption _selectOption = SelectTypeOption.None;
		private string _selectedName = string.Empty;
		private string _selectedCode = string.Empty;
		private int _selectedId = 0;
		private int _filterId = 0;

		#endregion

		#region class property

		public SelectTypeOption SelectOption
		{
			set
			{
				_selectOption = value;
			}
		}

		public int FilterId
		{
			set
			{
				_filterId = value;
			}
		}

		public string SelectedName
		{
			get
			{
				return _selectedName;
			}
		}

		public string SelectedCode
		{
			get
			{
				return _selectedCode;
			}
		}

		public int SelectedId
		{
			get
			{
				return _selectedId;
			}

		}
		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.btnSearch.Visible = (this.lst.Items.Count > 20);

		} // end UpdateUI

		private void SetTitle(SelectTypeOption Option)
		{
			switch (Option)
			{
				case SelectTypeOption.Customer:
					this.lbTitle.Text = "รายชื่อลูกค้า";
					break;
				case SelectTypeOption.Currency:
					this.lbTitle.Text = "สกุลเงิน";
					break;
				case SelectTypeOption.Department:
					this.lbTitle.Text = "แผนกงาน";
					break;
				case SelectTypeOption.District:
					this.lbTitle.Text = "อำเภอ";
					break;
				case SelectTypeOption.Province:
					this.lbTitle.Text = "จังหวัด";
					break;
				case SelectTypeOption.Country:
					this.lbTitle.Text = "ประเทศ";
					break;
				case SelectTypeOption.ItemNo:
					this.lbTitle.Text = "รหัสสินค้า";
					break;
				case SelectTypeOption.Material:
					this.lbTitle.Text = "วัสดุ";
					break;
				case SelectTypeOption.SaleMan:
					this.lbTitle.Text = "พนักงานขาย";
					break;
				case SelectTypeOption.SaleType:
					this.lbTitle.Text = "ประเภทงานขาย";
					break;
				case SelectTypeOption.VatRate:
					this.lbTitle.Text = "อัตราภาษีมูลค่าเพิ่ม";
					break;
				case SelectTypeOption.CastingCode:
					this.lbTitle.Text = "ประเภทงาน";
					break;
				case SelectTypeOption.Worker:
					this.lbTitle.Text = "พนักงาน";
					break;
				case SelectTypeOption.Worker2:
					this.lbTitle.Text = "พนักงาน - ID";
					break;
				case SelectTypeOption.UnitCount:
					this.lbTitle.Text = "หน่วยนับ";
					break;
				case SelectTypeOption.Sex:
					this.lbTitle.Text = "เพศ";
					break;
				case SelectTypeOption.ProductStyle:
					this.lbTitle.Text = "รูปแบบงาน";
					break;
				case SelectTypeOption.FamilyStatus:
					this.lbTitle.Text = "สถานะครอบครัว";
					break;
			}

		} // end SetTitle

		private void GetData(SelectTypeOption Option)
		{
			this.GetData(Option, 0);

		} // end GetData

		private void GetData(SelectTypeOption Option,int FilterId)
		{
			this.lst.DataSource = Tools.SelectOptions.GetDataByOption(Option, FilterId);
			this.lst.DisplayMember = "value";
			this.lst.ValueMember = "key";
			this.lst.SetSelected(0, true);
		} // end GetData

		#endregion

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
			this.SetTitle(_selectOption);
			this.GetData(_selectOption,_filterId);
			this.UpdateUI();
		}

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedName = this.lst.Text;
				if (this.lst.SelectedValue.GetType() == typeof(System.String))
				{
					_selectedCode = this.lst.SelectedValue.ToString();
				}
				else if (this.lst.SelectedValue.GetType() == typeof(System.Int32))
				{
					_selectedId = Convert.ToInt32(this.lst.SelectedValue);
				}
			}
			catch(IndexOutOfRangeException ex)
			{
				_selectedId = 0;
				_selectedCode = string.Empty;
				_selectedName = string.Empty;

				throw new Exception("Error selected item in listbox", ex);
			}

			// debug
			this.lbSelected.Text = string.Format("id:{0} code:{1}",_selectedId,_selectedCode);
			// end
		}

		private void lst_DoubleClick(object sender, EventArgs e)
		{
			this.btnSelect.PerformClick();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			string _title = "Select....";
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
				case SelectTypeOption.Worker:
					_title = "Worker Name";
					break;
				case SelectTypeOption.Worker2:
					_title = "Worker Name (ID)";
					break;
				case SelectTypeOption.District:
					_title ="District Name";
					break;
	
			}

			// search by string input for customer name
			(this.lst.DataSource as DataTable).DefaultView.RowFilter = string.Format(
				"[{0}] LIKE '%{1}%'", "value", OMControls.OMDataUtils.GetFilter<string>(_title));
			this.lst.SetSelected(0, true);

		}
	}
}
