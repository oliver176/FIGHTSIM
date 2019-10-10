using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Fighter
    {
        int hp;
        int dmg;
        int armor;
        public string name;
        Random gen = new Random();

        public Fighter(string getName)   //input för namn
        {
            armor = gen.Next(0, 5);
            hp = 1000;
            name = getName;
        }

        public int Attack(int enemyArmor)
        {
            dmg = gen.Next(50, 100);
            return dmg / enemyArmor;
        }
        public void Hurt(int amount)
        {
            hp -= amount;   //ta dmg amount
        }
        public bool IsAlive()
        {
            if (hp > 0) //om den lever return true
            {
                return true;
            }
            else return false;
        }
        public int GetHp()
        {
            return hp;
        }

    }
}
