using System;
using System.Collections.Generic;
using System.Linq;

namespace LuhnAlgorithm
{
    public class CardType : IEquatable<CardType>
    {
        private string _name;
        public string Name => _name;

        private List<int> _digitsCount;
        private List<string> _startsWith;
        public CardType(string name, List<int> digitsCount, List<string> startsWith)
        {
            _name = name;
            SetDigitsCount(digitsCount);
            SetStartsWith(startsWith);
        }

        public CardType(CardType cardType)
        {
            if (cardType == null)
                throw new ArgumentNullException(nameof(cardType));

            _name = cardType._name;
            SetDigitsCount(cardType._digitsCount);
            SetStartsWith(cardType._startsWith);
        }

        public void SetDigitsCount(List<int> digitsCount)
        {
            _digitsCount = new List<int>(digitsCount);
        }

        public void SetStartsWith(List<string> startsWith)
        {
            _startsWith = new List<string>(startsWith);
        }

        public bool Check(string cardNumber)
        {
            if (!_digitsCount.Any(c => c == cardNumber.Length))
                return false;

            if (!_startsWith.Any(cardNumber.StartsWith))
                return false;

            return true;
        }

        public bool Equals(CardType other)
        {
            return _name.Equals(other._name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
