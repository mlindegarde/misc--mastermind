using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    public class Game
    {
        #region Member Variables
        private readonly string _answer;
        #endregion

        #region Constructor
        public Game()
        {
            Random rnd = new Random();

            _answer = 
                new string(new[]
                {
                    (char)(rnd.Next(1,7)+48),
                    (char)(rnd.Next(1,7)+48),
                    (char)(rnd.Next(1,7)+48),
                    (char)(rnd.Next(1,7)+48)
                });
        }
        #endregion

        #region Methods
        public Result CheckGuess(string guess)
        {
            return CheckGuess(guess, _answer);
        }
        #endregion

        #region Static Methods
        public static Result CheckGuess(string guess, string answer)
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
