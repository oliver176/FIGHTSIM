using System;
using System.IO;
using System.Text;

namespace FightSimV2
{
    internal class Creature : BaseClass
    {
        //Den klass som player och enemy ärver från
        protected int hp;
        protected int maxHP;
        protected int level = 1;
        protected int xp = 0;
        protected int xpRequired = 100;
        private string name;
        private bool defStance = false;
        private bool offStance = false;
        protected int statModifier = 1;
        protected int armor;

        public Creature()
        {
            //Sätter ett namn genom metoden Names()
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
            hp -= amount;   //ta emot dmg med värde amount
        }

        public void DefensiveStance(int minDmg, int maxDmg)
        {
            if (offStance) //Om du är i offStance och vill byta, ta bort +dmgen av offstance och sätt till false
            {
                minDmg -= 20;
                maxDmg -= 40;
                offStance = false;
            }
            else if (!defStance) //ta mindre dmg
            {
                armor += 2;
                defStance = true;
            }
        }

        public void OffensiveStance(int minDmg, int maxDmg)
        {
            if (defStance) //Om du är i defStance och vill byta, ta bort +armor av defStance och sätt till false
            {
                armor -= 2;
                defStance = false;
            }
            else if (!offStance) //gör mer dmg
            {
                minDmg += 20;
                maxDmg += 40;
                offStance = true;
            }
        }

        public string GetStance() //returnera string med den stance du är i
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

        public virtual void Present(string weaponName) //presentera info, kan vara olika för enemy/player därför virtual
        {
            Console.Clear();
            Console.WriteLine("Name: " + GetName());
            Console.WriteLine("\nHP: " + hp);
            Console.WriteLine("Equipped Weapon: " + weaponName);
            Console.WriteLine("Current Stance: " + GetStance());
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

        public int GetArmor()
        {
            return armor;
        }

        protected int GetXP()
        {
            return xp;
        }

        public void ReceiveXP()
        {
            xp += 50;
        }

        public virtual void ModifyStats(int playerLevel, int minDmg, int maxDmg)
        {
            statModifier = playerLevel; //Improve stats beroende på lvl
            if (xp >= xpRequired) //om du har tillräckligt med xp
            {
                level++;
                xpRequired += 50; //nästa lvl kräver mer xp
                xp = 0;   //reset xp värdet

                hp = maxHP + (50 * statModifier);
                armor = armor + (2 * statModifier);
                minDmg = minDmg + (25 * statModifier);
                maxDmg = maxDmg + (25 * statModifier);
            }
            else hp = maxHP; //om du inte lvlar resetta hp till max. (Detta händer efter en fight)
        }
    }
}