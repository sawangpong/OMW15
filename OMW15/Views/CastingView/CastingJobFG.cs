using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using OMControls;
using OMW15.Casting.CastingView;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Models.CustomerModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class CastingJobFG : Form
	{
		#region class field member

		private JOBORDER _job = new JOBORDER();
		private string _customerName = string.Empty;
		private string _customerCode = string.Empty;
		private string _selectedGroupCode = string.Empty;
		private int _jobStatus = 0;
		private int _jobId = 0;
		private int _customerId = 0;
		private int _materialId = 0;
		private int _selectedJobInfoItemId = 0;
		private int _selectedJobFGItemId = 0;

		#endregion

		public CastingJobFG()
		{
			InitializeComponent();
			pnlHeader.BackColor = omglobal.OM_ORANGE_COLOR;
		}

		private void CastingJobFG_Load(object sender, EventArgs e)
		{
			CenterToParent();
			// initial variable value
			_selectedGroupCode = string.Empty;
			_selectedJobFGItemId = 0;
			_selectedJobInfoItemId = 0;

			// setting data grid view
			OMUtils.SettingDataGridView(ref dgv);

			// display info
			lbCustomer.Text = $"{_customerCode} :: {_customerName}  :: {_customerId}";
			txtJobNo.Text = $"{(_jobId > 0 ? _jobId.ToString() : "")}";

			// find job-info
			if (_jobId > 0)
			{
				btnFindJob.PerformClick();
			}

			UpdateUI();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			string _group = "FG";

			// define for group from item-no for update
			switch (lbPrefix.Text)
			{
				case "P": // Print resin
					_group = "RESIN";
					break;

				case "R": // ฉีด / หล่อ
				case "S": // ให้เทียน
				case "W": // หล่อ wax
					_group = "FG";
					break;
				case "M": // ทำก้อนยาง
				case "L": // ทำก้อนใส
					_group = "BLOCK";
					break;
			}

			// update - all pending process for job orders
			if (new JobDAL().UpdateJobOrdersStatusByFinishQty(_jobId, _group) > 0)
				Alert.DisplayAlert(" ปรับปรุงข้อมูล",
					$" ปรับปรุงข้อมูล ของหมายเลขใบงาน ที่ :: {_jobId} เรียบร้อยแล้ว");

			// Close this form
			Close();
		}

		decimal _requiredQtyForDelete = 0;

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedJobInfoItemId = Convert.ToInt32(dgv["LINESEQ", e.RowIndex].Value);
			_selectedJobFGItemId = Convert.ToInt32(dgv["FGLINESEQ", e.RowIndex].Value);
			_requiredQtyForDelete = Convert.ToDecimal(dgv["ACCEPTQTY", e.RowIndex].Value);

			// check for deletable of not
			// (if selected item was taken from FG-Stock for delevered to customer 
			// it is not available for deletion.

			if ((_selectedGroupCode == "FG") || (_selectedGroupCode == "BLOCK") || ( _selectedGroupCode == "RESIN"))
			{
				//string _groupCode = _selectedGroupCode == "FG" ? "QC-FG" : "QC-BLOCK";
				string _groupCode = "QC-FG";
				switch (_selectedGroupCode)
				{
					case "FG":
						_groupCode = "QC-FG";
						break;

					case "BLOCK":
						_groupCode = "QC-BLOCK";
						break;

					case "RESIN":
						_groupCode = "QC-RESIN";
						break;
				}


				// finding 
				bool _findRecordDelivered = new JobDAL().findRecordWasDelivered(int.Parse(this.txtJobNo.Text), _groupCode);

				//DataTable _dt = new JobDAL().findEditableRecord(int.Parse(this.txtJobNo.Text), _groupCode);

				this.tsbtnDelete.Enabled = !_findRecordDelivered;
				//this.tsbtnEdit.Enabled = this.tsbtnDelete.Enabled;
			}

			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetJobFG(_jobId, _selectedGroupCode);
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			// step through for deleting record from JobInfo and FG-stock
			// 1. Check the Infomation code (FG, WAX etc)
			// 2. if information is not from "FG", delete the record from JobInfos table
			// 3. if information is "FG", do the following
			// 4. check the information from FG-Stock is able to delete the record.
			//    by the delivery-qty from the FG-Stock is active (more than zero (0))
			// 5. if, FG-Stock had taken to delivered Alert "CANNOT DELETE RECODE"
			// 6. otherwise, update (-) qty from FG-STOCK
			// 7. delete record from JobInfos table
			//

			// Main delete process
			if (
				MessageBox.Show("ต้องการลบรายการที่เลือก ใช่หรือไม่?", "Delete Record", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				int _result = 0;

				if (_selectedGroupCode == "FG" || _selectedGroupCode == "BLOCK" || _selectedGroupCode == "RESIN")
				{
					// checking Group for delete
					string _fgGroupCode = "";

					switch (_selectedGroupCode)
					{
						case "BLOCK":
							_fgGroupCode = "QC-BLOCK";
							break;

						case "FG":
							_fgGroupCode = "QC-FG";
							break;

						case "RESIN":
							_fgGroupCode = "QC-RESIN";
							break;
					}


					//if (_selectedGroupCode == "FG")
					//{
					//	_fgGroupCode = "QC-FG";
					//}
					//else if (_selectedGroupCode == "BLOCK")
					//{
					//	_fgGroupCode = "QC-BLOCK";
					//}


					// check remaining qty in case of FG-STOCK 
					decimal _remainFGQty = new JobDAL().findRemainFGQty(int.Parse(this.txtJobNo.Text), _fgGroupCode);


					if (_remainFGQty < _requiredQtyForDelete)
					{
						MessageBox.Show("รายการที่เลือกไม่สามารถลบได้! \nเนื่องจากได้นำไปใช้ในรายการส่งสินค้าแล้ว", "Delete",
							MessageBoxButtons.OK, MessageBoxIcon.Warning);

						return;
					}

					_result = new JobDAL().updateFGStockForDeletionJobInfoRecord(_jobId, _selectedGroupCode, _selectedJobInfoItemId);
				}
				else
				{
					_result = new JobDAL().removeRecordForJobInfo(_selectedJobInfoItemId);

				}

				// Show message after delete complete....
				if (_result > 0)
				{
					MessageBox.Show("ลบรายการที่เลือกเรียบร้อยแล้ว", "Message",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}

			GetJobInfoProgress(_jobId, Convert.ToDecimal(lbOrderQty.Text));
			tsbtnRefresh.PerformClick();

		} // end delete

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			AddEditJobInfoItem(_jobId, _selectedJobInfoItemId);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedJobInfoItemId = 0;
			AddEditJobInfoItem(_jobId, _selectedJobInfoItemId);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void btnFindJob_Click(object sender, EventArgs e)
		{
			// get job-info
			try
			{
				GetJobInfo(Convert.ToInt32(txtJobNo.Text));
			}
			catch
			{
				txtJobNo.Text = string.Empty;
				txtJobNo.Focus();
			}
		}

		private void txtJobNo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnFindJob.PerformClick();
			}
		}

		#region class property

		public int JobId
		{
			set
			{
				_jobId = value;
			}
		}

		public string CustomerCode
		{
			set
			{
				_customerCode = value;
			}
		}

		public int CustomerId
		{
			set
			{
				_customerId = value;
			}
		}

		public string CustomerName
		{
			set
			{
				_customerName = value;
			}
		}

		public Image ItemImage
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

		#endregion

		#region class helper

		private void UpdateUI()
		{
			if (string.IsNullOrEmpty(_selectedGroupCode))
			{
				tsbtnAdd.Enabled = false;
				tsbtnEdit.Enabled = tsbtnAdd.Enabled;
				tsbtnDelete.Enabled = tsbtnAdd.Enabled;
				tsbtnRefresh.Enabled = tsbtnAdd.Enabled;
			}
			else
			{
				tsbtnAdd.Enabled = true;
				tsbtnEdit.Enabled = _selectedJobInfoItemId > 0;
				tsbtnDelete.Enabled = tsbtnEdit.Enabled && _selectedJobFGItemId == 0;
				tsbtnRefresh.Enabled = dgv.Rows.Count > 0;
			}

			tslbLineId.Text = $"[ID :: {_selectedJobInfoItemId}]";
			tslbFGId.Text = $"[FG :: {_selectedJobFGItemId}]";

		} // end UpdateUI

		private void CreateFGMenu(string Prefix)
		{
			tsmnuJobFG.DropDownItems.Clear();

			var _btnResin = new ToolStripMenuItem("พิมพ์เรซิ่น");
			_btnResin.Tag = "RESIN";
			_btnResin.Click += mnuGroupSelection;

			var _btnWax = new ToolStripMenuItem("ฉีดเทียน");
			_btnWax.Tag = "WAX";
			_btnWax.Click += mnuGroupSelection;

			var _btnFinishing = new ToolStripMenuItem("แต่งเทียน");
			_btnFinishing.Tag = "FINISHING";
			_btnFinishing.Click += mnuGroupSelection;

			var _btnTree = new ToolStripMenuItem("ติดต้น");
			_btnTree.Tag = "TREE";
			_btnTree.Click += mnuGroupSelection;

			var _btnCasting = new ToolStripMenuItem("หล่องาน");
			_btnCasting.Tag = "FG";
			_btnCasting.Click += mnuGroupSelection;

			var _btnBlock = new ToolStripMenuItem("อัดยาง / ผ่ายาง");
			_btnBlock.Tag = "BLOCK";
			_btnBlock.Click += mnuGroupSelection;

			// create menu as the present prefix
			switch (Prefix)
			{
				case "R":
					tsmnuJobFG.DropDownItems.Add(_btnWax);
					tsmnuJobFG.DropDownItems.Add(_btnFinishing);
					tsmnuJobFG.DropDownItems.Add(_btnTree);
					tsmnuJobFG.DropDownItems.Add(_btnCasting);
					break;

				case "P":
					tsmnuJobFG.DropDownItems.Add(_btnResin);
					tsmnuJobFG.DropDownItems.Add(_btnFinishing);
					tsmnuJobFG.DropDownItems.Add(_btnTree);
					tsmnuJobFG.DropDownItems.Add(_btnCasting);
					break;

				case "S":
				case "W":
					tsmnuJobFG.DropDownItems.Add(_btnFinishing);
					tsmnuJobFG.DropDownItems.Add(_btnTree);
					tsmnuJobFG.DropDownItems.Add(_btnCasting);
					break;

				case "L":
				case "M":
					tsmnuJobFG.DropDownItems.Add(_btnBlock);
					break;
			}
		} // end CreateFGMenu

		private void mnuGroupSelection(object sender, EventArgs e)
		{
			var _mnu = sender as ToolStripMenuItem;
			_selectedGroupCode = _mnu.Tag.ToString().ToUpper();

			// re-write menutext
			tsmnuJobFG.Text = $"เลือกงาน :: {_mnu.Text}";
			tslbFGGroup.Text = _selectedGroupCode;
			GetJobFG(_jobId, _selectedGroupCode);
			UpdateUI();

		} // end mnuGroupSelection

		private void GetJobInfoProgress(int JobId, decimal OrderQty)
		{
			var _dt = new JobDAL().GetSummaryJobInfoByGroupCode(JobId);

			if (_dt.Rows.Count > 0)
			{
				foreach (DataRow _dr in _dt.Rows)
				{
					var _group = _dr["KEY"].ToString().ToUpper();
					switch (_group)
					{
						case "BLOCK":
							lbFinishQty.Text = $"{_dr["FG"]:N2}";
							break;

						case "FG":
							lbFinishQty.Text = $"{_dr["FG"]:N2}";
							break;

						case "FINISHING":
							lbWaxFinish.Text = $"{_dr["FG"]:N2}";
							break;

						case "RESIN":
							lbFinishQty.Text = $"{_dr["FG"]:N2}";
							break;

						case "TREE":
							lbWaxTree.Text = $"{_dr["FG"]:N2}";
							break;

					  case "WAX":
							lbWaxQty.Text = $"{_dr["FG"]:N2}";
							break;
					}
				}

				decimal _orderQty = (OrderQty == 0.00m ? 1.00m : OrderQty);

				lbFGProgress.Text = $"{Convert.ToDecimal(lbFinishQty.Text) / _orderQty:P2}";
				lbBackOrderQty.Text = $"{OrderQty - Convert.ToDecimal(lbFinishQty.Text):N2}";
				lbWaxProgress.Text = $"{Convert.ToDecimal(lbWaxQty.Text) / _orderQty:P2}";
				lbFinishingProgress.Text = $"{Convert.ToDecimal(lbWaxFinish.Text) / _orderQty:P2}";
				lbTreeProgress.Text = $"{Convert.ToDecimal(lbWaxTree.Text) / _orderQty:P2}";
			}
			else
			{
				lbWaxFinish.Text = "0.00";
				lbWaxQty.Text = "0.00";
				lbWaxTree.Text = "0.00";
				lbFinishQty.Text = "0.00";
				lbBackOrderQty.Text = "0.00";
				lbFGProgress.Text = "0.00%";
				lbWaxProgress.Text = "0.00%";
				lbFinishingProgress.Text = "0.00%";
				lbTreeProgress.Text = "0.00%";
			}
		} // end GetJobInfoProgress

		private void GetCustomerInfo(string customerCode)
		{
			var c = new CustomerDAL().GetLocalCustomerRecord(customerCode);

			_customerCode = c.CUSTCODE;
			_customerId = c.CUSTID;
			_customerName = c.CUSTNAME;

			// display customer infos
			lbCustomer.Text = $"{c.CUSTCODE}::{c.CUSTNAME}";

		} // end GetCustomerInfo

		private JOBORDER GetJobData(int jobId)
		{
			var _j = new JobDAL().GetJobHeaderInfo(jobId);
			try
			{
				if (_j == null)
				{
					MessageBox.Show("Job not found ......", "JOB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtJobNo.Text = "";
					txtJobNo.Focus();
					return null;
				}
				return _j;
			}
			catch
			{
				return null;
			}
		} // end GetJobData


		private void GetJobInfo(int JobId)
		{
			// job - header
			var _orderQty = 0.00m;

			// clear all contents of datagridview
			dgv.DataSource = null;

			// retrieve data
			_job = GetJobData(JobId);

			// map data to object
			if (_job != null)
			{
				_jobId = _job.JOBNO;
				_jobStatus = _job.STATUS;
				_materialId = _job.MATERIALTYPE;
				_orderQty = _job.ORDERQTY;
				ItemId = _job.ITEMID.Value;

				lbPrefix.Text = $"{_job.PREFIX}";
				lbItemNo.Text = _job.ITEMNO;
				lbItemName.Text = _job.ITEMNAME;
				lbMaterial.Text = new MaterialDAL().GetMaterialNameById(_job.MATERIALTYPE);
				lbUnit.Text = _job.ORDERUNIT;
				lbOrderQty.Text = $"{_orderQty}";
				lbBackOrderQty.Text = $"{_job.BACKORDQTY.Value:N2}";

				lbStatus.Text = $"[{Enum.GetName(typeof(OMShareJobEnums.JobStatusEnumEN), _job.STATUS)}]";

				// get customer info
				GetCustomerInfo(_job.CUSTCODE);

				// get item-picture
				pic.Image = new PriceListDAL().GetItemPicture(_job.ITEMID.Value);

				// create menu as of giving item-code
				CreateFGMenu(_job.PREFIX);

				// jobinfo - FG info
				GetJobInfoProgress(JobId, _orderQty);
			}
			else
			{
				_jobId = 0;
				_jobStatus = 0;
				_materialId = 0;
				_orderQty = 0.00m;

				lbPrefix.Text = "";
				lbItemNo.Text = "";
				lbItemName.Text = "";
				lbMaterial.Text = "";
				lbUnit.Text = "";
				lbOrderQty.Text = "0.00";
				lbBackOrderQty.Text = "0.00";
				lbStatus.Text = "";

				// get customer info
				lbCustomer.Text = "";

				// get item-picture
				pic.Image = null;
				lbAvgWT.Text = "";
				lbFGProgress.Text = "0.00%";
				lbFinishQty.Text = "0.00";
				lbFinishingProgress.Text = "0.00%";
				lbWaxProgress.Text = "0.00%";
				lbTreeProgress.Text = "0.00%";
				lbWaxQty.Text = "0.00";
				lbWaxFinish.Text = "0.00";
				lbWaxTree.Text = "0.00";

				dgv.DataSource = null;
			}

			UpdateUI();
		} // end GetJobInfo

		private void GetJobFG(int JobId, string FGCode)
		{
			dgv.SuspendLayout();

			//var _job = new JobDAL();
			//var _dt = await _job.GetJobInfoByGroupCodeAsync(JobId, FGCode);
			// loading data
			// new JobDAL().GetJobInfoByGroupCodeAsync(JobId, FGCode);

			var _dt = new JobDAL().GetJobInfoByGroupCode(JobId, FGCode, omglobal.SysConnectionString);
			dgv.DataSource = _dt;

			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if (dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
			}

			// formatting - DataGridView
			dgv.Columns["LINESEQ"].Visible = false;
			dgv.Columns["FGLINESEQ"].Visible = false;
			dgv.Columns["ITEMID"].Visible = false;
			dgv.Columns["ITEMPREFIX"].Visible = false;
			dgv.Columns["GROUPCODE"].Visible = false;
			dgv.Columns["FLASK_TEMP"].Visible = FGCode == "FG" ? true : false;
			dgv.Columns["CAST_TEMP"].Visible = FGCode == "FG" ? true : false;

			dgv.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			dgv.Columns["OPERATORNAME"].HeaderText = "ผู้ปฏิบัติงาน";
			dgv.Columns["FINISHDATE"].HeaderText = "วันที่เสร็จ";
			dgv.Columns["ACCEPTQTY"].HeaderText = "ชิ้นงานดี";
			dgv.Columns["REJECTQTY"].HeaderText = "ชิ้นงานเสีย";
			dgv.Columns["TOTALQTY"].HeaderText = "ชิ้นงานรวม";
			dgv.Columns["TOTALWEIGHT"].HeaderText = "น้ำหนักรวม (กรัม)";
			dgv.Columns["AVGWEIGHT"].HeaderText = "น้ำหนักเฉลี่ย (กรัม)";
			dgv.Columns["FLASK_TEMP"].HeaderText = "อุณหภูมิเบ้า";
			dgv.Columns["CAST_TEMP"].HeaderText = "อุณหภูมิหล่อ";

			dgv.ResumeLayout();
			UpdateUI();

			DisplayStatInfo();

			if (dgv.Rows.Count == 0)
			{
				_selectedJobInfoItemId = 0;
				_selectedJobFGItemId = 0;
			}
		} // end GetJobFG

		private void DisplayStatInfo()
		{
			if (dgv.Rows.Count > 0)
			{
				var _dt = (DataTable)dgv.DataSource;
				var _totalWT = _dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTALWEIGHT"));
				var _avgWT = _dt.AsEnumerable().Average(x => x.Field<decimal>("AVGWEIGHT"));

				lbTotalWT.Text = $"total wt : {_totalWT:N2} g";
				lbAvgWT.Text = $"Avg wt : {_avgWT:N2} g/{lbUnit.Text}";
				lbRowCount.Text = $"row : {dgv.Rows.Count}";
			}
		} // end DisplayStatInfo

		private void AddEditJobInfoItem(int JobNo, int JobInfoItemId)
		{
			// in case of want to edit recode must be 
			// looking that record was issue to SaleOrder or not
			// if, the record was issued must be alert to user
			var _isEditable = true;

			if (JobInfoItemId > 0 
				&& (_selectedGroupCode == "FG" || _selectedGroupCode == "RESIN" || _selectedGroupCode == "BLOCK"))
			{
				//_isEditable = new CastingSaleOrderDAL().FindJobItemWasIssueToSaleOrderItem(JobNo);

				if (_isEditable == true)
					using (var _fgItem = new CastingFGItem())
					{
						_fgItem.JobId = JobNo;
						_fgItem.JobinfoId = JobInfoItemId;
						_fgItem.FGItemId = _selectedJobFGItemId;
						_fgItem.GroupCode = _selectedGroupCode;
						_fgItem.CustomerCode = _customerCode;
						_fgItem.CustomerId = _customerId;
						_fgItem.ItemId = ItemId;
						_fgItem.ItemPrefix = lbPrefix.Text;
						_fgItem.ItemName = lbItemName.Text;
						_fgItem.MaterialId = _materialId;
						_fgItem.MaterialName = this.lbMaterial.Text;
						_fgItem.Unit = this.lbUnit.Text;
						_fgItem.StartPosition = FormStartPosition.CenterParent;
						_fgItem.ShowDialog(this);
					}
				else
				{
					MessageBox.Show("รายการที่เลือกไม่สามารถแก้ไขได้! \nเนื่องจากได้นำไปใช้ในรายการส่งสินค้าแล้ว", "Message",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				using (var _fgItem = new CastingFGItem())
				{
					_fgItem.JobId = _jobId;
					_fgItem.JobinfoId = JobInfoItemId;
					_fgItem.FGItemId = _selectedJobFGItemId;
					_fgItem.GroupCode = _selectedGroupCode;
					_fgItem.CustomerId = _customerId;
					_fgItem.CustomerCode = _customerCode;
					_fgItem.ItemId = ItemId;
					_fgItem.ItemPrefix = lbPrefix.Text;
					_fgItem.ItemName = lbItemName.Text;
					_fgItem.MaterialId = _materialId;
					_fgItem.MaterialName = this.lbMaterial.Text;
					_fgItem.Unit = this.lbUnit.Text;

					_fgItem.StartPosition = FormStartPosition.CenterParent;
					_fgItem.ShowDialog(this);
				}
			}

			// re-load job order and JobInfo Item List
			GetJobInfo(_jobId);
			GetJobFG(_jobId, _selectedGroupCode);

		} // end AddEditJobInfoItem

		#endregion
	}
}