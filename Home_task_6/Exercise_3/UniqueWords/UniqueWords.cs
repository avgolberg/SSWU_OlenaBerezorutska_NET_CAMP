using System;
using System.Collections.Generic;
using System.Text;

namespace UniqueWords
{// чудово!
    class UniqueWords
    {
        private string _text;
        public UniqueWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException($"{nameof(text)} can not be null or white space", nameof(text));

            _text = text;
        }

        public IEnumerable<string> GetUniqueWords() 
        {
            var uniques = new List<string>();
            var word = new StringBuilder();

            //Реалізуємо власний "Split", викорстовуючи yield, щоб не обробляти увесь рядок за раз, а лише за необхідністю
            foreach (var character in _text)
            {
                if (char.IsPunctuation(character) || char.IsWhiteSpace(character))
                {
                    if (word.Length > 0)
                    {
                        if (!uniques.Contains(word.ToString()))
                        {
                            uniques.Add(word.ToString());
                            yield return word.ToString();
                        }
                        word.Clear();
                    }
                }
                else
                {
                    word.Append(character);
                }
            }

            if (word.Length > 0 && !uniques.Contains(word.ToString()))
            {
                yield return word.ToString();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in GetUniqueWords())
            {
                sb.Append(item + " ");
            }
            return sb.ToString();
        }

    }
}
