using System;
using System.Text;

namespace LuhnAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                var cardValidator = new CardValidator(@"..\..\..\cards.txt");
                Console.WriteLine("Card Types:");
                Console.WriteLine(cardValidator.GetCardTypes());
                Console.WriteLine();

                Console.WriteLine(cardValidator);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error ocured");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
