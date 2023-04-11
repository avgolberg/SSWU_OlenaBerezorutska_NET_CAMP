using System;
using System.Text;

namespace BracketsFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                var bracketsFinder = new BracketsFinder(@"..\..\..\englishText.txt");
                Console.WriteLine(bracketsFinder);

                bracketsFinder = new BracketsFinder(@"..\..\..\ukrainianText.txt");
                Console.WriteLine(bracketsFinder);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error ocured");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
