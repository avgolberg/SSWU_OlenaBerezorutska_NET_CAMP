namespace Shop_Visitor
{
    interface IShoppingItem
    {
        string Name { get; }
        Size Size { get; }
        double Weight { get; }
        double Accept(IVisitor visitor);
    }
}