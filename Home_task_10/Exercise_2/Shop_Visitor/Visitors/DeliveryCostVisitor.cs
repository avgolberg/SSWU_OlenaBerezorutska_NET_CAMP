using System;

namespace Shop_Visitor
{
    class DeliveryCostVisitor : IVisitor
    {
        private const double KILO = 1000;
      
        public double Visit(Product p)
        {
            double deliveryCost = 10;
            if (p.ExpiryDate.CompareTo(DateTime.Now) < 5)
            {
                deliveryCost += 30;
            }
            if (p.Weight > 5 * KILO)
            {
                deliveryCost += 60;
            }
            return deliveryCost;
        }
        public double Visit(Device d)
        {
            double deliveryCost = 150;
            double surcharge = 0.2; // доплата, ящко більше 20 кг складає 20%
            if (d.Weight > 20 * KILO)
            {
                deliveryCost += deliveryCost * surcharge;
            }
            return deliveryCost;
        }
        public double Visit(Clothes c)
        {
            double deliveryCost = 50;
            double surcharge = 0.3;
            if (c.Size.Height > 30)
            {
                deliveryCost += deliveryCost * surcharge;
            }
            return deliveryCost;
        }
    }
}