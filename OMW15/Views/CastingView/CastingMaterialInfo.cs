using System;
using System.Windows.Forms;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class CastingMaterialInfo : Form
	{
		#region class field member

		private ActionMode _mode = ActionMode.None;

		#endregion

		public CastingMaterialInfo()
		{
			InitializeComponent();
		}

		private void CastingMaterialInfo_Load(object sender, EventArgs e)
		{
			// setting Mode
			_mode = MaterialRecordId == 0 ? ActionMode.Add : ActionMode.Edit;

			// display mode
			grp.Text = $"รายละเอียดวัสดุ [{_mode}] : [{Category}]";

			switch (_mode)
			{
				case ActionMode.Add:
					SetNewMaterialInfoUI();
					break;
				case ActionMode.Edit:
					GetMaterialInfo(MaterialRecordId);
					break;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			InsertUpdateaMaterialInfo(MaterialRecordId);
		}

		#region class property

		public int MaterialRecordId { get; set; }

		public string Category { get; set; }

		#endregion

		#region class method

		private void UpdateUI()
		{
			txtGroupTitle.Enabled = false;
			txtGroupTitleHeader.Enabled = txtGroupTitle.Enabled;
			txtCategory.Enabled = txtGroupTitle.Enabled;
			txtKeyValue.Enabled = _mode == ActionMode.Add;

			btnSave.Enabled = (!string.IsNullOrEmpty(txtEnKeyName.Text) && !string.IsNullOrEmpty(txtThKeyName.Text));

		} // end UpdateUI

		private void SetNewMaterialInfoUI()
		{
			var _newMaterialIndex = new MaterialDAL().GetMaxIndexForMaterial("MATERIAL");
			chkInused.Checked = true;
			txtCategory.Text = Category;
			txtGroupTitle.Text = "MATERIAL";
			txtGroupTitleHeader.Text = "MATERIALS";
			txtEnKeyName.Text = string.Empty;
			txtThKeyName.Text = string.Empty;
			txtKeyValue.Text = $"{_newMaterialIndex + 1}";
			txtConvertFactor.Text = $"{0:N4}";
			txtMatFactor.Text = $"{0:N4}";
			txtFurnaceTemp.Text = $"{550:N0}";
			txtCastingTemp.Text = $"{1050:N0}";

			UpdateUI();

		} // end SetNewMaterialInfoUI

		private void GetMaterialInfo(int MaterialRecordId)
		{
			// get information
			var m = new MaterialDAL().GetMaterialInfo(MaterialRecordId);

			chkInused.Checked = m.Inused;
			txtCastingTemp.Text = m.CASTINGTEMP.ToString();
			txtCategory.Text = m.CATEGORY;
			txtConvertFactor.Text = m.CONVERTFACTOR.ToString();
			txtEnKeyName.Text = m.ENKEYNAME;
			txtFurnaceTemp.Text = m.FURNACETEMP.ToString();
			txtGroupTitle.Text = m.GROUPTITLE;
			txtGroupTitleHeader.Text = m.GROUPTITLEHEADER;
			txtKeyValue.Text = m.KEYVALUE;
			txtMatFactor.Text = m.MATFACTOR.ToString();
			txtThKeyName.Text = m.THKEYNAME;
			ntxtSI.Text = $"{m.SI:N2}";

			UpdateUI();
		} // end GetMaterialInfo

		private void InsertUpdateaMaterialInfo(int RecordId)
		{
			var _result = 0;

			var mi = new SYSDATA();
			mi.Inused = chkInused.Checked;
			mi.CASTINGTEMP = Convert.ToDecimal(txtCastingTemp.Text);
			mi.CATEGORY = Category;
			mi.CONVERTFACTOR = Convert.ToDecimal(txtConvertFactor.Text);
			mi.ENKEYNAME = txtEnKeyName.Text.ToUpper();
			mi.FURNACETEMP = Convert.ToDecimal(txtFurnaceTemp.Text);
			mi.GROUPTITLE = txtGroupTitle.Text.ToUpper();
			mi.GROUPTITLEHEADER = txtGroupTitleHeader.Text.ToUpper();
			mi.MATFACTOR = Convert.ToDecimal(txtMatFactor.Text);
			mi.SI = Convert.ToDecimal(ntxtSI.Text);
			mi.THKEYNAME = txtThKeyName.Text;

			switch (_mode)
			{
				case ActionMode.Add:
					mi.KEYVALUE = (new MaterialDAL().GetMaxIndexForMaterial("MATERIAL") + 1).ToString();
					_result = new MaterialDAL().InsertCastingMaterialInfo(mi);
					break;
				case ActionMode.Edit:
					mi.KEYVALUE = txtKeyValue.Text;
					_result = new MaterialDAL().UpdateCastingMaterialInformation(mi, RecordId);
					break;
			}

			if (_result > 0)
				Alert.DisplayAlert("Message",
					string.Format("{0} Material Information completed....", _mode == ActionMode.Add ? "Insert " : "Update "));
		} // end

		#endregion

		private void txt_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}
	}
}