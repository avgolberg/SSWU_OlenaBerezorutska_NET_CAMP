using System;

namespace TrafficLights
{
    [Flags] //Вказує, що перерахування може оброблятися як бітове поле (тобто набір прапорів)
    public enum MovementType
    {
        Forward, Right, Left,
        ForwardRight = Forward | Right,
        ForwardLeft = Forward | Left,
        RightLeft = Right | Left
    }
}
