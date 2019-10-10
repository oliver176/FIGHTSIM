using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Zombie : Fighter
    {
        public Zombie()
        {
            hp += 1000;
            minDmg -= 20;
        }
    }
}
