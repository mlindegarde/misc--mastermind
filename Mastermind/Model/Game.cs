using System.Collections.Generic;
using Mastermind.Application;

namespace Mastermind.Model
{
    public class Game
    {
        #region Properties
        public Combination Combination { get; }
        public List<Result> History { get; }
        #endregion

        #region Wrapper Properties
        public int GuessCount => History.Count;
        #endregion

        #region Constructor
        public Game(Settings settings)
        {
            History = new List<Result>();
            Combination =
                new CombinationBuilder()
                    .WithLength(settings.CombinationLength)
                    .UsingDigitsBetween(1, 6);
        }
        #endregion

        #region Methods
        public Result TryCombination(string guess)
        {
            Result result = Combination.Try(guess);

            History.Add(result);
            return result;
        }
        #endregion
    }
}
