namespace FightSimV2
{
    internal class Goblin : Creature
    {
        private int goblinArmor = 2;

        public Goblin()
        {
            maxHP = 400 * statModifier;
            SetName("Goblin");
            hp = maxHP * statModifier;
            armor = goblinArmor;
        }
    }
}