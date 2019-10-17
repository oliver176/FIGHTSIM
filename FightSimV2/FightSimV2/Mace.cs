namespace FightSimV2
{
    class Mace : Vapen
    {
        public Mace()
        {
            minDmg = 20 * statModifier;
            maxDmg = 120 * statModifier;
            minHitChance = 0;
            maxHitChance = 85;
            weaponName = "Mace";
        }
    }
}