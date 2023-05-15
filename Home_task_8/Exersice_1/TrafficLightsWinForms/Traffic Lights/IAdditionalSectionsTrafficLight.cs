using System.Collections.Generic;

namespace TrafficLights
{
    public interface IAdditionalSectionsTrafficLight : ITrafficLight
    {
        OrdinaryTrafficLight TrafficLight { get; }
        IEnumerable<AdditionalSectionTrafficLight> AdditionalSections { get; }
    }
}
