using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Goblin : Fighter
    {
        public Goblin()
        {
            hp -= 100;
            maxDmg += 20;
        }
    }
}
