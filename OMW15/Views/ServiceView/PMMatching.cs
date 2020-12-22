using OMW15.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.ServiceView
{
	public partial class PMMatching : Form
	{
		#region class field

		private const string _matchingCode = "PM";
		private int _selectedJobOrderId = 0;

		#endregion

		#region class property

		public int PMContractId
		{
			get; set;
		}

		public int PMScheduleId
		{
			get; set;
		}

		public string CustomerCode
		{
			get; set;
		}

		public string Customer
		{
			get; set;
		}

		public string MachineModel
		{
			get; set;
		}

		public string SerialNo
		{
			get; set;
		}

		public int PMJobId
		{
			get; set;
		}

		public string PMJobNumber
		{
			get; set;
		}

		public DateTime OrderDate
		{
			get; set;
		}


		#endregion

		#region class helper

		private void updateUI()
		{
			this.btnSelect.Enabled = (_selectedJobOrderId > 0);
		}

		private void getJobList(string customerCode, string jobCode)
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = new PMDal().getJobListForPMMatching(this.CustomerCode, "PM",this.MachineModel , this.SerialNo);

			this.dgv.Columns["orderid"].Visible = false;
			this.dgv.Columns["status"].Visible = false;
			this.dgv.Columns["statusname"].HeaderText = "สถานะ";
			this.dgv.Columns["jobno"].HeaderText = "เลขที่ใบงาน";
			this.dgv.Columns["orderdate"].HeaderText = "วันที่เปิดใบงาน";
			this.dgv.Columns["duedate"].HeaderText = "กำหนดเสร็จ";
			this.dgv.Columns["finishdate"].HeaderText = "วันที่เสร็จจริง";
			this.dgv.Columns["type"].HeaderText = "รุ่นเครื่องจักร";
			this.dgv.Columns["s_no"].HeaderText = "หมายเลขเครื่องจักร";


			this.dgv.ResumeLayout();

			this.lbMatchFound.Text = $"matched : {this.dgv.Rows.Count}";
			this.updateUI();
		}


		#endregion


		public PMMatching()
		{
			InitializeComponent();
		}

		private void PMMatching_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.lbTitle.Text = $"Customer : {this.Customer}";

			this.getJobList(this.CustomerCode, _matchingCode);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			int.TryParse(this.dgv["orderid", e.RowIndex].Value.ToString(), out _selectedJobOrderId);
			this.PMJobId = _selectedJobOrderId;
			this.PMJobNumber = this.dgv["Jobno", e.RowIndex].Value.ToString();

			DateTime _orderDate = DateTime.Today;
			DateTime.TryParse(this.dgv["orderdate", e.RowIndex].Value.ToString(), out _orderDate);

			this.OrderDate = _orderDate;

			this.lbOrderId.Text = $"idx:{_selectedJobOrderId}";
			this.updateUI();
		}
	}
}
