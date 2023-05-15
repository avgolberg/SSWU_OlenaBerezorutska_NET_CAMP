using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TrafficLights
{
    public class ComplexMovement : TrafficPattern
    {
        public ComplexMovement(int redTime, int yellowTime, int greenTime) : base(redTime, yellowTime, greenTime)
        {

        }

        public override void ChangeTrafficLightsWorkingTime(int redTime, int yellowTime, int greenTime)
        {
            if (timer.Enabled)
                timer.Stop();

            List<IRoad> roads = new List<IRoad>();

            roads.Add(
             new TrafficLightRoad(new List<IRoadLane>()
                {
                    new OrdinaryRoadLane(MovementType.Forward, false),
                    new OrdinaryRoadLane(MovementType.Forward, false),
                    new OrdinaryRoadLane(MovementType.ForwardRight, true)
                },
            RoadLocationType.North,
            new AdditionalSectionsTrafficLight(
                new OrdinaryTrafficLight("North-South", new RedLight(), new TrafficLightColorTime(redTime, yellowTime, greenTime)),
                new AdditionalSectionTrafficLight(MovementType.Right, new GreenLight(), new TrafficLightColorTime(greenTime, yellowTime, redTime)))));

            roads.Add(
             new TrafficLightRoad(new List<IRoadLane>()
                {
                        new OrdinaryRoadLane(MovementType.Forward, false),
                        new OrdinaryRoadLane(MovementType.Forward, false),
                        new OrdinaryRoadLane(MovementType.ForwardRight, true)
                },
            RoadLocationType.South,
            new AdditionalSectionsTrafficLight(
                new OrdinaryTrafficLight("South-North", new RedLight(), new TrafficLightColorTime(redTime, yellowTime, greenTime)),
                new AdditionalSectionTrafficLight(MovementType.Right, new GreenLight(), new TrafficLightColorTime(greenTime, yellowTime, redTime)))));

            roads.Add(
               new TrafficLightRoad(new List<IRoadLane>()
                  {
                            new OrdinaryRoadLane(MovementType.Forward, false),
                            new OrdinaryRoadLane(MovementType.Forward, false),
                            new OrdinaryRoadLane(MovementType.Forward, false),
                            new OrdinaryRoadLane(MovementType.Forward, false),
                            new OrdinaryRoadLane(MovementType.Forward, false),
                            new OrdinaryRoadLane(MovementType.Forward, false)
                  },
              RoadLocationType.East,
              new OrdinaryTrafficLight("East-West", new GreenLight(), new TrafficLightColorTime(greenTime, yellowTime, redTime))));

            roads.Add(
              new TrafficLightRoad(new List<IRoadLane>()
                 {
                            new OrdinaryRoadLane(MovementType.Forward, false),
                            new OrdinaryRoadLane(MovementType.Forward, false),
                            new OrdinaryRoadLane(MovementType.Forward, false),
                            new OrdinaryRoadLane(MovementType.Forward, false),
                            new OrdinaryRoadLane(MovementType.Forward, false),
                            new OrdinaryRoadLane(MovementType.Forward, false)
                 },
             RoadLocationType.West,
             new OrdinaryTrafficLight("West-East", new GreenLight(), new TrafficLightColorTime(greenTime, yellowTime, redTime))));

            _intersection = new Intersection(roads);

            _trafficLights = (List<ITrafficLight>)_intersection.TrafficLights;
        }
    }
}
