namespace TrafficLights
{
    public interface IRoadLane
    {
        MovementType MovementType { get; }
        bool StopLine { get; }
    }
}
