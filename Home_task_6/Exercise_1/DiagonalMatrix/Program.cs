using System;
using System.Collections;

namespace DiagonalMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix dm = new DiagonalMatrix(4);
            Console.WriteLine(dm + "\n");

            foreach (var item in dm)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            IEnumerator enumerator = dm.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.Write(enumerator.Current + " ");
            }
            Console.WriteLine("\n");

            DiagonalMatrix dm2 = new DiagonalMatrix(new int[,] { { 1, 3, 5 }, { 7, 9, 11 }, { 13, 15, 17 } });
            Console.WriteLine(dm2);
        }
    }
}
