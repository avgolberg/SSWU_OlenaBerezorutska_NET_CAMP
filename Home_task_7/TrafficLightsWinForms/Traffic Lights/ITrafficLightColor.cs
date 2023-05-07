﻿using System;

namespace TrafficLights
{
    public interface ITrafficLightColor : ICloneable
    {
        string Color { get; }
        void ChangeColor(TrafficLight light);
    }
}
