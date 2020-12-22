using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Services.ServiceView
{
	public partial class MachineRecord : Form
	{
		#region class methods

		private void GetSaleMachineSummary()
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			using (SERVICEEF _srv = new  SERVICEEF())
			{
				var mc = (from m in _srv.MIXes
						  join pd in _srv.PRODUCTS on m.productid equals pd.id
						  where (m.isdelete == false) && (m.isnewproduct == true) && (m.istransfer == false)
						  group m by new { m.type,m.yearsale} into mrec
						  
						  select new
						  {
							 mrec.Key.type,
							 mrec.Key.yearsale,
							 total = mrec.Sum(x=>x.qtysale)
						  }).AsParallel().ToList();


				DataTable _dt = OMControls.OMDataUtils.ToDataTable(mc);
				DataTable _tmp = _dt.Copy();
				//_tmp.Columns.Remove("type");
				_tmp.Columns.Remove("yearsale");
				_tmp.Columns.Remove("total");

				string[] pkCol = _tmp.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();

				// prep result table
				DataTable _result = _tmp.DefaultView.ToTable(true, pkCol).Copy();
				_result.PrimaryKey = _result.Columns.Cast<DataColumn>().ToArray();
				_dt.AsEnumerable().Select(r => r["yearsale"].ToString()).Distinct().ToList().ForEach(c => _result.Columns.Add(c, typeof(System.String)));

				// add last column for total values
				_result.Columns.Add("Total", typeof(System.String));


				// load it
				foreach(DataRow dr in _dt.Rows)
				{
					DataRow _r = _result.Rows.Find(pkCol.Select(c => dr[c]).ToArray());
					_r[dr["yearsale"].ToString()] = dr["total"];
				}
				_result.DefaultView.Sort = "type";
				this.dgv.DataSource = _result;
			}
		} // end GetSaleMachineSummary

		#endregion


		public MachineRecord()
		{
			InitializeComponent();
		}

		private void MachineRecord_Load(object sender, EventArgs e)
		{
			this.GetSaleMachineSummary();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
