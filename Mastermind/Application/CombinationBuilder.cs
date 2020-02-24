using System;
using System.Linq;
using Mastermind.Model;

namespace Mastermind.Application
{
    /// <summary>
    /// This class provides a more declarative way to build the Combination object.
    /// </summary>
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

            // Randomly generate a new combination given the parameters that have
            // been configured.  Random comment, other languages have much better
            // range support than C#.
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
        // A convenience method that makes it so that we don't have to explicitly
        // call the build method.
        public static implicit operator Combination(CombinationBuilder builder) => builder.Build();
        #endregion
    }
}
