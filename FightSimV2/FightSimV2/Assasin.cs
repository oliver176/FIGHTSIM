﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Assasin : Character
    {
        int assasinArmor = 2;
        public Assasin()
        {
            className = "Assasin";
            maxHP = 375 * statModifier;
            hp = maxHP * statModifier;
            armor = assasinArmor;
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
