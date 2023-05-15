using System.Collections.Generic;

namespace TrafficLights
{
    public class OrdinaryRoad : Road
    {
        public OrdinaryRoad(List<IRoadLane> roadLanes, RoadLocationType locationType) : base(roadLanes, locationType)
        {

        }
    }
}
