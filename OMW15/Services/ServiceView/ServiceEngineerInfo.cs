using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Services.ServiceView
{
	public partial class ServiceEngineerInfo : Form
	{
		#region class field member

		private ENGINEER _engineer;
		private ActionMode _mode = ActionMode.None;
		private int _selectedEngineerStatus = (int)Services.ServiceController.EngineerStatusEnum.Working;
		private int _engSEQ = 0;

		#endregion

		#region class property
		
		#endregion


		#region class helper method

		private void UpdateUI()
		{
			this.txtEngId.Enabled = (_mode == ActionMode.Add);

			this.btnSave.Enabled = !string.IsNullOrEmpty(this.txtName.Text)
									&& !string.IsNullOrEmpty(this.txtEngId.Text);
		} // end UpdateUI

		private void GetStatusList()
		{
			this.cbxStatus.DataSource =OMControls.EnumWithName<Services.ServiceController.EngineerStatusEnum>.ParseEnum();
			this.cbxStatus.DisplayMember = "Name";
			this.cbxStatus.ValueMember = "Value";
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
					_engineer.curr = Services.ServiceController.EngineerStatusEnum.Working.ToString();
			
					break;
				case ActionMode.Edit:
					_engineer = Services.ServiceController.ServiceEngineerController.GetEngineer(EngSEQ);
					break;
			}

			this.lbStatus.Text = _engineer.engiseq.ToString();
			// map to object
			this.txtEngId.DataBindings.Add("Text", _engineer, "id");
			this.txtName.DataBindings.Add("Text", _engineer, "name");
			this.txtLastName.DataBindings.Add("Text", _engineer, "lastname");
			this.dtpResignDate.Value = _engineer.resigndate == 0 ? DateTime.Today : OMControls.OMUtils.Num2Date(_engineer.resigndate);
			this.cbxStatus.SelectedValue = _engineer.Status;

			this.UpdateUI();

		} // end GetEngineerInfo

		private void SaveUpdateEngineerInfo()
		{
			switch (_mode)
			{
				case ActionMode.Add:

					_engineer.empcode = string.Empty;
					_engineer.Status = _selectedEngineerStatus;
					_engineer.curr = this.cbxStatus.Text;
					_engineer.resigndate =  (_selectedEngineerStatus == (int)Services.ServiceController.EngineerStatusEnum.Working ? 0 : OMControls.OMUtils.Date2Num(this.dtpResignDate.Value));

					break;
				case ActionMode.Edit:
					_engineer.Status = _selectedEngineerStatus;
					_engineer.curr = this.cbxStatus.Text;
					_engineer.empcode = string.Empty;
					_engineer.resigndate =  (_selectedEngineerStatus == (int)Services.ServiceController.EngineerStatusEnum.Working ? 0 : OMControls.OMUtils.Date2Num(this.dtpResignDate.Value));

					break;
			}

			if (Services.ServiceController.ServiceEngineerController.UpdateEngineerInfo(_mode, _engineer) > 0)
			{
				//MessageBox.Show("Update Engineer Record successfully....");
			}

		} // end SaveUpdateEngineerInfo


		#endregion



		public ServiceEngineerInfo(int EngineerSEQ)
		{
			InitializeComponent();

			_engSEQ = EngineerSEQ;
			_mode = (_engSEQ == 0 ? ActionMode.Add : ActionMode.Edit);

		}

		private void ServiceEngineerInfo_Load(object sender, EventArgs e)
		{
			this.GetStatusList();

			this.groupBox1.Text = string.Format("ช่างบริการ :: [{0}]", _mode.ToString());

			this.GetEngineerInfo(_engSEQ);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cbxStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			string _status = this.cbxStatus.Text;
			try
			{
				_selectedEngineerStatus = Convert.ToInt32(this.cbxStatus.SelectedValue);
			}
			catch
			{
				_selectedEngineerStatus = (int)Services.ServiceController.EngineerStatusEnum.Working;
			}

			this.dtpResignDate.Visible = ((_selectedEngineerStatus  == (int)Services.ServiceController.EngineerStatusEnum.Resign) ? true : false);
			this.lbResignDate.Visible = this.dtpResignDate.Visible;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.SaveUpdateEngineerInfo();
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}


	}
}
