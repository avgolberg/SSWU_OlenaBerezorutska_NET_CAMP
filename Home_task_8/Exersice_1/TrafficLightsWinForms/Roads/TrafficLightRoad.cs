using System;
using System.Collections.Generic;

namespace TrafficLights
{
    public class TrafficLightRoad : Road, IContainTrafficLight
    {
        private ITrafficLight _trafficLight;
        public ITrafficLight TrafficLight => (ITrafficLight)_trafficLight.Clone();

        public TrafficLightRoad(List<IRoadLane> roadLanes, RoadLocationType locationType, ITrafficLight trafficLight) : base(roadLanes, locationType)
        {
            _trafficLight = trafficLight ?? throw new ArgumentNullException(nameof(trafficLight));
        }
    }
}
