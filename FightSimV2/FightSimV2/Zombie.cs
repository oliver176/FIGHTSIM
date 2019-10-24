namespace FightSimV2
{
    internal class Zombie : Creature
    {

        public Zombie()
        {
            maxHP = 1000 * statModifier;
            SetName("Zombie");
            hp = maxHP;
            armor = 1;
        }
    }
}