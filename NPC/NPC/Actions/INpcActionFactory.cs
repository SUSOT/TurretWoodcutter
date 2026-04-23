using UnityEngine;

namespace _01_Works.CM._01_Scripts.NPC.NPC.Actions
{
    public interface INpcActionFactory
    {
        INpcAction CreateChopTree(Transform target);
        INpcAction CreateStoreWood();
        INpcAction CreateTakeWoodFromStorage();
        INpcAction CreateSupplyFuel(Transform target);
        INpcAction CreateRepairTower(Transform target);
    }
}
