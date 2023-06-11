using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace QuickSort
{
    public class QuickSort<T> where T : IComparable<T>
    {
        private List<T> _originalItems;
        private List<T> _items;
        private IPivotStrategy<T> _pivotStrategy;
        private Stopwatch _stopwatch;
        public QuickSort(IEnumerable<T> items, IPivotStrategy<T> pivotStrategy)
        {
            _stopwatch = new Stopwatch();
            _originalItems = new List<T>(items);
            _items = new List<T>(items);
            ChangePivotStrategy(pivotStrategy);
        }
        public void ChangePivotStrategy(IPivotStrategy<T> pivotStrategy)
        {
            if (pivotStrategy == null)
                throw new ArgumentException("Pivot Strategy can not be null");

            _pivotStrategy = pivotStrategy;
        }

        public void Sort()
        {
            _stopwatch.Start();
            QuickSortAlgorithm(_items, 0, _items.Count - 1);
            _stopwatch.Stop();
        }
      
        private void QuickSortAlgorithm(List<T> arr, int left, int right)
        {
            if (left < right)
            {
                int partition = _pivotStrategy.Partition(arr, left, right);

                QuickSortAlgorithm(arr, left, partition - 1);
                QuickSortAlgorithm(arr, partition + 1, right);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Original Items:");
            sb.AppendLine(string.Join(", ", _originalItems));

            sb.AppendLine("Sorted Items:");
            sb.AppendLine(string.Join(", ", _items));

            sb.AppendLine($"Pivot: {_pivotStrategy.Name}");
            sb.AppendLine($"Time: {_stopwatch.Elapsed}");
            return sb.ToString();
        }
    }
}
