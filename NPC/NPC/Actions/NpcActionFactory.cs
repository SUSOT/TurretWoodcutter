using UnityEngine;

namespace _01_Works.CM._01_Scripts.NPC.NPC.Actions
{
    public class NpcActionFactory : INpcActionFactory
    {
        public INpcAction CreateChopTree(Transform target) => new ChopTreeAction(target);

        public INpcAction CreateStoreWood() => new StoreWoodAction();

        public INpcAction CreateTakeWoodFromStorage() => new TakeWoodFromStorageAction();

        public INpcAction CreateSupplyFuel(Transform target) => new SupplyFuelAction(target);

        public INpcAction CreateRepairTower(Transform target) => new RepairTowerAction(target);
    }
}
