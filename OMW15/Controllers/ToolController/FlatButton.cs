using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Tools.ToolControls
{
	public class FlatButton : Button
	{
		public enum ButtonImageStyle
		{
			Normal,
			Chart,
			Filter,
			Search,
			Find,
			MonthSearch
		}

		#region class field member

		private ButtonImageStyle _style = ButtonImageStyle.Search;

		#endregion

		#region class properties
		[DefaultValue(ButtonImageStyle.Search),Description("Setting Style to FlatButton Control"), Browsable(true)]
		public ButtonImageStyle Style
		{
			get
			{
				return _style;
			}
			set
			{
				_style = value;
				this.UpdateUI();
				this.Invalidate();
			}
		}

		#endregion


		#region class helper

		private void UpdateUI()
		{
			switch (_style)
			{
				case ButtonImageStyle.Chart:
					this.Image = global::OMW15.Properties.Resources.graphhs;
					break;
				case ButtonImageStyle.Filter:
					this.Image = global::OMW15.Properties.Resources.Filter2HS;
					break;
				case ButtonImageStyle.Search:
					this.Image = global::OMW15.Properties.Resources.ZoomHS;
					break;
				case ButtonImageStyle.Find:
					this.Image = global::OMW15.Properties.Resources.FindHS;
					break;
				case ButtonImageStyle.MonthSearch:
					this.Image = global::OMW15.Properties.Resources.MonthlyViewHS;
					break;
				case ButtonImageStyle.Normal:
					break;
			}
		}


		#endregion

		public FlatButton()
		{
			this.Text = string.Empty;
			this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.FlatAppearance.BorderSize = 0;
			this.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			this.FlatAppearance.MouseOverBackColor = SystemColors.Control;
			this.ImageAlign = ContentAlignment.MiddleCenter;
			this.UpdateUI();
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.OnResize(new EventArgs());
			this.Invalidate();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Size = new Size(this.Height, this.Height);
			this.Invalidate();
		}
	}
}
