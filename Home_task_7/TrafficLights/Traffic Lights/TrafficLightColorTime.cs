using System;

namespace TrafficLights
{
    public class TrafficLightColorTime : ICloneable
    {
        public int RedTime { get; }
        public int YellowTime { get; }
        public int GreenTime { get; }

        public TrafficLightColorTime(int redTime, int yellowTime, int greenTime)
        {
            RedTime = redTime;
            YellowTime = yellowTime;
            GreenTime = greenTime;
        }

        public object Clone()
        {
            return new TrafficLightColorTime(RedTime, YellowTime, GreenTime);
        }

        public override string ToString()
        {
            return $"Red: {RedTime}, Yellow: {YellowTime}, Green: {GreenTime}";
        }
    }
}
