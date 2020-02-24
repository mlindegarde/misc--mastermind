using System.Collections.Generic;
using Mastermind.Application;

namespace Mastermind.Model
{
    public class Combination
    {
        #region Member Variables
        private readonly string _value;
        #endregion

        #region Properties
        public int MinimumDigit { get; set; }
        public int MaximumDigit { get; set; }
        public int Length { get; set; }
        #endregion

        #region Constructor
        public Combination(string value, int minDigit, int maxDigit)
        {
            _value = value;

            MinimumDigit = minDigit;
            MaximumDigit = maxDigit;
            Length = value.Length;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Used to test guess provided by users.
        /// </summary>
        /// <param name="guess">User submitted guess</param>
        /// <returns>A complex object indicating outcome of guess</returns>
        public GuessResult Try(string guess)
        {
            return Try(guess, _value);
        }

        /// <summary>
        /// Used to test guesses from the Solver implementation.
        /// </summary>
        /// <param name="guess">Guess from Solver</param>
        /// <param name="answer">The hypothetical answer</param>
        /// <returns>A complex object indicating outcome of guess</returns>
        public GuessResult Try(string guess, string answer)
        {
            GuessResult result = new GuessResult();

            // We need to make sure that we successfully handle duplicate digits
            // in the possible answer and guess.  To handle that we add any digits
            // that are not perfect matches to the two lists below.
            List<char> answerValues = new List<char>();
            List<char> guessValues = new List<char>();

            for (int i = 0; i < guess.Length; i++)
            {
                if (answer[i] != guess[i])
                {
                    // Not a perfect answer, Add to lists for a later check.
                    answerValues.Add(answer[i]);
                    guessValues.Add(guess[i]);
                }
                else
                    result.ExactlyRight++;
            }

            foreach (char c in guessValues)
            {
                if(answerValues.Contains(c))
                {
                    result.SortaRight++;

                    // This is how we handle duplicates.  Once we've used up a given
                    // digit we remove it from the list of potential answers.
                    answerValues.Remove(c);
                }
                else
                    result.CompletelyWrong++;
            }

            return result;
        }

        public string GetAnswer() => _value;
        #endregion
    }
}
