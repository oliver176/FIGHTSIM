using System;
using System.Collections.Generic;

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
            var keyRead = Console.ReadKey(true).Key;

            List<Vapen> inventoryList = new List<Vapen>();

            Character player = new Character(); //skapar spelaren
            Vapen playerWeapon = new Vapen();
            Vapen enemyWeapon = new Mace();
            Creature enemy = new Zombie();  //skapar en creature

            while (gameRunning)
            {
                while (classMenu == false)
                {
                    classMenu = false;
                    ClassOptions(); //skriver ut alternativ

                    keyRead = Console.ReadKey(true).Key;
                    if (keyRead == ConsoleKey.D1)
                    {
                        player = new Brute();
                        playerWeapon = new Mace();
                        inventoryList.Add(playerWeapon);
                        classMenu = true;
                    }
                    if (keyRead == ConsoleKey.D2)
                    {
                        player = new Warrior();
                        playerWeapon = new Sword();
                        inventoryList.Add(playerWeapon);
                        classMenu = true;
                    }
                    if (keyRead == ConsoleKey.D3)
                    {
                        player = new Assasin();
                        playerWeapon = new Dagger();
                        inventoryList.Add(playerWeapon);
                        classMenu = true;
                    }
                    Console.Clear();
                }
                while (mainMenu)
                {
                    MainMenu(); //skriver ut alternativ

                    keyRead = Console.ReadKey(true).Key;
                    if (keyRead == ConsoleKey.D1)
                    {
                        player.Present(playerWeapon.GetWeaponName());
                    }
                    if (keyRead == ConsoleKey.D2)
                    {
                        enemy.Present(enemyWeapon.GetWeaponName());
                    }
                    if (keyRead == ConsoleKey.D3)
                    {
                        mainMenu = false;
                        fighting = true; //sätt igång while loopen med fight koden
                        Console.Clear();
                    }
                    if (keyRead == ConsoleKey.D4)
                    {
                        Console.Clear();
                        Console.WriteLine("Pick a weapon to equip!");
                        for (int i = 0; i < playerWeapon.GetAllWeaponsCount(); i++)
                        {
                            if (i < playerWeapon.GetAllWeaponsCount())
                            {
                                Console.WriteLine("___________________");
                                Console.WriteLine((i + 1) + ": " + inventoryList[i].weaponName);
                            }
                        }

                        keyRead = Console.ReadKey(true).Key;
                        if (keyRead == ConsoleKey.D1)
                        {
                            if (player.inventoryList[0].Contains("Mace"))
                            {
                                playerWeapon = new Mace();
                            }
                            if (player.inventoryList[0].Contains("Sword"))
                            {
                                playerWeapon = new Sword();
                            }
                            if (player.inventoryList[0].Contains("Pike"))
                            {
                                playerWeapon = new Pike();
                            }
                            if (player.inventoryList[0].Contains("Dagger"))
                            {
                                playerWeapon = new Dagger();
                            }
                        }
                        else if (keyRead == ConsoleKey.D2)
                        {
                            if (player.inventoryList[1].Contains("Mace"))
                            {
                                playerWeapon = new Mace();
                            }
                            if (player.inventoryList[1].Contains("Sword"))
                            {
                                playerWeapon = new Sword();
                            }
                            if (player.inventoryList[1].Contains("Pike"))
                            {
                                playerWeapon = new Pike();
                            }
                            if (player.inventoryList[1].Contains("Dagger"))
                            {
                                playerWeapon = new Dagger();
                            }
                        }
                        else if (keyRead == ConsoleKey.D3)
                        {
                            if (player.inventoryList[2].Contains("Mace"))
                            {
                                playerWeapon = new Mace();
                            }
                            if (player.inventoryList[2].Contains("Sword"))
                            {
                                playerWeapon = new Sword();
                            }
                            if (player.inventoryList[2].Contains("Pike"))
                            {
                                playerWeapon = new Pike();
                            }
                            if (player.inventoryList[2].Contains("Dagger"))
                            {
                                playerWeapon = new Dagger();
                            }
                        }
                        else if (keyRead == ConsoleKey.D4)
                        {
                            if (player.inventoryList[3].Contains("Mace"))
                            {
                                playerWeapon = new Mace();
                            }
                            if (player.inventoryList[3].Contains("Sword"))
                            {
                                playerWeapon = new Sword();
                            }
                            if (player.inventoryList[3].Contains("Pike"))
                            {
                                playerWeapon = new Pike();
                            }
                            if (player.inventoryList[3].Contains("Dagger"))
                            {
                                playerWeapon = new Dagger();
                            }
                        }
                    }
                }
                while (fighting)
                {
                    if (player.IsAlive() && enemy.IsAlive())  //när båda lever
                    {
                        Console.WriteLine(player.GetName() + "'s HP: " + player.GetHp());  //Skriv ut deras hp
                        Console.WriteLine(enemy.GetName() + "'s HP: " + enemy.GetHp());
                        Console.WriteLine("___________________");
                        StanceOptions();
                        keyRead = Console.ReadKey(true).Key;
                        if (keyRead == ConsoleKey.D1)
                        {
                            player.DefensiveStance();
                        }
                        else if (keyRead == ConsoleKey.D2)
                        {
                            player.OffensiveStance();
                        }

                        AttackOptions();
                        keyRead = Console.ReadKey(true).Key;
                        if (keyRead == ConsoleKey.D1)
                        {
                            enemy.Hurt(playerWeapon.LightAttack(enemy.armor)); //light attack faktorerar in armor
                        }
                        else if (keyRead == ConsoleKey.D2)
                        {
                            enemy.Hurt(playerWeapon.HeavyAttack(enemy.armor)); //heavy attack faktorerar in armor
                        }

                        if (enemy.GenRandom(0, 1) == 0) // 50/50 stance för enemy
                        {
                            enemy.OffensiveStance();
                        }
                        else
                        {
                            enemy.DefensiveStance();
                        }
                        if (enemy.GenRandom(0, 1) == 0) //50/50 vilken attack för enemy
                        {
                            player.Hurt(enemyWeapon.LightAttack(player.armor));
                        }
                        else
                        {
                            player.Hurt(enemyWeapon.HeavyAttack(player.armor));
                        }
                        Console.Clear();
                    }
                    else if (!player.IsAlive() || !enemy.IsAlive()) //Om någon är död
                    {
                        if (player.IsAlive())
                        {
                            Console.WriteLine(player.GetName() + " WINS!\n");
                            player.ReceiveXP(); //få xp om du vinner samt kolla om du lvlar
                            enemy.ReceiveXP(); //så att enemy kommer att skala med playern

                            switch (playerWeapon.GenRandom(1, playerWeapon.GetAllWeaponsCount() + 1))
                            {
                                case 1:
                                    if (player.inventoryList.Contains("Mace")) //om du redan har mace så får du inte en till
                                    {
                                        break;
                                    }
                                    else inventoryList.Add(new Mace()); Console.WriteLine("You receive a Mace!");
                                    break;

                                case 2:
                                    if (player.inventoryList.Contains("Sword"))
                                    {
                                        break;
                                    }
                                    else inventoryList.Add(new Sword()); Console.WriteLine("You receive a Sword!");
                                    break;

                                case 3:
                                    if (player.inventoryList.Contains("Dagger"))
                                    {
                                        break;
                                    }
                                    else inventoryList.Add(new Dagger()); Console.WriteLine("You receive a Dagger!");
                                    break;

                                case 4:
                                    if (player.inventoryList.Contains("Pike"))
                                    {
                                        break;
                                    }
                                    else inventoryList.Add(new Pike()); Console.WriteLine("You receive a Pike!");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine(enemy.GetName() + " WINS");
                        }

                        player.ModifyStats(player.GetLevel()); //skala både player och enemy stats beroende på playerns level
                        enemy.ModifyStats(player.GetLevel());
                        Console.WriteLine("\nPress enter to return to main menu");
                        Console.ReadLine(); Console.Clear();
                        fighting = false; mainMenu = true;
                    }
                }
            }
        }

        private static void MainMenu()
        {
            Console.WriteLine("\n1: Present Character");
            Console.WriteLine("2: Present Opponent");
            Console.WriteLine("3: Start Fighting");
            Console.WriteLine("4: Show Inventory\n");
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
            Console.WriteLine("3: Assasin");
        }

        private static void StanceOptions()
        {
            Console.WriteLine("Choose Stance\n");
            Console.WriteLine("1: Defensive Stance");
            Console.WriteLine("2: Offensive Stance");
        }

        private static void AttackOptions()
        {
            Console.WriteLine("\nChoose Attack:\n");
            Console.WriteLine("1: Light Attack");
            Console.WriteLine("2: Heavy Attack\n");
        }
    }
}