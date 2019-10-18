using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Brute : Character
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
