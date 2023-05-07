using System;

namespace TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            IntersectionSimulator simulator = new IntersectionSimulator(new ConsoleDisplay(new ForwardMovement(3, 1, 3)));
            simulator.Start();

            Console.ReadLine();

            Console.WriteLine("--------- Change ---------");
            simulator.Change(2, 1, 2);

            Console.ReadLine();

            simulator.Stop();
        }
    }
}
