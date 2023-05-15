using System;
using System.Collections.Generic;

namespace TrafficLights
{
    public class Intersection : IIntersection
    {
        private List<IRoad> _roads;
        public IEnumerable<IRoad> Roads => _roads;

        List<ITrafficLight> _trafficLights = new List<ITrafficLight>();
        public IEnumerable<ITrafficLight> TrafficLights => GetTrafficLights();

        public Intersection(List<IRoad> roads)
        {
            _roads = roads ?? throw new ArgumentNullException(nameof(roads));
        }

        private IEnumerable<ITrafficLight> GetTrafficLights()
        {
            if (_trafficLights.Count != 0) return _trafficLights;

            foreach (IRoad road in _roads)
            {
                if (road is IContainTrafficLight)
                {
                    _trafficLights.Add((road as IContainTrafficLight).TrafficLight);
                    continue;
                }

                foreach (IRoadLane roadlane in road.RoadLanes)
                {
                    if (roadlane is IContainTrafficLight)
                        _trafficLights.Add((roadlane as IContainTrafficLight).TrafficLight);
                }
            }
            return _trafficLights;
        }
    }
}
