namespace FightSimV2
{
    internal class Assasin : Character
    {
        public Assasin()
        {
            className = "Assasin";
            maxHP = 375 * statModifier;
            hp = maxHP * statModifier;
            armor = 2;
        }

        public override void ModifyStats(int playerLevel, int minDmg, int maxDmg)
        {
            if (xp >= xpRequired)
            {
                level++;
                xpRequired += 50;
                xp = 0;

                statModifier = playerLevel; //Improve stats beroende på lvl
                hp = maxHP + (15 * statModifier);
                armor = armor + (2 * statModifier);
                minDmg = minDmg + (20 * statModifier);
                maxDmg = maxDmg + (50 * statModifier);
            }
            else hp = maxHP;
        }
    }
}