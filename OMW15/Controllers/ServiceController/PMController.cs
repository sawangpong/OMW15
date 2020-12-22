using OMW15.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Controllers.ServiceController
{
	public class PMController
	{
		// constructor
		public PMController()
		{

		}

		#region class field member

		private PMMC mc = new PMMC();

		#endregion


		#region class property

		public PMMC Machine
		{
			get; set;
		}

		#endregion

		#region class helper 

		public void getMachineForPM(string customerCode, string customer, out string model, out string sn)
		{
			model = "";
			sn = "";

			Views.ServiceView.PMMCList mclist = new Views.ServiceView.PMMCList(customerCode, customer);
			mclist.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			if (mclist.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				model = mclist.Model;
				sn = mclist.SN;

				// create machine from selected model 
				mc = new PMMC();
			}
		}

		public string getNewPMContractNo(DateTime contractDate, out string currentPMYear, out int latestPMNumber)
		{
			currentPMYear = contractDate.GetFullThaiYearFormat();
			latestPMNumber = new Models.ServiceModel.PMDal().getLatestPMContract(currentPMYear);
			return $"{currentPMYear}-{(latestPMNumber + 1):00#}";
		}

		#region PM-Schedule

		#endregion

		public int deleteMachine(int id)
		{
			return new PMDal().deletePMMachine(id);
		}

		#endregion

	}
}
