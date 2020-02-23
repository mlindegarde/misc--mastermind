using System.Collections.Generic;

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
        public Result Try(string guess)
        {
            return Try(guess, _value);
        }

        public Result Try(string guess, string answer)
        {
            Result result = new Result(guess);

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
        #endregion
    }
}
