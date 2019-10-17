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
        protected int maxHP;
        protected int level = 1;
        int xp = 0;
        protected int xpRequired = 100;
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

        public virtual void Present(string weaponName)
        {
            Console.Clear();
            Console.WriteLine("Name: " + GetName());
            Console.WriteLine("\nHP: " + hp);
            Console.WriteLine("Equipped Weapon: " + GetWeaponName());
            Console.WriteLine("Current Stance: " + weaponName);
            Console.WriteLine("Armor rating: " + armor);
            Console.WriteLine("____________________________________");

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
        private void CheckXP()
        {
            if (xp >= xpRequired)
            {
                level++;
                xpRequired += 50;
                xp = 0;
            }
        }
        protected int GetXP()
        {
            return xp;
        }
        public void ReceiveXP()
        {
            xp += 50;
            CheckXP();
        }
        public virtual void ModifyStats(int playerLevel)
        {
            statModifier = playerLevel; //Improve stats beroende på lvl
            hp = maxHP * statModifier;
            armor *= statModifier;
            minDmg *= statModifier;
            maxDmg *= statModifier;
        }
    }
}
