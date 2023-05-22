using System;

namespace Cafe_CoR
{
    class Program
    {
        static void Main(string[] args)
        {
            Dish quattroFormaggiPizza = new Dish("Піца 4 сири", Category.Pizzas, 5);
            Dish hawaiianPizza = new Dish("Піца Гавайська", Category.Pizzas, 4);
            Dish paradiseDessert = new Dish("Десерт Райський", Category.Sweets, 3);
            Dish tiramisuDessert = new Dish("Тірамісу", Category.Sweets, 4);
            Dish pineappleJuice = new Dish("Сік ананасовий", Category.Drinks, 1);

            Order order = new Order();
            order.Add(pineappleJuice, 5);
            order.Add(quattroFormaggiPizza, 2);
            order.Add(hawaiianPizza, 2);
            order.Add(paradiseDessert, 1);
            order.Add(tiramisuDessert, 3);

            Kitchen kitchen = new Kitchen();
            kitchen.TakeOrder(order);
            kitchen.TakeOrder(order);

            Console.ReadLine();
        }
    }
}
