using System;
using System.Data;
using System.Windows.Forms;

namespace OMW15.Views.ToolViews
{
	public partial class Datadic : Form
	{
		#region Singleton
		public static Datadic _instance;
		public static Datadic GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new Datadic();
				}
				return _instance;
			}
		}
		#endregion

		#region class field
		DataTable _dtDic;

		#endregion

		#region class helper

		private void GetDataFromEntities()
		{
			OLDMOONEF1 _om = new OLDMOONEF1();

			_dtDic = new DataTable();
			_dtDic.Columns.Add("MainObjectName", typeof(System.String));
			_dtDic.Columns.Add("ObjectName", typeof(System.String));
			_dtDic.Columns.Add("ObjectType", typeof(System.String));
			_dtDic.Columns.Add("TypeName", typeof(System.String));

			var _f = _om.GetType().GetMembers();

			DataRow _dr;
			foreach (var dt in _om.GetType().GetMembers())
			{
				if (dt.MemberType.ToString() == "Property")
				{
					foreach(var t in dt.GetType().GetMembers())
					{
						//if (t.MemberType.ToString() == "Property")
						//{
							_dr = _dtDic.NewRow();
							_dr[0] = dt.Name;
							_dr[1] = t.Name;
							_dr[2] = t.MemberType.ToString();
							_dr[3] = t.CustomAttributes.ToString();
							_dtDic.Rows.Add(_dr);
						//}
					}
				}
			}


			dgv.DataSource = _dtDic;


		}

		#endregion

		public Datadic()
		{
			InitializeComponent();
			OMControls.OMUtils.SettingDataGridView(ref dgv);
		}

		private void Datadic_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			GetDataFromEntities();
		}
	}
}
