using System;
using System.IO;

namespace MergeSort
{
    class IntegersGenerator
    {
        int[] _array;
        public IntegersGenerator(string path, int count, int min = 0, int max = 100)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path can not be null or white space");

            if (count < 0)
                throw new ArgumentException("Count can not be negative");

            if (min > max)
                throw new ArgumentException("Min value can not be greater than max value");

            GenerateArray(count, min, max);
            WriteToFile(path);
        }

        private void GenerateArray(int count, int min, int max)
        {
            _array = new int[count];
            Random random = new Random();
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = random.Next(min, max);
            }
        }
        private void WriteToFile(string path)
        {
            File.WriteAllText(path, string.Join("\n", _array));
        }
    }
}
