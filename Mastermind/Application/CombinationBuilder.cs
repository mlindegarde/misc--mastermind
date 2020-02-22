using System;
using System.Linq;
using Mastermind.Model;

namespace Mastermind.Application
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

        public Combination Build()
        {
            Random rnd = new Random();

            return
                new Combination(
                    new String(
                        Enumerable
                            .Range(0, _digitCount)
                            .Select(_ => (char)(rnd.Next(_minDigit, _maxDigit + 1) + 48))
                            .ToArray()),
                    _minDigit,
                    _maxDigit);
        }
        #endregion

        #region Operators
        public static implicit operator Combination(CombinationBuilder builder) => builder.Build();
        #endregion
    }
}
