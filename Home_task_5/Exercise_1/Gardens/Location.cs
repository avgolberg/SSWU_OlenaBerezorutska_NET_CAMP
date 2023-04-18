namespace Gardens
{
    class Location
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Location(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X:f}, {Y:f})";
        }
    }
}
