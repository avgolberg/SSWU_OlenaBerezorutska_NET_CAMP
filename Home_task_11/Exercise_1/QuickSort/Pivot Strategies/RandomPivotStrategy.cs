using System;
using System.Collections.Generic;

namespace QuickSort
{
    public class RandomPivotStrategy<T> : IPivotStrategy<T> where T : IComparable<T>
    {
        private Random random = new Random();
        public string Name => "Random element";

        public int Partition(List<T> arr, int left, int right)
        {
            int pivotIndex = GenerateRandomPivot(left, right);
            T pivot = arr[pivotIndex];
            Swap(arr, pivotIndex, right);

            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (arr[j].CompareTo(pivot) <= 0)
                {
                    Swap(arr, ++i, j);
                }
            }
            Swap(arr, ++i, right);
            return i;
        }
        private int GenerateRandomPivot(int low, int high)
        {
            return low + random.Next(high - low + 1);
        }
        private void Swap(List<T> arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
