using _01_Works.CM._01_Scripts.NPC.NPC.Actions;
using System;

namespace _01_Works.CM._01_Scripts.NPC.NPC.Roles
{
    public class NpcRoleFactory : INpcRoleFactory
    {
        private readonly INpcActionFactory _actionFactory;

        public NpcRoleFactory(INpcActionFactory actionFactory)
        {
            _actionFactory = actionFactory;
        }

        public INpcRole CreateRole(NpcRoleType roleType)
        {
            switch (roleType)
            {
                case NpcRoleType.Tree:
                    return new TreeNpcRole(_actionFactory);
                case NpcRoleType.Tower:
                    return new TowerNpcRole(_actionFactory);
                case NpcRoleType.Repair:
                    return new RepairNpcRole(_actionFactory);
                default:
                    throw new ArgumentOutOfRangeException(nameof(roleType), roleType, "Unknown NPC role type.");
            }
        }
    }
}
