using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers;
using OMW15.Models;
using OMW15.Shared;
using OMW15.Views;

namespace OMW15.Models.CastingModel
{
	public class CastingFG 
	{
		OLDMOONEF _om;

		#region constructor and destructor
		
		public CastingFG()
		{
			_om = new OLDMOONEF();
		}

		#endregion

	}
}
