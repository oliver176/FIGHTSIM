using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Program
    {

        static void Main(string[] args)
        {
            var keyRead = Console.ReadKey(true).Key;

            Fighter fighterA = new Fighter(); //skapar 2 fighter med namn input
            Thread.Sleep(27);
            Fighter fighterB = new Fighter();

            while (true)
            {
                if (fighterA.IsAlive() && fighterB.IsAlive())  //när båda lever
                {
                    Console.WriteLine(fighterA.name + "'s HP: " + fighterA.GetHp());  //Skriv ut deras hp
                    Console.WriteLine(fighterB.name + "'s HP: " + fighterB.GetHp());

                    fighterB.Hurt(fighterA.Attack(fighterB.armor));
                    fighterA.Hurt(fighterB.Attack(fighterA.armor));  //ta skada från den andras attack faktorera in armor

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
        public void StanceOptions()
        {
            Console.WriteLine("1: Defensive Stance");
            Console.WriteLine("2: Offensive Stance");
        }
        public void AttackOptions()
        {
            Console.WriteLine("1: Light Attack");
            Console.WriteLine("2: Heavy Attack");
        }
    }
}
