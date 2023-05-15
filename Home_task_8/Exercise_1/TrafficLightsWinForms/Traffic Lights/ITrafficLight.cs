using System;

namespace TrafficLights
{
    public interface ITrafficLight : ICloneable
    {
        ITrafficLightColor Color { get; }
        ITrafficLightColor PrevColor { get; }
        TrafficLightColorTime СolorTime { get; }
        void CheckColorToChange();
        void SetColor(ITrafficLightColor trafficLightColor);
    }
}
