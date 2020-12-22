using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OMW15.Properties;

namespace OMW15.Views.CastingView
{
	public partial class CastingWebReport : Form
	{
		// CONSTRUCTOR
		public CastingWebReport(DataTable ReportSource, string Material)
		{
			InitializeComponent();
			_source = ReportSource;
			_material = Material;
		}

		private void CastingWebReport_Load(object sender, EventArgs e)
		{
			tsbtnLoadReport.PerformClick();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnLoadReport_Click(object sender, EventArgs e)
		{
			GenerateWebReport(_source, _material);
		}

		#region class field member

		private readonly DataTable _source = new DataTable();
		private readonly string _material = string.Empty;
		private readonly StringBuilder _sb = new StringBuilder();

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GenerateWebReport(DataTable Source, string Material)
		{
			// Create Web Content
			_sb.AppendFormat("{0}", "<table class='datatable'>");
			_sb.AppendLine();
			_sb.AppendFormat("<caption><H3>MATERIAL {0} OUTSTANDING AS OF DATE {1}</H3></caption", Material,
				DateTime.Today.ToShortDateString());
			_sb.AppendLine();

			// create the first row
			_sb.AppendFormat("{0}", "<tr>");
			_sb.AppendLine();

			// create the columns header 
			foreach (DataColumn _dc in Source.Columns)
				if (_dc.ColumnName != "CUSTCODE")
				{
					_sb.AppendFormat("<th scope='col'>{0}</th>", _dc.ColumnName);
					_sb.AppendLine();
				}
			_sb.AppendFormat("{0}", "</tr>");
			_sb.AppendLine();

			// add row to report
			foreach (DataRow _dr in Source.Rows)
			{
				_sb.AppendFormat("{0}", "<tr>");
				foreach (DataColumn _dc in Source.Columns)
					if (_dc.ColumnName != "CUSTCODE")
						if (_dc.Ordinal == 1)
						{
							_sb.AppendFormat("<th scope='row'>{0}</th>", _dr[_dc.Ordinal]);
						}
						else
						{
							if (_dc.DataType == typeof(decimal))
							{
								_sb.AppendFormat("<td style='text-align:right'>{0:N2}</td>", _dr[_dc.Ordinal]);
								_sb.AppendLine();
							}
							else
							{
								_sb.AppendFormat("<td>{0}</td>", _dr[_dc.Ordinal]);
								_sb.AppendLine();
							}
						}
				_sb.AppendFormat("{0}", "</tr>");
				_sb.AppendLine();
			}
			_sb.AppendFormat("{0}", "</table>");
			_sb.AppendLine();

			var _template = Resources.htmltemplate.Replace("$(CONTENT)", _sb.ToString());

			File.WriteAllText("MaterialOutstanding.html", _template);
			wb.Url = new Uri(Path.GetFullPath("MaterialOutstanding.html"));
			wb.Document.InvokeScript("Hilight");
		} // end GenerateWebReport

		#endregion
	}
}