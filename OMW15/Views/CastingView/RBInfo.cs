using System;
using System.Windows.Forms;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class RBInfo : Form
	{
		public RBInfo()
		{
			InitializeComponent();
		}

		private void RBInfo_Load(object sender, EventArgs e)
		{
			CenterToParent();
			_mode = BaseId == 0 ? ActionMode.Add : ActionMode.Edit;
			GetRBSizeList();

			// update Mode
			grb.Text = string.Format("ข้อมูลฐานยาง ::[{0}]", _mode);

			switch (_mode)
			{
				case ActionMode.Add:
					SetRBInfo();
					break;

				case ActionMode.Edit:
					GetRBInfo(BaseId);
					break;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{

			if (string.IsNullOrEmpty(cbxBaseSize.SelectedValue.ToString())){
				return;
			}

			if (decimal.Parse(ntxtBaseWeight.Text) <= 0.0m) {
				return;
			}


			rb.BASENO = txtBaseNo.Text;
			rb.BASESIZE = cbxBaseSize.SelectedValue.ToString();
			rb.INACTIVE = chkInActive.Checked;
			rb.REMARK = txtRemark.Text;
			rb.WEIGHTGRAM = Convert.ToDecimal(ntxtBaseWeight.Text);

			if (new CastingRubberBase().SaveOrUpdateRubber(_mode, rb) > 0)
				MessageBox.Show(
					string.Format("{0} Rubber base Successfully", _mode == ActionMode.Add ? "Insert new " : "Update Rubber Information"),
					"Message");
		}

		#region class field member

		private ActionMode _mode = ActionMode.None;
		private string _selectedBaseSize = string.Empty;
		private RUBBERBASE rb = new RUBBERBASE();

		#endregion

		#region class property

		public int BaseId { get; set; }

		public string BaseSize { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			txtBaseNo.Enabled = _mode == ActionMode.Add;
		} // end UpdateUI

		private void GetRBSizeList()
		{
			cbxBaseSize.DataSource = new CastingRubberBase().GetRBSize();
			cbxBaseSize.DisplayMember = "BASESIZE";
			cbxBaseSize.ValueMember = "BASESIZE";
		} // end GetRBList

		private void SetRBInfo()
		{
			rb = new RUBBERBASE();
			rb.BASENO = string.Empty;
			rb.BASESIZE = BaseSize;
			rb.WEIGHTGRAM = 0.00m;
			rb.REMARK = string.Empty;
			rb.INACTIVE = false;

			MappingData();
		} // end SetRBInfo

		private void GetRBInfo(int BaseId)
		{
			rb = new CastingRubberBase().GetRubberBaseInfo(BaseId);
			MappingData();
		} // end GetRBInfo

		private void MappingData()
		{
			txtBaseNo.Text = rb.BASENO;
			cbxBaseSize.SelectedValue = rb.BASESIZE;
			chkInActive.Checked = rb.INACTIVE;
			txtRemark.Text = rb.REMARK;
			ntxtBaseWeight.Text = string.Format("{0:N2}", rb.WEIGHTGRAM);

			UpdateUI();
		} // end MappingData

		#endregion
	}
}