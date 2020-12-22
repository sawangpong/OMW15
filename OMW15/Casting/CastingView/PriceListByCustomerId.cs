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

namespace OMW15.Casting.CastingView
{
	public partial class PriceListByCustomerId : Form
	{
		#region class field member

		private decimal _selectedCastingUnitPrice = 0.00m;
		private decimal _selectedUnitPrice = 0.00m;
		private decimal _selectedItemScore = 0.00m;
		private int _customerId = 0;
		private int _selectedItemId = 0;
		private int _selectedItemStyleId = 0;
		private int _selectedItemMaterial = 0;
		private string _customerCode = string.Empty;
		private string _customerName = string.Empty;
		private string _selectedItemCategoryName = string.Empty;
		private string _selectedItemPrefix = string.Empty;
		private string _selectedItemNo = string.Empty;
		private string _selectedItemName = string.Empty;
		private string _selectedItemUnit = string.Empty;
		private string _selectedItemMaterialName = string.Empty;
		private string _selectedItemStyleName = string.Empty;
		private string _title = "Select ? -->";

		#endregion

		#region class property
		
		//
		// =================================================================
		// ========================= SET PROPERTY
		public int CustomerId
		{
			set
			{
				_customerId = value;
			}
		}		
		
		public string CustomerCode
		{
			set
			{
				_customerCode = value;
			}
		}

		public string CustomerName
		{
			set
			{
				_customerName = value;
			}
		}

		public string Title
		{
			set
			{
				_title = value;
			}
		}

		//
		// =================================================================
		// ========================= GET PROPERTY
		public int ItemMaterial
		{
			get
			{
				return _selectedItemMaterial;
			}
		}

		public string ItemMaterialName
		{
			get
			{
				return _selectedItemMaterialName;
			}
		}
		public int ItemStyle
		{
			get
			{
				return _selectedItemStyleId;
			}
		}

		public string ItemStyleName
		{
			get
			{
				return _selectedItemStyleName;
			}
		}

		public int ItemId
		{
			get
			{
				return _selectedItemId;
			}
		}		
		
		public string ItemPrefix
		{
			get
			{
				return _selectedItemPrefix;
			}
		}

		public string ItemCategory
		{
			get
			{
				return _selectedItemCategoryName;
			}
		}
		
		public string ItemNo
		{
			get
			{
				return _selectedItemNo;
			}
		}

		public string ItemName
		{
			get
			{
				return _selectedItemName;
			}
		}

		public string Unit
		{
			get
			{
				return _selectedItemUnit;
			}
		}

		public decimal CastingUnitPrice
		{
			get
			{
				return _selectedCastingUnitPrice;
			}
		}

		public decimal UnitPrice
		{
			get
			{
				return _selectedUnitPrice;
			}
		}

		public decimal ItemScore
		{
			get
			{
				return _selectedItemScore;
			}
		}


		#endregion


		#region class helper

		private void UpdateUI()
		{
			this.btnSelect.Enabled = (this.dgv.Rows.Count > 1);
			this.btnSearch.Visible = (this.dgv.Rows.Count >= 20);

		} // end UpdateUI


		private DataTable GetPriceListItemData(string CustomerCode)
		{
			return new OMW15.Casting.CastingController.PriceListDAL().GetPriceListByCustomer(CustomerCode);

		} // end GetPriceListItemData


		private void GetData(string CustomerCode)
		{
			// update control
			this.dgv.SuspendLayout();

			// binding data
			this.dgv.DataSource = this.GetPriceListItemData(CustomerCode);

			// formatting DataGridView
			this.dgv.Columns["ID"].Visible = false;
			this.dgv.Columns["CUSTOMERCODE"].Visible = false;
			this.dgv.Columns["MATERIALID"].Visible = false;
			this.dgv.Columns["STYLEID"].Visible = false;
			this.dgv.Columns["SCORE"].Visible = false;
			this.dgv.Columns["HASIMAGE"].Visible = false;
			this.dgv.Columns["WEIGHT"].Visible = false;

			this.dgv.Columns["UNIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dgv.Columns["MATERIAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dgv.Columns["STYLE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			this.dgv.Columns["CASTINGPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["CASTINGPRICE"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["UNITPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["UNITPRICE"].DefaultCellStyle.Format = "N2";
			
			
			//
			this.dgv.ResumeLayout();

			// update-UI
			this.UpdateUI();

		} // end GetData

		#endregion


		public PriceListByCustomerId()
		{
			InitializeComponent();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			// search by string input for customer name
			(this.dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(
				"[{0}] LIKE '%{1}%'", "ItemNo", OMControls.OMDataUtils.GetFilter<string>("Select Item-No."));
		}

		private void PriceListByCustomerId_Load(object sender, EventArgs e)
		{
			// setting DataGridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			
			// display header
			this.lbCustomer.Text = string.Format("({0})-[{1}] :: {2}",_customerId,_customerCode,_customerName);
			this.lbTitle.Text = _title;

			// loading Data by sending parameter - _customerCode (string)
			this.GetData(_customerCode);

			// update-UI
			this.UpdateUI();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				_selectedItemId           = Convert.ToInt32(this.dgv["ID", e.RowIndex].Value);
				_selectedItemPrefix       = this.dgv["ITEMCODE", e.RowIndex].Value.ToString();
				_selectedItemCategoryName = this.dgv["ITEMTYPE", e.RowIndex].Value.ToString();
				_selectedItemNo           = this.dgv["ITEMNO", e.RowIndex].Value.ToString();
				_selectedItemName         = this.dgv["ITEMNAME", e.RowIndex].Value.ToString();
				_selectedItemUnit = this.dgv["UNIT", e.RowIndex].Value.ToString();
				_selectedItemScore        = Convert.ToDecimal(this.dgv["SCORE", e.RowIndex].Value);
				_selectedItemMaterial     = Convert.ToInt32(this.dgv["MATERIALID", e.RowIndex].Value);
				_selectedItemMaterialName = this.dgv["MATERIAL", e.RowIndex].Value.ToString();
				_selectedItemStyleId      = Convert.ToInt32(this.dgv["STYLEID", e.RowIndex].Value);
				_selectedItemStyleName = this.dgv["STYLE", e.RowIndex].Value.ToString();
				_selectedCastingUnitPrice = Convert.ToDecimal(this.dgv["CASTINGPRICE", e.RowIndex].Value);
				_selectedUnitPrice        = Convert.ToDecimal(this.dgv["UNITPRICE", e.RowIndex].Value);
			}
			catch
			{
				_selectedUnitPrice        = 0.00m;
				_selectedItemUnit         = string.Empty;
				_selectedItemStyleId      = 0;
				_selectedItemScore        = 0.00m;
				_selectedItemPrefix       = string.Empty;
				_selectedItemNo           = string.Empty;
				_selectedItemName         = string.Empty;
				_selectedItemMaterial     = 0;
				_selectedItemId           = 0;
				_selectedCastingUnitPrice = 0.00m;
			}
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.btnSelect.PerformClick();
		}
	}
}
