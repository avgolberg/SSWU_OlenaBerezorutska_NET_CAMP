using System;

namespace TrafficLights
{
    public abstract class TrafficLight : ITrafficLight
    {
        protected ITrafficLightColor _color;
        public ITrafficLightColor Color => (ITrafficLightColor)_color.Clone();

        protected ITrafficLightColor _prevColor;
        public ITrafficLightColor PrevColor => (ITrafficLightColor)_prevColor.Clone();

        protected int counter = 0;

        protected TrafficLightColorTime _colorTime;
        public TrafficLightColorTime СolorTime => (TrafficLightColorTime)_colorTime.Clone();


        public TrafficLight(ITrafficLightColor color, TrafficLightColorTime colorTime)
        {
            if(color == null)
                throw new ArgumentNullException(nameof(color));

            if (colorTime == null)
                throw new ArgumentNullException(nameof(colorTime));

            _color = (ITrafficLightColor)color.Clone();
            _colorTime = (TrafficLightColorTime)colorTime.Clone();
        }

        public virtual void CheckColorToChange()
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

        public abstract object Clone();
    }
}
