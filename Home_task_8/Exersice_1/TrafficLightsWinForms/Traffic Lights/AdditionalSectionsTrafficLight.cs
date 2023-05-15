using System;
using System.Collections.Generic;

namespace TrafficLights
{
    public class AdditionalSectionsTrafficLight : IAdditionalSectionsTrafficLight
    {
        private OrdinaryTrafficLight _trafficLight;
        public OrdinaryTrafficLight TrafficLight => (OrdinaryTrafficLight)_trafficLight.Clone();

        private List<AdditionalSectionTrafficLight> _additionalSections = new List<AdditionalSectionTrafficLight>();
        public IEnumerable<AdditionalSectionTrafficLight> AdditionalSections => _additionalSections;

        public ITrafficLightColor Color => TrafficLight.Color;
        public ITrafficLightColor PrevColor => TrafficLight.PrevColor;
        public TrafficLightColorTime СolorTime => TrafficLight.СolorTime;

        public AdditionalSectionsTrafficLight(OrdinaryTrafficLight trafficLight, params AdditionalSectionTrafficLight[] additionalSection)
        {
            _trafficLight = trafficLight ?? throw new ArgumentNullException(nameof(trafficLight));

            foreach (var section in additionalSection)
            {
                if (section == null)
                    throw new ArgumentNullException(nameof(section));

                _additionalSections.Add(section);
            }
        }
        public void CheckColorToChange()
        {
            _trafficLight.CheckColorToChange();
            foreach (var additionalSection in _additionalSections)
            {
                additionalSection.CheckColorToChange();
            }
        }

        public void SetColor(ITrafficLightColor trafficLightColor)
        {
            _trafficLight.SetColor(trafficLightColor);
        }

        public object Clone()
        {
            return new AdditionalSectionsTrafficLight(TrafficLight, (AdditionalSectionTrafficLight[])AdditionalSections);
        }

        public override string ToString()
        {
            return $"{_trafficLight.Location}: {Color.Color}, Additional: {_additionalSections.Count} ({string.Join(",", _additionalSections)})";
        }
    }
}
