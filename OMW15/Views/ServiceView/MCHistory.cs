using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers;
using OMW15.Models;
using OMW15.Shared;
using OMW15.Views;


namespace OMW15.Views.ServiceView
{
	public partial class MCHistory : Form
	{
		#region class field member

		private string _selectedMachineModel = string.Empty;
		private string _selectedSerialNo = string.Empty;
		private string _customerCode = string.Empty;
		private string _customerName = string.Empty;
		private string _orderCode = string.Empty;
		private int _selectedOrderId = 0;
		private string _fileURLpath = string.Empty;
		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetMachineModelList()
		{
			this.tscbxModel.ComboBox.BeginUpdate();
			this.tscbxModel.ComboBox.DataSource = new Models.ProductModel.ProductDAL().GetProdcutModelList();
			this.tscbxModel.ComboBox.DisplayMember = "MODELDISPLAY";
			this.tscbxModel.ComboBox.ValueMember = "MODEL";
			this.tscbxModel.ComboBox.EndUpdate();

		} // end GetMachineModelList

		private void FindCustomer(string MachineModel, string SerialNo)
		{
			DataTable _dtCust = new Models.ProductModel.ProductDAL().GetCustomerListByMachine(MachineModel, SerialNo);

			if (_dtCust.Rows.Count > 0)
			{
				if (_dtCust.Rows.Count > 1)
				{
					using (Views.ServiceView.MachineOwnerList _owners = new MachineOwnerList(_dtCust))
					{
						_owners.StartPosition = FormStartPosition.CenterScreen;
						if (_owners.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
						{
							_customerCode = _owners.OwnerCode;
							_customerName = _owners.OwnerName;
							_selectedSerialNo = _owners.SerialNo;
						}
					}
				}
				else
				{
					_customerCode = _dtCust.Rows[0]["OWNERCODE"].ToString();
					_customerName = _dtCust.Rows[0]["OWNER"].ToString();
					_selectedSerialNo = _dtCust.Rows[0]["SERIALNO"].ToString();
				}
				this.lbOwnerCode.Text = _customerCode;
				this.lbOwnerName.Text = _customerName;
				this.tstxtSN.Text = _selectedSerialNo;

				this.GetOrderByOwner(_customerCode, _selectedMachineModel, _selectedSerialNo);
			}
			else
			{
				this.tstxtSN.Text = string.Empty;
				this.tsbtnSN.PerformClick();
			}

		}// end FindCustomer

		private void GetOrderByOwner(string OwnerCode, string MachineModel, string SerialNo)
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = new Models.ServiceModel.ServiceJobDAL().GetOrderListByMachine(OwnerCode, MachineModel, SerialNo);

			// hiding columns
			this.dgv.Columns["ID"].Visible = false;
			this.dgv.Columns["ORDERCODE"].Visible = false;

			this.dgv.ResumeLayout();

		} // end GetOrderByOwner

		private void CreateHTMLReport(int OrderId, string OrderCode)
		{
			StringBuilder content = new StringBuilder();
			ORDERMAINTENANCE _order = new Models.ServiceModel.ServiceJobDAL().GetJobOrderInfo(OrderId);

			DataTable _dtFixed = new Models.ServiceModel.ServiceJobDAL().GetJobOrderFixedItems(OrderCode, OrderId);


			// create Report Header
			content.AppendFormat("<H4>{0}</H4>", "Machine History Report");
			content.Append("<div class='material'>");
			content.AppendFormat("หมายเลขใบงาน: <strong>{0}-{1}</strong> &nbsp;&nbsp;&nbsp; วันที่ : <strong>{2}</strong> &nbsp;&nbsp;&nbsp; สถานะ : <strong>{3}</strong><br>", _order.orderCode, _order.s_order, _order.orderdate.Value.ToShortDateString(), _order.status.Value == 1 ? "Active" : "Closed");
			content.AppendFormat("ชื่อลูกค้า: <strong>{0} {1}</strong><br>", _order.acccustcode, _order.cus_na);
			content.AppendFormat("รุ่นเครื่องจักร: <strong>{0}</strong> &nbsp;&nbsp;&nbsp; หมายเลขเครื่องจักร : <strong>{1}</strong><br>", _order.type, _order.s_no);
			content.Append("</div>");

			// create table for error 
			content.Append("<table class='datatableTop'>");
			content.Append("<tr valign=top>");
			content.Append("<td width=50%>");
			content.Append("<div class='material'>");
			content.AppendFormat("สาเหตุที่เสีย : <strong>{0}</strong><br>", _order.errorcode);
			content.AppendFormat("<strong>{0}</strong><br>", _order.error);
			content.AppendFormat("ค่าแรงซ่อม : <strong>{0:N2}</strong><br>", _order.servicecost);
			content.AppendFormat("ค่าอะไหล่ : <strong>{0:N2}</strong><br>", _order.sparepartcost);
			content.Append("</div>");
			content.Append("</td>");

			// put content of date of repairing
			content.Append("<td width=50%>");
			if (_dtFixed.Rows.Count > 0)
			{
				content.Append("<div class='material'>");
				foreach (DataRow dr in _dtFixed.Rows)
				{
					content.AppendFormat("วันที่ซ่อม: <strong>{0}</strong> &nbsp;&nbsp", Convert.ToDateTime(dr["DATEFIXED"].ToString()).ToShortDateString());
					content.AppendFormat("ช่างบริการ: <strong>{0}</strong>", dr["ENGINEER1"].ToString());
					if (!string.IsNullOrEmpty(dr["ENGINEER2"].ToString()))
					{
						content.AppendFormat("<strong>,{0}</strong>", dr["ENGINEER2"].ToString());
						if (!string.IsNullOrEmpty(dr["ENGINEER3"].ToString()))
						{
							content.AppendFormat("<strong>,{0}</strong>", dr["ENGINEER3"].ToString());
						}
						if (!string.IsNullOrEmpty(dr["ENGINEER4"].ToString()))
						{
							content.AppendFormat("<strong>,{0}</strong>", dr["ENGINEER4"].ToString());
						}
					}
					content.Append("<br><strong>รายการซ่อม:</strong><br>");
					content.AppendFormat("<textarea rows='15' cols='65' readonly>{0}</textarea><br>", dr["FIXEDDETAIL"].ToString());
					content.Append("<br>");
				}
				content.Append("</div>");
			}
			content.Append("</td>");
			content.Append("</tr>");
			// end content

			content.Append("</table>");
			content.Append("<br>");

			// create data source for spare part used for selected order
			DataTable dt = new Models.WarehouseModel.IssueDAL().GetSparePartItems(OrderId);

			// crate HTML report if the spare part has records
			if (dt.Rows.Count > 0)
			{
				this.GetSparePartUsedHTMLReportContent(dt, ref content);
			}

			// My.Resources - VB.Net syntax
			string template = Properties.Resources.htmltemplate;
			template = template.Replace("$(CONTENT)", content.ToString());
			System.IO.File.WriteAllText("MCHistoryReport.html", template);
			_fileURLpath = System.IO.Path.GetFullPath("MCHistoryReport.html");
			this.webBrowser1.Url = new Uri(_fileURLpath);

			//this.webBrowser1.Document.InvokeScript(" hilite");
			this.webBrowser1.Document.InvokeScript("hilite");

		} // end CreateDataForHTMLReport

		private void GetSparePartUsedHTMLReportContent(DataTable DataSource, ref StringBuilder ReportContent)
		{
			ReportContent.Append("<table class='datatable'>");
			ReportContent.Append("<th><tr><strong>รายการอะไหล่ที่ใช้</strong></tr></th>");
			ReportContent.Append("<tr>");

			// create table column header
			foreach (DataColumn dc in DataSource.Columns)
			{
				ReportContent.AppendFormat("<th>{0}</th>", dc.ColumnName);
			}
			ReportContent.Append("</tr>");

			foreach (DataRow dr in DataSource.Rows)
			{
				ReportContent.Append("<tr>");
				foreach (DataColumn dcc in DataSource.Columns)
				{
					if (dcc.Ordinal == 0)
					{
						ReportContent.AppendFormat("<td>{0}</td>", dr[dcc.Ordinal]);
					}
					else
					{
						switch (dcc.DataType.ToString())
						{
							case "System.Decimal":
								ReportContent.AppendFormat("<td style='text-align: right'>{0:N2}</td>", dr[dcc.Ordinal]);
								break;
							default:
								ReportContent.AppendFormat("<td>{0}</td>", dr[dcc.Ordinal]);
								break;
						}
					}
				}
				ReportContent.Append("</tr>");
			}

			ReportContent.Append("</table>");

		} // end GetSparePartUsedHTMLReportContent

		#endregion


		public MCHistory()
		{
			InitializeComponent();
		}

		private void MCHistory_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			// get machine model list
			this.GetMachineModelList();
			this.btnPrintHTMLReport.Enabled = false;

		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tscbxModel_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedMachineModel = this.tscbxModel.ComboBox.SelectedValue.ToString();
			}
			catch
			{
				_selectedMachineModel = string.Empty;
			}
		}

		private void tsbtnSN_Click(object sender, EventArgs e)
		{
			_selectedSerialNo = this.tstxtSN.Text;
			this.FindCustomer(_selectedMachineModel, _selectedSerialNo);
		}

		private void tsbtnFindMachine_Click(object sender, EventArgs e)
		{
			_selectedSerialNo = this.tstxtSN.Text;
			this.FindCustomer(_selectedMachineModel, _selectedSerialNo);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedOrderId = Convert.ToInt32(this.dgv["ID", e.RowIndex].Value);
			_orderCode = this.dgv["ORDERCODE", e.RowIndex].Value.ToString();

			this.btnPrintHTMLReport.Enabled = false;
			// Create the WEB REPORT
			this.CreateHTMLReport(_selectedOrderId, _orderCode);
		}

		private void tstxtSN_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				this.tsbtnFindMachine.PerformClick();
			}
		}

		private void btnPrintHTMLReport_Click(object sender, EventArgs e)
		{
			// add an event handler that prints the document
			//this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(PrintDocument);
			////this.webBrowser1.Url = new Uri(_fileURLpath);

			this.webBrowser1.Print();
		}

		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			this.btnPrintHTMLReport.Enabled = true;
		}
	}
}
