namespace TrafficLights
{
    public class OrdinaryTrafficLight : TrafficLight
    {
        private string _location;
        public string Location => _location;

        public OrdinaryTrafficLight(string location, ITrafficLightColor color, TrafficLightColorTime colorTime) : base(color, colorTime)
        {
            _location = location;
        }
        public override object Clone()
        {
            return new OrdinaryTrafficLight(_location, _color, _colorTime);
        }
        public override string ToString()
        {
            return $"{Location}: {Color.Color}";
        }
    }
}
