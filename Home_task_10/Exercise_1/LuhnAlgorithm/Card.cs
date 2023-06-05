using System;
using System.Linq;

namespace LuhnAlgorithm
{
    public class Card
    {
        public string Number { get; private set; }
        public string CardType { get; private set; }

        public Card(string number, string cardType = "")
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException($"Card number can not be empty");

            if (!number.All(char.IsDigit))
                throw new ArgumentException($"Card number can not contain non digits characters");

            Number = number;
            CardType = cardType;
        }
        public override string ToString()
        {
            return Number + " " + CardType;
        }
    }
}
