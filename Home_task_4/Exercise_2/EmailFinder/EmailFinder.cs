using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmailFinder
{
    class EmailFinder
    {
        private string _text;
        private List<string> _potentialEmails = new List<string>();

        public EmailFinder(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException($"{nameof(path)} can not be null or white space", nameof(path));

            if (!File.Exists(path))
                throw new ArgumentException("File does not exist", nameof(path));

            _text = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(_text))
                throw new ArgumentException($"{nameof(_text)} can not be null or white space", nameof(_text));

            GetPotentialEmails();
        }

        private void GetPotentialEmails()
        {
            var split = _text.Replace(Environment.NewLine, " ").Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //перевірка, чи не закінчується потенціальна адреса на розділові знаки, що не відділяються пробілом
            var punctuation = new char[] { '.', ',', ';', ':', '?', '!' };
            foreach (string item in split)
            {
                if (item.Contains('@'))
                {
                    if (item.EndsWith("..."))
                        _potentialEmails.Add(item.Substring(0, item.Length - "...".Length));
                    else if (punctuation.Contains(item[item.Length - 1]))
                        _potentialEmails.Add(item.Substring(0, item.Length - 1));
                    else _potentialEmails.Add(item);
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            int lastAtIndex = email.LastIndexOf('@');
            if (lastAtIndex == 0)
                return false;

            string local = email.Substring(0, lastAtIndex);
            string domain = email.Substring(lastAtIndex + 1);

            //дужки
            if (!CorrectBrackets(local) || !CorrectBrackets(domain))
                return false;

            //лапки у локальній частині
            bool hasRightQuotes = false;
            if (local.Contains('\"'))
            {
                if (local.CharCount('\"') == 2 && local.StartsWith("\"") && local.EndsWith("\""))
                    hasRightQuotes = true;
                else
                    return false;
            }

            if (!hasRightQuotes)
            {
                if (local.CharCount('@') > 1)
                    return false;

                if (local.StartsWith('.') || local.EndsWith('.') || local.Contains(".."))
                    return false;

                var localSymbols = new char[] { '\\', ';', ':', ',', '<', '>', '[', ']', ' ' };
                if (local.IndexOfAny(localSymbols) != -1)
                    return false;
            }

            //домен
            if (domain.StartsWith("-") || domain.EndsWith("-"))
                return false;

            if (domain.StartsWith('.') || domain.EndsWith('.') || domain.Contains(".."))
                return false;

            if (domain.HasSpecialChars(new char[] { '.', '-', '(', ')' }))
                return false;

            //довжина
            if (local.Length > 64 || domain.Length > 253 || (local.Length + domain.Length) > 256)
                return false;

            return true;
        }

        private bool CorrectBrackets(string str)
        {
            var brackets = new char[] { '(', ')' };

            if (str.IndexOfAny(brackets) != -1 && !BracketsBalanced(str))
                return false;

            return true;
        }

        private bool BracketsBalanced(string str)
        {
            if (!str.Contains('(')) return false;

            List<char> brackets = new List<char>();
            foreach (char c in str)
            {
                if (c == '(')
                    brackets.Add(c);

                else if (brackets.Count == 0)
                    continue;

                else if (brackets[brackets.Count - 1] == '(' && c == ')')
                    brackets.RemoveAt(brackets.Count - 1);
            }
            return brackets.Count == 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (string item in _potentialEmails)
                sb.Append(string.Format("{1,-5} -> {0} ", item, IsValidEmail(item)) + "\n");

            return sb.ToString();
        }
    }

    public static class StringExtension
    {
        public static int CharCount(this string str, char ch)
        {
            int counter = 0;
            foreach (char c in str)
            {
                if (c == ch)
                    counter++;
            }
            return counter;
        }

        /// <summary>
        /// Сheck string for special characters ignoring passed ones
        /// </summary>
        public static bool HasSpecialChars(this string str, params char[] chars)
        {
            foreach (char c in str)
            {
                if (chars.Contains(c))
                    continue;

                if (!char.IsLetterOrDigit(c))
                    return true;
            }
            return false;
        }
    }
}
