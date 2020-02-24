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
        public GuessResult Try(string guess)
        {
            return Try(guess, _value);
        }

        public GuessResult Try(string guess, string answer)
        {
            GuessResult result = new GuessResult();

            List<char> answerValues = new List<char>();
            List<char> guessValues = new List<char>();

            for (int i = 0; i < guess.Length; i++)
            {
                if (answer[i] != guess[i])
                {
                    answerValues.Add(answer[i]);
                    guessValues.Add(guess[i]);
                }
                else
                    result.ExactlyRight++;

                foreach (char c in guessValues)
                {
                    if(answerValues.Contains(c))
                    {
                        result.SortaRight++;
                        answerValues.Remove(c);
                    }
                    else
                        result.CompletelyWrong++;

                }
            }

            return result;
        }

        public string GetAnswer() => _value;
        #endregion
    }
}
