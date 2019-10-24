namespace FightSimV2
{
    internal class Goblin : Creature
    {

        public Goblin()
        {
            maxHP = 400 * statModifier;
            SetName("Goblin");
            hp = maxHP * statModifier;
            armor = 2;
        }
    }
}