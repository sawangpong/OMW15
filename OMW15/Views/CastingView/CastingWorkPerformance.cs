using OMW15.Models.CastingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAF;
using log4net;
using OMW15;

namespace OMW15.Views.CastingView
{
    public partial class CastingWorkPerformance : Form
    {
        #region class field member

        //private int _step = 0;

        private int actionMenu = 0;
        private int selectedWorkingYear = DateTime.Today.Year;
        private int selectedWorkingMonth = DateTime.Today.Month;
        private int _selectedWorkerId = 0;
        private decimal _selectedWorkDate = 0m;

        #endregion

        #region class methods

        private void updateUI()
        {
            lbYear.Visible = !(actionMenu == 2);
            cbxWorkYear.Visible = lbYear.Visible;

            lbMonth.Visible = !(actionMenu == 1 || actionMenu == 2);
            cbxMonth.Visible = lbMonth.Visible;

            splitter2.Visible = (actionMenu == 3);
            dgvDayContents.Visible = splitter2.Visible;

            dgvContents.Dock = (dgvDayContents.Visible == true ? DockStyle.Top : DockStyle.Fill);

            btnLoadData.Enabled = (actionMenu > 0);

        } // end updateUI

        private void loadYears()
        {
            cbxWorkYear.DataSource = null;
            cbxWorkYear.DataSource = new Models.CastingModel.CastingPerformanceDAL().getWorkingYear();
            cbxWorkYear.DisplayMember = "WorkYear";
            cbxWorkYear.ValueMember = "WorkYear";
            cbxWorkYear.SelectedIndex = 0;

        } // end loadYears

        private void getMonthList(int workingYear)
        {
            cbxMonth.DataSource = null;
            cbxMonth.DataSource = new Models.CastingModel.CastingPerformanceDAL().getWorkingMonth(workingYear);
            cbxMonth.DisplayMember = "MonthName";
            cbxMonth.ValueMember = "WorkMonth";
            cbxMonth.SelectedIndex = 0;

        } // end getMonthList

        private void loadMenus()
        {
            cbxTopic.DataSource = new Models.CastingModel.CastingPerformanceDAL().getCastingPerformaceMenus();
            cbxTopic.DisplayMember = "name";
            cbxTopic.ValueMember = "value";

        } // end loadMenus


        private void loadData(int action, int workingYear, int workingMonth = 0)
        {
            switch (action)
            {
                case 1:
                    getOverCastingProduction(workingYear);
                    break;

                case 2:
                    getSummaryCastingProductionByYear();
                    break;

                case 3:
                    getJobProgressByDay(workingYear, workingMonth);
                    break;

                case 4:
                    getAVGProgressByMonth(workingMonth, selectedWorkingYear);
                    break;
            }

        } // end loadPerformanceData

        private void getOverCastingProduction(int workingYear)
        {
            dgvContents.DataSource = null;
            dgvContents.SuspendLayout();
            dgvContents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvContents.DataSource = new Models.CastingModel.CastingPerformanceDAL().getOverCastingProduction(workingYear);

            foreach (DataGridViewColumn dgc in dgvContents.Columns)
            {
                if (dgc.ValueType == typeof(System.Decimal))
                {
                    dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
                }
            }
            dgvContents.ResumeLayout();

        } // end getOverCastingProduction

        private async void getSummaryCastingProductionByYear()
        {
            var _dal = new JobDAL();
            dgvContents.DataSource = null;
            dgvContents.SuspendLayout();
            dgvContents.DataSource = await _dal.GetSummaryJobInfoByYearAsync();
            dgvContents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            foreach (DataGridViewColumn dgc in dgvContents.Columns)
            {
                if (dgc.ValueType == typeof(System.Decimal))
                {
                    dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
                }
            }
            dgvContents.ResumeLayout();

        } // end getSummaryCastingProductionByYear

        private async void getJobProgressByDay(int workingYear, int workingMonth)
        {
            if (workingYear > 0)
            {
                // load summary progress by year
                //GetSummaryJobInfoByYear();
                var _dal = new JobDAL();
                var dt = await _dal.GetProgressJobInfoAsync(workingYear, workingMonth);

                // create summary row
                var dr = dt.NewRow();
                dr["DAY"] = "";
                dr["WORKDATE"] = "TOTAL";
                dr["BLOCK"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("BLOCK"));
                dr["WAX"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("WAX"));
                dr["FINISHING"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("FINISHING"));
                dr["TREE"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("TREE"));
                dr["CAST_GOOD"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("CAST_GOOD"));
                dr["CAST_BAD"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("CAST_BAD"));
                dr["TOTAL_CAST"] = dt.AsEnumerable().Sum(x => x.Field<decimal>("TOTAL_CAST"));

                // add summary row into main datatable
                dt.Rows.Add(dr);

                dgvContents.SuspendLayout();

                // map data into datagridview
                dgvContents.DataSource = dt;

                // format column header
                foreach (DataGridViewColumn dgc in dgvContents.Columns)
                {
                    switch (dgc.Name)
                    {
                        case "WORKDATE":
                            dgc.HeaderText = "วันทำงาน";
                            break;
                        case "BLOCK":
                            dgc.HeaderText = "ทำก้อนยาง";
                            break;
                        case "WAX":
                            dgc.HeaderText = "ฉีดเทียน";
                            break;
                        case "FINISHING":
                            dgc.HeaderText = "แต่งเทียน";
                            break;
                        case "TREE":
                            dgc.HeaderText = "ติดต้น";
                            break;
                        case "CAST_GOOD":
                            dgc.HeaderText = "งานหล่อ-ดี";
                            break;
                        case "CAST_BAD":
                            dgc.HeaderText = "งานหล่อ-เสีย";
                            break;
                        case "TOTAL_CAST":
                            dgc.HeaderText = "รวมงานหล่อ";
                            break;
                    }

                    if (dgc.ValueType == typeof(decimal))
                    {
                        dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
                    }
                }
                dgvContents.Columns["DAY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvContents.Columns["DAY"].DefaultCellStyle.Font = new Font(dgvContents.Font, FontStyle.Bold);
                dgvContents.Columns["WORKDATE"].Frozen = true;
                dgvContents.Columns["WORKDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvContents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvContents.ResumeLayout();
            }

        } // end getJobProgressByDay

        private async void GetWorkDetails(decimal WorkDate)
        {
            var _dal = new JobDAL();
            var _dt = await _dal.GetWorkDetailsByDayAsync(WorkDate);
            dgvDayContents.SuspendLayout();
            dgvDayContents.DataSource = null;
  
            // summary row
            // create summary row
            var dr = _dt.NewRow();
            dr[0] = 0;
            dr[1] = "";
            dr["BLOCK"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("BLOCK"));
            dr["WAX"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("WAX"));
            dr["FINISHING"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("FINISHING"));
            dr["TREE"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("TREE"));
            dr["CAST_GOOD"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("CAST_GOOD"));
            dr["CAST_BAD"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("CAST_BAD"));
            dr["WORK_TOTAL"] = _dt.AsEnumerable().Sum(x => x.Field<decimal>("WORK_TOTAL"));

            // map data
            dgvDayContents.DataSource = _dt;
            dgvDayContents.Columns["OPERATORID"].Visible = false;
            dgvDayContents.Columns["OPERATORNAME"].HeaderText = "ชื่อพนักงาน";

            foreach (DataGridViewColumn dgc in dgvDayContents.Columns)
                if (dgc.Name == "OPERATORNAME")
                {
                    dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();

                    switch (dgc.Name)
                    {
                        case "BLOCK":
                            dgc.HeaderText = $"ทำก้อนยาง = {dr["BLOCK"]:N0}";
                            break;
                        case "WAX":
                            dgc.HeaderText = $"ฉีดเทียน = {dr["WAX"]:N0}";
                            break;
                        case "FINISHING":
                            dgc.HeaderText = $"แต่งเทียน = {dr["FINISHING"]:N0}";
                            break;
                        case "TREE":
                            dgc.HeaderText = $"ติดต้น = {dr["TREE"]:N0}";
                            break;
                        case "CAST_GOOD":
                            dgc.HeaderText = $"งานหล่อ-ดี = {dr["CAST_GOOD"]:N0}";
                            break;
                        case "CAST_BAD":
                            dgc.HeaderText = $"งานหล่อ-เสีย = {dr["CAST_BAD"]:N0}";
                            break;
                        case "WORK_TOTAL":
                            dgc.HeaderText = $"รวม = {dr["WORK_TOTAL"]:N0}";
                            break;
                    }
                }
            dgvDayContents.Columns["OPERATORNAME"].Frozen = true;
            dgvDayContents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDayContents.ResumeLayout();

        } // end GetWorkDetails

        private async void getAVGProgressByMonth(int Period, int WorkYear)
        {
            var _dal = new JobDAL();

            var _dt = await _dal.GetAVGProgressByMonthAsync(Period, WorkYear);

            dgvContents.SuspendLayout();
            dgvContents.DataSource = _dt;

            // formatting datagridview
            dgvContents.Columns["WORKER"].HeaderText = "ชื่อพนักงาน";
            dgvContents.Columns["N"].Visible = false;
            dgvContents.Columns["WORKER"].Frozen = true;

            dgvContents.Columns["TOTAL"].HeaderText = "ยอดรวม";
            dgvContents.Columns["TOTAL"].DefaultCellStyle.Format = "N0";
            dgvContents.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvContents.Columns["AVG"].HeaderText = "ยอดเฉลี่ยต่อเดือน";
            dgvContents.Columns["AVG"].DefaultCellStyle.Format = "N2";
            dgvContents.Columns["AVG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvContents.Columns["PERFORMANCE"].HeaderText = " ผลงาน%";
            dgvContents.Columns["PERFORMANCE"].DefaultCellStyle.Format = "P2";
            dgvContents.Columns["PERFORMANCE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvContents.ResumeLayout();

        } // end getAVGProgressByMonth

        private void getJobByWorker(int workerId, decimal workDate)
        {
            dgvJobs.SuspendLayout();
            dgvJobs.DataSource = new Models.CastingModel.CastingPerformanceDAL().getJobByWorkerWork(workerId, workDate);
            dgvJobs.ResumeLayout();

        }
        #endregion

        public CastingWorkPerformance()
        {
            InitializeComponent();

            // setting datagridview
            OMControls.OMUtils.SettingDataGridView(ref this.dgvContents);
            OMControls.OMUtils.SettingDataGridView(ref this.dgvDayContents);
            OMControls.OMUtils.SettingDataGridView(ref this.dgvJobs);
         }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CastingPerformance_Load(object sender, EventArgs e)
        {
            loadYears();
            loadMenus();

            updateUI();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
             loadData(actionMenu, selectedWorkingYear, selectedWorkingMonth);
        }

        private void cbxWorkYear_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedWorkingYear = int.Parse(cbxWorkYear.Text);
            updateUI();
            if (actionMenu > 2)
            {
                getMonthList(selectedWorkingYear);
            }
         }

        private void cbxMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedWorkingMonth = int.Parse(cbxMonth.SelectedValue.ToString());
            updateUI();
        }

        private void dgvContents_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            switch (actionMenu)
            {
                case 3:
                    _selectedWorkDate = (decimal)dgvContents["WORKDATE", e.RowIndex].Value.ToString().Date2Num();
                    GetWorkDetails(_selectedWorkDate);
                    break;
            }
        }

        private void cbxTopic_SelectedValueChanged(object sender, EventArgs e)
        {
            int tempAction = actionMenu;

            try
            {
                actionMenu = int.Parse(cbxTopic.SelectedValue.ToString());
            }
            catch
            {
                actionMenu = 0;
            }

             if (tempAction != actionMenu)
            {
                dgvContents.DataSource = null;
                dgvDayContents.DataSource = null;
            }

            selectedWorkingYear = DateTime.Today.Year;
            cbxWorkYear.SelectedIndex = 0;

            lbMenuId.Text = $"id:{actionMenu}";
            pnlRight.Visible = (actionMenu == 3);
            updateUI();

        }

        private void dgvDayContents_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
             _selectedWorkerId = int.Parse(dgvDayContents["OPERATORID", e.RowIndex].Value.ToString());
            lbWorkerId.Text = $"{_selectedWorkerId}";
            getJobByWorker(_selectedWorkerId, _selectedWorkDate);
        }
    }
}
