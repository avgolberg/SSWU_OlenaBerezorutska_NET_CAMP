using System.Collections.Generic;

namespace Cafe_CoR
{
    public class Order
    {
        private List<KeyValuePair<Dish, int>> _foodSet = new List<KeyValuePair<Dish, int>>();
        public IEnumerable<KeyValuePair<Dish, int>> FoodSet { get => _foodSet; }

        public void Add(Dish dish, int amount)
        {
            _foodSet.Add(new KeyValuePair<Dish, int>(dish, amount));
        }
    }
}
