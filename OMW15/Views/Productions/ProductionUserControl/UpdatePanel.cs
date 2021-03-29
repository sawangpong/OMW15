using System;
using System.Drawing;
using System.Windows.Forms;

namespace OMW15.Views.Productions.ProductionUserControl
{
	public partial class UpdatePanel : UserControl
	{
		#region class field member
		private Color _defaultBackgroundColor = Color.DarkBlue;

		private decimal _currentValue = 0m;


		#endregion


		#region class property

		public string Title
		{
			set
			{
				lbTitle.Text = value;
				this.Validate();
			}
		}

		public string Unit
		{
			set
			{
				lbUnit.Text = value;
				this.Validate();
			}
		}

		public decimal TotalQty
		{
			get
			{
				return _currentValue;
			}
			set
			{
				if (_currentValue != value)
				{
					_currentValue = value;
					lbTotalQty.Text = $"{_currentValue:N0}";
					this.BackColor = Color.Orange;
					timer1.Enabled = true;
				}
				this.Validate();
			}
		}

		private decimal Convert(string text)
		{
			throw new NotImplementedException();
		}

		public decimal HourNeed
		{
			set
			{
				lbHourNeed.Text = $"{value:N2}";
				this.Validate();
			}
		}

		#endregion



		public UpdatePanel()
		{
			InitializeComponent();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.BackColor = _defaultBackgroundColor;

		}

		private void UpdatePanel_Load(object sender, EventArgs e)
		{
	
		}
	}
}
