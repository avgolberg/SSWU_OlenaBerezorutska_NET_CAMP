using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string data = @"..\..\..\integers.txt";
                IntegersGenerator generator = new IntegersGenerator(data, 150);
                MergeSort mergeSort = new MergeSort(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error occured!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
