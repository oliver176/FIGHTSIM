using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Pike : Vapen
    {
        public Pike()
        {
            minDmg = 40 * statModifier;
            maxDmg = 90 * statModifier;
            minHitChance = 33;
            maxHitChance = 100;
            weaponName = "Pike";
        }
    }
}
