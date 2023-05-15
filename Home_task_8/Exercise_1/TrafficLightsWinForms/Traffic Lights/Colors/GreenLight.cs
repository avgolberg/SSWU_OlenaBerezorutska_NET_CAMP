namespace TrafficLights
{
    public class GreenLight : ITrafficLightColor
    {
        public string Color => "Green";
         public void ChangeColor(ITrafficLight tl)
        {
            tl.SetColor(new YellowLight());
        }
        public object Clone()
        {
            return new GreenLight();
        }
    }
}
