using System;

namespace Tensor
{
    class Program
    {
        static void Main(string[] args)
        {
            var tensor = new Tensor(1);
            tensor.Fill(5);
            Console.WriteLine(tensor);
            Console.WriteLine("Elements: " + tensor.Count);
            Console.WriteLine();

            tensor = new Tensor(2, 3);
            Console.WriteLine(tensor);
            Console.WriteLine("Elements: " + tensor.Count);
            Console.WriteLine();

            tensor = new Tensor(2, 3, 3);
            Console.WriteLine(tensor);
            Console.WriteLine("Elements: " + tensor.Count);
            Console.WriteLine("tensor[0, 2, 1]: " + tensor[0, 2, 1]);
            Console.WriteLine();

            tensor = new Tensor(2, 3, 3, 4);
            Console.WriteLine(tensor);
            Console.WriteLine("Elements: " + tensor.Count);
            Console.WriteLine();
        }
    }
}
