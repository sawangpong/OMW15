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
	public partial class CastingLoss : Form
	{
		#region class field member

		private string _matCatName = string.Empty;
		private int _selecedFiscYear = DateTime.Today.Year;

		#endregion
		#region class helper

		private void UpdateUI()
		{
		}

		//private void GetMaterialCategory()
		//{
		//	DataTable _dt = new Casting.CastingController.MaterialDAL().GetMaterialCategory();
		//	_dt.DefaultView.Sort = "CATEGORY";
		//	this.tscbxMatCategory.ComboBox.DataSource = _dt;
		//	this.tscbxMatCategory.ComboBox.DisplayMember = "CATEGORY";
		//	this.tscbxMatCategory.ComboBox.ValueMember = "CATEGORY";
		//} // end GetMaterialCategory
		
		private void GetYearList()
		{
			this.tscbxFiscYear.ComboBox.DataSource = new Casting.CastingController.CastingTreeController().GetYearCastingWaxTree();
			this.tscbxFiscYear.ComboBox.DisplayMember = "FY";
			this.tscbxFiscYear.ComboBox.ValueMember = "FY";
			
		} // end GetYearList

		private void ShowLossData(int Fiscyear)
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = new Casting.CastingController.CastingTreeController().GetYearSummaryLossCasting(Fiscyear);

			foreach (DataGridViewColumn dgc in this.dgv.Columns)
			{
				if (dgc.ValueType == typeof(System.Decimal))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = "P2";
				}
			}

			this.dgv.ResumeLayout();
		
		} // end ShowLossData


		#endregion


		public CastingLoss()
		{
			InitializeComponent();
		}

		private void CastingLoss_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			//this.GetMaterialCategory();
			this.GetYearList();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tscbxFiscYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selecedFiscYear = Convert.ToInt32(this.tscbxFiscYear.ComboBox.SelectedValue);
			}
			catch
			{
				_selecedFiscYear = DateTime.Today.Year;
			}
		
			this.ShowLossData(_selecedFiscYear);
		}

		//private void tscbxMatCategory_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//	try
		//	{
		//		_matCatName = this.tscbxMatCategory.ComboBox.SelectedValue.ToString();
		//	}
		//	catch
		//	{
		//		_matCatName = "SILVER";
		//	}
		//	this.ShowLossData(_matCatName, _selecedFiscYear);
		//}

	
	}
}
