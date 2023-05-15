using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TrafficLights
{
    public class ForwardMovement : TrafficPattern
    {
        public ForwardMovement(int redTime, int yellowTime, int greenTime) : base(redTime, yellowTime, greenTime)
        {

        }

        public override void ChangeTrafficLightsWorkingTime(int redTime, int yellowTime, int greenTime)
        {
            if (timer.Enabled)
                timer.Stop();

            //стара версія

            /*var NorthSouth = new TrafficLight("North-South", new GreenLight(), new TrafficLightColorTime(redTime, yellowTime, greenTime));
            var SouthNorth = new TrafficLight("South-North", new GreenLight(), new TrafficLightColorTime(redTime, yellowTime, greenTime));
            var EastWest = new TrafficLight("East-West", new RedLight(), new TrafficLightColorTime(greenTime, yellowTime, redTime));
            var WestEast = new TrafficLight("West-East", new RedLight(), new TrafficLightColorTime(greenTime, yellowTime, redTime));

            _trafficLights = new List<ITrafficLight>() { NorthSouth, SouthNorth, EastWest, WestEast }; */

            List<IRoad> roads = new List<IRoad>();
            roads.Add(new OrdinaryRoad(new List<IRoadLane>() 
            { 
                new TrafficLightRoadLane(MovementType.Forward, false, new OrdinaryTrafficLight("North-South", new GreenLight(), new TrafficLightColorTime(redTime, yellowTime, greenTime))),
                new TrafficLightRoadLane(MovementType.Forward, false, new OrdinaryTrafficLight("South-North", new GreenLight(), new TrafficLightColorTime(redTime, yellowTime, greenTime))) 
            },
            RoadLocationType.North | RoadLocationType.South));

            roads.Add(new OrdinaryRoad(new List<IRoadLane>() 
            { 
                new TrafficLightRoadLane(MovementType.Forward, false, new OrdinaryTrafficLight("East-West", new RedLight(), new TrafficLightColorTime(greenTime, yellowTime, redTime))),
                new TrafficLightRoadLane(MovementType.Forward, false, new OrdinaryTrafficLight("West-East", new RedLight(), new TrafficLightColorTime(greenTime, yellowTime, redTime))) 
            }, 
            RoadLocationType.East | RoadLocationType.West));

            _intersection = new Intersection(roads);

            _trafficLights = (List<ITrafficLight>)_intersection.TrafficLights;
        }
    }
}
