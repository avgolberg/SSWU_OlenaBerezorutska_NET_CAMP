using System;

namespace WorkWithText
{//По першій задачі. У Вас ніяким чином класи башта та користувач не зв'язані. Але користувач має знати з якої башти він бере воду.Чи цей зв'язок має здійснювати симулятор. 
    /Але в будь-якому варіанті це має відбуватись. Не ясно також, коли мав би включатись насос, де мала б відбуватись перекриття насосу. І хто мав би відображати користувачеві все,що може зробити він.
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
