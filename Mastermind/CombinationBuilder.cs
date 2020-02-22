using System;
using System.Linq;

namespace Mastermind
{
    public class CombinationBuilder
    {
        #region Member Variables
        private int _digitCount;
        private int _minDigit;
        private int _maxDigit;
        #endregion

        #region Setters
        public CombinationBuilder WithLength(int digitCount)
        {
            _digitCount = digitCount;
            return this;
        }

        public CombinationBuilder UsingDigitsBetween(int minDigit, int maxDigit)
        {
            _minDigit = minDigit;
            _maxDigit = maxDigit;

            return this;
        }

        public string Build()
        {
            Random rnd = new Random();

            return
                new String(
                    Enumerable
                        .Range(0, _digitCount)
                        .Select(_ => (char)(rnd.Next(_minDigit, _maxDigit + 1) + 48))
                        .ToArray());
        }
        #endregion

        #region Operators
        public static implicit operator string(CombinationBuilder builder) => builder.Build();
        #endregion
    }
}
