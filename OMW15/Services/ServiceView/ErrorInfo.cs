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
	public partial class ErrorInfo : Form
	{
		private ActionMode _mode = ActionMode.None;
		private int _errorCatId = 0;
		private ERRORCATEGORY _errItem = new ERRORCATEGORY();
		private BindingSource _bds = new BindingSource();

		private void UpdateUI()
		{
			this.btnSave.Enabled = (!string.IsNullOrEmpty(this.txtErrorCode.Text)
									|| !string.IsNullOrEmpty(this.txtErrorName.Text));

		} // end UpdateUI

		private void SetDataBinding(ActionMode Mode,int ErrorCatId)
		{
			_bds = new BindingSource();
			switch (Mode)
			{
				case ActionMode.Add:
					_errItem = new ERRORCATEGORY();
					break;
				case ActionMode.Edit:
					_errItem = new Services.ServiceController.ServiceJobListController().GetErrorItem(ErrorCatId);
					break;
			}

			_bds.DataSource = _errItem;

			// binding to object
			this.txtErrorCode.DataBindings.Add("Text", _bds, "ErrorCode");
			this.txtErrorName.DataBindings.Add("Text", _bds, "ErrorCatname");

		}


		private void SetErrorInfo()
		{
			//_errItem = new ERRORCATEGORY();
			//this.txtErrorCode.Text = _errItem.errorcode;
			//this.txtErrorName.Text = _errItem.errorcatname;
			this.SetDataBinding(_mode, _errorCatId);

		} // end SetErrorInfo

		private void GetErrorInfo(int ErrorCatId)
		{
			this.SetDataBinding(_mode, ErrorCatId);
			//_errItem = new Services.ServiceController.ServiceJobListController().GetErrorItem(ErrorCatId);

			//_bds.DataSource = _errItem;
			//this.txtErrorCode.DataBindings.Add("Text", _bds, "ErrorCode");
			//this.txtErrorCode.Text = _errItem.errorcode;
			//this.txtErrorName.Text = _errItem.errorcatname;
		
		} // end GetErrorInfo

		private void AddEditErrorCategory(int ErrorCatId)
		{
			//_errItem.errorcatid = ErrorCatId;
			//_errItem.errorcatname = this.txtErrorName.Text;
			//_errItem.errorcode = this.txtErrorCode.Text;

			int _result = new Services.ServiceController.ServiceJobListController().AddEditErrorCategory(_errItem, _mode);

			if (_result > 0)
			{
				MessageBox.Show("Update success !!!");
			}

		} // end AddEditErrorCategory

		public ErrorInfo(int ErrorCatId)
		{
			InitializeComponent();
			_errorCatId = ErrorCatId;
			_mode = _errorCatId == 0 ? ActionMode.Add : ActionMode.Edit;
		}

		private void ErrorInfo_Load(object sender, EventArgs e)
		{
			this.grp.Text = string.Format("Error Information : [{0}]", _mode.ToString());
			switch (_mode)
			{
				case ActionMode.Add:
					this.SetErrorInfo();
					break;
				case ActionMode.Edit:
					this.GetErrorInfo(_errorCatId);
					break;
			}
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.AddEditErrorCategory(_mode == ActionMode.Add?0:_errorCatId);
		}
	}
}
