namespace TrafficLights
{
    public class YellowLight : ITrafficLightColor
    {
        public string Color => "Yellow";

        public void ChangeColor(ITrafficLight tl)
        {
            if(tl.PrevColor is RedLight)
               tl.SetColor(new GreenLight());
            else if (tl.PrevColor is GreenLight)
               tl.SetColor(new RedLight());
        }
      
        public object Clone()
        {
            return new YellowLight();
        }
    }
}
