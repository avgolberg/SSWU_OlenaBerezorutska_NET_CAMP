namespace TrafficLights
{
    public class TrafficLightRoadLane : RoadLane, IContainTrafficLight
    {
        private ITrafficLight _trafficLight;
        public ITrafficLight TrafficLight => _trafficLight;

        public TrafficLightRoadLane(MovementType movementType, bool stopLine, ITrafficLight trafficLight) : base(movementType, stopLine)
        {
            _trafficLight = trafficLight;
        }

        public override string ToString()
        {
            return $"{MovementType}, Stop Line: {StopLine}";
        }
    }
}
