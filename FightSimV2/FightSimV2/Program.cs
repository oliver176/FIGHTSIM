using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace FightSimV2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RestClient client;

            client = new RestClient("https://pokeapi.co/api/v2/");

            RestRequest request = new RestRequest("pokemon/" + 4); //Skickar en request för pokemon med id 4
            IRestResponse response = client.Get(request);  //fångar requesten
            Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content); //Deserialize datan som du får från requesten så att det är läsbart.

            bool fighting = false;
            bool mainMenu = true;
            bool gameRunning = true;
            bool classMenu = false;
            var keyRead = Console.ReadKey(true).Key;
            var readKey = Console.ReadKey();

            ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input

            List<Vapen> inventoryList = new List<Vapen>(); //lista med vapen
            List<Creature> enemyList = new List<Creature>  //lista för de enemies du kan fighta
            {
                new Goblin(),
                new Zombie()
            };

            Character player = new Character(); //skapar en ny spelare
            Vapen playerWeapon = new Vapen();   //skapar spelarens vapen
            Creature enemy = new Creature();  //skapar enemy
            enemy = enemyList[enemy.GenRandom(0, enemyList.Count)]; //välj en random enemy av de som finns från enemy listan
            Vapen enemyWeapon = new Mace(); //skapar fiende vapnet

            while (gameRunning) //main game loopen
            {
                while (classMenu == false)
                {
                    ClassOptions(); //metod som skriver ut alternativ för att välja class (rouge, warrior etc.)

                    keyRead = Console.ReadKey(true).Key; //variabel som lagrar en keypress
                    if (keyRead == ConsoleKey.D1)
                    {
                        player = new Brute(); //sätt player instansen till den nya klassen
                        playerWeapon = new Mace();  //sätt vapnet till det specifika för klassen
                        inventoryList.Add(playerWeapon);  //lägg till vapnet i inventoryn
                        classMenu = true;   //blir true så att menyn inte ska komma upp igen
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
                    MainMenu(); //skriver ut alternativ för main menyn

                    keyRead = Console.ReadKey(true).Key;
                    if (keyRead == ConsoleKey.D1)
                    {
                        player.PresentPlayer(playerWeapon.GetWeaponName(), pokemon.name); //Presentera information om spelaren
                    }
                    if (keyRead == ConsoleKey.D2)
                    {
                        enemy.Present(enemyWeapon.GetWeaponName());  //presentera information om enemy
                    }
                    if (keyRead == ConsoleKey.D3)
                    {
                        mainMenu = false;
                        fighting = true; //sätt igång while loopen med fight koden
                        enemy = enemyList[enemy.GenRandom(0, enemyList.Count)]; //välj en random enemy av de som finns från enemy listan
                        Console.Clear();
                    }
                    if (keyRead == ConsoleKey.D4) //inventory
                    {
                        Console.Clear();
                        Console.WriteLine("Pick a weapon to equip!");
                        for (int i = 0; i < playerWeapon.GetAllWeaponsCount(); i++)
                        {
                            if (i < inventoryList.Count) //skriv ut alla vapen i inventory
                            {
                                Console.WriteLine("___________________");
                                Console.WriteLine((i + 1) + ": " + inventoryList[i].weaponName);
                            }
                        }

                        UserInput = Console.ReadKey();
                        if (char.IsDigit(UserInput.KeyChar))
                        {
                            int.TryParse(UserInput.KeyChar.ToString(), out int index); // använd parse om det är en digit
                            if (index <= inventoryList.Count)
                            {
                                playerWeapon = inventoryList[index - 1]; //vapnet blir input -1 eftersom första positionen är 0.
                            }
                        }

                        Console.Clear();
                    }
                }
                while (fighting)
                {
                    if (player.IsAlive() && enemy.IsAlive())  //när båda lever
                    {
                        Console.WriteLine(player.GetName() + "'s HP: " + player.GetHp());  //Skriv ut deras hp
                        Console.WriteLine(enemy.GetName() + "'s HP: " + enemy.GetHp());
                        Console.WriteLine("___________________");

                        StanceOptions(); //presenterar de olika stancerna

                        keyRead = Console.ReadKey(true).Key;
                        if (keyRead == ConsoleKey.D1)
                        {
                            player.DefensiveStance(playerWeapon.GetMinDmg(), playerWeapon.GetMaxDmg()); //Stance som ökar armor
                        }
                        else if (keyRead == ConsoleKey.D2)
                        {
                            player.OffensiveStance(playerWeapon.GetMinDmg(), playerWeapon.GetMaxDmg()); //Stance some ökar dmg
                        }

                        AttackOptions(); //presenterar attack valen (light/heavy)
                        keyRead = Console.ReadKey(true).Key;
                        if (keyRead == ConsoleKey.D1)
                        {
                            enemy.Hurt(playerWeapon.LightAttack(enemy.GetArmor())); //skadar enemy med light attack faktorerar in armor
                        }
                        else if (keyRead == ConsoleKey.D2)
                        {
                            enemy.Hurt(playerWeapon.HeavyAttack(enemy.GetArmor())); //skadar enemy med heavy attack faktorerar in armor
                        }

                        if (enemy.GenRandom(0, 1) == 0) // 50/50 % chance vilken stance för enemy
                        {
                            enemy.OffensiveStance(enemyWeapon.GetMinDmg(), enemyWeapon.GetMaxDmg());
                        }
                        else
                        {
                            enemy.DefensiveStance(enemyWeapon.GetMinDmg(), enemyWeapon.GetMaxDmg());
                        }
                        if (enemy.GenRandom(0, 1) == 0) //50/50 % chance vilken attack som enemy ska utföra
                        {
                            player.Hurt(enemyWeapon.LightAttack(player.GetArmor())); //skadar player med light attack faktorerar in armor
                        }
                        else
                        {
                            player.Hurt(enemyWeapon.HeavyAttack(player.GetArmor())); //skadar player med heavy attack faktorerar in armor
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

                            switch (playerWeapon.GenRandom(1, playerWeapon.GetAllWeaponsCount() + 1)) // +1 eftersom att taket på en generator inte är inkluderande
                            {
                                case 1: //4 olika vappen som kan "droppa"

                                    inventoryList.Add(new Mace()); Console.WriteLine("You receive a Mace!");
                                    break;

                                case 2:

                                    inventoryList.Add(new Sword()); Console.WriteLine("You receive a Sword!");
                                    break;

                                case 3:

                                    inventoryList.Add(new Dagger()); Console.WriteLine("You receive a Dagger!");
                                    break;

                                case 4:

                                    inventoryList.Add(new Pike()); Console.WriteLine("You receive a Pike!");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine(enemy.GetName() + " WINS");
                        }
                        //skala både player och enemy stats beroende på playerns level
                        player.ModifyStats(player.GetLevel(), playerWeapon.GetMinDmg(), playerWeapon.GetMaxDmg());
                        enemy.ModifyStats(player.GetLevel(), enemyWeapon.GetMinDmg(), enemyWeapon.GetMaxDmg());
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

        private static void CreateEnemyList(List<Creature> enemyLista)
        {
            enemyLista.Add(new Goblin());
            enemyLista.Add(new Zombie());
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