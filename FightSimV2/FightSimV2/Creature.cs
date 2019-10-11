using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Creature
    {
        protected int hp;
        protected int dmg;
        protected int hitChance;
        protected int maxHP;
        protected string name;
        public int armor;

        public Creature()
        {
            name = Names();
        }
        private string Names()
        {
            List<string> nameList = new List<string>(new string[] { "Oliver", "Eric", "Vladivostok", "Gaston", "Muntop", "Doc", "Marley", "Heehoo" });
            return nameList[GenRandom(0, nameList.Count - 1)];  //returnerar random namn från string listan
        }
        public int GenRandom(int min, int max)
        {

            Random gen = new Random();
            return gen.Next(min, max);
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string nameInput)
        {
            name = nameInput;
        }
        public void RandomName()
        {
            name = Names();
        }
    }
}
