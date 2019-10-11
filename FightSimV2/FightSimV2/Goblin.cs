using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Goblin : Creature
    {
        public Goblin()
        {
            ResetHP();
            SetName("Goblin");
            hp -= 200;
            maxDmg += 20;
        }
        public override int LightAttack(int enemyArmor)
        {
            hitChance = GenRandom(33, 100);
            if (hitChance > 33)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return dmg / enemyArmor;
            }
            else return 0;
        }
        public override int HeavyAttack(int enemyArmor)
        {
            hitChance = GenRandom(1, 90);
            if (hitChance > 66)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return (dmg / enemyArmor) + minDmg;
            }
            else return 0;
        }
    }
}
