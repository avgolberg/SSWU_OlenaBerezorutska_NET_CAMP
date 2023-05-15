using System;

namespace BaseClassEvents
{
    public class CarEventArgs : EventArgs
    {
        public double Speed { get; }

        public CarEventArgs(double speed)
        {
            Speed = speed;
        }
    }
}
