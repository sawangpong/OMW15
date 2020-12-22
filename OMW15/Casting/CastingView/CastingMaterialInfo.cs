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

namespace OMW15.Casting.CastingView
{
	public partial class CastingMaterialInfo : Form
	{
		#region class field member

		private ActionMode _mode = ActionMode.None;

		#endregion

		#region class property

		public int MaterialRecordId
		{
			get;
			set;
		}

		public string Category
		{
			get;
			set;
		}

		#endregion

		#region class method

		private void UpdateUI()
		{
			this.txtGroupTitle.Enabled = false;
			this.txtGroupTitleHeader.Enabled = this.txtGroupTitle.Enabled;
			this.txtCategory.Enabled = this.txtGroupTitle.Enabled;
			this.txtKeyValue.Enabled = (_mode == ActionMode.Add);

		} // end UpdateUI

		private void SetNewMaterialInfoUI()
		{
			int _newMaterialIndex = new Casting.CastingController.MaterialDAL().GetMaxIndexForMaterial("MATERIAL");

			// debug
			// MessageBox.Show(string.Format("New Index = {0}",_newMaterialIndex),"DEBUG");
			// end debug

			this.txtCategory.Text = this.Category;
			this.txtGroupTitle.Text = "MATERIAL";
			this.txtGroupTitleHeader.Text = "MATERIALS";
			this.txtEnKeyName.Text = string.Empty;
			this.txtThKeyName.Text = string.Empty;
			this.txtKeyValue.Text = string.Format("{0}", (_newMaterialIndex + 1));
			this.txtConvertFactor.Text = string.Format("{0:N4}", 0);
			this.txtMatFactor.Text = string.Format("{0:N4}", 1);
			this.txtFurnaceTemp.Text = string.Format("{0:N0}", 550);
			this.txtCastingTemp.Text = string.Format("{0:N0}", 1050);

		} // end SetNewMaterialInfoUI

		private void GetMaterialInfo(int MaterialRecordId)
		{
			// get information
			SYSDATA m = new Casting.CastingController.MaterialDAL().GetMaterialInfo(MaterialRecordId);

			this.txtCastingTemp.Text = m.CASTINGTEMP.ToString();
			this.txtCategory.Text = m.CATEGORY;
			this.txtConvertFactor.Text = m.CONVERTFACTOR.ToString();
			this.txtEnKeyName.Text = m.ENKEYNAME;
			this.txtFurnaceTemp.Text = m.FURNACETEMP.ToString();
			this.txtGroupTitle.Text = m.GROUPTITLE;
			this.txtGroupTitleHeader.Text = m.GROUPTITLEHEADER;
			this.txtKeyValue.Text = m.KEYVALUE;
			this.txtMatFactor.Text = m.MATFACTOR.ToString();
			this.txtThKeyName.Text = m.THKEYNAME;
			this.ntxtSI.Text = string.Format("{0:N2}", m.SI);

			this.UpdateUI();

		} // end GetMaterialInfo

		private void InsertUpdateaMaterialInfo(int RecordId)
		{
			int _result = 0;

			SYSDATA mi = new SYSDATA();
			mi.CASTINGTEMP = Convert.ToDecimal(this.txtCastingTemp.Text);
			mi.CATEGORY = this.Category;
			mi.CONVERTFACTOR = Convert.ToDecimal(this.txtConvertFactor.Text);
			mi.ENKEYNAME = this.txtEnKeyName.Text;
			mi.FURNACETEMP = Convert.ToDecimal(this.txtFurnaceTemp.Text);
			mi.GROUPTITLE = this.txtGroupTitle.Text;
			mi.GROUPTITLEHEADER = this.txtGroupTitleHeader.Text;
			mi.MATFACTOR = Convert.ToDecimal(this.txtMatFactor.Text);
			mi.SI = Convert.ToDecimal(ntxtSI.Text);
			mi.THKEYNAME = this.txtThKeyName.Text;

			switch (_mode)
			{
				case ActionMode.Add:
					mi.KEYVALUE = (new Casting.CastingController.MaterialDAL().GetMaxIndexForMaterial("MATERIAL") + 1).ToString();
					_result = new Casting.CastingController.MaterialDAL().InsertCastingMaterialInfo(mi);
					break;
				case ActionMode.Edit:
					mi.KEYVALUE = this.txtKeyValue.Text;
					_result = new Casting.CastingController.MaterialDAL().UpdateCastingMaterialInformation(mi, RecordId);
					break;
			}

			if (_result > 0)
			{
				omglobal.DisplayAlert("Message", string.Format("{0} Material Information completed....", (_mode == ActionMode.Add ? "Insert " : "Update ")));
			}
		} // end

		#endregion

		public CastingMaterialInfo()
		{
			InitializeComponent();
		}

		private void CastingMaterialInfo_Load(object sender, EventArgs e)
		{
			// setting Mode

			_mode = (this.MaterialRecordId == 0 ? ActionMode.Add : ActionMode.Edit);

			// display mode
			this.grp.Text = string.Format("รายละเอียดวัสดุ [{0}] : [{1}]", _mode.ToString(), this.Category);

			switch (_mode)
			{
				case ActionMode.Add:
					this.SetNewMaterialInfoUI();
					break;
				case ActionMode.Edit:
					this.GetMaterialInfo(this.MaterialRecordId);
					break;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.InsertUpdateaMaterialInfo(this.MaterialRecordId);
		}
	}
}
