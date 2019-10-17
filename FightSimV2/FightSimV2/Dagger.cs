using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Dagger : Vapen
    {
        public Dagger()
        {
            minDmg = 40 * statModifier;
            maxDmg = 120 * statModifier;
            minHitChance = 50;
            maxHitChance = 100;
            weaponName = "Dagger";
        }
    }
}
