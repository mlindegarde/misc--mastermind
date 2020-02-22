using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    public class Game
    {
        #region Member Variables
        private readonly char[] _answer;
        #endregion

        #region Constructor
        public Game()
        {
            Random rnd = new Random();

            _answer = new[]
            {
                (char)(rnd.Next(1,7)+48),
                (char)(rnd.Next(1,7)+48),
                (char)(rnd.Next(1,7)+48),
                (char)(rnd.Next(1,7)+48)
            };
        }
        #endregion

        #region Methods
        public Result CheckGuess(char[] guess, char[] answer = null)
        {
            if(answer == null)
                answer = _answer;

            Result result = new Result();

            List<char> answerValues = new List<char>();
            List<char> guessValues = new List<char>();

            for (int i = 0; i < guess.Length; i++)
            {
                if (answer[i] == guess[i])
                    result.ExactlyRight++;
                else
                {
                    answerValues.Add(answer[i]);
                    guessValues.Add(guess[i]);
                }

                foreach (char c in guessValues)
                {
                    if (answerValues.Contains(c))
                    {
                        result.SortaRight++;
                        answerValues.Remove(c);
                    }
                }
            }

            return result;
        }
        #endregion
    }
}
