using System;
using System.Data;
using System.Data.Entity.Core;
using System.Windows.Forms;

namespace OMW15.Views.ToolViews
{
	public partial class ErrorDisplay : Form
	{
		private void ErrorDisplay_Load(object sender, EventArgs e)
		{
			this.pnlTitle.BackColor = omglobal.FB_BLUE;
			this.pnlTitle.ForeColor = System.Drawing.Color.White;

			lbTitle.Text = _title;
			txtMsg.Text = _message;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		#region Overload Contructor

		private readonly string _title = "Message";
		private readonly string _message = "Nothing to display";

		public ErrorDisplay()
		{
			InitializeComponent();
		}

		public ErrorDisplay(string Title, string Message)
		{
			InitializeComponent();
			_title = Title;
			_message = Message;
		}

		public ErrorDisplay(string Caption, string Title, object Message)
		{
			InitializeComponent();
			Text = Caption;
			_title = Title;
			_message = Message.ToString();
		}

		public ErrorDisplay(string Caption, string Title, EntitySqlException Message)
		{
			InitializeComponent();
			Text = Caption;
			_title = Title;
			_message = Message.ToString();
		}

		#endregion
	}
}