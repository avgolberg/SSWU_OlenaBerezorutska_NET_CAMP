using System;
using System.Linq;

namespace UniqueWords
{// Оцінка за завдання 98 балів.
    class Program
    {
        static void Main(string[] args)
        {
            UniqueWords unique = new UniqueWords("Sample text is  text, also (we need) to use text!");
            Console.WriteLine(unique);

            foreach (var word in unique.GetUniqueWords().Take(4))
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }
    }
}
