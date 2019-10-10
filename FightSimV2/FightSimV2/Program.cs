using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Fighter fighterA = new Fighter(Console.ReadLine()); //skapar 2 fighter med namn input
            Fighter fighterB = new Fighter(Console.ReadLine());

            while (true)
            {
                if (fighterA.IsAlive() && fighterB.IsAlive())  //när båda lever
                {
                    Console.WriteLine(fighterA.name + " HP: " + fighterA.GetHp());  //Skriv ut deras hp
                    Console.WriteLine(fighterB.name + " HP: " + fighterB.GetHp());

                    fighterB.Hurt(fighterA.Attack(fighterB.armor));
                    fighterA.Hurt(fighterB.Attack(fighterA.armor));  //ta skada från den andras attack faktorera in armor

                    Console.WriteLine("___________________");
                    Console.ReadLine();
                }
                else if (fighterA.IsAlive() == false || fighterB.IsAlive() == false) //Om någon är död
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
    }
}
