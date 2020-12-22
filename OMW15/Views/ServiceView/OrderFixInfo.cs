using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ServiceModel;
using OMW15.Shared;

namespace OMW15.Views.ServiceView
{
	public partial class OrderFixInfo : Form
	{
		public OrderFixInfo(int OrderFixLindId, int JobId, string OrderCode, string OrderNumber)
		{
			InitializeComponent();

			_orderFixLineId = OrderFixLindId;
			_mode = _orderFixLineId == 0 ? ActionMode.Add : ActionMode.Edit;
			_jobId = JobId;
			_orderCode = OrderCode;
			_orderNumber = OrderNumber;
			lbOrderCode.Text = _orderCode;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			var _btn = sender as OMFlatButton;
			switch (_btn.Tag.ToString().ToUpper())
			{
				case "D1":
					lbId1.Text = string.Empty;
					lbEng1.Text = string.Empty;
					break;
				case "D2":
					lbId2.Text = string.Empty;
					lbEng2.Text = string.Empty;
					break;
				case "D3":
					lbId3.Text = string.Empty;
					lbEng3.Text = string.Empty;
					break;
				case "D4":
					lbId4.Text = string.Empty;
					lbEng4.Text = string.Empty;
					break;
			}

			UpdateUI();
		}

		private void OrderFixInfo_Load(object sender, EventArgs e)
		{
			CenterToParent();
			GetOrderFixedInfo(_mode, _orderFixLineId);
		}

		private void btnEng_Click(object sender, EventArgs e)
		{
			var _selectedEngineerName = string.Empty;
			var _selectedEngineerId = string.Empty;
			var _btn = sender as OMFlatButton;
			switch (_btn.Tag.ToString().ToUpper())
			{
				case "E1":
					_selectedEngineerId = lbId1.Text;
					_selectedEngineerName = lbEng1.Text;
					break;
				case "E2":
					_selectedEngineerId = lbId2.Text;
					_selectedEngineerName = lbEng2.Text;
					break;
				case "E3":
					_selectedEngineerId = lbId3.Text;
					_selectedEngineerName = lbEng3.Text;
					break;
				case "E4":
					_selectedEngineerId = lbId4.Text;
					_selectedEngineerName = lbEng4.Text;
					break;
			}


			// loading engineer list
			using (var _eng = new ServiceEngineers(OMShareServiceEnums.EngineerViewState.Select))
			{
				_eng.StartPosition = FormStartPosition.CenterScreen;
				if (_eng.ShowDialog(this) == DialogResult.OK)
				{
					_selectedEngineerName = _eng.EngineerName;
					_selectedEngineerId = _eng.EngineerCode;
				}

				switch (_btn.Tag.ToString().ToUpper())
				{
					case "E1":
						lbId1.Text = _selectedEngineerId;
						lbEng1.Text = _selectedEngineerName;
						break;
					case "E2":
						lbId2.Text = _selectedEngineerId;
						lbEng2.Text = _selectedEngineerName;
						break;
					case "E3":
						lbId3.Text = _selectedEngineerId;
						lbEng3.Text = _selectedEngineerName;
						break;
					case "E4":
						lbId4.Text = _selectedEngineerId;
						lbEng4.Text = _selectedEngineerName;
						break;
				}
			}

			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			AddOrUpdateOrderFixedInfo();
		}

		#region class field member

		private ORDERFIXED _rf = new ORDERFIXED();
		private readonly ActionMode _mode = ActionMode.None;
		private readonly int _orderFixLineId;
		private readonly int _jobId;
		private readonly string _orderCode = string.Empty;
		private readonly string _orderNumber = string.Empty;

		#endregion

		#region class property

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			btnSave.Enabled = !string.IsNullOrEmpty(lbEng1.Text);

			// toggle the button
			btnEng2.Enabled = !string.IsNullOrEmpty(lbEng1.Text);
			btnEng3.Enabled = !string.IsNullOrEmpty(lbEng2.Text);
			btnEng4.Enabled = !string.IsNullOrEmpty(lbEng3.Text);

			btnDeleteEng1.Enabled = !string.IsNullOrEmpty(lbEng1.Text);
			btnDeleteEng2.Enabled = !string.IsNullOrEmpty(lbEng2.Text);
			btnDeleteEng3.Enabled = !string.IsNullOrEmpty(lbEng3.Text);
			btnDeleteEng4.Enabled = !string.IsNullOrEmpty(lbEng4.Text);
		} // end UpdateUI

		private void GetOrderFixedInfo(ActionMode Mode, int LineId)
		{
			switch (Mode)
			{
				case ActionMode.Add:
					_rf = new ORDERFIXED();
					_rf.s_order = _orderNumber;
					_rf.orderid = _jobId;
					_rf.ordercode = _orderCode;
					_rf.isdelete = false;
					_rf.datefixed = DateTime.Today;

					break;
				case ActionMode.Edit:
					_rf = new ServiceJobDAL().GetOrderFixItem(LineId);

					break;
			}

			// map data to controls
			grpEngineer.Text = $"Order Index:{_rf.orderid} Line:{_rf.lineid}";

			lbOrderCode.Text = _rf.ordercode;
			lbOrderNo.Text = _rf.s_order;
			dtpFixedDate.Value = _rf.datefixed;
			lbId1.Text = _rf.engcode1;
			lbEng1.Text = _rf.engineer1;
			lbId2.Text = _rf.engcode2;
			lbEng2.Text = _rf.engineer2;
			lbId3.Text = _rf.engcode3;
			lbEng3.Text = _rf.engineer3;
			lbId4.Text = _rf.engcode4;
			lbEng4.Text = _rf.engineer4;
			txtFixedDetail.Text = _rf.fixeddetail;

			UpdateUI();
		} // end GetOrderFixedInfo

		private void AddOrUpdateOrderFixedInfo()
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_rf = new ORDERFIXED();
					_rf.fixeddetail = txtFixedDetail.Text;
					_rf.datefixed = dtpFixedDate.Value;
					_rf.isdelete = false;
					_rf.ordercode = _orderCode;
					_rf.orderid = _jobId;
					_rf.s_order = _orderNumber;
					_rf.engcode1 = lbId1.Text;
					_rf.engineer1 = lbEng1.Text;
					_rf.engcode2 = lbId2.Text;
					_rf.engineer2 = lbEng2.Text;
					_rf.engcode3 = lbId3.Text;
					_rf.engineer3 = lbEng3.Text;
					_rf.engcode4 = lbId4.Text;
					_rf.engineer4 = lbEng4.Text;

					break;

				case ActionMode.Edit:
					_rf.datefixed = dtpFixedDate.Value;
					_rf.fixeddetail = txtFixedDetail.Text;
					_rf.engcode1 = lbId1.Text;
					_rf.engineer1 = lbEng1.Text;
					_rf.engcode2 = lbId2.Text;
					_rf.engineer2 = lbEng2.Text;
					_rf.engcode3 = lbId3.Text;
					_rf.engineer3 = lbEng3.Text;
					_rf.engcode4 = lbId4.Text;
					_rf.engineer4 = lbEng4.Text;

					break;
			}

			// debug
			//StringBuilder s = new StringBuilder();
			//s.AppendFormat("Mode :: {0}", _mode.ToString());
			//s.AppendLine();
			//s.AppendFormat("Line/Id :{0}/{1}", _rf.lineid, _rf.orderid);
			//s.AppendLine();
			//s.AppendFormat("Job-No. :{0}-{1}", _rf.ordercode, _rf.s_order);
			//s.AppendLine();
			//s.AppendFormat("Fixed Date: {0}", _rf.datefixed.ToShortDateString());
			//s.AppendLine();
			//s.AppendFormat("Fixed Details: {0}", _rf.fixeddetail);
			//s.AppendLine();
			//s.AppendFormat("id:{0}\t name:{1}", _rf.engcode1, _rf.engineer1);
			//s.AppendLine();
			//s.AppendFormat("id:{0}\t name:{1}", _rf.engcode2, _rf.engineer2);
			//s.AppendLine();
			//s.AppendFormat("id:{0}\t name:{1}", _rf.engcode3, _rf.engineer3);
			//s.AppendLine();
			//s.AppendFormat("id:{0}\t name:{1}", _rf.engcode4, _rf.engineer4);
			//s.AppendLine();
			////OMControls.OMUtils.Show
			//OMControls.OMView.Alert _alert = new OMControls.OMView.Alert("Message", s.ToString());
			//_alert.ShowDialog();
			// end debug


			if (new ServiceJobDAL().AddOrUpdateOrderFixedInfo(_mode, _rf) > 0)
			{
				MessageBox.Show(string.Format("{0} Order fixed Info successfully....", _mode == ActionMode.Add ? "Add" : "Update"),
					"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		} // end AddOrUpdateOrderFixedInfo

		#endregion
	}
}