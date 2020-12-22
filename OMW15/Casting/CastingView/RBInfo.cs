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
	public partial class RBInfo : Form
	{
		#region class field member
		private ActionMode _mode = ActionMode.None;
		private string _selectedBaseSize = string.Empty;
		private RUBBERBASE rb = new RUBBERBASE();
		#endregion

		#region class property
		public int BaseId
		{
			get;
			set;
		}

		public string BaseSize
		{
			get;
			set;
		}


		#endregion

		#region class helper method
		private void UpdateUI()
		{
			this.txtBaseNo.Enabled = (_mode == ActionMode.Add);


		} // end UpdateUI

		private void GetRBSizeList()
		{
			this.cbxBaseSize.DataSource = Casting.CastingController.CastingRubberBase.GetRBSize();
			this.cbxBaseSize.DisplayMember = "BASESIZE";
			this.cbxBaseSize.ValueMember = "BASESIZE";

		} // end GetRBList

		private void SetRBInfo()
		{
			rb = new RUBBERBASE();
			rb.BASENO = string.Empty;
			rb.BASESIZE = this.BaseSize;
			rb.WEIGHTGRAM = 0.00m;
			rb.REMARK = string.Empty;
			rb.INACTIVE = false;

			this.MappingData();

		}// end SetRBInfo

		private void GetRBInfo(int BaseId)
		{
			rb = Casting.CastingController.CastingRubberBase.GetRubberBaseInfo(BaseId);
			this.MappingData();

		} // end GetRBInfo

		private void MappingData()
		{
			this.txtBaseNo.Text = rb.BASENO;
			this.cbxBaseSize.SelectedValue = rb.BASESIZE;
			this.chkInActive.Checked = rb.INACTIVE;
			this.txtRemark.Text = rb.REMARK;
			this.ntxtBaseWeight.Text = String.Format("{0:N2}", rb.WEIGHTGRAM);

			this.UpdateUI();

		} // end MappingData


		#endregion

		public RBInfo()
		{
			InitializeComponent();
		}

		private void RBInfo_Load(object sender, EventArgs e)
		{
			_mode = (this.BaseId == 0 ? ActionMode.Add : ActionMode.Edit);
			this.GetRBSizeList();

			// update Mode
			this.grb.Text = string.Format("ข้อมูลฐานยาง ::[{0}]", _mode.ToString());

			switch (_mode)
			{
				case ActionMode.Add:
					this.SetRBInfo();
					break;

				case ActionMode.Edit:
					this.GetRBInfo(this.BaseId);
					break;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			rb.BASENO = this.txtBaseNo.Text;
			rb.BASESIZE = this.cbxBaseSize.SelectedValue.ToString();
			rb.INACTIVE = this.chkInActive.Checked;
			rb.REMARK = this.txtRemark.Text;
			rb.WEIGHTGRAM = Convert.ToDecimal(this.ntxtBaseWeight.Text);

			if (Casting.CastingController.CastingRubberBase.SaveOrUpdateRubber(_mode, rb) > 0)
			{
				MessageBox.Show(string.Format("{0} Rubber base Successfully", _mode == ActionMode.Add ? "Insert new " : "Update Rubber Information"), "Message");
			}
		}
	}
}
