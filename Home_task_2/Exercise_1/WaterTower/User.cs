using System;

namespace WaterTower
{
    class User
    {
        public double Consuption { get; private set; } // потрібно зазвичай
        private double _waterUsed; // дійсно використано
        private double _currentWaterLevel;

        public event EventHandler WaterIsNeeded;

        public User(double consuption)
        {
            if (consuption <= 0)
                throw new ArgumentException($"{nameof(consuption)} can not be 0 or negative", nameof(consuption));

            Consuption = consuption;
            _waterUsed = 0;
            _currentWaterLevel = 0;
        }

        public void UseWater(double consuption)
        {
            //notify Simulator to get water from WaterTower (not specific one)
            //if(...) call OnWaterIsNeeded()
        }
        protected virtual void OnWaterIsNeeded()
        {
            if (WaterIsNeeded != null)
                WaterIsNeeded(this, EventArgs.Empty);
        }

        public void GetWater(double consuption)
        {

        }

        public override string ToString()
        {
            return $"User: Amount of used water is {_waterUsed}, current water level is {_currentWaterLevel}, (consuption is {Consuption})";
        }

    }
}
