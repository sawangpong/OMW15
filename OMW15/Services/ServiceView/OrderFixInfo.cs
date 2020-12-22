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
	public partial class OrderFixInfo : Form
	{
		#region class field member
		
		private ORDERFIXED _rf = new ORDERFIXED();
		private ActionMode _mode = ActionMode.None;
		private int _orderFixLineId = 0;
		private int _jobId = 0;
		private string _orderCode = string.Empty;
		private string _orderNumber = string.Empty;

		#endregion

		#region class property

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			this.btnSave.Enabled = !string.IsNullOrEmpty(this.lbEng1.Text);

			// toggle the button
			this.btnEng2.Enabled = !string.IsNullOrEmpty(this.lbEng1.Text);
			this.btnEng3.Enabled = !string.IsNullOrEmpty(this.lbEng2.Text);
			this.btnEng4.Enabled = !string.IsNullOrEmpty(this.lbEng3.Text);

			this.btnDeleteEng1.Enabled = !string.IsNullOrEmpty(this.lbEng1.Text);
			this.btnDeleteEng2.Enabled = !string.IsNullOrEmpty(this.lbEng2.Text);
			this.btnDeleteEng3.Enabled = !string.IsNullOrEmpty(this.lbEng3.Text);
			this.btnDeleteEng4.Enabled = !string.IsNullOrEmpty(this.lbEng4.Text);

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
					_rf = new Services.ServiceController.ServiceJobInfoController().GetOrderFixItem(LineId);

					break;
			}

			// map data to controls
			this.grpEngineer.Text = string.Format("Order Index:{0} Line:{1}", _rf.orderid, _rf.lineid);

			this.lbOrderCode.Text = _rf.ordercode;
			this.lbOrderNo.Text = _rf.s_order;
			this.dtpFixedDate.Value = _rf.datefixed;
			this.lbId1.Text = _rf.engcode1;
			this.lbEng1.Text = _rf.engineer1;
			this.lbId2.Text = _rf.engcode2;
			this.lbEng2.Text = _rf.engineer2;
			this.lbId3.Text = _rf.engcode3;
			this.lbEng3.Text = _rf.engineer3;
			this.lbId4.Text = _rf.engcode4;
			this.lbEng4.Text = _rf.engineer4;
			this.txtFixedDetail.Text = _rf.fixeddetail;

			this.UpdateUI();

		} // end GetOrderFixedInfo

		private void AddOrUpdateOrderFixedInfo()
		{
			switch (_mode)
			{
				case ActionMode.Add:
					_rf = new ORDERFIXED();
					_rf.fixeddetail = this.txtFixedDetail.Text;
					_rf.datefixed = this.dtpFixedDate.Value;
					_rf.isdelete = false;
					_rf.ordercode = _orderCode;
					_rf.orderid = _jobId;
					_rf.s_order = _orderNumber;
					_rf.engcode1 = this.lbId1.Text;
					_rf.engineer1 = this.lbEng1.Text;
					_rf.engcode2 = this.lbId2.Text;
					_rf.engineer2 = this.lbEng2.Text;
					_rf.engcode3 = this.lbId3.Text;
					_rf.engineer3 = this.lbEng3.Text;
					_rf.engcode4 = this.lbId4.Text;
					_rf.engineer4 = this.lbEng4.Text;

					break;

				case ActionMode.Edit:
					_rf.datefixed = this.dtpFixedDate.Value;
					_rf.engcode1 = this.lbId1.Text;
					_rf.engineer1 = this.lbEng1.Text;
					_rf.engcode2 = this.lbId2.Text;
					_rf.engineer2 = this.lbEng2.Text;
					_rf.engcode3 = this.lbId3.Text;
					_rf.engineer3 = this.lbEng3.Text;
					_rf.engcode4 = this.lbId4.Text;
					_rf.engineer4 = this.lbEng4.Text;

					break;
			}

			// debug
			StringBuilder s = new StringBuilder();
			s.AppendFormat("Mode :: {0}", _mode.ToString());
			s.AppendLine();
			s.AppendFormat("Line/Id :{0}/{1}", _rf.lineid, _rf.orderid);
			s.AppendLine();
			s.AppendFormat("Job-No. :{0}-{1}", _rf.ordercode, _rf.s_order);
			s.AppendLine();
			s.AppendFormat("Fixed Date: {0}", _rf.datefixed.ToShortDateString());
			s.AppendLine();
			s.AppendFormat("Fixed Details: {0}", _rf.fixeddetail);
			s.AppendLine();
			s.AppendFormat("id:{0}\t name:{1}", _rf.engcode1, _rf.engineer1);
			s.AppendLine();
			s.AppendFormat("id:{0}\t name:{1}", _rf.engcode2, _rf.engineer2);
			s.AppendLine();
			s.AppendFormat("id:{0}\t name:{1}", _rf.engcode3, _rf.engineer3);
			s.AppendLine();
			s.AppendFormat("id:{0}\t name:{1}", _rf.engcode4, _rf.engineer4);
			s.AppendLine();

			//OMControls.OMUtils.Show
			OMControls.OMView.Alert _alert = new OMControls.OMView.Alert("Message", s.ToString());
			_alert.ShowDialog();
			// end debug


			if (new Services.ServiceController.ServiceJobInfoController().AddOrUpdateOrderFixedInfo(_mode, _rf) > 0)
			{
				MessageBox.Show(string.Format("{0} Order fixed Info successfully....",(_mode == ActionMode.Add ? "Add" : "Update")), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		} // end AddOrUpdateOrderFixedInfo


		#endregion


		public OrderFixInfo(int OrderFixLindId,int JobId, string OrderCode,string OrderNumber)
		{
			InitializeComponent();

			_orderFixLineId = OrderFixLindId;
			_mode = (_orderFixLineId == 0 ? ActionMode.Add : ActionMode.Edit);
			_jobId = JobId;
			_orderCode = OrderCode;
			_orderNumber = OrderNumber;
			this.lbOrderCode.Text = _orderCode;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			OMControls.OMFlatButton _btn = sender as OMControls.OMFlatButton;
			switch (_btn.Tag.ToString().ToUpper())
			{
				case "D1":
					this.lbId1.Text = string.Empty;
					this.lbEng1.Text = string.Empty;
					break;
				case "D2":
					this.lbId2.Text = string.Empty;
					this.lbEng2.Text = string.Empty;
					break;
				case "D3":
					this.lbId3.Text = string.Empty;
					this.lbEng3.Text = string.Empty;
					break;
				case "D4":
					this.lbId4.Text = string.Empty;
					this.lbEng4.Text = string.Empty;
					break;
			}

			this.UpdateUI();
		}

		private void OrderFixInfo_Load(object sender, EventArgs e)
		{
			this.GetOrderFixedInfo(_mode, _orderFixLineId);
		}

		private void btnEng_Click(object sender, EventArgs e)
		{
			string _selectedEngineerName = string.Empty;
			string _selectedEngineerId = string.Empty;
			OMControls.OMFlatButton _btn = sender as OMControls.OMFlatButton;
			switch (_btn.Tag.ToString().ToUpper())
			{
				case "E1":
					_selectedEngineerId = this.lbId1.Text;
					_selectedEngineerName = this.lbEng1.Text;
					break;
				case "E2":
					_selectedEngineerId = this.lbId2.Text;
					_selectedEngineerName = this.lbEng2.Text;
					break;
				case "E3":
					_selectedEngineerId = this.lbId3.Text;
					_selectedEngineerName = this.lbEng3.Text;
					break;
				case "E4":
					_selectedEngineerId = this.lbId4.Text;
					_selectedEngineerName = this.lbEng4.Text;
					break;
			}


			// loading engineer list
			using (Services.ServiceView.ServiceEngineers _eng = new ServiceEngineers(ServiceController.EngineerViewState.Select))
			{
				_eng.StartPosition = FormStartPosition.CenterScreen;
				if (_eng.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					_selectedEngineerName = _eng.EngineerName;
					_selectedEngineerId = _eng.EngineerCode;
				}

				switch (_btn.Tag.ToString().ToUpper())
				{
					case "E1":
						this.lbId1.Text = _selectedEngineerId;
						this.lbEng1.Text = _selectedEngineerName;
						break;
					case "E2":
						this.lbId2.Text = _selectedEngineerId;
						this.lbEng2.Text = _selectedEngineerName;
						break;
					case "E3":
						this.lbId3.Text = _selectedEngineerId;
						this.lbEng3.Text = _selectedEngineerName;
						break;
					case "E4":
						this.lbId4.Text = _selectedEngineerId;
						this.lbEng4.Text = _selectedEngineerName;
						break;
				}
			}

			this.UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.AddOrUpdateOrderFixedInfo();
		}
	}
}
