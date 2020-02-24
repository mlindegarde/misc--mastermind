using System;
using System.Collections.Generic;
using System.Text;
using Mastermind.Application;
using Mastermind.Model;

namespace Mastermind.Ai
{
    public class Solver
    {
        #region Methods
        public Solution Crack(Combination combination)
        {
            Solution solution = new Solution();

            List<string> possibilities = GenerateAllPossibilities(combination);

            string guess = GenerateInitialGuess(combination);

            while (!solution.HasAnswer)
            {
                Crack(combination, guess, solution, possibilities);

                guess = possibilities[0];
            }

            return solution;
        }

        private void Crack(Combination combination, string guess, Solution solution, List<string> possibilities)
        {
            GuessResult baseResult = combination.Try(guess);

            solution.Guesses.Add(guess);

            if (baseResult.WasRight)
            {
                solution.Answer = guess;
                return;
            }

            for (int i = 0; i < possibilities.Count; i++)
            {
                GuessResult result = combination.Try(guess, possibilities[i]);

                if(!result.HasSameIndicatorsAs(baseResult))
                {
                    possibilities.Remove(possibilities[i]);
                    i--;
                }
            }
        }
        #endregion

        #region Utility Methods
        private string GenerateInitialGuess(Combination combination)
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0, digit = 1; i < combination.Length; i++)
            {
                sb.Append(digit);

                if(i % 2 == 1)
                    digit++;
            }

            return sb.ToString();
        }

        private List<string> GenerateAllPossibilities(Combination combination)
        {
            List<string> solutions = new List<string>();
            Stack<char> currentSolution = new Stack<char>();

            for(int i = combination.MinimumDigit; i <= combination.MaximumDigit; i++)
            {
                currentSolution.Push((char)(48 + i));
                GenerateAllPossibilities(solutions, currentSolution, combination);
                currentSolution.Pop();
            }

            return solutions;
        }

        private void GenerateAllPossibilities(List<string> solutions, Stack<char> currentSolution, Combination combination)
        {
            for(int i = combination.MinimumDigit; i <= combination.MaximumDigit; i++)
            {
                currentSolution.Push((char)(48 + i));

                if(currentSolution.Count == combination.Length)
                    solutions.Add(new String(currentSolution.ToArray()));
                else
                    GenerateAllPossibilities(solutions, currentSolution, combination);

                currentSolution.Pop();
            }
        }
        #endregion
    }
}
