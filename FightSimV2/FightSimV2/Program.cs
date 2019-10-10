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
            Console.WriteLine("Name the 2 fighters!");

            Fighter fighterA = new Fighter(Console.ReadLine()); //skapar 2 fighter med namn input
            Fighter fighterB = new Fighter(Console.ReadLine());

            while (true)
            {
                if (fighterA.IsAlive() && fighterB.IsAlive())  //när båda lever
                {
                    Console.WriteLine(fighterA.name + fighterA.GetHp());  //Skriv ut deras hp
                    Console.WriteLine(fighterB.name + fighterB.GetHp());

                    fighterB.Hurt(fighterA.Attack());
                    fighterA.Hurt(fighterB.Attack());  //ta skada från den andras attack

                    Console.WriteLine("___________");
                    Console.ReadLine();
                }
                else if (fighterA.IsAlive() == false || fighterB.IsAlive() == false) //Om någon är död
                {
                    if (fighterA.IsAlive())
                    {
                        Console.WriteLine("Player A WINS!");
                    }
                    else
                    {
                        Console.WriteLine("Player B WINS");
                    }
                    break; // :)
                }
            }

            Console.ReadLine();
        }
    }
}
