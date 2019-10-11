using System;
using System.Collections.Generic;
using System.IO;
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
            //Läser alla rader från text filen
            string[] nameArray = File.ReadAllLines(@"C:\Users\oliver.sagefors\Documents\GitHub\FIGHTSIM\FightSimV2\FightSimV2\ListOfNames.txt", Encoding.UTF8);
            return nameArray[GenRandom(0, nameArray.Length - 1)]; //returnerar random namn från text filen
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
