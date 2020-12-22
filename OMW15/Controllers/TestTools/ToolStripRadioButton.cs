using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Controllers.TestTools
{
	public class ToolStripRadioButton : ToolStripButton
	{
		private int radioButtonGroupId;
		private bool updateButtonGroup = true;

		public ToolStripRadioButton()
		{
			CheckOnClick = true;
		}

		[Category("Behavior")]
		public int RadioButtonGroupId
		{
			get { return radioButtonGroupId; }
			set
			{
				radioButtonGroupId = value;

				// Make sure no two radio buttons are checked at the same time
				UpdateGroup();
			}
		}

		[Category("Appearance")]
		public Color CheckedColor1 { get; set; } = Color.FromArgb(71, 113, 179);

		[Category("Appearance")]
		public Color CheckedColor2 { get; set; } = Color.FromArgb(98, 139, 205);

		// Set check value without updating (disabling) other radio buttons in the group
		private void SetCheckValue(bool checkValue)
		{
			updateButtonGroup = false;
			Checked = checkValue;
			updateButtonGroup = true;
		}

		// To make sure no two radio buttons are checked at the same time
		private void UpdateGroup()
		{
			if (Parent != null)
			{
				// Get number of checked radio buttons in group
				var checkedCount =
					Parent.Items.OfType<ToolStripRadioButton>().Count(x => x.RadioButtonGroupId == RadioButtonGroupId && x.Checked);

				if (checkedCount > 1)
					Checked = false;
			}
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			Checked = true;
		}

		protected override void OnCheckedChanged(EventArgs e)
		{
			if (Parent != null && updateButtonGroup)
				foreach (var radioButton in Parent.Items.OfType<ToolStripRadioButton>())
					if (radioButton != this && radioButton.RadioButtonGroupId == RadioButtonGroupId)
						radioButton.SetCheckValue(false);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (Checked)
			{
				var checkedBackgroundBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), CheckedColor1,
					CheckedColor2);
				e.Graphics.FillRectangle(checkedBackgroundBrush, new Rectangle(new Point(0, 0), Size));
			}

			base.OnPaint(e);
		}
	}
}