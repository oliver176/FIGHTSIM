using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Vapen
    {
        protected int minDmg = 50;
        protected int maxDmg = 100;
        protected int hitChance;
        protected int minHitChance;
        protected int maxHitChance;

        public void Mace()  // olika vapen att välja mellan
        {
            minDmg -= 20;
            maxDmg += 20;
            minHitChance = 0;
            maxHitChance = 85;
        }
        public void Sword()
        {
            minDmg += 20;
            maxDmg -= 20;
            minHitChance = 15;
            maxHitChance = 100;
        }
        public void Pike()
        {
            minDmg -= 10;
            maxDmg -= 10;
            minHitChance = 33;
            maxHitChance = 100;
        }
    }
}
