using System;
using System.Linq;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Product book = new Product("Book", new Size(10, 10, 10));
            Product cheese = new Product("Cheese", new Size(5, 5, 2));

            Store store = new Store("Silpo");
            store.CreateStructure("|Технічний відділ||Смарт-годинники||Комп'ютери|||Аксесуари||Побутова техніка|Продуктовий відділ||Молочний відділ||М'ясний відділ");
            Console.WriteLine(store);

            store.Buy(book, "Технічний відділ|Комп'ютери|Аксесуари");
            store.Buy(book, "Технічний відділ|Комп'ютери|Аксесуари");
            store.Buy(cheese, "Продуктовий відділ|Молочний відділ");
            Console.WriteLine(store.Pack());
        }
    }
}
