using System;
using System.Threading;

namespace FightSimV2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool fighting = false;
            bool mainMenu = true;

            Fighter fighterA = new Fighter(); //skapar 2 fighter med namn input
            Thread.Sleep(27);
            Fighter fighterB = new Fighter();

            var keyRead = Console.ReadKey(true).Key;

            while (mainMenu)
            {
                MainMenu();

                keyRead = Console.ReadKey(true).Key;
                if (keyRead == ConsoleKey.D1)
                {
                    fighterA.Present();
                }
                if (keyRead == ConsoleKey.D2)
                {
                    fighterB.Present();
                }
                if (keyRead == ConsoleKey.D3)
                {
                    mainMenu = false;
                    fighting = true; //sätt igång while loopen med fight koden
                }
            }
            while (fighting)
            {

                if (fighterA.IsAlive() && fighterB.IsAlive())  //när båda lever
                {
                    StanceOptions();
                    keyRead = Console.ReadKey(true).Key;
                    if (keyRead == ConsoleKey.D1)
                    {
                        fighterA.DefensiveStance();
                    }
                    else if (keyRead == ConsoleKey.D2)
                    {
                        fighterA.OffensiveStance();
                    }

                    AttackOptions();
                    keyRead = Console.ReadKey(true).Key;
                    if (keyRead == ConsoleKey.D1)
                    {
                        fighterB.Hurt(fighterA.LightAttack(fighterB.armor)); //light attack faktorerar in armor
                    }
                    else if (keyRead == ConsoleKey.D2)
                    {
                        fighterB.Hurt(fighterA.HeavyAttack(fighterB.armor)); //heavy attack faktorerar in armor
                    }

                    if (fighterB.GenRandom(0, 1) == 0)
                    {
                        fighterA.Hurt(fighterB.LightAttack(fighterA.armor));
                    }
                    else
                    {
                        fighterA.Hurt(fighterB.HeavyAttack(fighterA.armor));
                    }
                    //Console.Clear();
                    Console.WriteLine(fighterA.name + "'s HP: " + fighterA.GetHp());  //Skriv ut deras hp
                    Console.WriteLine(fighterB.name + "'s HP: " + fighterB.GetHp());
                    Console.WriteLine("___________________");
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
        private static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1: Present Character");
            Console.WriteLine("2: Present Opponent");
            Console.WriteLine("3: Start Fighting");
            Console.WriteLine();
        }
        private static void StanceOptions()
        {
            Console.WriteLine("1: Defensive Stance");
            Console.WriteLine("2: Offensive Stance");
        }

        private static void AttackOptions()
        {
            Console.Clear();
            Console.WriteLine("1: Light Attack");
            Console.WriteLine("2: Heavy Attack\n");
        }
    }
}