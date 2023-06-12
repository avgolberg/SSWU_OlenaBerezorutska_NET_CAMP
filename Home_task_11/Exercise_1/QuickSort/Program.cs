using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var arr = new int[] { 73, 14, 62, 8, 56, 31, 96, 14, 30, 34, 38, 82, 56, 92, 78, 53, 91, 47, 58, 78 };
                QuickSort<int> quickSort = new QuickSort<int>(arr, new FirstPivotStrategy<int>());
                quickSort.Sort();
                Console.WriteLine(quickSort);

                quickSort.ChangePivotStrategy(new LastPivotStrategy<int>());
                quickSort.Sort();
                Console.WriteLine(quickSort);

                quickSort.ChangePivotStrategy(new RandomPivotStrategy<int>());
                quickSort.Sort();
                Console.WriteLine(quickSort);

                quickSort.ChangePivotStrategy(new MedianPivotStrategy<int>());
                quickSort.Sort();
                Console.WriteLine(quickSort);

                var arr2 = new string[] { "Bob", "Sam", "Alex", "Karolina", "Roman", "Olena", "Sam", "Boris" };
                QuickSort<string> quickSort2 = new QuickSort<string>(arr2, new FirstPivotStrategy<string>());
                quickSort2.Sort();
                Console.WriteLine(quickSort2);

                quickSort2.ChangePivotStrategy(new LastPivotStrategy<string>());
                quickSort2.Sort();
                Console.WriteLine(quickSort2);

                quickSort2.ChangePivotStrategy(new RandomPivotStrategy<string>());
                quickSort2.Sort();
                Console.WriteLine(quickSort2);

                quickSort2.ChangePivotStrategy(new MedianPivotStrategy<string>());
                quickSort2.Sort();
                Console.WriteLine(quickSort2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error occured!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
