namespace TrafficLights
{
    public abstract class RoadLane : IRoadLane
    {
        protected MovementType _movementType;
        public MovementType MovementType => _movementType;

        protected bool _stopLine;
        public bool StopLine => _stopLine;

        public RoadLane(MovementType movementType, bool stopLine)
        {
            _movementType = movementType;
            _stopLine = stopLine;
        }
    }
}
