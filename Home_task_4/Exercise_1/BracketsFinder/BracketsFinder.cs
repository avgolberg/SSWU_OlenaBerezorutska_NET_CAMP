using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BracketsFinder
{
    class BracketsFinder
    {
        private List<string> _lines = new List<string>();
        private List<List<string>> _sentences = new List<List<string>>();
        private List<int> _sentencesWithBrackets = new List<int>();

        public BracketsFinder(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException($"{nameof(path)} can not be null or white space", nameof(path));

            if (!File.Exists(path))
                throw new ArgumentException("File does not exist", nameof(path));

            _lines.AddRange(File.ReadLines(path));
        }

        public void FindSentencesWithBrackets()
        {
            List<string> currentSentences = new List<string>();
            for (int i = 0; i < _lines.Count; i++)
            {
                currentSentences.AddRange(_lines[i].Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
            }

            List<string> sentence = new List<string>() { currentSentences[0] };
            for (int i = 1; i < currentSentences.Count; i++)
            {
                if (char.IsUpper(currentSentences[i], 0))
                {
                    _sentences.Add(sentence);
                    sentence = new List<string>();
                }
                sentence.Add(currentSentences[i]);
            }
            _sentences.Add(sentence);

            for (int i = 0; i < _sentences.Count; i++)
            {
                for (int j = 0; j < _sentences[i].Count; j++)
                {
                    if (_sentences[i][j].Contains("("))
                    {
                        _sentencesWithBrackets.Add(i);
                        break;
                    }
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (string line in _lines)
            {
                sb.Append(line + "\n");
            }
            sb.Append("\n");

            if (_sentencesWithBrackets.Count == 0) FindSentencesWithBrackets();

            foreach (int i in _sentencesWithBrackets)
            {
                foreach (string item in _sentences[i])
                {
                    sb.Append(item + " ");
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
