namespace TrafficLights
{
    public class OrdinaryRoadLane : RoadLane
    {
        public OrdinaryRoadLane(MovementType movementType, bool stopLine) : base(movementType, stopLine)
        {

        }

        public override string ToString()
        {
            return $"{MovementType}, Stop Line: {StopLine}";
        }
    }
}
