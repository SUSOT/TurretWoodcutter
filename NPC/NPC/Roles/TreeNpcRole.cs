using _01_Works.CM._01_Scripts.NPC.NPC.Actions;
using _01_Works.CM._01_Scripts.NPC.NPC.Npcs;
using System;
using UnityEngine;

namespace _01_Works.CM._01_Scripts.NPC.NPC.Roles
{
    public class TreeNpcRole : INpcRole
    {
        private readonly INpcActionFactory _actionFactory;

        public TreeNpcRole(INpcActionFactory actionFactory)
        {
            _actionFactory = actionFactory ?? throw new ArgumentNullException(nameof(actionFactory));
        }

        public bool TryGetNextAction(Npc npc, out INpcAction action)
        {
            TreeNpc treeNpc = npc as TreeNpc;
            action = null;

            if (!treeNpc)
            {
                return false;
            }

            if (treeNpc.IsLoadFull)
            {
                action = _actionFactory.CreateStoreWood();
                return true;
            }

            if (treeNpc.TryAcquireTreeTarget(out Transform target))
            {
                action = _actionFactory.CreateChopTree(target);
                return true;
            }

            return false;
        }
    }
}
