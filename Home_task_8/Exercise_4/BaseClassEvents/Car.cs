using System;

namespace BaseClassEvents
{
    public abstract class Car
    {
        protected double _speed;
        public event EventHandler<CarEventArgs> SpeedLimit;
        public abstract void Move(double distance, double time);
        protected virtual void OnMaxSpeed(CarEventArgs e)
        {
            SpeedLimit?.Invoke(this, e);
        }
    }
}
