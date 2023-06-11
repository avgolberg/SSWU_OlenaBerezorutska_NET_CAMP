using System;
using System.Collections.Generic;

namespace QuickSort
{
    public interface IPivotStrategy<T> where T : IComparable<T>
    {
        string Name { get; }
        int Partition(List<T> arr, int left, int right);
    }
}