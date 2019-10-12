using System;

namespace FightSimV2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool fighting = false;
            bool mainMenu = true;
            bool gameRunning = true;
            bool classMenu = false;
            bool weaponEquipped = false;

            Character fighterA = new Character();
            var keyRead = Console.ReadKey(true).Key;
            Zombie fighterB = new Zombie();  //skapar en creature

            while (gameRunning)
            {
                while (classMenu == false)
                {
                    classMenu = false;
                    ClassOptions();
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        fighterA = new Brute();
                        classMenu = true;
                    }
                    if (input == "2")
                    {
                        fighterA = new Warrior();
                        classMenu = true;
                    }
                    if (input == "3")
                    {
                        fighterA = new Assasin();
                        classMenu = true;
                    }
                }
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
                    if (keyRead == ConsoleKey.D4)
                    {
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

                        if (fighterB.GenRandom(0, 1) == 0) // 50/50 stance för enemy
                        {
                            fighterB.OffensiveStance();
                        }
                        else
                        {
                            fighterB.DefensiveStance();
                        }
                        if (fighterB.GenRandom(0, 1) == 0) //50/50 vilken attack för enemy
                        {
                            fighterA.Hurt(fighterB.LightAttack(fighterA.armor));
                        }
                        else
                        {
                            fighterA.Hurt(fighterB.HeavyAttack(fighterA.armor));
                        }
                        //Console.Clear();
                        Console.WriteLine(fighterA.GetName() + "'s HP: " + fighterA.GetHp());  //Skriv ut deras hp
                        Console.WriteLine(fighterB.GetName() + "'s HP: " + fighterB.GetHp());
                        Console.WriteLine("___________________");
                    }
                    else if (!fighterA.IsAlive() || !fighterB.IsAlive()) //Om någon är död
                    {
                        if (fighterA.IsAlive())
                        {
                            Console.WriteLine(fighterA.GetName() + " WINS!");
                            fighterA.ReceiveXP(); //få xp om du vinner samt kolla om du lvlar
                            fighterB.ReceiveXP(); //så att enemy kommer att skala med playern
                        }
                        else
                        {
                            Console.WriteLine(fighterB.GetName() + " WINS");
                        }

                        fighterA.ModifyStats();
                        fighterB.ModifyStats();
                        Console.WriteLine("\nPress enter to return to main menu");
                        Console.ReadLine(); Console.Clear();
                        fighting = false;
                        mainMenu = true;
                    }
                }
            }
        }

        private static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1: Present Character");
            Console.WriteLine("2: Present Opponent");
            Console.WriteLine("3: Start Fighting");
            Console.WriteLine("4: Pick Weapon");
            Console.WriteLine();
        }

        private static void WeaponOptions()
        {
            Console.Clear();
            Console.WriteLine("Pick a weapon!\n");
            Console.WriteLine("1: Mace");
            Console.WriteLine("2: Sword");
            Console.WriteLine("3: Pike");
        }

        private static void ClassOptions()
        {
            Console.Clear();
            Console.WriteLine("Pick a class!\n");
            Console.WriteLine("1: Brute");
            Console.WriteLine("2: Warrior");
            Console.WriteLine("3: Rouge");
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