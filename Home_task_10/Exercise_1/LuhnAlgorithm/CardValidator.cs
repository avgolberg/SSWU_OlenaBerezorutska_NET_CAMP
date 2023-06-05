using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LuhnAlgorithm
{
    class CardValidator
    {
        private HashSet<CardType> _cardTypes = new HashSet<CardType>(); // типи карток повинні бути унікальними з можливістю змінювати правила
        private List<Card> _potentialCards = new List<Card>();

        public CardValidator(string path, string separator = "# ")
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException($"{nameof(path)} can not be null or white space", nameof(path));

            if (!File.Exists(path))
                throw new ArgumentException("File does not exist", nameof(path));

            List<string> lines = new List<string>();
            lines.AddRange(File.ReadLines(path));
            if (lines.Count == 0)
                throw new ArgumentException($"File's content can not be empty");

            if (string.IsNullOrWhiteSpace(separator))
                throw new ArgumentException($"{nameof(separator)} can not be null or white space", nameof(path));

            AddStartCardTypes();
            Parse(lines, separator);
        }

        private void AddStartCardTypes()
        {
            _cardTypes.Add(new CardType("American Express", new List<int>() { 15 }, new List<string>() { "34", "37" }));
            _cardTypes.Add(new CardType("MasterCard", new List<int>() { 16 }, new List<string>() { "51", "52", "53", "54", "55" }));
            _cardTypes.Add(new CardType("Visa", new List<int>() { 13, 16 }, new List<string>() { "4" }));
        }

        private void Parse(List<string> lines, string separator)
        {
            string[] split;
            foreach (string line in lines)
            {
                split = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                var cardTypeName = split[0].Trim();

                var cardNumberWithQuotes = split[1].Split(" ")[2];
                if (string.IsNullOrWhiteSpace(cardNumberWithQuotes))
                    throw new ArgumentException($"Card number can not be empty");

                var cardNumber = cardNumberWithQuotes.Substring(1, cardNumberWithQuotes.Length - 2);

                //перевірка, що всі символи є числами у конструкторі картки 
                Card card = new Card(cardNumber, cardTypeName);
                _potentialCards.Add(card);
            }
        }
        public string GetCardTypes()
        {
            return string.Join("\n", _cardTypes);
        }

        public void AddCardType(CardType cardType)
        {
            _cardTypes.Add(new CardType(cardType));
        }

        public void RemoveCardType(string name)
        {
            _cardTypes.RemoveWhere(c => c.Name.Equals(name));
        }

        public bool ChangeCardTypeStartsWith(string name, List<string> startsWith)
        {
            var cardType = _cardTypes.FirstOrDefault(c => c.Name.Equals(name));
            if (cardType == null)
                return false;

            cardType.SetStartsWith(startsWith);
            return true;
        }

        public bool ChangeCardTypeDigitsCount(string name, List<int> digitsCount)
        {
            var cardType = _cardTypes.FirstOrDefault(c => c.Name.Equals(name));
            if (cardType == null)
                return false;

            cardType.SetDigitsCount(digitsCount);
            return true;
        }

        private bool CheckCard(string cardNumber) //LuhnAlgorithm
        {
            const int zeroAscii = 48; // '0'

            int digit;
            int sum = 0;
            bool isSecond = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                digit = cardNumber[i] - zeroAscii;
                //digit = int.Parse(cardNumber[i].ToString()); 

                if (isSecond)
                    digit *= 2;

                sum += digit % 10;
                sum += digit / 10;
                //sum += (digit > 9) ? digit - 9 : digit;

                isSecond = !isSecond;
            }
            return sum % 10 == 0;
        }
        private string GetCardType(string cardNumber)
        {
            if (CheckCard(cardNumber))
            {
                foreach (CardType cardType in _cardTypes)
                {
                    if (cardType.Check(cardNumber))
                    {
                        return cardType.Name;
                    }
                }
            }
            return "-";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            int[] columnsSize = new int[] { -20, -10, -20, -20 };
            
            var columnPattern = new StringBuilder();
            for (int i = 0; i < columnsSize.Length; i++)
            {
                columnPattern.Append("{" + i + ", " + columnsSize[i] + "} ");
            }
            string pattern = columnPattern.ToString().Trim();

            sb.AppendLine(string.Format(pattern, "Номер картки", "Валідна", "Заданий тип", "Виявлений тип"));
            foreach (var card in _potentialCards)
                sb.AppendLine(string.Format(pattern, card.Number, CheckCard(card.Number), card.CardType, GetCardType(card.Number)));

            return sb.ToString();
        }
    }
}
