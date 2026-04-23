using _01_Works.CM._01_Scripts.NPC.NPC.Actions;
using _01_Works.CM._01_Scripts.NPC.NPC.Npcs;
using System;
using UnityEngine;

namespace _01_Works.CM._01_Scripts.NPC.NPC.Roles
{
    public class RepairNpcRole : INpcRole
    {
        private readonly INpcActionFactory _actionFactory;

        public RepairNpcRole(INpcActionFactory actionFactory)
        {
            _actionFactory = actionFactory ?? throw new ArgumentNullException(nameof(actionFactory));
        }

        public bool TryGetNextAction(Npc npc, out INpcAction action)
        {
            RepairNpc repairNpc = npc as RepairNpc;
            action = null;

            if (!repairNpc)
            {
                return false;
            }

            if (repairNpc.HasLoad)
            {
                if (repairNpc.TryGetBestRepairTarget(out Transform target))
                {
                    action = _actionFactory.CreateRepairTower(target);
                    return true;
                }

                return false;
            }

            if (repairNpc.CanTakeFromStorage())
            {
                action = _actionFactory.CreateTakeWoodFromStorage();
                return true;
            }

            return false;
        }
    }
}
