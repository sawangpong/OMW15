using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ServiceModel;
using OMW15.Shared;

namespace OMW15.Views.ServiceView
{
	public partial class ServiceEngineerInfo : Form
	{
		public ServiceEngineerInfo(int EngineerSEQ)
		{
			InitializeComponent();

			_engSEQ = EngineerSEQ;
			_mode = _engSEQ == 0 ? ActionMode.Add : ActionMode.Edit;
		}

		private void ServiceEngineerInfo_Load(object sender, EventArgs e)
		{
			GetStatusList();

			groupBox1.Text = string.Format("ช่างบริการ :: [{0}]", _mode);

			GetEngineerInfo(_engSEQ);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cbxStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			var _status = cbxStatus.Text;
			try
			{
				_selectedEngineerStatus = Convert.ToInt32(cbxStatus.SelectedValue);
			}
			catch
			{
				_selectedEngineerStatus = (int) OMShareServiceEnums.EngineerStatusEnum.Working;
			}

			dtpResignDate.Visible = _selectedEngineerStatus == (int) OMShareServiceEnums.EngineerStatusEnum.Resign ? true : false;
			lbResignDate.Visible = dtpResignDate.Visible;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveUpdateEngineerInfo();
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		#region class field member

		private ENGINEER _engineer;
		private readonly ActionMode _mode = ActionMode.None;
		private int _selectedEngineerStatus = (int) OMShareServiceEnums.EngineerStatusEnum.Working;
		private readonly int _engSEQ;

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			txtEngId.Enabled = _mode == ActionMode.Add;

			btnSave.Enabled = !string.IsNullOrEmpty(txtName.Text)
			                  && !string.IsNullOrEmpty(txtEngId.Text);
		} // end UpdateUI

		private void GetStatusList()
		{
			cbxStatus.DataSource = EnumWithName<OMShareServiceEnums.EngineerStatusEnum>.ParseEnum();
			cbxStatus.DisplayMember = "Name";
			cbxStatus.ValueMember = "Value";
		}


		private void GetEngineerInfo(int EngSEQ)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_engineer = new ENGINEER();
					_engineer.empcode = string.Empty;
					_engineer.engiseq = 0;
					_engineer.id = string.Empty;
					_engineer.lastname = string.Empty;
					_engineer.name = string.Empty;
					_engineer.resigndate = 0;
					_engineer.Status = 0;
					_engineer.curr = OMShareServiceEnums.EngineerStatusEnum.Working.ToString();

					break;
				case ActionMode.Edit:
					_engineer = new ServiceJobDAL().GetEngineer(EngSEQ);
					break;
			}

			lbStatus.Text = _engineer.engiseq.ToString();
			// map to object
			txtEngId.DataBindings.Add("Text", _engineer, "id");
			txtName.DataBindings.Add("Text", _engineer, "name");
			txtLastName.DataBindings.Add("Text", _engineer, "lastname");
			dtpResignDate.Value = _engineer.resigndate == 0 ? DateTime.Today : _engineer.resigndate.Num2Date();
			cbxStatus.SelectedValue = _engineer.Status;

			UpdateUI();
		} // end GetEngineerInfo

		private void SaveUpdateEngineerInfo()
		{
			switch (_mode)
			{
				case ActionMode.Add:

					_engineer.empcode = string.Empty;
					_engineer.Status = _selectedEngineerStatus;
					_engineer.curr = cbxStatus.Text;
					_engineer.resigndate = _selectedEngineerStatus == (int) OMShareServiceEnums.EngineerStatusEnum.Working
						? 0
						: dtpResignDate.Value.Date2Num();

					break;
				case ActionMode.Edit:
					_engineer.Status = _selectedEngineerStatus;
					_engineer.curr = cbxStatus.Text;
					_engineer.empcode = string.Empty;
					_engineer.resigndate = _selectedEngineerStatus == (int) OMShareServiceEnums.EngineerStatusEnum.Working
						? 0
						: dtpResignDate.Value.Date2Num();

					break;
			}

			if (new ServiceJobDAL().UpdateEngineerInfo(_mode, _engineer) > 0)
			{
				//MessageBox.Show("Update Engineer Record successfully....");
			}
		} // end SaveUpdateEngineerInfo

		#endregion
	}
}