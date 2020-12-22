using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers;
using OMW15.Models;
using OMW15.Shared;
using OMW15.Views;

namespace OMW15.Models.SaleModel
{
	public class SaleQTItems:List<QUOTATIONLL>
	{
		private OLDMOONEF _om;

		#region class helper Method

		public void AddQuotationItem(QUOTATIONLL Item)
		{
			this.Add(Item);
		}

		#endregion


		#region constructor

		public SaleQTItems()
		{
		}

		public SaleQTItems(QUOTATIONLL Item)
		{
			this.Add(Item);
		}

		#endregion

	}


}
