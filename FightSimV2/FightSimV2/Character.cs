using System;
using System.Collections.Generic;

namespace FightSimV2
{
    internal class Character : Creature
    {
        protected string className;
        public List<string> inventoryList = new List<string>();

        public Character()
        {
            maxHP = 5000 * statModifier;
            armor = GenRandom(1, 5) * statModifier;
            hp = maxHP;
        }

        public override void Present()
        {
            Console.Clear();
            Console.WriteLine("Name: " + GetName());
            Console.WriteLine("Lvl " + level + " " + className + " " + GetXP() + "/" + xpRequired + "XP");
            Console.WriteLine("\nHP: " + hp);
            Console.WriteLine("Armor rating: " + armor);
            Console.WriteLine("Equipped Weapon: " + GetWeapon() + " Damage");
            Console.WriteLine("Current Stance: " + GetStance());
            Console.WriteLine("____________________________________");
        }
        public int GetLevel()
        {
            return level;
        }
        public override void ModifyStats(int playerLevel)
        {
            statModifier = playerLevel; //Improve stats beroende på lvl
            hp = maxHP * statModifier;
            armor *= statModifier;
            minDmg *= statModifier;
            maxDmg *= statModifier;
        }
    }
}