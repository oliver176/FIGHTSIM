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
            RestClient client;

            client = new RestClient("https://pokeapi.co/api/v2/");

            RestRequest request = new RestRequest("pokemon/" + GenRandom(1, 100));
            IRestResponse response = client.Get(request);
            Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);

            maxHP = 5000 * statModifier;
            armor = GenRandom(1, 5) * statModifier;
            hp = maxHP;
        }

        public override void Present(string weaponName, string pokemonName)
        {
            Console.Clear();
            Console.WriteLine("Name: " + GetName());
            Console.WriteLine("Lvl " + level + " " + className + " " + GetXP() + "/" + xpRequired + "XP");
            Console.WriteLine("\nHP: " + hp);
            Console.WriteLine("Armor rating: " + armor);
            Console.WriteLine("Equipped Weapon: " + weaponName);
            Console.WriteLine("Current Stance: " + GetStance());
            Console.WriteLine("Favorite Pokemon: ");
            Console.WriteLine("____________________________________");
        }

        public int GetLevel()
        {
            return level;
        }
    }
}