namespace TrafficLights
{
    public interface IDisplayTrafficPattern
    {
        TrafficPattern GetTrafficPattern();
        void Start();
        void Show();
        void Stop();
    }
}
