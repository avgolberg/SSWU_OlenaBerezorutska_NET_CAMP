using System;

namespace SpiralMatrix
{
    class Program
    {Вітаю. Перше завдання по створенню репозиторію Ви виконали.
        static void Main(string[] args)
        {
            var spiralMatrix = new SpiralMatrix(5, 6);
            spiralMatrix.Fill();
            Console.WriteLine(spiralMatrix);

            spiralMatrix.Direction = SpiralMatrixDirection.Right;
            spiralMatrix.Fill();
            Console.WriteLine(spiralMatrix);
        }
    }
}
