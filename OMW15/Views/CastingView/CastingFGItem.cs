using System;
using System.Data;
using System.Data.Entity.Core;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;
using System.Diagnostics;
using System.Text;
using GAF;
using OMW15.Views.CastingView;

namespace OMW15.Casting.CastingView
{
	public partial class CastingFGItem : Form
	{
		#region class field member

		private JOBINFO _ji;
		private ActionMode _mode = ActionMode.None;
		private string _itemNo = string.Empty;
		private int _itemScore;

		#endregion

		#region class property

		public int CustomerId
		{
			get; set;
		}

		public string CustomerCode
		{
			get; set;
		}

		public int ItemId
		{
			get; set;
		}

		public string ItemPrefix
		{
			get; set;
		}

		public string ItemName
		{
			get; set;
		}

		public int JobId
		{
			get; set;
		}

		public int JobinfoId
		{
			get; set;
		}

		public int FGItemId
		{
			get; set;
		}

		public string GroupCode
		{
			get; set;
		}

		public int MaterialId
		{
			get; set;
		}

		public string MaterialName
		{
			get; set;
		}

		public string Unit
		{
			get; set;
		}

		#endregion


		// CONSTRUCTOR
		public CastingFGItem()
		{
			InitializeComponent();
		}

		private void CastingFGItem_Load(object sender, EventArgs e)
		{
			CenterToParent();

			_mode = JobinfoId == 0 ? ActionMode.Add : ActionMode.Edit;
			//_om = new OLDMOONEF();

			// display header
			lbHeader.Text = $"หมายเลขใบงาน :: {JobId}";
			lbGroup.Text = $"{GroupCode}-[{JobinfoId}]";
			lbMode.Text = _mode.ToString();
			lbCustInfo.Text = $"{this.CustomerId} :: {this.CustomerCode}";

			switch (_mode)
			{
				case ActionMode.Add:
					SetNewJobInfoRecordUI();
					break;
				case ActionMode.Edit:
					GetJobInfoItem(JobinfoId);
					break;
			}

			// update-UI
			UpdateUI();
		}

		private void btnFinishDate_ButtonClick(object sender, EventArgs e)
		{
			btnFinishDate.SelectedDate = txtFinishDate.Text.IsDate() ? Convert.ToDateTime(txtFinishDate.Text) : DateTime.Today;
		}

		private void txtQty_TextChanged(object sender, EventArgs e)
		{
			CalQtyAndScore();
		}

		private void btnWorker_Click(object sender, EventArgs e)
		{
			using (var worker = new CastingWorker())
			{
				if (worker.ShowDialog(this) == DialogResult.OK)
				{
					txtOperator.Text = worker.Name;
					txtOperator.Tag = worker.id;
					return;
				}

				txtOperator.Text = "";
				txtOperator.Tag = 0;
			}
		}

		private void txtTotalWeight_TextChanged(object sender, EventArgs e)
		{
			CalAVgWeight();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			// add or edit job information as giving data
			UpdateJobInfo(JobinfoId);
		}

		private void btnFinishDate_DateSelected(object sender, EventArgs e)
		{
			DateTime _selectWorkingDate = btnFinishDate.SelectedDate;

			if (_selectWorkingDate.IsDate())
			{
				if (_selectWorkingDate.DayOfWeek == DayOfWeek.Sunday)
				{
					Controllers.ToolController.Alert.DisplayAlert("ข้อความ", " ***** วันที่ท่านเลือกเป็นวันอาทิตย์ *****");
				}

				txtFinishDate.Text = _selectWorkingDate.ToShortDateString();
			}
			else
			{
				if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
				{
					Controllers.ToolController.Alert.DisplayAlert("ข้อความ", " ***** วันที่ท่านเลือกเป็นวันอาทิตย์ *****");
				}

				txtFinishDate.Text = DateTime.Today.ToShortDateString();
			}
		}

		private void txtFinishDate_TextChanged(object sender, EventArgs e)
		{
			//if (OMUtils.IsDate(txtFinishDate.Text))
			//{
			//	var _d = txtFinishDate.Text.ToDateTime();

			//	if (_d.DayOfWeek == DayOfWeek.Sunday)
			//		MessageBox.Show("วันที่เลือกเป็นวันอาทิตย์ !!!!!", "ข้อความ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			//}

			//UpdateUI();
		}

		private void txtOperator_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		#region class helper

		private void UpdateUI()
		{
			if (GroupCode == "BLOCK" || GroupCode == "FG" || GroupCode == "RESIN")
			{
				btnSave.Enabled = (!string.IsNullOrEmpty(this.txtOperator.Text)
								  && Convert.ToDecimal(this.txtTotalWeight.Text) > 0.00m
								  && Convert.ToDecimal(this.txtGoodQty.Text) > 0.00m);
			}
			else
			{
				btnSave.Enabled = !string.IsNullOrEmpty(this.txtOperator.Text);
			}
		} // end UpdateUI

		private void CalQtyAndScore()
		{
			try
			{
				decimal _goodQty = Convert.ToDecimal(txtGoodQty.Text);
				decimal _totalQty = Convert.ToDecimal(txtBadQty.Text) + _goodQty;
				int _score = ((int)_goodQty * (int)_itemScore);
				txtTotalQty.Text = $"{_totalQty:N2}";
				txtScore.Text = $"{_score:N0}";
			}
			catch
			{
				txtTotalQty.Text = $"{0:N2}";
				txtScore.Text = $"{0}";
			}

			UpdateUI();

		} // end CalQtyAndScore

		private void CalAVgWeight()
		{
			try
			{
				decimal _q = Convert.ToDecimal(txtGoodQty.Text);
				decimal _w = Convert.ToDecimal(txtTotalWeight.Text);
				decimal _avg = (_w / _q);
				txtAvgWeight.Text = $"{_avg:N2}";
			}
			catch
			{
				txtAvgWeight.Text = $"{0:N2}";
			}

			UpdateUI();

		} //  end CalAVgWeight

		private void GetJobInfoItem(int JobInfoItemId)
		{
			var _itmNo = string.Empty;
			var _itmName = string.Empty;

			var cp = new PriceListDAL().GetCustomerPriceListItemInfo(ItemId);
			_itmNo = cp.ITEMNO;
			_itmName = cp.ITEMNAME;
			_itemScore = (int)cp.SCOREPRICE;

			// get JobItem Information
			_ji = new JobDAL().GetJobInfoItem(JobInfoItemId);


			txtPrefix.Text = ItemPrefix;
			txtItemNo.Text = string.IsNullOrEmpty(_ji.ITEMNO) ? _itmNo : _ji.ITEMNO;
			txtItemName.Text = string.IsNullOrEmpty(ItemName) ? _itmName : ItemName;
			txtFinishDate.Text = _ji.FINISHDATE.Num2Date().ToShortDateString();
			txtGoodQty.Text = $"{_ji.ACCEPTQTY:N2}";
			txtScore.Text = $"{_ji.GOODSCORE:N2}";
			txtBadQty.Text = $"{_ji.REJECTQTY:N2}";
			txtTotalQty.Text = $"{_ji.TOTALQTY:N2}";
			txtTotalWeight.Text = $"{_ji.TOTALWEIGHT:N2}";
			txtAvgWeight.Text = $"{_ji.AVGWEIGHT:N2}";
			cbxError.SelectedValue = _ji.ERRORID;
			txtOperator.Tag = _ji.OPERATORID.Value;
			txtOperator.Text = _ji.OPERATORNAME;
			txtFlaskTemp.Text = _ji.FLASK_TEMP;
			txtCastTemp.Text = _ji.CAST_TEMP;

			this.lbUnit.Text = this.Unit;
			this.lbMaterial.Text = $"{this.MaterialId} : {this.MaterialName}";

		} // end GetJobInfoItem

		private void SetNewJobInfoRecordUI()
		{
			var cp = new PriceListDAL().GetCustomerPriceListItemInfo(ItemId);

			var _itmName = cp.ITEMNAME;
			_itemNo = cp.ITEMNO;
			_itemScore = (int)cp.SCOREPRICE;

			// binding data to control
			_ji = new JOBINFO();
			_ji.ITEMPREFIX = ItemPrefix;
			_ji.ITEMNO = _itemNo;

			_ji.JOBNO = this.JobId;
			txtPrefix.Text = $"{_ji.ITEMPREFIX}";
			txtItemNo.Text = $"{_ji.ITEMNO}";
			txtItemName.Text = string.IsNullOrEmpty(ItemName) ? ItemName : ItemName;
			txtFinishDate.Text = DateTime.Today.ToShortDateString();
			txtFlaskTemp.Text = "0";
			txtCastTemp.Text = "0";
			this.lbUnit.Text = this.Unit;
			this.lbMaterial.Text = $"{this.MaterialId} : {this.MaterialName}";


			UpdateUI();

		} // end SetNewJobInfoRecordUI

		private void UpdateJobInfo(int JobInfoItemId)
		{
			try
			{
				switch (_mode)
				{
					case ActionMode.Add:
						_ji.ISDELETE = false;
						_ji.FGLINESEQ = 0;
						_ji.AUDITUSER = omglobal.UserInfo;
						break;
					case ActionMode.Edit:
						break;
				}

				_ji.JOBNO = this.JobId;
				_ji.CUSTID = this.CustomerId;
				_ji.CUSTCODE = this.CustomerCode;
				_ji.FINISHDATE = txtFinishDate.Text.Date2Num();
				_ji.FISCPERIOD = Convert.ToDateTime(txtFinishDate.Text).Month;
				_ji.FISCYEAR = Convert.ToDateTime(txtFinishDate.Text).Year;
				_ji.GROUPCODE = GroupCode;
				_ji.ITEMID = ItemId;
				_ji.ITEMPREFIX = ItemPrefix;
				_ji.ITEMNO = txtItemNo.Text;
				_ji.MATERIALID = MaterialId;
				_ji.OPERATORID = Convert.ToInt32(txtOperator.Tag.ToString());
				_ji.OPERATORNAME = txtOperator.Text;
				_ji.CAST_TEMP = txtCastTemp.Text;
				_ji.FLASK_TEMP = txtFlaskTemp.Text;
				_ji.ACCEPTQTY = Convert.ToDecimal(txtGoodQty.Text);
				_ji.GOODSCORE = Convert.ToDecimal(txtScore.Text);
				_ji.REJECTQTY = Convert.ToDecimal(txtBadQty.Text);
				_ji.ERRORID = Convert.ToInt32(cbxError.SelectedValue);
				_ji.TOTALQTY = Convert.ToDecimal(txtTotalQty.Text);
				_ji.TOTALWEIGHT = Convert.ToDecimal(txtTotalWeight.Text);
				_ji.AVGWEIGHT = Convert.ToDecimal(txtAvgWeight.Text);

				_ji.RECORDDATE = DateTime.Today;
				_ji.RECORDEDBY = omglobal.UserInfo;
				_ji.MODIDATE = DateTime.Today;
				_ji.MODIUSER = omglobal.UserInfo;

				// find the method
				if ((new JobDAL().UpdateJobInfoItem(_ji) > 0))
				{
					// log file
					FGLogInfo _log = new FGLogInfo();
					_log.action = $"{ _mode.ToString()}";
					_log.logdate = DateTime.Now;
					_log.modulename = "JobInfo";
					_log.partname = this.txtItemName.Text;
					_log.partno = this.txtItemNo.Text;
					_log.qty = decimal.Parse(this.txtGoodQty.Text);
					_log.recordid = JobinfoId;
					_log.jobno = this.JobId;
					_log.type = this.GroupCode;
					_log.unit = this.Unit;
					_log.woker = omglobal.UserName;
					_log.workstation = omglobal.WorkStation;
					_log.material = this.lbMaterial.Text;
					_log.matweight = decimal.Parse(this.txtTotalWeight.Text);
				   
					// insert FG-log
					new JobDAL().saveFGLog(_log);

					// end log 

					if (GroupCode == "FG" || GroupCode == "BLOCK" || GroupCode == "RESIN")
					{
						var _result = 0;
						if ((_result = new JobDAL().UpdateFGSByFinishQty(JobId, GroupCode)) > 0)
						{
							Alert.DisplayAlert("ปรับปรุงรายการของสต็อกสินค้าแล้ว (FG-STOCK)",
							  $"ปรับปรุงรายการของสต็อกสินค้าจำนวน {_result} รายการ เรียบร้อยแล้ว");
						}
					}
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("มีความผิดพลาดเกิดขึ้นในระหว่างการปรับปรุงข้อมูล....", ex);
			}
		} // end UpdateJobInfo

		#endregion
	}
}