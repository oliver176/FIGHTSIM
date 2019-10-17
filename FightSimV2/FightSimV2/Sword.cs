using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Sword : Vapen
    {
        public Sword()
        {
            minDmg = 70 * statModifier;
            maxDmg = 80 * statModifier;
            minHitChance = 15;
            maxHitChance = 100;
            weaponName = "Sword";
        }
    }
}
