using System;

namespace WaterTower
{
    class Simulator
    {
        private WaterTower _waterTower;
        private User _user;

        public Simulator(WaterTower waterTower, User user)
        {
            //тут же не потрібні конктруктори копіювання?
            _waterTower = waterTower;
            _user = user;

            user.WaterIsNeeded += OnWaterIsNeeded;
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
