namespace FightSimV2
{
    internal class Brute : Character
    {
        public Brute()
        {
            className = "Brute";
            maxHP = 750 * statModifier;
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
                hp = maxHP + (100 * statModifier);
                armor = armor + (4 * statModifier);
                minDmg = minDmg + (20 * statModifier);
                maxDmg = maxDmg + (20 * statModifier);
            }
            else hp = maxHP;
        }
    }
}