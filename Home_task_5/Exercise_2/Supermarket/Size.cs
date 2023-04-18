namespace Supermarket
{
    class Size
    {
        public double Length { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Size(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{Length:F1}×{Width:F1}×{Height:F1}";
        }
    }
}
