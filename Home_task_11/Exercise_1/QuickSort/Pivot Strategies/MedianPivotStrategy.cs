using System;
using System.Collections.Generic;

namespace QuickSort
{
    public class MedianPivotStrategy<T> : IPivotStrategy<T> where T : IComparable<T>
    {
        public string Name => "Median element";

        public int Partition(List<T> arr, int left, int right)
        {
            //Change logic to median
            T pivot = arr[left];

            int i = right + 1;
            for (int j = right; j > left; j--)
            {
                if (arr[j].CompareTo(pivot) > 0)
                {
                    Swap(arr, --i, j);
                }
            }
            Swap(arr, left, --i);
            return i;
        }
        public void Swap(List<T> arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
