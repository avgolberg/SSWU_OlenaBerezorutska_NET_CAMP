using System;
using System.Timers;

namespace TrafficLights
{
    class ConsoleDisplay : IDisplayTrafficPattern
    {
        private Timer _timer;
        private TrafficPattern _trafficPattern;

        public ConsoleDisplay(TrafficPattern trafficPattern, double interval = 1000)
        {
            _timer = new Timer(interval);
            _timer.Elapsed += OnTimedEvent;
            _trafficPattern = trafficPattern;
        }
        public TrafficPattern GetTrafficPattern()
        {
            return _trafficPattern;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("\n{0:HH:mm:ss}", e.SignalTime);
            Show();
        }
        public void Show()
        {
            Console.WriteLine(_trafficPattern);
        }
    }
}
