using OMW15.Models.ProductionModel;
using OMW15.Shared;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class ProductionProcessInfo : Form
	{
		#region class field member

		private readonly ActionMode _mode = ActionMode.None;

		#endregion

		#region class property

		public int ProductionProcessId { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnSave.Enabled = !string.IsNullOrEmpty(txtProcessName.Text);
		} // end UpdateUI

		private void GetProductionProcessInfo(int ProcessId)
		{
			var _pc = new PRDPROCESS();

			if (_mode == ActionMode.Edit)
			{
				_pc = new ProductionDAL().GetProcessInfo(ProcessId);
			}
			txtProcessName.Text = _pc.PROCESSNAME;
			txtMachine.Text = _pc.MACHINE;
			txtScore.Text = _pc.SCORE.ToString();

			UpdateUI();

		} // end GetProductionProcessInfo

		private void UpdateProductionProcess()
		{
			var _pc = new PRDPROCESS();

			switch (_mode)
			{
				case ActionMode.Add:
					_pc.PRDPROCESSID = new ProductionDAL().GetNewProductionProcessId();
					break;

				case ActionMode.Edit:
					_pc.PRDPROCESSID = ProductionProcessId;
					break;
			}

			_pc.PROCESSNAME = txtProcessName.Text;
			_pc.MACHINE = txtMachine.Text;
			_pc.SCORE = Convert.ToDecimal(txtScore.Text);
			_pc.STDHOUR = 0.00m;


			if (new ProductionDAL().UpdateProductionProcess(_pc, _mode) > 0)
			{
				MessageBox.Show("Production Process update successfully...", "Message", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		} // end UpdateProductionProcess

		#endregion


		// Constructor
		public ProductionProcessInfo(int ProductionProcessId)
		{
			InitializeComponent();
			this.ProductionProcessId = ProductionProcessId;

			lbMode.Text = (_mode = this.ProductionProcessId == 0 ? ActionMode.Add : ActionMode.Edit).ToString();
		}

		private void ProductionProcessInfo_Load(object sender, EventArgs e)
		{
			pnlHeader.BackColor = omglobal.OM_BLUE_COLOR;

			GetProductionProcessInfo(ProductionProcessId);
		}

		private void txtProcessName_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			UpdateProductionProcess();
		}

		private void btnMachine_Click(object sender, EventArgs e)
		{
			using (var option = new PrdOption(OMShareProduction.ProductionOptionEnum.Machine))
			{
				option.DataSource = new ProductionDAL().GetProcessMachineList();

				if(option.ShowDialog(this) == DialogResult.OK)
				{
					txtMachine.Text = option.SelectedItem;
				}
			}
		}
	}
}