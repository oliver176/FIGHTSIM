using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Assasin : Character
    {
        int assasinArmor = 1;
        public Assasin()
        {
            maxHP = 750 * statModifier;
            hp = maxHP * statModifier;
            armor = assasinArmor;
            Sword();
        }
        public override void ModifyStats()
        {
            statModifier = level; //Improve stats beroende på lvl
            hp = maxHP * statModifier;
            armor *= statModifier;
            minDmg *= statModifier;
            maxDmg *= statModifier;
        }
    }
}
