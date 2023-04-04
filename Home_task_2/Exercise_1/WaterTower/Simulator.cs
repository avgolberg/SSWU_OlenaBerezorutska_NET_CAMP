using System;

namespace WaterTower
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
            //supply water to user
        }

        public void Simulate()
        {

        }
    }
}
