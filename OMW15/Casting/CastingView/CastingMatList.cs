using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;

namespace OMW15.Casting.CastingView
{
	public partial class CastingMatList : Form
	{
		#region class field member
		private ActionMode _mode = ActionMode.View;
		private string _selectedCategory = string.Empty;
		private int _selectedMatRecordId = 0;

		#endregion

		#region class property
		public ActionMode Mode
		{
			get;
			set;
		}

		public int MatId
		{
			get;
			set;
		}

		public string MatName
		{
			get;
			set;
		}

		public decimal  ConvertFactor
		{
			get;
			set;
		}

		public decimal MatFactor
		{
			get;
			set;
		}

		public decimal FlaskTemp
		{
			get;
			set;
		}

		public decimal CastingTemp
		{
			get;
			set;
		}

		public string MatGroup
		{
			get;
			set;
		}

		#endregion

		#region class method

		private void UpdateUI()
		{
			this.tsbtnAdd.Visible = (_mode != ActionMode.Selection);
			this.tsSep1.Visible = this.tsbtnAdd.Visible;
			this.tsbtnEdit.Visible = this.tsbtnAdd.Visible;
			this.tsSep2.Visible = this.tsbtnAdd.Visible;
			this.tsbtnClose.Visible = this.tsbtnAdd.Visible;
			this.tsSep3.Visible = this.tsbtnAdd.Visible;
			this.btnSelect.Visible = !this.tsbtnAdd.Visible;
			this.btnClose.Visible = this.btnSelect.Visible;

			this.tsbtnEdit.Enabled = (_selectedMatRecordId > 0);

		} // end UpdateUI

		private void GetMaterialCategory()
		{
			DataTable _dt = new Casting.CastingController.MaterialDAL().GetMaterialCategory();
			_dt.DefaultView.Sort = "CATEGORY";
			this.tscbxMatCategory.ComboBox.DataSource = _dt;
			this.tscbxMatCategory.ComboBox.DisplayMember = "CATEGORY";
			this.tscbxMatCategory.ComboBox.ValueMember = "CATEGORY";

		} // end GetMaterialCategory

		private void GetMaterialListByCategory(string Category)
		{
			DataTable _dt = new Casting.CastingController.MaterialDAL().GetCastingMaterial(Category);
			_dt.DefaultView.Sort = "MATERIALNAME";

			this.dgv.SuspendLayout();
			this.dgv.DataSource = _dt;

			// formatting DataGridView
			this.dgv.Columns["LINESEQ"].Visible = false;
			this.dgv.Columns["ENKEYNAME"].Visible = false;
			this.dgv.Columns["KEYVALUE"].HeaderText = "KEY";
			this.dgv.Columns["MATERIALNAME"].HeaderText = "Material Name";
			this.dgv.Columns["MATFACTOR"].HeaderText = "Factor";
			this.dgv.Columns["FURNACETEMP"].HeaderText = "Furnace (C)";
			this.dgv.Columns["CASTINGTEMP"].HeaderText = "Casting (C)";

			this.dgv.Columns["KEYVALUE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			this.dgv.Columns["MATERIALNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

			this.dgv.Columns["MATFACTOR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
			this.dgv.Columns["FURNACETEMP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
			this.dgv.Columns["CASTINGTEMP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

			this.dgv.Columns["MATFACTOR"].DefaultCellStyle.Format = "N4";
			this.dgv.Columns["FURNACETEMP"].DefaultCellStyle.Format = "N0";
			this.dgv.Columns["CASTINGTEMP"].DefaultCellStyle.Format = "N0";

			this.dgv.ResumeLayout();

			this.UpdateUI();

		} // end 

		private void AddEditMaterial(string MaterialCategory, int MaterialRecordId)
		{
			Casting.CastingView.CastingMaterialInfo _cmi = new CastingMaterialInfo();
			_cmi.MaterialRecordId = _selectedMatRecordId;
			_cmi.Category = _selectedCategory;
			_cmi.StartPosition = FormStartPosition.CenterScreen;
			if (_cmi.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				this.tsbtnRefresh.PerformClick();
			}
		} // end 

		#endregion

		public CastingMatList(ActionMode Mode = ActionMode.Recording)
		{
			InitializeComponent();
			_mode = Mode;
		}

		private void CastingMatList_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.GetMaterialCategory();
			this.UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.GetMaterialListByCategory(_selectedCategory);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tscbxMatCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tscbxMatCategory.ComboBox.SelectedValue.GetType() == typeof(System.String))
			{
				_selectedCategory = this.tscbxMatCategory.ComboBox.SelectedValue.ToString();
			}
			else
			{
				_selectedCategory = string.Empty;
			}

			// debug display selected material category
			// this.lbCAT.Text = _selectedCategory;
			this.MatGroup = _selectedCategory;

			// loading material list
			this.tsbtnRefresh.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			// get material record id
			_selectedMatRecordId = Convert.ToInt32(this.dgv["LINESEQ", e.RowIndex].Value);

			this.FlaskTemp = Convert.ToDecimal(this.dgv["FURNACETEMP", e.RowIndex].Value);
			this.CastingTemp = Convert.ToDecimal(this.dgv["CASTINGTEMP", e.RowIndex].Value);
			this.MatFactor = Convert.ToDecimal(this.dgv["MATFACTOR", e.RowIndex].Value);
			this.ConvertFactor = Convert.ToDecimal(this.dgv["CONVERTFACTOR", e.RowIndex].Value);

			this.MatName = this.dgv["ENKEYNAME", e.RowIndex].Value.ToString();
			this.MatId = Convert.ToInt32(this.dgv["KEYVALUE", e.RowIndex].Value);

			this.lbCAT.Text = string.Format("line index :: {0}", _selectedMatRecordId);
			
			// call update UI
			this.UpdateUI();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedMatRecordId = 0;
			this.AddEditMaterial(_selectedCategory, _selectedMatRecordId);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			this.AddEditMaterial(_selectedCategory, _selectedMatRecordId);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.tsbtnEdit.PerformClick();
		}
	}
}
