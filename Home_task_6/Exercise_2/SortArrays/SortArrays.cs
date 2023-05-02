using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortArrays
{
    class SortArrays
    {
        private IEnumerable<int>[] _arrays;

        public SortArrays(params IEnumerable<int>[] arrays)
        {
            _arrays = arrays;
            InitialSort();
        }

        private void InitialSort()
        {
            for (int i = 0; i < _arrays.Length; i++)
            {
                //сортування із вибором, щоб повертати min у yield
                //SelectionSort Ω(n^2) - θ(n^2) - O(n^2), просторова - O(1)
                //чи Heap Sort Ω(n log(n)) - θ(n log(n)) - O(n log(n)), просторова - O(1)
                _arrays[i] = SelectionSort(_arrays[i]);

                //QuickSort Ω(n log(n)) - θ(n log(n) - O(n^2), просторова - O(n)
                //_arrays[i] = _arrays[i].OrderBy(e => e); 
            }
        }

        private IEnumerable<int> SelectionSort(IEnumerable<int> arr)
        {
            List<int> array = arr.ToList();
            for (int i = 0; i < array.Count - 1; i++)
            {
                int minI = i;
                for (int j = i + 1; j < array.Count; j++)
                    if (array[j] < array[minI])
                        minI = j;

                yield return array[minI];

                int temp = array[minI];
                array[minI] = array[i];
                array[i] = temp;
            }

            yield return array[array.Count-1];
        }

        public IEnumerable<int> Merge()
        {// тут треба обговорити в індивідіальному порядку.
            var enumerators = _arrays.Select(a => a.GetEnumerator()).ToList();
            enumerators.RemoveAll(e => !e.MoveNext());

            while (enumerators.Any())
            {
                int min = enumerators.Min(e => e.Current);
                var minEnumerator = enumerators.Find(e => e.Current == min);

                yield return minEnumerator.Current;

                if (!minEnumerator.MoveNext())
                    enumerators.Remove(minEnumerator);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Merge())
            {
                sb.Append(item + " ");
            }
            return sb.ToString();
        }
    }
}
