using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe_CoR
{
    public class Kitchen
    {
        private object locker = new();

        private Dictionary<Category, List<ICookHandler>> _cooks = new();
        private Dictionary<Category, bool> _freeCategoryCooks = new();

        private Dictionary<Order, List<KeyValuePair<Dish, int>>> _orders = new();

        public Kitchen()
        {
            Cook drinksCook1 = new Cook("Workman", Category.Drinks);
            Cook drinksCook2 = new Cook("Saris", Category.Drinks);

            Cook pizzasCook1 = new Cook("Levin", Category.Pizzas);
            Cook pizzasCook2 = new Cook("Philips", Category.Pizzas);
            Cook pizzasCook3 = new Cook("Curtis", Category.Pizzas);

            Cook sweetCook1 = new Cook("Smith", Category.Sweets);
            Cook sweetCook2 = new Cook("Vetrovs", Category.Sweets);

            _cooks.Add(Category.Drinks, new List<ICookHandler>() { drinksCook1, drinksCook2 });
            _cooks.Add(Category.Pizzas, new List<ICookHandler>() { pizzasCook1, pizzasCook2, pizzasCook3 });
            _cooks.Add(Category.Sweets, new List<ICookHandler>() { sweetCook1, sweetCook2 });

            _freeCategoryCooks.Add(Category.Drinks, true);
            _freeCategoryCooks.Add(Category.Pizzas, true);
            _freeCategoryCooks.Add(Category.Sweets, true);

            foreach (var key in _cooks.Keys)
            {
                foreach (var value in _cooks[key])
                {
                    value.CookIsFree += OnCookIsFree;
                }
            }

            foreach (var key in _cooks.Keys)
            {
                for (int j = 0; j < _cooks[key].Count - 1; j++)
                {
                    _cooks[key][j].Next = _cooks[key][j + 1];
                }
            }
        }

        public void TakeOrder(Order order)
        {
            try
            {
                _orders.Add(order, order.FoodSet.ToList());
            }
            catch (ArgumentException)
            {
                var anotherOrder = new Order();
                foreach (var item in order.FoodSet.ToList())
                {
                    anotherOrder.Add(item.Key, item.Value);
                }
                _orders.Add(anotherOrder, anotherOrder.FoodSet.ToList());
            }

            ExecuteOrder(_orders.Last());
        }

        private void ExecuteOrder(KeyValuePair<Order, List<KeyValuePair<Dish, int>>> order)
        {
            object result = new();
            int i = 0;

            for (int n = 0; n < order.Value.Count; n++)
            {
                var amount = order.Value[n].Value;
                if (amount == 0) continue;

                i = amount;

                for (; i > 0;)
                {
                    var category = order.Value[n].Key.Category;
                    if (_freeCategoryCooks[category] == false)
                        break;

                    result = _cooks[category][0].CookHandle(order.Value[n].Key);

                    if (result == null)
                    {
                        _freeCategoryCooks[order.Value[n].Key.Category] = false;
                    }
                    else
                    {
                        var currentOrder = order.Key;
                        var currentPair = _orders[currentOrder].Find(p => p.Key == order.Value[n].Key);
                        var currentPairIndex = _orders[currentOrder].IndexOf(currentPair);

                        if (currentPair.Value != 0)
                        {
                            _orders[currentOrder][currentPairIndex] = new KeyValuePair<Dish, int>(currentPair.Key, currentPair.Value - 1);
                            i = currentPair.Value - 1;
                        }
                    }
                }
            }
        }
        private void OnCookIsFree(ICookHandler freeCook)
        {
            lock (locker)
            {
                var category = freeCook.Category;
                _freeCategoryCooks[category] = true;

                var notCompletedOrdersInCategory = _orders.Where(p => p.Value.Any(i => i.Key.Category == category && i.Value != 0)).ToList();
                if (notCompletedOrdersInCategory.Count == 0)
                    return;

                foreach (var item in notCompletedOrdersInCategory)
                {
                    ExecuteOrder(item);
                }
            }
        }

        private bool IsOrderCompleted(KeyValuePair<Order, List<KeyValuePair<Dish, int>>> order)
        {
            return _orders[order.Key].All(p => p.Value == 0);
        }
    }
}
