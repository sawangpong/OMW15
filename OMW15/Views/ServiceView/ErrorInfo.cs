using System;
using System.Windows.Forms;
using OMW15.Models.ServiceModel;
using OMW15.Shared;

namespace OMW15.Views.ServiceView
{
	public partial class ErrorInfo : Form
	{
		private BindingSource _bds = new BindingSource();
		private ERRORCATEGORY _errItem = new ERRORCATEGORY();
		private readonly int _errorCatId;
		private readonly ActionMode _mode = ActionMode.None;

		public ErrorInfo(int ErrorCatId)
		{
			InitializeComponent();
			_errorCatId = ErrorCatId;
			_mode = _errorCatId == 0 ? ActionMode.Add : ActionMode.Edit;
		}

		private void UpdateUI()
		{
			btnSave.Enabled = !string.IsNullOrEmpty(txtErrorCode.Text)
			                  || !string.IsNullOrEmpty(txtErrorName.Text);
		} // end UpdateUI

		private void SetDataBinding(ActionMode Mode, int ErrorCatId)
		{
			_bds = new BindingSource();
			switch (Mode)
			{
				case ActionMode.Add:
					_errItem = new ERRORCATEGORY();
					break;
				case ActionMode.Edit:
					_errItem = new ServiceJobDAL().GetErrorItem(ErrorCatId);
					break;
			}

			_bds.DataSource = _errItem;

			// binding to object
			txtErrorCode.DataBindings.Add("Text", _bds, "ErrorCode");
			txtErrorName.DataBindings.Add("Text", _bds, "ErrorCatname");
		}


		private void SetErrorInfo()
		{
			//_errItem = new ERRORCATEGORY();
			//this.txtErrorCode.Text = _errItem.errorcode;
			//this.txtErrorName.Text = _errItem.errorcatname;
			SetDataBinding(_mode, _errorCatId);
		} // end SetErrorInfo

		private void GetErrorInfo(int ErrorCatId)
		{
			SetDataBinding(_mode, ErrorCatId);
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

			var _result = new ServiceJobDAL().AddEditErrorCategory(_errItem, _mode);

			if (_result > 0)
				MessageBox.Show("Update success !!!");
		} // end AddEditErrorCategory

		private void ErrorInfo_Load(object sender, EventArgs e)
		{
			grp.Text = string.Format("Error Information : [{0}]", _mode);
			switch (_mode)
			{
				case ActionMode.Add:
					SetErrorInfo();
					break;
				case ActionMode.Edit:
					GetErrorInfo(_errorCatId);
					break;
			}
		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			AddEditErrorCategory(_mode == ActionMode.Add ? 0 : _errorCatId);
		}
	}
}