using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;

namespace OMW15.Views.ServiceView
{
	public partial class MachineRecord : Form
	{
		public MachineRecord()
		{
			InitializeComponent();
		}

		#region class methods

		private void GetSaleMachineSummary()
		{
			OMUtils.SettingDataGridView(ref dgv);

			using (var _om = new OLDMOONEF1())
			{
				var mc = (from m in _om.MIXes
					join pd in _om.PRODUCTS on m.productid equals pd.id
					where m.isdelete == false
					      && m.isnewproduct
					      && m.istransfer == false
					group m by new
					{
						m.type,
						m.yearsale
					}
					into mrec
					select new
					{
						mrec.Key.type,
						mrec.Key.yearsale,
						total = mrec.Sum(x => x.qtysale)
					}).AsParallel();


				var _dt = mc.ToDataTable();
				var _tmp = _dt.Copy();

				_tmp.Columns.Remove("yearsale");
				_tmp.Columns.Remove("total");

				var pkCol = _tmp.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();

				// prep result table
				var _result = _tmp.DefaultView.ToTable(true, pkCol).Copy();
				_result.PrimaryKey = _result.Columns.Cast<DataColumn>().ToArray();
				_dt.AsEnumerable()
					.Select(r => r["yearsale"].ToString())
					.Distinct()
					.ToList()
					.ForEach(c => _result.Columns.Add(c, typeof(string)));

				// add last column for total values
				_result.Columns.Add("Total", typeof(string));


				// load it
				foreach (DataRow dr in _dt.Rows)
				{
					var _r = _result.Rows.Find(pkCol.Select(c => dr[c]).ToArray());
					_r[dr["yearsale"].ToString()] = dr["total"];
				}
				_result.DefaultView.Sort = "type";
				dgv.SuspendLayout();
				dgv.DataSource = _result;

				foreach (DataGridViewColumn dgc in dgv.Columns)
					if (dgc.ValueType == typeof(decimal)
					    || dgc.ValueType == typeof(int)) dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				dgv.ResumeLayout();
			}
		} // end GetSaleMachineSummary

		#endregion

		private void MachineRecord_Load(object sender, EventArgs e)
		{
			CenterToParent();
			GetSaleMachineSummary();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}