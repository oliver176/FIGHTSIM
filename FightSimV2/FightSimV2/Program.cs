using System;
using System.Threading;

namespace FightSimV2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var keyRead = Console.ReadKey(true).Key;

            Fighter fighterA = new Fighter(); //skapar 2 fighter med namn input
            Thread.Sleep(27);
            Fighter fighterB = new Fighter();

            while (true)
            {
                if (fighterA.IsAlive() && fighterB.IsAlive())  //när båda lever
                {
                    StanceOptions();
                    if (keyRead == ConsoleKey.D1)
                    {
                        fighterA.DefensiveStance();
                    }
                    else if (keyRead == ConsoleKey.D2)
                    {
                        fighterA.OffensiveStance();
                    }
                    AttackOptions();
                    Console.WriteLine(fighterA.name + "'s HP: " + fighterA.GetHp());  //Skriv ut deras hp
                    Console.WriteLine(fighterB.name + "'s HP: " + fighterB.GetHp());

                    fighterB.Hurt(fighterA.LightAttack(fighterB.armor));
                    fighterA.Hurt(fighterB.LightAttack(fighterA.armor));  //ta skada från den andras attack faktorera in armor

                    Console.WriteLine("___________________");
                    Console.ReadLine();
                }
                else if (!fighterA.IsAlive() || !fighterB.IsAlive()) //Om någon är död
                {
                    if (fighterA.IsAlive())
                    {
                        Console.WriteLine(fighterA.name + " WINS!");
                    }
                    else
                    {
                        Console.WriteLine(fighterB.name + " WINS");
                    }
                    break; // :)
                }
            }

            Console.ReadLine();
        }

        private static void StanceOptions()
        {
            Console.WriteLine("1: Defensive Stance");
            Console.WriteLine("2: Offensive Stance");
        }

        private static void AttackOptions()
        {
            Console.WriteLine("1: Light Attack");
            Console.WriteLine("2: Heavy Attack");
        }
    }
}