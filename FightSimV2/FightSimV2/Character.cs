using Newtonsoft.Json;
using RestSharp;
using System;

namespace FightSimV2
{
    internal class Character : Creature
    {
        protected string className;

        public Character()
        {
            maxHP = 5000 * statModifier;
            armor = GenRandom(1, 5) * statModifier;
            hp = maxHP;
        }

        public void PresentPlayer(string weaponName, string pokemonName)
        {
            Console.Clear();
            Console.WriteLine("Name: " + GetName());
            Console.WriteLine("Lvl " + level + " " + className + " " + GetXP() + "/" + xpRequired + "XP");
            Console.WriteLine("\nHP: " + hp);
            Console.WriteLine("Armor rating: " + armor);
            Console.WriteLine("Equipped Weapon: " + weaponName);
            Console.WriteLine("Current Stance: " + GetStance());
            Console.WriteLine("Favorite Pokemon: " + pokemonName);
            Console.WriteLine("____________________________________");
        }

        public int GetLevel()
        {
            return level;
        }
    }
}