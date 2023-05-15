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
            if (redTime <= 0) throw new ArgumentException(nameof(redTime), "ColorTime can not be negative or 0");
            if (yellowTime <= 0) throw new ArgumentException(nameof(yellowTime), "ColorTime can not be negative or 0");
            if (greenTime <= 0) throw new ArgumentException(nameof(greenTime), "ColorTime can not be negative or 0");

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
