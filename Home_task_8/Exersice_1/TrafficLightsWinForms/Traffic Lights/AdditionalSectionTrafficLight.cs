namespace TrafficLights
{
    public class AdditionalSectionTrafficLight : TrafficLight
    {
        private MovementType _movementType;
        public string MovementType => _movementType.ToString();

        public AdditionalSectionTrafficLight(MovementType movementType, ITrafficLightColor color, TrafficLightColorTime colorTime) : base(color, colorTime)
        {
            _movementType = movementType;
        }
        public override object Clone()
        {
            return new AdditionalSectionTrafficLight(_movementType, _color, _colorTime);
        }
        public override string ToString()
        {
            return $"{MovementType}: {Color.Color}";
        }
    }
}
