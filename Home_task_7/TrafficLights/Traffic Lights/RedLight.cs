namespace TrafficLights
{
    public class RedLight : ITrafficLightColor
    {
        public string Color =>  "Red";

        public void ChangeColor(TrafficLight tl)
        {
            tl.SetColor(new YellowLight());
        }
        public object Clone()
        {
            return new RedLight();
        }
    }
}
