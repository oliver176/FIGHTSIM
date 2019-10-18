namespace FightSimV2
{
    internal class Zombie : Creature
    {
        private int zombieArmor = 1;

        public Zombie()
        {
            maxHP = 1000 * statModifier;
            SetName("Zombie");
            hp = maxHP;
            armor = zombieArmor;
        }
    }
}