using System;
using System.Linq;

namespace SortArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            SortArrays sortArrays = new SortArrays(new int[] { 7, 7, 6, 5 }, new int[] { 1, 7, 2, 3, 4 }, new int[] {11, 9, 8, 10 }, new int[] { 13, 12 }, new int[] { 15, 14, 1 });
            Console.WriteLine(sortArrays);

            foreach (var item in sortArrays.Merge().Take(5))
            {
                Console.Write(item + " ");
            }
        }
    }
}
