using System.Collections.Generic;

namespace Mastermind.Model
{
    public class Safe
    {
        #region Member Variables
        private readonly string _combination;
        #endregion

        #region Constructor
        public Safe(string combination)
        {
            _combination = combination;
        }
        #endregion

        #region Methods
        public Result TryCombination(string guess)
        {
            return TryCombination(guess, _combination);
        }
        #endregion

        #region Static Methods
        public static Result TryCombination(string guess, string answer)
        {
            Result result = new Result();

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
                    if(!answerValues.Contains(c)) 
                        continue;

                    result.SortaRight++;
                    answerValues.Remove(c);
                }
            }

            return result;
        }
        #endregion
    }
}
