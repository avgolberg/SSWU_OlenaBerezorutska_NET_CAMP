using System;
using System.Collections.Generic;

namespace QuickSort
{
    public class LastPivotStrategy<T> : IPivotStrategy<T> where T : IComparable<T>
    {
        public string Name => "Last element";

        public int Partition(List<T> arr, int left, int right)
        {
            T pivot = arr[right];

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
        private void Swap(List<T> arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
