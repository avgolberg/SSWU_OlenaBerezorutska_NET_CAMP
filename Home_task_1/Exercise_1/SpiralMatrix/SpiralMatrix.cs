using System.Text;

namespace SpiralMatrix
{
    internal enum SpiralMatrixDirection
    {
        Down, Right
    }
    internal class SpiralMatrix
    {
        private int _rows;
        private int _columns;
        private int[,] _matrix;
        public SpiralMatrixDirection Direction { get; set; }

        public SpiralMatrix(int rows = 3, int columns = 4, SpiralMatrixDirection direction = SpiralMatrixDirection.Down)
        {
            _rows = rows;
            _columns = columns;
            Direction = direction;

            _matrix = new int[_rows, _columns];
        }

        public void Fill()
        {
            if (Direction == SpiralMatrixDirection.Down)
                FillDown();
            else if (Direction == SpiralMatrixDirection.Right)
                FillRight();
        }

        private void FillDown()
        {
            int rowsMin = 0;
            int rowsMax = _rows - 1;

            int columnsMin = 0;
            int columnsMax = _columns - 1;

            int i = 0, j = 0;
            int count = _rows * _columns;

            for (int n = 1; n <= count; n++)
            {
                //лаконічний код, але швидкодія в 4 циклах буде швидша
                _matrix[i, j] = n;

                if (j == columnsMin && i != rowsMax) i++;
                else if (i == rowsMax && j != columnsMax) j++;
                else if (j == columnsMax && i != rowsMin) i--;
                else if (i == rowsMin && j != columnsMin + 1) j--;
                else if (n != count)
                {
                    rowsMin++;
                    columnsMin++;
                    rowsMax--;
                    columnsMax--;
                    i++;
                }
            }
        }

        private void FillRight()
        {
            int rowsMin = 0;
            int rowsMax = _rows - 1;

            int columnsMin = 0;
            int columnsMax = _columns - 1;

            int i = 0, j = 0;
            int count = _rows * _columns;

            for (int n = 1; n <= count; n++)
            {
                _matrix[i, j] = n;

                if (i == rowsMin && j != columnsMax) j++;
                else if (j == columnsMax && i != rowsMax) i++;
                else if (i == rowsMax && j != columnsMin) j--;
                else if (j == columnsMin && i != rowsMin + 1) i--;
                else if (n != count)
                {
                    rowsMin++;
                    columnsMin++;
                    rowsMax--;
                    columnsMax--;
                    j++;
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    sb.Append(_matrix[i, j] + "\t");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
