using OMControls;
using OMW15.Models.CastingModel;
using OMW15.Shared;
using System;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingMatList : Form
	{

		//#region Singelton
		//private static CastingMatList _instance;
		//public static CastingMatList GetInstance
		//{
		//	get
		//	{
	//			if (_instance == null || _instance.IsDisposed)
		//		{
		//			_instance = new CastingMatList();
		//		}
		//		return _instance;
		//	}
		//}
		//#endregion

		public CastingMatList(ActionMode Mode = ActionMode.Recording)
		{
			InitializeComponent();
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);
			_mode = Mode;
		}

		private void CastingMatList_Load(object sender, EventArgs e)
		{
			GetMaterialCategory();
			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetMaterialListByCategory(_selectedCategory);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tscbxMatCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tscbxMatCategory.ComboBox.SelectedValue.GetType() == typeof(string))
				_selectedCategory = tscbxMatCategory.ComboBox.SelectedValue.ToString();
			else _selectedCategory = string.Empty;

			// debug display selected material category
			MatGroup = _selectedCategory;

			// loading material list
			tsbtnRefresh.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			// get material record id

			_selectedMatRecordId = Convert.ToInt32(dgv["LINESEQ", e.RowIndex].Value);
			FlaskTemp = Convert.ToDecimal(dgv["FURNACETEMP", e.RowIndex].Value);
			CastingTemp = Convert.ToDecimal(dgv["CASTINGTEMP", e.RowIndex].Value);
			MatFactor = Convert.ToDecimal(dgv["MATFACTOR", e.RowIndex].Value);
			ConvertFactor = Convert.ToDecimal(dgv["CONVERTFACTOR", e.RowIndex].Value);
			MatName = dgv["THKEYNAME", e.RowIndex].Value.ToString();
			MatId = Convert.ToInt32(dgv["KEYVALUE", e.RowIndex].Value);
			lbCAT.Text = $"Index :: [{_selectedMatRecordId}]  KEY-ID :: [{MatId}]";

			// call update UI
			UpdateUI();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedMatRecordId = 0;
			AddEditMaterial(_selectedCategory, _selectedMatRecordId);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			AddEditMaterial(_selectedCategory, _selectedMatRecordId);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		#region class field member

		private readonly ActionMode _mode = ActionMode.View;
		private string _selectedCategory = string.Empty;
		private int _selectedMatRecordId;

		#endregion

		#region class property

		public ActionMode Mode { get; set; }

		public int MatId { get; set; }

		public string MatName { get; set; }

		public decimal ConvertFactor { get; set; }

		public decimal MatFactor { get; set; }

		public decimal FlaskTemp { get; set; }

		public decimal CastingTemp { get; set; }

		public string MatGroup { get; set; }

		#endregion

		#region class method

		private void UpdateUI()
		{
			tsbtnAdd.Visible = _mode != ActionMode.Selection;
			tsSep1.Visible = tsbtnAdd.Visible;
			tsbtnEdit.Visible = tsbtnAdd.Visible;
			tsSep2.Visible = tsbtnAdd.Visible;
			tsbtnClose.Visible = tsbtnAdd.Visible;
			tsSep3.Visible = tsbtnAdd.Visible;
			btnSelect.Visible = !tsbtnAdd.Visible;
			btnClose.Visible = btnSelect.Visible;
			tsbtnEdit.Enabled = _selectedMatRecordId > 0;
		} // end UpdateUI

		private void GetMaterialCategory()
		{
			var _dt = new MaterialDAL().GetMaterialCategory();
			_dt.DefaultView.Sort = "CATEGORY";
			tscbxMatCategory.ComboBox.DataSource = _dt;
			tscbxMatCategory.ComboBox.DisplayMember = "CATEGORY";
			tscbxMatCategory.ComboBox.ValueMember = "CATEGORY";

			tscbxMatCategory.ComboBox.SelectedIndex = 0;

		} // end GetMaterialCategory

		private void GetMaterialListByCategory(string Category)
		{
			var _dt = new MaterialDAL().GetCastingMaterial(Category);
			_dt.DefaultView.Sort = "MATERIALNAME";

			dgv.SuspendLayout();
			dgv.DataSource = _dt;

			// formatting DataGridView
			dgv.Columns["LINESEQ"].Visible = false;
			dgv.Columns["THKEYNAME"].Visible = false;

			dgv.Columns["INUSED"].HeaderText = "ใช้งาน";
			//dgv.Columns["INUSED"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dgv.Columns["INUSED"].Width = 80;

			dgv.Columns["KEYVALUE"].Visible = false;
			dgv.Columns["KEYVALUE"].HeaderText = "KEY";
			dgv.Columns["CONVERTFACTOR"].HeaderText = "ตัวคูณ โลหะ";
			dgv.Columns["MATERIALNAME"].HeaderText = "ชื่อวัสดุ";
			dgv.Columns["MATFACTOR"].HeaderText = "ตัวคูณ น.น. เทียน";
			dgv.Columns["FURNACETEMP"].HeaderText = "อุณหภูมิเตา (C)";
			dgv.Columns["CASTINGTEMP"].HeaderText = "อุณหภูมิหล่อ (C)";

			dgv.Columns["KEYVALUE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dgv.Columns["MATERIALNAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

			dgv.Columns["INUSED"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
			dgv.Columns["CONVERTFACTOR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
			dgv.Columns["MATFACTOR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
			dgv.Columns["FURNACETEMP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
			dgv.Columns["CASTINGTEMP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

			dgv.Columns["CONVERTFACTOR"].DefaultCellStyle.Format = "N4";
			dgv.Columns["MATFACTOR"].DefaultCellStyle.Format = "N4";
			dgv.Columns["FURNACETEMP"].DefaultCellStyle.Format = "N0";
			dgv.Columns["CASTINGTEMP"].DefaultCellStyle.Format = "N0";

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();

			UpdateUI();
		} // end 

		private void AddEditMaterial(string MaterialCategory, int MaterialRecordId)
		{
			var _cmi = new CastingMaterialInfo();
			_cmi.MaterialRecordId = _selectedMatRecordId;
			_cmi.Category = _selectedCategory;
			_cmi.StartPosition = FormStartPosition.CenterScreen;
			if (_cmi.ShowDialog(this) == DialogResult.OK)
			{
				tsbtnRefresh.PerformClick();
			}
		} // end 

		#endregion
	}
}