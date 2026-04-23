using _01_Works.CM._01_Scripts.NPC.NPC.Actions;
using _01_Works.CM._01_Scripts.NPC.NPC.Npcs;
using System;
using UnityEngine;

namespace _01_Works.CM._01_Scripts.NPC.NPC.Roles
{
    public class TowerNpcRole : INpcRole
    {
        private readonly INpcActionFactory _actionFactory;

        public TowerNpcRole(INpcActionFactory actionFactory)
        {
            _actionFactory = actionFactory ?? throw new ArgumentNullException(nameof(actionFactory));
        }

        public bool TryGetNextAction(Npc npc, out INpcAction action)
        {
            TowerNpc towerNpc = npc as TowerNpc;
            action = null;

            if (!towerNpc)
            {
                return false;
            }

            if (towerNpc.HasLoad)
            {
                if (towerNpc.TryGetBestFuelTarget(out Transform target))
                {
                    action = _actionFactory.CreateSupplyFuel(target);
                    return true;
                }

                return false;
            }

            if (towerNpc.CanTakeFromStorage())
            {
                action = _actionFactory.CreateTakeWoodFromStorage();
                return true;
            }

            return false;
        }
    }
}
