using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Character : Creature
    {
        int xp = 0;

        public Character()   //input för namn
        {
            maxHP = 1000;
            armor = GenRandom(1, 5);
            hp = maxHP;
        }
        public int GetXP()
        {
            return xp;
        }
        public void ReceiveXP()
        {
            xp += 25;
        }
        public override void Present()
        {
            Console.Clear();
            Console.WriteLine("Name: " + GetName());
            Console.WriteLine("\nHP: " + hp);
            Console.WriteLine("XP: " + xp);
            Console.WriteLine("Current Stance: " + GetStance());
            Console.WriteLine("Armor rating: " + armor);
            Console.WriteLine("Min/Max Damage: " + minDmg + "-" + maxDmg);
        }
    }
}
