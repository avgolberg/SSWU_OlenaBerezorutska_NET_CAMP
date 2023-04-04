using System;

namespace WaterTowerWithImplementation
{
    class Program
    {
        static void MainWithImplementation(string[] args)
        {
            try
            {
                Simulator simulator = new Simulator(100, 6, 40);
                simulator.Simulate();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error ocured");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
