using System;
using System.Text;

namespace WorkWithText
{
    class WorkWithText
    {
        private string _text;

        public WorkWithText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException($"{nameof(text)} can not be null or white space", nameof(text));

            _text = RemovePunctuations(text);
        }
        public string RemovePunctuations(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }

        public int? SecondIndexOfSubstring(string substring)
        {
            if (string.IsNullOrWhiteSpace(substring) || !_text.Contains(substring))
                return null;

            int index = _text.IndexOf(substring);
            index = _text.IndexOf(substring, index + substring.Length);
            return (index != -1) ? index : null;
        }

        public int WordsStartWithUpper()
        {
            var words = _text.Split();
            int count = 0;
            foreach (string word in words)
            {
                if (char.IsUpper(word, 0)) count++;
            }
            return count;
        }

        public bool ContainsDuplicateChars(string str)
        {
            bool containsDuplicates = false;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    containsDuplicates = true;
                    break;
                }
            }
            return containsDuplicates;
        }

        public string ReplaceWordsWithDuplicateChars(string replace)
        {
            var words = _text.Split();
            for (int i = 0; i < words.Length; i++)
            {
                if (ContainsDuplicateChars(words[i]))
                    words[i] = replace;
            }
            return string.Join(" ", words);
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
