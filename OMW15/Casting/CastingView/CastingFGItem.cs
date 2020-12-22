using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;

namespace OMW15.Casting.CastingView
{
	public partial class CastingFGItem : Form
	{
		#region class field member
		private OLDMOONEF _om;
		private JOBINFO _ji;

		private ActionMode _mode = ActionMode.None;
		private string _customerCode = string.Empty;
		private string _groupCode = string.Empty;
		private string _itemNo = string.Empty;
		private string _itemName = string.Empty;
		private int _jobId = 0;
		private int _jobInfoId = 0;
		private int _fgItemId = 0;
		private int _customerId = 0;
		private int _itemId = 0;
		private int _materialId = 0;
		private int _itemScore = 0;

		#endregion

		#region class property

		public int CustomerId
		{
			set
			{
				_customerId = value;
			}
		}

		public string CustomerCode
		{
			set
			{
				_customerCode = value;
			}
		}

		public int ItemId
		{
			set
			{
				_itemId = value;
			}
		}

		public string ItemPrefix
		{
			get;
			set;
		}

		public string ItemName
		{
			set
			{
				_itemName = value;
			}
		}

		public int JobId
		{
			set
			{
				_jobId = value;
			}
		}

		public int JobinfoId
		{
			set
			{
				_jobInfoId = value;
			}
		}

		public int FGItemId
		{
			set
			{
				_fgItemId = value;
			}
		}

		public string GroupCode
		{
			set
			{
				_groupCode = value;
			}
		}

		public int MaterialId
		{
			set
			{
				_materialId = value;
			}
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.btnSave.Enabled = !string.IsNullOrEmpty(this.txtOperator.Text);
		
		} // end UpdateUI

		private void CalQtyAndScore()
		{
			try
			{
				decimal _goodQty = Convert.ToDecimal(this.txtGoodQty.Text);
				decimal _totalQty = (Convert.ToDecimal(this.txtBadQty.Text) + _goodQty);
				this.txtTotalQty.Text = string.Format("{0:N2}", _totalQty);
				this.txtScore.Text = string.Format("{0}", _goodQty * _itemScore);
			}
			catch
			{
				this.txtTotalQty.Text = string.Format("{0:N2}", 0);
				this.txtScore.Text = string.Format("{0}", 0);
			}

			this.UpdateUI();

		} // end CalQtyAndScore

		private void CalAVgWeight()
		{
			try
			{
				decimal _q = Convert.ToDecimal(this.txtGoodQty.Text);
				decimal _w = Convert.ToDecimal(this.txtTotalWeight.Text);
				decimal _avg = _w / _q;
				this.txtAvgWeight.Text = string.Format("{0:N2}", _avg);
			}
			catch
			{
				this.txtAvgWeight.Text = string.Format("{0:N2}", 0);
			}

			this.UpdateUI();

		} //  end CalAVgWeight

		private void GetJobInfoItem(int JobInfoItemId)
		{
			string _itmNo = string.Empty;
			string _itmName = string.Empty;

			CUSTPRICELIST cp = new Casting.CastingController.PriceListDAL().GetCustomerPriceListItemInfo(_itemId);
			_itmNo = cp.ITEMNO;
			_itmName = cp.ITEMNAME;
			_itemScore = (int)cp.SCOREPRICE;

			// get JobItem Information
			_ji = new OMW15.Casting.CastingController.JobDAL().GetJobInfoItem(JobInfoItemId);

			//_itemPrefix = _ji.ITEMPREFIX;
			this.txtPrefix.Text = this.ItemPrefix;
			this.txtItemNo.Text = string.IsNullOrEmpty(_ji.ITEMNO) ? _itmNo : _ji.ITEMNO;
			this.txtItemName.Text = string.IsNullOrEmpty(_itemName) ? _itmName : _itemName;
			this.txtFinishDate.Text = OMControls.OMUtils.Num2Date(_ji.FINISHDATE).ToShortDateString();
			this.txtGoodQty.Text = string.Format("{0:N2}", _ji.ACCEPTQTY);
			this.txtScore.Text = string.Format("{0:N2}", _ji.GOODSCORE);
			this.txtBadQty.Text = string.Format("{0:N2}", _ji.REJECTQTY);
			this.txtTotalQty.Text = string.Format("{0:N2}", _ji.TOTALQTY);
			this.txtTotalWeight.Text = string.Format("{0:N2}", _ji.TOTALWEIGHT);
			this.txtAvgWeight.Text = string.Format("{0:N2}", _ji.AVGWEIGHT);
			this.cbxError.SelectedValue = _ji.ERRORID;
			this.txtOperator.Tag = _ji.OPERATORID.Value;
			this.txtOperator.Text = _ji.OPERATORNAME;

		} // end GetJobInfoItem

		private void SetNewJobInfoRecordUI()
		{
			CUSTPRICELIST cp = new Casting.CastingController.PriceListDAL().GetCustomerPriceListItemInfo(_itemId);

			string _itmName = cp.ITEMNAME;
			//_itemPrefix = cp.PREFIX;
			_itemNo = cp.ITEMNO;
			_itemScore = (int)cp.SCOREPRICE;

			// binding data to control
			_ji = new JOBINFO();
			_ji.ITEMPREFIX = this.ItemPrefix;
			_ji.ITEMNO = _itemNo;

			this.txtPrefix.Text = string.Format("{0}", _ji.ITEMPREFIX);
			this.txtItemNo.Text = string.Format("{0}", _ji.ITEMNO);
			this.txtItemName.Text = (string.IsNullOrEmpty(_itemName) ? _itmName : _itemName);
			this.txtFinishDate.Text = DateTime.Today.ToShortDateString();

			this.UpdateUI();

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
						_ji.AUDITUSER = omglobal.UserName;
						break;
					case ActionMode.Edit:
						break;
				}

				_ji.JOBNO = _jobId;
				_ji.CUSTID = _customerId;
				_ji.CUSTCODE = _customerCode;
				_ji.FINISHDATE = OMControls.OMUtils.Date2Num(this.txtFinishDate.Text);
				_ji.FISCPERIOD = Convert.ToDateTime(this.txtFinishDate.Text).Month;
				_ji.FISCYEAR = Convert.ToDateTime(this.txtFinishDate.Text).Year;
				_ji.GROUPCODE = _groupCode;
				_ji.ITEMID = _itemId;
				_ji.ITEMPREFIX = this.ItemPrefix;
				_ji.ITEMNO = this.txtItemNo.Text;
				_ji.MATERIALID = _materialId;
				_ji.OPERATORID = Convert.ToInt32(this.txtOperator.Tag.ToString());
				_ji.OPERATORNAME = this.txtOperator.Text;
				_ji.ACCEPTQTY = Convert.ToDecimal(this.txtGoodQty.Text);
				_ji.GOODSCORE = Convert.ToDecimal(this.txtScore.Text);
				_ji.REJECTQTY = Convert.ToDecimal(this.txtBadQty.Text);
				_ji.ERRORID = Convert.ToInt32(this.cbxError.SelectedValue);
				_ji.TOTALQTY = Convert.ToDecimal(this.txtTotalQty.Text);
				_ji.TOTALWEIGHT = Convert.ToDecimal(this.txtTotalWeight.Text);
				_ji.AVGWEIGHT = Convert.ToDecimal(this.txtAvgWeight.Text);

				_ji.RECORDDATE = DateTime.Today;
				_ji.RECORDEDBY = omglobal.UserName;
				_ji.MODIDATE = DateTime.Today;
				_ji.MODIUSER = omglobal.UserName;

				if (new Casting.CastingController.CastingFG().UpdateFGItem(_ji) > 0)
				{
					omglobal.DisplayAlert("Update", "ปรับปรุงข้อมูลเรียบร้อยแล้ว");
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("มีความผิดพลาดเกิดขึ้นในระหว่างการปรับปรุงข้อมูล....", ex);
			}

		} // end UpdateJobInfo

		private void SaveFGStock(int JobNo, string Group)
		{
			int _result = new Casting.CastingController.JobDAL().UpdateFGSByFinishQty(JobNo, Group);

			if (_result > 0)
			{
				omglobal.DisplayAlert("ปรับปรุงรายการของสต็อกสินค้าแล้ว (FG-STOCK)", string.Format("ปรับปรุงรายการของสต็อกสินค้าจำนวน {0} รายการ เรียบร้อยแล้ว", _result));
			}

		} // end SaveFGStock

		#endregion


		public CastingFGItem()
		{
			InitializeComponent();
		}

		private void CastingFGItem_Load(object sender, EventArgs e)
		{
			_mode = (_jobInfoId == 0 ? ActionMode.Add : ActionMode.Edit);
			_om = new OLDMOONEF();

			// display header
			this.lbHeader.Text = string.Format("หมายเลขใบงาน :: {0}", _jobId);
			this.lbGroup.Text = string.Format("{0}-[{1}]", _groupCode, _jobInfoId);
			this.lbMode.Text = _mode.ToString();

			switch (_mode)
			{
				case ActionMode.Add:
					this.SetNewJobInfoRecordUI();
					break;
				case ActionMode.Edit:
					this.GetJobInfoItem(_jobInfoId);
					break;
			}

			// update-UI
			this.UpdateUI();
		}

		private void btnFinishDate_ButtonClick(object sender, EventArgs e)
		{
			this.btnFinishDate.SelectedDate = OMControls.OMUtils.IsDate(this.txtFinishDate.Text) ? Convert.ToDateTime(this.txtFinishDate.Text) : DateTime.Today;
		}

		private void txtQty_TextChanged(object sender, EventArgs e)
		{
			this.CalQtyAndScore();
		}

		private void btnWorker_Click(object sender, EventArgs e)
		{
			string _name = this.txtOperator.Text;
			string _code = string.Empty;
			int _id = ((this.txtOperator.Tag == null) ? 0 : Convert.ToInt32(this.txtOperator.Tag.ToString()));
			Tools.SelectOptions.GetData(SelectTypeOption.Worker2, ref _name, ref _code, ref _id);
			this.txtOperator.Text = _name;
			this.txtOperator.Tag = _id;

		}

		private void txtTotalWeight_TextChanged(object sender, EventArgs e)
		{
			this.CalAVgWeight();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			// add or edit job information as giving data
			this.UpdateJobInfo(_jobInfoId);

			// save FGStock 
			if ((_groupCode == "FG") || (_groupCode == "BLOCK"))
			{
				this.SaveFGStock(_jobId, _groupCode);
			}
		}

		private void btnFinishDate_DateSelected(object sender, EventArgs e)
		{
			this.txtFinishDate.Text = OMControls.OMUtils.IsDate(this.btnFinishDate.SelectedDate) ? this.btnFinishDate.SelectedDate.ToShortDateString() : DateTime.Today.ToShortDateString();
		}

		private void txtFinishDate_TextChanged(object sender, EventArgs e)
		{
			if (OMControls.OMUtils.IsDate(this.txtFinishDate.Text))
			{
				DateTime _d = Convert.ToDateTime(this.txtFinishDate.Text);

				if (_d.DayOfWeek == DayOfWeek.Sunday)
				{
					MessageBox.Show("วันที่เลือกเป็นวันอาทิตย์ !!!!!", "ข้อความ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}

			this.UpdateUI();
		}

		private void txtOperator_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void CastingFGItem_FormClosing(object sender, FormClosingEventArgs e)
		{
			_om.Dispose();
		}
	}
}
