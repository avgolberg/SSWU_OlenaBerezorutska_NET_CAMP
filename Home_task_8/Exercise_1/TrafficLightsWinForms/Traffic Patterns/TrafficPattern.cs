using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TrafficLights
{
    public abstract class TrafficPattern
    {
        private int SEC = 1000;
        protected Timer timer;
        protected List<ITrafficLight> _trafficLights = new List<ITrafficLight>();
        public IEnumerable<ITrafficLight> TrafficLights => _trafficLights;

        protected IIntersection _intersection;


        public TrafficPattern(int redTime, int yellowTime, int greenTime)
        {
            if (redTime <= 0) throw new ArgumentException(nameof(redTime), "ColorTime can not be negative or 0");
            if (yellowTime <= 0) throw new ArgumentException(nameof(yellowTime), "ColorTime can not be negative or 0");
            if (greenTime <= 0) throw new ArgumentException(nameof(greenTime), "ColorTime can not be negative or 0");

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
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (ITrafficLight tl in _trafficLights)
            {
                tl.CheckColorToChange();
            }
        }

        public abstract void ChangeTrafficLightsWorkingTime(int redTime, int yellowTime, int greenTime);

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (ITrafficLight tl in _trafficLights)
            {
                sb.Append(tl + "\n");
            }
            return sb.ToString();
        }
    }
}
