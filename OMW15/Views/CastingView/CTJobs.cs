using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using OMW15.Views.ToolViews;
using System.Data;

namespace OMW15.Views.CastingView
{
    public partial class CTJobs : Form
    {
        public CTJobs()
        {
            InitializeComponent();
            //bg.WorkerReportsProgress = true;
            //bg.WorkerSupportsCancellation = true;
            //bg.DoWork += bg_Dowork;
            //bg.ProgressChanged += bg_ProgressChanged;
            //bg.RunWorkerCompleted += bg_RunWorkerCompleted;

            lbSummaryHeader.BackColor = omglobal.OM_ORANGE_COLOR;

            OMUtils.SettingDataGridView(ref this.dgv);
            OMUtils.SettingDataGridView(ref this.dgvActiveQty);
            OMUtils.SettingDataGridView(ref this.dgvPriority);

        }


        private void CTJobs_Load(object sender, EventArgs e)
        {
            GetJobCat();
            GetJobStatus();
            GetYearList();
            GetMonthList();

            UpdateUI();

            // update all status 
            UpdateJobOrderInfos();
        }

        private void tsbtnJobProgress_Click(object sender, EventArgs e)
        {
            var _jud = new JobOrderProgressStatus();
            _jud.StartPosition = FormStartPosition.CenterParent;
            _jud.Show();
        }

        private void tsbtnJobInfo_Click(object sender, EventArgs e)
        {
            using (var _fg = new CastingJobFG())
            {
                _fg.JobId = _selectedJobId;
                _fg.ItemId = _selectedItemId;
                _fg.ItemPrefix = _selectedItemPrefix;
                _fg.CustomerId = _selectedCustomerId;
                _fg.CustomerCode = SelectedCustomerCode;
                _fg.CustomerName = _selectedCustomerName;
                _fg.ItemImage = pic.Image;

                if (_fg.ShowDialog(this) == DialogResult.OK)
                {
                    // update -- joblist
                }
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_maxRows == dgv.Rows.Count)
            {
                _selectedJobId = Convert.ToInt32(dgv["JOBNO", e.RowIndex].Value);
                _selectedItemPrefix = dgv["CAT", e.RowIndex].Value.ToString();
                _selectedItemId = Convert.ToInt32(dgv["ITEMID", e.RowIndex].Value);
                _selectedCustomerId = Convert.ToInt32(dgv["CUSTOMERID", e.RowIndex].Value);
                SelectedCustomerCode = dgv["CUSTOMERCODE", e.RowIndex].Value.ToString();
                _selectedCustomerName = dgv["CUSTOMERNAME", e.RowIndex].Value.ToString();

                var _itemNo = dgv["ITEMNO", e.RowIndex].Value.ToString();

                // display picture
                pic.Image = new PriceListDAL().GetPriceListItemPictureByItemId(_selectedItemId);

                // update selected-status
                UpdateListStatus();

                // update-UI
                UpdateUI();

                if (this.chkShowInfo.Checked)
                {
                    this.getJobInfo(_selectedJobId);
                }
            }
        }

        private void mnuFindJob_Click(object sender, EventArgs e)
        {
            var mnu = sender as ToolStripMenuItem;
            _findOption = mnu.Tag.ToString() == "BY_JOB"
                ? OMShareJobEnums.FindList.หมายเลขใบงาน
                : OMShareJobEnums.FindList.ชื่อลูกค้า;

            switch (_findOption)
            {
                case OMShareJobEnums.FindList.ชื่อลูกค้า:
                    _filterText = OMDataUtils.GetFilter<string>("กำหนดชื่อลูกค้าที่ต้องการค้นหา");
                    break;

                case OMShareJobEnums.FindList.หมายเลขใบงาน:
                    _filterText = OMDataUtils.GetFilter<string>("กำหนดหมายเลขใบงานที่ต้องการค้นหา");
                    break;
            }

            GetJobOrderList(_selectedJobCategory, _selectedJobStatus, _selectedYear, _selectedMonth, _filterText, _findOption);

            UpdateListStatus();
        }

        private void btnLoadJobData_Click(object sender, EventArgs e)
        {
            // loading job list

            if (_selectedJobStatus == (int)OMShareJobEnums.JobStatusEnumTH.เริ่มผลิต)
                _selectedMonth = 0;

            GetJobOrderList(_selectedJobCategory, _selectedJobStatus, _selectedYear, _selectedMonth, _filterText = "",
                _findOption = OMShareJobEnums.FindList.None);
        }


        private void cbxJobCat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _selectedJobCategory = cbxJobCat.SelectedValue.ToString();
            }
            catch
            {
                _selectedJobCategory = "R";
            }

            lbJobCat.Text = $"ประเภทงานหล่อ:[{_selectedJobCategory}]";
            UpdateUI();
        }


        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            AddEditJobOrder(_selectedJobId = 0);
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            AddEditJobOrder(_selectedJobId);
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            tsbtnEdit.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbxMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _selectedMonth = Convert.ToInt32(cbxMonth.SelectedValue);
            }
            catch
            {
                _selectedMonth = DateTime.Today.Month;
            }
        }

        private void cbxJobStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _selectedJobStatus = Convert.ToInt32(cbxJobStatus.SelectedValue);

                if (_selectedJobStatus == (int)OMShareJobEnums.JobStatusEnumTH.ผลิตเสร็จ)
                {
                    _selectedMonth = DateTime.Today.Month;
                    _selectedYear = DateTime.Today.Year;
                }
            }
            catch
            {
                _selectedJobStatus = 0;
            }

            lbStatus.Text = $"Status [{_selectedJobStatus}] :";

            UpdateUI();
        }

        private void cbxYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _selectedYear = Convert.ToInt32(cbxYear.SelectedValue);
            }
            catch
            {
                _selectedYear = DateTime.Today.Year;
            }
        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            var _crv = new CastingReportView();
            _crv.JobNumber = _selectedJobId;
            _crv.PrintWhat = PrintDocumentType.JobOrder;
            _crv.WindowState = FormWindowState.Maximized;
            _crv.MdiParent = ParentForm;
            _crv.Show();
        }

        #region class field

        //private readonly BackgroundWorker bg = new BackgroundWorker();
        //private LoadAlert alert = new LoadAlert();
        private OMShareJobEnums.FindList _findOption = OMShareJobEnums.FindList.None;
        private string _filterText = string.Empty;
        private string _selectedCustomerName = string.Empty;
        private string _selectedJobCategory = "R";
        private string _selectedItemPrefix = string.Empty;
        private int _selectedCustomerId;
        private int _selectedJobStatus = (int)OMShareJobEnums.JobStatusEnumTH.เริ่มผลิต;
        private int _selectedJobId;
        private int _selectedItemId;
        private int _priceItemId;
        private int _maxRows;
        private int _selectedYear = DateTime.Today.Year;
        private int _selectedMonth = DateTime.Today.Month;

        #endregion

        #region class property

        public string SelectedCustomerCode { get; set; } = string.Empty;

        public int PriceItemId
        {
            set
            {
                _priceItemId = value;
            }
        }

        #endregion

        #region class helper

        private void UpdateUI()
        {
            lbJobMonth.Visible = _selectedJobStatus == (int)OMShareJobEnums.JobStatusEnumTH.ผลิตเสร็จ;
            cbxMonth.Visible = lbJobMonth.Visible;
            lbYear.Visible = lbJobMonth.Visible;
            cbxYear.Visible = lbJobMonth.Visible;

            btnLoadJobData.Enabled = !string.IsNullOrEmpty(_selectedJobCategory);
            tsbtnFindJob.Enabled = dgv.Rows.Count > 0;
            tsbtnEdit.Enabled = _selectedJobId > 0;
            tsbtnPrint.Enabled = tsbtnEdit.Enabled;
            tsbtnJobInfo.Enabled = tsbtnEdit.Enabled;

        } // end UpdateUI

        private void UpdateListStatus()
        {
            lbFoundRecords.Text = $"Found :: {_maxRows} record{(_maxRows > 1 ? "s" : "")}";
            lbSelectedJobId.Text = $"Job Id :: {_selectedJobId}";
            lbCustomerCode.Text = $"({_selectedCustomerId})::{SelectedCustomerCode}";
        } // end UpdateListStatus


        private void UpdateJobOrderInfos()
        {
            var _resultUpdate = 0;

            // update jobinfos for FISCYEAR and FISCPERIOD
            _resultUpdate = new JobDAL().UpdateYearPeriodForJobInfos();

            // update status
            lbJobInfo.Text = $"JobInfos({_resultUpdate})";

            // update JobOrders for status of finishQty
            _resultUpdate = new JobDAL().UpdateJobOrdersStatusByFinishQty();

            lbJobOrder.Text = $"JobOrders({_resultUpdate})";
        } // end UpdateYPJobInfos


        private async void getJobPrioritySummary()
        {
            var _dal = new JobDAL();
            var _dt = await _dal.getJobPrioritySummary();
            _dt.DefaultView.Sort = "Q";

            this.dgvPriority.SuspendLayout();

            this.dgvPriority.DataSource = _dt;
            this.dgvPriority.Columns["Q"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPriority.Columns["BQ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvPriority.Columns["BQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            this.dgvPriority.Columns["BQ"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
            this.dgvPriority.Columns["R"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPriority.Columns["R"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            this.dgvPriority.Columns["R"].DefaultCellStyle.Format = "P2";

            this.dgvPriority.ColumnHeadersVisible = false;
            this.dgvPriority.ResumeLayout();
        }

        private void getJobInfo(int jobno)
        {
            decimal _wax = 0.00m;
            decimal _finish = 0.00m;
            decimal _tree = 0.00m;
            decimal _cast = 0.00m;
            DataTable _dt = new JobDAL().GetSummaryJobInfoByGroupCode(jobno);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow _dr in _dt.Rows)
                {
                    var _group = _dr["KEY"].ToString().ToUpper();
                    switch (_group)
                    {
                        case "WAX":
                            decimal.TryParse(_dr["FG"].ToString(), out _wax);
                            break;
                        case "FINISHING":
                            decimal.TryParse(_dr["FG"].ToString(), out _finish);
                            break;
                        case "TREE":
                            decimal.TryParse(_dr["FG"].ToString(), out _tree);
                            break;
                        case "FG":
                            decimal.TryParse(_dr["FG"].ToString(), out _cast);
                            break;
                    }
                }
            }
            this.lbWax.Text = $"ฉีดเทียน : {_wax:N0}";
            this.lbFinishing.Text = $"แต่งเทียน : {_finish:N0}";
            this.lbTree.Text = $"ติดต้น : {_tree:N0}";
            this.lbCast.Text = $"หล่อ : {_cast:N0}";
        }

        private async void GetActiveSummaryJob()
        {
            var _dal = new JobDAL();
            var _dt = await _dal.GetAsyncSummaryJobActive();
            _dt.DefaultView.Sort = "Q";

            dgvActiveQty.SuspendLayout();

            dgvActiveQty.DataSource = _dt;
            dgvActiveQty.Columns["Q"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvActiveQty.Columns["BQ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvActiveQty.Columns["BQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvActiveQty.Columns["BQ"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

            dgvActiveQty.ColumnHeadersVisible = false;
            dgvActiveQty.ResumeLayout();

        } // end GetActiveSummaryJob

        private void GetJobOrderList(string JobCategory, int JobStatus, int JobYear, int JobMonth, string FindText,
            OMShareJobEnums.FindList FindOption)
        {
            bool showColumnsForCloseStatus = (JobStatus == (int)OMShareJobEnums.JobStatusEnumEN.Closed ? true : false);

            dgv.SuspendLayout();
            var _dal = new JobDAL();

            if (!string.IsNullOrEmpty(JobCategory) && JobStatus > 0)
            {
                var _dt = _dal.GetJobOrderList(JobCategory, JobStatus, JobYear, JobMonth, FindText, FindOption);
                _maxRows = _dt.Rows.Count;
                dgv.DataSource = _dt;

                // formatting DataGridView
                // -- hide column
                dgv.Columns["STATUS"].Visible = false;
                dgv.Columns["PRIORITY"].Visible = false;
                dgv.Columns["ITEMID"].Visible = false;
                dgv.Columns["CUSTOMERCODE"].Visible = false;
                dgv.Columns["CUSTOMERID"].Visible = false;
                dgv.Columns["MATERIALTYPE"].Visible = false;
                //dgv.Columns["DUE"].Visible = !showColumnsForCloseStatus;
                dgv.Columns["RD"].Visible = !showColumnsForCloseStatus;
                dgv.Columns["FINISH"].Visible = showColumnsForCloseStatus;

                // formating style
                dgv.Columns["PRIORITYCLASS"].HeaderText = "PRIORITY";
                dgv.Columns["JOBSTATUSNAME"].HeaderText = "STATUS";
                dgv.Columns["ORDERDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["START"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["DUE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["FINISH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["CAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["UNIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["RD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["RD"].HeaderText = "Late";
                dgv.Columns["REMAIN"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
                dgv.Columns["QTY"].DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
            }
            else
            {
                dgv.DataSource = null;
            }

            dgv.ResumeLayout();

            // update - Active Order
            GetActiveSummaryJob();

            // update - Job Priority
            getJobPrioritySummary();

            // update - status
            UpdateListStatus();

            // update UI
            UpdateUI();

            //bg.WorkerSupportsCancellation = true;
            //bg.CancelAsync();
            //alert.Close();

        } // end GetJobOrderList

        private void getJobInfoSummary(int jobno)
        {
        }


        private void GetJobCat()
        {
            cbxJobCat.DataSource = new SelectOptions().GetItemCodeData();
            cbxJobCat.DisplayMember = "VALUE";
            cbxJobCat.ValueMember = "KEY";
            cbxJobCat.SelectedValue = _selectedJobCategory;
            lbJobCat.Text = $"ประเภทงานหล่อ:[{_selectedJobCategory}] :";

        }

        private void GetJobStatus()
        {
            cbxJobStatus.DataSource = OMDataUtils.GetValueList<OMShareJobEnums.JobStatusEnumTH>();
            cbxJobStatus.DisplayMember = "Value";
            cbxJobStatus.ValueMember = "Key";

            _selectedJobStatus =
                (int)Enum.Parse(typeof(OMShareJobEnums.JobStatusEnumTH), OMShareJobEnums.JobStatusEnumTH.เริ่มผลิต.ToString());

            //this.UpdateUI();
        } // end GetJobStatus

        private void GetYearList()
        {
            cbxYear.DataSource = DataTableTools.GetGeneralYearList();
            cbxYear.DisplayMember = "Y";
            cbxYear.ValueMember = "Y";
            cbxYear.SelectedValue = _selectedYear;
        } // end GetYearList

        private void GetMonthList()
        {
            cbxMonth.DataSource = EnumWithName<MonthList>.ParseEnum();
            cbxMonth.DisplayMember = "Name";
            cbxMonth.ValueMember = "Value";
            cbxMonth.SelectedValue = _selectedMonth;
        }

        private void AddEditJobOrder(int JobId)
        {
            using (var _jobInfo = new CastingJobInfo())
            {
                _jobInfo.CreateMode = OMShareJobEnums.JobOrderCreatedMode.CreateFromJobOrderList;
                _jobInfo.ItemId = 0;
                _jobInfo.ItemCode = string.Empty;
                _jobInfo.ItemName = string.Empty;
                _jobInfo.ItemNo = string.Empty;
                _jobInfo.StyleId = 0;
                _jobInfo.StyleName = string.Empty;
                _jobInfo.Material = string.Empty;
                _jobInfo.MaterialId = 0;
                _jobInfo.ItemImage = pic.Image;
                _jobInfo.JobId = JobId;
                _jobInfo.StartPosition = FormStartPosition.CenterScreen;
                _jobInfo.ShowDialog(this);
            }

            // re-load job after Add/Edit
            tsbtnRefresh.PerformClick();
        } // end AddEditJobOrder

        #endregion

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (int.Parse(this.dgv["PRIORITY", e.RowIndex].Value.ToString()) == 3)
            {
                e.CellStyle.BackColor = System.Drawing.Color.FromArgb(129, 20, 24);
                e.CellStyle.ForeColor = System.Drawing.Color.White;
            }
            else if (int.Parse(this.dgv["PRIORITY", e.RowIndex].Value.ToString()) == 2)
            {
                e.CellStyle.BackColor = System.Drawing.Color.FromArgb(160, 62, 62);
                e.CellStyle.ForeColor = System.Drawing.Color.White;
            }
            else if (int.Parse(this.dgv["PRIORITY", e.RowIndex].Value.ToString()) == 1)
            {
                e.CellStyle.BackColor = System.Drawing.Color.FromArgb(100, 62, 62);
                e.CellStyle.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                e.CellStyle.BackColor = System.Drawing.Color.FromArgb(12, 133, 117);
                e.CellStyle.ForeColor = System.Drawing.Color.White;
            }
        }

        private void chkShowInfo_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlJobInfo.Visible = this.chkShowInfo.Checked;
        }

        private void lbWax_Click(object sender, EventArgs e)
        {

        }
    }
}










