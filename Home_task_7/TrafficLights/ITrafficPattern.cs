namespace TrafficLights
{
    public interface ITrafficPattern
    {
        void StartMovement();
        void StopMovement();

        void ChangeTrafficLightsWorkingTime(int redTime, int yellowTime, int greenTime);
    }
}
