using System;

namespace FightSimV2
{
    internal class Character : Creature
    {
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
            Console.WriteLine("\nHP: " + hp);
            Console.WriteLine("Equipped Weapon: " + GetWeapon());
            Console.WriteLine("XP: " + GetXP() + "/" + xpRequired);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Current Stance: " + GetStance());
            Console.WriteLine("Armor rating: " + armor);
        }

        public override void ModifyStats()
        {
            statModifier = level; //Improve stats beroende på lvl
            hp = maxHP * statModifier;
            armor *= statModifier;
            minDmg *= statModifier;
            maxDmg *= statModifier;
        }
    }
}