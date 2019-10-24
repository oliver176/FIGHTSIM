namespace FightSimV2
{
    internal class Warrior : Character
    {

        public Warrior()
        {
            className = "Warrior";
            maxHP = 500 * statModifier;
            hp = maxHP * statModifier;
            armor = 5;
        }

        public override void ModifyStats(int playerLevel, int minDmg, int maxDmg)
        {
            if (xp >= xpRequired)
            {
                level++;
                xpRequired += 50;
                xp = 0;

                statModifier = playerLevel; //Improve stats beroende på lvl
                hp = maxHP + (50 * statModifier);
                armor = armor + (3 * statModifier);
                minDmg = minDmg + (20 * statModifier);
                maxDmg = maxDmg + (30 * statModifier);
            }
            else hp = maxHP;
        }
    }
}