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
        public int armor;
        public string name;

        public Fighter()   //input för namn
        {
            armor = GenRandom(1, 5);
            hp = 1000;
            name = Names();
        }

        public int Attack(int enemyArmor)
        {
            dmg = GenRandom(50, 100);
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
        public string Names()
        {
            List<string> nameList = new List<string>(new string[] {"Oliver", "Eric", "Vladivostok", "Gaston", "Muntop", "Doc", "Marley", "Heehoo"});
            return nameList[GenRandom(0, nameList.Count - 1)];  //returnerar random namn från string listan
        }
        public int GenRandom(int min, int max)
        {
            
            Random gen = new Random();
            return gen.Next(min, max);
        }
    }
}
