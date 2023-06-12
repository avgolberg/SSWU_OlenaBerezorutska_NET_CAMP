using System;
using System.Collections.Generic;

namespace QuickSort
{
    public class MedianPivotStrategy<T> : IPivotStrategy<T> where T : IComparable<T>
    {
        public string Name => "Median element";

        public int Partition(List<T> arr, int left, int right)
        {
            T pivot = MedianOf3(arr, left, right);

            int i = left;
            for (int j = left + 1; j < right - 1; j++)
            {
                if (arr[j].CompareTo(pivot) < 0)
                {
                    Swap(arr, ++i, j);
                }
            }
            Swap(arr, ++i, right - 1);
            return i;
        }
        private T MedianOf3(List<T> arr, int left, int right)
        {
            if (right - left == 1)
            {
                if (arr[left].CompareTo(arr[right]) >= 0)
                    return arr[right];
                else
                    return arr[left];
            }

            int middle = (left + right) / 2;

            if (arr[left].CompareTo(arr[middle]) >= 0)
                Swap(arr, left, middle);

            if (arr[left].CompareTo(arr[right]) >= 0)
                Swap(arr, left, right);

            if (arr[middle].CompareTo(arr[right]) >= 0)
                Swap(arr, middle, right);

            Swap(arr, middle, right - 1);
            return arr[right - 1];
        }

        public void Swap(List<T> arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
