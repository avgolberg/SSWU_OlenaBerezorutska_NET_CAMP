namespace Supermarket
{
    class Product : IPackable
    {
        public string Name { get; private set; }
        public Size Size { get; private set; }
        public Product(string name, Size size)
        {
            Name = name;
            Size = size;
        }
        public Product(string name, double length, double width, double height)
        {
            Name = name;
            Size = new Size(length, width, height);
        }

        public Box Pack()
        {
            return new Box(Name, this);
        }
        public override string ToString()
        {
            return $"{Name} ({Size}) ";
        }
    }
}
