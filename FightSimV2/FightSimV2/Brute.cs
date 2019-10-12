using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Brute : Character
    {
        int bruteArmor = 5;
        public Brute()
        {
            className = "Brute";
            maxHP = 1500 * statModifier;
            hp = maxHP * statModifier;
            armor = bruteArmor;
            Sword();
        }
        public override void ModifyStats(int playerLevel)
        {
            statModifier = playerLevel; //Improve stats beroende på lvl
            hp = maxHP * statModifier;
            armor *= statModifier;
            minDmg *= statModifier;
            maxDmg *= statModifier;
        }
    }
}
