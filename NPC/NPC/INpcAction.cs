using System.Collections;
using UnityEngine;

namespace _01_Works.CM._01_Scripts.NPC.NPC
{
    public interface INpcAction
    {
        bool RequiresMovement { get; }
        bool IsValid(Npc npc);
        Vector3 GetDestination(Npc npc);
        float GetArrivalDistance(Npc npc);
        bool HasReached(Npc npc);
        void OnAssigned(Npc npc);
        void OnCancelled(Npc npc);
        IEnumerator Execute(Npc npc);
    }
}
