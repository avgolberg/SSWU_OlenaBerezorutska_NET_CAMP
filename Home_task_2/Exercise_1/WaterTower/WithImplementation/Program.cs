using System;

namespace WaterTowerWithImplementation
{
    class Program
    {
        static void MainWithImplementation(string[] args)
        {
            try
            {
                Pump pump = new Pump(6);
                WaterTower waterTower = new WaterTower(100, pump);
                User user = new User(40);
                Simulator simulator = new Simulator(waterTower, user);
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
