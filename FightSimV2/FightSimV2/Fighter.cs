using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Fighter : Vapen
    {
        bool defStance = false;
        bool offStance = false;
        protected int hp;
        protected int dmg;
        protected int hitChance;
        public int armor;
        public string name;

        public Fighter()   //input för namn
        {
            armor = GenRandom(1, 5);
            hp = 1000;
            name = Names();
        }
        public void DefensiveStance()
        {
            if (offStance) //sätt tillbaks dmg till sitt normala värde
            {
                minDmg -= 20;
                maxDmg -= 40;
                offStance = false;
            }
            armor += 2;
            defStance = true;
        }
        public void OffensiveStance()
        {
            if (defStance) //sätt tillbaks armor till sitt normala värde
            {
                armor -= 2;
                defStance = false;
            }
            minDmg += 20;
            maxDmg += 40;
            offStance = true;
        }
        public int LightAttack(int enemyArmor)
        {
            hitChance = GenRandom(1, 100);
            if (hitChance > 33)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return dmg / enemyArmor;
            }
            else return 0;
        }
        public int HeavyAttack(int enemyArmor)
        {
            hitChance = GenRandom(1, 75);
            if (hitChance > 33)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return (dmg / enemyArmor) + minDmg;
            }
            else return 0;
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
            if (hp < 0)
            {
                hp = 0;
            }
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
        public void Present()
        {
            Console.Clear();
            Console.WriteLine("Name: " + name);
            Console.WriteLine("\nStats: ");
            Console.WriteLine("HP: "+ hp);
            Console.WriteLine("Armor rating: " + armor);
            Console.WriteLine("Min/Max Damage: " + minDmg + "-" + maxDmg);
        }
    }
}
