using System;

namespace WaterTowerWithImplementation
{
    class WaterTower
    {
        private readonly double _maxLevel;
        private double _currentLevel;
        private Pump _pump;

        public WaterTower(double maxLevel, Pump pump)
        {
            if (maxLevel <= 0)
                throw new ArgumentException($"{nameof(maxLevel)} can not be 0 or negative", nameof(maxLevel));

            if (pump == null)
                throw new ArgumentNullException(nameof(pump));

            _maxLevel = maxLevel;
            _currentLevel = 0;
            _pump = new Pump(pump); //конструктор копіювання через порушення інкапсуляції (?)

            GetWater(maxLevel);
        }
        
        public void ChangePump(Pump pump)
        {
            _pump = new Pump(pump);
        }

        public double SupplyWater(double consuption)
        {
            _currentLevel -= consuption;

            if (_currentLevel == 0)
                GetWater(_maxLevel - _currentLevel);

            return consuption;
        }

        public void GetWater(double consuption)
        {
            _currentLevel += _pump.SupplyWater(consuption);
        }

        public override string ToString()
        {
            return $"WaterTower: Current level is {_currentLevel} (max = {_maxLevel})";
        }
    }
}
