using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Warrior : Character
    {
        int warriorArmor = 3;
        public Warrior()
        {
            className = "Warrior";
            maxHP = 1000 * statModifier;
            hp = maxHP * statModifier;
            armor = warriorArmor;
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
