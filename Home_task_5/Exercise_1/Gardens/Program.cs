using System;
using System.Collections.Generic;
//Бали: 92	10	10	90	95	98	75	100 Вітаю Вас. Ви в другому турі.
namespace Gardens
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Location> trees = new List<Location>() { new Location(0, 0), new Location(2, 3), new Location(1, 1), new Location(2, 1), new Location(0, 3), new Location(3, 0), new Location(3, 3) };
            GardenTS garden = new GardenTS(trees); //Travelling salesman - not the shortest one (go around all the points)
            Console.WriteLine(garden);

            GardenTS garden2 = new GardenTS(3, 3, 4);
            Console.WriteLine(garden2);

            GardenTS garden3 = new GardenTS(trees);

            Console.WriteLine(garden > garden2);
            Console.WriteLine(garden < garden3);

            Console.WriteLine(garden >= garden2);
            Console.WriteLine(garden <= garden3);

            Console.WriteLine(garden == garden2);
            Console.WriteLine(garden != garden3);
            Console.WriteLine();

            GardenGW garden4 = new GardenGW(trees); //Gift wrapping algorithm
            Console.WriteLine(garden4);
        }
    }
}
