using OMW15.Controllers.ToolController;
using OMW15.Models.ProductionModel;
using OMW15.Shared;
using OMW15.Views.WarehouseView;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class STDItemProcess : Form
	{
		#region class field
		private int _processId = 0;
		private int _itemId = 0;
		private string _itemName = "";
		private string _itemNo = "";
		private ActionMode _actionMode = ActionMode.None;
		private PDITEMPROCESS _process = new PDITEMPROCESS();

		#endregion

		#region class property

		#endregion

		#region Class helper

		private void UpdateUI()
		{
			btnSave.Enabled = !String.IsNullOrEmpty(txtProcess.Text);
		}

		private void GetProcess()
		{
			var _processName = string.Empty;
			var _processCode = string.Empty;
			var _processId = 0;

			ToolGetData.GetData(SelectTypeOption.ProductionProcess, ref _processName, ref _processCode, ref _processId);

			txtProcess.Text = _processName;
			txtProcess.Tag = _processId;
			lbProcessId.Text = _processId.ToString();


		} // end  GetProcess

		private void getProcessInfo(int processId)
		{
			if (_actionMode == ActionMode.Add)
			{
				_process = new PDITEMPROCESS();
				_process.CreateBy = omglobal.UserName;
				_process.REF_PROCESS = 0;
				_process.MATID = "";
				_process.MATNAME = "";
				_process.REF_STDITEM = this._itemId;
				_process.REF_STDITEMNO = this._itemNo;
				_process.STD_HR = 0.00m;
				_process.STEP = (new ProductionDAL().GetMaxStep(this._itemNo));
				_process.STEP_COST = 0.00m;
				_process.WORKMINT = 0.00m;
				_process.HOUR_FACTOR = 1.0m;
			}
			else
			{
				_process = new ProductionDAL().GetItemProcessInfo(processId);
			}
		}
		

		#endregion

		public STDItemProcess(int id, int itemId, string itemNo, string itemName)
		{
			InitializeComponent();

			_processId = id;
			_itemId = itemId;
			_itemNo = itemNo;
			_itemName = itemName;

			_actionMode = (id == 0 ? ActionMode.Add : ActionMode.Edit);
			lbMode.Text = _actionMode.ToString();
		}

		private void STDItemProcess_Load(object sender, EventArgs e)
		{
			lbId.Text = $"id : {_processId}";

			// get info
			getProcessInfo(_processId);

			lbHeader.Text = $"ขั้นตอนการผลิตมาตรฐาน # {this._itemNo}";
			txtStep.Text = _process.STEP.ToString();
			txtPartName.Text = _itemName;
			txtProcess.Text = (_actionMode == ActionMode.Add ? "" : new ProductionDAL().GetProcessName(_process.REF_PROCESS));
			txtMatId.Text = _process.MATID;
			txtMaterial.Text = _process.MATNAME;
			txtProcess.Tag = _process.REF_PROCESS;
			txtStdHr.Text = $"{_process.STD_HR:N2}";
			hourFactor.Value = _process.HOUR_FACTOR;
			txtWorkMint.Text = $"{_process.WORKMINT:N2}";
			txtStepCost.Text = $"{_process.STEP_COST:N2}";
		}

		private void btnProcess_Click(object sender, EventArgs e)
		{
			this.GetProcess();
		}

		private void txtProcess_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			_process.REF_PROCESS = Convert.ToInt32(this.txtProcess.Tag);
			_process.MATID = txtMatId.Text;
			_process.MATNAME = txtMaterial.Text;
			_process.REF_STDITEM = _itemId;
			_process.REF_STDITEMNO = _itemNo;
			_process.STEP = Convert.ToInt32(txtStep.Text);
			_process.WORKMINT = Convert.ToDecimal(txtWorkMint.Text);
			_process.STD_HR = Convert.ToDecimal(txtStdHr.Text);
			_process.STEP_COST = Convert.ToDecimal(txtStepCost.Text);
			_process.HOUR_FACTOR = hourFactor.Value;

			if (_actionMode == ActionMode.Add)
			{
				_process.CreateBy = omglobal.UserName;
				_process.CreateDate = DateTime.Now;
			}

			_process.ModifyBy = omglobal.UserName;
			_process.ModifyDate = DateTime.Now;

			if (new ProductionDAL().UpdateStdProcess(_process) > 0)
			{
				MessageBox.Show("Update Process successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void txtWorkMint_TextChanged(object sender, EventArgs e)
		{
			if (txtWorkMint.Text.Length == 0)
			{
				txtStdHr.Text = $"{0:N2}";
				return;
			}

			if (!txtWorkMint.Text.IsNumeric())
			{
				if (Convert.ToDecimal(txtWorkMint.Text) == 0m)
				{
					txtStdHr.Text = $"{0:N2}";
				}
				return;
			}

			txtStdHr.Text = $"{Convert.ToDecimal(txtWorkMint.Text) / 60:N2}";
		}

		private void btnMatNo_Click(object sender, EventArgs e)
		{
			using (var _im = new StockMaster(ActionMode.Selection))
			{
				_im.StartPosition = FormStartPosition.CenterScreen;
				if (_im.ShowDialog() == DialogResult.OK)
				{
					txtMatId.Text = _im.ItemMasterCode;
					txtMaterial.Text = _im.ItemMasterNameTH;
				}
			}
		}

		private void hourFactor_ValueChanged(object sender, EventArgs e)
		{

		}
	}
}
