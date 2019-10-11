using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Zombie : Creature
    {
        int zombieHP = 2000;

        public Zombie()
        {
            ResetHP();
            SetName("Zombie");
            hp = zombieHP;
            Mace();

        }
        public override int LightAttack(int enemyArmor)
        {
            hitChance = GenRandom(20, 80);
            if (hitChance > 33)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return dmg / enemyArmor;
            }
            else return 0;
        }
        public override int HeavyAttack(int enemyArmor)
        {
            hitChance = GenRandom(20, 80);
            if (hitChance > 66)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return (dmg / enemyArmor) + minDmg;
            }
            else return 0;
        }
    }
}
