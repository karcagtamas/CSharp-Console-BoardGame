using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console_BoardGame
{
    class Program
    {
        static void Main()
        {
            int fields = 44;
            int round = 1;
            //int first = 1;
            //int second = 1;
            bool end = false;
            int winner = 0;
            //bool firstStepDouble = false;
            //bool secondStepDouble = false;
            int[] blue = { 10, 20, 30, 40 };
            Dictionary<int, int> arrow = new Dictionary<int, int>() { { 14, 5 }, { 26, 18 }, { 42, 24 } };
            string[] names = { "András", "Bence", "Cecilia", "Dénes", "Elemér", "Ferenc", "Géza", "Hedvig", "István" };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Adjon meg egy játékos számot (2-8):");
            int players = int.TryParse(Console.ReadLine(), out int x)? x : 2;
            if (players < 2) players = 2;
            if (players > 8) players = 8;
            int[] Players = new int[players];
            bool[] Doubles = new bool[players];

            for (int i = 0; i < Players.Length; i++)
            {
                Players[i] = 1;
            }
            

            Random r = new Random();
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                // Kör kiirás
                Console.WriteLine("{0}. kör", round);

                for (int i = 0; i < Players.Length && !end; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    int rnd = r.Next(1, 7);
                    Players[i] += Doubles[i] ? rnd * 2 : rnd;
                    if (Doubles[i])
                    {
                        Doubles[i] = false;
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (Players[i] >= fields)
                    {
                        Players[i] = fields;
                        end = true;
                        winner = i;
                    }
                    if (blue.Contains(Players[i]))
                    {
                        Doubles[i] = true;
                    }
                    if (arrow.ContainsKey(Players[i]))
                    {
                        Players[i] = arrow[Players[i]];
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine("\t{0} {1}-t dobott, {2}. mezőre lépett.", names[i], rnd, Players[i]);
                }
                round++;
            } while (!end);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(names[winner]);
            Console.ReadKey();
        }
    }
}
