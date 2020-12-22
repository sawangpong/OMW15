using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingView
{
	public partial class CastingJobFG : Form
	{
		#region class field member
		//private ActionMode _mode = ActionMode.None;

		private string _customerName = string.Empty;
		private string _customerCode = string.Empty;
		private string _selectedGroupCode = string.Empty;
		//private string _itemPrefix = string.Empty;
		private bool _readyFinished = false;
		private int _jobStatus = 0;
		private int _jobId = 0;
		private int _customerId = 0;
		private int _materialId = 0;
		//private int _itemId = 0;
		private int _selectedItemInfoId = 0;
		private int _selectedItemInfoFG = 0;

		#endregion

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
			get;
			set;
		}
		public int ItemId
		{
			get;
			set;
		}

		public string ItemPrefix
		{
			get;
			set;
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			if(string.IsNullOrEmpty(_selectedGroupCode))
			{
				this.tsbtnAdd.Enabled = false;
				this.tsbtnEdit.Enabled = this.tsbtnAdd.Enabled;
				this.tsbtnDelete.Enabled = this.tsbtnAdd.Enabled;
				this.tsbtnRefresh.Enabled = this.tsbtnAdd.Enabled;
			}
			else
			{
				this.tsbtnAdd.Enabled = true;
				this.tsbtnEdit.Enabled = (_selectedItemInfoId > 0);
				this.tsbtnDelete.Enabled = (this.tsbtnEdit.Enabled && _selectedItemInfoFG == 0);
				this.tsbtnRefresh.Enabled = this.dgv.Rows.Count > 0;
			}

		} // end UpdateUI

		private void CreateFGMenu(string Prefix)
		{
			ToolStripMenuItem _btn = new ToolStripMenuItem();

			// create menu as the present prefix
			switch(Prefix)
			{
				case "R":
					_btn = new ToolStripMenuItem();
					_btn.Text = "ฉีดเทียน";
					_btn.Tag = "WAX";
					_btn.Click += new EventHandler(this.mnuGroupSelection);
					this.tsmnuJobFG.DropDownItems.Add(_btn);

					_btn = new ToolStripMenuItem();
					_btn.Text = "แต่งเทียน";
					_btn.Tag = "FINISHING";
					_btn.Click += new EventHandler(this.mnuGroupSelection);
					this.tsmnuJobFG.DropDownItems.Add(_btn);

					_btn = new ToolStripMenuItem();
					_btn.Text = "ติดต้น";
					_btn.Tag = "TREE";
					_btn.Click += new EventHandler(this.mnuGroupSelection);
					this.tsmnuJobFG.DropDownItems.Add(_btn);

					_btn = new ToolStripMenuItem();
					_btn.Text = "หล่องาน";
					_btn.Tag = "FG";
					_btn.Click += new EventHandler(this.mnuGroupSelection);
					this.tsmnuJobFG.DropDownItems.Add(_btn);
					break;
				case "S":
				case "W":
					_btn = new ToolStripMenuItem();
					_btn.Text = "ติดต้น";
					_btn.Tag = "TREE";
					_btn.Click += new EventHandler(this.mnuGroupSelection);
					this.tsmnuJobFG.DropDownItems.Add(_btn);

					_btn = new ToolStripMenuItem();
					_btn.Text = "หล่องาน";
					_btn.Tag = "FG";
					_btn.Click += new EventHandler(this.mnuGroupSelection);
					this.tsmnuJobFG.DropDownItems.Add(_btn);
					break;
				case "L":
				case "M":
					_btn.Text = "อัดยาง / ผ่ายาง";
					_btn.Tag = "BLOCK";
					_btn.Click += new EventHandler(this.mnuGroupSelection);
					this.tsmnuJobFG.DropDownItems.Add(_btn);
					break;
			}

		} // end CreateFGMenu

		private void mnuGroupSelection(object sender, EventArgs e)
		{
			ToolStripMenuItem _mnu = sender as ToolStripMenuItem;
			_selectedGroupCode = _mnu.Tag.ToString().ToUpper();

			// re-write menutext
			this.tsmnuJobFG.Text = string.Format("เลือกงาน :: {0}", _mnu.Text);
			this.tslbFGGroup.Text = _selectedGroupCode;

			this.GetJobFG(_jobId, _selectedGroupCode);

			this.UpdateUI();

		} // end mnuGroupSelection



		private void GetJobInfoProgress(int JobId, decimal OrderQty)
		{
			DataTable _dt = new Casting.CastingController.JobDAL().GetSummaryJobInfoByGroupCode(JobId);

				//this.GetSummaryJobInfoByGroupCode(JobId);

			if(_dt.Rows.Count > 0)
			{
				foreach(DataRow _dr in _dt.Rows)
				{
					string _group = _dr["KEY"].ToString().ToUpper();
					switch(_group)
					{
						case "WAX":
							this.lbWaxQty.Text = string.Format("{0:N2}", _dr["FG"]);
							break;
						case "FINISHING":
							this.lbWaxFinish.Text = string.Format("{0:N2}", _dr["FG"]);
							break;
						case "TREE":
							this.lbWaxTree.Text = string.Format("{0:N2}", _dr["FG"]);
							break;
						case "FG":
							this.lbFinishQty.Text = string.Format("{0:N2}", _dr["FG"]);
							break;
					}
				}

				_readyFinished = ((Convert.ToDecimal(this.lbOrderQty.Text) <= Convert.ToDecimal(this.lbFinishQty.Text)) ? true : false);
				this.lbFlagStatus.Text = (_readyFinished == false ? "Active" : "Finish");

				this.lbFGProgress.Text = string.Format("{0:P2}", (Convert.ToDecimal(this.lbFinishQty.Text) / OrderQty));
				this.lbBackOrderQty.Text = string.Format("{0:N2}", (OrderQty - Convert.ToDecimal(this.lbFinishQty.Text)));
				this.lbWaxProgress.Text = string.Format("{0:P2}", (Convert.ToDecimal(this.lbWaxQty.Text) / OrderQty));
				this.lbFinishingProgress.Text = string.Format("{0:P2}", (Convert.ToDecimal(this.lbWaxFinish.Text) / OrderQty));
				this.lbTreeProgress.Text = string.Format("{0:P2}", (Convert.ToDecimal(this.lbWaxTree.Text) / OrderQty));
			}
			else
			{
				this.lbWaxFinish.Text = "0.00";
				this.lbWaxQty.Text = "0.00";
				this.lbWaxTree.Text = "0.00";
				this.lbFinishQty.Text = "0.00";
				this.lbBackOrderQty.Text = "0.00";
				this.lbFGProgress.Text = "0.00%";
				this.lbWaxProgress.Text = "0.00%";
				this.lbFinishingProgress.Text = "0.00%";
				this.lbTreeProgress.Text = "0.00%";
			}

		} // end GetJobInfoProgress

		private void GetJobInfo(int JobId)
		{
			// job - header
			decimal _orderQty = 0.00m;

			JOBORDER _job = new Casting.CastingController.JobDAL().GetJobOrderInfo(JobId);
			_jobStatus = _job.STATUS;
			_materialId = _job.MATERIALTYPE;
			//_itemId = _job.ITEMID.Value;
			_orderQty = _job.ORDERQTY;
			//_itemPrefix = _job.PREFIX;

			this.lbPrefix.Text = string.Format("{0}", this.ItemPrefix);
			this.lbItemNo.Text = _job.ITEMNO;
			this.lbItemName.Text = _job.ITEMNAME;
			this.lbUnit.Text = _job.ORDERUNIT;
			this.lbOrderQty.Text = string.Format("{0}", _orderQty);
			this.lbBackOrderQty.Text = string.Format("{0:N2}", _job.BACKORDQTY.Value);

			// create menu as of giving item-code
			this.CreateFGMenu(this.ItemPrefix);

			// get item-picture
			this.pic.Image = this.ItemImage;

			// jobinfo - FG info
			this.GetJobInfoProgress(JobId, _orderQty);

		} // end GetJobInfo

		private void GetJobFG(int JobId, string FGCode)
		{
			this.dgv.SuspendLayout();
			// loading data
			this.dgv.DataSource = new OMW15.Casting.CastingController.JobDAL().GetJobInfoByGroupCode(JobId, FGCode);

			foreach(DataGridViewColumn dgc in this.dgv.Columns)
			{
				if(dgc.Index <= this.dgv.Columns.Count - 2)
				{
					dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				}
				else
				{
					dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
			}

			// formatting - DataGridView
			this.dgv.Columns["LINESEQ"].Visible = false;
			this.dgv.Columns["FGLINESEQ"].Visible = false;
			this.dgv.Columns["ITEMID"].Visible = false;
			this.dgv.Columns["ITEMPREFIX"].Visible = false;
			this.dgv.Columns["GROUPCODE"].Visible = false;

			//this.dgv.Columns["GROUPCODE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			this.dgv.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			this.dgv.Columns["OPERATORNAME"].HeaderText = "ผู้ปฏิบัติงาน";

			this.dgv.Columns["FINISHDATE"].HeaderText = "วันที่เสร็จ";
			this.dgv.Columns["FINISHDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dgv.Columns["FINISHDATE"].DefaultCellStyle.Format = "####-##-##";

			this.dgv.Columns["ACCEPTQTY"].HeaderText = "ชิ้นงานดี";
			this.dgv.Columns["ACCEPTQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["ACCEPTQTY"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["REJECTQTY"].HeaderText = "ชิ้นงานเสีย";
			this.dgv.Columns["REJECTQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["REJECTQTY"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["TOTALQTY"].HeaderText = "ชิ้นงานรวม";
			this.dgv.Columns["TOTALQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["TOTALQTY"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["TOTALWEIGHT"].HeaderText = "น้ำหนักรวม (กรัม)";
			this.dgv.Columns["TOTALWEIGHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["TOTALWEIGHT"].DefaultCellStyle.Format = "N2";

			this.dgv.Columns["AVGWEIGHT"].HeaderText = "น้ำหนักเฉลี่ย (กรัม)";
			this.dgv.Columns["AVGWEIGHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["AVGWEIGHT"].DefaultCellStyle.Format = "N2";

			this.dgv.ResumeLayout();
			this.UpdateUI();

		} // end GetJobFG

		private void UpdateJobInfo(int JobFGId)
		{
		} // end UpdateJobInfo

		private void AddEditJobInfoItem(int JobInfoItemId)
		{
			using(OMW15.Casting.CastingView.CastingFGItem _fgItem = new OMW15.Casting.CastingView.CastingFGItem())
			{
				_fgItem.JobId = _jobId;
				_fgItem.JobinfoId = _selectedItemInfoId;
				_fgItem.FGItemId = _selectedItemInfoFG;
				_fgItem.GroupCode = _selectedGroupCode;
				_fgItem.CustomerId = _customerId;
				_fgItem.CustomerCode = _customerCode;
				_fgItem.ItemId = this.ItemId;
				_fgItem.ItemPrefix = this.lbPrefix.Text;
				_fgItem.ItemName = this.lbItemName.Text;
				_fgItem.MaterialId = _materialId;
				_fgItem.ShowDialog(this);
			}

			// re-load job order and JobInfo Item List
			this.GetJobInfo(_jobId);
			this.GetJobFG(_jobId, _selectedGroupCode);

		} // end AddEditJobInfoItem

		#endregion


		public CastingJobFG()
		{
			InitializeComponent();
		}

		private void CastingJobFG_Load(object sender, EventArgs e)
		{
			// initial variable value
			_selectedGroupCode = string.Empty;
			_selectedItemInfoFG = 0;
			_selectedItemInfoId = 0;

			// setting data grid view
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			// display info
			this.lbCustomer.Text = string.Format("{0} :: {1}", _customerCode, _customerName);
			this.lbJobNo.Text = string.Format("หมายเลขใบงาน : {0}", _jobId);

			// get job-info
			this.GetJobInfo(_jobId);

			this.UpdateUI();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			string _group = "FG";
			// define for group from item-no for update
			switch(this.lbPrefix.Text)
			{
				case "R":	// ฉีด / หล่อ
				case "S":	// ให้เทียน
				case "W":	// หล่อ wax
					_group = "FG";
					break;
				case "M":	// ทำก้อนยาง
				case "L":	// ทำก้อนใส
					_group = "BLOCK";
					break;
			}

			// update - all pending process for job orders
			if(new OMW15.Casting.CastingController.JobDAL().UpdateJobOrdersStatusByFinishQty(_jobId, _group) > 0)
			{
				omglobal.DisplayAlert(" ปรับปรุงข้อมูล", string.Format(" ปรับปรุงข้อมูล ของหมายเลขใบงาน ที่ :: {0} เรียบร้อยแล้ว", _jobId));
			}

			// Close this form
			this.Close();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedItemInfoId = Convert.ToInt32(this.dgv["LINESEQ", e.RowIndex].Value);
			_selectedItemInfoFG = Convert.ToInt32(this.dgv["FGLINESEQ", e.RowIndex].Value);

			this.tslbLineId.Text = string.Format("[ID :: {0}]", _selectedItemInfoId);
			this.tslbFGId.Text = string.Format("[FG :: {0}]", _selectedItemInfoFG);

			// update - UI
			this.UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.GetJobFG(_jobId, _selectedGroupCode);
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("ต้องการลบรายการที่เลือก ใช่หรือไม่?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				using(var scope = new System.Transactions.TransactionScope())
				{
					OLDMOONEF _oldmoon = new OLDMOONEF();
					// 1. delete the selected item from JobInfos Table
					// 2. Update Total Values in table FGStock
					try
					{
						var j = (from ji in _oldmoon.JOBINFOS
								 where ji.LINESEQ == _selectedItemInfoId
								 select ji).FirstOrDefault();

						_oldmoon.JOBINFOS.Remove(j);
						_oldmoon.SaveChanges();
						scope.Complete();
					}
					catch(OptimisticConcurrencyException ex)
					{
						//scope.Dispose();
						throw new Exception("มีข้อผิดพลาด ไม่สามารถลบรายการที่เลือกได้ !!!!", ex);
					}

				} // end scope

				// update FG-Stock table
				if((_selectedGroupCode == "FG") || (_selectedGroupCode == "BLOCK"))
				{
					int _result = new Casting.CastingController.JobDAL().UpdateFGSByFinishQty(_jobId, _selectedGroupCode);
				}

				// after delete and updated 
				// reload JobInfos List
				// jobinfo - FG info
				this.GetJobInfoProgress(_jobId, Convert.ToDecimal(this.lbOrderQty.Text));

				// reload the list
				this.tsbtnRefresh.PerformClick();

			}
		} // end delete

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			this.AddEditJobInfoItem(_selectedItemInfoId);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedItemInfoId = 0;
			this.AddEditJobInfoItem(_selectedItemInfoId);
		}
	}
}
