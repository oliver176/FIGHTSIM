namespace FightSimV2
{
    internal class Sword : Vapen
    {
        public Sword()
        {
            minDmg = 70 * statModifier;
            maxDmg = 80 * statModifier;
            minHitChance = 15;
            maxHitChance = 100;
            weaponName = "Sword";
        }
    }
}