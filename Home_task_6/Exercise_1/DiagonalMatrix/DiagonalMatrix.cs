using System.Collections;
using System.Text;

namespace DiagonalMatrix
{// Щодо застосування інтерфейсу, то все чітко. Молодець.
    class DiagonalMatrix : IEnumerable
    {
        private int _size;
        private int[,] _matrix;

        public DiagonalMatrix(int[,] matrix)
        {
            _matrix = matrix;
            _size = _matrix.GetLength(0);
        }

        public DiagonalMatrix(int size)
        {
            _size = size;
            _matrix = new int[_size, _size];
            Fill();
        }

        private void Fill()
        {
            int row = 1;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _matrix[i, j] = row + j;
                }
                row += _size;
            }
        }

        public IEnumerator GetEnumerator()
        {
            int i = 0, j = 0;
            bool isUp = false;
            int counter = 0;
// Не помилка, але рекомендую для відомого числа повторень використовувати цикл for.
            while (counter < _size * _size)
            {
                if (isUp)
                {
                    while (i >= 0 && j < _size)
                    {
                        yield return _matrix[i, j];
                        ++counter;
                        ++j; --i;
                    }

                    if (i < 0 && j <= _size - 1)
                        i = 0;
// ви на кожній вітці перепитуєте чи це не останній елемент. Можна оптимізувати.
                    if (j == _size)
                    {
                        i += 2;
                        --j;
                    }
                }
                else
                {
                    while (j >= 0 && i < _size)
                    {
                        yield return _matrix[i, j];
                        ++counter;
                        ++i; --j;
                    }

                    if (j < 0 && i <= _size - 1)
                        j = 0;

                    if (i == _size)
                    {
                        j += 2;
                        --i;
                    }
                }
                isUp = !isUp;
            }
        }
    
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    sb.Append(_matrix[i, j] + "\t");
                }
                sb.Append("\n");
            }
            sb.Append("\n");

            foreach (var item in this)
            {
                sb.Append(item + " ");
            }
            return sb.ToString();
        }
    }
}
