using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Goblin : Creature
    {
        int goblinHP = 800;

        public Goblin()
        {
            ResetHP();
            SetName("Goblin");
            hp = goblinHP;
            Sword();
        }
        public override int LightAttack(int enemyArmor)
        {
            hitChance = GenRandom(minHitChance, maxHitChance);
            if (hitChance > 33)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return dmg / enemyArmor;
            }
            else return 0;
        }
        public override int HeavyAttack(int enemyArmor)
        {
            hitChance = GenRandom(minHitChance, maxHitChance);
            if (hitChance > 66)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return (dmg / enemyArmor) + minDmg;
            }
            else return 0;
        }
    }
}
