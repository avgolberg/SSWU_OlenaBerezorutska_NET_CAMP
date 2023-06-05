namespace Shop_Visitor
{
    class Clothes : IShoppingItem
    {
        public string Name { get; private set; }
        public Size Size { get; private set; }
        public double Weight { get; private set; }
        public Clothes(string name, Size size, double weight)
        {
            Name = name;
            Size = size;
            Weight = weight;
        }
        public double Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public override string ToString()
        {
            return $"{Name} ({Size}, {Weight})";
        }
    }
}