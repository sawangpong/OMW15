using OMW15.Models.ToolModel;
using System.Data;
using System.Linq;

namespace OMW15.Models.ProductionModel
{
	public class ProductionMachineDAL
	{
		#region constructor
		private readonly OLDMOONEF1 _om;
		public ProductionMachineDAL()
		{
			_om = new OLDMOONEF1();
		}
		#endregion

		#region MachineGroup

		public DataTable GetMachineGroup()
		{
			return new DataConnect($"EXECUTE dbo.usp_OM_PRODUCTION_MACHINE_GROUP", omglobal.SysConnectionString).ToDataTable;
		}

		public int UpdateMachineGroup(PRODUCTION_MACHINEGROUP mcGroup)
		{
			int _result = 0;
			try
			{
				if (mcGroup.MC_GROUPID == 0)
				{
					_om.PRODUCTION_MACHINEGROUP.Add(mcGroup);
				}
				else
				{
					PRODUCTION_MACHINEGROUP mg = _om.PRODUCTION_MACHINEGROUP.Find(mcGroup.MC_GROUPID);
					mg.MC_GROUPNAME = mcGroup.MC_GROUPNAME;
				}
				_result = _om.SaveChanges();
			}
			catch
			{
			}
			return _result;
		}

		public int RemoveMachineGroup(int id)
		{
			int _result = 0;
			try
			{
				_om.PRODUCTION_MACHINEGROUP.Remove(_om.PRODUCTION_MACHINEGROUP.Find(id));
				_result = _om.SaveChanges();
			}
			catch { }
			return _result;
		}

		#endregion

		#region MachineGroupMember

		public DataTable GetMachineMember(int groupId)
		{
			return _om.PRODUCTION_MC_MEMBER.Where(x => x.MC_GROUP == groupId).ToDataTable();
		}

		public DataTable GetMachineMemberByGroup(int groupId)
		{
			return _om.PRODUCTION_MC_MEMBER
						.Where(x => x.MC_GROUP == groupId)
						.Select(c => new
						{
							c.ID,
							c.MC_NUMBER,
							MachineDetail = c.MC_NUMBER + "::" + c.MC_NAME
						})
						.OrderBy(o => o.MC_NUMBER)
						.ToDataTable();
		}


		public PRODUCTION_MC_MEMBER GetMachineGroupMemberInfo(int id)
		{
			return _om.PRODUCTION_MC_MEMBER.Find(id);
		}

		public int UpdateMachineGroupMember(PRODUCTION_MC_MEMBER mcMember)
		{
			int _result=0;
			try
			{
				if(mcMember.ID == 0)
				{
					_om.PRODUCTION_MC_MEMBER.Add(mcMember);
				}
				else
				{
					PRODUCTION_MC_MEMBER _member = GetMachineGroupMemberInfo(mcMember.ID);
					_member.MC_GROUP = mcMember.MC_GROUP;
					_member.MC_NAME = mcMember.MC_NAME;
					_member.MC_NUMBER = mcMember.MC_NUMBER;
				}
				_result = _om.SaveChanges();
			}
			catch { }
			return _result;
		}

		public int RemoveMachineGroupMember(int id)
		{
			int _result = 0;
			try
			{
				_om.PRODUCTION_MC_MEMBER.Remove(GetMachineGroupMemberInfo(id));
				_result = _om.SaveChanges();
			}
			catch { }
			return _result;
		}

		#endregion

	}
}
