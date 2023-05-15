using System;
using System.Collections.Generic;

namespace TrafficLights
{
    public abstract class Road : IRoad
    {
        protected List<IRoadLane> _roadLanes;
        public IEnumerable<IRoadLane> RoadLanes => _roadLanes;

        protected RoadLocationType _locationType;
        public RoadLocationType LocationType => _locationType;

        public Road(List<IRoadLane> roadLanes, RoadLocationType locationType)
        {
            _roadLanes = roadLanes ?? throw new ArgumentNullException(nameof(_roadLanes));
            _locationType = locationType;
        }
    }
}
