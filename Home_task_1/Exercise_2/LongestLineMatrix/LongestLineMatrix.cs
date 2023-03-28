using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestLineMatrix
{
    internal class LongestLineMatrix
    {// чому порушені принципи інкапсуляції?
        private struct Index
        {
            public int i;
            public int j;

            public Index(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
        }

        private struct LongestLine
        {// чому обрані для додатних величин знакові типи?
            public int color;
            public int count;
            public Index startIndex;
            // Ще бракує напрямку, горизонтального чи вертикального, чи діагонального

            public LongestLine(int color, int count, Index startIndex)
            {
                this.color = color;
                this.count = count;
                this.startIndex = startIndex;
            }

            public override string ToString()
            {
                return $"Color: {color}, " +
                     $"StartIndex: [{startIndex.i}, {startIndex.j}], " +
                     $"EndIndex: [{startIndex.i}, {startIndex.j + count - 1}], " +
                     $"Length: {count}";
            }
        }

        private int[,] _matrix;
        private int longestCount;

        private List<LongestLine> longestLines;

        public LongestLineMatrix(int rows = 5, int columns = 6)
        {
            _matrix = new int[rows, columns];
            longestLines = new List<LongestLine>();

            Fill();
        }

        private void Fill()
        {
            var rand = new Random();
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {// чарівних констант треба уникати
                    _matrix[i, j] = rand.Next(0, 17);
                }
            }
        }
// ToString Замість цього методу...
        public void PrintMatrix()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write(_matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void Find()
        {
            int count = 1;
            int longestCount = 1;

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 1; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] != _matrix[i, j - 1])
                        count = 0;

                    count++;

                    if (count > longestCount)
                    {
                        longestCount = count;

                        longestLines.Clear();
                        longestLines.Add(new LongestLine(_matrix[i, j + 1 - count], count, new Index(i, j + 1 - count)));
                    }
                    else if (count == longestCount && longestCount > 1)
                        longestLines.Add(new LongestLine(_matrix[i, j + 1 - count], longestCount, new Index(i, j + 1 - count)));
                }
                count = 1;
            }

            this.longestCount = longestCount;
        }

        public override string ToString()
        {
            if (longestCount == 0) Find();
// Точку вже треба розуміти як лінію міри 1.
            
            if (longestLines.Count == 0) return "Nothing found";

            var sb = new StringBuilder();
            foreach (LongestLine ll in longestLines)
            {
                sb.Append(ll.ToString() + "\n");
            }

            return sb.ToString();
        }
    }
}
