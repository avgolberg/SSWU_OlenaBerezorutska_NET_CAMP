namespace TrafficLights
{
    public interface IDisplayTrafficPattern
    {
        ITrafficPattern GetTrafficPattern();
        void Start();
        void Show();
        void Stop();
    }
}
