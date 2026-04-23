namespace _01_Works.CM._01_Scripts.NPC.NPC.Roles
{
    public interface INpcRoleFactory
    {
        INpcRole CreateRole(NpcRoleType roleType);
    }
}
