using System;
using System.Text;

namespace Shop_Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                var shop = new Shop();
                shop.AddToShoppingCart(new Product("Сир", new Size(5, 5, 2), 200, DateTime.Now.AddDays(3)));
                shop.AddToShoppingCart(new Device("Пральна машина", new Size(400, 900, 600), 30000));
                shop.AddToShoppingCart(new Clothes("Плаття", new Size(100, 70, 5), 300));

                Console.WriteLine(shop);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error ocured");
                Console.WriteLine(ex.Message);
            }
        }
    }
}