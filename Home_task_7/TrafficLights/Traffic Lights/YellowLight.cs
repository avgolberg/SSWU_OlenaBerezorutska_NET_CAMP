namespace TrafficLights
{
    public class YellowLight : ITrafficLightColor
    {
        public string Color => "Yellow";

        public void ChangeColor(TrafficLight tl)
        {
            if(tl.GetPreviousColor() is RedLight)
               tl.SetColor(new GreenLight());
            else if (tl.GetPreviousColor() is GreenLight)
               tl.SetColor(new RedLight());
        }
      
        public object Clone()
        {
            return new YellowLight();
        }
    }
}
