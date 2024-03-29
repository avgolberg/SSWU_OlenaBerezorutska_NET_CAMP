﻿using System;

namespace WaterTowerWithImplementation
{
    class Simulator
    {
        private WaterTower _waterTower;
        private User _user;

        public Simulator(double maxWaterLevel, double pumpPower, double userConsuption)
        {
            _waterTower = new WaterTower(maxWaterLevel, new Pump(pumpPower));
            _user = new User(userConsuption);

            _user.WaterIsNeeded += OnWaterIsNeeded;
        }

        public void OnWaterIsNeeded(object source, EventArgs e)
        {
            var user = source as User;
            double supply = user.Consuption / 2; //правило, треба винести окремо
            user.GetWater(_waterTower.SupplyWater(supply));
            Console.WriteLine(_waterTower);
        }

        public void Simulate()
        {
            for (int i = 0; i < 20; i++)
            {
                _user.UseWater(20);
                Console.WriteLine(_user);
            }
        }
    }
}
