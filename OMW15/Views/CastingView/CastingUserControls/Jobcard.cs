using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.CastingView.CastingUserControls
{
	public partial class Jobcard : UserControl
	{
		public Jobcard()
		{
			InitializeComponent();


		}

		private void Jobcard_Load(object sender, EventArgs e)
		{

		}

		protected override void OnPaint(PaintEventArgs e)
		{
			System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
			gp.AddEllipse(0, 0, pic.Width - 3, pic.Height - 3);
			Region rg = new Region(gp);
			pic.Region = rg;
			base.OnPaint(e);
		}
	}
}
