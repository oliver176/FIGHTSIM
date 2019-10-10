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
        public string name;
        Random gen = new Random();

        public Fighter(string getName)   //input för namn
        {
            hp = 100;
            dmg = gen.Next(3, 20);
            name = getName;
        }

        public int Attack()
        {
            return dmg;
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
