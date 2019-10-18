namespace FightSimV2
{
    internal class Pike : Vapen
    {
        public Pike()
        {
            minDmg = 40 * statModifier;
            maxDmg = 90 * statModifier;
            minHitChance = 33;
            maxHitChance = 100;
            weaponName = "Pike";
        }
    }
}