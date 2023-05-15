using System.Collections.Generic;

namespace TrafficLights
{
    public interface IIntersection
    {
        IEnumerable<IRoad> Roads { get; }
        IEnumerable<ITrafficLight> TrafficLights { get; }
    }
}
