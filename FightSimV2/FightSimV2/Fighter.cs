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
        int xp = 0;

        public Fighter()   //input för namn
        {
            maxHP = 1000;
            armor = GenRandom(1, 5);
            hp = maxHP;
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
        public int GetXP()
        {
            return xp;
        }
        public void ReceiveXP()
        {
            xp += 25;
        }
        public void Present()
        {
            Console.Clear();
            Console.WriteLine("Name: " + name);
            Console.WriteLine("\nHP: " + hp);
            Console.WriteLine("XP: " + xp);
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
