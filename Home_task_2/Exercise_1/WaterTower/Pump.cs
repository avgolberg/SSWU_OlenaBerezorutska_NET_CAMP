using System;

namespace WaterTower
{
    class Pump
    {
        private readonly double _power;
        private bool _isActive = false; //знадобиться при неавтоматичному виклику

        public Pump(double power)
        {
            if (power <= 0)
                throw new ArgumentException($"{nameof(power)} can not be 0 or negative", nameof(power));

            _power = power;
        }

        public Pump(Pump pumpToCopy)
        {
            if (pumpToCopy == null)
                throw new ArgumentNullException(nameof(pumpToCopy));

            _power = pumpToCopy._power;
        }

        public double SupplyWater(double consuption)
        {
            return consuption;
        }

        public override string ToString()
        {
            return $"Pump: Power is {_power} (pump is " + (_isActive ? "active" : "not active") + ")";
        }
    }
}
