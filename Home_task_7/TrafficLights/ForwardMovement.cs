using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TrafficLights
{
    public class ForwardMovement : ITrafficPattern
    {
        private const int SEC = 1000;
        private Timer timer;
        private List<TrafficLight> _trafficLights = new List<TrafficLight>();

        public ForwardMovement(int redTime, int yellowTime, int greenTime)
        {
            timer = new Timer(SEC);
            timer.Elapsed += OnTimedEvent;
            ChangeTrafficLightsWorkingTime(redTime, yellowTime, greenTime);
        }

        public void StartMovement()
        {
            timer.Start();
        }
        public void StopMovement()
        {
            timer.Stop();
        }

        public void ChangeTrafficLightsWorkingTime(int redTime, int yellowTime, int greenTime)
        {
            if (timer.Enabled)
                timer.Stop();

            var NorthSouth = new TrafficLight(new GreenLight(), "North-South", new TrafficLightColorTime(redTime, yellowTime, greenTime));
            var SouthNorth = new TrafficLight(new GreenLight(), "South-North", new TrafficLightColorTime(redTime, yellowTime, greenTime));
            var EastWest = new TrafficLight(new RedLight(), "East-West", new TrafficLightColorTime(greenTime, yellowTime, redTime));
            var WestEast = new TrafficLight(new RedLight(), "West-East", new TrafficLightColorTime(greenTime, yellowTime, redTime));

            _trafficLights = new List<TrafficLight>() { NorthSouth, SouthNorth, EastWest, WestEast };
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (TrafficLight tl in _trafficLights)
            {
                tl.Tick();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (TrafficLight tl in _trafficLights)
            {
                sb.Append(tl + "\n");
            }
            return sb.ToString();
        }
    }
}
