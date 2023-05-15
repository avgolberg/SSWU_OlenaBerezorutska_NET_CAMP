namespace TrafficLights
{
    public abstract class RoadLane : IRoadLane
    {
        private MovementType _movementType;
        public MovementType MovementType => _movementType;

        private bool _stopLine;
        public bool StopLine => _stopLine;

        public RoadLane(MovementType movementType, bool stopLine)
        {
            _movementType = movementType;
            _stopLine = stopLine;
        }
    }
}
