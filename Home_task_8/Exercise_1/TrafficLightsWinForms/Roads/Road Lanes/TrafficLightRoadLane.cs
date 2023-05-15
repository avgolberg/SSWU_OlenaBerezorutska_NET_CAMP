using System;

namespace TrafficLights
{
    public class TrafficLightRoadLane : RoadLane, IContainTrafficLight
    {
        private ITrafficLight _trafficLight;
        public ITrafficLight TrafficLight => (ITrafficLight)_trafficLight.Clone();

        public TrafficLightRoadLane(MovementType movementType, bool stopLine, ITrafficLight trafficLight) : base(movementType, stopLine)
        {
            _trafficLight = trafficLight ?? throw new ArgumentNullException(nameof(trafficLight));
        }

        public override string ToString()
        {
            return $"{MovementType}, Stop Line: {StopLine}";
        }
    }
}
