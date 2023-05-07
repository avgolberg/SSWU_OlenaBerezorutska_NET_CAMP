namespace TrafficLights
{
    public class IntersectionSimulator
    {
        public ITrafficPattern _pattern;
        public IDisplayTrafficPattern _display;

        public IntersectionSimulator(IDisplayTrafficPattern display)
        {
            _display = display;
            _pattern = display.GetTrafficPattern();
        }
        public void Start()
        {
            _pattern.StartMovement();
            _display.Start();
        }

        public void Change(int redTime, int yellowTime, int greenTime)
        {
            _display.Stop();
            _pattern.ChangeTrafficLightsWorkingTime(redTime, yellowTime, greenTime);

            Start();
        }

        public void Stop()
        {
            _pattern.StopMovement();
            _display.Stop();
        }
    }
}
