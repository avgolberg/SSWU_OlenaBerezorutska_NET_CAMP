using System;
using System.Text;

namespace ElectricityAccounting
{// Молодець!
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                var accounting = new ElectricityAccounting(@"..\..\..\electricityData.txt", 1.5);
                Console.WriteLine(accounting + "\n");
                Console.WriteLine(accounting.PrintBy(12) + "\n");
                Console.WriteLine(accounting.PrintBy("вул. Василя Стуса, б. 14, кв. 13", 2022, 1) + "\n");
                Console.WriteLine("Прізвище власника з найбільшою заборгованістю: " + accounting.LargestDebtSurname() + "\n");
                Console.WriteLine("Номери квартири, в яких не використовувалась електроенергія: " + string.Join(", ", accounting.NotUsedElectricityApartments())+ "\n");
                Console.WriteLine("Суми витрат:");
                Console.WriteLine(accounting.TotalExpenses(1) + "\n");
                Console.WriteLine(accounting.TotalExpenses(2) + "\n");
                Console.WriteLine(accounting.DaysPast());

                double price = 2;
                Console.WriteLine($"Ціну змінено на {price}");
                accounting.ChangePrice(price);
                Console.WriteLine("Суми витрат:");
                Console.WriteLine(accounting.TotalExpenses(1) + "\n");
                Console.WriteLine(accounting.TotalExpenses(2) + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error ocured");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
