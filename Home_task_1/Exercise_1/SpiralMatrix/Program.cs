using System;

namespace SpiralMatrix
{
    class Program
    {
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
