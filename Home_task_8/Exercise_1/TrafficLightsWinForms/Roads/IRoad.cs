using System.Collections.Generic;

namespace TrafficLights
{
    public interface IRoad
    {
        IEnumerable<IRoadLane> RoadLanes { get; }
        RoadLocationType LocationType { get; }
    }
}
