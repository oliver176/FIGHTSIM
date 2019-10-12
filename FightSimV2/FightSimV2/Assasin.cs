using System;
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
            maxHP = 750 * statModifier;
            hp = maxHP * statModifier;
            armor = assasinArmor;
            Sword();
            minHitChance = 50;
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
