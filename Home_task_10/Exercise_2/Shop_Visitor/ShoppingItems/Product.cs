using System;

namespace Shop_Visitor
{
    class Product : IShoppingItem
    {
        public string Name { get; private set; }
        public Size Size { get; private set; }
        public double Weight { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        public Product(string name, Size size, double weight, DateTime expiryDate)
        {
            Name = name;
            Size = size;
            Weight = weight;
            ExpiryDate = expiryDate;
        }

        public double Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public override string ToString()
        {
            return $"{Name} ({Size}, {Weight}, {ExpiryDate})";
        }
    }
}