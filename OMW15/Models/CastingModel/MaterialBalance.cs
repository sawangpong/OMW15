using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using OMW15.Controllers.ToolController;
using OMW15.Shared;
using System.Text;

namespace OMW15.Models.CastingModel {
	public class MaterialBalance {
		private readonly OLDMOONEF1 _om;


		// CONSTRUCTOR
		public MaterialBalance() {
			_om = new OLDMOONEF1();
		}

		#region class helper

		public async Task<DataTable> GetAsyncCustomerBalance(int YearOpenBalance, string CustomerCode, string MaterialCategory) {
			return await Task.Run(() => {
				var result = new DataTable();

				// create customer list from SaleOrders
				var customers = (from s in _om.SALEORDERS.AsEnumerable()
								 join c in _om.CUSTOMERS on s.CUSTCODE equals c.CUSTCODE
								 join sy in _om.SYSDATAs on s.DELIVERMAT.ToString() equals sy.KEYVALUE
								 where s.ISDELETE == false
									   && s.ISCANCEL == false
									   && s.FISCYEAR == YearOpenBalance
									   && s.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
									   && sy.GROUPTITLE == "MATERIAL"
								 select new {
									 s.CUSTCODE,
									 c.CUSTNAME,
									 sy.CATEGORY
								 }).Distinct().OrderBy(o => o.CUSTCODE).ThenBy(o => o.CATEGORY).AsParallel();

				// create customer list from material receive
				var matReceive = (from mr in _om.MATRECEIVEs.AsEnumerable()
								  join c in _om.CUSTOMERS on mr.CUSTCODE equals c.CUSTCODE
								  join sy in _om.SYSDATAs on mr.MATTYPE.ToString() equals sy.KEYVALUE
								  where mr.ISDELETE == false
										&& sy.GROUPTITLE == "MATERIAL"
										&& mr.RECEIVEDATE.Num2Date().Year == YearOpenBalance
								  select new {
									  mr.CUSTCODE,
									  c.CUSTNAME,
									  sy.CATEGORY
								  }).Distinct().OrderBy(o => o.CUSTCODE).ThenBy(o => o.CATEGORY).AsParallel();

				// join to query
				if (CustomerCode != "" && MaterialCategory != "") {
					var custListByCat =
						customers.Union(matReceive)
							.Distinct()
							.Where(x => x.CUSTCODE == CustomerCode && x.CATEGORY == MaterialCategory)
							.AsParallel();
					result = custListByCat.ToDataTable();
				}
				else if (CustomerCode == "" && MaterialCategory != "") {
					var custList = customers.Union(matReceive).Distinct().Where(x => x.CATEGORY == MaterialCategory).AsParallel();
					result = custList.ToDataTable();
				}
				else if (CustomerCode != "" && MaterialCategory == "") {
					var custList = customers.Union(matReceive).Distinct().Where(x => x.CUSTCODE == CustomerCode).AsParallel();
					result = custList.ToDataTable();
				}
				else if (CustomerCode == "" && MaterialCategory == "") {
					var custList = customers.Union(matReceive).Distinct().AsParallel();
					result = custList.ToDataTable();
				}

				return result;
			});
		} // end GetAsyncCustomerBalance


		public  decimal GetOpenBalanceByCustomer(string customerCode, string materialCategory, int currentYear,
			int currentMonth) {

			//decimal openBalance = new Models.CastingModel.ReturnMaterialDAL().GetLastOpenBalance(customerCode, materialCategory, currentYear);

			// get last balance of last year - end of the year (December)
			// must become to open balance for next year in January
			var lastOpenBalance = new Models.CastingModel.ReturnMaterialDAL().GetLastOpenBalance(customerCode, materialCategory,currentYear);

			var monthForOpenBalance = currentMonth == 1 ? 12 : currentMonth - 1;
			var yearForOpenBalance = currentMonth == 1 ? currentYear - 1 : currentYear;

			try {
				var m =
					_om.MATOPENBALANCEs.FirstOrDefault(
						x => x.CUSTCODE == customerCode && x.MATCAT == materialCategory && x.OPENYEAR == yearForOpenBalance);

				if (m != null)
					switch (monthForOpenBalance) {
						case 1:
							lastOpenBalance = m.BALANCE1;
							break;
						case 2:
							lastOpenBalance = m.BALANCE2;
							break;
						case 3:
							lastOpenBalance = m.BALANCE3;
							break;
						case 4:
							lastOpenBalance = m.BALANCE4;
							break;
						case 5:
							lastOpenBalance = m.BALANCE5;
							break;
						case 6:
							lastOpenBalance = m.BALANCE6;
							break;
						case 7:
							lastOpenBalance = m.BALANCE7;
							break;
						case 8:
							lastOpenBalance = m.BALANCE8;
							break;
						case 9:
							lastOpenBalance = m.BALANCE9;
							break;
						case 10:
							lastOpenBalance = m.BALANCE10;
							break;
						case 11:
							lastOpenBalance = m.BALANCE11;
							break;
						case 12:
							lastOpenBalance = m.BALANCE12;
							break;
					}
			}
			catch {
				MessageBox.Show("Error for retrieving the open balance value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return lastOpenBalance;

		} // end GetOpenBalanceByCustomer

		public int UpdateOpenBalance(List<MATOPENBALANCE> OpenBalanceList) {
			var result = 0;

			using (var scope = new TransactionScope()) {
				try {
					foreach (var m in OpenBalanceList) {
						var bl =
							_om.MATOPENBALANCEs.FirstOrDefault(
								x => x.CUSTCODE == m.CUSTCODE && x.MATCAT == m.MATCAT && x.OPENYEAR == m.OPENYEAR);
						if (bl != null) {
							// found record then edit
							bl.CUSTNAME = m.CUSTNAME;
							bl.BALANCE1 = m.BALANCE1;
							bl.BALANCE2 = m.BALANCE2;
							bl.BALANCE3 = m.BALANCE3;
							bl.BALANCE4 = m.BALANCE4;
							bl.BALANCE5 = m.BALANCE5;
							bl.BALANCE6 = m.BALANCE6;
							bl.BALANCE7 = m.BALANCE7;
							bl.BALANCE8 = m.BALANCE8;
							bl.BALANCE9 = m.BALANCE9;
							bl.BALANCE10 = m.BALANCE10;
							bl.BALANCE11 = m.BALANCE11;
							bl.BALANCE12 = m.BALANCE12;
							bl.LASTUPDATE = DateTime.Now;
							result += _om.SaveChanges();
						}
						else {
							_om.MATOPENBALANCEs.Add(m);
						}
					}
					result += _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex) {
					Alert.DisplayAlert("Error Update", "Can't update Material Stock....", ex.ToString());
				}
			}

			return result;
		} // end UpdateOpenBalance

		#endregion
	} // end class MaterialBalance


	public class MaterialOpenBalace {
		public string ERPCustomerCode {
			get; set;
		}

		public string CustomerName {
			get; set;
		}

		public string MaterialCategory {
			get; set;
		}

		public int YearBalance {
			get; set;
		}

		public decimal OpenBalance1 {
			get; set;
		}

		public decimal OpenBalance2 {
			get; set;
		}

		public decimal OpenBalance3 {
			get; set;
		}

		public decimal OpenBalance4 {
			get; set;
		}

		public decimal OpenBalance5 {
			get; set;
		}

		public decimal OpenBalance6 {
			get; set;
		}

		public decimal OpenBalance7 {
			get; set;
		}

		public decimal OpenBalance8 {
			get; set;
		}

		public decimal OpenBalance9 {
			get; set;
		}

		public decimal OpenBalance10 {
			get; set;
		}

		public decimal OpenBalance11 {
			get; set;
		}

		public decimal OpenBalance12 {
			get; set;
		}
	}
}