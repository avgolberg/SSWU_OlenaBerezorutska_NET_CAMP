using System;
using System.Collections.Generic;

namespace Gardens
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Location> trees = new List<Location>() { new Location(0, 0), new Location(0, 3), new Location(3, 0), new Location(3, 3) };
            Garden garden = new Garden(trees);
            Console.WriteLine(garden);

            Garden garden2 = new Garden(3, 3, 4);
            Console.WriteLine(garden2);

            Garden garden3 = new Garden(trees);
            Console.WriteLine(garden3);

            Console.WriteLine(garden > garden2);
            Console.WriteLine(garden < garden3);

            Console.WriteLine(garden >= garden2);
            Console.WriteLine(garden <= garden3);

            Console.WriteLine(garden == garden2);
            Console.WriteLine(garden != garden3);
        }
    }
}
