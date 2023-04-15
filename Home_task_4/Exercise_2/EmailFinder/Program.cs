using System;
using System.Text;

namespace EmailFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                var emailFinder = new EmailFinder(@"..\..\..\text.txt");
                Console.WriteLine(emailFinder);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error ocured");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
