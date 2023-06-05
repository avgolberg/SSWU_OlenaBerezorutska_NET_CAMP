namespace Shop_Visitor
{
    interface IVisitor
    {
        double Visit(Product p);
        double Visit(Device d);
        double Visit(Clothes c);
    }
}