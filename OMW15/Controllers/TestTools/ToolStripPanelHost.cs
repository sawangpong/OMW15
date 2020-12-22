using System.Windows.Forms;

namespace OMW15.Controllers.TestTools
{
	public class ToolStripPanelHost : ToolStripControlHost
	{
		// Call the base constructor passing in a MonthCalendar instance. 
		public ToolStripPanelHost()
			: base(new Panel())
		{
			Width = 400;
		}


		public Panel ToolStripPanel
		{
			get { return Control as Panel; }
		}
	}
}