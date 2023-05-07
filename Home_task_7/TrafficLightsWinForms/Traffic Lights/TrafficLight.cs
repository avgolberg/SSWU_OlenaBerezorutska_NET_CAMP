using System;

namespace TrafficLights
{
    public class TrafficLight
    {
        private string _location;
        public string Location => _location;

        private ITrafficLightColor _color;
        public string Color => _color.Color;

        public ITrafficLightColor _prevColor;

        private int counter = 0;
        private TrafficLightColorTime _colorTime;

        public TrafficLight(ITrafficLightColor color, string location, TrafficLightColorTime colorTime)
        {
            _color = (ITrafficLightColor)color.Clone();
            _location = location;
            _colorTime = (TrafficLightColorTime)colorTime.Clone();
        }

        //rules
        public void Tick()
        {
            ++counter;
            if (_color is RedLight && counter == _colorTime.RedTime)
            {
                _prevColor = _color;
                _color.ChangeColor(this);
                counter = 0;
            }
            else if (_color is YellowLight && counter == _colorTime.YellowTime)
            {
                _color.ChangeColor(this);
                counter = 0;
            }
            else if (_color is GreenLight && counter == _colorTime.GreenTime)
            {
                _prevColor = _color;
                _color.ChangeColor(this);
                counter = 0;
            }
        }
        public void SetColor(ITrafficLightColor trafficLightColor)
        {
            if (trafficLightColor == null)
                throw new ArgumentNullException("TrafficLightColor can not be null");

            _color = (ITrafficLightColor)trafficLightColor.Clone();
        }

        public ITrafficLightColor GetPreviousColor()
        {
            return (ITrafficLightColor)_prevColor.Clone();
        }
        public override string ToString()
        {
            return $"{Location}: {Color}";
        }
    }
}
