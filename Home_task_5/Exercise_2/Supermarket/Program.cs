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

            //create structure method
            Store store = new Store("Silpo");
            //store.CreateStructure("|Технічний відділ||Комп'ютери|||Аксесуари||Побутова техніка|Продуктовий відділ||Молочний відділ||М'ясний відділ");

            var tech = new StoreSection("Технічний відділ");
            var computers = new StoreSection("Комп'ютери");
            var accessories = new StoreSection("Аксесуари");

            var householdAppliances = new StoreSection("Побутова техніка");

            var product = new StoreSection("Продуктовий відділ");
            var dairy = new StoreSection("Молочний відділ");
            var meat = new StoreSection("М'ясний відділ");

            computers.AddSubsection(accessories);

            tech.AddSubsection(computers);
            tech.AddSubsection(householdAppliances);

            product.AddSubsection(dairy);
            product.AddSubsection(meat);

            store.AddSection(tech);
            store.AddSection(product);

            Console.WriteLine(store);

            store.Buy(book, "Технічний відділ|Комп'ютери|Аксесуари");
            store.Buy(book, "Технічний відділ|Комп'ютери|Аксесуари");
            store.Buy(cheese, "Продуктовий відділ|Молочний відділ");
            var box = store.Pack();
            Console.WriteLine(box);
        }
    }
}
