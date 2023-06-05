using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_Visitor
{
    class Shop
    {
        private List<IShoppingItem> _shoppingList = new List<IShoppingItem>();
        private DeliveryCostVisitor deliveryVisitor = new DeliveryCostVisitor();
        public void AddToShoppingCart(IShoppingItem shoppingItem)
        {
            if (shoppingItem == null)
                throw new ArgumentException("Shopping Item can no be null");

            _shoppingList.Add(shoppingItem);
        }

        public double GetTotalDeliveryCost()
        {
            if (_shoppingList.Count == 0)
                return 0;

            double totalCost = 0;
            foreach (var shoppingItem in _shoppingList)
            {
                totalCost += shoppingItem.Accept(deliveryVisitor);
            }
            return totalCost;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(); 
            
            if (_shoppingList.Count == 0)
                return "Shopping List is empty";

            foreach (var shoppingItem in _shoppingList)
            {
                sb.AppendLine(shoppingItem.Name + " - " + shoppingItem.Accept(deliveryVisitor));
            }
            sb.AppendLine("Total Cost: " + GetTotalDeliveryCost().ToString());
            return sb.ToString();
        }
    }
}