using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Tools.ToolControls
{
	public partial class PopupMonth : Form
	{
		#region member

		private string _title = "Select";
		private DateTime _dateSelected = DateTime.Today;

		#endregion

		#region properties
		public string Title
		{
			set
			{
				_title = value;
			}
		}

		public DateTime DateSelectd
		{
			get
			{
				return _dateSelected;
			}
			set
			{
				_dateSelected = value;
				this.Invalidate();
			}
		}

		#endregion


		public PopupMonth()
		{
			InitializeComponent();
		}

		private void PopupMonth_Load(object sender, EventArgs e)
		{
			// debug
			//MessageBox.Show(_dateSelected.ToShortDateString(), "Property DateSelected");
			// end 
			this.Text = _title;
			//this.calendar.TodayDate = _dateSelected;
			this.calendar.SelectionStart = _dateSelected;
			this.calendar.SelectionEnd = _dateSelected;
		}

		private void PopupMonth_SizeChanged(object sender, EventArgs e)
		{
			this.Size = new Size(this.calendar.Width + 3, (this.calendar.Height + this.pnlCommand.Height + 30));
		}

		private void calendar_DateSelected(object sender, DateRangeEventArgs e)
		{
			_dateSelected = e.Start; 
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			_dateSelected = calendar.SelectionStart;
		}
	}
}
