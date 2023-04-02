using System;

namespace WorkWithText
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string text = @"Parrot is a kind of bird. My Parrot preffer eatting seeds.";
                WorkWithText workWithText = new WorkWithText(text);
                Console.WriteLine($"Text is \"{workWithText}\"");

                Console.WriteLine($"Second index of substring \"Parrot\" is {workWithText.SecondIndexOfSubstring("Parrot")}");
                Console.WriteLine($"Count of words that start with uppercase letter is {workWithText.WordsStartWithUpper()}");
                Console.WriteLine($"Replaced words with duplicate chars by word \"Yes\": {workWithText.ReplaceWordsWithDuplicateChars("Yes")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error ocured");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
