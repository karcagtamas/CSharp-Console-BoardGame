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
            int first = 1;
            int second = 1;
            bool end = false;
            bool firstStepDouble = false;
            bool secondStepDouble = false;
            int[] blue = { 10, 20, 30, 40 };
            Dictionary<int, int> arrow = new Dictionary<int, int>(){{14, 5}, {26, 18}, {42, 24}};
            Random r = new Random();
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                // Kör kiirás
                Console.WriteLine("{0}. kör", round);

                // Első (András)
                int x = r.Next(1, 7);
                first += firstStepDouble? + x * 2 : x;
                if (first >= fields)
                {
                    first = fields;
                    end = true;
                }
                if (firstStepDouble)
                {
                    firstStepDouble = false;
                    
                }

                if (blue.Contains(first))
                {
                    firstStepDouble = true;
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (arrow.ContainsKey(first))
                {
                    first = arrow[first];
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine("\tAndrás {0}-t dobott, 0 {1}. mezőre lépett.", x, first);

                if (!end)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    // Második (András)
                    int y = r.Next(1, 7);
                    second += secondStepDouble ? + y * 2 : y;
                    if (second >= fields)
                    {
                        second = fields;
                        end = true;
                    }
                    if (secondStepDouble)
                    {
                        secondStepDouble = false;
                    }

                    if (blue.Contains(second))
                    {
                        secondStepDouble = true;
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (arrow.ContainsKey(second))
                    {
                        second = arrow[second];
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine("\tBence {0}-t dobott, 0 {1}. mezőre lépett.", y, second);
                }


                round++;
            } while (!end);

            Console.ForegroundColor = ConsoleColor.Green;
            if (first == fields) Console.WriteLine("András");
            else Console.WriteLine("Bence");
            Console.ReadKey();
        }
    }
}
