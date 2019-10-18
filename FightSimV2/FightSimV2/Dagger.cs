namespace FightSimV2
{
    internal class Dagger : Vapen
    {
        public Dagger()
        {
            minDmg = 40 * statModifier;
            maxDmg = 120 * statModifier;
            minHitChance = 50;
            maxHitChance = 100;
            weaponName = "Dagger";
        }
    }
}