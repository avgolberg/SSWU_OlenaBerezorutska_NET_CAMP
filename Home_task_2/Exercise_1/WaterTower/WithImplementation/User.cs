using System;

namespace WaterTowerWithImplementation
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

            GetWater(consuption);
        }

        public void UseWater(double consuption)
        {
            _waterUsed += consuption;
            _currentWaterLevel -= consuption;
            if (_currentWaterLevel < Consuption / 2) //правило, треба винести окремо
                OnWaterIsNeeded();
        }

        public void GetWater(double consuption)
        {
            _currentWaterLevel += consuption;
        }

        protected virtual void OnWaterIsNeeded()
        {
            if (WaterIsNeeded != null)
                WaterIsNeeded(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return $"User: Amount of used water is {_waterUsed}, current water level is {_currentWaterLevel}, (consuption is {Consuption})";
        }

    }
}
