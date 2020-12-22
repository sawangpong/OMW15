using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace OMW15.Tools.ToolControls
{
	public partial class MonthPopup : UserControl
	{
		#region member

		private DateTime _selectedDate = DateTime.Today;
		private string _title = "Select Date";
		#endregion

		#region properties

		public DateTime SelectedDate
		{
			get
			{
				return (Microsoft.VisualBasic.Information.IsDate(_selectedDate) ? _selectedDate : DateTime.Today);
			}
			set
			{
				_selectedDate = value;
				this.Invalidate();
			}
		}

		public string Title
		{
			set
			{
				_title = value;
			}
		}

		#endregion

		#region helper

		public event EventHandler DateSelected;
		public event EventHandler ButtonClick;

		private void OnButtonClick(EventArgs e)
		{
			//this.ButtonClick(this.btnMonth, e);
			this.ButtonClick(this, e);
		}

		private void OnDateSelected(EventArgs e)
		{
			//this.DateSelected(_selectedDate, e);
			this.DateSelected(this, e);
		}

		#endregion

		public MonthPopup()
		{
			InitializeComponent();
		}

		private void MonthPopup_SizeChanged(object sender, EventArgs e)
		{
			this.Size = new Size(this.Height, this.Height);
		}

		private void btnMonth_Click(object sender, EventArgs e)
		{
			this.OnButtonClick(new EventArgs());

			using (PopupMonth pm = new PopupMonth())
			{
				pm.Title = _title;
				pm.DateSelectd = _selectedDate;
				pm.StartPosition = FormStartPosition.CenterScreen;
				if (pm.ShowDialog() == DialogResult.OK)
				{
					_selectedDate = pm.DateSelectd;
				}
			}
			this.OnDateSelected(new EventArgs());
		}

		private void MonthPopup_Load(object sender, EventArgs e)
		{
			this.btnMonth.FlatStyle = FlatStyle.Flat;
			this.btnMonth.FlatAppearance.BorderSize = 0;
			this.btnMonth.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			this.btnMonth.FlatAppearance.MouseOverBackColor = SystemColors.Control;

			// debug
			//MessageBox.Show(_selectedDate.ToShortDateString(), "Property SelectedDate");
			// end 
		}
	}
}
