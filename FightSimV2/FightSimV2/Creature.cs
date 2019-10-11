using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Creature : Vapen
    {
        protected int hp;
        protected int dmg;
        protected int maxHP;
        string name;
        bool defStance = false;
        bool offStance = false;
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
        public void DefensiveStance()
        {
            if (offStance) //sätt tillbaks dmg till sitt normala värde
            {
                minDmg -= 20;
                maxDmg -= 40;
                offStance = false;
            }
            else if (!defStance)
            {
                armor += 2;
                defStance = true;
            }
        }
        public void OffensiveStance()
        {
            if (defStance) //sätt tillbaks armor till sitt normala värde
            {
                armor -= 2;
                defStance = false;
            }
            else if (!offStance)
            {
                minDmg += 20;
                maxDmg += 40;
                offStance = true;
            }
        }
        public virtual int LightAttack(int enemyArmor)
        {
            hitChance = GenRandom(1, 100);
            if (hitChance > 33)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return dmg / enemyArmor;
            }
            else return 0;
        }
        public virtual int HeavyAttack(int enemyArmor)
        {
            hitChance = GenRandom(1, 100);
            if (hitChance > 66)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return (dmg / enemyArmor) + minDmg;
            }
            else return 0;
        }
        public virtual void Present()
        {
            Console.Clear();
            Console.WriteLine("Name: " + GetName());
            Console.WriteLine("\nHP: " + hp);
            Console.WriteLine("Current Stance: " + GetStance());
            Console.WriteLine("Armor rating: " + armor);
            Console.WriteLine("Min/Max Damage: " + minDmg + "-" + maxDmg);
        }
        public void ResetHP()
        {
            hp = maxHP;
        }
        public string GetStance()
        {
            if (offStance)
            {
                return "Offensive";
            }
            else if (defStance)
            {
                return "Defensive";
            }
            else return "";
        }
    }
}
